Imports CapaNegocio
Imports CapaObjetos

Public Class FrmTipoCambio
    Dim cn As New cnTipoCambio
    Private _CodTipoCambio As Integer
    Dim _Operacion As Integer

    Sub Nuevo()
        _Operacion = 0
        Cambio()
        limpiar()
    End Sub

    Sub limpiar()
        txtCodigo.Text = ""
        txtPrecioCompra.Text = ""
        txtPrecioCompra.Select()
        txtPrecioVenta.Text = ""
        _CodTipoCambio = 0
    End Sub

    Sub Cambio()
        btnNuevo.Visible = False
        btnEditar.Visible = False
        btnGuardar.Visible = True
        btnCancelar.Visible = True
        dtpFecha.Enabled = True
        txtPrecioCompra.Enabled = True
        txtPrecioVenta.Enabled = True
        cmbMoneda.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevo.Visible = True
        btnEditar.Visible = True
        btnGuardar.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        dtpFecha.Enabled = False
        txtPrecioCompra.Clear()
        txtPrecioCompra.Enabled = False
        txtPrecioVenta.Clear()
        txtPrecioVenta.Enabled = False
        cmbMoneda.Enabled = False
    End Sub
    Private Sub FrmTipoCambio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFecha.Value = Now.Date
        Cancelar()
        ListarMonedas()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub
    Sub ListarMonedas()
        Dim cn As New cnMoneda
        Dim tb As New DataTable
        tb = cn.Cn_Listar().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Moneda"
        With cmbMoneda
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub
    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (_Operacion = 1 OrElse _Operacion = 2) AndAlso (txtCodigo.Text = "" OrElse txtCodigo.Text.Length = 0) Then
                msj_advert("Seleccione un Registro")
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtPrecioCompra.Text = "" OrElse txtPrecioCompra.Text.Length = 0) Then
                msj_advert("Precio de Compra no Valido")
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtPrecioVenta.Text = "" OrElse txtPrecioVenta.Text.Length = 0) Then
                msj_advert("Precio de Venta no Valido")
                Return
            End If
            Dim obj As New coTipoCambio
            obj.Operacion = _Operacion
            obj.Codigo = _CodTipoCambio
            obj.Fecha = dtpFecha.Value
            obj.PrecioCompra = txtPrecioCompra.Text
            obj.PrecioVenta = txtPrecioVenta.Text
            obj.IdMoneda = cmbMoneda.Value
            obj.Iduser = 1
            _mensaje = cn.Cn_Mantenimiento(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Cancelar()
                Consultar()
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        Dim obj As New coTipoCambio
        obj.Fecha = Nothing
        obj.PrecioCompra = 0.0
        obj.PrecioVenta = 0.0
        obj.IdMoneda = Nothing
        dtgListado.DataSource = cn.Cn_Consultar(obj)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodTipoCambio = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodTipoCambio.ToString
                txtPrecioCompra.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
                txtPrecioCompra.Focus()
                txtPrecioVenta.Text = dtgListado.DisplayLayout.ActiveRow.Cells(3).Value.ToString
                txtPrecioVenta.Focus()
                cmbMoneda.Text = dtgListado.DisplayLayout.ActiveRow.Cells(4).Value.ToString
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Mantenimiento()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Width = 100
                .Columns(1).Width = 170
                .Columns(2).Width = 170
                .Columns(3).Width = 170
                .Columns(4).Width = 170
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub txtPrecioCompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioCompra.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub txtPrecioVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioVenta.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub
End Class