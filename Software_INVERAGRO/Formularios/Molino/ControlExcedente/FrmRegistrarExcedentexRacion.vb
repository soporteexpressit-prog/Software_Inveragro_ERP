Public Class FrmRegistrarExcedentexRacion
    Public codRacion As Integer = 0

    Private Sub FrmRegistrarExcedentexRacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscarRacion_Click(sender As Object, e As EventArgs) Handles BtnBuscarRacion.Click
        Try
            Dim frm As New FrmListaRacionesExcedente(Me)
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposRacion(codigo As Integer, nombre As String)
        codRacion = codigo
        TxtNombreRacion.Text = nombre
    End Sub
End Class