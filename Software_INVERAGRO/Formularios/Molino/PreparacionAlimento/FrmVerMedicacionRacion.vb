Imports CapaNegocio
Imports CapaObjetos

Public Class FrmVerMedicacionRacion
    Dim cn As New cnControlAlimento
    Public idDetalleRacion As Integer = 0

    Private Sub FrmVerMedicacionRacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim obj As New coControlAlimento With {
               .Codigo = idDetalleRacion
           }

            dtgListado.DataSource = cn.Cn_ObtenerPeriodoMedicacionRacion(obj)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class