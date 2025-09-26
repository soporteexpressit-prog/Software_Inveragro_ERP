Imports CapaNegocio
Imports CapaObjetos

Public Class FrmUbicacion
    Dim cn As New cnUbicacion
    Private _CodUbicacion As Integer
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
        _CodUbicacion = 0
    End Sub

    Sub Cambio()
        btnNuevoCtubicacion.Visible = False
        btnEditarCtubicacion.Visible = False
        btnGuardarCtubicacion.Visible = True
        btnCancelar.Visible = True
        txtDescripcion.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevoCtubicacion.Visible = True
        btnEditarCtubicacion.Visible = True
        btnGuardarCtubicacion.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
    End Sub
    Private Sub FrmUbicacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            btnGuardarCtubicacion.Visible = False
            btnCancelar.Visible = False
            txtCodigo.Clear()
            txtCodigo.Enabled = False
            txtDescripcion.Clear()
            txtDescripcion.Enabled = False
            LblDensidad.Visible = False
            TxtDensidad.Visible = False
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub Mantenimiento()
        Try
            Dim esPlantel As String = dtgListado.ActiveRow.Cells("Es Plantel").Value.ToString

            If (_Operacion = 1 OrElse _Operacion = 2) AndAlso (txtCodigo.Text = "" OrElse txtCodigo.Text.Length = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtDescripcion.Text = "" OrElse txtDescripcion.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If

            If esPlantel = "SI" AndAlso (TxtDensidad.Text = "" OrElse TxtDensidad.Text.Length = 0) Then
                msj_advert("Densidad no Valida")
                Return
            ElseIf esPlantel = "SI" AndAlso CInt(TxtDensidad.Text) = 0 Then
                msj_advert("Densidad no Valida")
                Return
            End If

            Dim obj As New coUbicacion With {
                .Operacion = _Operacion,
                .Codigo = _CodUbicacion,
                .Descripcion = txtDescripcion.Text,
                .Densidad = If(esPlantel = "SI", CDec(TxtDensidad.Text), Nothing),
                .NumChanchillas = Nothing,
                .Iduser = VP_IdUser
            }

            Dim _mensaje As String = cn.Cn_Mantenimiento(obj)
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
        Dim obj As New coUbicacion
        obj.Descripcion = ""
        dtgListado.DataSource = cn.Cn_Consultar(obj)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoCtubicacion.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarCtubicacion.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim esPlantel As String = dtgListado.ActiveRow.Cells("Es Plantel").Value.ToString
                _Operacion = 1
                Cambio()
                _CodUbicacion = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodUbicacion.ToString
                txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                txtDescripcion.Focus()
                If esPlantel = "SI" Then
                    LblDensidad.Visible = True
                    TxtDensidad.Visible = True
                    TxtDensidad.Text = dtgListado.DisplayLayout.ActiveRow.Cells("Densidad por Corral").Value.ToString
                End If
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarCtubicacion.Click
        Mantenimiento()
        LblDensidad.Visible = False
        TxtDensidad.Visible = False
        TxtDensidad.Text = ""
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub TxtDensidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDensidad.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub
End Class