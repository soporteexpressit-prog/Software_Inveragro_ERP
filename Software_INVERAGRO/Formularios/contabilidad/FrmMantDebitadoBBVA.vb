Public Class FrmMantDebitadoBBVA
    Public indice As Integer
    Public _fechaOperacion As String
    Public _fechaValor As String
    Public _descripcionOficina As String
    Public _can As String
    Public _nOperacion As String
    Public _cargoAbono As String
    Public _itf As String
    Public _saldoContable As String
    Public _operacion As Integer
    Private Sub FrmMantDebitadoBBVA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDescripcionOficina.Select()

        If (_operacion = 1) Then
            dtpFechaOperacion.Text = _fechaOperacion
            dtpFechaValor.Text = _fechaValor
            txtDescripcionOficina.Text = _descripcionOficina
            txtCan.Text = _can
            txtNumOperacion.Text = _nOperacion
            txtCargoAbono.Text = _cargoAbono
            txtItf.Text = _itf
            txtSaldoContable.Text = _saldoContable
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
        _fechaOperacion = FormatearFechaDiaMes(dtpFechaOperacion.Value)
        _fechaValor = FormatearFechaDiaMes(dtpFechaValor.Value)
        _descripcionOficina = txtDescripcionOficina.Text
        _can = txtCan.Text
        _nOperacion = txtNumOperacion.Text
        _cargoAbono = txtCargoAbono.Text
        _itf = txtItf.Text
        _saldoContable = txtSaldoContable.Text
    End Sub
    Private Function FormatearFechaDiaMes(fecha As DateTime) As String
        Return fecha.ToString("dd-MM")
    End Function
End Class