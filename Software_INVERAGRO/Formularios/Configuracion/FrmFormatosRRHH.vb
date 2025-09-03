Public Class FrmFormatosRRHH
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

    Private Sub rbFormatoDespido_CheckedChanged(sender As Object, e As EventArgs) Handles rbFormatoMemo.CheckedChanged
        AbrirFomEnPanel(New FrmFormatoMemorandum1)
    End Sub

    Private Sub rbFormatoMemo_CheckedChanged(sender As Object, e As EventArgs) Handles rbFormatoDespido.CheckedChanged
        AbrirFomEnPanel(New FrmFormatoDespido)
    End Sub

    Private Sub FrmFormatosRRHH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbFormatoMemo.Checked = True
        AbrirFomEnPanel(New FrmFormatoMemorandum1)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
End Class