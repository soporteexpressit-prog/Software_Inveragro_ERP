Imports CapaNegocio
Imports CapaObjetos

Public Class FrmImportesAFP
    Private cn As New cnControlPagosyDes()
    Dim _Operacion As Integer
    Private _Codregimen As Integer
    Private Sub FrmImportesAFP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cancelar()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub
    Sub Consultar()
        dtgListado.DataSource = Nothing
        dtgListado.DataSource = cn.Cn_Consultarregimenpensionario()
    End Sub
    Sub ConsultarHistorial()
        dtgListado.DataSource = Nothing
        dtgListado.DataSource = cn.Cn_Consultarhistorial()
    End Sub
    Sub Cancelar()
        btnNuevoContabilidadbancos.Visible = True
        btnEditarContabilidadbancos.Visible = True
        btnGuardarContabilidadbancos.Visible = False
        btnCancelar.Visible = False
        txt_tiposeguro.Clear()
        txt_tiposeguro.Enabled = False
        txt_porcentaje.Enabled = False
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
        txt_porcentaje.Text = ""
        txt_tiposeguro.Text = ""
        _Codregimen = 0
    End Sub
    Sub Cambio()
        btnNuevoContabilidadbancos.Visible = False
        btnEditarContabilidadbancos.Visible = False
        btnGuardarContabilidadbancos.Visible = True
        btnCancelar.Visible = True
        txt_tiposeguro.Enabled = True
        txt_porcentaje.Enabled = True
    End Sub

    Private Sub btnEditarContabilidadbancos_Click(sender As Object, e As EventArgs) Handles btnEditarContabilidadbancos.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _Codregimen = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txt_tiposeguro.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                txt_tiposeguro.Focus()
                txt_porcentaje.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
                txt_porcentaje.Focus()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dispose()
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
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txt_tiposeguro.Text = "" OrElse txt_tiposeguro.Text.Length = 0) AndAlso (txt_porcentaje.Text = "" OrElse txt_porcentaje.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If
            Dim obj As New coControlPagosyDes
            obj.Operacion = _Operacion
            obj.Codigo = _Codregimen
            obj.Descripcion = txt_tiposeguro.Text
            obj.porcentaje = (txt_porcentaje.Text / 100)
            obj.Iduser = 1
            _mensaje = cn.Cn_RegimenPensionario(obj)
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

    Private Sub btnregresar_Click(sender As Object, e As EventArgs) Handles btnregresar.Click
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
        btnhistorial.Visible = True
        btnregresar.Visible = False
        btnNuevoContabilidadbancos.Enabled = True
        btnEditarContabilidadbancos.Enabled = True
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles btnhistorial.Click
        btnregresar.Visible = True
        ConsultarHistorial()
        btnhistorial.Visible = False
        btnNuevoContabilidadbancos.Enabled = False
        btnEditarContabilidadbancos.Enabled = False
        txt_porcentaje.Enabled = False
    End Sub
End Class