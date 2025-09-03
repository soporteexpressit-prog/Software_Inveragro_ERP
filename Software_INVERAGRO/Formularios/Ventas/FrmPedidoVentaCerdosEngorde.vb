Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmPedidoVentaCerdosEngorde
    Dim cn As New cnVentas
    Public _idguia As Integer = 0
    Public _codigo As Integer = 0
    Public operacion As Integer
    Public transferencia As Integer
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
            ListarPlanteles()
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


        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    ' Variable para controlar si se deben procesar los eventos del ComboBox
    Private EventosHabilitados As Boolean = True

    ' Método para listar planteles
    Public Sub ListarPlanteles()
        Try
            ' Deshabilitar temporalmente eventos
            EventosHabilitados = False

            ' Inicializar conexión y obtener datos
            Dim cn As New cnProducto
            tbtmpplanteles = cn.Cn_ListarPlanteles().Copy
            tbtmpplanteles.TableName = "tmp"

            ' Crear DataView solo si la tabla no está vacía
            If tbtmpplanteles IsNot Nothing AndAlso tbtmpplanteles.Rows.Count > 0 Then
                DvPlanteles = New DataView(tbtmpplanteles)
            Else
                DvPlanteles = Nothing
            End If

            ' Configurar ComboBox cbxplanteles
            If DvPlanteles IsNot Nothing Then
                With cbxplanteles
                    .DataSource = DvPlanteles
                    .DisplayMember = tbtmpplanteles.Columns(1).ColumnName ' Nombre de la columna a mostrar
                    .ValueMember = tbtmpplanteles.Columns(0).ColumnName   ' Nombre de la columna del valor
                    If tbtmpplanteles.Rows.Count > 0 Then
                        .SelectedValue = tbtmpplanteles.Rows(0)(0) ' Seleccionar el primer valor
                    End If
                End With
            Else
                ' Si no hay datos, limpia el ComboBox
                cbxplanteles.DataSource = Nothing
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        Finally
            ' Habilitar eventos nuevamente
            EventosHabilitados = True
        End Try
    End Sub

    Private Sub cbxmotivotransaccion_ValueChanged(sender As Object, e As EventArgs) Handles cbxmotivotransaccion.ValueChanged
        ' Verificar si los eventos están habilitados
        If Not EventosHabilitados Then Return

        Try
            ' Validar que DvPlanteles no sea null antes de aplicar filtros
            If DvPlanteles Is Nothing Then
                ' No hacer nada si no hay datos en el DataView
                cbxplanteles.DataSource = Nothing
                Return
            End If

            ' Obtener el valor seleccionado del ComboBox
            Dim filtro As Integer
            If IsNumeric(cbxmotivotransaccion.Value) Then
                filtro = CInt(cbxmotivotransaccion.Value)
            Else
                ' Si no es numérico, limpiar el filtro
                filtro = -1
            End If

            Select Case filtro
                Case 45, 46, 47, 48, 31
                    txtcantidad.Text = 1
                    txtcantidad.Enabled = False
                Case Else
                    txtcantidad.Enabled = True
            End Select
            ' Aplicar filtro al DataView según el motivo de la transacción
            Select Case filtro
                Case 29, 31
                    DvPlanteles.RowFilter = "IdUbicacion IN (3, 4, 7)"
                    Label9.Visible = True
                    txtcantidadalimento.Visible = True
                Case 35, 36, 38, 39, 45, 46, 47, 48
                    DvPlanteles.RowFilter = "IdUbicacion IN (1, 2)"
                    Label9.Visible = True
                    txtcantidadalimento.Visible = True
                Case Else
                    ' Si no hay un filtro válido, limpiar el filtro
                    DvPlanteles.RowFilter = String.Empty
                    Label9.Visible = True
                    txtcantidadalimento.Visible = True
            End Select

            ' Refrescar el ComboBox con los datos filtrados
            cbxplanteles.DataSource = DvPlanteles
            ObtenerStock()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ObtenerStock()

        clsBasicas.ObtenerStockxPlantel(txtstock, txtstockdisponibleslimento, cbxplanteles.SelectedValue, cbxmotivotransaccion.Value)
        If (CDec(txtstock.Text) = 0) Then
            txtstock.BackColor = Color.Red
            txtstock.ForeColor = Color.White
        Else
            txtstock.BackColor = Color.Green
            txtstock.ForeColor = Color.White
        End If
        If (CDec(txtstockdisponibleslimento.Text) = 0) Then
            txtstockdisponibleslimento.BackColor = Color.Red
            txtstockdisponibleslimento.ForeColor = Color.White
        Else
            txtstockdisponibleslimento.BackColor = Color.Green
            txtstockdisponibleslimento.ForeColor = Color.White
        End If
    End Sub
    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            btnactualizar.Visible = False
            Me.Size = New Size(750, 600)
            ListarTablas()
            dtfecharececpcion.Value = Now.Date
            dtfechaemision.Value = Now.Date
            dtpedido.Value = Now.Date
            btnbuscarpoveedor.Select()
            cbxtipoprecio.SelectedIndex = 0
            ObtenerStock()
            clsBasicas.ListarVendedores(cbxvendedor)
            If operacion = 1 Then
                'Me.Size = New Size(740, 275)
                'Me.MaximumSize = New Size(740, 280)
                'Me.MinimumSize = New Size(740, 280)
                cbxvendedor.Enabled = False
                cbxmotivotransaccion.Enabled = False
                cbxplanteles.Enabled = False
                cbxtipoprecio.Enabled = False
                btnGuardar.Visible = False
                Label3.Visible = False
                txtArchivoRuta.Visible = False
                btnSubirArchivo.Visible = False
                btnactualizar.Visible = True
                Text = "ACTUALIZAR PEDIDO"
                If transferencia = 1 Then
                    cbxcondicionpago.Enabled = False
                    dtfecharececpcion.Enabled = False
                End If
                Consultar()
                ObtenerStock()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub Consultar()
        Dim obj As New coVentas
        obj.Codigo = _codigo
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarxCodigoventa(obj).Copy
        tb.TableName = "tmp"
        If tb.Rows.Count > 0 Then
            With tb.Rows(0)
                dtpedido.Value = .Item(0).ToString()
                dtfecharececpcion.Value = .Item(1).ToString()
                cbxmotivotransaccion.Value = .Item(2).ToString()
                cbxvendedor.SelectedValue = .Item(3).ToString()
                cbxplanteles.SelectedValue = .Item(4).ToString()
                cbxcondicionpago.Value = .Item(5).ToString()
                txtcantidad.Text = .Item(6).ToString()
                txtcantidadalimento.Text = .Item(7).ToString()
                txtcodproveedor.Text = .Item(8).ToString()
                txtproveedor.Text = .Item(9).ToString()
                txtdireccion.Text = .Item(10).ToString()
                txtobservacion.Text = .Item(11).ToString()
            End With
        Else
            MessageBox.Show("No se encontró ningún registro con el código especificado.")
        End If
    End Sub

    Private DtDetalle As New DataTable("TempDetProd")


    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Esta Seguro de Registrar el Pedido de Venta?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If
            If dtpedido.Value > dtfecharececpcion.Value Then
                msj_advert("La fecha 'Pedido' debe ser anterior o igual a la fecha 'Recepción'.")
                Return
            End If
            If txtcantidad.TextLength = 0 Then
                msj_advert("Ingrese una Cantidad Válida")
                Return
            End If
            If cbxmotivotransaccion.Value = 31 And CInt(txtcantidad.Text) > 1 Then
                msj_advert("Cuando el Pedido es de Cerdos de Emergencia solo se puede vender un Cerdo a la vez")
                Return
            End If

            If (txtcodproveedor.Text.Length = 0) Then
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
                obj.Codigo = _codigo
                obj.Serie = ""
                obj.Correlativo = ""
                obj.FEmision = dtfechaemision.Value
                obj.Fpedido = dtpedido.Value
                obj.Total = 0
                obj.Igv = 0
                obj.Flete = 0
                obj.Observacion = txtobservacion.Text
                obj.Estado = "ACTIVO"
                obj.Iduser = GlobalReferences.ActiveSessionId
                obj.IdCondicionpago = cbxcondicionpago.Value
                obj.IdMotivoTransaccion = cbxmotivotransaccion.Value
                obj.Frecepcion = dtfecharececpcion.Value
                obj.IdUbicacionOrigen = cbxplanteles.SelectedValue
                obj.IdUbicacionDestino = 6
                obj.Idmoneda = cbxmoneda.Value
                obj.Tipocambio = txttc.Text
                obj.Idcotizacion = 0
                obj.Lista_items = creacion_de_arrary()
                obj.Idtipodocumento = 1
                obj.Idproveedor = txtcodproveedor.Text
                'If cbxmotivotransaccion.Value = 29 Then
                obj.EstadoRecepcion = "NO"
                'ElseIf cbxmotivotransaccion.Value = 30 Or cbxmotivotransaccion.Value = 31 Then
                'obj.EstadoRecepcion = "SI"
                'End If
                obj.entregadirecta = If(CheckBox1.Checked, 1, 0)
                obj.Idguia = _idguia
                obj.Tipoprecio = "NINGUNO"
                obj.Idplantel = cbxplanteles.SelectedValue
                Dim MensajeBgWk As String = ""

                If Not String.IsNullOrEmpty(txtArchivoRuta.Text) Then
                    Dim fileInfo As New FileInfo(txtArchivoRuta.Text)
                    If fileInfo.Length > 1500 * 1024 Then
                        msj_advert("El archivo excede el tamaño máximo permitido de 1500 kB.")
                        Return
                    End If
                    Dim pdfData As Byte() = File.ReadAllBytes(txtArchivoRuta.Text)
                    obj.SetArchivo(pdfData)
                End If

                MensajeBgWk = cn.Cn_RegPedidoVentaCerdo(obj)
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

        ' Agregar el primer conjunto de valores
        array_valvulas.AppendFormat("{0}+{1}+{2}+{3}+{4},",
                                txtcantidad.Text,
                                txtprecio.Text,
                                "212",
                                "",
                                "1")

        ' Verificar si txtcantidadalimento y txtprecio no están vacíos y agregar el nuevo conjunto de valores
        If Not String.IsNullOrEmpty(txtcantidadalimento.Text) Then
            array_valvulas.AppendFormat("{0}+{1}+{2}+{3}+{4},",
                                    txtcantidadalimento.Text,
                                    txtprecio.Text,
                                    "325",
                                     "ENGORDE",
                                     "50")
        End If

        ' Elimina la última coma si es necesario
        If array_valvulas.Length > 0 Then
            array_valvulas.Length -= 1
        End If

        Return array_valvulas.ToString()
    End Function

    Private Sub txtflete_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress, txtcantidad.KeyPress, txtcantidadalimento.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtprecio.KeyPress, txtcantidad.KeyPress
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
            txtcodproveedor.Text = f.codproveedor
            txtproveedor.Text = f.razonsocial
            txtdireccion.Text = f.direccion
            f.codproveedor = 0
        Else
            txtcodproveedor.Clear()
            txtproveedor.Clear()
            txtdireccion.Clear()
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

    Private Sub cbxmotivotransaccion_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles cbxmotivotransaccion.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(2).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxplanteles_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbxplanteles.SelectionChangeCommitted
        ObtenerStock()
    End Sub


    Private Sub btnSubirArchivo_Click(sender As Object, e As EventArgs) Handles btnSubirArchivo.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Archivos Img|*.jpg|Todos los archivos|*.*"
        openFileDialog.Title = "Selecciona una Imagen"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = openFileDialog.FileName
            txtArchivoRuta.Text = selectedFilePath
        End If
    End Sub

    Private Sub btnactualizar_Click(sender As Object, e As EventArgs) Handles btnactualizar.Click
        Try
            Dim obj As New coVentas
            obj.Codigo = _codigo
            obj.Frecepcion = dtfecharececpcion.Value
            obj.Fpedido = dtpedido.Value
            obj.IdCondicionpago = cbxcondicionpago.Value
            obj.Idproveedor = txtcodproveedor.Text
            obj.Cantidad = txtcantidad.Text
            If txtcantidadalimento.Text = Nothing Or txtcantidadalimento.Text = "" Then
                obj.Cantidadsacos = 0
            Else
                obj.Cantidadsacos = txtcantidadalimento.Text
            End If

            obj.Observacion = txtobservacion.Text
            Dim MensajeBgWk As String = ""
            MensajeBgWk = cn.Cn_RegPedidoVentaCerdoupdate(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Dispose()
            Else
                msj_advert(MensajeBgWk)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class