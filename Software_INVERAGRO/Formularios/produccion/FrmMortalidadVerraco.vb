Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMortalidadVerraco
    Dim cn As New cnControlAnimal
    Public idAnimal As Integer = 0
    Public arete As String = ""
    Public idMotivoMortalidad As Integer = 0
    Dim loadNewImageFoto As Boolean = False
    Dim imagefoto As Byte() = Nothing

    Private Sub FrmMortalidadVerraco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LblCodArete.Text = arete
            TxtMotivoMortalidad.ReadOnly = True
            DtpFecha.Value = Now.Date
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCampoMotivoMortalidad(id As String, motivo As String)
        idMotivoMortalidad = id
        TxtMotivoMortalidad.Text = motivo
    End Sub

    Private Sub BtnMotivoMortalidad_Click(sender As Object, e As EventArgs) Handles BtnMotivoMortalidad.Click
        Dim frm As New FrmListarMotivoMortalidadVerraco(Me)
        frm.ShowDialog()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (DtpFecha.Value > Now.Date) Then
                msj_advert("La fecha de mortalidad no puede ser mayor a la fecha actual.")
                Return
            End If

            If picFoto.Image IsNot Nothing Then
                If (loadNewImageFoto) Then
                    Dim optimizedImageBytes As Byte() = clsBasicas.OptimizeImageFromPictureBox(picFoto)
                    picFoto.Image = clsBasicas.ByteArrayToImage(optimizedImageBytes)
                    imagefoto = optimizedImageBytes
                End If
            End If

            Dim obj As New coControlAnimal With {
                .FechaControl = DtpFecha.Value,
                .Codigo = idAnimal,
                .IdControlFichaMortalidad = idMotivoMortalidad,
                .ArchivoFotoMortalidad = If(loadNewImageFoto AndAlso imagefoto IsNot Nothing, imagefoto, Nothing),
                .IdUsuario = VP_IdUser
            }

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR LA MORTALIDAD DE " & arete & " ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim MensajeBgWk As String = cn.Cn_RegistrarMortalidadAnimal(obj)
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class