Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmAsistencia
    Dim cn As New cnControlAsistencia
    Dim idAsistencia As Integer

    Private Sub FrmAsistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cbxMeses.SelectedIndex = 12
            ListarAños()
            ListarPlanteles()
            ConsultarAsistencia()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
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

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrarrrhhasistencia.Click
        Dim f As New FrmControlAsistencia
        f.idPlantelSeleccionado = cbxListarPlanteles.Value
        f.ShowDialog()
        ListarAños()
        ConsultarAsistencia()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ConsultarAsistencia()
    End Sub

    Sub ConsultarAsistencia()
        Dim obj As New coControlAsistencia
        Dim mesSeleccionado As Integer? = Nothing
        Dim anio As Integer = cbxAños.Value

        If cbxMeses.SelectedIndex <> 12 Then
            mesSeleccionado = cbxMeses.SelectedIndex + 1
        End If

        obj.Mes = mesSeleccionado
        obj.Anio = anio
        obj.IdUbicacion = cbxListarPlanteles.Value

        Dim dt As DataTable = cn.Cn_ConsultarAsistencia(obj)
        dtgListado.DataSource = dt
        ColorearGrid()
    End Sub

    Sub ColorearGrid()
        Dim estado As Integer = 6
        Dim tipo As Integer = 7

        'estado
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "PENDIENTE", estado)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "APROBADO", estado)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ENVIADO", estado)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "INCOMPLETO", estado)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Yellow, Color.Black, "OBSERVADO", estado)

        'tipo
        clsBasicas.Colorear_SegunValor(dtgListado, Color.LightBlue, Color.Black, "EVENTUAL", tipo)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.Black, "PLANILLA", tipo)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.Black, "PLANILLA ADMNISTRATIVA", tipo)

        With dtgListado.DisplayLayout.Bands(0)
            .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            .Columns(tipo).CellAppearance.TextHAlign = HAlign.Center
        End With
    End Sub

    Private Sub btnFiltros_Click(sender As Object, e As EventArgs) Handles btnFiltros.Click
        Dim isFilterActive As Boolean = Not btnFiltros.Checked
        btnFiltros.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
    Sub ListarAños()
        Try
            Dim dt As New DataTable
            dt = cn.Cn_ListarAñosDeHorarios().Copy
            dt.TableName = "tmp"
            dt.Columns(0).ColumnName = "Seleccione un Año"
            With cbxAños
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

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobarrrhhasistencia.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim estado As String = dtgListado.ActiveRow.Cells("Estado").Value.ToString()
                    Dim tipo As String = dtgListado.ActiveRow.Cells("Tipo Planilla").Value.ToString()

                    If estado = "INCOMPLETO" Then
                        msj_advert("PARA PODER APROBAR SE NECESITA COMPLETAR LA QUINCENA O SEMANA")
                        Return
                    End If

                    If tipo = "EVENTUAL" Then
                        If (estado = "APROBADO" Or estado = "ENVIADO") Then
                            msj_advert("LA SEMANA YA FUE APROBADA.")
                            Return
                        End If
                    ElseIf tipo = "PLANILLA" Then
                        If (estado = "APROBADO" Or estado = "ENVIADO") Then
                            msj_advert("LA QUINCENA YA FUE APROBADA.")
                            Return
                        End If
                    End If

                    If (MessageBox.Show("¿Está seguro de aprobar la asistencia de los trabajadores?", "Aprobar Asistencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    idAsistencia = CInt(dtgListado.ActiveRow.Cells(0).Value)
                    Dim obj As New coControlAsistencia
                    obj.Codigo = idAsistencia
                    Dim MensajeBgWk As String = ""
                    MensajeBgWk = cn.Cn_ActualizarEstadoAsistencia(obj)
                    If (obj.CodeError = 0) Then
                        msj_ok(MensajeBgWk)
                        ConsultarAsistencia()
                    Else
                        msj_advert(MensajeBgWk)
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


    Private Sub btnEnviarRrhhCtrlasist_Click(sender As Object, e As EventArgs) Handles btnEnviarRrhhCtrlasist.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim fechaPeriodo As String = activeRow.Cells(2).Value
                    Dim tipoPeriodo As String = dtgListado.ActiveRow.Cells(4).Value.ToString()
                    Dim estado As String = dtgListado.ActiveRow.Cells("Estado").Value.ToString()
                    Dim tipo As String = dtgListado.ActiveRow.Cells("Tipo Planilla").Value.ToString()
                    Dim partes() As String = fechaPeriodo.Split("/"c)
                    Dim mes As Integer = Convert.ToInt32(partes(0))
                    Dim anio As Integer = Convert.ToInt32(partes(1))
                    Dim dtpFechaInicio As DateTime
                    Dim dtpFechaFin As DateTime

                    If tipo = "EVENTUAL" Then
                        msj_advert("Esta opción está disponible solo para trabajadores que pertenecen a eventual.")
                        Return
                    End If

                    If tipo = "PLANILLA" Then
                        If (estado = "ENVIADO") Then
                            msj_advert("LA QUINCENA YA FUE ENVIADA.")
                            Return
                        ElseIf (estado <> "APROBADO") Then
                            msj_advert("DEBE ESTAR APROBADO PARA PODER ENVIARSE A PAGAR.")
                            Return
                        End If
                    End If

                    If (MessageBox.Show("¿Está seguro de enviar a pagar la asistencia de los trabajadores?", "Enviar Asistencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If


                    idAsistencia = CInt(dtgListado.ActiveRow.Cells(0).Value)
                    Dim obj As New coControlAsistencia
                    Dim mensaje As String = ""


                    If tipoPeriodo = "QUINCENA 1" Then
                        dtpFechaInicio = New DateTime(anio, mes, 1)
                        dtpFechaFin = New DateTime(anio, mes, 15)
                    ElseIf tipoPeriodo = "QUINCENA 2" Then
                        dtpFechaInicio = New DateTime(anio, mes, 16)
                        dtpFechaFin = New DateTime(anio, mes, DateTime.DaysInMonth(anio, mes))
                    ElseIf tipoPeriodo = "MENSUAL" Then
                        dtpFechaInicio = New DateTime(anio, mes, 1)
                        dtpFechaFin = New DateTime(anio, mes, DateTime.DaysInMonth(anio, mes))
                    End If

                    obj.idHorario = idAsistencia
                    obj.Tipoperiodo = tipoPeriodo
                    obj.FechaInicio = dtpFechaInicio
                    obj.FechaFin = dtpFechaFin
                    obj.Estado = "ENVIADO"
                    obj.IdUsuario = VariablesGlobales.VP_IdUser
                    mensaje = cn.Cn_EnviarPagoAsistencias(obj)
                    If (obj.CodeError = 0) Then
                        msj_ok(mensaje)
                        ConsultarAsistencia()
                    Else
                        msj_advert(mensaje)
                    End If
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub


    Private Sub btnVerRrhhCtrlasist_Click(sender As Object, e As EventArgs) Handles btnVerRrhhCtrlasist.Click

        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim idHorario As Integer = activeRow.Cells(0).Value
                Dim fechaPeriodo As String = activeRow.Cells(2).Value
                Dim plantel As String = activeRow.Cells(3).Value
                Dim tipoPeriodo As String = activeRow.Cells(4).Value
                Dim estado As String = activeRow.Cells("Estado").Value
                Dim tipo As String = activeRow.Cells("Tipo Planilla").Value

                Dim partes() As String = fechaPeriodo.Split("/"c)
                Dim mes As Integer = Convert.ToInt32(partes(0))
                Dim anio As Integer = Convert.ToInt32(partes(1))

                Dim f As New FrmVerAsistencia()
                f.idHorario = idHorario
                f.anio = anio
                f.mes = mes
                f.plantel = plantel
                f.tipo = tipo
                f.estado = estado
                f.tipoPeriodo = tipoPeriodo
                f.ShowDialog()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelarrrhhasistencia.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then

                    Dim estado As String = dtgListado.ActiveRow.Cells("Estado").Value.ToString()
                    Dim tipoPeriodo As String = dtgListado.ActiveRow.Cells("Tipo Planilla").Value.ToString()

                    If estado = "OBSERVADO" Then
                        msj_advert("LA ASISTENCIA YA SE MANDO A OBSERVAR PARA LAS CORRECCIONES")
                        Return
                    End If

                    If tipoPeriodo = "PLANILLA" Then
                        If estado = "ENVIADO" Then
                            msj_advert("LA QUINCENA YA FUE ENVIADA Y NO SE PUEDE MANDAR A OBSERVAR")
                            Return
                        ElseIf estado = "APROBADO" Then
                            msj_advert("LA QUINCENA YA FUE APROBADA Y NO SE PUEDE MANDAR A OBSERVAR")
                            Return
                        End If
                    ElseIf tipoPeriodo = "EVENTUAL" Then
                        If estado = "ENVIADO" Then
                            msj_advert("LA SEMANA YA FUE ENVIADA Y NO SE PUEDE MANDAR A OBSERVAR")
                            Return
                        ElseIf estado = "APROBADO" Then
                            msj_advert("LA SEMANA YA FUE APROBADA Y NO SE PUEDE MANDAR A OBSERVAR")
                            Return
                        End If
                    End If

                    If (estado = "INCOMPLETO" Or estado = "NO REGISTRADO") Then
                        msj_advert("PARA MANDAR A OBSERVAR SE NECESITA COMPLETAR LA QUINCENA O SEMANA")
                        Return
                    End If

                    If (MessageBox.Show("¿Está seguro de mandar a observar la asistencia de los trabajadores?", "Cancelar Asistencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    idAsistencia = CInt(dtgListado.ActiveRow.Cells(0).Value)
                    Dim obj As New coControlAsistencia

                    obj.Codigo = idAsistencia
                    Dim MensajeBgWk As String = ""
                    MensajeBgWk = cn.Cn_ActualizarObservadoAsistencia(obj)
                    If (obj.CodeError = 0) Then
                        msj_ok(MensajeBgWk)
                        ConsultarAsistencia()
                    Else
                        msj_advert(MensajeBgWk)
                    End If
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarrhhasistencia.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim idHorario As Integer = activeRow.Cells(0).Value
                    Dim fechaPeriodo As String = activeRow.Cells(2).Value
                    Dim plantel As String = activeRow.Cells(3).Value
                    Dim tipoPeriodo As String = activeRow.Cells(4).Value
                    Dim estado As String = activeRow.Cells("Estado").Value
                    Dim tipo As String = activeRow.Cells("Tipo Planilla").Value

                    Dim partes() As String = fechaPeriodo.Split("/"c)
                    Dim mes As Integer = Convert.ToInt32(partes(0))
                    Dim anio As Integer = Convert.ToInt32(partes(1))

                    If tipo = "PLANILLA" Or tipo = "EVENTUAL" Then
                        If estado = "APROBADO" Or estado = "ENVIADO" Then
                            msj_advert("NO SE PUEDE EDITAR PORQUE LA ASISTENCIA DE PLANILLA YA HA SIDO APROBADA")
                            Return
                        End If
                    End If

                    Dim f As New FrmEditarAsistencia()
                    f.idHorario = idHorario
                    f.anio = anio
                    f.mes = mes
                    f.plantel = plantel
                    f.estado = estado
                    f.tipoPeriodo = tipoPeriodo
                    f.tipo = tipo
                    f.ShowDialog()
                    ConsultarAsistencia()
                    ListarAños()
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

    Private Sub btnEnviarSemanal_Click(sender As Object, e As EventArgs) Handles btnEnviarSemanalrrhhasistencia.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim fechaPeriodo As String = activeRow.Cells(2).Value
                        Dim tipoPeriodo As String = dtgListado.ActiveRow.Cells(4).Value.ToString()
                        Dim estado As String = dtgListado.ActiveRow.Cells("Estado").Value.ToString()
                        Dim tipo As String = dtgListado.ActiveRow.Cells("Tipo Planilla").Value.ToString()
                        Dim partes() As String = fechaPeriodo.Split("/"c)
                        Dim mes As Integer = Convert.ToInt32(partes(0))
                        Dim anio As Integer = Convert.ToInt32(partes(1))
                        Dim dtpFechaInicio As DateTime
                        Dim dtpFechaFin As DateTime

                        If tipo = "PLANILLA" Then
                            msj_advert("Esta opción está disponible solo para trabajadores que pertenecen a eventual.")
                            Return
                        End If

                        If tipo = "EVENTUAL" Then
                            If (estado = "ENVIADO") Then
                                msj_advert("LA SEMANA YA FUE ENVIADA.")
                                Return
                            ElseIf (estado <> "APROBADO") Then
                                msj_advert("DEBE ESTAR APROBADO PARA PODER ENVIARSE A PAGAR.")
                                Return
                            End If
                        End If

                        If (MessageBox.Show("¿Está seguro de enviar la asistencia de los trabajadores?", "Enviar Asistencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                            Return
                        End If

                        If tipoPeriodo.StartsWith("SEMANA") Then
                            ' Extraer las fechas del tipoPeriodo
                            Dim partesSemana As String() = tipoPeriodo.Replace("SEMANA", "").Trim().Split("-"c)

                            Dim fechaInicio As String = partesSemana(0).Trim()
                            Dim fechaFin As String = partesSemana(1).Trim()

                            Dim fechaInicioParts() As String = fechaInicio.Split("/"c)
                            Dim diaInicio As Integer = Convert.ToInt32(fechaInicioParts(0))
                            Dim mesInicio As Integer = Convert.ToInt32(fechaInicioParts(1))

                            Dim fechaFinParts() As String = fechaFin.Split("/"c)
                            Dim diaFin As Integer = Convert.ToInt32(fechaFinParts(0))
                            Dim mesFin As Integer = Convert.ToInt32(fechaFinParts(1))

                            dtpFechaInicio = New DateTime(anio, mesInicio, diaInicio)
                            dtpFechaFin = New DateTime(anio, mesFin, diaFin)
                        Else
                            If tipoPeriodo = "QUINCENA 1" Then
                                dtpFechaInicio = New DateTime(anio, mes, 1)
                                dtpFechaFin = New DateTime(anio, mes, 15)
                            ElseIf tipoPeriodo = "QUINCENA 2" Then
                                dtpFechaInicio = New DateTime(anio, mes, 16)
                                dtpFechaFin = New DateTime(anio, mes, DateTime.DaysInMonth(anio, mes))
                            End If
                        End If

                        idAsistencia = CInt(dtgListado.ActiveRow.Cells(0).Value)
                        Dim obj As New coControlAsistencia
                        Dim mensaje As String = ""

                        obj.idHorario = idAsistencia
                        obj.Tipoperiodo = tipoPeriodo
                        obj.FechaInicio = dtpFechaInicio
                        obj.FechaFin = dtpFechaFin
                        obj.Estado = "ENVIADO"
                        obj.IdUsuario = VariablesGlobales.VP_IdUser
                        mensaje = cn.Cn_EnviarPagoAsistencias(obj)
                        If (obj.CodeError = 0) Then
                            msj_ok(mensaje)
                            ConsultarAsistencia()
                        Else
                            msj_advert(mensaje)
                        End If
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

    Private Sub btnExportarRrhhCtrlasist_Click(sender As Object, e As EventArgs) Handles btnExportarRrhhCtrlasist.Click
        clsBasicas.ExportarExcel("Reporte de Asistencia", dtgListado)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnAnularRrhhCtrlasist_Click(sender As Object, e As EventArgs) Handles btnAnularRrhhCtrlasist.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim estado As String = dtgListado.ActiveRow.Cells("Estado").Value.ToString()

                        If estado = "ENVIADO" Or estado = "APROBADO" Then
                            msj_advert("NO SE PUEDE ELIMINAR PORQUE ESTÁ ENVIADO O APROBADO")
                            Return
                        End If

                        If estado = "ANULADO" Then
                            msj_advert("LA ASISTENCIA YA HA SIDO ANULADA")
                        End If

                        If (MessageBox.Show("¿Está seguro de eliminar de la lista la asistencia de los trabajadores?", "Enviar Asistencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                            Return
                        End If

                        idAsistencia = CInt(dtgListado.ActiveRow.Cells(0).Value)
                        Dim obj As New coControlAsistencia
                        Dim mensaje As String = ""
                        obj.idHorario = idAsistencia
                        mensaje = cn.Cn_InvalidarAsistencia(obj)
                        If (obj.CodeError = 0) Then
                            msj_ok(mensaje)
                            ConsultarAsistencia()
                        Else
                            msj_advert(mensaje)
                        End If
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

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCancelarAprobacion_Click(sender As Object, e As EventArgs) Handles btnCancelarAprobacion.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then

                    Dim estado As String = dtgListado.ActiveRow.Cells("Estado").Value.ToString()
                    Dim tipoPeriodo As String = dtgListado.ActiveRow.Cells("Tipo Planilla").Value.ToString()

                    If estado <> "APROBADO" Then
                        msj_advert("PARA CANCELAR LA APROBACIÓN DE LA ASISTENCIA, DEBE DE ESTAR EN EL ESTADO APROBADO")
                        Return
                    End If

                    If (MessageBox.Show("¿Está seguro de cancelar la aprobación de la asistencia de trabajadores?", "Cancelar Asistencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    idAsistencia = CInt(dtgListado.ActiveRow.Cells(0).Value)
                    Dim obj As New coControlAsistencia

                    obj.Codigo = idAsistencia
                    Dim MensajeBgWk As String = ""
                    MensajeBgWk = cn.Cn_CancelarAprobacionAsistencia(obj)
                    If (obj.CodeError = 0) Then
                        msj_ok(MensajeBgWk)
                        ConsultarAsistencia()
                    Else
                        msj_advert(MensajeBgWk)
                    End If
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub BtnReporte_Click(sender As Object, e As EventArgs) Handles BtnReporte.Click
        Try
            Dim frm As New FrmReporteTrabajadoresAsistencia
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class