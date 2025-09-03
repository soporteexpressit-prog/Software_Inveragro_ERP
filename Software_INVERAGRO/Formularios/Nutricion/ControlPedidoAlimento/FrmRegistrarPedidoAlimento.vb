Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmRegistrarPedidoAlimento
    Private DtDetalleAlimento As New DataTable("TempDetAlimento")
    Public DtDetalleMedicamentos As New DataTable("TempDetMedicamento")
    Dim cn As New cnControlAlimento
    Dim idAntiValorOriginal As Integer = 0
    Dim idAntiValor As Integer = 0
    Dim idPlanMedicadoValor As Integer = 0
    Dim idPeriodoMedicacionValorOriginal As Integer = 0
    Dim idPeriodoMedicacionValor As Integer = 0
    Dim idPeriodoPlusValorOriginal As Integer = 0
    Dim idPeriodoPlusValor As Integer = 0
    Dim flag As Boolean = False
    Dim valorMedicacion As String = "MEDICADO"
    Dim valorPlus As String = "PLUS"

    Private Sub FrmRegistrarPedidoAlimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            clsBasicas.ListarPlantelesAsignados(cbxalmacendestino)
            ListarAlmacenesPrincipales()
            CargarTablaDetalleAlimento()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Inicializar()
        txtCodAlimento.Enabled = False
        txtCodAlimento.Visible = False
        txtDescripcionAlimento.Enabled = False
        txtCantidad.Text = 1
        ChkAnti.Enabled = False
        ChkMedicacion.Enabled = False
        ChkPlus.Enabled = False
        'para la medicación
        LblMedicaciones.Visible = False
        BtnBuscarMedicacion.Visible = False
        LblSeleccionadoMedicado.Visible = False
        'para el plus
        LblPlus.Visible = False
        BtnBuscarPlus.Visible = False
        LblSeleccionadoPlus.Visible = False
        TxtNotaGeneral.Text = ""
        TxtNotaGeneral.ReadOnly = True
    End Sub

    Sub ListarCampañasActivas()
        Dim cn As New cnControlLoteDestete
        Dim obj As New coControlLoteDestete With {
            .IdPlantel = cbxalmacendestino.SelectedValue
        }
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarCampañasActivas(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Campaña"
        With CmbCampaña
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarAlmacenesPrincipales()
        Dim cn As New cnProducto
        Dim tb As New DataTable
        tb = cn.Cn_ListarAlmacenPrincipal().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Categoría"
        With cmbAlmacenPrincipal
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub btnBuscarInsumos_Click(sender As Object, e As EventArgs) Handles btnBuscarInsumos.Click
        Try
            If (flag = False) Then
                If (MessageBox.Show("¿ESTÁ SEGURO QUE ES PEDIDO DE ALIMENTO ES PARA " & cbxalmacendestino.Text & "?", "Aprobar Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If
            End If

            flag = True
            cbxalmacendestino.Enabled = False
            Dim f As New FrmListarAlimentos(Me) With {
                .IdUbicacionDestino = cbxalmacendestino.SelectedValue
            }
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposAlimento(codigo As Integer, descripcion As String, idAnti As Integer, idPlanMedicado As Integer, idPeriodoMedicacion As Integer, totalMedicacionesActivas As Integer, idPlus As Integer, totalPlusActivas As Integer)
        txtCodAlimento.Text = codigo
        txtDescripcionAlimento.Text = descripcion
        idAntiValorOriginal = idAnti
        idPlanMedicadoValor = idPlanMedicado
        idPeriodoMedicacionValorOriginal = idPeriodoMedicacion
        idPeriodoPlusValorOriginal = idPlus

        If idAntiValorOriginal <> 0 Then
            ChkAnti.Enabled = True
        Else
            ChkAnti.Enabled = False
        End If

        'para la medicación
        If totalMedicacionesActivas = 1 Then
            ChkMedicacion.Enabled = True
        Else
            ChkMedicacion.Enabled = False
        End If

        If totalMedicacionesActivas > 1 Then
            LblMedicaciones.Visible = True
            BtnBuscarMedicacion.Visible = True
            LblSeleccionadoMedicado.Visible = True
            ChkMedicacion.Visible = False
        Else
            LblMedicaciones.Visible = False
            BtnBuscarMedicacion.Visible = False
            LblSeleccionadoMedicado.Visible = False
            ChkMedicacion.Visible = True
        End If

        'para el plus
        If totalPlusActivas = 1 Then
            ChkPlus.Enabled = True
        Else
            ChkPlus.Enabled = False
        End If

        If totalPlusActivas > 1 Then
            LblPlus.Visible = True
            BtnBuscarPlus.Visible = True
            LblSeleccionadoPlus.Visible = True
            ChkPlus.Visible = False
        Else
            LblPlus.Visible = False
            BtnBuscarPlus.Visible = False
            LblSeleccionadoPlus.Visible = False
            ChkPlus.Visible = True
        End If

        LblSeleccionadoMedicado.Text = "-"
        LblSeleccionadoPlus.Text = "-"
        idPeriodoMedicacionValor = 0
        idPeriodoPlusValor = 0
        idAntiValor = 0
    End Sub

    Sub CargarTablaDetalleAlimento()
        DtDetalleAlimento = New DataTable("TempDetAlimento")
        DtDetalleAlimento.Columns.Add("codprod", GetType(Integer))
        DtDetalleAlimento.Columns.Add("producto", GetType(String))
        DtDetalleAlimento.Columns.Add("cantidad", GetType(Decimal))
        DtDetalleAlimento.Columns.Add("tipo", GetType(String))
        DtDetalleAlimento.Columns.Add("nota", GetType(String))
        DtDetalleAlimento.Columns.Add("btneliminar", GetType(String))
        DtDetalleAlimento.Columns.Add("idAnti", GetType(Integer))
        DtDetalleAlimento.Columns.Add("planMedicado", GetType(Integer))
        DtDetalleAlimento.Columns.Add("idPeriodoMedicacion", GetType(Integer))
        DtDetalleAlimento.Columns.Add("idPlus", GetType(Integer))
        dtgListadoAlimento.DataSource = DtDetalleAlimento
        clsBasicas.Formato_Tablas_Grid(dtgListadoAlimento)
        dtgListadoAlimento.DisplayLayout.Bands(0).Columns("idAnti").Hidden = True
        dtgListadoAlimento.DisplayLayout.Bands(0).Columns("planMedicado").Hidden = True
        dtgListadoAlimento.DisplayLayout.Bands(0).Columns("idPeriodoMedicacion").Hidden = True
        dtgListadoAlimento.DisplayLayout.Bands(0).Columns("idPlus").Hidden = True
    End Sub

    Private Sub dtgListadoAlimento_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListadoAlimento.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este Alimento?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetalleAlimento.Rows.RemoveAt(rowIndex)
                DtDetalleAlimento.AcceptChanges()
                dtgListadoAlimento.DataSource = DtDetalleAlimento
                ActualizarNotaGeneralDesdeDetalle()
            End If
        End If
    End Sub

    Private Sub ActualizarNotaGeneralDesdeDetalle()
        Dim notas As New List(Of String)
        For Each row As DataRow In DtDetalleAlimento.Rows
            Dim producto As String = row("producto").ToString()
            Dim tipo As String = row("tipo").ToString()
            Dim nota As String = row("nota").ToString().Trim()

            ' Solo añadir si la nota contiene algo más que espacios
            If Not String.IsNullOrWhiteSpace(nota) Then
                Dim textoNota As String
                If tipo <> "NORMAL" Then
                    textoNota = $"{producto}-{tipo}: {nota}"
                Else
                    textoNota = $"{producto}: {nota}"
                End If
                notas.Add(textoNota)
            End If
        Next
        TxtNotaGeneral.Text = String.Join(" / ", notas)
    End Sub

    Private Sub dtgListadoAlimento_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListadoAlimento.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Header.Caption = "Alimento"
                .Columns(1).Width = 150
                .Columns(2).Header.Caption = "Cantidad"
                .Columns(2).Width = 65
                .Columns(3).Header.Caption = "Tipo"
                .Columns(3).Width = 65
                .Columns(4).Header.Caption = "Nota"
                .Columns(4).Width = 150
                .Columns(5).Header.Caption = "Eliminar"
                .Columns(5).Width = 60
                .Columns(5).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(5).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(5).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnAgregarAlimento_Click(sender As Object, e As EventArgs) Handles btnAgregarAlimento.Click
        Try
            Dim valorTipo As String = ""

            If String.IsNullOrWhiteSpace(txtCodAlimento.Text) Then
                msj_advert("Seleccione un Alimento")
                Return
            End If
            Dim cantidad As Decimal
            If String.IsNullOrWhiteSpace(txtCantidad.Text) Then
                msj_advert("Ingrese una Cantidad")
                Return
            ElseIf Not Decimal.TryParse(txtCantidad.Text, cantidad) Then
                msj_advert("Por Favor Ingrese una Cantidad válida")
                txtCantidad.Select()
                Return
            ElseIf cantidad <= 0 Then
                msj_advert("La Cantidad debe ser mayor que 0")
                txtCantidad.Select()
                Return
            End If

            Dim filtro As String = "codprod = " & txtCodAlimento.Text & " AND idAnti= " & idAntiValor & " AND idPeriodoMedicacion = " & idPeriodoMedicacionValor & " AND idPlus = " & idPeriodoPlusValor

            Dim existeProducto = DtDetalleAlimento.Select(filtro)

            If existeProducto.Length > 0 Then
                msj_advert("La ración ya existe en la lista.")
                Return
            End If

            If idAntiValor <> 0 Then
                If idPeriodoMedicacionValor <> 0 Then
                    If idPeriodoPlusValor <> 0 Then
                        valorTipo = "ANTI-" & valorMedicacion & "-" & valorPlus
                    Else
                        valorTipo = "ANTI-" & valorMedicacion
                    End If
                Else
                    If idPeriodoPlusValor <> 0 Then
                        valorTipo = "ANTI-" & valorPlus
                    Else
                        valorTipo = "ANTI"
                    End If
                End If
            Else
                If idPeriodoMedicacionValor <> 0 Then
                    If idPeriodoPlusValor <> 0 Then
                        valorTipo = valorMedicacion & "-" & valorPlus
                    Else
                        valorTipo = valorMedicacion
                    End If
                Else
                    If idPeriodoPlusValor <> 0 Then
                        valorTipo = valorPlus
                    Else
                        valorTipo = "NORMAL"
                    End If
                End If
            End If

            'ingresamos los valores a la tabla
            Dim dr As DataRow = DtDetalleAlimento.NewRow
            dr(0) = txtCodAlimento.Text
            dr(1) = txtDescripcionAlimento.Text
            Dim c As Double
            c = CDbl(txtCantidad.Text.Trim).ToString(P_FormatoDecimales)
            dr(2) = c
            dr(3) = valorTipo
            dr(4) = TxtObservacion.Text.Trim
            dr(6) = idAntiValor
            dr(7) = idPlanMedicadoValor
            dr(8) = idPeriodoMedicacionValor
            dr(9) = idPeriodoPlusValor

            DtDetalleAlimento.Rows.Add(dr)
            DtDetalleAlimento.AcceptChanges()
            dtgListadoAlimento.DataSource = DtDetalleAlimento

            ActualizarNotaGeneralDesdeDetalle()
            LimpiarCamposAlimento()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarCamposAlimento()
        txtCodAlimento.Text = ""
        txtDescripcionAlimento.Text = ""
        txtCantidad.Text = 1
        idAntiValor = 0
        idPlanMedicadoValor = 0
        ChkAnti.Enabled = False
        ChkAnti.Checked = False
        TxtObservacion.Text = ""
        'para la medicación
        ChkMedicacion.Enabled = False
        ChkMedicacion.Checked = False
        LblMedicaciones.Visible = False
        BtnBuscarMedicacion.Visible = False
        LblSeleccionadoMedicado.Visible = False
        LblSeleccionadoMedicado.Text = "-"
        'para el plus
        ChkPlus.Enabled = False
        ChkPlus.Checked = False
        LblPlus.Visible = False
        BtnBuscarPlus.Visible = False
        LblSeleccionadoPlus.Visible = False
        LblSeleccionadoPlus.Text = "-"
        valorMedicacion = "MEDICADO"
        valorPlus = "PLUS"
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (DtpFechaPedido.Value > Date.Now) Then
                msj_advert("La fecha de pedido no puede ser mayor a la fecha actual")
                DtpFechaPedido.Focus()
                Return
            End If

            If (dtgListadoAlimento.Rows.Count = 0) Then
                msj_advert("Seleccione una ración")
            Else
                If (MessageBox.Show("¿ESTÁ SEGURO DE REALIZAR ESTE PEDIDO DE ALIMENTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim obj As New coControlAlimento With {
                    .IdUsuario = VP_IdUser,
                    .IdAlmacenPrincipal = cmbAlmacenPrincipal.Value,
                    .IdAlmacenSolicitante = cbxalmacendestino.SelectedValue,
                    .ListaAlimentos = creacion_de_array_alimento(),
                    .FechaPedido = DtpFechaPedido.Value,
                    .Observacion = TxtNotaGeneral.Text,
                    .IdCampana = If(cbxalmacendestino.SelectedValue = 1 Or cbxalmacendestino.SelectedValue = 2, 0, CmbCampaña.Value)
                }

                Dim MensajeBgWk As String = cn.Cn_RegistrarRequerimientoAlimento(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Close()
                Else
                    msj_advert(MensajeBgWk)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function creacion_de_array_alimento() As String
        Dim array_valvulas As String = ""
        If (dtgListadoAlimento.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgListadoAlimento.Rows.Count - 1
                If (dtgListadoAlimento.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtgListadoAlimento.Rows(i)
                        array_valvulas = array_valvulas & .Cells("cantidad").Value.ToString.Trim & "+" &
                            .Cells("codprod").Value.ToString.Trim & "+" &
                            .Cells("idAnti").Value.ToString.Trim & "+" &
                            .Cells("planMedicado").Value.ToString.Trim & "+" &
                            .Cells("idPeriodoMedicacion").Value.ToString.Trim & "+" &
                            .Cells("idPlus").Value.ToString.Trim & ","
                    End With
                End If
            Next

            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnBuscarMedicacion_Click(sender As Object, e As EventArgs) Handles BtnBuscarMedicacion.Click
        Try
            Dim frm As New FrmListaMedicacionesPorRacion(Me) With {
                .idRacion = CInt(txtCodAlimento.Text),
                .idUbicacion = cbxalmacendestino.SelectedValue,
                .tipo = "MEDICACIÓN"
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub ActualizarMedicacionRacion(codigo As Integer, medicacionPlus As String, tipo As String)
        If tipo = "MEDICACIÓN" Then
            idPeriodoMedicacionValor = codigo
            LblSeleccionadoMedicado.Visible = True
            LblSeleccionadoMedicado.Text = medicacionPlus
            valorMedicacion = medicacionPlus
        Else
            idPeriodoPlusValor = codigo
            LblSeleccionadoPlus.Visible = True
            LblSeleccionadoPlus.Text = medicacionPlus
            valorPlus = medicacionPlus
        End If
    End Sub

    Private Sub ChkAnti_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAnti.CheckedChanged
        If ChkAnti.Checked Then
            idAntiValor = idAntiValorOriginal
        Else
            idAntiValor = 0
        End If
    End Sub

    Private Sub ChkMedicacion_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMedicacion.CheckedChanged
        If ChkMedicacion.Checked Then
            idPeriodoMedicacionValor = idPeriodoMedicacionValorOriginal
        Else
            idPeriodoMedicacionValor = 0
        End If
    End Sub

    Private Sub ChkPlus_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPlus.CheckedChanged
        If ChkPlus.Checked Then
            idPeriodoPlusValor = idPeriodoPlusValorOriginal
        Else
            idPeriodoPlusValor = 0
        End If
    End Sub

    Private Sub BtnBuscarPlus_Click(sender As Object, e As EventArgs) Handles BtnBuscarPlus.Click
        Try
            Dim frm As New FrmListaMedicacionesPorRacion(Me) With {
                .idRacion = CInt(txtCodAlimento.Text),
                .idUbicacion = cbxalmacendestino.SelectedValue,
                .tipo = "PLUS"
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxalmacendestino_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbxalmacendestino.SelectedValueChanged
        If cbxalmacendestino.SelectedValue IsNot Nothing AndAlso IsNumeric(cbxalmacendestino.SelectedValue) Then
            ListarCampañasActivas()
            If cbxalmacendestino.SelectedValue = 1 Or cbxalmacendestino.SelectedValue = 2 Then
                CmbCampaña.Visible = False
                LblCampaña.Visible = False
            Else
                CmbCampaña.Visible = True
                LblCampaña.Visible = True
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class