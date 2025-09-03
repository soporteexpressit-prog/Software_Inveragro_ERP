Imports CapaNegocio
Imports CapaObjetos

Public Class FrmCancelarVentaCamal

    Public idHistorialEnvioCamal As Integer = 0
    Public idUbicacion As Integer = 0
    Dim cn As New cnControlAnimal

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If txtDescripcionAnulacion.Text.Length = 0 Then
                msj_advert("Ingrese el motivo de anulación")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE CANCELAR LA VENTA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAnimal With {
                .IdHistorialEnvioCamal = idHistorialEnvioCamal,
                .IdPlantel = idUbicacion,
                .MotivoAnulacion = txtDescripcionAnulacion.Text,
                .IdUsuario = VP_IdUser
            }

            Dim _mensaje As String = cn.Cn_CancelarVentaEnvioCamal(obj)
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class