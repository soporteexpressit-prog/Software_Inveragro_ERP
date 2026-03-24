Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmReportexInsumoCubrirMerma
    Dim cn As New cnControlExcedente
    Dim tbtmp As New DataTable

    Private Sub FrmReportexInsumoCubrirMerma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Inicializar()
        Me.KeyPreview = True
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        GrupoFiltros.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        GrupoFiltros.Enabled = True
        ToolStrip1.Enabled = True
    End Sub

    Sub Consultar()
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If

        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlExcedente With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlExcedente = CType(e.Argument, coControlExcedente)
            tbtmp = cn.Cn_ReporteConsolidadoxInsumoCubrirMerma(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            DesbloquearControladores()
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        End If
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportarControlCerdaenvioscamalpro_Click(sender As Object, e As EventArgs) Handles BtnExportarControlCerdaenvioscamalpro.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL DE EXCEDENTE", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class