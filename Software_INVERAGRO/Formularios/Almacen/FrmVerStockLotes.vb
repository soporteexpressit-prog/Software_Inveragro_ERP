Imports CapaNegocio
Imports CapaObjetos

Public Class FrmVerStockLotes
    Dim cn As New cnProducto
    Public idProducto As Integer = 0
    Public descripcion As String = ""
    Public idUbicacion As Integer = 0

    Private Sub FrmVerStockLotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LblProducto.Text = descripcion
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        Dim obj As New coProductos With {
            .Idproducto = idProducto,
            .IdUbicacion = idUbicacion
        }
        dtgListado.DataSource = cn.Cn_ListarLoteProducto(obj)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("LOTES DE PRODUCTO", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class