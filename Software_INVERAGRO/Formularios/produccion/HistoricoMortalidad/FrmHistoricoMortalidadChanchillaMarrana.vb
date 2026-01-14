Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmHistoricoMortalidadChanchillaMarrana
    Dim cn As New cnControlAnimal
    Dim tbtmp As New DataTable
    Dim ds As New DataSet
    Public tipoHembra As String
    Public idUbicacion As Integer

    Private Sub FrmHistoricoMortalidadChanchillaMarrana_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        LblTitle.Text = "HISTÓRICO DE MORTALIDAD - " & tipoHembra.ToUpper
        Me.KeyPreview = True
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub BloquearControles()
        Ptbx_Cargando.Visible = True
        BarraNavegacion.Enabled = False
        GrupoFiltros.Enabled = False
    End Sub

    Private Sub DesbloquearControles()
        Ptbx_Cargando.Visible = False
        BarraNavegacion.Enabled = True
        GrupoFiltros.Enabled = True
    End Sub

    Sub Consultar()
        dtgListado.DataSource = Nothing
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If

        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()

            Dim obj As New coControlAnimal With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .IdPlantel = idUbicacion,
                .TipoControl = tipoHembra
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            tbtmp = cn.Cn_ConsultarMortalidadChanchillasMarranas(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DesbloquearControles()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            dtgListado.DisplayLayout.Bands(0).Columns("idControlFicha").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Estado Evidencia").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Ver Evidencia").Hidden = True
        End If
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub

    Private Sub BtnExportarhistoricomortalidad_Click(sender As Object, e As EventArgs) Handles BtnExportarhistoricomortalidad.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL-MORTALIDAD" + "_" + tipoHembra, dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class