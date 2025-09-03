Imports CapaNegocio
Imports CapaObjetos

Public Class FrmReporteSistema

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnreportemovimientosalmacen.Click
        ImprimirReporteAlmacen()
    End Sub
    Sub ImprimirReporteAlmacen()
        Dim cn As New cnControlIncidencia
        Dim obj As New coControlincidencia
        Dim dsCapacitacion As New DataSet
        obj.FechaDesde = dtpFechaDesde.Value
        obj.FechaHasta = dtpFechaHasta.Value
        dsCapacitacion = cn.Cn_Consultaralmacen(obj).Copy

        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_MovimientosAlmacen.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnstockalmacen_Click(sender As Object, e As EventArgs) Handles btnstockalmacen.Click
        Imprimirlistaproductos()
    End Sub
    Sub Imprimirlistaproductos()
        Dim cn As New cnControlIncidencia
        Dim obj As New coControlincidencia
        Dim dsCapacitacion As New DataSet
        obj.FechaDesde = dtpFechaDesde.Value
        obj.FechaHasta = dtpFechaHasta.Value
        dsCapacitacion = cn.Cn_Consultarlistaproductos(obj).Copy

        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_ListaproductosAlmacen.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnmovimientocontabilidad_Click(sender As Object, e As EventArgs) Handles btnmovimientocontabilidad.Click
        ImprimirReporteContabilidad()
    End Sub

    Sub ImprimirReporteContabilidad()
        Dim cn As New cnControlIncidencia
        Dim obj As New coControlincidencia
        Dim dsCapacitacion As New DataSet
        obj.FechaDesde = dtpFechaDesde.Value
        obj.FechaHasta = dtpFechaHasta.Value
        dsCapacitacion = cn.Cn_ConsultarreporteContabilidad(obj).Copy

        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_MovimientoContabilidad.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnreportegeneral_Click(sender As Object, e As EventArgs) Handles btnreportegeneral.Click
        ImprimirReportegeneralContabilidad()
    End Sub
    Sub ImprimirReportegeneralContabilidad()
        Dim cn As New cnControlIncidencia
        Dim obj As New coControlincidencia
        Dim dsCapacitacion As New DataSet
        obj.FechaDesde = dtpFechaDesde.Value
        obj.FechaHasta = dtpFechaHasta.Value
        dsCapacitacion = cn.Cn_ConsultarreporteContabilidadgeneral(obj).Copy

        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_GeneralContabilidad.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnreporterrhh_Click(sender As Object, e As EventArgs) Handles btnreporterrhh.Click
        ImprimirReportegeneralRrhhd()
    End Sub
    Sub ImprimirReportegeneralRrhhd()
        Dim cn As New cnControlIncidencia
        Dim obj As New coControlincidencia
        Dim dsCapacitacion As New DataSet
        obj.FechaDesde = dtpFechaDesde.Value
        obj.FechaHasta = dtpFechaHasta.Value
        dsCapacitacion = cn.Cn_Consultarreporterrhhgeneral(obj).Copy

        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_ReporteGeneraldeRrhh.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btn.Click
        ImprimirReportegeneralcompras()
    End Sub

    Sub ImprimirReportegeneralcompras()
        Dim cn As New cnControlIncidencia
        Dim obj As New coControlincidencia
        Dim dsCapacitacion As New DataSet
        obj.FechaDesde = dtpFechaDesde.Value
        obj.FechaHasta = dtpFechaHasta.Value
        dsCapacitacion = cn.Cn_Consultarreportecomprasgeneral(obj).Copy

        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_ReporteGeneralCompras.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TsBtn_Cerrar_Click_1(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub

    Private Sub BtnReporteTotal_Click(sender As Object, e As EventArgs) Handles BtnReporteTotal.Click
        Dim cn As New cnControlIncidencia
        Dim obj As New coControlincidencia
        Dim reporteTablas As New DataSet
        obj.FechaDesde = dtpFechaDesde.Value
        obj.FechaHasta = dtpFechaHasta.Value
        reporteTablas = cn.Cn_ConsultaTotalModuloSistema(obj).Copy

        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_TotalModulosSistema.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(reporteTablas)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class