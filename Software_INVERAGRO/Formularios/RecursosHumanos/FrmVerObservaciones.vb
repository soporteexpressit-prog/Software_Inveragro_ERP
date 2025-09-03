Public Class FrmVerObservaciones

    Public observacion As String
    Public datosTrabajador As String

    Private Sub FrmVerObservaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializar()
    End Sub

    Private Sub Inicializar()
        txtObservaciones.Text = observacion
        txtDatosTrabajador.Text = datosTrabajador
        txtObservaciones.ReadOnly = True
        txtDatosTrabajador.ReadOnly = True
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class