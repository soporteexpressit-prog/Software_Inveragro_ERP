Imports CapaNegocio
Imports CapaObjetos
Imports System.IO

Public Class Frmagregarpdfguiatraslado

    Dim cn As New cnVentas
    Public Property guiaid As Integer
    Private Sub btnSubirArchivo_Click(sender As Object, e As EventArgs) Handles btnSubirArchivo.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Archivos PDF|*.pdf|Todos los archivos|*.*"
        openFileDialog.Title = "Selecciona un archivo PDF"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = openFileDialog.FileName
            txtArchivo.Text = selectedFilePath
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub Frmagregarpdfguiatraslado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtArchivo.ReadOnly = True
        Consultar()
    End Sub
    Sub Consultar()
        Dim obj As New coVentas
        Dim cn As New cnVentas
        obj.Codigo = guiaid
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarxCodigo(obj).Copy
        tb.TableName = "tmp"
        If tb.Rows.Count > 0 Then
            With tb.Rows(0)
                dtfecharecepcion.Value = .Item(1).ToString()
                dttraslado.Value = .Item(7).ToString()
                txthorometroincial.Text = .Item(18).ToString()
                txtodometro.Text = .Item(22).ToString()
            End With
        Else
            MessageBox.Show("No se encontró ningún registro con el código especificado.")
        End If
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim obj As New coVentas
            obj.Codigo = guiaid
            obj.Fechadesde = dtfecharecepcion.Value
            obj.Fechahasta = dttraslado.Value
            obj.Horometro_incial = txthorometroincial.Text
            obj.odometro_inicial = txtodometro.Text
            If (txthorometroincial.Text.Length = 0) Then
                msj_advert("Ingrese el Horómetro Inicial")
                Return
            End If
            If Not String.IsNullOrEmpty(txtArchivo.Text) Then
                Dim fileInfo As New FileInfo(txtArchivo.Text)
                If fileInfo.Length > 1024 * 1024 Then
                    msj_advert("El archivo excede el tamaño máximo permitido de 400 kB.")
                    Return
                End If
                Dim pdfData As Byte() = File.ReadAllBytes(txtArchivo.Text)
                obj.SetArchivo(pdfData)
            End If

            If MsgBox("¿Esta Seguro de Registrar Archivo?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Ok Then
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_actualizarregistroguiapdf(obj)
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

    Private Sub txthorometroincial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txthorometroincial.KeyPress, txtodometro.KeyPress
        clsBasicas.ValidarNumerosDecimales(e)
    End Sub
End Class