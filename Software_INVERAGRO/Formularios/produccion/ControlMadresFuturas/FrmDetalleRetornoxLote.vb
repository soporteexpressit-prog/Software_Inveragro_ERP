Imports CapaNegocio
Imports CapaObjetos

Public Class FrmDetalleRetornoxLote
    Dim cn As New cnControlLoteDestete
    Public idRetorno As Integer = 0

    Private Sub FrmDetalleRetornoxLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ConsultarDetalleRetorno()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub ConsultarDetalleRetorno()
        Dim obj As New coControlLoteDestete With {
            .IdMovimientoBajada = idRetorno
        }

        Dim dt As DataTable = cn.Cn_ConsultarDetalleRetorno(obj)
        dtgListado.DataSource = dt
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class