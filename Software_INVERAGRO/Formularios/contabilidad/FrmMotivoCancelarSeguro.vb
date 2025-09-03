Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMotivoCancelarSeguro
    Public Property Id_Seguro As Integer
    Dim cn As New cnControlSeguro

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (txtDescripcionAnulacion.Text = "" Or txtDescripcionAnulacion.ToString.Length < 5) Then
            MessageBox.Show("Debe ingresar una descripción de la anulación mayor a 5 caracteres.")
            Return
        Else
            Dim result As DialogResult = MessageBox.Show("¿Confirma que desea proceder con la cancelación de este seguro?", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Dim obj As New coControlSeguro
                obj.IdUsuarioAnulacion = VP_IdUser
                obj.Codigo = Id_Seguro
                obj.MotivoAnulacion = txtDescripcionAnulacion.Text
                Dim rpta As String = cn.Cn_CancelarSeguro(obj)
                Dispose()
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
    Private Sub FrmMotivoCancelarSeguro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDescripcionAnulacion.Text = ""
    End Sub
End Class