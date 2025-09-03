Imports System.IO
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmGuardarEvidenciaCapacitacion
    Dim cn As New cnControlCapacitacion
    Public CapacitacionId As Integer
    Dim seleccionar1 As Boolean = False
    Dim seleccionar2 As Boolean = False
    Dim seleccionar3 As Boolean = False
    Dim seleccionar4 As Boolean = False

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If NumericUpDown1.Value = 4 Then
            picEvidencia4.Visible = True
            btnSubirEvidencia4.Visible = True
        ElseIf NumericUpDown1.Value = 3 Then
            picEvidencia4.Visible = False
            btnSubirEvidencia4.Visible = False

            picEvidencia4.Image = Formularios.My.Resources.Resources.sinimagen
            picEvidencia4.Tag = Nothing
            seleccionar4 = False
        End If
    End Sub

    Private Sub FrmGuardarEvidenciaCapacitacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NumericUpDown1.Minimum = 3
        NumericUpDown1.Maximum = 4
        NumericUpDown1.Value = 3

        picEvidencia4.Visible = False
        btnSubirEvidencia4.Visible = False
    End Sub

    Private Sub btnSubirEvidencia1_Click(sender As Object, e As EventArgs) Handles btnSubirEvidencia1.Click
        CargarImagen(picEvidencia1, 1)
    End Sub

    Private Sub btnSubirEvidencia2_Click(sender As Object, e As EventArgs) Handles btnSubirEvidencia2.Click
        CargarImagen(picEvidencia2, 2)
    End Sub

    Private Sub btnSubirEvidencia3_Click(sender As Object, e As EventArgs) Handles btnSubirEvidencia3.Click
        CargarImagen(picEvidencia3, 3)
    End Sub

    Private Sub btnSubirEvidencia4_Click(sender As Object, e As EventArgs) Handles btnSubirEvidencia4.Click
        CargarImagen(picEvidencia4, 4)
    End Sub

    Private Sub CargarImagen(pic As PictureBox, numEvidencia As Integer)
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            pic.Image = Image.FromFile(openFileDialog.FileName)
            pic.Tag = openFileDialog.FileName

            If (numEvidencia = 1) Then
                seleccionar1 = True
            ElseIf (numEvidencia = 2) Then
                seleccionar2 = True
            ElseIf (numEvidencia = 3) Then
                seleccionar3 = True
            Else
                seleccionar4 = True
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim totalImagensEsperadas As Integer = NumericUpDown1.Value
        Dim imagenesCargadas As Integer = 0
        Dim carpetaCreada As Boolean = False

        If ValidarImagenSeleccionada() Then
            Dim fechaHora As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
            Dim nombreCarpeta As String = String.Format("{0}_{1}", CapacitacionId, fechaHora)
            Dim rutaCarpeta = Path.Combine("C:\Users\Administrator\Documents\evidencia_capacitaciones", nombreCarpeta)

            If Not Directory.Exists(rutaCarpeta) Then
                Directory.CreateDirectory(rutaCarpeta)
                carpetaCreada = True
            End If

            If carpetaCreada Then
                If seleccionar1 Then
                    GuardarImagen(picEvidencia1, rutaCarpeta, "Evidencia1")
                    imagenesCargadas += 1
                End If

                If seleccionar2 Then
                    GuardarImagen(picEvidencia2, rutaCarpeta, "Evidencia2")
                    imagenesCargadas += 1
                End If

                If seleccionar3 Then
                    GuardarImagen(picEvidencia3, rutaCarpeta, "Evidencia3")
                    imagenesCargadas += 1
                End If

                If totalImagensEsperadas = 4 AndAlso seleccionar4 Then
                    GuardarImagen(picEvidencia4, rutaCarpeta, "Evidencia4")
                    imagenesCargadas += 1
                End If

                If imagenesCargadas = totalImagensEsperadas Then
                    Dim obj As New coControlCapacitacion
                    obj.Codigo = CapacitacionId
                    obj.RutaEvidencia = rutaCarpeta

                    Dim MensajeBgWk As String = ""
                    MensajeBgWk = cn.Cn_RegistrarRutaEvidencia(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(MensajeBgWk)
                        Dispose()
                    Else
                        msj_advert(MensajeBgWk)
                    End If
                End If
            End If
        End If
    End Sub

    Private Function ValidarImagenSeleccionada() As Boolean
        Dim totalImagensEsperadas As Integer = NumericUpDown1.Value

        If totalImagensEsperadas >= 1 AndAlso Not seleccionar1 Then
            msj_advert("Seleccione un archivo de evidencia 01. Debe cargar todas las imágenes antes de guardar.")
            Return False
        End If

        If totalImagensEsperadas >= 2 AndAlso Not seleccionar2 Then
            msj_advert("Seleccione un archivo de evidencia 02. Debe cargar todas las imágenes antes de guardar.")
            Return False
        End If

        If totalImagensEsperadas >= 3 AndAlso Not seleccionar3 Then
            msj_advert("Seleccione un archivo de evidencia 03. Debe cargar todas las imágenes antes de guardar.")
            Return False
        End If

        If totalImagensEsperadas = 4 AndAlso Not seleccionar4 Then
            msj_advert("Seleccione un archivo de evidencia 04. Debe cargar todas las imágenes antes de guardar.")
            Return False
        End If

        Return True
    End Function

    Private Sub GuardarImagen(pic As PictureBox, rutaCarpeta As String, nombreImagen As String)
        If pic.Image IsNot Nothing AndAlso pic.Tag IsNot Nothing Then
            Dim extension As String = Path.GetExtension(pic.Tag.ToString())
            Dim rutaDestino As String = Path.Combine(rutaCarpeta, nombreImagen & extension)
            pic.Image.Save(rutaDestino)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class