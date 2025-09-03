Imports CapaNegocio
Imports CapaObjetos

Public Class FrmTipoDocumento
    Dim cn As New cnTipoDocumento
    Private _CodTipoDocumento As Integer
    Dim _Operacion As Integer

    Sub Nuevo()
        _Operacion = 0
        Cambio()
        limpiar()
    End Sub

    Sub limpiar()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtAbreviatura.Text = ""
        txtDescripcion.Select()
        _CodTipoDocumento = 0
    End Sub

    Sub Cambio()
        btnNuevoContabilidadtpdoc.Visible = False
        btnEditarContabilidadtpdoc.Visible = False
        btnGuardarContabilidadtpdoc.Visible = True
        btnCancelar.Visible = True
        txtDescripcion.Enabled = True
        txtAbreviatura.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevoContabilidadtpdoc.Visible = True
        btnEditarContabilidadtpdoc.Visible = True
        btnGuardarContabilidadtpdoc.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        'txtDescripcion.Enabled = False
        txtAbreviatura.Clear()
        'txtAbreviatura.Enabled = False
    End Sub

    Private Sub FrmTipoDocumento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnGuardarContabilidadtpdoc.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        'txtDescripcion.Enabled = False
        txtAbreviatura.Clear()
        'txtAbreviatura.Enabled = False
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
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtAbreviatura.Text = "" OrElse txtAbreviatura.Text.Length = 0) Then
                msj_advert("Abreviatura no Valida")
                Return
            End If
            Dim obj As New coTipoDocumento
            obj.Operacion = _Operacion
            obj.Codigo = _CodTipoDocumento
            obj.Descripcion = txtDescripcion.Text
            obj.Abreviatura = txtAbreviatura.Text
            obj.Iduser = 1
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
        Dim obj As New coTipoDocumento
        obj.Descripcion = ""
        obj.Abreviatura = ""
        dtgListado.DataSource = cn.Cn_Consultar(obj)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoContabilidadtpdoc.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarContabilidadtpdoc.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodTipoDocumento = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodTipoDocumento.ToString
                txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                txtAbreviatura.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarContabilidadtpdoc.Click
        Mantenimiento()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Width = 100
                .Columns(1).Width = 170
                .Columns(2).Width = 150
                .Columns(3).Width = 170
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        clsBasicas.ValidarLetras(e)
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class