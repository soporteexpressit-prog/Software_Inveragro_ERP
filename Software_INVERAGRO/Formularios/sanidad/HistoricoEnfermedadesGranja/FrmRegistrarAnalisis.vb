Imports System.IO
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRegistrarAnalisis

    Dim cn As New cnControlMedico
    Public codigo As Integer = 0

    Private Sub FrmRegistrarAnalisis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        DtpFechaRegistro.Value = Date.Now
        TxtArchivo.ReadOnly = True
    End Sub

    Private Sub btnarchivoadjunto_Click(sender As Object, e As EventArgs) Handles btnarchivoadjunto.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf"
        openFileDialog.Title = "Seleccionar archivo PDF"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = openFileDialog.FileName
            TxtArchivo.Text = selectedFilePath
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If DtpFechaRegistro.Value > Date.Now Then
                msj_advert("La fecha de registro no puede ser mayor a la fecha actual")
                DtpFechaRegistro.Value = Date.Now
                Return
            End If

            If String.IsNullOrEmpty(TxtObservacion.Text) Then
                msj_advert("Ingrese una observación")
                Return
            End If

            If String.IsNullOrEmpty(TxtArchivo.Text) Then
                msj_advert("Seleccione un archivo PDF")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR EL ANÁLISIS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlMedico With {
                .Codigo = codigo,
                .FechaControl = DtpFechaRegistro.Value,
                .Observacion = TxtObservacion.Text
            }

            If Not String.IsNullOrEmpty(TxtArchivo.Text) Then
                Dim fileInfo As New FileInfo(TxtArchivo.Text)
                If fileInfo.Length > 400 * 1024 Then
                    msj_advert("El archivo excede el tamaño máximo permitido de 400 kB.")
                    Return
                End If
                Dim pdfData As Byte() = File.ReadAllBytes(TxtArchivo.Text)
                obj.SetArchivo(pdfData)
            End If

            Dim mensaje As String = cn.Cn_RegistrarAnalisis(obj)
            If (obj.Coderror = 0) Then
                msj_ok(mensaje)
                Close()
            Else
                msj_advert(mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Close()
    End Sub
End Class