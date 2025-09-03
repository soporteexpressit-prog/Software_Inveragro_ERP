Imports CapaNegocio
Imports CapaObjetos

Public Class FrmTipoCurso
    Dim cn As New cnTipoCurso
    Private _CodTipoCurso As Integer
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
        _CodTipoCurso = 0
    End Sub

    Sub Cambio()
        cmbEstado.SelectedIndex = 0
        btnNuevoRrhhtcurso.Visible = False
        btnEditarRrhhtcurso.Visible = False
        btnGuardarRrhhtcurso.Visible = True
        btnCancelar.Visible = True
        txtDescripcion.Enabled = True
    End Sub
    Sub Cancelar()
        cmbEstado.SelectedIndex = 0
        btnNuevoRrhhtcurso.Visible = True
        btnEditarRrhhtcurso.Visible = True
        btnGuardarRrhhtcurso.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        cmbEstado.Enabled = False
    End Sub
    Private Sub FrmTipoCurso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnGuardarRrhhtcurso.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        cmbEstado.Enabled = False
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
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtDescripcion.Text = "" OrElse txtDescripcion.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If
            Dim obj As New coTipoCurso
            obj.Operacion = _Operacion
            obj.Codigo = _CodTipoCurso
            obj.Descripcion = txtDescripcion.Text
            obj.Estado = cmbEstado.Text

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
        Dim obj As New coTipoCurso
        obj.Descripcion = Nothing
        obj.Estado = Nothing
        dtgListado.DataSource = cn.Cn_Consultar(obj)

        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "INACTIVO", 2)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 2)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoRrhhtcurso.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarRrhhtcurso.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                cmbEstado.Enabled = True
                _CodTipoCurso = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodTipoCurso.ToString
                txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                txtDescripcion.Focus()
                cmbEstado.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarRrhhtcurso.Click
        Mantenimiento()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub


    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        clsBasicas.ValidarLetras(e)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class