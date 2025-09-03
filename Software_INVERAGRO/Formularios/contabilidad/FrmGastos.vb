Imports System.Text.RegularExpressions
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmGastos
    Dim cn As New cnCtaPagar
    Public operacion As Integer
    Public codigo As Integer
    Dim ds As New DataSet

    Private Sub cbxmoneda_ValueChanged(sender As Object, e As EventArgs) Handles cbxmoneda.ValueChanged
        Try
            If cbxmoneda.ActiveRow IsNot Nothing Then
                If cbxmoneda.ActiveRow.Cells.Count > 2 Then
                    txttc.Text = cbxmoneda.ActiveRow.Cells(2).Value.ToString
                End If
            Else
            End If
            If (cbxmoneda.Value = 1) Then
                txttc.Text = 1
            Else
                txttc.Text = cbxmoneda.ActiveRow.Cells(2).Value.ToString
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub cbxmoneda_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxmoneda.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(2).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub ListarTablas()
        Try
            ds = cn.Cn_ListarTablasMaestrasGasto().Copy
            ds.DataSetName = "tmp"
            Dim indice_tabla As Integer = 0
            ' Cargar Monedas
            ds.Tables(0).Columns(1).ColumnName = "Seleccione una Moneda"
            With cbxmoneda
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = 1
                End If
            End With
            ' Cargar Forma de Pago
            indice_tabla += 1
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Seleccione Condición de Pago"
            With cbxcondicionpag
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With
            ' Cargar Tipo de Documento
            indice_tabla += 1
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Seleccione el Tipo de Documento"
            With cbxtipodocumento
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With
            ' Cargar Tipo de Documento
            indice_tabla += 1
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Seleccione el Tipo de Documento"
            With cbxbanco_origen
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With
            ' Cargar Tipo de Documento
            indice_tabla += 1
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Seleccione el Tipo de Documento"
            With cbxformapago
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
    Private Sub FiltrarBancosPorMoneda(tablaBancos As DataTable, comboBanco As UltraCombo, idMoneda As Integer)
        Try
            Dim vistaFiltrada As DataView = New DataView(tablaBancos)
            vistaFiltrada.RowFilter = "IdMoneda = " & idMoneda ' Filtra por la columna IdMoneda
            With comboBanco
                .DataSource = vistaFiltrada
                .DisplayMember = tablaBancos.Columns(1).ColumnName
                .ValueMember = tablaBancos.Columns(0).ColumnName
                If vistaFiltrada.Count > 0 Then
                    .Value = vistaFiltrada(0)(0)
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(735, 783)
        Me.KeyPreview = True
        ListarTablas()
        dtfecha.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListado)
        CargarTablaDetalle()
        If operacion = 1 Then
            Consultar()
            btnActualizar.Visible = True
            btnGuardar.Visible = False
            ckliquidado.Checked = False
        Else
            dtfecha.Value = Now.Date
            btnActualizar.Visible = False
            btnGuardar.Visible = True
            ckliquidado.Checked = True
        End If
        txtcodproveedor.ReadOnly = True
        txtcodproveedor.TabStop = False
        txtproveedor.ReadOnly = True
        txtproveedor.TabStop = False
        txtcodcuenta.ReadOnly = True
        txtcodcuenta.TabStop = False
        txtcodactivo.ReadOnly = True
        txtcodactivo.TabStop = False
        txtactivo.ReadOnly = True
        txtactivo.TabStop = False
        btnbuscaractivo.TabStop = False
        txtcuenta.ReadOnly = True
        txtcuenta.TabStop = False
        txtimporte.ReadOnly = True
        txtimporte.TabStop = False
        dtgListado.TabStop = False

        ' Opcional: Ajusta el TabIndex si es necesario, pero lo usaremos solo para referencia
        dtfecha.TabIndex = 0
        dtfecha.TabStop = True
        cbxcondicionpag.TabIndex = 1
        ckliquidado.TabStop = True
        ckliquidado.TabIndex = 2
        ckliquidado.TabStop = True
        btnbuscarproveedor.TabIndex = 3
        btnbuscarproveedor.TabStop = True
        btncuentacontable.TabIndex = 4
        btncuentacontable.TabStop = True
        cbxmoneda.TabIndex = 5
        cbxmoneda.TabStop = True
        txttc.TabIndex = 6
        txttc.TabStop = True
        txtserie.TabIndex = 7
        txtserie.TabStop = True
        txtcorrelativo.TabIndex = 8
        txtcorrelativo.TabStop = True
        cbxformapago.TabIndex = 9
        cbxformapago.TabStop = True
        txtnumdocumento.TabIndex = 10
        txtnumdocumento.TabStop = True
        txtdetalle.TabIndex = 11
        txtdetalle.TabStop = True
        txtcantidad.TabIndex = 12
        txtcantidad.TabStop = True
        txtprecio.TabIndex = 13
        txtprecio.TabStop = True
        cbxagregar.TabIndex = 14
        cbxagregar.TabStop = True
    End Sub
    Sub Consultar()
        Try
            Dim obj As New coCtaCobrar With {
                .Id = codigo
            }
            Dim ds As New DataSet
            ' Supongamos que tienes un método para ejecutar procedimientos almacenados que llena un DataSet.
            ds = cn.Cn_consultarxidcobrarEDITAR(obj)


            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                Dim fila As DataRow = ds.Tables(0).Rows(0)
                txtcodproveedor.Text = fila("codigo").ToString()
                txtproveedor.Text = fila("datos").ToString()
                dtfecha.Value = fila("fInicioCredito").ToString()
                cbxcondicionpag.Value = fila("idcondicionpago").ToString()
                txtcodcuenta.Text = fila("idplancuenta").ToString()
                txtcuenta.Text = fila("planCuenta").ToString()
                cbxtipodocumento.Value = fila("idtipodocumento").ToString()
                txtnumdocreferencia.Text = fila("codReferencia").ToString()
                cbxmoneda.Value = fila("idmoneda").ToString()
                txttc.Text = fila("tipocambio").ToString()
                txtimporte.Text = fila("total").ToString()
                txtobservacion.Text = fila("observacion").ToString()
                txtserie.Text = fila("serie").ToString()
                txtcorrelativo.Text = fila("correlativo").ToString()

                ' Ahora, el segundo conjunto de resultados es el detalle:
                If ds.Tables.Count > 1 Then
                    dtgListado.DataSource = ds.Tables(1)
                End If
            Else
                MessageBox.Show("No se encontraron datos para el transporte seleccionado.", "Consultar Transporte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar los datos del transporte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            'If MsgBox("¿Esta Seguro de Registra Nueva Cuenta por Pagar?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
            '    Return
            'End If
            If (txtimporte.TextLength = 0 OrElse CDec(txtimporte.Text) = 0) Then
                msj_advert("Ingrese un Importe válido")
                txtimporte.Select()
                Return
            ElseIf (txttc.TextLength = 0 OrElse CDec(txttc.Text) = 0) Then
                msj_advert("Ingrese un Tipo de Cambio válido")
                txttc.Select()
                Return
            ElseIf (txtcodcuenta.TextLength = 0) Then
                msj_advert("Seleccione una Cuenta Contable")
                btncuentacontable.Select()
                Return
            ElseIf (txtcodproveedor.TextLength = 0) Then
                msj_advert("Seleccione un Responsable o Proveedor")
                btnbuscarproveedor.Select()
                Return

            Else
                Dim obj As New coCtaPagar
                obj.Total = txtimporte.Text
                obj.Fpago = dtfecha.Value
                obj.Idusuario = VP_IdUser
                obj.Iddestino = txtcodproveedor.Text
                obj.Idactivo = IIf(txtcodactivo.Text.Length = 0, 0, txtcodactivo.Text)
                obj.Idcuentapagar = txtcodcuenta.Text
                obj.Observacion = txtobservacion.Text
                obj.Idcondicionpago = cbxcondicionpag.Value
                obj.Idmoneda = cbxmoneda.Value
                obj.Tipocambio = txttc.Text
                obj.Idctacontable = txtcodcuenta.Text
                obj.Liquidado = IIf(ckliquidado.Checked, 1, 0)
                obj.Idctabancoorigen = cbxbanco_origen.ActiveRow.Cells(0).Value.ToString
                obj.Idformapago = cbxformapago.Value
                obj.Numdocreferencia = txtnumdocreferencia.Text
                obj.Serie = txtserie.Text
                obj.Correlativo = txtcorrelativo.Text
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_RegNuevaCuentaPagar(obj)

                If (obj.Coderror = 0) Then
                    For i = 0 To dtgListado.Rows.Count - 1
                        Dim obj2 As New coCtaPagar
                        obj2.Idtipodocumento = dtgListado.Rows(i).Cells(6).Value.ToString
                        obj2.Numdocreferencia = dtgListado.Rows(i).Cells(1).Value.ToString
                        obj2.Detalle = dtgListado.Rows(i).Cells(2).Value.ToString
                        obj2.Cantidad = dtgListado.Rows(i).Cells(3).Value.ToString
                        obj2.Precio = dtgListado.Rows(i).Cells(4).Value.ToString
                        obj2.Idcuentapagar = obj.Id

                        Dim msj2 As String = ""
                        msj2 = cn.Cn_NuevaCtaPagarDetalle(obj2)
                    Next
                    msj_ok("Cuenta por Pagar Registrada Correctamente")
                    Dispose()
                Else
                    msj_advert(MensajeBgWk)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub Dtg_Listado_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            If (e.Cell.Column.Key = "btneliminar") Then
                If dtgListado.ActiveRow IsNot Nothing Then
                    If MsgBox("¿Esta Seguro de Eliminar el Detalle ?" & ChrW(13) & ChrW(13) & " Código  :" & dtgListado.ActiveRow.Cells(1).Value.ToString, MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Ok Then
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
    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub


    Private Sub cbxtipodocumento_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxtipodocumento.InitializeLayout
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
    Private Sub cbxformapago_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxcondicionpag.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnbuscarproveedor.Click
        Dim f As New FrmBuscarProveedorTrabajador
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
    Private DtDetalle As New DataTable("TempDetProd")

    Sub Agregar()
        Try
            txtcantidad.Text = "1"
            If txtcantidad.Text.Length = 0 Then
                msj_advert("Ingrese una Cantidad")
                Return
            ElseIf CDec(txtcantidad.Text) = 0 Then
                msj_advert("Por Favor Ingrese la Cantidad")
                txtcantidad.Select()
                Return

            ElseIf txtprecio.Text.Trim.Length = 0 Then
                msj_advert("Por Favor Ingrese el Precio")
                txtprecio.Focus()
                Return
            ElseIf CDec(txtprecio.Text) <= 0 Then
                msj_advert("El Precio de Venta no puede Tener el valor menor a 0")
                txtprecio.Focus()
                Return
            Else

                Dim dr As DataRow = DtDetalle.NewRow
                dr(0) = cbxtipodocumento.Text
                dr(1) = txtnumdocumento.Text
                dr(2) = txtdetalle.Text
                Dim c As Double
                c = CDbl(txtcantidad.Text.Trim).ToString(P_FormatoDecimales)
                dr(3) = c
                Dim p As Double
                p = CDbl(txtprecio.Text).ToString(P_FormatoDecimales)
                dr(4) = p
                dr(5) = ""
                dr(6) = cbxtipodocumento.Value
                DtDetalle.Rows.Add(dr)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle
                dtgListado.DataBind()
                CalculaTotal()

                txtdetalle.Text = ""
                ' txtprecio.Text = ""
                txtcantidad.Text = "1"

            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub CargarTablaDetalle()
        ' Create Columns
        DtDetalle = New DataTable("TempDetProd")
        DtDetalle.Columns.Add("tipodocumento", GetType(String))
        DtDetalle.Columns.Add("numdocumento", GetType(String))
        DtDetalle.Columns.Add("detalle", GetType(String))
        DtDetalle.Columns.Add("cantidad", GetType(Decimal))
        DtDetalle.Columns.Add("precunit", GetType(Decimal))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        DtDetalle.Columns.Add("idtipodocumento", GetType(Integer))
        dtgListado.DataSource = DtDetalle
    End Sub
    Sub CalculaTotal()
        Dim total As Decimal = 0
        If (dtgListado.Rows.Count > 0) Then

            For Each Fila As DataRow In DtDetalle.Rows
                total += CDec(Fila(3).ToString) * CDec(Fila(4).ToString)
            Next

            txtimporte.Text = total

        Else
            txtimporte.Text = "0.00"
        End If
    End Sub

    Private Sub cbxagregar_Click(sender As Object, e As EventArgs) Handles cbxagregar.Click
        Agregar()
    End Sub

    Private Sub btncuentacontable_Click(sender As Object, e As EventArgs) Handles btncuentacontable.Click
        Dim f As New FrmBuscarCuentaContable
        f.ShowDialog()
        If (f.codigo <> 0) Then
            txtcodcuenta.Text = f.codigo
            txtcuenta.Text = f.descripcion
            f.codigo = 0
        Else
            txtcodcuenta.Clear()
            txtcuenta.Clear()
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "Tipo de Documento"
                .Columns(0).Width = 120
                .Columns(1).Header.Caption = "N° Documento"
                .Columns(1).Width = 100
                .Columns(2).Header.Caption = "Detalle"
                .Columns(2).Width = 180
                .Columns(3).Header.Caption = "Cantidad"
                .Columns(3).Width = 90
                .Columns(4).Header.Caption = "Precio"
                .Columns(4).Width = 90
                .Columns(5).Header.Caption = "Eliminar"
                .Columns(5).Width = 80
                .Columns(5).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(5).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(5).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns(6).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnbuscaractivo_Click(sender As Object, e As EventArgs) Handles btnbuscaractivo.Click
        Dim f As New FrmBuscarActivos
        f.ShowDialog()
        If (f.codigo <> 0) Then
            txtcodactivo.Text = f.codigo
            txtactivo.Text = f.descripcion
            f.codigo = 0
        Else
            txtcodactivo.Clear()
            txtactivo.Clear()
        End If
    End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprecio.KeyPress, txtcantidad.KeyPress, txttc.KeyPress
        clsBasicas.ValidarNumerosDecimales(e)
    End Sub

    Private Sub ckliquidado_CheckedChanged(sender As Object, e As EventArgs) Handles ckliquidado.CheckedChanged
        If ckliquidado.Checked Then
            cbxformapago.Visible = True
            Label11.Visible = True
            txtnumdocreferencia.Visible = True
            Label12.Visible = True

        Else
            cbxformapago.Visible = False
            Label11.Visible = False
            cbxbanco_origen.Visible = False
            lblbancoorigen.Visible = False
            txtnumdocreferencia.Visible = False
            Label12.Visible = False
        End If
    End Sub

    Private Sub cbxformapago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxformapago.RowSelected
        If cbxformapago.Value = 1 Then
            cbxbanco_origen.Visible = False
            lblbancoorigen.Visible = False
            Label13.Visible = False
            Label16.Visible = False
            txtcorrelativo.Visible = False
            Label10.Visible = False
            cbxmoneda.Visible = False
            txttc.Visible = False
            Label23.Visible = False
            txtserie.Visible = False
        Else
            cbxbanco_origen.Visible = True
            lblbancoorigen.Visible = True
            Label13.Visible = True
            Label16.Visible = True
            txtcorrelativo.Visible = True
            Label10.Visible = True
            cbxmoneda.Visible = True
            txttc.Visible = True
            Label23.Visible = True
            txtserie.Visible = True
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try

            'If MsgBox("¿Esta Seguro de Registrar Nuevo Ingreso?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
            '    Return
            'End If

            If (txtobservacion.TextLength = 0) Then
                msj_advert("Ingrese una Observación")
                txtobservacion.Select()
                Return
            ElseIf (txtimporte.TextLength = 0 OrElse CDec(txtimporte.Text) = 0) Then
                msj_advert("Ingrese un Importe válido")
                txtimporte.Select()
                Return
            ElseIf (txtcodproveedor.TextLength = 0) Then
                msj_advert("Selecione un Proveedor o Trabajador")
                Return
            ElseIf (txtcodcuenta.TextLength = 0) Then
                msj_advert("Seleccione un Plan de Cuenta")
                Return
            Else

                Dim obj As New coCtaCobrar
                obj.Numdocreferencia = txtnumdocreferencia.Text
                obj.Total = txtimporte.Text
                obj.Fpago = dtfecha.Value
                obj.Comentario = txtobservacion.Text
                obj.Idformapago = cbxformapago.Value
                obj.Tipocambio = txttc.Text
                obj.Idusuario = VP_IdUser
                obj.Idctabancoorigen = cbxbanco_origen.ActiveRow.Cells(0).Value.ToString
                obj.Idtipodocumento = cbxtipodocumento.Value
                obj.Idmoneda = cbxmoneda.Value
                obj.Liquidado = IIf(ckliquidado.Checked, 1, 0)
                obj.Iddestino = txtcodproveedor.Text
                obj.Idcondicionpago = cbxcondicionpag.Value
                obj.Idcuentapagar = txtcodcuenta.Text
                obj.Id = codigo
                obj.Serie = txtserie.Text
                obj.Correlativo = txtcorrelativo.Text
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_RegNuevaCuentaCobraractualizar(obj)

                If (obj.Coderror = 0) Then
                    For i = 0 To dtgListado.Rows.Count - 1
                        Dim obj2 As New coCtaPagar
                        obj2.Idtipodocumento = dtgListado.Rows(i).Cells(6).Value.ToString
                        obj2.Numdocreferencia = dtgListado.Rows(i).Cells(1).Value.ToString
                        obj2.Detalle = dtgListado.Rows(i).Cells(2).Value.ToString
                        obj2.Cantidad = dtgListado.Rows(i).Cells(3).Value.ToString
                        obj2.Precio = dtgListado.Rows(i).Cells(4).Value.ToString
                        obj2.Idcuentapagar = obj.Id

                        Dim msj2 As String = ""
                        msj2 = cn.Cn_NuevaCtaPagarDetalle(obj2)
                    Next
                    msj_ok("Cuenta por Pagar Registrada Correctamente")
                    Dispose()
                Else
                    msj_advert(MensajeBgWk)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


End Class