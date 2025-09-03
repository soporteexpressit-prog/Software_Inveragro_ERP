Imports CapaNegocio
Imports CapaObjetos

Public Class FrmAnularEntregaEpp
    Public Property Id_EntregaEpp As Integer
    Dim cn As New cnControlEpp

    Private Sub FrmAnularEntregaEpp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDescripcionAnulacion.Text = ""
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (txtDescripcionAnulacion.Text = "" Or txtDescripcionAnulacion.ToString.Length < 5) Then
            MessageBox.Show("Debe ingresar una descripción de la anulación mayor a 5 caracteres.")
            Return
        Else
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO QUE DESEA ANULAR ESTE REGISTRO?", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Dim obj As New coControlEpp With {
                    .IdUserAnulacion = VP_IdUser,
                    .Codigo = Id_EntregaEpp,
                    .MotivoAnulacion = txtDescripcionAnulacion.Text
                }

                Dim MensajeBgWk As String = cn.Cn_AnularEpp(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Dispose()
                Else
                    msj_advert(MensajeBgWk)
                End If
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class