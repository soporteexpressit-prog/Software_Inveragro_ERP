Imports CapaDatos
Imports CapaObjetos

Public Class cnIngreso
    Private cls_at As New cdIngreso
    Public Function Cn_Mantenimiento(ByRef obj As coIngreso) As String
        Return cls_at.Cd_Mantenimiento("[i_pa_regingreso_productos]", obj)
    End Function
    Public Function Cn_RegCompra(ByRef obj As coIngreso) As String
        Return cls_at.Cd_Mantenimientoregistrarorden("i_pa_regcompra", obj)
    End Function
    Public Function Cn_RegOrdenCompra(ByRef obj As coIngreso) As String
        Return cls_at.Cd_RegOrdenCompra("[i_pa_regordencompra]", obj)
    End Function
    Public Function Cn_RegPedidoUsuario(ByRef obj As coIngreso) As String
        Return cls_at.Cd_RegPedidoUsuario("[i_pa_regorpedidousuario]", obj)
    End Function
    Public Function Cn_ListarTablasMaestras() As DataSet
        Return cls_at.ListarTablasMaestras("[i_pa_listar_tablas_maestras_ingreso]")
    End Function
    Public Function Cn_ListarTablasMaestrasCompra() As DataSet
        Return cls_at.ListarTablasMaestras("[i_pa_listar_tablas_maestras_compras]")
    End Function
    Public Function Cn_ListarTipoDocumento() As DataTable
        Return cls_at.ListarTipoDocumento("[i_pa_listar_tipodocumento_ingreso]")
    End Function
    Public Function Cn_Consultar(ByRef obj As coIngreso) As DataSet
        Return cls_at.Consultar("[i_pa_cons_control_ingresos_producto]", obj)
    End Function
    Public Function Cn_ConsultarInventario(ByRef obj As coIngreso) As DataSet
        Return cls_at.ConsultarInventario("[i_pa_cons_control_inventario]", obj)
    End Function
    Public Function Cn_ConsultarCompras(ByRef obj As coIngreso) As DataSet
        Return cls_at.Consultar("[i_pa_cons_control_compras]", obj)
    End Function
    Public Function Cn_ConsultarOrdenesCompras(ByRef obj As coIngreso) As DataSet
        Return cls_at.Consultar("[i_pa_cons_control_ordenes_compras]", obj)
    End Function
    Public Function Cn_Consultarxproductoordencompra(ByRef obj As coIngreso) As DataSet
        Return cls_at.Consultarxproductoordencompra("[j_pa_recepciones_ordenes_compra]", obj)
    End Function
    Public Function Cn_ConsultarPedidosUsuarios(ByRef obj As coIngreso) As DataSet
        Return cls_at.Consultar("[i_pa_cons_control_pedidos_de_usuarios]", obj)
    End Function
    Public Function Cn_ConsultarOrdenesCompraEnviadasaFacturacion(ByRef obj As coIngreso) As DataSet
        Return cls_at.Consultar("[i_pa_cons_control_ordenes_compras_enviados_facturacion]", obj)
    End Function
    Public Function Cn_ConsultarOrdenesComprasArchivoCotizacion(ByRef obj As coIngreso) As String
        Return cls_at.Cd_ObtenerArchivoCotizaciondeOrdenCompra("[i_pa_obtenerArchivoCotizacion_ordencompra]", obj)
    End Function

    Public Function Cn_ConsultarDetallexCodigo(ByRef obj As coIngreso) As DataTable
        Return cls_at.ConsultarDetallexCodigo("[i_pa_cons_control_ingresos_detalle_x_codigo]", obj)
    End Function
    Public Function Cn_ConsultarDetallexCodigorequerimiento(ByRef obj As coIngreso) As DataTable
        Return cls_at.ConsultarDetallexCodigo("[i_pa_cons_control_salidas_detalle_x_codigo]", obj)
    End Function
    Public Function Cn_ConsultarRecepcionxCodigo(ByRef obj As coIngreso) As DataSet
        Return cls_at.Cd_ConsultarRecepcionxCodigo("[w_pa_cons_recepcion_x_ingreso]", obj)
    End Function
    Public Function Cn_ConsultarAtencionesOrdenesCompra(ByRef obj As coIngreso) As DataSet
        Return cls_at.Cd_ConsultarAtencionesOrdenesCompra("[i_pa_cons_ordenes_atendidas_de_pedidos_usuarios]", obj)
    End Function
    Public Function Cn_RecepcionProductos(ByRef obj As coIngreso) As String
        Return cls_at.Cd_RecepcionProductos("i_pa_regrecepcion_productos_v2", obj)
    End Function
    Public Function Cn_RecepcionProductosrequerimientos(ByRef obj As coIngreso) As String
        Return cls_at.Cd_RecepcionRequerimientoProductos("[i_pa_regrecepcion_productos_requerimientos]", obj)
    End Function
    Public Function Cn_ActualizarArchivo(ByRef obj As coIngreso) As String
        Return cls_at.Cd_ActualizarArchivoCotizacionOrdenCompra("[i_actualizar_archivo_cotizacion_orden_compra]", obj)
    End Function
    Public Function Cn_AprobarFacturacionOrdenCompra(ByRef obj As coIngreso) As String
        Return cls_at.Cd_AprobarFacturacionOrdenCompra("[i_pa_confirmar_facturacion_orden_compra]", obj)
    End Function

    Public Function Cn_anularfacturaordencompra(ByRef obj As coIngreso) As String
        Return cls_at.Cd_AprobarFacturacionOrdenCompra("[j_anular_factura_orden_compra]", obj)
    End Function

    Public Function Cn_crearsueldosbonificacionescts(ByRef obj As coIngreso) As String
        Return cls_at.Cd_crearsueldosbonificaciones("[j_Procesarctspagos]", obj)
    End Function

    Public Function Cn_crearsueldosbonificaciones(ByRef obj As coIngreso) As String
        Return cls_at.Cd_crearsueldosbonificaciones("[j_ProcesarGratificacionpagos]", obj)
    End Function
    Public Function Cn_ConsultarOrdendeCompraxCodigo(ByRef obj As coIngreso) As DataSet
        Return cls_at.ConsultarOrdenCompraxCodigo("[i_pa_cons_ordencompra_x_codigo]", obj)
    End Function
    Public Function Cn_ReporteOrdendeCompraxCodigo(ByRef obj As coIngreso) As DataSet
        Return cls_at.ConsultarOrdenCompraxCodigo("[i_pa_cons_reporte_ordencompra_x_codigo]", obj)
    End Function
    Public Function Cn_ReporteOrdendeFacturaxCodigo(ByRef obj As coIngreso) As DataSet
        Return cls_at.ConsultarOrdenCompraxCodigo("[j_buscar_factura_x_codigo]", obj)
    End Function
    Public Function Cn_anularfacturacionventa(ByRef obj As coIngreso) As String
        Return cls_at.Cd_AprobarFacturacionOrdenCompra("[j_anular_facturacion_venta]", obj)
    End Function
    Public Function Cn_ObtenerArchivo(idRecepcion As Integer) As Byte()
        Return cls_at.Cd_obtenerArchivo("[w_obtener_archivo_recepcion]", idRecepcion)
    End Function
    Public Function Cn_AnularOrdenCompra(ByRef obj As coIngreso) As String
        Return cls_at.Cd_AnularOrdenCompra("[i_pa_anularordendecompra]", obj)
    End Function
    Public Function Cn_Anularasignacionrequerimiento(ByRef obj As coIngreso) As String
        Return cls_at.Cd_AnularOrdenCompra("[an_pa_anularasignacionrequerimiento]", obj)
    End Function
    Public Function Cn_AnularPedidoUsuario(ByRef obj As coIngreso) As String
        Return cls_at.Cd_AnularOrdenCompra("[i_pa_anularpedidousuario]", obj)
    End Function
    Public Function Cn_ConsultarRecepcionProductos(ByRef obj As coIngreso) As DataTable
        Return cls_at.Cd_ConsultarRecepcionProductos("[w_pa_cons_productos_recepcionados]", obj)
    End Function
    Public Function Cn_ReporteGuiaTrasladoVentaxCodigo(ByRef obj As coIngreso) As DataSet
        Return cls_at.ReporteGuiaTrasladoxCodigo("[i_pa_reporte_guia_venta]", obj)
    End Function
    Public Function Cn_ValidarPedido(ByRef obj As coIngreso) As String
        Return cls_at.Cd_ValidarPedido("[i_pa_validarpedido]", obj)
    End Function
    Public Function Cn_ConsultarPedidoxCodigo(ByRef obj As coIngreso) As DataSet
        Return cls_at.ConsultarPedidoxCodigo("[i_pa_cons_pedidocompra_x_codigo]", obj)
    End Function
    Public Function Cn_ConsultarPedidosUsuarioSemenPorcino(ByRef obj As coIngreso) As DataSet
        Return cls_at.ConsultarSemenPorcino("[w_pa_cons_pedido_semen_porcino]", obj)
    End Function
    Public Function Cn_EnviarCorreoOrdenCompra(ByRef obj As coIngreso) As String
        Return cls_at.Cd_EnviarCorreoOrdenCompra("[w_pa_incrementar_num_correos_orden_compra]", obj)
    End Function
    Public Function Cn_ReporteFacturasVinculadas(ByRef obj As coIngreso) As DataTable
        Return cls_at.Cd_ReporteFacturasVinculadas("[r_pa_reporte_facturas_vinculadas]", obj)
    End Function
    Public Function Cn_Reportesaldosconsumidosvinculados(ByRef obj As coIngreso) As DataTable
        Return cls_at.Cd_ReporteFacturasVinculadas("[j_ver_consumido_saldo_vinculados]", obj)
    End Function

    Public Function Cn_ReportePagosGratificacionpagos(ByRef obj As coIngreso) As DataTable
        Return cls_at.Cd_ReportePagosGratificacion("[j_ver_grati_persona_pago]", obj)
    End Function

    Public Function Cn_ReportePagosGratificacion(ByRef obj As coIngreso) As DataTable
        Return cls_at.Cd_ReportePagosGratificacion("[j_ver_gratificacion_calculada_persona]", obj)
    End Function
    Public Function Cn_ReportePagosCtsPagos(ByRef obj As coIngreso) As DataTable
        Return cls_at.Cd_ReportePagosGratificacion("[j_ver_cts_pago_persona]", obj)
    End Function
    Public Function Cn_ReportePagosCts(ByRef obj As coIngreso) As DataTable
        Return cls_at.Cd_ReportePagosGratificacion("[j_ver_cts_calculado_persona]", obj)
    End Function
End Class
