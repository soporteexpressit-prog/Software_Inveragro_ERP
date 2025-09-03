Imports CapaNegocio
Imports CapaObjetos

Public Class FrmKardex
    Dim cn As New cnProducto
    Public idubicacion As Integer
    Private Sub FrmHistoricoCompraPorProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultarCompras()
        clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListado)
    End Sub

    Private Sub ConsultarCompras()
        Try
            Dim obj As New coProductos With {
                .Idproducto = CInt(lblCodigo.Text),
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .IdUbicacion = idubicacion
            }
            dtgListado.DataSource = cn.Cn_ConsultarKardexProductoPorIdyUbicacion(obj)

            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "SALIDA", 0)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "INGRESO", 0)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub btnexportar_excel_Click(sender As Object, e As EventArgs) Handles btnexportar_excel.Click
        Try
            clsBasicas.ExportarExcel("Kardex de " & lblNombreProducto.Text, dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        ConsultarCompras()
    End Sub
End Class