Public Class FrmMantDebitadoCajaPiura
    Public indice As Integer
    Public _NrmDias As Integer
    Public _Concepto As String
    Public _Deposito As String
    Public _Itf As String
    Public _Retiro As String
    Public _Itf_ As String
    Public _Orden As String
    Public _Saldo As String
    Public _Operacion As Integer

    Private Sub FrmMantDebitadoCajaPiura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtConcepto.Select()

        If (_Operacion = 1) Then
            txtNrmDias.Text = _NrmDias
            txtConcepto.Text = _Concepto
            txtDeposito.Text = _Deposito
            txtItf.Text = _Itf
            txtRetiro.Text = _Retiro
            txtItf_.Text = _Itf_
            txtOrden.Text = _Orden
            txtSaldo.Text = _Saldo
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (MessageBox.Show("¿Desea guardar los cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
            Return
        End If

        Actualizar()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Actualizar()
        _NrmDias = txtNrmDias.Text
        _Concepto = txtConcepto.Text
        _Deposito = txtDeposito.Text
        _Itf = txtItf.Text
        _Retiro = txtRetiro.Text
        _Itf_ = txtItf_.Text
        _Orden = txtOrden.Text
        _Saldo = txtSaldo.Text
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class