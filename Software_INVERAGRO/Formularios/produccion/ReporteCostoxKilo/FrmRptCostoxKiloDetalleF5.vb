Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRptCostoxKiloDetalleF5
    Dim cn As New cnControlAnimal
    Dim ds As New DataSet
    Public idDetalle As String
    Public idCampaña As Integer

    Private Sub FrmRptCostoxKiloDetalleF5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                .idCampaña = idCampaña
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            ds = cn.Cn_CostoxKiloLechonRP10Detallado(obj).Copy
            'Tabla 1
            ds.Tables(1).Columns("idPersona").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("Area").ColumnMapping = MappingType.Hidden

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
            LblInicioInseminacion.Text = If(IsDBNull(dtResult.Rows(0)("Monta_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Monta_Inicio")).ToString("dd/MM/yyyy"))
            LblFinInseminacion.Text = If(IsDBNull(dtResult.Rows(0)("Monta_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Monta_Fin")).ToString("dd/MM/yyyy"))
            LblInicioChanchilla.Text = If(IsDBNull(dtResult.Rows(0)("Chanchilla_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Chanchilla_Inicio")).ToString("dd/MM/yyyy"))
            LblFinChanchilla.Text = If(IsDBNull(dtResult.Rows(0)("Chanchilla_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Chanchilla_Fin")).ToString("dd/MM/yyyy"))
            LblFechaUltDestete.Text = If(IsDBNull(dtResult.Rows(0)("Destete_UltimoRegistro")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Destete_UltimoRegistro")).ToString("dd/MM/yyyy"))

            dtgListado2.DataSource = dsResult.Tables(1)
            dtgListado1.DataSource = dsResult.Tables(2)

            If IsDBNull(dtResult3.Rows(0)("CostoPersonal_XLechon")) Then
                LblCostoTotalPersonal.Text = "-"
                LblLechonesDestetados.Text = "-"
                LblCostoTotalLechon.Text = "-"
            Else
                Dim costoTotalPersonal As Decimal = Convert.ToDecimal(dtResult3.Rows(0)("CostoTotal_Prorrateado"))
                LblCostoTotalPersonal.Text = Math.Round(costoTotalPersonal, 2).ToString("0.00")

                Dim lechonesDestetados As Integer = Convert.ToInt32(dtResult3.Rows(0)("LechonesDestetados"))
                LblLechonesDestetados.Text = lechonesDestetados.ToString()

                Dim costoTotalLechon As Decimal = Convert.ToDecimal(dtResult3.Rows(0)("CostoPersonal_XLechon"))
                LblCostoTotalLechon.Text = Math.Round(costoTotalLechon, 2).ToString("0.00")
            End If
        End If
    End Sub

    Private Sub dtgListado1_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado1.InitializeLayout
        Try
            If (dtgListado1.Rows.Count = 0) Then
            Else
                clsBasicas.Totales_Formato(dtgListado1, e, 0)
                clsBasicas.SumarTotales_Formato(dtgListado1, e, 6)
                clsBasicas.SumarTotales_Formato(dtgListado1, e, 7)
                clsBasicas.SumarTotales_Formato(dtgListado1, e, 8)
                clsBasicas.SumarTotales_Formato(dtgListado1, e, 9)
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
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class