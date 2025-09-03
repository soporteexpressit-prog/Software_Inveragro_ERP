Imports CapaNegocio
Imports CapaObjetos

Public Class FrmCancelarPedidoAlimento
    Public IdPedidoAlimento As Integer
    Public _idsDetalle As String
    Public _tipoAlimento As String
    Public _estado As String
    Dim cn As New cnControlAlimento

    Private Sub FrmCancelarPedidoAlimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDescripcionAnulacion.Text = ""
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (txtDescripcionAnulacion.Text = "" Or txtDescripcionAnulacion.ToString.Length < 5) Then
                MessageBox.Show("Debe ingresar una descripción de la anulación mayor a 5 caracteres.")
                Return
            Else
                Dim result As DialogResult = MessageBox.Show("¿Está seguro de cancelar este requerimiento de alimento?", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If result = DialogResult.Yes Then
                    Dim obj As New coControlAlimento With {
                        .Codigo = IdPedidoAlimento,
                        .IdUserAnulacion = VP_IdUser,
                        .MotivoAnulacion = txtDescripcionAnulacion.Text
                    }
                    Dim rpta As String = cn.Cn_AnularRequerimientoAlimento(obj)
                    Dispose()
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class