Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmIngresoCuenta
    Dim cn As New cnCtaCobrar
    Dim ds As New DataSet
    Public operacion As Integer
    Public codigo As Integer
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
                    .Value = 1
                End If
            End With

            ' Cargar Forma de Pago
            indice_tabla += 1
            Dim dv As New DataView(ds.Tables(indice_tabla))

            '' Aplicar el filtro para que no muestre los registros con idformapago = 1
            'If (_idcuota <> 0) Then
            '    dv.RowFilter = "idformapago <> 1"
            'End If


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

            With cbxcondicionpago
                .DataSource = ds.Tables(5)
                .DisplayMember = ds.Tables(5).Columns(1).ColumnName
                .ValueMember = ds.Tables(5).Columns(0).ColumnName
                If (ds.Tables(5).Rows.Count > 0) Then
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
        Me.Size = New Size(500, 614)
        ListarTablas()
        If operacion = 1 Then
            Consultar()
            btnActualizar.Visible = True
            btnGuardar.Visible = False
        Else
            dtfecha.Value = Now.Date
            btnActualizar.Visible = False
            btnGuardar.Visible = True
        End If
        Me.KeyPreview = True
        txtcuenta.ReadOnly = True
        txtcuenta.TabStop = False
        txtcodcuenta.ReadOnly = True
        txtcodcuenta.TabStop = False
        txtcodproveedor.ReadOnly = True
        txtcodproveedor.TabStop = False
        txtproveedor.ReadOnly = True
        txtproveedor.TabStop = False
        txtArchivoRuta.ReadOnly = True
        txtArchivoRuta.TabStop = False

        ' Opcional: Ajusta el TabIndex si es necesario, pero lo usaremos solo para referencia
        btnbuscarpoveedor.TabIndex = 0
        btnbuscarpoveedor.TabStop = True
        ckliquidado.TabIndex = 1
        ckliquidado.TabStop = True
        dtfecha.TabIndex = 2
        dtfecha.TabStop = True
        cbxcondicionpago.TabIndex = 3
        cbxcondicionpago.TabStop = True
        btncuentacontable.TabIndex = 4
        btncuentacontable.TabStop = True
        cbxtipodocumento.TabIndex = 5
        cbxtipodocumento.TabStop = True
        cbxformapago.TabIndex = 6
        cbxformapago.TabStop = True
        txtnumdocreferencia.TabIndex = 7
        txtnumdocreferencia.TabStop = True
        cbxmoneda.TabIndex = 8
        cbxmoneda.TabStop = True
        txttc.TabIndex = 9
        txttc.TabStop = True
        cbxbanco_destino.TabIndex = 10
        cbxbanco_destino.TabStop = True
        CheckfotoPdf.TabIndex = 11
        CheckfotoPdf.TabStop = True
        btnarchivoadjunto.TabIndex = 12
        btnarchivoadjunto.TabStop = True
        txtimporte.TabIndex = 13
        txtimporte.TabStop = True
        txtobservacion.TabIndex = 14
        txtobservacion.TabStop = True


    End Sub
    Sub Consultar()
        Try
            Dim obj As New coCtaCobrar With {
                .Id = codigo
            }

            Dim dt As DataTable = cn.Cn_consultarxidcobrarEDITAR(obj)

            If dt.Rows.Count > 0 Then
                Dim fila As DataRow = dt.Rows(0) ' Tomar la primera fila del resultado

                txtcodproveedor.Text = fila("codigo").ToString()
                txtproveedor.Text = fila("datos").ToString()
                dtfecha.Value = fila("fInicioCredito").ToString()
                cbxcondicionpago.Value = fila("idcondicionpago").ToString()
                txtcodcuenta.Text = fila("idplancuenta").ToString()
                txtcuenta.Text = fila("planCuenta").ToString()
                cbxtipodocumento.Value = Convert.ToInt32(fila("idtipodocumento"))
                txtnumdocreferencia.Text = fila("codReferencia").ToString()
                cbxmoneda.Value = fila("idmoneda").ToString()
                txttc.Text = fila("tipocambio").ToString()
                txtimporte.Text = fila("total").ToString()
                txtobservacion.Text = fila("observacion").ToString()
            Else
                MessageBox.Show("No se encontraron datos para el transporte seleccionado.", "Consultar Transporte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar los datos del transporte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FrmCotizacion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' Verifica si se presionan Control y Espacio al mismo tiempo
        If e.Control AndAlso e.KeyCode = Keys.Space Then
            btnGuardar.PerformClick()  ' Ejecuta el clic del botón
        End If
    End Sub
    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
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
                obj.Idctabancodestino = cbxbanco_destino.ActiveRow.Cells(3).Value.ToString
                obj.Idtipodocumento = cbxtipodocumento.Value
                obj.Idmoneda = cbxmoneda.Value
                obj.Liquidado = IIf(ckliquidado.Checked, 1, 0)
                obj.Iddestino = txtcodproveedor.Text
                obj.Idcondicionpago = cbxcondicionpago.Value
                obj.Idcuentapagar = txtcodcuenta.Text
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
                MensajeBgWk = cn.Cn_CrearCuentaCobrar(obj)

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
                txttc.ReadOnly = False
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
                    Label2.Visible = False
                    txtnumdocreferencia.Visible = False
                    Label8.Visible = False
                    cbxmoneda.Visible = False
                    Label23.Visible = False
                    txttc.Visible = False


                Else
                    lblbancodestino.Visible = True
                    cbxbanco_destino.Visible = True
                    Label2.Visible = True
                    txtnumdocreferencia.Visible = True
                    Label8.Visible = True
                    cbxmoneda.Visible = True
                    Label23.Visible = True
                    txttc.Visible = True

                End If
                If cbxformapago.ActiveRow.Cells(0).Value.ToString = "7" Then

                    cbxmoneda.Enabled = True
                    txttc.Enabled = True
                Else

                    cbxmoneda.Enabled = True
                    txttc.Enabled = True
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


    Private Sub btnbuscarpoveedor_Click(sender As Object, e As EventArgs) Handles btnbuscarpoveedor.Click
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
            ElseIf (cbxtipodocumento.Value Is Nothing OrElse IsDBNull(cbxtipodocumento.Value) OrElse cbxtipodocumento.Value = 0) Then
                msj_advert("Seleccione un Tipo de documento")
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
                obj.Idctabancoorigen = cbxbanco_origen.ActiveRow.Cells(3).Value.ToString
                obj.Idctabancodestino = cbxbanco_destino.ActiveRow.Cells(3).Value.ToString
                obj.Idtipodocumento = cbxtipodocumento.Value
                obj.Idmoneda = cbxmoneda.Value
                obj.Liquidado = IIf(ckliquidado.Checked, 1, 0)
                obj.Iddestino = txtcodproveedor.Text
                obj.Idcondicionpago = cbxcondicionpago.Value
                obj.Idcuentapagar = txtcodcuenta.Text
                obj.Id = codigo
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_RegNuevaCuentaCobraractualizar(obj)

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

    Private Sub CheckfotoPdf_CheckedChanged(sender As Object, e As EventArgs) Handles CheckfotoPdf.CheckedChanged
        If CheckfotoPdf.Checked Then
            Label25.Text = "Adjuntar Foto : "
        Else
            Label25.Text = "Adjuntar Archivo : "
        End If
    End Sub
End Class