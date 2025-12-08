Imports CapaNegocio
Imports CapaObjetos

Public Class FrmEditarDestete
    Dim cn As New cnControlLoteDestete
    Public idControlFicha As Integer = 0
    Public peso As Decimal = 0

    Private Sub FrmEditarDestete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LblPesoActual.Text = peso.ToString("N2") & " kg"
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If (TxtPesoTotal.Text = String.Empty) Then
                msj_advert("DEBE INGRESAR EL PESO TOTAL DEL LOTE")
                TxtPesoTotal.Focus()
                Return
            End If

            If (CDec(TxtPesoTotal.Text) <= 0) Then
                msj_advert("DEBE INGRESAR EL PESO TOTAL MAYOR A 0")
                TxtPesoTotal.Focus()
                Return
            End If

            If (idControlFicha <= 0) Then
                msj_advert("ID DE FICHA DE CONTROL NO VÁLIDO")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DEL PESO A REGISTRAR?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .IdControlFicha = idControlFicha,
                .PesoTotal = TxtPesoTotal.Text
            }

            Dim MensajeBgWk As String = cn.Cn_ActualizarPesoDestete(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Dispose()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class