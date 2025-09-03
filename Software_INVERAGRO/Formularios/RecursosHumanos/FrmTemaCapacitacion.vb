Imports CapaNegocio
Imports CapaObjetos

Public Class FrmTemaCapacitacion
    Dim cn As New cnTemaCapacitacion
    Private _CodTemaCapa As Integer
    Dim _Operacion As Integer
    Dim idCodigo As Integer = 0

    Sub Nuevo()
        _Operacion = 0
        Cambio()
        limpiar()
    End Sub

    Sub limpiar()
        txtDescripcion.Text = ""
        txtDescripcion.Select()
        _CodTemaCapa = 0
    End Sub

    Sub Cambio()
        btnNuevoRrhhteca.Visible = False
        btnEditarRrhhteca.Visible = False
        btnGuardarRrhhteca.Visible = True
        btnCancelar.Visible = True
        txtDescripcion.Enabled = True
        cmbAreaCapacitadora.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevoRrhhteca.Visible = True
        btnEditarRrhhteca.Visible = True
        btnGuardarRrhhteca.Visible = False
        btnCancelar.Visible = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        cmbAreaCapacitadora.Enabled = False
        cmbEstado.Enabled = False
    End Sub
    Private Sub FrmTemaCapacitacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbEstado.SelectedIndex = 0
        btnGuardarRrhhteca.Visible = False
        btnCancelar.Visible = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        cmbAreaCapacitadora.Enabled = False
        cmbEstado.Enabled = False
        ListarAreaCapacitadora()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub
    Sub ListarAreaCapacitadora()
        Dim cn As New cnAreaCapacitadora
        Dim tb As New DataTable
        tb = cn.Cn_Listar().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Área Capacitadora"
        With cmbAreaCapacitadora
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (_Operacion = 1 OrElse _Operacion = 2) AndAlso (idCodigo = 0) Then
                msj_advert("Seleccione un Registro")
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtDescripcion.Text = "" OrElse txtDescripcion.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE GUARDAR ESTE REGISTRO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coTemaCapacitacion With {
                .Operacion = _Operacion,
                .Codigo = _CodTemaCapa,
                .Descripcion = txtDescripcion.Text,
                .Estado = cmbEstado.Text,
                .IdAreaCapacitadora = cmbAreaCapacitadora.Value
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
        dtgListado.DataSource = cn.Cn_Consultar()
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True

        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "INACTIVO", 3)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 3)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoRrhhteca.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarRrhhteca.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    cmbEstado.Enabled = True
                    _Operacion = 1
                    Cambio()
                    _CodTemaCapa = CInt(activeRow.Cells("Código").Value.ToString)
                    idCodigo = _CodTemaCapa
                    txtDescripcion.Text = activeRow.Cells("Descripción").Value.ToString
                    txtDescripcion.Focus()
                    cmbAreaCapacitadora.Text = activeRow.Cells("Área capacitadora").Value.ToString
                    cmbEstado.Text = activeRow.Cells("Estado").Value.ToString
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

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarRrhhteca.Click
        Mantenimiento()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Public Sub ToolStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class