Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmReporteCondCorporal
    Dim cn As New cnControlLoteDestete
    Dim tbtmp As New DataTable
    Public idLote As Integer = 0

    Private Sub FrmReporteCondCorporal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(DtgListado)
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then

            Dim obj As New coControlLoteDestete With {
                .IdLote = idLote
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ConsultarReporteCondCorporal(obj).Copy
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
            DtgListado.DataSource = CType(e.Result, DataTable)
            If DtgListado.Rows.Count > 0 Then
                CalcularPorcentajeCondCorporal(CType(e.Result, DataTable))
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                LblPorcentajeCondCorporalP.Text = "0.00 %"
                LblPorcentajeCondCorporalD.Text = "0.00 %"
            End If
        End If
    End Sub

    Private Sub CalcularPorcentajeCondCorporal(tbtmp As DataTable)
        Dim sumaParto As Decimal = 0D
        Dim sumaDestete As Decimal = 0D

        For Each fila As DataRow In tbtmp.Rows
            Dim condicion As Decimal = Convert.ToDecimal(fila("Condición Corporal"))
            If condicion = 2D OrElse condicion = 3D Then
                sumaParto += Convert.ToDecimal(fila("% Parto"))
                sumaDestete += Convert.ToDecimal(fila("% Destete"))
            End If
        Next

        LblPorcentajeCondCorporalP.Text = Math.Round(sumaParto, 2).ToString("N2") & " %"
        LblPorcentajeCondCorporalD.Text = Math.Round(sumaDestete, 2).ToString("N2") & " %"
    End Sub

    Private Sub BtnExportarLoteParto_Click(sender As Object, e As EventArgs) Handles BtnExportarLoteParto.Click
        Try
            If (DtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE DE COND CORPORAL", DtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class