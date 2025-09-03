Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmReporteAnimalesPlantel
    Dim cn As New cnControlLoteDestete
    Dim tbtmp As New DataTable
    Dim totalLotes As Decimal = 0
    Dim consumo As Decimal = 0
    Dim pesoTotalBajada As Decimal = 0
    Public idPlantel As Integer = 0
    Public idCampana As Integer = 0

    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1500, 600)
    End Sub

    Private Sub FrmReporteAnimalesPlantel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RtnGeneral.Checked = True
            clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListado)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar1()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            Dim obj As New coControlLoteDestete With {
                .IdPlantel = idPlantel,
                .IdCampana = idCampana
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ConsultarReportePlantelCampaña(obj).Copy
            tbtmp.TableName = "tmp"
            tbtmp.Columns("peso").ColumnMapping = MappingType.Hidden
            tbtmp.Columns("pesoConsumoDonacion").ColumnMapping = MappingType.Hidden
            tbtmp.Columns("edadPromedioLote").ColumnMapping = MappingType.Hidden
            tbtmp.Columns("pesoPromedioVentaLote").ColumnMapping = MappingType.Hidden
            tbtmp.Columns("Campaña").ColumnMapping = MappingType.Hidden
            tbtmp.Columns("totalLotes").ColumnMapping = MappingType.Hidden
            tbtmp.Columns("consumo").ColumnMapping = MappingType.Hidden
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            Ptbx_Cargando.Visible = False
            ToolStrip1.Enabled = True
            LblIngreso.Text = SumarTotalAnimalesIngreso().ToString("N0")
            LblRetorno.Text = SumarTotalAnimalesRetorno().ToString("N0")
            LblTotalMortalidad.Text = SumarMortalidad()
            LblTotalAnimales.Text = SumarTotalAnimales().ToString("N0")
            PorcentajeMortalidadCampana.Text = If(SumarTotalAnimalesIngreso() = 0, 0, ((SumarMortalidad() / SumarTotalAnimalesIngreso()) * 100).ToString("F2"))
            PorcentajeEmergenciaCampaña.Text = If(SumarTotalAnimalesIngreso() = 0, 0, ((SumarTotalAnimalesEmergencia() / SumarTotalAnimalesIngreso()) * 100).ToString("F2"))
            LblVendidos.Text = Convert.ToDecimal(SumarTotalAnimalesVendidos()).ToString("N0")
            LblEmergencia.Text = SumarTotalAnimalesEmergencia()
            totalLotes = SumaTotalLotes()
            LblAproxVentaSemana.Text = (SumarTotalAnimales() / totalLotes).ToString("N0")
            pesoTotalBajada = SumarTotalPesoBajada()
            LblTotalConsDona.Text = SumarTotalAnimalesConsumoDonacion()
            If dtgListado.Rows.Count > 0 Then
                LblPesoVenta.Text = Convert.ToDecimal(dtgListado.Rows(0).Cells("peso").Value).ToString("N0")
                LblPesoTotalConsDona.Text = Convert.ToDecimal(dtgListado.Rows(0).Cells("pesoConsumoDonacion").Value).ToString("N0")
                'LblConversionAlimenticia.Text = If(CInt(LblEdadPromedioLote.Text) = 0, 0, Convert.ToDecimal((dtgListado.Rows(0).Cells("consumo").Value + dtgListado.Rows(0).Cells("pesoConsumoDonacion").Value) / (CDec(LblPesoVenta.Text) - pesoTotalBajada))).ToString("F2")
                LblEdadPromedioLote.Text = Convert.ToDecimal(dtgListado.Rows(0).Cells("edadPromedioLote").Value).ToString("F2")
                LblPromedioPesoVenta.Text = Convert.ToDecimal(dtgListado.Rows(0).Cells("pesoPromedioVentaLote").Value).ToString("F2")
                LblCampaña.Text = dtgListado.Rows(0).Cells("Campaña").Value.ToString()
                Dim valor As Decimal = 0

                If CInt(LblEdadPromedioLote.Text) <> 0 Then
                    valor = Convert.ToDecimal(
                        (dtgListado.Rows(0).Cells("consumo").Value +
                         dtgListado.Rows(0).Cells("pesoConsumoDonacion").Value) /
                        (CDec(LblPesoVenta.Text) - pesoTotalBajada)
                    )
                End If

                LblConversionAlimenticia.Text = If(valor < 0, "-", valor.ToString("F2"))
            End If
            GananciaDiariaPeso.Text = If(CInt(LblEdadPromedioLote.Text) = 0, 0, (CInt(LblPromedioPesoVenta.Text) / CInt(LblEdadPromedioLote.Text)).ToString("F3"))
            LblPesoTotalVentaConsDona.Text = (Convert.ToDecimal(dtgListado.Rows(0).Cells("pesoConsumoDonacion").Value) + Convert.ToDecimal(dtgListado.Rows(0).Cells("peso").Value)).ToString("N0")
        End If
    End Sub

    Sub Consultar2()
        If Not BackgroundWorker2.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            Dim obj As New coControlLoteDestete With {
                .IdPlantel = idPlantel,
                .IdCampana = idCampana
            }

            BackgroundWorker2.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ConsultarMortalidadDetalladoCampaña(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            Ptbx_Cargando.Visible = False
            ToolStrip1.Enabled = True
        End If
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        If (dtgListado.Rows.Count = 0) Then
            msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
            Return
        Else
            clsBasicas.ExportarExcel("REPORTE DE LOTES POR PLANTEL", dtgListado)
        End If
    End Sub

    Private Sub RtnGeneral_CheckedChanged(sender As Object, e As EventArgs) Handles RtnGeneral.CheckedChanged
        clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListado)
        If RtnGeneral.Checked Then
            dtgListado.DataSource = Nothing
            Consultar1()
        End If
    End Sub

    Private Function SumarTotalAnimalesIngreso() As Integer
        Dim suma As Integer = 0
        For i As Integer = 0 To dtgListado.Rows.Count - 1
            suma += dtgListado.Rows(i).Cells("Ingreso").Value
        Next
        Return suma
    End Function

    Private Function SumarTotalAnimalesRetorno() As Integer
        Dim suma As Integer = 0
        For i As Integer = 0 To dtgListado.Rows.Count - 1
            suma += dtgListado.Rows(i).Cells("Retorno").Value
        Next
        Return suma
    End Function

    Private Function SumarMortalidad() As Integer
        Dim suma As Integer = 0
        For i As Integer = 0 To dtgListado.Rows.Count - 1
            suma += dtgListado.Rows(i).Cells("Mortalidad").Value
        Next
        Return suma
    End Function

    Private Function SumarTotalAnimales() As Integer
        Dim suma As Integer = 0
        For i As Integer = 0 To dtgListado.Rows.Count - 1
            suma += dtgListado.Rows(i).Cells("Disponibles para Venta").Value
        Next
        Return suma
    End Function

    Private Function SumarTotalAnimalesVendidos() As Integer
        Dim suma As Integer = 0
        For i As Integer = 0 To dtgListado.Rows.Count - 1
            suma += dtgListado.Rows(i).Cells("Vendidos").Value
        Next
        Return suma
    End Function

    Private Function SumarTotalAnimalesConsumoDonacion() As Integer
        Dim suma As Integer = 0
        For i As Integer = 0 To dtgListado.Rows.Count - 1
            suma += dtgListado.Rows(i).Cells("Consumo / Donación").Value
        Next
        Return suma
    End Function

    Private Function SumarTotalAnimalesEmergencia() As Integer
        Dim suma As Integer = 0
        For i As Integer = 0 To dtgListado.Rows.Count - 1
            suma += dtgListado.Rows(i).Cells("Emergencia").Value
        Next
        Return suma
    End Function

    Private Function SumarTotalPesoBajada() As Integer
        Dim suma As Integer = 0
        For i As Integer = 0 To dtgListado.Rows.Count - 1
            suma += dtgListado.Rows(i).Cells("Peso Bajada").Value
        Next
        Return suma
    End Function

    Private Function CalcularPesoPromedioVenta() As Decimal
        Dim suma As Decimal = 0
        Dim contador As Integer = 0

        For Each fila As UltraGridRow In dtgListado.Rows
            If Not fila.IsFilteredOut AndAlso Not fila.IsGroupByRow Then
                Dim valor = fila.Cells("Peso Promedio Venta (kg)").Value
                If valor IsNot Nothing AndAlso IsNumeric(valor) Then
                    suma += Convert.ToDecimal(valor)
                    contador += 1
                End If
            End If
        Next

        If contador > 0 Then
            Return Math.Round(suma / contador, 2)
        Else
            Return 0
        End If
    End Function

    Private Sub RtnMortalidad_CheckedChanged(sender As Object, e As EventArgs) Handles RtnMortalidad.CheckedChanged
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        If RtnMortalidad.Checked Then
            dtgListado.DataSource = Nothing
            Consultar2()
        End If
    End Sub

    Private Function SumaTotalLotes() As Decimal
        Dim suma As Decimal = 0
        For i As Integer = 0 To dtgListado.Rows.Count - 1
            suma += dtgListado.Rows(i).Cells("totalLotes").Value
        Next
        Return suma
    End Function

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 0)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 2)
                If RtnGeneral.Checked Then
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 4)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 9)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 10)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 11)
                Else
                    clsBasicas.PromedioTotales_Formato(dtgListado, e, 4)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class