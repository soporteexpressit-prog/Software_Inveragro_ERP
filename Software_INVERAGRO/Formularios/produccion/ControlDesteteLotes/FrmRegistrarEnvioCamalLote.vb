Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRegistrarEnvioCamalLote
    Dim cn As New cnControlAnimal
    Dim loadNewImageFoto As Boolean = False
    Dim imagefoto As Byte() = Nothing
    Public listaIdsCriasConCod As String = ""
    Public cantidadEngordeCamal As Integer = 0
    Public cantidadTatuajeCamal As Integer = 0
    Public idMotivoEnvioCamal As Integer = 0
    Public idJaulaCorral As Integer = 0
    Public idLote As Integer = 0
    Public idPlantel As Integer = 0
    Public observacion As String = ""
    Public fecha As Date
    Public peso As Decimal
    Public frmMandarCamal As FrmRegistrarMandarCamalMortalidadLote
    Public esChanchilla As Boolean = False

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If picFoto.Image IsNot Nothing Then
                If (loadNewImageFoto) Then
                    Dim optimizedImageBytes As Byte() = clsBasicas.OptimizeImageFromPictureBox(picFoto)
                    picFoto.Image = clsBasicas.ByteArrayToImage(optimizedImageBytes)
                    imagefoto = optimizedImageBytes
                End If
            End If

            Dim obj As New coControlAnimal With {
                .ListaIdsCriasConCod = listaIdsCriasConCod,
                .CantidadCamalEngorde = cantidadEngordeCamal,
                .CantidadCamalTatuaje = cantidadTatuajeCamal,
                .IdLote = idLote,
                .IdPlantel = idPlantel,
                .ArchivoFotoCamal = If(loadNewImageFoto AndAlso imagefoto IsNot Nothing, imagefoto, Nothing),
                .IdMotivoMortalidadCamal = idMotivoEnvioCamal,
                .IdUsuario = VP_IdUser,
                .IdJaulaCorral = idJaulaCorral,
                .Observacion = observacion,
                .FechaControl = fecha,
                .Peso = peso,
                .EsChanchilla = esChanchilla
            }

            If (MessageBox.Show("¿ESTÁ SEGURO DE ENVIAR A CAMAL A ESTOS CERDOS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim MensajeBgWk As String = cn.Cn_RegistrarEnvioCamalLote(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                frmMandarCamal.LimpiarCampos()
                Dispose()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

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
        Me.Close()
    End Sub
End Class