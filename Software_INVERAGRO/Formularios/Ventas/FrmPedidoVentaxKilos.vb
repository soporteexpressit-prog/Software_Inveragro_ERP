Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmPedidoVentaxKilos
    Dim cn As New cnVentas
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

            Dim tb1 As New DataTable
            tb1 = cn.Cn_ConsultarPesoKilos(_codigo)

            ' Formatear los valores a 2 decimales antes de asignarlos al TextBox
            txtpesogranja.Text = Convert.ToDecimal(tb1.Rows(0)(0)).ToString("F2")
            txtsaldo.Text = Convert.ToDecimal(tb1.Rows(0)(1)).ToString("F2")

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarTablas()
            dtfechaemision.Value = Now.Date
            dtpedido.Value = Now.Date
            btnbuscarpoveedor.Select()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub CalculaTotal()
        Dim total As Decimal = 0
        If (txtcantidad.Text.Length = 0) Then
            Return
        End If
        If (txtprecio.Text.Length = 0) Then
            Return
        End If
        If (txtcantidad.Text.Length > 0) Then
            total = CDec(txtcantidad.Text) * CDec(txtprecio.Text)
            txtsubtotal.Text = Math.Round(((total)), P_Redondeo_Decimal).ToString(P_FormatoDecimales)
            txtigv.Text = Math.Round((0))

            txttotal.Text = (CDec(txtsubtotal.Text) + CDec(txtigv.Text)).ToString(P_FormatoDecimales)

        Else
            txtsubtotal.Text = "0.00"
            txttotal.Text = "0.00"
            txtigv.Text = "0.00"
        End If
    End Sub

    Private DtDetalle As New DataTable("TempDetProd")


    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Esta Seguro de Registrar la Venta por Kilos?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If

            If (ckconsumo.Checked = False) Then
                If (txtcantidad.TextLength = 0) Then
                    msj_advert("Ingrese un Cantidad")
                    Return
                ElseIf CDec(txtcantidad.Text) = 0 Then
                    msj_advert("Ingrese una Cantidad Válida")
                    Return
                ElseIf (txtprecio.TextLength = 0) Then
                    msj_advert("Ingrese un Precio de Venta")
                    Return
                ElseIf CDec(txtcantidad.Text) > CDec(txtsaldo.Text) Then
                    msj_advert("La Cantidad de Kilos Ingresada supera el Saldo de Kilos que se tiene del Cerdo")
                Return
            End If
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
            Else
                Dim obj As New coVentas
                obj.Codigo = _codigo
                obj.Serie = ""
                obj.Correlativo = ""
                obj.FEmision = dtfechaemision.Value
                obj.Fpedido = dtpedido.Value
                obj.Total = txttotal.Text
                obj.Igv = txtigv.Text
                obj.Flete = 0
                obj.Observacion = txtobservacion.Text
                obj.Estado = "ACTIVO"
                obj.Iduser = VP_IdUser
                obj.IdCondicionpago = 1
                obj.IdMotivoTransaccion = If(ckconsumo.Checked, 41, 40)
                obj.Frecepcion = dtfechaemision.Value
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
                obj.Precio = txtprecio.Text
                obj.Cantidad = txtcantidad.Text
                'ElseIf cbxmotivotransaccion.Value = 30 Or cbxmotivotransaccion.Value = 31 Then
                'obj.EstadoRecepcion = "SI"
                'End If

                obj.Idguia = 0
                obj.Tipoprecio = If(ckconsumo.Checked, "CONSUMO INTERNO", "VENTA POR KILOS")
                obj.Idplantel = 0
                Dim MensajeBgWk As String = ""

                MensajeBgWk = cn.Cn_RegPedidoVentaxKilos(obj)
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
                                        0,
                                        "212",
"0")

        ' Elimina la última coma si es necesario
        If array_valvulas.Length > 0 Then
            array_valvulas.Length -= 1
        End If

        Return array_valvulas.ToString()
    End Function


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

    Private Sub txtprecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprecio.KeyPress, txtcantidad.KeyPress
        Try
            clsBasicas.ValidarNumerosDecimalessin_coma(e)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub txtprecio_TextChanged(sender As Object, e As EventArgs) Handles txtprecio.TextChanged, txtcantidad.TextChanged
        Try
            CalculaTotal()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ckconsumo_CheckedChanged(sender As Object, e As EventArgs) Handles ckconsumo.CheckedChanged
        If (ckconsumo.Checked) Then
            txtprecio.Text = 0
            txtcantidad.Text = txtsaldo.Text
            txtprecio.ReadOnly = True
            txtcantidad.ReadOnly = True
        Else
            txtprecio.Text = ""
            txtcantidad.Text = ""
            txtprecio.ReadOnly = False
            txtcantidad.ReadOnly = False
        End If
    End Sub

End Class