Imports CapaDatos
Imports CapaObjetos

Public Class cnControlLoteDestete
    Private cls_at As New cdControlLoteDestete

    Public Function Cn_MantenimientoLote(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_MantenimientoLote("[w_pa_mant_lote]", obj)
    End Function

    Public Function Cn_ConsultarLotesUltimos(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxIdUbicacion("[w_pa_listar_ultimos_lotes]", obj)
    End Function

    Public Function Cn_ConsultarLotesAnio(obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarLoteAnio("[w_pa_listar_lotes_por_anio]", obj)
    End Function

    Public Function Cn_ConsultarLotesAnioCombo(obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarLoteAnio("[w_pa_listar_lotes_por_anio_combo]", obj)
    End Function

    Public Function Cn_ConsultarLotesUnicos(obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxAnioDt("[w_pa_listar_lotes_unicos]", obj)
    End Function

    Public Function Cn_ConsultarLotesxAnio(obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarxAnioUbicacion("[w_pa_cons_lotes_por_anio]", obj)
    End Function

    Public Function Cn_CambiarLoteCerdaCrias(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_CambiarLoteCerdaCrias("[w_pa_cambiar_lote_cerda_crias]", obj)
    End Function

    Public Function Cn_ConsultarCerdaLoteUbicacionDestete(obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxLoteUbicacionDt("[w_pa_cons_cerdas_destete_ubicacion_lote]", obj)
    End Function

    Public Function Cn_ConsultarCamadasDestetadasxLote(obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxLoteUbicacionDt("[w_pa_cons_camadas_destetadas_lote]", obj)
    End Function

    Public Function Cn_ConsultarCorralesPorLote(ByRef obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarxLoteUbicacionDs("[w_pa_cons_corrales_por_lote]", obj)
    End Function

    Public Function Cn_ConsultarAnimalesLoteClinica(ByRef obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarxLoteUbicacionDs("[w_pa_cons_corrales_animales_por_lote_clinica]", obj)
    End Function

    Public Function Cn_ConsultarAnimalesLoteTransitoBajadaRetorno(ByRef obj As coControlLoteDestete) As Object
        Dim resultado As Object = cls_at.Cd_ObtenerAnimalesLoteBajada("[w_pa_cons_corrales_animales_por_lote_transito]", obj)

        If TypeOf resultado Is String Then
            Return resultado
        Else
            Return CType(resultado, DataSet)
        End If
    End Function

    Public Function Cn_ConsultarAnimalesxIdJaulaCorral(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarAnimalesxIdJaulaCorral("[w_pa_cons_animales_por_jaula_corral]", obj)
    End Function

    Public Function Cn_ConsultarAnimalesxIdJaulaCorralMadreFutura(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarAnimalesxIdJaulaCorral("[w_pa_cons_animales_por_jaula_corral_mf]", obj)
    End Function

    Public Function Cn_ConsultarAnimalesClinica(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxIdUbicacion("[w_pa_cons_animales_clinica]", obj)
    End Function

    Public Function Cn_ConsultarAnimalesxIdJaulaCorralRegularizacion(ByRef obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarAnimalesxIdJaulaCorralRegularizacion("[w_pa_cons_animales_por_jaula_corral_regularizacion]", obj)
    End Function

    Public Function Cn_RegistrarBajada(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RegistrarBajada("[w_pa_registrar_bajada_lote]", obj)
    End Function

    Public Function Cn_ConsultarAnimalesxIdJaulaCorralAjustar(ByRef obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarAnimalesxIdJaulaCorralAjuste("[w_pa_cons_animales_por_jaula_corral_ajuste]", obj)
    End Function

    Public Function Cn_ConsultarAnimalesRegistradosxLoteSinAjustar(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.ConsultarxLoteDt("[w_pa_obtener_animales_reg_por_lote_sin_ajuste]", obj)
    End Function

    Public Function Cn_ConsultarAnimalesRegistradosxLote(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarDepuracionxIdLote("[w_pa_obtener_animales_reg_por_lote]", obj)
    End Function

    Public Function Cn_AjustarAnimalesxJaulaCorral(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_AjustarAnimalesxJaulaCorral("[w_pa_actualizar_ajustado_jaulacorral]", obj)
    End Function

    Public Function Cn_AjustarCerdosCorral(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_AjustarCerdosCorral("[w_pa_ajustar_cerdos_corral]", obj)
    End Function

    Public Function Cn_ConsultarBajadaLotexAnio(obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarxAnioUbicacion("[w_pa_cons_bajada_lote_x_anio]", obj)
    End Function

    Public Function Cn_RegistrarMovimientoUbicacion(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RegistrarMovimientoUbicacion("[w_pa_reg_movimiento_ubicacion_lote]", obj)
    End Function

    Public Function Cn_RegistrarMovimientoUbicacionxLote(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RegistrarMovimientoUbicacionxLote("[w_pa_reg_movimiento_ambiente_x_lote]", obj)
    End Function

    Public Function Cn_RegistrarMovimientoZonaEspera(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RegistrarMovimientoZonaEspera("[w_pa_ubicar_animales_zona_espera]", obj)
    End Function

    Public Function Cn_RegistrarRetorno(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RegistrarRetorno("[w_pa_registrar_retorno_chanchillas_puras]", obj)
    End Function

    Public Function Cn_RegistrarControlDescarteMadreFutura(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RegistrarControlDescarteMadreFutura("[w_pa_reg_control_ficha_descarte]", obj)
    End Function

    Public Function Cn_ConsultarAnimalesRetornarxLote(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarDepuracionxIdLote("[w_pa_contar_pura_y_chanchilla_por_lote_retornar]", obj)
    End Function

    Public Function Cn_ConsultarMovimientoRetornoxLote(ByRef obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarxAnioUbicacion("[w_pa_cons_movimientos_por_plantel_llegada]", obj)
    End Function

    Public Function Cn_ConsultarDepuracionCerdaxLotexUbicacion(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxLoteUbicacionDt("[w_pa_cons_depuracion_cerda]", obj)
    End Function

    Public Function Cn_ConsultarCriasMortalidadLote(ByRef obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsCriasMortalidadLote("[r_pa_cons_crias_mortalidad_lote]", obj)
    End Function

    Public Function Cn_EliminarEventoMortalidadLote(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_EliminarEventoMortalidadLote("[r_pa_eliminar_evento_mortalidad_lote]", obj)
    End Function

    Public Function Cn_MovimientoMadreFutura(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_MovimientoMadreFutura("[w_pa_reg_movimiento_madre_futura]", obj)
    End Function

    Public Function Cn_ConsultarCorralesPorLoteMortalidad(ByRef obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarxLoteUbicacionDs("[r_pa_cons_corrales_por_lote_mortalidad]", obj)
    End Function

    Public Function Cn_CancelarDepuracionMadreFutura(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_CancelarDepuracionMadreFutura("[w_pa_cancelar_depuracion_madre_futura]", obj)
    End Function

    Public Function Cn_ConsultarResumenLotes(obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarxAnioDs("[w_pa_const_resumen_lote_anual]", obj)
    End Function

    Public Function Cn_ConsultarCorralesMadreFutura(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxLoteUbicacionDt("[w_pa_cons_corrales_por_lote_mortalidad_mf]", obj)
    End Function

    Public Function Cn_RegistrarDesteteCrias(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RegistrarDesteteCrias("[w_pa_actualizar_estado_destete_crias]", obj)
    End Function

    Public Function Cn_ConsultarRegularizacionPlantel(obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarRegularizacionPlantel("[w_pa_cons_regularizar_cerdo]", obj)
    End Function

    Public Function Cn_AnularRegularizacionCerdo(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_AnularRegularizacionCerdo("[w_pa_anular_regularizacion_cerdo]", obj)
    End Function

    Public Function Cn_ConsultarMadresFuturasCodificar(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxLoteUbicacionChanchillaDt("[w_pa_cons_pura_camborough_x_ubicacion]", obj)
    End Function

    Public Function Cn_ConsultarHistorialLote(obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxLoteUbicacionDt("[w_pa_cons_historia_lotes]", obj)
    End Function

    Public Function Cn_ConsultarReportePlantelCampaña(obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarReporteGeneralLote("[w_pa_reporte_proyeccion_lote_venta]", obj)
    End Function

    Public Function Cn_ConsultarMortalidadDetalladoCampaña(obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarReporteGeneralLote("[w_pa_reporte_mortalidad_detallado_campaña]", obj)
    End Function

    Public Function Cn_ConsultarReporteDistribucionPlantel(obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxIdUbicacion("[w_pa_obtener_informacion_lotes_proyeccion]", obj)
    End Function

    Public Function Cn_RegistrarAnimalClinica(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RegistrarAnimalClinica("[w_pa_mandar_clinica_animal_x_lote]", obj)
    End Function

    Public Function Cn_RetirarAnimalClinica(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RetirarAnimalClinica("[w_pa_retirar_animal_clinica]", obj)
    End Function

    Public Function Cn_RegistrarConfirmacionBajada(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RegistrarConfirmacionBajada("[w_pa_confirmacion_bajada_transito]", obj)
    End Function

    Public Function Cn_CancelarConfirmacionBajada(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_CancelarConfirmacionEnvio("[w_pa_cancelar_confirmacion]", obj)
    End Function

    Public Function Cn_CancelarBajada(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_CancelarConfirmacionEnvio("[w_pa_cancelar_bajada]", obj)
    End Function

    Public Function Cn_CancelarConfirmacionRetorno(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_CancelarConfirmacionChanchillas("[w_pa_cancelar_confirmacion_retorno]", obj)
    End Function

    Public Function Cn_CancelarRetorno(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_CancelarConfirmacionEnvio("[w_pa_cancelar_retorno]", obj)
    End Function

    Public Function Cn_RegistrarPesoBajada(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RegistrarPesoBajada("[w_pa_registrar_peso_bajada]", obj)
    End Function

    Public Function Cn_RegistrarVentaLote(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RegistrarVentaLote("[w_pa_reg_venta_lote]", obj)
    End Function

    Public Function Cn_CancelarVentaLote(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_CancelarVentaLote("[w_pa_cancelar_venta_lote]", obj)
    End Function

    Public Function Cn_ConsultarLotesPartos(ByRef obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarxIdLoteDs("[w_pa_cons_reporte_partos]", obj)
    End Function

    Public Function Cn_ConsultarClinica(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxIdUbicacion("[w_pa_consultar_clinicas]", obj)
    End Function

    Public Function Cn_ConsultarLotesDestete(ByRef obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarxIdLoteDs("[w_pa_cons_reporte_destete_v2]", obj)
    End Function

    Public Function Cn_ConsultarPesoLotexIdMovimiento(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxIdMovimiento("[w_pa_consultar_peso_lote]", obj)
    End Function

    Public Function Cn_ConsultarCerdasRetornarxLotes(ByRef obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarCerdasRetornarxLotes("[w_pa_contar_chanchillas_por_lotes_retornar]", obj)
    End Function

    Public Function Cn_RegistrarConfirmacionRetorno(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RegistrarConfirmacionRetorno("[w_pa_confirmar_llegada_chanchillas]", obj)
    End Function

    Public Function Cn_ConsultarReporteMortalidadLoteEdad(obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxLoteUbicacionDt("[w_pa_reporte_mortalidad_edad_pic]", obj)
    End Function

    Public Function Cn_ConsultarCampaña(obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarxAnioDs("[w_pa_cons_control_campañas]", obj)
    End Function

    Public Function Cn_EdadPromedioLoteDestete(ByRef obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultaxIdLoteDs("[w_pa_edad_destete]", obj)
    End Function

    Public Function Cn_GruposLoteDestete(ByRef obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultaxIdLoteDs("[w_pa_cons_grupos_destete_idlote]", obj)
    End Function

    Public Function Cn_ConsultarCampañasActivas(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxIdUbicacion("[w_pa_consultar_campañas_en_curso]", obj)
    End Function

    Public Function Cn_ConsultarDetalleRetorno(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxIdMovimiento("[w_pa_listar_det_movimiento_lote]", obj)
    End Function

    Public Function Cn_ConsultarLotesxUbicacion(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxIdUbicacion("[w_pa_cons_lotes_x_ubicacion]", obj)
    End Function

    Public Function Cn_ReporteAnimalesVentaStock() As DataTable
        Return cls_at.Cd_ConsultarGeneral("[w_pa_reporte_animales_para_venta_x_plantel]")
    End Function

    Public Function Cn_ConsultarMortalidadGeneralxLote(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.ConsultarxLoteDt("[w_pa_cons_mortalidad_x_lote]", obj)
    End Function

    Public Function Cn_ConsultarReporteProyeccionVenta(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxAnioDt("[w_pa_reporte_proyeccion_lote_venta_por_anio]", obj)
    End Function

    Public Function Cn_ConsultarReporteCondCorporal(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.ConsultarxLoteDt("[w_pa_reporte_cond_corporal_x_lote_pivot]", obj)
    End Function

    Public Function Cn_ConsultarConsumoDonacion(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxAnioDt("[w_pa_cons_consumo_donacion]", obj)
    End Function

    Public Function Cn_ConsultarPartosVsDestete(ByRef obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarPartoVsDestete("[w_pa_parto_vs_destete]", obj)
    End Function

    Public Function Cn_ReportePesosGranja(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxAnioMesSemOtrosDt("[w_pa_reporte_pesos_granja]", obj)
    End Function

    Public Function Cn_ReporteMermas(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxAnioMesSemDt("[w_pa_reporte_mermas]", obj)
    End Function

    Public Function Cn_ReportePesosxDespacho(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxIdDespacho("[w_pa_pesos_x_despacho_granja]", obj)
    End Function

    Public Function Cn_ReporteAreteVenta(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxIdDespacho("[w_pa_cons_aretes_venta]", obj)
    End Function

    Public Function Cn_ConsultarMetaPartoxLote(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxIdLote("[w_pa_consultar_meta_partos]", obj)
    End Function

    Public Function Cn_ActualizarMetaPartos(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_ActualizarMetaPartos("[w_pa_actualizar_meta_partos]", obj)
    End Function

    Public Function Cn_HistorialDescarte(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxIdLote("[w_pa_reporte_historico_hembras_lote]", obj)
    End Function

    Public Function Cn_ReporteBajada(ByRef obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarxIdLoteDs("[w_pa_reporte_bajada]", obj)
    End Function

    Public Function Cn_ConsultarPesosBajada(ByRef obj As coControlLoteDestete) As DataSet
        Return cls_at.Cd_ConsultarxIdLoteTipoClasificacion("[w_pa_consultar_pesos_bajada_por_lote]", obj)
    End Function

    Public Function Cn_RegistrarPesosBajada(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RegistrarPesosBajada("[w_pa_mant_pesos_bajada]", obj)
    End Function

    Public Function Cn_EliminarPesosBajada(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_EliminarPesoBajada("[w_pa_eliminar_pesos_bajada]", obj)
    End Function

    Public Function Cn_ReporteViables(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxIdLote("[w_pa_reporte_viables]", obj)
    End Function

    Public Function Cn_ObtenerChanchillasMeishan(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxIdLote("[w_pa_obtener_chanchillas_meishan]", obj)
    End Function

    Public Function Cn_RegMovimientoChanchillaMeishan(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RegMovimientoChanchillaMeishan("[w_pa_mover_chanchillas_meishan_x_idlote]", obj)
    End Function

    Public Function Cn_RegistrarGrupos(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RegistrarGrupos("[w_pa_registrar_grupos_destete]", obj)
    End Function

    Public Function Cn_ListarGruposPresupuesto(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxIdLote("[w_pa_grupos_destete_idlote_presupuesto]", obj)
    End Function

    Public Function Cn_RegistrarPresupuestoAlimentoGrupo(ByRef obj As coControlLoteDestete) As String
        Return cls_at.Cd_RegistrarPresupuestoAlimentoGrupo("[w_pa_reg_presupuesto_alimento_grupo]", obj)
    End Function

    Public Function Cn_ConsultarPresupuestoAlimentoGrupo(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxGrupoLoteAlimento("[w_pa_consultar_presupuesto_alimento_grupo]", obj)
    End Function

    Public Function Cn_ConsultarInformacionDestete(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ConsultarxIdControlFicha("[w_pa_cons_informacion_destete]", obj)
    End Function

    Public Function Cn_ReporteEngordeCampana(ByRef obj As coControlLoteDestete) As DataTable
        Return cls_at.Cd_ReporteEngordeCampana("[w_pa_reporte_ambientes_x_campaña]", obj)
    End Function
End Class