Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmCotizacion
    Dim cn As New cnCotizacion

    Public _codigo As Integer = 0

    Sub ListarTablas()
        Dim ds As New DataSet
        ds = cn.Cn_ListarTablasMaestras().Copy
        ds.DataSetName = "tmp"
        ds.Tables(0).Columns(1).ColumnName = "Seleccione una Moneda"
        With cbxmoneda
            .DataSource = ds.Tables(0)
            .DisplayMember = ds.Tables(0).Columns(1).ColumnName
            .ValueMember = ds.Tables(0).Columns(0).ColumnName
            If (ds.Tables(0).Rows.Count > 0) Then
                .Value = ds.Tables(0).Rows(0)(0)
            End If
        End With

        ds.Tables(1).Columns(1).ColumnName = "Seleccione una Condicion de Pago"
        With cbxcondicionpago
            .DataSource = ds.Tables(1)
            .DisplayMember = ds.Tables(1).Columns(1).ColumnName
            .ValueMember = ds.Tables(1).Columns(0).ColumnName
            If (ds.Tables(1).Rows.Count > 0) Then
                .Value = ds.Tables(1).Rows(0)(0)
            End If
        End With

    End Sub
    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1342, 1471)
        ListarTablas()
        Dtp_FecEmi.Value = Now.Date
        CargarTablaDetalle()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Sub BuscarProducto()
        Dim f As New FrmBuscarProductoCot()
        f._codalmacendestino = 1
        f.ShowDialog()
        If (f.codproducto <> 0) Then
            txtcodprod.Text = f.codproducto
            txtproducto.Text = f.descripcion
            txtpresentacion.Text = f.presentacion
            f.codproducto = 0
            txtcantidad.Focus()
        End If
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
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        dtgListado.DataSource = DtDetalle
    End Sub
    Sub Agregar()
        Try
            If txtcodprod.Text.Length = 0 Then
                msj_advert("Seleccione un Producto")
                Return
            ElseIf txtcantidad.Text.Length = 0 Then
                msj_advert("Ingrese una Cantidad")
                Return
            ElseIf CDec(txtcantidad.Text) = 0 Then
                msj_advert("Por Favor Ingrese la Cantidad")
                txtcantidad.Select()
                Return
            ElseIf txtcantidad.Text = 0 Then
                msj_advert("Por Favor Ingrese la Cantidad")
                txtcantidad.Select()
                Return
            ElseIf txtprecio.Text.Trim.Length = 0 Then
                msj_advert("Por Favor Ingrese el Precio")
                txtprecio.Focus()
                Return
            ElseIf CDec(txtprecio.Text) <= 0 Then
                msj_advert("El Precio de Venta no puede Tener el valor menor a 0")
                txtprecio.Focus()
                Return
            Else
                ' Validar que el idProducto no esté ya registrado en el DataTable
                Dim existingRows As DataRow() = DtDetalle.Select("codprod = '" & txtcodprod.Text.Trim & "'")
                If existingRows.Length > 0 Then
                    msj_advert("El producto ya ha sido agregado. No se puede agregar el mismo producto dos veces.")
                    Return
                End If

                ' Agregar el nuevo producto al DataTable
                Dim dr As DataRow = DtDetalle.NewRow
                dr(0) = txtcodprod.Text
                dr(1) = txtproducto.Text
                dr(2) = txtpresentacion.Text
                Dim c As Double = CDbl(txtcantidad.Text.Trim).ToString(P_FormatoDecimales)
                dr(3) = c
                Dim p As Double = CDbl(txtprecio.Text).ToString(P_FormatoDecimales)
                dr(4) = p
                dr(5) = 0
                DtDetalle.Rows.Add(dr)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle
                dtgListado.DataBind()
                CalculaTotal()

                ' Limpiar los campos después de agregar el producto
                txtcodprod.Text = ""
                txtproducto.Text = ""
                txtprecio.Text = ""
                txtcantidad.Text = ""
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub CalculaTotal()
        Dim total As Decimal = 0
        If (dtgListado.Rows.Count > 0) Then

            For Each Fila As DataRow In DtDetalle.Rows
                total += CDec(Fila(3).ToString) * CDec(Fila(4).ToString)
            Next
            If (txtflete.Text.Length = 0) Then
                txtflete.Text = "0"
            End If
            total = total + txtflete.Text
            txtsubtotal.Text = Math.Round(((total) / (1.18)), P_Redondeo_Decimal).ToString(P_FormatoDecimales)
            txtigv.Text = Math.Round((total) - CDec(txtsubtotal.Text), P_Redondeo_Decimal).ToString(P_FormatoDecimales)

            txttotal.Text = (CDec(txtsubtotal.Text) + CDec(txtigv.Text)).ToString(P_FormatoDecimales)

        Else
            txtsubtotal.Text = "0.00"
            txttotal.Text = "0.00"
            txtigv.Text = "0.00"
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "Codigo"
                .Columns(0).Width = 80
                .Columns(1).Header.Caption = "Producto"
                .Columns(1).Width = 160
                .Columns(2).Header.Caption = "Presentacion"
                .Columns(2).Width = 120
                .Columns(3).Header.Caption = "Cantidad"
                .Columns(3).Width = 90
                .Columns(4).Header.Caption = "Precio"
                .Columns(4).Width = 90
                .Columns(5).Hidden = True
                .Columns(6).Header.Caption = "Eliminar"
                .Columns(6).Width = 80
                .Columns(6).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(6).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(6).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always

            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try


            If (txtcodproveedor.Text.Length = 0) Then
                msj_advert("Seleccione un Proveedor")
                Exit Sub
            ElseIf (dtgListado.Rows.Count = 0) Then
                msj_advert("Seleccione un Producto")
                Exit Sub
            Else
                If MsgBox("¿Esta Seguro de Guardar ?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                    Exit Sub
                End If
                Dim obj As New coCotizacion
                obj.Codigo = _codigo
                obj.Fpedido = Dtp_FecEmi.Value
                obj.Total = txttotal.Text
                obj.Igv = txtigv.Text
                obj.Flete = txtflete.Text
                obj.Observacion = txtobservacion.Text
                obj.Iduser = VP_IdUser
                obj.IdCondicionpago = cbxcondicionpago.Value

                obj.IdSolicitante = VP_IdUser
                obj.IdDestino = txtcodproveedor.Text
                obj.IdTipoCambio = cbxmoneda.Value
                obj.Lista_items = creacion_de_arrary()



                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_Mantenimiento(obj)
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
        Dim array_valvulas As String = ""
        If (dtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgListado.Rows.Count - 1
                If (dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtgListado.Rows(i)
                        array_valvulas = array_valvulas & .Cells(3).Value.ToString.Trim & "+" &
                            .Cells(4).Value.ToString.Replace(".", "_") & "+" &
                            .Cells(0).Value.ToString.Replace(".", "_") & "+" &
                            .Cells(5).Value.ToString.Trim & ","
                    End With
                End If
            Next
            If (dtgListado.Rows.Count = 1) Then
                array_valvulas = array_valvulas & ","
            End If
            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function
    Private Sub Dtg_Listado_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            If (e.Cell.Column.Key = "btneliminar") Then
                If dtgListado.ActiveRow IsNot Nothing Then
                    If MsgBox("¿Esta Seguro de Eliminar el Producto ?" & ChrW(13) & ChrW(13) & " Código  :" & dtgListado.ActiveRow.Cells(1).Value.ToString, MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Ok Then
                        DtDetalle.Rows.RemoveAt(dtgListado.ActiveRow.Index)
                        dtgListado.DataSource = DtDetalle
                        CalculaTotal()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtflete_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtflete.KeyPress, txtcantidad.KeyPress, txtcantidad.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub txtflete_ValueChanged(sender As Object, e As EventArgs) Handles txtflete.ValueChanged
        If (txtflete.Text.Length <> 0) Then
            CalculaTotal()
        End If
    End Sub

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtprecio.KeyPress, txtcantidad.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub btnagregar_Click(sender As Object, e As EventArgs) Handles btnagregar.Click
        Agregar()
    End Sub

    Private Sub btnbuscarpoveedor_Click(sender As Object, e As EventArgs) Handles btnbuscarpoveedor.Click
        Dim f As New FrmBuscarProveedorIngreso
        f.ShowDialog()
        If (f.codproveedor <> 0) Then
            txtcodproveedor.Text = f.codproveedor
            txtproveedor.Text = f.razonsocial
            f.codproveedor = 0
        Else
            txtcodproveedor.Clear()
            txtproveedor.Clear()
        End If
    End Sub

    Private Sub btnbuscarproducto_Click(sender As Object, e As EventArgs) Handles btnbuscarproducto.Click
        BuscarProducto()
    End Sub
End Class