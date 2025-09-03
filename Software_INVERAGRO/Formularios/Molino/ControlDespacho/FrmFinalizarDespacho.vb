Imports CapaNegocio
Imports CapaObjetos

Public Class FrmFinalizarDespacho
    Public IdSalida As Integer
    Dim cn As New cnControlDespacho

    Private Sub FrmFinalizarDespacho_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDescripcion.Text = ""
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (txtDescripcion.Text = "" Or txtDescripcion.ToString.Length < 5) Then
            MessageBox.Show("Debe ingresar una descripción de la anulación mayor a 5 caracteres.")
            Return
        Else
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE FINALIZAR EL PEDIDO DE ALIMENTO?", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Dim obj As New coControlDespacho With {
                    .Codigo = IdSalida,
                    .IdUserAnulacion = VP_IdUser,
                    .MotivoAnulacion = txtDescripcion.Text
                }
                Dim rpta As String = cn.Cn_FinalizarRequerimientoAlimento(obj)
                Dispose()
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class