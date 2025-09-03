Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win


Public Class FrmRecepcionOrdenCompraProducto
    Public lblCodigo As Integer
    Private productosEnviarCorreo As New List(Of String)
    Dim cn As New cnIngreso
    Dim ds As New DataSet
    Private _estado As String
    Private _Idtipodocumento As String
    Private WithEvents BackgroundWorker1 As New System.ComponentModel.BackgroundWorker


    Private Sub FrmControlEpp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = Windows.Forms.FormWindowState.Maximized
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub

    Sub Consultar()
        'Pasamos todos los parametros y ejecutamos el hilo para cargar la busqueda
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coIngreso
            obj.Fechadesde = dtpFechaDesde.Value
            obj.Fechahasta = dtpFechaHasta.Value
            obj.Idproveedor = lblCodigo
            ds = New DataSet
            ds = cn.Cn_Consultarxproductoordencompra(obj).Copy
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


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportarcomprasordencompa.Click
        clsBasicas.ExportarExcel("Lista de Ordenes de Compra", dtgListado)
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


    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        Consultar()
    End Sub
End Class