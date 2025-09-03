Imports CapaNegocio
Imports CapaObjetos

Public Class FrmAnularAbonoCuentaPagar
    Public Property coddetallecuentapagar As Integer
    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (txtmotivoanulacion.Text.Length = 0) Then
                msj_advert("Ingrese un Motivo")
                Return
            Else
                Dim cn As New cnCtaPagar
                Dim obj As New coCtaPagar
                obj.Idcuentapagar = coddetallecuentapagar
                obj.Idusuario = VP_IdUser
                obj.Motivoanulacion = txtmotivoanulacion.Text

                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_AnularAbonoCtaPagar(obj)

                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Dispose()
                Else
                    msj_advert(MensajeBgWk)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class