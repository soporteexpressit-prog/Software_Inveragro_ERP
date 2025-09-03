Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmConsolidadoAlimento
    Dim cn As New cnControlAlimento
    Dim tbtmp As New DataTable
    Dim semana As Tuple(Of Date, Date)

    Private Sub FrmConsolidadoAlimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Timer1.Interval = 500
            Timer1.Enabled = False
            dtpFecha.Value = DateTime.Now
            clsBasicas.Formato_Tablas_Grid(dtgListado)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Consultar(Optional ByVal fechaDesde As Date? = Nothing, Optional ByVal fechaHasta As Date? = Nothing)
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True

            Dim obj As New coControlAlimento With {
                .FechaDesde = semana.Item1,
                .FechaHasta = semana.Item2
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)

            tbtmp = cn.Cn_ConsolidadoAlimentoxSemana(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub ConfigurarUltraGrid()
        With dtgListado.DisplayLayout.Bands(0)
            .Groups.Clear()
            .RowLayoutStyle = RowLayoutStyle.GroupLayout

            Dim groupTipo As UltraGridGroup = .Groups.Add("TIPO DE", "TIPO DE")
            Dim group1 As UltraGridGroup = .Groups.Add("PLANTEL 1", "PLANTEL 1")
            Dim group2 As UltraGridGroup = .Groups.Add("PLANTEL 2", "PLANTEL 2")
            Dim group3 As UltraGridGroup = .Groups.Add("PLANTEL 3", "PLANTEL 3")
            Dim group4 As UltraGridGroup = .Groups.Add("PLANTEL 4", "PLANTEL 4")
            Dim group5 As UltraGridGroup = .Groups.Add("PLANTEL 5", "PLANTEL 5")
            Dim group6 As UltraGridGroup = .Groups.Add("TOTAL", "TOTAL")

            .Columns(0).RowLayoutColumnInfo.ParentGroup = groupTipo
            .Columns(1).RowLayoutColumnInfo.ParentGroup = group1
            .Columns(2).RowLayoutColumnInfo.ParentGroup = group1
            .Columns(3).RowLayoutColumnInfo.ParentGroup = group2
            .Columns(4).RowLayoutColumnInfo.ParentGroup = group2
            .Columns(5).RowLayoutColumnInfo.ParentGroup = group3
            .Columns(6).RowLayoutColumnInfo.ParentGroup = group3
            .Columns(7).RowLayoutColumnInfo.ParentGroup = group4
            .Columns(8).RowLayoutColumnInfo.ParentGroup = group4
            .Columns(9).RowLayoutColumnInfo.ParentGroup = group5
            .Columns(10).RowLayoutColumnInfo.ParentGroup = group5
            .Columns(11).RowLayoutColumnInfo.ParentGroup = group6
            .Columns(12).RowLayoutColumnInfo.ParentGroup = group6
        End With

        dtgListado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        clsBasicas.Filtrar_Tabla(dtgListado, False)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            ColorearColumnas()
            Ptbx_Cargando.Visible = False
            ConfigurarUltraGrid()
        End If
    End Sub

    Sub ColorearColumnas()
        If dtgListado.Rows.Count > 0 Then
            Dim colorDespacho As Color = Color.FromArgb(255, 189, 61)
            Dim colorTotalPedidoDespacho As Color = Color.FromArgb(196, 225, 246)
            Dim colorUltimaFila As Color = Color.LightGray

            For index As Integer = 0 To dtgListado.Rows.Count - 1
                Dim fila As UltraGridRow = dtgListado.Rows(index)

                fila.Cells(0).Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

                fila.Cells(11).Appearance.BackColor = colorTotalPedidoDespacho
                fila.Cells(11).Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

                fila.Cells(12).Appearance.BackColor = colorTotalPedidoDespacho
                fila.Cells(12).Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

                For i As Integer = 1 To fila.Cells.Count - 1
                    fila.Cells(i).Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                Next

                If index = dtgListado.Rows.Count - 1 Then
                    For Each celda As UltraGridCell In fila.Cells
                        celda.Appearance.BackColor = colorUltimaFila
                        celda.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        celda.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                    Next
                Else
                    fila.Cells(2).Appearance.BackColor = colorDespacho
                    fila.Cells(4).Appearance.BackColor = colorDespacho
                    fila.Cells(6).Appearance.BackColor = colorDespacho
                    fila.Cells(8).Appearance.BackColor = colorDespacho
                    fila.Cells(10).Appearance.BackColor = colorDespacho
                End If
            Next
        End If
    End Sub

    Public Function ObtenerSemana(fecha As Date) As Tuple(Of Date, Date)
        Dim diaSemana As Integer = fecha.DayOfWeek
        Dim fechaInicioSemana As Date = fecha.AddDays(-diaSemana)
        Dim fechaFinSemana As Date = fechaInicioSemana.AddDays(6)

        Return Tuple.Create(fechaInicioSemana, fechaFinSemana)
    End Function

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        Timer1.Stop()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        ConsultarConsolidado()
    End Sub

    Private Sub ConsultarConsolidado()
        semana = ObtenerSemana(dtpFecha.Value)
        lblPeriodo.Text = "Del " & semana.Item1.ToString("dd/MM/yyyy") & " al " & semana.Item2.ToString("dd/MM/yyyy")
        Consultar()
    End Sub

    Private Sub btnExportarNpea_Click(sender As Object, e As EventArgs) Handles btnExportarNpea.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONSOLIDADO DE ALIMENTOS", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class