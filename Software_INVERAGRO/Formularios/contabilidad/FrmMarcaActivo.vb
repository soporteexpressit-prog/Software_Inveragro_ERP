Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMarcaActivo
    Dim cn As New cnMarcaActivo
    Private _CodMarcaActivo As Integer
    Dim _Operacion As Integer

    Sub Nuevo()
        _Operacion = 0
        Cambio()
        limpiar()
    End Sub

    Sub limpiar()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtDescripcion.Select()
        _CodMarcaActivo = 0
    End Sub

    Sub Cambio()
        btnNuevoctmaac.Visible = False
        btnEditarctmaac.Visible = False
        btnGuardarctmaac.Visible = True
        btnCancelar.Visible = True
        txtDescripcion.Enabled = True
        cmbTipoActivos.Enabled = True
        cmbCategorias.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevoctmaac.Visible = True
        btnEditarctmaac.Visible = True
        btnGuardarctmaac.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        cmbTipoActivos.Enabled = False
        cmbCategorias.Enabled = False
    End Sub
    Private Sub FrmMarcaActivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnGuardarctmaac.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        cmbTipoActivos.Enabled = False
        cmbCategorias.Enabled = False
        ListarCategoriaActivo()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub
    Sub ListarCategoriaActivo()
        Dim cn As New cnCategoriaActivo
        Dim tb As New DataTable
        tb = cn.Cn_ListarConTipoActivo().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Categoria"
        With cmbCategorias
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub
    Sub ListarTiposActivo(idCategoria As Integer)
        Dim cn As New cnTipoActivo
        Dim tb As New DataTable
        Dim obj As New coTipoActivo
        obj.IdCategoriaActivo = idCategoria
        tb = cn.Cn_Listar_Tipo_Activo_Por_Categoria(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Galpón"
        With cmbTipoActivos
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
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtDescripcion.Text = "" OrElse txtDescripcion.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If

            Dim obj As New coMarcaActivo
            obj.Operacion = _Operacion
            obj.Codigo = _CodMarcaActivo
            obj.Descripcion = txtDescripcion.Text
            obj.IdTipoActivo = cmbTipoActivos.Value

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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoctmaac.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarctmaac.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodMarcaActivo = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodMarcaActivo.ToString
                txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                txtDescripcion.Focus()
                cmbTipoActivos.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarctmaac.Click
        Mantenimiento()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub cmbCategorias_ValueChanged(sender As Object, e As EventArgs) Handles cmbCategorias.ValueChanged
        Try
            ListarTiposActivo(cmbCategorias.Value)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub UltraGroupBox1_Click(sender As Object, e As EventArgs)

    End Sub
End Class