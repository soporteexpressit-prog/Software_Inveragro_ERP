Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmConsolidadoPedidoAlimento
    Dim cn As New cnControlAlimento
    Dim ds As New DataSet

    Private Sub FrmConsolidadoPedidoAlimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            WindowState = Windows.Forms.FormWindowState.Maximized
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Inicializar()
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Inicializar()
        Ptbx_Cargando.Visible = True
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
    End Sub

    Sub Consultar(Optional ByVal fechaDesde As Date? = Nothing, Optional ByVal fechaHasta As Date? = Nothing)
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            btnBuscar.Enabled = False

            Dim obj As New coControlAlimento
            If fechaDesde.HasValue Then
                obj.FechaDesde = fechaDesde
            Else
                obj.FechaDesde = Nothing
            End If

            If fechaHasta.HasValue Then
                obj.FechaHasta = fechaHasta
            Else
                obj.FechaHasta = Nothing
            End If

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)

            ds = cn.Cn_ConsultarAlimentoPedir(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(1).Columns(0).ColumnMapping = MappingType.Hidden

            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = ds.Tables(0)
            btnBuscar.Enabled = True
        End If
    End Sub

    Private Sub btnPrepararOrden_Click(sender As Object, e As EventArgs) Handles btnPrepararOrdencompraspediali.Click
        Try
            Dim f As New FrmPrepararRegistrarOrden
            f.ShowDialog()
            Dim fechaDesde As Date? = dtpFechaDesde.Value
            Dim fechaHasta As Date? = dtpFechaHasta.Value
            Consultar(fechaDesde, fechaHasta)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportarcompraspediali.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("LISTA DE INSUMOS A PEDIR", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            If dtpFechaDesde.Value > dtpFechaHasta.Value Then
                msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
                Return
            End If

            Dim fechaDesde As Date? = dtpFechaDesde.Value
            Dim fechaHasta As Date? = dtpFechaHasta.Value
            Consultar(fechaDesde, fechaHasta)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub BtnMedicamentoRacion_Click(sender As Object, e As EventArgs) Handles BtnMedicamentoRacion.Click
        Try
            Dim frm As New FrmMedicamentoRacionDetalle
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class