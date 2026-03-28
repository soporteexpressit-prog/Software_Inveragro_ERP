Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmReporteConsumoMaternidad
    Dim cn As New cnControlLoteDestete
    Public idUbicacion As Integer
    Dim tbtmp As New DataTable

    Private Sub FrmReporteConsumoMaternidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        GrupoFiltros.Enabled = False
        BarraNavegacion.Enabled = False
    End Sub


    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        GrupoFiltros.Enabled = True
        BarraNavegacion.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlLoteDestete With {
                .Anio = CmbAnios.Text,
                .IdPlantel = idUbicacion
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ReporteConsumoAlimentoMaternidad(obj).Copy
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
        End If
    End Sub

    Private Sub CmbAnios_TextChanged(sender As Object, e As EventArgs) Handles CmbAnios.TextChanged
        If CmbAnios Is Nothing OrElse String.IsNullOrEmpty(CmbAnios.Text) Then
            Return
        End If
        Consultar()
    End Sub

    Private Sub BtnExportarControlCerdacontrollotespro_Click(sender As Object, e As EventArgs) Handles BtnExportarControlCerdacontrollotespro.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE CONSUMO DE MATERNIDAD", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class