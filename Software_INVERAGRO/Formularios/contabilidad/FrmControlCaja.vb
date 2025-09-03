Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlCaja
    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles ctcontrolcjchi.Click
        clsBasicas.ExportarExcel("Control Caja", dtgListado)
    End Sub
    Private _estado As String
    Private _idpersona As Integer
    Dim cn As New cnCtaPagar

    Dim ds As New DataSet
    Sub Consultar()
        'Pasamos todos los parametros y ejecutamos el hilo para cargar la busqueda
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ' GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            _estado = cbxestado.Text
            If (cktodods.Checked) Then
                _idpersona = 0
            Else
                _idpersona = CInt(txtcodproveedor.Text)
            End If
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
            ds = cn.Cn_ConsultarControlCaja(obj).Copy
        Catch ex As Exception
            e.Cancel = True
            MessageBox.Show("Ocurrió un error al consultar el control de caja:" & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "EGRESO", 14)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "INGRESO", 14)


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
        cbxestado.SelectedIndex = 0
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
    End Sub

    Private Sub cktodods_CheckedChanged(sender As Object, e As EventArgs) Handles cktodods.CheckedChanged
        txtcodproveedor.Clear()
        txtproveedor.Clear()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If cktodods.Checked = False AndAlso txtcodproveedor.Text.Length = 0 Then
            msj_advert("Seleccione un Proveedor")
            Return
        End If
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

                .Columns("btnver").Header.Caption = "Archivo"
                .Columns("btnver").Width = 80
                .Columns("btnver").Style = UltraWinGrid.ColumnStyle.Button
                .Columns("btnver").CellButtonAppearance.Image = My.Resources.adjuntar
                .Columns("btnver").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns("btnver").Header.VisiblePosition = 1
                .Columns("Tipo Movimiento").Header.VisiblePosition = 0
            End With

            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 1)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
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
    Sub ConsultarArchivo(codigo As Integer)

        Dim obj As New coCtaPagar
        obj.Id = codigo
        cn.Cn_ConsultarArchivodeAbono(obj)


        Dim pdfData As Byte() = obj.ArchivoRecepcion
        If pdfData IsNot Nothing AndAlso pdfData.Length > 0 Then
            Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "ArchivoAbono" & codigo.ToString & ".pdf")

            File.WriteAllBytes(tempFilePath, pdfData)
            Process.Start(tempFilePath)
        Else
            MessageBox.Show("No se encontró el archivo PDF en la base de datos.")
        End If


    End Sub
    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub



    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim f As New FrmBuscarProveedorTrabajador
        f.ShowDialog()
        If (f.codproveedor <> 0) Then
            txtcodproveedor.Text = f.codproveedor
            txtproveedor.Text = f.razonsocial
            f.codproveedor = 0
        Else
            txtcodproveedor.Clear()
            txtproveedor.Clear()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)
        Dim f As New FrmGastos
        f.ShowDialog()
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnreportecaja.Click
        ImprimirReportecaja()
    End Sub
    Sub ImprimirReportecaja()
        Dim cn As New cnControlIncidencia
        Dim obj As New coControlincidencia
        Dim dsCapacitacion As New DataSet
        obj.FechaDesde = dtpFechaDesde.Value
        obj.FechaHasta = dtpFechaHasta.Value
        dsCapacitacion = cn.Cn_ConsultarreporteCajachica(obj).Copy

        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_MovimientoCajaChica.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class