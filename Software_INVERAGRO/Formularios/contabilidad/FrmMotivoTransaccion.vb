Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMotivoTransaccion
    Dim cn As New cnMotivoTransaccion
    Private _CodMotivoTransaccion As Integer
    Dim _Operacion As Integer

    Sub Nuevo()
        _Operacion = 0
        Cambio()
        limpiar()
    End Sub

    Sub limpiar()
        txtCodigo.Text = ""
        txtMotivo.Text = ""
        txtMotivo.Select()
        _CodMotivoTransaccion = 0
    End Sub

    Sub Cambio()
        btnNuevoctmotivot.Visible = False
        btnEditarctmotivot.Visible = False
        btnGuardarctmotivot.Visible = True
        btnCancelar.Visible = True
        txtMotivo.Enabled = True
        cmbTipo.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevoctmotivot.Visible = True
        btnEditarctmotivot.Visible = True
        btnGuardarctmotivot.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtMotivo.Clear()
        txtMotivo.Enabled = False
        cmbTipo.Enabled = False
        cmbTipo.SelectedIndex = 0
    End Sub
    Private Sub FrmMotivoTransaccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnGuardarctmotivot.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtMotivo.Clear()
        txtMotivo.Enabled = False
        cmbTipo.Enabled = False
        cmbTipo.SelectedIndex = 0
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub
    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (_Operacion = 1 OrElse _Operacion = 2) AndAlso (txtCodigo.Text = "" OrElse txtCodigo.Text.Length = 0) Then
                msj_advert("Seleccione un Registro")
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtMotivo.Text = "" OrElse txtMotivo.Text.Length = 0) Then
                msj_advert("Motivo de Transaccion no Valida")
                Return
            End If
            Dim obj As New coMotivoTransaccion
            obj.Operacion = _Operacion
            obj.Codigo = _CodMotivoTransaccion
            obj.Descripcion = txtMotivo.Text
            obj.Tipo = cmbTipo.Text

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
        dtgListado.DataSource = cn.Cn_Listar()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoctmotivot.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarctmotivot.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodMotivoTransaccion = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodMotivoTransaccion.ToString
                txtMotivo.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                cmbTipo.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
                txtMotivo.Focus()
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarctmotivot.Click
        Mantenimiento()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
        cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class