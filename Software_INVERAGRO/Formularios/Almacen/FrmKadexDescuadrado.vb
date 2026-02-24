Imports CapaNegocio
Imports CapaObjetos
Public Class FrmKadexDescuadrado
    Dim cn As New cnProducto
    Public operacion As Integer = 1
    Public valor As String = ""

    Private Sub FrmKadexDescuadrado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultarCompras()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub


    Private Sub ConsultarCompras()
        Dim obj As New coProductos
        obj.Idproducto = operacion
        obj.Descripcion = valor
        dtgListado.DataSource = cn.Cn_Consultardeskardex(obj)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ConsultarCompras()
    End Sub


    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 1)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 2)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 8)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dispose()
    End Sub
End Class