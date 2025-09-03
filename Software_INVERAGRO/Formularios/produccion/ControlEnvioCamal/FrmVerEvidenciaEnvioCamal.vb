Imports System.IO
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmVerEvidenciaEnvioCamal
    Dim cn As New cnControlAnimal
    Public idHistorialEnvioCamal As Integer = 0

    Private Sub FrmVerEvidenciaEnvioCamal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim obj As New coControlAnimal With {
                .IdHistorialEnvioCamal = idHistorialEnvioCamal
            }

            Dim archivoFoto() As Byte = cn.Cn_ConsultarArchivoCamal(obj)

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