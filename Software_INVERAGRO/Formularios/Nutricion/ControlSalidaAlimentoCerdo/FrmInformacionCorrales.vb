Imports CapaNegocio
Imports CapaObjetos

Public Class FrmInformacionCorrales
    Dim cn As New cnControlAlimento
    Public idSalida As Integer = 0
    Public valorGalpon As String = ""
    Public valorPlantel As String = ""

    Private Sub FrmInformacionCorrales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarDetalleCorralesLote()
        LblGalpon.Text = valorGalpon
        LblPlantel.Text = valorPlantel
    End Sub

    Private Sub ListarDetalleCorralesLote()
        Try
            Dim obj As New coControlAlimento With {
                .Codigo = idSalida
            }

            Dim dt As DataTable = cn.Cn_ListarDetalleCorrales(obj)
            DtgListado.DataSource = dt
            clsBasicas.Formato_Tablas_Grid(DtgListado)
            DtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            If (DtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE DE CORRRALES", DtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class