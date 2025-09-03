Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid
Public Class FrmAbonarCuentaCobrar
    Dim cn As New cnCtaCobrar
    Public Property _codmoneda As Integer
    Public _codigo As Integer = 0
    Public _fechaemision As Date
    Public _idcuota As Integer = 0
    Public _deuda As Decimal = 0
    Dim tipoAbono As Integer = 1

    Dim ds As New DataSet
    Sub ObtenerDatosCuentaporCobrar()
        Try
            Dim obj As New coCtaCobrar With {.Id = _codigo}
            Dim ds As DataSet = cn.Cn_ObtenerDatosdeCuentaPagar(obj)

            ' 1) Texto: de Tables(1)
            If ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 0 Then
                Dim info As DataRow = ds.Tables(1).Rows(0)
                txtmonedadeuda.Text = info("Moneda").ToString()
                txttcdeuda.Text = info("Tipo de Cambio").ToString()
                txtsaldofavor.Text = info("saldo disponible").ToString()
            End If

            ' 2) Grid: de Tables(2)
            If ds.Tables.Count > 2 Then
                dtgListado_saldofavor.DataSource = ds.Tables(2)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
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

            ' Renombrar la columna si es necesario
            dv.Table.Columns(1).ColumnName = "Seleccione una Forma de Pago"
            With cbxformapago
                .DataSource = dv
                .DisplayMember = dv.Table.Columns(1).ColumnName
                .ValueMember = dv.Table.Columns(0).ColumnName
                If (dv.Count > 0) Then
                    .Value = dv(0)(0)
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
            FiltrarBancosPorMoneda(ds.Tables(3), cbxbanco_origen, cbxmoneda.Value)
            FiltrarBancosPorMoneda(ds.Tables(4), cbxbanco_destino, cbxmoneda.Value)

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
        Me.Size = New Size(1068, 1121)
        ListarTablas()
        Me.KeyPreview = True
        dtfecha.Value = Now.Date
        If (_idcuota = 0) Then
            ckliquidado.Visible = False
        End If
        ObtenerDatosCuentaporCobrar()
        cbxtransexep.Text = "Transferencia" & vbCrLf & "Excepcional"
        clsBasicas.Formato_Tablas_Grid(dtgListado_saldofavor)
    End Sub
    Private Sub FrmCotizacion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' Verifica si se presionan Control y Espacio al mismo tiempo
        If e.Control AndAlso e.KeyCode = Keys.Space Then
            btnGuardar.PerformClick()  ' Ejecuta el clic del botón
        End If
    End Sub

    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If cbxformapago.ActiveRow.Cells(0).Value.ToString <> "10" And CDec(txtsaldofavor.Text) > 0 Then
                If MsgBox(
                        "¿Está seguro de que desea continuar con la operación, dado que aún tiene saldo a favor disponible?",
                        MsgBoxStyle.OkCancel Or MsgBoxStyle.Exclamation,
                        "Aviso") = MsgBoxResult.Cancel Then
                    Return
                End If
            End If

            If txtsaldopendiente.Text = "" Or txtsaldopendiente.Text = Nothing Then
            Else
                If (CDec(txtimporte.Text) > CDec(txtsaldopendiente.Text)) Then
                    msj_advert("Ingrese un Importe válido, no puede ser mayor al importe de deuda")
                    txtimporte.Select()
                    Return
                End If
            End If

            If cbxformapago.ActiveRow.Cells(0).Value.ToString = "10" Then
                If (CDec(txtimporte.Text) > CDec(txtsaldofavorselecionado.Text)) Then
                    msj_advert("Ingrese un Importe válido, no puede ser mayor al saldo disponible")
                    txtimporte.Select()
                    Return
                End If
            End If
            If (txtobservacion.TextLength = 0) Then
                msj_advert("Ingrese una Observación")
                txtobservacion.Select()
                Return
            ElseIf dtfecha.Value > Date.Today Then
                msj_advert("La Fecha de Pago no puede ser mayor a la fecha actual")
                dtfecha.Select()
                Return
            ElseIf (txtnumdocreferencia.TextLength = 0) Then
                msj_advert("Ingrese un N° de Documento de Referencia")
                txtnumdocreferencia.Select()
                Return
            ElseIf (txtimporte.TextLength = 0 OrElse CDec(txtimporte.Text) = 0) Then
                msj_advert("Ingrese un Importe válido")
                txtimporte.Select()
                Return
            ElseIf Not cbxadelanto.Checked AndAlso CDec(txtimporte.Text) > CDec(txtdeuda.Text) Then
                msj_advert("Ingrese un Importe válido, no puede ser mayor a la deuda")
                txtimporte.Select()
                Return
            ElseIf cbxformapago.ActiveRow.Cells(0).Value.ToString = "9" And txtproveedor.Text.Length = 0 Then
                msj_advert("Debe seleccionar el Proveedor de Referencia")
                btnbuscarpoveedor.Select()
                Return
            Else

                Dim obj As New coCtaCobrar
                obj.Serie = txtserie.Text
                obj.Correlativo = txtcorrelativo.Text
                obj.Numdocreferencia = txtnumdocreferencia.Text
                obj.Total = txtimporte.Text
                obj.Fpago = dtfecha.Value
                obj.Comentario = txtobservacion.Text
                obj.Estado = "ACT"
                obj.Idusuario = VP_IdUser
                obj.Idcuentapagar = _codigo
                obj.Idformapago = cbxformapago.Value
                obj.Tipocambio = txttc.Text
                If cbxformapago.ActiveRow.Cells(0).Value.ToString = "9" Then
                    obj.Idctabancoorigen = 0
                    obj.Idctabancodestino = 0
                Else
                    obj.Idctabancoorigen = cbxbanco_origen.ActiveRow.Cells(3).Value.ToString
                    obj.Idctabancodestino = cbxbanco_destino.ActiveRow.Cells(3).Value.ToString
                End If

                obj.Idtipodocumento = cbxtipodocumento.Value
                obj.Idmoneda = cbxmoneda.Value
                obj.Idcuota = _idcuota
                obj.Liquidado = IIf(ckliquidado.Checked, 1, 0)
                obj.fotopdf = IIf(CheckfotoPdf.Checked, 1, 0)
                obj.transexepcional = IIf(cbxtransexep.Checked, 1, 0)
                obj.Idproveedorreferencia = txtproveedor.AccessibleDescription
                If txtsaldopendiente.AccessibleDescription = Nothing Or txtsaldopendiente.AccessibleDescription = "" Then
                    obj.idcuentaabonar = 0
                Else
                    obj.idcuentaabonar = txtsaldopendiente.AccessibleDescription
                End If
                If txtsaldofavorselecionado.AccessibleDescription = Nothing Or txtsaldofavorselecionado.AccessibleDescription = "" Then
                    obj.idcuentasaldofavor = 0
                Else
                    obj.idcuentasaldofavor = txtsaldofavorselecionado.AccessibleDescription
                End If
                obj.idtipoabono = tipoAbono

                If cbxadelanto.Checked Then
                    Dim saldo As Decimal = 0D
                    Decimal.TryParse(txtsaldo.Text, saldo)
                    obj.saldotomarfavor = Math.Abs(saldo)
                    obj.adelantoid = IIf(cbxadelanto.Checked, 1, 0)
                Else
                    obj.saldotomarfavor = 0D
                    obj.adelantoid = IIf(cbxadelanto.Checked, 1, 0)
                End If

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
                    FiltrarBancosPorMoneda(ds.Tables(3), cbxbanco_origen, cbxmoneda.Value)
                    FiltrarBancosPorMoneda(ds.Tables(4), cbxbanco_destino, cbxmoneda.Value)
                Else
                    ' Manejar el caso donde la celda 2 no existe
                    txttc.Text = String.Empty
                End If

            Else
                ' Manejar el caso donde no hay ninguna fila activa
                txttc.Text = String.Empty


            End If

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
    Private Sub cbxformapago_ValueChanged(sender As Object, e As EventArgs) Handles cbxformapago.ValueChanged
        Try
            ' Verifica que ActiveRow no sea Nothing
            If cbxformapago.ActiveRow IsNot Nothing Then
                ' Verifica que la celda 2 exista
                If cbxformapago.ActiveRow.Cells(0).Value.ToString = "1" Then
                    lblbancodestino.Visible = False
                    cbxbanco_destino.Visible = False
                    txtnumdocreferencia.Enabled = False
                    Label2.Enabled = False
                Else
                    lblbancodestino.Visible = True
                    cbxbanco_destino.Visible = True
                    txtnumdocreferencia.Enabled = True
                    Label2.Enabled = True
                End If
                If cbxformapago.ActiveRow.Cells(0).Value.ToString = "9" Then
                    lblproveedor.Visible = True
                    txtproveedor.Visible = True
                    btnbuscarpoveedor.Visible = True
                    lblbancodestino.Visible = False
                    cbxbanco_destino.Visible = False
                    btnbuscarabono.Visible = True
                    Label10.Visible = True
                    txttiposervicio.Visible = True
                    txtsaldopendiente.Visible = True
                    lbsaldopendiente.Visible = True
                    cbxtransexep.Visible = True
                    tipoAbono = 1
                    txtnumdocreferencia.Enabled = True
                    Label2.Enabled = True
                Else
                    lblproveedor.Visible = False
                    txtproveedor.Visible = False
                    btnbuscarpoveedor.Visible = False
                    btnbuscarabono.Visible = False
                    Label10.Visible = False
                    txttiposervicio.Visible = False
                    txtsaldopendiente.Visible = False
                    lbsaldopendiente.Visible = False
                    cbxtransexep.Visible = False
                    tipoAbono = 0
                End If
                If cbxformapago.ActiveRow.Cells(0).Value.ToString = "7" Then
                    panel_moneda.Visible = True
                    cbxmoneda.Enabled = True
                    txttc.Enabled = True
                Else
                    panel_moneda.Visible = False
                    cbxmoneda.Enabled = False
                    txttc.Enabled = False
                    txtdeuda.Text = _deuda
                    txtimporte.Text = _deuda
                End If
                If cbxformapago.ActiveRow.Cells(0).Value.ToString = "10" Then
                    cbxbanco_destino.Visible = False
                    lblbancodestino.Visible = False
                    txtsaldofavorselecionado.Visible = True
                    Label11.Visible = True
                    txtnumdocreferencia.Visible = False
                    Label2.Visible = False
                    txtnumdocreferencia.Enabled = False
                    Label2.Enabled = False
                Else
                    txtsaldofavorselecionado.Visible = False
                    Label11.Visible = False
                    txtnumdocreferencia.Visible = True
                    Label2.Visible = True
                End If
            Else
                ' Manejar el caso donde no hay ninguna fila activa
                lblbancodestino.Visible = False
                cbxbanco_destino.Visible = False


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

    Private Sub cbxbanco_origen_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
        Try
            With e.Layout.Bands(0)
                .Columns(1).Width = 250
                .Columns(2).Hidden = True
                .Columns(3).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub cbxbanco_destino_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxbanco_destino.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(1).Width = 250
                .Columns(2).Hidden = True
                .Columns(3).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
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
        ' Filtra para PDF e imágenes (JPG, JPEG, PNG, BMP)
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
        ' Asegurarse de que ambos TextBox tengan valores válidos antes de realizar la operación
        If IsNumeric(txttc.Text) Then
            Dim tc As Decimal = Convert.ToDecimal(txttc.Text)
            Dim deuda As Decimal = _deuda
            ' Verificar que el valor de txttc no sea cero para evitar división por cero
            If tc <> 0 Then
                ' Realizar la división
                Dim resultado As Decimal = deuda / tc

                ' Mostrar el resultado en otro TextBox o Label, según lo necesites
                txtdeuda.Text = resultado.ToString("N2") ' Formato de dos decimales
                txtimporte.Text = resultado.ToString("N2")
            Else
                MessageBox.Show("El valor de TC no puede ser cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Ingrese valores numéricos válidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnbuscarpoveedor_Click(sender As Object, e As EventArgs) Handles btnbuscarpoveedor.Click
        Dim f As New FrmBuscarProveedorIngreso()
        f.ShowDialog()
        If (f.codproveedor <> 0) Then
            txtproveedor.AccessibleDescription = f.codproveedor
            txtproveedor.Text = f.razonsocial
            f.codproveedor = 0
        Else
            txtproveedor.AccessibleDescription = ""
            txtsaldopendiente.AccessibleDescription = ""
            txttiposervicio.Text = ""
            txtsaldopendiente.Text = ""
            txtproveedor.Clear()
        End If
    End Sub

    Private Sub txtnumdocreferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumdocreferencia.KeyPress
        clsBasicas.ValidarNumerosTarjetas(e)
    End Sub
    Private Sub CheckfotoPdf_CheckedChanged(sender As Object, e As EventArgs) Handles CheckfotoPdf.CheckedChanged
        If CheckfotoPdf.Checked Then
            Label25.Text = "Adjuntar Foto : "
        Else
            Label25.Text = "Adjuntar Archivo : "
        End If
    End Sub


    Private Sub btnbuscarabono_Click(sender As Object, e As EventArgs) Handles btnbuscarabono.Click
        Dim f As New FrmCuentaPagarSelecionar()
        If txtproveedor.Text = "" Then
            MessageBox.Show("Por favor seleccione un proveedor", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        Else
            f.codproveedor = txtproveedor.AccessibleDescription
            f.ShowDialog()
            If (f.codcuenta <> 0) Then
                txtsaldopendiente.AccessibleDescription = f.codcuenta
                txttiposervicio.Text = f.tiposervicio
                txtsaldopendiente.Text = f.deudapendiente
                f.codproveedor = 0
            Else
                txtsaldopendiente.AccessibleDescription = ""
                txttiposervicio.Text = ""
                txtsaldopendiente.Text = ""
            End If
        End If
    End Sub

    Private Sub cbxtransexep_CheckedChanged(sender As Object, e As EventArgs) Handles cbxtransexep.CheckedChanged
        If cbxtransexep.Checked Then
            btnbuscarabono.Visible = False
            Label10.Visible = False
            txttiposervicio.Visible = False
            txtsaldopendiente.Visible = False
            lbsaldopendiente.Visible = False
        Else
            btnbuscarabono.Visible = True
            Label10.Visible = True
            txttiposervicio.Visible = True
            txtsaldopendiente.Visible = True
            lbsaldopendiente.Visible = True
        End If
    End Sub

    Private Sub dtgListado_saldofavor_AfterRowActivate(
        sender As Object,
        e As EventArgs
    ) Handles dtgListado_saldofavor.AfterRowActivate

        Dim grid As UltraGrid = CType(sender, UltraGrid)
        Dim row As UltraGridRow = grid.ActiveRow
        If row Is Nothing Then Return

        txtsaldofavorselecionado.Text = row.Cells(2).Value?.ToString()
        txtsaldofavorselecionado.AccessibleDescription = row.Cells(0).Value?.ToString()
    End Sub

    Private Sub txtsaldo_TextChanged(sender As Object, e As EventArgs) Handles txtsaldo.TextChanged
        Dim saldo As Decimal
        If Decimal.TryParse(txtsaldo.Text, saldo) Then
            cbxadelanto.Checked = (saldo < 0)
            cbxadelanto.Visible = (saldo < 0)
        Else
            cbxadelanto.Checked = False
            cbxadelanto.Visible = False
        End If
    End Sub

End Class