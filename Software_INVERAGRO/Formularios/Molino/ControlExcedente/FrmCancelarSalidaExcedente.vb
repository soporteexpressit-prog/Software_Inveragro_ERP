Imports CapaNegocio
Imports CapaObjetos

Public Class FrmCancelarSalidaExcedente
    Public Property IdSalidaExcedente As Integer
    Dim cn As New cnControlExcedente

    Private Sub FrmCancelarSalidaExcedente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDescripcionCancelar.Text = ""
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (txtDescripcionCancelar.Text = "" Or txtDescripcionCancelar.ToString.Length < 5) Then
            MessageBox.Show("Debe ingresar una descripción de la anulación mayor a 5 caracteres.")
            Return
        Else
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ANULAR ESTE REGISTRO?", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Dim obj As New coControlExcedente
                obj.IdUserAnulacion = VP_IdUser
                obj.Codigo = IdSalidaExcedente
                obj.MotivoAnulacion = txtDescripcionCancelar.Text
                Dim rpta As String = cn.Cn_CancelarSalidaInsumoExcedente(obj)
                Dispose()
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class