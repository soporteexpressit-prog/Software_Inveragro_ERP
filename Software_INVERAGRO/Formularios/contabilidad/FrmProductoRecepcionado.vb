Imports CapaNegocio
Imports CapaObjetos

Public Class FrmProductoRecepcionado
    Dim cn As New cnIngreso
    Private _CodRedecepcion As Integer
    Dim _Operacion As Integer

    Private Sub FrmProductoRecepcionado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Consultar()
        Inicializar()
    End Sub
    Sub Inicializar()
        _CodRedecepcion = 0
        _Operacion = 0
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        txtNumMinimo.Value = 0
    End Sub
    Sub Consultar()
        Dim obj As New coIngreso
        obj.Fechadesde = Nothing
        obj.Fechahasta = Nothing
        obj.MontoMinimo = Nothing
        dtgListado.DataSource = cn.Cn_ConsultarRecepcionProductos(obj)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub btnConvertirActivo_Click(sender As Object, e As EventArgs) Handles btnConvertirActivoctpr.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim cantidad = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(7).Value.ToString)
                Dim idDetalleRecepcion = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                Dim producto = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
                Dim fechaCompra = dtgListado.DisplayLayout.ActiveRow.Cells(5).Value
                Dim fechaRecepcion = dtgListado.DisplayLayout.ActiveRow.Cells(6).Value
                Dim precioUnitario = Convert.ToDecimal(dtgListado.DisplayLayout.ActiveRow.Cells(8).Value)
                Dim f As New FrmListaActivoRegistrar
                f.cantidadActivos = cantidad
                f.producto = producto
                f.fechaCompra = fechaCompra
                f.fechaRecepcion = fechaRecepcion
                f.idDetalleRecepcion = idDetalleRecepcion
                f.precioUnitario = precioUnitario
                f.ShowDialog()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportarctpr.Click
        Try
            clsBasicas.ExportarExcel("Productos Recepcionados", dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert("La fecha 'Desde' debe ser anterior o igual a la fecha 'Hasta'.")
            Return
        End If
        Consultar()
    End Sub



    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class