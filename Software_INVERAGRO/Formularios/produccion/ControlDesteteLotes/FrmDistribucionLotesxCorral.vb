Imports CapaNegocio
Imports CapaObjetos

Public Class FrmDistribucionLotesxCorral
    Dim cn As New cnControlLoteDestete
    Public idPlantel As Integer = 0
    Dim tbtmp As New DataTable

    Private Sub FrmDistribucionLotesxCorral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            Dim obj As New coControlLoteDestete With {
                .IdPlantel = idPlantel
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ConsultarReporteDistribucionPlantel(obj).Copy
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
            Ptbx_Cargando.Visible = False
            ToolStrip1.Enabled = True
            LblTotalAnimales.Text = SumarTotalAnimalesDetallado()
        End If
    End Sub

    Private Function SumarTotalAnimalesDetallado() As Integer
        Dim suma As Integer = 0
        For i As Integer = 0 To dtgListado.Rows.Count - 1
            suma += dtgListado.Rows(i).Cells("Cantidad Animales").Value
        Next
        Return suma
    End Function

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        If (dtgListado.Rows.Count = 0) Then
            msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
            Return
        Else
            clsBasicas.ExportarExcel("REPORTE DISTRIBUCIÓN DE LOTES X CORRALES", dtgListado)
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 0)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 4)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        Try
            If e.Row.Cells.Exists("Corral") AndAlso e.Row.Cells("Corral").Value.ToString() = "ZONA-ESPERA" Then
                e.Row.Appearance.BackColor = Color.LightGray
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class