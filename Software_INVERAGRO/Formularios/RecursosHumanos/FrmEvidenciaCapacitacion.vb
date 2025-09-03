Imports System.IO

Public Class FrmEvidenciaCapacitacion
    Public rutaArchivoEvidencia As String

    Private Sub FrmEvidenciaCapacitacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Directory.Exists(rutaArchivoEvidencia) Then
            Dim archivosImagen As String() = Directory.GetFiles(rutaArchivoEvidencia, "*.jpg").Concat(Directory.GetFiles(rutaArchivoEvidencia, "*.jpeg")).Concat(Directory.GetFiles(rutaArchivoEvidencia, "*.png")).ToArray()

            If archivosImagen.Length >= 1 Then
                CargarImagenEnPictureBox(picEvidenciaCapacitacion1, archivosImagen(0))
            End If
            If archivosImagen.Length >= 2 Then
                CargarImagenEnPictureBox(picEvidenciaCapacitacion2, archivosImagen(1))
            End If
            If archivosImagen.Length >= 3 Then
                CargarImagenEnPictureBox(picEvidenciaCapacitacion3, archivosImagen(2))
            End If
            If archivosImagen.Length >= 4 Then
                CargarImagenEnPictureBox(picEvidenciaCapacitacion4, archivosImagen(3))
            End If

            picEvidenciaCapacitacion2.Visible = archivosImagen.Length >= 2
            picEvidenciaCapacitacion3.Visible = archivosImagen.Length >= 3
            picEvidenciaCapacitacion4.Visible = archivosImagen.Length >= 4
        Else
            MessageBox.Show("La carpeta de evidencias no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub CargarImagenEnPictureBox(pic As PictureBox, rutaImagen As String)
        If File.Exists(rutaImagen) Then
            pic.Image = Image.FromFile(rutaImagen)
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class