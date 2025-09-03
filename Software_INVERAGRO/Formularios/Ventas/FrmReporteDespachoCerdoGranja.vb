Imports CapaNegocio
Imports CapaObjetos

Public Class FrmReporteDespachoCerdoGranja
    Dim cn As New cnVentas
    Dim tbtmp As New DataTable
    Public idUbicacion As Integer = 0
    Public operacion As Integer = 0
    Public flag As Boolean = False

    Private Sub FrmReportePesoCerdo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Ptbx_Cargando.Visible = True
            dtpFechaDesde.Value = Now.Date
            dtpFechaHasta.Value = Now.Date
            Consultar()

            If operacion = 1 Then
                Me.Text = "PEDIDOS DE VENTAS AGRUPADOS POR CLIENTE"
                Label6.Text = "PEDIDOS DE VENTAS AGRUPADOS POR CLIENTE"
            ElseIf operacion = 2 Then
                Me.Text = "DESPACHOS DE CERDOS DE GRANJA"
                Label6.Text = "DESPACHOS DE CERDOS DE GRANJA"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Consultar()
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If

        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            Dim obj As New coVentas With {
                .Fechadesde = dtpFechaDesde.Value,
                .Fechahasta = dtpFechaHasta.Value,
                .IdUbicacionOrigen = idUbicacion
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coVentas = CType(e.Argument, coVentas)
            If operacion = 0 Or operacion = 2 Then
                tbtmp = cn.Cn_ConsultarDespachoCerdoGranja(obj).Copy
            ElseIf operacion = 1 Then
                tbtmp = cn.Consultarpedidosventasagrupadoporcliente(obj)
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
            If flag Then
                dtgListado.DisplayLayout.Bands(0).Columns("Plantel").Hidden = True
            End If
            ToolStrip1.Enabled = True
        End If
    End Sub

    Private Sub BtnFiltros_Click(sender As Object, e As EventArgs) Handles BtnFiltros.Click
        Dim isFilterActive As Boolean = Not BtnFiltros.Checked
        BtnFiltros.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub BtnExportarhistoricomortalidad_Click(sender As Object, e As EventArgs) Handles BtnExportarhistoricomortalidad.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL PESOS CERDO DE VENTA", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                If operacion = 0 Or operacion = 2 Then
                    clsBasicas.Totales_Formato(dtgListado, e, 0)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 3)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
                ElseIf operacion = 1 Then
                    clsBasicas.Totales_Formato(dtgListado, e, 0)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
                    clsBasicas.DivisionTotales_Formato(dtgListado, e, 6, 5, 7)
                    clsBasicas.DivisionTotales_Formato(dtgListado, e, 9, 6, 8)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 9)
                End If

            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class