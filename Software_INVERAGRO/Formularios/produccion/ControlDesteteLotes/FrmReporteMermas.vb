Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmReporteMermas
    Dim cn As New cnControlLoteDestete
    Dim tbtmp As New DataTable
    Dim search As Boolean = False
    Dim anio As Integer = 0
    Dim mes As Integer = 0
    Dim semana As Integer = 0

    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1300, 800)
    End Sub

    Private Sub FrmReporteMermas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
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
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.LlenarComboMeses(CmbMeses)
        anio = CInt(CmbAnios.Text)
        mes = clsBasicas.ObtenerNumeroMes(CmbMeses)
        clsBasicas.LlenarComboSemanas(CmbSemanas, anio, mes)
        semana = clsBasicas.ObtenerNumeroSemana(CmbSemanas)
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        CmbAnios.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        CmbAnios.Enabled = True
        If Not CkbOmitirMes.Checked Then
            CmbMeses.Enabled = True
        End If
        If Not CkbOmitirSemana.Checked Then
            CmbSemanas.Enabled = True
        End If
        ToolStrip1.Enabled = True
    End Sub

    Sub Consultar()
        BloquearControladores()
        If Not BackgroundWorker1.IsBusy Then

            Dim obj As New coControlLoteDestete With {
                .Anio = anio,
                .Mes = mes,
                .Semana = semana
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ReporteMermas(obj).Copy
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
                clsBasicas.ExportarExcel("REPORTE DE MERMAS", dtgListado)
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
                clsBasicas.SumarTotales_Formato(dtgListado, e, 3)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 4)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 8)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 9)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 10)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cmbMeses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbMeses.SelectedIndexChanged
        If CmbMeses.SelectedIndex >= 0 Then
            Dim año As Integer = CInt(CmbAnios.Text)
            Dim mes As Integer = clsBasicas.ObtenerNumeroMes(CmbMeses)
            clsBasicas.LlenarComboSemanas(CmbSemanas, año, mes)
            CmbSemanas.SelectedIndex = 0
        End If
    End Sub

    Private Sub CkbOmitirMes_CheckedChanged(sender As Object, e As EventArgs) Handles CkbOmitirMes.CheckedChanged
        If CkbOmitirMes.Checked Then
            CmbMeses.Enabled = False
            CmbSemanas.Enabled = False
            CkbOmitirSemana.Checked = True
        Else
            CmbMeses.Enabled = True
            CmbSemanas.Enabled = True
            CkbOmitirSemana.Checked = False
        End If
    End Sub

    Private Sub CkbOmitirSemana_CheckedChanged(sender As Object, e As EventArgs) Handles CkbOmitirSemana.CheckedChanged
        If CkbOmitirSemana.Checked Then
            CmbSemanas.Enabled = False

            anio = CInt(CmbAnios.Text)
            mes = clsBasicas.ObtenerNumeroMes(CmbMeses)
        Else
            CmbSemanas.Enabled = True
            CkbOmitirMes.Checked = False
            CmbMeses.Enabled = True

            anio = CInt(CmbAnios.Text)
            mes = clsBasicas.ObtenerNumeroMes(CmbMeses)
            semana = clsBasicas.ObtenerNumeroSemana(CmbSemanas)
        End If
    End Sub

    Private Sub BtnBusqueda_Click(sender As Object, e As EventArgs) Handles BtnBusqueda.Click
        Try
            anio = CInt(CmbAnios.Text)
            mes = If(CkbOmitirMes.Checked, 0, clsBasicas.ObtenerNumeroMes(CmbMeses))
            semana = If(CkbOmitirSemana.Checked, 0, clsBasicas.ObtenerNumeroSemana(CmbSemanas))
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub
End Class