Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmReporteCondCorporalFechas
    Dim cn As New cnControlAnimal
    Public idUbicacion As Integer
    Dim tbtmp As New DataTable

    Private Sub FrmReporteCondCorporalFechas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        Ptbx_Cargando.Visible = True
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
            tbtmp = cn.Cn_ReporteCondCorporalFechas(obj).Copy
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
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim etapa As Integer = 0
            Dim condicion As Integer = 7
            Dim estadoRango As Integer = 8

            'ETAPA
            'GESTACIÓN
            clsBasicas.Colorear_SegunClave(dtgListado, Color.AntiqueWhite, Color.DarkOliveGreen, "GESTACIÓN", etapa)
            'MATERNIDAD
            clsBasicas.Colorear_SegunClave(dtgListado, Color.MistyRose, Color.Maroon, "MATERNIDAD", etapa)

            'CONDICION CORPORAL
            'Ideal
            clsBasicas.Colorear_SegunClave(dtgListado, Color.Green, Color.White, "Ideal", condicion)
            'Mediana
            clsBasicas.Colorear_SegunClave(dtgListado, Color.Yellow, Color.Black, "Mediana", condicion)
            'Delgada
            clsBasicas.Colorear_SegunClave(dtgListado, Color.Red, Color.White, "Delgada", condicion)
            'Sobrepeso
            clsBasicas.Colorear_SegunClave(dtgListado, Color.Orange, Color.White, "Sobrepeso", condicion)
            'No Registrado
            clsBasicas.Colorear_SegunClave(dtgListado, Color.Gray, Color.White, "No Registrado", condicion)

            'ESTADO RANGO
            'En Rango
            clsBasicas.Colorear_SegunClave(dtgListado, Color.Green, Color.White, "En Rango", estadoRango)
            'Fuera de Rango
            clsBasicas.Colorear_SegunClave(dtgListado, Color.Red, Color.White, "Fuera de Rango", estadoRango)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(etapa).CellAppearance.TextHAlign = HAlign.Center
                .Columns(condicion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoRango).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Consultar()
    End Sub

    Private Sub btnExportarNpea_Click(sender As Object, e As EventArgs) Handles btnExportarNpea.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL DE CONDICION CORPORAL MATERNIDAD", dtgListado)
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
                clsBasicas.Totales_Formato(dtgListado, e, 0)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class