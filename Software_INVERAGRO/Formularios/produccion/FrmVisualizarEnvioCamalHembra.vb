Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmVisualizarEnvioCamalHembra
    Dim cn As New cnControlLoteDestete
    Public idControlFicha As Integer
    Dim tbtmp As New DataTable
    Dim mensaje As String

    Private Sub FrmVisualizarEnvioCamalHembra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RtbMotivo.ReadOnly = True
            RtbObservacion.ReadOnly = True
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Dim obj As New coControlLoteDestete With {
                .IdControlFicha = idControlFicha
            }
            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ConsultarInformacionCamal(obj).Copy
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
            Dim dt As DataTable = CType(e.Result, DataTable)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)

                LblFechaControl.Text = Format(CDate(row("fControl")), "dd/MM/yyyy")
                LblResponsable.Text = row("Responsable").ToString()
                LblRegistradoPor.Text = row("Registrado Por").ToString()
                RtbMotivo.Text = row("Incidencia").ToString()
                RtbObservacion.Text = row("observacion").ToString()
                LblLote.Text = row("Lote").ToString()
                LblCodCerdo.Text = row("Arete").ToString()
                LblUbicacion.Text = row("ubicacion").ToString()
            Else
                msj_advert("No se encontraron datos para el ID ingresado")
            End If

        End If
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Dispose()
    End Sub
End Class