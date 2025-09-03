Imports CapaNegocio
Imports CapaObjetos

Public Class FrmAnularBonificacionVehiculoNN
    Public Property Id_Bonificacion As Integer
    Dim cn As New cnControlBonificacionVehiculoNN
    Private Sub FrmAnularBonificacionVehiculoNN_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim result As DialogResult = MessageBox.Show("¿Confirma que desea proceder con la anular esta bonificación?", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Dim obj As New coControlBonificacionVehiculoNN
            obj.Codigo = Id_Bonificacion
            obj.IdUsuarioAnulacion = VP_IdUser
            obj.MotivoAnulacion = txtDescripcionAnulacion.Text
            Dim rpta As String = cn.Cn_AnularBonificacionVehiculoNN(obj)
            Dispose()
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class