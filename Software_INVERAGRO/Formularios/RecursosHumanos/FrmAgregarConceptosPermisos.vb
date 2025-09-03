Imports CapaNegocio
Imports CapaObjetos

Public Class FrmAgregarConceptosPermisos
    Dim cn As New cnPermisoLaboral
    Private _CodConcepto As Integer
    Dim _Operacion As Integer
    Private Sub FrmAgregarConceptosPermisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub

    Sub Consultar()
        Dim obj As New coPermisoLaboral
        obj.Descripcion = ""
        dtgListado.DataSource = cn.Cn_Consultarconceptos(obj)
    End Sub

    Private Sub btnNuevoContabilidadbancos_Click(sender As Object, e As EventArgs) Handles btnNuevoContabilidadbancos.Click
        Nuevo()
    End Sub
    Sub Nuevo()
        _Operacion = 0
        Cambio()
        limpiar()
    End Sub
    Sub limpiar()
        txtdescripcionconcepto.Text = ""
        txtdescripcionconcepto.Select()
        _CodConcepto = 0
    End Sub

    Sub Cambio()
        btnNuevoContabilidadbancos.Visible = False
        btnEditarContabilidadbancos.Visible = False
        btnGuardarContabilidadbancos.Visible = True
        btnCancelar.Visible = True
        txtdescripcionconcepto.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevoContabilidadbancos.Visible = True
        btnEditarContabilidadbancos.Visible = True
        btnGuardarContabilidadbancos.Visible = False
        btnCancelar.Visible = False
        txtdescripcionconcepto.Clear()
        txtdescripcionconcepto.Enabled = False
    End Sub

    Private Sub btnEditarContabilidadbancos_Click(sender As Object, e As EventArgs) Handles btnEditarContabilidadbancos.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodConcepto = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtdescripcionconcepto.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                txtdescripcionconcepto.Focus()
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

    Private Sub btnGuardarContabilidadbancos_Click(sender As Object, e As EventArgs) Handles btnGuardarContabilidadbancos.Click
        Mantenimiento()
    End Sub

    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtdescripcionconcepto.Text = "" OrElse txtdescripcionconcepto.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If
            Dim obj As New coPermisoLaboral
            obj.Operacion = _Operacion
            obj.Codigo = _CodConcepto
            obj.Descripcion = txtdescripcionconcepto.Text
            _mensaje = cn.Cn_RegConceptoSueldo(obj)
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
End Class