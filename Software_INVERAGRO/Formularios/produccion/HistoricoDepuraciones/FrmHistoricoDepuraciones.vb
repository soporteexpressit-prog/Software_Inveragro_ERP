Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmHistoricoDepuraciones
    Dim cnLote As New cnControlLoteDestete
    Public idPlantel As Integer = 0
    Dim tbtmp As New DataTable

    Private Sub FrmHistoricoDepuraciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarPlanteles()
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub BloquearControles()
        Ptbx_Cargando.Visible = True
        ToolStrip1.Enabled = False
        GrupoFiltros.Enabled = False
    End Sub

    Private Sub DesbloquearControles()
        Ptbx_Cargando.Visible = False
        ToolStrip1.Enabled = True
        GrupoFiltros.Enabled = True
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlanteles().Copy
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

    Sub Consultar()
        dtgListado.DataSource = Nothing
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If

        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()

            Dim obj As New coControlLoteDestete With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .IdPlantel = CmbUbicacion.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cnLote.Cd_ConsultarDepuracionHistorico(obj).Copy
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
            'Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estadoPdf As Integer = 11

            'estadoPdf
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "CON EVIDENCIA", estadoPdf)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "SIN EVIDENCIA", estadoPdf)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estadoPdf).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub BtnExportarHistoricoDepuracion_Click(sender As Object, e As EventArgs) Handles BtnExportarHistoricoDepuracion.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL-DEPURACION", dtgListado)
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

    Private Sub FrmHistoricoDepuraciones_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnBuscar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class