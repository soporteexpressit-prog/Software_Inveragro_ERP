Imports CapaNegocio
Imports CapaObjetos

Public Class FrmTipoSeguro
    Dim cn As New cnTipoSeguro
    Private _CodTipoSeguro As Integer
    Dim _Operacion As Integer

    Sub Nuevo()
        _Operacion = 0
        Cambio()
        limpiar()
    End Sub

    Sub limpiar()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtTipoSeguro.Text = ""
        txtDescripcion.Select()
        _CodTipoSeguro = 0
    End Sub

    Sub Cambio()
        btnNuevocttpseg.Visible = False
        btnEditarcttpseg.Visible = False
        btnGuardarcttpseg.Visible = True
        btnCancelar.Visible = True
        txtDescripcion.Enabled = True
        txtTipoSeguro.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevocttpseg.Visible = True
        btnEditarcttpseg.Visible = True
        btnGuardarcttpseg.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        txtTipoSeguro.Enabled = False
    End Sub
    Private Sub FrmTipoSeguro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnGuardarcttpseg.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        txtTipoSeguro.Enabled = False
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub
    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (_Operacion = 1 OrElse _Operacion = 2) AndAlso (txtCodigo.Text = "" OrElse txtCodigo.Text.Length = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtDescripcion.Text = "" OrElse txtDescripcion.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If
            Dim obj As New coTipoSeguro
            obj.Operacion = _Operacion
            obj.Codigo = _CodTipoSeguro
            obj.Descripcion = txtDescripcion.Text
            obj.TipoSeguro = txtTipoSeguro.Text
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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevocttpseg.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarcttpseg.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodTipoSeguro = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodTipoSeguro.ToString
                txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                txtDescripcion.Focus()
                txtTipoSeguro.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarcttpseg.Click
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