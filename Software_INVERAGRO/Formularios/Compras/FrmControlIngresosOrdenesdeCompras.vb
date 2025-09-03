Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlIngresosOrdenesdeCompras
    Private productosEnviarCorreo As New List(Of String)
    Dim cn As New cnIngreso
    Dim ds As New DataSet
    Private _estado As String
    Private _Idtipodocumento As String

    Sub ListarTipoDocumento()
        Try
            Dim dt As New DataTable
            dt = cn.Cn_ListarTipoDocumento().Copy
            dt.Columns(1).ColumnName = "Seleccione un Tipo de Documento"

            With cbxtipodocumento
                .DataSource = dt
                .DisplayMember = dt.Columns(1).ColumnName
                .ValueMember = dt.Columns(0).ColumnName
                If (dt.Rows.Count > 0) Then
                    .SelectedValue = dt.Rows(0)(0)
                End If
            End With

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub FrmControlEpp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = Windows.Forms.FormWindowState.Maximized
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        ListarTipoDocumento()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        cbxestado.SelectedIndex = 1
        Consultar()
    End Sub

    Sub Consultar()
        'Pasamos todos los parametros y ejecutamos el hilo para cargar la busqueda
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            _estado = cbxestado.Text
            _Idtipodocumento = cbxtipodocumento.SelectedValue
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coIngreso
            obj.Fechadesde = dtpFechaDesde.Value
            obj.Fechahasta = dtpFechaHasta.Value
            obj.Estado = _estado
            obj.Idtipodocumento = _Idtipodocumento
            obj.NombreProducto = txtProducto.Text
            obj.NombreProveedor = txtProveedor.Text
            ds = New DataSet
            ds = cn.Cn_ConsultarOrdenesCompras(obj).Copy
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        btnConsultar.Enabled = True
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            ds.DataSetName = "tmp"

            Dim relation1 As New DataRelation("tabla_relacion_32", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(6), False)

            ds.Relations.Add(relation1)
            dtgListado.DataSource = ds
            If (ds.Tables(0).Rows.Count > 0) Then
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", 17)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 17)

                clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "RECEPCIONADO", 18)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "PARCIAL", 18)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "SIN RECEPCION", 18)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", 18)

                clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ENVIADO", 19)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "PENDIENTE", 19)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "FACTURADO", 19)
            End If
            dtgListado.DisplayLayout.Bands(0).Columns("correoProveedor").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("correoSolicitante").Hidden = True
            GrupoMasOpcionesBusqueda.Enabled = True
            ToolStrip1.Enabled = True
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            dtgListado.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None
            With e.Layout.Bands(0)
                .Columns("codorden").Header.VisiblePosition = 0
                .Columns("codorden").Header.Caption = "Código Orden"
                .Columns("codorden").Width = 130
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True
                .Columns(2).Hidden = True
                .Columns(3).Hidden = True
                .Columns(4).Hidden = True
                .Columns(5).Width = 80
                .Columns(6).Width = 80
                .Columns(7).Width = 80
                .Columns(12).Header.VisiblePosition = 12
                .Columns(8).Hidden = True
                .Columns(15).Hidden = True
                .Columns("btnver").Header.Caption = "Cotización"
                .Columns("btnver").Width = 80
                .Columns("btnver").Style = UltraWinGrid.ColumnStyle.Button
                .Columns("btnver").CellButtonAppearance.Image = My.Resources.adjuntar
                .Columns("btnver").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns("CON IGV").Header.VisiblePosition = 13
                .Columns("claveApliGoogle").Hidden = True
            End With

            With e.Layout.Bands(1)
                .Columns(6).Hidden = True
                .Columns(8).Hidden = True
                .Columns(9).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(9).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns(10).Hidden = True

                .Columns(12).Header.VisiblePosition = 3
            End With
            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 1)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 10)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 11)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 12)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        If e.Row.Band.Index = 1 Then
            e.Row.Cells(9).Value = "Lotizar"
        End If
    End Sub

    Private Sub Dtg_Listado_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            If (e.Cell.Column.Key = "btnver") Then
                If dtgListado.ActiveRow IsNot Nothing Then
                    ConsultarArchivo(dtgListado.ActiveRow.Cells(0).Value.ToString)
                End If
            Else
                Dim lote As String = e.Cell.Row.Cells("Lote").Value.ToString
                Dim idProducto As Integer = e.Cell.Row.Cells("idProducto").Value.ToString
                Dim nombreProducto As String = e.Cell.Row.Cells("Producto").Value.ToString
                Dim cantidadLotizar As Integer = e.Cell.Row.Cells("Cantidad Recepcionada").Value.ToString
                Dim idIngreso As Integer = e.Cell.Row.Cells("idingreso").Value.ToString
                Dim idUbicacionDestino As Integer = e.Cell.Row.Cells("idubicacion_destino").Value.ToString
                Dim infoLote As String = e.Cell.Row.Cells("Información Lotes").Value.ToString

                If (lote = "NO") Then
                    msj_advert("Este producto no se puede lotizar")
                    Return
                End If

                If (infoLote <> "-") Then
                    msj_advert("Este producto ya fue lotizado")
                    Return
                End If

                Dim f As New FrmLotizarProductos With {
                    .idProducto = idProducto,
                    .nombreProducto = nombreProducto,
                    .cantidadLotizar = cantidadLotizar,
                    .idIngreso = idIngreso,
                    .idUbicacionDestino = idUbicacionDestino
                }
                f.ShowDialog()
                Consultar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        Consultar()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub


    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnularcomprasordencompa.Click
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    ' If dtgListado.ActiveRow.Cells(19).Value = "FACTURADO" And (dtgListado.ActiveRow.Cells(29).Value.ToString = "NO") Then
                    ' msj_advert("Orden de Compra no puede ser Anulada por que ya fue " & dtgListado.ActiveRow.Cells(19).Value.ToString)
                    'Else
                    Dim f As New FrmAnularOrdendeCompra
                        f.idordencompra = dtgListado.ActiveRow.Cells(0).Value.ToString
                        f.ShowDialog()
                        Consultar()
                    ' End If
                End If

            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevocomprasordencompa.Click
        Dim f As New FrmOrdendeCompra
        f.ShowDialog()
        Consultar()
    End Sub

    Private Sub btnRecepcionar_Click(sender As Object, e As EventArgs) Handles btnRecepcionarcomprasordencompa.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            If activeRow.Cells(17).Value = "ANULADO" Then
                msj_advert("Orden de Compra no puede ser Recepcionada porque fue Anulado")
                Return
            End If
            Dim f As New FrmRecepcionProductos
            f._codigo = activeRow.Cells(0).Value.ToString
            f.txtproveedor.Text = activeRow.Cells(7).Value.ToString
            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ConsultarArchivo(codigo As Integer)

        Dim obj As New coIngreso
        obj.Codigo = codigo
        cn.Cn_ConsultarOrdenesComprasArchivoCotizacion(obj)


        Dim pdfData As Byte() = obj.ArchivoRecepcion
        If pdfData IsNot Nothing AndAlso pdfData.Length > 0 Then
            Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "OrdenCompra_archivo" & codigo.ToString & ".pdf")

            File.WriteAllBytes(tempFilePath, pdfData)
            Process.Start(tempFilePath)
        Else
            MessageBox.Show("No se encontró el archivo PDF en la base de datos.")
        End If
    End Sub

    Private Sub btnadjuntar_Click(sender As Object, e As EventArgs) Handles btnadjuntarcomprasordencompa.Click

        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow IsNot Nothing AndAlso dtgListado.ActiveRow.Cells(0).Value IsNot Nothing) Then
                    If (dtgListado.ActiveRow.Cells(19).Value.ToString = "FACTURADO") Then
                        msj_advert("No puede adjuntar Cotizacion a la Orden de Compra por que ya fue " & dtgListado.ActiveRow.Cells(19).Value.ToString)
                        Return
                    End If
                    Dim memorandumId As Integer
                    Integer.TryParse(dtgListado.ActiveRow.Cells(0).Value.ToString(), memorandumId)
                    Dim f As New FrmMantArchivoCotizacionOrdenCompra()
                    f.Idingreso = memorandumId
                    f.ShowDialog()
                Else
                    msj_advert("Seleccione un Registro")
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If
        Catch ex As Exception
            msj_advert("Seleccione un Registro Correcto")
        End Try
    End Sub

    Private Sub btnconfirmar_facturacion_Click(sender As Object, e As EventArgs) Handles btnconfirmar_facturacioncomprasordencompa.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            If (activeRow.Cells(18).Value.ToString = "SIN RECEPCION") And (activeRow.Cells(29).Value.ToString = "NO") Then
                msj_advert("Orden de Compra no puede ser enviada a facturación por que no tiene ninguna recepcion de productos")
                Return
            End If
            If (activeRow.Cells(19).Value.ToString <> "PENDIENTE") Then
                msj_advert("Orden de Compra ya fue " & dtgListado.ActiveRow.Cells(19).Value.ToString)
                Return
            End If

            Dim obj As New coIngreso With {
                .Codigo = activeRow.Cells(0).Value
            }

            If MsgBox("¿Esta Seguro de Confirmar la Facturación de la Orden de Compra Seleccionada?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Ok Then
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_AprobarFacturacionOrdenCompra(obj)
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

    Private Sub btnhistoricorecepciones_Click_1(sender As Object, e As EventArgs) Handles btnhistoricorecepcionescomprasordencompa.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            Dim estadoRecepcion = activeRow.Cells(18).Value.ToString
            If estadoRecepcion = "RECEPCIONADO" OrElse estadoRecepcion = "PARCIAL" Then
                Dim f As New FrmHistoricoRecepcion
                f.lblCodigo.Text = activeRow.Cells(0).Value.ToString
                f.lblcodOrden.Text = activeRow.Cells(22).Value.ToString
                f.lblMotivoTransaccion.Text = activeRow.Cells(4).Value.ToString
                f.lblFechaPedido.Text = DateTime.Parse(activeRow.Cells(5).Value).ToString("dd/MM/yyyy")
                f.lblProveedor.Text = activeRow.Cells(7).Value.ToString
                f.ShowDialog()
            Else
                msj_advert("La Orden de Compra no tiene Recepciones")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub




    Private Sub BtnEnviarCorreo_Click(sender As Object, e As EventArgs) Handles BtnEnviarCorreocomprasordenes.Click
        Try
            Dim activeRow As UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.ChildBands IsNot Nothing AndAlso activeRow.ChildBands.Count > 0 Then
                        productosEnviarCorreo.Clear()

                        For Each childBand In activeRow.ChildBands
                            For Each childRow As Infragistics.Win.UltraWinGrid.UltraGridRow In childBand.Rows
                                Dim producto As String = If(childRow.Cells(0).Value?.ToString(), String.Empty)
                                Dim cantidadValor As Object = childRow.Cells(1).Value
                                Dim cantidad As String = If(IsNumeric(cantidadValor), Convert.ToDecimal(cantidadValor).ToString("F2"), "0.00")

                                productosEnviarCorreo.Add($"    -  {producto} (Cantidad: {cantidad})")
                            Next
                        Next

                        If productosEnviarCorreo.Any() Then
                            Dim frm As New FrmEnviarCorreoArchivoOC With {
                                .productosPedir = productosEnviarCorreo,
                                .correoRemitente = activeRow.Cells("correoSolicitante").Value.ToString(),
                                .correoDestinatario = activeRow.Cells("correoProveedor").Value.ToString(),
                                .idIngreso = activeRow.Cells(0).Value,
                                .fechaPedido = activeRow.Cells("F.Pedido").Value,
                                .claveApliGoogle = activeRow.Cells("claveApliGoogle").Value
                            }
                            frm.ShowDialog()
                            Consultar()
                        Else
                            msj_advert("No se encontraron productos a pedir en este registro")
                        End If
                    Else
                        msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
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



    Private Sub ReporteDeOrdenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeOrdenToolStripMenuItem.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            Dim obj As New coIngreso
            Dim cn As New cnIngreso
            obj.Codigo = activeRow.Cells(0).Value
            Dim ds As New DataSet
            ds = cn.Cn_ReporteOrdendeCompraxCodigo(obj).Copy
            ds.DataSetName = "bd"
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_OrdenCompra.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(ds)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ExportarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportarToolStripMenuItem.Click
        clsBasicas.ExportarExcel("Lista de Ordenes de Compra", dtgListado)
    End Sub

    Private Sub btnFacturasVinculadas_Click(sender As Object, e As EventArgs) Handles btnFacturasVinculadas.Click
        Try
            Dim frm As New FrmReporteFacturasVinculadas
            frm.idIngreso = dtgListado.ActiveRow.Cells(0).Value
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub EditarOrdenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarOrdenToolStripMenuItem.Click
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(19).Value.ToString <> "FACTURADO") Then
                    ' Validar si alguna fila hija tiene Cantidad Recepcionada > 0
                    Dim tieneRecepcionadas As Boolean = False
                    If dtgListado.ActiveRow.ChildBands IsNot Nothing AndAlso dtgListado.ActiveRow.ChildBands.Count > 0 Then
                        For Each childBand In dtgListado.ActiveRow.ChildBands
                            For Each childRow As Infragistics.Win.UltraWinGrid.UltraGridRow In childBand.Rows
                                Dim cantidadRecepcionada As Decimal = 0
                                Decimal.TryParse(childRow.Cells("Cantidad Recepcionada").Value.ToString(), cantidadRecepcionada)
                                If cantidadRecepcionada > 0 Then
                                    tieneRecepcionadas = True
                                    Exit For
                                End If
                            Next
                            If tieneRecepcionadas Then Exit For
                        Next
                    End If

                    If tieneRecepcionadas Then
                        msj_advert("No puede editar la orden porque existen recepciones. Debe anular las recepciones antes de ajustar precio o cantidad.")
                        Return
                    End If

                    Dim f As New FrmAjusteNegativo
                    f._codigo = 0
                    f._idordencompra = dtgListado.ActiveRow.Cells(0).Value
                    f.ShowDialog()
                    Consultar()
                Else
                    msj_advert("No puede editar la orden porque existen recepciones. Debe anular las recepciones antes de ajustar precio o cantidad.")
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FinalizarOrdenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinalizarOrdenToolStripMenuItem.Click
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(19).Value.ToString <> "FACTURADO") Then
                    Dim f As New FrmAjusteNegativo
                    f._codigo = 4
                    f._idordencompra = dtgListado.ActiveRow.Cells(0).Value
                    f.ShowDialog()
                    Consultar()
                Else
                    msj_advert("No se puede finalizar la orden, ya que la orden de compra ha sido facturada.")
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub AjustarOrdenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjustarOrdenToolStripMenuItem.Click
        Try
            If (dtgListado.Rows.Count > 0) Then
                Dim f As New FrmAjusteNegativo
                f._codigo = 3
                f._idordencompra = dtgListado.ActiveRow.Cells(0).Value
                f.ShowDialog()
                Consultar()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class