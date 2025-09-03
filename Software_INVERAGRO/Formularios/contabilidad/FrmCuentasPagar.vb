Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmCuentasPagar
    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportarctcp.Click
        clsBasicas.ExportarExcel("Cuentas por Pagar", dtgListado)
    End Sub
    Private _estado As String
    Private _estadoliquidado As String
    Private _idpersona As Integer
    Private _idfechas As Integer
    Dim cn As New cnCtaPagar
    Private _selectedIds As New List(Of Integer)()
    Private _selectedIdsString As String = ""
    Private _totalSelectedAmount As Decimal = 0.0D
    Dim idMonedaBase As Integer
    Dim tipocambiobase As String
    Dim ds As New DataSet
    Sub Consultar()
        'Pasamos todos los parametros y ejecutamos el hilo para cargar la busqueda
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            'GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            _estado = cbxestado.Text
            _estadoliquidado = cbxliquidado.Text
            If (cktodods.Checked) Then
                _idpersona = 0
            Else
                _idpersona = CInt(txtcodproveedor.Text)
            End If
            If (cktodosfechas.Checked) Then
                _idfechas = 0
            Else
                _idfechas = 1
            End If
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coCtaPagar
            obj.Fdesde = dtpFechaDesde.Value
            obj.Fhasta = dtpFechaHasta.Value
            obj.Estado = _estado
            obj.Id = _idfechas
            obj.estadoliquidado = _estadoliquidado
            obj.Idpersona = _idpersona
            ' Simplified ComboBox value handling
            If cbxbancodestino.InvokeRequired Then
                obj.Iddestino = CInt(cbxbancodestino.Invoke(Function() cbxbancodestino.SelectedValue))
            Else
                obj.Iddestino = CInt(cbxbancodestino.SelectedValue)
            End If
            ds = New DataSet
            ds = cn.Cn_Consultar(obj).Copy
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        btnConsultar.Enabled = True
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            ds.DataSetName = "tmp"

            Dim relation1 As New DataRelation("tabla_relacion_32", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(1), False)

            ds.Relations.Add(relation1)
            dtgListado.DataSource = ds
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", 14)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 14)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "NO", 13)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "SI", 13)

            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "VENCIDO", 20)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "NORMAL", 20)

            'GrupoMasOpcionesBusqueda.Enabled = True
            ToolStrip1.Enabled = True
        End If
    End Sub

    Private Sub FrmCuentasPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = Windows.Forms.FormWindowState.Maximized
        clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListado)
        cbxestado.SelectedIndex = 1
        cbxliquidado.SelectedIndex = 0
        dtpFechaDesde.Value = Now.Date
        ToolStripButton1.Checked = True
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        dtpFechaHasta.Value = Now.Date
        ListarTablas()
        Consultar()
    End Sub
    Sub ListarTablas()
        Try
            Dim ds As New DataSet
            ds = cn.Cn_ListarTablasMaestrasGasto().Copy
            Dim bankTable = ds.Tables(3)
            bankTable.Columns(1).ColumnName = "Banco"
            Dim newRow = bankTable.NewRow()
            newRow("idCuentaBanco") = 0
            newRow("Banco") = "-- Seleccione un banco --"
            bankTable.Rows.InsertAt(newRow, 0)
            With cbxbancodestino
                .DataSource = bankTable
                .DisplayMember = "Banco"
                .ValueMember = "idCuentaBanco"
                .SelectedIndex = 0
            End With

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub cktodods_CheckedChanged(sender As Object, e As EventArgs) 
        txtcodproveedor.Clear()
        txtproveedor.Clear()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If cktodods.Checked = False AndAlso txtcodproveedor.Text.Length = 0 Then
            msj_advert("Seleccione un Proveedor")
            Return
        End If
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        Consultar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(18).Hidden = True
                .Columns(19).Hidden = True
                .Columns(21).Hidden = True
                .Columns(9).CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Columns(9).CellAppearance.FontData.SizeInPoints = 8

                .Columns(10).CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Columns(10).CellAppearance.FontData.SizeInPoints = 8

                .Columns(11).CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Columns(11).CellAppearance.FontData.SizeInPoints = 8
                .Columns(20).Header.VisiblePosition = 0
                '.Columns(8).Header.VisiblePosition = 1
            End With
            With e.Layout.Bands(1)
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True
                .Columns("btnver").Header.Caption = "Archivo"
                .Columns("btnver").Width = 80
                .Columns("btnver").Style = UltraWinGrid.ColumnStyle.Button
                .Columns("btnver").CellButtonAppearance.Image = My.Resources.adjuntar
                .Columns("btnver").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 1)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 9)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 10)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 11)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub ConsultarArchivo(codigo As Integer)

        Dim obj As New coCtaPagar
        obj.Id = codigo
        cn.Cn_ConsultarArchivodeAbono(obj)


        Dim pdfData As Byte() = obj.ArchivoRecepcion
        If pdfData IsNot Nothing AndAlso pdfData.Length > 0 Then
            Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "ArchivoAbono" & codigo.ToString & ".pdf")

            File.WriteAllBytes(tempFilePath, pdfData)
            Process.Start(tempFilePath)
        Else
            MessageBox.Show("No se encontró el archivo PDF en la base de datos.")
        End If
    End Sub
    Private Sub Dtg_Listado_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            With dtgListado
                If (e.Cell.Column.Key = "btnver") Then
                    ' Obtener el ID del detalle
                    Dim idDetalleCuentaCobrar As Integer = CInt(.ActiveRow.Cells(0).Value)
                    Dim cn2 As New cnCtaCobrar
                    ' Obtener el archivo y el tipo de imagen_pdf (1 = imagen, 0 = PDF)
                    Dim resultado = cn2.Cn_ObtenerArchivopagar(idDetalleCuentaCobrar)
                    Dim archivoData As Byte() = resultado.Item1
                    Dim imagen_pdf As Integer = resultado.Item2
                    If archivoData IsNot Nothing AndAlso archivoData.Length > 0 Then
                        ' Determinar la extensión del archivo según imagen_pdf
                        Dim extension As String = If(imagen_pdf = 1, ".png", ".pdf")
                        Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "documento" & extension)
                        ' Guardar el archivo en el disco
                        File.WriteAllBytes(tempFilePath, archivoData)
                        ' Abrir el archivo con la aplicación predeterminada
                        Process.Start(tempFilePath)
                    Else
                        MessageBox.Show("No se encontró el archivo en la base de datos.")
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub
    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub dtgListado_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dtgListado.DoubleClickRow
        Try
            If e.Row IsNot Nothing Then
                If e.Row.Cells(13).Value.ToString().ToUpper() = "SI" Then
                    MessageBox.Show("La cuenta seleccionada ya está liquidada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If e.Row.Cells(14).Value.ToString().ToUpper() = "ANULADO" Then
                    MessageBox.Show("La cuenta seleccionada ha sido anulada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If e.Row.Cells(10).Value > 0 Then
                    MessageBox.Show("Cuenta con abono registrado. Prosiga con el pago múltiple y luego liquide el saldo de esta cuenta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If idMonedaBase = 0 Then
                    idMonedaBase = CInt(e.Row.Cells(18).Value)
                End If
                Dim idMonedaActual As Integer = CInt(e.Row.Cells(18).Value)
                If idMonedaActual <> idMonedaBase Then
                    MessageBox.Show("Para realizar pagos, debe seleccionar cuentas con la misma moneda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If tipocambiobase = "" Then
                    tipocambiobase = e.Row.Cells(12).Value.ToString()
                End If
                Dim tipocambioactual As String = e.Row.Cells(12).Value.ToString()
                If tipocambioactual <> tipocambiobase Then
                    MessageBox.Show("Para realizar pagos, debe seleccionar cuentas con el mismo tipo de cambio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim id As Integer = CInt(e.Row.Cells(0).Value.ToString())
                Dim amount As Decimal = CDec(e.Row.Cells(11).Value) ' Ajusta esto al nombre correcto de la columna de monto
                ' Check if ID is already in the list
                If Not _selectedIds.Contains(id) Then
                    _selectedIds.Add(id)
                    If _selectedIdsString.Length > 0 Then
                        _selectedIdsString += ","
                    End If
                    _selectedIdsString += id.ToString()
                    _totalSelectedAmount += amount
                    e.Row.Appearance.BackColor = Color.LightBlue
                Else
                    _selectedIds.Remove(id)
                    _selectedIdsString = String.Join(",", _selectedIds)
                    _totalSelectedAmount -= amount
                    e.Row.Appearance.ResetBackColor()
                    idMonedaBase = 0
                    tipocambiobase = ""
                    tipocambioactual = ""

                End If
            End If
        Catch ex As Exception
            ' clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    ' Add a method to clear the selection
    Public Sub ClearSelection()
        _selectedIds.Clear()
        _selectedIdsString = ""
        _totalSelectedAmount = 0.0D
        idMonedaBase = 0
        tipocambiobase = ""
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            row.Appearance.ResetBackColor()
        Next
    End Sub
    Public ReadOnly Property SelectedIdsString As String
        Get
            Return _selectedIdsString
        End Get
    End Property
    Public ReadOnly Property TotalSelectedAmount As Decimal
        Get
            Return _totalSelectedAmount
        End Get
    End Property

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagarctcp.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            If (activeRow.Cells(13).Value.ToString.Equals("SI")) Then
                msj_advert("La cuenta ya fue liquidada")
                Return
            Else
                If (activeRow.Cells(14).Value.ToString.Equals("ANULADO")) Then
                    msj_advert("La cuenta ya fue anulada")
                    Return
                Else

                    If (activeRow.Cells(1).Value.ToString <> "PRESTAMO") Then
                        Dim f As New FrmNotaCredito
                        f._codigo = CInt(activeRow.Cells(0).Value.ToString)
                        f.listaids = 0
                        f._deuda = clsBasicas.FormatearComoDecimal(activeRow.Cells(11).Value.ToString)
                        f.txtdeuda.Text = clsBasicas.FormatearComoDecimal(activeRow.Cells(11).Value.ToString)
                        f._codmoneda = activeRow.Cells(18).Value.ToString
                        f._tiposervicio = activeRow.Cells(1).Value.ToString
                        f._idpersona = activeRow.Cells(21).Value.ToString
                        f.tiposervicio = activeRow.Cells(1).Value.ToString
                        f.serie = activeRow.Cells(3).Value.ToString
                        f.correlativo = activeRow.Cells(4).Value.ToString
                        f.cliente = activeRow.Cells(5).Value.ToString
                        f.emisión = activeRow.Cells(6).Value.ToString
                        f.ShowDialog()
                    End If
                    Consultar()
                End If
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnularctcp.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            If activeRow.Cells(14).Value = "ANULADO" Then
                msj_advert("La cuenta ya fue Anulada")
                Return
            End If
            Dim f As New FrmAnularCtaPagar
            f.codcta = activeRow.Cells(0).Value.ToString
            f.ShowDialog()
            Consultar()

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub btnnuevoprestamo_Click(sender As Object, e As EventArgs) Handles btnnuevoprestamoctcp.Click
        Dim f As New FrmRegPrestamo
        f.ShowDialog()
        Consultar()
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1ctcp.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            If (activeRow.Cells(1).Value.ToString <> "PRESTAMO") Then
                msj_advert("Seleccione un Prestamo")
            Else
                Dim f As New FrmRegPrestamo
                f._codigo = activeRow.Cells(19).Value.ToString
                f.ShowDialog()
                Consultar()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim f As New FrmBuscarProveedorIngreso
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
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2ctcp.Click
        Dim f As New FrmGastos
        f.ShowDialog()
        Consultar()
    End Sub
    Private Sub btnPagoDebitado_Click(sender As Object, e As EventArgs) Handles btnPagoDebitadoctcp.Click
        Dim f As New FrmConsolidadoPagoDebitadoBanco
        f.ShowDialog()
    End Sub



    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub btneditarcuentapagar_Click(sender As Object, e As EventArgs) Handles btneditarcuentapagar.Click
        Try
            Dim filaSeleccionada = dtgListado.ActiveRow ' Obtener la fila activa
            Dim f As New FrmGastos
            If filaSeleccionada.Band.Index <> 0 Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Return
            End If
            If filaSeleccionada.HasChild() Then
                For Each childRow As Infragistics.Win.UltraWinGrid.UltraGridRow In filaSeleccionada.ChildBands(0).Rows
                    Dim estadoHijo As String = childRow.Cells("Estado").Value.ToString().ToUpper()
                    If estadoHijo = "SI" Then
                        msj_advert("Para poder entrar a la edición, debe de anular todos los pagos.")
                        Return
                    End If
                Next
            End If
            f.operacion = 1
            f.codigo = filaSeleccionada.Cells(0).Value ' Valor de la primera columna
            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnpagomultiplecontabilidad_Click(sender As Object, e As EventArgs) Handles btnpagomultiplecontabilidad.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            If (activeRow.Cells(13).Value.ToString.Equals("SI")) Then
                msj_advert("La cuenta ya fue liquidada")
                Return
            Else
                If (activeRow.Cells(14).Value.ToString.Equals("ANULADO")) Then
                    msj_advert("La cuenta ya fue anulada")
                    Return
                Else

                    If (activeRow.Cells(1).Value.ToString <> "PRESTAMO") Then
                        Dim f As New FrmAbonarCuentaPagar
                        f._codigo = CInt(activeRow.Cells(0).Value.ToString)
                        f.listaids = _selectedIdsString
                        f.montototal = _totalSelectedAmount
                        f._codmoneda = activeRow.Cells(18).Value.ToString
                        f._tiposervicio = activeRow.Cells(1).Value.ToString
                        f.operacion = 1
                        f.ShowDialog()
                        ClearSelection()
                    Else
                        Dim f As New FrmVerCuotasPendientesdePago
                        f._codigocta = activeRow.Cells(0).Value.ToString
                        f._codigo_prestamo = activeRow.Cells(19).Value.ToString
                        f.ShowDialog()
                    End If
                    Consultar()
                    ClearSelection()
                End If
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            If (activeRow.Cells(13).Value.ToString.Equals("SI")) Then
                msj_advert("La cuenta ya fue liquidada")
                Return
            Else
                If (activeRow.Cells(14).Value.ToString.Equals("ANULADO")) Then
                    msj_advert("La cuenta ya fue anulada")
                    Return
                Else

                    If (activeRow.Cells(1).Value.ToString <> "PRESTAMO") Then
                        Dim f As New FrmAbonarCuentaPagar
                        f._codigo = CInt(activeRow.Cells(0).Value.ToString)
                        f.listaids = 0
                        f._deuda = clsBasicas.FormatearComoDecimal(activeRow.Cells(11).Value.ToString)
                        f.txtdeuda.Text = clsBasicas.FormatearComoDecimal(activeRow.Cells(11).Value.ToString)
                        f._codmoneda = activeRow.Cells(18).Value.ToString
                        f._tiposervicio = activeRow.Cells(1).Value.ToString
                        f._idpersona = activeRow.Cells(21).Value.ToString
                        f.tiposervicio = activeRow.Cells(1).Value.ToString
                        f.serie = activeRow.Cells(3).Value.ToString
                        f.correlativo = activeRow.Cells(4).Value.ToString
                        f.cliente = activeRow.Cells(5).Value.ToString
                        f.emisión = activeRow.Cells(6).Value.ToString
                        f.ShowDialog()
                    End If
                    Consultar()
                End If
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class