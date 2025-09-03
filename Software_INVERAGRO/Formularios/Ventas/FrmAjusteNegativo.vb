Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmAjusteNegativo
    Dim cn As New cnVentas
    Dim tieneigv As String
    Dim iddetalleingreso As Integer
    Public _codigo As Integer = 0
    Public _idordencompra As Integer = 0
    Public operacion As Integer = 0
    Sub ListarTablas()
        Try
            Dim cn2 As New cnIngreso
            Dim ds As New DataSet
            ds = cn2.Cn_ListarTablasMaestrasCompra().Copy
            ds.DataSetName = "tmp"
            ds.Tables(0).Columns(1).ColumnName = "Seleccione una Moneda"

            Dim indice_tabla As Integer = 0
            With cbxmoneda
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarTablas()
            Me.Size = New Size(818, 512)
            CargarTablaDetalle()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ConsultarOrdenCompra()
            cbxflete.SelectedIndex = 0
            If _codigo = 4 Or _codigo = 3 Then
                If _codigo = 4 Then
                    Me.Text = "FINALIZAR ORDEN DE COMPRA"
                ElseIf _codigo = 3 Then
                    Me.Text = "AJUSTAR ORDEN DE COMPRA"
                End If
                Label4.Enabled = False
                txtcantidad.Enabled = False
                Label27.Enabled = False
                txtstock.Enabled = False
                Label6.Enabled = False
                ckigv.Enabled = False
                Label8.Enabled = False
                cbxmoneda.Enabled = False
                Label5.Enabled = False
                UltraTextEditor1.Enabled = False
                cbxagregar.Enabled = False
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub CalculaTotal()
        Dim total As Decimal = 0
        Dim flete As Decimal = 0
        Dim subtotal As Decimal = 0
        Dim igv As Decimal = 0
        Const IGV_TASA As Decimal = 0.18 ' 18% de IGV
        If DtDetalle.Rows.Count > 0 Then
            For Each Fila As DataRow In DtDetalle.Rows
                Dim precio As Decimal
                Dim cantidad As Decimal

                ' Validar y convertir valores
                Decimal.TryParse(Fila(3).ToString(), precio)
                Decimal.TryParse(Fila(4).ToString(), cantidad)

                total += precio * cantidad
            Next
        End If
        If Not Decimal.TryParse(txtflete.Text, flete) Then
            flete = 0
            txtflete.Text = "0.00"
        End If
        subtotal = total + flete
        If ckigv.Checked Then
            igv = Math.Round(subtotal * IGV_TASA, P_Redondeo_Decimal3)
            subtotal = Math.Round(subtotal, P_Redondeo_Decimal3)
            total = Math.Round(subtotal + igv, P_Redondeo_Decimal3)
        Else
            igv = 0
            total = Math.Round(subtotal + igv, P_Redondeo_Decimal3)
        End If
        txtsubtotal.Text = subtotal.ToString(P_FormatoDecimales)
        txtigv.Text = igv.ToString(P_FormatoDecimales)
        txttotal.Text = total.ToString(P_FormatoDecimales)
    End Sub
    Sub ConsultarOrdenCompra()
        Dim obj As New coIngreso
        Dim cn As New cnIngreso
        obj.Codigo = _idordencompra
        Dim ds As New DataSet
        ds = cn.Cn_ConsultarOrdendeCompraxCodigo(obj).Copy

        If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            Dim hdr As DataRow = ds.Tables(0).Rows(0)
            txttotal.Text = hdr("total").ToString()
            txtigv.Text = hdr("igv").ToString()
            txtflete.Text = hdr("flete").ToString()
            tieneigv = hdr("conigv").ToString()
            ckigv.Checked = (tieneigv.Trim().ToUpper() = "SI")
            txtfleteinterno.Text = hdr("flete_interno").ToString()
            If txtflete.Text > 0 Then
                cbxflete.SelectedIndex = 1
            Else
                cbxflete.SelectedIndex = 0
            End If
            cbxmoneda.Value = hdr("idmoneda").ToString()
            UltraTextEditor1.Text = hdr("tipocambio").ToString()
        Else
            Return
        End If

        ' Limpia el DataTable antes de llenarlo
        DtDetalle.Clear()

        ' Selecciona la tabla de detalle según el valor de _codigo
        If _codigo = 4 Then
            ' Tercera tabla (índice 2)
            If ds.Tables.Count > 2 AndAlso ds.Tables(2).Rows.Count > 0 Then
                DtDetalle = ds.Tables(2).Copy
                dtgListado.DataSource = DtDetalle
            Else
                dtgListado.DataSource = Nothing
                MessageBox.Show("La orden de compra no se puede finalizar, si no tiene recepciones registradas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dispose()
            End If
        ElseIf _codigo = 3 Then
            ' Tercera tabla (índice 2)
            If ds.Tables.Count > 3 AndAlso ds.Tables(3).Rows.Count > 0 Then
                DtDetalle = ds.Tables(3).Copy
                dtgListado.DataSource = DtDetalle
            Else
                dtgListado.DataSource = Nothing
                MessageBox.Show("La orden de compra no se puede finalizar, si no tiene recepciones registradas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dispose()
            End If
        Else
            ' Segunda tabla (índice 1)
            If ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 0 Then
                DtDetalle = ds.Tables(1).Copy
                dtgListado.DataSource = DtDetalle
            Else
                dtgListado.DataSource = Nothing
                MessageBox.Show("No se encontraron datos para la orden de compra, por favor cancele recepciones para poder editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dispose()
            End If
        End If

        CalculaTotal()
    End Sub

    Private Sub ckigv_CheckedChanged(sender As Object, e As EventArgs) Handles ckigv.CheckedChanged
        CalculaTotal()
    End Sub

    Private DtDetalle As New DataTable("TempDetProd")
    Sub CargarTablaDetalle()
        ' Create Columns
        DtDetalle = New DataTable("TempDetProd")
        DtDetalle.Columns.Add("codprod", GetType(Integer))
        DtDetalle.Columns.Add("producto", GetType(String))
        DtDetalle.Columns.Add("unidad", GetType(String))
        DtDetalle.Columns.Add("cantidad", GetType(Decimal))
        DtDetalle.Columns.Add("precunit", GetType(Decimal))
        DtDetalle.Columns.Add("iddetpedpres", GetType(Integer))
        DtDetalle.Columns.Add("btnelegir", GetType(String))
        dtgListado.DataSource = DtDetalle
    End Sub
    Sub Agregar()
        Try
            If txtcodprod.Text.Trim.Length = 0 Then
                msj_advert("Seleccione un Producto")
                Return
            ElseIf txtcantidad.Text.Trim.Length = 0 OrElse CDec(txtcantidad.Text) = 0 Then
                msj_advert("Por Favor Ingrese la Cantidad")
                txtcantidad.Select()
                Return
            End If
            Dim newQty As Decimal = Decimal.Parse(txtcantidad.Text.Trim)
            Dim newPrice As Decimal = Decimal.Parse(txtprecio.Text.Trim)
            For Each row As DataRow In DtDetalle.Rows
                If row("codprod").ToString() = txtcodprod.Text.Trim() Then
                    row("cantidad") = newQty
                    row("precunit") = newPrice
                    DtDetalle.AcceptChanges()
                    dtgListado.DataSource = DtDetalle
                    dtgListado.DataBind()
                    txtcodprod.Text = ""
                    txtproducto.Text = ""
                    txtcantidad.Text = ""
                    txtunidadmedida.Text = ""
                    txtstock.Text = ""
                    txtprecio.Text = ""
                    Return
                End If
            Next
            ' 3) Si no existía, lo agrego nuevo
            Dim dr As DataRow = DtDetalle.NewRow()
            dr("codprod") = txtcodprod.Text.Trim()
            dr("producto") = txtproducto.Text.Trim()
            dr("unidad") = txtunidadmedida.Text.Trim()
            dr("cantidad") = newQty
            dr("precio") = newPrice
            dr("importe") = 0
            DtDetalle.Rows.Add(dr)
            DtDetalle.AcceptChanges()
            dtgListado.DataSource = DtDetalle
            dtgListado.DataBind()
            txtcodprod.Text = ""
            txtproducto.Text = ""
            txtunidadmedida.Text = ""
            txtcantidad.Text = ""
            txtprecio.Text = ""
            txtstock.Text = ""
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "Codigo"
                .Columns(0).Width = 80
                .Columns(1).Header.Caption = "Producto"
                .Columns(1).Width = 160
                .Columns(2).Header.Caption = "Unidad Medida"
                .Columns(2).Width = 120
                .Columns(3).Header.Caption = "Cantidad"
                .Columns(3).Width = 90
                .Columns(4).Header.Caption = "Precio"
                .Columns(4).Width = 90
                .Columns(5).Hidden = True
                .Columns(6).Header.Caption = "Elegir"
                .Columns(6).Width = 80
                .Columns(6).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(6).CellButtonAppearance.Image = My.Resources.editar
                .Columns(6).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always

            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            If MsgBox("¿Esta Seguro de Guardar el Ajuste?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If

            If (dtgListado.Rows.Count = 0) Then
                msj_advert("Seleccione un Producto")
                Return
            Else
                Dim obj As New coVentas
                obj.Codigo = _codigo
                obj.Serie = "0"
                obj.Correlativo = "0"
                obj.FEmision = Now.Date
                obj.Fpedido = Now.Date
                obj.Total = txttotal.Text
                obj.Igv = txtigv.Text
                obj.Flete = 0
                obj.Observacion = "AJUSTE POR PROVEEDORES TERCEROS"
                obj.Estado = "ACTIVO"
                obj.Iduser = VP_IdUser
                obj.IdCondicionpago = 1
                obj.IdMotivoTransaccion = 37
                obj.Frecepcion = Now.Date
                obj.IdUbicacionOrigen = 6
                obj.IdUbicacionDestino = 6
                obj.Idmoneda = 1
                obj.Tipocambio = 1
                obj.Idcotizacion = 0

                    obj.Lista_items = creacion_de_arrary()
                obj.Idtipodocumento = 15
                obj.Idproveedor = VP_IdUser
                obj.Idordencompra = _idordencompra
                obj.EstadoRecepcion = "SI"
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_RegAjusteNegativoOrdenCompra(obj)
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

    Function creacion_de_arrary() As String
        Dim array_valvulas As New Text.StringBuilder()
        If dtgListado.Rows.Count = 0 Then
            Return "0"
        End If
        For i = 0 To dtgListado.Rows.Count - 1
            Dim row = dtgListado.Rows(i)
            If Not String.IsNullOrWhiteSpace(row.Cells(0).Value?.ToString()) Then
                array_valvulas.AppendFormat("{0}+{1}+{2},",
                                        row.Cells(3).Value.ToString().Trim(),
                                        row.Cells(4).Value.ToString(),
                                        row.Cells(0).Value.ToString())
            End If
        Next
        If array_valvulas.Length > 0 Then
            array_valvulas.Length -= 1
        End If
        Return array_valvulas.ToString()
    End Function

    Private Sub Dtg_Listado_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            If e.Cell.Column.Key = "btnelegir" Then
                Dim activeRow = dtgListado.ActiveRow
                If activeRow IsNot Nothing Then
                    txtcodprod.Text = activeRow.Cells(0).Value?.ToString()
                    txtproducto.Text = activeRow.Cells(1).Value?.ToString()
                    txtunidadmedida.Text = activeRow.Cells(2).Value?.ToString()
                    txtcantidad.Text = activeRow.Cells(3).Value?.ToString()
                    txtstock.Text = activeRow.Cells(3).Value?.ToString()
                    txtprecio.Text = activeRow.Cells(4).Value?.ToString()
                End If
            End If

        Catch ex As Exception
            MsgBox("Ocurrió un error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub

    Private Sub cbxagregar_Click(sender As Object, e As EventArgs) Handles cbxagregar.Click
        Agregar()
        CalculaTotal()
    End Sub

    Private Sub btnactualizar_Click(sender As Object, e As EventArgs) Handles btnactualizar.Click
        Try
            If MsgBox("¿Esta Seguro de Guardar el Ajuste?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If
            If (dtgListado.Rows.Count = 0) Then
                msj_advert("Seleccione un Producto")
                Return
            Else
                Dim obj As New coVentas
                obj.Codigo = _codigo
                obj.Total = txttotal.Text
                obj.Igv = txtigv.Text
                obj.Flete = IIf(txtflete.Text.Length = 0, "0", txtflete.Text)
                obj.Fleteinterno = IIf(txtfleteinterno.Text.Length = 0, "0", txtfleteinterno.Text)
                obj.Observacion = "ACTUALIZACION DE PRECIO O CANTIDAD"
                obj.Lista_items = creacion_de_arrary()
                obj.Idordencompra = _idordencompra
                obj.Idmoneda = cbxmoneda.Value
                obj.Tipocambio = UltraTextEditor1.Text
                obj.conigv = IIf(ckigv.Checked, "SI", "NO")
                Dim MensajeBgWk As String = ""
                If _codigo = 4 Or _codigo = 3 Then
                    MensajeBgWk = cn.Cn_culminarordencompra(obj)
                Else
                    MensajeBgWk = cn.Cn_Updateordencompra(obj)
                End If
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

    Private Sub txtprecio_ValueChanged(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtprecio.KeyPress
        clsBasicas.ValidarNumerosDecimalessin_coma(e)
    End Sub

    Private Sub txtflete_ValueChanged_1(sender As Object, e As EventArgs) Handles txtflete.ValueChanged
        If (txtflete.Text.Length <> 0) Then
            CalculaTotal()
        End If
    End Sub

    Private Sub cbxflete_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxflete.SelectedIndexChanged
        If cbxflete.SelectedIndex = 0 Then
            txtflete.Visible = False
            txtfleteinterno.Visible = True
            txtflete.Text = 0
        Else
            txtfleteinterno.Visible = False
            txtflete.Visible = True
            txtfleteinterno.Text = 0
        End If
    End Sub

End Class