Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRptCostoxKiloDetalleF8
    Dim cn As New cnControlAnimal
    Dim ds As New DataSet
    Public idDetalle As String
    Public idCampaña As Integer

    Private Sub FrmRptCostoxKiloDetalleF8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Consultar()
            clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        BarraOpciones.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        BarraOpciones.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlAnimal With {
                .idCampaña = idCampaña
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            ds = cn.Cn_CostoxKiloLechonRP14Detallado(obj).Copy
            ds.Tables(1).Columns("Codigo").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("FRecepcion").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("Estado").ColumnMapping = MappingType.Hidden
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
            If dsResult Is Nothing OrElse dsResult.Tables.Count = 0 Then Return

            Dim dtResult As DataTable = dsResult.Tables(0)
            Dim dtResult2 As DataTable = dsResult.Tables(2)

            LblInicioDestete.Text = If(IsDBNull(dtResult.Rows(0)("DesteteInicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("DesteteInicio")).ToString("dd/MM/yyyy"))
            LblFinDestete.Text = If(IsDBNull(dtResult.Rows(0)("DesteteFin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("DesteteFin")).ToString("dd/MM/yyyy"))

            dtgListado.DataSource = dsResult.Tables(1)

            If IsDBNull(dtResult2.Rows(0)("Regalias_x_Lechon")) Then
                LblTotal.Text = "-"
            Else
                Dim totalRegalias As Decimal = Convert.ToDecimal(dtResult2.Rows(0)("Total_Regalias"))
                LblTotalRegalias.Text = Math.Round(totalRegalias, 2).ToString("0.00")

                Dim numDiasRegalias As Integer = Convert.ToInt32(dtResult2.Rows(0)("Dias_Denominador"))
                LblNumDiasRegalia.Text = numDiasRegalias.ToString()

                Dim valorxDiaRegalias As Decimal = Convert.ToDecimal(dtResult2.Rows(0)("ValorPorDia"))
                LblValorDiaRegalia.Text = Math.Round(valorxDiaRegalias, 2).ToString("0.00")

                Dim numDias As Integer = Convert.ToInt32(dtResult2.Rows(0)("Dias_RangoDestete"))
                LblNumDiasDestete.Text = numDias.ToString()

                Dim totalDestetados As Decimal = Convert.ToDecimal(dtResult2.Rows(0)("Total_Destetados"))
                LblNumLechones.Text = Math.Round(totalDestetados, 2).ToString("0.00")

                Dim total As Decimal = Convert.ToDecimal(dtResult2.Rows(0)("Regalias_x_Lechon"))
                LblTotal.Text = Math.Round(total, 2).ToString("0.00")
            End If
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                clsBasicas.Totales_Formato(dtgListado, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 10)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 11)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 12)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 13)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportarprocontrolcerdos_Click(sender As Object, e As EventArgs) Handles BtnExportarprocontrolcerdos.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL DE DETALLE DE COSTO", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class