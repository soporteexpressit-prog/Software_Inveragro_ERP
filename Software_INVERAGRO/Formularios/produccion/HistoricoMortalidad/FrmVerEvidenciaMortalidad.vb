Imports CapaNegocio
Imports CapaObjetos
Imports System.IO

Public Class FrmVerEvidenciaMortalidad
    Dim cn As New cnControlAnimal
    Public idControlFicha As Integer = 0

    Private Sub FrmVerEvidenciaEnvioCamal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim obj As New coControlAnimal With {
                .IdControlFichaMortalidad = idControlFicha
            }

            Dim archivoFoto() As Byte = cn.Cn_ConsultarArchivoMortalidad(obj)

            If archivoFoto IsNot Nothing AndAlso archivoFoto.Length > 0 Then
                Using ms As New MemoryStream(archivoFoto)
                    picFoto.Image = Image.FromStream(ms)
                End Using
            Else
                msj_advert("No se encontró ninguna evidencia para este registro.")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class