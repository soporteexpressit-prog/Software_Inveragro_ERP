Imports CapaNegocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmReporteStockCerdosVenta
    Dim cn As New cnControlLoteDestete
    Dim tbtmp As New DataTable

    Private Sub FrmReporteStockCerdosVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(DtgListado)
            Ptbx_Cargando.Visible = True
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            tbtmp = cn.Cn_ReporteAnimalesVentaStock().Copy
            tbtmp.TableName = "tmp"
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
            DtgListado.DataSource = CType(e.Result, DataTable)
            ToolStrip1.Enabled = True
            PintarFilasConsumoDonacion()
            PintarColumnaPorIndice(6)
        End If
    End Sub

    Private Sub PintarFilasConsumoDonacion()
        For Each fila As UltraGridRow In DtgListado.Rows
            Dim disponibleVenta As String = fila.Cells("TIPO DE ANIMAL").Value?.ToString().ToUpper().Trim()

            If disponibleVenta = "TOTAL" Then
                fila.Appearance.BackColor = Color.FromArgb(234, 239, 239)
                fila.Appearance.FontData.Bold = DefaultableBoolean.True
            End If
        Next
    End Sub

    Private Sub PintarColumnaPorIndice(indiceColumna As Integer)
        For Each fila As UltraGridRow In DtgListado.Rows
            If fila.Cells.Count > indiceColumna Then
                With fila.Cells(indiceColumna).Appearance
                    .BackColor = Color.FromArgb(234, 239, 239)
                    .FontData.Bold = DefaultableBoolean.True
                End With
            End If
        Next
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class