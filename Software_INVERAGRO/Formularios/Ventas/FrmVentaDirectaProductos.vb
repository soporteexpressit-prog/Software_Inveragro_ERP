Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmVentaDirectaProductos
    Dim cn As New cnVentas
    Public _idguia As Integer = 0
    Public _codigo As Integer = 0

    Sub ListarTablas()
        Try


            Dim ds As New DataSet
            ds = cn.Cn_ListarTablasMaestrasPedidoVenta().Copy
            ds.DataSetName = "tmp"
            ds.Tables(0).Columns(1).ColumnName = "Seleccione una Moneda"

            Dim indice_tabla As Integer = 0


            indice_tabla = 4
            For Each row As DataRow In ds.Tables(indice_tabla).Rows
                txtcodcliente.Text = row("idpersona").ToString()
                txtcliente.Text = row("datos").ToString()
                txtdireccion.Text = row("direccion").ToString()
            Next
            clsBasicas.ListarVendedores(cbxvendedor)
            clsBasicas.ListarAlmacenesAsignados(cbxalmacen_origen)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtstock.ReadOnly = True
            Me.Size = New Size(796, 689)
            ListarTablas()
            dtpedido.Value = Now.Date
            CargarTablaDetalle()
            btnbuscarpoveedor.Select()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub BuscarProducto()
        Dim f As New FrmBuscarProductoparaVentas()
        f._idalmacen = cbxalmacen_origen.SelectedValue
        f.ShowDialog()
        If (f.codproducto <> 0) Then
            txtcodprod.Text = f.codproducto
            txtproducto.Text = f.descripcion
            txtpresentacion.Text = f.presentacion
            txtunidadmedida.Text = f.unidadmedida
            txtstock.Text = f.stokdisponible
            f.codproducto = 0
            txtcantidad.Select()
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
            ' Validaciones iniciales
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
                txtprecio.Select()
                Return
            End If
            Dim precioDecimal As Decimal
            If Not Decimal.TryParse(txtprecio.Text.Trim, precioDecimal) Then
                msj_advert("El valor ingresado no es un número decimal válido")
                txtprecio.Focus()
                Return
            End If
            If CDec(txtprecio.Text) <= 0 Then
                msj_advert("El Precio de Venta no puede Tener el valor menor a 0")
                txtprecio.Select()
                Return
            ElseIf CDec(txtcantidad.Text) > CDec(txtstock.Text) Then
                msj_advert("La Cantidad no puede ser Mayor a la del Stock Disponible")
                txtcantidad.Select()
                Return
            End If

            ' Verificación de código de producto repetido
            For Each row As DataRow In DtDetalle.Rows
                If row("codprod").ToString() = txtcodprod.Text.Trim() Then
                    msj_advert("El Producto ya ha sido agregado.")
                    Return
                End If
            Next

            ' Si pasa las validaciones, se agrega el nuevo producto
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

            ' Actualiza el DataGridView o Listado
            dtgListado.DataSource = DtDetalle
            dtgListado.DataBind()
            CalculaTotal()

            ' Limpiar los campos
            txtcodprod.Text = ""
            txtproducto.Text = ""
            txtpresentacion.Text = ""
            txtunidadmedida.Text = ""
            txtprecio.Text = ""
            txtcantidad.Text = ""
            txtstock.Text = ""
            btnbuscarproducto.Select()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Sub CalculaTotal()
        Dim total As Decimal = 0

        ' Verifica si hay filas en el DataTable
        If DtDetalle.Rows.Count > 0 Then
            ' Recorre las filas del DataTable y calcula el total
            For Each fila As DataRow In DtDetalle.Rows
                Dim cantidad As Decimal = 0
                Dim precio As Decimal = 0

                ' Intentamos convertir las columnas a Decimal de forma segura
                Decimal.TryParse(fila(3).ToString(), cantidad)
                Decimal.TryParse(fila(4).ToString(), precio)

                total += cantidad * precio
            Next

            ' Calcula el subtotal y el IGV
            Dim subtotal As Decimal = Math.Round(total, P_Redondeo_Decimal)
            Dim igv As Decimal = 0

            ' Asigna los valores calculados a los controles de texto
            txtsubtotal.Text = subtotal.ToString(P_FormatoDecimales)
            txtigv.Text = igv.ToString(P_FormatoDecimales)
            txttotal.Text = (subtotal + igv).ToString(P_FormatoDecimales)

        Else
            ' Si no hay filas, establece todos los totales a 0
            txtsubtotal.Text = "0.00"
            txtigv.Text = "0.00"
            txttotal.Text = "0.00"
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
            If MsgBox("¿Esta Seguro de Guardar el Pedido de Venta Directa?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If

            If (txtcodcliente.Text.Length = 0) Then
                msj_advert("Seleccione un Cliente")
                Return
            ElseIf (dtgListado.Rows.Count = 0) Then
                msj_advert("Seleccione un Producto")
                Return
                'ElseIf (txttc.TextLength = 0) Then
                '    msj_advert("Ingrese un Tipo de Cambio")
                '    Return
                'ElseIf CDec(txttc.Text) = 0 Then
                '    msj_advert("Ingrese un Tipo de Cambio Válido")
                '    Return
            Else
                Dim obj As New coVentas
                obj.Codigo = 0
                obj.Serie = ""
                obj.Correlativo = ""
                obj.FEmision = Now.Date
                obj.Fpedido = dtpedido.Value
                obj.Total = txttotal.Text
                obj.Igv = txtigv.Text
                obj.Observacion = txtobservacion.Text
                obj.Estado = "ACTIVO"
                obj.Iduser = cbxvendedor.SelectedValue
                obj.IdCondicionpago = 1
                obj.IdMotivoTransaccion = 5
                obj.Frecepcion = Now.Date
                obj.IdUbicacionOrigen = cbxalmacen_origen.SelectedValue
                obj.IdUbicacionDestino = cbxalmacendestino.SelectedValue
                obj.Idmoneda = 1
                obj.Tipocambio = 1
                obj.Idcotizacion = 0
                obj.Lista_items = creacion_de_arrary()
                obj.Idtipodocumento = 14
                obj.Idproveedor = txtcodcliente.Text
                obj.EstadoRecepcion = "SI"
                obj.Idguia = 0
                obj.Tipoprecio = "NORMAL"
                Dim MensajeBgWk As String = ""


                MensajeBgWk = cn.Cn_RegPedidoVentaProductos(obj)
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

            ' Verifica si la celda en la columna 0 tiene un valor no vacío
            If Not String.IsNullOrWhiteSpace(row.Cells(0).Value?.ToString()) Then
                array_valvulas.AppendFormat("{0}+{1}+{2}+{3},",
                                        row.Cells(3).Value.ToString().Trim(),
                                        row.Cells(4).Value.ToString(),
                                        row.Cells(0).Value.ToString(),
                                        row.Cells(5).Value.ToString().Trim())
            End If
        Next

        ' Elimina la última coma si es necesario
        If array_valvulas.Length > 0 Then
            array_valvulas.Length -= 1
        End If

        Return array_valvulas.ToString()
    End Function


    Private Sub Dtg_Listado_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            ' Verifica si la columna es "btneliminar"
            If e.Cell.Column.Key = "btneliminar" Then
                Dim activeRow = dtgListado.ActiveRow

                ' Verifica si hay una fila activa
                If activeRow IsNot Nothing Then
                    Dim codigoProducto As String = activeRow.Cells(1).Value?.ToString()

                    ' Confirmación para eliminar el producto
                    Dim mensaje As String = $"¿Está seguro de eliminar el producto?{vbCrLf}{vbCrLf}Código: {codigoProducto}"
                    If MsgBox(mensaje, MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Ok Then
                        ' Elimina la fila del DataTable
                        DtDetalle.Rows.RemoveAt(activeRow.Index)

                        ' Actualiza el DataGridView
                        dtgListado.DataSource = DtDetalle

                        ' Recalcula el total después de la eliminación
                        CalculaTotal()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub txtflete_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress, txtcantidad.KeyPress
        clsBasicas.ValidarNumerosDecimales(e)
    End Sub


    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtprecio.KeyPress, txtcantidad.KeyPress
        clsBasicas.ValidarNumerosDecimales(e)
    End Sub

    Private Sub cbxagregar_Click(sender As Object, e As EventArgs) Handles cbxagregar.Click
        Agregar()
    End Sub

    Private Sub btnbuscarpoveedor_Click(sender As Object, e As EventArgs) Handles btnbuscarpoveedor.Click
        Dim f As New FrmBuscarClientes()
        f.ShowDialog()
        If (f.codproveedor <> 0) Then
            txtcodcliente.Text = f.codproveedor
            txtcliente.Text = f.razonsocial
            txtdireccion.Text = f.direccion
            f.codproveedor = 0
        Else
            txtcodcliente.Clear()
            txtcliente.Clear()
            txtdireccion.Clear()
        End If
        btnbuscarproducto.Select()
    End Sub

    Private Sub btnbuscarproducto_Click(sender As Object, e As EventArgs) Handles btnbuscarproducto.Click
        BuscarProducto()
    End Sub


End Class