Imports CapaNegocio
Imports CapaObjetos
Imports Stimulsoft.Report.Func

Public Class FrmAnularCtaPagar
    Public Property codcta As Integer
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
                obj.Idcuentapagar = codcta
                obj.Idusuario = VP_IdUser
                obj.Motivoanulacion = txtmotivoanulacion.Text

                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_AnularCtaPagar(obj)

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

    Private Sub FrmAnularCtaPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub
    Private Sub FrmAnularCtaPagar_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' Verifica si se presionan Control y Espacio al mismo tiempo
        If e.Control AndAlso e.KeyCode = Keys.Space Then
            btnGuardar.PerformClick()  ' Ejecuta el clic del botón
        End If
    End Sub
End Class