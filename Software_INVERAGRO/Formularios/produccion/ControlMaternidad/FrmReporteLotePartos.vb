Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmReporteLotePartos
    Dim cn As New cnControlLoteDestete
    Private idLote As Integer = 0
    Private search As Boolean = False
    Public idPlantel As Integer = 0
    Dim ds As New DataSet

    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1400, 850)
    End Sub

    Private Sub FrmReporteLotePartos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarLotes()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        LblPesoTotalProm.Text = "Peso Total (X" & ChrW(&H305) & "):"
        LblFechaNacProm.Text = "Fecha Nacimiento (X" & ChrW(&H305) & "):"
        LblNacVivosProm.Text = "Nac Vivo (X" & ChrW(&H305) & "):"
        LblNacTotales.Text = "Nac Totales (X" & ChrW(&H305) & "):"
        LblPromViables.Text = "Viables (X" & ChrW(&H305) & "):"
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.Formato_Tablas_Grid(DtgListado)
        clsBasicas.Formato_Tablas_Grid(DtgListadoConsolidado)
        clsBasicas.Filtrar_Tabla(DtgListadoConsolidado, False)
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

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlLoteDestete With {
               .IdLote = CmbLotes.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            ds = cn.Cn_ConsultarLotesPartos(obj).Copy
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            Dim dsResult As DataSet = CType(e.Result, DataSet)
            DtgListado.DataSource = dsResult.Tables(0)
            DesbloquearControladores()
            DtgListado.DisplayLayout.Bands(0).Columns("F. Nacimiento Promedio").Hidden = True
            DtgListado.DisplayLayout.Bands(0).Columns("Viables").Hidden = True
            DtgListado.DisplayLayout.Bands(0).Columns("PromViables").Hidden = True
            DtgListado.DisplayLayout.Bands(0).Columns("Objetivo").Hidden = True
            LblFechaNacimiento.Text = If(dsResult.Tables(0).Rows.Count > 0,
                dsResult.Tables(0).Rows(0)("F. Nacimiento Promedio").ToString(), "-/-/-")
            LblMachos.Text = SumarMachos().ToString()
            LblHembras.Text = SumarHembras().ToString()
            LblMuertos.Text = SumarMuertos().ToString()
            LblMomias.Text = SumarMomias().ToString()
            LblNacTotal.Text = NacidosTotal().ToString()
            LblTotalVivos.Text = NacidosVivosTotal().ToString()
            LblPorcentajeMortalidad.Text = If(NacidosTotal() > 0,
                (SumarMuertos() / NacidosTotal() * 100).ToString("N2") & "%", "0.00%")
            LblPorcentajeMomias.Text = If(NacidosVivosTotal() > 0,
                (SumarMomias() / NacidosTotal() * 100).ToString("N2") & "%", "0.00%")
            LblPromNacVivos.Text = PromedioTotalVivos().ToString("N2")
            LblPromTotalNac.Text = PromedioNacidosTotales().ToString("N2")
            If NacidosVivosTotal() = 0 Then
                LblPesoTotal.Text = "0.00"
            Else
                LblPesoTotal.Text = (SumarPesoTotal() / NacidosVivosTotal()).ToString("N2")
            End If
            LblChanchillas.Text = SumarChanchillas().ToString("N0")

            If dsResult.Tables(0).Rows.Count > 0 Then
                LblViables.Text = dsResult.Tables(0).Rows(0)("Viables").ToString()
                LblPromedioViables.Text = dsResult.Tables(0).Rows(0)("PromViables").ToString()
                LblObjetivoParto.Text = dsResult.Tables(0).Rows(0)("Objetivo").ToString()
            Else
                LblViables.Text = "0"
            End If

            If dsResult.Tables.Count > 1 Then
                DtgListadoConsolidado.DataSource = dsResult.Tables(1)
            End If
        End If
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
                clsBasicas.SumarTotales_Formato(DtgListado, e, 9)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 8)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 7)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 6)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 5)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 4)
                clsBasicas.SumarTotales_Formato(DtgListado, e, 17)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function NacidosTotal() As Integer
        Return SumarMachos() + SumarHembras() + SumarMuertos() + SumarMomias()
    End Function

    Private Function NacidosVivosTotal() As Integer
        Return SumarMachos() + SumarHembras()
    End Function

    Private Function SumarMachos() As Integer
        Dim total As Integer = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListado.Rows
            If row.Cells("Machos").Value IsNot Nothing AndAlso IsNumeric(row.Cells("Machos").Value) Then
                total += CInt(row.Cells("Machos").Value)
            End If
        Next
        Return total
    End Function

    Private Function SumarHembras() As Integer
        Dim total As Integer = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListado.Rows
            If row.Cells("Hembra").Value IsNot Nothing AndAlso IsNumeric(row.Cells("Hembra").Value) Then
                total += CInt(row.Cells("Hembra").Value)
            End If
        Next
        Return total
    End Function

    Private Function SumarMuertos() As Integer
        Dim total As Integer = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListado.Rows
            If row.Cells("Muertos").Value IsNot Nothing AndAlso IsNumeric(row.Cells("Muertos").Value) Then
                total += CInt(row.Cells("Muertos").Value)
            End If
        Next
        Return total
    End Function

    Private Function SumarMomias() As Integer
        Dim total As Integer = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListado.Rows
            If row.Cells("Momias").Value IsNot Nothing AndAlso IsNumeric(row.Cells("Momias").Value) Then
                total += CInt(row.Cells("Momias").Value)
            End If
        Next
        Return total
    End Function

    Private Function SumarPesoTotal() As Decimal
        Dim total As Decimal = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListado.Rows
            If row.Cells("Peso Total").Value IsNot Nothing AndAlso IsNumeric(row.Cells("Peso Total").Value) Then
                total += CDec(row.Cells("Peso Total").Value)
            End If
        Next
        Return total
    End Function

    Private Function SumarChanchillas() As Decimal
        Dim total As Decimal = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListado.Rows
            If row.Cells("Chanchillas").Value IsNot Nothing AndAlso IsNumeric(row.Cells("Chanchillas").Value) Then
                total += CDec(row.Cells("Chanchillas").Value)
            End If
        Next
        Return total
    End Function

    Private Function PromedioTotalVivos() As Decimal
        Dim totalVivos As Integer = 0
        Dim totalRegistros As Integer = 0

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListado.Rows
            If row.Cells("Vivos").Value IsNot Nothing AndAlso IsNumeric(row.Cells("Vivos").Value) Then
                totalVivos += CInt(row.Cells("Vivos").Value)
                totalRegistros += 1
            End If
        Next

        If totalRegistros > 0 Then
            Return CDec(totalVivos) / CDec(totalRegistros)
        Else
            Return 0
        End If
    End Function

    Private Function PromedioNacidosTotales() As Decimal
        Dim totalNacidos As Integer = 0
        Dim totalRegistros As Integer = 0

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListado.Rows
            Dim machos As Integer = 0
            Dim hembras As Integer = 0
            Dim momias As Integer = 0
            Dim muertos As Integer = 0

            If row.Cells("Machos").Value IsNot Nothing AndAlso IsNumeric(row.Cells("Machos").Value) Then
                machos = CInt(row.Cells("Machos").Value)
            End If

            If row.Cells("Hembra").Value IsNot Nothing AndAlso IsNumeric(row.Cells("Hembra").Value) Then
                hembras = CInt(row.Cells("Hembra").Value)
            End If

            If row.Cells("Momias").Value IsNot Nothing AndAlso IsNumeric(row.Cells("Momias").Value) Then
                momias = CInt(row.Cells("Momias").Value)
            End If

            If row.Cells("Muertos").Value IsNot Nothing AndAlso IsNumeric(row.Cells("Muertos").Value) Then
                muertos = CInt(row.Cells("Muertos").Value)
            End If

            totalNacidos += (machos + hembras + momias + muertos)
            totalRegistros += 1
        Next

        If totalRegistros > 0 Then
            Return CDec(totalNacidos) / CDec(totalRegistros)
        Else
            Return 0
        End If
    End Function

    Private Sub BtnExportarLoteParto_Click(sender As Object, e As EventArgs) Handles BtnExportarLoteParto.Click
        Try
            If (DtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                Dim nombreLote As String = CmbLotes.Text & "-" & CmbAnios.Text & "-PARTOS"
                clsBasicas.ExportarExcel(nombreLote, DtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnReporteViables_Click(sender As Object, e As EventArgs) Handles BtnReporteViables.Click
        Try
            Dim frm As New FrmReporteDetalladoViables With {
                .idLote = CmbLotes.Value,
                .valorLote = CmbLotes.Text
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class