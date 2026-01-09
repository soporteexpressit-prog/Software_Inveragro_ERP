Imports CapaNegocio
Imports CapaObjetos

Public Class FrmHistoricoCompraPorProducto
    Dim cn As New cnProducto
    Public operacion As Integer = 0
    Private Sub FrmHistoricoCompraPorProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultarCompras()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        If operacion = 1 Then
            Me.Text = "HISTORICO DE RECEPCIONES DEL PRODUCTO "
            lbltitulo.Text = "HISTORICO DE RECEPCIONES "
        End If
    End Sub

    Private Sub ConsultarCompras()
        Dim obj As New coProductos
        obj.Idproducto = CInt(lblCodigo.Text)
        obj.FechaDesde = dtpFechaDesde.Value
        obj.FechaHasta = dtpFechaHasta.Value
        If operacion = 0 Then
            dtgListado.DataSource = cn.Cn_ConsultarIngresoProductoPorId(obj)
        ElseIf operacion = 1 Then
            dtgListado.DataSource = cn.Cn_ConsultarRecepcionProductoPorId(obj)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        ConsultarCompras()
    End Sub



    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

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
End Class