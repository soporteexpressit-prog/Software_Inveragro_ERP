Imports System.IO

Public Class FrmEvidenciaCapacitacion
    Public rutaArchivoEvidencia As String

    Private Sub FrmEvidenciaCapacitacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Convertir rutas antiguas (C:\Users\Administrator\...) a relativas
            Dim rutaFinal As String = ConvertirRutaARelativa(rutaArchivoEvidencia)

            ' Crear la carpeta si no existe
            If Not Directory.Exists(rutaFinal) Then
                Directory.CreateDirectory(rutaFinal)
            End If

            If Directory.Exists(rutaFinal) Then
                Dim archivosImagen As String() = Directory.GetFiles(rutaFinal, "*.jpg").Concat(Directory.GetFiles(rutaFinal, "*.jpeg")).Concat(Directory.GetFiles(rutaFinal, "*.png")).ToArray()

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

                ' Si no hay imágenes, mostrar mensaje
                If archivosImagen.Length = 0 Then
                    MessageBox.Show("La carpeta existe pero no contiene imágenes.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("No se pudo crear la carpeta de evidencias." & vbCrLf & "Ruta: " & rutaFinal, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar evidencias: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Convierte rutas antiguas absolutas a relativas con respecto a la carpeta de la aplicación
    ''' </summary>
    Private Function ConvertirRutaARelativa(rutaOriginal As String) As String
        If String.IsNullOrEmpty(rutaOriginal) Then
            ' Si no hay ruta, crear una por defecto
            Return Path.Combine(Application.StartupPath, "evidencia_capacitaciones")
        End If

        ' Si ya es una ruta relativa, devolverla tal cual
        If Not Path.IsPathRooted(rutaOriginal) Then
            Return Path.Combine(Application.StartupPath, rutaOriginal)
        End If

        ' Si contiene la ruta antigua, extraer solo la parte relativa
        If rutaOriginal.Contains("evidencia_capacitaciones") Then
            ' Buscar desde "evidencia_capacitaciones" hacia adelante
            Dim indice As Integer = rutaOriginal.IndexOf("evidencia_capacitaciones")
            If indice >= 0 Then
                Dim rutaRelativa As String = rutaOriginal.Substring(indice)
                Return Path.Combine(Application.StartupPath, rutaRelativa)
            End If
        End If

        ' Si no se puede convertir, devolver la ruta original
        Return rutaOriginal
    End Function

    Private Sub CargarImagenEnPictureBox(pic As PictureBox, rutaImagen As String)
        Try
            If File.Exists(rutaImagen) Then
                pic.Image = Image.FromFile(rutaImagen)
            End If
        Catch ex As Exception
            ' Ignorar errores de imágenes individuales
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class