Imports CapaNegocio
Imports CapaObjetos

Public Class FrmFinalizarVenta
    Dim cn As New cnControlLoteDestete
    Public idCampaña As Integer = 0
    Public nombrePlantel As String = ""

    Private Sub FrmFinalizarVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LblPlantel.Text = nombrePlantel
            DtpFechaFinVenta.Value = Date.Now
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnGuardarLote_Click(sender As Object, e As EventArgs) Handles BtnGuardarLote.Click
        Try
            If (MessageBox.Show("¿ESTÁ SEGURO DE ESTA REALIZAR ESTA ACCIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .FechaControl = DtpFechaFinVenta.Value,
                .IdCampana = idCampaña
            }

            Dim _mensaje As String = cn.Cn_FinalizarVentaxCampaña(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Dispose()
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Dispose()
    End Sub
End Class