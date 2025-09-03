Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantenimientoLogo
    Dim cn As New cnConfiguracion
    Dim imagefoto As Byte() = Nothing
    Dim seleccionar As Boolean = False
    Public configuracionId As Integer = 0
    Public frmPadre As Form

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim obj As New coConfiguracion
            obj.IdConfiguracion = configuracionId

            If picLogo.Image IsNot Nothing Then
                If (seleccionar) Then
                    Dim optimizedImageBytes As Byte() = clsBasicas.OptimizeImageFromPictureBox(picLogo)
                    picLogo.Image = clsBasicas.ByteArrayToImage(optimizedImageBytes)
                    imagefoto = optimizedImageBytes

                    obj.Imagen = If(imagefoto IsNot Nothing, imagefoto, Nothing)

                    Dim MensajeBgWk As String = ""
                    MensajeBgWk = cn.Cn_MantenimientoLogo(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(MensajeBgWk)
                        If TypeOf frmPadre Is FrmFormatoMemorandum1 Then
                            DirectCast(frmPadre, FrmFormatoMemorandum1).ActualizarContenido(configuracionId)
                        ElseIf TypeOf frmPadre Is FrmFormatoDespido Then
                            DirectCast(frmPadre, FrmFormatoDespido).ActualizarContenido(configuracionId)
                        End If
                    Else
                        msj_advert(MensajeBgWk)
                    End If
                    Dispose()
                Else
                    msj_advert("Seleccione un archivo de imagen")
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSubirEvidencia1_Click(sender As Object, e As EventArgs) Handles btnSubirEvidencia1.Click
        Dim ofd As New OpenFileDialog()
        ofd.Title = "Seleccionar Imagen"
        ofd.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp"
        ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)

        If ofd.ShowDialog() = DialogResult.OK Then
            picLogo.Image = Image.FromFile(ofd.FileName)
            seleccionar = True
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class