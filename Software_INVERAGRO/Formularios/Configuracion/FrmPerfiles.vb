Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmPerfiles

    Dim cn As New cnPerfil
    Private _CodPerfil As Integer
    Dim _Operacion As Integer

    Sub Nuevo()
        _Operacion = 0
        Cambio()
        Limpiar()
    End Sub

    Sub Limpiar()
        txtCodigo.Text = ""
        txtRol.Text = ""
        txtRol.Select()
        _CodPerfil = 0
    End Sub

    Sub Cambio()
        btnNuevo.Visible = False
        btnEditar.Visible = False
        btnGuardar.Visible = True
        btnCancelar.Visible = True
        txtRol.Enabled = True
    End Sub

    Sub Cancelar()
        btnNuevo.Visible = True
        btnEditar.Visible = True
        btnGuardar.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtRol.Clear()
        txtRol.Enabled = False
        CmbTipo.SelectedIndex = 0
    End Sub

    Private Sub FrmPerfiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cancelar()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarPerfiles()
    End Sub

    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (_Operacion = 1 OrElse _Operacion = 2) AndAlso (txtCodigo.Text = "" OrElse txtCodigo.Text.Length = 0) Then
                msj_advert("Seleccione un Registro")
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtRol.Text = "" OrElse txtRol.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If
            Dim obj As New coPerfil
            obj.Operacion = _Operacion
            obj.Codigo = _CodPerfil
            obj.Rol = txtRol.Text
            obj.Tipo = CmbTipo.Text
            _mensaje = cn.Cn_Mantenimiento(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Cancelar()
                ListarPerfiles()
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarPerfiles()
        Dim dt As New DataTable
        dt = cn.Cn_ListarPerfilesCompletos().Copy
        dtgListado.DataSource = dt
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodPerfil = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodPerfil.ToString
                txtRol.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                txtRol.Focus()
                CmbTipo.SelectedItem = dtgListado.DisplayLayout.ActiveRow.Cells(3).Value.ToString
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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class