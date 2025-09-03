Imports CapaNegocio
Imports CapaObjetos

Public Class FrmControlCotizacion
    Dim cn As New cnCotizacion

    Dim ds As New DataSet
    Private Sub FrmControlEpp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbEstadoEpp.SelectedIndex = 0
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListado)
        cmbEstadoEpp.SelectedIndex = 0
        Consultar()

    End Sub

    Private _estado As String

    Sub Consultar()
        'Pasamos todos los parametros y ejecutamos el hilo para cargar la busqueda
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            _estado = cmbEstadoEpp.Text
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coCotizacion
            obj.Fechadesde = dtpFechaDesde.Value
            obj.Fechahasta = dtpFechaHasta.Value
            obj.Estado = _estado
            ds = New DataSet
            ds = cn.Cn_Consultar(obj).Copy
            ds.DataSetName = "tmp"
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
            Dim relation1 As New DataRelation("tabla_relacion_32", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item("idPedidoCotizacion"), False)

            ds.Relations.Add(relation1)
            dtgListado.DataSource = ds
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", 11)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 11)

            GrupoMasOpcionesBusqueda.Enabled = True
            ToolStrip1.Enabled = True
        End If
    End Sub



    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try

            With e.Layout.Bands(1)
                .Columns(3).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim f As New FrmCotizacion
        f.ShowDialog()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportar.Click
        clsBasicas.ExportarExcel("Lista de Cotizaciones", dtgListado)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    If MsgBox("¿Esta Seguro de Anular la Cotización ?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                        Exit Sub
                    End If
                    Dim obj As New coCotizacion
                    obj.Codigo = dtgListado.ActiveRow.Cells(0).Value.ToString
                    Dim MensajeBgWk As String = ""
                    MensajeBgWk = cn.Cn_Anular(obj)
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
            Dim Stireport1 As New Stimulsoft.Report.StiReport
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
    Private Sub ReporteGneralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteGneralToolStripMenuItem.Click
        ImprimirListado()
    End Sub



    Private Sub UltraGroupBox2_Click(sender As Object, e As EventArgs) Handles UltraGroupBox2.Click

    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class