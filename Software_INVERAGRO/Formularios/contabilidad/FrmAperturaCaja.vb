Imports CapaNegocio
Imports CapaObjetos

Public Class FrmAperturaCaja

    Private Sub FReg_Caja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObtenerSaldo()
        txt_glosa.Select()
        dtfecha.Value = Now.Date
        CenterGroupBox()
    End Sub
    Sub ObtenerSaldo()
        txtsaldoanterior.Text = clsBasicas.ObtenerSaldoAnteriorCaja().ToString
    End Sub
    Sub AperturarCaja()
        Dim la As New cnCaja
        Dim obj As New coCaja With {
            .Mi = txtmonto.Text,
            .Observacion = txt_glosa.Text,
            .Iduser = VP_IdUser,
            .Saldoanterior = txtsaldoanterior.Text
        }
        Dim MensajeBgWk As String = la.Cn_AperturaCaja(obj)
        If (obj.Codreturn = 0) Then
            msj_ok(MensajeBgWk)
            Dispose()
        Else
            msj_advert(MensajeBgWk)
        End If
    End Sub
    'Sub Obtene

    Private Sub txtmonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub


    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub ToolStripGuardar_Click_1(sender As Object, e As EventArgs) Handles ToolStripGuardarctac.Click
        If String.IsNullOrWhiteSpace(txtmonto.Text) OrElse Not IsNumeric(txtmonto.Text) Then
            msj_advert("Ingrese un monto válido, por favor")
            txtmonto.Select()
        ElseIf CDec(txtmonto.Text) < 0 Then
            msj_advert("El monto debe ser mayor a 0")
            txtmonto.Select()
        ElseIf String.IsNullOrWhiteSpace(txt_glosa.Text) Then
            msj_advert("Ingrese una Observación")
            txt_glosa.Select()
        Else
            AperturarCaja()
        End If
        'basicas.Obtener_Valores_x_Usuario()
    End Sub

    Private Sub txtmonto_TextChanged(sender As Object, e As EventArgs) Handles txtmonto.TextChanged
        Static isFirstEntry As Boolean = True
        If isFirstEntry Then
            txtmonto.Clear()
            isFirstEntry = False
        End If
    End Sub

    Private Sub CenterGroupBox()
        If GroupBox1 IsNot Nothing Then
            ' Calcula la posición para centrar el GroupBox
            GroupBox1.Left = (Me.ClientSize.Width - GroupBox1.Width) / 2
            GroupBox1.Top = (Me.ClientSize.Height - GroupBox1.Height) / 2
        End If
    End Sub

    Private Sub FrmAperturaCaja_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        CenterGroupBox()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class