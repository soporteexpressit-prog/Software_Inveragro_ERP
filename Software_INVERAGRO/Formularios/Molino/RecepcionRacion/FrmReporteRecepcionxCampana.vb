Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Stimulsoft.Editor

Public Class FrmReporteRecepcionxCampana
    Dim cn As New cnControlRecepcionAlimento
    Dim ds As New DataSet

    Private Sub FrmReporteRecepcionxCampana_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Inicializar()
        clsBasicas.Formato_Tablas_Grid(dtgListadoPreparacionRacion)
        clsBasicas.Formato_Tablas_Grid(DtgListadoConsolidadoRacion)
        clsBasicas.LlenarComboAnios(CmbAnios)
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlantelesEngorde().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbUbicacion
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarCampañas()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        Dim obj As New coUbicacion With {
            .Codigo = CmbUbicacion.Value,
            .Anio = CmbAnios.Text
        }
        tb = cn.Cn_ListarCampañas(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbCampaña
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub CmbAnios_TextChanged(sender As Object, e As EventArgs) Handles CmbAnios.TextChanged
        If CmbAnios Is Nothing OrElse String.IsNullOrEmpty(CmbAnios.Text) Then
            Return
        End If
        ListarCampañas()
    End Sub

    Private Sub CmbUbicacion_ValueChanged(sender As Object, e As EventArgs) Handles CmbUbicacion.ValueChanged
        If CmbUbicacion Is Nothing OrElse CmbUbicacion.Value Is Nothing OrElse String.IsNullOrEmpty(CmbAnios.Text) Then
            Return
        End If
        ListarCampañas()
    End Sub

    Private Sub BloquearControles()
        GrupoFiltros.Enabled = False
        Ptbx_Cargando.Visible = True
        BarraOpciones.Enabled = False
    End Sub

    Private Sub DesbloquearControles()
        GrupoFiltros.Enabled = True
        Ptbx_Cargando.Visible = False
        BarraOpciones.Enabled = True
    End Sub


    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()

            Dim obj As New coControlRecepcionAlimento With {
                .IdUbicacion = CmbUbicacion.Value,
                .IdCampaña = CmbCampaña.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub


    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlRecepcionAlimento = CType(e.Argument, coControlRecepcionAlimento)

            ds = cn.Cn_ReporteRecepcionesxIdUbicacion(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns(1).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(1).ColumnMapping = MappingType.Hidden
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListadoPreparacionRacion.DataSource = ds.Tables(0)
            DtgListadoConsolidadoRacion.DataSource = ds.Tables(2)
            DesbloquearControles()
            Colorear()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If CmbCampaña.Value Is Nothing OrElse String.IsNullOrEmpty(CmbCampaña.Text) Then
            msj_advert("Seleccione una Campaña")
            Return
        End If
        Consultar()
    End Sub

    Sub Colorear()
        If (dtgListadoPreparacionRacion.Rows.Count > 0) Then
            Dim estado As Integer = 8

            'tipoAdquisicion
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.LightBlue, Color.Black, "ENTREGADO", estado)
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.LightGray, Color.Black, "PENDIENTE", estado)
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.Red, Color.White, "ANULADO", estado)

            'centrar columnas
            With dtgListadoPreparacionRacion.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub dtgListadoPreparacionRacion_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListadoPreparacionRacion.InitializeLayout
        Try
            If (dtgListadoPreparacionRacion.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListadoPreparacionRacion, e, 2)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgListadoConsolidadoRacion_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListadoConsolidadoRacion.InitializeLayout
        Try
            If (DtgListadoConsolidadoRacion.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(DtgListadoConsolidadoRacion, e, 0)
                clsBasicas.SumarTotales_Formato(DtgListadoConsolidadoRacion, e, 1)
                clsBasicas.SumarTotales_Formato(DtgListadoConsolidadoRacion, e, 2)
                clsBasicas.SumarTotales_Formato(DtgListadoConsolidadoRacion, e, 3)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            If (dtgListadoPreparacionRacion.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("RECEPCION POR CAMPAÑA", dtgListadoPreparacionRacion)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class