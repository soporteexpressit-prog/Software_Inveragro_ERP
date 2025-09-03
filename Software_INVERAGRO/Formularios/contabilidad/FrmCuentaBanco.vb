Imports CapaNegocio
Imports CapaObjetos

Public Class FrmCuentaBanco
    Dim cn As New cnCuentaBanco
    Private _CodCuentaBanco As Integer
    Dim _Operacion As Integer

    Sub Nuevo()
        _Operacion = 0
        Cambio()
        limpiar()
    End Sub

    Sub limpiar()
        txtCodigo.Text = ""
        txtNumCuenta.Text = ""
        txtCodReferencia.Text = ""
        txtCodReferencia.Select()
        _CodCuentaBanco = 0
    End Sub

    Sub Cambio()
        btnNuevoContabilidadotrascuentas.Visible = False
        btnEditarContabilidadotrascuentas.Visible = False
        btnGuardarContabilidadotrascuentas.Visible = True
        btnCancelar.Visible = True
        txtCodReferencia.Enabled = True
        txtNumCuenta.Enabled = True
        cmbMoneda.Enabled = True
        cmbBanco.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevoContabilidadotrascuentas.Visible = True
        btnEditarContabilidadotrascuentas.Visible = True
        btnGuardarContabilidadotrascuentas.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtCodReferencia.Clear()
        txtCodReferencia.Enabled = False
        txtNumCuenta.Clear()
        txtNumCuenta.Enabled = False
        cmbMoneda.Enabled = False
        cmbBanco.Enabled = False
        cmbEstado.Enabled = False
    End Sub
    Private Sub FrmCuentaBanco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = Windows.Forms.FormWindowState.Maximized
        cmbEstado.SelectedIndex = 0
        btnGuardarContabilidadotrascuentas.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtCodReferencia.Clear()
        txtCodReferencia.Enabled = False
        txtNumCuenta.Clear()
        txtNumCuenta.Enabled = False
        cmbMoneda.Enabled = False
        cmbBanco.Enabled = False
        cmbEstado.Enabled = False
        ListarMonedas()
        ListarBancos()
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

    Sub ListarBancos()
        Dim cn As New cnBanco
        Dim tb As New DataTable
        tb = cn.Cn_Listar().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Banco"
        With cmbBanco
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
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtNumCuenta.Text = "" OrElse txtNumCuenta.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If
            Dim obj As New coCuentaBanco
            obj.Operacion = _Operacion
            obj.Codigo = _CodCuentaBanco
            obj.NumeroCuenta = txtNumCuenta.Text
            obj.Estado = cmbEstado.Text
            obj.CodReferencia = txtCodReferencia.Text
            obj.IdMoneda = cmbMoneda.Value
            obj.IdBanco = cmbBanco.Value
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
        Dim obj As New coCuentaBanco
        obj.NumeroCuenta = ""
        obj.IdMoneda = Nothing
        obj.IdBanco = Nothing
        dtgListado.DataSource = cn.Cn_Consultar(obj)

        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "INACTIVO", 5)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 5)
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Width = 85
                .Columns(1).Width = 210
                .Columns(2).Width = 100
                .Columns(3).Width = 100
                .Columns(6).Width = 200
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoContabilidadotrascuentas.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarContabilidadotrascuentas.Click
        cmbEstado.Enabled = True
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodCuentaBanco = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodCuentaBanco.ToString
                txtCodReferencia.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                txtCodReferencia.Focus()
                txtNumCuenta.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
                cmbMoneda.Text = dtgListado.DisplayLayout.ActiveRow.Cells(3).Value.ToString
                cmbBanco.Text = dtgListado.DisplayLayout.ActiveRow.Cells(4).Value.ToString
                cmbEstado.Text = dtgListado.DisplayLayout.ActiveRow.Cells(5).Value.ToString
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarContabilidadotrascuentas.Click
        Mantenimiento()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btnverestadocuentaContabilidadotrascuentas.Click
        Try
            If (dtgListado.Rows.Count > 0) Then
                If dtgListado.ActiveRow.Cells(0).Value.ToString <> 0 Then
                    Dim f As New FrmEstadodeCuentaBancario
                    f.lblbanco.Text = dtgListado.ActiveRow.Cells(4).Value.ToString
                    f.lblcuenta.Text = dtgListado.ActiveRow.Cells(2).Value.ToString
                    f.lblcuenta.AccessibleDescription = dtgListado.ActiveRow.Cells(0).Value.ToString
                    f.ShowDialog()
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub BtnReporte_Click(sender As Object, e As EventArgs) Handles BtnReporte.Click
        Try
            Dim frm As New FrmReporteCtaBanco
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class