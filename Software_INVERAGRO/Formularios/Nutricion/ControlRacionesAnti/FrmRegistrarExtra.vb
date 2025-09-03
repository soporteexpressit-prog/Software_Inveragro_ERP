Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmRegistrarExtra
    Dim cn As New cnControlAlimento
    Dim _idMedicamento As Integer
    Private DtDetalle As New DataTable("TempDetProdExtra")
    Public tipoExtra As String

    Private Sub FrmRegistrarAnti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            CargarTablaDetalleProductoAnti()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Inicializar()
        txtDescripcionMedicamento.Enabled = False
        txtUnidadMedida.Enabled = False
        CbxNucleoInsumo.Checked = False
        CbxNucleoInsumo.Visible = False
        If (tipoExtra = "ANTI") Then
            CmbPremixeroAsignado.Text = "PREMIXERO 2"
            groupTitle.Text = "DETALLE MEDICAMENTO ANTI (1 TN)"
            DtpFechaRotacion.Visible = False
            LblFechaRotacion.Visible = False
        Else
            CmbPremixeroAsignado.SelectedIndex = 0
            groupTitle.Text = "DETALLE DE PLAN MEDICADO (1 TN)"
            DtpFechaRotacion.Value = Now.Date
            DtpFechaRotacion.Visible = True
            LblFechaRotacion.Visible = True
        End If
    End Sub

    Public Sub LlenarCamposMedicamento(codigo As Integer, medicamento As String, unidadMedida As String)
        _idMedicamento = codigo
        txtDescripcionMedicamento.Text = medicamento
        txtUnidadMedida.Text = unidadMedida
    End Sub

    Private Sub btnBuscarMedicamento_Click(sender As Object, e As EventArgs) Handles btnBuscarMedicamento.Click
        Dim f As New FrmListarMedicamento(Me)
        f.ShowDialog()
    End Sub

    Sub CargarTablaDetalleProductoAnti()
        DtDetalle = New DataTable("TempDetProdExtra")
        DtDetalle.Columns.Add("codprod", GetType(Integer))
        DtDetalle.Columns.Add("producto", GetType(String))
        DtDetalle.Columns.Add("unidad", GetType(String))
        DtDetalle.Columns.Add("cantidad", GetType(Decimal))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        dtgListado.DataSource = DtDetalle
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetalle.Rows.RemoveAt(rowIndex)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle
            End If
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Header.Caption = "Medicamento"
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

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If txtDescripcionMedicamento.Text.Length = 0 Then
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
                Dim existeProducto = DtDetalle.Select("codprod = " & _idMedicamento.ToString())
                If existeProducto.Length > 0 Then
                    msj_advert("El Medicamento ya existe en la lista")
                    Return
                End If

                Dim dr As DataRow = DtDetalle.NewRow
                dr(0) = _idMedicamento
                dr(1) = txtDescripcionMedicamento.Text
                dr(2) = txtUnidadMedida.Text
                Dim c As Double
                c = CDbl(txtCantidad.Text.Trim).ToString(P_FormatoDecimales)
                dr(3) = c
                DtDetalle.Rows.Add(dr)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle
                dtgListado.DataBind()

                LimpiarCamposProductoAnti()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarCamposProductoAnti()
        _idMedicamento = 0
        txtDescripcionMedicamento.Text = ""
        txtUnidadMedida.Text = ""
        txtCantidad.Text = 1
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert("Seleccione un Medicamento")
            Else
                Dim obj As New coControlAlimento With {
                    .Descripcion = tipoExtra & DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss"),
                    .IdUsuario = VP_IdUser,
                    .Tipo = tipoExtra,
                    .ListaMedicamentos = creacion_de_arrary(),
                    .TipoPremixero = CmbPremixeroAsignado.Text,
                    .IncluirEnNucleo = If(CbxNucleoInsumo.Checked, "SI", "NO"),
                    .FechaRecepcion = DtpFechaRotacion.Value
                }

                Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR " & tipoExtra & "?", "Confirmar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    Dim MensajeBgWk As String = ""
                    MensajeBgWk = cn.Cn_RegistrarMedicamentoExtra(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(MensajeBgWk)
                        Dispose()
                    Else
                        msj_advert(MensajeBgWk)
                    End If
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function creacion_de_arrary() As String
        Dim array_valvulas As String = ""

        If (dtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgListado.Rows.Count - 1
                If (dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtgListado.Rows(i)
                        array_valvulas &= .Cells(3).Value.ToString.Trim & "+" &
                            .Cells(0).Value.ToString.Replace(".", "_")
                    End With
                    If i < dtgListado.Rows.Count - 1 Then
                        array_valvulas &= ","
                    End If
                End If
            Next
        End If

        Return array_valvulas
    End Function

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

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