Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlPedidosRequerimientos
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
    Sub Consultar()
        'Pasamos todos los parametros y ejecutamos el hilo para cargar la busqueda
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            _estado = cbxestado.Text
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coVentas
            obj.Fechadesde = dtpFechaDesde.Value
            obj.Fechahasta = dtpFechaHasta.Value
            obj.Estado = _estado
            obj.NombreProducto = txtProducto.Text
            obj.Iduser = VP_IdUser
            ds = New DataSet
            ds = cn.Cn_ConsultarSolicitudesRequerimientos(obj).Copy
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

            Dim relation1 As New DataRelation("tabla_relacion_32", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(5), False)

                ds.Relations.Add(relation1)
            dtgListado.DataSource = ds
            If (ds.Tables(0).Rows.Count > 0) Then
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", 8)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 8)

                clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ENTREGADO", 9)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "PARCIAL", 9)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "SIN DESPACHO", 9)
            End If
            GrupoMasOpcionesBusqueda.Enabled = True
            ToolStrip1.Enabled = True
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try

            With e.Layout.Bands(0)
                .Columns("codpedido").Header.VisiblePosition = 0
                .Columns("codpedido").Header.Caption = "Código Pedido"
                .Columns("codpedido").Width = 130
                '.Columns(0).Hidden = True
                '.Columns(1).Hidden = True
                '.Columns(2).Hidden = True
                '.Columns(3).Hidden = True
                '.Columns(4).Hidden = True
                '.Columns(5).Width = 80
                '.Columns(6).Width = 80
                '.Columns(7).Width = 80

                '.Columns(9).Hidden = True
                '.Columns(15).Hidden = True
                '.Columns("btnver").Hidden = True
                '.Columns("btnver").Header.Caption = "Cotización"
                '.Columns("btnver").Width = 80
                '.Columns("btnver").Style = UltraWinGrid.ColumnStyle.Button
                '.Columns("btnver").CellButtonAppearance.Image = My.Resources.adjuntar
                '.Columns("btnver").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                '.Columns("btnver").Hidden = True
                '.Columns("direccion").Hidden = True
            End With

            'With e.Layout.Bands(1)
            'End With
            e.Layout.Bands(0).Summaries.Clear()
            'clsBasicas.Totales_Formato(dtgListado, e, 1)
            'clsBasicas.SumarTotales_Formato(dtgListado, e, 10)
            'clsBasicas.SumarTotales_Formato(dtgListado, e, 11)
            'clsBasicas.SumarTotales_Formato(dtgListado, e, 12)
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

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportaratencionreque.Click
        clsBasicas.ExportarExcel("Lista de Requerimientos", dtgListado)
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



    Private Sub btnhistoricorecepciones_Click_1(sender As Object, e As EventArgs) Handles btnhistoricorecepcionesatencionreque.Click

        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            Dim f As New FrmHistoricoRecepcionAtenciones
            'f.btnconfirmar_entrega.Visible = False
            f.lblCodigo.Text = activeRow.Cells(0).Value.ToString
            f.lblcodOrden.Text = activeRow.Cells(10).Value.ToString
            f.lblMotivoTransaccion.Text = activeRow.Cells(1).Value.ToString
            f.lblFechaPedido.Text = DateTime.Parse(activeRow.Cells(2).Value).ToString("dd/MM/yyyy")
            f.lblProveedor.Text = activeRow.Cells(4).Value.ToString
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub



    Private Sub btnRecepcionar_Click(sender As Object, e As EventArgs) Handles btnRecepcionaratencionreque.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            If activeRow.Cells(8).Value = "ANULADO" Then
                msj_advert("El Requerimiento no puede ser Atendido porque fue Anulado")
                Return
            End If

            If (activeRow.Cells(9).Value.ToString <> "ENTREGADO") Then
                Dim f As New FrmAtenderRequerimientos
                f._codigo = activeRow.Cells(0).Value.ToString
                f.txtcliente.Text = activeRow.Cells(4).Value.ToString
                f.ShowDialog()
                Consultar()
            Else
                msj_advert("Ya fue Entregado todos los productos")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxalmacen_SelectionChangeCommitted(sender As Object, e As EventArgs)
        Consultar()
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class