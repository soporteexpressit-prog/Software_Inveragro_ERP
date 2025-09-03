Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmOrdendeCompra
    Dim cn As New cnIngreso
    Dim cnProducto As New cnProducto
    Public _codigo As Integer = 0
    Public categoria As String = ""
    ' Declarar estas variables a nivel de clase
    Private cantidadOriginal As Decimal = 0
    Private cantidadSolicitadaOriginal As Decimal = 0


    Sub ListarTablas()
        Try
            Dim ds As New DataSet
            ds = cn.Cn_ListarTablasMaestrasCompra().Copy
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

            cbxalmacen_origen.SelectedValue = P_IdAlmacenPrincipal
            cbxalmacendestino.SelectedValue = P_IdAlmacenPrincipal
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarTablas()
        dtfecharececpcion.Value = Now.Date
        dtfechaemision.Value = Now.Date
        dtpedido.Value = Now.Date
        cbxflete.SelectedIndex = 0
        CargarTablaDetalle()
        InicializarUnidadMedidaPorDefecto()
        btnbuscarpoveedor.Select()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub InicializarUnidadMedidaPorDefecto()
        Try
            Dim tb As New DataTable("temp")
            tb.Columns.Add("codigo", GetType(Integer))
            tb.Columns.Add("Seleccione Unidad de Medida", GetType(String))

            Dim newRow As DataRow = tb.NewRow()
            newRow(0) = 0
            newRow(1) = "SELECCIONA EL PRODUCTO"
            tb.Rows.Add(newRow)

            With cbUnidadMedida
                .DataSource = tb
                .DisplayMember = "Seleccione Unidad de Medida"
                .ValueMember = "codigo"
                .Value = 0
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub ActualizarConversion()
        Try
            If cbUnidadMedida.Rows.Count = 0 OrElse cbUnidadMedida.Value Is Nothing Then
                txtcantsolicitada.Text = ""
                Return
            End If

            ' Solo convertir si los valores originales son mayores a 0
            If cantidadOriginal = 0 And cantidadSolicitadaOriginal = 0 Then
                Return
            End If

            Dim row As UltraWinGrid.UltraGridRow = cbUnidadMedida.ActiveRow
            If row Is Nothing Then
                txtcantsolicitada.Text = ""
                Return
            End If

            Dim factor As Decimal = 1
            Decimal.TryParse(row.Cells(2).Value.ToString(), factor)

            If factor = 1 Then
                txtcantidad.Text = cantidadOriginal.ToString("N2")
                txtcantsolicitada.Text = cantidadSolicitadaOriginal.ToString("N2")
            Else
                Dim resultado As Decimal = cantidadOriginal / factor
                txtcantidad.Text = resultado.ToString("N2")
                txtcantsolicitada.Text = (cantidadSolicitadaOriginal / factor).ToString("N2")
            End If

        Catch ex As Exception
            txtcantsolicitada.Text = ""
        End Try
    End Sub


    Sub ListarUnidadMedidaPorProducto(ByVal idProducto As Integer)
        Try
            Dim obj As New coProductos With {
                .Idproducto = idProducto
            }
            Dim tb As New DataTable
            tb = cnProducto.Cn_ListarUnidadesMedidaPorProducto(obj)
            tb.TableName = "temp"
            tb.Columns(1).ColumnName = "Seleccione Unidad de Medida"

            If tb.Rows.Count = 0 Then
                Dim newRow As DataRow = tb.NewRow()
                newRow(0) = 0
                newRow(1) = "SIN UNIDAD DE MEDIDA"
                newRow(2) = "0"
                tb.Rows.Add(newRow)
            End If

            With cbUnidadMedida
                .DataSource = tb
                .DisplayMember = tb.Columns(1).ColumnName
                .ValueMember = tb.Columns(0).ColumnName
                If (tb.Rows.Count > 0) Then
                    .Value = tb.Rows(0)(0)
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub BuscarProducto()
        Dim f As New FrmBuscarProductoPedidoOrdenCompra()
        f._codalmacendestino = cbxalmacendestino.SelectedValue
        If checkservicios.Checked Then
            f.servicio = 1
        Else
            f.servicio = 0
        End If
        f.ShowDialog()
        If (f.codproducto <> 0) Then
            txtcodprod.Text = f.codproducto
            txtproducto.Text = f.descripcion
            cbUnidadMedida.Text = f.unidadmedida
            txtcantidad.Text = f.cantidad
            txtcantsolicitada.Text = f.cantidad
            categoria = f.categoria
            f.codproducto = 0
            ' Asignar valores originales ANTES de cargar unidades de medida
            Decimal.TryParse(f.cantidad, cantidadOriginal)
            Decimal.TryParse(f.cantidad, cantidadSolicitadaOriginal)
            txtcantidad.Select()
            ListarUnidadMedidaPorProducto(txtcodprod.Text.Trim)
        End If

        If categoria = "GENÉTICA" Then
            cbxalmacendestino.SelectedValue = 2
        Else
            cbxalmacendestino.SelectedValue = P_IdAlmacenPrincipal
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
        DtDetalle.Columns.Add("idconversion", GetType(Integer))
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
            End If
            Dim cantidad As Decimal
            If Not Decimal.TryParse(txtcantidad.Text.Trim, cantidad) Then
                msj_advert("Por Favor Ingrese la Cantidad")
                txtcantidad.Focus()
                Return
            End If

            Dim precioDecimal As Decimal
            If Not Decimal.TryParse(txtprecio.Text.Trim, precioDecimal) Then
                msj_advert("Por Favor Ingrese el Precio")
                txtprecio.Focus()
                Return
            End If

            'If txtprecio.Text.Trim.Length = 0 Then
            '        txtprecio.Focus()
            '        Return
            '    ElseIf CDec(txtprecio.Text) <= 0 Then
            '        msj_advert("El Precio de Venta no puede Tener el valor menor a 0")
            '    txtprecio.Focus()
            '    Return
            'End If
            If CDec(txtcantidad.Text) > CDec(txtcantsolicitada.Text) Then
                msj_advert("La Cantidad ingresada no puede ser mayor a la Cantidad Solicitada")
                txtcantidad.Focus()
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
            dr(2) = cbUnidadMedida.Text
            Dim c As Double = CDbl(txtcantidad.Text.Trim).ToString(P_FormatoDecimales)
            dr(3) = c
            Dim p As Double = CDbl(txtprecio.Text).ToString(P_FormatoDecimales5)
            dr(4) = p
            dr(5) = 0
            dr(7) = cbUnidadMedida.Value
            DtDetalle.Rows.Add(dr)
            DtDetalle.AcceptChanges()

            ' Actualiza el DataGridView o Listado
            dtgListado.DataSource = DtDetalle
            dtgListado.DataBind()
            CalculaTotal()

            ' Limpiar los campos
            txtcodprod.Text = ""
            txtproducto.Text = ""
            cbUnidadMedida.Text = ""
            txtprecio.Text = ""
            txtcantidad.Text = ""
            txtcantsolicitada.Text = ""
            btnbuscarproducto.Select()
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

        ' Verificar si hay filas en DtDetalle
        If DtDetalle.Rows.Count > 0 Then
            ' Sumar total de los productos (precio * cantidad)
            For Each Fila As DataRow In DtDetalle.Rows
                Dim precio As Decimal
                Dim cantidad As Decimal

                ' Validar y convertir valores
                Decimal.TryParse(Fila(3).ToString(), precio)
                Decimal.TryParse(Fila(4).ToString(), cantidad)

                total += precio * cantidad
            Next
        End If

        ' Validar y convertir el valor del flete
        If Not Decimal.TryParse(txtflete.Text, flete) Then
            flete = 0
            txtflete.Text = "0.00"
        End If

        ' Calcular el subtotal incluyendo el flete
        subtotal = total + flete

        ' Aplicar lógica según el estado del CheckBox
        If ckigv.Checked Then
            ' Caso "CON IGV": El subtotal ya incluye IGV
            igv = Math.Round(subtotal * IGV_TASA, P_Redondeo_Decimal3)
            subtotal = Math.Round(subtotal, P_Redondeo_Decimal3)
            total = Math.Round(subtotal + igv, P_Redondeo_Decimal3)
        Else
            ' Caso "SIN IGV": Se calcula el IGV y se suma al total
            igv = 0
            total = Math.Round(subtotal + igv, P_Redondeo_Decimal3)
        End If

        ' Asignar valores a los campos de texto con el formato adecuado
        txtsubtotal.Text = subtotal.ToString(P_FormatoDecimales)
        txtigv.Text = igv.ToString(P_FormatoDecimales)
        txttotal.Text = total.ToString(P_FormatoDecimales)
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
                .Columns(6).Header.Caption = "Eliminar"
                .Columns(6).Width = 80
                .Columns(6).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(6).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(6).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns(7).Hidden = True

            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            ' Validación de fecha de pedido mayor a hoy
            If dtpedido.Value > Date.Today Then
                If MsgBox("La fecha 'Pedido' es mayor a la fecha actual. ¿Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Advertencia") = MsgBoxResult.No Then
                    Return
                End If
            End If
            If txtobservacion.Text.Trim = "" Then
                msj_advert("Ingrese una Observación")
                txtobservacion.Select()
                Return
            End If
            If dtpedido.Value > dtfecharececpcion.Value Then
                msj_advert("La fecha 'Pedido' debe ser anterior o igual a la fecha 'Recepción'.")
                Return
            End If
            If MsgBox("¿Esta Seguro de Guardar la Orden de Compra?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If

            If (txtcodproveedor.Text.Length = 0) Then
                msj_advert("Seleccione un Proveedor")
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
                Dim obj As New coIngreso
                obj.Codigo = _codigo
                obj.Serie = txtserie.Text
                obj.Correlativo = txtcorrelativo.Text
                obj.FEmision = dtfechaemision.Value
                obj.Fpedido = dtpedido.Value
                obj.Total = txttotal.Text
                obj.Igv = txtigv.Text
                obj.Flete = IIf(txtflete.Text.Length = 0, "0", txtflete.Text)
                obj.Fleteinterno = IIf(txtfleteinterno.Text.Length = 0, "0", txtfleteinterno.Text)
                obj.Observacion = txtobservacion.Text
                obj.Estado = "ACTIVO"
                obj.Iduser = VP_IdUser
                obj.IdCondicionpago = cbxcondicionpago.Value
                obj.IdMotivoTransaccion = cbxmotivotransaccion.Value
                obj.Frecepcion = dtfecharececpcion.Value
                obj.IdUbicacionOrigen = cbxalmacen_origen.SelectedValue
                obj.IdUbicacionDestino = cbxalmacendestino.SelectedValue
                obj.Idmoneda = cbxmoneda.Value
                obj.Tipocambio = txttc.Text
                obj.Conigv = IIf(ckigv.Checked, "SI", "NO")
                If (txtcodcotizacion.Text.Length = 0) Then
                    obj.Idcotizacion = 0
                Else
                    obj.Idcotizacion = txtcodcotizacion.Text
                End If
                obj.Lista_items = creacion_de_arrary()
                obj.Idtipodocumento = cbxtipodocumento.Value
                obj.Idproveedor = txtcodproveedor.Text
                obj.EstadoRecepcion = IIf(ckrecepcionado.Checked, "SI", "NO")
                obj.pagoanticipado = IIf(checkpagoanticipado.Checked, "SI", "NO")
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

                MensajeBgWk = cn.Cn_RegOrdenCompra(obj)
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
                        .Cells(4).Value.ToString & "+" &
                        .Cells(0).Value.ToString & "+" &
                        .Cells(5).Value.ToString.Trim & "+" &
                        .Cells(7).Value.ToString.Trim & "," ' <-- Aquí agregas la unidad de medida (ID)
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
    Private Sub txtflete_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtflete.KeyPress, txtcantidad.KeyPress
        clsBasicas.ValidarNumerosDecimalessin_coma(e)
    End Sub

    Private Sub txtflete_ValueChanged(sender As Object, e As EventArgs) Handles txtflete.ValueChanged
        If (txtflete.Text.Length <> 0) Then
            CalculaTotal()
        End If
    End Sub

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        clsBasicas.ValidarNumerosDecimalessin_coma(e)
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
                txttc.Text = 1
            Else
                txttc.Text = cbxmoneda.ActiveRow.Cells(2).Value.ToString
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        txtcodcotizacion.Clear()
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



    Private Sub txttc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttc.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub btnbuscarpoveedor_Click_1(sender As Object, e As EventArgs) Handles btnbuscarpoveedor.Click
        Dim f As New FrmBuscarProveedorIngreso()
        f.ShowDialog()
        If (f.codproveedor <> 0) Then
            txtcodproveedor.Text = f.codproveedor
            txtproveedor.Text = f.razonsocial
            f.codproveedor = 0
        Else
            txtcodproveedor.Clear()
            txtproveedor.Clear()
        End If
        btnbuscarproducto.Select()
    End Sub

    Private Sub btnarchivoadjunto_Click_1(sender As Object, e As EventArgs) Handles btnarchivoadjunto.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Archivos PDF|*.pdf|Todos los archivos|*.*"
        openFileDialog.Title = "Selecciona un archivo PDF"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = openFileDialog.FileName
            txtArchivoRuta.Text = selectedFilePath
        End If
    End Sub

    Private Sub btnbuscarproducto_Click_1(sender As Object, e As EventArgs) Handles btnbuscarproducto.Click
        BuscarProducto()
    End Sub

    Private Sub cbxagregar_Click_1(sender As Object, e As EventArgs) Handles cbxagregar.Click
        Agregar()
    End Sub

    Private Sub ckigv_CheckedChanged(sender As Object, e As EventArgs) Handles ckigv.CheckedChanged
        CalculaTotal()
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

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles checkservicios.CheckedChanged
        If checkservicios.Checked Then
            GroupBox1.Text = "Detalles de Servicios"
            Me.Text = "NUEVA ORDEN DE COMPRA - SERVICIOS"
        Else
            GroupBox1.Text = "Detalles de Productos"
            Me.Text = "NUEVA ORDEN DE COMPRA"
        End If
    End Sub
    Private Sub cbUnidadMedida_ValueChanged(sender As Object, e As EventArgs) Handles cbUnidadMedida.ValueChanged
        ActualizarConversion()
    End Sub

End Class