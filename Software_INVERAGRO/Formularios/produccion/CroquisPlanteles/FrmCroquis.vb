Public Class FrmCroquis

    Private Sub FrmCroquis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbPlantel2.Checked = True
        AbrirFomEnPanel(New FrmCroquisPlantel2)
    End Sub

    Private Sub AbrirFomEnPanel(ByVal FormHijo As Object)
        If Me.PanelContenedor.Controls.Count > 0 Then
            Me.PanelContenedor.Controls.RemoveAt(0)
        End If
        Dim fh As Form = TryCast(FormHijo, Form)
        fh.TopLevel = False
        fh.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        fh.Dock = DockStyle.Fill
        Me.PanelContenedor.Controls.Add(fh)
        Me.PanelContenedor.Tag = fh
        fh.Show()
    End Sub

    Private Sub rbPlantel1_CheckedChanged(sender As Object, e As EventArgs) Handles rbPlantel1.CheckedChanged
        AbrirFomEnPanel(New FrmCroquisPlantel1)
    End Sub

    Private Sub rbPlantel2_CheckedChanged(sender As Object, e As EventArgs) Handles rbPlantel2.CheckedChanged
        AbrirFomEnPanel(New FrmCroquisPlantel2)
    End Sub

    Private Sub rbPlantel3_CheckedChanged(sender As Object, e As EventArgs) Handles rbPlantel3.CheckedChanged
        AbrirFomEnPanel(New FrmCroquisPlantel3)
    End Sub

    Private Sub rbPlantel4_CheckedChanged(sender As Object, e As EventArgs) Handles rbPlantel4.CheckedChanged
        AbrirFomEnPanel(New FrmCroquisPlantel4)
    End Sub

    Private Sub rbPlantel5_CheckedChanged(sender As Object, e As EventArgs) Handles rbPlantel5.CheckedChanged
        AbrirFomEnPanel(New FrmCroquisPlantel5)
    End Sub

    Private Sub RbLineaProduccionReproductiva_CheckedChanged(sender As Object, e As EventArgs) Handles RbLineaProduccionReproductiva.CheckedChanged
        AbrirFomEnPanel(New FrmLineaProduccionReproductiva)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class