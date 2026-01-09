Imports CapaDatos
Imports CapaObjetos

Public Class cnVentas
    Private cls_at As New cdVentas
    Public Function Cn_RegPedidoVenta(ByRef obj As coVentas) As String
        Return cls_at.Cd_RegPedidoVenta("[i_pa_regpedidoventa]", obj)
    End Function
    Public Function Cn_Regasignacionreque(ByRef obj As coVentas) As String
        Return cls_at.Cd_Regasignacionrequerimiento("[i_pa_regasignacionrequerimiento]", obj)
    End Function
    Public Function Cn_RegAjusteNegativoOrdenCompra(ByRef obj As coVentas) As String
        Return cls_at.Cd_RegAjusteNegativoOrdenCompra("[i_pa_ajustenegativo_ordencompra]", obj)
    End Function
    Public Function Cn_Updateordencompra(ByRef obj As coVentas) As String
        Return cls_at.Cd_Updateordencompra("[j_pa_actualizar_precio_cantidad_orden_compra]", obj)
    End Function
    Public Function Cn_culminarordencompra(ByRef obj As coVentas) As String
        Return cls_at.Cd_Updateordencompra("[j_pa_actualizar_precio_cantidad_orden_culminar_orden_compra]", obj)
    End Function

    Public Function Cn_imprimir_reporte_venta(obj As coVentas) As DataSet
        Return cls_at.Cd_imprimir_reporte_venta("[j_pa_imprimir_reporte_venta]", obj)
    End Function
    Public Function Cn_RegPedidoVentaProductos(ByRef obj As coVentas) As String
        Return cls_at.Cd_RegPedidoVentaProductos("[i_pa_regpedidoventa_productos]", obj)
    End Function
    Public Function Cn_ConsultarxCodigo(obj As coVentas) As DataTable
        Return cls_at.Cd_ConsultarxCodigo("[j_pa_cons_RecepcionesVentas]", obj)
    End Function
    Public Function Cn_Consultarxproductoyvendedor(obj As coVentas) As DataTable
        Return cls_at.Cd_ConsultarxCodigovendedorcliente("[j_listar_transferencias_salida]", obj)
    End Function
    Public Function Cn_ConsultarxCodigoventa(obj As coVentas) As DataTable
        Return cls_at.Cd_ConsultarxCodigo("[j_pa_consultar_ventacerdo]", obj)
    End Function
    Public Function Cn_actualizarregistroguiapdf(ByRef obj As coVentas) As String
        Return cls_at.Cd_actualizarregistroguiapdf("[j_adjuntar_archivo_guia]", obj)
    End Function
    Public Function Cn_RegPedidoVentaCerdo(ByRef obj As coVentas) As String
        Return cls_at.Cd_RegPedidoVentaCerdo("[i_pa_regpedidoventa_cerdo]", obj)
    End Function
    Public Function Cn_RegPedidoVentaCerdoupdate(ByRef obj As coVentas) As String
        Return cls_at.Cd_RegPedidoVentaCerdoupdate("[j_pa_update_ventacerdo]", obj)
    End Function
    Public Function Cn_RegPedidoVentaCerdoTransferencia(ByRef obj As coVentas) As String
        Return cls_at.Cd_RegPedidoVentaCerdo("[i_pa_regpedidoventa_cerdo_x_transferencia]", obj)
    End Function
    Public Function Cn_RegPedidoVentaCerdoxConductor(ByRef obj As coVentas) As String
        Return cls_at.Cd_RegPedidoVentaCerdoxConductor("[i_pa_regpedidoventa_cerdo_por_conductor]", obj)
    End Function
    Public Function Cn_RegAjustenegativoventa(ByRef obj As coVentas) As String
        Return cls_at.Cd_RegAjustenegativoventa("[j_pa_descuento_parcial_recepcion_pedido_venta_cerdos_con_nuevo_registro]", obj)
    End Function
    Public Function Cn_RegAjustepositivoventa(ByRef obj As coVentas) As String
        Return cls_at.Cd_RegAjustepositivoventa("[j_pa_ajuste_positivo_venta]", obj)
    End Function
    Public Function Cn_Regactualizacionvendedor(ByRef obj As coVentas) As String
        Return cls_at.Cd_Regactualizacionvendedor("[j_pa_actualizar_vendedor]", obj)
    End Function
    Public Function Cn_Regactualizacionatipopeso(ByRef obj As coVentas) As String
        Return cls_at.Cd_Regactualizaciontipopeso("[j_pa_actualizar_tipo_peso]", obj)
    End Function
    Public Function Cn_Regactualizacioncerdo(ByRef obj As coVentas) As String
        Return cls_at.Cd_Regactualizacionvendedor("[j_pa_actualizar_cerdo]", obj)
    End Function
    Public Function Cn_RegPedidoVentaxKilos(ByRef obj As coVentas) As String
        Return cls_at.Cd_RegPedidoVentaxKilos("[i_pa_regpedidoventa_cerdo_por_kilo]", obj)
    End Function
    Public Function Cn_Reganulacionajuste(ByRef obj As coVentas) As String
        Return cls_at.Cd_Reganulacionajuste("[j_pa_anular_ajuste_parcial]", obj)
    End Function
    Public Function Cn_RegPedidoVentaDirecta(ByRef obj As coVentas) As String
        Return cls_at.Cd_RegPedidoVentaDirecta("[i_pa_regpedidoventa_directa_x_vendedora]", obj)
    End Function
    Public Function Cn_RegAjustexIrrecuperable(ByRef obj As coVentas) As String
        Return cls_at.Cd_RegAjustexIrrecuperable("[i_pa_regajuste_por_irrecuperable]", obj)
    End Function
    Public Function Cn_RegPedidoRequerimiento(ByRef obj As coVentas) As String
        Return cls_at.Cd_RegPedidoRequerimiento("[i_pa_regpedidorequerimiento]", obj)
    End Function
    Public Function Cn_ValidarRequerimiento(ByRef obj As coVentas) As String
        Return cls_at.Cd_ValidarRequerimiento("[i_pa_validarrequerimiento]", obj)
    End Function
    Public Function Cn_EliminarDetalleRequerimiento(ByRef obj As coVentas) As String
        Return cls_at.Cd_EliminarDetalleRequerimiento("[i_pa_eliminar_producto_de_requerimiento]", obj)
    End Function
    Public Function Cn_ListarTablasMaestrasPedidoVenta() As DataSet
        Return cls_at.ListarTablasMaestras("[i_pa_listar_tablas_maestras_pedido_venta]")
    End Function
    Public Function Cn_ListarVendedores(obj As coProductos) As DataTable
        Return cls_at.ListarVendedores("[i_pa_listar_vendedores]", obj)
    End Function

    Public Function Cn_ListartodosVendedores(obj As coProductos) As DataTable
        Return cls_at.ListarVendedores("[i_pa_listar_vendedores_todos]", obj)
    End Function

    Public Function Cn_ListarDestinoScti() As DataTable
        Return cls_at.ListarDestinoScti("[i_pa_listar_direcciones_scti]")
    End Function
    Public Function Cn_ListarTablasMaestrasPedidoVentaCerdo() As DataSet
        Return cls_at.ListarTablasMaestras("[i_pa_listar_tablas_maestras_pedido_venta_cerdo]")
    End Function
    Public Function j_Cn_ListarTablasMaestrasPedidoVentaCerdo() As DataSet
        Return cls_at.ListarTablasMaestras("[j_pa_listar_tablas_maestras_pedido_venta_cerdo]")
    End Function
    Public Function Cn_ListarTablasMaestrasSalidaProductos() As DataSet
        Return cls_at.ListarTablasMaestras("[i_pa_listar_tablas_maestras_salida_productos]")
    End Function
    Public Function Cn_ListarTablasMaestrasTransferenciaProductos() As DataSet
        Return cls_at.ListarTablasMaestras("[i_pa_listar_tablas_maestras_transferencia_productos]")
    End Function
    Public Function Cn_ListarTablasMaestrasRequerimientoProductos() As DataSet
        Return cls_at.ListarTablasMaestras("[i_pa_listar_tablas_maestras_requerimiento_productos]")
    End Function
    Public Function Cn_ListarTipoDocumento() As DataTable
        Return cls_at.ListarTipoDocumento("[i_pa_listar_tipodocumento_ingreso]")
    End Function
    Public Function Cn_ConsultarPedidosVentas(ByRef obj As coVentas) As DataSet
        Return cls_at.Consultar("[i_pa_cons_control_pedidos_venta]", obj)
    End Function
    Public Function Cn_Consultarareaspedido(ByRef obj As coVentas) As DataSet
        Return cls_at.ListarAreasGalpones("[j_pa_cons_listar_areas_galpones]", obj)
    End Function
    Public Function Cn_ConsultarPedidosVentasProductos(ByRef obj As coVentas) As DataSet
        Return cls_at.Consultar("[i_pa_cons_control_pedidos_venta_productos]", obj)
    End Function
    Public Function Cn_ConsultarGuiasTraslado(ByRef obj As coVentas) As DataSet
        Return cls_at.ConsultarGuiasTraslado("[i_pa_cons_guia_traslado]", obj)
    End Function
    Public Function Cn_ConsultarGuiasTrasladoPedidosCerdo(ByRef obj As coVentas) As DataSet
        Return cls_at.ConsultarGuiasTraslado("[i_pa_cons_guia_traslado_pedidos_cerdo]", obj)
    End Function
    Public Function Cn_VerGuiasTrasladoPedidosCerdo(ByRef obj As coVentas) As DataSet
        Return cls_at.VerGuiasTraslado("[i_pa_vet_guia_traslado_pedidos_cerdo]", obj)
    End Function
    Public Function Cn_ConsultarPedidosTransferencia(ByRef obj As coVentas) As DataSet
        Return cls_at.ConsultarTransferencia("[i_pa_cons_control_pedidos_transferencias]", obj)
    End Function
    Public Function Cn_ConsultarPedidoVentasCerdo(ByRef obj As coVentas) As DataSet
        Return cls_at.ConsultarPedidoVentaCerdo("[i_pa_cons_control_pedidos_venta_cerdo]", obj)
    End Function
    Public Function Cn_ConsultarVentasAnexadasaPedidosVentas(ByRef obj As coVentas) As DataSet
        Return cls_at.ConsultarVentasAnexadasaPedidoVentas("[i_pa_cons_ventas_anexadas_a_pedidos_venta]", obj)
    End Function
    Public Function Cn_ConsultarAtencionesRequerimientos(ByRef obj As coVentas) As DataSet
        Return cls_at.ConsultarAtencionesRequerimiento("[i_pa_cons_control_atenenciones_pedidos_requerimientos]", obj)
    End Function
    Public Function Cn_ConsultarSolicitudesRequerimientos(ByRef obj As coVentas) As DataSet
        Return cls_at.ConsultarSolicitudesRequerimiento("[i_pa_cons_control_solicitudes_pedidos_requerimientos]", obj)
    End Function
    Public Function Cn_ConsultarSalidaProductos(ByRef obj As coVentas) As DataSet
        Return cls_at.Consultar("[i_pa_cons_control_salida_productos]", obj)
    End Function
    Public Function Cn_ConsultarSalidaasignaciones(ByRef obj As coVentas) As DataSet
        Return cls_at.Consultar("[j_pa_cons_control_salida_productos_asignaciones]", obj)
    End Function
    Public Function Cn_ObtenerArchivoPedidoVenta(ByRef obj As coVentas) As String
        Return cls_at.Cd_ObtenerArchivoPedidoVenta("[i_pa_obtenerArchivoPedidoVenta]", obj)
    End Function
    Public Function Cn_ConsultarArchivoFacturacionVenta(ByRef obj As coVentas) As String
        Return cls_at.Cd_ObtenerArchivoFacturacionVenta("[i_pa_obtenerArchivoFacturacionVenta]", obj)
    End Function
    Public Function Cn_ConsultarDetallexCodigo(ByRef obj As coVentas) As DataTable
        Return cls_at.ConsultarDetallexCodigo("[i_pa_cons_control_pedido_venta_detalle_x_codigo]", obj)
    End Function
    Public Function Cn_ConsultarPesoKilos(ByVal codigo As Integer) As DataTable
        Return cls_at.ConsultarKilosxCodigo("[i_pa_obtener_kilos]", codigo)
    End Function

    Public Function Cn_ConsultarPedidosAtendidosProduccion(idplantel As Integer, transferencia As String) As DataTable
        Return cls_at.ConsultarPedidoAtendidoProduccion("[i_pa_consultar_pedidos_atendidos_produccion]", idplantel, transferencia)
    End Function
    Public Function Cn_ConsultarDespachoxCodigo(ByRef obj As coVentas) As DataSet
        Return cls_at.Cd_ConsultarDespachosxCodigo("[i_pa_cons_despachos_x_salida]", obj)
    End Function
    Public Function Cn_ConsultarDespachoxCodigoRequerimiento(ByRef obj As coVentas) As DataSet
        Return cls_at.Cd_ConsultarDespachosxCodigo("[i_pa_cons_despachos_x_salida_requerimiento]", obj)
    End Function
    Public Function Cn_RecepcionProductos(ByRef obj As coVentas) As String
        Return cls_at.Cd_RecepcionProductos("[i_pa_regrecepcion_productos_pedido_venta]", obj)
    End Function
    Public Function Cd_RecepcionPedidoVentasCerdo(ByRef obj As coVentas) As String
        Return cls_at.Cd_RecepcionPedidoVentasCerdo("[i_pa_regrecepcion_productos_pedido_venta_cerdos]", obj)
    End Function
    Public Function CnAntencionProductos(ByRef obj As coVentas) As String
        Return cls_at.Cd_AtencionProductos("[i_pa_atencion_requerimientos]", obj)
    End Function

    Public Function Cn_AprobarFacturacionPedidoVenta(ByRef obj As coVentas) As String
        Return cls_at.Cn_AprobarFacturacionPedidoVenta("[i_pa_confirmar_facturacion_pedido_venta]", obj)
    End Function
    Public Function Cn_ObtenerArchivo(idRecepcion As Integer) As Byte()
        Return cls_at.Cd_obtenerArchivo("[i_obtener_archivo_recepcion_venta]", idRecepcion)
    End Function

    Public Function Cn_ObtenerArchivoAtencionPedidoVenta(idRecepcion As Integer) As Byte()
        Return cls_at.Cd_obtenerArchivo("[i_obtener_archivo_detalle_recepcion_venta]", idRecepcion)
    End Function

    Public Function Cn_AnularPedidoguia(ByRef obj As coVentas) As String
        Return cls_at.Cd_AnularPedidoVenta("[i_pa_anular_entrega_conductor]", obj)
    End Function

    Public Function Cn_AnularPedidoVentaKilos(ByRef obj As coVentas) As String
        Return cls_at.Cd_AnularPedidoVenta("[i_pa_anular_pedidoventa_cerdo_por_kilo]", obj)
    End Function

    Public Function Cn_AnularPedidoVentas(ByRef obj As coVentas) As String
        Return cls_at.Cd_AnularPedidoVenta("[jpa_anular_pedidoventa]", obj)
    End Function

    Public Function Cn_AnularPedidoVenta(ByRef obj As coVentas) As String
        Return cls_at.Cd_AnularPedidoVenta("[i_pa_anular_pedidoventa]", obj)
    End Function
    Public Function Cn_AnularRequerimiento(ByRef obj As coVentas) As String
        Return cls_at.Cd_AnularRequerimiento("[i_pa_anular_requerimiento]", obj)
    End Function

    Public Function Cn_AnularrecepcionRequerimiento(ByRef obj As coVentas) As String
        Return cls_at.Cd_AnularrecepcionRequerimiento("[i_pa_anular_recepcion_requerimientos]", obj)
    End Function
    Public Function Cn_AnularGuia(ByRef obj As coVentas) As String
        Return cls_at.Cd_AnularGuia("[i_pa_anular_guia_pedido_venta]", obj)
    End Function
    Public Function Cn_ActualizarConfirmarGuia(ByRef obj As coVentas) As String
        Return cls_at.Cd_ActualizarConfirmarGuia("[i_actualizar_confirmar_guias_pedido]", obj)
    End Function

    Public Function Cn_ConfirmarEntregaPedido(ByRef obj As coVentas) As String
        Return cls_at.Cd_ConfirmarEntregaPedido("[i_confirmar_entrega_pedido]", obj)
    End Function

    Public Function Cn_ConsultarVentas(ByRef obj As coVentas) As DataSet
        Return cls_at.ConsultarVentasFacturadas("[i_pa_cons_control_ventas]", obj)
    End Function
    Public Function Cn_ConsultarPedidosVentaEnviadasaFacturacion(ByRef obj As coVentas) As DataSet
        Return cls_at.ConsultarPedidoEnviadoFacturacion("[i_pa_cons_control_pedidos_pendientes_enviados_facturacion]", obj)
    End Function
    Public Function Cn_RegVenta(ByRef obj As coVentas) As String
        Return cls_at.Cd_FacturaciónVenta("[i_pa_regventa]", obj)
    End Function
    'Public Function Cn_RegVenta(ByRef obj As coVentas) As String
    '    Return cls_at.Cd_FacturaciónVenta("[i_pa_regventa_regularizacion]", obj)
    'End Function
    Public Function Cn_ModificarVenta(ByRef obj As coVentas) As String
        Return cls_at.Cd_ModificarVenta("[i_pa_modifcarventa]", obj)
    End Function
    Public Function Cn_anularnevioafacturacion(ByRef obj As coVentas) As String
        Return cls_at.Cd_anularnevioafacturacion("[i_pa_revertirventa]", obj)
    End Function
    Public Function Cn_ConsultarPedidoVentaxCodigo(ByRef obj As coVentas) As DataSet
        Return cls_at.ConsultarPedidoVentaxCodigo("[i_pa_cons_pedidoventa_x_codigo]", obj)
    End Function
    Public Function Cn_ConsultarPesosGancho(ByRef obj As coVentas) As DataSet
        Return cls_at.ConsultarPesosGancho("[i_pa_listar_pesos_gancho]", obj)
    End Function
    Public Function Cn_ConsultarPedidoVentaparaFacturacionxCodigolista(ByRef obj As coVentas) As DataSet
        Return cls_at.ConsultarPedidoVentaxCodigolista("[i_pa_cons_pedidoventa_para_facturacion_x_codigo_ventas]", obj)
    End Function
    Public Function Cn_ConsultarPedidoVentaparaFacturacionxCodigolistageneral(ByRef obj As coVentas) As DataSet
        Return cls_at.ConsultarPedidoVentaxCodigolista("[i_pa_cons_pedidoventa_resumen_x_codigo_ventas]", obj)
    End Function
    Public Function Cn_ConsultarRequerimientoxCodigo(ByRef obj As coVentas) As DataSet
        Return cls_at.ConsultarRequerimientoxCodigo("[i_pa_cons_requerimiento_x_codigo]", obj)
    End Function
    Public Function Cn_ListarTablasMaestrasFacturacion() As DataSet
        Return cls_at.ListarTablasMaestras("[i_pa_listar_tablas_maestras_pedido_venta]")
    End Function

    Public Function Cn_ConsultarDespachoCerdoGranja(ByRef obj As coVentas) As DataTable
        Return cls_at.Cd_ConsultarDespachoCerdoGranja("[w_pa_despachos_cerdo_granja]", obj)
    End Function

    Public Function Consultarpedidosventasagrupadoporcliente(ByRef obj As coVentas) As DataTable
        Return cls_at.Cd_ConsultarDespachoCerdoGranja("[j_pa_reporte_salida_pesos_cerdo_agrupado]", obj)
    End Function
    Public Function Cn_ReportePesosPorVendedor(ByRef obj As coVentas) As DataTable
        Return cls_at.Cd_ReportePesosPorVendedor("[r_pa_reporte_pesos_por_vendedor]", obj)
    End Function
    Public Function Cn_ListarVendedoresActivos() As DataTable
        Return cls_at.ListarVendedoresActivos("[r_pa_listar_vendedores_activos]")
    End Function
    Public Function Cn_ListarMotivoTransaccionCerdos() As DataTable
        Return cls_at.ListarMotivoTransaccionCerdos("[r_pa_listar_motivos_transaccion_cerdo]")
    End Function
    Public Function Cn_ListarTipoPeso() As DataTable
        Return cls_at.ListarTipoPeso("[r_pa_listar_peso_gancho_vivo]")
    End Function
    Public Function Cn_ReporteVentaCerdosPorVendedor(ByRef obj As coVentas) As DataTable
        Return cls_at.Cd_ReporteVentaCerdosPorVendedoranio("[r_pa_reporte_ventas_cerdos_x_vendedor]", obj)
    End Function
    Public Function Cn_ReporteVentaCerdosconsolidadoIs(ByRef obj As coVentas) As DataTable
        Return cls_at.Cd_ReporteVentaCerdosPorVendedoranio("[j_pa_reporte_ventas_cerdos_consolidado_IS]", obj)
    End Function
    Public Function Cn_ReporteVentaconsolidado(ByRef obj As coVentas) As DataTable
        Return cls_at.Cd_ReporteVentaconsolidado("[j_pa_reporte_consolidado_mensual_ventas_cerdos]", obj)
    End Function
    Public Function Cn_ReporteVentaconsolidadoanual(ByRef obj As coVentas) As DataTable
        Return cls_at.Cd_ReporteVentaconsolidado("[j_pa_reporte_consolidado_anual_ventas_cerdos]", obj)
    End Function
    Public Function Cn_ReporteVentaCerdosPorcliente(ByRef obj As coVentas) As DataTable
        Return cls_at.Cd_ReporteVentaCerdosPorcliente("[j_pa_reporte_ventas_cerdos_x_cliente]", obj)
    End Function
    Public Function Cn_ReporteCobrosVentas(ByRef obj As coVentas) As DataTable
        Return cls_at.Cd_ReporteVentaCerdosPorcliente("[j_pa_reporte_cobros_x_cliente]", obj)
    End Function
    Public Function Cn_ReporteVentaresumen(ByRef obj As coVentas) As DataTable
        Return cls_at.Cd_ReporteVentaresumen("[j_pa_promedio_cerdos_por_tipo]", obj)
    End Function
    Public Function Cn_Resumenstockmoyocha() As DataSet
        Return cls_at.Cd_Resumenstockmoyocha("[j_pa_consultar_stock_moyo_chacha]")
    End Function
    Public Function Cn_Consolidadoventascerdos(ByRef obj As coVentas) As DataTable
        Return cls_at.Cd_ReporteVentaCerdosPorVendedor("[j_pa_promedio_cerdos_por_tipo]", obj)
    End Function
    Public Function Cn_ReporteVentaAnualCerdos(ByRef obj As coVentas) As DataTable
        Return cls_at.Cd_ReporteVentaAnualCerdos("[r_pa_reporte_consolidado_venta_cerdos]", obj)
    End Function
    Public Function Cn_ReporteGuiasAsociadasVenta(ByRef obj As coVentas) As DataSet
        Return cls_at.Cd_ReporteGuiasAsociadasVenta("[j_pa_reporte_ventas_muerte_conductores]", obj)
    End Function
    Public Function Cn_Reporteventaskilos(ByRef obj As coVentas) As DataSet
        Return cls_at.Cd_ReporteGuiasAsociadasVenta("[j_pa_reporte_ventas_por_kg]", obj)
    End Function
End Class
