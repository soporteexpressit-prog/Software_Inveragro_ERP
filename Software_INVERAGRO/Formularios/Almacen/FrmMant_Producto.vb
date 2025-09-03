Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid
Imports OfficeOpenXml

Public Class FrmMant_Producto

    Private _idubicacion As Integer
    Dim tbtmp As New DataTable

    Sub ConsultarItems()
        'Pasamos todos los parametros y ejecutamos el hilo para cargar la busqueda
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            'GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            _idubicacion = cbxalmacen.SelectedValue
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coProductos
            Dim cn As New cnProducto
            obj.Descripcion = txtnombre.Text
            obj.IdUbicacion = _idubicacion
            tbtmp = cn.Cn_Consultar(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        btnBuscar.Enabled = True
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtg_Listado.DataSource = CType(e.Result, DataTable)

            clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Red, Color.White, "INACTIVO", 8)
            clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Green, Color.White, "ACTIVO", 8)

            clsBasicas.ColorearColumnas_SegunValor(dtg_Listado, Color.Red, Color.White, "INACTIVO", 8, "8,3")
            'clsBasicas.ColorearColumnas_SegunValor(dtg_Listado, Color.Green, Color.White, "ACTIVO", 8, "8,3")


            clsBasicas.Colorear_SegunValor_igual_a(dtg_Listado, Color.White, Color.Red, 0, 5)
            clsBasicas.Colorear_SegunValor_mayor_a(dtg_Listado, Color.White, Color.Green, 0, 5)

            ' Columnas: 15 = stock actual, 4 = stock mínimo permitido
            clsBasicas.ColorearStockPorPorcentaje(dtg_Listado, 5, 4)

            clsBasicas.Colorear_SegunValor_igual_a(dtg_Listado, Color.White, Color.Red, 0, 7)
            clsBasicas.Colorear_SegunValor_mayor_a(dtg_Listado, Color.White, Color.Green, 0, 7)
            'GrupoMasOpcionesBusqueda.Enabled = True
            ToolStrip1.Enabled = True
        End If
    End Sub

    Private Sub FrmMant_Producto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            WindowState = Windows.Forms.FormWindowState.Maximized
            btnDashboardproductos.Visible = True
            clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtg_Listado)
            clsBasicas.ListarAlmacenesAsignados(cbxalmacen)
            ConsultarItems()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtg_ListaProducto_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtg_Listado.InitializeLayout
        'Formateamos y le damos estilo a nuestra grilla
        Try
            dtg_Listado.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None
            If (dtg_Listado.Rows.Count = 0) Then
            Else
                With e.Layout.Bands(0)

                    .Columns(0).Width = 70
                    .Columns(3).Width = 300
                End With

                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtg_Listado, e, 1)
                'clsBasicas.SumarTotales_Formato(dtg_Listado, e, 10)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub bnuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevoproductos.Click
        Try
            Dim f As New FrmProducto With {
                ._Codigo = 0
            }
            f.ShowDialog()
            ConsultarItems()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub



    Private Sub btnexportar_excel_Click(sender As Object, e As EventArgs) Handles btnexportar_excelproductos.Click
        'Validamos sin existen registros, si es asi exportamos a excel toda la lista de la grilla
        Try
            clsBasicas.ExportarExcel("Lista de Productos", dtg_Listado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub btn_editar_Click(sender As Object, e As EventArgs) Handles btn_editarproductos.Click
        'Le damos doble click a la celda para poder editar los datos del item
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If (dtg_Listado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim f As New FrmProducto
                    f._Codigo = dtg_Listado.ActiveRow.Cells(0).Value.ToString
                    f.ShowDialog()
                    ConsultarItems()
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
    Sub EliminarItem()
        'Eliminamos el Item seleccionado
        Try
            Dim MensajeBgWk As String = ""
            Dim obj As New coProductos
            Dim cn_item As New cnProducto
            obj.Operacion = 2
            obj.Idproducto = dtg_Listado.ActiveRow.Cells(0).Value.ToString
            obj.Idmarca = 0
            obj.Descripcion = ""
            obj.Observacion = ""
            obj.Stockminimo = 0
            obj.Estado = ""
            obj.Lotes = ""
            obj.AfectoIgv = ""
            obj.IdUbicacion = 0
            MensajeBgWk = cn_item.Cn_Mantenimiento(obj)
            If (obj.Coderror = 1) Then
                msj_advert(MensajeBgWk)
            Else
                msj_ok(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If MsgBox("¿Esta Seguro de Eliminar el Item ?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Ok Then
                    EliminarItem()
                    ConsultarItems()
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Generar_Dashboard()
        Try

            Dim obj As New coProductos
            Dim cn As New cnProducto
            Dim tb_tmp As New DataTable

            tb_tmp = cn.Cn_ConsultarReporteDashboard(obj).Copy
            tb_tmp.TableName = "tmp"

            Dim archivo As String = Application.StartupPath + "\DashoardsExcel\Almacen.xlsx"
            Dim ruta_destino As String = ""
            Dim MyComputer = New Microsoft.VisualBasic.Devices.Computer

            If (dtg_Listado.Rows.Count = 0) Then
                msj_advert("No existen Registros vuelva a Buscar por Favor")
                Return
            Else
                Dim FolderBrowserDialog1 As New FolderBrowserDialog
                If FolderBrowserDialog1.ShowDialog() = 1 Then
                    ruta_destino = FolderBrowserDialog1.SelectedPath & "\Dashboard_Almacen " + "" & Now.Date.ToShortDateString.Replace("/", "_") + "_" + "" & Now.Hour.ToString + "" & Now.Minute.ToString + "" & Now.Second.ToString + ".xlsx"
                    MyComputer.FileSystem.CopyFile(archivo, ruta_destino)

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial
                    Dim fila As Integer = 1
                    Using package As ExcelPackage = New ExcelPackage(New FileInfo(ruta_destino))
                        Dim worksheet = package.Workbook.Worksheets("Data")

                        For Each row As DataRow In tb_tmp.Rows
                            If (CDec(CStr(row(7).ToString())) > 0) Then
                                Dim valor As String = CStr(row(0))
                                fila = fila + 1

                                worksheet.Cells(fila, 1).Value = CStr(row(0).ToString())
                                worksheet.Cells(fila, 2).Value = CStr(row(1).ToString())
                                worksheet.Cells(fila, 3).Value = CStr(row(2).ToString())
                                worksheet.Cells(fila, 4).Value = CStr(row(3).ToString())
                                worksheet.Cells(fila, 5).Value = CStr(row(4).ToString())
                                worksheet.Cells(fila, 6).Value = CStr(row(5).ToString())
                                worksheet.Cells(fila, 7).Value = CDec(CStr(row(6).ToString()))
                                worksheet.Cells(fila, 8).Value = CDec(CStr(row(7).ToString()))
                                worksheet.Cells(fila, 9).Value = CStr(row(8).ToString())
                                worksheet.Cells(fila, 10).Value = CStr(row(9).ToString())
                                worksheet.Cells(fila, 11).Value = CStr(row(10).ToString())
                                worksheet.Cells(fila, 12).Value = CStr(row(11).ToString())
                                worksheet.Cells(fila, 13).Value = CStr(row(12).ToString())
                                worksheet.Cells(fila, 14).Value = CStr(row(13).ToString())
                                worksheet.Cells(fila, 15).Value = CStr(row(14).ToString())
                                worksheet.Cells(fila, 16).Value = IIf(CDec(CStr(row(7).ToString())) > 0, "CON STOCK", "SIN STOCK")
                                worksheet.Cells(fila, 17).Value = IIf(CStr(row(8).ToString()) = "MA6", "MAYOR A 6 MESES", "MENOR A 6 MESES")
                            End If
                        Next

                        worksheet.Cells("T1").Value = "Ultima Actualización : " + Now.Date.ToShortDateString()
                        package.Save()
                    End Using

                    'msj_ok("Se Generó Corretamente")
                    System.Diagnostics.Process.Start(ruta_destino)
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
            Dim ds As New DataSet("bd")
            ds.Tables.Add(tbtmp.Copy)
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_Inventario.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(ds)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnImprimirListaInventario_Click(sender As Object, e As EventArgs) Handles btnImprimirListaInventario.Click
        ImprimirListado()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Ptbx_Cargando.Visible = True
        btnBuscar.Enabled = False
        ConsultarItems()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles btn_historicodecompraalmacenali.Click

        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If dtg_Listado.ActiveRow.Cells(0).Value.ToString <> 0 Then
                    Dim f As New FrmHistoricoCompraPorProducto
                    f.lblNombreProducto.Text = dtg_Listado.ActiveRow.Cells(3).Value.ToString
                    f.lblCodigo.Text = dtg_Listado.ActiveRow.Cells(0).Value.ToString
                    f.ShowDialog()
                Else
                    msj_advert("Seleccione un Registro")
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles btnverkardexproductos.Click
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If dtg_Listado.ActiveRow.Cells(0).Value.ToString <> 0 Then
                    Dim f As New FrmKardex
                    f.lblpresentación.Text = dtg_Listado.ActiveRow.Cells(19).Value.ToString
                    f.idubicacion = cbxalmacen.SelectedValue
                    f.lblNombreProducto.Text = dtg_Listado.ActiveRow.Cells(3).Value.ToString
                    f.lblCodigo.Text = dtg_Listado.ActiveRow.Cells(0).Value.ToString
                    f.ShowDialog()
                Else
                    msj_advert("Seleccione un Registro")
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub cbxalmacen_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbxalmacen.SelectionChangeCommitted
        ConsultarItems()
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

    Private Sub BtnCodigoBarra_Click(sender As Object, e As EventArgs) Handles BtnCodigoBarraalmaali.Click
        If (dtg_Listado.Rows.Count > 0) Then
            If (dtg_Listado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim estado As String = dtg_Listado.ActiveRow.Cells(14).Value.ToString
                Dim f As New FrmImprimirCodBarraProducto
                f._Codigo = dtg_Listado.ActiveRow.Cells("Codigo").Value.ToString
                f._NumSerie = dtg_Listado.ActiveRow.Cells("Cod.Barras").Value.ToString
                f._Descripcion = dtg_Listado.ActiveRow.Cells("Descripción").Value.ToString
                f.ShowDialog()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub BtnVerLote_Click(sender As Object, e As EventArgs) Handles BtnVerLotealmcenproductos.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtg_Listado.ActiveRow
        If (dtg_Listado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim lote As String = activeRow.Cells("Lotes").Value.ToString()
                Dim idUbicacion As Integer = cbxalmacen.SelectedValue
                Dim nombreProducto As String = activeRow.Cells("Descripción").Value.ToString()

                If lote = "NO" Then
                    msj_advert("este producto no se maneja por lotes")
                    Return
                End If

                Dim frm As New FrmVerStockLotes With {
                    .idProducto = activeRow.Cells("Codigo").Value,
                    .idUbicacion = idUbicacion,
                    .descripcion = nombreProducto
                }
                frm.ShowDialog()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        Close()
    End Sub

    Private Sub ToolStripButton1productos_Click(sender As Object, e As EventArgs) Handles ToolStripButton1productos.Click

    End Sub

    Private Sub btnrecepciones_Click(sender As Object, e As EventArgs) Handles btnrecepciones.Click
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If dtg_Listado.ActiveRow.Cells(0).Value.ToString <> 0 Then
                    Dim f As New FrmRecepcionOrdenCompraProducto
                    f.lblCodigo = dtg_Listado.ActiveRow.Cells(0).Value.ToString
                    f.ShowDialog()
                Else
                    msj_advert("Seleccione un Registro")
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ReporteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteToolStripMenuItem.Click
        Try
            Dim frm As New FrmReporteGastosVeterinarios
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ReporteDeCostosDeAlmancenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeCostosDeAlmancenToolStripMenuItem.Click
        Try
            Dim frm As New FrmReporteGastosVeterinarios
            frm.op = 1
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ReporteDashboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnDashboardproductos.Click
        Generar_Dashboard()
    End Sub

    Private Sub btnAsignarUnidadesMedida_Click(sender As Object, e As EventArgs) Handles btnAsignarUnidadesMedida.Click
        Try
            Dim frm As New FrmAsignarUnidadesMedida
            frm.ShowDialog()
            ConsultarItems()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            Dim frm As New FrmAsignarUnidadesMedida
            frm.operacion = 1
            frm.idProducto = dtg_Listado.ActiveRow.Cells(0).Value.ToString
            frm.producto = dtg_Listado.ActiveRow.Cells(3).Value.ToString
            frm.presentacion = dtg_Listado.ActiveRow.Cells(19).Value.ToString
            frm.ShowDialog()
            ConsultarItems()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub HistoricoDeRecepcionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoricoDeRecepcionesToolStripMenuItem.Click
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If dtg_Listado.ActiveRow.Cells(0).Value.ToString <> 0 Then
                    Dim f As New FrmHistoricoCompraPorProducto
                    f.lblNombreProducto.Text = dtg_Listado.ActiveRow.Cells(3).Value.ToString
                    f.lblCodigo.Text = dtg_Listado.ActiveRow.Cells(0).Value.ToString
                    f.operacion = 1
                    f.ShowDialog()
                Else
                    msj_advert("Seleccione un Registro")
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class