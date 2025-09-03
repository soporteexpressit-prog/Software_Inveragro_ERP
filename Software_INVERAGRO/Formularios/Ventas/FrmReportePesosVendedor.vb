Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmReportePesosVendedor
    Dim cn As New cnVentas
    Dim tbtmp As New DataTable
    Dim usuarioActivo As Integer = ActiveSessionId
    Private _codigo As String


    Private Sub FrmReportePesosVendedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtpFechaDesde.Value = Date.Now
            dtpFechaHasta.Value = Date.Now
            ListarVendedores()
            ListarTipoPesos()
            Consultar()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtglistadopesos)
            clsBasicas.Filtrar_Tabla(dtglistadopesos, True)
            Dim dtVacio As New DataTable()
            dtVacio.Columns.Add("Codigo") ' Cambia los nombres y cantidad de columnas según tu estructura
            dtVacio.Columns.Add("idsalida")
            dtVacio.Columns.Add("Peso")
            dtVacio.Columns.Add("Conteo")
            dtglistadopesos.DataSource = dtVacio
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
        With CmbVendedor
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            ' Buscar si el usuarioActivo coincide con un idPersona en la tabla
            Dim rowUsuario = tb.Select("idPersona = " & usuarioActivo).FirstOrDefault()

            If rowUsuario IsNot Nothing AndAlso (usuarioActivo = 94 OrElse usuarioActivo = 152) Then
                .Value = usuarioActivo
                .Enabled = False
                .DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
            ElseIf tb.Rows.Count > 0 Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub
    Sub Consultarpesos()
        Dim obj As New coVentas
        Dim cn As New cnVentas
        obj.Codigo = _codigo
        Dim ds As New DataSet
        ds = cn.Cn_ConsultarPesosGancho(obj).Copy
        dtglistadopesos.DataSource = ds

        Dim total As Decimal = 0
        Dim conteo As Decimal = 0

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtglistadopesos.Rows
            If Not row.Cells(2).Value Is Nothing AndAlso IsNumeric(row.Cells(2).Value) Then
                total += Convert.ToDecimal(row.Cells(2).Value)
                conteo += Convert.ToDecimal(row.Cells(3).Value)
            End If
        Next

        txttotalpesogancho.Text = total.ToString("F2")
        txtnumcerdos.Text = conteo.ToString("F0")


        If dtglistadopesos.Rows.Count > 0 Then
            txtpesopromedio.Text = (total / conteo).ToString("F2")
        Else
            txtpesopromedio.Text = "0.0000"
        End If

    End Sub
    Sub ListarTipoPesos()
        Try
            Dim ds As New DataSet
            Dim cn As New cnVentas
            ds = cn.Cn_ListarTablasMaestrasFacturacion().Copy
            ds.DataSetName = "tmp"
            ds.Tables(0).Columns(1).ColumnName = "Seleccione una Moneda"

            Dim indice_tabla As Integer = 0
            indice_tabla = 5
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Seleccione un Tipo de Peso Final"
            With CmbTipoPeso
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

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            Dim obj As New coVentas With {
                .Fechadesde = dtpFechaDesde.Value,
                .Fechahasta = dtpFechaHasta.Value,
                .Iduser = CmbVendedor.Value,
                .Idtipopeso = CmbTipoPeso.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coVentas = CType(e.Argument, coVentas)
            tbtmp = cn.Cn_ReportePesosPorVendedor(obj).Copy
            tbtmp.TableName = "tmp"
            tbtmp.Columns("idSalida").ColumnMapping = MappingType.Hidden
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            ToolStrip1.Enabled = True
            Colorear()
        End If
    End Sub


    Private Sub dtgListado_AfterRowActivate(sender As Object, e As EventArgs) Handles dtgListado.AfterRowActivate
        Try
            If dtgListado.ActiveRow IsNot Nothing AndAlso Not dtgListado.ActiveRow.IsFilterRow Then
                _codigo = dtgListado.ActiveRow.Cells(0).Value.ToString()
                Consultarpesos()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim motivoTransaccion As Integer = 6

            'colorear segun clave
            clsBasicas.Colorear_SegunClave(dtgListado, Color.Green, Color.White, "CERDO", motivoTransaccion)
            clsBasicas.Colorear_SegunClave(dtgListado, Color.Orange, Color.White, "CERDOS DE EMERGENCIA", motivoTransaccion)
            clsBasicas.Colorear_SegunClave(dtgListado, Color.LightGreen, Color.White, "CHANCHILLAS", motivoTransaccion)
            clsBasicas.Colorear_SegunClave(dtgListado, Color.Yellow, Color.White, "MARRANAS", motivoTransaccion)
            clsBasicas.Colorear_SegunClave(dtgListado, Color.DarkViolet, Color.White, "VERRACOS", motivoTransaccion)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(motivoTransaccion).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        If dtgListado.Rows.Count = 0 Then
            msj_advert("No hay datos para exportar.")
            Return
        Else
            clsBasicas.ExportarExcel("REPORTE DE PESOS POR VENDEDOR", dtgListado)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub UltraGrid1_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtglistadopesos.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(1).Hidden = True
                .Columns(0).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            ' Autoajustar cada columna al contenido
            For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                ' Ajusta al valor más largo entre encabezado y celdas visibles
                col.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
            Next
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub



End Class