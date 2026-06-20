Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRptCostoxKiloDetalleF7
    Dim cn As New cnControlAnimal
    Dim ds As New DataSet
    Public idDetalle As String
    Public idCampaña As Integer

    Private Sub FrmRptCostoxKiloDetalleF7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Consultar()
            clsBasicas.Formato_Tablas_Grid(dtgListado1)
            clsBasicas.Formato_Tablas_Grid(dtgListado2)
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
                .IdCampaña = idCampaña
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            ds = cn.Cn_CostoxKiloLechonRP13Detallado(obj).Copy
            ds.Tables(1).Columns("idControlTratamiento").ColumnMapping = MappingType.Hidden
            ds.Tables(2).Columns("idVacunacionTratamiento").ColumnMapping = MappingType.Hidden
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
            Dim dtResult3 As DataTable = dsResult.Tables(3)

            LblInicioCampana.Text = If(IsDBNull(dtResult.Rows(0)("Campaña_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Campaña_Inicio")).ToString("dd/MM/yyyy"))
            LblFinCampana.Text = If(IsDBNull(dtResult.Rows(0)("Campaña_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Campaña_Fin")).ToString("dd/MM/yyyy"))
            LblInicioMaternidad.Text = If(IsDBNull(dtResult.Rows(0)("Maternidad_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Maternidad_Inicio")).ToString("dd/MM/yyyy"))
            LblFinMaternidad.Text = If(IsDBNull(dtResult.Rows(0)("Maternidad_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Maternidad_Fin")).ToString("dd/MM/yyyy"))
            LblInicioDestete.Text = If(IsDBNull(dtResult.Rows(0)("Destete_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Destete_Inicio")).ToString("dd/MM/yyyy"))
            LblFinDestete.Text = If(IsDBNull(dtResult.Rows(0)("Destete_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Destete_Fin")).ToString("dd/MM/yyyy"))
            LblLotesInvolucrados.Text = If(IsDBNull(dtResult.Rows(0)("LotesInvolucrados")), "-", dtResult.Rows(0)("LotesInvolucrados").ToString())
            LblTotalDestetados.Text = If(IsDBNull(dtResult.Rows(0)("Total_Destetados")), "-", dtResult.Rows(0)("Total_Destetados").ToString())

            dtgListado1.DataSource = dsResult.Tables(1)
            dtgListado2.DataSource = dsResult.Tables(2)

            If IsDBNull(dtResult3.Rows(0)("SubtotalParvo")) Then
                LblSubTotalParvo.Text = "-"
            Else
                Dim subTotal As Decimal = Convert.ToDecimal(dtResult3.Rows(0)("SubtotalParvo"))
                LblSubTotalParvo.Text = Math.Round(subTotal, 2).ToString("0.00")

                Dim total As Decimal = Convert.ToDecimal(dtResult3.Rows(0)("CostoXLechon_RP13"))
                LblTotal.Text = Math.Round(total, 2).ToString("0.00")
            End If
        End If
    End Sub

    Private Sub dtgListado1_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado1.InitializeLayout
        Try
            If (dtgListado1.Rows.Count = 0) Then
            Else
                clsBasicas.Totales_Formato(dtgListado1, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListado1, e, 3)
                clsBasicas.SumarTotales_Formato(dtgListado1, e, 8)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado2_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado2.InitializeLayout
        Try
            If (dtgListado2.Rows.Count = 0) Then
            Else
                clsBasicas.Totales_Formato(dtgListado2, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListado2, e, 4)
                clsBasicas.SumarTotales_Formato(dtgListado2, e, 5)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class