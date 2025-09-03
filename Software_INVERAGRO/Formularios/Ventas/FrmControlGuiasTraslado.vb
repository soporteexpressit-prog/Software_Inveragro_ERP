Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmControlGuiasTraslado
    Dim cn As New cnVentas
    Dim ds As New DataSet
    Private Sub FrmHistoricoRecepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtpFechaDesde.Value = Now.Date
            dtpFechaHasta.Value = Now.Date
            cbxestado.SelectedIndex = 1
            Consultar()
            clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListado)
            btnreporteGuiatrasladoventas.Visible = False
            btngenerar_ajuste_irrecuperableGuiatrasladoventas.Visible = False
            btnconfirmar_entregaGuiatrasladoventas.Visible = False
            btngenerar_ventaGuiatrasladoventas.Visible = False
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub Consultar()
        Dim obj As New coVentas
        obj.Fechadesde = dtpFechaDesde.Value
        obj.Fechahasta = dtpFechaHasta.Value
        obj.Estado = cbxestado.Text
        ds = New DataSet
        ds = cn.Cn_ConsultarGuiasTrasladoPedidosCerdo(obj).Copy

        ds.DataSetName = "tmp"

        Dim relation1 As New DataRelation("tb_relacion1", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(0), False)

        ds.Relations.Add(relation1)
        dtgListado.DataSource = ds

        dtgListado.DisplayLayout.Bands(1).Columns(0).Hidden = True

        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "Sin PDF", 21)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "Con PDF", 21)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "OMITIDO", 21)

        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", 17)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.OrangeRed, Color.White, "PENDIENTE", 17)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ENTREGADO", 17)

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub


    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        If e.Row.Band.Index = 0 Then
            Dim colVerPDF As Infragistics.Win.UltraWinGrid.UltraGridColumn
            If dtgListado.DisplayLayout.Bands(0).Columns.Exists("Ver PDF") Then
                colVerPDF = dtgListado.DisplayLayout.Bands(0).Columns("Ver PDF")
                colVerPDF.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerPDF.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                If Not e.ReInitialize Then
                    e.Row.Cells("Ver PDF").Value = "Ver Archivo"
                    e.Row.Cells("Ver PDF").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                End If
            End If
        End If
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            With dtgListado
                If (e.Cell.Column.Key = "Ver PDF") Then

                    Dim estadoPDF As String = .ActiveRow.Cells("Estado PDF").Value.ToString()
                    If estadoPDF = "Sin PDF" Then
                        msj_advert("EL REGISTRO NO TIENE DOCUMENTO EN ADJUNTO")
                        Return
                    End If

                    Dim idRecepcion As Integer = CInt(.ActiveRow.Cells(0).Value)
                    Dim imagenData As Byte() = cn.Cn_ObtenerArchivo(idRecepcion)

                    If imagenData IsNot Nothing AndAlso imagenData.Length > 0 Then
                        Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "documento.pdf")

                        ' Guarda la imagen en el disco
                        File.WriteAllBytes(tempFilePath, imagenData)

                        ' Abre la imagen en el visor de imágenes predeterminado
                        Process.Start(tempFilePath)
                    Else
                        MessageBox.Show("No se encontró la imagen en la base de datos.")
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAnularguia_Click(sender As Object, e As EventArgs) Handles btnAnularguiaGuiatrasladoventas.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            If activeRow.Cells("Estado").Value.ToString.Equals("ANULADO") Then
                msj_advert("Guia de Traslado ya fue Anulado")
            Else
                If activeRow.Cells(17).Value.ToString.Equals("SI") Then
                    msj_advert("Guia de Traslado no puede ser Anulada por que tiene Ventas o Irrecuperaples generado por el Conductor")
                Else
                    If activeRow.Cells("Estado").Value <> "PENDIENTE" Then
                        msj_advert("Guia de Traslado no puede ser Anulada por que ya fue " & activeRow.Cells(14).Value.ToString)
                    Else
                        Dim f As New FrmAnularGuiaPedido
                        f.idguia = activeRow.Cells(0).Value.ToString
                        f.ShowDialog()
                        Consultar()
                    End If
                End If
            End If

        Catch ex As Exception
            msj_advert("Seleccione un Registro Correcto")
        End Try
    End Sub

    Private Sub btnconfirmar_entrega_Click(sender As Object, e As EventArgs) Handles btnconfirmar_entregaGuiatrasladoventas.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            If (activeRow.Cells("Estado").Value.ToString = "ANULADO") Then
                msj_advert("La Guia de Traslado ya fue ANULADO")
                Return
            End If
            If (activeRow.Cells("Estado").Value.ToString = "ENTREGADO") Then
                msj_advert("La Guia de Traslado ya fue ENTREGADO")
                Return
            End If

            Dim obj As New coVentas
            obj.Codigo = activeRow.Cells(0).Value

            If MsgBox("¿Esta Seguro de Confirmar la Guia Seleccionada?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Ok Then
                Dim f As New FrmConfirmarGuiaTraslado
                f.id = activeRow.Cells(0).Value.ToString
                f.ShowDialog()
                Consultar()

            End If

        Catch ex As Exception
            msj_advert("Seleccione un Registro Correcto")
        End Try
    End Sub

    Private Sub btngenerar_venta_Click(sender As Object, e As EventArgs) Handles btngenerar_ventaGuiatrasladoventas.Click

        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            If (activeRow.Cells("Estado").Value.ToString = "ANULADO") Then
                msj_advert("La Guia de Traslado ya fue ANULADO")
                Return
            End If
            If (activeRow.Cells("Estado").Value.ToString = "ENTREGADO") Then
                msj_advert("La Guia de Traslado ya fue ENTREGADA")
                Return
            End If
            If MsgBox("¿Esta Seguro de Registrar Pedido de Venta anexando a esta Guia Seleccionada?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Ok Then
                Dim f As New FrmPedidoVentaDirectaCerdosxConductor
                f._idguia = activeRow.Cells(0).Value.ToString
                f.ShowDialog()
                Consultar()
            End If

        Catch ex As Exception
            msj_advert("Seleccione un Registro Correcto")
        End Try
    End Sub

    Private Sub btnreporte_Click(sender As Object, e As EventArgs) Handles btnreporteGuiatrasladoventas.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            Dim obj As New coIngreso
            Dim cn As New cnIngreso
            obj.Codigo = activeRow.Cells(0).Value.ToString
            Dim ds As New DataSet
            ds = cn.Cn_ReporteGuiaTrasladoVentaxCodigo(obj).Copy
            ds.DataSetName = "bd"
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_GuiaTraslado.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(ds)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try

    End Sub

    Private Sub btngenerar_ajuste_irrecuperable_Click(sender As Object, e As EventArgs) Handles btngenerar_ajuste_irrecuperableGuiatrasladoventas.Click

        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            If (activeRow.Cells("Estado").Value.ToString = "ANULADO") Then
                msj_advert("La Guia de Traslado ya fue ANULADO")
                Return
            End If
            If (activeRow.Cells("Estado").Value.ToString = "ENTREGADO") Then
                msj_advert("La Guia de Traslado ya fue ENTREGADA")
                Return
            End If
            If MsgBox("¿Esta Seguro de Registrar Ajuste por Irrecuperable anexando a esta Guia Seleccionada?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Ok Then
                Dim f As New FrmPedidoVentaAjusteIrrecuperableCerdos
                f._idguia = activeRow.Cells(0).Value.ToString
                f.ShowDialog()
                Consultar()
            End If

        Catch ex As Exception
            msj_advert("Seleccione un Registro Correcto")
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert("La fecha 'Desde' debe ser anterior o igual a la fecha 'Hasta'.")
            Return
        End If
        Consultar()
    End Sub

    Private Sub btnNuevoVmopeve_Click(sender As Object, e As EventArgs) Handles btnNuevaGuiatrasladoventas.Click
        Dim f As New FrmRecepcionProductosPedidoVenta
        f._transferencia = "NO"
        f.ShowDialog()
        Consultar()
    End Sub

    Private Sub ToolStripButton1Rrhhctrlinyac_Click(sender As Object, e As EventArgs) Handles btnadjuntarguiatrasladoMODUVENTA.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim guiaid As Integer
                Integer.TryParse(dtgListado.ActiveRow.Cells(0).Value.ToString(), guiaid)
                Dim f As New Frmagregarpdfguiatraslado()
                f.guiaid = guiaid
                f.ShowDialog()
                Consultar()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            dtgListado.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None
            If (dtgListado.Rows.Count = 0) Then
            Else
                With e.Layout.Bands(0)

                    .Columns(0).Hidden = True
                    .Columns(6).Hidden = True
                    .Columns(7).Hidden = True
                End With

                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 1)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class