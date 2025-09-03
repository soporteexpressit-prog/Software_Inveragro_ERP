Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmVerCuotasPendientesdePago
    Dim cn As New cnCtaPagar
    Public _codigo_prestamo As Integer = 0
    Public _codigocta As Integer = 0
    Dim ds As New DataSet
    Private DtDetalle As New DataTable("TempDetCuota")

    Sub ListarTablas()
        Try
            ds = New DataSet
            ds = cn.Cn_ListarTablasMaestrasPrestamo().Copy
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
            indice_tabla = 1
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Seleccione un Tipo de Prestamo"
            With cbxtipoprestamo
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With


            ' Cargar Bancos filtrados por la Moneda seleccionada
            FiltrarBancosPorMoneda(ds.Tables(2), cbxbanco_origen, cbxmoneda.Value)

            ds.Tables(3).Columns(1).ColumnName = "Seleccione un Banco"
            With cbxbanco
                .DataSource = ds.Tables(3)
                .DisplayMember = ds.Tables(3).Columns(1).ColumnName
                .ValueMember = ds.Tables(3).Columns(0).ColumnName
                If (ds.Tables(3).Rows.Count > 0) Then
                    .Value = 1
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
        dtfechaaprobacion.Value = Now.Date
        dtfFechaCuota.Value = Now.Date
        dtfechasolicitud.Value = Now.Date
        txtNumCuota.Enabled = False
        txtimporte.Enabled = False
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarTablas()
        CargarTablaDetalleCuota()
        dtfechasolicitud.Value = Now.Date
        If (_codigo_prestamo <> 0) Then
            ' grupo_cabecera.Enabled = False
            btnGuardar.Visible = False
            dtfFechaCuota.ReadOnly = True
            txtcodigoreferencia.ReadOnly = True
            txtcomentario.ReadOnly = True
            ConsultarxId()
        Else
            btnGuardar.Visible = True
        End If
    End Sub


    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (txtcomentario.TextLength = 0) Then
                msj_advert("Ingrese una Observación")
                Return
            ElseIf (txtcodigoreferencia.TextLength = 0) Then
                msj_advert("Ingrese el Codigo de Referencia del Prestamo")
                Return
            ElseIf (txtimporte.TextLength = 0 OrElse CDec(txtimporte.Text) = 0) Then
                msj_advert("Ingrese un Importe válido")
                Return
            ElseIf (txttasa.TextLength = 0) Then
                msj_advert("Ingrese una Tasa de Interés")
                Return
            Else
                Dim prestamoCtaPagar As New coPrestamo

                prestamoCtaPagar.CodReferencia = txtcodigoreferencia.Text
                prestamoCtaPagar.TotalCuotas = dtgListado.Rows.Count
                prestamoCtaPagar.Importe = txtimporte.Text
                prestamoCtaPagar.FSolicitud = dtfechasolicitud.Value
                prestamoCtaPagar.FAprobacion = dtfechaaprobacion.Value ' Aprobación pendiente
                prestamoCtaPagar.FCuota = DateTime.Now.AddMonths(1) ' Primera cuota en un mes
                prestamoCtaPagar.TasaInteres = Decimal.Parse(txttasa.Text) ' 5% de interés
                prestamoCtaPagar.EstadoPrestamo = "APROBADO"
                prestamoCtaPagar.Comentario = txtcomentario.Text
                prestamoCtaPagar.IdUsuario = VP_IdUser
                prestamoCtaPagar.IdBanco = cbxbanco.Value
                prestamoCtaPagar.IdCuentaBancoDestDepo = cbxbanco_origen.ActiveRow.Cells(3).Value.ToString
                prestamoCtaPagar.IdTipoPrestamo = cbxtipoprestamo.Value
                prestamoCtaPagar.IdSolicitante = VP_IdUser
                prestamoCtaPagar.IdMoneda = cbxmoneda.Value
                prestamoCtaPagar.TipoCambio = txttc.Text
                prestamoCtaPagar.Lista_items = creacion_de_arrary()

                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_ResPrestamo(prestamoCtaPagar)

                If (prestamoCtaPagar.Coderror = 0) Then
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
    Sub ConsultarxId()
        Try
            Dim obj As New coPrestamo
            obj.Idprestamo = _codigo_prestamo
            Dim dsPrestamo As DataSet = cn.Cn_ConsultarPrestamopPendientePagoxCodigo(obj)

            If dsPrestamo IsNot Nothing AndAlso dsPrestamo.Tables.Count > 0 Then
                ' Obtener datos del préstamo


                txtcodigoreferencia.Text = dsPrestamo.Tables(0).Rows(0)(1).ToString()
                'numcuota.Value = dsPrestamo.Tables(0).Rows(0)(2).ToString()
                txtimporte.Text = Convert.ToDecimal(dsPrestamo.Tables(0).Rows(0)(3))
                dtfechasolicitud.Value = dsPrestamo.Tables(0).Rows(0)(4).ToString()
                dtfechaaprobacion.Value = dsPrestamo.Tables(0).Rows(0)(5).ToString()
                txttasa.Text = dsPrestamo.Tables(0).Rows(0)(6).ToString()
                txtcomentario.Text = dsPrestamo.Tables(0).Rows(0)(7).ToString()

                cbxbanco.Value = dsPrestamo.Tables(0).Rows(0)(11).ToString()
                cbxbanco_origen.ActiveRow.Cells(3).Value = dsPrestamo.Tables(0).Rows(0)(12).ToString()
                cbxtipoprestamo.Value = dsPrestamo.Tables(0).Rows(0)(13).ToString()

                cbxmoneda.Value = dsPrestamo.Tables(0).Rows(0)(15).ToString()

                dtgListado.DataSource = dsPrestamo.Tables(1)

            Else
                MessageBox.Show("No se encontró el préstamo.")
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub


    Private Sub cbxmoneda_ValueChanged(sender As Object, e As EventArgs) Handles cbxmoneda.ValueChanged
        Try
            ' Verifica que ActiveRow no sea Nothing
            If cbxmoneda.ActiveRow IsNot Nothing Then
                ' Verifica que la celda 2 exista
                If cbxmoneda.ActiveRow.Cells.Count > 2 Then
                    txttc.Text = cbxmoneda.ActiveRow.Cells(2).Value.ToString
                    FiltrarBancosPorMoneda(ds.Tables(2), cbxbanco_origen, cbxmoneda.Value)
                Else
                    ' Manejar el caso donde la celda 2 no existe
                    txttc.Text = String.Empty
                End If
            Else
                ' Manejar el caso donde no hay ninguna fila activa
                txttc.Text = String.Empty
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub txtimporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtimporte.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub cbxbanco_origen_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxbanco_origen.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(2).Hidden = True
                .Columns(1).Width = 220
                .Columns(3).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxtipoprestamo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxtipoprestamo.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
            End With
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

    Private Sub cbxbanco_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxbanco.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Width = 200
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    'Private Sub Dtg_Listado_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
    '    Try
    '        If (_codigo <> 0) Then
    '            If (e.Cell.Column.Key = "btnpagar") Then
    '                If dtgListado.ActiveRow IsNot Nothing Then
    '                    If MsgBox("¿Está seguro de pagar la cuota?" & vbCrLf & vbCrLf &
    '      "Fecha: " & dtgListado.ActiveRow.Cells(1).Value.ToString() & " -- Importe: " &
    '      dtgListado.ActiveRow.Cells(2).Value.ToString(),
    '      MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Ok Then

    '                        ' Código para ejecutar el pago de la cuota
    '                        ' ...

    '                    End If
    '                End If
    '            End If
    '        End If

    '    Catch ex As Exception
    '        clsBasicas.controlException(Name, ex)
    '    End Try
    'End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            ' Verifica si el importe de la cuota ha sido ingresado
            If txtImporteCuota.Text.Length = 0 Then
                msj_advert("Ingrese el importe de la cuota")
                Return
            End If

            ' Obtiene la nueva fecha de la cuota
            Dim nuevaFechaCuota As DateTime = DateTime.Parse(dtfFechaCuota.Text)

            ' Verifica si hay filas en el DtDetalle
            If DtDetalle.Rows.Count > 0 Then
                ' Obtiene la fecha de la última cuota
                Dim ultimaFechaCuota As DateTime = DtDetalle.AsEnumerable().Max(Function(row) row.Field(Of DateTime)(0))

                ' Verifica que la nueva fecha sea mayor que la última fecha
                If nuevaFechaCuota <= ultimaFechaCuota Then
                    msj_advert("La fecha de la nueva cuota debe ser mayor a la fecha de la última cuota agregada.")
                    Return
                End If
            End If

            ' Crear una nueva fila
            Dim dr As DataRow = DtDetalle.NewRow
            dr(0) = nuevaFechaCuota

            ' Verifica y asigna el importe
            Dim importe As Decimal
            If Decimal.TryParse(txtImporteCuota.Text, importe) Then
                dr(1) = importe
            Else
                Throw New Exception("El importe ingresado no es un valor decimal válido.")
            End If

            ' Asigna la fecha actual y el estado
            dr(2) = Now.Date
            dr(3) = "PENDIENTE"

            ' Agregar la nueva fila al DataTable
            DtDetalle.Rows.Add(dr)
            DtDetalle.AcceptChanges()

            ' Actualizar el DataGrid
            dtgListado.DataSource = DtDetalle
            dtgListado.DataBind()

            ' Limpiar el campo de importe de cuota
            txtImporteCuota.Text = ""

            ' Incrementar el número de cuota
            Dim numCuota As Integer
            If Integer.TryParse(txtNumCuota.Text, numCuota) Then
                txtNumCuota.Text = (numCuota + 1).ToString()
            Else
                txtNumCuota.Text = "1"
            End If

            ' Calcular la suma de los importes
            Dim sumaImportes As Decimal = 0
            For Each row As DataRow In DtDetalle.Rows
                sumaImportes += row.Field(Of Decimal)(1)
            Next
            txtimporte.Text = sumaImportes.ToString()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub CargarTablaDetalleCuota()
        DtDetalle = New DataTable("TempDetProd")
        DtDetalle.Columns.Add("fechaCuota", GetType(DateTime))
        DtDetalle.Columns.Add("importe", GetType(Decimal))
        DtDetalle.Columns.Add("fechapago", GetType(DateTime))
        DtDetalle.Columns.Add("estado", GetType(String))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        DtDetalle.Columns.Add("btnpagar", GetType(String))
        dtgListado.DataSource = DtDetalle
        dtgListado.Refresh()
    End Sub


    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            If e.Cell.Column.Key = "btnpagar" Then
                Dim rowIndex As Integer = e.Cell.Row.Index

                ' Validar que las cuotas anteriores tengan fecha de pago
                For i As Integer = 0 To rowIndex - 1
                    If IsDBNull(dtgListado.Rows(i).Cells("fechapago").Value) Then
                        MessageBox.Show("Debe pagar las cuotas en orden de fechas. Existen cuotas anteriores que no han sido pagadas.", "Error de Pago", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                Next

                ' Preguntar si se desea pagar la cuota seleccionada
                Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea pagar esta cuota?", "Confirmar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    ' Abrir el formulario de pago de la cuota
                    Dim f As New FrmAbonarCuentaPagar
                    Dim t As Decimal = clsBasicas.FormatearComoDecimal(dtgListado.ActiveRow.Cells("importe").Value.ToString())

                    f._codigo = _codigocta
                    f._idcuota = dtgListado.ActiveRow.Cells(0).Value.ToString
                    f._deuda = t
                    f.txtdeuda.Text = t
                    f.txtimporte.Text = t
                    f._codmoneda = cbxmoneda.Value
                    f.ShowDialog()
                    ConsultarxId()
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)

                If (_codigo_prestamo <> 0) Then
                    '.Columns(4).Hidden = True
                    .Columns(0).Hidden = True
                    .Columns(1).Header.Caption = "Fecha Cuota"
                    .Columns(2).Header.Caption = "Importe"
                    .Columns(3).Header.Caption = "Estado"
                    .Columns(4).Header.Caption = "Fecha Pago"

                    .Columns(5).Header.Caption = "Pagar"
                    .Columns(5).Width = 60
                    .Columns(5).Style = UltraWinGrid.ColumnStyle.Button
                    .Columns(5).CellButtonAppearance.Image = My.Resources.Pagar_24_px
                    .Columns(5).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always

                Else
                    .Columns(2).Hidden = True
                    .Columns(3).Hidden = True
                    .Columns(5).Hidden = True

                    .Columns(0).Header.Caption = "Fecha de Cuota"
                    .Columns(0).Width = 200

                    .Columns(1).Header.Caption = "Importe"
                    .Columns(1).Width = 65


                    .Columns(4).Header.Caption = "Eliminar"
                    .Columns(4).Width = 60
                    .Columns(4).Style = UltraWinGrid.ColumnStyle.Button
                    .Columns(4).CellButtonAppearance.Image = My.Resources.eliminar24_px
                    .Columns(4).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                End If
            End With
            clsBasicas.Totales_Formato(dtgListado, e, 0)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub txtImporteCuota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImporteCuota.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Function creacion_de_arrary() As String
        Dim array_valvulas As String = ""
        If (dtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgListado.Rows.Count - 1
                If (dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtgListado.Rows(i)
                        array_valvulas = array_valvulas & .Cells(0).Value.ToString.Trim & "+" &
                            .Cells(1).Value.ToString.Replace(".", "_") & ","
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

    Private Sub txttasa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttasa.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

End Class