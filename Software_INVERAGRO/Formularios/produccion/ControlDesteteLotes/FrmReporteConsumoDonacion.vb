Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmReporteConsumoDonacion
    Dim cn As New cnControlLoteDestete
    Dim tbtmp As New DataTable
    Dim search As Boolean = False

    Private Sub FrmReporteConsumoDonacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.LlenarComboAnios(CmbAnios)
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        Ptbx_Cargando.Visible = True
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Filtrar_Tabla(dtgListado, True)
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        CmbAnios.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        CmbAnios.Enabled = True
        ToolStrip1.Enabled = True
    End Sub

    Sub Consultar()
        BloquearControladores()
        If Not BackgroundWorker1.IsBusy Then

            Dim obj As New coControlLoteDestete With {
                .Anio = CmbAnios.Text
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ConsultarConsumoDonacion(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DesbloquearControladores()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            search = True
        End If
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs)
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE DE CONSUMO Y DONACIÓN", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CmbAnios_TextChanged(sender As Object, e As EventArgs) Handles CmbAnios.TextChanged
        If search Then
            Consultar()
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 0)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 4)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub
End Class