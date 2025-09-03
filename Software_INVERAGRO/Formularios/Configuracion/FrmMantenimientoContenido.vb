
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantenimientoContenido
    Dim cn As New cnConfiguracion
    Public idConfiguracion As Integer
    Public contenido As String
    Public frmPadre As Form

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (txtContenido.Text = "" Or txtContenido.ToString.Length < 5) Then
            MessageBox.Show("Debe ingresar una contenido del parrafo mayor a 5 caracteres.")
            Return
        Else
            Dim result As DialogResult = MessageBox.Show("¿Está seguro que desea actualizar el contenido?", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Dim _mensaje As String = ""
                Dim obj As New coConfiguracion
                obj.IdConfiguracion = idConfiguracion
                obj.Texto = txtContenido.Text

                _mensaje = cn.Cn_MantenimientoContenido(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(_mensaje)
                    If TypeOf frmPadre Is FrmFormatoMemorandum1 Then
                        DirectCast(frmPadre, FrmFormatoMemorandum1).ActualizarContenido(idConfiguracion)
                    ElseIf TypeOf frmPadre Is FrmFormatoDespido Then
                        DirectCast(frmPadre, FrmFormatoDespido).ActualizarContenido(idConfiguracion)
                    End If
                Else
                    msj_advert(_mensaje)
                End If
                Dispose()
            End If
        End If
    End Sub

    Private Sub FrmMantenimientoContenido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtContenido.Text = contenido
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class