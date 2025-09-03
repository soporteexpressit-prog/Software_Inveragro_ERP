Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmSala
    Dim cn As New cnSala
    Private _CodSala As Integer
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
        CbxEstado.SelectedIndex = 0
        _CodSala = 0
    End Sub

    Sub Cambio()
        btnNuevoProsa.Visible = False
        btneditarprosa.Visible = False
        btnGuardarprosa.Visible = True
        btnCancelar.Visible = True
        txtDescripcion.Enabled = True
        CbxEstado.Enabled = True
    End Sub

    Sub Cancelar()
        btnNuevoProsa.Visible = True
        btneditarprosa.Visible = True
        btnGuardarprosa.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        CbxEstado.SelectedIndex = 0
        CbxEstado.Enabled = False
    End Sub

    Private Sub FrmSala_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cancelar()
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

            Dim obj As New coSala With {
                .Operacion = _Operacion,
                .Codigo = _CodSala,
                .Descripcion = txtDescripcion.Text,
                .Estado = CbxEstado.Text
            }
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
        Try
            dtgListado.DataSource = cn.Cn_Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnNuevoArea_Click(sender As Object, e As EventArgs) Handles btnNuevoProsa.Click
        Nuevo()
    End Sub

    Private Sub btnEditarArea_Click(sender As Object, e As EventArgs) Handles btneditarprosa.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodSala = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodSala.ToString
                txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                txtDescripcion.Focus()
                CbxEstado.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
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

    Private Sub btnGuardarArea_Click(sender As Object, e As EventArgs) Handles btnGuardarprosa.Click
        Mantenimiento()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class