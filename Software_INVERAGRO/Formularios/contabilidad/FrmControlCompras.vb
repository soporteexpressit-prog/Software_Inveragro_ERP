Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlCompras
    Dim cn As New cnIngreso

    Dim ds As New DataSet

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
        cbxestado.SelectedIndex = 0
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        ListarTipoDocumento()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        cbxestado.SelectedIndex = 1
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
            ds = cn.Cn_ConsultarCompras(obj).Copy
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

            Dim relation1 As New DataRelation("tabla_relacion_32", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(3), False)

                ds.Relations.Add(relation1)
            dtgListado.DataSource = ds
            If (ds.Tables(0).Rows.Count > 0) Then

                clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", 17)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 17)

                clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "RECEPCIONADO", 18)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "PARCIAL", 18)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "SIN RECEPCION", 18)


            End If
            'GrupoMasOpcionesBusqueda.Enabled = True
            ToolStrip1.Enabled = True
        End If
    End Sub
    Sub ConsultarArchivo(codigo As Integer)

        Dim obj As New coIngreso
        obj.Codigo = codigo
        cn.Cn_ConsultarOrdenesComprasArchivoCotizacion(obj)


        Dim pdfData As Byte() = obj.ArchivoRecepcion
        If pdfData IsNot Nothing AndAlso pdfData.Length > 0 Then
            Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "DocCotizacion_compra" & codigo.ToString & ".pdf")

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
                    ConsultarArchivo(dtgListado.ActiveRow.Cells("idordencompra").Value.ToString)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try

            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(6).Hidden = True
                .Columns(8).Hidden = True
                .Columns(18).Hidden = True
                .Columns(20).Hidden = True
                .Columns("btnver").Header.Caption = "Cotización"
                .Columns("btnver").Width = 80
                .Columns("btnver").Style = UltraWinGrid.ColumnStyle.Button
                .Columns("btnver").CellButtonAppearance.Image = My.Resources.adjuntar
                .Columns("btnver").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns("idordencompra").Hidden = True
                .Columns("CON IGV").Header.VisiblePosition = 13
            End With

            With e.Layout.Bands(1)
                .Columns(3).Hidden = True
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
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        Consultar()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportarctfoc.Click
        clsBasicas.ExportarExcel("Lista de Facturacion de Ordenes de Compra", dtgListado)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs)
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim obj As New coCotizacion
                    obj.Codigo = dtgListado.ActiveRow.Cells(0).Value.ToString
                    Dim MensajeBgWk As String = ""
                    'MensajeBgWk = cn.Cn_Anular(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(MensajeBgWk)
                        Consultar()
                    Else
                        msj_advert(MensajeBgWk)
                    End If
                End If
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub ImprimirListado()
        'Generamos el Reporte de Inventario
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            ds.DataSetName = "bd"
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_Cotizaciones.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(ds)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ReporteGneralToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ImprimirListado()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoctfoc.Click
        Dim f As New FrmBuscarOrdenesCompraPendientesFacturacion
        f.ShowDialog()
        Consultar()
    End Sub

    Private Sub btnRecepcionar_Click(sender As Object, e As EventArgs)
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            If (activeRow.Cells(17).Value.ToString <> "RECEPCIONADO") Then
                Dim f As New FrmRecepcionProductos
                f._codigo = activeRow.Cells(0).Value.ToString
                f.txtproveedor.Text = activeRow.Cells(7).Value.ToString
                f.ShowDialog()
            Else
                msj_advert("Ya fue recepcionado todos los productos")
                    End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Try
            If dtgListado.ActiveRow IsNot Nothing AndAlso dtgListado.ActiveRow.Cells(0).Value IsNot Nothing Then
                ' Pregunta de confirmación
                Dim respuesta As DialogResult = MessageBox.Show("¿Realmente desea anular la factura de la orden de compra seleccionada?", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If respuesta = DialogResult.Yes Then
                    Dim obj As New coIngreso
                    obj.Codigo = dtgListado.ActiveRow.Cells(0).Value.ToString()
                    Dim mensaje As String = cn.Cn_anularfacturaordencompra(obj)
                    If obj.Coderror = 0 Then
                        msj_ok(mensaje)
                        Consultar() ' Refresca la grilla si fue exitoso
                    Else
                        msj_advert(mensaje)
                    End If
                End If
            Else
                msj_advert("Seleccione un registro válido.")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

End Class