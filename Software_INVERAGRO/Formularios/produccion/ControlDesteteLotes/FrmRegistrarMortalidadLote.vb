Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRegistrarMortalidadLote
    Dim cn As New cnControlAnimal
    Dim loadNewImageFoto As Boolean = False
    Dim imagefoto As Byte() = Nothing
    Public listaIdsCriasConCod As String = ""
    Public cantidadMuertosEngorde As Integer = 0
    Public cantidadMuertosTatuaje As Integer = 0
    Public idLote As Integer = 0
    Public idPlantel As Integer = 0
    Public cantidadMuertosConCod As Integer = 0
    Public observacion As String = ""
    Public idMotivoMortalidad As Integer = 0
    Public idJaulaCorral As Integer = 0
    Public fecha As Date
    Public frmMortalidad As FrmRegistrarMandarCamalMortalidadLote
    Public esChanchilla As Boolean = False

    Private Sub BtnSeleccionarEvidencia_Click(sender As Object, e As EventArgs) Handles BtnSeleccionarEvidencia.Click
        Dim ofd As New OpenFileDialog With {
            .Title = "Seleccionar Imagen",
            .Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        }
        If ofd.ShowDialog() = DialogResult.OK Then
            picFoto.Image = Image.FromFile(ofd.FileName)
            loadNewImageFoto = True
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If Not loadNewImageFoto Then
                msj_advert("Debe seleccionar una imagen")
                Exit Sub
            Else
                If picFoto.Image IsNot Nothing Then
                    If (loadNewImageFoto) Then
                        Dim optimizedImageBytes As Byte() = clsBasicas.OptimizeImageFromPictureBox(picFoto)
                        picFoto.Image = clsBasicas.ByteArrayToImage(optimizedImageBytes)
                        imagefoto = optimizedImageBytes
                    End If
                End If

                Dim obj As New coControlAnimal With {
                        .ListaIdsCriasConCod = listaIdsCriasConCod,
                        .CantidadMuertosEngorde = cantidadMuertosEngorde,
                        .CantidadMuertosTatuaje = cantidadMuertosTatuaje,
                        .IdLote = idLote,
                        .IdPlantel = idPlantel,
                        .CantidadMuertoConCod = cantidadMuertosConCod,
                        .Observacion = observacion,
                        .IdMotivoMortalidadCamal = idMotivoMortalidad,
                        .IdJaulaCorral = idJaulaCorral,
                        .IdUsuario = VP_IdUser,
                        .ArchivoFotoMortalidad = If(loadNewImageFoto AndAlso imagefoto IsNot Nothing, imagefoto, Nothing),
                        .FechaControl = fecha,
                        .EsChanchilla = esChanchilla
                }

                If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR LA MORTALIDAD DE LOS ANIMALES?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim MensajeBgWk As String = cn.Cn_RegistrarMortalidadLote(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    frmMortalidad.LimpiarCampos()
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