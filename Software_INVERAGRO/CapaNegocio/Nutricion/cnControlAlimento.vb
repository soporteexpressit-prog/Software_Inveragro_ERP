Imports CapaDatos
Imports CapaObjetos

Public Class cnControlAlimento
    Private cls_at As New cdControlAlimento

    Public Function Cn_RegistrarRequerimientoAlimento(obj As coControlAlimento) As String
        Return cls_at.Cd_RegistrarRequerimientoAlimento("[w_pa_reg_requerimiento_alimento]", obj)
    End Function

    Public Function Cn_ListarRequerimientoAlimento(obj As coControlAlimento) As DataSet
        Return cls_at.Cd_ListarRequerimientoAlimento("[w_pa_listar_requerimientos_alimento]", obj)
    End Function

    Public Function Cn_ObtenerRequerimientoAlimentoxId(obj As coControlAlimento) As DataTable
        Return cls_at.Cd_ObtenerRequerimientoAlimentoxId("[w_pa_obtener_requerimiento_alimento_x_id]", obj)
    End Function

    Public Function Cn_ActualizarRequerimientoAlimento(obj As coControlAlimento) As String
        Return cls_at.Cd_ActualizarRequerimientoAlimento("[w_pa_actualizar_requerimiento_alimento]", obj)
    End Function

    Public Function Cn_ConsultarExtra(obj As coControlAlimento) As DataSet
        Return cls_at.Cd_ConsultarExtra("[w_pa_cons_extra]", obj)
    End Function

    Public Function Cn_RegistrarMedicamentoExtra(obj As coControlAlimento) As String
        Return cls_at.Cd_RegistrarMedicamentoExtra("[w_pa_reg_producto_extra]", obj)
    End Function

    Public Function Cn_ActualizarEstadoExtra(obj As coControlAlimento) As String
        Return cls_at.Cd_ActualizarEstadoExtra("[w_actualizar_estado_extra]", obj)
    End Function

    Public Function Cn_ConsolidadoAlimentoxSemana(obj As coControlAlimento) As DataTable
        Return cls_at.Cd_ConsolidadoAlimentoxSemana("[w_pa_consolidado_alimento_x_semana]", obj)
    End Function

    Public Function Cn_RequerimientoAlimentoxSemana(obj As coControlAlimento) As DataSet
        Return cls_at.Cd_RequerimientoAlimentoxSemana("[w_pa_cons_requerimiento_alimento_x_semana]", obj)
    End Function

    Public Function Cn_ConsolidadoAlimentoxSemanaAprobado(obj As coControlAlimento) As DataTable
        Return cls_at.Cd_ConsolidadoAlimentoxSemanaNutricionista("[w_pa_consolidado_requerimiento_alimento_x_semana_aprobado]", obj)
    End Function

    'Public Function Cn_ConsolidadoInsumoPlusPedirxSemana(ByRef obj As coControlAlimento) As Object
    '    Dim resultado As Object = cls_at.Cd_ConsolidadoAlimentoPedirxSemana("[w_pa_consolidado_plus_pedir_x_semana]", obj)

    '    If TypeOf resultado Is String Then
    '        Return resultado
    '    Else
    '        Return CType(resultado, DataTable)
    '    End If
    'End Function

    Public Function Cn_ConsolidadoAlimentoPedirxSemana(ByRef obj As coControlAlimento) As Object
        Dim resultado As Object = cls_at.Cd_ConsolidadoAlimentoPedirxSemana("[w_pa_reporte_alimento_preparado_semana]", obj)

        If TypeOf resultado Is String Then
            Return resultado
        Else
            Return CType(resultado, DataTable)
        End If
    End Function

    Public Function Cn_ConsolidadoAlimentoPedirxSemanaNutricionista(ByRef obj As coControlAlimento) As Object
        Dim resultado As Object = cls_at.Cd_ConsolidadoAlimentoPedirxSemanaNutricionista("[w_pa_consolidado_alimento_pedir_x_semana_por_nutricionista]", obj)

        If TypeOf resultado Is String Then
            Return resultado
        Else
            Return CType(resultado, DataTable)
        End If
    End Function

    Public Function Cn_AnularRequerimientoAlimento(obj As coControlAlimento) As String
        Return cls_at.Cd_AnularRequerimientoAlimento("[w_pa_cancelar_pedido_alimento]", obj)
    End Function

    Public Function Cn_ConsultarAlimentoPedir(obj As coControlAlimento) As DataSet
        Return cls_at.Cd_ConsultarAlimentoPedir("[w_pa_cons_alimento_pedir]", obj)
    End Function

    Public Function Cn_RegistrarListaInsumosPedir(ByRef obj As coControlAlimento) As String
        Return cls_at.Cd_RegistrarListaInsumosPedir("[w_pa_registrar_lista_alimento_pedir]", obj)
    End Function

    Public Function Cn_AgruparPedidoAlimentoxTipoAlimento(obj As coControlAlimento) As DataSet
        Return cls_at.Cd_AgruparPedidoAlimentoxTipoAlimento("[w_pa_agrupar_salidas_por_tipo_alimento]", obj)
    End Function

    Public Function Cn_ListarDetalleAlimentoxIds(obj As coControlAlimento) As DataTable
        Return cls_at.Cd_ListarDetalleAlimentoxIds("[w_pa_listar_detalle_salida_x_ids]", obj)
    End Function

    Public Function Cn_ConsolidadoExtraMedicamentoAlimento(obj As coControlAlimento) As DataTable
        Return cls_at.Cd_ListarDetalleAlimentoxIds("[w_pa_obtener_consolidado_extra_medicamento_alimento]", obj)
    End Function

    Public Function Cn_MantenimientoPlanMedicado(ByRef obj As coControlFormulacion) As String
        Return cls_at.Cd_MantenimientoPlanMedicado("[w_pa_reg_racion_plan_medico]", obj)
    End Function

    Public Function Cn_ListarAlimentoCerdoActivo(ByRef idAlmacen As Integer) As DataTable
        Return cls_at.Cd_ListarAlimentoCerdoActivo("[r_pa_listar_alimento_cerdo_activo]", idAlmacen)
    End Function

    Public Function Cn_ListarAlimentoPresupuesto(ByRef idAlmacen As Integer) As DataTable
        Return cls_at.Cd_ListarAlimentoCerdoActivo("[w_pa_listar_alimento_cerdo_presupuesto]", idAlmacen)
    End Function

    Public Function Cn_RegistrarAlimentoCerdo(ByRef obj As coControlAlimento) As String
        Return cls_at.Cd_RegistrarAlimentoCerdo("[r_pa_reg_salida_alimento_cerdo]", obj)
    End Function

    Public Function Cn_ConsultarAlimentoCerdo(ByRef obj As coControlAlimento) As DataSet
        Return cls_at.Cd_ConsultarAlimentoCerdo("[r_pa_cons_alimento_cerda]", obj)
    End Function

    Public Function Cn_AnularAlimentoCerdo(ByRef obj As coControlAlimento) As String
        Return cls_at.Cd_AnularAlimentoCerdo("[r_pa_anular_salida_alimento_cerdo]", obj)
    End Function

    Public Function Cn_ConsultarDetalleSalidaAntiMedicadoRacion(ByRef obj As coControlAlimento) As DataTable
        Return cls_at.Cd_ConsultarDetalleSalidaAntiMedicadoRacion("[w_pa_listar_detalle_salida_anti_medicado]", obj)
    End Function

    Public Function Cn_ConsultarMedicacionesRacion(obj As coControlAlimento) As DataSet
        Return cls_at.Cd_ConsultarMedicacionesRacion("[w_pa_cons_periodo_medicacion_x_idracion]", obj)
    End Function

    Public Function Cn_ConsultarMedicacionesPlusRacion(obj As coControlAlimento) As DataSet
        Return cls_at.Cd_ConsultarMedicacionesPlusRacion("[w_pa_cons_periodo_medicacion_plus_x_idracion]", obj)
    End Function

    Public Function Cn_ObtenerPeriodoMedicacionRacion(obj As coControlAlimento) As DataTable
        Return cls_at.Cd_ObtenerPeriodoMedicacionRacion("[w_pa_obtener_medicamento_racion]", obj)
    End Function

    Public Function Cn_ObtenerHistorioPreparaciones(ByRef obj As coControlAlimento) As DataSet
        Return cls_at.Cd_ObtenerHistorioPreparaciones("[w_pa_detalle_preparacion_alimento]", obj)
    End Function

    Public Function Cn_CancelarPreparacionAlimento(ByRef obj As coControlAlimento) As String
        Return cls_at.Cd_CancelarPreparacionAlimento("[w_pa_cancelar_preparacion_alimento]", obj)
    End Function

    Public Function Cn_ListarDetalleCorrales(ByRef obj As coControlAlimento) As DataTable
        Return cls_at.Cd_ListarDetalleCorrales("[r_pa_detalle_corrales_x_alimento]", obj)
    End Function

    Public Function Cn_ReporteAlimentoPorPlantel(ByRef obj As coControlAlimento) As DataSet
        Return cls_at.Cd_ReporteAlimentoPorPlantel("[r_pa_cons_reporte_alimento_x_plantel]", obj)
    End Function

    Public Function Cn_ListarCampañasPorPlantel(ByRef obj As coControlAlimento) As DataTable
        Return cls_at.Cd_ListarCampañasPorPlantel("[r_pa_listar_campañas_x_plantel]", obj)
    End Function

    Public Function Cn_ConsultarCumplimientoPresupuestoAli(ByRef obj As coControlAlimento) As DataTable
        Return cls_at.Cd_ConsultarCampañaGalpon("[w_pa_reporte_consumo_alimento_diario]", obj)
    End Function

    Public Function Cn_ConsultarConsumoDiarioAlimento(ByRef obj As coControlAlimento) As DataTable
        Return cls_at.Cd_ConsultarCampañaGalpon("[w_pa_plantel_engorde_consumo]", obj)
    End Function

    Public Function Cn_ConsultarAlimentoAnual(ByRef obj As coControlAlimento) As DataTable
        Return cls_at.Cd_ConsultarAlimentoAnual("[w_pa_reporte_anual_consumo_alimento]", obj)
    End Function

    Public Function Cn_ReporteAlimentoPorPlantelReproductor(ByRef obj As coControlAlimento) As DataSet
        Return cls_at.Cd_ReporteAlimentoPorPlantelReproductor("[w_pa_cons_reporte_alimento_x_plantel_reproductor]", obj)
    End Function

    Public Function Cn_ActualizarEstadoPresupuestoProducto(ByRef obj As coControlAlimento) As String
        Return cls_at.Cd_ActualizarEstadoPresupuestoProducto("[w_pa_actualizar_estado_presupuesto_producto]", obj)
    End Function

    Public Function Cn_RegistrarAlimentacionPresupuesto(ByRef obj As coControlAlimento) As String
        Return cls_at.Cd_RegistrarAlimentacionPresupuesto("[w_pa_alimentar_grupo_presupuesto]", obj)
    End Function

    Public Function Cn_ListarxUbicacionLoteGrupoProducto(ByRef obj As coControlAlimento) As DataTable
        Return cls_at.Cd_ListarxUbicacionLoteGrupoProducto("[w_pa_consultar_distribucion_grupo]", obj)
    End Function

    Public Function Cn_ListarxDetalleAlimentoGrupo(ByRef obj As coControlAlimento) As DataTable
        Return cls_at.Cd_ListarxUbicacionGrupoProducto("[w_pa_consultar_detalle_alimento_grupo]", obj)
    End Function

    Public Function Cn_EliminarDetalleAlimentoGrupo(ByRef obj As coControlAlimento) As String
        Return cls_at.Cd_EliminarDetalleAlimentoGrupo("[w_pa_cancelar_alimento_grupo]", obj)
    End Function

    Public Function Cn_ReporteSemanalPedidoAlimento(obj As coControlAlimento) As DataTable
        Return cls_at.Cd_ReporteSemanalPedidoAlimento("[w_pa_reporte_semanal_pedidos_alimento_consolidado]", obj)
    End Function

    Public Function Cn_ModificarCampañaPedido(ByRef obj As coControlAlimento) As String
        Return cls_at.Cd_ModificarCampañaPedido("[w_pa_modificar_campaña_pedido]", obj)
    End Function
End Class
