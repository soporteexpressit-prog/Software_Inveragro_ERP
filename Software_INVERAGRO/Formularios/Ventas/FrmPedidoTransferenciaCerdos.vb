Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Public Class FrmPedidoTransferenciaCerdos

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

            clsBasicas.ListarDistribuidoresAsignados(cbxalmacendestino)
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
            Me.Size = New Size(1000, 350)
            ListarTablas()
            dtpedido.Value = Now.Date
            ObtenerStock()
        Catch ex As Exception
                clsBasicas.controlException(Name, ex)
            End Try
        End Sub


        Private DtDetalle As New DataTable("TempDetProd")


        Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
            Try
            If MsgBox("¿Esta Seguro de Registrar la Transferencia?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If
            If String.IsNullOrWhiteSpace(txtcantidad.Text) Then
                msj_advert("Ingrese una cantidad")
                Return
            End If
            If cbxmotivotransaccion.Value = 31 And CInt(txtcantidad.Text) > 1 Then
                msj_advert("Cuando el Pedido es de Cerdos de Emergencia solo se puede vender un Cerdo a la vez")
                Return
            End If
            If (txtcantidad.TextLength = 0) Then
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
                obj.FEmision = dtpedido.Value
                obj.Fpedido = dtpedido.Value
                    obj.Total = 0
                    obj.Igv = 0
                    obj.Flete = 0
                    obj.Observacion = txtobservacion.Text
                    obj.Estado = "ACTIVO"
                obj.Iduser = VP_IdUser
                obj.IdCondicionpago = 1
                obj.IdMotivoTransaccion = cbxmotivotransaccion.Value
                obj.Frecepcion = dtpedido.Value
                obj.IdUbicacionOrigen = cbxplanteles.SelectedValue
                obj.IdUbicacionDestino = cbxalmacendestino.SelectedValue
                obj.Idmoneda = 1
                obj.Tipocambio = 1
                obj.Idcotizacion = 0
                    obj.Lista_items = creacion_de_arrary()
                    obj.Idtipodocumento = 1
                obj.Idproveedor = VP_IdUser
                'If cbxmotivotransaccion.Value = 29 Then
                obj.EstadoRecepcion = "NO"
                    'ElseIf cbxmotivotransaccion.Value = 30 Or cbxmotivotransaccion.Value = 31 Then
                    'obj.EstadoRecepcion = "SI"
                    'End If

                    obj.Idguia = _idguia
                obj.Tipoprecio = "NINGUNO"
                obj.Idplantel = cbxplanteles.SelectedValue
                obj.entregadirecta = 0
                Dim MensajeBgWk As String = ""

                MensajeBgWk = cn.Cn_RegPedidoVentaCerdoTransferencia(obj)
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
                                1,
                                "212",
                                "",
                                "1")

        ' Verificar si txtcantidadalimento y txtprecio no están vacíos y agregar el nuevo conjunto de valores
        If Not String.IsNullOrEmpty(txtcantidadalimento.Text) Then
            array_valvulas.AppendFormat("{0}+{1}+{2}+{3}+{4},",
                                    txtcantidadalimento.Text,
                                    1,
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

    Private Sub txtflete_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress, txtcantidad.KeyPress
            clsBasicas.ValidarNumeros(e)
        End Sub

        Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
            Dispose()
        End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub


    Private Sub cbxcondicionpago_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs)
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Width = 200
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
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

End Class