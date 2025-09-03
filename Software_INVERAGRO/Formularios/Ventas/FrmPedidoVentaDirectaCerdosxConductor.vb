Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmPedidoVentaDirectaCerdosxConductor
    Dim cn As New cnVentas
    Public _idguia As Integer = 0
    Public _codigo As Integer = 0
    Dim tbtmpplanteles As New DataTable
    Dim DvPlanteles As DataView
    Sub ListarTablas()
        Try
            Dim ds As New DataSet
            ds = cn.Cn_ListarTablasMaestrasPedidoVentaCerdo().Copy
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


            indice_tabla = 3
            For Each row As DataRow In ds.Tables(indice_tabla).Rows
                txtcodcliente.Text = row("idpersona").ToString()
                txtcliente.Text = row("datos").ToString()
                txtdireccion.Text = row("direccion").ToString()
            Next

            ListarPedidosCerdosxGuia()
            clsBasicas.ListarVendedores(cbxvendedor)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub ListarPedidosCerdosxGuia()
        Try
            ' Inicializar conexión y obtener datos
            Dim cn As New cnProducto
            tbtmpplanteles = cn.Cn_ListarPedidosCerdos_x_guia(_idguia).Copy

            With cbxpedidoreferencia
                .DataSource = tbtmpplanteles
                .DisplayMember = tbtmpplanteles.Columns(1).ColumnName ' Nombre de la columna a mostrar
                .ValueMember = tbtmpplanteles.Columns(0).ColumnName   ' Nombre de la columna del valor
                If tbtmpplanteles.Rows.Count > 0 Then
                    .Value = tbtmpplanteles.Rows(0)(0) ' Seleccionar el primer valor
                End If
            End With

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        Finally
        End Try
    End Sub


    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Size = New Size(716, 496)
            ListarTablas()
            dtfecharececpcion.Value = Now.Date
            dtfechaemision.Value = Now.Date
            dtpedido.Value = Now.Date
            btnbuscarpoveedor.Select()
            cbxtipoprecio.SelectedIndex = 0
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private DtDetalle As New DataTable("TempDetProd")


    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Esta Seguro de Registrar la Venta por Conductor?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If
            If dtpedido.Value > dtfecharececpcion.Value Then
                msj_advert("La fecha 'Pedido' debe ser anterior o igual a la fecha 'Recepción'.")
                Return
            End If
            If MsgBox("¿Esta Seguro de Guardar el Pedido de Venta?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If

            If (txtcodcliente.Text.Length = 0) Then
                msj_advert("Seleccione un Cliente")
                Return

            ElseIf (txttc.TextLength = 0) Then
                msj_advert("Ingrese un Tipo de Cambio")
                Return
            ElseIf CDec(txttc.Text) = 0 Then
                msj_advert("Ingrese un Tipo de Cambio Válido")
                Return
            ElseIf (txtcantidad.TextLength = 0) Then
                msj_advert("Ingrese un Cantidad")
                Return
            ElseIf CDec(txtcantidad.Text) = 0 Then
                msj_advert("Ingrese una Cantidad Válida")
                Return
            ElseIf CDec(txtcantidad.Text) > CDec(txtstock.Text) Then
                msj_advert("No cuenta con Stock Disponible para la Cantidad Indicada")
                Return
            Else
                Dim obj As New coVentas
                obj.Codigo = cbxpedidoreferencia.Value
                obj.Serie = ""
                obj.Correlativo = ""
                obj.FEmision = dtfechaemision.Value
                obj.Fpedido = dtpedido.Value
                obj.Total = txttotal.Text
                obj.Igv = txtigv.Text
                obj.Flete = 0
                obj.Observacion = txtobservacion.Text
                obj.Estado = "ACTIVO"
                obj.Iduser = cbxvendedor.SelectedValue
                obj.IdCondicionpago = 1
                obj.IdMotivoTransaccion = 22
                obj.Frecepcion = dtfecharececpcion.Value
                obj.IdUbicacionOrigen = 6
                obj.IdUbicacionDestino = 6
                obj.Idmoneda = cbxmoneda.Value
                obj.Tipocambio = txttc.Text
                obj.Idcotizacion = 0
                obj.Lista_items = creacion_de_arrary()
                obj.Idtipodocumento = 1
                obj.Idproveedor = txtcodcliente.Text
                'If cbxmotivotransaccion.Value = 29 Then
                obj.EstadoRecepcion = "SI"
                'ElseIf cbxmotivotransaccion.Value = 30 Or cbxmotivotransaccion.Value = 31 Then
                'obj.EstadoRecepcion = "SI"
                'End If

                obj.Idguia = _idguia
                obj.Tipoprecio = cbxtipoprecio.Text
                obj.Idplantel = 0
                Dim MensajeBgWk As String = ""

                MensajeBgWk = cn.Cn_RegPedidoVentaCerdoxConductor(obj)
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
        array_valvulas.AppendFormat("{0}+{1}+{2}+{3},",
                                        txtcantidad.Text,
                                        txtprecio.Text,
                                        "212",
"0")

        ' Elimina la última coma si es necesario
        If array_valvulas.Length > 0 Then
            array_valvulas.Length -= 1
        End If

        Return array_valvulas.ToString()
    End Function

    Private Sub txtflete_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
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

    Private Sub txtprecio_ValueChanged(sender As Object, e As EventArgs) Handles txtprecio.ValueChanged
        CalcularSubtotalTotalEIGV()
    End Sub

    Private Sub txtcantidad_ValueChanged(sender As Object, e As EventArgs) Handles txtcantidad.ValueChanged
        CalcularSubtotalTotalEIGV()
    End Sub

    ' Método para calcular el subtotal, total e IGV
    Private Sub CalcularSubtotalTotalEIGV()
        Try
            ' Obtener los valores de precio y cantidad
            Dim precio As Decimal = If(IsNumeric(txtprecio.Text), CDec(txtprecio.Text), 0)
            Dim cantidad As Decimal = If(IsNumeric(txtcantidad.Text), CDec(txtcantidad.Text), 0)

            ' Calcular el total
            Dim total As Decimal = precio * cantidad

            ' Calcular el subtotal (sin IGV)
            Dim subtotal As Decimal = Math.Round(total / 1.18D, 2)

            ' Calcular el IGV
            Dim igv As Decimal = Math.Round(total - subtotal, 2)

            ' Mostrar los resultados en los TextBox correspondientes
            txttotal.Text = total.ToString("N2")    ' Total redondeado a 2 decimales
            txtsubtotal.Text = subtotal.ToString("N2") ' Subtotal redondeado a 2 decimales
            txtigv.Text = igv.ToString("N2")        ' IGV redondeado a 2 decimales
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al calcular el subtotal, total y el IGV: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprecio.KeyPress
        clsBasicas.ValidarNumerosDecimales(e)
    End Sub

    Private Sub cbxpedidoreferencia_ValueChanged(sender As Object, e As EventArgs) Handles cbxpedidoreferencia.ValueChanged
        Try
            ' Validar que el objeto ActiveRow no sea Nothing
            If cbxpedidoreferencia.ActiveRow IsNot Nothing AndAlso
           cbxpedidoreferencia.ActiveRow.Cells IsNot Nothing AndAlso
           cbxpedidoreferencia.ActiveRow.Cells.Count > 2 Then

                ' Si la fila activa y las celdas son válidas, asignar el valor
                txtstock.Text = cbxpedidoreferencia.ActiveRow.Cells(2).Value.ToString()
            Else
                ' Si no es válido, establecer un valor predeterminado
                txtstock.Text = "0"
            End If
        Catch ex As Exception
            ' Manejar cualquier excepción
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub cbxpedidoreferencia_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles cbxpedidoreferencia.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "Codigo Pedido"
                .Columns(1).Header.Caption = "Cliente"
                .Columns(2).Header.Caption = "Cantidad"

                .Columns(0).Width = 90
                .Columns(1).Width = 150
                .Columns(2).Width = 100
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class