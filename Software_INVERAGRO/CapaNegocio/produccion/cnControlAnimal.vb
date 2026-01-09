Imports CapaDatos
Imports CapaObjetos

Public Class cnControlAnimal
    Private cls_at As New cdControlAnimal

    Public Function Cn_RegistrarVerraco(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarVerraco("[w_pa_registrar_verraco]", obj)
    End Function

    Public Function Cn_RegistrarCerda(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarCerda("[w_pa_registrar_cerda]", obj)
    End Function

    Public Function Cn_RegistrarCodificacionAnimal(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarCodificacionAnimal("[w_pa_reg_codificacion_animal]", obj)
    End Function

    Public Function Cn_ActualizarDatosCerda(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_ActualizarDatosCerda("[w_pa_actualizar_informacion_cerda]", obj)
    End Function

    Public Function Cn_ActualizarDatosVerraco(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_ActualizarDatosVerraco("[w_pa_actualizar_informacion_verraco]", obj)
    End Function

    Public Function Cn_ConsultarVerraco(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarAnimal("[w_pa_cons_verracos]", obj)
    End Function

    Public Function Cn_ConsultarCerda(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarAnimalCerda("[w_pa_cons_cerdas]", obj)
    End Function

    Public Function Cn_ConsultarCerdasCamal(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_GeneralxIdUbicacion("[w_pa_cons_cerdas_camal]", obj)
    End Function

    Public Function Cn_ConsultarChanchillaCelador(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarChanchillaCelador("[w_pa_cons_chanchillas_celadores]", obj)
    End Function

    Public Function Cn_ConsultarAnimalxId(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarxIdAnimal("[w_pa_cons_cerda_x_id]", obj)
    End Function

    Public Function Cn_ConsultarGeneralAnimalxId(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarxIdAnimal("[w_pa_cons_datos_general_animal_x_id]", obj)
    End Function

    Public Function Cn_ListarVerracoDisponible(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_GeneralxIdUbicacion("[w_pa_listar_verracos_disponibles]", obj)
    End Function

    Public Function Cn_ListarCerdaDisponibleInseminar(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_GeneralxIdUbicacion("[w_pa_cons_cerdas_inseminar]", obj)
    End Function

    Public Function Cn_RegistrarTestGestacion(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarTestGestacion("[w_pa_registrar_test_gestacion]", obj)
    End Function

    Public Function Cn_ConsultarCerdaEtapaGestacion(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarCerdasGestacion("[w_pa_cons_cerdas_gestacion]", obj)
    End Function

    Public Function Cn_ConsultarCerdaEtapaMaternidad(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarCerdasMaternidad("[w_pa_cons_cerdas_maternidad]", obj)
    End Function

    Public Function Cn_ConsultarCerdasVacias(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_GeneralxIdUbicacion("[r_pa_cons_cerdas_vacias]", obj)
    End Function

    Public Function Cn_ConsultarCerdasGestantes(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_GeneralxIdUbicacion("[w_pa_cons_cerdas_gestante]", obj)
    End Function

    Public Function Cn_RegistrarMonitoreCondCorporal(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarMonitoreCondCorporal("[w_pa_reg_monitoreo_cond_corporal]", obj)
    End Function

    Public Function Cn_ConsultarMonitoreoCondCorporalxIdCerda(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarGeneralxIdCerda("[w_pa_cons_monitoreo_condcorporal_cerda]", obj)
    End Function

    Public Function Cn_RegistrarParto(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarParto("[w_pa_reg_parto]", obj)
    End Function

    Public Function Cn_ConsultarDetallePartoMortalidad(ByRef obj As coControlAnimal) As DataSet
        Return cls_at.Cd_ConsultarDetallePartoMortalidad("[w_pa_obtener_crias_mortalidad_maternidad]", obj)
    End Function

    Public Function Cn_MantenimientoMortalidadMaternidad(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_MantenimientoMortalidadCerdo("[w_pa_mant_mortalidad_maternidad]", obj)
    End Function

    Public Function Cn_RegistrarEnvioCamalLote(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarEnvioCamalLote("[w_pa_reg_envio_camal_crias_lote]", obj)
    End Function

    Public Function Cn_RegistrarMortalidadAnimal(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarMortalidadAnimal("[w_pa_reg_mortalidad_animal]", obj)
    End Function

    Public Function Cn_RegistrarEnvioCamalMadreFutura(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarEnvioCamalMadreFuturaLote("[w_pa_reg_envio_camal_crias_lote_mf]", obj)
    End Function

    Public Function Cn_RegistrarMortalidadLote(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarMortalidadLote("[w_pa_registrar_mortalidad_lote]", obj)
    End Function

    Public Function Cn_RegistrarMortalidadMadreFutura(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarMortalidadMadreFutura("[w_pa_registrar_mortalidad_lote_mf]", obj)
    End Function

    Public Function Cn_ConsultarCerdosxIdUbicacion(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_GeneralxIdUbicacion("[w_pa_cons_cerdos_por_ubicacion]", obj)
    End Function

    Public Function Cn_ConsultarMortalidad(ByRef obj As coControlAnimal) As DataSet
        Return cls_at.Cd_ConsultarxFechasUbicacionDs("[w_pa_cons_mortalidad]", obj)
    End Function

    Public Function Cn_ConsultarMortalidadChanchillasMarranas(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarxFechasUbicacionDt("[w_pa_cons_mortalidad_chanchilla_marrana]", obj)
    End Function

    Public Function Cn_ConsultarHistorialGestacionMaternidadxIdCerda(ByRef obj As coControlAnimal) As DataSet
        Return cls_at.Cd_ConsultarHistorialEtapaxIdCerda("[w_pa_cons_historial_gestacion_maternidad_x_anio]", obj)
    End Function

    Public Function Cn_ConsultarHistorialAbortoxIdCerda(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarxIdAnimal("[w_pa_cons_abortos_por_id_animal]", obj)
    End Function

    Public Function Cn_ConsultarHistoricoxIdCerda(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarxIdAnimal("[w_pa_consultar_historico_por_animal]", obj)
    End Function

    Public Function Cn_ConsultarHistorialPartosxIdCerda(ByRef obj As coControlAnimal) As DataSet
        Return cls_at.Cd_ConsultarxIdAnimalAnio("[w_pa_cons_parto_cerda]", obj)
    End Function

    Public Function Cn_ConsultarMedicacionxIdAnimal(ByRef obj As coControlAnimal) As DataSet
        Return cls_at.Cd_ConsultarMedicacionxIdAnimal("[w_pa_cons_medicacion_por_id_animal]", obj)
    End Function

    Public Function Cn_RegistrarEnvioCamal(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarEnvioCamal("[w_pa_reg_envio_camal]", obj)
    End Function

    Public Function Cn_RegistrarEnvioCamalMasivo(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarEnvioCamalMasivo("[w_pa_reg_envio_camal_masivo]", obj)
    End Function

    Public Function Cn_ConsultarEnvioCamal(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarEnvioCamal("[w_pa_consultar_historial_envio_camal]", obj)
    End Function

    Public Function Cn_ConsultarArchivoCamal(ByRef obj As coControlAnimal) As Byte()
        Return cls_at.Cd_ConsultarArchivoCamal("[w_pa_obtener_archivo_foto_envio_camal]", obj)
    End Function

    Public Function Cn_ConsultarMortalidadCriasMaternidad(ByRef obj As coControlAnimal) As DataSet
        Return cls_at.Cd_ConsultarxFechasUbicacionLoteDs("[w_pa_cons_mortalidad_crias_maternidad]", obj)
    End Function

    Public Function Cn_ConsultarMortalidadRecriaEngorde(ByRef obj As coControlAnimal) As DataSet
        Return cls_at.Cd_ConsultarxMortalidadUbicacionLoteDs("[w_pa_reporte_mortalidad_recria_engorde]", obj)
    End Function

    Public Function Cn_EliminarPerdidaReproductiva(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_EliminarEventoCerda("[w_pa_eliminar_test_gestacion]", obj)
    End Function

    Public Function Cn_EliminarMortalidadCriasMaternidad(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_EliminarEventoCerda("[w_pa_eliminar_evento_mortalidad_crias]", obj)
    End Function

    Public Function Cn_ListarCerdasDonantes(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_GeneralxIdUbicacion("[w_pa_cons_cerdas_donantes]", obj)
    End Function

    Public Function Cn_ListarCriasCerdasDonantes(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarGeneralxIdCerda("[w_pa_obtener_crias_cerda_donante]", obj)
    End Function

    Public Function Cn_ConsultarIncidenciaTrabajador(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarxFechasUbicacionTipoLoteDt("[w_pa_cons_mortalidad_incidencia_trabajador]", obj)
    End Function

    Public Function Cn_ConsultarMotivosMortalidad(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarxFechasUbicacionLoteDt("[w_pa_cons_mortalidad_motivos_recria_engorde]", obj)
    End Function

    Public Function Cn_RegistrarNodrizaje(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarNodrizaje("[w_pa_reg_cerda_nodriza]", obj)
    End Function

    Public Function Cn_RegistrarMovimientoCriaMaternidad(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarMovimientoCriaMaternidad("[w_pa_reg_movimiento_crias]", obj)
    End Function

    Public Function Cn_ListarCerdaMovimientoMaternidad(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_GeneralxIdUbicacion("[w_pa_cons_cerdas_maternidad_movimiento]", obj)
    End Function

    Public Function Cn_EliminarMovimientoCriasMaternidad(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_EliminarMovimientoCriasMaternidad("[w_pa_eliminar_evento_movimiento_cria]", obj)
    End Function

    Public Function Cn_RegistrarTestCelo(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarTestCelo("[r_pa_reg_test_celo]", obj)
    End Function

    Public Function Cn_ConsultarTestCeloPorAnimal(ByRef obj As coControlAnimal) As DataSet
        Return cls_at.Cd_ConsultarTestCeloPorAnimal("[r_pa_cons_test_celo_por_animal]", obj)
    End Function

    Public Function Cn_ConfirmarVentaEnvioCamal(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_ConfirmarVentaEnvioCamal("[r_pa_confirmar_venta_cerdo]", obj)
    End Function

    Public Function Cn_CancelarVentaEnvioCamal(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_CancelarVentaEnvioCamal("[r_pa_cancelar_venta_cerdo]", obj)
    End Function

    Public Function Cn_ConsultarArchivoMortalidad(ByRef obj As coControlAnimal) As Byte()
        Return cls_at.Cd_ConsultarArchivoMortalidad("[r_pa_obtener_archivo_foto_mortalidad]", obj)
    End Function

    Public Function Cn_RegistrarRegularizacionCerdos(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_RegistrarRegularizacionCerdos("[w_pa_reg_regularizar_cerdos]", obj)
    End Function

    Public Function Cn_EliminarServicio(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_EliminarEventoCerda("[w_pa_eliminar_evento_servicio]", obj)
    End Function

    Public Function Cn_EliminarParto(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_EliminarEventoCerda("[w_pa_eliminar_evento_parto]", obj)
    End Function

    Public Function Cn_EliminarMortalidad(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_EliminarEventoCerda("[w_pa_eliminar_evento_mortalidad]", obj)
    End Function

    Public Function Cn_EliminarDestete(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_EliminarEventoCerda("[w_pa_eliminar_evento_destete]", obj)
    End Function

    Public Function Cn_ConsultarVaciasMasMenosSiete(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarVaciasMasMenosSiete("[w_pa_vacias_mas_menos_7]", obj)
    End Function

    Public Function Cn_AnularEnvioCamal(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_AnularEnvioCamal("[r_pa_anular_envio_camal_cerdo]", obj)
    End Function

    Public Function Cn_ConsultarCerdosVentaIncidencia(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarCerdosVentaIncidencia("[w_pa_consultar_incidencias_venta]", obj)
    End Function

    Public Function Cn_ConsultarTatuajeCambor(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_GeneralxIdUbicacion("[w_pa_obtener_tatuaje_cambor]", obj)
    End Function

    Public Function Cn_ConsultarCerdasLactante(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_GeneralxIdUbicacion("[w_pa_cons_cerdas_lactante]", obj)
    End Function

    Public Function Cn_ConsultarControlFichaParto(ByRef obj As coControlAnimal) As DataSet
        Return cls_at.Cd_ConsultarControlFichaDs("[w_pa_cons_parto_x_id_cerda]", obj)
    End Function

    Public Function Cn_ListarCerdasMaternidadGestacion(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ListarCerdasMaternidadGestacion("[w_pa_cons_cerdas_maternidad_gestacion]", obj)
    End Function

    Public Function Cn_ConsultarInfoCerdaGestacion(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarInfoCerdaGestacion("[w_pa_cons_info_cerda_gestacion]", obj)
    End Function

    Public Function Cn_ConsultarControlFichaMortalidadCrias(ByRef obj As coControlAnimal) As DataSet
        Return cls_at.Cd_ConsultarControlFichaDs("[w_pa_cons_mortalidad_crias_x_id]", obj)
    End Function

    Public Function Cn_ConsultarPerdidaReproductiva(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarControlFichaDt("[w_pa_cons_perdida_reproductiva_x_id]", obj)
    End Function

    Public Function Cn_ListarCerdasGestantes(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_GeneralxIdUbicacion("[w_pa_cons_todas_cerdas_gestante]", obj)
    End Function

    Public Function Cn_ReportePartoDetallado(ByRef obj As coControlAnimal) As DataSet
        Return cls_at.Cd_ConsultarxLoteDs("[w_pa_cons_reporte_partos_detallado]", obj)
    End Function

    Public Function Cn_VaciarCerda(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_EnvioxIdAnimal("[w_pa_vaciar_cerda]", obj)
    End Function

    Public Function Cn_EliminarAnimal(ByRef obj As coControlAnimal) As String
        Return cls_at.Cd_EnvioxIdAnimal("[w_pa_eliminar_animal]", obj)
    End Function

    Public Function Cn_LineaProduccionReproductiva(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarFechas("[w_pa_linea_produccion_reproductiva]", obj)
    End Function

    Public Function Cn_ListarUltimas2Campañas() As DataTable
        Return cls_at.Cd_ListarGeneral("[w_pa_resumen_ultimas_2_campanas]")
    End Function

    Public Function Cn_ConsultarCerdosxIdUbicacionArea(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_GeneralxIdUbicacionArea("[w_pa_cons_cerdos_x_ubicacion_x_area]", obj)
    End Function

    Public Function Cn_ConsultarHistoricoDestete(ByRef obj As coControlAnimal) As DataTable
        Return cls_at.Cd_ConsultarxFechasUbicacionDt("[w_pa_cons_reporte_destete_por_fechas]", obj)
    End Function
End Class
