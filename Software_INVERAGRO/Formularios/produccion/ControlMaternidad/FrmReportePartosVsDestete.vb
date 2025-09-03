Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmReportePartosVsDestete
    Dim cn As New cnControlLoteDestete
    Private idLote As Integer = 0
    Private search As Boolean = False
    Public idPlantel As Integer = 0
    Dim ds As New DataSet

    Private Sub FrmReportePartosVsDestete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarLotes()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.Formato_Tablas_Grid(DtgListado)
        clsBasicas.Filtrar_Tabla(DtgListado, True)
        CkbTotal.Checked = False
    End Sub

    Sub ListarLotes()
        Dim cn As New cnControlLoteDestete
        Dim obj As New coControlLoteDestete With {
            .Anio = CmbAnios.Text,
           .IdPlantel = idPlantel
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

    Sub Consultar()
        BloquearControladores()
        If Not BackgroundWorker1.IsBusy Then

            Dim obj As New coControlLoteDestete With {
                .Anio = CmbAnios.Text,
                .IdLote = CmbLotes.Value,
                .TipoFiltro = If(CkbTotal.Checked, "SI", "NO")
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            ds = cn.Cn_ConsultarPartosVsDestete(obj).Copy
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
                Dim dtIndicadores As DataTable = ds.Tables("indicadores")
                Dim obtenerValor = Function(nombreIndicador As String) As String
                                       Dim fila As DataRow = dtIndicadores.Select("indicador = '" & nombreIndicador & "'").FirstOrDefault()
                                       If fila IsNot Nothing Then
                                           Return fila("Valor").ToString()
                                       End If
                                       Return "0"
                                   End Function
                LblTotalPartos.Text = Convert.ToDecimal(obtenerValor("TOTAL_PARTOS")).ToString("N0")
                LblTotalDestete.Text = Convert.ToDecimal(obtenerValor("TOTAL_DESTETES")).ToString("N0")
                LblMuertos.Text = Convert.ToDecimal(obtenerValor("TOTAL_NACIDOS_MUERTOS")).ToString("N0")
                LblNacVivos.Text = Convert.ToDecimal(obtenerValor("TOTAL_NACIDOS_VIVOS")).ToString("N0")
                LblTotalDestetado.Text = Convert.ToDecimal(obtenerValor("TOTAL_DESTETADOS")).ToString("N0")
                LblPorcSupervivencia.Text = Convert.ToDecimal(obtenerValor("PORCENTAJE_SUPERVIVENCIA_GENERAL")).ToString("N2") & "%"
                LblObjetivo.Text = Convert.ToDecimal(obtenerValor("META")).ToString("N0")
                LblPartos.Text = Convert.ToDecimal(obtenerValor("TOTAL_PARTOS")).ToString("N0")
                Dim porcentajeCumplimiento As Decimal = 0
                If Convert.ToDecimal(obtenerValor("META")) > 0 Then
                    porcentajeCumplimiento = (Convert.ToDecimal(obtenerValor("TOTAL_PARTOS")) / Convert.ToDecimal(obtenerValor("META"))) * 100
                End If
                LblPorCumplimiento.Text = porcentajeCumplimiento.ToString("N1") & "%"
            End If
            search = True
            DesbloquearControladores()
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (DtgListado.Rows.Count > 0) Then
            Dim estado As Integer = 10


            'estadoVivo
            clsBasicas.Colorear_SegunValor(DtgListado, Color.LightGreen, Color.DarkGreen, "COMPLETO", estado)
            clsBasicas.Colorear_SegunValor(DtgListado, Color.LightPink, Color.Black, "SOLO PARTO", estado)
            clsBasicas.Colorear_SegunValor(DtgListado, Color.LightGray, Color.Black, "SOLO DESTETE", estado)

            'centrar columnas
            With DtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub CkbTotal_CheckedChanged(sender As Object, e As EventArgs) Handles CkbTotal.CheckedChanged
        Consultar()
    End Sub

    Private Sub CmbLotes_ValueChanged(sender As Object, e As EventArgs) Handles CmbLotes.ValueChanged
        Consultar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListado.InitializeLayout
        Try
            If (DtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(DtgListado, e, 0)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 3)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 4)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 5)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 6)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 8)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 9)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportarLoteParto_Click(sender As Object, e As EventArgs) Handles BtnExportarLoteParto.Click
        Try
            If (DtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                Dim nombreLote As String = CmbLotes.Text & "-" & CmbAnios.Text & "-PARTOS-VS-DESTETE"
                clsBasicas.ExportarExcel(nombreLote, DtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class