Imports CapaNegocio
Imports CapaObjetos

Public Class FrmVerGuiaAsociadaVenta

    Public operacion As Integer = 0
    Dim cn As New cnVentas
    Dim tbtmp As New DataSet
    Dim ds As New DataSet

    Private Sub FrmVerGuiaAsociadaVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If operacion = 1 Then
                Me.Text = "Reporte de ventas por Kilos"
                lbltitulo.Text = "Reporte de ventas por Kilos"
            Else
                Consultar()
            End If
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            Dim obj As New coVentas With {
                .Fechadesde = fechadesde.Value,
                .Fechahasta = fechahasta.Value
            }
            If operacion = 1 Then
                dtgListado.DataSource = cn.Cn_Reporteventaskilos(obj).Copy
            Else
                dtgListado.DataSource = cn.Cn_ReporteGuiasAsociadasVenta(obj).Copy
            End If
            Ptbx_Cargando.Visible = False
            ToolStrip1.Enabled = True
        End If
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        If dtgListado.Rows.Count = 0 Then
            msj_advert("No hay datos para exportar.")
            Return
        Else
            clsBasicas.ExportarExcel("REPORTE DE GUÍAS ASOCIADAS A LA VENTA", dtgListado)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        clsBasicas.Totales_Formato(dtgListado, e, 0)

        If operacion = 1 Then
            clsBasicas.Colorear_SegunValor(dtgListado, Color.DarkViolet, Color.White, "VENTA POR KILOS", 0)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Blue, Color.White, "CONSUMO INTERNO", 0)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 2)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 4)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
        Else
            clsBasicas.SumarTotales_Formato(dtgListado, e, 3)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
            clsBasicas.PromedioTotales_Formato(dtgListado, e, 7)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 8)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "MUERTE IRRECUPERABLE", 0)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Yellow, Color.Black, "VENTA CONDUCTOR", 0)
        End If
    End Sub
End Class