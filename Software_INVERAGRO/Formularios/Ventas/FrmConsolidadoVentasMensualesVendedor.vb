Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmConsolidadoVentasMensualesVendedor
    Dim cn As New cnVentas
    Dim tbtmp As New DataTable
    Dim usuarioActivo As Integer = ActiveSessionId

    Private Sub FrmConsolidadoVentasMensualesVendedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.ListartodosVendedores(cbxvendedor)
        Consultar()
    End Sub
    Sub Consultar()
        Try
            Dim obj As New coVentas With {
                    .Iduser = If(CkbOmitirMes.Checked, 0, cbxvendedor.SelectedValue),
                    .anio = CInt(CmbAnios.Text),
                    .Semana = 0
                }
            dtgListado.DataSource = cn.Cn_ReporteVentaconsolidadoanual(obj).Copy

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Consultar()
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class