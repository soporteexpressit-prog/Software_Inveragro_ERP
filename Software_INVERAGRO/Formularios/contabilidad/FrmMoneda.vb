Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMoneda
    Dim cn As New cnMoneda
    Private _CodTMoneda As Integer
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
        txtpreciocompra.Text = ""
        txtprecioventa.Text = ""
        txtDescripcion.Select()
        _CodTMoneda = 0
    End Sub

    Sub Cambio()
        btnNuevoContabilidadmonedad.Visible = False
        btnEditarContabilidadmonedad.Visible = False
        btnGuardarContabilidadmonedad.Visible = True
        btnCancelar.Visible = True
        txtDescripcion.Enabled = True
        txtAbreviatura.Enabled = True
        txtprecioventa.Enabled = True
        txtpreciocompra.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevoContabilidadmonedad.Visible = True
        btnEditarContabilidadmonedad.Visible = True
        btnGuardarContabilidadmonedad.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        txtAbreviatura.Clear()
        txtAbreviatura.Enabled = False
        txtpreciocompra.Clear()
        txtpreciocompra.Enabled = False
        txtprecioventa.Clear()
        txtprecioventa.Enabled = False
    End Sub
    Private Sub FrmMoneda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnGuardarContabilidadmonedad.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        txtAbreviatura.Clear()
        txtAbreviatura.Enabled = False
        txtprecioventa.Clear()
        txtprecioventa.Enabled = False
        txtpreciocompra.Clear()
        txtpreciocompra.Enabled = False
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
            Dim obj As New coMoneda
            obj.Operacion = _Operacion
            obj.Codigo = _CodTMoneda
            obj.Descripcion = txtDescripcion.Text
            obj.Abreviatura = txtAbreviatura.Text
            obj.preciocompra = txtpreciocompra.Text
            obj.precioventa = txtprecioventa.Text
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
        Dim obj As New coMoneda
        dtgListado.DataSource = Nothing
        dtgListado.DataSource = cn.Cn_Consultar(obj)
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Width = 85
                .Columns(1).Width = 300
                .Columns(2).Width = 100
                .Columns(3).Width = 100
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoContabilidadmonedad.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarContabilidadmonedad.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodTMoneda = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodTMoneda.ToString
                txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                txtAbreviatura.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
                txtpreciocompra.Text = dtgListado.DisplayLayout.ActiveRow.Cells(3).Value.ToString
                txtprecioventa.Text = dtgListado.DisplayLayout.ActiveRow.Cells(4).Value.ToString
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarContabilidadmonedad.Click
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
    Sub ConsultarHistorial()
        Dim obj As New coMoneda
        dtgListado.DataSource = Nothing
        dtgListado.DataSource = cn.Cn_ConsultarHistorial(obj)
    End Sub
    Private Sub btnhistorial_Click(sender As Object, e As EventArgs) Handles btnhistorial.Click
        btnregresar.Visible = True
        ConsultarHistorial()
        btnhistorial.Visible = False
        btnEditarContabilidadmonedad.Enabled = False
        btnNuevoContabilidadmonedad.Enabled = False
        'txt_porcentaje.Enabled = False
    End Sub

    Private Sub btnregresar_Click(sender As Object, e As EventArgs) Handles btnregresar.Click
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
        btnhistorial.Visible = True
        btnregresar.Visible = False
        btnEditarContabilidadmonedad.Enabled = True
        btnNuevoContabilidadmonedad.Enabled = True
    End Sub
End Class