Imports CapaNegocio
Imports CapaObjetos
Imports System.ComponentModel

Public Class FrmReporteCtaBanco

    Dim cn As New cnBanco
    Dim tbtmp As New DataTable

    Private Sub FrmReporteCtaBanco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtpFechaDesde.Value = Date.Now
            dtpFechaHasta.Value = Date.Now
            Consultar()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            Dim obj As New coBanco With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coBanco = CType(e.Argument, coBanco)
            tbtmp = cn.Cn_ReporteCtaBanco(obj).Copy
            tbtmp.TableName = "tmp"
            tbtmp.Columns("Codigo").ColumnMapping = MappingType.Hidden
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            ToolStrip1.Enabled = True
        End If
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        If dtgListado.Rows.Count = 0 Then
            msj_advert("No hay datos para exportar.")
            Return
        Else
            clsBasicas.ExportarExcel("REPORTE DE CUENTA DE BANCOS", dtgListado)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        clsBasicas.Totales_Formato(dtgListado, e, 1)
        clsBasicas.SumarTotales_Formato(dtgListado, e, 4)
        clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
        clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
        clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
    End Sub
End Class