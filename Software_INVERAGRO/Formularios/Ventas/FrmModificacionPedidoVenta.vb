Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmModificacionPedidoVenta

    Dim cn As New cnVentas
    Public _codordencompra As Integer = 0
    Public _codigo As Integer = 0
    Dim preciosacos As Decimal = 0
    Dim pdescuento As Decimal = 0
    Dim totalOriginal As Decimal = 0D  ' Total original sin descuento
    Dim descuento As Decimal = 0D
    Dim valorGuardado As Decimal = 0D  ' Valor original guardado
    Dim totalConDescuento As Decimal = 0D
    Private DtDetalle As New DataTable
    Dim conteoCerdos As Integer = 0
    Dim totalCerdosActual As Integer = 0
    Sub ListarTablas()
        Try
            Dim ds As New DataSet
            ds = cn.Cn_ListarTablasMaestrasFacturacion().Copy
            ds.DataSetName = "tmp"
            ds.Tables(0).Columns(1).ColumnName = "Seleccione una Moneda"

            Dim indice_tabla As Integer = 0
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
            indice_tabla = 5
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Seleccione un Tipo de Peso Final"
            With cbxtipopesofinal
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
        'PANEL DE PESO GANCHO, MUEVELO A LA IZQUIERDA Y NO PERDERAS TIEMPO XD
        clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListado)
        ListarTablas()
        'CargarTablaDetalle()
        If (_codordencompra <> 0) Then
            ConsultarPedidoVenta()
        End If
        ' Inicializar la tabla
        InicializarTabla()
    End Sub

    Sub ConsultarPedidoVenta()
        Dim obj As New coVentas
        Dim cn As New cnVentas
        obj.Codigo = _codordencompra
        Dim ds As New DataSet
        ds = cn.Cn_ConsultarPedidoVentaxCodigo(obj).Copy
        DtDetalle = ds.Tables(1).Copy

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0) ' Tomar la primera fila

            ' Llenar los campos del formulario con los valores de la fila
            txtcodproveedor.Text = row(2)
            txtproveedor.Text = row(3)
            txtobservacion.Text = row(7)
            cbxmotivotransaccion.Value = row(10)

            txtcantidad.Text = CInt(ds.Tables(1).Rows(0)(3).ToString)
            If ds IsNot Nothing AndAlso ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 1 Then
                Dim valor As Object = ds.Tables(1).Rows(1)(3)
                If valor IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(valor.ToString()) Then
                    txtcantidadalimento.Text = CInt(valor).ToString()
                Else
                    ' Si el valor es nulo o vacío, asigna un valor predeterminado o deja sin asignar.
                    txtcantidadalimento.Text = "0"
                End If
            Else
                ' Manejar el caso en que la tabla o la fila no existan.
                txtcantidadalimento.Text = "0"
            End If


            txtcantidadpedido.Text = CInt(ds.Tables(1).Rows(0)(3).ToString)
            txtpesopromediogranja.Text = Math.Round(CDec(ds.Tables(1).Rows(0)(7)), 4).ToString("F2") ' Redondear a 4 decimales
            txtpesototalgranja.Text = Math.Round(CDec(txtcantidad.Text) * CDec(txtpesopromediogranja.Text), 2).ToString("F2") ' Redondeo a 4 decimales
        End If

        CalculaTotal()
    End Sub
    Private Sub RecalcularPesos()

        ' Antes de validar, normaliza los campos vacíos a "0"
        If String.IsNullOrWhiteSpace(txtpesodescuento.Text) Then
            txtpesodescuento.Text = "0"
        End If
        If String.IsNullOrWhiteSpace(txtpesototalfinal.Text) Then
            txtpesototalfinal.Text = "0"
        End If

        Decimal.TryParse(txtpesototalfinal.AccessibleDescription, valorGuardado)  ' Asumiendo que tienes un campo oculto o label con el valor original
        If valorGuardado = 0D Then
            Decimal.TryParse(txtpesototalfinal.Text, valorGuardado)
            txtpesototalfinal.AccessibleDescription = valorGuardado.ToString("F2")  ' Guardar el valor original
        End If
        Decimal.TryParse(txtpesodescuento.Text, descuento)
        If descuento = 0D Then
            txtpesototalfinal.Text = valorGuardado.ToString("F2")
        Else
            totalConDescuento = Math.Round(valorGuardado - descuento, 4)
            txtpesototalfinal.Text = totalConDescuento.ToString("F2")
        End If
        CalculaTotal()
        ' Ahora compara de forma segura
        If CDbl(txtpesodescuento.AccessibleDescription) > CDbl(txtpesototalfinal.Text) Then
            msj_advert("El peso del descuento no puede ser mayor al peso total")
            Return
        End If
    End Sub


    Sub CalculaTotal()
        Dim total As Decimal = 0
        Dim flete As Decimal = 0
        Dim subtotal As Decimal = 0
        Dim igv As Decimal = 0
        Const IGV_TASA As Decimal = 0.18 ' 18% de IGV
        If txtpesototalfinal.Text.Length = 0 Then
            txtpesototalfinal.AccessibleDescription = ""
            txtpesototalfinal.Text = ""
            valorGuardado = 0D
            descuento = 0D
            totalConDescuento = 0D
        End If
        If (String.IsNullOrEmpty(txtpesototalfinal.Text)) Then
            txtpesopromfinal.Text = "0.00"
            Return
        Else
            ' Cálculo del peso promedio final con redondeo a 4 decimales
            txtpesopromfinal.Text = Math.Round(CDec(txtpesototalfinal.Text) / CDec(txtcantidad.Text), 4).ToString("F2")

        End If
        ' Validaciones para evitar errores al calcular
        If String.IsNullOrEmpty(txtpreciofinal.Text) OrElse String.IsNullOrEmpty(txtpesototalfinal.Text) Then
            txtsubtotal.Text = "0.00"
            txtigv.Text = "0.00"
            txttotal.Text = "0.00"
            Return
        End If
        If (cbxtipopesofinal.Value = 3) Then
            txtp1.Text = Math.Round(CDec(txtpesopromfinal.Text) / 0.76, 2).ToString("F2")
            txtp2.Text = Math.Round((CDec(txtp1.Text) - CDec(txtpesopromediogranja.Text)), 2).ToString("F2")
            txtp3.Text = Math.Round(CDec(txtp2.Text) * CDec(txtpreciofinal.Text), 2).ToString("F2")
        Else
            txtp1.Text = Math.Round(CDec(txtpesototalfinal.Text) - (CDec(txtpesototalgranja.Text)), 2).ToString("F2")
            txtp2.Text = Math.Round((CDec(txtp1.Text)) / CDec(txtcantidad.Text), 2).ToString("F2")
            txtp3.Text = Math.Round(CDec(txtp2.Text) * CDec(txtpreciofinal.Text), 2).ToString("F2")

        End If

        ' Cálculo del total con redondeo a 4 decimales
        total = CDec(txtpreciofinal.Text) * CDec(txtpesototalfinal.Text) + preciosacos


        ' Aplicar lógica según el estado del CheckBox
        If ckigv.Checked Then
            ' Cálculo del subtotal e IGV con redondeo
            txtsubtotal.Text = Math.Round((total), 2).ToString("F2")
            txtigv.Text = Math.Round((total * 0.18), 2).ToString("F2")
            txttotal.Text = Math.Round(CDec(txtsubtotal.Text) + CDec(txtigv.Text), 2).ToString("F2")
        Else
            ' Cálculo del subtotal e IGV con redondeo
            txtsubtotal.Text = Math.Round((total), 2).ToString("F2")
            txtigv.Text = 0
            txttotal.Text = Math.Round(CDec(txtsubtotal.Text) + CDec(txtigv.Text), 2).ToString("F2")
        End If

    End Sub
    Private Sub ckigv_CheckedChanged(sender As Object, e As EventArgs) Handles ckigv.CheckedChanged
        CalculaTotal()
    End Sub

    Sub montototalsacos()
        ' Si alguno de los campos está vacío, no se realiza el cálculo y se sale del método.
        If String.IsNullOrWhiteSpace(txtpreciofinalalimento.Text) OrElse String.IsNullOrWhiteSpace(txtcantidadalimento.Text) Then
            Return
        End If
        Dim precio As Decimal
        Dim cantidad As Decimal
        ' Si no se pueden convertir a Decimal, salimos sin modificar nada.
        If Not Decimal.TryParse(txtpreciofinalalimento.Text, precio) OrElse Not Decimal.TryParse(txtcantidadalimento.Text, cantidad) Then
            Return
        End If
        ' Realizamos el cálculo y asignamos el resultado con formato.
        txtmontoanimalporprecio.Text = Math.Round(precio * cantidad, 4).ToString("F2")
        preciosacos = Math.Round(precio * cantidad, 4).ToString("F2")
        CalculaTotal()
    End Sub


    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (txtpesototalfinal.Text.Length = 0) Then
                msj_advert("Ingrese los Pesos Correspondientes")
                Return
            End If
            If CDec(txtpesototalfinal.Text) = 0 Then
                msj_advert("El Peso no pueder ser igual a 0")
                Return
            End If
            If txtpreciofinal.Text.Length = 0 Then
                msj_advert("Ingrese un Precio de Venta")
                Return
            ElseIf CDec(txtpreciofinal.Text) = 0 Then
                Dim result As DialogResult = MessageBox.Show("El precio ingresado es 0. ¿Desea continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If result = DialogResult.No Then
                    txtpreciofinal.Focus() ' Regresa el foco al campo de precio
                    Exit Sub ' Detiene la ejecución
                End If
            End If

            ' 2. Sumar “N° Cerdos” desde el UltraGrid
            Dim totalCerdosActual As Integer = 0
            For Each uRow As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                ' Ignorar filas de grupo o empty
                If Not uRow.IsDataRow Then Continue For

                Dim val = uRow.Cells(1).Value
                Dim n As Integer
                If val IsNot Nothing AndAlso Integer.TryParse(val.ToString(), n) Then
                    totalCerdosActual += n
                End If
            Next

            If totalCerdosActual = txtcantidadpedido.Text Then

                Dim obj As New coVentas
                obj.Codigo = _codordencompra
                obj.Idtipopeso = cbxtipopesofinal.Value
                obj.Precio = txtpreciofinal.Text
                obj.Igv = txtigv.Text
                obj.Total = txttotal.Text
                obj.Peso_promediofinal = Math.Round(CDec(txtpesototalfinal.Text) / CDec(txtcantidad.Text), 10)
                If String.IsNullOrWhiteSpace(txtpreciofinalalimento.Text) Then
                    obj.Precioalimento = 0
                Else
                    obj.Precioalimento = (Convert.ToDecimal(txtpreciofinalalimento.Text) / 50)
                End If
                obj.Observacion = txtobservacion.Text
                If String.IsNullOrWhiteSpace(txtpesodescuento.Text) Then
                    obj.pesodescontado = 0
                Else
                    obj.pesodescontado = (Convert.ToDecimal(txtpesodescuento.Text))
                End If
                obj.Lista_items = creacion_de_arrary()
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_ModificarVenta(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Dispose()
                Else
                    msj_advert(MensajeBgWk)
                End If
            Else
                msj_advert("Debe Indicar todos los Pesos de cada Cerdo")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function creacion_de_arrary() As String
        Dim array_valvulas As String = ""
        If dtgListado.Rows.Count = 0 Then
            Return "0"
        End If
        For i = 0 To dtgListado.Rows.Count - 1
            With dtgListado.Rows(i)
                Dim num As String = .Cells("num").Value.ToString().Trim()
                Dim peso As String = .Cells("peso").Value.ToString().Trim()
                Dim conteo As String = .Cells("N° Cerdos").Value.ToString().Trim()

                If num.Length > 0 Then
                    array_valvulas &= num & "+" & peso & "+" & conteo & ","
                End If
            End With
        Next
        ' Eliminar última coma si existe
        If array_valvulas.EndsWith(",") Then
            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If

        Return array_valvulas
    End Function


    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub

    Private Sub cbxtipopesofinal_ValueChanged(sender As Object, e As EventArgs) Handles cbxtipopesofinal.ValueChanged
        Try
            If (cbxtipopesofinal.Value = 3) Then
                InicializarTabla()
                btnbuscarpesos.Visible = True
                txtpesopromfinal.ReadOnly = True
                txtpesototalfinal.ReadOnly = True
                txtnumcerdos.ReadOnly = True
                txtpesototalfinal.Text = "0"
                tabla = Nothing
                dtgListado.DataSource = tabla
            Else
                InicializarTabla()
                txtnumcerdos.ReadOnly = False
                txtpesopromfinal.ReadOnly = True
                txtpesototalfinal.ReadOnly = True
                btnbuscarpesos.Visible = True
                tabla = Nothing
                dtgListado.DataSource = tabla
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub btnbuscarpesos_Click(sender As Object, e As EventArgs) Handles btnbuscarpesos.Click
        panelpesos.Visible = True
    End Sub




    Dim tabla As New DataTable()
    Private Sub Button2_Click(sender As Object, e As EventArgs)

        Try
            If (txtpesodetalle.Text.Length = 0) Then
                msj_advert("Ingrese el Peso")
                txtpesodetalle.Select()
                Return
            End If
            AgregarDatos(txtpesodetalle.Text, False)
            txtpesodetalle.Text = ""
            txtpesodetalle.Select()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Sub InicializarTabla()
        If tabla Is Nothing Then
            tabla = New DataTable()
            tabla.Columns.Add("num", GetType(Integer))
            tabla.Columns.Add("N° Cerdos", GetType(Integer))
            tabla.Columns.Add("peso", GetType(Decimal))
            tabla.Columns.Add("eliminar", GetType(String))
        End If
    End Sub

    ' Función para agregar datos a la tabla
    Sub AgregarDatos(peso As Decimal, eliminar As Boolean)
        If tabla Is Nothing Then
            InicializarTabla()
        End If

        conteoCerdos = If(IsNumeric(txtnumcerdos.Text), CInt(txtnumcerdos.Text), 1)

        ' Calcular el total actual de cerdos
        totalCerdosActual = tabla.AsEnumerable().Sum(Function(r) If(IsDBNull(r("N° Cerdos")), 0, Convert.ToInt32(r("N° Cerdos"))))

        ' Validar que no se exceda el límite
        If totalCerdosActual + conteoCerdos > CInt(txtcantidadpedido.Text) Then
            MessageBox.Show("No se pueden agregar más de " & txtcantidadpedido.Text & " cerdos.", "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Obtener número secuencial
        Dim nuevoNumero As Integer = If(tabla.Rows.Count > 0, CInt(tabla.Compute("MAX(num)", "")) + 1, 1)

        ' Crear y agregar la fila
        Dim fila As DataRow = tabla.NewRow()
        fila("num") = nuevoNumero
        fila("peso") = Math.Round(peso, 4)
        fila("N° Cerdos") = conteoCerdos
        fila("eliminar") = "" ' o True/False si es un botón
        tabla.Rows.Add(fila)

        ' Actualizar grid
        dtgListado.DataSource = tabla
        dtgListado.Refresh()

        sumarpesos()
    End Sub



    ' Función para eliminar una fila según su número
    Sub EliminarFila(num As Integer)
        For Each fila As DataRow In tabla.Rows
            If fila("num") = num Then
                fila.Delete() ' Marca la fila para eliminación
                Exit For
            End If
        Next
        tabla.AcceptChanges() ' Aplica la eliminación
        sumarpesos()
    End Sub
    Sub sumarpesos()
        Dim p As Decimal = 0
        For Each fila As DataRow In tabla.Rows
            If Not IsDBNull(fila("peso")) AndAlso IsNumeric(fila("peso")) Then
                p += Convert.ToDecimal(fila("peso"))
            End If
        Next
        txtpesototalfinal.Text = p.ToString("F4")
        txtpesototal2.Text = p.ToString("F4")
        txtpesopromfinal.Text = (p / CInt(txtcantidadpedido.Text)).ToString("F4")
        txtpesopromedio2.Text = (p / CInt(txtcantidadpedido.Text)).ToString("F4")
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "eliminar" Then
            Dim numEliminar As Integer = CInt(e.Cell.Row.Cells("num").Value)
            EliminarFila(numEliminar)
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout_1(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "N°"
                .Columns(1).Header.Caption = "N° Cerdos"
                .Columns(2).Header.Caption = "Peso"
                .Columns(3).Header.Caption = "Eliminar"
                .Columns(3).Width = 80
                .Columns(3).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(3).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(3).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always

            End With
            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 0)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 1)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 2)
            ' Desplazamiento horizontal


        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub txtpreciofinal_ValueChanged(sender As Object, e As EventArgs) Handles txtpreciofinal.ValueChanged, txtpesototalfinal.ValueChanged
        CalculaTotal()
    End Sub
    Private Sub txtpreciofinalalimento_TextChanged(sender As Object, e As EventArgs) Handles txtpreciofinalalimento.TextChanged
        montototalsacos()
    End Sub

    Private Sub txtpesototalfinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpreciofinal.KeyPress, txtpesototalfinal.KeyPress, txtpesodescuento.KeyPress
        clsBasicas.ValidarNumerosDecimalessin_coma(e)
    End Sub

    Private Sub txtpesodetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpesodetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnagregar.PerformClick()
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        panelpesos.Visible = False
    End Sub

    Private Sub btnagregar_Click(sender As Object, e As EventArgs) Handles btnagregar.Click
        Try
            If (txtpesodetalle.Text.Length = 0) Then
                msj_advert("Ingrese el Peso")
                txtpesodetalle.Select()
                Return
            End If
            AgregarDatos(txtpesodetalle.Text, False)
            txtpesodetalle.Text = ""
            txtpesodetalle.Select()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub txtpesodescuento_ValueChanged(sender As Object, e As EventArgs) Handles txtpesodescuento.ValueChanged
        RecalcularPesos()
    End Sub


End Class