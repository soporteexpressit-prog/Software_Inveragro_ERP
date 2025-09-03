Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmReporteVentaCerdos

    Dim cn As New cnVentas
    Dim tbtmp As New DataTable
    Dim usuarioActivo As Integer = ActiveSessionId
    Public operacion As Integer = 0
    Private Sub FrmReporteVentaCerdos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarVendedores()
            ListarMotivoTransaccion()
            ListarTipoPeso()
            Consultar()
            ConsultarDirecto()
            Consultastock()
            clsBasicas.LlenarComboAnios(CmbAnios)
            clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListado)
            clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgresumengeneral)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Filtrar_Tabla(dtgresumengeneral, True)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Inicializar()
        Ptbx_Cargando.Visible = False
        lblSemana.Visible = False
        CbxSemana.Visible = False
        LblAnio.Visible = False
        CmbAnios.Visible = False
        dtpFechaDesde.Value = Date.Now
        dtpFechaHasta.Value = Date.Now
        CbxSemana.SelectedIndex = 0
        ChkSemana.Checked = False

    End Sub

    Sub ListarTipoPeso()
        Try
            Dim tb As New DataTable
            tb = cn.Cn_ListarTipoPeso().Copy
            tb.TableName = "tmp"
            tb.Columns(1).ColumnName = "Seleccione un Tipo de Peso"
            With CbxTipoPeso
                .DataSource = tb
                .DisplayMember = tb.Columns(1).ColumnName
                .ValueMember = tb.Columns(0).ColumnName
                If (tb.Rows.Count > 0) Then
                    .Value = tb.Rows(0)(0)
                End If
                .Enabled = True
                .DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Listartipoventa()
        Try
            Dim ds As New DataSet
            ds = cn.j_Cn_ListarTablasMaestrasPedidoVentaCerdo().Copy
            ds.DataSetName = "tmp"
            ds.Tables(0).Columns(1).ColumnName = "Seleccione una Moneda"

            Dim indice_tabla As Integer = 0
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

    Sub ListarMotivoTransaccion()
        Try
            Dim tb As New DataTable
            tb = cn.Cn_ListarMotivoTransaccionCerdos().Copy
            tb.TableName = "tmp"
            tb.Columns(1).ColumnName = "Seleccione un Motivo de Transacción"

            Dim filaInicial As DataRow = tb.NewRow()
            filaInicial(0) = 0
            filaInicial(1) = "ELIJA MOTIVO DE TRANSACCIÓN"
            tb.Rows.InsertAt(filaInicial, 0)
            With cbxmotivotransaccion
                .DataSource = tb
                .DisplayMember = tb.Columns(1).ColumnName
                .ValueMember = tb.Columns(0).ColumnName
                .Value = 0 ' Selecciona por defecto la opción "Elija Motivo de Transacción"
                .Enabled = True
                .DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarVendedores()
        Dim cn As New cnVentas
        Dim tb As New DataTable
        tb = cn.Cn_ListarVendedoresActivos().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Vendedor"

        ' Agregar fila inicial "Elija Vendedor"
        Dim filaInicial As DataRow = tb.NewRow()
        filaInicial(0) = 0
        filaInicial(1) = "ELIJA VENDEDOR"
        tb.Rows.InsertAt(filaInicial, 0)

        With CmbVendedor
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            .Value = 0 ' Selecciona por defecto la opción "Elija Vendedor"
            .Enabled = True
            .DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        End With
    End Sub

    Sub ConsultarDirecto()
        Try
            Dim obj As New coVentas With {
            .Fechadesde = dtpFechaDesde.Value,
            .Fechahasta = dtpFechaHasta.Value,
            .Idtipopeso = CbxTipoPeso.Value,
            .IdMotivoTransaccion = cbxmotivotransaccion.Value,
            .Semana = CbxSemana.SelectedItem.ToString(),
            .TipoFiltro = If(ChkSemana.Checked, 1, 0),
            .anio = CInt(CmbAnios.Text)
        }

            dtgresumengeneral.DataSource = cn.Cn_ReporteVentaresumen(obj).Copy
        Catch ex As Exception
            ' msj_advert("Error al cargar los datos resumen: " & ex.Message)
        End Try
    End Sub


    Sub Consultastock()
        Try

            Dim ds As DataSet = cn.Cn_Resumenstockmoyocha()
            If ds IsNot Nothing AndAlso ds.Tables.Count >= 2 Then
                ' Primera tabla: stock moyo
                If ds.Tables(0).Rows.Count > 0 Then
                    lblStockMoyo.Text = ds.Tables(0).Rows(0)("stock").ToString()
                Else
                    lblStockMoyo.Text = "0"
                End If

                ' Segunda tabla: stock chaca
                If ds.Tables(1).Rows.Count > 0 Then
                    lblStockChaca.Text = ds.Tables(1).Rows(0)("stock").ToString()
                Else
                    lblStockChaca.Text = "0"
                End If
            Else
                lblStockMoyo.Text = "0"
                lblStockChaca.Text = "0"
            End If

        Catch ex As Exception
            msj_advert("Error al cargar los datos resumen: " & ex.Message)
        End Try
    End Sub


    Sub Consultar()
        Try
            If Not BackgroundWorker1.IsBusy Then
                ToolStrip1.Enabled = False
                ToolStrip1.Enabled = True
                Dim obj As New coVentas With {
                    .Fechadesde = dtpFechaDesde.Value,
                    .Fechahasta = dtpFechaHasta.Value,
                    .Iduser = CmbVendedor.Value,
                    .NombreCliente = TxtNombreCliente.Text,
                    .IdMotivoTransaccion = cbxmotivotransaccion.Value,
                    .Semana = CbxSemana.SelectedItem.ToString(),
                    .TipoFiltro = If(ChkSemana.Checked, 1, 0),
                    .Idtipopeso = CbxTipoPeso.Value,
                    .anio = CInt(CmbAnios.Text)
                }
                If operacion = 1 Then
                    dtgListado.DataSource = cn.Cn_ReporteVentaCerdosconsolidadoIs(obj).Copy
                    dtgListado.DisplayLayout.Bands(0).Columns("codigo").Hidden = True
                    dtgListado.DisplayLayout.Bands(0).Columns("cant. Pedido").Hidden = True
                Else
                    dtgListado.DataSource = cn.Cn_ReporteVentaCerdosPorVendedor(obj).Copy
                End If
                Ptbx_Cargando.Visible = False
                BackgroundWorker1.RunWorkerAsync(obj)


            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If operacion = 1 Then
                clsBasicas.Totales_Formato(dtgListado, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
                clsBasicas.DivisionTotales_Formato(dtgListado, e, 7, 6, 8)
                clsBasicas.DivisionTotales_Formato(dtgListado, e, 10, 7, 9)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 10)
            Else
                clsBasicas.Totales_Formato(dtgListado, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 3)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
                clsBasicas.PromedioTotales_Formato(dtgListado, e, 7)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 8)
            End If
            e.Layout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            e.Layout.Bands(0).PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand)

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ChkSemana_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSemana.CheckedChanged
        If ChkSemana.Checked Then
            lblSemana.Visible = True
            CbxSemana.Visible = True
            LblAnio.Visible = True
            CmbAnios.Visible = True
            lblFechaDesde.Visible = False
            dtpFechaDesde.Visible = False
            lblFechaHasta.Visible = False
            dtpFechaHasta.Visible = False
        Else
            lblSemana.Visible = False
            CbxSemana.Visible = False
            LblAnio.Visible = False
            CmbAnios.Visible = False
            lblFechaDesde.Visible = True
            dtpFechaDesde.Visible = True
            lblFechaHasta.Visible = True
            dtpFechaHasta.Visible = True
        End If
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Ptbx_Cargando.Visible = True
        ConsultarDirecto()
        Consultar()
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        If dtgListado.Rows.Count = 0 Then
            msj_advert("No hay datos para exportar.")
            Return
        Else
            clsBasicas.ExportarExcel("REPORTE DE VENTAS DE CERDOS POR VENDEDOR", dtgListado)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
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

    Private Sub dtgresumengeneral_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgresumengeneral.InitializeLayout
        Try
            clsBasicas.Totales_Formato(dtgresumengeneral, e, 0)
            clsBasicas.SumarTotales_Formato(dtgresumengeneral, e, 4)

            e.Layout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            e.Layout.Bands(0).PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            Dim frm As New FrmVerGuiaAsociadaVenta
            frm.operacion = 1
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            Dim frm As New FrmVerGuiaAsociadaVenta
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class