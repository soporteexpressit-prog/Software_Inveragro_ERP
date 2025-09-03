Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmPedidoVenta
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
            With cbxmoneda
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With

            indice_tabla = 1
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Seleccione una Condicion de Pago"
            With cbxcondicionpago
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With

            indice_tabla = 2
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Seleccione un Motivo de Transacción"
            With cbxmotivotransaccion
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With

            indice_tabla = 3
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Seleccione el Tipo de Documento"
            With cbxtipodocumento
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With

            clsBasicas.ListarAlmacenesAsignados(cbxalmacen_origen)
            clsBasicas.ListarAlmacenesAsignados(cbxalmacendestino)
            'indice_tabla = 4
            'ds.Tables(indice_tabla).Columns(1).ColumnName = "Seleccione el Almacen"
            'With cbxalmacen_origen
            '    .DataSource = ds.Tables(indice_tabla)
            '    .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
            '    .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
            '    If (ds.Tables(indice_tabla).Rows.Count > 0) Then
            '        .Value = ds.Tables(indice_tabla).Rows(0)(0)
            '    End If
            'End With

            'indice_tabla = 4
            'With cbxalmacendestino
            '    .DataSource = ds.Tables(indice_tabla)
            '    .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
            '    .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
            '    If (ds.Tables(indice_tabla).Rows.Count > 0) Then
            '        .Value = ds.Tables(indice_tabla).Rows(0)(0)
            '    End If
            'End With
            clsBasicas.ListarVendedores(cbxvendedor)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Size = New Size(752, 813)
            ListarTablas()
            dtfecharececpcion.Value = Now.Date
            dtfechaemision.Value = Now.Date
            dtpedido.Value = Now.Date
            CargarTablaDetalle()
            btnbuscarpoveedor.Select()
            cbxtipoprecio.SelectedIndex = 0
            clsBasicas.Formato_Tablas_Grid(dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub BuscarProducto()
        Dim f As New FrmBuscarProductosVentas()
        f._codalmacendestino = cbxalmacen_origen.SelectedValue
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
            dr(7) = 0.0
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

            ' Verifica si el campo txtflete está vacío y lo establece en 0 si es necesario
            If String.IsNullOrWhiteSpace(txtflete.Text) Then
                txtflete.Text = "0"
            End If

            ' Suma el flete al total
            Dim flete As Decimal = 0
            Decimal.TryParse(txtflete.Text, flete)
            total += flete

            ' Calcula el subtotal y el IGV
            Dim subtotal As Decimal = Math.Round(total / 1.18D, P_Redondeo_Decimal)
            Dim igv As Decimal = Math.Round(total - subtotal, P_Redondeo_Decimal)

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
                .Columns(7).Header.VisiblePosition = 5
                .Columns(7).Header.Caption = "Peso"

            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Esta Seguro de Registrar el Pedido de Venta?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If
            If dtpedido.Value > dtfecharececpcion.Value Then
                msj_advert("La fecha 'Pedido' debe ser anterior o igual a la fecha 'Recepción'.")
                Return
            End If
            If MsgBox("¿Esta Seguro de Guardar el Pedido de Venta?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If

            If (txtcodproveedor.Text.Length = 0) Then
                msj_advert("Seleccione un Cliente")
                Return
            ElseIf (dtgListado.Rows.Count = 0) Then
                msj_advert("Seleccione un Producto")
                Return
            ElseIf (txttc.TextLength = 0) Then
                msj_advert("Ingrese un Tipo de Cambio")
                Return
            ElseIf CDec(txttc.Text) = 0 Then
                msj_advert("Ingrese un Tipo de Cambio Válido")
                Return
            Else
                Dim obj As New coVentas
                obj.Codigo = _codigo
                obj.Serie = txtserie.Text
                obj.Correlativo = txtcorrelativo.Text
                obj.FEmision = dtfechaemision.Value
                obj.Fpedido = dtpedido.Value
                obj.Total = txttotal.Text
                obj.Igv = txtigv.Text
                obj.Flete = IIf(txtflete.Text.Length = 0, "0", txtflete.Text)
                obj.Observacion = txtobservacion.Text
                obj.Estado = "ACTIVO"
                obj.Iduser = cbxvendedor.SelectedValue
                obj.IdCondicionpago = cbxcondicionpago.Value
                obj.IdMotivoTransaccion = cbxmotivotransaccion.Value
                obj.Frecepcion = dtfecharececpcion.Value
                obj.IdUbicacionOrigen = cbxalmacen_origen.SelectedValue
                obj.IdUbicacionDestino = cbxalmacendestino.SelectedValue
                obj.Idmoneda = cbxmoneda.Value
                obj.Tipocambio = txttc.Text
                If (txtcodcotizacion.Text.Length = 0) Then
                    obj.Idcotizacion = 0
                Else
                    obj.Idcotizacion = txtcodcotizacion.Text
                End If
                obj.Lista_items = creacion_de_arrary()
                obj.Idtipodocumento = cbxtipodocumento.Value
                obj.Idproveedor = txtcodproveedor.Text
                obj.EstadoRecepcion = IIf(ckrecepcionado.Checked, "SI", "NO")
                obj.Idguia = _idguia
                obj.Tipoprecio = cbxtipoprecio.Text
                Dim MensajeBgWk As String = ""

                If Not String.IsNullOrEmpty(txtArchivoRuta.Text) Then
                    Dim fileInfo As New FileInfo(txtArchivoRuta.Text)
                    If fileInfo.Length > 400 * 1024 Then
                        msj_advert("El archivo excede el tamaño máximo permitido de 400 kB.")
                        Return
                    End If
                    Dim pdfData As Byte() = File.ReadAllBytes(txtArchivoRuta.Text)
                    obj.SetArchivo(pdfData)
                End If

                MensajeBgWk = cn.Cn_RegPedidoVenta(obj)
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
        DtDetalle.Columns.Add("peso", GetType(Decimal))
        dtgListado.DataSource = DtDetalle
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

    Private Sub cbxmotivotransaccion_ValueChanged(sender As Object, e As EventArgs) Handles cbxmotivotransaccion.ValueChanged
        Try
            If (cbxmotivotransaccion.Value = 1) Then
                btnvercotizacion.Visible = True
            Else
                btnvercotizacion.Visible = False
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxmoneda_ValueChanged(sender As Object, e As EventArgs) Handles cbxmoneda.ValueChanged
        Try
            If (cbxmoneda.Value = 1) Then
                txttc.ReadOnly = True
                txttc.Text = 1
            Else
                txttc.ReadOnly = False
                txttc.Text = cbxmoneda.ActiveRow.Cells(2).Value.ToString
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxagregar_Click(sender As Object, e As EventArgs) Handles cbxagregar.Click
        Agregar()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        txtcodcotizacion.Clear()
    End Sub

    Private Sub btnbuscarpoveedor_Click(sender As Object, e As EventArgs) Handles btnbuscarpoveedor.Click
        Dim f As New FrmBuscarClientes()
        f.ShowDialog()
        If (f.codproveedor <> 0) Then
            txtcodproveedor.Text = f.codproveedor
            txtproveedor.Text = f.razonsocial
            txtdireccion.Text = f.direccion
            f.codproveedor = 0
        Else
            txtcodproveedor.Clear()
            txtproveedor.Clear()
            txtdireccion.Clear()
        End If
        btnbuscarproducto.Select()
    End Sub

    Private Sub btnbuscarproducto_Click(sender As Object, e As EventArgs) Handles btnbuscarproducto.Click
        BuscarProducto()
    End Sub

    Private Sub btnvercotizacion_Click(sender As Object, e As EventArgs) Handles btnvercotizacion.Click
        If (txtcodproveedor.Text.Length = 0) Then
            msj_advert("Seleccione un Proveedor")

        Else
            Dim f As New FrmBuscarCotizacion
            f.codproveedor = txtcodproveedor.Text

            f.ShowDialog()
            If (f.codcotizacion <> 0) Then
                txtcodcotizacion.Text = f.codcotizacion
                cbxcondicionpago.Value = f.codcondicionpago
                cbxmoneda.Value = f.codmoneda

                DtDetalle.Clear()
                ' Filtrar la DataTable
                Dim filtro As String = String.Format("idPedidoCotizacion = {0}", f.codcotizacion)
                Dim filasFiltradas As DataRow() = f.dtdetalle_coti.Select(filtro)

                ' Recorrer los registros filtrados
                For Each fila As DataRow In filasFiltradas

                    Dim dr As DataRow = DtDetalle.NewRow
                    dr(0) = Convert.ToInt32(fila("idProducto"))
                    dr(1) = fila("Producto").ToString()
                    dr(2) = fila("Unidad").ToString()
                    Dim c As Double
                    c = Convert.ToDecimal(fila("cantidad")).ToString(P_FormatoDecimales)
                    dr(3) = c
                    Dim p As Double
                    p = Convert.ToDecimal(fila("precio")).ToString(P_FormatoDecimales)
                    dr(4) = p
                    dr(5) = 0
                    DtDetalle.Rows.Add(dr)


                Next
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle
                dtgListado.DataBind()
                CalculaTotal()
            End If
        End If
    End Sub

    Private Sub cbxcondicionpago_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles cbxcondicionpago.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Width = 200
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxmoneda_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles cbxmoneda.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnarchivoadjunto_Click(sender As Object, e As EventArgs) Handles btnarchivoadjunto.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Archivos PDF|*.pdf|Todos los archivos|*.*"
        openFileDialog.Title = "Selecciona un archivo PDF"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = openFileDialog.FileName
            txtArchivoRuta.Text = selectedFilePath
        End If
    End Sub

    Private Sub txttc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttc.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub
End Class