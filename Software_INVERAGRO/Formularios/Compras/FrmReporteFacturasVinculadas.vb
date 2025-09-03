Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmReporteFacturasVinculadas

    Dim cn As New cnIngreso
    Dim tbtmp As New DataTable
    Public idIngreso As Integer = 0
    Public operacion As Integer = 0

    Private Sub FrmReporteFacturasVinculadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Label1.Visible = False
            fechaperiodo.Visible = False
            If operacion = 1 Then
                Me.Text = "Reporte de Saldos Consumidos Vinculados"
                lbltitulo.Text = "Reporte de Saldos Consumidos Vinculados a la Cuenta"
            ElseIf operacion = 0 Then
                Me.Text = "Reporte de Facturas Vinculadas"
                lbltitulo.Text = "FACTURAS VINCULADAS A LA ÓRDEN DE COMPRA"
            ElseIf operacion = 2 Then
                Me.Text = "Reporte de Pagos de la Gratificación"
                lbltitulo.Text = "Reporte de Pagos de la Gratificación"
                Label1.Visible = True
                fechaperiodo.Visible = True
            ElseIf operacion = 3 Then
                Me.Text = "Reporte de Pagos de la Cts"
                lbltitulo.Text = "Reporte de Pagos de la Cts"
                Label1.Visible = True
                fechaperiodo.Visible = True
            End If
            Consultar()
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

            Dim obj As New coIngreso With {
                .Codigo = idIngreso,
                .Fechadesde = fechaperiodo.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coIngreso = CType(e.Argument, coIngreso)
            If operacion = 0 Then
                tbtmp = cn.Cn_ReporteFacturasVinculadas(obj).Copy
            ElseIf operacion = 1 Then
                tbtmp = cn.Cn_Reportesaldosconsumidosvinculados(obj).Copy
            ElseIf operacion = 2 Then
                tbtmp = cn.Cn_ReportePagosGratificacion(obj).Copy
            ElseIf operacion = 3 Then
                tbtmp = cn.Cn_ReportePagosCts(obj).Copy
            Else
                Throw New Exception("Operación no reconocida.")
            End If
            tbtmp.TableName = "tmp"
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
        End If
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        If dtgListado.Rows.Count = 0 Then
            msj_advert("No hay datos para exportar.")
            Return
        Else
            clsBasicas.ExportarExcel("FACTURAS VINCULADAS A LA ÓRDEN DE COMPRA", dtgListado)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Consultar()
    End Sub
End Class