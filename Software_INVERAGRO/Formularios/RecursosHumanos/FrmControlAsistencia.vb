Imports CapaNegocio
Imports CapaObjetos
Imports ExcelDataReader
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Globalization
Imports System.IO
Imports System.Text

Public Class FrmControlAsistencia

    'Variables
    Private _idPlantel As Integer
    Dim cn As New cnControlAsistencia

    Dim rangoInicioOperario As Integer = 0
    Dim rangoFinOperario As Integer = 0

    Dim totalAsistenciaCompleta As Integer = 0
    Dim totalInasistencias As Integer = 0
    Dim totalIncompletas As Integer = 0
    Dim totalConHorasExtras As Integer = 0
    Dim totalConPermisoMedico As Integer = 0
    Dim totalConDescanso As Integer = 0
    Dim totalConFeriadoTrabajado As Integer = 0
    Dim totalConFeriadoNoTrabajado As Integer = 0

    Dim observacion As String = "Sin observación"
    Dim horasExtras As String = "0"
    Dim pagoEspecial As String = "0"
    Dim horasTrabajadasTotal As String = "0"
    Dim horasLaboradas As String = "0"
    Dim horasRefrigerio As Integer = 1
    Dim permisoMedico As String = "NO"
    Dim feriadoTrabajado As String = "SIN ASIGNAR"
    Dim horasExtrasMarranas As String = "0"

    Dim fechaPeriodoExcel As String
    Dim fechaActualExcel As String

    Dim fecha As DateTime
    Dim anio As Integer
    Dim mes As Integer
    Dim dia As Integer
    Dim ultimoDiaRegistro As Integer
    Dim ultimoDiaRegistroEventual As Integer
    Dim mesEventual As Integer

    Dim dt As DataTable
    Dim table As DataTable
    Dim dtTrabajadores As New DataTable()
    Dim diasEnElMes As Integer
    Dim entrada As String = ""
    Dim salida As String = ""
    Dim horariosTrabajadores As New Dictionary(Of String, List(Of (String, String, String, String, String, String, Integer, String, String, String)))()
    Dim horariosTrabajadoresEventuales As New Dictionary(Of String, List(Of (String, String, String, String, String, String, Integer, String, String, String)))()

    Dim listaHorariosString As New StringBuilder()

    ' Variable para rastrear si se ha dado click al boton generar planilla
    Private generadoEnPlanilla As Boolean = False
    Private generadoEnOperario As Boolean = False
    Private generadoQuincenaEventual As Boolean = False

    Public idPlantelSeleccionado As Integer = 0

    Private Sub FrmControlAsistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1800, 900)
        cbListaMeses.SelectedIndex = DateTime.Now.Month - 1
        rbPlanilla.Checked = True
        InicializarDtgAsistencia()
        ListarPlanteles()
        ObtenerAnios()
        cbxListarPlanteles.Value = idPlantelSeleccionado
        cbxListarPlanteles.ReadOnly = True
        clsBasicas.Formato_Tablas_Grid_Asistencia(dtgListado)
    End Sub

    ' Botones
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarRrhhCtrlasist.Click
        Try
            If dtgListado.Rows.Count = 0 Then
                msj_advert("No hay datos para guardar.")
                Return
            End If

            If VerificacionHorario() Then
                msj_advert("No se puede guardar. Hay datos incompletos por rellenar.")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR LA ASISTENCIA DE LOS TRABAJADORES?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            If generadoEnPlanilla Then
                _idPlantel = 11
            Else
                _idPlantel = cbxListarPlanteles.Value
            End If

            Dim mesCb As Integer = cbListaMeses.SelectedIndex + 1
            Dim idHorario As Integer
            Dim errorEncontrado As Boolean = False
            Dim mensajeError As String = ""

            Dim tipoSeleccionado As String = ""
            Dim tipoPeriodo As String = ""
            Dim MensajeBgWk As String = ""

            Dim anioSeleccionado As Integer
            Dim mesSeleccionado As Integer
            Dim diaSeleccionado As Integer

            If rbEventual.Checked Then
                tipoSeleccionado = "EVENTUAL"
                anioSeleccionado = CInt(CmbAnios.SelectedItem)
                diaSeleccionado = ultimoDiaRegistroEventual

                If generadoQuincenaEventual Then
                    mesSeleccionado = mesCb
                    Dim ultimoDiaMes As Integer = DateTime.DaysInMonth(anioSeleccionado, mesSeleccionado)
                    If diaSeleccionado >= 1 And diaSeleccionado <= 15 Then
                        tipoPeriodo = "QUINCENA 1"
                    ElseIf diaSeleccionado >= 16 And diaSeleccionado <= ultimoDiaRegistroEventual Then
                        tipoPeriodo = "QUINCENA 2"
                    End If
                Else
                    mesSeleccionado = mesEventual
                    tipoPeriodo = "SEMANA"
                End If
            ElseIf rbPlanilla.Checked Then
                    If generadoEnPlanilla Then
                    tipoSeleccionado = "PLANILLA"
                    tipoPeriodo = "MENSUAL"
                    anioSeleccionado = CInt(CmbAnios.SelectedItem)
                    mesSeleccionado = mesCb
                    diaSeleccionado = ultimoDiaRegistroEventual
                ElseIf generadoEnOperario Then
                    tipoSeleccionado = "PLANILLA"
                    mesSeleccionado = mesCb
                    anioSeleccionado = CInt(CmbAnios.SelectedItem)
                    Dim ultimoDiaMes As Integer = DateTime.DaysInMonth(anioSeleccionado, mesSeleccionado)
                    diaSeleccionado = ultimoDiaRegistroEventual

                    ' Determinar el tipo de periodo basado en el día seleccionado
                    If diaSeleccionado >= 1 And diaSeleccionado <= 15 Then
                        tipoPeriodo = "QUINCENA 1"
                    ElseIf diaSeleccionado >= 16 And diaSeleccionado <= ultimoDiaMes Then
                        tipoPeriodo = "QUINCENA 2"
                    End If
                Else
                    tipoSeleccionado = "PLANILLA"
                    anioSeleccionado = anio
                    mesSeleccionado = mes
                    diaSeleccionado = dia
                    Dim ultimoDiaMes As Integer = DateTime.DaysInMonth(anioSeleccionado, mesSeleccionado)

                    ' Determinar el tipo de periodo basado en el día seleccionado
                    If diaSeleccionado >= 1 And diaSeleccionado <= 15 Then
                        tipoPeriodo = "QUINCENA 1"
                    ElseIf diaSeleccionado >= 16 And diaSeleccionado <= ultimoDiaMes Then
                        tipoPeriodo = "QUINCENA 2"
                    End If
                End If
            End If

            For Each fila As UltraGridRow In dtgListado.Rows
                Dim dni As String = fila.Cells("ID").Value.ToString()

                If horariosTrabajadores.ContainsKey(dni) OrElse horariosTrabajadoresEventuales.ContainsKey(dni) Then
                    If horariosTrabajadores.ContainsKey(dni) Then
                        Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = horariosTrabajadores(dni)
                    End If

                    If horariosTrabajadoresEventuales.ContainsKey(dni) Then
                        Dim listaHorariosEventuales As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = horariosTrabajadoresEventuales(dni)
                    End If

                    Dim obj As New coControlAsistencia()
                    obj.UltimoDiaReg = diaSeleccionado
                    obj.idHorario = idHorario
                    obj.Lista_Asistencias = ObtenerListaHorariosString(horariosTrabajadores, dni, mesSeleccionado) 'mes

                    If rbEventual.Checked AndAlso Not generadoQuincenaEventual Then
                        Dim hayCruceMeses As Boolean = DetectarCruceMesesSimple(mesCb)

                        If hayCruceMeses Then
                            obj.Lista_Asistencias_Eventuales = ObtenerListaHorariosEventualesStringCruceMeses(horariosTrabajadoresEventuales, dni, mesCb)
                            Console.WriteLine($"CRUCE DE MESES detectado para DNI {dni} - mesEventual({mesEventual}) != mesBase({mesCb}) - Usando función CruceMeses")
                        Else
                            obj.Lista_Asistencias_Eventuales = ObtenerListaHorariosEventualesString(horariosTrabajadoresEventuales, dni, mesCb, diaSeleccionado)
                            Console.WriteLine($"SIN cruce de meses para DNI {dni} - mesEventual({mesEventual}) == mesBase({mesCb}) - Usando función normal")
                        End If
                    Else
                        ' Para otros casos (quincena eventual, etc.)
                        obj.Lista_Asistencias_Eventuales = If(generadoQuincenaEventual,
                        ObtenerListaHorariosStrinEventualQuincena(horariosTrabajadoresEventuales, dni, mesCb),
                        ObtenerListaHorariosEventualesString(horariosTrabajadoresEventuales, dni, mesCb, diaSeleccionado))
                    End If

                    Console.WriteLine("Lista de asistencias eventual: " & obj.Lista_Asistencias_Eventuales)
                    obj.Mes = mesSeleccionado 'mes
                    obj.Anio = anioSeleccionado 'anio
                    obj.IdUbicacion = _idPlantel
                    obj.IdUsuario = VariablesGlobales.VP_IdUser
                    obj.Tipo = tipoSeleccionado
                    obj.Tipoperiodo = tipoPeriodo

                    Console.WriteLine(mesSeleccionado)
                    Console.WriteLine(anioSeleccionado)
                    Console.WriteLine(_idPlantel)
                    Console.WriteLine(tipoSeleccionado)
                    Console.WriteLine(tipoPeriodo)

                    MensajeBgWk = cn.Cn_Mantenimiento(obj)
                    If obj.CodeError <> 0 Then
                        errorEncontrado = True
                        mensajeError = MensajeBgWk
                        Exit For
                    End If
                End If
            Next
            If errorEncontrado Then
                msj_advert(mensajeError)
            Else
                If generadoEnPlanilla Then
                    msj_ok(MensajeBgWk)
                    LimpiarAdministrativo()
                ElseIf generadoEnOperario Then
                    msj_ok(MensajeBgWk)
                    LimpiarOperario()
                ElseIf generadoQuincenaEventual Then
                    msj_ok(MensajeBgWk)
                    LimpiarEventual()
                Else
                    msj_ok(MensajeBgWk)
                    Limpiar()
                End If

            End If
        Catch ex As Exception
            msj_advert("Error al guardar los datos: " & ex.Message)
        End Try
    End Sub
    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Archivos Excel|*.xls;*.xlsx"
        openFileDialog.Title = "Selecciona un archivo Excel"

        If openFileDialog.ShowDialog() = DialogResult.OK Then

            tbRutaArchivoExcel.Text = openFileDialog.FileName
            Dim mes As Integer = ObtenerMesDelExcel(tbRutaArchivoExcel.Text)

            If mes >= 1 And mes <= 12 Then
                cbListaMeses.SelectedIndex = mes - 1
                Activar()
            End If
        End If
    End Sub
    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        LimpiarGrid()

        If String.IsNullOrEmpty(tbRutaArchivoExcel.Text) Then
            msj_advert("POR FAVOR, SELECCIONE UN ARCHIVO EXCEL PRIMERO")
            InicializarDtgAsistencia()
            Return
        End If

        Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
        Dim mesExcel As Integer = ObtenerMesDelExcel(tbRutaArchivoExcel.Text)

        If mesSeleccionado <> mesExcel Then
            msj_advert("El mes seleccionado no coincide con el mes del Reporte de Asistencia del Excel.")
            InicializarDtgAsistencia()
            Return
        End If

        Dim dtExcel As DataTable = LeerExcel(tbRutaArchivoExcel.Text, False)
        Dim obj As New coControlAsistencia
        obj.IdUbicacion = cbxListarPlanteles.Value
        obj.Anio = anio
        obj.Mes = mes
        obj.Dia = dia
        Dim mensaje As String = ""
        Try
            mensaje = cn.Cn_ConsultarAsistenciaExistente(obj)
            If obj.CodeError <> 0 Then
                msj_advert(mensaje)
                InicializarDtgAsistencia()
                Return
            End If
        Catch ex As Exception
            msj_advert("No se pudo verificar la asistencia existente")
            InicializarDtgAsistencia()
            Return
        End Try

        ObtenerTodosLosDNI(tbRutaArchivoExcel.Text)
        CargarDatosExcel()
        Desactivar()
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If rbEventual.Checked Then
            Dim f As New FrmBuscarTrabajador_Asis(Me)
            f.tipoTrabajador = "EVENTUAL"
            f.quincenaEventual = If(generadoQuincenaEventual, 1, 0)
            f.ShowDialog()

            If dtgListado.Rows.Count > 0 Then
                cbListaMeses.Enabled = False
                cbxListarPlanteles.ReadOnly = True
                CmbAnios.Enabled = False
                MostrarSemanasEnLabel(cbListaMeses.SelectedIndex + 1, CInt(CmbAnios.SelectedItem), labelSemanas)
            End If
        Else
            If generadoEnPlanilla Then
                Dim f As New FrmBuscarTrabajador_Asis(Me)
                f.tipoTrabajador = "PLANILLA"
                f.ShowDialog()
                If dtgListado.Rows.Count > 0 Then
                    cbListaMeses.Enabled = False
                    cbxListarPlanteles.ReadOnly = True
                    CmbAnios.Enabled = False
                    MostrarSemanasEnLabel(cbListaMeses.SelectedIndex + 1, CInt(CmbAnios.SelectedItem), labelSemanas)
                End If
            ElseIf generadoEnOperario Then
                Dim f As New FrmBuscarTrabajador_Asis(Me)
                f.tipoTrabajador = "PLANILLA"
                f.ShowDialog()
                If dtgListado.Rows.Count > 0 Then
                    cbListaMeses.Enabled = False
                    cbxListarPlanteles.ReadOnly = True
                    CmbAnios.Enabled = False
                    MostrarSemanasEnLabel(cbListaMeses.SelectedIndex + 1, CInt(CmbAnios.SelectedItem), labelSemanas)
                End If
            Else
                If dtgListado.Rows.Count > 0 Then
                    Dim f As New FrmBuscarTrabajador_Asis(Me)
                    f.tipoTrabajador = "PLANILLA"
                    f.ShowDialog()
                Else
                    msj_advert("Primero carga la tabla antes de agregar un nuevo trabajador")
                End If
            End If

        End If
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub cbMostrarCantidadHoras_CheckedChanged(sender As Object, e As EventArgs) Handles cbMostrarCantidadHoras.CheckedChanged
        Try
            If dtgListado.Rows.Count = 0 Then
                msj_advert("No hay datos para mostrar.")
                Return
            End If

            If cbMostrarHorasExtras.Checked AndAlso cbMostrarCantidadHoras.Checked Then
                msj_advert("Debes desactivar 'Mostrar Horas Extras' antes de activar 'Mostrar Cantidad Horas'.")
                cbMostrarCantidadHoras.Checked = False
                Return
            End If

            If rbEventual.Checked Then

                If generadoQuincenaEventual Then
                    Dim rangoInicio As Integer
                    Dim rangoFin As Integer

                    rangoInicio = rangoInicioOperario
                    rangoFin = rangoFinOperario

                    For Each fila As UltraGridRow In dtgListado.Rows
                        For Each celda As UltraGridCell In fila.Cells
                            If celda.Column.Key.StartsWith("Dia") Then
                                Dim dia As Integer = Integer.Parse(celda.Column.Key.Replace("Dia", ""))

                                If dia >= rangoInicio AndAlso dia <= rangoFin Then
                                    Dim idTrabajador As String = fila.Cells("ID").Value.ToString()

                                    If horariosTrabajadoresEventuales.ContainsKey(idTrabajador) Then
                                        Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = horariosTrabajadoresEventuales(idTrabajador)
                                        Dim entrada As String = listaHorarios(dia - 1).Item1
                                        Dim salida As String = listaHorarios(dia - 1).Item2
                                        Dim observacion As String = listaHorarios(dia - 1).Item3
                                        Dim horasExtras As String = listaHorarios(dia - 1).Item4
                                        Dim horasTrabajadas As String = listaHorarios(dia - 1).Item6
                                        Dim permisoMedico As String = listaHorarios(dia - 1).Item8
                                        Dim feriadoTrabajado As String = listaHorarios(dia - 1).Item9
                                        Dim horasExtrasMarranas As String = listaHorarios(dia - 1).Item10

                                        Dim totalHoras As Integer = Integer.Parse(horasTrabajadas)
                                        Dim totalHorasExtras As Double = Double.Parse(horasExtras)
                                        Dim totalHorasExtrasMarranas As Double = Double.Parse(horasExtrasMarranas)

                                        Dim sumatoriaTotal As Double = totalHoras + totalHorasExtras + horasExtrasMarranas

                                        If cbMostrarCantidadHoras.Checked Then

                                            If celda.Value.ToString() = "HEX" Then
                                                celda.Value = $"{sumatoriaTotal}"
                                            ElseIf celda.Value.ToString() = "A" Then
                                                celda.Value = $"{totalHoras}"
                                            ElseIf celda.Value.ToString() = "IN" Then
                                                celda.Value = "IN"
                                            ElseIf celda.Value.ToString() = "F" Then
                                                celda.Value = "F"
                                            ElseIf celda.Value.ToString() = "D" Then
                                                celda.Value = $"{sumatoriaTotal}"
                                            ElseIf celda.Value.ToString() = "V" Then
                                                celda.Value = $"{sumatoriaTotal}"
                                            ElseIf celda.Value.ToString() = "PM" Then
                                                celda.Value = $"{sumatoriaTotal}"
                                            ElseIf celda.Value.ToString() = "FT" Then
                                                celda.Value = $"{sumatoriaTotal}"
                                            ElseIf celda.Value.ToString() = "FNT" Then
                                                celda.Value = "FNT"
                                            End If

                                        Else
                                            Dim resultado As String = "F"

                                            If Not String.IsNullOrWhiteSpace(entrada) AndAlso Not String.IsNullOrWhiteSpace(salida) Then
                                                ' Prioridad 1: Permiso Médico
                                                If permisoMedico = "SI" Then
                                                    resultado = "PM"

                                                    ' Prioridad 2: Descanso o Vacaciones
                                                ElseIf observacion.IndexOf("DESCANSO", StringComparison.OrdinalIgnoreCase) >= 0 Then
                                                    resultado = "D"

                                                ElseIf observacion = "VACACIONES" Then
                                                    resultado = "V"

                                                    ' Prioridad 3: Feriado trabajado
                                                ElseIf feriadoTrabajado = "SI" Then
                                                    resultado = "FT"

                                                    ' Prioridad 4: Feriado NO trabajado
                                                ElseIf feriadoTrabajado = "NO" Then
                                                    resultado = "FNT"

                                                    ' Prioridad 5: Horas extras
                                                ElseIf totalHorasExtras > 0 Or totalHorasExtrasMarranas > 0 Then
                                                    resultado = "HEX"

                                                    ' Prioridad 6: Inasistencia parcial (trabajó menos de 8h)
                                                ElseIf totalHoras < 8 Then
                                                    resultado = "IN"

                                                    ' Prioridad 7: Asistencia normal
                                                Else
                                                    resultado = "A"
                                                End If
                                            ElseIf Not String.IsNullOrWhiteSpace(entrada) Or Not String.IsNullOrWhiteSpace(salida) Then
                                                resultado = "IN"
                                            Else
                                                resultado = "F"
                                            End If
                                            celda.Value = resultado
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    Next

                Else
                    For Each fila As UltraGridRow In dtgListado.Rows
                        Dim idTrabajador As String = fila.Cells("ID").Value.ToString()

                        ' Recorrer todas las columnas que empiezan con "Dia"
                        For Each celda As UltraGridCell In fila.Cells
                            If celda.Column.Key.StartsWith("Dia") Then
                                ' Obtener la fecha del nombre de la columna (formato dd-MM)
                                Dim fechaStr As String = celda.Column.Key.Replace("Dia", "")
                                Dim fecha As Date = Date.ParseExact(fechaStr, "dd-MM", Globalization.CultureInfo.InvariantCulture)

                                fecha = New Date(CInt(CmbAnios.SelectedItem), fecha.Month, fecha.Day)

                                If horariosTrabajadoresEventuales.ContainsKey(idTrabajador) Then
                                    Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = horariosTrabajadoresEventuales(idTrabajador)

                                    ' Calcular el índice basado en el día relativo al primer domingo del mes
                                    Dim primerDiaMes As New Date(CInt(CmbAnios.SelectedItem), fecha.Month, 1)
                                    Dim primerDomingo As Date = primerDiaMes
                                    While primerDomingo.DayOfWeek <> DayOfWeek.Sunday
                                        primerDomingo = primerDomingo.AddDays(1)
                                    End While

                                    ' Calcular el índice como la diferencia de días entre la fecha actual y el primer domingo
                                    Dim indice As Integer = (fecha - primerDomingo).Days

                                    Debug.WriteLine($"Procesando fecha: {fecha} - Índice: {indice}")

                                    Debug.WriteLine($"Fecha columna: {fecha}, Primer domingo: {primerDomingo}, Índice calculado: {indice}")

                                    If indice >= 0 AndAlso indice < listaHorarios.Count Then
                                        Dim entrada As String = listaHorarios(indice).Item1
                                        Dim salida As String = listaHorarios(indice).Item2
                                        Dim observacion As String = listaHorarios(indice).Item3
                                        Dim horasExtras As String = listaHorarios(indice).Item4
                                        Dim horasTrabajadas As String = listaHorarios(indice).Item6
                                        Dim permisoMedico As String = listaHorarios(indice).Item8
                                        Dim feriadoTrabajado As String = listaHorarios(indice).Item9
                                        Dim horasExtrasMarranas As String = listaHorarios(indice).Item10

                                        ' Comprobar si la celda tiene "-" y saltarla si es así
                                        If celda.Value?.ToString() = "-" Then
                                            Continue For
                                        End If

                                        Dim totalHoras As Integer = Integer.Parse(horasTrabajadas)
                                        Dim totalHorasExtras As Double = Double.Parse(horasExtras)
                                        Dim totalHorasExtrasMarranas As Double = Double.Parse(horasExtrasMarranas)

                                        Dim sumaTotal As Double = totalHoras + totalHorasExtras + totalHorasExtrasMarranas

                                        If cbMostrarCantidadHoras.Checked Then

                                            Debug.WriteLine($"Asignando celda Día: {fecha.Day}, Trabajador: {idTrabajador}, Valor previo: {celda.Value}, Nuevo valor: {totalHoras}")


                                            If celda.Value.ToString() = "HEX" Then
                                                celda.Value = $"{sumaTotal}"
                                            ElseIf celda.Value.ToString() = "A" Then
                                                celda.Value = $"{totalHoras}"
                                            ElseIf celda.Value.ToString() = "IN" Then
                                                celda.Value = "IN"
                                            ElseIf celda.Value.ToString() = "F" Then
                                                celda.Value = "F"
                                            ElseIf celda.Value.ToString() = "D" Then
                                                celda.Value = $"{sumaTotal}"
                                            ElseIf celda.Value.ToString() = "V" Then
                                                celda.Value = $"{sumaTotal}"
                                            ElseIf celda.Value.ToString() = "PM" Then
                                                celda.Value = $"{sumaTotal}"
                                            ElseIf celda.Value.ToString() = "FT" Then
                                                celda.Value = $"{sumaTotal}"
                                            ElseIf celda.Value.ToString() = "FNT" Then
                                                celda.Value = "FNT"
                                            End If
                                        Else
                                            Dim resultado As String = "F"

                                            If Not String.IsNullOrWhiteSpace(entrada) AndAlso Not String.IsNullOrWhiteSpace(salida) Then

                                                ' Prioridad 1: Permiso Médico
                                                If permisoMedico = "SI" Then
                                                    resultado = "PM"

                                                    ' Prioridad 2: Descanso o Vacaciones
                                                ElseIf observacion.IndexOf("DESCANSO", StringComparison.OrdinalIgnoreCase) >= 0 Then
                                                    resultado = "D"

                                                ElseIf observacion = "VACACIONES" Then
                                                    resultado = "V"

                                                    ' Prioridad 3: Feriado trabajado
                                                ElseIf feriadoTrabajado = "SI" Then
                                                    resultado = "FT"

                                                    ' Prioridad 4: Feriado NO trabajado
                                                ElseIf feriadoTrabajado = "NO" Then
                                                    resultado = "FNT"

                                                    ' Prioridad 5: Horas extras
                                                ElseIf totalHorasExtras > 0 Or totalHorasExtrasMarranas > 0 Then
                                                    resultado = "HEX"

                                                    ' Prioridad 6: Inasistencia parcial (trabajó menos de 8h)
                                                ElseIf totalHoras < 8 Then
                                                    resultado = "IN"

                                                    ' Prioridad 7: Asistencia normal
                                                Else
                                                    resultado = "A"
                                                End If

                                            ElseIf Not String.IsNullOrWhiteSpace(entrada) Or Not String.IsNullOrWhiteSpace(salida) Then
                                                resultado = "IN"
                                            Else
                                                resultado = "F"
                                            End If
                                            celda.Value = resultado
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    Next
                End If
            Else
                Dim rangoInicio As Integer
                Dim rangoFin As Integer

                If rbPlanilla.Checked Or rbEventualPlanilla.Checked Then
                    If generadoEnPlanilla Then
                        rangoInicio = 1
                        rangoFin = ultimoDiaRegistroEventual
                    ElseIf generadoEnOperario Then
                        rangoInicio = rangoInicioOperario
                        rangoFin = rangoFinOperario
                    Else
                        If ultimoDiaRegistro > 0 Then
                            rangoInicio = ultimoDiaRegistro + 1
                            rangoFin = dia
                        Else
                            rangoInicio = 1
                            rangoFin = dia
                        End If
                    End If
                End If

                For Each fila As UltraGridRow In dtgListado.Rows
                    For Each celda As UltraGridCell In fila.Cells
                        If celda.Column.Key.StartsWith("Dia") Then
                            Dim dia As Integer = Integer.Parse(celda.Column.Key.Replace("Dia", ""))

                            If dia >= rangoInicio AndAlso dia <= rangoFin Then
                                Dim idTrabajador As String = fila.Cells("ID").Value.ToString()

                                If horariosTrabajadores.ContainsKey(idTrabajador) Then
                                    Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = horariosTrabajadores(idTrabajador)
                                    Dim entrada As String = listaHorarios(dia - 1).Item1
                                    Dim salida As String = listaHorarios(dia - 1).Item2
                                    Dim observacion As String = listaHorarios(dia - 1).Item3
                                    Dim horasExtras As String = listaHorarios(dia - 1).Item4
                                    Dim horasTrabajadas As String = listaHorarios(dia - 1).Item6
                                    Dim permisoMedico As String = listaHorarios(dia - 1).Item8
                                    Dim feriadoTrabajado As String = listaHorarios(dia - 1).Item9
                                    Dim horasExtrasMarranas As String = listaHorarios(dia - 1).Item10

                                    Dim totalHoras As Integer = Integer.Parse(horasTrabajadas)
                                    Dim totalHorasExtras As Double = Double.Parse(horasExtras)
                                    Dim totalHorasExtrasMarranas As Double = Double.Parse(horasExtrasMarranas)

                                    Dim sumatoriaTotal As Double = totalHoras + totalHorasExtras + totalHorasExtrasMarranas

                                    If cbMostrarCantidadHoras.Checked Then

                                        If celda.Value.ToString() = "HEX" Then
                                            celda.Value = $"{sumatoriaTotal}"
                                        ElseIf celda.Value.ToString() = "A" Then
                                            celda.Value = $"{totalHoras}"
                                        ElseIf celda.Value.ToString() = "IN" Then
                                            celda.Value = "IN"
                                        ElseIf celda.Value.ToString() = "F" Then
                                            celda.Value = "F"
                                        ElseIf celda.Value.ToString() = "D" Then
                                            celda.Value = $"{sumatoriaTotal}"
                                        ElseIf celda.Value.ToString() = "V" Then
                                            celda.Value = $"{sumatoriaTotal}"
                                        ElseIf celda.Value.ToString() = "PM" Then
                                            celda.Value = $"{sumatoriaTotal}"
                                        ElseIf celda.Value.ToString() = "FT" Then
                                            celda.Value = $"{sumatoriaTotal}"
                                        ElseIf celda.Value.ToString() = "FNT" Then
                                            celda.Value = "FNT"
                                        End If

                                    Else
                                        Dim resultado As String = "F"

                                        If Not String.IsNullOrWhiteSpace(entrada) AndAlso Not String.IsNullOrWhiteSpace(salida) Then
                                            ' Prioridad 1: Permiso Médico
                                            If permisoMedico = "SI" Then
                                                resultado = "PM"

                                                ' Prioridad 2: Descanso o Vacaciones
                                            ElseIf observacion.IndexOf("DESCANSO", StringComparison.OrdinalIgnoreCase) >= 0 Then
                                                resultado = "D"

                                            ElseIf observacion = "VACACIONES" Then
                                                resultado = "V"

                                                ' Prioridad 3: Feriado trabajado
                                            ElseIf feriadoTrabajado = "SI" Then
                                                resultado = "FT"

                                                ' Prioridad 4: Feriado NO trabajado
                                            ElseIf feriadoTrabajado = "NO" Then
                                                resultado = "FNT"

                                                ' Prioridad 5: Horas extras
                                            ElseIf totalHorasExtras > 0 Or totalHorasExtrasMarranas > 0 Then
                                                resultado = "HEX"

                                                ' Prioridad 6: Inasistencia parcial (trabajó menos de 8h)
                                            ElseIf totalHoras < 8 Then
                                                resultado = "IN"

                                                ' Prioridad 7: Asistencia normal
                                            Else
                                                resultado = "A"
                                            End If
                                        ElseIf Not String.IsNullOrWhiteSpace(entrada) Or Not String.IsNullOrWhiteSpace(salida) Then
                                            resultado = "IN"
                                        Else
                                            resultado = "F"
                                        End If
                                        celda.Value = resultado
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next
            End If


        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbMostrarHorasExtras_CheckedChanged(sender As Object, e As EventArgs) Handles cbMostrarHorasExtras.CheckedChanged

        Try
            If dtgListado.Rows.Count = 0 Then
                msj_advert("No hay datos para mostrar.")
                Return
            End If

            If cbMostrarCantidadHoras.Checked AndAlso cbMostrarHorasExtras.Checked Then
                msj_advert("Debes desactivar 'Mostrar Cantidad Horas' antes de activar 'Mostrar Horas Extras'.")
                cbMostrarHorasExtras.Checked = False
                Return
            End If

            If rbEventual.Checked Then
                If generadoQuincenaEventual Then

                    Dim rangoInicio As Integer
                    Dim rangoFin As Integer

                    rangoInicio = rangoInicioOperario
                    rangoFin = rangoFinOperario

                    For Each fila As UltraGridRow In dtgListado.Rows
                        For Each celda As UltraGridCell In fila.Cells
                            If celda.Column.Key.StartsWith("Dia") Then
                                Dim dia As Integer = Integer.Parse(celda.Column.Key.Replace("Dia", ""))

                                If dia >= rangoInicio AndAlso dia <= rangoFin Then
                                    Dim idTrabajador As String = fila.Cells("ID").Value.ToString()

                                    If horariosTrabajadoresEventuales.ContainsKey(idTrabajador) Then
                                        Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = horariosTrabajadoresEventuales(idTrabajador)
                                        Dim entrada As String = listaHorarios(dia - 1).Item1
                                        Dim salida As String = listaHorarios(dia - 1).Item2
                                        Dim horasExtras As String = listaHorarios(dia - 1).Item4
                                        Dim horasTrabajadas As String = listaHorarios(dia - 1).Item6
                                        Dim feriadoTrabajado As String = listaHorarios(dia - 1).Item9
                                        Dim horasExtrasMarranas As String = listaHorarios(dia - 1).Item10

                                        Dim totalHoras As Integer = Integer.Parse(horasTrabajadas)
                                        Dim totalHorasExtras As Double = Double.Parse(horasExtras) + Double.Parse(horasExtrasMarranas)

                                        If cbMostrarHorasExtras.Checked Then

                                            Select Case celda.Value?.ToString()
                                                Case "HEX", "FT"
                                                    celda.Value = $"{totalHorasExtras}"
                                            End Select

                                        Else
                                            If celda.Value?.ToString() = "PM" Then
                                                Continue For
                                            ElseIf celda.Value.ToString() = "V" Then
                                                Continue For
                                            ElseIf celda.Value?.ToString() = "D" Then
                                                Continue For
                                            ElseIf celda.Value?.ToString() = "FNT" Then
                                                Continue For
                                            End If

                                            Dim resultado As String = "F"

                                            If Not String.IsNullOrWhiteSpace(entrada) AndAlso Not String.IsNullOrWhiteSpace(salida) Then
                                                If feriadoTrabajado = "SI" Then
                                                    resultado = "FT"
                                                ElseIf totalHorasExtras > 0 Then
                                                    resultado = "HEX"
                                                ElseIf totalHoras < 8 Then
                                                    resultado = "IN"
                                                Else
                                                    resultado = "A"
                                                End If
                                            ElseIf Not String.IsNullOrWhiteSpace(entrada) Or Not String.IsNullOrWhiteSpace(salida) Then
                                                resultado = "IN"
                                            Else
                                                resultado = "F"
                                            End If
                                            celda.Value = resultado
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    Next

                Else
                    For Each fila As UltraGridRow In dtgListado.Rows
                        Dim idTrabajador As String = fila.Cells("ID").Value.ToString()

                        ' Recorrer todas las columnas que empiezan con "Dia"
                        For Each celda As UltraGridCell In fila.Cells
                            If celda.Column.Key.StartsWith("Dia") Then
                                ' Obtener la fecha del nombre de la columna (formato dd-MM)
                                Dim fechaStr As String = celda.Column.Key.Replace("Dia", "")
                                Dim fecha As Date = Date.ParseExact(fechaStr, "dd-MM", Globalization.CultureInfo.InvariantCulture)

                                fecha = New Date(CInt(CmbAnios.SelectedItem), fecha.Month, fecha.Day)

                                If horariosTrabajadoresEventuales.ContainsKey(idTrabajador) Then
                                    Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = horariosTrabajadoresEventuales(idTrabajador)

                                    ' Calcular el índice basado en el día relativo al primer domingo del mes
                                    Dim primerDiaMes As New Date(CInt(CmbAnios.SelectedItem), fecha.Month, 1)
                                    Dim primerDomingo As Date = primerDiaMes
                                    While primerDomingo.DayOfWeek <> DayOfWeek.Sunday
                                        primerDomingo = primerDomingo.AddDays(1)
                                    End While

                                    ' Calcular el índice como la diferencia de días entre la fecha actual y el primer domingo
                                    Dim indice As Integer = (fecha - primerDomingo).Days

                                    If indice >= 0 AndAlso indice < listaHorarios.Count Then
                                        Dim entrada As String = listaHorarios(indice).Item1
                                        Dim salida As String = listaHorarios(indice).Item2
                                        Dim horasExtras As String = listaHorarios(indice).Item4
                                        Dim horasTrabajadas As String = listaHorarios(indice).Item6
                                        Dim feriadoTrabajado As String = listaHorarios(indice).Item9
                                        Dim horasExtrasMarranas As String = listaHorarios(indice).Item10

                                        ' Comprobar si la celda tiene "-" y saltarla si es así
                                        If celda.Value?.ToString() = "-" Then
                                            Continue For
                                        End If

                                        Dim totalHoras As Integer = Integer.Parse(horasTrabajadas)
                                        Dim totalHorasExtras As Double = Double.Parse(horasExtras) + Double.Parse(horasExtrasMarranas)

                                        If cbMostrarHorasExtras.Checked Then

                                            Select Case celda.Value?.ToString()
                                                Case "HEX", "FT"
                                                    celda.Value = $"{totalHorasExtras}"
                                            End Select

                                        Else
                                            If celda.Value?.ToString() = "PM" Then
                                                Continue For
                                            ElseIf celda.Value.ToString() = "V" Then
                                                Continue For
                                            ElseIf celda.Value?.ToString() = "D" Then
                                                Continue For
                                            End If

                                            Dim resultado As String = "F"

                                            If Not String.IsNullOrWhiteSpace(entrada) AndAlso Not String.IsNullOrWhiteSpace(salida) Then
                                                If feriadoTrabajado = "SI" Then
                                                    resultado = "FT"
                                                ElseIf totalHorasExtras > 0 Then
                                                    resultado = "HEX"
                                                ElseIf totalHoras < 8 Then
                                                    resultado = "IN"
                                                Else
                                                    resultado = "A"
                                                End If
                                            ElseIf Not String.IsNullOrWhiteSpace(entrada) Or Not String.IsNullOrWhiteSpace(salida) Then
                                                resultado = "IN"
                                            Else
                                                resultado = "F"
                                            End If
                                            celda.Value = resultado
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    Next
                End If
            Else
                Dim rangoInicio As Integer
                Dim rangoFin As Integer

                If rbEventual.Checked Then
                    rangoInicio = 1
                    rangoFin = 1
                ElseIf rbPlanilla.Checked Or rbEventualPlanilla.Checked Then
                    If generadoEnPlanilla Then
                        rangoInicio = 1
                        rangoFin = ultimoDiaRegistroEventual
                    ElseIf generadoEnOperario Then
                        rangoInicio = rangoInicioOperario
                        rangoFin = rangoFinOperario
                    Else
                        If ultimoDiaRegistro > 0 Then
                            rangoInicio = ultimoDiaRegistro + 1
                            rangoFin = dia
                        Else
                            rangoInicio = 1
                            rangoFin = dia
                        End If
                    End If
                End If

                For Each fila As UltraGridRow In dtgListado.Rows
                    For Each celda As UltraGridCell In fila.Cells
                        If celda.Column.Key.StartsWith("Dia") Then
                            Dim dia As Integer = Integer.Parse(celda.Column.Key.Replace("Dia", ""))

                            If dia >= rangoInicio AndAlso dia <= rangoFin Then
                                Dim idTrabajador As String = fila.Cells("ID").Value.ToString()

                                If horariosTrabajadores.ContainsKey(idTrabajador) Then
                                    Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = horariosTrabajadores(idTrabajador)
                                    Dim entrada As String = listaHorarios(dia - 1).Item1
                                    Dim salida As String = listaHorarios(dia - 1).Item2
                                    Dim horasExtras As String = listaHorarios(dia - 1).Item4
                                    Dim horasTrabajadas As String = listaHorarios(dia - 1).Item6
                                    Dim feriadoTrabajado As String = listaHorarios(dia - 1).Item9
                                    Dim horasExtrasMarranas As String = listaHorarios(dia - 1).Item10

                                    Dim totalHoras As Integer = Integer.Parse(horasTrabajadas)
                                    Dim totalHorasExtras As Double = Double.Parse(horasExtras) + Double.Parse(horasExtrasMarranas)

                                    If cbMostrarHorasExtras.Checked Then

                                        Select Case celda.Value?.ToString()
                                            Case "HEX", "FT"
                                                celda.Value = $"{totalHorasExtras}"
                                        End Select

                                    Else
                                        If celda.Value?.ToString() = "PM" Then
                                            Continue For
                                        ElseIf celda.Value.ToString() = "V" Then
                                            Continue For
                                        ElseIf celda.Value?.ToString() = "D" Then
                                            Continue For
                                        End If

                                        Dim resultado As String = "F"

                                        If Not String.IsNullOrWhiteSpace(entrada) AndAlso Not String.IsNullOrWhiteSpace(salida) Then
                                            If feriadoTrabajado = "SI" Then
                                                resultado = "FT"
                                            ElseIf totalHorasExtras > 0 Then
                                                resultado = "HEX"
                                            ElseIf totalHoras < 8 Then
                                                resultado = "IN"
                                            Else
                                                resultado = "A"
                                            End If
                                        ElseIf Not String.IsNullOrWhiteSpace(entrada) Or Not String.IsNullOrWhiteSpace(salida) Then
                                            resultado = "IN"
                                        Else
                                            resultado = "F"
                                        End If
                                        celda.Value = resultado
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    ' Configuracion del UltraGrid 
    Private Sub dtgListado_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If e.Cell.Column.Key.StartsWith("Dia") Then

            If rbPlanilla.Checked Then
                If e.Cell.Row.Cells("ID").Value Is Nothing Then
                    msj_advert("Selecciona un registro.")
                    Exit Sub
                End If

                Dim idTrabajador As String = e.Cell.Row.Cells("ID").Value.ToString()
                Dim diaSeleccionado As Integer = Integer.Parse(e.Cell.Column.Key.Replace("Dia", ""))

                If rbEventualPlanilla.Checked Or rbPlanilla.Checked Then
                    If generadoEnPlanilla Then
                        If e.Cell.Value.ToString() = "V" Then
                            msj_advert("No puedes editar este día, ya que se le han aplicado vacaciones.")
                            Exit Sub
                        End If
                    ElseIf generadoEnOperario Then
                        If e.Cell.Value.ToString() = "V" Then
                            msj_advert("No puedes editar este día, ya que se le han aplicado vacaciones.")
                            Exit Sub
                        End If
                    Else
                        If e.Cell.Value.ToString() = "-" Then
                            msj_advert("No se puede editar este día, ya que no pertenece al rango de fechas válido.")
                            Exit Sub
                        ElseIf e.Cell.Value.ToString() = "V" Then
                            msj_advert("No puedes editar este día, ya que se le han aplicado vacaciones.")
                            Exit Sub
                        End If
                    End If
                End If

                Dim tipoTrabajador As String = e.Cell.Row.Cells("TIPO").Value.ToString()

                Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = Nothing

                If rbEventualPlanilla.Checked Or rbPlanilla.Checked Then
                    If tipoTrabajador = "EVENTUAL" Then
                        If horariosTrabajadoresEventuales.ContainsKey(idTrabajador) Then
                            listaHorarios = horariosTrabajadoresEventuales(idTrabajador)
                        End If
                    ElseIf tipoTrabajador = "PLANILLA" Then
                        If horariosTrabajadores.ContainsKey(idTrabajador) Then
                            listaHorarios = horariosTrabajadores(idTrabajador)
                        End If
                    End If
                ElseIf rbEventual.Checked Then
                    If tipoTrabajador = "EVENTUAL" Then
                        If horariosTrabajadores.ContainsKey(idTrabajador) Then
                            listaHorarios = horariosTrabajadores(idTrabajador)
                        End If
                    End If
                End If

                If listaHorarios IsNot Nothing Then
                    Dim horario As (String, String, String, String, String, String, Integer, String, String, String) = listaHorarios(diaSeleccionado - 1)

                    Dim entrada As String = horario.Item1
                    Dim salida As String = horario.Item2
                    Dim observacion As String = horario.Item3
                    Dim horasExtras As String = horario.Item4
                    Dim pagoEspecial As String = horario.Item5
                    Dim horasTrabajadasTotal As String = horario.Item6
                    horasRefrigerio = horario.Item7
                    Dim permisoMedico As String = horario.Item8
                    Dim feriadoTrabajado As String = horario.Item9
                    Dim horasExtrasMarranas As String = horario.Item10

                    ' Verifica si los valores de entrada y salida están presentes
                    Dim valorAnterior As String = e.Cell.Value.ToString()
                    If Not String.IsNullOrWhiteSpace(entrada) AndAlso Not String.IsNullOrWhiteSpace(salida) Then
                        Dim horaEntrada As DateTime = DateTime.Parse(entrada)
                        Dim horaSalida As DateTime = DateTime.Parse(salida)
                        Dim diferencia As TimeSpan = horaSalida - horaEntrada
                        Dim horasTotales As Integer = Math.Floor(diferencia.TotalHours)
                        horasTotales = Math.Max(0, horasTotales - horasRefrigerio)

                        Dim horasNormales As Integer = Math.Min(horasTotales, 8)
                        Dim horasExtrasCalculadas As Integer = If(horasTotales > 8, horasTotales - 8, 0)

                        If horasExtras = 0 Then
                            horasExtras = horasExtrasCalculadas.ToString()
                        End If

                        horasLaboradas = horasNormales.ToString()
                        horasTrabajadasTotal = (horasNormales + horasExtrasCalculadas).ToString()
                    Else
                        horasLaboradas = "0"
                    End If

                    Dim frmEditarHorarios As New frmEditarHorarios(entrada, salida, observacion, horasExtras, pagoEspecial, horasLaboradas, horasRefrigerio, permisoMedico, feriadoTrabajado, horasExtrasMarranas)

                    If frmEditarHorarios.ShowDialog() = DialogResult.OK Then
                        entrada = frmEditarHorarios.Entrada.Trim()
                        salida = frmEditarHorarios.Salida.Trim()
                        observacion = frmEditarHorarios.Observacion.Trim()
                        horasExtras = frmEditarHorarios.HorasExtras.Trim()
                        pagoEspecial = frmEditarHorarios.PagoEspecial.Trim()
                        horasLaboradas = frmEditarHorarios.HorasLaboradas.Trim()
                        horasRefrigerio = frmEditarHorarios.HorasRefrigerio.Trim()
                        permisoMedico = frmEditarHorarios.PermisoMedico.Trim()
                        feriadoTrabajado = frmEditarHorarios.Feriado.Trim()
                        horasExtrasMarranas = frmEditarHorarios.HorasExtrasMarranas.Trim()

                        If tipoTrabajador = "EVENTUAL" Then
                            listaHorarios(diaSeleccionado - 1) = (entrada, salida, observacion, horasExtras, pagoEspecial, horasLaboradas, horasRefrigerio, permisoMedico, feriadoTrabajado, horasExtrasMarranas)
                            horariosTrabajadoresEventuales(idTrabajador) = listaHorarios
                        ElseIf tipoTrabajador = "PLANILLA" Then
                            listaHorarios(diaSeleccionado - 1) = (entrada, salida, observacion, horasExtras, pagoEspecial, horasLaboradas, horasRefrigerio, permisoMedico, feriadoTrabajado, horasExtrasMarranas)
                            horariosTrabajadores(idTrabajador) = listaHorarios
                        End If

                        Dim nuevoValor As String = ""
                        If String.IsNullOrWhiteSpace(entrada) AndAlso String.IsNullOrWhiteSpace(salida) Then
                            nuevoValor = "F"
                        ElseIf String.IsNullOrWhiteSpace(entrada) Or String.IsNullOrWhiteSpace(salida) Then
                            nuevoValor = "IN"
                        Else
                            If Double.Parse(horasExtras) > 0 Or Double.Parse(horasExtrasMarranas) > 0 Then
                                nuevoValor = "HEX"
                            Else
                                nuevoValor = "A"
                            End If
                        End If

                        If frmEditarHorarios.cbxPermisoMedico.SelectedItem.ToString() = "SI" Then
                            nuevoValor = "PM"
                        End If

                        If frmEditarHorarios.Observacion.Trim().IndexOf("DESCANSO", StringComparison.OrdinalIgnoreCase) >= 0 Then
                            nuevoValor = "D"
                        End If

                        If frmEditarHorarios.cbxFeriado.SelectedItem.ToString() = "SI" Then
                            nuevoValor = "FT"
                        End If

                        If frmEditarHorarios.cbxFeriado.SelectedItem.ToString() = "NO" Then
                            nuevoValor = "FNT"
                        End If

                        e.Cell.Value = nuevoValor

                        Colorear()
                        ActualizarContadores(valorAnterior, nuevoValor)

                        ' Calcular horas semanales
                        Dim horasTotalesSemana As Double = 0
                        Dim horasNormalesSemana As Integer = 0
                        Dim horasAdicionalesSemana As Double = 0

                        For Each horarioDia In listaHorarios
                            If Not String.IsNullOrWhiteSpace(horarioDia.Item1) AndAlso Not String.IsNullOrWhiteSpace(horarioDia.Item2) Then

                                Dim horasLaboradasDia As Integer = Integer.Parse(horarioDia.Item6)
                                Dim horasExtrasDia As Double = Double.Parse(horarioDia.Item4)
                                Dim horasExtrasMarranasDia As Double = Double.Parse(horarioDia.Item10)
                                If horasExtrasDia > 0 Or horasExtrasMarranasDia > 0 Then
                                    horasTotalesSemana += horasExtrasDia + horasExtrasMarranasDia
                                    horasAdicionalesSemana += horasExtrasDia + horasExtrasMarranasDia
                                End If

                                If horasLaboradasDia > 8 Then
                                    horasTotalesSemana += horasLaboradasDia
                                    horasNormalesSemana += 8
                                Else
                                    horasTotalesSemana += horasLaboradasDia
                                    horasNormalesSemana += horasLaboradasDia
                                End If
                            End If
                        Next

                        ' Actualizar las celdas de horas semanales
                        e.Cell.Row.Cells("H.T").Value = horasTotalesSemana
                        e.Cell.Row.Cells("H.TR").Value = horasNormalesSemana
                        e.Cell.Row.Cells("H.EX").Value = horasAdicionalesSemana

                        'For i As Integer = 0 To listaHorarios.Count - 1
                        '    Dim dia As (String, String, String, String, String, String, Integer, String) = listaHorarios(i)
                        '    Dim valor As String = dtgListado.Rows(e.Cell.Row.Index).Cells(i + 4).Value.ToString()
                        '    If valor <> "-" Then
                        '        ultimoDiaRegistroEventual = i + 1 ' Usar el índice para actualizar el último día
                        '        Console.WriteLine($"Ultimo día: {ultimoDiaRegistroEventual}")
                        '    End If
                        'Next

                        Dim maxDia As Integer = 0
                        For i As Integer = 0 To listaHorarios.Count - 1
                            Dim dia As (String, String, String, String, String, String, Integer, String, String, String) = listaHorarios(i)
                            Dim valor As String = dtgListado.Rows(e.Cell.Row.Index).Cells($"Dia{i + 1}").Value.ToString()
                            If valor <> "-" And (i + 1) > maxDia Then
                                maxDia = i + 1
                            End If
                        Next
                        ultimoDiaRegistroEventual = maxDia
                        Console.WriteLine($"Ultimo día: {ultimoDiaRegistroEventual}")

                    End If
                End If
            ElseIf rbEventual.Checked Then
                If e.Cell.Row.Cells("ID").Value Is Nothing Then
                    msj_advert("Selecciona un registro.")
                    Exit Sub
                End If

                Dim idTrabajador As String = e.Cell.Row.Cells("ID").Value.ToString()
                Dim tipoTrabajador As String = e.Cell.Row.Cells("Tipo").Value.ToString()

                ' Solo permitir la edición si el trabajador es EVENTUAL
                If tipoTrabajador <> "EVENTUAL" Then
                    msj_advert("Solo se pueden editar los horarios de trabajadores eventuales.")
                    Exit Sub
                End If

                If generadoQuincenaEventual Then

                    Dim diaSeleccionado As Integer = Integer.Parse(e.Cell.Column.Key.Replace("Dia", ""))

                    Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = Nothing

                    If horariosTrabajadoresEventuales.ContainsKey(idTrabajador) Then
                        listaHorarios = horariosTrabajadoresEventuales(idTrabajador)
                    End If

                    If listaHorarios IsNot Nothing Then
                        ' Obtener el horario del día seleccionado
                        Dim horario As (String, String, String, String, String, String, Integer, String, String, String) = listaHorarios(diaSeleccionado - 1)

                        Dim entrada As String = horario.Item1
                        Dim salida As String = horario.Item2
                        Dim observacion As String = horario.Item3
                        Dim horasExtras As String = horario.Item4
                        Dim pagoEspecial As String = horario.Item5
                        Dim horasTrabajadasTotal As String = horario.Item6
                        horasRefrigerio = horario.Item7
                        Dim permisoMedico As String = horario.Item8
                        Dim feriadoTrabajado As String = horario.Item9
                        Dim horasExtrasMarranas As String = horario.Item10

                        ' Verifica si los valores de entrada y salida están presentes
                        Dim valorAnterior As String = e.Cell.Value.ToString()
                        If Not String.IsNullOrWhiteSpace(entrada) AndAlso Not String.IsNullOrWhiteSpace(salida) Then
                            Dim horaEntrada As DateTime = DateTime.Parse(entrada)
                            Dim horaSalida As DateTime = DateTime.Parse(salida)
                            Dim diferencia As TimeSpan = horaSalida - horaEntrada
                            Dim horasTotales As Integer = Math.Floor(diferencia.TotalHours)
                            horasTotales = Math.Max(0, horasTotales - horasRefrigerio)

                            Dim horasNormales As Integer = Math.Min(horasTotales, 8)
                            Dim horasExtrasCalculadas As Integer = If(horasTotales > 8, horasTotales - 8, 0)

                            If horasExtras = 0 Then
                                horasExtras = horasExtrasCalculadas.ToString()
                            End If

                            horasLaboradas = horasNormales.ToString()
                            horasTrabajadasTotal = (horasNormales + horasExtrasCalculadas).ToString()
                        Else
                            horasLaboradas = "0"
                        End If

                        Dim frmEditarHorarios As New frmEditarHorarios(entrada, salida, observacion, horasExtras, pagoEspecial, horasLaboradas, horasRefrigerio, permisoMedico, feriadoTrabajado, horasExtrasMarranas)

                        If frmEditarHorarios.ShowDialog() = DialogResult.OK Then
                            entrada = frmEditarHorarios.Entrada.Trim()
                            salida = frmEditarHorarios.Salida.Trim()
                            observacion = frmEditarHorarios.Observacion.Trim()
                            horasExtras = frmEditarHorarios.HorasExtras.Trim()
                            pagoEspecial = frmEditarHorarios.PagoEspecial.Trim()
                            horasLaboradas = frmEditarHorarios.HorasLaboradas.Trim()
                            horasRefrigerio = frmEditarHorarios.HorasRefrigerio.Trim()
                            permisoMedico = frmEditarHorarios.PermisoMedico.Trim()
                            feriadoTrabajado = frmEditarHorarios.Feriado.Trim()
                            horasExtrasMarranas = frmEditarHorarios.HorasExtrasMarranas.Trim()

                            listaHorarios(diaSeleccionado - 1) = (entrada, salida, observacion, horasExtras, pagoEspecial, horasLaboradas, horasRefrigerio, permisoMedico, feriadoTrabajado, horasExtrasMarranas)
                            horariosTrabajadoresEventuales(idTrabajador) = listaHorarios

                            Dim nuevoValor As String = ""
                            If String.IsNullOrWhiteSpace(entrada) AndAlso String.IsNullOrWhiteSpace(salida) Then
                                nuevoValor = "F"
                            ElseIf String.IsNullOrWhiteSpace(entrada) Or String.IsNullOrWhiteSpace(salida) Then
                                nuevoValor = "IN"
                            Else
                                If Double.Parse(horasExtras) > 0 Or Double.Parse(horasExtrasMarranas) > 0 Then
                                    nuevoValor = "HEX"
                                Else
                                    nuevoValor = "A"
                                End If
                            End If

                            If frmEditarHorarios.cbxPermisoMedico.SelectedItem.ToString() = "SI" Then
                                nuevoValor = "PM"
                            End If

                            If frmEditarHorarios.Observacion.Trim().IndexOf("DESCANSO", StringComparison.OrdinalIgnoreCase) >= 0 Then
                                nuevoValor = "D"
                            End If

                            If frmEditarHorarios.cbxFeriado.SelectedItem.ToString() = "SI" Then
                                nuevoValor = "FT"
                            End If

                            If frmEditarHorarios.cbxFeriado.SelectedItem.ToString() = "NO" Then
                                nuevoValor = "FNT"
                            End If

                            e.Cell.Value = nuevoValor

                            Colorear()
                            ActualizarContadores(valorAnterior, nuevoValor)

                            ' Calcular horas semanales
                            Dim horasTotalesSemana As Double = 0
                            Dim horasNormalesSemana As Integer = 0
                            Dim horasAdicionalesSemana As Double = 0

                            For Each horarioDia In listaHorarios
                                If Not String.IsNullOrWhiteSpace(horarioDia.Item1) AndAlso Not String.IsNullOrWhiteSpace(horarioDia.Item2) Then

                                    Dim horasLaboradasDia As Integer = Integer.Parse(horarioDia.Item6)
                                    Dim horasExtrasDia As Double = Double.Parse(horarioDia.Item4)
                                    Dim horasExtrasMarranasDia As Double = Double.Parse(horarioDia.Item10)
                                    If horasExtrasDia > 0 Or horasExtrasMarranasDia > 0 Then
                                        horasTotalesSemana += horasExtrasDia + horasExtrasMarranasDia
                                        horasAdicionalesSemana += horasExtrasDia + horasExtrasMarranasDia
                                    End If

                                    If horasLaboradasDia > 8 Then
                                        horasTotalesSemana += horasLaboradasDia
                                        horasNormalesSemana += 8
                                    Else
                                        horasTotalesSemana += horasLaboradasDia
                                        horasNormalesSemana += horasLaboradasDia
                                    End If
                                End If
                            Next

                            ' Actualizar las celdas de horas semanales
                            e.Cell.Row.Cells("H.T").Value = horasTotalesSemana
                            e.Cell.Row.Cells("H.TR").Value = horasNormalesSemana
                            e.Cell.Row.Cells("H.EX").Value = horasAdicionalesSemana

                            Dim maxDia As Integer = 0
                            For i As Integer = 0 To listaHorarios.Count - 1
                                Dim dia As (String, String, String, String, String, String, Integer, String, String, String) = listaHorarios(i)
                                Dim valor As String = dtgListado.Rows(e.Cell.Row.Index).Cells($"Dia{i + 1}").Value.ToString()
                                If valor <> "-" And (i + 1) > maxDia Then
                                    maxDia = i + 1
                                End If
                            Next
                            ultimoDiaRegistroEventual = maxDia
                        End If
                    End If
                Else
                    ' Obtener la fecha del día seleccionado (formato: "DiaDD-MM")
                    'Dim fechaStr As String = e.Cell.Column.Key.Replace("Dia", "")
                    'Dim fechaSeleccionada As DateTime = DateTime.ParseExact(fechaStr, "dd-MM", CultureInfo.InvariantCulture)

                    '' Obtener el primer domingo del mes
                    'Dim primerDiaMes As DateTime = New DateTime(CInt(CmbAnios.SelectedItem), cbListaMeses.SelectedIndex + 1, 1)
                    'Dim primerDomingo As DateTime = primerDiaMes
                    'While primerDomingo.DayOfWeek <> DayOfWeek.Sunday
                    '    primerDomingo = primerDomingo.AddDays(1)
                    'End While

                    '' Calcular el índice basado en la diferencia de días desde el primer domingo
                    'Dim indiceDia As Integer = CInt((fechaSeleccionada - primerDomingo).TotalDays)
                    'If indiceDia < 0 OrElse indiceDia >= horariosTrabajadoresEventuales(idTrabajador).Count Then
                    '    msj_advert("Esta fecha está fuera del rango válido para el mes actual.")
                    '    Exit Sub
                    'End If

                    ' Obtener la fecha del día seleccionado (formato: "DiaDD-MM")
                    ' Obtener la fecha del día seleccionado (formato: "DiaDD-MM")
                    Dim fechaStr As String = e.Cell.Column.Key.Replace("Dia", "")
                    Dim partesFecha As String() = fechaStr.Split("-"c)
                    Dim dia As Integer = Integer.Parse(partesFecha(0))
                    Dim mes As Integer = Integer.Parse(partesFecha(1))

                    ' Determinar el año correcto
                    Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
                    Dim anioSeleccionado As Integer = CInt(CmbAnios.SelectedItem)

                    ' Obtener el primer domingo del mes PRIMERO
                    Dim primerDiaMes As DateTime = New DateTime(anioSeleccionado, mesSeleccionado, 1)
                    Dim primerDomingo As DateTime = primerDiaMes
                    While primerDomingo.DayOfWeek <> DayOfWeek.Sunday
                        primerDomingo = primerDomingo.AddDays(1)
                    End While

                    ' ✅ SOLUCIÓN: Usar el año base del primer domingo para construir la fecha
                    Dim anioBase As Integer = primerDomingo.Year

                    ' Si el mes de la celda es diferente al mes del primer domingo, ajustar el año
                    Dim anioFecha As Integer = anioBase
                    If mes < primerDomingo.Month AndAlso primerDomingo.Month = 12 Then
                        ' La fecha es del año siguiente (ej: enero cuando el primer domingo es en diciembre)
                        anioFecha = anioBase + 1
                    ElseIf mes > primerDomingo.Month AndAlso mes = 12 Then
                        ' La fecha es del año anterior (ej: diciembre cuando el primer domingo es en enero)
                        anioFecha = anioBase - 1
                    End If

                    Dim fechaSeleccionada As DateTime = New DateTime(anioFecha, mes, dia)

                    ' Calcular el índice basado en la diferencia de días desde el primer domingo
                    Dim indiceDia As Integer = CInt((fechaSeleccionada - primerDomingo).TotalDays)
                    If indiceDia < 0 OrElse indiceDia >= horariosTrabajadoresEventuales(idTrabajador).Count Then
                        msj_advert("Esta fecha está fuera del rango válido para el mes actual.")
                        Exit Sub
                    End If

                    Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = Nothing

                    If horariosTrabajadoresEventuales.ContainsKey(idTrabajador) Then
                        listaHorarios = horariosTrabajadoresEventuales(idTrabajador)
                    End If

                    If listaHorarios IsNot Nothing Then
                        ' Obtener el horario del día seleccionado
                        Dim horario As (String, String, String, String, String, String, Integer, String, String, String) = listaHorarios(indiceDia)

                        Dim entrada As String = horario.Item1
                        Dim salida As String = horario.Item2
                        Dim observacion As String = horario.Item3
                        Dim horasExtras As String = horario.Item4
                        Dim pagoEspecial As String = horario.Item5
                        Dim horasTrabajadasTotal As String = horario.Item6
                        Dim horasRefrigerio As Integer = horario.Item7
                        Dim permisoMedico As String = horario.Item8
                        Dim feriadoTrabajado As String = horario.Item9
                        Dim horasExtrasMarranas As String = horario.Item10

                        ' Calcular horas trabajadas si hay entrada y salida
                        Dim valorAnterior As String = e.Cell.Value.ToString()
                        If Not String.IsNullOrWhiteSpace(entrada) AndAlso Not String.IsNullOrWhiteSpace(salida) Then
                            Dim horaEntrada As DateTime = DateTime.Parse(entrada)
                            Dim horaSalida As DateTime = DateTime.Parse(salida)
                            Dim diferencia As TimeSpan = horaSalida - horaEntrada
                            Dim horasTotales As Integer = Math.Floor(diferencia.TotalHours)
                            horasTotales = Math.Max(0, horasTotales - horasRefrigerio)

                            Dim horasNormales As Integer = Math.Min(horasTotales, 8)
                            Dim horasExtrasCalculadas As Integer = If(horasTotales > 8, horasTotales - 8, 0)

                            If horasExtras = "0" Then
                                horasExtras = horasExtrasCalculadas.ToString()
                            End If

                            horasLaboradas = horasNormales.ToString()
                            horasTrabajadasTotal = (horasNormales + horasExtrasCalculadas).ToString()
                        Else
                            horasLaboradas = "0"
                        End If

                        ' Mostrar formulario de edición
                        Dim frmEditarHorarios As New frmEditarHorarios(entrada, salida, observacion, horasExtras,
                                                             pagoEspecial, horasLaboradas, horasRefrigerio, permisoMedico, feriadoTrabajado, horasExtrasMarranas)

                        If frmEditarHorarios.ShowDialog() = DialogResult.OK Then
                            ' Actualizar valores desde el formulario
                            entrada = frmEditarHorarios.Entrada.Trim()
                            salida = frmEditarHorarios.Salida.Trim()
                            observacion = frmEditarHorarios.Observacion.Trim()
                            horasExtras = frmEditarHorarios.HorasExtras.Trim()
                            pagoEspecial = frmEditarHorarios.PagoEspecial.Trim()
                            horasLaboradas = frmEditarHorarios.HorasLaboradas.Trim()
                            horasRefrigerio = frmEditarHorarios.HorasRefrigerio.Trim()
                            permisoMedico = frmEditarHorarios.PermisoMedico.Trim()
                            feriadoTrabajado = frmEditarHorarios.Feriado.Trim()
                            horasExtrasMarranas = frmEditarHorarios.HorasExtrasMarranas.Trim()

                            ' Actualizar el horario en la lista
                            listaHorarios(indiceDia) = (entrada, salida, observacion, horasExtras,
                                              pagoEspecial, horasLaboradas,
                                              Integer.Parse(horasRefrigerio), permisoMedico, feriadoTrabajado, horasExtrasMarranas)
                            horariosTrabajadoresEventuales(idTrabajador) = listaHorarios

                            ' Actualizar la celda y su apariencia
                            Dim nuevoValor As String = ""
                            If String.IsNullOrWhiteSpace(entrada) AndAlso String.IsNullOrWhiteSpace(salida) Then
                                nuevoValor = "F"
                            ElseIf String.IsNullOrWhiteSpace(entrada) Or String.IsNullOrWhiteSpace(salida) Then
                                nuevoValor = "IN"
                            Else
                                If Double.Parse(horasExtras) > 0 Or Double.Parse(horasExtrasMarranas) > 0 Then
                                    nuevoValor = "HEX"
                                Else
                                    nuevoValor = "A"
                                End If
                            End If

                            If frmEditarHorarios.cbxPermisoMedico.SelectedItem.ToString() = "SI" Then
                                nuevoValor = "PM"
                            End If

                            If frmEditarHorarios.Observacion.Trim().IndexOf("DESCANSO", StringComparison.OrdinalIgnoreCase) >= 0 Then
                                nuevoValor = "D"
                            End If

                            If frmEditarHorarios.cbxFeriado.SelectedItem.ToString() = "SI" Then
                                nuevoValor = "FT"
                            End If

                            If frmEditarHorarios.cbxFeriado.SelectedItem.ToString() = "NO" Then
                                nuevoValor = "FNT"
                            End If

                            e.Cell.Value = nuevoValor

                            ' Actualizar interfaz y contadores
                            Colorear()
                            ActualizarContadores(valorAnterior, nuevoValor)

                            ' Calcular totales de horas semanales
                            Dim horasTotales As Double = 0
                            Dim horasNormales As Integer = 0
                            Dim horasAdicionales As Double = 0

                            For Each horarioDia In listaHorarios
                                If Not String.IsNullOrWhiteSpace(horarioDia.Item1) AndAlso Not String.IsNullOrWhiteSpace(horarioDia.Item2) Then
                                    Dim horaEntrada As DateTime = DateTime.Parse(horarioDia.Item1)
                                    Dim horaSalida As DateTime = DateTime.Parse(horarioDia.Item2)
                                    Dim diferencia As TimeSpan = horaSalida - horaEntrada
                                    Dim horasDia As Integer = Math.Floor(diferencia.TotalHours)
                                    horasDia = Math.Max(0, horasDia - horarioDia.Item7)

                                    Dim horasLaboradasDia As Integer = Integer.Parse(horarioDia.Item6)
                                    Dim horasExtrasDia As Double = Double.Parse(horarioDia.Item4)
                                    Dim horasExtrasMarranasDia As Double = Double.Parse(horarioDia.Item10)
                                    If horasExtrasDia > 0 Or horasExtrasMarranasDia > 0 Then
                                        horasTotales += horasExtrasDia + horasExtrasMarranasDia
                                        horasAdicionales += horasExtrasDia + horasExtrasMarranasDia
                                    End If

                                    If horasLaboradasDia > 8 Then
                                        horasTotales += horasLaboradasDia
                                        horasNormales += 8
                                    Else
                                        horasTotales += horasLaboradasDia
                                        horasNormales += horasLaboradasDia
                                    End If
                                End If
                            Next

                            ' Actualizar celdas de totales
                            e.Cell.Row.Cells("H.T").Value = horasTotales
                            e.Cell.Row.Cells("H.TR").Value = horasNormales
                            e.Cell.Row.Cells("H.EX").Value = horasAdicionales

                            ' Actualizar último día de registro
                            For i As Integer = 0 To listaHorarios.Count - 1
                                Dim fechaActual As DateTime = primerDomingo.AddDays(i)
                                Dim mesActual As Integer = cbListaMeses.SelectedIndex + 1

                                ' Si la fecha actual está en un mes diferente al seleccionado
                                If fechaActual.Month <> mesActual Then
                                    ' Si hay un valor no "-" en esta fecha del siguiente mes
                                    Dim valor As String = dtgListado.Rows(e.Cell.Row.Index).Cells($"Dia{fechaActual:dd-MM}").Value.ToString()
                                    If valor <> "-" Then
                                        ' Reiniciamos el contador para el nuevo mes
                                        ultimoDiaRegistroEventual = fechaActual.Day
                                        mesEventual = fechaActual.Month
                                        Console.WriteLine("Mes eventual: " + mesEventual.ToString())
                                        Console.WriteLine($"Cruce de mes detectado. Nuevo ultimodiagreg: {ultimoDiaRegistroEventual}")
                                    End If
                                Else
                                    ' Comportamiento normal para el mes actual
                                    Dim valor As String = dtgListado.Rows(e.Cell.Row.Index).Cells($"Dia{primerDomingo.AddDays(i):dd-MM}").Value.ToString()
                                    If valor <> "-" Then
                                        ultimoDiaRegistroEventual = fechaActual.Day
                                        mesEventual = fechaActual.Month
                                        Console.WriteLine("ultimodiagreg: " + ultimoDiaRegistroEventual.ToString())
                                        Console.WriteLine("Mes eventual: " + mesEventual.ToString())
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CargarDatosExcel()
        Dim dtExcel As DataTable = LeerExcel(tbRutaArchivoExcel.Text, True)

        dtgListado.DataSource = dtExcel
        Colorear()
        ConfigurarUltraGrid()
        ProcesarAsistencias()
    End Sub

    ' Agregar el manejador de eventos para el botón eliminar
    Private Sub dtgListado_ClickCellButton(sender As Object, e As CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "Eliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿Está seguro que desea eliminar este registro?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                ' Obtener el DNI antes de eliminar la fila
                Dim dni As String = e.Cell.Row.Cells("ID").Value.ToString()

                dtTrabajadores.Rows.RemoveAt(e.Cell.Row.Index)
                dtTrabajadores.AcceptChanges()
                dtgListado.DataSource = dtTrabajadores

                ' Eliminar del diccionario horariosTrabajadores si existe
                If horariosTrabajadores.ContainsKey(dni) Then
                    horariosTrabajadores.Remove(dni)
                ElseIf horariosTrabajadoresEventuales.ContainsKey(dni) Then
                    horariosTrabajadoresEventuales.Remove(dni)
                End If
            End If
        End If
    End Sub

    Private Sub ConfigurarUltraGrid()
        Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
        Dim anioActual As Integer = DateTime.Now.Year
        Dim diasEnElMes As Integer = DateTime.DaysInMonth(anioActual, mesSeleccionado)
        MostrarSemanasEnLabel(mesSeleccionado, anioActual, labelSemanas)

        With dtgListado.DisplayLayout.Bands(0)
            .Columns.ClearUnbound()

            .Columns("Codigo").Header.Caption = "Cod."
            .Columns("ID").Header.Caption = "DNI"
            .Columns("Nombre").Header.Caption = "Personal"
            .Columns("Tipo").Header.Caption = "Tipo"
            .Columns("Eliminar").Header.Caption = ""
            .Columns("Codigo").Width = 70
            .Columns("ID").Width = 130
            .Columns("Nombre").Width = 200
            .Columns("Tipo").Width = 100
            .Columns("Eliminar").Style = UltraWinGrid.ColumnStyle.Button
            .Columns("Eliminar").CellButtonAppearance.Image = My.Resources.ico_eliminar
            .Columns("Eliminar").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            .Override.HeaderAppearance.TextHAlign = HAlign.Center
            .Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True

            If .Columns.Exists("OrigenDatos") Then
                .Columns("OrigenDatos").Hidden = True
            End If

            .Groups.Clear()
            .RowLayoutStyle = RowLayoutStyle.GroupLayout

            Dim groupGeneral As UltraGridGroup = .Groups.Add("Información General", "Información General")
            Dim group1 As UltraGridGroup = .Groups.Add("Primera Quincena", "Primera Quincena")
            Dim group2 As UltraGridGroup = .Groups.Add("Segunda Quincena", "Segunda Quincena")
            Dim groupHoras As UltraGridGroup = .Groups.Add("Informe de Horas", "Informe de Horas")

            .Columns("ID").RowLayoutColumnInfo.ParentGroup = groupGeneral
            .Columns("Nombre").RowLayoutColumnInfo.ParentGroup = groupGeneral
            .Columns("Codigo").RowLayoutColumnInfo.ParentGroup = groupGeneral
            .Columns("Tipo").RowLayoutColumnInfo.ParentGroup = groupGeneral

            For i As Integer = 1 To diasEnElMes
                Dim diaCol As String = $"Dia{i}"

                If .Columns.Exists(diaCol) Then
                    Dim col As UltraGridColumn = .Columns(diaCol)
                    col.Header.Caption = i.ToString()
                    col.Width = 50
                    col.CellAppearance.TextHAlign = HAlign.Center

                    If i <= 15 Then
                        col.RowLayoutColumnInfo.ParentGroup = group1
                    Else
                        col.RowLayoutColumnInfo.ParentGroup = group2
                    End If
                End If
            Next

            For Each colName As String In {"H.T", "H.TR", "H.EX"}
                If Not .Columns.Exists(colName) Then
                    .Columns.Add(colName)
                End If
                .Columns(colName).Width = 50
                .Columns(colName).CellAppearance.TextHAlign = HAlign.Center
                .Columns(colName).RowLayoutColumnInfo.ParentGroup = groupHoras
            Next
        End With

        dtgListado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        clsBasicas.Filtrar_Tabla(dtgListado, False)
    End Sub

    Private Function LeerExcel(archivoExcel As String, Optional mostrarMensaje As Boolean = True) As DataTable
        horariosTrabajadores.Clear()
        totalAsistenciaCompleta = Nothing
        totalInasistencias = Nothing
        totalConHorasExtras = Nothing
        totalConPermisoMedico = Nothing
        totalConDescanso = Nothing
        totalConFeriadoTrabajado = Nothing
        totalConFeriadoNoTrabajado = Nothing

        dtTrabajadores = New DataTable()
        dtTrabajadores.Columns.Add("Codigo", GetType(Integer))
        dtTrabajadores.Columns.Add("ID", GetType(String))
        dtTrabajadores.Columns.Add("Nombre", GetType(String))
        dtTrabajadores.Columns.Add("Tipo", GetType(String))
        dtTrabajadores.Columns.Add("Eliminar", GetType(Button))


        Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
        Dim trabajadoresInactivos As New List(Of String)()
        Dim dnisInvalidos As New List(Of String)()

        Try
            ' Primero validamos y guardamos los DNIs inválidos
            Using stream = File.Open(archivoExcel, FileMode.Open, FileAccess.Read)
                Using reader As IExcelDataReader = ExcelReaderFactory.CreateReader(stream)
                    Dim result As DataSet = reader.AsDataSet(New ExcelDataSetConfiguration() With {
                    .ConfigureDataTable = Function() New ExcelDataTableConfiguration() With {
                        .UseHeaderRow = True
                    }
                })
                    Dim table = result.Tables(2)
                    For rowIndex As Integer = 3 To table.Rows.Count - 1 Step 2
                        Dim dni As String = table.Rows(rowIndex)(2).ToString().Trim()
                        If Not String.IsNullOrWhiteSpace(dni) Then
                            If dni.Length <> 8 OrElse Not dni.All(Function(c) Char.IsDigit(c)) Then
                                dnisInvalidos.Add(dni)
                            End If
                        End If
                    Next
                End Using
            End Using

            Dim listaDNIs As String = ObtenerTodosLosDNI(archivoExcel)
            Dim nombresPorDNI As Dictionary(Of String, String) = ObtenerNombresPorDNI(listaDNIs)

            If nombresPorDNI.Count = 0 Then
                Return dtTrabajadores
            End If

            Using stream = File.Open(archivoExcel, FileMode.Open, FileAccess.Read)
                Using reader As IExcelDataReader = ExcelReaderFactory.CreateReader(stream)
                    Dim result As DataSet = reader.AsDataSet(New ExcelDataSetConfiguration() With {
                .ConfigureDataTable = Function() New ExcelDataTableConfiguration() With {
                    .UseHeaderRow = True
                }
            })

                    table = result.Tables(2)

                    fechaPeriodoExcel = table.Rows(1)(2).ToString()
                    fechaActualExcel = table.Rows(1)(11).ToString()
                    lblSetPeriodo.Text = fechaPeriodoExcel
                    lblSetFechaActual.Text = fechaActualExcel

                    If DateTime.TryParse(fechaActualExcel, fecha) Then
                        anio = fecha.Year
                        mes = fecha.Month
                        dia = fecha.Day
                    End If

                    Dim obj As New coControlAsistencia() With {
                    .IdUbicacion = cbxListarPlanteles.Value,
                    .mes = mes,
                    .anio = anio,
                    .Tipo = "PLANILLA",
                    .idHorario = 0
                    }

                    Dim mensaje As String = cn.Cn_ObtenerUltimoDiaRegistroAsistencia(obj)
                    Dim diasEnElMes As Integer = DateTime.DaysInMonth(anio, mes)
                    ultimoDiaRegistro = obj.UltimoDiaReg
                    Dim rangoInicio As Integer = ultimoDiaRegistro + 1
                    Dim rangoFin As Integer = dia

                    If dia < obj.UltimoDiaReg Then
                        Return dtTrabajadores
                    Else
                        If obj.UltimoDiaReg < 15 AndAlso dia > 15 Then
                            rangoFin = 15
                            dia = 15
                        End If
                    End If

                    For i As Integer = 1 To diasEnElMes
                        dtTrabajadores.Columns.Add($"Dia{i}", GetType(String))
                    Next

                    dtTrabajadores.Columns.Add("H.T", GetType(Double))
                    dtTrabajadores.Columns.Add("H.TR", GetType(Integer))
                    dtTrabajadores.Columns.Add("H.EX", GetType(Double))

                    For rowIndex As Integer = 3 To table.Rows.Count - 1 Step 2
                        Dim id As String = table.Rows(rowIndex)(2).ToString().Trim()
                        Dim dni As String = id

                        ' Solo verificamos contratos inactivos si el DNI es válido
                        If Not dnisInvalidos.Contains(dni) Then
                            Dim nombre As String = If(nombresPorDNI.ContainsKey(dni), nombresPorDNI(dni), String.Empty)

                            If String.IsNullOrWhiteSpace(nombre) Then
                                trabajadoresInactivos.Add(dni)
                                Continue For
                            End If

                            Dim listaHorarios As New List(Of (String, String, String, String, String, String, Integer, String, String, String))()

                            ' Inicializar la lista horarios para todos los días del mes
                            For i As Integer = 1 To diasEnElMes
                                listaHorarios.Add(("", "", "", "0", "", "0", horasRefrigerio, "", "", "0"))
                            Next

                            Dim newRow As DataRow = dtTrabajadores.NewRow()
                            newRow("ID") = id
                            newRow("Nombre") = nombre
                            newRow("Tipo") = "PLANILLA"

                            Dim horasTotales As Double = 0
                            Dim horasNormales As Integer = 0
                            Dim horasAdicionales As Double = 0

                            ' Initialize all days with "-"
                            For i As Integer = 1 To diasEnElMes
                                newRow($"Dia{i}") = "-"
                            Next

                            For columnIndex As Integer = 0 To table.Columns.Count - 1
                                Dim dia As Integer
                                If Integer.TryParse(table.Rows(2)(columnIndex).ToString(), dia) Then
                                    If dia <= diasEnElMes Then
                                        Dim filaHorario As Integer = rowIndex + 1

                                        If filaHorario >= table.Rows.Count Then
                                            table.Rows.Add(table.NewRow())
                                        End If

                                        Dim horariosCelda As String = table.Rows(filaHorario)(columnIndex).ToString()
                                        Dim horarios() As String = ObtenerPrimerYUltimoHorario(horariosCelda)

                                        entrada = horarios(0).Trim()
                                        salida = horarios(1).Trim()
                                        horasExtras = 0
                                        horasTrabajadasTotal = 0

                                        Dim resultado As String
                                        Dim horasTrabajadas As Double = 0
                                        Dim horasExtrasTotal As Double = 0

                                        ' Columnas
                                        Dim horasExtrasColum As Double = 0
                                        Dim horasTrabajadasTotalColum As Double = 0

                                        If dia >= rangoInicio AndAlso dia <= rangoFin Then
                                            If String.IsNullOrWhiteSpace(entrada) AndAlso String.IsNullOrWhiteSpace(salida) Then
                                                resultado = "F"
                                            ElseIf String.IsNullOrWhiteSpace(entrada) Or String.IsNullOrWhiteSpace(salida) Then
                                                resultado = "IN"
                                            Else
                                                resultado = "A"
                                                Dim horaEntrada As DateTime = DateTime.Parse(entrada)
                                                Dim horaSalida As DateTime = DateTime.Parse(salida)
                                                Dim diferencia As TimeSpan = horaSalida - horaEntrada

                                                horasTrabajadas = Math.Floor(diferencia.TotalHours)
                                                Dim minutosExtra As Integer = diferencia.Minutes

                                                horasTrabajadas = Math.Max(0, horasTrabajadas - horasRefrigerio)

                                                Dim horasExtrasCalculadas As Integer = If(horasTrabajadas > 8, horasTrabajadas - 8, 0)
                                                Dim horasExtrasDecimal As Double = 0

                                                If horasTrabajadas >= 8 AndAlso minutosExtra >= 30 Then
                                                    horasExtrasDecimal = 0.5
                                                End If

                                                horasExtrasTotal = horasExtrasCalculadas + horasExtrasDecimal

                                                ' Columnas
                                                horasExtrasColum = horasExtrasTotal
                                                horasTrabajadasTotalColum = horasTrabajadas + horasExtrasDecimal

                                                If horasTrabajadas <= 8 Then
                                                    horasTrabajadasTotal = horasTrabajadas.ToString()
                                                Else
                                                    horasTrabajadasTotal = "8"
                                                End If

                                                horasExtras = horasExtrasTotal.ToString("0.0")

                                                If horasTrabajadas < 8 Then
                                                    resultado = "IN"
                                                ElseIf horasExtrasTotal > 0 Then
                                                    resultado = "HEX"
                                                Else
                                                    resultado = "A"
                                                End If
                                            End If


                                            newRow($"Dia{dia}") = resultado

                                            If resultado = "A" OrElse resultado = "HEX" Then
                                                ' Lógica de suma ajustada según la referencia
                                                If horasExtrasTotal > 0 Then
                                                    horasTotales += horasExtrasTotal
                                                    horasAdicionales += horasExtrasTotal
                                                End If

                                                If horasTrabajadasTotal > 8 Then
                                                    horasTotales += horasTrabajadasTotal
                                                    horasNormales += 8
                                                Else
                                                    horasTotales += horasTrabajadasTotal
                                                    horasNormales += horasTrabajadasTotal
                                                End If
                                            End If
                                        Else
                                            newRow($"Dia{dia}") = "-"
                                        End If

                                        ' Actualizar la lista de horarios para este día
                                        listaHorarios(dia - 1) = (entrada, salida, observacion, horasExtras, pagoEspecial, horasTrabajadasTotal, horasRefrigerio, permisoMedico, feriadoTrabajado, horasExtrasMarranas)
                                    End If
                                End If
                            Next

                            newRow("H.T") = horasTotales
                            newRow("H.TR") = horasNormales
                            newRow("H.EX") = horasAdicionales

                            If Not horariosTrabajadores.ContainsKey(id) Then
                                horariosTrabajadores.Add(id, listaHorarios)
                            End If
                            dtTrabajadores.Rows.Add(newRow)
                        End If
                    Next
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Error: {ex.Message}")
            msj_advert("EL EXCEL NO TIENE FORMATO DE ASISTENCIA " & ex.Message)
        End Try

        For index As Integer = 0 To dtTrabajadores.Rows.Count - 1
            dtTrabajadores.Rows(index)("Codigo") = index + 1
        Next

        If mostrarMensaje Then
            Dim mensajeCompleto As String = ""

            ' Mensaje para DNIs inválidos
            If dnisInvalidos.Count > 0 Then
                mensajeCompleto = "LOS SIGUIENTES DNI NO SE HAN REGISTRADO PORQUE NO CUMPLEN CON EL FORMATO DE 8 DIGITOS:" &
                             Environment.NewLine &
                             String.Join(Environment.NewLine, dnisInvalidos) &
                             Environment.NewLine & Environment.NewLine
            End If

            ' Mensaje para trabajadores inactivos
            If trabajadoresInactivos.Count > 0 Then
                mensajeCompleto &= "LOS SIGUIENTES DNI NO SE HAN REGISTRADO EN LA TABLA PORQUE SU CONTRATO ESTA INACTIVO O NO ESTÁN REGISTRADO:" &
                              Environment.NewLine &
                              String.Join(Environment.NewLine, trabajadoresInactivos)
            End If

            ' Mostrar mensaje solo si hay algo que reportar
            If mensajeCompleto.Length > 0 Then
                msj_advert(mensajeCompleto)
            End If
        End If
        Return dtTrabajadores
    End Function

    Private Function ObtenerTodosLosDNI(archivoExcel As String) As String
        Dim dniConcatenados As String = String.Empty
        Try
            Using stream = File.Open(archivoExcel, FileMode.Open, FileAccess.Read)
                Using reader As IExcelDataReader = ExcelReaderFactory.CreateReader(stream)
                    Dim result As DataSet = reader.AsDataSet(New ExcelDataSetConfiguration() With {
                .ConfigureDataTable = Function() New ExcelDataTableConfiguration() With {
                    .UseHeaderRow = True
                }
            })
                    Dim table = result.Tables(2)
                    For rowIndex As Integer = 3 To table.Rows.Count - 1 Step 2
                        Dim dni As String = table.Rows(rowIndex)(2).ToString().Trim()
                        ' Verificar que el DNI tenga exactamente 8 dígitos y solo contenga números
                        If Not String.IsNullOrWhiteSpace(dni) AndAlso dni.Length = 8 AndAlso dni.All(Function(c) Char.IsDigit(c)) Then
                            If String.IsNullOrEmpty(dniConcatenados) Then
                                dniConcatenados = dni
                            Else
                                dniConcatenados &= "," & dni
                            End If
                        End If
                    Next
                End Using
            End Using
        Catch ex As Exception
            msj_advert("Error al leer el archivo Excel: " & ex.Message)
        End Try
        If Not String.IsNullOrEmpty(dniConcatenados) Then
            dniConcatenados &= ","
        End If
        Return dniConcatenados
    End Function

    Private Function ObtenerNombresPorDNI(listaDNIs As String) As Dictionary(Of String, String)
        Dim nombresPorDNI As New Dictionary(Of String, String)
        Try
            ' Solo proceder si hay DNIs válidos
            If Not String.IsNullOrWhiteSpace(listaDNIs) Then
                Dim obj As New coControlAsistencia()
                Dim msj As String
                obj.Lista_NumDocumentos = listaDNIs
                msj = cn.Cn_ObtenerDatosTrabajadorPorDNI(obj)
                If obj.CodeError = 0 Then
                    Dim nombres() As String = obj.Datos.Split(","c)
                    Dim dnis() As String = listaDNIs.Split(","c)
                    For i As Integer = 0 To dnis.Length - 1
                        If Not String.IsNullOrEmpty(dnis(i)) Then
                            nombresPorDNI(dnis(i)) = nombres(i)
                        End If
                    Next
                Else
                    msj_advert(msj)
                End If
            End If
        Catch ex As Exception
            msj_advert("Error al obtener nombres por DNI: " & ex.Message)
        End Try
        Return nombresPorDNI
    End Function
    Private Sub LimpiarGrid()
        dtgListado.DataSource = Nothing

        With dtgListado.DisplayLayout.Bands(0)
            .Columns.ClearUnbound()
        End With
    End Sub
    Private Sub ActualizarContadores(valorAnterior As String, nuevoValor As String)
        Select Case valorAnterior
            Case "A"
                totalAsistenciaCompleta -= 1
            Case "IN"
                totalIncompletas -= 1
            Case "HEX"
                totalConHorasExtras -= 1
            Case "PM"
                totalConPermisoMedico -= 1
            Case "F"
                totalInasistencias -= 1
            Case "D"
                totalConDescanso -= 1
            Case "FT"
                totalConFeriadoTrabajado -= 1
            Case "FNT"
                totalConFeriadoNoTrabajado -= 1
        End Select

        Select Case nuevoValor
            Case "A"
                totalAsistenciaCompleta += 1
            Case "IN"
                totalIncompletas += 1
            Case "HEX"
                totalConHorasExtras += 1
            Case "PM"
                totalConPermisoMedico += 1
            Case "F"
                totalInasistencias += 1
            Case "D"
                totalConDescanso += 1
            Case "FT"
                totalConFeriadoTrabajado += 1
            Case "FNT"
                totalConFeriadoNoTrabajado += 1
        End Select

        lblTotalAsistenciaCompleta.Text = totalAsistenciaCompleta.ToString()
        lblTotalPermisoMedico.Text = totalConPermisoMedico.ToString()
        lblTotalHorasExtras.Text = totalConHorasExtras.ToString()
        lblTotalIncompleta.Text = totalIncompletas.ToString()
        lblTotalInasistencias.Text = totalInasistencias.ToString()
        lblTotalDescanso.Text = totalConDescanso.ToString()
        lblTotalTrabajoFeriado.Text = totalConFeriadoTrabajado.ToString()
        lblTotalNoTrabajoFeriado.Text = totalConFeriadoNoTrabajado.ToString()
    End Sub
    Private Sub ProcesarAsistencias()
        For Each fila As UltraGridRow In dtgListado.Rows
            For Each celda As UltraGridCell In fila.Cells
                If celda.Column.Key.StartsWith("Dia") Then
                    Dim valor As String = celda.Value.ToString()

                    Select Case valor
                        Case "A"
                            totalAsistenciaCompleta += 1
                        Case "IN"
                            totalIncompletas += 1
                        Case "HEX"
                            totalConHorasExtras += 1
                        Case "PM"
                            totalConPermisoMedico += 1
                        Case "F"
                            totalInasistencias += 1
                        Case "D"
                            totalConDescanso += 1
                        Case "FT"
                            totalConFeriadoTrabajado += 1
                        Case "FNT"
                            totalConFeriadoNoTrabajado += 1
                    End Select
                End If
            Next
        Next

        lblTotalAsistenciaCompleta.Text = totalAsistenciaCompleta.ToString()
        lblTotalIncompleta.Text = totalIncompletas.ToString()
        lblTotalHorasExtras.Text = totalConHorasExtras.ToString()
        lblTotalPermisoMedico.Text = totalConPermisoMedico.ToString()
        lblTotalInasistencias.Text = totalInasistencias.ToString()
        lblTotalDescanso.Text = totalConDescanso.ToString()
        lblTotalTrabajoFeriado.Text = totalConFeriadoTrabajado.ToString()
        lblTotalNoTrabajoFeriado.Text = totalConFeriadoNoTrabajado.ToString()
    End Sub
    Private Function ObtenerPrimerYUltimoHorario(horariosCelda As String) As String()
        Dim horariosSeparados As New List(Of String)
        Dim horario As String = ""

        For i As Integer = 0 To horariosCelda.Length - 1
            horario += horariosCelda(i)
            If horario.Length = 5 Then ' Formato HH:MM
                horariosSeparados.Add(horario)
                horario = ""
            End If
        Next

        If horariosSeparados.Count = 1 Then
            Return New String() {horariosSeparados(0), ""}
        ElseIf horariosSeparados.Count >= 2 Then
            Return New String() {horariosSeparados(0), horariosSeparados(horariosSeparados.Count - 1)}
        Else
            Return New String() {"", ""}
        End If
    End Function

    Private Function VerificacionHorario() As Boolean
        For Each fila As UltraGridRow In dtgListado.Rows
            For Each celda As UltraGridCell In fila.Cells
                If celda.Column.Key.StartsWith("Dia") Then
                    Dim valor As String = celda.Value.ToString()
                    If valor = "IN" Then
                        Return True
                    End If
                End If
            Next
        Next
        Return False
    End Function
    Private Function ObtenerMesDelExcel(archivoExcel As String) As Integer
        Dim mesExcel As Integer = 0

        Try
            Using stream = File.Open(archivoExcel, FileMode.Open, FileAccess.Read)
                Using reader As IExcelDataReader = ExcelReaderFactory.CreateReader(stream)
                    Dim result As DataSet = reader.AsDataSet(New ExcelDataSetConfiguration() With {
                        .ConfigureDataTable = Function() New ExcelDataTableConfiguration() With {
                            .UseHeaderRow = True
                        }
                    })

                    Dim table As DataTable = result.Tables(2)

                    fechaActualExcel = table.Rows(1)(11).ToString()

                    If DateTime.TryParse(fechaActualExcel, fecha) Then
                        mesExcel = fecha.Month
                    Else
                        mesExcel = 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            msj_advert("SELECCIONE UN ARCHIVO EXCEL DE REPORTE DE ASISTENCIA CORRECTO.")
        End Try

        Return mesExcel
    End Function

    Private Function ObtenerListaHorariosStrinEventualQuincena(horariosTrabajadoresEventuales As Dictionary(Of String, List(Of (String, String, String, String, String, String, Integer, String, String, String))), dni As String, mes As Integer) As String
        Dim listaHorariosString As New StringBuilder()
        Dim anioSeleccionado As Integer

        If rbEventual.Checked Then
            anioSeleccionado = CInt(CmbAnios.SelectedItem)
        End If

        If horariosTrabajadoresEventuales.ContainsKey(dni) Then
            Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = horariosTrabajadoresEventuales(dni)
            Dim diasEnElMes As Integer = DateTime.DaysInMonth(anioSeleccionado, mes)

            For diaRecorre As Integer = 1 To diasEnElMes
                Dim entrada As String = listaHorarios(diaRecorre - 1).Item1
                Dim salida As String = listaHorarios(diaRecorre - 1).Item2
                Dim observacion As String = listaHorarios(diaRecorre - 1).Item3
                Dim horasExtras As String = listaHorarios(diaRecorre - 1).Item4
                Dim pagoEspecial As String = listaHorarios(diaRecorre - 1).Item5
                Dim horasTrabajadasTotal As Integer = listaHorarios(diaRecorre - 1).Item6
                Dim horasRefrigerio As Integer = listaHorarios(diaRecorre - 1).Item7
                Dim permisoMedico As String = listaHorarios(diaRecorre - 1).Item8
                Dim feriadoTrabajado As String = listaHorarios(diaRecorre - 1).Item9
                Dim horasExtrasMarranas As String = listaHorarios(diaRecorre - 1).Item10

                Dim formato As String = $"{dni}+{diaRecorre}+{entrada}+{salida}+{observacion}+{horasExtras}+{pagoEspecial}+{horasTrabajadasTotal}+{permisoMedico}+{horasRefrigerio}+{feriadoTrabajado}+{horasExtrasMarranas}"
                listaHorariosString.Append(formato)

                If diaRecorre < diasEnElMes Then
                    listaHorariosString.Append(",")
                End If
            Next
        End If

        Return listaHorariosString.ToString()
    End Function

    Private Function ObtenerListaHorariosString(horariosTrabajadores As Dictionary(Of String, List(Of (String, String, String, String, String, String, Integer, String, String, String))), dni As String, mes As Integer) As String
        Dim listaHorariosString As New StringBuilder()
        Dim anioSeleccionado As Integer

        If rbEventual.Checked Then
            anioSeleccionado = CInt(CmbAnios.SelectedItem)
        ElseIf rbPlanilla.Checked Then
            If generadoEnPlanilla Then
                anioSeleccionado = CInt(CmbAnios.SelectedItem)
            ElseIf generadoEnOperario Then
                anioSeleccionado = CInt(CmbAnios.SelectedItem)
            Else
                anioSeleccionado = anio
            End If
        End If

        If horariosTrabajadores.ContainsKey(dni) Then
            Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = horariosTrabajadores(dni)
            Dim diasEnElMes As Integer = DateTime.DaysInMonth(anioSeleccionado, mes)

            For diaRecorre As Integer = 1 To diasEnElMes
                Dim entrada As String = listaHorarios(diaRecorre - 1).Item1
                Dim salida As String = listaHorarios(diaRecorre - 1).Item2
                Dim observacion As String = listaHorarios(diaRecorre - 1).Item3
                Dim horasExtras As String = listaHorarios(diaRecorre - 1).Item4
                Dim pagoEspecial As String = listaHorarios(diaRecorre - 1).Item5
                Dim horasTrabajadasTotal As Integer = listaHorarios(diaRecorre - 1).Item6
                Dim horasRefrigerio As Integer = listaHorarios(diaRecorre - 1).Item7
                Dim permisoMedico As String = listaHorarios(diaRecorre - 1).Item8
                Dim feriadoTrabajado As String = listaHorarios(diaRecorre - 1).Item9
                Dim horasExtrasMarranas As String = listaHorarios(diaRecorre - 1).Item10

                Dim formato As String = $"{dni}+{diaRecorre}+{entrada}+{salida}+{observacion}+{horasExtras}+{pagoEspecial}+{horasTrabajadasTotal}+{permisoMedico}+{horasRefrigerio}+{feriadoTrabajado}+{horasExtrasMarranas}"
                listaHorariosString.Append(formato)

                If diaRecorre < diasEnElMes Then
                    listaHorariosString.Append(",")
                End If
            Next
        End If

        Return listaHorariosString.ToString()
    End Function

    Private Function ObtenerListaHorariosEventualesStringCruceMeses(horariosTrabajadoresEventuales As Dictionary(Of String, List(Of (String, String, String, String, String, String, Integer, String, String, String))), dni As String, mes As Integer) As String
        Dim listaHorariosString As New StringBuilder()

        ' Determine selected year based on radio button selection
        Dim anioSeleccionado As Integer = If(rbEventual.Checked, CInt(CmbAnios.SelectedItem), anio)

        If horariosTrabajadoresEventuales.ContainsKey(dni) Then
            Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = horariosTrabajadoresEventuales(dni)

            ' Get the first day of the month
            Dim primerDiaMes As DateTime = New DateTime(anioSeleccionado, mes, 1)

            ' Find the first Sunday of the month
            Dim primerDomingo As DateTime = primerDiaMes
            While primerDomingo.DayOfWeek <> DayOfWeek.Sunday
                primerDomingo = primerDomingo.AddDays(1)
            End While

            ' Find the last Sunday and Saturday of the month
            Dim ultimoDiaMes As DateTime = primerDiaMes.AddMonths(1).AddDays(-1)
            Dim ultimoDomingo As DateTime = ultimoDiaMes
            While ultimoDomingo.DayOfWeek <> DayOfWeek.Sunday
                ultimoDomingo = ultimoDomingo.AddDays(-1)
            End While
            Dim ultimoSabado As DateTime = ultimoDomingo.AddDays(6)

            ' Process days from first Sunday to last Saturday
            Dim indice As Integer = 0
            Dim fechaActual As DateTime = primerDomingo

            While fechaActual <= ultimoSabado
                If indice < listaHorarios.Count Then
                    Dim horario = listaHorarios(indice)
                    Dim formato As String = $"{dni}+{fechaActual.Day}+" &
                                      $"{horario.Item1}+{horario.Item2}+" &
                                      $"{horario.Item3}+{horario.Item4}+" &
                                      $"{horario.Item5}+{horario.Item6}+" &
                                      $"{horario.Item8}+{horario.Item7}+" &
                                      $"{horario.Item9}+{horario.Item10}"

                    listaHorariosString.Append(formato)

                    Console.WriteLine($"Día {fechaActual.Day}: {listaHorariosString.ToString()}")

                    If fechaActual < ultimoSabado Then
                        listaHorariosString.Append(",")
                    End If
                End If

                fechaActual = fechaActual.AddDays(1)
                indice += 1
            End While
        End If

        Return listaHorariosString.ToString()
    End Function

    Private Function ObtenerListaHorariosEventualesString(horariosTrabajadoresEventuales As Dictionary(Of String, List(Of (String, String, String, String, String, String, Integer, String, String, String))), dni As String, mes As Integer, diaSeleccionado As Integer) As String
        Dim listaHorariosString As New StringBuilder()

        ' Determine selected year based on radio button selection 
        Dim anioSeleccionado As Integer = If(rbEventual.Checked, CInt(CmbAnios.SelectedItem), anio)

        If horariosTrabajadoresEventuales.ContainsKey(dni) Then
            Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = horariosTrabajadoresEventuales(dni)

            ' Get the first day of the month
            Dim primerDiaMes As DateTime = New DateTime(anioSeleccionado, mes, 1)

            ' Find the first Sunday of the month
            Dim primerDomingo As DateTime = primerDiaMes
            While primerDomingo.DayOfWeek <> DayOfWeek.Sunday
                primerDomingo = primerDomingo.AddDays(1)
            End While

            ' Crear la fecha del día seleccionado
            Dim fechaSeleccionada As DateTime = New DateTime(anioSeleccionado, mes, diaSeleccionado)

            ' Encontrar el domingo de la semana del día seleccionado
            Dim domingoSemanaSeleccionada As DateTime = fechaSeleccionada
            While domingoSemanaSeleccionada.DayOfWeek <> DayOfWeek.Sunday
                domingoSemanaSeleccionada = domingoSemanaSeleccionada.AddDays(-1)
            End While

            ' Calcular el sábado de esa semana
            Dim sabadoSemanaSeleccionada As DateTime = domingoSemanaSeleccionada.AddDays(6)

            ' Calcular el índice de inicio basado en la diferencia desde el primer domingo
            Dim indiceInicio As Integer = CInt((domingoSemanaSeleccionada - primerDomingo).TotalDays)

            ' Procesar solo los 7 días de la semana seleccionada
            Dim fechaActual As DateTime = domingoSemanaSeleccionada
            Dim indice As Integer = indiceInicio

            For i As Integer = 0 To 6 ' Domingo a Sábado (7 días)
                If indice >= 0 AndAlso indice < listaHorarios.Count Then
                    Dim horario = listaHorarios(indice)
                    Dim formato As String = $"{dni}+{fechaActual.Day}+" &
                                      $"{horario.Item1}+{horario.Item2}+" &
                                      $"{horario.Item3}+{horario.Item4}+" &
                                      $"{horario.Item5}+{horario.Item6}+" &
                                      $"{horario.Item8}+{horario.Item7}+" &
                                      $"{horario.Item9}+{horario.Item10}"

                    listaHorariosString.Append(formato)

                    Console.WriteLine($"Semana del día {diaSeleccionado} - Día {fechaActual.Day}: {formato}")

                    If i < 6 Then ' No agregar coma al último elemento
                        listaHorariosString.Append(",")
                    End If
                End If

                fechaActual = fechaActual.AddDays(1)
                indice += 1
            Next
        End If

        Return listaHorariosString.ToString()
    End Function

    Private Function DetectarCruceMesesSimple(mesBase As Integer) As Boolean
        ' Si el mes eventual es diferente al mes base, hay cruce
        Return mesEventual <> mesBase
    End Function

    Private Sub InicializarDtgAsistencia()
        Dim dt As New DataTable()
        dtTrabajadores = New DataTable()

        dtTrabajadores.Columns.Add("Codigo", GetType(Integer))
        dtTrabajadores.Columns.Add("ID", GetType(String))
        dtTrabajadores.Columns.Add("Nombre", GetType(String))
        dtTrabajadores.Columns.Add("Tipo", GetType(String))
        dtTrabajadores.Columns.Add("Eliminar", GetType(Button))

        Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
        Dim anioActual As Integer = DateTime.Now.Year
        Dim diasEnElMes As Integer = DateTime.DaysInMonth(anioActual, mesSeleccionado)

        For i As Integer = 1 To diasEnElMes '31
            dtTrabajadores.Columns.Add($"Dia{i}", GetType(String))
        Next

        dtTrabajadores.Columns.Add("H.T", GetType(Double))
        dtTrabajadores.Columns.Add("H.TR", GetType(Integer))
        dtTrabajadores.Columns.Add("H.EX", GetType(Double))

        dtgListado.DataSource = dtTrabajadores

        With dtgListado.DisplayLayout.Bands(0)
            .Columns.ClearUnbound()

            .Columns("Codigo").Header.Caption = "Cod."
            .Columns("ID").Header.Caption = "DNI"
            .Columns("Nombre").Header.Caption = "Personal"
            .Columns("Tipo").Header.Caption = "Tipo"
            .Columns("Eliminar").Header.Caption = ""
            .Columns("Codigo").Width = 70
            .Columns("ID").Width = 130
            .Columns("Nombre").Width = 200
            .Columns("Tipo").Width = 100
            .Columns("Eliminar").Style = UltraWinGrid.ColumnStyle.Button
            .Columns("Eliminar").CellButtonAppearance.Image = My.Resources.ico_eliminar
            .Columns("Eliminar").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            .Override.HeaderAppearance.TextHAlign = HAlign.Center
            .Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True

            .Groups.Clear()
            .RowLayoutStyle = RowLayoutStyle.GroupLayout

            Dim groupGeneral As UltraGridGroup = .Groups.Add("Información General", "Información General")
            Dim group1 As UltraGridGroup = .Groups.Add("Primera Quincena", "Primera Quincena")
            Dim group2 As UltraGridGroup = .Groups.Add("Segunda Quincena", "Segunda Quincena")

            .Columns("Codigo").RowLayoutColumnInfo.ParentGroup = groupGeneral
            .Columns("ID").RowLayoutColumnInfo.ParentGroup = groupGeneral
            .Columns("Nombre").RowLayoutColumnInfo.ParentGroup = groupGeneral
            .Columns("Tipo").RowLayoutColumnInfo.ParentGroup = groupGeneral

            For i As Integer = 1 To diasEnElMes '31
                Dim diaCol As String = $"Dia{i}"
                If .Columns.Exists(diaCol) Then
                    Dim col As UltraGridColumn = .Columns(diaCol)
                    col.Header.Caption = i.ToString()
                    col.Width = 50
                    col.CellAppearance.TextHAlign = HAlign.Center

                    If i <= 15 Then
                        col.RowLayoutColumnInfo.ParentGroup = group1
                    Else
                        col.RowLayoutColumnInfo.ParentGroup = group2
                    End If
                End If
            Next

            Dim groupHoras As UltraGridGroup = .Groups.Add("Informe de Horas", "Informe de Horas")

            For Each colName As String In {"H.T", "H.TR", "H.EX"}
                If .Columns.Exists(colName) Then
                    Dim col As UltraGridColumn = .Columns(colName)
                    col.Width = 50
                    col.CellAppearance.TextHAlign = HAlign.Center
                    col.RowLayoutColumnInfo.ParentGroup = groupHoras
                End If
            Next
        End With

        dtgListado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        clsBasicas.Filtrar_Tabla(dtgListado, False)
    End Sub


    Sub ListarPlanteles()
        Try
            Dim dt As New DataTable

            dt = cn.Cn_ListarPlanteles().Copy
            dt.TableName = "tmp"
            dt.Columns(1).ColumnName = "Seleccione un Plantel"
            With cbxListarPlanteles
                .DataSource = dt
                .DisplayMember = dt.Columns(1).ColumnName
                .ValueMember = dt.Columns(0).ColumnName
                If (dt.Rows.Count > 0) Then
                    .Value = dt.Rows(0)(0)
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Function ObtenerSemanaDelAnio(fecha As DateTime) As Integer
        Dim culture As CultureInfo = CultureInfo.CurrentCulture
        Dim calendar As Calendar = culture.Calendar
        Dim weekOfYear As Integer = calendar.GetWeekOfYear(fecha, culture.DateTimeFormat.CalendarWeekRule, culture.DateTimeFormat.FirstDayOfWeek)

        If weekOfYear > 52 Then
            Return 1
        Else
            Return weekOfYear
        End If
    End Function
    Function ObtenerSemanasDelMes(anio As Integer, mes As Integer) As List(Of (Inicio As DateTime, Fin As DateTime, Semana As Integer))
        Dim semanas As New List(Of (Inicio As DateTime, Fin As DateTime, Semana As Integer))()
        Dim fechaActual As New DateTime(anio, mes, 1)

        While fechaActual.Month = mes
            Dim semana As Integer = ObtenerSemanaDelAnio(fechaActual)

            Dim primerDiaDeLaSemana As DateTime = fechaActual.AddDays(-CInt(fechaActual.DayOfWeek) + CInt(CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek))
            Dim ultimoDiaDeLaSemana As DateTime = primerDiaDeLaSemana.AddDays(6)

            If primerDiaDeLaSemana.Month = mes OrElse ultimoDiaDeLaSemana.Month = mes Then
                If primerDiaDeLaSemana < New DateTime(anio, mes, 1) Then
                    primerDiaDeLaSemana = New DateTime(anio, mes, 1)
                End If
                If ultimoDiaDeLaSemana > New DateTime(anio, mes, DateTime.DaysInMonth(anio, mes)) Then
                    ultimoDiaDeLaSemana = New DateTime(anio, mes, DateTime.DaysInMonth(anio, mes))
                End If

                semanas.Add((primerDiaDeLaSemana, ultimoDiaDeLaSemana, semana))
            End If

            fechaActual = ultimoDiaDeLaSemana.AddDays(1)
        End While

        Return semanas.Distinct().ToList()
    End Function
    Sub MostrarSemanasEnLabel(mes As Integer, anio As Integer, label As Label)

        Dim nombreMes As String = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes)
        Dim semanasDelMes As List(Of (Inicio As DateTime, Fin As DateTime, Semana As Integer)) = ObtenerSemanasDelMes(anio, mes)

        label.Text = ""
        label.Text = $"Semana del mes {nombreMes} , {anio}:{Environment.NewLine}{Environment.NewLine}"

        For Each semana In semanasDelMes
            label.Text &= $"Semana {semana.Semana}: del {semana.Inicio.Day()} al {semana.Fin.Day()}" & Environment.NewLine
        Next
    End Sub

    Public Sub LlenarTablaAsistencia(dni As String, datos As String, tipo As String)
        totalAsistenciaCompleta = Nothing
        totalInasistencias = Nothing
        totalConHorasExtras = Nothing
        totalConPermisoMedico = Nothing
        totalIncompletas = Nothing
        totalConDescanso = Nothing
        totalConFeriadoTrabajado = Nothing
        totalConFeriadoNoTrabajado = Nothing

        If rbEventual.Checked AndAlso tipo = "PLANILLA" Then
            msj_advert("No se puede agregar a la tabla. Los tipos 'PLANILLA' no son permitidos cuando en el registro de trabajadores eventuales.")
            Return
        ElseIf rbPlanilla.Checked AndAlso tipo = "EVENTUAL" Then
            msj_advert("No se puede agregar a la tabla. Los tipos 'EVENTUAL' no son permitidos cuando en el registro de trabajadores de planilla.")
            Return
        End If

        For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If fila.Cells("ID").Value.ToString() = dni Then
                msj_advert($"La persona {datos} con el DNI {dni} ya existe en la tabla. No se puede agregar la misma persona más de una vez.")
                Exit Sub
            End If
        Next

        Dim rangoInicio As Integer
        Dim rangoFin As Integer

        If rbEventual.Checked Then
            rangoInicio = 0
            rangoFin = 0
        ElseIf rbPlanilla.Checked Then
            If generadoEnPlanilla Then
                rangoInicio = 0
                rangoFin = 0
            ElseIf generadoEnOperario Then
                rangoInicio = 0
                rangoFin = 0
            Else
                If ultimoDiaRegistro > 0 Then
                    rangoInicio = ultimoDiaRegistro + 1
                    rangoFin = dia
                Else
                    rangoInicio = 1
                    rangoFin = dia
                End If
            End If
        End If

        Dim dr As DataRow
        Dim horasTotales As Double = 0
        Dim horasNormales As Integer = 0
        Dim horasAdicionales As Double = 0
        Dim mesCb As Integer = cbListaMeses.SelectedIndex + 1

        Dim anioSeleccionado As Integer
        Dim mesSeleccionado As Integer


        If rbEventual.Checked Then
            anioSeleccionado = CInt(CmbAnios.SelectedItem)
            mesSeleccionado = mesCb
        ElseIf rbPlanilla.Checked Then
            If generadoEnPlanilla Then
                anioSeleccionado = CInt(CmbAnios.SelectedItem)
                mesSeleccionado = mesCb
            ElseIf generadoEnOperario Then
                anioSeleccionado = CInt(CmbAnios.SelectedItem)
                mesSeleccionado = mesCb
            Else
                anioSeleccionado = anio
                mesSeleccionado = mes
            End If

        ElseIf rbEventualPlanilla.Checked Then
            anioSeleccionado = anio
            mesSeleccionado = mes
        End If

        Dim anioActual As Integer = anioSeleccionado
        Dim diasEnElMes As Integer = DateTime.DaysInMonth(anioSeleccionado, mesSeleccionado)

        dr = dtTrabajadores.NewRow
        dr("ID") = dni
        dr("Nombre") = datos
        dr("Tipo") = tipo

        Dim listaHorarios As New List(Of (String, String, String, String, String, String, Integer, String, String, String))()
        Dim listaHorariosEventuales As New List(Of (String, String, String, String, String, String, Integer, String, String, String))()

        For i As Integer = 1 To diasEnElMes
            Dim entrada As String = ""
            Dim salida As String = ""
            Dim observacion As String = "Sin observación"
            Dim horasExtras As String = "0"
            Dim pagoEspecial As String = "0"
            Dim horasTrabajadasTotal As String = "0"
            Dim horasLaboradas As String = "0"
            Dim horasRefrigerio As Integer = 1
            Dim permisoMedico As String = "NO"
            Dim feriadoTrabajado As String = "SIN ASIGNAR"
            Dim horasExtrasMarranas As String = "0"

            Dim resultado As String

            If i >= rangoInicio AndAlso i <= rangoFin Then
                If String.IsNullOrWhiteSpace(entrada) AndAlso String.IsNullOrWhiteSpace(salida) Then
                    resultado = "F"
                ElseIf String.IsNullOrWhiteSpace(entrada) OrElse String.IsNullOrWhiteSpace(salida) Then
                    resultado = "IN"
                Else
                    resultado = "A"
                    Dim horaEntrada As DateTime = DateTime.Parse(entrada)
                    Dim horaSalida As DateTime = DateTime.Parse(salida)
                    Dim diferencia As TimeSpan = horaSalida - horaEntrada
                    Dim horasTrabajadas As Integer = Math.Floor(diferencia.TotalHours)
                    horasTrabajadas = Math.Max(0, horasTrabajadas - horasRefrigerio)

                    If horasTrabajadas > 8 Then
                        resultado = "HEX"
                    Else
                        resultado = "A"
                    End If

                    If resultado = "A" OrElse resultado = "HEX" Then
                        horasTotales += horasTrabajadas
                        If horasTrabajadas > 8 Then
                            horasNormales += 8
                            horasAdicionales += (horasTrabajadas - 8)
                        Else
                            horasNormales += horasTrabajadas
                        End If
                    End If
                End If
            Else
                resultado = "-"
            End If

            dr($"Dia{i}") = resultado

            If tipo = "PLANILLA" Then
                listaHorarios.Add((entrada, salida, observacion, horasExtras, pagoEspecial, horasTrabajadasTotal, horasRefrigerio, permisoMedico, feriadoTrabajado, horasExtrasMarranas))
            ElseIf tipo = "EVENTUAL" Then
                listaHorariosEventuales.Add((entrada, salida, observacion, horasExtras, pagoEspecial, horasTrabajadasTotal, horasRefrigerio, permisoMedico, feriadoTrabajado, horasExtrasMarranas))
            End If
        Next

        dr("H.T") = horasTotales
        dr("H.TR") = horasNormales
        dr("H.EX") = horasAdicionales

        dtTrabajadores.Rows.Add(dr)

        If rbEventualPlanilla.Checked Then
            If tipo = "PLANILLA" Then
                If Not horariosTrabajadores.ContainsKey(dni) Then
                    horariosTrabajadores.Add(dni, listaHorarios)
                End If
            ElseIf tipo = "EVENTUAL" Then
                If Not horariosTrabajadoresEventuales.ContainsKey(dni) Then
                    horariosTrabajadoresEventuales.Add(dni, listaHorariosEventuales)
                End If
            End If
        ElseIf rbEventual.Checked Then
            If tipo = "EVENTUAL" Then
                If Not horariosTrabajadoresEventuales.ContainsKey(dni) Then
                    horariosTrabajadores.Add(dni, listaHorariosEventuales)
                End If
            End If
        ElseIf rbPlanilla.Checked Then
            If tipo = "PLANILLA" Then
                If Not horariosTrabajadores.ContainsKey(dni) Then
                    horariosTrabajadores.Add(dni, listaHorarios)
                End If
            End If
        End If

        Dim ultimaFilaIndex As Integer = dtTrabajadores.Rows.Count - 1

        dtTrabajadores.Rows(ultimaFilaIndex)("Codigo") = ultimaFilaIndex + 1

        Dim cell As Infragistics.Win.UltraWinGrid.UltraGridCell = dtgListado.Rows(ultimaFilaIndex).Cells("Codigo")
        cell.Appearance.BackColor = Color.FromArgb(205, 255, 0)

        'ConfigurarUltraGrid()
        Colorear()
        ProcesarAsistencias()
    End Sub

    Public Sub LlenarTablaAsistenciaEventual(dni As String, datos As String, tipo As String)
        totalAsistenciaCompleta = Nothing
        totalInasistencias = Nothing
        totalConHorasExtras = Nothing
        totalConPermisoMedico = Nothing
        totalIncompletas = Nothing
        totalConDescanso = Nothing
        totalConFeriadoTrabajado = Nothing
        totalConFeriadoNoTrabajado = Nothing

        ' Validaciones iniciales de tipo de trabajador
        If rbEventual.Checked AndAlso tipo = "PLANILLA" Then
            msj_advert("No se puede agregar a la tabla. Los tipos 'PLANILLA' no son permitidos cuando en el registro de trabajadores eventuales.")
            Return
        ElseIf rbPlanilla.Checked AndAlso tipo = "EVENTUAL" Then
            msj_advert("No se puede agregar a la tabla. Los tipos 'EVENTUAL' no son permitidos cuando en el registro de trabajadores de planilla.")
            Return
        End If

        ' Verificar si el DNI ya existe
        For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If fila.Cells("ID").Value.ToString() = dni Then
                msj_advert($"La persona {datos} con el DNI {dni} ya existe en la tabla. No se puede agregar la misma persona más de una vez.")
                Exit Sub
            End If
        Next

        Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
        Dim anioSeleccionado As Integer = CInt(CmbAnios.SelectedItem)

        ' Obtener el primer día del mes
        Dim primerDiaMes As DateTime = New DateTime(anioSeleccionado, mesSeleccionado, 1)

        ' Encontrar el primer domingo del mes
        Dim primerDomingo As DateTime = primerDiaMes
        While primerDomingo.DayOfWeek <> DayOfWeek.Sunday
            primerDomingo = primerDomingo.AddDays(1)
        End While

        ' Encontrar el último domingo del mes y el último día de la última semana (sábado)
        Dim ultimoDiaMes As DateTime = primerDiaMes.AddMonths(1).AddDays(-1)
        Dim ultimoDomingo As DateTime = ultimoDiaMes
        While ultimoDomingo.DayOfWeek <> DayOfWeek.Sunday
            ultimoDomingo = ultimoDomingo.AddDays(-1)
        End While
        Dim ultimoSabado As DateTime = ultimoDomingo.AddDays(6) ' Aseguramos incluir hasta el sábado

        Dim dr As DataRow = dtTrabajadores.NewRow
        dr("ID") = dni
        dr("Nombre") = datos
        dr("Tipo") = tipo

        Dim horasTotales As Double = 0
        Dim horasNormales As Integer = 0
        Dim horasAdicionales As Double = 0
        Dim listaHorariosEventuales As New List(Of (String, String, String, String, String, String, Integer, String, String, String))()

        ' Procesar días por semanas
        Dim fechaActual As DateTime = primerDomingo
        While fechaActual <= ultimoSabado ' Procesamos hasta el último sábado
            Dim diaDelMes As Integer = fechaActual.Day
            Dim nombreColumna As String = $"Dia{fechaActual:dd-MM}"

            Dim entrada As String = ""
            Dim salida As String = ""
            Dim observacion As String = "Sin observación"
            Dim horasExtras As String = "0"
            Dim pagoEspecial As String = "0"
            Dim horasTrabajadasTotal As String = "0"
            Dim horasRefrigerio As Integer = 1
            Dim permisoMedico As String = "NO"
            Dim feriadoTrabajado As String = "SIN ASIGNAR"
            Dim horasExtrasMarranas As String = "0" ' Para horas extras adicionales

            Dim resultado As String = "-"
            If rbEventual.Checked Then
                ' Aquí puedes agregar lógica específica para eventuales
                resultado = "-" ' Por defecto, día no trabajado
            End If

            dr(nombreColumna) = resultado

            listaHorariosEventuales.Add((entrada, salida, observacion, horasExtras,
                                   pagoEspecial, horasTrabajadasTotal,
                                   horasRefrigerio, permisoMedico, feriadoTrabajado, horasExtrasMarranas))

            fechaActual = fechaActual.AddDays(1)
        End While

        dr("H.T") = horasTotales
        dr("H.TR") = horasNormales
        dr("H.EX") = horasAdicionales

        dtTrabajadores.Rows.Add(dr)

        ' Manejar los horarios de trabajadores eventuales
        If rbEventual.Checked AndAlso tipo = "EVENTUAL" Then
            If Not horariosTrabajadoresEventuales.ContainsKey(dni) Then
                horariosTrabajadoresEventuales.Add(dni, listaHorariosEventuales)
            End If
        End If

        ' Asignar código y colorear la última fila
        Dim ultimaFilaIndex As Integer = dtTrabajadores.Rows.Count - 1
        dtTrabajadores.Rows(ultimaFilaIndex)("Codigo") = ultimaFilaIndex + 1

        Dim cell As Infragistics.Win.UltraWinGrid.UltraGridCell = dtgListado.Rows(ultimaFilaIndex).Cells("Codigo")
        cell.Appearance.BackColor = Color.FromArgb(205, 255, 0)

        Colorear()
        ProcesarAsistencias()
    End Sub

    Public Sub LlenarTablaAsistenciaEventualQuincena(dni As String, datos As String, tipo As String)
        totalAsistenciaCompleta = Nothing
        totalInasistencias = Nothing
        totalConHorasExtras = Nothing
        totalConPermisoMedico = Nothing
        totalIncompletas = Nothing
        totalConDescanso = Nothing
        totalConFeriadoTrabajado = Nothing
        totalConFeriadoNoTrabajado = Nothing

        If rbEventual.Checked AndAlso tipo = "PLANILLA" Then
            msj_advert("No se puede agregar a la tabla. Los tipos 'PLANILLA' no son permitidos cuando en el registro de trabajadores eventuales.")
            Return
        ElseIf rbPlanilla.Checked AndAlso tipo = "EVENTUAL" Then
            msj_advert("No se puede agregar a la tabla. Los tipos 'EVENTUAL' no son permitidos cuando en el registro de trabajadores de planilla.")
            Return
        End If

        For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If fila.Cells("ID").Value.ToString() = dni Then
                msj_advert($"La persona {datos} con el DNI {dni} ya existe en la tabla. No se puede agregar la misma persona más de una vez.")
                Exit Sub
            End If
        Next

        Dim rangoInicio As Integer
        Dim rangoFin As Integer

        If rbEventual.Checked Then
            rangoInicio = 0
            rangoFin = 0
        End If

        Dim dr As DataRow
        Dim horasTotales As Double = 0
        Dim horasNormales As Integer = 0
        Dim horasAdicionales As Double = 0
        Dim mesCb As Integer = cbListaMeses.SelectedIndex + 1

        Dim anioSeleccionado As Integer
        Dim mesSeleccionado As Integer


        If rbEventual.Checked Then
            anioSeleccionado = CInt(CmbAnios.SelectedItem)
            mesSeleccionado = mesCb
        End If

        Dim anioActual As Integer = anioSeleccionado
        Dim diasEnElMes As Integer = DateTime.DaysInMonth(anioSeleccionado, mesSeleccionado)

        dr = dtTrabajadores.NewRow
        dr("ID") = dni
        dr("Nombre") = datos
        dr("Tipo") = tipo

        Dim listaHorarios As New List(Of (String, String, String, String, String, String, Integer, String, String, String))()
        Dim listaHorariosEventuales As New List(Of (String, String, String, String, String, String, Integer, String, String, String))()

        For i As Integer = 1 To diasEnElMes
            Dim entrada As String = ""
            Dim salida As String = ""
            Dim observacion As String = "Sin observación"
            Dim horasExtras As String = "0"
            Dim pagoEspecial As String = "0"
            Dim horasTrabajadasTotal As String = "0"
            Dim horasLaboradas As String = "0"
            Dim horasRefrigerio As Integer = 1
            Dim permisoMedico As String = "NO"
            Dim feriadoTrabajado As String = "SIN ASIGNAR"
            Dim horasExtrasMarranas As String = "0" ' Para horas extras adicionales

            Dim resultado As String = ""

            If generadoQuincenaEventual Then
                resultado = "-"
            End If

            dr($"Dia{i}") = resultado

            listaHorariosEventuales.Add((entrada, salida, observacion, horasExtras, pagoEspecial, horasTrabajadasTotal, horasRefrigerio, permisoMedico, feriadoTrabajado, horasExtrasMarranas))


            Console.WriteLine($"Día {i}: {resultado}")
        Next

        dr("H.T") = horasTotales
        dr("H.TR") = horasNormales
        dr("H.EX") = horasAdicionales

        dtTrabajadores.Rows.Add(dr)

        If rbEventual.Checked Then
            If tipo = "EVENTUAL" Then
                If Not horariosTrabajadoresEventuales.ContainsKey(dni) Then
                    horariosTrabajadoresEventuales.Add(dni, listaHorariosEventuales)
                End If
            End If
        End If

        Dim ultimaFilaIndex As Integer = dtTrabajadores.Rows.Count - 1

        dtTrabajadores.Rows(ultimaFilaIndex)("Codigo") = ultimaFilaIndex + 1

        Dim cell As Infragistics.Win.UltraWinGrid.UltraGridCell = dtgListado.Rows(ultimaFilaIndex).Cells("Codigo")
        cell.Appearance.BackColor = Color.FromArgb(205, 255, 0)

        'ConfigurarUltraGrid()
        Colorear()
        ProcesarAsistencias()
    End Sub

    Sub Desactivar()
        cbListaMeses.Enabled = False
        cbxListarPlanteles.ReadOnly = True
        tbRutaArchivoExcel.Enabled = False
        btnAplicarRrhhCtrlasist.Visible = True ' Nuevo
    End Sub

    Sub Activar()
        cbListaMeses.Enabled = True
        ''cbxListarPlanteles.ReadOnly = False
        tbRutaArchivoExcel.Enabled = True
        dtTrabajadores.Clear()
    End Sub

    Sub Limpiar()
        dtTrabajadores.Clear()
        tbRutaArchivoExcel.Clear()
        cbListaMeses.SelectedIndex = DateTime.Now.Month - 1
        cbxListarPlanteles.SelectedRow = cbxListarPlanteles.Rows(0)
        cbListaMeses.Enabled = True
        cbxListarPlanteles.ReadOnly = False
        tbRutaArchivoExcel.Enabled = True
        CmbAnios.Enabled = True
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            For Each fila As UltraGridRow In dtgListado.Rows
                For Each celda As UltraGridCell In fila.Cells
                    If celda.Column.Key.StartsWith("Dia") Then
                        Dim valor As String = celda.Value.ToString()
                        Dim columna As Integer = celda.Column.Index
                        Select Case valor
                            Case "F"
                                clsBasicas.Colorear_SegunValor(dtgListado, Color.FromArgb(250, 185, 185), Color.Black, "F", columna)
                            Case "HEX"
                                clsBasicas.Colorear_SegunValor(dtgListado, Color.FromArgb(252, 252, 196), Color.Black, "HEX", columna)
                            Case "A"
                                clsBasicas.Colorear_SegunValor(dtgListado, Color.FromArgb(226, 239, 219), Color.Black, "A", columna)
                            Case "PM"
                                clsBasicas.Colorear_SegunValor(dtgListado, Color.FromArgb(252, 195, 142), Color.Black, "PM", columna)
                            Case "IN"
                                clsBasicas.Colorear_SegunValor(dtgListado, Color.FromArgb(156, 188, 226), Color.Black, "IN", columna)
                            Case "V"
                                clsBasicas.Colorear_SegunValor(dtgListado, Color.FromArgb(255, 120, 7), Color.Black, "V", columna)
                            Case "D"
                                clsBasicas.Colorear_SegunValor(dtgListado, Color.FromArgb(157, 213, 241), Color.Black, "D", columna)
                            Case "FT"
                                clsBasicas.Colorear_SegunValor(dtgListado, Color.FromArgb(220, 200, 240), Color.Black, "FT", columna)
                            Case "FNT"
                                clsBasicas.Colorear_SegunValor(dtgListado, Color.FromArgb(188, 210, 238), Color.Black, "FNT", columna)
                            Case "-"
                                clsBasicas.Colorear_SegunValor(dtgListado, Color.FromArgb(167, 167, 167), Color.Black, "-", columna)
                        End Select
                    End If
                Next
            Next
        End If
    End Sub

    Sub LimpiarContadores()
        horariosTrabajadores.Clear()
        horariosTrabajadoresEventuales.Clear()
        dtTrabajadores.Clear()
        labelSemanas.Text = "Semanas del excel importado"
        lblSetFechaActual.Text = "-"
        lblSetPeriodo.Text = "-"
        lblTotalAsistenciaCompleta.Text = "TotalAsis"
        lblTotalInasistencias.Text = "TotalFalta"
        lblTotalIncompleta.Text = "TotalIncom"
        lblTotalHorasExtras.Text = "TotalHEX"
        lblTotalPermisoMedico.Text = "TotalPM"
        lblTotalDescanso.Text = "TotalDesc"
        lblTotalTrabajoFeriado.Text = "TotalTrabFer"
        lblTotalNoTrabajoFeriado.Text = "TotalNoTrabFer"
    End Sub

    Private Sub rbEventual_CheckedChanged(sender As Object, e As EventArgs) Handles rbPlanilla.CheckedChanged, rbEventual.CheckedChanged, rbEventualPlanilla.CheckedChanged
        If rbEventual.Checked Then
            btnImportar.Enabled = False
            btnProcesar.Enabled = False
            tbRutaArchivoExcel.Enabled = False
            'cbxListarPlanteles.ReadOnly = False
            cbListaMeses.Enabled = True
            lblAño.Visible = True
            CmbAnios.Visible = True
            btnAplicarRrhhCtrlasist.Visible = False

            ' Nuevo para la quincena del eventual
            btnQuincenaEventual.Visible = True

            LimpiarContadores()
            InicializarDtgAsistenciaSemanal()
        ElseIf rbPlanilla.Checked Then
            btnImportar.Enabled = True
            btnProcesar.Enabled = True
            tbRutaArchivoExcel.Enabled = True
            'cbxListarPlanteles.ReadOnly = False
            cbListaMeses.Enabled = True
            lblAño.Visible = False
            CmbAnios.Visible = False
            CmbAnios.Enabled = True

            ' Nuevo para la quincena del eventual
            btnQuincenaEventual.Visible = False

            LimpiarContadores()
            InicializarDtgAsistencia()
        ElseIf rbEventualPlanilla.Checked Then
            btnImportar.Enabled = True
            btnProcesar.Enabled = True
            tbRutaArchivoExcel.Enabled = True
            cbxListarPlanteles.ReadOnly = False
            cbListaMeses.Enabled = True
            lblAño.Visible = False
            CmbAnios.Visible = False
            CmbAnios.Enabled = True
            LimpiarContadores()
        End If
    End Sub

    Private Sub ObtenerAnios()
        For i As Integer = DateTime.Now.Year - 10 To DateTime.Now.Year + 20
            CmbAnios.Items.Add(i.ToString())
        Next
        CmbAnios.DropDownStyle = ComboBoxStyle.DropDownList
        CmbAnios.Text = DateTime.Now.Year.ToString()
    End Sub

    Private Sub btnGenerarRrhhCtrlasist_Click(sender As Object, e As EventArgs) Handles btnGenerarRrhhCtrlasist.Click
        If rbPlanilla.Checked Then
            If (MessageBox.Show("¿ESTÁ SEGURO DE GENERAR LA PLANILLA ADMINISTRATIVA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            btnAplicarRrhhCtrlasist.Visible = True
            btnGenerarRrhhCtrlasist.Visible = False
            btnCancelarRrhhCtrlasist.Visible = True
            tbRutaArchivoExcel.ReadOnly = True
            btnImportar.Enabled = False
            btnProcesar.Enabled = False
            cbxListarPlanteles.ReadOnly = True
            cbxListarPlanteles.Value = 11
            generadoEnPlanilla = True
            CmbAnios.Visible = True
            dtTrabajadores.Clear()
            horariosTrabajadores.Clear()
            msj_ok("Ahora puedes registrar la asistencia de los trabajadores administrativos")
        Else
            msj_advert("No puedes generar la planilla administrativa para eventuales")
        End If
    End Sub

    Private Sub btnCancelarRrhhCtrlasist_Click(sender As Object, e As EventArgs) Handles btnCancelarRrhhCtrlasist.Click
        If rbPlanilla.Checked Then
            If (MessageBox.Show("¿ESTÁ SEGURO DE CANCELAR LA PLANILLA ADMINISTRATIVA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            btnAplicarRrhhCtrlasist.Visible = False
            btnGenerarRrhhCtrlasist.Visible = True
            btnCancelarRrhhCtrlasist.Visible = False
            tbRutaArchivoExcel.ReadOnly = False
            btnImportar.Enabled = True
            btnProcesar.Enabled = True
            cbxListarPlanteles.ReadOnly = False
            cbxListarPlanteles.Value = 1
            cbListaMeses.Enabled = True
            generadoEnPlanilla = False
            CmbAnios.Visible = False
            dtTrabajadores.Clear()
            horariosTrabajadores.Clear()
            msj_ok("Ha sido cancelada la generación de planilla administrativa")
        Else
            msj_advert("No puedes generar la planilla administrativa para eventuales")
        End If
    End Sub

    Private Sub btnAplicarRrhhCtrlasist_Click(sender As Object, e As EventArgs) Handles btnAplicarRrhhCtrlasist.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If dtgListado.Rows.Count > 0 Then
            If activeRow IsNot Nothing AndAlso Not String.IsNullOrEmpty(activeRow.Cells(0).Value.ToString()) Then
                If activeRow.Band.Index = 0 Then
                    If MessageBox.Show("¿Está seguro de aplicar asistencia al trabajador seleccionado?", "Aplicar Asistencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        Dim dni As String = activeRow.Cells("ID").Value.ToString()

                        If generadoEnPlanilla Then
                            ' Update horariosTrabajadores dictionary
                            If horariosTrabajadores.ContainsKey(dni) Then
                                Dim listaHorarios = horariosTrabajadores(dni)

                                For i As Integer = 0 To listaHorarios.Count - 1

                                    ' Set ultimoDiaRegEventual
                                    ultimoDiaRegistroEventual = i + 1

                                    Console.WriteLine("Ultimo dia Registro: " + ultimoDiaRegistroEventual.ToString())

                                    ' Set default work hours
                                    Dim entrada As String = "08:00"
                                    Dim salida As String = "18:00"

                                    listaHorarios(i) = (
                                    entrada,           ' Hora Entrada
                                    salida,            ' Hora Salida
                                    "Sin observación", ' Observación
                                    "0",               ' Horas Extras
                                    "0",               ' Pago Especial
                                    "8",               ' Horas Trabajadas
                                    2,                 ' Horas Refrigerio
                                    "NO",               ' Permiso Médico
                                    "SIN ASIGNAR",      ' Feriado
                                    "0"                ' Horas Extras Marranas 
                                )

                                    ' Update grid cell value
                                    activeRow.Cells($"Dia{i + 1}").Value = "A"
                                Next

                                ' Recalculate totals
                                activeRow.Cells("H.T").Value = listaHorarios.Count * 8
                                activeRow.Cells("H.TR").Value = listaHorarios.Count * 8
                                activeRow.Cells("H.EX").Value = 0

                                Colorear()
                                ReiniciarContadores()
                                ProcesarAsistencias()

                                msj_ok("Asistencia aplicada correctamente.")
                            End If
                        ElseIf generadoEnOperario Then
                            Dim obj As New coControlAsistencia
                            obj.IdUbicacion = cbxListarPlanteles.Value
                            obj.Anio = CInt(CmbAnios.SelectedItem)
                            obj.Mes = cbListaMeses.SelectedIndex + 1
                            obj.Tipo = "PLANILLA"
                            Dim mensaje As String = cn.Cn_ConsOperariosAsistencia(obj)

                            If obj.CodeError = 0 Then
                                Dim diasEnElMes As Integer = DateTime.DaysInMonth(obj.Anio, obj.Mes)
                                Dim diaInicio As Integer = If(obj.Tipoperiodo = "QUINCENA 1", 1, 16)
                                Dim diaFin As Integer = If(obj.Tipoperiodo = "QUINCENA 2", diasEnElMes, 15)

                                If obj.Tipoperiodo = "QUINCENA 1" Then
                                    rangoInicioOperario = 1
                                    rangoFinOperario = 15
                                ElseIf obj.Tipoperiodo = "QUINCENA 2" Then
                                    rangoInicioOperario = 16
                                    rangoFinOperario = diasEnElMes
                                End If

                                If horariosTrabajadores.ContainsKey(dni) Then
                                    Dim listaHorarios = horariosTrabajadores(dni)

                                    For i As Integer = diaInicio - 1 To diaFin - 1
                                        ' Set ultimoDiaRegEventual
                                        ultimoDiaRegistroEventual = i + 1
                                        Console.WriteLine("Ultimo dia Registro: " + ultimoDiaRegistroEventual.ToString())

                                        ' Set default work hours
                                        Dim entrada As String = "08:00"
                                        Dim salida As String = "17:00"

                                        listaHorarios(i) = (
                                            entrada,           ' Hora Entrada
                                            salida,            ' Hora Salida
                                            "Sin observación", ' Observación
                                            "0",               ' Horas Extras
                                            "0",               ' Pago Especial
                                            "8",               ' Horas Trabajadas
                                            1,                 ' Horas Refrigerio
                                            "NO",               ' Permiso Médico
                                            "SIN ASIGNAR",      ' Feriado
                                            "0"                ' Horas Extras Marranas
                                        )

                                        ' Update grid cell value
                                        activeRow.Cells($"Dia{i + 1}").Value = "A"
                                    Next

                                    ' Recalculate totals basado en los días de la quincena
                                    Dim diasTrabajados As Integer = diaFin - diaInicio + 1
                                    activeRow.Cells("H.T").Value = diasTrabajados * 8
                                    activeRow.Cells("H.TR").Value = diasTrabajados * 8
                                    activeRow.Cells("H.EX").Value = 0

                                    Colorear()
                                    ReiniciarContadores()
                                    ProcesarAsistencias()

                                    msj_ok("Asistencia aplicada correctamente.")
                                End If
                            End If
                        ElseIf generadoQuincenaEventual Then
                            Dim obj As New coControlAsistencia
                            obj.IdUbicacion = cbxListarPlanteles.Value
                            obj.Anio = CInt(CmbAnios.SelectedItem)
                            obj.Mes = cbListaMeses.SelectedIndex + 1
                            obj.Tipo = "EVENTUAL"
                            Dim mensaje As String = cn.Cn_ConsOperariosAsistencia(obj)

                            If obj.CodeError = 0 Then
                                Dim diasEnElMes As Integer = DateTime.DaysInMonth(obj.Anio, obj.Mes)
                                Dim diaInicio As Integer = If(obj.Tipoperiodo = "QUINCENA 1", 1, 16)
                                Dim diaFin As Integer = If(obj.Tipoperiodo = "QUINCENA 2", diasEnElMes, 15)

                                If obj.Tipoperiodo = "QUINCENA 1" Then
                                    rangoInicioOperario = 1
                                    rangoFinOperario = 15
                                ElseIf obj.Tipoperiodo = "QUINCENA 2" Then
                                    rangoInicioOperario = 16
                                    rangoFinOperario = diasEnElMes
                                End If

                                If horariosTrabajadoresEventuales.ContainsKey(dni) Then
                                    Dim listaHorarios = horariosTrabajadoresEventuales(dni)

                                    For i As Integer = diaInicio - 1 To diaFin - 1
                                        ' Set ultimoDiaRegEventual
                                        ultimoDiaRegistroEventual = i + 1
                                        Console.WriteLine("Ultimo dia Registro: " + ultimoDiaRegistroEventual.ToString())

                                        ' Set default work hours
                                        Dim entrada As String = "08:00"
                                        Dim salida As String = "17:00"

                                        listaHorarios(i) = (
                                            entrada,           ' Hora Entrada
                                            salida,            ' Hora Salida
                                            "Sin observación", ' Observación
                                            "0",               ' Horas Extras
                                            "0",               ' Pago Especial
                                            "8",               ' Horas Trabajadas
                                            1,                 ' Horas Refrigerio
                                            "NO",               ' Permiso Médico
                                            "SIN ASIGNAR",      ' Feriado
                                            "0"                ' Horas Extras Marranas
                                        )

                                        ' Update grid cell value
                                        activeRow.Cells($"Dia{i + 1}").Value = "A"
                                    Next

                                    ' Recalculate totals basado en los días de la quincena
                                    Dim diasTrabajados As Integer = diaFin - diaInicio + 1
                                    activeRow.Cells("H.T").Value = diasTrabajados * 8
                                    activeRow.Cells("H.TR").Value = diasTrabajados * 8
                                    activeRow.Cells("H.EX").Value = 0

                                    Colorear()
                                    ReiniciarContadores()
                                    ProcesarAsistencias()

                                    msj_ok("Asistencia aplicada correctamente.")
                                End If
                            End If
                        Else
                            Dim objAsistencia As New coControlAsistencia With {
                                .IdUbicacion = cbxListarPlanteles.Value,
                                .Anio = anio,
                                .Mes = cbListaMeses.SelectedIndex + 1,
                                .Tipo = "PLANILLA",
                                .idHorario = 0
                            }
                            ' Obtener último día registrado
                            Dim mensajeUltimoRegistro As String = cn.Cn_ObtenerUltimoDiaRegistroAsistencia(objAsistencia)
                            Dim diasEnElMes As Integer = DateTime.DaysInMonth(objAsistencia.Anio, objAsistencia.Mes)
                            Dim ultimoDiaRegistro As Integer = objAsistencia.UltimoDiaReg
                            Dim diaActual As Integer = dia

                            Dim rangoInicio As Integer = ultimoDiaRegistro + 1
                            Dim rangoFin As Integer = diaActual

                            ' Ajuste para la lógica de quincena si aplica
                            If diaActual < objAsistencia.UltimoDiaReg Then
                                Return ' Ya se registró asistencia para días posteriores, salimos
                            Else
                                If objAsistencia.UltimoDiaReg < 15 AndAlso diaActual > 15 Then
                                    rangoFin = 15
                                    diaActual = 15
                                End If
                            End If

                            If horariosTrabajadores.ContainsKey(dni) Then
                                Dim listaHorarios = horariosTrabajadores(dni)
                                Dim diasTrabajadosConteo As Integer = 0

                                For i As Integer = rangoInicio - 1 To rangoFin - 1
                                    ' Horario por defecto
                                    Dim entrada As String = "08:00"
                                    Dim salida As String = "17:00"

                                    listaHorarios(i) = (
                                        entrada,
                                        salida,
                                        "Sin observación",
                                        "0",
                                        "0",
                                        "8",
                                        1,
                                        "NO",
                                        "SIN ASIGNAR",
                                        "0"
                                    )

                                    activeRow.Cells($"Dia{i + 1}").Value = "A"
                                    diasTrabajadosConteo += 1
                                Next

                                activeRow.Cells("H.T").Value = 0
                                activeRow.Cells("H.TR").Value = 0
                                activeRow.Cells("H.EX").Value = 0

                                activeRow.Cells("H.T").Value = diasTrabajadosConteo * 8
                                activeRow.Cells("H.TR").Value = diasTrabajadosConteo * 8

                                Colorear()
                                ReiniciarContadores()
                                ProcesarAsistencias()
                                msj_ok("Asistencia aplicada correctamente.")
                            End If
                        End If
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub cbListaMeses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbListaMeses.SelectedIndexChanged
        If rbPlanilla.Checked Then
            InicializarDtgAsistencia()
        ElseIf rbEventual.Checked Then
            If generadoQuincenaEventual Then
                InicializarDtgAsistencia()
            Else
                InicializarDtgAsistenciaSemanal()
            End If

            'InicializarDtgAsistenciaSemanal()
        End If
    End Sub

    Private Sub CmbAnios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbAnios.SelectedIndexChanged
        ' Solo actualizar si hay un valor seleccionado (evitar errores al cargar el formulario)
        If CmbAnios.SelectedItem IsNot Nothing Then
            If rbPlanilla.Checked Then
                InicializarDtgAsistencia()
            ElseIf rbEventual.Checked Then
                If generadoQuincenaEventual Then
                    InicializarDtgAsistencia()
                Else
                    InicializarDtgAsistenciaSemanal()
                End If
            End If
        End If
    End Sub

    Private Sub LimpiarAdministrativo()
        btnAplicarRrhhCtrlasist.Visible = False
        btnGenerarRrhhCtrlasist.Visible = True
        btnCancelarRrhhCtrlasist.Visible = False
        generadoEnPlanilla = False
        CmbAnios.Visible = False
        tbRutaArchivoExcel.ReadOnly = False
        btnImportar.Enabled = True
        btnProcesar.Enabled = True
        cbxListarPlanteles.SelectedRow = cbxListarPlanteles.Rows(0)
        cbListaMeses.SelectedIndex = DateTime.Now.Month - 1
        cbListaMeses.Enabled = True
        cbxListarPlanteles.ReadOnly = False
        dtTrabajadores.Clear()
        horariosTrabajadores.Clear()
    End Sub

    Private Sub LimpiarOperario()
        btnAplicarRrhhCtrlasist.Visible = False
        btnPlanillaOperaria.Visible = True
        btnCancelarPlanillaOperaria.Visible = False
        generadoEnOperario = False
        BloquearItemsUltraCombo()
        CmbAnios.Visible = False
        tbRutaArchivoExcel.ReadOnly = False
        btnImportar.Enabled = True
        btnProcesar.Enabled = True
        cbxListarPlanteles.SelectedRow = cbxListarPlanteles.Rows(0)
        cbListaMeses.SelectedIndex = DateTime.Now.Month - 1
        cbListaMeses.Enabled = True
        cbxListarPlanteles.ReadOnly = False
        dtTrabajadores.Clear()
        horariosTrabajadores.Clear()
    End Sub

    Private Sub LimpiarEventual()
        btnAplicarRrhhCtrlasist.Visible = False
        btnGenerarRrhhCtrlasist.Visible = True
        btnAplicarVacacionesRrhhCtrlasist.Visible = True
        btnPlanillaOperaria.Visible = True
        btnCancelarEventualQuincena.Visible = False
        generadoQuincenaEventual = False
        cbxListarPlanteles.SelectedRow = cbxListarPlanteles.Rows(0)
        cbListaMeses.SelectedIndex = DateTime.Now.Month - 1
        InicializarDtgAsistenciaSemanal()
        dtTrabajadores.Clear()
        horariosTrabajadores.Clear()
        horariosTrabajadoresEventuales.Clear()
    End Sub

    Private Sub btnAplicarVacacionesRrhhCtrlasist_Click(sender As Object, e As EventArgs) Handles btnAplicarVacacionesRrhhCtrlasist.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If dtgListado.Rows.Count > 0 Then
                If activeRow IsNot Nothing AndAlso Not String.IsNullOrEmpty(activeRow.Cells(0).Value.ToString()) Then
                    If activeRow.Band.Index = 0 Then
                        If MessageBox.Show("¿Está seguro de aplicar vacaciones al trabajador seleccionado?", "Aplicar Asistencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Dim dni As String = activeRow.Cells("ID").Value.ToString()
                            Dim anioSeleccionado As Integer = If(generadoEnPlanilla OrElse generadoEnOperario,
                                                           CInt(CmbAnios.SelectedItem),
                                                           anio)

                            Dim obj As New coControlAsistencia
                            obj.NumDocumento = dni
                            obj.Mes = cbListaMeses.SelectedIndex + 1
                            obj.Anio = anioSeleccionado
                            Dim mensaje As String = cn.Cn_AplicarVacacionesPorTrabajadorAsistencia(obj)

                            If obj.CodeError = 0 Then
                                If horariosTrabajadores.ContainsKey(dni) Then
                                    Dim listaHorarios = horariosTrabajadores(dni)

                                    If generadoEnPlanilla Then
                                        ' Para planilla procesa todo el rango normalmente
                                        For i As Integer = obj.DiaInicio - 1 To obj.DiaFin - 1

                                            ultimoDiaRegistroEventual = i + 1

                                            Dim nombreCelda As String = $"Dia{i + 1}"
                                            Dim entrada As String = "08:00"
                                            Dim salida As String = "17:00"
                                            listaHorarios(i) = (entrada, salida, "VACACIONES", "0", "0", "8", 1, "NO", "SIN ASIGNAR", "0")
                                            activeRow.Cells(nombreCelda).Value = "V"
                                        Next

                                    ElseIf generadoEnOperario Then
                                        Dim objOpe As New coControlAsistencia
                                        objOpe.IdUbicacion = cbxListarPlanteles.Value
                                        objOpe.Anio = anioSeleccionado
                                        objOpe.Mes = cbListaMeses.SelectedIndex + 1
                                        objOpe.Tipo = "PLANILLA"
                                        Dim mensajeOpe As String = cn.Cn_ConsOperariosAsistencia(objOpe)

                                        If objOpe.CodeError = 0 Then
                                            ' Obtener el rango real de vacaciones
                                            Dim diaInicioVacaciones As Integer = obj.DiaInicio - 1 ' Convertir a índice base 0
                                            Dim diaFinVacaciones As Integer = obj.DiaFin - 1 ' Convertir a índice base 0

                                            ' Aplicar vacaciones solo en el rango especificado, pero respetando la quincena
                                            If objOpe.Tipoperiodo = "QUINCENA 1" Then
                                                ' Para QUINCENA 1: aplicar vacaciones del día 1 al 15, pero solo en el rango de vacaciones
                                                Dim inicioRango As Integer = Math.Max(diaInicioVacaciones, 0) ' No antes del día 1
                                                Dim finRango As Integer = Math.Min(diaFinVacaciones, 14) ' No después del día 15

                                                For i As Integer = inicioRango To finRango
                                                    ultimoDiaRegistroEventual = i + 1
                                                    Dim nombreCelda As String = $"Dia{i + 1}"
                                                    Dim entrada As String = "08:00"
                                                    Dim salida As String = "17:00"
                                                    listaHorarios(i) = (entrada, salida, "VACACIONES", "0", "0", "8", 1, "NO", "SIN ASIGNAR", "0")
                                                    activeRow.Cells(nombreCelda).Value = "V"
                                                Next

                                            Else ' QUINCENA 2
                                                ' Para QUINCENA 2: aplicar vacaciones del día 16 al fin del mes, pero solo en el rango de vacaciones
                                                Dim diasEnElMes As Integer = DateTime.DaysInMonth(objOpe.Anio, objOpe.Mes)
                                                Dim inicioRango As Integer = Math.Max(diaInicioVacaciones, 15) ' No antes del día 16
                                                Dim finRango As Integer = Math.Min(diaFinVacaciones, diasEnElMes - 1) ' No después del fin del mes

                                                For i As Integer = inicioRango To finRango
                                                    ultimoDiaRegistroEventual = i + 1
                                                    Dim nombreCelda As String = $"Dia{i + 1}"
                                                    Dim entrada As String = "08:00"
                                                    Dim salida As String = "17:00"
                                                    listaHorarios(i) = (entrada, salida, "VACACIONES", "0", "0", "8", 1, "NO", "SIN ASIGNAR", "0")
                                                    activeRow.Cells(nombreCelda).Value = "V"
                                                Next
                                            End If
                                        End If
                                    Else
                                        ' Para otros casos, verifica que la celda no contenga "-"
                                        For i As Integer = obj.DiaInicio - 1 To obj.DiaFin - 1
                                            Dim nombreCelda As String = $"Dia{i + 1}"
                                            If activeRow.Cells(nombreCelda).Value IsNot Nothing AndAlso
                                           activeRow.Cells(nombreCelda).Value.ToString() <> "-" Then

                                                ultimoDiaRegistroEventual = i + 1

                                                Dim entrada As String = "08:00"
                                                Dim salida As String = "17:00"
                                                listaHorarios(i) = (entrada, salida, "VACACIONES", "0", "0", "8", 1, "NO", "SIN ASIGNAR", "0")
                                                activeRow.Cells(nombreCelda).Value = "V"
                                            End If
                                        Next
                                    End If

                                    ' Actualizar totales según los días procesados
                                    Dim diasTrabajados As Integer = obj.DiaFin - obj.DiaInicio + 1
                                    activeRow.Cells("H.T").Value = diasTrabajados * 8
                                    activeRow.Cells("H.TR").Value = diasTrabajados * 8
                                    activeRow.Cells("H.EX").Value = 0

                                    Colorear()
                                    ProcesarAsistencias()
                                End If

                                msj_ok("Vacaciones aplicadas correctamente")
                            End If
                        End If
                    Else
                        msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub InicializarDtgAsistenciaSemanal()
        Dim dt As New DataTable()
        dtTrabajadores = New DataTable()

        ' Basic columns setup
        dtTrabajadores.Columns.Add("Codigo", GetType(Integer))
        dtTrabajadores.Columns.Add("ID", GetType(String))
        dtTrabajadores.Columns.Add("Nombre", GetType(String))
        dtTrabajadores.Columns.Add("Tipo", GetType(String))
        dtTrabajadores.Columns.Add("Eliminar", GetType(Button))

        Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
        Dim anioActual As Integer = CInt(CmbAnios.SelectedItem) ' Fixed to 2025 for this example

        ' Get the first day of the selected month
        Dim primerDiaMes As DateTime = New DateTime(anioActual, mesSeleccionado, 1)

        ' Find the first Sunday of the month
        Dim primerDomingo As DateTime = primerDiaMes
        While primerDomingo.DayOfWeek <> DayOfWeek.Sunday
            primerDomingo = primerDomingo.AddDays(1)
        End While

        ' Find the last Sunday of the month
        Dim ultimoDiaMes As DateTime = primerDiaMes.AddMonths(1).AddDays(-1)
        Dim ultimoDomingo As DateTime = ultimoDiaMes
        While ultimoDomingo.DayOfWeek <> DayOfWeek.Sunday
            ultimoDomingo = ultimoDomingo.AddDays(-1)
        End While

        ' Add 6 days to get the complete week (ends on Saturday)
        Dim ultimoSabado As DateTime = ultimoDomingo.AddDays(6)

        ' Calculate weeks
        Dim semanas As New List(Of Tuple(Of DateTime, DateTime))()
        Dim inicioSemana As DateTime = primerDomingo

        While inicioSemana <= ultimoDomingo
            Dim finSemana As DateTime = inicioSemana.AddDays(6)
            semanas.Add(New Tuple(Of DateTime, DateTime)(inicioSemana, finSemana))
            inicioSemana = inicioSemana.AddDays(7)
        End While

        ' Add columns for each day
        For Each semana In semanas
            Dim fechaActual As DateTime = semana.Item1
            While fechaActual <= semana.Item2
                Dim nombreColumna As String = $"Dia{fechaActual:dd-MM}"
                dtTrabajadores.Columns.Add(nombreColumna, GetType(String))
                fechaActual = fechaActual.AddDays(1)
            End While
        Next

        dtTrabajadores.Columns.Add("H.T", GetType(Double))
        dtTrabajadores.Columns.Add("H.TR", GetType(Integer))
        dtTrabajadores.Columns.Add("H.EX", GetType(Double))

        dtgListado.DataSource = dtTrabajadores

        With dtgListado.DisplayLayout.Bands(0)
            .Columns.ClearUnbound()

            ' Configure basic columns
            .Columns("Codigo").Header.Caption = "Cod."
            .Columns("ID").Header.Caption = "DNI"
            .Columns("Nombre").Header.Caption = "Personal"
            .Columns("Tipo").Header.Caption = "Tipo"
            .Columns("Eliminar").Header.Caption = ""
            .Columns("Codigo").Width = 70
            .Columns("ID").Width = 130
            .Columns("Nombre").Width = 200
            .Columns("Tipo").Width = 100
            .Columns("Eliminar").Style = UltraWinGrid.ColumnStyle.Button
            .Columns("Eliminar").CellButtonAppearance.Image = My.Resources.ico_eliminar
            .Columns("Eliminar").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            .Override.HeaderAppearance.TextHAlign = HAlign.Center
            .Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True

            ' Setup groups
            .Groups.Clear()
            .RowLayoutStyle = RowLayoutStyle.GroupLayout

            Dim groupGeneral As UltraGridGroup = .Groups.Add("Información General", "Información General")

            ' Assign basic columns to general group
            .Columns("Codigo").RowLayoutColumnInfo.ParentGroup = groupGeneral
            .Columns("ID").RowLayoutColumnInfo.ParentGroup = groupGeneral
            .Columns("Nombre").RowLayoutColumnInfo.ParentGroup = groupGeneral
            .Columns("Tipo").RowLayoutColumnInfo.ParentGroup = groupGeneral

            ' Create week groups and assign days
            Dim gruposSemanas As New List(Of UltraGridGroup)
            For i As Integer = 0 To semanas.Count - 1
                Dim fechaInicio As DateTime = semanas(i).Item1
                Dim fechaFin As DateTime = semanas(i).Item2
                Dim numeroSemana As Integer = DatePart(DateInterval.WeekOfYear, fechaInicio, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)

                ' Limit the week number to 1-52
                If numeroSemana > 52 Then
                    numeroSemana = (numeroSemana - 1) Mod 52 + 1
                End If

                Dim nombreGrupo As String = $"Semana {numeroSemana} ({fechaInicio:dd/MM} - {fechaFin:dd/MM})"
                Dim grupo As UltraGridGroup = .Groups.Add(nombreGrupo, nombreGrupo)
                gruposSemanas.Add(grupo)

                ' Assign days to their corresponding week
                Dim fechaActual As DateTime = fechaInicio
                While fechaActual <= fechaFin
                    Dim nombreColumna As String = $"Dia{fechaActual:dd-MM}"
                    If .Columns.Exists(nombreColumna) Then
                        Dim col As UltraGridColumn = .Columns(nombreColumna)
                        col.Header.Caption = fechaActual.Day.ToString()
                        col.Width = 50
                        col.CellAppearance.TextHAlign = HAlign.Center
                        col.RowLayoutColumnInfo.ParentGroup = grupo
                    End If
                    fechaActual = fechaActual.AddDays(1)
                End While
            Next

            Dim groupHoras As UltraGridGroup = .Groups.Add("Informe de Horas", "Informe de Horas")

            ' Configure hour columns
            For Each colName As String In {"H.T", "H.TR", "H.EX"}
                If .Columns.Exists(colName) Then
                    Dim col As UltraGridColumn = .Columns(colName)
                    col.Width = 50
                    col.CellAppearance.TextHAlign = HAlign.Center
                    col.RowLayoutColumnInfo.ParentGroup = groupHoras
                End If
            Next
        End With

        dtgListado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        clsBasicas.Filtrar_Tabla(dtgListado, False)
    End Sub

    Private Sub btnPlanillaOperaria_Click(sender As Object, e As EventArgs) Handles btnPlanillaOperaria.Click
        If rbPlanilla.Checked Then
            If (MessageBox.Show("¿ESTÁ SEGURO DE GENERAR LA PLANILLA OPERARIA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            btnAplicarRrhhCtrlasist.Visible = True
            btnPlanillaOperaria.Visible = False
            btnCancelarPlanillaOperaria.Visible = True
            tbRutaArchivoExcel.ReadOnly = True
            btnImportar.Enabled = False
            btnProcesar.Enabled = False

            'If idPlantelSeleccionado = 12 Or idPlantelSeleccionado = 13 Or idPlantelSeleccionado = 16 Then
            '    cbxListarPlanteles.Value = idPlantelSeleccionado
            '    cbxListarPlanteles.ReadOnly = True
            'Else
            '    cbxListarPlanteles.Value = 12
            '    cbxListarPlanteles.ReadOnly = False
            'End If

            generadoEnOperario = True
            BloquearItemsUltraCombo()
            CmbAnios.Visible = True
            dtTrabajadores.Clear()
            horariosTrabajadores.Clear()
            msj_ok("Ahora puedes registrar la asistencia de los trabajadores operarios")
        Else
            msj_advert("No puedes generar la planilla operaria para eventuales")
        End If
    End Sub

    Private Sub btnCancelarPlanillaOperaria_Click(sender As Object, e As EventArgs) Handles btnCancelarPlanillaOperaria.Click
        If rbPlanilla.Checked Then
            If (MessageBox.Show("¿ESTÁ SEGURO DE CANCELAR LA PLANILLA OPERARIA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            btnAplicarRrhhCtrlasist.Visible = False
            btnPlanillaOperaria.Visible = True
            btnCancelarPlanillaOperaria.Visible = False
            tbRutaArchivoExcel.ReadOnly = False
            btnImportar.Enabled = True
            btnProcesar.Enabled = True
            cbxListarPlanteles.ReadOnly = False
            cbxListarPlanteles.Value = 1
            cbListaMeses.Enabled = True
            generadoEnOperario = False
            BloquearItemsUltraCombo()
            CmbAnios.Visible = False
            dtTrabajadores.Clear()
            horariosTrabajadores.Clear()
            msj_ok("Ha sido cancelada la generación de planilla operaria")
        Else
            msj_advert("No puedes generar la planilla operaria para eventuales")
        End If
    End Sub

    Private Sub BloquearItemsUltraCombo()
        If generadoEnOperario Then
            ' Iterar sobre las filas del UltraCombo
            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In cbxListarPlanteles.Rows
                ' Bloquear todos excepto el valor 12, 13 y 16
                'If row.Cells(0).Value <> 12 AndAlso row.Cells(0).Value <> 13 AndAlso row.Cells(0).Value <> 16 Then
                '    row.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled
                'End If
            Next
        Else
            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In cbxListarPlanteles.Rows
                row.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            Next
        End If
    End Sub

    Private Sub btnQuincenaEventual_Click(sender As Object, e As EventArgs) Handles btnQuincenaEventual.Click
        If rbEventual.Checked Then
            If (MessageBox.Show("¿ESTÁ SEGURO DE GENERAR LA QUINCENA EVENTUAL?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            btnGenerarRrhhCtrlasist.Visible = False
            btnPlanillaOperaria.Visible = False
            btnAplicarVacacionesRrhhCtrlasist.Visible = False
            btnQuincenaEventual.Visible = False
            btnAplicarRrhhCtrlasist.Visible = True
            btnCancelarEventualQuincena.Visible = True
            generadoQuincenaEventual = True
            dtTrabajadores.Clear()
            horariosTrabajadoresEventuales.Clear()
            InicializarDtgAsistencia()
            msj_ok("Ahora puedes registrar la asistencia de los trabajadores eventuales")
        Else
            msj_advert("No puedes generar la quincena para cuando esta seleccionada la planilla")
        End If
    End Sub

    Private Sub btnCancelarEventualQuincena_Click(sender As Object, e As EventArgs) Handles btnCancelarEventualQuincena.Click
        If rbEventual.Checked Then
            If (MessageBox.Show("¿ESTÁ SEGURO DE CANCELAR LA QUINCENA EVENTUAL?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            btnGenerarRrhhCtrlasist.Visible = True
            btnPlanillaOperaria.Visible = True
            btnAplicarVacacionesRrhhCtrlasist.Visible = True
            btnQuincenaEventual.Visible = True
            btnAplicarRrhhCtrlasist.Visible = False
            btnCancelarEventualQuincena.Visible = False
            generadoQuincenaEventual = False
            dtTrabajadores.Clear()
            horariosTrabajadoresEventuales.Clear()
            InicializarDtgAsistenciaSemanal()
            msj_ok("Ha sido cancelada la generación de quincena eventual")
        Else
            msj_advert("No puedes cancelar la quincena para cuando esta seleccionada la planilla")
        End If
    End Sub

    Private Sub ReiniciarContadores()
        totalAsistenciaCompleta = 0
        totalIncompletas = 0
        totalConHorasExtras = 0
        totalConPermisoMedico = 0
        totalInasistencias = 0
        totalConDescanso = 0
        totalConFeriadoTrabajado = 0
        totalConFeriadoNoTrabajado = 0
    End Sub
End Class