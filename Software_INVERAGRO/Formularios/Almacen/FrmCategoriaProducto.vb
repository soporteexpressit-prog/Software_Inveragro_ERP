Imports CapaNegocio
Imports CapaObjetos

Public Class FrmCategoriaProducto
    Dim cn As New cnCategoriaProducto
    Private _CodCategoriaProducto As Integer
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
        _CodCategoriaProducto = 0
    End Sub

    Sub Cambio()
        btnNuevocate.Visible = False
        btnEditarcate.Visible = False
        btnGuardarcate.Visible = True
        btnCancelarcate.Visible = True
    End Sub

    Sub Cancelar()
        btnNuevocate.Visible = True
        btnEditarcate.Visible = True
        btnGuardarcate.Visible = False
        btnCancelarcate.Visible = False
        txtCodigo.Clear()
        txtCodigo.ReadOnly = True
        txtDescripcion.Clear()
    End Sub
    Private Sub FrmCategoriaProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnGuardarcate.Visible = False
        btnCancelarcate.Visible = False
        txtCodigo.Clear()
        txtCodigo.ReadOnly = True
        txtDescripcion.Clear()
        cbestado.SelectedIndex = 0
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
            Dim obj As New coCategoriaProducto
            obj.Operacion = _Operacion
            obj.Codigo = _CodCategoriaProducto
            obj.Descripcion = txtDescripcion.Text
            obj.Estado = cbestado.Text
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
        Dim obj As New coCategoriaProducto
        obj.Descripcion = ""
        dtgListado.DataSource = cn.Cn_Consultar(obj)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevocate.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarcate.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodCategoriaProducto = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodCategoriaProducto.ToString
                txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                ' ✅ CORRECTO: Obtener el texto del estado y buscar el índice en el ComboBox
                Dim estadoTexto As String = dtgListado.ActiveRow.Cells(3).Value.ToString().Trim().ToUpper()

                ' Buscar el índice del item que coincida con el texto
                Dim indiceEncontrado As Integer = -1
                For i As Integer = 0 To cbestado.Items.Count - 1
                    If cbestado.Items(i).ToString().Trim().ToUpper() = estadoTexto Then
                        indiceEncontrado = i
                        Exit For
                    End If
                Next
                If indiceEncontrado <> -1 Then
                    cbestado.SelectedIndex = indiceEncontrado
                End If
                txtDescripcion.Focus()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelarcate.Click
        Cancelar()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarcate.Click
        Mantenimiento()
    End Sub

    Private Sub btncerrarr_Click(sender As Object, e As EventArgs) Handles btncerrarr.Click
        Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class