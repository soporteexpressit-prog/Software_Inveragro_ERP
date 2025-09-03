Imports CapaNegocio
Imports CapaObjetos

Public Class FrmEditarDiasVacaciones

    Public idPersona As Integer = 0
    Dim cn As New cnTrabajador

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If txtDias.TextLength = 0 Then
                msj_advert("Ingrese el número de días")
                txtDias.Focus()
                Return
            End If

            If CInt(txtDias.Text) <= 0 Then
                msj_advert("El número de días no puede ser negativo")
                txtDias.Focus()
                Return
            End If

            If CInt(txtDias.Text) > 60 Then
                msj_advert("El número de días no puede ser mayor a 60")
                txtDias.Focus()
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE ACTUALIZAR LOS DÍAS DE VACACIONES DE ESTA PERSONA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coTrabajador With {
                .IdPersona = idPersona,
                .Dias = CInt(txtDias.Text)
            }

            Dim mensaje = cn.Cn_ActualizarDiasVacaciones(obj)
            If (obj.Coderror = 0) Then
                msj_ok(mensaje)
                Dispose()
            Else
                msj_advert(mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub txtDias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDias.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class