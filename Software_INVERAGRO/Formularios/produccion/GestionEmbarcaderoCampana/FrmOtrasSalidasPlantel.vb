Imports CapaNegocio
Imports CapaObjetos

Public Class FrmOtrasSalidasPlantel
    Dim cn As New cnControlCampanaEmbarque
    Public idUbicacion As Integer = 0
    Public idCampaña As Integer = 0
    Public valorPlantel As String = ""
    Public valorCampaña As String = ""

    Private Sub FrmOtrasSalidasPlantel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LblCampaña.Text = valorCampaña
            LblPlantel.Text = valorPlantel

            Dim obj As New coControlCampanaEmbarque With {
                .IdPlantel = idUbicacion,
                .IdCampaña = idCampaña
            }

            DtgListado.DataSource = cn.Cn_ConsultarOtrasSalidasPlantel(obj)
            clsBasicas.Formato_Tablas_Grid(DtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class