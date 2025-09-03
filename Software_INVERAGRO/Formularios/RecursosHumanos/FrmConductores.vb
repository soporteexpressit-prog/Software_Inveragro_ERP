Imports CapaNegocio
Imports CapaObjetos
Imports System.ComponentModel

Public Class FrmConductores
    Dim cn As New cnTrabajador
    Dim tbtmp As New DataTable
    Public Property DNI As String
    Public Property CUSP As String
    Public Property TipoAFP As String

    ' Declare and initialize BackgroundWorker1
    Private WithEvents BackgroundWorker1 As New BackgroundWorker With {
        .WorkerSupportsCancellation = True,
        .WorkerReportsProgress = True
    }

    Sub ConsultarItems()
        'Pasamos todos los parametros y ejecutamos el hilo para cargar la busqueda
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coTrabajador
            Dim cn As New cnTrabajador
            tbtmp = cn.Cn_Consultarconductores(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtg_Listado.DataSource = CType(e.Result, DataTable)
            GrupoMasOpcionesBusqueda.Enabled = True
            ToolStrip1.Enabled = True
        End If
    End Sub
    Private Sub dtg_Listado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtg_Listado.InitializeRow
        clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Red, Color.White, "INACTIVO", 12)
        clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Green, Color.White, "ACTIVO", 12)
    End Sub
    Private Sub FrmConductores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            WindowState = FormWindowState.Maximized
            clsBasicas.Formato_Tablas_Grid(dtg_Listado)
            Ptbx_Cargando.Visible = True
            ConsultarItems()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtg_Listado, isFilterActive)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If ToolStripButton2.Checked Then
            dtg_Listado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
            dtg_Listado.DisplayLayout.GroupByBox.Hidden = False
        Else
            dtg_Listado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal
            dtg_Listado.DisplayLayout.GroupByBox.Hidden = True
            dtg_Listado.DisplayLayout.Bands(0).SortedColumns.Clear() ' Eliminar agrupamiento y orden
        End If
        ToolStripButton2.Checked = Not ToolStripButton2.Checked
    End Sub

    Private Sub btn_nuevoRrhhtra_Click(sender As Object, e As EventArgs) Handles btn_nuevoRrhhconductores.Click
        Try
            Dim f As New Mant_Conductores
            f._Codigo = 0
            f.ShowDialog()
            ConsultarItems()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btn_editarRrhhtra_Click(sender As Object, e As EventArgs) Handles btn_editarRrhhconductores.Click
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If (dtg_Listado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim f As New Mant_Conductores
                    f._Codigo = dtg_Listado.ActiveRow.Cells(0).Value.ToString
                    f.ShowDialog()
                    ConsultarItems()
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

    Private Sub btnexportar_excelRrhhtra_Click(sender As Object, e As EventArgs) Handles btnexportar_excelRrhconductores.Click
        'Validamos sin existen registros, si es asi exportamos a excel toda la lista de la grilla
        Try
            If (dtg_Listado.Rows.Count = 0) Then
                msj_advert("No existen Registros vuelva a Buscar por Favor")
                Return
            Else
                clsBasicas.ExportarExcel("Lista de Conductores", dtg_Listado)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
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

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
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

    Private Sub ConvertirATrabajadorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertirATrabajadorToolStripMenuItem.Click
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If Not String.IsNullOrEmpty(dtg_Listado.ActiveRow.Cells(0).Value.ToString()) Then
                    Dim codigo As String = dtg_Listado.ActiveRow.Cells(0).Value.ToString()
                    Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro de que quieres convertirlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If resultado = DialogResult.Yes Then
                        Try
                            Dim f As New FrmTrabajador
                            f._Codigo = dtg_Listado.ActiveRow.Cells(0).Value.ToString

                            f.ShowDialog()
                            f.Consultar()
                            ConsultarItems()
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
End Class