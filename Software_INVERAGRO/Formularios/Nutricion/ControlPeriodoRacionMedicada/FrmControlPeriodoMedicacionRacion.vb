Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlPeriodoMedicacionRacion
    Dim cn As New cnMedicamentoRacion
    Dim ds As New DataSet

    Private Sub FrmControlPeriodoMedicacionRacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            WindowState = Windows.Forms.FormWindowState.Maximized
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Ptbx_Cargando.Visible = True
            dtpFechaDesde.Value = Now.Date
            dtpFechaHasta.Value = Now.Date
            cmbEstado.SelectedIndex = 0
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BloquearControles()
        GrupoFiltros.Enabled = False
        Ptbx_Cargando.Visible = True
        BarraOpciones.Enabled = False
    End Sub

    Private Sub DesbloquearControles()
        GrupoFiltros.Enabled = True
        Ptbx_Cargando.Visible = False
        BarraOpciones.Enabled = True
    End Sub

    Sub Consultar(Optional ByVal fechaDesde As Date? = Nothing, Optional ByVal fechaHasta As Date? = Nothing)
        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()

            Dim obj As New coMedicamentoRacion With {
                .Estado = cmbEstado.Text
            }
            If fechaDesde.HasValue Then
                obj.FechaInicio = fechaDesde
            Else
                obj.FechaInicio = Nothing
            End If

            If fechaHasta.HasValue Then
                obj.FechaFin = fechaHasta
            Else
                obj.FechaFin = Nothing
            End If

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coMedicamentoRacion = CType(e.Argument, coMedicamentoRacion)

            ds = cn.Cn_ConsultarPeriodoMedicamentoRacion(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(1).ColumnMapping = MappingType.Hidden
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = ds.Tables(0)
            DesbloquearControles()
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estado As Integer = 8
            Dim tipo As Integer = 6

            'estadoPeso
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "FINALIZADO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "CANCELADO", estado)

            'tipo
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.Black, "MEDICACIÓN", tipo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Yellow, Color.Black, "PLUS", tipo)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
                .Columns(tipo).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            If dtpFechaDesde.Value > dtpFechaHasta.Value Then
                msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
                Return
            End If

            Dim fechaDesde As Date? = dtpFechaDesde.Value
            Dim fechaHasta As Date? = dtpFechaHasta.Value
            Consultar(fechaDesde, fechaHasta)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnNuevaMedicacion_Click(sender As Object, e As EventArgs) Handles btnNuevaMedicacionNPeRa.Click
        Try
            Dim f As New FrmRegistrarMedicacionRacion
            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnAmpliarPlazo_Click(sender As Object, e As EventArgs) Handles btnAmpliarPlazoNPeRa.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim estado As String = dtgListado.DisplayLayout.ActiveRow.Cells("Estado").Value

                        If (dtgListado.Rows.Count = 0) Then
                            msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                            Return
                        End If

                        If (estado = "CANCELADO" Or estado = "FINALIZADO") Then
                            msj_advert("EL PERIODO DE MEDICACIÓN YA SE ENCUENTRA CANCELADO O FINALIZADO")
                            Return
                        End If

                        Dim f As New FrmAmpliarPeriodoMedicamentoRacion With {
                            .idPeriodoMedicacion = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value),
                            .fechaInicio = dtgListado.DisplayLayout.ActiveRow.Cells("Fecha de Inicio").Value,
                            .fechaFin = dtgListado.DisplayLayout.ActiveRow.Cells("Fecha de Fin").Value,
                            .ubicacion = dtgListado.DisplayLayout.ActiveRow.Cells("Ubicación").Value,
                            .racion = dtgListado.DisplayLayout.ActiveRow.Cells("Ración").Value
                        }
                        f.ShowDialog()
                        Consultar()
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

    Private Sub btnCancelarMedicacion_Click(sender As Object, e As EventArgs) Handles btnCancelarMedicacionNPeRa.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim estado As String = dtgListado.DisplayLayout.ActiveRow.Cells("Estado").Value

                        If (dtgListado.Rows.Count = 0) Then
                            msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                            Return
                        End If

                        If (estado = "CANCELADO" Or estado = "FINALIZADO") Then
                            msj_advert("El periodo de medicación o plus ya se encuentra cancelado o finalizado")
                            Return
                        End If

                        Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE CANCELAR ESTA MEDICACIÓN / PLUS DE LA RACIÓN?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                        If result = DialogResult.Yes Then
                            Dim obj As New coMedicamentoRacion With {
                                .Codigo = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value)
                            }
                            Dim mensaje As String = cn.Cn_CancelarPeriodoMedicamentoRacionPlus(obj)

                            If (obj.Coderror = 0) Then
                                msj_ok(mensaje)
                                Consultar()
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

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportarNPeRa.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("MEDICACION DE RACIONES", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnActivarMedicacionPlus_Click(sender As Object, e As EventArgs) Handles BtnActivarMedicacionPlus.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim estado As String = dtgListado.DisplayLayout.ActiveRow.Cells("Estado").Value

                        If (dtgListado.Rows.Count = 0) Then
                            msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                            Return
                        End If

                        If (estado = "ACTIVO") Then
                            msj_advert("El periodo de medicación o plus se encuentra activo")
                            Return
                        End If

                        Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ACTIVAR ESTA MEDICACIÓN / PLUS DE LA RACIÓN?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                        If result = DialogResult.Yes Then
                            Dim obj As New coMedicamentoRacion With {
                                .Codigo = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value)
                            }
                            Dim mensaje As String = cn.Cn_ActivarPeriodoMedicamentoRacionPlus(obj)

                            If (obj.Coderror = 0) Then
                                msj_ok(mensaje)
                                Consultar()
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class