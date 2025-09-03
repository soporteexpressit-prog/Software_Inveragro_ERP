Imports CapaNegocio
Imports CapaObjetos

Public Class FrmResumenCaja
    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportarctresumencaja.Click
        clsBasicas.ExportarExcel("Resumenes de Caja", dtgListado)
    End Sub
    Private _estado As String
    Private _idpersona As Integer
    Dim cn As New cnCtaPagar

    Dim ds As New DataSet
    Sub Consultar()
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
            Dim obj As New coCtaPagar
            obj.Fdesde = dtpFechaDesde.Value
            obj.Fhasta = dtpFechaHasta.Value
            obj.Estado = _estado
            obj.Idpersona = _idpersona
            ds = New DataSet
            ds = cn.Cn_ConsultarResumenesCaja(obj).Copy
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try


            Ptbx_Cargando.Visible = False
            btnConsultar.Enabled = True
            If e.Error IsNot Nothing OrElse e.Cancelled Then
                msj_advert("Error al Cargar los Datos")
            Else
                ds.DataSetName = "tmp"
                dtgListado.DataSource = ds
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "Cerrado", 10)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "Abierto", 10)
                'clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "NO", 13)
                'clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "SI", 13)


                'GrupoMasOpcionesBusqueda.Enabled = True
                ToolStrip1.Enabled = True
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmCuentasPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = Windows.Forms.FormWindowState.Maximized
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        Consultar()
    End Sub


    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

        If (dtpFechaDesde.Value > dtpFechaHasta.Value) Then
            msj_advert("Seleccione un Fecha Válida")
            Return
        End If
        Consultar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True


            End With

            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 1)
            ' clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class