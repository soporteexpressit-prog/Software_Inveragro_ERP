Imports System.Data.SqlClient
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Public Class FrmMant_Proveedor
    Dim cn As New cnProveedor
    Dim tbtmp As New DataTable
    Dim cnlogin As New cnLogin
    Sub Consultar()
        ' Verificamos si el BackgroundWorker está ocupado antes de iniciar una nueva operación
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            'grupomasopcionesdebusqueda.Enabled = False
            ToolStrip1.Enabled = False
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub


    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coProveedor
            tbtmp = cn.Cn_Consultar(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        'btn_buscar.Enabled = True
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtg_Listado.DataSource = CType(e.Result, DataTable)
            Colorear()
            'grupomasopcionesdebusqueda.Enabled = True
            ToolStrip1.Enabled = True
        End If
    End Sub


    Private Sub FMant_Producto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargamos las funciones al momento de iniciar el formulario
        Try
            WindowState = Windows.Forms.FormWindowState.Maximized
            clsBasicas.Formato_Tablas_Grid(dtg_Listado)
            Ptbx_Cargando.Visible = True
            'btn_buscar.Enabled = True
            Consultar()
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtg_ListaProducto_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
        'Formateamos y le damos estilo a nuestra grilla
        Try
            dtg_Listado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            dtg_Listado.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
            dtg_Listado.DisplayLayout.PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand)
            e.Layout.UseFixedHeaders = True
            With e.Layout.Bands(0)

                '.Columns("Estado Garantia").Hidden = True
                '.Columns("Estado").Hidden = True
                '.Columns("kardex").Hidden = True
                '.Columns("Categoría").Hidden = True
                '.Columns("Dni Responsable del Área").Hidden = True
                '.Columns("Responsable del Área").Hidden = True
                '.Columns("Ultimo Dni Responsable").Hidden = True
            End With

            e.Layout.Bands(0).Summaries.Clear()
            e.Layout.Override.AllowRowSummaries = AllowRowSummaries.False
            Dim ColumnContarItems As UltraGridColumn = e.Layout.Bands(0).Columns(1)
            Dim symaryColumnContarItems As SummarySettings = e.Layout.Bands(0).Summaries.Add("symaryColumnContarItems", SummaryType.Count, ColumnContarItems)
            'symaryColumnSumarPrecio.DisplayFormat = "{0:N2}"
            'symaryColumnSumarPrecio.Appearance.TextHAlign = HAlign.Right
            symaryColumnContarItems.DisplayFormat = "{0:N2}"
            symaryColumnContarItems.Appearance.TextHAlign = HAlign.Right
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.TopFixed
            e.Layout.Override.SummaryDisplayArea = e.Layout.Override.SummaryDisplayArea OrElse SummaryDisplayAreas.GroupByRowsFooter
            e.Layout.Override.SummaryDisplayArea = e.Layout.Override.SummaryDisplayArea OrElse SummaryDisplayAreas.InGroupByRows
            'symaryColumnSumarPrecio.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed OrElse SummaryDisplayAreas.GroupByRowsFooter
            symaryColumnContarItems.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed OrElse SummaryDisplayAreas.GroupByRowsFooter
            e.Layout.Override.GroupBySummaryDisplayStyle = GroupBySummaryDisplayStyle.SummaryCells
            e.Layout.Override.SummaryFooterAppearance.BackColor = Color.Khaki
            e.Layout.Override.SummaryValueAppearance.BackColor = Color.Khaki
            e.Layout.Override.SummaryValueAppearance.ForeColor = Color.Black
            e.Layout.Override.SummaryValueAppearance.FontData.Bold = DefaultableBoolean.True
            e.Layout.Override.GroupBySummaryValueAppearance.BackColor = Color.Khaki
            e.Layout.Override.GroupBySummaryValueAppearance.ForeColor = Color.Black
            e.Layout.Override.GroupBySummaryValueAppearance.TextHAlign = HAlign.Right
            e.Layout.Bands(0).SummaryFooterCaption = "Totales : "
            e.Layout.Override.SummaryFooterCaptionAppearance.FontData.Bold = DefaultableBoolean.True
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.True
            e.Layout.Override.SummaryFooterSpacingAfter = 5
            e.Layout.Override.SummaryFooterSpacingBefore = 5
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Colorear()

        If (dtg_Listado.Rows.Count > 0) Then
            For index As Integer = 0 To dtg_Listado.Rows.Count - 1
                Dim estado As String = dtg_Listado.Rows(index).Cells(9).Value.ToString
                If (estado = "INACTIVO") Then
                    Dim i As Integer = 9
                    With dtg_Listado.Rows(index).Cells(i).SelectedAppearance
                        .BackColor = Color.Red
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color.White
                    End With

                    With dtg_Listado.Rows(index).Cells(i).Appearance
                        .BackColor = Color.Red
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color.White
                    End With

                    With dtg_Listado.Rows(index).Cells(i).ActiveAppearance
                        .BackColor = Color.Red
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color.White
                    End With

                Else
                    Dim i As Integer = 9
                    With dtg_Listado.Rows(index).Cells(i).SelectedAppearance
                        .BackColor = Color.Green
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color.White
                    End With

                    With dtg_Listado.Rows(index).Cells(i).Appearance
                        .BackColor = Color.Green
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color.White
                    End With

                    With dtg_Listado.Rows(index).Cells(i).ActiveAppearance
                        .BackColor = Color.Green
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color.White
                    End With


                End If
            Next
        End If
    End Sub



    Sub ImprimirListado()
        'Generamos el Reporte de Inventario
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            Dim ds As New DataSet("bd")
            ds.Tables.Add(tbtmp.Copy)
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_Proveedor.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(ds)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        'Segun el caso seleccionado realizamos el agrupamiento por columnas
        'If (grupomasopcionesdebusqueda.Checked) Then
        '    dtg_Listado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        '    dtg_Listado.DisplayLayout.GroupByBox.Hidden = False
        'Else
        '    dtg_Listado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        '    dtg_Listado.DisplayLayout.GroupByBox.Hidden = True
        'End If
    End Sub

    Private Sub ActivarDesactivarBotones(botones As List(Of (IdPersona As Integer, NombreBoton As String, EstadoBoton As Boolean)))
        ' Aquí puedes agregar lógica para activar/desactivar botones según la lista recibida
        For Each boton In botones
            Select Case boton.NombreBoton
                Case "btn_nuevo"
                    btn_nuevocomprasproveedores.Enabled = boton.EstadoBoton
                Case "btn_editar"
                    btn_editarcomprasproveedores.Enabled = boton.EstadoBoton
                Case "btnexportar_excel"
                    btnexportar_excelcomprasproveedores.Enabled = boton.EstadoBoton
                Case "btnImprimirListaProveedor"
                    btnImprimirListaProveedor.Enabled = boton.EstadoBoton
                    ' Agrega otros botones según sea necesario
            End Select
        Next
    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevocomprasproveedores.Click
        Try
            Dim f As New FrmProveedor
            f._Codigo = 0
            f._TipoProveedor = 1

            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btn_editar_Click_1(sender As Object, e As EventArgs) Handles btn_editarcomprasproveedores.Click
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If (dtg_Listado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim f As New FrmProveedor
                    f._Codigo = dtg_Listado.ActiveRow.Cells(0).Value.ToString
                    f._TipoProveedor = 1
                    f.ShowDialog()
                    Consultar()
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

    Private Sub btnexportar_excel_Click_1(sender As Object, e As EventArgs) Handles btnexportar_excelcomprasproveedores.Click
        Try
            If (dtg_Listado.Rows.Count = 0) Then
                msj_advert("No existen Registros vuelva a Buscar por Favor")
                Return
            Else
                clsBasicas.ExportarExcel("Lista de Proveedores", dtg_Listado)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnImprimirListaProveedor_Click_1(sender As Object, e As EventArgs) Handles btnImprimirListaProveedor.Click
        ImprimirListado()
    End Sub

    Private Sub btn_cerrar_Click_1(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        Close()
    End Sub

    Private Sub btn_buscar_Click_1(sender As Object, e As EventArgs)
        'Ptbx_Cargando.Visible = True
        'btn_buscar.Enabled = False
        'Consultar()
    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1ComprasConvercli.Click
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If Not String.IsNullOrEmpty(dtg_Listado.ActiveRow.Cells(0).Value.ToString()) Then
                    Dim codigo As String = dtg_Listado.ActiveRow.Cells(0).Value.ToString()
                    Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro de que quieres convertirlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If resultado = DialogResult.Yes Then
                        Try
                            Dim f As New FrmMantenimientoCliente
                            f._Codigo = dtg_Listado.ActiveRow.Cells(0).Value.ToString
                            f.ShowDialog()
                            f.Consultar()
                        Catch ex As Exception
                            clsBasicas.controlException(Name, ex)
                        End Try
                    Else
                        msj_advert(MensajesSistema.mensajesGenerales("Conversión cancelada."))
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            'clsBasicas.controlException(Name, ex)
        End Try
    End Sub



    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtg_Listado, isFilterActive)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

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

    Private Sub grupomasopcionesdebusqueda_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub UltraGroupBox3_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class