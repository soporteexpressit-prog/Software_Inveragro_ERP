Imports System.IO
Imports System.Text.RegularExpressions
Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid
Imports iText.Kernel.Pdf.Canvas.Wmf

Public Class FrmNotaCredito
    Dim cn As New cnCtaPagar
    Public Property _codmoneda As Integer
    Public _codigo As Integer = 0
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
    Dim dt As DataTable
    Private DtDetalle As DataTable

    Dim ds As New DataSet
    Sub ListarTablas()
        Try
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
                ' clsBasicas.controlException(Name, ex)
            End Try

            ds = cn.Cn_ListarTablasMaestrasNotacredito().Copy
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

        Catch ex As Exception
            'clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub consultar()
        Try
            Dim obj As New coCtaPagar
            Dim ds As DataSet
            obj.Id = _codigo
            If listaids = 1 Then
                ds = cn.Cn_ObtenerDatosdeLAORDENventa(obj)
            Else
                ds = cn.Cn_ObtenerDatosdeLAORDEN(obj)
            End If

            ' Primer DataTable: Detalle de productos
            If ds.Tables.Count > 0 Then
                dtgListado.DataSource = ds.Tables(0)
            End If

            ' Segundo DataTable: Totales (total, igv, flete)
            If ds.Tables.Count > 1 Then
                Dim totales As DataTable = ds.Tables(1)
                If totales.Rows.Count > 0 Then
                    txttotal.Text = totales.Rows(0)("total").ToString()
                    txtigv.Text = totales.Rows(0)("igv").ToString()
                    txtsubtotal.Text = totales.Rows(0)("subtotal").ToString()
                    txtflete.Text = totales.Rows(0)("flete").ToString()
                End If
            End If

        Catch ex As Exception
            MsgBox("Error al consultar: " & ex.Message)
            Return
        End Try
    End Sub

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub

    Private Sub FrmNotaCredito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(500, 630)
        Me.KeyPreview = True
        ListarTablas()
        dtfecha.Value = Now.Date
        txtnombrecliente.Text = cliente
        txtseriereferente.Text = serie & "-" & correlativo
        txttiposervicio.Text = tiposervicio
        txtfechaemision.Text = emisión
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
        End If
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        consultar()
    End Sub
    Private Sub cbxtipodocumento_ValueChanged(sender As Object, e As EventArgs) Handles cbxtipodocumento.ValueChanged
        If cbxtipodocumento.Value IsNot Nothing AndAlso IsNumeric(cbxtipodocumento.Value) Then
            If CInt(cbxtipodocumento.Value) = 21 Then
                cbxtiponota.SelectedIndex = 0
            Else
                cbxtiponota.SelectedIndex = 2
            End If
        End If
    End Sub
    Private Sub cbxmoneda_ValueChanged(sender As Object, e As EventArgs) Handles cbxmoneda.ValueChanged
        Try
            If cbxmoneda.ActiveRow IsNot Nothing Then
                If cbxmoneda.ActiveRow.Cells.Count > 2 Then
                    txttc.Text = cbxmoneda.ActiveRow.Cells(2).Value.ToString
                Else
                    txttc.Text = String.Empty
                End If

            Else
                txttc.Text = String.Empty
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (txtobservacion.TextLength = 0) Then
                msj_advert("Ingrese una Observación")
                txtobservacion.Select()
                Return
            End If
            If cbxtiponota.SelectedIndex = 0 Then
                Dim importe As Decimal = 0
                Dim deuda As Decimal = 0
                Decimal.TryParse(txtimporte.Text, importe)
                Decimal.TryParse(txtdeuda.Text, deuda)
                If importe > deuda Then
                    msj_advert("El valor de la nota no puede ser mayor a la deuda.")
                    txtimporte.Select()
                    Return
                End If
            End If
            Dim obj As New coCtaPagar
            obj.Numdocreferencia = txtserie.Text & " - " & txtcorrelativo.Text
            obj.Total = txtimporte.Text
            obj.Fpago = dtfecha.Value
            obj.Comentario = cbxtiponota.Text & " - " & txtobservacion.Text
            obj.Estado = "ACT"
            obj.Idusuario = VP_IdUser
            obj.Tipocambio = txttc.Text
            obj.Idcuentapagar = _codigo
            obj.Idtipodocumento = cbxtipodocumento.Value
            obj.Idmoneda = cbxmoneda.Value
            obj.Serie = txtserie.Text
            obj.Correlativo = txtcorrelativo.Text
            If cbxtiponota.SelectedIndex = 0 Or cbxtiponota.SelectedIndex = 1 Then
                obj.Liquidado = 0
            Else
                obj.Liquidado = 1
            End If
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
            If listaids = 1 Then
                MensajeBgWk = cn.Cn_Mantenimientoajustecobrar(obj)
            Else
                MensajeBgWk = cn.Cn_Mantenimientoajuste(obj)
            End If

            If (obj.Coderror = 0) Then
                Dispose()

            Else
                msj_advert(MensajeBgWk)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CheckfotoPdf_CheckedChanged(sender As Object, e As EventArgs) Handles CheckfotoPdf.CheckedChanged
        If CheckfotoPdf.Checked Then
            Label25.Text = "Adjuntar Foto : "
        Else
            Label25.Text = "Adjuntar Archivo : "
        End If
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
                If cbxtiponota.SelectedIndex = 0 Then
                    ts = td - ti
                Else
                    ts = td + ti
                End If
                txtsaldo.Text = clsBasicas.FormatearComoDecimal(ts)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            e.Layout.Bands(0).Columns(0).Hidden = True
            e.Layout.Bands(0).Columns(5).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxtiponota_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxtiponota.SelectedIndexChanged
        If IsNumeric(cbxtiponota.SelectedIndex) Then
            If cbxtiponota.SelectedIndex = 0 Or cbxtiponota.SelectedIndex = 1 Then
                cbxtipodocumento.Value = 21
            Else
                cbxtipodocumento.Value = 22
            End If
        End If
    End Sub

    Private Sub cbxagregar_Click(sender As Object, e As EventArgs) Handles cbxagregar.Click

    End Sub
End Class