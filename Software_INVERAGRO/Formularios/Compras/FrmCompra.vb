Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinEditors

Public Class FrmCompra
    Dim cn As New cnIngreso
    Dim cn2 As New cnCtaPagar
    Public _codordencompra As Integer = 0
    Public _codigo As Integer = 0
    Public porfacturar As Decimal = 0
    Private dtgFacturar As New DataTable("Facturas")
    Private DtDetalle As New DataTable
    Private porFacturarOriginal As Decimal = 0
    Dim dt As DataTable
    Dim ds As New DataSet
    Dim importetotaloriginal As Decimal = 0
    Dim importenuevototal As Decimal = 0
    Dim importeajustado As Decimal = 0

    Sub ListarTablas2()
        Try
            ds = cn2.Cn_ListarTablasMaestrasNotacredito().Copy
            ds.DataSetName = "tmp"
            Dim indice_tabla As Integer = 0
            ' Cargar Forma de Pago
            indice_tabla += 1
            Dim dv As New DataView(ds.Tables(indice_tabla))


            ' Cargar Tipo de Documento
            indice_tabla += 1
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Seleccione el Tipo de Documento"
            With cbxtipodocoriginal
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
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(805, 710)
        ListarTablas()
        ListarTablas2()
        dtfechaemision.Value = Now.Date
        dtpedido.Value = Now.Date
        'CargarTablaDetalle()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Formato_Tablas_Grid(dtgfacturas)
        If (_codordencompra <> 0) Then
            ConsultarOrdenCompra()
            InicializarTablaFacturas()
        End If
        cbxtipodocumento.Select()
        CbxCulminarOrden.Checked = False
        cbxagregar.Enabled = False
        dtgListado.DisplayLayout.Bands(0).Columns(6).Hidden = Not CbxCulminarOrden.Checked
    End Sub
    Private Sub CbxCulminarOrden_CheckedChanged(sender As Object, e As EventArgs) Handles CbxCulminarOrden.CheckedChanged
        cbxagregar.Enabled = CbxCulminarOrden.Checked

        ' Mostrar u ocultar la columna "Elegir Precio" (índice 6)
        If dtgListado.DisplayLayout.Bands.Count > 0 AndAlso dtgListado.DisplayLayout.Bands(0).Columns.Count > 6 Then
            dtgListado.DisplayLayout.Bands(0).Columns(6).Hidden = Not CbxCulminarOrden.Checked
        End If
    End Sub
    Sub ConsultarOrdenCompra()
        Dim obj As New coIngreso
        Dim cn As New cnIngreso
        obj.Codigo = _codordencompra
        Dim ds As New DataSet
        ds = cn.Cn_ConsultarOrdendeCompraxCodigo(obj).Copy
        DtDetalle = ds.Tables(1).Copy

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0) ' Tomar la primera fila

            ' Llenar los campos del formulario con los valores de la fila

            dtpedido.Value = Convert.ToDateTime(row(1))
            txtcodproveedor.Text = row(2)
            txtproveedor.Text = row(3)
            cbxalmacendestino.SelectedValue = row(4)
            cbxcondicionpago.Value = row(5)
            cbxmoneda.Value = row(6)
            txtobservacion.Text = row(7)
            txttc.Text = row(8)
            If (row(9) = "SI") Then
                ckigv.Checked = True
            Else
                ckigv.Checked = False
            End If
            If row(12) = 0 Then
                txtflete.Text = row(12)
            Else
                txtflete.Text = row(13)
            End If
            importetotaloriginal = row(10)


            dtgListado.DataSource = DtDetalle
        Else
            ' Si no hay datos, dejar los campos vacíos o con valores predeterminados
            dtgListado.DataSource = Nothing
        End If
        CalculaTotal()
    End Sub

    Private Sub InicializarTablaFacturas()
        dtgFacturar = New DataTable("Facturas")
        dtgFacturar.Columns.Add("Serie", GetType(String))
        dtgFacturar.Columns.Add("Correlativo", GetType(String))
        dtgFacturar.Columns.Add("Fecha", GetType(Date))
        dtgFacturar.Columns.Add("Importe", GetType(Decimal))
        dtgFacturar.Columns.Add("Eliminar", GetType(String))
        dtgFacturar.AcceptChanges()
        dtgfacturas.DataSource = dtgFacturar
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
        txtporfacturar.Text = total.ToString(P_FormatoDecimales)
        porFacturarOriginal = total.ToString(P_FormatoDecimales)
        importe.Text = total.ToString("N2")
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
                .Columns(5).Hidden = True ' Oculta solo la columna 5

                ' Configura la columna 6 como botón
                .Columns(6).Header.Caption = "Elegir Precio"
                .Columns(6).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                .Columns(6).ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                .Columns(6).Width = 100

            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Esta Seguro de Registrar la Compra?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If
            If (dtgListado.Rows.Count = 0) Then
                msj_advert("Seleccione un Producto")
                Return
            ElseIf (dtgfacturas.Rows.Count = 0) Then
                msj_advert("Ingrese una factura")
                Return
            Else
                Dim obj As New coIngreso
                obj.Codigo = _codigo
                obj.FEmision = dtpedido.Value
                obj.Fpedido = dtpedido.Value
                obj.Total = txttotal.Text
                obj.Igv = txtigv.Text
                obj.Flete = IIf(txtflete.Text.Length = 0, "0", txtflete.Text)
                obj.Observacion = txtobservacion.Text
                obj.Estado = "ACTIVO"
                obj.Iduser = VP_IdUser
                obj.IdCondicionpago = cbxcondicionpago.Value
                obj.Frecepcion = dtpedido.Value
                obj.IdUbicacionOrigen = cbxalmacen_origen.SelectedValue
                obj.IdUbicacionDestino = cbxalmacendestino.SelectedValue
                obj.Idmoneda = cbxmoneda.Value
                obj.Tipocambio = txttc.Text
                obj.Idcotizacion = _codordencompra
                obj.Lista_items = creacion_de_arrary()
                obj.Idtipodocumento = cbxtipodocumento.Value
                obj.Idproveedor = txtcodproveedor.Text
                obj.EstadoRecepcion = "SI"
                obj.listafacturas = CrearListaFacturas()
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_RegCompra(obj)
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
                        array_valvulas = array_valvulas & .Cells(3).Value.ToString & "+" &
                            .Cells(4).Value.ToString & "+" &
                            .Cells(0).Value.ToString & "+" &
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
    Private Sub Dtg_Listado_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs)
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
    Private Sub txtflete_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtflete.KeyPress
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

    Private Sub cbxmoneda_ValueChanged(sender As Object, e As EventArgs) Handles cbxmoneda.ValueChanged
        Try
            If (cbxmoneda.Value = 1) Then
                txttc.ReadOnly = True
                txttc.Text = 1
            Else
                txttc.ReadOnly = False
                If cbxmoneda.ActiveRow IsNot Nothing AndAlso cbxmoneda.ActiveRow.Cells.Count > 2 AndAlso cbxmoneda.ActiveRow.Cells(2).Value IsNot Nothing Then
                    txttc.Text = cbxmoneda.ActiveRow.Cells(2).Value.ToString()
                Else
                    txttc.Text = "" ' O asigna algún valor por defecto
                End If
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        txtcodcotizacion.Clear()
    End Sub

    Private Sub btnbuscarpoveedor_Click(sender As Object, e As EventArgs) Handles btnbuscarpoveedor.Click
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
                Dim filasFiltradas() As DataRow = f.dtdetalle_coti.Select(filtro)

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
    Sub ConsultarArchivo(codigo As Integer)

        Dim obj As New coIngreso
        obj.Codigo = codigo
        cn.Cn_ConsultarOrdenesComprasArchivoCotizacion(obj)


        Dim pdfData As Byte() = obj.ArchivoRecepcion
        If pdfData IsNot Nothing AndAlso pdfData.Length > 0 Then
            Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "doccotizacion_compra" & codigo.ToString & ".pdf")

            File.WriteAllBytes(tempFilePath, pdfData)
            Process.Start(tempFilePath)
        Else
            MessageBox.Show("No se encontró el archivo PDF en la base de datos.")
        End If
    End Sub
    Private Sub btnvercotizacion_Click_1(sender As Object, e As EventArgs) Handles btnvercotizacion.Click
        Try
            ConsultarArchivo(_codordencompra)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cbxtipodocumento_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles cbxtipodocumento.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(2).Hidden = True
                .Columns(3).Hidden = True
                .Columns(4).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim f As New FrmTipoDocumento
            f.ShowDialog()
            ListarTablas()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            Dim obj As New coIngreso
            Dim cn As New cnIngreso
            obj.Codigo = _codordencompra
            Dim ds As New DataSet
            ds = cn.Cn_ReporteOrdendeCompraxCodigo(obj).Copy
            ds.DataSetName = "bd"
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_OrdenCompra.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(ds)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgfacturas_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgfacturas.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns("Eliminar").Header.Caption = "Eliminar"
                .Columns("Eliminar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                .Columns("Eliminar").ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                .Columns("Eliminar").CellButtonAppearance.Image = My.Resources.ico_eliminar ' Usa tu recurso de imagen
                .Columns("Eliminar").Width = 80
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub dtgfacturas_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgfacturas.ClickCellButton
        If e.Cell.Column.Key = "Eliminar" Then
            If e.Cell.Row.Index >= 0 Then
                If MsgBox("¿Está seguro de eliminar la factura seleccionada?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Ok Then
                    dtgFacturar.Rows.RemoveAt(e.Cell.Row.Index)
                    dtgFacturar.AcceptChanges()
                    ActualizarTotalesFacturas()
                End If
            End If
        End If
    End Sub


    Private Sub btnagregarfactura_Click(sender As Object, e As EventArgs) Handles btnagregarfactura.Click
        ' Validaciones
        If String.IsNullOrWhiteSpace(txtserie.Text) Then
            msj_advert("Ingrese la serie.")
            txtserie.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtcorrelativo.Text) Then
            msj_advert("Ingrese el correlativo.")
            txtcorrelativo.Focus()
            Return
        End If
        If Not IsNumeric(importe.Text) OrElse CDec(importe.Text) < 0 Then
            msj_advert("Ingrese un importe válido.")
            importe.Focus()
            Return
        End If

        ' Validar que no se repita serie y correlativo
        Dim existeFactura = dtgFacturar.Select($"Serie = '{txtserie.Text.Trim.Replace("'", "''")}' AND Correlativo = '{txtcorrelativo.Text.Trim.Replace("'", "''")}'")
        If existeFactura.Length > 0 Then
            msj_advert("Ya existe una factura con la misma serie y correlativo.")
            txtserie.Focus()
            Return
        End If

        ' Validar que el importe no supere el por facturar
        Dim totalFacturado As Decimal = 0
        For Each row As DataRow In dtgFacturar.Rows
            totalFacturado += CDec(row("Importe"))
        Next
        Dim importeNuevo As Decimal = CDec(importe.Text)
        Dim porFacturarActual As Decimal = 0
        Decimal.TryParse(txtporfacturar.Text, porFacturarActual)
        Dim nuevoTotalFacturado As Decimal = totalFacturado + importeNuevo
        Dim nuevoPorFacturar As Decimal = porFacturarActual - importeNuevo

        If nuevoPorFacturar < 0 Then
            msj_advert("El importe ingresado excede el importe pendiente de la orden de compra. Corrija el importe.")
            importe.Focus()
            Return
        End If

        ' Agregar fila
        Dim dr As DataRow = dtgFacturar.NewRow()
        dr("Serie") = txtserie.Text.Trim()
        dr("Correlativo") = txtcorrelativo.Text.Trim()
        dr("Fecha") = dtpedido.Value
        dr("Importe") = importeNuevo
        dr("Eliminar") = "Eliminar"
        dtgFacturar.Rows.Add(dr)
        dtgFacturar.AcceptChanges()

        ' Actualizar totales
        ActualizarTotalesFacturas()

        ' Limpiar campos
        txtserie.Clear()
        txtcorrelativo.Clear()
        importe.Clear()
    End Sub


    Private Sub ActualizarTotalesFacturas()
        Dim totalFacturado As Decimal = 0
        For Each row As DataRow In dtgFacturar.Rows
            totalFacturado += CDec(row("Importe"))
        Next
        lbtotalfacturado.Text = totalFacturado.ToString("N2")

        ' Siempre calcula a partir del valor original
        txtporfacturar.Text = (porFacturarOriginal - totalFacturado).ToString("N2")
    End Sub

    Private Sub importe_TextChanged(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles importe.KeyPress
        clsBasicas.ValidarNumerosDecimalessin_coma(e)
    End Sub

    Function CrearListaFacturas() As String
        Dim lista As New System.Text.StringBuilder()
        For Each row As DataRow In dtgFacturar.Rows
            Dim serie As String = row("Serie").ToString().Trim()
            Dim correlativo As String = row("Correlativo").ToString().Trim()
            Dim fecha As String = CDate(row("Fecha")).ToString("yyyy-MM-dd")
            Dim importe As String = CDec(row("Importe")).ToString("F2")
            lista.Append($"{serie}+{correlativo}+{fecha}+{importe},")
        Next
        If lista.Length > 0 Then
            lista.Length -= 1 ' Quitar la última coma
        End If
        Return lista.ToString()
    End Function

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CbxCulminarOrden.CheckedChanged
        If CbxCulminarOrden.Checked Then
            cbxagregar.Enabled = True
        Else
            cbxagregar.Enabled = False
            txtcodprod.Clear()
            txtproducto.Clear()
            txtunidadmedida.Clear()
            txtcantidad.Clear()
            txtprecio.Clear()
        End If
    End Sub



    Private Sub dtgordenoriginal_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            If e.Cell.Column.Index = 6 Then ' Columna 6: Botón "Elegir Precio"
                Dim precio As Object = e.Cell.Row.Cells(4).Value ' Columna 4: Precio
                txtcodprod.Text = e.Cell.Row.Cells(0).Value ' Columna 4: Precio
                txtproducto.Text = e.Cell.Row.Cells(1).Value ' Columna 4: Precio
                txtunidadmedida.Text = e.Cell.Row.Cells(2).Value ' Columna 4: Precio
                txtcantidad.Text = e.Cell.Row.Cells(3).Value ' Columna 4: Precio
                If precio IsNot Nothing Then
                    txtprecio.Text = precio.ToString()
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxagregar_Click(sender As Object, e As EventArgs) Handles cbxagregar.Click
        Try
            ' Validar que haya un producto seleccionado
            If String.IsNullOrWhiteSpace(txtcodprod.Text) Then
                msj_advert("Seleccione un producto para actualizar.")
                Return
            End If

            ' Validar que el precio sea numérico y mayor o igual a cero
            Dim nuevoPrecio As Decimal
            If Not Decimal.TryParse(txtprecio.Text, nuevoPrecio) OrElse nuevoPrecio < 0 Then
                msj_advert("Ingrese un precio válido.")
                txtprecio.Focus()
                Return
            End If

            ' Validar que la cantidad sea numérica y mayor a cero
            Dim nuevaCantidad As Decimal
            If Not Decimal.TryParse(txtcantidad.Text, nuevaCantidad) OrElse nuevaCantidad < 0 Then
                msj_advert("Ingrese una cantidad válida.")
                txtprecio.Focus()
                Return
            End If

            ' Buscar la fila en DtDetalle por el código de producto y actualizar cantidad y precio
            For Each row As DataRow In DtDetalle.Rows
                If row(0).ToString() = txtcodprod.Text Then
                    row(3) = nuevaCantidad ' Columna 3: Cantidad
                    row(4) = nuevoPrecio   ' Columna 4: Precio
                    Exit For
                End If
            Next

            ' Refrescar la grilla
            dtgListado.DataSource = Nothing
            dtgListado.DataSource = DtDetalle
            dtgListado.DataBind()

            CalculaTotal()
            ' Limpiar los campos
            txtcodprod.Clear()
            txtproducto.Clear()
            txtunidadmedida.Clear()
            txtcantidad.Clear()
            txtprecio.Clear()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub



End Class