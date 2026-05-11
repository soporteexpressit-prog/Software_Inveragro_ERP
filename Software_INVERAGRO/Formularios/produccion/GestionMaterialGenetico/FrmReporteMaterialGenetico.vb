Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmReporteMaterialGenetico
    Dim cn As New cnControlMaterialGenetico
    Dim ds As New DataSet
    Public idPlantel As Integer

    Private Sub FrmReporteMaterialGenetico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        Ptbx_Cargando.Visible = True
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Formato_Tablas_Grid(dtgListado2)
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
    End Sub

    Private Sub BloquearControles()
        Ptbx_Cargando.Visible = True
        ToolStrip1.Enabled = False
        GrupoFiltros.Enabled = False
    End Sub

    Private Sub DesbloquearControles()
        Ptbx_Cargando.Visible = False
        ToolStrip1.Enabled = True
        GrupoFiltros.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()

            Dim obj As New coControlMaterialGenetico With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .IdUbicacionOrigen = idPlantel
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlMaterialGenetico = CType(e.Argument, coControlMaterialGenetico)
            ds = cn.Cn_ReporteMaterialGenetico(obj).Copy
            e.Result = ds
            ds.Tables(0).Columns("idAnimal").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("Ubicacion").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("idMaterialGenetico").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("idProducto").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idProducto").ColumnMapping = MappingType.Hidden
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DesbloquearControles()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            Dim dsResult As DataSet = CType(e.Result, DataSet)
            dtgListado.DataSource = dsResult.Tables(0)
            dtgListado2.DataSource = dsResult.Tables(1)
        End If
    End Sub

    Private Sub BtnBuscarMG_Click(sender As Object, e As EventArgs) Handles BtnBuscarMG.Click
        Consultar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If dtgListado.Rows.Count > 0 Then
                clsBasicas.Totales_Formato(dtgListado, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado2_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado2.InitializeLayout
        Try
            If dtgListado2.Rows.Count > 0 Then
                clsBasicas.Totales_Formato(dtgListado2, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListado2, e, 2)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportarMaterialGeneticopro_Click(sender As Object, e As EventArgs) Handles BtnExportarMaterialGeneticopro.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE MATERIAL GENETICO", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class