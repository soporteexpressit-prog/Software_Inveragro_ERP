Imports CapaNegocio
Imports CapaObjetos

Public Class FrmDarBajaActivo
    Public Property Id_Activo As Integer
    Dim cn As New cnActivo
    Private Sub FrmDarBajaActivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDescripcionAnulacion.Text = ""
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (txtDescripcionAnulacion.Text = "" Or txtDescripcionAnulacion.ToString.Length < 5) Then
            MessageBox.Show("Debe ingresar una descripción de la anulación mayor a 5 caracteres.")
            Return
        Else
            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea dar de baja este Activo?", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Dim obj As New coActivo
                obj.Codigo = Id_Activo
                obj.IdUserAnulacion = VP_IdUser
                obj.MotivoAnulacion = txtDescripcionAnulacion.Text
                Dim rpta As String = cn.Cn_DarBajaActivo(obj)
                Dispose()
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class