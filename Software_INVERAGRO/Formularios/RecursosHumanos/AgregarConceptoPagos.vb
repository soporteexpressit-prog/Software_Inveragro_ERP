Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class AgregarConceptoPagos
    Private cn As New cnControlPagosyDes()
    Private _CodConcepto As Integer
    Dim _Operacion As Integer

    Private Sub AgregarConceptoPagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxTipoConcepto.SelectedIndex = 0
        Cancelar()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
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


    Private Sub cbxTipoConcepto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoConcepto.SelectedIndexChanged
        cbxTipoConcepto.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub txtdescripcionconcepto_TextChanged(sender As Object, e As EventArgs) Handles txtdescripcionconcepto.TextChanged
        'If System.Text.RegularExpressions.Regex.IsMatch(txtdescripcionconcepto.Text, "\d") Then
        '    txtdescripcionconcepto.Text = System.Text.RegularExpressions.Regex.Replace(txtdescripcionconcepto.Text, "\d", "")
        '    txtdescripcionconcepto.SelectionStart = txtdescripcionconcepto.Text.Length
        'End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)

    End Sub

    Sub Consultar()
        Dim obj As New coControlPagosyDes
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

    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtdescripcionconcepto.Text = "" OrElse txtdescripcionconcepto.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If
            Dim obj As New coControlPagosyDes
            obj.Operacion = _Operacion
            obj.Codigo = _CodConcepto
            obj.Descripcion = txtdescripcionconcepto.Text
            obj.TipoConcepto = cbxTipoConcepto.Text
            obj.Iduser = 1
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

    Private Sub btnGuardarContabilidadbancos_Click(sender As Object, e As EventArgs) Handles btnGuardarContabilidadbancos.Click
        Mantenimiento()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dispose()
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

    Private Sub GrupoMasOpcionesBusqueda_Click(sender As Object, e As EventArgs) Handles GrupoMasOpcionesBusqueda.Click

    End Sub
End Class