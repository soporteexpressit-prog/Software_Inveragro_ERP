Imports CapaNegocio
Imports CapaObjetos

Public Class FrmBanco
    Dim cn As New cnBanco
    Private _CodBanco As Integer
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
        _CodBanco = 0
    End Sub

    Sub Cambio()
        btnNuevoContabilidadbancos.Visible = False
        btnEditarContabilidadbancos.Visible = False
        btnGuardarContabilidadbancos.Visible = True
        btnCancelar.Visible = True
        txtDescripcion.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevoContabilidadbancos.Visible = True
        btnEditarContabilidadbancos.Visible = True
        btnGuardarContabilidadbancos.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
    End Sub
    Private Sub FrmBanco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            btnGuardarContabilidadbancos.Visible = False
            btnCancelar.Visible = False
            txtCodigo.Clear()
            txtCodigo.Enabled = False
            txtDescripcion.Clear()
            txtDescripcion.Enabled = False
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
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
            Dim obj As New coBanco
            obj.Operacion = _Operacion
            obj.Codigo = _CodBanco
            obj.Descripcion = txtDescripcion.Text
            obj.Iduser = VariablesGlobales.VP_IdUser
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
        Dim obj As New coBanco
        obj.Descripcion = ""
        dtgListado.DataSource = cn.Cn_Consultar(obj)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoContabilidadbancos.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarContabilidadbancos.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodBanco = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodBanco.ToString
                txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarContabilidadbancos.Click
        Mantenimiento()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class