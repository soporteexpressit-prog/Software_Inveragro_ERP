Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmFacturacion
    Dim cn As New cnVentas
    Public _codordencompra As String
    Public _codigo As Integer = 0
    Public _IGV As Integer = 0

    Private DtDetalle As New DataTable
    Private DtDetalle2 As New DataTable
    Sub ListarTablas()
        Try
            Dim ds As New DataSet
            ds = cn.Cn_ListarTablasMaestrasFacturacion().Copy
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
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(805, 710)
        ListarTablas()
        dtfechaemision.Value = Now.Date
        dtpedido.Value = Now.Date
        'CargarTablaDetalle()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Formato_Tablas_Grid(dtgdetalleventa)
        If (_codordencompra <> 0) Then
            ConsultarPedidoVenta()
            ConsultarPedidoVentageneral()
        End If
        cbxtipodocumento.Select()
    End Sub

    Sub ConsultarPedidoVenta()
        Dim obj As New coVentas
        Dim cn As New cnVentas
        obj.codigolista = _codordencompra
        Dim ds As New DataSet
        ds = cn.Cn_ConsultarPedidoVentaparaFacturacionxCodigolista(obj).Copy
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
            cbxmotivotransaccion.Value = row(10)
            ' Llenar el DataGrid con los detalles
            dtgdetalleventa.DataSource = DtDetalle
        Else
            ' Si no hay datos, dejar los campos vacíos o con valores predeterminados
            dtgdetalleventa.DataSource = Nothing
        End If
    End Sub

    Sub ConsultarPedidoVentageneral()
        Dim obj As New coVentas
        Dim cn As New cnVentas
        obj.codigolista = _codordencompra
        Dim ds As New DataSet
        ds = cn.Cn_ConsultarPedidoVentaparaFacturacionxCodigolistageneral(obj).Copy
        DtDetalle2 = ds.Tables(0).Copy

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0) ' Tomar la primera fila
            dtgListado.DataSource = DtDetalle2
        Else
            dtgListado.DataSource = Nothing
        End If
        CalculaTotal()
    End Sub

    Sub CalculaTotal()
        ' 1) Lista para almacenar cada subtotal de fila ya redondeado
        Dim subtotales As New List(Of Decimal)

        ' 2) Recorremos filas y calculamos subtotalFila (redondeado a 2 decimales)
        For Each Fila As DataRow In DtDetalle.Rows
            Dim pu As Decimal = 0
            Dim cantidad As Decimal = 0
            Dim factor As Decimal = 1

            Decimal.TryParse(Fila(3).ToString(), pu)
            Decimal.TryParse(Fila(7).ToString(), cantidad)
            Decimal.TryParse(Fila(4).ToString(), factor)

            Dim subtotalFila As Decimal =
            Math.Round(pu * cantidad * factor, 2, MidpointRounding.AwayFromZero)

            subtotales.Add(subtotalFila)
        Next

        ' 3) Sumamos todos los subtotales (ya no redondeamos aquí)
        Dim totalSinFlete As Decimal = subtotales.Sum()

        ' 4) Leemos y redondeamos el flete
        Dim flete As Decimal = 0
        If Not Decimal.TryParse(txtflete.Text, flete) Then flete = 0
        flete = Math.Round(flete, 2, MidpointRounding.AwayFromZero)

        ' 5) Total antes de impuestos
        Dim subtotalFinal As Decimal = totalSinFlete + flete

        ' 6) Calculamos IGV (18%) y lo redondeamos a 2 decimales
        Dim igv As Decimal = 0
        If _IGV <> 0 Then
            igv = Math.Round(subtotalFinal * 0.18D, 2, MidpointRounding.AwayFromZero)
        End If

        ' 7) Total final
        Dim totalFinal As Decimal = subtotalFinal + igv

        ' 8) Mostramos (aquí solo formateamos la salida, NO volvemos a Math.Round)
        txtsubtotal.Text = subtotalFinal.ToString("0.00")
        txtigv.Text = igv.ToString("0.00")
        txttotal.Text = totalFinal.ToString("0.00")
    End Sub



    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout, dtgdetalleventa.InitializeLayout
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
                .Columns(6).Hidden = True
                .Columns(7).Header.Caption = "Peso"
                .Columns(7).Header.VisiblePosition = 7
                '.Columns(6).Header.Caption = "Eliminar"
                '.Columns(6).Width = 80
                '.Columns(6).Style = UltraWinGrid.ColumnStyle.Button
                '.Columns(6).CellButtonAppearance.Image = My.Resources.ico_eliminar
                '.Columns(6).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always

            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert("Seleccione un Producto")
                Return
            ElseIf (txtserie.TextLength = 0) Then
                msj_advert("Ingrese una Serie")
                Return
            ElseIf (txtcorrelativo.TextLength = 0) Then
                msj_advert("Ingrese un Correlativo")
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
                obj.Iduser = VP_IdUser
                obj.IdCondicionpago = cbxcondicionpago.Value
                obj.IdMotivoTransaccion = cbxmotivotransaccion.Value
                obj.Frecepcion = dtpedido.Value
                obj.IdUbicacionOrigen = cbxalmacen_origen.SelectedValue
                obj.IdUbicacionDestino = cbxalmacendestino.SelectedValue
                obj.Idmoneda = cbxmoneda.Value
                obj.Tipocambio = txttc.Text
                obj.Idcotizacionlista = _codordencompra
                obj.Lista_items = creacion_de_arrary()
                obj.Idtipodocumento = cbxtipodocumento.Value
                obj.Idproveedor = txtcodproveedor.Text
                obj.EstadoRecepcion = "SI"
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_RegVenta(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    _codordencompra = ""
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
        If (dtgdetalleventa.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgdetalleventa.Rows.Count - 1
                If (dtgdetalleventa.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtgdetalleventa.Rows(i)
                        array_valvulas = array_valvulas & .Cells(3).Value.ToString & "+" &
                            .Cells(4).Value.ToString & "+" &
                            .Cells(0).Value.ToString & "+" &
                            .Cells(5).Value.ToString.Trim & ","
                    End With
                End If
            Next
            If (dtgdetalleventa.Rows.Count = 1) Then
                array_valvulas = array_valvulas & ","
            End If
            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

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

    Private Sub cbxmoneda_ValueChanged(sender As Object, e As EventArgs)
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


    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        txtcodcotizacion.Clear()
    End Sub

    Private Sub btnbuscarpoveedor_Click(sender As Object, e As EventArgs)
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


    Sub ConsultarArchivo(codigo As Integer)

        Dim obj As New coVentas
        obj.Codigo = codigo
        cn.Cn_ObtenerArchivoPedidoVenta(obj)


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

    Private Sub cbxtipodocumento_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs)
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
End Class