Imports System.IO
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantArchivoCotizacionOrdenCompra
    Dim cn As New cnIngreso
    Public Property Idingreso As Integer
    Private Sub btnSubirArchivo_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim obj As New coIngreso
            obj.Codigo = Idingreso

            If Not String.IsNullOrEmpty(txtArchivo.Text) Then
                Dim fileInfo As New FileInfo(txtArchivo.Text)
                If fileInfo.Length > 400 * 1024 Then
                    msj_advert("El archivo excede el tamaño máximo permitido de 400 kB.")
                    Return
                End If
                Dim pdfData As Byte() = File.ReadAllBytes(txtArchivo.Text)
                obj.SetArchivo(pdfData)
            End If

            If MsgBox("¿Esta Seguro de Registrar Archivo?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Ok Then
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_ActualizarArchivo(obj)
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

    Private Sub FrmMantArchivoMemorandum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtArchivo.ReadOnly = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub btnSubirArchivo_Click_1(sender As Object, e As EventArgs) Handles btnSubirArchivo.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Archivos PDF|*.pdf|Todos los archivos|*.*"
        openFileDialog.Title = "Selecciona un archivo PDF"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = openFileDialog.FileName
            txtArchivo.Text = selectedFilePath
        End If
    End Sub
End Class