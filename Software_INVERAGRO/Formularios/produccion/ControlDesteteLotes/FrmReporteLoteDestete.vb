Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmReporteLoteDestete
    Dim cn As New cnControlLoteDestete
    Private search As Boolean = False
    Public idPlantel As Integer = 0
    Dim ds As New DataSet

    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1350, 850)
    End Sub

    Private Sub FrmReporteDestete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarLotes()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        LblPesoProm.Text = "Peso X" & ChrW(&H305) & " (kg):"
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Formato_Tablas_Grid(DtgConsolidadEdad)
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        CmbAnios.Enabled = False
        CmbLotes.Enabled = False
        BtnReporteCondCorporal.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        CmbAnios.Enabled = True
        CmbLotes.Enabled = True
        BtnReporteCondCorporal.Enabled = True
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
            ds = cn.Cn_ConsultarLotesDestete(obj).Copy
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
            DesbloquearControladores()
            dtgListado.DataSource = dsResult.Tables(0)
            DtgConsolidadEdad.DataSource = dsResult.Tables(1)
            dtgListado.DisplayLayout.Bands(0).Columns("idLote").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("fNacimiento").Hidden = True
            DtgConsolidadEdad.DisplayLayout.Bands(0).Columns("EdadLote").Hidden = True
            LblLechones.Text = SumarLechones().ToString()
            LblMarranas.Text = dtgListado.Rows.Count.ToString()
            LblMl.Text = If(CInt(LblMarranas.Text) = 0, 0, (CInt(LblLechones.Text) / CInt(LblMarranas.Text)).ToString("F1"))
            LblPesoTotal.Text = SumarPesoTotal().ToString("F1")
            LblPesoPromedio.Text = If(CInt(LblLechones.Text) = 0, 0, (CInt(LblPesoTotal.Text) / CInt(LblLechones.Text)).ToString("F1"))
            LblChanchillas.Text = SumarChanchillas().ToString("N0")
            If dtgListado.Rows.Count > 0 Then
                LblFechaNacimiento.Text = dtgListado.Rows(0).Cells("fNacimiento").Value.ToString()
            Else
                LblFechaNacimiento.Text = "0"
            End If

            If DtgConsolidadEdad.Rows.Count > 0 Then
                LblEdad.Text = DtgConsolidadEdad.Rows(0).Cells("EdadLote").Value.ToString()
            Else
                LblEdad.Text = "0"
            End If

            Colorear()
            CentrarColumnas()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim codigo As Integer = 3

            'colorear segun clave
            clsBasicas.Colorear_SegunClave(dtgListado, Color.Yellow, Color.Black, "NDZ", codigo)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(codigo).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Sub CentrarColumnas()
        If (DtgConsolidadEdad.Rows.Count > 0) Then
            Dim totalLechones As Integer = 1
            Dim diasLactandoPromedio As Integer = 2
            Dim ponderacionxFecha As Integer = 3

            'centrar columnas
            With DtgConsolidadEdad.DisplayLayout.Bands(0)
                .Columns(totalLechones).CellAppearance.TextHAlign = HAlign.Center
                .Columns(diasLactandoPromedio).CellAppearance.TextHAlign = HAlign.Center
                .Columns(ponderacionxFecha).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Function SumarLechones() As Integer
        Dim total As Integer = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If row.Cells("N° Lechones").Value IsNot Nothing AndAlso IsNumeric(row.Cells("N° Lechones").Value) Then
                total += CInt(row.Cells("N° Lechones").Value)
            End If
        Next
        Return total
    End Function

    Private Function SumarPesoTotal() As Decimal
        Dim total As Decimal = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If row.Cells("P.T Camada").Value IsNot Nothing AndAlso IsNumeric(row.Cells("P.T Camada").Value) Then
                total += CDec(row.Cells("P.T Camada").Value)
            End If
        Next
        Return total
    End Function

    Private Function SumarChanchillas() As Decimal
        Dim total As Decimal = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If row.Cells("Chanchillas").Value IsNot Nothing AndAlso IsNumeric(row.Cells("Chanchillas").Value) Then
                total += CDec(row.Cells("Chanchillas").Value)
            End If
        Next
        Return total
    End Function

    Private Sub CmbLotes_ValueChanged(sender As Object, e As EventArgs) Handles CmbLotes.ValueChanged
        Consultar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 15)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportarLoteParto_Click(sender As Object, e As EventArgs) Handles BtnExportarLoteParto.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                Dim nombreLote As String = CmbLotes.Text & "-" & CmbAnios.Text & "-DESTETES"
                clsBasicas.ExportarExcel(nombreLote, dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnReporteCondCorporal_Click(sender As Object, e As EventArgs) Handles BtnReporteCondCorporal.Click
        Try
            Dim frm As New FrmReporteCondCorporal With {
                .idLote = CmbLotes.Value
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