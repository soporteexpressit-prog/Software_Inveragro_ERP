Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmPedidoVentaDirecta
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


            indice_tabla = 4
            For Each row As DataRow In ds.Tables(indice_tabla).Rows
                txtcodcliente.Text = row("idpersona").ToString()
                txtcliente.Text = row("datos").ToString()
                txtdireccion.Text = row("direccion").ToString()
            Next


            clsBasicas.ListarAlmacenesAsignados(cbxalmacen_origen)
            clsBasicas.ListarAlmacenesAsignados(cbxalmacendestino)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        Try

            Dim obj As New coVentas
            obj.Iduser = cbxalmacen_origen.SelectedValue
            obj.Idproducto = If(String.IsNullOrEmpty(txtproducto.AccessibleDescription), 0, txtproducto.AccessibleDescription)
            Dim tb As New DataTable
            dtglistapedidos.DataSource = cn.Cn_Consultarxproductoyvendedor(obj).Copy
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Size = New Size(755, 686)
            ListarTablas()
            dtfecharececpcion.Value = Now.Date
            dtfechaemision.Value = Now.Date
            dtpedido.Value = Now.Date
            CargarTablaDetalle()
            btnbuscarpoveedor.Select()
            cbxtipoprecio.SelectedIndex = 0
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            clsBasicas.Formato_Tablas_Grid(dtglistapedidos)
            stockdisponible.Enabled = False
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub cbxmotivotransaccion_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs)
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(2).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub BuscarProducto()
        Dim f As New FrmBuscarProductoparaVentas()
        f._idalmacen = cbxalmacen_origen.SelectedValue
        f.ShowDialog()
        If (f.codproducto <> 0) Then
            txtproducto.AccessibleDescription = f.codproducto
            txtproducto.Text = f.descripcion
            txtstock.Text = f.stokdisponible
            f.codproducto = 0
            txtcantidad.Select()
        End If
        Consultar()
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
            If txtproducto.AccessibleDescription.Length = 0 Then
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
            If CDec(txtcantidad.Text) > CDec(stockdisponible.Text) Then
                msj_advert("La Cantidad no puede ser Mayor a la del Stock Disponible")
                txtcantidad.Select()
                Return
            End If

            ' Verificación de código de producto repetido
            For Each row As DataRow In DtDetalle.Rows
                If row("codprod").ToString() = txtproducto.AccessibleDescription.Trim() Then
                    msj_advert("El Producto ya ha sido agregado.")
                    Return
                End If
            Next

            ' Si pasa las validaciones, se agrega el nuevo producto
            Dim dr As DataRow = DtDetalle.NewRow
            dr(0) = txtproducto.AccessibleDescription
            dr(1) = txtproducto.Text
            dr(2) = ""
            Dim c As Double = CDbl(txtcantidad.Text.Trim).ToString(P_FormatoDecimales)
            dr(3) = c
            Dim p As Double = 1
            dr(4) = p
            dr(5) = 0
            DtDetalle.Rows.Add(dr)
            DtDetalle.AcceptChanges()

            ' Actualiza el DataGridView o Listado
            dtgListado.DataSource = DtDetalle
            dtgListado.DataBind()

            ' Limpiar los campos
            txtproducto.AccessibleDescription = ""
            txtproducto.Text = ""

            txtcantidad.Text = ""
            txtstock.Text = ""
            btnbuscarproducto.Select()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub dtglistapedidos_AfterRowActivate(sender As Object, e As EventArgs) Handles dtglistapedidos.AfterRowActivate
        Try
            Dim row = dtglistapedidos.ActiveRow
            If row IsNot Nothing AndAlso Not row.IsFilteredOut Then
                Dim stock1 As Object = row.Cells(3).Value
                stockdisponible.Text = If(stock1 IsNot Nothing, stock1.ToString(), "0")
            End If
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
                .Columns(2).Header.Caption = "Presentacion"
                .Columns(2).Hidden = True
                .Columns(2).Width = 120
                .Columns(3).Header.Caption = "Cantidad"
                .Columns(3).Width = 90
                .Columns(4).Header.Caption = "Precio"
                .Columns(4).Hidden = True
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
            Else
                Dim obj As New coVentas
                obj.Codigo = 0
                obj.FEmision = dtpedido.Value
                obj.Observacion = txtobservacion.Text
                obj.Iduser = VP_IdUser
                obj.IdUbicacionOrigen = cbxalmacen_origen.SelectedValue
                obj.IdUbicacionDestino = cbxalmacendestino.SelectedValue
                obj.Lista_items = creacion_de_arrary()
                obj.Idproveedor = txtcodcliente.Text
                obj.Idguia = _idguia
                obj.IdMotivoTransaccion = dtglistapedidos.ActiveRow.Cells(0).Value.ToString
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_RegPedidoVentaDirecta(obj)
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
                array_valvulas.AppendFormat("{0}+{1}+{2},",
                                        row.Cells(3).Value.ToString().Trim(),
                                        row.Cells(4).Value.ToString(),
                                        row.Cells(0).Value.ToString())
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

    Private Sub txtprecio_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        clsBasicas.ValidarNumerosDecimales(e)
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

    Private Sub btnvercotizacion_Click(sender As Object, e As EventArgs) Handles btnvercotizacion.Click
        If (txtcodcliente.Text.Length = 0) Then
            msj_advert("Seleccione un Proveedor")

        Else
            Dim f As New FrmBuscarCotizacion
            f.codproveedor = txtcodcliente.Text

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
        clsBasicas.ValidarNumerosDecimales(e)
    End Sub

    Private Sub dtglistapedidos_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtglistapedidos.InitializeLayout

    End Sub
End Class