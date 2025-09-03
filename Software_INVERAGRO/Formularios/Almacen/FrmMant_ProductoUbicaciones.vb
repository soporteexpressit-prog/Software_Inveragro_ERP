Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmMant_ProductoUbicaciones

    Private _idubicacion As Integer
    Dim tbtmp As New DataTable

    Sub ConsultarItems()
        'Pasamos todos los parametros y ejecutamos el hilo para cargar la busqueda
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            'GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub



    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coProductos
            Dim cn As New cnProducto
            obj.Descripcion = ""
            tbtmp = cn.Cn_ConsultarStockAlmacenes(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        ' btnBuscar.Enabled = True
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtg_Listado.DataSource = CType(e.Result, DataTable)

            clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Red, Color.White, "INACTIVO", 7)
            clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Green, Color.White, "ACTIVO", 7)
            'GrupoMasOpcionesBusqueda.Enabled = True
            ToolStrip1.Enabled = True
        End If
    End Sub

    Private Sub FrmMant_Producto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            WindowState = Windows.Forms.FormWindowState.Maximized
            clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtg_Listado)
            ConsultarItems()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtg_ListaProducto_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtg_Listado.InitializeLayout
        'Formateamos y le damos estilo a nuestra grilla
        Try
            If (dtg_Listado.Rows.Count = 0) Then
            Else
                With e.Layout.Bands(0)

                    .Columns(0).Width = 70
                    .Columns(5).Hidden = True
                    .Columns(6).Hidden = True
                    '.Columns(8).Header.VisiblePosition = 16
                    '.Columns(17).Header.VisiblePosition = 10
                    '.Columns(14).Header.VisiblePosition = 5

                    '.Columns(18).Header.VisiblePosition = 6
                    '.Columns(19).Header.VisiblePosition = 7

                    '.Columns(20).Header.VisiblePosition = 6
                End With

                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtg_Listado, e, 1)
                'clsBasicas.SumarTotales_Formato(dtg_Listado, e, 10)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub btnexportar_excel_Click(sender As Object, e As EventArgs) Handles btnexportar_excelstockalmacen.Click
        'Validamos sin existen registros, si es asi exportamos a excel toda la lista de la grilla
        Try
            clsBasicas.ExportarExcel("Lista de Productos", dtg_Listado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs)
        'Ptbx_Cargando.Visible = True
        'btnBuscar.Enabled = False
        'ConsultarItems()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2stockalmacen.Click

        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If dtg_Listado.ActiveRow.Cells(0).Value.ToString <> 0 Then
                    Dim f As New FrmHistoricoCompraPorProducto
                    f.lblNombreProducto.Text = dtg_Listado.ActiveRow.Cells(3).Value.ToString
                    f.lblCodigo.Text = dtg_Listado.ActiveRow.Cells(0).Value.ToString
                    f.ShowDialog()
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

    Private Sub ckagrupar_columnas_CheckedChanged(sender As Object, e As EventArgs)
        'If ckagrupar_columnas.Checked Then
        '    dtg_Listado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        '    dtg_Listado.DisplayLayout.GroupByBox.Hidden = False
        '    btnBuscar.Enabled = False
        'Else
        '    dtg_Listado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal
        '    dtg_Listado.DisplayLayout.GroupByBox.Hidden = True
        '    dtg_Listado.DisplayLayout.Bands(0).SortedColumns.Clear() ' Eliminar agrupamiento y orden
        '    btnBuscar.Enabled = True
        'End If
    End Sub

    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtg_Listado, isFilterActive)
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If ToolStripButton2.Checked Then
            ' Si está marcado, restauramos la vista de agrupamiento
            dtg_Listado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
            dtg_Listado.DisplayLayout.GroupByBox.Hidden = False
        Else
            ' Si no está marcado, cambiamos a la vista horizontal y ocultamos el GroupByBox
            dtg_Listado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal
            dtg_Listado.DisplayLayout.GroupByBox.Hidden = True
            dtg_Listado.DisplayLayout.Bands(0).SortedColumns.Clear() ' Eliminar agrupamiento y orden
        End If

        ' Alternar el estado de ToolStripButton2
        ToolStripButton2.Checked = Not ToolStripButton2.Checked

    End Sub

    Private Sub UltraGroupBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub UltraGroupBox1_Click_1(sender As Object, e As EventArgs)

    End Sub
End Class