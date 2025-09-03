Public Class FrmMantDebitadoBCP
    Public indice As Integer
    Public _fechaProc As String
    Public _MedAt As String
    Public _SucAge As String
    Public _NumOperacion As String
    Public _Tipo As String
    Public _Descripcion As String
    Public _Lugar As String
    Public _CargoAbono As String
    Public _SaldoContable As String
    Public _Operacion As Integer
    Private Sub FrmMantDebitadoBCP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDescripcion.Select()

        If (_Operacion = 1) Then
            dtpFechaProc.Text = _fechaProc
            txtMedAt.Text = _MedAt
            txtSucAge.Text = _SucAge
            txtNumOperacion.Text = _NumOperacion
            txtTipo.Text = _Tipo
            txtDescripcion.Text = _Descripcion
            txtLugar.Text = _Lugar
            txtCargoAbono.Text = _CargoAbono
            txtSaldoContable.Text = _SaldoContable
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
        _fechaProc = FormatearFechaDiaMes(dtpFechaProc.Value)
        _MedAt = txtMedAt.Text
        _SucAge = txtSucAge.Text
        _NumOperacion = txtNumOperacion.Text
        _Tipo = txtTipo.Text
        _Descripcion = txtDescripcion.Text
        _Lugar = txtLugar.Text
        _CargoAbono = txtCargoAbono.Text
        _SaldoContable = txtSaldoContable.Text
    End Sub

    Private Function FormatearFechaDiaMes(fecha As DateTime) As String
        Return fecha.ToString("dd-MM")
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class