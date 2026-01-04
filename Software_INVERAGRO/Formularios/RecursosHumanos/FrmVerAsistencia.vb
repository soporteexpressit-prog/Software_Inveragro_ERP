Imports System.Globalization
Imports System.Text
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmVerAsistencia
    Dim cn As New cnControlAsistencia
    Dim dtBaseDatos As DataTable
    Dim horasTrabajadasDict As New Dictionary(Of String, Dictionary(Of Integer, Integer))()
    Private horasExtrasDict As New Dictionary(Of String, Dictionary(Of Integer, Double))()
    Private observacionesDict As New Dictionary(Of String, Dictionary(Of Integer, String))()
    Private feriadosDict As New Dictionary(Of String, Dictionary(Of Integer, String))()
    Private horasExtrasMarranasDict As New Dictionary(Of String, Dictionary(Of Integer, Double))()
    Private _idPlantel As Integer
    Public anio As Integer
    Public mes As Integer
    Public idHorario As Integer
    Public plantel As String
    Public tipo As String
    Public tipoPeriodo As String
    Public estado As String

    Dim ultimoDiaRegistro As Integer

    Dim totalAsistenciaCompleta As Integer = 0
    Dim totalInasistencias As Integer = 0
    Dim totalIncompletas As Integer = 0
    Dim totalConHorasExtras As Integer = 0
    Dim totalConPermisoMedico As Integer = 0
    Dim totalConDescanso As Integer = 0
    Dim totalConFeriadoTrabajado As Integer = 0
    Dim totalConFeriadoNoTrabajado As Integer = 0
    Dim tipoQuincena As Integer
    Private Sub frmVerAsistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbListaMeses.SelectedIndex = DateTime.Now.Month - 1
        cbxListaQuincenas.SelectedIndex = 0
        'InicializarDtgAsistencia()
        CargarTablaAsistencia()
        ListarAños()
        ListarPlanteles()
        AsignarValores()
        clsBasicas.Formato_Tablas_Grid_Asistencia(dtgListado)
        Me.Size = New Size(1400, 700)
    End Sub

    Private Sub CargarTablaAsistencia()
        If tipo = "EVENTUAL" Then
            If tipoPeriodo.StartsWith("SEMANA") Then
                InicializarDtgAsistenciaSemanal()
            Else
                InicializarDtgAsistencia()
            End If
        ElseIf tipo = "PLANILLA" Then
            InicializarDtgAsistencia()
        End If
    End Sub

    Sub AsignarValores()
        cbxListaAños.Value = anio
        cbxListarPlanteles.Text = plantel
        cbListaMeses.SelectedIndex = mes - 1
        cbxListaAños.ReadOnly = True
        cbxListarPlanteles.ReadOnly = True
        cbListaMeses.DropDownStyle = ComboBoxStyle.DropDownList
        cbListaMeses.Enabled = False
        txtTipoPlanilla.Text = tipo
        txtTipoPlanilla.ReadOnly = True


        If tipo = "PLANILLA" Then
            If tipoPeriodo.StartsWith("QUINCENA") Then
                cbxListaQuincenas.Enabled = False

                If tipoPeriodo = "QUINCENA 1" Then
                    tipoQuincena = 1
                    cbxListaQuincenas.SelectedIndex = 0
                ElseIf tipoPeriodo = "QUINCENA 2" Then
                    tipoQuincena = 2
                    cbxListaQuincenas.SelectedIndex = 1
                ElseIf tipoPeriodo = "MENSUAL" Then
                    tipoQuincena = 3
                    cbxListaQuincenas.SelectedIndex = 2
                End If
            Else
                cbxListaQuincenas.Enabled = False
                tipoQuincena = 3
                cbxListaQuincenas.SelectedIndex = 2
            End If
        Else
            If tipoPeriodo.StartsWith("QUINCENA") Then
                cbxListaQuincenas.Enabled = False

                If tipoPeriodo = "QUINCENA 1" Then
                    tipoQuincena = 1
                    cbxListaQuincenas.SelectedIndex = 0
                ElseIf tipoPeriodo = "QUINCENA 2" Then
                    tipoQuincena = 2
                    cbxListaQuincenas.SelectedIndex = 1
                ElseIf tipoPeriodo = "MENSUAL" Then
                    tipoQuincena = 3
                    cbxListaQuincenas.SelectedIndex = 2
                End If
            Else
                cbxListaQuincenas.Enabled = False
                tipoQuincena = 3
                cbxListaQuincenas.SelectedIndex = 2
            End If
        End If

        CargarDatosBaseDeDatos()
    End Sub
    Sub ReiniciarContadores()
        totalAsistenciaCompleta = 0
        totalInasistencias = 0
        totalIncompletas = 0
        totalConHorasExtras = 0
        totalConPermisoMedico = 0
        totalConDescanso = 0
        totalConFeriadoNoTrabajado = 0
        totalConFeriadoTrabajado = 0
    End Sub

    Sub ListarAños()
        Try
            Dim dt As New DataTable
            dt = cn.Cn_ListarAñosDeHorarios().Copy
            dt.TableName = "tmp"
            dt.Columns(0).ColumnName = "Seleccione un Año"
            With cbxListaAños
                .DataSource = dt
                .DisplayMember = dt.Columns(0).ColumnName
                .ValueMember = dt.Columns(0).ColumnName
                If (dt.Rows.Count > 0) Then
                    .Value = dt.Rows(0)(0)
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CargarDatosBaseDeDatos()
        Dim dtBaseDatos As DataTable = ObtenerDatosBaseDatos()
        Dim dtDatosMostrar As DataTable = EstructuraDeDatosParaMostrar(dtBaseDatos)
        dtgListado.DataSource = dtDatosMostrar

        Colorear()
        ConfigurarUltraGrid()
        ProcesarAsistencias()
    End Sub

    Private Function ObtenerDatosBaseDatos() As DataTable
        Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
        Dim anioActual As Integer = cbxListaAños.Value
        _idPlantel = cbxListarPlanteles.Value

        Dim obj As New coControlAsistencia()
        obj.idHorario = idHorario
        obj.Mes = mesSeleccionado
        obj.Anio = anioActual
        obj.IdUbicacion = _idPlantel
        obj.TipoQuincena = tipoQuincena
        obj.Tipo = tipo

        Return cn.Cn_Consultar(obj)
    End Function

    Private Function EstructuraDeDatosParaMostrar(dtBaseDatos As DataTable) As DataTable
        horasExtrasDict.Clear()
        horasTrabajadasDict.Clear()
        observacionesDict.Clear()
        feriadosDict.Clear()
        horasExtrasMarranasDict.Clear()

        Dim dtMostrar As New DataTable()
        Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
        Dim anioActual As Integer = cbxListaAños.Value
        Dim diasEnElMes As Integer = DateTime.DaysInMonth(anioActual, mesSeleccionado)

        ' Columnas básicas
        dtMostrar.Columns.Add("Codigo", GetType(Integer))
        dtMostrar.Columns.Add("ID", GetType(String))
        dtMostrar.Columns.Add("Nombre", GetType(String))

        Dim rangoInicio As Integer = 1
        Dim rangoFin As Integer = diasEnElMes

        Dim obj As New coControlAsistencia
        obj.IdUbicacion = _idPlantel
        obj.Mes = mes
        obj.Anio = anio
        obj.Tipo = tipo
        obj.idHorario = idHorario

        Dim mensaje As String = cn.Cn_ObtenerUltimoDiaRegistroAsistencia(obj)
        ultimoDiaRegistro = obj.UltimoDiaReg

        If tipo = "EVENTUAL" Then
            If tipoPeriodo.StartsWith("SEMANA") Then
                ' Extraer las fechas del tipoPeriodo
                'Dim partes As String() = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)
                'Dim fechaInicio As Date = Date.ParseExact(partes(0).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)
                'Dim fechaFin As Date = Date.ParseExact(partes(1).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)

                '' Configurar el rango basado en la semana seleccionada
                'rangoInicio = fechaInicio.Day
                'rangoFin = fechaFin.Day

                '' Agregar columnas para cada día de la semana
                'Dim fechaActual As Date = fechaInicio
                'While fechaActual <= fechaFin
                '    Dim columnName As String = $"Dia{fechaActual:dd-MM}"
                '    dtMostrar.Columns.Add(columnName, GetType(String))
                '    fechaActual = fechaActual.AddDays(1)
                'End While
                Dim partes As String() = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)

                ' Extraer día y mes de inicio y fin
                Dim diaInicio As Integer = Integer.Parse(partes(0).Trim().Split("/"c)(0))
                Dim mesInicio As Integer = Integer.Parse(partes(0).Trim().Split("/"c)(1))
                Dim diaFin As Integer = Integer.Parse(partes(1).Trim().Split("/"c)(0))
                Dim mesFin As Integer = Integer.Parse(partes(1).Trim().Split("/"c)(1))

                ' Determinar el año correcto para cada fecha
                Dim anioInicio As Integer = anioActual
                Dim anioFin As Integer = anioActual

                ' Si el mes de inicio es mayor que el mes de fin, hay cruce de año
                If mesInicio > mesFin Then anioFin = anioActual + 1

                ' Si estamos viendo desde enero y el inicio es diciembre, el inicio es del año anterior
                If mesSeleccionado = 1 And mesInicio = 12 Then anioInicio = anioActual - 1

                ' Si estamos viendo desde diciembre y el fin es enero, el fin es del año siguiente
                If mesSeleccionado = 12 And mesFin = 1 Then anioFin = anioActual + 1

                ' Crear las fechas con años correctos
                Dim fechaInicio As New Date(anioInicio, mesInicio, diaInicio)
                Dim fechaFin As New Date(anioFin, mesFin, diaFin)

                ' Agregar columnas solo para los días de la semana seleccionada
                Dim fechaActual As DateTime = fechaInicio
                While fechaActual <= fechaFin
                    dtMostrar.Columns.Add($"Dia{fechaActual:dd-MM}", GetType(String))
                    fechaActual = fechaActual.AddDays(1)
                End While
            Else
                ' Para no eventuales, mantener la lógica original
                rangoInicio = 1
                rangoFin = ultimoDiaRegistro

                ' Ajustar según tipo de quincena
                If tipoQuincena = 1 Then
                    rangoFin = Math.Min(15, rangoFin)
                ElseIf tipoQuincena = 2 Then
                    rangoInicio = 16
                End If

                For dia As Integer = rangoInicio To rangoFin
                    dtMostrar.Columns.Add($"Dia{dia}", GetType(String))
                Next
            End If
        Else
            ' Para no eventuales, mantener la lógica original
            rangoInicio = 1
            rangoFin = ultimoDiaRegistro

            ' Ajustar según tipo de quincena
            If tipoQuincena = 1 Then
                rangoFin = Math.Min(15, rangoFin)
            ElseIf tipoQuincena = 2 Then
                rangoInicio = 16
            End If

            For dia As Integer = rangoInicio To rangoFin
                dtMostrar.Columns.Add($"Dia{dia}", GetType(String))
            Next
        End If

        dtMostrar.Columns.Add("H.T", GetType(Double))
        dtMostrar.Columns.Add("H.TR", GetType(Integer))
        dtMostrar.Columns.Add("H.EX", GetType(Double))
        dtMostrar.Columns.Add("OrigenDatos", GetType(String))

        ' Procesar datos de la base de datos
        Dim datosBaseDatos As New Dictionary(Of String, Dictionary(Of String, String))()
        Dim nombresEmpleados As New Dictionary(Of String, String)()
        Dim codigoSecuencial As Integer = 1

        For Each row As DataRow In dtBaseDatos.Rows
            Dim dni As String = row("ID").ToString()
            Dim datos As String = row("Personal").ToString()
            Dim dia As Integer = CInt(row("dia"))
            Dim horaEntrada As String = row("horaEntrada").ToString()
            Dim horaSalida As String = row("horaSalida").ToString()
            Dim permisoMedico As String = row("permisoMedico").ToString().ToUpper()
            Dim horasExtras As Double = row("horasExtras")
            Dim horasTrabajadas As Integer = row("horasTrabajadas") ' Son 8 horas o menos
            Dim observacion As String = row("observacion").ToString()
            Dim horasRefrigerio As Integer = row("horasRefrigerio")
            Dim feriadoTrabajado As String = row("feriadoTrabajado").ToString().ToUpper()
            Dim horasExtrasMarranas As Double = row("horasExtrasMarranas")

            If Not datosBaseDatos.ContainsKey(dni) Then
                datosBaseDatos(dni) = New Dictionary(Of String, String)()
                horasExtrasDict(dni) = New Dictionary(Of Integer, Double)()
                horasTrabajadasDict(dni) = New Dictionary(Of Integer, Integer)()
                observacionesDict(dni) = New Dictionary(Of Integer, String)()
                feriadosDict(dni) = New Dictionary(Of Integer, String)()
                horasExtrasMarranasDict(dni) = New Dictionary(Of Integer, Double)()
                nombresEmpleados(dni) = datos
            End If

            Dim columnKey As String
            If tipo = "EVENTUAL" Then
                If tipoPeriodo.StartsWith("SEMANA") Then
                    'Dim mesDelDia As Integer = mesSeleccionado

                    '' Si es tipo SEMANA, verificar si el día pertenece al mes siguiente
                    'If tipoPeriodo.StartsWith("SEMANA") Then
                    '    Dim partesSemana() As String = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)
                    '    Dim fechaInicio As Date = Date.ParseExact(partesSemana(0).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)

                    '    ' Si el día es menor que el día de inicio, pertenece al mes siguiente
                    '    If dia < fechaInicio.Day Then
                    '        mesDelDia = mesSeleccionado + 1
                    '    End If
                    'End If

                    'Dim fecha As New DateTime(anioActual, mesDelDia, dia)
                    'columnKey = $"Dia{fecha:dd-MM}"

                    Dim partesSemana() As String = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)

                    ' Extraer día y mes de inicio y fin
                    Dim diaInicio As Integer = Integer.Parse(partesSemana(0).Trim().Split("/"c)(0))
                    Dim mesInicio As Integer = Integer.Parse(partesSemana(0).Trim().Split("/"c)(1))
                    Dim diaFin As Integer = Integer.Parse(partesSemana(1).Trim().Split("/"c)(0))
                    Dim mesFin As Integer = Integer.Parse(partesSemana(1).Trim().Split("/"c)(1))

                    ' Determinar el año y mes correctos para el día actual
                    Dim anioDelDia As Integer = anioActual
                    Dim mesDelDia As Integer

                    ' ✅ CORRECCIÓN: Detectar cruce de años
                    If mesFin < mesInicio Then
                        ' Hay cruce de años (ej: 28/12 - 03/01)
                        If mesSeleccionado = mesFin Then
                            ' Estamos viendo enero (mes de fin)
                            If dia >= diaInicio Then
                                ' El día pertenece a diciembre del año anterior
                                mesDelDia = mesInicio
                                anioDelDia = anioActual - 1
                            Else
                                ' El día pertenece a enero del año actual
                                mesDelDia = mesFin
                                anioDelDia = anioActual
                            End If
                        ElseIf mesSeleccionado = mesInicio Then
                            ' Estamos viendo diciembre (mes de inicio)
                            If dia >= diaInicio Then
                                ' El día pertenece a diciembre del año actual
                                mesDelDia = mesInicio
                                anioDelDia = anioActual
                            Else
                                ' El día pertenece a enero del año siguiente
                                mesDelDia = mesFin
                                anioDelDia = anioActual + 1
                            End If
                        Else
                            ' Mes fuera del rango de la semana
                            mesDelDia = mesSeleccionado
                        End If
                    Else
                        ' No hay cruce de años, solo posible cruce de meses
                        mesDelDia = mesSeleccionado

                        If dia < diaInicio Then
                            ' El día pertenece al mes siguiente
                            mesDelDia = mesSeleccionado + 1

                            ' ✅ Ajustar el año si el mes pasa de 12
                            If mesDelDia > 12 Then
                                mesDelDia = 1
                                anioDelDia = anioActual + 1
                            End If
                        End If
                    End If

                    ' Crear la fecha con el año y mes correctos
                    Dim fecha As New DateTime(anioDelDia, mesDelDia, dia)
                    columnKey = $"Dia{fecha:dd-MM}"
                Else
                    columnKey = $"Dia{dia}"
                End If
            Else
                columnKey = $"Dia{dia}"
            End If

            Dim resultado As String

            If tipo = "EVENTUAL" Then

                If tipoPeriodo.StartsWith("SEMANA") Then
                    If (rangoInicio <= rangoFin AndAlso dia >= rangoInicio AndAlso dia <= rangoFin) Or
                    (rangoInicio > rangoFin AndAlso (dia >= rangoInicio Or dia <= rangoFin)) Then

                        If permisoMedico = "SI" Then
                            resultado = "PM"
                            horasTrabajadasDict(dni)(dia) = horasTrabajadas
                        ElseIf feriadoTrabajado = "SI" Then
                            resultado = "FT"
                            horasTrabajadasDict(dni)(dia) = horasTrabajadas
                            horasExtrasDict(dni)(dia) = horasExtras + horasExtrasMarranas
                            feriadosDict(dni)(dia) = feriadoTrabajado
                        ElseIf feriadoTrabajado = "NO" Then
                            resultado = "FNT"
                            feriadosDict(dni)(dia) = feriadoTrabajado
                        ElseIf observacion.IndexOf("DESCANSO", StringComparison.OrdinalIgnoreCase) >= 0 Then
                            resultado = "D"
                            horasTrabajadasDict(dni)(dia) = horasTrabajadas
                        ElseIf String.IsNullOrWhiteSpace(horaEntrada) AndAlso String.IsNullOrWhiteSpace(horaSalida) Then
                            resultado = "F"
                        ElseIf String.IsNullOrWhiteSpace(horaEntrada) Or String.IsNullOrWhiteSpace(horaSalida) Or horasTrabajadas < 8 Then
                            resultado = "IN"
                        Else
                            If horasExtras > 0 Or horasExtrasMarranas > 0 Then
                                resultado = "HEX"
                            Else
                                resultado = "A"
                            End If
                            horasTrabajadasDict(dni)(dia) = horasTrabajadas
                        End If
                    Else
                        resultado = "-"
                    End If
                Else
                    If dia >= rangoInicio AndAlso dia <= rangoFin Then
                        If permisoMedico = "SI" Then
                            resultado = "PM"
                            horasTrabajadasDict(dni)(dia) = horasTrabajadas
                        ElseIf feriadoTrabajado = "SI" Then
                            resultado = "FT"
                            horasTrabajadasDict(dni)(dia) = horasTrabajadas
                            horasExtrasDict(dni)(dia) = horasExtras + horasExtrasMarranas
                            feriadosDict(dni)(dia) = feriadoTrabajado
                        ElseIf feriadoTrabajado = "NO" Then
                            resultado = "FNT"
                            feriadosDict(dni)(dia) = feriadoTrabajado
                        ElseIf observacion.IndexOf("DESCANSO", StringComparison.OrdinalIgnoreCase) >= 0 Then
                            resultado = "D"
                            horasTrabajadasDict(dni)(dia) = horasTrabajadas
                        ElseIf observacion = "VACACIONES" Then
                            resultado = "V"
                            horasTrabajadasDict(dni)(dia) = horasTrabajadas
                        ElseIf String.IsNullOrWhiteSpace(horaEntrada) AndAlso String.IsNullOrWhiteSpace(horaSalida) Then
                            resultado = "F"
                        ElseIf String.IsNullOrWhiteSpace(horaEntrada) Or String.IsNullOrWhiteSpace(horaSalida) Or horasTrabajadas < 8 Then ' Agregue horas trabajadas
                            resultado = "IN"
                        Else
                            If horasExtras > 0 Or horasExtrasMarranas > 0 Then
                                resultado = "HEX"
                            Else
                                resultado = "A"
                            End If
                            horasTrabajadasDict(dni)(dia) = horasTrabajadas
                        End If
                    Else
                        resultado = "-"
                    End If
                End If
            Else
                If dia >= rangoInicio AndAlso dia <= rangoFin Then
                    If permisoMedico = "SI" Then
                        resultado = "PM"
                        horasTrabajadasDict(dni)(dia) = horasTrabajadas
                    ElseIf feriadoTrabajado = "SI" Then
                        resultado = "FT"
                        horasTrabajadasDict(dni)(dia) = horasTrabajadas
                        horasExtrasDict(dni)(dia) = horasExtras + horasExtrasMarranas
                        feriadosDict(dni)(dia) = feriadoTrabajado
                    ElseIf feriadoTrabajado = "NO" Then
                        resultado = "FNT"
                        feriadosDict(dni)(dia) = feriadoTrabajado
                    ElseIf observacion.IndexOf("DESCANSO", StringComparison.OrdinalIgnoreCase) >= 0 Then
                        resultado = "D"
                        horasTrabajadasDict(dni)(dia) = horasTrabajadas
                    ElseIf observacion = "VACACIONES" Then
                        resultado = "V"
                        horasTrabajadasDict(dni)(dia) = horasTrabajadas
                    ElseIf String.IsNullOrWhiteSpace(horaEntrada) AndAlso String.IsNullOrWhiteSpace(horaSalida) Then
                        resultado = "F"
                    ElseIf String.IsNullOrWhiteSpace(horaEntrada) Or String.IsNullOrWhiteSpace(horaSalida) Or horasTrabajadas < 8 Then ' Agregue horas trabajadas
                        resultado = "IN"
                    Else
                        If horasExtras > 0 Or horasExtrasMarranas > 0 Then
                            resultado = "HEX"
                        Else
                            resultado = "A"
                        End If
                        horasTrabajadasDict(dni)(dia) = horasTrabajadas
                    End If
                Else
                    resultado = "-"
                End If
            End If

            datosBaseDatos(dni)(columnKey) = resultado
            horasExtrasDict(dni)(dia) = horasExtras + horasExtrasMarranas
            observacionesDict(dni)(dia) = observacion
            feriadosDict(dni)(dia) = feriadoTrabajado
            horasExtrasMarranasDict(dni)(dia) = horasExtrasMarranas
        Next

        ' Generar filas
        For Each dni In datosBaseDatos.Keys
            Dim newRow As DataRow = dtMostrar.NewRow()
            newRow("Codigo") = codigoSecuencial
            newRow("ID") = dni
            newRow("Nombre") = nombresEmpleados(dni)
            newRow("OrigenDatos") = "DB"

            Dim totalHorasTrabajadas As Double = 0
            Dim totalHorasNormales As Integer = 0
            Dim totalHorasExtras As Double = 0

            ' Procesar cada columna de día
            For Each col As DataColumn In dtMostrar.Columns
                If col.ColumnName.StartsWith("Dia") Then
                    Dim dia As Integer
                    Dim mesDia As Integer = mes ' Por defecto, usamos el mes actual

                    If tipo = "EVENTUAL" Then

                        If tipoPeriodo.StartsWith("SEMANA") Then
                            ' Si el formato es "Diadd-MM"
                            Dim partesFecha() As String = col.ColumnName.Substring(3).Split("-"c)
                            dia = Integer.Parse(partesFecha(0))

                            ' Si el tipoPeriodo es SEMANA y contiene fechas
                            If tipoPeriodo.StartsWith("SEMANA") Then
                                Dim partesSemana() As String = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)
                                Dim fechaInicio As Date = Date.ParseExact(partesSemana(0).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)
                                Dim fechaFin As Date = Date.ParseExact(partesSemana(1).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)

                                ' Si el día es menor que el día inicial, está en el mes siguiente
                                If dia < fechaInicio.Day Then
                                    mesDia = mes + 1
                                End If

                                ' Comparar considerando el mes
                                If mesDia > mes Then
                                    ' Si es del mes siguiente, comparar con ultimoDiaRegistro directamente
                                    If dia > ultimoDiaRegistro Then
                                        newRow(col.ColumnName) = "-"
                                        Continue For
                                    End If
                                Else
                                    ' Si es del mes actual, solo comparar si ultimoDiaRegistro es del mismo mes
                                    If ultimoDiaRegistro > dia AndAlso ultimoDiaRegistro < fechaFin.Day Then
                                        newRow(col.ColumnName) = "-"
                                        Continue For
                                    End If
                                End If
                            End If
                        Else
                            dia = Integer.Parse(col.ColumnName.Substring(3))
                        End If
                    Else
                        dia = Integer.Parse(col.ColumnName.Substring(3))
                    End If

                    If datosBaseDatos(dni).ContainsKey(col.ColumnName) Then
                        Dim resultadoDia As String = datosBaseDatos(dni)(col.ColumnName)
                        newRow(col.ColumnName) = resultadoDia
                        Select Case resultadoDia
                            Case "A"
                                If horasTrabajadasDict(dni).ContainsKey(dia) Then
                                    Dim horasTrabajadas As Integer = horasTrabajadasDict(dni)(dia)
                                    If horasTrabajadas <= 8 Then
                                        totalHorasNormales += horasTrabajadas
                                    End If
                                End If
                            Case "HEX"
                                If horasTrabajadasDict(dni).ContainsKey(dia) Then
                                    Dim horasTrabajadas As Integer = horasTrabajadasDict(dni)(dia)
                                    If horasTrabajadas > 8 Then
                                        totalHorasNormales += horasTrabajadas
                                    Else
                                        totalHorasNormales += horasTrabajadas
                                    End If
                                    totalHorasExtras += horasExtrasDict(dni)(dia)
                                End If
                            Case "D"
                                If horasTrabajadasDict(dni).ContainsKey(dia) Then
                                    totalHorasNormales += horasTrabajadasDict(dni)(dia)
                                End If
                            Case "V"
                                If horasTrabajadasDict(dni).ContainsKey(dia) Then
                                    totalHorasNormales += horasTrabajadasDict(dni)(dia)
                                End If
                            Case "PM"
                                If horasTrabajadasDict(dni).ContainsKey(dia) Then
                                    totalHorasNormales += horasTrabajadasDict(dni)(dia)
                                End If
                            Case "FT"
                                If horasTrabajadasDict(dni).ContainsKey(dia) Then
                                    totalHorasNormales += horasTrabajadasDict(dni)(dia)
                                    totalHorasExtras += horasExtrasDict(dni)(dia)
                                End If
                        End Select
                    Else
                        newRow(col.ColumnName) = "-" 'F
                    End If
                End If
            Next

            totalHorasTrabajadas = totalHorasNormales + totalHorasExtras
            newRow("H.T") = totalHorasTrabajadas
            newRow("H.TR") = totalHorasNormales
            newRow("H.EX") = totalHorasExtras

            dtMostrar.Rows.Add(newRow)
            codigoSecuencial += 1
        Next

        Return dtMostrar
    End Function


    Private Sub ConfigurarUltraGrid()
        Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
        Dim anioActual As Integer = cbxListaAños.Value
        Dim diasEnElMes As Integer = DateTime.DaysInMonth(anioActual, mesSeleccionado)
        MostrarSemanasEnLabel(mesSeleccionado, anioActual, labelSemanas)

        With dtgListado.DisplayLayout.Bands(0)
            .Columns.ClearUnbound()
            .Columns("Codigo").Header.Caption = "Cod."
            .Columns("ID").Header.Caption = "DNI"
            .Columns("Nombre").Header.Caption = "Personal"
            .Columns("Codigo").Width = 60
            .Columns("ID").Width = 140
            .Columns("Nombre").Width = 200
            .Override.HeaderAppearance.TextHAlign = HAlign.Center
            .Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True

            If .Columns.Exists("OrigenDatos") Then
                .Columns("OrigenDatos").Hidden = True
            End If

            .Groups.Clear()
            .RowLayoutStyle = RowLayoutStyle.GroupLayout

            Dim groupGeneral As UltraGridGroup = .Groups.Add("Información General", "Información General")

            .Columns("ID").RowLayoutColumnInfo.ParentGroup = groupGeneral
            .Columns("Nombre").RowLayoutColumnInfo.ParentGroup = groupGeneral
            .Columns("Codigo").RowLayoutColumnInfo.ParentGroup = groupGeneral

            If tipo = "EVENTUAL" Then

                If tipoPeriodo.StartsWith("SEMANA") Then
                    ' Obtener las fechas del tipoPeriodo actual
                    'Dim partes As String() = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)
                    'Dim fechaInicio As Date = Date.ParseExact(partes(0).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)
                    'Dim fechaFin As Date = Date.ParseExact(partes(1).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)

                    '' Crear solo el grupo para la semana específica
                    'Dim nombreGrupo As String = $"Semana ({fechaInicio:dd/MM} - {fechaFin:dd/MM})"
                    'Dim groupSemana As UltraGridGroup = .Groups.Add(nombreGrupo, nombreGrupo)

                    '' Asignar columnas solo para los días de esta semana
                    'Dim fechaActual As DateTime = fechaInicio
                    'While fechaActual <= fechaFin
                    '    Dim nombreColumna As String = $"Dia{fechaActual:dd-MM}"
                    '    If .Columns.Exists(nombreColumna) Then
                    '        Dim col As UltraGridColumn = .Columns(nombreColumna)
                    '        col.Header.Caption = fechaActual.Day.ToString()
                    '        col.Width = 60
                    '        col.CellAppearance.TextHAlign = HAlign.Center
                    '        col.RowLayoutColumnInfo.ParentGroup = groupSemana
                    '    End If
                    '    fechaActual = fechaActual.AddDays(1)
                    'End While

                    Dim partes As String() = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)

                    ' Parsear solo día y mes
                    Dim diaInicio As Integer = Integer.Parse(partes(0).Trim().Split("/"c)(0))
                    Dim mesInicio As Integer = Integer.Parse(partes(0).Trim().Split("/"c)(1))
                    Dim diaFin As Integer = Integer.Parse(partes(1).Trim().Split("/"c)(0))
                    Dim mesFin As Integer = Integer.Parse(partes(1).Trim().Split("/"c)(1))

                    ' Determinar el año correcto para cada fecha
                    Dim anioInicio As Integer = anioActual
                    Dim anioFin As Integer = anioActual

                    ' Si el mes de inicio es mayor que el mes de fin, hay cruce de año
                    If mesInicio > mesFin Then
                        anioFin = anioActual + 1
                    End If

                    ' Si estamos viendo desde enero y el inicio es diciembre, el inicio es del año anterior
                    If mesSeleccionado = 1 And mesInicio = 12 Then
                        anioInicio = anioActual - 1
                    End If

                    ' Si estamos viendo desde diciembre y el fin es enero, el fin es del año siguiente  
                    If mesSeleccionado = 12 And mesFin = 1 Then
                        anioFin = anioActual + 1
                    End If

                    ' Crear las fechas con los años correctos
                    Dim fechaInicio As New Date(anioInicio, mesInicio, diaInicio)
                    Dim fechaFin As New Date(anioFin, mesFin, diaFin)

                    ' Crear solo el grupo para la semana específica
                    Dim nombreGrupo As String = $"Semana ({fechaInicio:dd/MM} - {fechaFin:dd/MM})"
                    Dim groupSemana As UltraGridGroup = .Groups.Add(nombreGrupo, nombreGrupo)

                    ' Asignar columnas solo para los días de esta semana
                    Dim fechaActual As DateTime = fechaInicio
                    While fechaActual <= fechaFin
                        Dim nombreColumna As String = $"Dia{fechaActual:dd-MM}"
                        If .Columns.Exists(nombreColumna) Then
                            Dim col As UltraGridColumn = .Columns(nombreColumna)
                            col.Header.Caption = fechaActual.Day.ToString()
                            col.Width = 60
                            col.CellAppearance.TextHAlign = HAlign.Center
                            col.RowLayoutColumnInfo.ParentGroup = groupSemana
                        End If
                        fechaActual = fechaActual.AddDays(1)
                    End While
                Else
                    Dim group1 As UltraGridGroup = .Groups.Add("Primera Quincena", "Primera Quincena")
                    Dim group2 As UltraGridGroup = .Groups.Add("Segunda Quincena", "Segunda Quincena")

                    For i As Integer = 1 To diasEnElMes
                        Dim diaCol As String = $"Dia{i}"

                        If .Columns.Exists(diaCol) Then
                            Dim col As UltraGridColumn = .Columns(diaCol)
                            col.Header.Caption = i.ToString()
                            col.Width = 60
                            col.CellAppearance.TextHAlign = HAlign.Center

                            Select Case tipoQuincena
                                Case 1
                                    col.Hidden = i > 15
                                    If i <= 15 Then col.RowLayoutColumnInfo.ParentGroup = group1
                                    group1.Hidden = False

                                Case 2
                                    col.Hidden = i <= 15
                                    If i > 15 Then col.RowLayoutColumnInfo.ParentGroup = group2
                                    group2.Hidden = False

                                Case 3
                                    col.Hidden = False
                                    If i <= 15 Then
                                        col.RowLayoutColumnInfo.ParentGroup = group1
                                    Else
                                        col.RowLayoutColumnInfo.ParentGroup = group2
                                    End If
                                    group1.Hidden = False
                                    group2.Hidden = False
                            End Select
                        End If
                    Next
                    Select Case tipoQuincena
                        Case 1
                            group1.Hidden = False
                            group2.Hidden = True

                        Case 2
                            group1.Hidden = True
                            group2.Hidden = False

                        Case 3
                            group1.Hidden = False
                            group2.Hidden = False
                    End Select
                End If
            Else
                Dim group1 As UltraGridGroup = .Groups.Add("Primera Quincena", "Primera Quincena")
                Dim group2 As UltraGridGroup = .Groups.Add("Segunda Quincena", "Segunda Quincena")

                For i As Integer = 1 To diasEnElMes
                    Dim diaCol As String = $"Dia{i}"

                    If .Columns.Exists(diaCol) Then
                        Dim col As UltraGridColumn = .Columns(diaCol)
                        col.Header.Caption = i.ToString()
                        col.Width = 60
                        col.CellAppearance.TextHAlign = HAlign.Center

                        Select Case tipoQuincena
                            Case 1
                                col.Hidden = i > 15
                                If i <= 15 Then col.RowLayoutColumnInfo.ParentGroup = group1
                                group1.Hidden = False

                            Case 2
                                col.Hidden = i <= 15
                                If i > 15 Then col.RowLayoutColumnInfo.ParentGroup = group2
                                group2.Hidden = False

                            Case 3
                                col.Hidden = False
                                If i <= 15 Then
                                    col.RowLayoutColumnInfo.ParentGroup = group1
                                Else
                                    col.RowLayoutColumnInfo.ParentGroup = group2
                                End If
                                group1.Hidden = False
                                group2.Hidden = False
                        End Select
                    End If
                Next
                Select Case tipoQuincena
                    Case 1
                        group1.Hidden = False
                        group2.Hidden = True

                    Case 2
                        group1.Hidden = True
                        group2.Hidden = False

                    Case 3
                        group1.Hidden = False
                        group2.Hidden = False
                End Select
            End If

            Dim groupHoras As UltraGridGroup = .Groups.Add("Informe de Horas", "Informe de Horas")
            For Each colName As String In {"H.T", "H.TR", "H.EX"}
                If Not .Columns.Exists(colName) Then
                    .Columns.Add(colName)
                End If
                .Columns(colName).Width = 70
                .Columns(colName).CellAppearance.TextHAlign = HAlign.Center
                .Columns(colName).RowLayoutColumnInfo.ParentGroup = groupHoras
            Next
        End With

        dtgListado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        clsBasicas.Filtrar_Tabla(dtgListado, False)
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
                            totalCoNFeriadoNoTrabajado += 1
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
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ReiniciarContadores()
        CargarDatosBaseDeDatos()
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
                            Case "IN"
                                clsBasicas.Colorear_SegunValor(dtgListado, Color.FromArgb(156, 188, 226), Color.Black, "IN", columna)
                            Case "PM"
                                clsBasicas.Colorear_SegunValor(dtgListado, Color.FromArgb(252, 195, 142), Color.Black, "PM", columna)
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

    Private Sub cbxListaQuincenas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxListaQuincenas.SelectedIndexChanged
        Select Case cbxListaQuincenas.SelectedItem.ToString()
            Case "Primera quincena"
                tipoQuincena = 1
            Case "Segunda quincena"
                tipoQuincena = 2
            Case "Todo"
                tipoQuincena = 3
        End Select
    End Sub

    Private Sub cbMostrarCantidadHoras_CheckedChanged(sender As Object, e As EventArgs) Handles cbMostrarCantidadHoras.CheckedChanged
        Try
            If tipo = "PLANILLA" Then
                MostrarHorasTotales(cbMostrarCantidadHoras.Checked)
            ElseIf tipo = "EVENTUAL" Then
                If tipoPeriodo.StartsWith("SEMANA") Then
                    MostrarHorasTotalesEventuales(cbMostrarCantidadHoras.Checked)
                Else
                    MostrarHorasTotales(cbMostrarCantidadHoras.Checked)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub MostrarHorasTotales(mostrarHoras As Boolean)
        ' Diccionario para almacenar los estados originales
        Static estadosOriginalesDict As New Dictionary(Of String, Dictionary(Of Integer, String))

        For Each fila As UltraGridRow In dtgListado.Rows
            For Each celda As UltraGridCell In fila.Cells
                If celda.Column.Key.StartsWith("Dia") Then
                    Dim dni As String = fila.Cells("ID").Value.ToString()
                    Dim dia As Integer = Integer.Parse(celda.Column.Key.Replace("Dia", ""))
                    Dim estadoActual As String = celda.Value.ToString()

                    ' Primera vez que se ejecuta o al cambiar de no mostrar a mostrar
                    If mostrarHoras Then
                        ' Guardar estado original para TODOS los valores
                        If Not estadosOriginalesDict.ContainsKey(dni) Then
                            estadosOriginalesDict(dni) = New Dictionary(Of Integer, String)()
                        End If
                        ' Guardar el estado original
                        estadosOriginalesDict(dni)(dia) = estadoActual

                        ' Mostrar horas si no es "F" - Ahora incluye también "V"
                        If estadoActual <> "F" Then
                            If horasTrabajadasDict.ContainsKey(dni) AndAlso horasTrabajadasDict(dni).ContainsKey(dia) Then
                                Dim horasTrabajadas = horasTrabajadasDict(dni)(dia)
                                Dim horasExtras = horasExtrasDict(dni)(dia)
                                Dim sumaHoras = CDbl(horasTrabajadas + horasExtras)
                                celda.Value = sumaHoras.ToString()
                            End If
                        End If
                    Else
                        ' Restaurar al estado original usando el diccionario
                        If estadosOriginalesDict.ContainsKey(dni) AndAlso estadosOriginalesDict(dni).ContainsKey(dia) Then
                            ' Restaurar al valor original guardado
                            celda.Value = estadosOriginalesDict(dni)(dia)
                        Else
                            ' Si no hay valor guardado, determinar por las horas (caso de fallback)
                            If horasTrabajadasDict.ContainsKey(dni) AndAlso horasTrabajadasDict(dni).ContainsKey(dia) Then
                                Dim horasTrabajadas = horasTrabajadasDict(dni)(dia)
                                Dim horasExtras = horasExtrasDict(dni)(dia)
                                If Double.Parse(horasExtras) > 0 Then
                                    celda.Value = "HEX"
                                ElseIf Integer.Parse(horasTrabajadas) >= 0 And Integer.Parse(horasTrabajadas) <= 8 Then
                                    celda.Value = "A"
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If e.Cell.Column.Key.StartsWith("Dia") Then
            ' Verificar si se seleccionó un registro
            If e.Cell.Row.Cells("ID").Value Is Nothing Then
                msj_advert("Selecciona un registro.")
                Exit Sub
            End If

            Dim idTrabajador As String = e.Cell.Row.Cells("ID").Value.ToString()
            Dim diaKey As String = e.Cell.Column.Key.Replace("Dia", "")
            Dim diaSeleccionado As Integer
            Dim nombreTrabajador As String = e.Cell.Row.Cells("Nombre").Value.ToString()
            Dim fechaTexto As String = ""

            ' Obtener el día seleccionado
            If diaKey.Contains("-") Then
                ' Si el formato es dd-MM, usamos el texto completo para mostrar
                diaSeleccionado = Integer.Parse(diaKey.Split("-"c)(0))
                fechaTexto = diaKey  ' Guardamos el formato dd-MM para mostrarlo
            Else
                ' Si el formato es solo el número del día
                diaSeleccionado = Integer.Parse(diaKey)
                fechaTexto = diaSeleccionado.ToString()

                ' Agregar el mes actual para mayor claridad
                Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
                Dim anioActual As Integer = cbxListaAños.Value
                Dim fecha As New DateTime(anioActual, mesSeleccionado, diaSeleccionado)
                fechaTexto = fecha.ToString("dd/MM/yyyy")
            End If

            ' Buscar la observación para este trabajador y día
            If observacionesDict.ContainsKey(idTrabajador) AndAlso observacionesDict(idTrabajador).ContainsKey(diaSeleccionado) Then
                Dim observacion As String = observacionesDict(idTrabajador)(diaSeleccionado)

                ' Preparar el título del MessageBox
                Dim titulo As String = $"Observación - Día {fechaTexto}"

                ' Preparar el mensaje con el nombre del trabajador
                Dim mensaje As String = $"Trabajador: {nombreTrabajador}{Environment.NewLine}{Environment.NewLine}"

                ' Agregar la observación
                If String.IsNullOrEmpty(observacion) Then
                    mensaje += "No hay observaciones para este registro."
                Else
                    mensaje += observacion
                End If

                ' Mostrar la observación en un MessageBox
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show($"No hay información para el día {fechaTexto}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub MostrarHorasTotalesEventuales(mostrarHoras As Boolean)
        ' Diccionario para almacenar los estados originales
        Static estadosOriginalesDict As New Dictionary(Of String, Dictionary(Of Integer, String))

        For Each fila As UltraGridRow In dtgListado.Rows
            For Each celda As UltraGridCell In fila.Cells
                If celda.Column.Key.StartsWith("Dia") Then
                    Dim dni As String = fila.Cells("ID").Value.ToString()
                    ' Extraer la fecha del nombre de la columna (formato: "Dia{dd-MM}")
                    Dim fechaStr As String = celda.Column.Key.Substring(3)
                    Dim dia As Integer = Integer.Parse(fechaStr.Split("-"c)(0))
                    Dim estadoActual As String = celda.Value?.ToString()

                    ' Primera vez que se ejecuta o al cambiar de no mostrar a mostrar
                    If mostrarHoras Then
                        ' Guardar estado original para TODOS los valores
                        If Not estadosOriginalesDict.ContainsKey(dni) Then
                            estadosOriginalesDict(dni) = New Dictionary(Of Integer, String)()
                        End If
                        ' Guardar el estado original
                        estadosOriginalesDict(dni)(dia) = estadoActual

                        ' Mostrar horas si no es "F"
                        If estadoActual <> "F" Then
                            If horasTrabajadasDict.ContainsKey(dni) AndAlso horasTrabajadasDict(dni).ContainsKey(dia) Then
                                Dim horasTrabajadas = horasTrabajadasDict(dni)(dia)
                                Dim horasExtras = horasExtrasDict(dni)(dia)
                                Dim sumaHoras = CDbl(horasTrabajadas + horasExtras)
                                celda.Value = sumaHoras.ToString()
                            End If
                        End If
                    Else
                        ' Restaurar al estado original usando el diccionario
                        If estadosOriginalesDict.ContainsKey(dni) AndAlso estadosOriginalesDict(dni).ContainsKey(dia) Then
                            ' Restaurar al valor original guardado
                            celda.Value = estadosOriginalesDict(dni)(dia)
                        Else
                            ' Si no hay valor guardado, aplicar la lógica original
                            If horasTrabajadasDict.ContainsKey(dni) AndAlso horasTrabajadasDict(dni).ContainsKey(dia) Then
                                Dim horasTrabajadas = horasTrabajadasDict(dni)(dia)
                                Dim horasExtras = horasExtrasDict(dni)(dia)
                                Dim sumaHoras = CDbl(horasTrabajadas + horasExtras)

                                If Double.Parse(horasExtras) > 0 Then
                                    celda.Value = "HEX"
                                ElseIf Integer.Parse(horasTrabajadas) > 0 AndAlso Integer.Parse(horasTrabajadas) <= 8 Then
                                    celda.Value = "A"
                                ElseIf Integer.Parse(horasTrabajadas) = 0 Then
                                    ' Si las horas trabajadas son 0, verificar si era F o PM originalmente
                                    If estadoActual = "F" OrElse estadoActual = "PM" Then
                                        celda.Value = estadoActual
                                    Else
                                        celda.Value = String.Empty
                                    End If
                                End If
                            ElseIf estadoActual = "F" OrElse estadoActual = "PM" Then
                                ' Si el valor original era "F" o "PM", mantenerlo
                                celda.Value = estadoActual
                            End If
                        End If
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub cbMostrarHorasExtras_CheckedChanged(sender As Object, e As EventArgs) Handles cbMostrarHorasExtras.CheckedChanged
        Try
            If tipo = "PLANILLA" Then
                MostrarHorasExtras(cbMostrarHorasExtras.Checked)
            ElseIf tipo = "EVENTUAL" Then
                If tipoPeriodo.StartsWith("SEMANA") Then
                    MostrarHorasExtrasEventuales(cbMostrarHorasExtras.Checked)
                Else
                    MostrarHorasExtras(cbMostrarHorasExtras.Checked)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub MostrarHorasExtras(mostrarHorasExtras As Boolean)
        For Each fila As UltraGridRow In dtgListado.Rows
            For Each celda As UltraGridCell In fila.Cells
                If celda.Column.Key.StartsWith("Dia") Then
                    Dim dni As String = fila.Cells("ID").Value.ToString()
                    Dim dia As Integer = Integer.Parse(celda.Column.Key.Replace("Dia", ""))

                    Dim estadoOriginal As String = celda.Value.ToString()

                    If estadoOriginal = "F" Then
                        Continue For
                    End If

                    If estadoOriginal = "V" Then
                        Continue For
                    End If

                    If estadoOriginal = "D" Then
                        Continue For
                    End If

                    If estadoOriginal = "PM" Then
                        Continue For
                    End If

                    If estadoOriginal = "FNT" Then
                        Continue For
                    End If


                    If mostrarHorasExtras Then
                        ' Mostrar horas reales si era HEX o FT
                        If (estadoOriginal = "HEX" Or estadoOriginal = "FT") AndAlso horasExtrasDict.ContainsKey(dni) AndAlso horasExtrasDict(dni).ContainsKey(dia) Then
                            Dim horasExtras As Double = horasExtrasDict(dni)(dia)
                            celda.Value = horasExtras.ToString()
                        End If
                    Else
                        Dim horasTrabajadas As Double = 0
                        Dim horasExtras As Double = 0
                        Dim feriadoTrabajado As String = ""

                        If horasTrabajadasDict.ContainsKey(dni) AndAlso horasTrabajadasDict(dni).ContainsKey(dia) Then
                            horasTrabajadas = horasTrabajadasDict(dni)(dia)
                        End If

                        If horasExtrasDict.ContainsKey(dni) AndAlso horasExtrasDict(dni).ContainsKey(dia) Then
                            horasExtras = horasExtrasDict(dni)(dia)
                        End If

                        If feriadosDict.ContainsKey(dni) AndAlso feriadosDict(dni).ContainsKey(dia) Then
                            feriadoTrabajado = feriadosDict(dni)(dia)
                        End If

                        ' Aplicar prioridades
                        If feriadoTrabajado = "SI" Then
                            celda.Value = "FT"
                        ElseIf horasExtras > 0 Then
                            celda.Value = "HEX"
                        ElseIf horasTrabajadas < 8 Then
                            celda.Value = "IN"
                        Else
                            celda.Value = "A"
                        End If
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub MostrarHorasExtrasEventuales(mostrarHorasExtras As Boolean)
        For Each fila As UltraGridRow In dtgListado.Rows
            For Each celda As UltraGridCell In fila.Cells
                If celda.Column.Key.StartsWith("Dia") Then
                    Dim dni As String = fila.Cells("ID").Value.ToString()

                    ' Extraer la fecha del nombre de la columna (formato: "Dia{dd-MM}")
                    Dim fechaStr As String = celda.Column.Key.Substring(3)
                    Dim dia As Integer = Integer.Parse(fechaStr.Split("-"c)(0))

                    Dim estadoOriginal As String = celda.Value?.ToString()

                    If estadoOriginal = "F" Then
                        Continue For
                    End If

                    If estadoOriginal = "V" Then
                        Continue For
                    End If

                    If estadoOriginal = "D" Then
                        Continue For
                    End If

                    If estadoOriginal = "PM" Then
                        Continue For
                    End If

                    If estadoOriginal = "FNT" Then
                        Continue For
                    End If


                    If mostrarHorasExtras Then
                        If (estadoOriginal = "HEX" Or estadoOriginal = "FT") AndAlso horasExtrasDict.ContainsKey(dni) AndAlso horasExtrasDict(dni).ContainsKey(dia) Then
                            Dim horasExtras As Double = horasExtrasDict(dni)(dia)
                            celda.Value = horasExtras.ToString()
                        End If
                    Else
                        Dim horasTrabajadas As Double = 0
                        Dim horasExtras As Double = 0
                        Dim feriadoTrabajado As String = ""

                        If horasTrabajadasDict.ContainsKey(dni) AndAlso horasTrabajadasDict(dni).ContainsKey(dia) Then
                            horasTrabajadas = horasTrabajadasDict(dni)(dia)
                        End If

                        If horasExtrasDict.ContainsKey(dni) AndAlso horasExtrasDict(dni).ContainsKey(dia) Then
                            horasExtras = horasExtrasDict(dni)(dia)
                        End If

                        If feriadosDict.ContainsKey(dni) AndAlso feriadosDict(dni).ContainsKey(dia) Then
                            feriadoTrabajado = feriadosDict(dni)(dia)
                        End If

                        ' Aplicar prioridades
                        If feriadoTrabajado = "SI" Then
                            celda.Value = "FT"
                        ElseIf horasExtras > 0 Then
                            celda.Value = "HEX"
                        ElseIf horasTrabajadas < 8 Then
                            celda.Value = "IN"
                        Else
                            celda.Value = "A"
                        End If
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub InicializarDtgAsistencia()
        Dim dt As New DataTable("Asistencia")

        dt.Columns.Add("Cod.", GetType(Integer))
        dt.Columns.Add("DNI", GetType(String))
        dt.Columns.Add("Personal", GetType(String))

        For i As Integer = 1 To 31
            dt.Columns.Add(i.ToString(), GetType(Integer))
        Next

        dt.Columns.Add("H.T", GetType(Double))
        dt.Columns.Add("H.TR", GetType(Double))
        dt.Columns.Add("H.EX", GetType(Double))

        dtgListado.DataSource = dt

        With dtgListado.DisplayLayout.Bands(0)
            .Columns("Cod.").Width = 90
            .Columns("DNI").Width = 110
            .Columns("Personal").Width = 200
            .Override.HeaderAppearance.TextHAlign = HAlign.Center
            .Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True

            For i As Integer = 1 To 31
                .Columns(i.ToString()).Width = 50
            Next

            .Columns("H.T").Width = 70
            .Columns("H.TR").Width = 70
            .Columns("H.EX").Width = 70
        End With

        dtgListado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        clsBasicas.Filtrar_Tabla(dtgListado, False)

    End Sub

    Private Sub InicializarDtgAsistenciaSemanal()
        Dim dt As New DataTable("Asistencia")
        dt = New DataTable()

        ' Basic columns setup
        dt.Columns.Add("Codigo", GetType(Integer))
        dt.Columns.Add("ID", GetType(String))
        dt.Columns.Add("Nombre", GetType(String))

        Dim mesSeleccionado As Integer = mes
        Dim anioActual As Integer = anio ' Fixed to 2025 for this example

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
                dt.Columns.Add(nombreColumna, GetType(String))
                fechaActual = fechaActual.AddDays(1)
            End While
        Next

        dt.Columns.Add("H.T", GetType(Double))
        dt.Columns.Add("H.TR", GetType(Integer))
        dt.Columns.Add("H.EX", GetType(Double))

        dtgListado.DataSource = dt

        With dtgListado.DisplayLayout.Bands(0)
            .Columns.ClearUnbound()

            ' Configure basic columns
            .Columns("Codigo").Header.Caption = "Cod."
            .Columns("ID").Header.Caption = "DNI"
            .Columns("Nombre").Header.Caption = "Personal"
            .Columns("Codigo").Width = 70
            .Columns("ID").Width = 130
            .Columns("Nombre").Width = 200
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

            ' Create week groups and assign days
            Dim gruposSemanas As New List(Of UltraGridGroup)
            For i As Integer = 0 To semanas.Count - 1
                Dim fechaInicio As DateTime = semanas(i).Item1
                Dim fechaFin As DateTime = semanas(i).Item2
                Dim nombreGrupo As String = $"Semana {i + 1} ({fechaInicio:dd/MM} - {fechaFin:dd/MM})"
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

    Private Sub btnVerObservaciones_Click(sender As Object, e As EventArgs) Handles btnVerObservaciones.Click
        Try
            ' Verificar si hay filas y si hay una fila seleccionada
            If dtgListado.Rows.Count > 0 AndAlso dtgListado.ActiveRow IsNot Nothing Then
                Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow

                ' Verificar que la fila tenga un ID válido
                If activeRow.Cells("ID").Value IsNot Nothing AndAlso Not String.IsNullOrEmpty(activeRow.Cells("ID").Value.ToString()) Then
                    Dim idTrabajador As String = activeRow.Cells("ID").Value.ToString()
                    Dim nombreTrabajador As String = activeRow.Cells("Nombre").Value.ToString()

                    ' Comprobar si hay observaciones para este trabajador
                    If observacionesDict.ContainsKey(idTrabajador) Then
                        Dim observacionesTrabajador As Dictionary(Of Integer, String) = observacionesDict(idTrabajador)

                        ' Si no hay observaciones, mostrar un mensaje
                        If observacionesTrabajador.Count = 0 Then
                            MessageBox.Show($"No hay observaciones registradas para {nombreTrabajador}.",
                                    "Sin observaciones", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return
                        End If

                        ' Construir el mensaje con todas las observaciones
                        Dim sb As New StringBuilder()
                        sb.AppendLine($"Resumen de observaciones para: {nombreTrabajador} ({idTrabajador})")
                        sb.AppendLine()

                        ' Obtener el mes y año seleccionados para formatear las fechas
                        Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
                        Dim anioActual As Integer = cbxListaAños.Value

                        ' Organizar las observaciones por día
                        Dim diasConObservacion As New List(Of Integer)(observacionesTrabajador.Keys)
                        diasConObservacion.Sort() ' Ordenar los días

                        Dim tieneObservaciones As Boolean = False

                        ' Recorrer los días con observaciones
                        For Each dia As Integer In diasConObservacion
                            Dim observacion As String = observacionesTrabajador(dia)

                            ' Solo incluir si hay una observación no vacía
                            If Not String.IsNullOrWhiteSpace(observacion) _
                                AndAlso Not observacion.Trim().ToUpper().Contains("SIN OBSERVACIÓN") _
                                AndAlso Not observacion.Trim().ToUpper().Contains("DESCANSO") _
                                AndAlso Not observacion.Trim().ToUpper().Contains("VACACIONES") Then
                                tieneObservaciones = True

                                ' Formatear la fecha
                                Dim fecha As New DateTime(anioActual, mesSeleccionado, dia)

                                ' Detectar si es período de semana para ajustar posible mes
                                If tipo = "EVENTUAL" AndAlso tipoPeriodo.StartsWith("SEMANA") Then
                                    ' Extraer las fechas del tipoPeriodo
                                    Dim partes As String() = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)
                                    Dim fechaInicio As Date = Date.ParseExact(partes(0).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)

                                    ' Si el día es menor que el día de inicio, probablemente pertenece al mes siguiente
                                    If dia < fechaInicio.Day Then
                                        fecha = New DateTime(anioActual, mesSeleccionado + 1, dia)
                                    End If
                                End If

                                sb.AppendLine($"- Observación:  {observacion}")
                                sb.AppendLine()
                            End If
                        Next

                        ' Si después de filtrar no hay observaciones con contenido
                        If Not tieneObservaciones Then
                            msj_advert($"No hay observaciones con contenido para {nombreTrabajador}.")
                            Return
                        End If

                        Dim frm As New FrmVerObservaciones()
                        frm.datosTrabajador = nombreTrabajador
                        frm.observacion = sb.ToString()
                        frm.ShowDialog()

                    Else
                        msj_advert($"No hay observaciones con contenido para {nombreTrabajador}.")
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub btnExportarRrhhCtrlasist_Click(sender As Object, e As EventArgs) Handles btnExportarRrhhCtrlasist.Click
        clsBasicas.ExportarExcel("Reporte de Asistencia de Trabajadores", dtgListado)
    End Sub

    Private Sub btnVerHorasExtrasMarranas_Click(sender As Object, e As EventArgs) Handles btnVerHorasExtrasMarranas.Click
        Try
            ' Verificar si hay filas y si hay una fila seleccionada
            If dtgListado.Rows.Count > 0 AndAlso dtgListado.ActiveRow IsNot Nothing Then
                Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow

                ' Verificar que la fila tenga un ID válido
                If activeRow.Cells("ID").Value IsNot Nothing AndAlso Not String.IsNullOrEmpty(activeRow.Cells("ID").Value.ToString()) Then
                    Dim idTrabajador As String = activeRow.Cells("ID").Value.ToString()
                    Dim nombreTrabajador As String = activeRow.Cells("Nombre").Value.ToString()

                    ' Comprobar si hay horas extras marranas para este trabajador
                    If horasExtrasMarranasDict.ContainsKey(idTrabajador) Then
                        Dim horasMarranasTrabajador As Dictionary(Of Integer, Double) = horasExtrasMarranasDict(idTrabajador)

                        ' Si no hay horas extras marranas, mostrar un mensaje
                        If horasMarranasTrabajador.Count = 0 Then
                            MessageBox.Show($"No hay horas extras marranas registradas para {nombreTrabajador}.",
                                "Sin horas extras marranas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return
                        End If

                        ' Construir el mensaje con todas las horas extras marranas
                        Dim sb As New StringBuilder()
                        sb.AppendLine($"Resumen de horas extras marranas para: {nombreTrabajador} ({idTrabajador})")
                        sb.AppendLine()

                        ' Obtener el mes y año seleccionados para formatear las fechas
                        Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
                        Dim anioActual As Integer = cbxListaAños.Value

                        ' Organizar las horas extras marranas por día
                        Dim diasConHorasMarranas As New List(Of Integer)(horasMarranasTrabajador.Keys)
                        diasConHorasMarranas.Sort() ' Ordenar los días

                        Dim tieneHorasMarranas As Boolean = False
                        Dim totalHorasMarranas As Double = 0

                        ' Recorrer los días con horas extras marranas
                        For Each dia As Integer In diasConHorasMarranas
                            Dim horasMarranas As Double = horasMarranasTrabajador(dia)

                            ' Solo incluir si hay horas extras marranas mayores a 0
                            If horasMarranas > 0 Then
                                tieneHorasMarranas = True
                                totalHorasMarranas += horasMarranas

                                ' Formatear la fecha
                                Dim fecha As New DateTime(anioActual, mesSeleccionado, dia)

                                ' Detectar si es período de semana para ajustar posible mes
                                If tipo = "EVENTUAL" AndAlso tipoPeriodo.StartsWith("SEMANA") Then
                                    ' Extraer las fechas del tipoPeriodo
                                    Dim partes As String() = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)
                                    Dim fechaInicio As Date = Date.ParseExact(partes(0).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)

                                    ' Si el día es menor que el día de inicio, probablemente pertenece al mes siguiente
                                    If dia < fechaInicio.Day Then
                                        fecha = New DateTime(anioActual, mesSeleccionado + 1, dia)
                                    End If
                                End If

                                sb.AppendLine($"- Día {dia}: {horasMarranas} horas extras marranas")
                            End If
                        Next

                        ' Si después de filtrar no hay horas extras marranas
                        If Not tieneHorasMarranas Then
                            msj_advert($"No hay horas extras marranas registradas para {nombreTrabajador}.")
                            Return
                        End If

                        ' Agregar total al final
                        sb.AppendLine()
                        sb.AppendLine($"Total de horas extras marranas: {totalHorasMarranas} horas")

                        Dim frm As New FrmVerHorasExtMarranas()
                        frm.datosTrabajador = nombreTrabajador
                        frm.observacion = sb.ToString()
                        frm.ShowDialog()

                    Else
                        msj_advert($"No hay horas extras marranas registradas para {nombreTrabajador}.")
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
End Class