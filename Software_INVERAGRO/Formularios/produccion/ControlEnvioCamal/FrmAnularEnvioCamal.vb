Imports CapaNegocio
Imports CapaObjetos

Public Class FrmAnularEnvioCamal
    Dim cn As New cnControlAnimal
    Public idHistorialEnvioCamal As Integer = 0
    Public idUbicacion As Integer = 0

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If txtDescripcionAnulacion.Text.Length = 0 Then
                msj_advert("Ingrese el motivo de anulación")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE ANULAR EL ENVÍO AL CAMAL?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAnimal With {
                .IdHistorialEnvioCamal = idHistorialEnvioCamal,
                .IdPlantel = idUbicacion,
                .MotivoAnulacion = txtDescripcionAnulacion.Text
            }

            Dim _mensaje As String = cn.Cn_AnularEnvioCamal(obj)
            If obj.Coderror = 0 Then
                msj_ok(_mensaje)
                Dispose()
            Else
                msj_error(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class