Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmRegistrarMedicacionRacion
    Dim cn As New cnMedicamentoRacion
    Dim codMedicacion As Integer = 0
    Private DtDetalleMedicRacion As New DataTable("TempDetMedicRacion")

    Private Sub FrmMantMedicacionRacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarPlanteles()
            ListarRaciones()
            CargarTablaDetalleMedicamentoRacion()
            txtMedicamento.Enabled = False
            txtUnidad.Enabled = False
            dtpFechaInicio.Value = Now.Date
            dtpFechaFin.Value = Now.Date
            dtpFechaInicio.Select()
            CmbPremixeroAsignado.SelectedIndex = 0
            CbxNucleoInsumo.Checked = False
            CbxNucleoInsumo.Visible = False
            CmbTipo.SelectedIndex = 0
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposMedicamentoRacion(codigo As Integer, descripcion As String, unidad As String)
        codMedicacion = codigo
        txtMedicamento.Text = descripcion
        txtUnidad.Text = unidad
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlanteles().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With cmbPlanteles
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarRaciones()
        Dim cn As New cnNucleo
        Dim tb As New DataTable
        tb = cn.Cn_ListarRaciones().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Ración"
        With cmbRaciones
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub btnAgregarMedicamento_Click(sender As Object, e As EventArgs) Handles btnAgregarMedicamento.Click
        Try
            Dim f As New FrmListarMedicamentoRacion(Me)
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If codMedicacion = 0 Then
                msj_advert("Seleccione un Medicamento")
                Return
            ElseIf txtCantidad.Text.Length = 0 Then
                msj_advert("Ingrese una Cantidad")
                Return
            ElseIf CDec(txtCantidad.Text) = 0 Then
                msj_advert("Por Favor Ingrese Cantidad válida")
                txtCantidad.Select()
                Return
            ElseIf txtCantidad.Text = 0 Then
                msj_advert("Por Favor Ingrese la Cantidad")
                txtCantidad.Select()
                Return
            Else
                Dim existeProducto = DtDetalleMedicRacion.Select("codprod = " & codMedicacion.ToString())
                If existeProducto.Length > 0 Then
                    msj_advert("EL MEDICAMENTO YA EXISTE EN LISTA")
                    Return
                End If

                Dim dr As DataRow = DtDetalleMedicRacion.NewRow
                dr(0) = codMedicacion
                dr(1) = txtMedicamento.Text
                dr(2) = txtUnidad.Text
                Dim c As Double
                c = CDbl(txtCantidad.Text.Trim).ToString(P_FormatoDecimales)
                dr(3) = c
                DtDetalleMedicRacion.Rows.Add(dr)
                DtDetalleMedicRacion.AcceptChanges()
                dtgListado.DataSource = DtDetalleMedicRacion
                dtgListado.DataBind()

                LimpiarCamposMedicamentoRacion()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarCamposMedicamentoRacion()
        codMedicacion = 0
        txtMedicamento.Text = ""
        txtUnidad.Text = ""
        txtCantidad.Text = 1
    End Sub

    Sub CargarTablaDetalleMedicamentoRacion()
        DtDetalleMedicRacion = New DataTable("TempDetMedicRacion")
        DtDetalleMedicRacion.Columns.Add("codprod", GetType(Integer))
        DtDetalleMedicRacion.Columns.Add("medicamento", GetType(String))
        DtDetalleMedicRacion.Columns.Add("unidad", GetType(String))
        DtDetalleMedicRacion.Columns.Add("cantidad", GetType(Decimal))
        DtDetalleMedicRacion.Columns.Add("btneliminar", GetType(String))
        dtgListado.DataSource = DtDetalleMedicRacion
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Header.Caption = "Producto"
                .Columns(1).Width = 200
                .Columns(2).Header.Caption = "U.M Mínima"
                .Columns(2).Width = 90
                .Columns(3).Header.Caption = "Cantidad"
                .Columns(3).Width = 65
                .Columns(4).Header.Caption = "Eliminar"
                .Columns(4).Width = 60
                .Columns(4).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(4).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(4).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este medicamento?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetalleMedicRacion.Rows.RemoveAt(rowIndex)
                DtDetalleMedicRacion.AcceptChanges()
                dtgListado.DataSource = DtDetalleMedicRacion
            End If
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert("Seleccione un medicamento")
            ElseIf dtpFechaInicio.Value > dtpFechaFin.Value Then
                msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
                Return
            Else

                If MsgBox("¿ESTAÁ SEGURO DE REGISTRAR MEDICACIÓN?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Registrar Medicación") = MsgBoxResult.No Then
                    Return
                End If

                Dim obj As New coMedicamentoRacion With {
                    .FechaInicio = dtpFechaInicio.Value,
                    .FechaFin = dtpFechaFin.Value,
                    .IdRacion = cmbRaciones.Value,
                    .IdUbicacion = cmbPlanteles.Value,
                    .Estado = "ACTIVO",
                    .IdUsuario = VP_IdUser,
                    .ListaMedicamentos = creacion_string_medicamento(),
                    .TipoPremixero = CmbPremixeroAsignado.Text,
                    .IncluirEnNucleo = If(CbxNucleoInsumo.Checked, "SI", "NO"),
                    .Tipo = CmbTipo.Text,
                    .Nota = TxtNota.Text
                }

                Dim MensajeBgWk As String = cn.Cn_RegistrarPeriodoMedicamentoRacion(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Dispose()
                Else
                    msj_advert(MensajeBgWk)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function creacion_string_medicamento() As String
        Dim array_valvulas As String = ""
        If (dtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgListado.Rows.Count - 1
                If (dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtgListado.Rows(i)
                        array_valvulas = array_valvulas & .Cells(3).Value.ToString.Trim & "+" &
                            .Cells(0).Value.ToString.ToString.Trim & ","
                    End With
                End If
            Next
        End If

        array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        Return array_valvulas
    End Function

    Private Sub CmbPremixeroAsignado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPremixeroAsignado.SelectedIndexChanged
        If (CmbPremixeroAsignado.Text = "PREMIXERO 2") Then
            CbxNucleoInsumo.Visible = True
        Else
            CbxNucleoInsumo.Checked = False
            CbxNucleoInsumo.Visible = False
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class