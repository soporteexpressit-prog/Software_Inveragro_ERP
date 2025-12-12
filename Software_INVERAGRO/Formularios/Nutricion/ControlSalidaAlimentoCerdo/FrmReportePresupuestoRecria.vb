Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmReportePresupuestoRecria
    Dim cn As New cnControlAlimento
    Public idUbicacion As Integer = 0
    Dim ds As New DataSet
    Dim tbtmp As New DataTable

    Private Sub FrmReportePresupuestoRecria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        CmbEstado.SelectedIndex = 0
        dtpFechaDesde.Value = Date.Now
        dtpFechaHasta.Value = Date.Now
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        GrupoFiltros.Enabled = False
        BarraNavegacion.Enabled = False
        BtnBuscar.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        GrupoFiltros.Enabled = True
        BarraNavegacion.Enabled = True
        BtnBuscar.Enabled = True
    End Sub

    Sub Consultar()
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlAlimento With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .Estado = CmbEstado.Text,
                .Tipo = If(RbtDetallado.Checked, "NORMAL", "CONSOLIDADO"),
                .IdUbicacion = idUbicacion,
                .Anio = CInt(CmbAnios.Text)
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub


    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)

            ds = cn.Cn_ReporteConsumoPresupuestoRecria(obj).Copy
            ds.DataSetName = "tmp"

            ' Solo crear la relación si hay 2 tablas (modo NORMAL/DETALLADO)
            If ds.Tables.Count > 1 Then
                Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
                ds.Relations.Add(relation1)
                ds.Tables(0).Columns(0).ColumnMapping = MappingType.Hidden
                ds.Tables(1).Columns(0).ColumnMapping = MappingType.Hidden
            End If

            ' Ocultar columna Estado si existe en la primera tabla
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Columns.Contains("Estado") Then
                ds.Tables(0).Columns("Estado").ColumnMapping = MappingType.Hidden
                ds.Tables(1).Columns("Estado").ColumnMapping = MappingType.Hidden
            End If

            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = Nothing
            dtgListado.Refresh()
            dtgListado.DataSource = ds.Tables(0)
            DesbloquearControladores()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub

    Private Sub RbtConsolidado_CheckedChanged(sender As Object, e As EventArgs) Handles RbtConsolidado.CheckedChanged
        If RbtConsolidado.Checked Then
            LblPeriodoLote.Visible = False
            CmbAnios.Visible = False
        Else
            LblPeriodoLote.Visible = True
            CmbAnios.Visible = True
        End If
    End Sub

    Private Sub BtnExportarNutricionSaalice_Click(sender As Object, e As EventArgs) Handles BtnExportarNutricionSaalice.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONSUMO PRESUPUESTO RECRIA", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class