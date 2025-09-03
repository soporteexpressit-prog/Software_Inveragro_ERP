Imports CapaNegocio
Imports CapaObjetos

Public Class FrmCancelarMedicacion

    Dim cn As New cnControlMedico
    Public IdControlFicha As Integer = 0

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If txtDescripcionAnulacion.Text.Length = 0 Then
                msj_advert("Ingrese el motivo de cancelación")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE CANCELAR ESTA MEDICACIÓN / TRATAMIENTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlMedico With {
                .IdControlFicha = IdControlFicha,
                .MotivoAnulacion = txtDescripcionAnulacion.Text,
                .IdUsuario = VP_IdUser
            }

            Dim _mensaje As String = cn.Cn_CancelarMedicacion(obj)
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