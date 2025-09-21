Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmReporteEngordeCampana
    Dim cn As New cnControlLoteDestete
    Dim tbtmp As New DataTable
    Public idCampaña As Integer = 0

    Private Sub FrmReporteEngordeCampana_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        Ptbx_Cargando.Visible = True
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Dim obj As New coControlLoteDestete With {
                .IdCampana = idCampaña
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ReporteEngordeCampana(obj).Copy
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
            PintarColumnaPorIndice(6)
        End If
    End Sub

    Private Sub PintarColumnaPorIndice(indiceColumna As Integer)
        For Each fila As UltraGridRow In dtgListado.Rows
            If fila.Cells.Count > indiceColumna Then
                With fila.Cells(indiceColumna).Appearance
                    .BackColor = Color.FromArgb(234, 239, 239)
                    .FontData.Bold = DefaultableBoolean.True
                End With
            End If
        Next
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 0)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 4)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 8)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 9)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE DE ENGORDE", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class