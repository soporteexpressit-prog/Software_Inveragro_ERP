Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Olap.Core.Data
Imports Infragistics.Win

Public Class FrmHistoricoDestete
    Dim cn As New cnControlAnimal
    Dim ds As New DataSet
    Public idUbicacion As Integer = 0

    Private Sub FrmHistoricoDestete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        Ptbx_Cargando.Visible = True
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        GrupoFiltros.Enabled = False
        BarraOpciones.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        GrupoFiltros.Enabled = True
        BarraOpciones.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlAnimal With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .IdPlantel = idUbicacion
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            ds = cn.Cn_ConsultarHistoricoDestete(obj).Copy
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DesbloquearControladores()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            Dim dsResult As DataSet = CType(e.Result, DataSet)
            dtgListado.DataSource = dsResult.Tables(0)
            dtgListado.DisplayLayout.Bands(0).Columns("idControlFicha").Hidden = True

            If dsResult.Tables.Count > 1 AndAlso dsResult.Tables(1).Rows.Count > 0 Then

                Dim row As DataRow = dsResult.Tables(1).Rows(0)
                LblEdadLote.Text = row("Edad Lote").ToString()
                LblPesoPromCamada.Text = FormatNumber(row("Peso Promedio Camada"), 2)
                LblCantidadLechones.Text = row("Cantidad Lechones").ToString()
                LblPesoPromCria.Text = FormatNumber(row("Peso Promedio Cría"), 2)

            End If
            Colorear()
        End If
    End Sub


    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim codigo As Integer = 2

            'colorear segun clave
            clsBasicas.Colorear_SegunClave(dtgListado, Color.Yellow, Color.Black, "NDZ", codigo)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(codigo).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnExportarNpea_Click(sender As Object, e As EventArgs) Handles btnExportarNpea.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE DE DESTETE HISTORICO", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Consultar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 0)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 8)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class