Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports System.IO
Public Class FrmCuentasCobrar
    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportarctcc.Click
        clsBasicas.ExportarExcel("Cuentas por Cobrar", dtgListado)
    End Sub
    Private _estado As String
    Private _estadoliquidado As String
    Private _idpersona As Integer
    Private _idfechas As Integer
    Dim cn As New cnCtaCobrar

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
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coCtaCobrar
            obj.Fdesde = dtpFechaDesde.Value
            obj.Fhasta = dtpFechaHasta.Value
            obj.Estado = _estado
            obj.estadoliquidado = _estadoliquidado
            obj.Idpersona = _idpersona
            obj.Id = _idfechas
            obj.Idusuario = GlobalReferences.ActiveSessionId
            ' Simplified ComboBox value handling
            If cbxbancodestino.InvokeRequired Then
                obj.Iddestino = CInt(cbxbancodestino.Invoke(Function() cbxbancodestino.SelectedValue))
            Else
                obj.Iddestino = CInt(cbxbancodestino.SelectedValue)
            End If
            ds = New DataSet
            ds = cn.Cn_ConsultarCtasCobrar(obj).Copy
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
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "VENCIDO", 20)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "NORMAL", 20)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "NO", 13)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "SI", 13)
            ToolStrip1.Enabled = True
        End If
    End Sub

    Private Sub FrmCuentasPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = Windows.Forms.FormWindowState.Maximized
        clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListado)
        cbxestado.SelectedIndex = 1
        cbxliquidado.SelectedIndex = 0
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        ToolStripButton1.Checked = True
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        ListarTablas()
        Consultar()
    End Sub

    Private Sub cktodods_CheckedChanged(sender As Object, e As EventArgs) Handles cktodods.CheckedChanged
        txtcodproveedor.Clear()
        txtproveedor.Clear()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If cktodods.Checked = False AndAlso txtcodproveedor.Text.Length = 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
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
                .Columns(19).Hidden = True
                .Columns(18).Hidden = True

                .Columns(9).CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Columns(9).CellAppearance.FontData.SizeInPoints = 8

                .Columns(10).CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Columns(10).CellAppearance.FontData.SizeInPoints = 8

                .Columns(11).CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                .Columns(11).CellAppearance.FontData.SizeInPoints = 8
                .Columns(3).Width = 80
                .Columns(4).Width = 80
                .Columns(21).Header.VisiblePosition = 9
                .Columns(22).Header.VisiblePosition = 15
            End With
            With e.Layout.Bands(1)
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True

                .Columns(15).Header.Caption = "Ver Archivo"
                .Columns(15).Width = 60
                .Columns(15).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(15).CellButtonAppearance.Image = My.Resources.adjuntar
                .Columns(15).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always

                .Columns(17).Header.Caption = "Ver Detalle Abono"
                .Columns(17).Width = 60
                .Columns(17).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(17).CellButtonAppearance.Image = My.Resources.ver24px
                .Columns(17).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always

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
    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            With dtgListado
                If (e.Cell.Column.Key = "btnver") Then


                    ' Obtener el ID del detalle
                    Dim idDetalleCuentaCobrar As Integer = CInt(.ActiveRow.Cells(0).Value)

                    ' Obtener el archivo y el tipo de imagen_pdf (1 = imagen, 0 = PDF)
                    Dim resultado = cn.Cn_ObtenerArchivo(idDetalleCuentaCobrar)
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
                        msj_advert("No se encontró el archivo en la base de datos.")
                    End If
                End If

                If (e.Cell.Column.Key = "btnverdetalle") Then
                    ' Obtener el ID del detalle
                    Dim idDetalleCuentaCobrar As Integer = CInt(.ActiveRow.Cells(0).Value)
                    Dim f As New FrmCuentaPagarSelecionar()
                    f.codproveedor = idDetalleCuentaCobrar
                    f.operacion = 1
                    f.ShowDialog()
                End If

            End With
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub


    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagarctcc.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            If (activeRow.Cells(13).Value.ToString.Equals("SI")) Then
                msj_advert("La cuenta ya fue liquidada")
            Else

                Dim f As New FrmAbonarCuentaCobrar
                f._codigo = CInt(activeRow.Cells(0).Value.ToString)
                f._fechaemision = (activeRow.Cells(6).Value.ToString)
                f._deuda = clsBasicas.FormatearComoDecimal(activeRow.Cells(11).Value.ToString)
                f.txtdeuda.Text = clsBasicas.FormatearComoDecimal(activeRow.Cells(11).Value.ToString)
                f._codmoneda = activeRow.Cells(18).Value.ToString
                f.ShowDialog()


                Consultar()
            End If

        Catch ex As Exception
            msj_advert("Seleccione un Registro Correcto")
        End Try
    End Sub



    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim f As New FrmBuscarClientes
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


    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2ctcc.Click
        Try
            Dim f As New FrmIngresoCuenta
            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If ToolStripButton2.Checked Then
            ' Si está marcado, restauramos la vista de agrupamiento
            dtgListado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
            dtgListado.DisplayLayout.GroupByBox.Hidden = False
        Else
            ' Si no está marcado, cambiamos a la vista horizontal y ocultamos el GroupByBox
            dtgListado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal
            dtgListado.DisplayLayout.GroupByBox.Hidden = True
            dtgListado.DisplayLayout.Bands(0).SortedColumns.Clear() ' Eliminar agrupamiento y orden
        End If

        ' Alternar el estado de ToolStripButton2
        ToolStripButton2.Checked = Not ToolStripButton2.Checked
    End Sub

    Private Sub btneditarclientecuentacobrarcontabilidad_Click(sender As Object, e As EventArgs) Handles btneditarclientecuentacobrarcontabilidad.Click
        If dtgListado.ActiveRow IsNot Nothing Then
            Dim filaSeleccionada = dtgListado.ActiveRow ' Obtener la fila activa
            Dim f As New FrmEditarclienteBanco With {
            .codigo = filaSeleccionada.Cells(0).Value ' Valor de la primera columna
        }
            If f.ShowDialog() = DialogResult.OK Then
                Consultar()
            End If
        Else
            MessageBox.Show("Por favor, seleccione una fila para editar.", "Editar Transporte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Consultar()
    End Sub

    Private Sub btnanularcontabilidad_Click(sender As Object, e As EventArgs) Handles btnanularcontabilidad.Click
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
            Dim f As New FrmAnulaCtaCobrar
            f.codcta = activeRow.Cells(0).Value.ToString
            f.ShowDialog()
            Consultar()

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btneditarModucontabiidad_Click(sender As Object, e As EventArgs) Handles btneditarModucontabiidad.Click
        Try
            Dim filaSeleccionada = dtgListado.ActiveRow ' Obtener la fila activa
            Dim f As New FrmIngresoCuenta

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

    Private Sub btnPagarctcp_Click(sender As Object, e As EventArgs) Handles btnPagarctcp.Click
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
                        f.listaids = 1
                        f._deuda = clsBasicas.FormatearComoDecimal(activeRow.Cells(11).Value.ToString)
                        f.txtdeuda.Text = clsBasicas.FormatearComoDecimal(activeRow.Cells(11).Value.ToString)
                        f._codmoneda = activeRow.Cells(18).Value.ToString
                        f._tiposervicio = activeRow.Cells(1).Value.ToString
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

    Private Sub btndetallesaldofavor_Click(sender As Object, e As EventArgs) Handles btndetallesaldofavor.Click
        Try
            Dim frm As New FrmReporteFacturasVinculadas
            frm.idIngreso = dtgListado.ActiveRow.Cells(0).Value
            frm.operacion = 1
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class