Imports System.Data.SqlClient
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlClientes
    Dim cn As New cnCliente
    Dim tbtmp As New DataTable

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        btnConsultar.Enabled = True
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtg_Listado.DataSource = CType(e.Result, DataTable)
            Colorear()
            GrupoMasOpcionesBusqueda.Enabled = True
            ToolStrip1.Enabled = True
        End If
    End Sub


    Private Sub FrmControlClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            WindowState = Windows.Forms.FormWindowState.Maximized
            clsBasicas.Formato_Tablas_Grid(dtg_Listado)
            Ptbx_Cargando.Visible = True
            btnConsultar.Enabled = True
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coCliente
            obj.Datos = txtbusqueda.Text
            tbtmp = cn.Cn_Consultar(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
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

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Ptbx_Cargando.Visible = True
        btnConsultar.Enabled = False
        Consultar()
    End Sub
    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevoVctrlcli.Click
        Try
            Dim f As New FrmMantenimientoCliente
            f._Codigo = 0
            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btn_editar_Click(sender As Object, e As EventArgs) Handles btn_editarVctrlcli.Click
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If (dtg_Listado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim f As New FrmMantenimientoCliente
                    f._Codigo = dtg_Listado.ActiveRow.Cells(0).Value.ToString
                    f.ShowDialog()
                    Consultar()
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

    Private Sub btnexportar_excel_Click(sender As Object, e As EventArgs) Handles btnexportar_excelVctrlcli.Click
        Try
            If (dtg_Listado.Rows.Count = 0) Then
                msj_advert("No existen Registros vuelva a Buscar por Favor")
                Return
            Else
                clsBasicas.ExportarExcel("Lista de Clientes", dtg_Listado)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnImprimirListaClientes_Click(sender As Object, e As EventArgs) Handles btnImprimirListaClientes.Click
        ImprimirListado()
    End Sub
    Sub ImprimirListado()
        Try
            Dim selectedRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtg_Listado.ActiveRow
            If selectedRow Is Nothing Then
                MsgBox("Por favor, seleccione un registro.")
                Return
            End If

            Dim StiReport1 As New Stimulsoft.Report.StiReport
            Dim ds As New DataSet("bd")
            ds.Tables.Add(tbtmp.Copy)
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_Clientes.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(ds)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        Close()
    End Sub

    Sub ConsultarItems()
        'Pasamos todos los parametros y ejecutamos el hilo para cargar la busqueda
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub


    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtg_Listado, isFilterActive)
    End Sub



    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

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

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If Not String.IsNullOrEmpty(dtg_Listado.ActiveRow.Cells(0).Value.ToString()) Then
                    Dim codigo As String = dtg_Listado.ActiveRow.Cells(0).Value.ToString()
                    Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro de que quieres convertirlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If resultado = DialogResult.Yes Then
                        Try
                            Dim f As New FrmTrabajador
                            f._Codigo = dtg_Listado.ActiveRow.Cells(0).Value.ToString
                            f.operacion = 1
                            f.ShowDialog()
                            f.Consultar()
                            ConsultarItems()
                        Catch ex As Exception
                            ' clsBasicas.controlException(Name, ex)
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

    Private Sub ConvertirAProveedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertirAProveedorToolStripMenuItem.Click
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If Not String.IsNullOrEmpty(dtg_Listado.ActiveRow.Cells(0).Value.ToString()) Then
                    Dim codigo As String = dtg_Listado.ActiveRow.Cells(0).Value.ToString()
                    Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro de que quieres convertirlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If resultado = DialogResult.Yes Then
                        Try
                            Dim f As New FrmProveedor
                            f._Codigo = dtg_Listado.ActiveRow.Cells(0).Value.ToString
                            f._TipoProveedor = 1

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

    Private Sub ConvertirAConductorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertirAConductorToolStripMenuItem.Click
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If (dtg_Listado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim f As New Mant_Conductores
                    f._Codigo = dtg_Listado.ActiveRow.Cells(0).Value.ToString
                    f._tipotrabajador = "CONDUCTOR"
                    f.ShowDialog()
                    ConsultarItems()
                Else
                    msj_advert("Seleccione un Registro")
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If
        Catch ex As Exception
            'clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class