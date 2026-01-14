Imports CapaNegocio
Imports CapaObjetos

Public Class FrmAnularventavendedoras
    Public idordencompra As Integer
    Dim cn As New cnVentas
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' Verifica si la descripción de anulación es válida
        If String.IsNullOrWhiteSpace(txtDescripcionAnulacion.Text) OrElse txtDescripcionAnulacion.Text.Length < 5 Then
            MessageBox.Show("Debe ingresar una descripción de la anulación mayor a 5 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Confirmación de la anulación
        Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea anular este Pedido de Venta?", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                ' Crea el objeto y asigna los valores necesarios
                Dim obj As New coVentas With {
                .Codigo = idordencompra,
                .Motivoanulacion = txtDescripcionAnulacion.Text,
                .Iduser = VariablesGlobales.VP_IdUser
            }

                ' Realiza la anulación a través de la función correspondiente
                Dim mensaje As String = cn.Cn_AnularPedidoVentasdistribucionventas(obj)

                ' Verifica el resultado de la operación
                If obj.Coderror = 0 Then
                    msj_ok(mensaje)
                    Me.Dispose() ' Cierra el formulario actual
                Else
                    msj_advert(mensaje)
                End If
            Catch ex As Exception
                MessageBox.Show("Ocurrió un error al intentar anular el Pedido de Venta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub FrmAnularEntregaEpp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDescripcionAnulacion.Text = ""
    End Sub
End Class