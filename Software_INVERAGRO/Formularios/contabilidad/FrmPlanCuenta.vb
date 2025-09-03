Imports CapaNegocio
Imports CapaObjetos

Public Class FrmPlanCuenta
    Dim cn As New cnPlanCuenta
    Dim _Operacion As Integer

    Sub Nuevo()
        _Operacion = 0
        Cambio()
        limpiar()
    End Sub

    Sub limpiar()
        txtNumeroCuenta.Text = ""
        txtDescripcion.Text = ""
        txtNumeroCuenta.Select()
    End Sub

    Sub Cambio()
        btnNuevoContabilidadPlancuentas.Visible = False
        btnEditarContabilidadPlancuentas.Visible = False
        btnGuardarContabilidadPlancuentas.Visible = True
        btnCancelar.Visible = True
        txtNumeroCuenta.Enabled = True
        txtDescripcion.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevoContabilidadPlancuentas.Visible = True
        btnEditarContabilidadPlancuentas.Visible = True
        btnGuardarContabilidadPlancuentas.Visible = False
        btnCancelar.Visible = False
        txtNumeroCuenta.Clear()
        txtNumeroCuenta.Enabled = False
        txtDescripcion.Clear()
        txtcod2.Enabled = False
        txtdescripcion2.Enabled = False
    End Sub
    Private Sub FrmPlanCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxtipocalificacioncuenta.SelectedIndex = 0
        btnGuardarContabilidadPlancuentas.Visible = False
        btnCancelar.Visible = False
        txtNumeroCuenta.Clear()
        txtNumeroCuenta.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub
    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (_Operacion = 1 OrElse _Operacion = 2) AndAlso (txtNumeroCuenta.Text = "" OrElse txtNumeroCuenta.Text.Length = 0) Then
                msj_advert("Seleccione un Registro")
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtNumeroCuenta.Text = "" OrElse txtNumeroCuenta.Text.Length = 0) Then
                msj_advert("Número de Cuenta no Valida")
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtDescripcion.Text = "" OrElse txtDescripcion.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If
            Dim obj As New coPlanCuenta
            obj.Operacion = _Operacion
            obj.Codigo = txtNumeroCuenta.AccessibleDescription
            obj.NumeroCuenta = txtNumeroCuenta.Text
            obj.Descripcion = txtDescripcion.Text
            If (ckctaprincipal.Checked) Then
                obj.tipocalificacion = ""
            Else
                obj.tipocalificacion = cbxtipocalificacioncuenta.Text
            End If
            obj.IdSuperior = If(ckctaprincipal.Checked,
                    If(txtcod2.AccessibleDescription IsNot Nothing, CInt(txtcod2.AccessibleDescription.ToString), 0),
                    0)
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
        Dim obj As New coPlanCuenta
        dtgListado.DataSource = cn.Cn_Consultar(obj)
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoContabilidadPlancuentas.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarContabilidadPlancuentas.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                txtNumeroCuenta.AccessibleDescription = dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString
                txtNumeroCuenta.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
                cbxtipocalificacioncuenta.Text = dtgListado.DisplayLayout.ActiveRow.Cells(4).Value.ToString
                txtDescripcion.Focus()
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarContabilidadPlancuentas.Click
        Mantenimiento()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub dtgListado_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles dtgListado.ClickCell
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                With dtgListado.DisplayLayout.ActiveRow
                    txtcod2.AccessibleDescription = .Cells(0).Value.ToString
                    txtcod2.Text = .Cells(1).Value.ToString
                    txtdescripcion2.Text = .Cells(2).Value.ToString
                    cbxtipocalificacioncuenta.Text = dtgListado.DisplayLayout.ActiveRow.Cells(4).Value.ToString
                End With
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub ckctaprincipal_CheckedChanged(sender As Object, e As EventArgs) Handles ckctaprincipal.CheckedChanged
        If (ckctaprincipal.Checked) Then
            lbl1.Enabled = False
            txtcod2.Enabled = False
            txtdescripcion2.Enabled = False
            Label1.Visible = False
            cbxtipocalificacioncuenta.Visible = False
            cbxtipocalificacioncuenta.Text = ""
        Else
            lbl1.Enabled = True
            txtcod2.Enabled = True
            txtdescripcion2.Enabled = True
            Label1.Visible = True
            cbxtipocalificacioncuenta.Visible = True
            txtcod2.Focus()
            txtdescripcion2.Focus()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class