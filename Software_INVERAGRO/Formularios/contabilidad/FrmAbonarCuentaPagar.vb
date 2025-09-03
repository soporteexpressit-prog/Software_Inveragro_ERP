Imports System.IO
Imports System.Text.RegularExpressions
Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmAbonarCuentaPagar
    Dim cn As New cnCtaPagar
    Public Property _codmoneda As Integer
    Public _codigo As Integer = 0
    Public _idcuentabancotrabajador As Integer = 0
    Public _idcuota As Integer = 0
    Public _deuda As Decimal = 0
    Public _tiposervicio As String = ""
    Public listaids As String
    Public montototal As String
    Public operacion As String
    Public cliente As String
    Public serie As String
    Public tiposervicio As String
    Public correlativo As String
    Public emisión As String
    Public _idpersona As Integer = 0
    Dim ds As New DataSet
    Sub ObtenerDatosCuentaporPagar()
        Try
            Dim tb As New DataTable
            Dim obj As New coCtaPagar
            obj.Id = _codigo
            tb = cn.Cn_ObtenerDatosdeCuentaPagar(obj)
            tb.TableName = "tmp"
            For Each row As DataRow In tb.Rows
                txtmonedadeuda.Text = row(0).ToString()
                txttcdeuda.Text = row(1).ToString()

            Next
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try

        If Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO BASE$") Or Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO EXTRA$") Then
            Try
                Dim tb As New DataTable
                Dim obj As New coCtaPagar
                obj.Idpersona = _idpersona
                tb = cn.Cn_ObtenerDatosdeCuentaPagarTrabajador(obj)
                tb.TableName = "tmp"
                For Each row As DataRow In tb.Rows
                    If Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO BASE$") Then
                        txtnumbancosueldo.Text = row(0).ToString()
                        cbxbancodestino.Value = Convert.ToInt32(row(3))
                        _idcuentabancotrabajador = Convert.ToInt32(row(4))
                    End If
                    If Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO EXTRA$") Then
                        txtnumbancosueldo.Text = row(5).ToString()
                        cbxbancodestino.Value = Convert.ToInt32(row(8))
                        _idcuentabancotrabajador = Convert.ToInt32(row(9))
                    End If
                Next
            Catch ex As Exception
                clsBasicas.controlException(Name, ex)
            End Try
        End If
    End Sub

    Sub ListarTablas()
        Try

            ds = cn.Cn_ListarTablasMaestrasAbonar().Copy
            ds.DataSetName = "tmp"
            Dim indice_tabla As Integer = 0

            ' Cargar Monedas
            ds.Tables(0).Columns(1).ColumnName = "Seleccione una Moneda"
            With cbxmoneda
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = _codmoneda
                End If
            End With

            ' Cargar Forma de Pago
            indice_tabla += 1
            Dim dv As New DataView(ds.Tables(indice_tabla))

            ' Aplicar el filtro para que no muestre los registros con idformapago = 1
            If (_idcuota <> 0) Then
                dv.RowFilter = "idformapago <> 1"
            End If


            ' Renombrar la columna si es necesario
            dv.Table.Columns(1).ColumnName = "Seleccione una Forma de Pago"
            With cbxformapago
                .DataSource = dv
                .DisplayMember = dv.Table.Columns(1).ColumnName
                .ValueMember = dv.Table.Columns(0).ColumnName
                If (dv.Count > 0) Then
                    .Value = dv(0)(0)
                    If Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO BASE$") Or Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO EXTRA$") Then
                        .Value = dv(3)(0)
                    End If
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

            ' Cargar Bancos filtrados por la Moneda seleccionada
            If Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO BASE$") Or Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO EXTRA$") Then
                FiltrarBancosPorMoneda(ds.Tables(3), cbxbanco_origen, cbxmoneda.Value)
                FiltrarBancosPorMoneda(ds.Tables(4), cbxbanco_destino, cbxmoneda.Value)
            End If
            If Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO BASE$") Or Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO EXTRA$") Then
                indice_tabla = 5
                If ds.Tables.Count > indice_tabla Then
                    ds.Tables(indice_tabla).Columns(1).ColumnName = "Seleccione un Banco"
                    With cbxbancodestino
                        .DataSource = ds.Tables(indice_tabla)
                        .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                        .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                        If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                            .Value = ds.Tables(indice_tabla).Rows(0)(0)
                        End If
                    End With
                Else
                    Throw New Exception("La tabla de Bancos de Trabajadores Planilla no está disponible.")
                End If
            End If

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
    Sub ObtenerSaldoCaja()
        clsBasicas.ObtenerSaldoCaja(txtsaldoanterior)
        If (CDec(txtsaldoanterior.Text) = 0) Then
            txtsaldoanterior.BackColor = Color.Red
        End If
    End Sub
    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(500, 630)
        Me.KeyPreview = True
        ListarTablas()
        dtfecha.Value = Now.Date
        If (_idcuota = 0) Then
            ckliquidado.Visible = False
        End If
        ObtenerSaldoCaja()
        ObtenerDatosCuentaporPagar()
        cbxbancodestino.Visible = False
        lbbancodestino.Visible = False
        lbnumcuenta.Visible = False
        txtnumbancosueldo.Visible = False
        txtnombrecliente.Text = cliente
        txtseriereferente.Text = serie
        txtcorrelativoreferente.Text = correlativo
        txttiposervicio.Text = tiposervicio
        txtfechaemision.Text = emisión
        If Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO BASE$") Or Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO EXTRA$") Then
            cbxbancodestino.Visible = True
            cbxbancodestino.Enabled = False
            lbbancodestino.Visible = True
            lbnumcuenta.Visible = True
            txtnumbancosueldo.Visible = True
            txtnumbancosueldo.Enabled = False
        End If
        If operacion = 1 Then
            Label1.Visible = False
            txtimporte.Visible = False
            Label5.Visible = False
            txtsaldo.Visible = False
            btnGuardar.Visible = False
        Else
            Label1.Visible = True
            txtimporte.Visible = True
            Label5.Visible = True
            txtsaldo.Visible = True
            btnpagomultiple.Visible = False
        End If
    End Sub

    Private Sub FrmCotizacion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.Space Then
            btnGuardar.PerformClick()  ' Ejecuta el clic del botón
        End If
    End Sub
    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim importe As Decimal = CDec(txtimporte.Text)
        Dim saldoAnterior As Decimal = CDec(txtsaldoanterior.Text)
        Try
            'If MsgBox("¿Está seguro de abonar la cuenta por pagar?", MsgBoxStyle.OkCancel Or MsgBoxStyle.Information, "Confirmación") = MsgBoxResult.Cancel Then
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
            ElseIf (CDec(txtimporte.Text) > CDec(txtdeuda.Text) And _idcuota = 0) Then
                msj_advert("Ingrese un Importe válido, no puede ser mayor a la deuda")
                txtimporte.Select()
                Return
            ElseIf (CDec(txtsaldo.Text) > 0 And _idcuota <> 0) Then
                msj_advert("Los pagos de las cuotas del préstamo deben liquidarse en su totalidad.")
                txtimporte.Select()
                Return
            ElseIf cbxformapago.Value = 1 Then
                If cbxmoneda.Value = 1 And _codmoneda = 1 Then
                    If importe > saldoAnterior Then
                        msj_advert("No puede realizar el Pago porque no cuenta con Efectivo en Caja")
                        txtimporte.Select()
                        Return
                    End If
                Else
                    msj_advert("Para pagos en efectivo, la moneda debe ser en soles.")
                    txtimporte.Select()
                    Return
                End If
            End If

            Dim obj As New coCtaPagar
            obj.Serie = txtserie.Text
            obj.Correlativo = txtcorrelativo.Text
            obj.Numdocreferencia = txtnumdocreferencia.Text
            obj.Total = txtimporte.Text
            obj.Fpago = dtfecha.Value
            obj.Comentario = txtobservacion.Text
            obj.Estado = "ACT"
            obj.Idusuario = VP_IdUser
            obj.Idformapago = cbxformapago.Value
            obj.Tipocambio = txttc.Text
            obj.Idctabancoorigen = cbxbanco_origen.ActiveRow.Cells(3).Value.ToString
            obj.Idcuentapagar = _codigo
            If Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO BASE$") Or Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO EXTRA$") Then
                obj.Idctabancodestino = cbxbanco_origen.ActiveRow.Cells(3).Value.ToString
            End If
            If Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO BASE$") Or Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO EXTRA$") Then
                obj.Idctabancodestino = cbxbancodestino.Value
                obj.idcuentabancotrabajador = _idcuentabancotrabajador
            End If
            obj.Idtipodocumento = cbxtipodocumento.Value
            obj.Idmoneda = cbxmoneda.Value
            obj.Idcuota = _idcuota
            obj.Liquidado = IIf(ckliquidado.Checked, 1, 0)
            obj.fotopdf = IIf(CheckfotoPdf.Checked, 1, 0)
            If Not String.IsNullOrEmpty(txtArchivoRuta.Text) Then
                Dim fileInfo As New FileInfo(txtArchivoRuta.Text)
                If fileInfo.Length > 400 * 1024 Then
                    msj_advert("El archivo excede el tamaño máximo permitido de 400 kB.")
                    Return
                End If
                Dim pdfData As Byte() = File.ReadAllBytes(txtArchivoRuta.Text)
                obj.SetArchivo(pdfData)
            End If

            Dim MensajeBgWk As String = ""
            MensajeBgWk = cn.Cn_Mantenimiento(obj)

            If (obj.Coderror = 0) Then
                Dispose()

            Else
                msj_advert(MensajeBgWk)
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
            If cbxmoneda.ActiveRow IsNot Nothing Then
                If cbxmoneda.ActiveRow.Cells.Count > 2 Then
                    txttc.Text = cbxmoneda.ActiveRow.Cells(2).Value.ToString
                    FiltrarBancosPorMoneda(ds.Tables(3), cbxbanco_origen, cbxmoneda.Value)
                    FiltrarBancosPorMoneda(ds.Tables(4), cbxbanco_destino, cbxmoneda.Value)
                Else
                    txttc.Text = String.Empty
                End If

                If cbxformapago.ActiveRow IsNot Nothing Then
                    If cbxformapago.ActiveRow.Cells(0).Value.ToString = 1 And cbxmoneda.ActiveRow.Cells(0).Value.ToString = 1 Then
                        lblcaja.Visible = True
                        txtsaldoanterior.Visible = True
                    Else
                        lblcaja.Visible = False
                        txtsaldoanterior.Visible = False
                    End If

                End If
            Else
                txttc.Text = String.Empty
                lblcaja.Visible = False
                txtsaldoanterior.Visible = False
            End If

            If (cbxmoneda.Value = 1) Then
                txttc.Text = 1
            Else
                txttc.ReadOnly = False
                txttc.Text = cbxmoneda.ActiveRow.Cells(2).Value.ToString
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub cbxformapago_ValueChanged(sender As Object, e As EventArgs) Handles cbxformapago.ValueChanged
        Try
            If cbxformapago.ActiveRow IsNot Nothing Then
                If cbxformapago.ActiveRow.Cells(0).Value.ToString = "1" Then
                    lblbancoorigen.Visible = False
                    cbxbanco_origen.Visible = False

                    If cbxmoneda.ActiveRow IsNot Nothing Then

                        If cbxmoneda.ActiveRow.Cells(0).Value.ToString = 1 Then

                            lblcaja.Visible = True
                            txtsaldoanterior.Visible = True
                            Label2.Visible = False
                            txtnumdocreferencia.Visible = False
                            cbxmoneda.Enabled = False
                            txttc.Enabled = False
                        Else
                            lblcaja.Visible = False
                            txtsaldoanterior.Visible = False
                        End If
                    End If
                Else
                    lblbancoorigen.Visible = True
                    cbxbanco_origen.Visible = True
                    Label2.Visible = True
                    txtnumdocreferencia.Visible = True
                    cbxmoneda.Enabled = True
                    txttc.Enabled = True
                    lblcaja.Visible = False
                    txtsaldoanterior.Visible = False

                End If
                If cbxformapago.ActiveRow.Cells(0).Value.ToString = "7" Then
                    panel_moneda.Visible = True
                    cbxmoneda.Enabled = True
                    txttc.Enabled = True
                Else
                    panel_moneda.Visible = True
                    If operacion = 1 Then
                        txtdeuda.Text = montototal
                        txtimporte.Text = montototal
                    Else
                        txtdeuda.Text = _deuda
                        txtimporte.Text = _deuda
                    End If

                End If
            Else
                ' Manejar el caso donde no hay ninguna fila activa
                lblbancoorigen.Visible = False
                cbxbanco_origen.Visible = False

                lblcaja.Visible = False
                txtsaldoanterior.Visible = False
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub txtimporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtimporte.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub txtimporte_TextChanged(sender As Object, e As EventArgs) Handles txtimporte.TextChanged
        Try
            If (txtimporte.Text.Length = 0) Then
                txtsaldo.Text = "0.00"
            Else
                Dim td As Decimal
                Dim ti As Decimal
                Dim ts As Decimal
                td = txtdeuda.Text
                ti = txtimporte.Text
                ts = td - ti
                txtsaldo.Text = clsBasicas.FormatearComoDecimal(ts)

            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxbanco_origen_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxbanco_origen.InitializeLayout
        If Not Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO BASE$") AndAlso Not Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO EXTRA$") Then
            Try
                With e.Layout.Bands(0)
                    .Columns(1).Width = 250
                    .Columns(2).Hidden = True
                    .Columns(3).Hidden = True
                End With
            Catch ex As Exception
                clsBasicas.controlException(Name, ex)
            End Try
        End If

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
    Private Sub cbxformapago_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxformapago.InitializeLayout
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

        If CheckfotoPdf.Checked Then
            openFileDialog.Filter = "Imágenes (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
        Else
            openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf"
        End If
        openFileDialog.Title = "Selecciona un archivo PDF o Imagen"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = openFileDialog.FileName
            txtArchivoRuta.Text = selectedFilePath
        End If
    End Sub

    Private Sub txttc_ValueChanged(sender As Object, e As EventArgs) Handles txttc.ValueChanged
        If IsNumeric(txttc.Text) Then
            Dim tc As Decimal = Convert.ToDecimal(txttc.Text)
            Dim deuda As Decimal
            If _deuda = 0 AndAlso Not String.IsNullOrEmpty(montototal) AndAlso IsNumeric(montototal) Then
                deuda = CDec(montototal)
            Else
                deuda = _deuda
            End If
            Dim resultado As Decimal
            If tc <> 0 Then
                If _codmoneda = 1 Then
                    If cbxmoneda.Value = 1 Then
                        resultado = deuda
                    Else
                        resultado = deuda / tc
                    End If
                ElseIf _codmoneda = 2 Then
                    If cbxmoneda.Value = 2 Then
                        resultado = deuda
                    Else
                        resultado = deuda * tc
                    End If
                Else
                    resultado = deuda
                End If
                txtdeuda.Text = resultado.ToString("N2")
                txtimporte.Text = resultado.ToString("N2")
            Else
                'MessageBox.Show("El valor de TC no puede ser cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            'MessageBox.Show("Ingrese valores numéricos válidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub txttcdeuda_ValueChanged(sender As Object, e As EventArgs) Handles txttcdeuda.ValueChanged

    End Sub

    Private Sub txtnumdocreferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumdocreferencia.KeyPress
        clsBasicas.ValidarNumerosTarjetas(e)
    End Sub

    Private Sub lblbancoorigen_Click(sender As Object, e As EventArgs) Handles lblbancoorigen.Click

    End Sub

    Private Sub bancodestino_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxbancodestino.InitializeLayout
        If Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO BASE$") Or Not Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO EXTRA$") Then
            For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
                column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
            Next
            If e.Layout.Bands(0).Columns.Count > 0 Then
                e.Layout.Bands(0).Columns(0).Hidden = True
            End If
        End If
    End Sub

    Private Sub CheckfotoPdf_CheckedChanged(sender As Object, e As EventArgs) Handles CheckfotoPdf.CheckedChanged
        If CheckfotoPdf.Checked Then
            Label25.Text = "Adjuntar Foto : "
        Else
            Label25.Text = "Adjuntar Archivo : "
        End If
    End Sub

    Private Sub btnpagomultiple_Click(sender As Object, e As EventArgs) Handles btnpagomultiple.Click
        Try

            'If MsgBox("¿Está seguro de abonar la cuenta por pagar?", MsgBoxStyle.OkCancel Or MsgBoxStyle.Information, "Confirmación") = MsgBoxResult.Cancel Then
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
            ElseIf (CDec(txtimporte.Text) > CDec(txtdeuda.Text) And _idcuota = 0) Then
                msj_advert("Ingrese un Importe válido, no puede ser mayor a la deuda")
                txtimporte.Select()
                Return
            ElseIf (CDec(txtsaldo.Text) > 0 And _idcuota <> 0) Then
                msj_advert("Los pagos de las cuotas del préstamo deben liquidarse en su totalidad.")
                txtimporte.Select()
                Return
            ElseIf (cbxformapago.Value = 1 And cbxmoneda.Value = 1 And CDec(txtimporte.Text) > CDec(txtsaldoanterior.Text)) Then
                msj_advert("No puede realizar el Pago por que no cuenta con Efectivo en Caja")
                txtimporte.Select()
                Return
            Else
                Dim obj As New coCtaPagar
                obj.Serie = txtserie.Text
                obj.Correlativo = txtcorrelativo.Text
                obj.Numdocreferencia = txtnumdocreferencia.Text
                obj.Fpago = dtfecha.Value
                obj.Comentario = txtobservacion.Text
                obj.Estado = "ACT"
                obj.Idusuario = VP_IdUser
                obj.Idformapago = cbxformapago.Value
                obj.Tipocambio = txttc.Text
                obj.Idctabancoorigen = cbxbanco_origen.ActiveRow.Cells(3).Value.ToString
                obj.listaidspagos = listaids
                If Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO BASE$") Or Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO EXTRA$") Then
                    obj.Idctabancodestino = cbxbanco_origen.ActiveRow.Cells(3).Value.ToString
                End If
                If Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO BASE$") Or Regex.IsMatch(_tiposervicio, "^PLANILLA.*SUELDO EXTRA$") Then
                    obj.Idctabancodestino = cbxbancodestino.Value
                    obj.idcuentabancotrabajador = _idcuentabancotrabajador
                End If
                obj.Idtipodocumento = cbxtipodocumento.Value
                obj.Idmoneda = cbxmoneda.Value
                obj.Idcuota = _idcuota
                obj.Liquidado = IIf(ckliquidado.Checked, 1, 0)
                obj.fotopdf = IIf(CheckfotoPdf.Checked, 1, 0)
                If Not String.IsNullOrEmpty(txtArchivoRuta.Text) Then
                    Dim fileInfo As New FileInfo(txtArchivoRuta.Text)
                    If fileInfo.Length > 400 * 1024 Then
                        msj_advert("El archivo excede el tamaño máximo permitido de 400 kB.")
                        Return
                    End If
                    Dim pdfData As Byte() = File.ReadAllBytes(txtArchivoRuta.Text)
                    obj.SetArchivo(pdfData)
                End If
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_Mantenimientopagomultiple(obj)
                If (obj.Coderror = 0) Then
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