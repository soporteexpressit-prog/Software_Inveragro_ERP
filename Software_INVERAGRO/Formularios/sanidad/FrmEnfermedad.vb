Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmEnfermedad
    Dim cn As New cnEnfermedad
    Private _CodEnfermedad As Integer = 0
    Dim _Operacion As Integer

    Sub Nuevo()
        _Operacion = 0
        Cambio()
        limpiar()
    End Sub

    Sub limpiar()
        txtNombre.Text = ""
        txtNombre.Select()
        txtDescripcion.Text = ""
        txtViaAplicacion.Text = ""
        _CodEnfermedad = 0
    End Sub

    Sub Cambio()
        btnNuevoSAenfer.Visible = False
        btnEditarSAenfer.Visible = False
        btnGuardarSAenfer.Visible = True
        btnCancelar.Visible = True
        txtNombre.Enabled = True
        txtDescripcion.Enabled = True
        txtViaAplicacion.Enabled = True
        cmbNivel.Enabled = True
        BtnEliminar.Visible = False
    End Sub

    Sub Cancelar()
        btnNuevoSAenfer.Visible = True
        btnEditarSAenfer.Visible = True
        btnGuardarSAenfer.Visible = False
        btnCancelar.Visible = False
        txtNombre.Clear()
        txtNombre.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        txtViaAplicacion.Clear()
        txtViaAplicacion.Enabled = False
        cmbNivel.Enabled = False
        BtnEliminar.Visible = True
    End Sub
    Private Sub FrmEnfermedad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            btnGuardarSAenfer.Visible = False
            btnCancelar.Visible = False
            txtNombre.Clear()
            txtNombre.Enabled = False
            TxtDescripcion.Clear()
            TxtDescripcion.Enabled = False
            TxtViaAplicacion.Clear()
            TxtViaAplicacion.Enabled = False
            cmbNivel.Enabled = False
            CargarNivelesEnfermedad()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub CargarNivelesEnfermedad()
        Dim niveles As New List(Of String) From {"LEVE", "MEDIO", "GRAVE"}
        cmbNivel.DataSource = niveles
    End Sub
    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (_Operacion = 1 OrElse _Operacion = 2) AndAlso (_CodEnfermedad = 0) Then
                msj_advert("Seleccione un Registro")
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtDescripcion.Text = "" OrElse txtDescripcion.Text.Length = 0) AndAlso (txtViaAplicacion.Text = "" OrElse txtViaAplicacion.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR Y/O ACTUALIZAR ESTA ENFEMEDAD?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coEnfermedad With {
                .Operacion = _Operacion,
                .Codigo = _CodEnfermedad,
                .Nombre = txtNombre.Text,
                .Descripcion = txtDescripcion.Text,
                .TipoNivel = cmbNivel.SelectedValue.ToString(),
                .ViaAplicacion = txtViaAplicacion.Text,
                .Iduser = VP_IdUser
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
        dtgListado.DataSource = cn.Cn_Listar()
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Colorear()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoSAenfer.Click
        Nuevo()
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estado As Integer = 5

            'estadoPeso
            clsBasicas.Colorear_SegunValor(dtgListado, Color.PaleGreen, Color.DarkGreen, "LEVE", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "MEDIO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.IndianRed, Color.White, "GRAVE", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarSAenfer.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodEnfermedad = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                _CodEnfermedad = _CodEnfermedad
                txtNombre.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
                Dim valorComboBox As String = dtgListado.DisplayLayout.ActiveRow.Cells(5).Value.ToString
                txtViaAplicacion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(3).Value.ToString
                cmbNivel.SelectedItem = valorComboBox
                txtDescripcion.Focus()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarSAenfer.Click
        Mantenimiento()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportarSAenfer.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL ENFERMEDADES", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then

                    If (MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTA ENFERMEDAD?", "Aprobar Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    Dim obj As New coEnfermedad With {
                        .Codigo = activeRow.Cells(0).Value.ToString()
                    }

                    Dim MensajeBgWk As String = cn.Cn_EliminarEnfermedad(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(MensajeBgWk)
                        Consultar()
                    Else
                        msj_advert(MensajeBgWk)
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class