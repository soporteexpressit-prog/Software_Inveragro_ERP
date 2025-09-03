Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmPedidoAlimentoCerdo
    Dim cn As New cnControlAlimento
    Dim ds As New DataSet

    Private Sub FrmPedidoAlimentoCerdo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Ptbx_Cargando.Visible = True
        cmbEstado.SelectedIndex = 0
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
    End Sub

    Sub Consultar(Optional ByVal fechaDesde As Date? = Nothing, Optional ByVal fechaHasta As Date? = Nothing)
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            btnBuscar.Enabled = False

            Dim obj As New coControlAlimento
            obj.Estado = cmbEstado.Text
            If fechaDesde.HasValue Then
                obj.FechaDesde = fechaDesde
            Else
                obj.FechaDesde = Nothing
            End If

            If fechaHasta.HasValue Then
                obj.FechaHasta = fechaHasta
            Else
                obj.FechaHasta = Nothing
            End If

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)

            ds = cn.Cn_ListarRequerimientoAlimento(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(1).ColumnMapping = MappingType.Hidden
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = ds.Tables(0)
            Colorear()
            btnBuscar.Enabled = True
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estado As Integer = 4
            Dim estadoAprobacion As Integer = 5
            Dim estadoPreparacion As Integer = 6
            Dim estadoRecepcion As Integer = 7

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", estado)

            'estadoAprobacion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "CANCELADO", estadoAprobacion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estadoAprobacion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "APROBADO", estadoAprobacion)

            'estadoPreparacion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightYellow, Color.Black, "PENDIENTE", estadoPreparacion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightSalmon, Color.Black, "PARCIAL", estadoPreparacion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.Black, "PREPARADO", estadoPreparacion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "CANCELADO", estadoPreparacion)

            'estadoRecepcion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "DESPACHADO", estadoRecepcion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.OrangeRed, Color.White, "SIN DESPACHO", estadoRecepcion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "PARCIAL", estadoRecepcion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "CANCELADO", estadoRecepcion)


            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoAprobacion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoPreparacion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoRecepcion).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportarrequealime.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REQUERIMIENTO DE ALIMENTOS CAPATAZ", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            If dtpFechaDesde.Value > dtpFechaHasta.Value Then
                msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
                Return
            End If

            Dim fechaDesde As Date? = dtpFechaDesde.Value
            Dim fechaHasta As Date? = dtpFechaHasta.Value
            Consultar(fechaDesde, fechaHasta)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class