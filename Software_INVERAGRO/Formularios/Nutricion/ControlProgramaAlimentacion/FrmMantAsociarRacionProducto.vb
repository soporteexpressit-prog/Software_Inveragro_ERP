Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantAsociarRacionProducto
    Dim cn As New cnControlFormulacion
    Dim idProducto1 As Integer = 0
    Dim idProducto2 As Integer = 0

    Private Sub FrmMantAsociarRacionProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnProductoEquivalencia1_Click(sender As Object, e As EventArgs) Handles BtnProductoEquivalencia1.Click
        Try
            Dim frm As New FrmListarProductoRacion(Me, 1)
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnProductoEquivalencia2_Click(sender As Object, e As EventArgs) Handles BtnProductoEquivalencia2.Click
        Try
            Dim frm As New FrmListarProductoRacion(Me, 2)
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposProductoEquivalencia(id As Integer, nombre As String, productoDestino As Integer)
        If productoDestino = 1 Then
            idProducto1 = id
            TxtNombreEqProducto1.Text = nombre
        ElseIf productoDestino = 2 Then
            idProducto2 = id
            TxtNombreEqProducto2.Text = nombre
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (idProducto1 = 0 Or idProducto2 = 0) Then
                msj_advert("Debe seleccionar ambos productos de equivalencia.")
                Return
            End If

            Dim obj As New coControlFormulacion With {
                .Codigo = idProducto1,
                .IdNucleo = idProducto2
            }

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR ASOCIAR ESTOS PRODUCTOS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim MensajeBgWk As String = cn.Cn_MantenimientoAgrupacionProductoRacion(obj)
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class