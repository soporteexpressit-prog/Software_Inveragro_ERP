Imports CapaNegocio
Imports CapaObjetos
Imports iText.Kernel.Pdf.Canvas.Wmf

Public Class FrmTipoCapacitacion
    Dim cn As New cnTipoCapacitacion
    Private _CodTipoCapacitacion As Integer
    Dim _Operacion As Integer
    Dim loginNegocio As New cnLogin()
    Dim estado As Boolean

    Sub Nuevo()
        _Operacion = 0
        Cambio()
        limpiar()
    End Sub

    Sub limpiar()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtDescripcion.Select()
        _CodTipoCapacitacion = 0
    End Sub

    Sub Cambio()
        btnNuevoRrhhtipocapaci.Visible = False
        btnEditarRrhhtipocapaci.Visible = False
        btnGuardarRrhhtipocapaci.Visible = True
        btnCancelar.Visible = True
        txtDescripcion.Enabled = True
        cmbEstado.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevoRrhhtipocapaci.Visible = True
        btnEditarRrhhtipocapaci.Visible = True
        btnGuardarRrhhtipocapaci.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        cmbEstado.Enabled = False
        cmbEstado.SelectedIndex = 0
    End Sub
    Private Sub FrmTipoCapacitacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnGuardarRrhhtipocapaci.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        cmbEstado.Enabled = False
        cmbEstado.SelectedIndex = 0
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
            Dim obj As New coTipoCapacitacion
            obj.Operacion = _Operacion
            obj.Codigo = _CodTipoCapacitacion
            obj.Descripcion = txtDescripcion.Text
            obj.Estado = cmbEstado.Text
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
        dtgListado.DataSource = cn.Cn_Listar()
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "INACTIVO", 2)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 2)
    End Sub



    Public Sub ActualizarEstadoBtnAincidencia(idPersona As Integer, NombreBoton As String)
        ' Obtener el estado de los botones
        Dim botonesEstado As List(Of (NombreBoton As String, Estado As Boolean)) = loginNegocio.ObtenerEstadoBotonesPorUsuario(idPersona)

        ' Habilitar o deshabilitar los botones según su estado
        For Each boton In botonesEstado
            Dim control As ToolStripButton = Nothing

            ' Buscar el botón correspondiente por su nombre
            Select Case boton.NombreBoton
                Case "btnNuevo"
                    control = btnNuevoRrhhtipocapaci
                Case "btnEditar"
                    control = btnEditarRrhhtipocapaci
                Case "btnCancelar"
                    control = btnCancelar
                Case "btnGuardar"
                    control = btnGuardarRrhhtipocapaci
                    ' Puedes agregar más botones aquí si es necesario
            End Select

            ' Si se encontró el botón, actualizar su estado
            If control IsNot Nothing Then
                control.Enabled = boton.Estado
            End If
        Next
    End Sub



    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoRrhhtipocapaci.Click
        If btnNuevoRrhhtipocapaci.Enabled Then ' Cambiar para verificar el estado
            Nuevo()
        Else
            btnNuevoRrhhtipocapaci.Enabled = estado
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarRrhhtipocapaci.Click
        If btnEditarRrhhtipocapaci.Enabled Then ' Cambiar para verificar el estado
            If dtgListado.Rows.Count > 0 Then
                If dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0 Then
                    _Operacion = 1
                    Cambio()
                    _CodTipoCapacitacion = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                    txtCodigo.Text = _CodTipoCapacitacion.ToString
                    txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                    cmbEstado.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
                    txtDescripcion.Focus()
                Else
                    msj_advert("Seleccione un Registro")
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            btnEditarRrhhtipocapaci.Enabled = estado
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If btnCancelar.Enabled Then ' Cambiar para verificar el estado
            Cancelar()
        Else
            btnCancelar.Enabled = estado
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarRrhhtipocapaci.Click
        If btnGuardarRrhhtipocapaci.Enabled Then ' Cambiar para verificar el estado
            Mantenimiento()
        Else
            btnGuardarRrhhtipocapaci.Enabled = estado
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout

    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class