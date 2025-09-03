Imports CapaNegocio
Imports CapaObjetos

Public Class FrmAnularAlimento
    Dim cn As New cnControlAlimento
    Public idSalida As Integer = 0

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If txtDescripcionAnulacion.Text.Length = 0 Then
                msj_advert("Ingrese el motivo de anulación")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE ANULAR LA SALIDA DE SU PEDIDO DE ALIMENTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAlimento With {
                .IdSalida = idSalida,
                .IdUsuario = VP_IdUser,
                .MotivoAnulacion = txtDescripcionAnulacion.Text
            }

            Dim _mensaje As String = cn.Cn_AnularAlimentoCerdo(obj)
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
End Class