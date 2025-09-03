Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics

Public Class FrmMotivoMemoDespido
    Dim cn As New cnMotivoMemoDespido
    Private _CodTipoMotivoMemo As Integer
    Dim _Operacion As Integer
    Dim _flag As Integer = 0

    Sub Nuevo()
        _Operacion = 0
        _flag = 1
        Cambio()
        limpiar()
    End Sub

    Sub limpiar()
        txtCodigo.Text = ""
        txtMotivo.Text = ""
        txtMotivo.Select()
        _CodTipoMotivoMemo = 0
    End Sub

    Sub Cambio()
        btnNuevoRrhhmem.Visible = False
        btnEditarRrhhmem.Visible = False
        btnGuardarRrhhmem.Visible = True
        btnCancelarRrhhmem.Visible = True
        txtMotivo.Enabled = True
        cmbGrado.Enabled = True
        cmbTipo.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevoRrhhmem.Visible = True
        btnEditarRrhhmem.Visible = True
        btnGuardarRrhhmem.Visible = False
        btnCancelarRrhhmem.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtMotivo.Clear()
        txtMotivo.Enabled = False
        cmbGrado.Enabled = False
        cmbTipo.Enabled = False
        cmbGrado.SelectedIndex = 0
        cmbTipo.SelectedIndex = 0
    End Sub

    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (_Operacion = 1 OrElse _Operacion = 2) AndAlso (txtCodigo.Text = "" OrElse txtCodigo.Text.Length = 0) Then
                msj_advert("Seleccione un Registro")
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtMotivo.Text = "" OrElse txtMotivo.Text.Length = 0) Then
                msj_advert("Motivo de Memorandum no Valida")
                Return
            End If
            Dim obj As New coMotivoMemoDespido
            obj.Operacion = _Operacion
            obj.Codigo = _CodTipoMotivoMemo
            obj.Descripcion = txtMotivo.Text
            obj.Grado = cmbGrado.Text
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
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Gray, Color.White, "BAJO", 3)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "MEDIO", 3)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ALTO", 3)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoRrhhmem.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarRrhhmem.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _flag = 1
                _Operacion = 1
                Cambio()
                _CodTipoMotivoMemo = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodTipoMotivoMemo.ToString
                txtMotivo.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                cmbTipo.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
                cmbGrado.Text = dtgListado.DisplayLayout.ActiveRow.Cells(3).Value.ToString
                txtMotivo.Focus()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelarRrhhmem.Click
        Cancelar()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarRrhhmem.Click
        Mantenimiento()
    End Sub

    Private Sub FrmMotivoMemoDespido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnGuardarRrhhmem.Visible = False
        btnCancelarRrhhmem.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtMotivo.Clear()
        txtMotivo.Enabled = False
        cmbGrado.Enabled = False
        cmbTipo.Enabled = False
        cmbGrado.SelectedIndex = 0
        cmbTipo.SelectedIndex = 0
        Consultar()
    End Sub

    Private Sub cmbTipo_TextChanged(sender As Object, e As EventArgs) Handles cmbTipo.TextChanged
        If (cmbTipo.Text = "DESPIDO") Then
            cmbGrado.SelectedIndex = 2
            cmbGrado.Enabled = False
        Else
            If _flag = 1 Then
                cmbGrado.Enabled = True
            End If
        End If
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout

    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
        cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub cmbGrado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrado.SelectedIndexChanged
        cmbGrado.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class