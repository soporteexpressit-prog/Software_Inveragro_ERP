Imports CapaNegocio
Imports CapaObjetos

Public Class FrmActualizarMotilidad
    Dim cn As New cnControlMaterialGenetico
    Public idMaterialGentico As Integer

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If (String.IsNullOrEmpty(TxtMotilidadDiluida.Text)) Then
                msj_advert("Debe ingresar la motilidad")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO ACTUALIZAR MOTILIDAD DE MATERIAL GENÉTICO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlMaterialGenetico With {
                .Codigo = idMaterialGentico,
                .MotilidadDiluida = TxtMotilidadDiluida.Text
            }

            Dim MensajeBgWk As String = cn.Cn_ActualizarMotilidadDiluMaterialGenetico(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Dispose()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class