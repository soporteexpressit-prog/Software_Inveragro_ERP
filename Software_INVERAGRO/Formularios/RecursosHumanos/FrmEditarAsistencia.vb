Imports System.Globalization
Imports System.Text
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmEditarAsistencia

    Dim cn As New cnControlAsistencia
    Dim horariosTrabajadores As New Dictionary(Of String, List(Of (String, String, String, String, String, String, Integer, String, String, String)))()
    Dim horasTrabajadasDict As New Dictionary(Of String, Dictionary(Of Integer, Integer))()
    Private horasExtrasDict As New Dictionary(Of String, Dictionary(Of Integer, Double))()
    Private _idPlantel As Integer
    Public idHorario As Integer
    Public anio As Integer
    Public mes As Integer
    Public plantel As String
    Public tipo As String
    Public tipoPeriodo As String
    Public estado As String
    Dim dtMostrar As New DataTable()

    Dim ultimoDiaRegistro As Integer
    Dim ultimoDiaRegistroEventual As Integer

    Dim totalAsistenciaCompleta As Integer = 0
    Dim totalInasistencias As Integer = 0
    Dim totalIncompletas As Integer = 0
    Dim totalConHorasExtras As Integer = 0
    Dim totalConPermisoMedico As Integer = 0
    Dim totalConDescanso As Integer = 0
    Dim totalConFeriadoTrabajado As Integer = 0
    Dim totalConFeriadoNoTrabajado As Integer = 0

    Private Sub FrmEditarAsistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarAños()
        ListarPlanteles()
        AsignarValores()
        BotonAplicarMensual()
        clsBasicas.Formato_Tablas_Grid_Asistencia(dtgListado)
        Me.Size = New Size(1400, 700)
    End Sub

    Sub BotonAplicarMensual()
        If tipo = "PLANILLA" Then
            btnAplicar.Visible = True
        ElseIf tipo = "EVENTUAL" Then
            If tipoPeriodo = "QUINCENA 1" Or tipoPeriodo = "QUINCENA 2" Then
                btnAplicar.Visible = True
            Else
                btnAplicarVacaciones.Visible = False
                btnAplicar.Visible = True
            End If
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
        CargarDatosBaseDeDatos()
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
        obj.Tipo = tipo

        Return cn.Cn_ListarAsistenciaPorHorario(obj)
    End Function

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

    Private Sub dtgListado_ClickCellButton(sender As Object, e As CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "Eliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿Está seguro que desea eliminar este registro?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                ' Obtener el DNI antes de eliminar la fila
                Dim dni As String = e.Cell.Row.Cells("ID").Value.ToString()

                Dim obj As New coControlAsistencia With {
                    .NumDocumento = dni,
                    .idHorario = idHorario
                }

                Dim mensaje As String = cn.Cn_EliminarTrabajadorAsistencia(obj)
                If obj.CodeError = 0 Then
                    msj_ok(mensaje)

                    dtMostrar.Rows.RemoveAt(e.Cell.Row.Index)
                    dtMostrar.AcceptChanges()
                    dtgListado.DataSource = dtMostrar

                    ' Eliminar del diccionario horariosTrabajadores si existe
                    If horariosTrabajadores.ContainsKey(dni) Then
                        horariosTrabajadores.Remove(dni)
                    End If
                Else
                    msj_error(mensaje)
                End If
            End If
        End If
    End Sub

    Private Sub ConfigurarUltraGrid()
        Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
        Dim anioActual As Integer = anio
        Dim diasEnElMes As Integer = DateTime.DaysInMonth(anioActual, mesSeleccionado)
        MostrarSemanasEnLabel(mesSeleccionado, anioActual, labelSemanas)

        With dtgListado.DisplayLayout.Bands(0)
            .Columns.ClearUnbound()
            .Columns("Codigo").Header.Caption = "Cod."
            .Columns("ID").Header.Caption = "DNI"
            .Columns("Nombre").Header.Caption = "Personal"
            .Columns("Eliminar").Header.Caption = ""
            .Columns("Codigo").Width = 60
            .Columns("ID").Width = 140
            .Columns("Nombre").Width = 200
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


            .Columns("ID").RowLayoutColumnInfo.ParentGroup = groupGeneral
            .Columns("Nombre").RowLayoutColumnInfo.ParentGroup = groupGeneral
            .Columns("Codigo").RowLayoutColumnInfo.ParentGroup = groupGeneral

            If tipo = "EVENTUAL" Then

                If tipoPeriodo.StartsWith("SEMANA") Then
                    ' Obtener las fechas del tipoPeriodo actual
                    Dim partes As String() = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)
                    Dim fechaInicio As Date = Date.ParseExact(partes(0).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)
                    Dim fechaFin As Date = Date.ParseExact(partes(1).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)

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

                            If i <= 15 Then
                                col.RowLayoutColumnInfo.ParentGroup = group1
                            Else
                                col.RowLayoutColumnInfo.ParentGroup = group2
                            End If
                        End If
                    Next
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

                        If i <= 15 Then
                            col.RowLayoutColumnInfo.ParentGroup = group1
                        Else
                            col.RowLayoutColumnInfo.ParentGroup = group2
                        End If
                    End If
                Next
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

    Private Function EstructuraDeDatosParaMostrar(dtBaseDatos As DataTable) As DataTable
        horasExtrasDict.Clear()
        horasTrabajadasDict.Clear()

        dtMostrar = New DataTable()
        Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
        Dim anioActual As Integer = cbxListaAños.Value
        Dim diasEnElMes As Integer = DateTime.DaysInMonth(anioActual, mesSeleccionado)

        ' Columnas básicas
        dtMostrar.Columns.Add("Codigo", GetType(Integer))
        dtMostrar.Columns.Add("ID", GetType(String))
        dtMostrar.Columns.Add("Nombre", GetType(String))

        ' Agregar columnas de días según el tipo
        If tipo = "EVENTUAL" Then

            If tipoPeriodo.StartsWith("SEMANA") Then
                ' Extraer las fechas del tipoPeriodo
                Dim partes As String() = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)
                Dim fechaInicio As Date = Date.ParseExact(partes(0).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)
                Dim fechaFin As Date = Date.ParseExact(partes(1).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)

                ' Agregar columnas solo para los días de la semana seleccionada
                Dim fechaActual As DateTime = fechaInicio
                While fechaActual <= fechaFin
                    dtMostrar.Columns.Add($"Dia{fechaActual:dd-MM}", GetType(String))
                    fechaActual = fechaActual.AddDays(1)
                End While
            Else
                For dia As Integer = 1 To diasEnElMes
                    dtMostrar.Columns.Add($"Dia{dia}", GetType(String))
                Next
            End If
        Else
            For dia As Integer = 1 To diasEnElMes
                dtMostrar.Columns.Add($"Dia{dia}", GetType(String))
            Next
        End If

        ' Columnas adicionales
        dtMostrar.Columns.Add("H.T", GetType(Double))
        dtMostrar.Columns.Add("H.TR", GetType(Integer))
        dtMostrar.Columns.Add("H.EX", GetType(Double))
        dtMostrar.Columns.Add("OrigenDatos", GetType(String))
        dtMostrar.Columns.Add("Eliminar", GetType(Button))

        ' Obtener último día de registro
        Dim obj As New coControlAsistencia
        obj.IdUbicacion = _idPlantel
        obj.Mes = mes
        obj.Anio = anio
        obj.Tipo = tipo
        obj.idHorario = idHorario

        Dim mensaje As String = cn.Cn_ObtenerUltimoDiaRegistroAsistencia(obj)
        ultimoDiaRegistro = obj.UltimoDiaReg

        ' Determinar rango de días
        Dim rangoInicio As Integer
        Dim rangoFin As Integer

        If tipo = "EVENTUAL" Then
            If tipoPeriodo.StartsWith("SEMANA") Then
                Dim partes As String() = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)
                Dim fechaInicio As Date = Date.ParseExact(partes(0).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)
                Dim fechaFin As Date = Date.ParseExact(partes(1).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)

                rangoInicio = fechaInicio.Day
                rangoFin = fechaFin.Day

                ' Si el mes de inicio es distinto al mes de fin, ajustamos el rango correctamente
                If fechaInicio.Month <> fechaFin.Month Then
                    If mesSeleccionado = fechaInicio.Month Then
                        rangoFin = DateTime.DaysInMonth(anioActual, mesSeleccionado)
                    ElseIf mesSeleccionado = fechaFin.Month Then
                        rangoInicio = 1
                    End If
                End If

                ' Ajustamos el rango según el último día registrado
                If mesSeleccionado = fechaInicio.Month Or mesSeleccionado = fechaFin.Month Then
                    rangoFin = Math.Min(ultimoDiaRegistro, rangoFin)
                Else
                    rangoInicio = 0
                    rangoFin = 0
                End If
            Else
                If tipoPeriodo = "QUINCENA 2" AndAlso (estado = "PENDIENTE" Or estado = "OBSERVADO" Or estado = "INCOMPLETO") Then
                    rangoInicio = 16
                    rangoFin = ultimoDiaRegistro
                ElseIf tipoPeriodo = "QUINCENA 1" AndAlso (estado = "PENDIENTE" Or estado = "OBSERVADO" Or estado = "INCOMPLETO") Then
                    rangoInicio = 1
                    rangoFin = ultimoDiaRegistro
                ElseIf tipoPeriodo = "MENSUAL" AndAlso (estado = "PENDIENTE" Or estado = "OBSERVADO" Or estado = "INCOMPLETO") Then
                    rangoInicio = 1
                    rangoFin = ultimoDiaRegistro
                End If
            End If
        Else
            If tipoPeriodo = "QUINCENA 2" AndAlso (estado = "PENDIENTE" Or estado = "OBSERVADO" Or estado = "INCOMPLETO") Then
                rangoInicio = 16
                rangoFin = ultimoDiaRegistro
            ElseIf tipoPeriodo = "QUINCENA 1" AndAlso (estado = "PENDIENTE" Or estado = "OBSERVADO" Or estado = "INCOMPLETO") Then
                rangoInicio = 1
                rangoFin = ultimoDiaRegistro
            ElseIf tipoPeriodo = "MENSUAL" AndAlso (estado = "PENDIENTE" Or estado = "OBSERVADO" Or estado = "INCOMPLETO") Then
                rangoInicio = 1
                rangoFin = ultimoDiaRegistro
            End If
        End If

        ' Procesar datos
        Dim datosBaseDatos As New Dictionary(Of String, Dictionary(Of Integer, String))()
        Dim nombresEmpleados As New Dictionary(Of String, String)()
        Dim codigoSecuencial As Integer = 1

        For Each row As DataRow In dtBaseDatos.Rows
            Dim dni As String = row("ID").ToString()
            Dim datos As String = row("Personal").ToString()
            Dim dia As Integer = CInt(row("dia"))
            Dim horaEntrada As String = row("horaEntrada").ToString()
            Dim horaSalida As String = row("horaSalida").ToString()
            Dim permisoMedico As String = row("permisoMedico").ToString().ToUpper()
            Dim observacion As String = row("observacion").ToString()
            Dim pagoEspecial As Double = row("pagoEspecial").ToString()
            Dim horasExtras As Double = row("horasExtras")
            Dim horasTrabajadas As Integer = row("horasTrabajadas")
            Dim horasRefrigerio As Integer = row("horasRefrigerio")
            Dim feriadoTrabajado As String = row("feriadoTrabajado").ToString().ToUpper()
            Dim horasExtrasMarranas As Double = row("horasExtrasMarranas")


            If Not datosBaseDatos.ContainsKey(dni) Then
                datosBaseDatos(dni) = New Dictionary(Of Integer, String)()
                horasExtrasDict(dni) = New Dictionary(Of Integer, Double)()
                horasTrabajadasDict(dni) = New Dictionary(Of Integer, Integer)()
                nombresEmpleados(dni) = datos
            End If

            Dim resultado As String

            If tipo = "EVENTUAL" Then

                If tipoPeriodo.StartsWith("SEMANA") Then
                    ' Modificar la condición para manejar rangos que cruzan fin de mes
                    If rangoFin < rangoInicio Then
                        ' Si el rango cruza el fin de mes (ej: 23-1), la condición debería ser:
                        ' día >= rangoInicio OR día <= rangoFin
                        If dia >= rangoInicio OrElse dia <= rangoFin Then
                            If permisoMedico = "SI" Then
                                resultado = "PM"
                                horasTrabajadasDict(dni)(dia) = horasTrabajadas
                            ElseIf feriadoTrabajado = "SI" Then
                                resultado = "FT"
                                horasTrabajadasDict(dni)(dia) = horasTrabajadas
                                horasExtrasDict(dni)(dia) = horasExtras + horasExtrasMarranas
                            ElseIf feriadoTrabajado = "NO" Then
                                resultado = "FNT"
                            ElseIf observacion = "DESCANSO" Then
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
                        ' Comportamiento normal cuando el rango no cruza el fin de mes
                        If dia >= rangoInicio AndAlso dia <= rangoFin Then
                            If permisoMedico = "SI" Then
                                resultado = "PM"
                                horasTrabajadasDict(dni)(dia) = horasTrabajadas
                            ElseIf feriadoTrabajado = "SI" Then
                                resultado = "FT"
                                horasTrabajadasDict(dni)(dia) = horasTrabajadas
                                horasExtrasDict(dni)(dia) = horasExtras + horasExtrasMarranas
                            ElseIf feriadoTrabajado = "NO" Then
                                resultado = "FNT"
                            ElseIf observacion = "DESCANSO" Then
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
                        ElseIf feriadoTrabajado = "NO" Then
                            resultado = "FNT"
                        ElseIf observacion = "DESCANSO" Then
                            resultado = "D"
                            horasTrabajadasDict(dni)(dia) = horasTrabajadas
                        ElseIf observacion = "VACACIONES" Then
                            resultado = "V"
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
                    ElseIf feriadoTrabajado = "NO" Then
                        resultado = "FNT"
                    ElseIf observacion = "DESCANSO" Then
                        resultado = "D"
                        horasTrabajadasDict(dni)(dia) = horasTrabajadas
                    ElseIf observacion = "VACACIONES" Then
                        resultado = "V"
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
            End If

            If Not horariosTrabajadores.ContainsKey(dni) Then
                horariosTrabajadores(dni) = New List(Of (String, String, String, String, String, String, Integer, String, String, String))()
            End If

            Dim listaHorarios = horariosTrabajadores(dni)
            If tipo = "EVENTUAL" Then

                If tipoPeriodo.StartsWith("SEMANA") Then

                    ' Para EVENTUAL, manejamos solo 7 elementos
                    If listaHorarios.Count = 0 Then
                        ' Inicializamos los 7 días de la semana
                        For i As Integer = 1 To 7
                            listaHorarios.Add(("", "", "", "0", "0.0", "0", 0, "", "", "0"))
                        Next
                    End If

                    ' Calculamos el índice correcto dentro de la semana
                    Dim partes As String() = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)
                    Dim fechaInicio As Date = Date.ParseExact(partes(0).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)
                    ' Ajustar el mes para la fecha actual si es necesario
                    Dim mesActual As Integer = mesSeleccionado
                    If dia < fechaInicio.Day Then
                        mesActual = mesSeleccionado + 1
                    End If

                    ' Crear las fechas asegurándose de usar el año correcto
                    Dim fechaInicioCompleta As New Date(anioActual, fechaInicio.Month, fechaInicio.Day)
                    Dim fechaActualCompleta As New Date(anioActual, mesActual, dia)

                    ' Calcular el índice
                    Dim indice As Integer = (fechaActualCompleta - fechaInicioCompleta).Days

                    ' Solo actualizamos si el índice está dentro del rango de la semana
                    If indice >= 0 AndAlso indice < 7 Then
                        listaHorarios(indice) = (horaEntrada, horaSalida, observacion, horasExtras, pagoEspecial, horasTrabajadas, horasRefrigerio, permisoMedico, feriadoTrabajado, horasExtrasMarranas)
                    End If
                Else
                    ' Para no EVENTUAL, mantenemos el comportamiento original
                    While listaHorarios.Count < dia
                        listaHorarios.Add(("", "", "", "0", "0.0", "0", 0, "", "", "0"))
                    End While
                    listaHorarios(dia - 1) = (horaEntrada, horaSalida, observacion, horasExtras, pagoEspecial, horasTrabajadas, horasRefrigerio, permisoMedico, feriadoTrabajado, horasExtrasMarranas)
                End If
            Else
                ' Para no EVENTUAL, mantenemos el comportamiento original
                While listaHorarios.Count < dia
                    listaHorarios.Add(("", "", "", "0", "0.0", "0", 0, "", "", "0"))
                End While
                listaHorarios(dia - 1) = (horaEntrada, horaSalida, observacion, horasExtras, pagoEspecial, horasTrabajadas, horasRefrigerio, permisoMedico, feriadoTrabajado, horasExtrasMarranas)
            End If

            datosBaseDatos(dni)(dia) = resultado
            horasExtrasDict(dni)(dia) = horasExtras + horasExtrasMarranas
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

            If tipo = "EVENTUAL" Then

                If tipoPeriodo.StartsWith("SEMANA") Then
                    ' Para EVENTUAL, procesar solo los días de la semana seleccionada
                    Dim partes As String() = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)
                    Dim fechaInicio As Date = Date.ParseExact(partes(0).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)
                    Dim fechaFin As Date = Date.ParseExact(partes(1).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)

                    Dim fechaActual As DateTime = fechaInicio
                    While fechaActual <= fechaFin
                        If (fechaActual >= fechaInicio AndAlso fechaActual <= fechaFin) Then
                            Dim nombreColumna As String = $"Dia{fechaActual:dd-MM}"
                            Dim dia As Integer = fechaActual.Day

                            ' Determinar si estamos en el mes siguiente
                            Dim esMesSiguiente As Boolean = fechaActual.Month > mesSeleccionado

                            ' si estamos en el día específico del mes siguiente
                            If (esMesSiguiente AndAlso dia > ultimoDiaRegistro) OrElse
                            (Not esMesSiguiente AndAlso dia > DateTime.DaysInMonth(anioActual, mesSeleccionado)) Then
                                newRow(nombreColumna) = "-"
                            ElseIf datosBaseDatos(dni).ContainsKey(dia) Then
                                Dim resultadoDia As String = datosBaseDatos(dni)(dia)
                                newRow(nombreColumna) = resultadoDia

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
                                            Dim horasExtras As Double = horasExtrasDict(dni)(dia)
                                            If horasExtras > 0 Then
                                                totalHorasNormales += horasTrabajadas
                                            End If
                                            totalHorasExtras += horasExtrasDict(dni)(dia)
                                        End If
                                    Case "D"
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
                                newRow(nombreColumna) = "F" 'F
                            End If
                        End If
                        fechaActual = fechaActual.AddDays(1)
                    End While
                Else
                    For dia As Integer = 1 To diasEnElMes
                        Dim nombreColumna As String = $"Dia{dia}"

                        If dia > ultimoDiaRegistro Then
                            newRow(nombreColumna) = "-"
                            Continue For
                        End If

                        If datosBaseDatos(dni).ContainsKey(dia) Then
                            Dim resultadoDia As String = datosBaseDatos(dni)(dia)
                            newRow(nombreColumna) = resultadoDia

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
                            newRow(nombreColumna) = "F"
                        End If
                    Next
                End If
            Else
                ' Para PLANILLA, procesar todos los días del mes
                For dia As Integer = 1 To diasEnElMes
                    Dim nombreColumna As String = $"Dia{dia}"

                    If dia > ultimoDiaRegistro Then
                        newRow(nombreColumna) = "-"
                        Continue For
                    End If

                    If datosBaseDatos(dni).ContainsKey(dia) Then
                        Dim resultadoDia As String = datosBaseDatos(dni)(dia)
                        newRow(nombreColumna) = resultadoDia

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
                        newRow(nombreColumna) = "F"
                    End If
                Next
            End If

            totalHorasTrabajadas = totalHorasNormales + totalHorasExtras
            newRow("H.T") = totalHorasTrabajadas
            newRow("H.TR") = totalHorasNormales
            newRow("H.EX") = totalHorasExtras

            dtMostrar.Rows.Add(newRow)
            codigoSecuencial += 1
        Next

        Return dtMostrar
    End Function

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If e.Cell.Column.Key.StartsWith("Dia") Then

            If e.Cell.Row.Cells("ID").Value Is Nothing Then
                msj_advert("Selecciona un registro.")
                Exit Sub
            End If

            If e.Cell.Value.ToString() = "V" Then
                msj_advert("No puedes editar este día, ya que se le han aplicado vacaciones.")
                Exit Sub
            End If

            Dim idTrabajador As String = e.Cell.Row.Cells("ID").Value.ToString()
            ' Corregimos la extracción del día seleccionado
            Dim diaKey As String = e.Cell.Column.Key.Replace("Dia", "")
            Dim diaSeleccionado As Integer

            ' Si el formato es dd-MM
            If diaKey.Contains("-") Then
                diaSeleccionado = Integer.Parse(diaKey.Split("-"c)(0))
            Else
                ' Si el formato es solo el número del día
                diaSeleccionado = Integer.Parse(diaKey)
            End If

            Dim fechaStr As String
            Dim fechaSeleccionada As DateTime
            Dim primerDiaMes As DateTime
            Dim primerDomingo As DateTime

            Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
            Dim anioActual As Integer = cbxListaAños.Value
            Dim diasEnElMes As Integer = DateTime.DaysInMonth(anioActual, mesSeleccionado)
            Dim rangoInicio As Integer = 1
            Dim rangoFin As Integer = diasEnElMes

            If tipo = "EVENTUAL" Then
                If tipoPeriodo.StartsWith("SEMANA") Then
                    fechaStr = e.Cell.Column.Key.Replace("Dia", "")
                    fechaSeleccionada = DateTime.ParseExact(fechaStr, "dd-MM", CultureInfo.InvariantCulture)

                    primerDiaMes = New DateTime(CInt(anio), mes, 1)
                    primerDomingo = primerDiaMes
                    While primerDomingo.DayOfWeek <> DayOfWeek.Sunday
                        primerDomingo = primerDomingo.AddDays(1)
                    End While
                End If
            End If

            If tipo = "PLANILLA" Then
                If tipoPeriodo = "QUINCENA 1" Then
                    rangoInicio = 1
                    rangoFin = 15
                ElseIf tipoPeriodo = "QUINCENA 2" Then
                    rangoInicio = 16
                    rangoFin = diasEnElMes
                End If

                ' Validar que el día seleccionado esté en el rango permitido
                If diaSeleccionado < rangoInicio Or diaSeleccionado > rangoFin Then
                    msj_advert("No puedes editar este día, ya que no pertenece a la quincena seleccionada.")
                    Exit Sub
                End If
            End If


            If tipo = "EVENTUAL" Then
                If tipoPeriodo.StartsWith("SEMANA") Then
                    ' Extraer las fechas del tipoPeriodo
                    Dim partes As String() = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)
                    Dim fechaInicio As Date = Date.ParseExact(partes(0).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)
                    Dim fechaFin As Date = Date.ParseExact(partes(1).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)

                    ' Ajustar el mes seleccionado si el día está en el mes siguiente
                    If diaSeleccionado < fechaInicio.Day Then
                        mesSeleccionado = fechaFin.Month
                    Else
                        mesSeleccionado = fechaInicio.Month
                    End If

                    rangoInicio = fechaInicio.Day

                    If fechaInicio.Month = fechaFin.Month Then
                        Dim diasDeLaSemana As Integer = (fechaFin - fechaInicio).Days + 1
                        Dim diasRestantes As Integer = diasEnElMes - fechaFin.Day

                        If diasRestantes < diasDeLaSemana Then
                            If estado = "PENDIENTE" OrElse estado = "INCOMPLETO" OrElse estado = "OBSERVADO" OrElse estado = "APROBADO" Or estado = "ENVIADO" Then
                                rangoFin = fechaFin.Day
                            Else
                                rangoFin = diasEnElMes
                            End If
                        Else
                            rangoFin = fechaFin.Day
                        End If
                    Else
                        If mesSeleccionado = fechaInicio.Month Then
                            rangoFin = Math.Min(ultimoDiaRegistro, diasEnElMes)
                        ElseIf mesSeleccionado = fechaFin.Month Then
                            rangoInicio = 1
                            rangoFin = fechaFin.Day
                        Else
                            rangoInicio = 0
                            rangoFin = 0
                        End If
                    End If
                Else
                    If tipoPeriodo = "QUINCENA 1" Then
                        rangoInicio = 1
                        rangoFin = 15
                    ElseIf tipoPeriodo = "QUINCENA 2" Then
                        rangoInicio = 16
                        rangoFin = diasEnElMes
                    End If

                    ' Validar que el día seleccionado esté en el rango permitido
                    If diaSeleccionado < rangoInicio Or diaSeleccionado > rangoFin Then
                        msj_advert("No puedes editar este día, ya que no pertenece a la quincena seleccionada.")
                        Exit Sub
                    End If
                End If
            End If

            If horariosTrabajadores.ContainsKey(idTrabajador) Then
                Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = horariosTrabajadores(idTrabajador)

                ' Calcular el índice basado en la semana
                Dim indice As Integer = diaSeleccionado - 1  ' valor por defecto

                If tipo = "EVENTUAL" AndAlso tipoPeriodo.StartsWith("SEMANA") Then
                    ' Extraer las fechas del tipoPeriodo
                    Dim partes As String() = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)
                    Dim fechaInicio As Date = Date.ParseExact(partes(0).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)
                    Dim fechaFin As Date = Date.ParseExact(partes(1).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)

                    If fechaInicio.Month = fechaFin.Month Then
                        ' Si es el mismo mes, calculamos normalmente
                        indice = diaSeleccionado - fechaInicio.Day
                    Else
                        ' Si hay cruce de mes
                        If mesSeleccionado = fechaInicio.Month Then
                            ' Si estamos en el mes inicial
                            indice = diaSeleccionado - fechaInicio.Day
                        ElseIf mesSeleccionado = fechaFin.Month Then
                            ' Si estamos en el mes final
                            ' Los días del mes siguiente empiezan desde 0
                            Dim diasMesAnterior As Integer = diasEnElMes - fechaInicio.Day + 1
                            indice = diasMesAnterior + diaSeleccionado - 1
                        End If
                    End If
                End If

                Dim horario As (String, String, String, String, String, String, Integer, String, String, String) = listaHorarios(indice)

                Dim entrada As String = horario.Item1
                Dim salida As String = horario.Item2
                Dim observacion As String = horario.Item3
                Dim horasExtras As String = horario.Item4.ToString()
                Dim pagoEspecial As String = horario.Item5.ToString()
                Dim horasLaboradas As String = horario.Item6.ToString()
                Dim horasRefrigerio As Integer = horario.Item7
                Dim permisoMedico As String = horario.Item8
                Dim feriadoTrabajado As String = horario.Item9
                Dim horasExtrasMarranas As String = horario.Item10

                Dim valorAnterior As String = e.Cell.Value.ToString()

                If Not String.IsNullOrWhiteSpace(entrada) AndAlso Not String.IsNullOrWhiteSpace(salida) Then
                    Dim horaEntrada As DateTime = DateTime.Parse(entrada)
                    Dim horaSalida As DateTime = DateTime.Parse(salida)
                    Dim diferencia As TimeSpan = horaSalida - horaEntrada
                    Dim horasTotales As Integer = Math.Max(0, Math.Floor(diferencia.TotalHours) - horasRefrigerio)

                    Dim horasNormales As Integer = Math.Min(horasTotales, 8)
                    Dim horasExtrasCalculadas As Integer = If(horasTotales > 8, horasTotales - 8, 0)

                    If horasExtras = "0" Then
                        horasExtras = horasExtrasCalculadas.ToString()
                    End If

                    horasLaboradas = horasNormales.ToString()
                Else
                    horasLaboradas = "0"
                End If

                Dim frmEditarHorarios As New frmEditarHorarios(entrada, salida, observacion, horasExtras, pagoEspecial, horasLaboradas, horasRefrigerio.ToString(), permisoMedico, feriadoTrabajado, horasExtrasMarranas)

                If frmEditarHorarios.cbxPermisoMedico.Text = "" Then
                    frmEditarHorarios.cbxPermisoMedico.SelectedItem = "NO"
                End If

                If frmEditarHorarios.cbxFeriado.Text = "" Then
                    frmEditarHorarios.cbxFeriado.SelectedItem = "SIN ASIGNAR"
                End If

                If frmEditarHorarios.ShowDialog() = DialogResult.OK Then
                    entrada = frmEditarHorarios.Entrada.Trim()
                    salida = frmEditarHorarios.Salida.Trim()
                    observacion = frmEditarHorarios.Observacion.Trim()
                    horasExtras = frmEditarHorarios.HorasExtras.Trim()
                    pagoEspecial = frmEditarHorarios.PagoEspecial.Trim()
                    horasLaboradas = frmEditarHorarios.HorasLaboradas.Trim()
                    horasRefrigerio = Integer.Parse(frmEditarHorarios.HorasRefrigerio.Trim())
                    permisoMedico = frmEditarHorarios.PermisoMedico.Trim()
                    feriadoTrabajado = frmEditarHorarios.Feriado.Trim()
                    horasExtrasMarranas = frmEditarHorarios.HorasExtrasMarranas.Trim()

                    listaHorarios(indice) = (entrada, salida, observacion, Double.Parse(horasExtras), Double.Parse(pagoEspecial), Integer.Parse(horasLaboradas), horasRefrigerio, permisoMedico, feriadoTrabajado, horasExtrasMarranas)

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

                    If frmEditarHorarios.Observacion.Trim() = "DESCANSO" Then
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

                    Dim horasTotales As Double = 0
                    Dim horasNormales As Integer = 0
                    Dim horasAdicionales As Double = 0

                    If tipo = "PLANILLA" Then
                        For Each horarioDia In listaHorarios
                            If Not String.IsNullOrWhiteSpace(horarioDia.Item1) AndAlso Not String.IsNullOrWhiteSpace(horarioDia.Item2) Then
                                If horarioDia.Equals(listaHorarios(indice)) Then
                                    ' Para el día actual, usar los valores del formulario
                                    horasTotales += Integer.Parse(horasLaboradas) + Double.Parse(horasExtras) + Double.Parse(horasExtrasMarranas)
                                    horasNormales += Integer.Parse(horasLaboradas)
                                    horasAdicionales += Double.Parse(horasExtras) + Double.Parse(horasExtrasMarranas)
                                Else
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
                            End If
                        Next
                    ElseIf tipo = "EVENTUAL" Then

                        If tipoPeriodo.StartsWith("SEMANA") Then
                            For Each horarioDia In listaHorarios
                                If Not String.IsNullOrWhiteSpace(horarioDia.Item1) AndAlso Not String.IsNullOrWhiteSpace(horarioDia.Item2) Then

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
                        Else
                            For Each horarioDia In listaHorarios
                                If Not String.IsNullOrWhiteSpace(horarioDia.Item1) AndAlso Not String.IsNullOrWhiteSpace(horarioDia.Item2) Then
                                    If horarioDia.Equals(listaHorarios(indice)) Then
                                        ' Para el día actual, usar los valores del formulario
                                        horasTotales += Integer.Parse(horasLaboradas) + Double.Parse(horasExtras) + Double.Parse(horasExtrasMarranas)
                                        horasNormales += Integer.Parse(horasLaboradas)
                                        horasAdicionales += Double.Parse(horasExtras) + Double.Parse(horasExtrasMarranas)
                                    Else
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
                                End If
                            Next
                        End If
                    End If

                    e.Cell.Row.Cells("H.T").Value = horasTotales
                    e.Cell.Row.Cells("H.TR").Value = horasNormales
                    e.Cell.Row.Cells("H.EX").Value = horasAdicionales

                    If tipo = "PLANILLA" Then
                        If tipoPeriodo = "MENSUAL" Then
                            For i As Integer = 0 To listaHorarios.Count - 1
                                Dim dia As (String, String, String, String, String, String, Integer, String, String, String) = listaHorarios(i)
                                Dim valor As String = dtgListado.Rows(e.Cell.Row.Index).Cells(i + 3).Value.ToString()
                                If valor <> "-" Then
                                    ultimoDiaRegistroEventual = i + 1 ' Usar el índice para actualizar el último día
                                    Console.WriteLine($"Mensual. Nuevo ultimodiagreg: {ultimoDiaRegistroEventual}")
                                End If
                            Next
                        End If

                        If tipoPeriodo = "QUINCENA 1" Or tipoPeriodo = "QUINCENA 2" Then
                            For i As Integer = 0 To listaHorarios.Count - 1
                                Dim dia As (String, String, String, String, String, String, Integer, String, String, String) = listaHorarios(i)
                                Dim valor As String = dtgListado.Rows(e.Cell.Row.Index).Cells(i + 3).Value.ToString()
                                If valor <> "-" Then
                                    ultimoDiaRegistroEventual = i + 1 ' Usar el índice para actualizar el último día
                                    Console.WriteLine($"Cruce de quincena detectado. Nuevo ultimodiagreg: {ultimoDiaRegistroEventual}")
                                End If
                            Next
                        End If
                    End If

                    If tipo = "EVENTUAL" Then

                        If tipoPeriodo.StartsWith("SEMANA") Then
                            ' Extraer las fechas del tipoPeriodo
                            Dim partes As String() = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)
                            Dim fechaInicio As Date = Date.ParseExact(partes(0).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)

                            For i As Integer = 0 To 6
                                ' Usar fechaInicio en lugar de primerDomingo
                                Dim fechaActual As DateTime = fechaInicio.AddDays(i)
                                Dim mesActual As Integer = mes

                                ' Si la fecha actual está en un mes diferente al seleccionado
                                If fechaActual.Month <> mesActual Then
                                    ' Si hay un valor no "-" en esta fecha del siguiente mes
                                    Dim columnKey As String = $"Dia{fechaActual:dd-MM}"
                                    If dtgListado.DisplayLayout.Bands(0).Columns.Exists(columnKey) Then
                                        Dim valor As String = dtgListado.Rows(e.Cell.Row.Index).Cells(columnKey).Value.ToString()
                                        If valor <> "-" Then
                                            ultimoDiaRegistroEventual = fechaActual.Day
                                            Console.WriteLine($"Cruce de mes detectado. Nuevo ultimodiagreg: {ultimoDiaRegistroEventual}")
                                        End If
                                    End If
                                Else
                                    ' Comportamiento normal para el mes actual
                                    Dim columnKey As String = $"Dia{fechaActual:dd-MM}"
                                    If dtgListado.DisplayLayout.Bands(0).Columns.Exists(columnKey) Then
                                        Dim valor As String = dtgListado.Rows(e.Cell.Row.Index).Cells(columnKey).Value.ToString()
                                        If valor <> "-" Then
                                            ultimoDiaRegistroEventual = fechaActual.Day
                                            Console.WriteLine("ultimodiagreg: " + ultimoDiaRegistroEventual.ToString())
                                        End If
                                    End If
                                End If
                            Next
                        Else
                            If tipoPeriodo = "QUINCENA 1" Or tipoPeriodo = "QUINCENA 2" Then
                                For i As Integer = 0 To listaHorarios.Count - 1
                                    Dim dia As (String, String, String, String, String, String, Integer, String, String, String) = listaHorarios(i)
                                    Dim valor As String = dtgListado.Rows(e.Cell.Row.Index).Cells(i + 3).Value.ToString()
                                    If valor <> "-" Then
                                        ultimoDiaRegistroEventual = i + 1 ' Usar el índice para actualizar el último día
                                        Console.WriteLine($"Cruce de quincena detectado. Nuevo ultimodiagreg: {ultimoDiaRegistroEventual}")
                                    End If
                                Next
                            End If
                        End If

                    End If
                End If
            End If
        End If
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Function ConvertirListaHorariosAString(dni As String, listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)), diasEnElMes As Integer) As String
        Dim listaHorariosString As New StringBuilder()

        If tipo = "PLANILLA" Then
            ' Existing logic for payroll workers
            For diaRecorre As Integer = 1 To listaHorarios.Count
                Dim horario = listaHorarios(diaRecorre - 1)
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
                Dim formato As String = $"{dni}+{diaRecorre}+{entrada}+{salida}+{observacion}+{horasExtras}+{pagoEspecial}+{horasTrabajadasTotal}+{permisoMedico}+{horasRefrigerio}+{feriadoTrabajado}+{horasExtrasMarranas}"
                listaHorariosString.Append(formato)
                If diaRecorre < diasEnElMes Then
                    listaHorariosString.Append(",")
                End If
            Next
        ElseIf tipo = "EVENTUAL" Then

            If tipoPeriodo.StartsWith("SEMANA") Then
                ' New logic for eventual workers with period parsing
                Dim periodoMatch = System.Text.RegularExpressions.Regex.Match(tipoPeriodo, "SEMANA (\d{2}/\d{2}) - (\d{2}/\d{2})")

                If periodoMatch.Success Then
                    Dim fechaInicio As DateTime = DateTime.ParseExact(periodoMatch.Groups(1).Value, "dd/MM", Nothing)
                    Dim fechaFin As DateTime = DateTime.ParseExact(periodoMatch.Groups(2).Value, "dd/MM", Nothing)

                    For diaRecorre As Integer = 0 To listaHorarios.Count - 1
                        Dim fechaActual As DateTime = fechaInicio.AddDays(diaRecorre)

                        If fechaActual >= fechaInicio AndAlso fechaActual <= fechaFin Then
                            Dim horario = listaHorarios(diaRecorre)
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
                            Dim formato As String = $"{dni}+{fechaActual.Day}+{entrada}+{salida}+{observacion}+{horasExtras}+{pagoEspecial}+{horasTrabajadasTotal}+{permisoMedico}+{horasRefrigerio}+{feriadoTrabajado}+{horasExtrasMarranas}"

                            listaHorariosString.Append(formato)
                            If diaRecorre < listaHorarios.Count - 1 Then
                                listaHorariosString.Append(",")
                            End If
                        End If
                    Next
                End If
            Else
                ' Existing logic for payroll workers
                For diaRecorre As Integer = 1 To listaHorarios.Count
                    Dim horario = listaHorarios(diaRecorre - 1)
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
                    Dim formato As String = $"{dni}+{diaRecorre}+{entrada}+{salida}+{observacion}+{horasExtras}+{pagoEspecial}+{horasTrabajadasTotal}+{permisoMedico}+{horasRefrigerio}+{feriadoTrabajado}+{horasExtrasMarranas}"
                    listaHorariosString.Append(formato)
                    If diaRecorre < diasEnElMes Then
                        listaHorariosString.Append(",")
                    End If
                Next
            End If
        End If

        Return listaHorariosString.ToString()
    End Function

    Public Sub LlenarTablaAsistencia(dni As String, datos As String, tipoTrabajador As String)
        totalAsistenciaCompleta = Nothing
        totalInasistencias = Nothing
        totalConHorasExtras = Nothing
        totalConPermisoMedico = Nothing
        totalIncompletas = Nothing
        totalConDescanso = Nothing
        totalConFeriadoNoTrabajado = Nothing
        totalConFeriadoTrabajado = Nothing

        For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If fila.Cells("ID").Value.ToString() = dni Then
                msj_advert($"La persona {datos} con el DNI {dni} ya existe en la tabla. No se puede agregar la misma persona más de una vez.")
                Exit Sub
            End If
        Next

        If tipo = "PLANILLA" Then
            If tipoTrabajador = "EVENTUAL" Then
                msj_advert("No se puede agregar un trabajador de tipo EVENTUAL.")
                Exit Sub
            End If
        ElseIf tipo = "EVENTUAL" Then
            If tipoTrabajador = "PLANILLA" Then
                msj_advert("No se puede agregar un trabajador de tipo PLANILLA.")
                Exit Sub
            End If
        End If

        Dim dr As DataRow
        Dim horasTotales As Integer = 0
        Dim horasNormales As Integer = 0
        Dim horasAdicionales As Integer = 0
        Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
        Dim anioActual As Integer = anio
        Dim diasEnElMes As Integer = DateTime.DaysInMonth(anioActual, mesSeleccionado)

        Dim rangoInicio As Integer
        Dim rangoFin As Integer
        Dim obj As New coControlAsistencia
        obj.IdUbicacion = _idPlantel
        obj.Mes = mes
        obj.Anio = anio
        obj.Tipo = tipo

        Dim mensaje As String = cn.Cn_ObtenerUltimoDiaRegistroAsistencia(obj)
        ultimoDiaRegistro = obj.UltimoDiaReg

        If tipo = "PLANILLA" Then
            ' Definir rango según tipoPeriodo
            Select Case tipoPeriodo.ToUpper()
                Case "QUINCENA 1"
                    rangoInicio = 1
                    rangoFin = Math.Min(15, ultimoDiaRegistro)
                Case "QUINCENA 2"
                    rangoInicio = 16
                    rangoFin = Math.Min(diasEnElMes, ultimoDiaRegistro)
                Case "MENSUAL"
                    rangoInicio = 1
                    rangoFin = Math.Min(diasEnElMes, ultimoDiaRegistro)
            End Select
        End If

        dr = dtMostrar.NewRow
        dr("ID") = dni
        dr("Nombre") = datos

        Dim listaHorarios As New List(Of (String, String, String, String, String, String, Integer, String, String, String))()

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
            Dim feriado As String = "SIN ASIGNAR"
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

            listaHorarios.Add((entrada, salida, observacion, horasExtras, pagoEspecial, horasTrabajadasTotal, horasRefrigerio, permisoMedico, feriado, horasExtrasMarranas))
        Next

        dr("H.T") = horasTotales
        dr("H.TR") = horasNormales
        dr("H.EX") = horasAdicionales

        dtMostrar.Rows.Add(dr)

        If Not horariosTrabajadores.ContainsKey(dni) Then
            horariosTrabajadores.Add(dni, listaHorarios)
        End If

        Dim ultimaFilaIndex As Integer = dtMostrar.Rows.Count - 1
        dtMostrar.Rows(ultimaFilaIndex)("Codigo") = ultimaFilaIndex + 1

        Dim cell As Infragistics.Win.UltraWinGrid.UltraGridCell = dtgListado.Rows(ultimaFilaIndex).Cells("Codigo")
        cell.Appearance.BackColor = Color.FromArgb(205, 255, 0)

        Colorear()
        ProcesarAsistencias()
    End Sub

    Public Sub LlenarTablaAsistenciaEventualQuincena(dni As String, datos As String, tipoTrabajador As String)
        totalAsistenciaCompleta = Nothing
        totalInasistencias = Nothing
        totalConHorasExtras = Nothing
        totalConPermisoMedico = Nothing
        totalIncompletas = Nothing
        totalConDescanso = Nothing

        For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If fila.Cells("ID").Value.ToString() = dni Then
                msj_advert($"La persona {datos} con el DNI {dni} ya existe en la tabla. No se puede agregar la misma persona más de una vez.")
                Exit Sub
            End If
        Next

        If tipo = "PLANILLA" Then
            If tipoTrabajador = "EVENTUAL" Then
                msj_advert("No se puede agregar un trabajador de tipo EVENTUAL.")
                Exit Sub
            End If
        ElseIf tipo = "EVENTUAL" Then
            If tipoTrabajador = "PLANILLA" Then
                msj_advert("No se puede agregar un trabajador de tipo PLANILLA.")
                Exit Sub
            End If
        End If

        Dim dr As DataRow
        Dim horasTotales As Integer = 0
        Dim horasNormales As Integer = 0
        Dim horasAdicionales As Integer = 0
        Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
        Dim anioActual As Integer = anio
        Dim diasEnElMes As Integer = DateTime.DaysInMonth(anioActual, mesSeleccionado)

        Dim rangoInicio As Integer
        Dim rangoFin As Integer
        Dim obj As New coControlAsistencia
        obj.IdUbicacion = _idPlantel
        obj.Mes = mes
        obj.Anio = anio
        obj.Tipo = tipo
        obj.idHorario = idHorario

        Dim mensaje As String = cn.Cn_ObtenerUltimoDiaRegistroAsistencia(obj)
        ultimoDiaRegistro = obj.UltimoDiaReg

        If tipo = "EVENTUAL" Then
            ' Definir rango según tipoPeriodo
            Select Case tipoPeriodo.ToUpper()
                Case "QUINCENA 1"
                    rangoInicio = 1
                    rangoFin = Math.Min(15, ultimoDiaRegistro)
                Case "QUINCENA 2"
                    rangoInicio = 16
                    rangoFin = Math.Min(diasEnElMes, ultimoDiaRegistro)
            End Select
        End If

        dr = dtMostrar.NewRow
        dr("ID") = dni
        dr("Nombre") = datos

        Dim listaHorarios As New List(Of (String, String, String, String, String, String, Integer, String, String, String))()

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
            Dim feriado As String = "SIN ASIGNAR"
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

            listaHorarios.Add((entrada, salida, observacion, horasExtras, pagoEspecial, horasTrabajadasTotal, horasRefrigerio, permisoMedico, feriado, horasExtrasMarranas))
        Next

        dr("H.T") = horasTotales
        dr("H.TR") = horasNormales
        dr("H.EX") = horasAdicionales

        dtMostrar.Rows.Add(dr)

        If Not horariosTrabajadores.ContainsKey(dni) Then
            horariosTrabajadores.Add(dni, listaHorarios)
        End If

        Dim ultimaFilaIndex As Integer = dtMostrar.Rows.Count - 1
        dtMostrar.Rows(ultimaFilaIndex)("Codigo") = ultimaFilaIndex + 1

        Dim cell As Infragistics.Win.UltraWinGrid.UltraGridCell = dtgListado.Rows(ultimaFilaIndex).Cells("Codigo")
        cell.Appearance.BackColor = Color.FromArgb(205, 255, 0)

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

        ' Verificar si el DNI ya existe en la tabla
        For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If fila.Cells("ID").Value.ToString() = dni Then
                msj_advert($"La persona {datos} con el DNI {dni} ya existe en la tabla. No se puede agregar la misma persona más de una vez.")
                Exit Sub
            End If
        Next

        Dim obj As New coControlAsistencia
        obj.IdUbicacion = _idPlantel
        obj.Mes = mes
        obj.Anio = anio
        obj.Tipo = tipo

        Dim mensaje As String = cn.Cn_ObtenerUltimoDiaRegistroAsistencia(obj)
        Dim ultimoDiaRegistro As Integer = obj.UltimoDiaReg

        ' Obtener fechas del periodo
        Dim fechas() As String = tipoPeriodo.Replace("SEMANA ", "").Split(" - ")
        Dim fechaInicioPeriodo As DateTime = DateTime.ParseExact(fechas(0), "dd/MM", Nothing)
        Dim fechaFinPeriodo As DateTime = DateTime.ParseExact(fechas(2), "dd/MM", Nothing)

        ' Ajustar el año actual (para evitar problemas con fechas de distintos años)
        Dim anioActual As Integer = anio
        fechaInicioPeriodo = New DateTime(anioActual, fechaInicioPeriodo.Month, fechaInicioPeriodo.Day)
        fechaFinPeriodo = New DateTime(anioActual, fechaFinPeriodo.Month, fechaFinPeriodo.Day)

        ' Convertir ultimoDiaRegistro en un DateTime para poder compararlo
        Dim fechaUltimoDiaRegistro As DateTime = New DateTime(anioActual, mes, ultimoDiaRegistro)

        Dim dr As DataRow = dtMostrar.NewRow
        dr("ID") = dni
        dr("Nombre") = datos

        Dim listaHorarios As New List(Of (String, String, String, String, String, String, Integer, String, String, String))()
        Dim horasTotales As Integer = 0
        Dim horasNormales As Integer = 0
        Dim horasAdicionales As Integer = 0

        ' Procesar días por semanas dentro del rango permitido
        Dim fechaActual As DateTime = fechaInicioPeriodo
        While fechaActual <= fechaFinPeriodo
            Dim nombreColumna As String = $"Dia{fechaActual:dd-MM}"

            Dim entrada As String = ""
            Dim salida As String = ""
            Dim observacion As String = "Sin observación"
            Dim horasExtras As String = "0"
            Dim pagoEspecial As String = "0"
            Dim horasTrabajadasTotal As String = "0"
            Dim horasRefrigerio As Integer = 1
            Dim permisoMedico As String = "NO"
            Dim feriado As String = "SIN ASIGNAR"
            Dim horasExtrasMarranas As String = "0"

            ' Determinar si se llena con "F" o "-"
            Dim resultado As String
            If fechaActual <= fechaUltimoDiaRegistro Then
                resultado = "F"
            Else
                resultado = "-"
            End If

            dr(nombreColumna) = resultado

            listaHorarios.Add((entrada, salida, observacion, horasExtras,
                            pagoEspecial, horasTrabajadasTotal,
                            horasRefrigerio, permisoMedico, feriado, horasExtrasMarranas))

            fechaActual = fechaActual.AddDays(1)
        End While

        dr("H.T") = horasTotales
        dr("H.TR") = horasNormales
        dr("H.EX") = horasAdicionales

        dtMostrar.Rows.Add(dr)

        ' Manejar los horarios de trabajadores eventuales
        If Not horariosTrabajadores.ContainsKey(dni) Then
            horariosTrabajadores.Add(dni, listaHorarios)
        End If

        ' Asignar código y colorear la última fila
        Dim ultimaFilaIndex As Integer = dtMostrar.Rows.Count - 1
        dtMostrar.Rows(ultimaFilaIndex)("Codigo") = ultimaFilaIndex + 1

        Dim cell As Infragistics.Win.UltraWinGrid.UltraGridCell = dtgListado.Rows(ultimaFilaIndex).Cells("Codigo")
        cell.Appearance.BackColor = Color.FromArgb(205, 255, 0)

        Colorear()
        ProcesarAsistencias()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If dtgListado.Rows.Count = 0 Then
                msj_advert("No hay datos para guardar.")
                Return
            End If

            If VerificacionHorario() Then
                msj_advert("No se puede guardar. Hay datos incompletos por rellenar.")
                Return
            End If

            If ultimoDiaRegistroEventual = 0 Then
                msj_advert("No se puede guardar porque no se han realizado modificaciones.")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE EDITAR LA ASISTENCIA DE LOS TRABAJADORES?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim errorEncontrado As Boolean = False
            Dim mensajeError As String = ""
            Dim MensajeBgWk As String = ""

            For Each fila As UltraGridRow In dtgListado.Rows
                Dim dni As String = fila.Cells("ID").Value.ToString()
                If horariosTrabajadores.ContainsKey(dni) Then
                    Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = horariosTrabajadores(dni)

                    Dim mesSeleccionado As Integer = cbListaMeses.SelectedIndex + 1
                    Dim diasEnElMes As Integer = DateTime.DaysInMonth(anio, mesSeleccionado)

                    Dim obj As New coControlAsistencia()
                    obj.Lista_Asistencias = ConvertirListaHorariosAString(dni, listaHorarios, diasEnElMes)
                    obj.idHorario = idHorario
                    obj.UltimoDiaRegEventual = ultimoDiaRegistroEventual

                    MensajeBgWk = cn.Cn_ActualizarAsistencia(obj)
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
                msj_ok(MensajeBgWk)
            End If
        Catch ex As Exception
            msj_advert("Error al guardar los datos: " & ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If dtgListado.Rows.Count > 0 Then
            Dim f As New FrmBuscarTrabajador_Asis(Me)
            f.tipoTrabajador = tipo
            f.quincenaEventual = If(tipoPeriodo.StartsWith("QUINCENA"), 1, 0)
            f.ShowDialog()
        Else
            msj_advert("Primero carga la tabla antes de agregar un nuevo trabajador")
        End If
    End Sub

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

            If tipo = "PLANILLA" Then
                Dim rangoInicio As Integer
                Dim rangoFin As Integer
                Dim diasEnElMes As Integer = DateTime.DaysInMonth(anio, mes)
                Dim obj As New coControlAsistencia
                obj.IdUbicacion = _idPlantel
                obj.Mes = mes
                obj.Anio = anio
                obj.Tipo = tipo

                Dim mensaje As String = cn.Cn_ObtenerUltimoDiaRegistroAsistencia(obj)
                ultimoDiaRegistro = obj.UltimoDiaReg
                If tipo = "PLANILLA" Then
                    If tipoPeriodo = "MENSUAL" Then
                        rangoInicio = 1
                        rangoFin = ultimoDiaRegistro
                    ElseIf ultimoDiaRegistro > 0 And ultimoDiaRegistro < 16 Then
                        rangoInicio = 1
                        rangoFin = ultimoDiaRegistro
                    Else
                        rangoInicio = 16
                        rangoFin = ultimoDiaRegistro
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

                                    Dim sumaHorasCheck As Double = CDbl(horasTrabajadas) + CDbl(horasExtras) + CDbl(horasExtrasMarranas)
                                    Dim horasTrabajadasCheck As Integer = Integer.Parse(horasTrabajadas)
                                    Dim horasExtrasCheck As Double = Double.Parse(horasExtras)
                                    Dim horasExtrasMarranasCheck As Double = Double.Parse(horasExtrasMarranas)

                                    If cbMostrarCantidadHoras.Checked Then

                                        If celda.Value.ToString() = "HEX" Then
                                            celda.Value = $"{sumaHorasCheck}"
                                        ElseIf celda.Value.ToString() = "A" Then
                                            celda.Value = $"{sumaHorasCheck}"
                                        ElseIf celda.Value.ToString() = "IN" Then
                                            celda.Value = "IN"
                                        ElseIf celda.Value.ToString() = "F" Then
                                            celda.Value = "F"
                                        ElseIf celda.Value.ToString() = "D" Then
                                            celda.Value = $"{sumaHorasCheck}"
                                        ElseIf celda.Value.ToString() = "V" Then
                                            celda.Value = $"{sumaHorasCheck}"
                                        ElseIf celda.Value.ToString() = "PM" Then
                                            celda.Value = $"{sumaHorasCheck}"
                                        ElseIf celda.Value.ToString() = "FT" Then
                                            celda.Value = $"{sumaHorasCheck}"
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
                                            ElseIf observacion = "DESCANSO" Then
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
                                            ElseIf horasExtrasCheck > 0 Or horasExtrasMarranasCheck > 0 Then
                                                resultado = "HEX"

                                                ' Prioridad 6: Inasistencia parcial (trabajó menos de 8h)
                                            ElseIf horasTrabajadasCheck < 8 Then
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

                If tipoPeriodo.StartsWith("SEMANA") Then
                    Dim fechaInicio As Date
                    Dim fechaFin As Date

                    If tipo = "EVENTUAL" AndAlso tipoPeriodo.Contains("-") Then
                        ' Extraer la parte después de "SEMANA "
                        Dim periodoSinPrefijo As String = tipoPeriodo.Replace("SEMANA ", "").Trim()

                        ' Dividir por el guion (-)
                        Dim partes() As String = periodoSinPrefijo.Split("-"c)

                        ' Eliminar espacios adicionales
                        Dim fechaInicioStr As String = partes(0).Trim()
                        Dim fechaFinStr As String = partes(1).Trim()

                        ' Analizar las fechas con el formato correcto
                        fechaInicio = Date.ParseExact(fechaInicioStr, "dd/MM", Globalization.CultureInfo.InvariantCulture)
                        fechaFin = Date.ParseExact(fechaFinStr, "dd/MM", Globalization.CultureInfo.InvariantCulture)

                        ' Ajustar el año si es necesario
                        fechaInicio = New Date(anio, fechaInicio.Month, fechaInicio.Day)
                        fechaFin = New Date(anio, fechaFin.Month, fechaFin.Day)
                    Else
                        msj_advert("Período semanal no válido.")
                        Return
                    End If

                    For Each fila As UltraGridRow In dtgListado.Rows
                        Dim idTrabajador As String = fila.Cells("ID").Value.ToString()

                        For Each celda As UltraGridCell In fila.Cells
                            If celda.Column.Key.StartsWith("Dia") Then
                                ' Obtener la fecha del nombre de la columna
                                Dim fechaColumnaStr As String = celda.Column.Key.Replace("Dia", "")
                                Dim fechaColumna As Date = Date.ParseExact(fechaColumnaStr, "dd-MM", Globalization.CultureInfo.InvariantCulture)

                                ' Ajustar el año de la fecha de la columna
                                fechaColumna = New Date(anio, fechaColumna.Month, fechaColumna.Day)

                                ' Verificar si la fecha de la columna está dentro del rango semanal
                                If fechaColumna >= fechaInicio AndAlso fechaColumna <= fechaFin Then
                                    If horariosTrabajadores.ContainsKey(idTrabajador) Then
                                        Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = horariosTrabajadores(idTrabajador)

                                        ' Encontrar el índice correcto basado en el día del mes
                                        Dim indexHorario As Integer = (fechaColumna - fechaInicio).Days

                                        If indexHorario >= 0 AndAlso indexHorario < listaHorarios.Count Then
                                            Dim entrada As String = listaHorarios(indexHorario).Item1
                                            Dim salida As String = listaHorarios(indexHorario).Item2
                                            Dim observacion As String = listaHorarios(indexHorario).Item3
                                            Dim horasExtras As String = listaHorarios(indexHorario).Item4
                                            Dim horasTrabajadas As String = listaHorarios(indexHorario).Item6
                                            Dim horasRefrigerio As Integer = listaHorarios(indexHorario).Item7
                                            Dim permisoMedico As String = listaHorarios(indexHorario).Item8
                                            Dim feriadoTrabajado As String = listaHorarios(indexHorario).Item9
                                            Dim horasExtrasMarranas As String = listaHorarios(indexHorario).Item10

                                            ' Verificar si el valor actual es "-" y si es así, no modificarlo
                                            If celda.Value?.ToString() = "-" Then
                                                Continue For
                                            End If

                                            Dim totalHoras As Integer = Integer.Parse(horasTrabajadas)
                                            Dim totalHorasExtras As Double = Double.Parse(horasExtras)
                                            Dim totalHorasExtrasMarranas As Double = Double.Parse(horasExtrasMarranas)

                                            Dim sumaTotal As Double = totalHoras + totalHorasExtras + horasExtrasMarranas

                                            If cbMostrarCantidadHoras.Checked Then

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
                                                    ElseIf observacion = "DESCANSO" Then
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
                            End If
                        Next
                    Next
                Else
                    Dim rangoInicio As Integer
                    Dim rangoFin As Integer
                    Dim diasEnElMes As Integer = DateTime.DaysInMonth(anio, mes)
                    Dim obj As New coControlAsistencia
                    obj.IdUbicacion = _idPlantel
                    obj.Mes = mes
                    obj.Anio = anio
                    obj.Tipo = tipo
                    obj.idHorario = idHorario

                    Dim mensaje As String = cn.Cn_ObtenerUltimoDiaRegistroAsistencia(obj)
                    ultimoDiaRegistro = obj.UltimoDiaReg

                    If ultimoDiaRegistro > 0 And ultimoDiaRegistro < 16 Then
                        rangoInicio = 1
                        rangoFin = ultimoDiaRegistro
                    Else
                        rangoInicio = 16
                        rangoFin = ultimoDiaRegistro
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

                                        Dim sumaHorasCheck As Double = CDbl(horasTrabajadas) + CDbl(horasExtras) + CDbl(horasExtrasMarranas)
                                        Dim horasTrabajadasCheck As Integer = Integer.Parse(horasTrabajadas)
                                        Dim horasExtrasCheck As Double = Double.Parse(horasExtras)
                                        Dim horasExtrasMarranasCheck As Double = Double.Parse(horasExtrasMarranas)

                                        If cbMostrarCantidadHoras.Checked Then

                                            If celda.Value.ToString() = "HEX" Then
                                                celda.Value = $"{sumaHorasCheck}"
                                            ElseIf celda.Value.ToString() = "A" Then
                                                celda.Value = $"{sumaHorasCheck}"
                                            ElseIf celda.Value.ToString() = "IN" Then
                                                celda.Value = "IN"
                                            ElseIf celda.Value.ToString() = "F" Then
                                                celda.Value = "F"
                                            ElseIf celda.Value.ToString() = "D" Then
                                                celda.Value = $"{sumaHorasCheck}"
                                            ElseIf celda.Value.ToString() = "V" Then
                                                celda.Value = $"{sumaHorasCheck}"
                                            ElseIf celda.Value.ToString() = "PM" Then
                                                celda.Value = $"{sumaHorasCheck}"
                                            ElseIf celda.Value.ToString() = "FT" Then
                                                celda.Value = $"{sumaHorasCheck}"
                                            ElseIf celda.Value.ToString() = "FNT" Then
                                                celda.Value = "FNT"
                                            End If
                                        Else
                                            Dim resultado As String = "F"

                                            If Not String.IsNullOrWhiteSpace(entrada) AndAlso Not String.IsNullOrWhiteSpace(salida) Then

                                                If permisoMedico = "SI" Then
                                                    resultado = "PM"

                                                ElseIf observacion = "DESCANSO" Then
                                                    resultado = "D"

                                                ElseIf observacion = "VACACIONES" Then
                                                    resultado = "V"

                                                ElseIf feriadoTrabajado = "SI" Then
                                                    resultado = "FT"

                                                ElseIf feriadoTrabajado = "NO" Then
                                                    resultado = "FNT"

                                                ElseIf horasExtrasCheck > 0 Or horasExtrasMarranasCheck > 0 Then
                                                    resultado = "HEX"

                                                ElseIf horasTrabajadasCheck < 8 Then
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

            If tipo = "PLANILLA" Then
                Dim rangoInicio As Integer
                Dim rangoFin As Integer
                Dim obj As New coControlAsistencia
                obj.IdUbicacion = _idPlantel
                obj.Mes = mes
                obj.Anio = anio
                obj.Tipo = tipo

                Dim mensaje As String = cn.Cn_ObtenerUltimoDiaRegistroAsistencia(obj)
                ultimoDiaRegistro = obj.UltimoDiaReg

                If tipo = "PLANILLA" Then
                    If tipoPeriodo = "MENSUAL" Then
                        rangoInicio = 1
                        rangoFin = ultimoDiaRegistro
                    ElseIf ultimoDiaRegistro > 0 And ultimoDiaRegistro < 16 Then
                        rangoInicio = 1
                        rangoFin = ultimoDiaRegistro
                    Else
                        rangoInicio = 16
                        rangoFin = ultimoDiaRegistro
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
                                    Dim horasRefrigerio As Integer = listaHorarios(dia - 1).Item7
                                    Dim feriadoTrabajado As String = listaHorarios(dia - 1).Item9
                                    Dim horasExtrasMarranas As String = listaHorarios(dia - 1).Item10

                                    Dim horasExtrasMostrar As Double = Double.Parse(horasExtras) + Double.Parse(horasExtrasMarranas)

                                    If cbMostrarHorasExtras.Checked Then
                                        Select Case celda.Value?.ToString()
                                            Case "HEX", "FT"
                                                celda.Value = $"{horasExtrasMostrar}"
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
                                            ElseIf horasExtrasMostrar > 0 Then
                                                resultado = "HEX"
                                            ElseIf horasTrabajadas < 8 Then
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
                If tipoPeriodo.StartsWith("SEMANA") Then

                    Dim fechaInicio As Date
                    Dim fechaFin As Date

                    If tipo = "EVENTUAL" AndAlso tipoPeriodo.Contains("-") Then
                        ' Extraer la parte después de "SEMANA "
                        Dim periodoSinPrefijo As String = tipoPeriodo.Replace("SEMANA ", "").Trim()

                        ' Dividir por el guion (-)
                        Dim partes() As String = periodoSinPrefijo.Split("-"c)

                        ' Eliminar espacios adicionales
                        Dim fechaInicioStr As String = partes(0).Trim()
                        Dim fechaFinStr As String = partes(1).Trim()

                        ' Analizar las fechas con el formato correcto
                        fechaInicio = Date.ParseExact(fechaInicioStr, "dd/MM", Globalization.CultureInfo.InvariantCulture)
                        fechaFin = Date.ParseExact(fechaFinStr, "dd/MM", Globalization.CultureInfo.InvariantCulture)

                        ' Ajustar el año si es necesario
                        fechaInicio = New Date(anio, fechaInicio.Month, fechaInicio.Day)
                        fechaFin = New Date(anio, fechaFin.Month, fechaFin.Day)
                    Else
                        msj_advert("Período semanal no válido.")
                        Return
                    End If

                    For Each fila As UltraGridRow In dtgListado.Rows
                        Dim idTrabajador As String = fila.Cells("ID").Value.ToString()

                        For Each celda As UltraGridCell In fila.Cells
                            If celda.Column.Key.StartsWith("Dia") Then
                                ' Obtener la fecha del nombre de la columna
                                Dim fechaColumnaStr As String = celda.Column.Key.Replace("Dia", "")
                                Dim fechaColumna As Date = Date.ParseExact(fechaColumnaStr, "dd-MM", Globalization.CultureInfo.InvariantCulture)

                                ' Ajustar el año de la fecha de la columna
                                fechaColumna = New Date(anio, fechaColumna.Month, fechaColumna.Day)

                                ' Verificar si la fecha de la columna está dentro del rango semanal
                                If fechaColumna >= fechaInicio AndAlso fechaColumna <= fechaFin Then
                                    If horariosTrabajadores.ContainsKey(idTrabajador) Then
                                        Dim listaHorarios As List(Of (String, String, String, String, String, String, Integer, String, String, String)) = horariosTrabajadores(idTrabajador)

                                        ' Encontrar el índice correcto basado en el día del mes
                                        Dim indexHorario As Integer = (fechaColumna - fechaInicio).Days

                                        If indexHorario >= 0 AndAlso indexHorario < listaHorarios.Count Then
                                            Dim entrada As String = listaHorarios(indexHorario).Item1
                                            Dim salida As String = listaHorarios(indexHorario).Item2
                                            Dim horasExtras As String = listaHorarios(indexHorario).Item4
                                            Dim horasTrabajadas As String = listaHorarios(indexHorario).Item6
                                            Dim horasRefrigerio As Integer = listaHorarios(indexHorario).Item7
                                            Dim feriadoTrabajado As String = listaHorarios(indexHorario).Item9
                                            Dim horasExtrasMarranas As String = listaHorarios(indexHorario).Item10

                                            Dim horasExtrasMostrar As Double = Double.Parse(horasExtras) + Double.Parse(horasExtrasMarranas)

                                            ' Verificar si el valor actual es "-" y si es así, no modificarlo
                                            If celda.Value?.ToString() = "-" Then
                                                Continue For
                                            End If

                                            If cbMostrarHorasExtras.Checked Then

                                                Select Case celda.Value?.ToString()
                                                    Case "HEX", "FT"
                                                        celda.Value = $"{horasExtrasMostrar}"
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
                                                    ElseIf horasExtrasMostrar > 0 Then
                                                        resultado = "HEX"
                                                    ElseIf horasTrabajadas < 8 Then
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
                            End If
                        Next
                    Next
                Else
                    Dim rangoInicio As Integer
                    Dim rangoFin As Integer
                    Dim obj As New coControlAsistencia
                    obj.IdUbicacion = _idPlantel
                    obj.Mes = mes
                    obj.Anio = anio
                    obj.Tipo = tipo
                    obj.idHorario = idHorario

                    Dim mensaje As String = cn.Cn_ObtenerUltimoDiaRegistroAsistencia(obj)
                    ultimoDiaRegistro = obj.UltimoDiaReg

                    If ultimoDiaRegistro > 0 And ultimoDiaRegistro < 16 Then
                        rangoInicio = 1
                        rangoFin = ultimoDiaRegistro
                    Else
                        rangoInicio = 16
                        rangoFin = ultimoDiaRegistro
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
                                        Dim horasRefrigerio As Integer = listaHorarios(dia - 1).Item7
                                        Dim feriadoTrabajado As String = listaHorarios(dia - 1).Item9
                                        Dim horasExtrasMarranas As String = listaHorarios(dia - 1).Item10

                                        Dim horasExtrasMostrar As Double = Double.Parse(horasExtras) + Double.Parse(horasExtrasMarranas)

                                        If cbMostrarHorasExtras.Checked Then

                                            Select Case celda.Value?.ToString()
                                                Case "HEX", "FT"
                                                    celda.Value = $"{horasExtrasMostrar}"
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
                                                ElseIf horasExtrasMostrar > 0 Then
                                                    resultado = "HEX"
                                                ElseIf horasTrabajadas < 8 Then
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

            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If dtgListado.Rows.Count > 0 Then
            If activeRow IsNot Nothing AndAlso Not String.IsNullOrEmpty(activeRow.Cells(0).Value.ToString()) Then
                If activeRow.Band.Index = 0 Then
                    If MessageBox.Show("¿Está seguro de aplicar asistencia al trabajador seleccionado?", "Aplicar Asistencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Dim dni As String = activeRow.Cells("ID").Value.ToString()

                        If tipo = "PLANILLA" Then
                            ' Código existente para PLANILLA
                            ' Calcular el último día del mes basado en el año y mes proporcionados
                            Dim ultimoDiaMes As Integer = DateTime.DaysInMonth(anio, mes)

                            ' Definir rango del período y horas de refrigerio
                            Dim rangoDelPeriodo As (Integer, Integer)
                            Dim horasRefrigerio As Integer

                            Select Case tipoPeriodo.ToUpper()
                                Case "QUINCENA 1"
                                    rangoDelPeriodo = (1, 15)
                                    horasRefrigerio = 1
                                Case "QUINCENA 2"
                                    rangoDelPeriodo = (16, ultimoDiaMes)
                                    horasRefrigerio = 1
                                Case "MENSUAL"
                                    rangoDelPeriodo = (1, ultimoDiaMes)
                                    horasRefrigerio = 2
                                Case Else
                                    rangoDelPeriodo = (1, ultimoDiaMes) ' Por defecto, todo el mes
                                    horasRefrigerio = 1 ' Por defecto, 1 hora
                            End Select

                            ' Definir horarios según tipo de período
                            Dim entrada As String = "08:00"
                            Dim salida As String
                            Dim horasTrabajadas As String = "8"

                            ' Ajustar la hora de salida según el tipo de período
                            If tipoPeriodo.ToUpper() = "MENSUAL" Then
                                salida = "18:00"
                            Else ' QUINCENA 1 o QUINCENA 2
                                salida = "17:00"
                            End If

                            ' Update horariosTrabajadores dictionary
                            If horariosTrabajadores.ContainsKey(dni) Then
                                Dim listaHorarios = horariosTrabajadores(dni)

                                ' Iterar solo dentro del rango del período
                                For dia As Integer = rangoDelPeriodo.Item1 To rangoDelPeriodo.Item2
                                    Dim i As Integer = dia - 1 ' Índice base 0 para el array

                                    ' Verificar que el índice esté dentro del rango de la lista
                                    If i >= 0 AndAlso i < listaHorarios.Count Then
                                        ' Set ultimoDiaRegEventual
                                        ultimoDiaRegistroEventual = dia

                                        listaHorarios(i) = (
                                    entrada,           ' Hora Entrada
                                    salida,            ' Hora Salida
                                    "Sin observación", ' Observación
                                    "0",               ' Horas Extras
                                    "0",               ' Pago Especial
                                    horasTrabajadas,   ' Horas Trabajadas
                                    horasRefrigerio,   ' Horas Refrigerio
                                    "NO",               ' Permiso Médico
                                    "SIN ASIGNAR",       ' Feriado
                                    "0"
                                )
                                        ' Update grid cell value
                                        activeRow.Cells($"Dia{dia}").Value = "A"
                                    End If
                                Next

                                ' Calcular el total de días en el rango
                                Dim diasEnRango As Integer = rangoDelPeriodo.Item2 - rangoDelPeriodo.Item1 + 1

                                ' Recalculate totals basados en el número de días en el rango
                                activeRow.Cells("H.T").Value = diasEnRango * 8
                                activeRow.Cells("H.TR").Value = diasEnRango * 8
                                activeRow.Cells("H.EX").Value = 0
                                Colorear()
                                ProcesarAsistencias()
                                msj_ok("Asistencia aplicada correctamente.")
                            End If

                        ElseIf tipo = "EVENTUAL" Then
                            ' Nueva lógica para EVENTUAL
                            If tipoPeriodo.StartsWith("SEMANA") Then
                                ' Extraer las fechas del tipoPeriodo
                                Dim partes As String() = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)
                                Dim fechaInicio As Date = Date.ParseExact(partes(0).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)
                                Dim fechaFin As Date = Date.ParseExact(partes(1).Trim(), "dd/MM", Globalization.CultureInfo.InvariantCulture)

                                ' Ajustar el año
                                fechaInicio = New Date(anio, fechaInicio.Month, fechaInicio.Day)
                                fechaFin = New Date(anio, fechaFin.Month, fechaFin.Day)

                                ' Definir horarios para EVENTUAL
                                Dim entrada As String = "08:00"
                                Dim salida As String = "17:00"
                                Dim horasTrabajadas As String = "8"
                                Dim horasRefrigerio As Integer = 1

                                If horariosTrabajadores.ContainsKey(dni) Then
                                    Dim listaHorarios = horariosTrabajadores(dni)

                                    ' Procesar cada día de la semana
                                    Dim fechaActual As DateTime = fechaInicio
                                    Dim indiceHorario As Integer = 0

                                    While fechaActual <= fechaFin
                                        ' Verificar que el índice esté dentro del rango de la lista (máximo 7 días para semana)
                                        If indiceHorario >= 0 AndAlso indiceHorario < listaHorarios.Count Then
                                            ' Set ultimoDiaRegEventual
                                            ultimoDiaRegistroEventual = fechaActual.Day

                                            listaHorarios(indiceHorario) = (
                                        entrada,           ' Hora Entrada
                                        salida,            ' Hora Salida
                                        "Sin observación", ' Observación
                                        "0",               ' Horas Extras
                                        "0",               ' Pago Especial
                                        horasTrabajadas,   ' Horas Trabajadas
                                        horasRefrigerio,   ' Horas Refrigerio
                                        "NO",               ' Permiso Médico
                                        "SIN ASIGNAR",       ' Feriado
                                        "0"                ' Horas Extras Marranas
                                    )

                                            ' Update grid cell value - usar formato de columna para semanas
                                            Dim nombreColumna As String = $"Dia{fechaActual:dd-MM}"
                                            If activeRow.Cells(nombreColumna) IsNot Nothing Then
                                                activeRow.Cells(nombreColumna).Value = "A"
                                            End If
                                        End If

                                        fechaActual = fechaActual.AddDays(1)
                                        indiceHorario += 1
                                    End While

                                    ' Calcular el total de días en la semana
                                    Dim diasEnSemana As Integer = (fechaFin - fechaInicio).Days + 1

                                    ' Recalculate totals basados en el número de días en la semana
                                    activeRow.Cells("H.T").Value = diasEnSemana * 8
                                    activeRow.Cells("H.TR").Value = diasEnSemana * 8
                                    activeRow.Cells("H.EX").Value = 0
                                    Colorear()
                                    ProcesarAsistencias()
                                    msj_ok($"Asistencia aplicada correctamente para la semana del {fechaInicio:dd/MM} al {fechaFin:dd/MM}.")
                                End If

                            Else
                                ' Para EVENTUAL con quincenas
                                Dim ultimoDiaMes As Integer = DateTime.DaysInMonth(anio, mes)
                                Dim rangoDelPeriodo As (Integer, Integer)
                                Dim horasRefrigerio As Integer = 1

                                Select Case tipoPeriodo.ToUpper()
                                    Case "QUINCENA 1"
                                        rangoDelPeriodo = (1, 15)
                                    Case "QUINCENA 2"
                                        rangoDelPeriodo = (16, ultimoDiaMes)
                                    Case Else
                                        rangoDelPeriodo = (1, ultimoDiaMes)
                                End Select

                                ' Definir horarios para EVENTUAL quincena
                                Dim entrada As String = "08:00"
                                Dim salida As String = "17:00"
                                Dim horasTrabajadas As String = "8"

                                If horariosTrabajadores.ContainsKey(dni) Then
                                    Dim listaHorarios = horariosTrabajadores(dni)

                                    ' Iterar solo dentro del rango del período
                                    For dia As Integer = rangoDelPeriodo.Item1 To rangoDelPeriodo.Item2
                                        Dim i As Integer = dia - 1 ' Índice base 0 para el array

                                        ' Verificar que el índice esté dentro del rango de la lista
                                        If i >= 0 AndAlso i < listaHorarios.Count Then
                                            ' Set ultimoDiaRegEventual
                                            ultimoDiaRegistroEventual = dia

                                            listaHorarios(i) = (
                                        entrada,           ' Hora Entrada
                                        salida,            ' Hora Salida
                                        "Sin observación", ' Observación
                                        "0",               ' Horas Extras
                                        "0",               ' Pago Especial
                                        horasTrabajadas,   ' Horas Trabajadas
                                        horasRefrigerio,   ' Horas Refrigerio
                                        "NO",               ' Permiso Médico
                                        "SIN ASIGNAR",       ' Feriado
                                        "0"                ' Horas Extras Marranas
                                    )
                                            ' Update grid cell value
                                            activeRow.Cells($"Dia{dia}").Value = "A"
                                        End If
                                    Next

                                    ' Calcular el total de días en el rango
                                    Dim diasEnRango As Integer = rangoDelPeriodo.Item2 - rangoDelPeriodo.Item1 + 1

                                    ' Recalculate totals basados en el número de días en el rango
                                    activeRow.Cells("H.T").Value = diasEnRango * 8
                                    activeRow.Cells("H.TR").Value = diasEnRango * 8
                                    activeRow.Cells("H.EX").Value = 0
                                    Colorear()
                                    ProcesarAsistencias()
                                    msj_ok("Asistencia aplicada correctamente.")
                                End If
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

    Private Sub btnAplicarVacaciones_Click(sender As Object, e As EventArgs) Handles btnAplicarVacaciones.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If dtgListado.Rows.Count > 0 Then
                If activeRow IsNot Nothing AndAlso Not String.IsNullOrEmpty(activeRow.Cells(0).Value.ToString()) Then
                    If activeRow.Band.Index = 0 Then
                        If MessageBox.Show("¿Está seguro de aplicar vacaciones al trabajador seleccionado?", "Aplicar Vacaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Dim dni As String = activeRow.Cells("ID").Value.ToString()
                            Dim obj As New coControlAsistencia
                            obj.NumDocumento = dni
                            obj.Mes = cbListaMeses.SelectedIndex + 1
                            obj.Anio = anio


                            Dim mensaje As String = cn.Cn_AplicarVacacionesPorTrabajadorAsistencia(obj)
                            If obj.CodeError = 0 Then
                                ' Ajustar el rango de días según el tipo de periodo
                                Dim diaInicio As Integer = obj.DiaInicio
                                Dim diaFin As Integer = obj.DiaFin
                                Dim ultimoDiaMes As Integer = DateTime.DaysInMonth(anio, obj.Mes)
                                Dim diasAplicar As (inicio As Integer, fin As Integer)
                                Dim rangoPeriodo As (inicio As Integer, fin As Integer)


                                Select Case tipoPeriodo.ToUpper()
                                    Case "QUINCENA 1"
                                        ' Limitar a los días del 1 al 15 dentro del rango solicitado
                                        diasAplicar.inicio = Math.Max(diaInicio, 1)
                                        diasAplicar.fin = Math.Min(diaFin, 15)
                                        rangoPeriodo.inicio = 1
                                        rangoPeriodo.fin = 15

                                    Case "QUINCENA 2"
                                        ' Limitar a los días del 16 al fin de mes dentro del rango solicitado
                                        diasAplicar.inicio = Math.Max(diaInicio, 16)
                                        diasAplicar.fin = Math.Min(diaFin, ultimoDiaMes)
                                        rangoPeriodo.inicio = 16
                                        rangoPeriodo.fin = ultimoDiaMes

                                    Case "MENSUAL"
                                        ' Usar todo el rango solicitado, limitado al mes
                                        diasAplicar.inicio = Math.Max(diaInicio, 1)
                                        diasAplicar.fin = Math.Min(diaFin, ultimoDiaMes)
                                        rangoPeriodo.inicio = 1
                                        rangoPeriodo.fin = ultimoDiaMes

                                    Case Else
                                        msj_advert("LAS VACACIONES PARA EVENTUALES NO SON VALIDAS")
                                        Return
                                End Select

                                ' Actualizar los días en el objeto
                                obj.DiaInicio = diasAplicar.inicio
                                obj.DiaFin = diasAplicar.fin

                                ' Apply attendance only within the specified range
                                If horariosTrabajadores.ContainsKey(dni) Then
                                    Dim listaHorarios = horariosTrabajadores(dni)

                                    ' Primero, limpiar todas las marcas de vacaciones existentes en el periodo actual
                                    For i As Integer = rangoPeriodo.inicio - 1 To rangoPeriodo.fin - 1
                                        Dim nombreCelda As String = $"Dia{i + 1}"
                                        If activeRow.Cells(nombreCelda).Value IsNot Nothing AndAlso activeRow.Cells(nombreCelda).Value.ToString() = "V" Then
                                            ' Si había una marca de vacaciones, la cambiamos a F (Falta)
                                            activeRow.Cells(nombreCelda).Value = "F"
                                            listaHorarios(i) = ("00:00", "00:00", "Sin Observación", "0", "0", "0", 1, "NO", "SIN ASIGNAR", "0")
                                        End If
                                    Next

                                    For i As Integer = obj.DiaInicio - 1 To obj.DiaFin - 1
                                        Dim nombreCelda As String = $"Dia{i + 1}"
                                        ' Verificar si la celda no contiene "-"
                                        Dim entrada As String = "08:00"
                                        Dim salida As String = "17:00"

                                        ultimoDiaRegistroEventual = i + 1

                                        listaHorarios(i) = (entrada, salida, "VACACIONES", "0", "0", "8", 1, "NO", "SIN ASIGNAR", "0")
                                        activeRow.Cells(nombreCelda).Value = "V"
                                    Next

                                    Dim diasTrabajados As Integer = obj.DiaFin - obj.DiaInicio + 1
                                    activeRow.Cells("H.T").Value = diasTrabajados * 8
                                    activeRow.Cells("H.TR").Value = diasTrabajados * 8
                                    activeRow.Cells("H.EX").Value = 0
                                    Colorear()
                                    ProcesarAsistencias()
                                End If

                                ' Mostrar mensaje con los días realmente aplicados
                                msj_ok($"Vacaciones aplicadas correctamente para los días del {obj.DiaInicio} al {obj.DiaFin}")
                            Else
                                msj_advert(mensaje)
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

    Private Sub btnFiltros_Click(sender As Object, e As EventArgs) Handles btnFiltros.Click
        Dim isFilterActive As Boolean = Not btnFiltros.Checked
        btnFiltros.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class