Imports CapaNegocio
Imports CapaObjetos

Public Class AnularPago
    Dim cn As New cnControlAsistencia
    Public idpago As Integer = 0
    Public operacion As Integer = 0
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub AnularPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim obj As New coControlAsistencia
        Dim mensaje As String = ""
        obj.idHorario = idpago
        obj.observacion = txtDescripcionAnulacion.Text
        obj.IdUsuario = VariablesGlobales.VP_IdUser
        If operacion = 0 Then
            mensaje = cn.Cn_AnularAsistencia(obj)
        ElseIf operacion = 1 Then
            mensaje = cn.Cn_Anularenviocuentas(obj)
        ElseIf operacion = 2 Then
            mensaje = cn.Cn_Anularbssociales(obj)
        End If
        If (obj.CodeError = 0) Then
            msj_ok(mensaje)
            Dispose()
        Else
            msj_advert(mensaje)
        End If
    End Sub
End Class