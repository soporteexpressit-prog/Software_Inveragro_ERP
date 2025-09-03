Imports CapaNegocio
Imports CapaObjetos

Public Class FrmTemarioCapacitacion
    Dim cn As New cnTemarioCapacitacion
    Private _CodTemarioCapa As Integer
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
        _CodTemarioCapa = 0
    End Sub

    Sub Cambio()
        btnNuevoRrhhtemarioscapa.Visible = False
        btnEditarRrhhtemarioscapa.Visible = False
        btnGuardarRrhhtemarioscapa.Visible = True
        btnCancelar.Visible = True
        txtDescripcion.Enabled = True
        cmbTemaCapa.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevoRrhhtemarioscapa.Visible = True
        btnEditarRrhhtemarioscapa.Visible = True
        btnGuardarRrhhtemarioscapa.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        cmbTemaCapa.Enabled = False
        cmbEstado.Enabled = False
    End Sub
    Private Sub FrmTemarioCapacitacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbEstado.SelectedIndex = 0
        btnGuardarRrhhtemarioscapa.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        cmbTemaCapa.Enabled = False
        cmbEstado.Enabled = False
        ListarTemaCapacitacion()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub
    Sub ListarTemaCapacitacion()
        Dim cn As New cnTemaCapacitacion
        Dim tb As New DataTable
        tb = cn.Cn_Listar().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Tema de Capacitación"
        With cmbTemaCapa
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
            Dim obj As New coTemarioCapacitacion
            obj.Operacion = _Operacion
            obj.Codigo = _CodTemarioCapa
            obj.Descripcion = txtDescripcion.Text
            obj.Estado = cmbEstado.Text
            obj.IdTemaCapacitacion = cmbTemaCapa.Value
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
        Dim obj As New coTemarioCapacitacion
        obj.Descripcion = ""
        obj.IdTemaCapacitacion = Nothing
        dtgListado.DataSource = cn.Cn_Consultar(obj)

        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "INACTIVO", 4)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 4)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoRrhhtemarioscapa.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarRrhhtemarioscapa.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                cmbEstado.Enabled = True
                _Operacion = 1
                Cambio()
                _CodTemarioCapa = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodTemarioCapa.ToString
                txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                txtDescripcion.Focus()
                cmbTemaCapa.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
                cmbEstado.Text = dtgListado.DisplayLayout.ActiveRow.Cells(3).Value.ToString
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarRrhhtemarioscapa.Click
        Mantenimiento()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class