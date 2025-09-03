Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmReportePesosGranja
    Dim cn As New cnControlLoteDestete
    Dim tbtmp As New DataTable
    Dim search As Boolean = False
    Dim anio As Integer = 0
    Dim mes As Integer = 0
    Dim semana As Integer = 0

    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1200, 800)
    End Sub

    Private Sub FrmReportePesosGranja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        Ptbx_Cargando.Visible = True
        CkbOmitirFecha.Checked = True
        LblPesoProm.Text = "Peso G(X" & ChrW(&H305) & "):"
        LblEdadPonderada.Text = "Edad G(X" & ChrW(&H305) & "):"
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
        CmbMeses.Enabled = False
        CmbSemanas.Enabled = False
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
                .Semana = semana,
                .FechaControl = DtpFecha.Value,
                .FechaHasta = dtpfhasta.Value,
                .Estado = If(CkbOmitirFecha.Checked, "NO", "SI"),
                .TipoFiltro = If(CkbOmitirConsDona.Checked, "NO", "SI")
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ReportePesosGranja(obj).Copy
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
            dtgListado.DisplayLayout.Bands(0).Columns("codigo").Hidden = True
            LblPesoPromedio.Text = If(SumarCantidad() = 0, 0, (SumarPesoGranja() / SumarCantidad()).ToString("N2"))
            LblEdadPond.Text = If(SumarCantidad() = 0, 0, CalculoEdadPonderada().ToString("N2"))
            PintarFilasConsumoDonacion()
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportarhistoricomortalidad_Click(sender As Object, e As EventArgs) Handles BtnExportarhistoricomortalidad.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE DE PESOS GRANJA", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub PintarFilasConsumoDonacion()
        For Each fila As UltraGridRow In dtgListado.Rows
            Dim disponibleVenta As String = fila.Cells("Cliente").Value?.ToString().ToUpper().Trim()

            If disponibleVenta = "CONSUMO" Or disponibleVenta = "DONACIÓN" Then
                fila.Appearance.BackColor = Color.FromArgb(255, 220, 220)
            End If
        Next
    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dtgListado.InitializeRow
        If e.Row.Band.Index = 0 Then
            Dim colVerPesos As Infragistics.Win.UltraWinGrid.UltraGridColumn
            If dtgListado.DisplayLayout.Bands(0).Columns.Exists("[+]") Then
                colVerPesos = dtgListado.DisplayLayout.Bands(0).Columns("[+]")
                colVerPesos.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerPesos.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                If Not e.ReInitialize Then
                    e.Row.Cells("[+]").Value = "[+]"
                    e.Row.Cells("[+]").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                End If
            End If
        End If
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As CellEventArgs) Handles dtgListado.ClickCellButton
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim cliente As String = activeRow.Cells("Cliente").Value?.ToString().ToUpper().Trim()

                If cliente = "CONSUMO" Or cliente = "DONACIÓN" Then
                    msj_advert("Solo esta disponible para ventas de cerdos de engorde")
                    Return
                End If

                Dim frm As New FrmPesosxDespachoGranja With {
                    .idSalida = Convert.ToInt32(activeRow.Cells("codigo").Value)
                }
                frm.ShowDialog()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub cmbMeses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbMeses.SelectedIndexChanged
        If CmbMeses.SelectedIndex >= 0 Then
            Dim año As Integer = CInt(CmbAnios.Text)
            Dim mes As Integer = clsBasicas.ObtenerNumeroMes(CmbMeses)
            clsBasicas.LlenarComboSemanas(CmbSemanas, año, mes)
            CmbSemanas.SelectedIndex = 0

            anio = CInt(CmbAnios.Text)
            mes = clsBasicas.ObtenerNumeroMes(CmbMeses)
            clsBasicas.PosicionarFecha(DtpFecha, anio, mes)
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
            clsBasicas.PosicionarFecha(DtpFecha, anio, mes)
        Else
            CmbSemanas.Enabled = True
            CkbOmitirMes.Checked = False
            CmbMeses.Enabled = True
            CkbOmitirFecha.Checked = False

            anio = CInt(CmbAnios.Text)
            mes = clsBasicas.ObtenerNumeroMes(CmbMeses)
            semana = clsBasicas.ObtenerNumeroSemana(CmbSemanas)
            clsBasicas.PosicionarFecha(DtpFecha, anio, mes, semana)
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

    Private Function CalculoEdadPonderada() As Decimal
        Dim sumaPonderada As Decimal = 0
        Dim sumaCantidad As Integer = 0

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            Dim cantidad = row.Cells(5).Value
            Dim epx = row.Cells(8).Value

            If epx IsNot Nothing AndAlso cantidad IsNot Nothing AndAlso
           IsNumeric(epx) AndAlso IsNumeric(cantidad) Then

                sumaPonderada += CDec(epx) * CInt(cantidad)
                sumaCantidad += CInt(cantidad)
            End If
        Next

        If sumaCantidad = 0 Then
            Return 0
        End If

        Return Math.Round(sumaPonderada / sumaCantidad, 2)
    End Function

    Private Function SumarCantidad() As Integer
        Dim total As Integer = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If row.Cells("Cantidad").Value IsNot Nothing AndAlso IsNumeric(row.Cells("Cantidad").Value) Then
                total += CInt(row.Cells("Cantidad").Value)
            End If
        Next
        Return total
    End Function

    Private Function SumarPesoGranja() As Integer
        Dim total As Integer = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If row.Cells("PG (kg)").Value IsNot Nothing AndAlso IsNumeric(row.Cells("PG (kg)").Value) Then
                total += CInt(row.Cells("PG (kg)").Value)
            End If
        Next
        Return total
    End Function

    Private Sub cmbSemanas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSemanas.SelectedIndexChanged
        If CmbSemanas.SelectedIndex >= 0 Then
            anio = CInt(CmbAnios.Text)
            mes = clsBasicas.ObtenerNumeroMes(CmbMeses)
            semana = clsBasicas.ObtenerNumeroSemana(CmbSemanas)
            clsBasicas.PosicionarFecha(DtpFecha, anio, mes, semana)
        End If
    End Sub

    Private Sub CkbOmitirFecha_CheckedChanged(sender As Object, e As EventArgs) Handles CkbOmitirFecha.CheckedChanged
        If CkbOmitirFecha.Checked Then
            DtpFecha.Enabled = False
            dtpfhasta.Enabled = False
        Else
            DtpFecha.Enabled = True
            dtpfhasta.Enabled = True
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class