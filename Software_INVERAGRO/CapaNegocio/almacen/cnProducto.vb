Imports CapaDatos
Imports CapaObjetos

Public Class cnProducto
    Private cls_at As New cdProducto
    Public Function Cn_Mantenimiento(ByRef obj As coProductos) As String
        Return cls_at.Cd_Mantenimiento("[i_pa_mant_producto]", obj)
    End Function
    Public Function Cn_Consultar(obj As coProductos) As DataTable
        Return cls_at.Cd_Listar("[i_pa_cons_producto]", obj)
    End Function
    Public Function Cn_Consultarunidamedidas(obj As coProductos) As DataTable
        Return cls_at.Cd_Listarunidadmedidas("[j_pa_consultar_unidad_medida]", obj)
    End Function
    Public Function Cn_ConsultarReporteDashboard(obj As coProductos) As DataTable
        Return cls_at.Cd_ListarDashboard("[i_pa_cons_producto_reporte_dashboard]", obj)
    End Function
    Public Function Cn_ConsultarStockAlmacenes(obj As coProductos) As DataTable
        Return cls_at.Cd_ListarStockAlmacenes("[i_pa_cons_producto_pivot]", obj)
    End Function
    Public Function Cn_ListarInsumosActivos() As DataTable
        Return cls_at.Cd_ListadoGeneral("[w_pa_listar_insumos_activos]")
    End Function
    Public Function Cn_ListarAlmacenes(obj As coProductos) As DataTable
        Return cls_at.Cd_ListarAlmacen("[i_pa_list_almacenes]", obj)
    End Function
    Public Function Cn_ListardistribuidoresAlmacenes(obj As coProductos) As DataTable
        Return cls_at.Cd_ListarAlmacen("[i_pa_list_distribuidora_almacenes]", obj)
    End Function
    Public Function Cn_ListarPlanteles() As DataTable
        Return cls_at.Cd_ListarPlanteles("[i_pa_list_planteles]")
    End Function
    Public Function Cn_ListarPedidosCerdos_x_guia(idguia As Integer) As DataTable
        Return cls_at.Cd_ListarPedidosCerdosxGuia("[i_pa_list_pedidos_cerdos_x_guia]", idguia)
    End Function
    Public Function Cn_ListarPedidosCerdos_x_guia_controlventas(idguia As Integer) As DataTable
        Return cls_at.Cd_ListarPedidosCerdosxGuia("[j_pa_list_pedidos_cerdos_x_guia]", idguia)
    End Function
    Public Function Cn_ListCategoria() As DataTable
        Return cls_at.Cd_ListadoGeneral("[i_pa_list_categoria]")
    End Function
    Public Function Cn_ListUnidadMedida(obj As coProductos) As DataTable
        Return cls_at.Cd_ListarUnidadMedida("[i_pa_list_unidadmedida]", obj)
    End Function
    Public Function Cn_ListPresentaciones(obj As coProductos) As DataTable
        Return cls_at.Cd_ListarPresentaciones("[i_pa_list_presentaciones]", obj)
    End Function
    Public Function Cn_ListMarcas(obj As coProductos) As DataTable
        Return cls_at.Cd_ListaMarcasxCategoria("[i_pa_list_marcas_x_categoria]", obj)
    End Function
    Public Function Cn_Consultar_x_codigo(obj As coProductos) As DataTable
        Return cls_at.Cd_ListarxCodigo("i_pa_cons_producto_x_codigo", obj)
    End Function
    Public Function Cn_ListarProductoEpp(obj As coProductos) As DataTable
        Return cls_at.Cd_listado_epps("[w_pa_listar_producto_epp]", obj)
    End Function
    Public Function Cn_ListarProductoLineaGenetica() As DataTable
        Return cls_at.Cd_ListadoGeneral("[w_pa_listar_producto_linea_genetica]")
    End Function
    Public Function Cn_ConsultarKardexProductoPorId(obj As coProductos) As DataTable
        Return cls_at.Cd_ConsultarKardexProductoPorId("[i_ObtenerKardexMovimientosProducto]", obj)
    End Function
    Public Function Cn_ConsultarEstadoCuentaBancario(obj As coProductos) As DataTable
        Return cls_at.Cd_ConsultarEstadoCuentaBancario("[i_sp_ObtenerMovimientosCtaBanco]", obj)
    End Function
    Public Function Cn_ConsultarIngresoProductoPorId(obj As coProductos) As DataTable
        Return cls_at.Cd_ConsultarIngresoProductoPorId("[w_obtener_ingresos_por_producto]", obj)
    End Function
    Public Function Cn_ConsultarRecepcionProductoPorId(obj As coProductos) As DataTable
        Return cls_at.Cd_ConsultarIngresoProductoPorId("[j_pa_cons_recepcion_x_ingreso]", obj)
    End Function
    Public Function Cn_ListarAlertas(obj As coProductos) As DataSet
        Return cls_at.Cd_ListarAlertas("[i_pa_gestion_de_alertas]", obj)
    End Function
    Public Function Cn_ConsultarKardexProductoPorIdyUbicacion(obj As coProductos) As DataTable
        Return cls_at.Cd_ConsultarKardexProductoPorIdyUbicacion("[i_ObtenerKardexMovimientosProductoxUbicacion]", obj)
    End Function
    Public Function Cn_ListarMedicamentosActivos(ByVal idAlmacen As Integer) As DataTable
        Return cls_at.Cd_ListarMedicamentosActivos("[w_pa_listar_medicamentos_activo]", idAlmacen)
    End Function
    Public Function Cn_ListarAlmacenPrincipal() As DataTable
        Return cls_at.Cd_ListadoGeneral("[w_pa_listar_almacen_principal]")
    End Function
    Public Function Cn_ConsultarProductoSemen(obj As coProductos) As DataTable
        Return cls_at.Cd_ConsultarProductoSemenPorcino("[w_pa_cons_producto_semen]", obj)
    End Function
    Public Function Cn_ConsultarProductoCerda(obj As coProductos) As DataTable
        Return cls_at.Cd_ConsultarProductoSemenPorcino("[w_pa_cons_producto_cerda]", obj)
    End Function
    Public Function Cn_ConsultarProductoVerraco(obj As coProductos) As DataTable
        Return cls_at.Cd_ConsultarProductoSemenPorcino("[w_pa_cons_producto_verraco]", obj)
    End Function

    Public Function Cn_RegistrarLotizarProductoFecVenc(ByRef obj As coProductos) As String
        Return cls_at.Cd_RegistrarLotizarProductoFecVenc("[w_pa_insertar_lote_producto]", obj)
    End Function

    Public Function Cn_ListarLoteProducto(obj As coProductos) As DataTable
        Return cls_at.Cd_ListarLoteProducto("[w_pa_listar_stock_lote]", obj)
    End Function
    Public Function Cn_ReporteGastosVeterinarios(ByRef obj As coProductos) As DataTable
        Return cls_at.Cd_ReporteGastosVeterinarios("[r_pa_reporte_gastos_veterinarios_x_plantel]", obj)
    End Function

    Public Function Cn_ReportevalorizadoAlmacen(ByRef obj As coProductos) As DataTable
        Return cls_at.Cd_ReporteGastosVeterinarios("[r_pa_reporte_valorizacion_plantel]", obj)
    End Function
    Public Function Cn_ReporteGastosAsignaciones(ByRef obj As coProductos) As DataTable
        Return cls_at.Cd_ReporteGastosAsignaciones("[r_pa_reporte_gastos_varios_x_plantel]", obj)
    End Function
    Public Function Cn_RegistrarAsignacionMultipleUnidadesMedida(ByRef obj As coProductos) As String
        Return cls_at.Cd_RegistrarAsignacionMultipleUnidadesMedida("[r_pa_registrar_asignacion_unidades_medida]", obj)
    End Function
    Public Function Cn_Editarunidadesmedida(ByRef obj As coProductos) As String
        Return cls_at.Cd_RegistrarAsignacionMultipleUnidadesMedida("[j_editar_unidades_medida]", obj)
    End Function
    Public Function Cn_Eliminarunidadesmedida(ByRef obj As coProductos) As String
        Return cls_at.Cd_eliminarUnidadesMedida("[j_pa_eliminar_unidad_medida]", obj)
    End Function
    Public Function Cn_ListarUnidadesMedidaPorProducto(ByRef obj As coProductos) As DataTable
        Return cls_at.Cd_ListarUnidadesMedidaPorProducto("[r_pa_listar_unidades_medida_x_producto]", obj)
    End Function
End Class
