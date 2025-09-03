Imports CapaNegocio
Imports CapaObjetos

Public Class FrmEstadodeCuentaBancario
    Dim cn As New cnProducto
    Private Sub FrmHistoricoCompraPorProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Consultar()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub Consultar()
        Dim obj As New coProductos
        obj.Idproducto = CInt(lblcuenta.AccessibleDescription)
        obj.FechaDesde = dtpFechaDesde.Value
        obj.FechaHasta = dtpFechaHasta.Value
        dtgListado.DataSource = cn.Cn_ConsultarEstadoCuentaBancario(obj)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "EGRESO", 0)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "INGRESO", 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Consultar()
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub btnexportar_excel_Click(sender As Object, e As EventArgs) Handles btnexportar_excel.Click
        Try
            clsBasicas.ExportarExcel("Kardex de " & lblbanco.Text, dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        clsBasicas.Totales_Formato(dtgListado, e, 1)
        clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
        clsBasicas.SumarTotales_Formato(dtgListado, e, 3)
        clsBasicas.SumarTotales_Formato(dtgListado, e, 4)
    End Sub
End Class