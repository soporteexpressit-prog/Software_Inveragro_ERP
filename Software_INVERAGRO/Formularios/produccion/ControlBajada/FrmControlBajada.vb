Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmControlBajada
    Dim cn As New cnControlLoteDestete
    Dim ds As New DataSet
    Dim flag As Boolean = False
    Dim totalAnimales As Integer = 0
    Private selectedParentRows As New List(Of UltraGridRow)
    Private selectedIds As New List(Of String)

    Private Sub FrmControlBajada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
            Consultar()
        Catch ex As Exception
            msj_advert(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        BarraNavegacion.Enabled = False
        GrupoFiltros.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        BarraNavegacion.Enabled = True
        GrupoFiltros.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()
            flag = True

            Dim obj As New coControlLoteDestete With {
                .Anio = CInt(CmbAnios.Text),
                .IdPlantel = CmbUbicacion.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlantelesEngorde().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbUbicacion
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)

            ds = cn.Cn_ConsultarBajadaLotexAnio(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns("idLote").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("idPlantel").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("Fecha Apertura").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("Fecha Cierre").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("Plantel").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("edadMinimaDepuracion").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idLote").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idMovimientoBajada").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idUbicacionSalida").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idUbicacionLlegada").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("Lote").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idLoteOrigen").ColumnMapping = MappingType.Hidden
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
            DesbloquearControladores()
            Colorear()
            ColorearSubItems()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estadoBajada As Integer = 9

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ENVIADO", estadoBajada)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estadoBajada)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estadoBajada).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub ColorearSubItems()
        If (dtgListado.Rows.Count > 0) Then
            For Each row As UltraGridRow In dtgListado.Rows
                For Each childRow As UltraGridRow In row.ChildBands(0).Rows
                    Dim estadoCell As UltraGridCell = childRow.Cells("Recepción")
                    Dim tipoCell As UltraGridCell = childRow.Cells("Tipo Movimiento")

                    Select Case estadoCell.Text
                        Case "SI"
                            With estadoCell.Appearance
                                .BackColor = Color.Green
                                .ForeColor = Color.White
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With estadoCell.ActiveAppearance
                                .BackColor = Color.Green
                                .ForeColor = Color.White
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With estadoCell.SelectedAppearance
                                .BackColor = Color.Green
                                .ForeColor = Color.White
                                .FontData.Bold = DefaultableBoolean.True
                            End With

                        Case "NO"
                            With estadoCell.Appearance
                                .BackColor = Color.LightGray
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With estadoCell.ActiveAppearance
                                .BackColor = Color.LightGray
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With estadoCell.SelectedAppearance
                                .BackColor = Color.LightGray
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                    End Select

                    Select Case tipoCell.Text
                        Case "ENVIO"
                            With tipoCell.Appearance
                                .BackColor = Color.LightSkyBlue
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With tipoCell.ActiveAppearance
                                .BackColor = Color.LightSkyBlue
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With tipoCell.SelectedAppearance
                                .BackColor = Color.LightSkyBlue
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With

                        Case "RETORNO"
                            With tipoCell.Appearance
                                .BackColor = Color.LightSalmon
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With tipoCell.ActiveAppearance
                                .BackColor = Color.LightSalmon
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With tipoCell.SelectedAppearance
                                .BackColor = Color.LightSalmon
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                    End Select
                Next
            Next

            With dtgListado.DisplayLayout.Bands(1)
                .Columns("Recepción").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Tipo Movimiento").CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub BtnRetornarCerdas_Click(sender As Object, e As EventArgs) Handles BtnRetornarCerdascontrolbajadapro.Click
        Dim activeRow As UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then

                    If selectedParentRows.Count = 0 Then
                        msj_advert("seleccione un registro con doble clic")
                        Return
                    End If

                    Dim frm As New FrmRetornarChanchillasPuras With {
                        .listaIdsLotes = ObtenerIdsSeleccionadosComoString(),
                        .edadLote = CInt(activeRow.Cells("Edad").Value),
                        .idPlantelSalida = CInt(activeRow.Cells("idPlantel").Value)
                    }
                    frm.ShowDialog()
                    LimpiarSelecciones()
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
    End Sub

    Private Sub BtnExportarControlCerda_Click(sender As Object, e As EventArgs) Handles BtnExportarControlCerdacontrolbajadapro.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL-BAJADAS", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If flag Then
            Consultar()
        End If
    End Sub

    Private Sub BtnConfirmarBajada_Click(sender As Object, e As EventArgs) Handles BtnConfirmarBajada.Click
        Try
            Dim filaSeleccionada As UltraGridRow = dtgListado.ActiveRow

            If filaSeleccionada Is Nothing Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Exit Sub
            End If

            If Not filaSeleccionada.IsDataRow Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            ElseIf filaSeleccionada.Band.Index = 0 Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILAS_CONTENIDAS"))
            Else

                Dim idLote As Integer = CInt(filaSeleccionada.Cells("idLote").Value)
                Dim lote As String = filaSeleccionada.Cells("Lote").Value.ToString
                Dim idMovimientoBajada As Integer = CInt(filaSeleccionada.Cells("idMovimientoBajada").Value)
                Dim plantelSalida As String = filaSeleccionada.Cells("Plantel Salida").Text
                Dim idUbicacionSalida As String = CInt(filaSeleccionada.Cells("idUbicacionSalida").Value)
                Dim idUbicacionLlegada As String = CInt(filaSeleccionada.Cells("idUbicacionLlegada").Value)
                Dim recepcion As String = filaSeleccionada.Cells("Recepción").Text

                If recepcion = "SI" Then
                    msj_advert("No se puede confirmar la bajada, porque ya fue confirmada")
                    Return
                End If

                Dim frm As New FrmMortalidadTransporteBajada With {
                    .idLote = idLote,
                    .idPlantel = idUbicacionLlegada,
                    .valorPlantelSalida = plantelSalida,
                    .valorLote = lote,
                    .codigo = idMovimientoBajada
                }
                frm.ShowDialog()
                Consultar()
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCancelarBajada_Click(sender As Object, e As EventArgs) Handles BtnCancelarBajada.Click
        Try
            Dim filaSeleccionada As UltraGridRow = dtgListado.ActiveRow

            If filaSeleccionada Is Nothing Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Exit Sub
            End If

            If Not filaSeleccionada.IsDataRow Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            ElseIf filaSeleccionada.Band.Index = 0 Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILAS_CONTENIDAS"))
            Else
                Dim idLote As Integer = CInt(filaSeleccionada.Cells("idLote").Value)
                Dim idUbicacionLlegada As String = CInt(filaSeleccionada.Cells("idUbicacionLlegada").Value)
                Dim idMovimientoBajada As Integer = CInt(filaSeleccionada.Cells("idMovimientoBajada").Value)

                If (MessageBox.Show("¿ESTÁ SEGURO QUE DESEA CANCELAR LA BAJADA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim obj As New coControlLoteDestete With {
                    .IdLote = idLote,
                    .IdPlantel = idUbicacionLlegada,
                    .IdMovimientoBajada = idMovimientoBajada
                }

                Dim MensajeBgWk As String = cn.Cn_CancelarBajada(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Consultar()
                Else
                    msj_advert(MensajeBgWk)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCancelarConfirmacion_Click(sender As Object, e As EventArgs) Handles BtnCancelarConfirmacion.Click
        Try
            Dim filaSeleccionada As UltraGridRow = dtgListado.ActiveRow

            If filaSeleccionada Is Nothing Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Exit Sub
            End If

            If Not filaSeleccionada.IsDataRow Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            ElseIf filaSeleccionada.Band.Index = 0 Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILAS_CONTENIDAS"))
            Else
                Dim recepcion As String = filaSeleccionada.Cells("Recepción").Text
                Dim idLote As Integer = CInt(filaSeleccionada.Cells("idLote").Value)
                Dim idUbicacionLlegada As String = CInt(filaSeleccionada.Cells("idUbicacionLlegada").Value)
                Dim idMovimientoBajada As Integer = CInt(filaSeleccionada.Cells("idMovimientoBajada").Value)

                If recepcion = "NO" Then
                    msj_advert("No se puede cancelar la confirmación. Aún no se ha confirmado la recepción de la bajada")
                    Return
                End If

                If (MessageBox.Show("¿ESTÁ SEGURO QUE DESEA CANCELAR LA CONFIRMACIÓN DE LLEGADA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim obj As New coControlLoteDestete With {
                    .IdLote = idLote,
                    .IdMovimientoBajada = idMovimientoBajada,
                    .IdPlantel = idUbicacionLlegada
                }

                Dim MensajeBgWk As String = cn.Cn_CancelarConfirmacionBajada(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Consultar()
                Else
                    msj_advert(MensajeBgWk)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ConsultarxIdCorral(idMovimientoBajada As Integer)
        Try
            Dim obj As New coControlLoteDestete With {
                .IdMovimientoBajada = idMovimientoBajada
            }
            Dim dt As New DataTable
            dt = cn.Cn_ConsultarPesoLotexIdMovimiento(obj).Copy
            If (dt.Rows.Count > 0) Then
                totalAnimales = dt.Rows(0)("TotalAnimales").ToString()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If e.Cell Is Nothing OrElse e.Cell.Row Is Nothing Then
                Return
            End If

            Dim clickedRow As UltraGridRow = e.Cell.Row

            If clickedRow.IsDataRow AndAlso clickedRow.ParentRow Is Nothing Then
                Dim firstColumnValue As String = clickedRow.Cells(0).Value.ToString()
                Dim totalPuras As Integer = CInt(clickedRow.Cells("Total Puras").Value)
                Dim totalCerdas As Integer = CInt(clickedRow.Cells("Total Camborough").Value)

                If totalPuras = 0 AndAlso totalCerdas = 0 Then
                    msj_advert("No hay chanchillas para retornar en este lote")
                    Return
                End If

                If selectedParentRows.Contains(clickedRow) Then
                    clickedRow.Appearance.BackColor = Color.White
                    selectedParentRows.Remove(clickedRow)

                    selectedIds.Remove(firstColumnValue)
                Else
                    clickedRow.Appearance.BackColor = Color.LightSkyBlue
                    selectedParentRows.Add(clickedRow)

                    selectedIds.Add(firstColumnValue)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Function ObtenerIdsSeleccionadosComoString() As String
        Return String.Join(",", selectedIds)
    End Function

    Private Sub LimpiarSelecciones()
        For Each row As UltraGridRow In selectedParentRows
            If Not row Is Nothing Then
                row.Appearance.BackColor = Color.White
            End If
        Next
        selectedParentRows.Clear()
        selectedIds.Clear()
    End Sub

    Private Sub FrmControlBajada_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BtnReporteGeneral_Click(sender As Object, e As EventArgs) Handles BtnReporteGeneral.Click
        Try
            Dim frm As New FrmReporteBajada
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnConfirmarPeso_Click(sender As Object, e As EventArgs) Handles BtnConfirmarPeso.Click
        Try
            Dim filaSeleccionada As UltraGridRow = dtgListado.ActiveRow
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow

            If filaSeleccionada Is Nothing Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Exit Sub
            End If

            If Not filaSeleccionada.IsDataRow Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            ElseIf filaSeleccionada.Band.Index = 0 Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILAS_CONTENIDAS"))
            Else
                Dim idLote As Integer = CInt(filaSeleccionada.Cells("idLoteOrigen").Value)
                Dim idUbicacionSalida As String = CInt(filaSeleccionada.Cells("idUbicacionSalida").Value)
                Dim idMovimientoBajada As Integer = CInt(filaSeleccionada.Cells("idMovimientoBajada").Value)
                ConsultarxIdCorral(idMovimientoBajada)

                Dim frm As New FrmRegistrarPesoBajada With {
                    .cantidadAnimales = totalAnimales,
                    .idLote = idLote,
                    .idPlantelSalida = idUbicacionSalida
                }
                frm.ShowDialog()
                Consultar()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCancelarPeso_Click(sender As Object, e As EventArgs) Handles BtnCancelarPeso.Click
        Try
            Dim filaSeleccionada As UltraGridRow = dtgListado.ActiveRow
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow

            If filaSeleccionada Is Nothing Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Exit Sub
            End If

            If Not filaSeleccionada.IsDataRow Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            ElseIf filaSeleccionada.Band.Index = 0 Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILAS_CONTENIDAS"))
            Else
                Dim idLote As Integer = CInt(filaSeleccionada.Cells("idLoteOrigen").Value)

                If (MessageBox.Show("¿ESTÁ SEGURO DE CANCELAR PESOS BAJADA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim obj As New coControlLoteDestete With {
                    .IdLote = idLote
                }

                Dim MensajeBgWk As String = cn.Cn_CancelarPesosBajada(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Consultar()
                Else
                    msj_advert(MensajeBgWk)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class