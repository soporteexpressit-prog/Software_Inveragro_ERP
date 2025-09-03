Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmReporteBajada
    Dim cn As New cnControlLoteDestete
    Private search As Boolean = False
    Dim ds As New DataSet

    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1400, 550)
    End Sub

    Private Sub FrmReporteBajada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarLotes()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.Formato_Tablas_Grid(DtgListado)
        LblPesoProm.Text = "Peso (X" & ChrW(&H305) & "):"
    End Sub

    Private Sub CmbAnios_TextChanged(sender As Object, e As EventArgs) Handles CmbAnios.TextChanged
        If (search) Then
            ListarLotes()
        End If
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        CmbAnios.Enabled = False
        CmbLotes.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        CmbAnios.Enabled = True
        CmbLotes.Enabled = True
        ToolStrip1.Enabled = True
    End Sub

    Sub ListarLotes()
        Dim cn As New cnControlLoteDestete
        Dim obj As New coControlLoteDestete With {
           .Anio = CmbAnios.Text,
           .IdPlantel = 2
        }
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarLotesAnioCombo(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbLotes
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
        search = True
    End Sub

    Sub Consultar()
        BloquearControladores()
        If Not BackgroundWorker1.IsBusy Then

            Dim obj As New coControlLoteDestete With {
                .IdLote = CmbLotes.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            ds = cn.Cn_ReporteBajada(obj).Copy
            ds.Tables(0).TableName = "tmp"
            ds.Tables(1).TableName = "indicadores"
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            Dim ds As DataSet = CType(e.Result, DataSet)
            DtgListado.DataSource = ds.Tables("tmp")

            If ds.Tables("indicadores").Rows.Count > 0 Then
                Dim fila As DataRow = ds.Tables("indicadores").Rows(0)
                LblTotalAniEnviados.Text = fila("Total Animales Enviados").ToString()
                LblTotalPurasEnviadas.Text = fila("Total Puras Enviadas").ToString()
                LblTotalCamborEnviadas.Text = fila("Total Camborough Enviadas").ToString()
                LblTotalEngordeEnviadas.Text = fila("Total Engorde Enviados").ToString()
                LblTotalMortalidad.Text = fila("Total Mortalidad").ToString()
                LblPorcMortalidad.Text = fila("Porcentaje Mortalidad").ToString()
                LblPesoTotal.Text = fila("Peso Total").ToString() & " Kg"
                LblPesoPromedio.Text = fila("Peso Promedio General").ToString() & " Kg"
            End If
            DesbloquearControladores()
            Colorear()
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListado.InitializeLayout
        Try
            If (DtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(DtgListado, e, 0)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 2)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 3)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 4)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 5)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 6)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Colorear()
        If (DtgListado.Rows.Count > 0) Then
            Dim tipo As Integer = 9
            Dim estado As Integer = 16

            'tipo
            clsBasicas.Colorear_SegunValor(DtgListado, Color.LightSkyBlue, Color.Black, "ENVIO", tipo)

            'estado
            clsBasicas.Colorear_SegunValor(DtgListado, Color.Green, Color.White, "SI", estado)
            clsBasicas.Colorear_SegunValor(DtgListado, Color.LightGray, Color.Black, "NO", estado)

            'centrar columnas
            With DtgListado.DisplayLayout.Bands(0)
                .Columns(tipo).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub BtnExportarBajada_Click(sender As Object, e As EventArgs) Handles BtnExportarBajada.Click
        Try
            If (DtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE BAJADA X LOTE", DtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CmbLotes_TextChanged(sender As Object, e As EventArgs) Handles CmbLotes.TextChanged
        Consultar()
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class