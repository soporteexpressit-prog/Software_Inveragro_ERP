Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMotivoAnulacionPreparacionAlimento
    Dim cnAlimento As New cnControlAlimento
    Public idPreparacionAlimento As Integer = 0

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If txtDescripcionAnulacion.Text.Length = 0 Then
                msj_advert("Ingrese el motivo de anulación")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE CANCELAR LA PREPARACIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAlimento With {
                .IdPreparacionAlimento = idPreparacionAlimento,
                .IdUserAnulacion = VP_IdUser,
                .MotivoAnulacion = txtDescripcionAnulacion.Text
            }

            Dim MensajeBgWk As String = cnAlimento.Cn_CancelarPreparacionAlimento(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Dispose()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class