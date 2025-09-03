Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlSalidasInventario
    Dim cn As New cnVentas

    Dim ds As New DataSet

    Private Sub FrmControlEpp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = Windows.Forms.FormWindowState.Maximized
        cbxestado.SelectedIndex = 0
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        cbxestado.SelectedIndex = 0
        Consultar()
    End Sub
    Private _estado As String
    Private _Idtipodocumento As String
    Sub Consultar()
        'Pasamos todos los parametros y ejecutamos el hilo para cargar la busqueda
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            'GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            _estado = cbxestado.Text
            _Idtipodocumento = 0
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coVentas
            obj.Fechadesde = dtpFechaDesde.Value
            obj.Fechahasta = dtpFechaHasta.Value
            obj.Estado = _estado
            obj.Idtipodocumento = _Idtipodocumento
            obj.NombreProducto = txtProducto.Text
            obj.NombreProveedor = txtProveedor.Text
            ds = New DataSet
            ds = cn.Cn_ConsultarSalidaProductos(obj).Copy
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

                clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ENTREGADO", 18)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "PARCIAL", 18)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "SIN DESPACHO", 18)
            End If
            ' GrupoMasOpcionesBusqueda.Enabled = True
            ToolStrip1.Enabled = True
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try

            With e.Layout.Bands(0)
                .Columns("codpedido").Header.VisiblePosition = 0
                .Columns("codpedido").Header.Caption = "Código Pedido"
                .Columns("codpedido").Width = 130
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True
                .Columns(2).Hidden = True
                .Columns(3).Hidden = True
                .Columns(5).Width = 80
                .Columns(6).Width = 80
                .Columns(7).Width = 80

                .Columns(8).Hidden = True
                .Columns(10).Hidden = True
                .Columns(11).Hidden = True
                .Columns(12).Hidden = True
                .Columns(13).Hidden = True
                .Columns(14).Hidden = True
                .Columns(15).Hidden = True
                .Columns(19).Hidden = True
                .Columns(20).Hidden = True
                .Columns("btnver").Header.Caption = "Cotización"
                .Columns("btnver").Width = 80
                .Columns("btnver").Style = UltraWinGrid.ColumnStyle.Button
                .Columns("btnver").CellButtonAppearance.Image = My.Resources.adjuntar
                .Columns("btnver").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns("btnver").Hidden = True
                .Columns("direccion").Hidden = True
            End With

            With e.Layout.Bands(1)
                .Columns(6).Hidden = True
                .Columns(7).Header.VisiblePosition = 1
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert("La fecha 'Desde' debe ser anterior o igual a la fecha 'Hasta'.")
            Return
        End If
        Consultar()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportarsalidadeinventario.Click
        clsBasicas.ExportarExcel("Lista de Salidas de Productos", dtgListado)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    If dtgListado.ActiveRow.Cells(18).Value.ToString.Equals("SIN DESPACHO") Then
                        If dtgListado.ActiveRow.Cells(19).Value <> "PENDIENTE" Then
                            msj_advert("Salida de Producto no puede ser Anulada por que ya fue " & dtgListado.ActiveRow.Cells(19).Value.ToString)
                        Else
                            Dim f As New FrmAnularOrdendeCompra
                            f.idordencompra = dtgListado.ActiveRow.Cells(0).Value.ToString
                            f.ShowDialog()
                            Consultar()
                        End If
                    Else
                        msj_advert("Salida de Producto no puede ser Anulada por que tiene Recepciones de Productos")
                    End If
                End If

            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevosalidainventario.Click

        Try
            Dim f As New FrmSalidaProducto
            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ConsultarArchivo(codigo As Integer)

        Dim obj As New coVentas
        obj.Codigo = codigo
        cn.Cn_ObtenerArchivoPedidoVenta(obj)


        Dim pdfData As Byte() = obj.ArchivoRecepcion
        If pdfData IsNot Nothing AndAlso pdfData.Length > 0 Then
            Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "PedidoVenta_archivo" & codigo.ToString & ".pdf")

            File.WriteAllBytes(tempFilePath, pdfData)
            Process.Start(tempFilePath)
        Else
            MessageBox.Show("No se encontró el archivo PDF en la base de datos.")
        End If


    End Sub
    Private Sub Dtg_Listado_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            If (e.Cell.Column.Key = "btnver") Then
                If dtgListado.ActiveRow IsNot Nothing Then
                    ConsultarArchivo(dtgListado.ActiveRow.Cells(0).Value.ToString)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class