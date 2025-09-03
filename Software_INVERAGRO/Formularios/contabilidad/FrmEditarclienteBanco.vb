Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmEditarclienteBanco
    Public codigo As Integer
    Public operacion As Integer
    Dim cn As New cnCtaCobrar
    Private Sub FrmEditarclienteBanco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        If operacion = 1 Then
            btnGuardar.Visible = False
            btnactualizarproveedorventa.Visible = True
            Text = "ACTUALIZAR PROVEEDOR DE VENTA"
            ConsultarproveedorVenta()
        Else
            Consultar()
            btnactualizarproveedorventa.Visible = False
        End If
    End Sub
    Private Sub FrmEditarclienteBanco_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' Verifica si se presionan Control y Espacio al mismo tiempo
        If e.Control AndAlso e.KeyCode = Keys.Space Then
            btnGuardar.PerformClick()  ' Ejecuta el clic del botón
        End If
    End Sub
    Sub Consultar()
        Try
            Dim obj As New coCtaCobrar With {
                .Id = codigo
            }

            Dim dt As DataTable = cn.Cn_consultarxidcobrar(obj)

            If dt.Rows.Count > 0 Then
                Dim fila As DataRow = dt.Rows(0) ' Tomar la primera fila del resultado

                txtcodproveedor.Text = fila("codigo").ToString()
                txtproveedor.Text = fila("datos").ToString()
            Else
                MessageBox.Show("No se encontraron datos para el transporte seleccionado.", "Consultar Transporte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar los datos del transporte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Sub ConsultarproveedorVenta()
        Try
            Dim obj As New coCtaCobrar With {
                .Id = codigo
            }
            Dim dt As DataTable = cn.Cn_consultarxidventacobrar(obj)
            If dt.Rows.Count > 0 Then
                Dim fila As DataRow = dt.Rows(0) ' Tomar la primera fila del resultado
                txtcodproveedor.Text = fila("codigo").ToString()
                txtproveedor.Text = fila("datos").ToString()
            Else
                MessageBox.Show("No se encontraron datos para el transporte seleccionado.", "Consultar Transporte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar los datos del transporte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnbuscarpoveedor_Click(sender As Object, e As EventArgs) Handles btnbuscarpoveedor.Click
        Dim f As New FrmBuscarProveedorTrabajador
        f.ShowDialog()
        If (f.codproveedor <> 0) Then
            txtcodproveedor.Text = f.codproveedor
            txtproveedor.Text = f.razonsocial
            f.codproveedor = 0
        Else
            txtcodproveedor.Clear()
            txtproveedor.Clear()
        End If
    End Sub

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim obj As New coCtaCobrar
        obj.Id = txtcodproveedor.Text
        obj.Idcondicionpago = codigo
        Dim rpta As String = cn.Cn_actualizar_cliente(obj)
        If (obj.Coderror = 0) Then
            msj_ok(rpta)
            Me.Close()
        Else
            msj_advert(rpta)
        End If
    End Sub

    Private Sub btnactualizarproveedorventa_Click(sender As Object, e As EventArgs) Handles btnactualizarproveedorventa.Click
        Dim obj As New coCtaCobrar
        obj.Id = txtcodproveedor.Text
        obj.Idcondicionpago = codigo
        Dim rpta As String = cn.Cn_actualizar_clienteventa(obj)
        If (obj.Coderror = 0) Then
            msj_ok(rpta)
            Me.Close()
        Else
            msj_advert(rpta)
        End If
    End Sub
End Class