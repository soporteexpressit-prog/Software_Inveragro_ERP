Imports CapaDatos
Imports CapaObjetos

Public Class cnControlAsistencia
    Private cls_at As New cdControlAsistencia

    Public Function Cn_Consultar(obj As coControlAsistencia) As DataTable
        Return cls_at.Cd_ListarTrabajadores("[r_pa_listar_trabajadores_x_fecha_periodo]", obj)
    End Function

    Public Function Cn_Mantenimiento(obj As coControlAsistencia) As String
        Return cls_at.Cd_Mantenimiento("[r_pa_mantenimiento_asistencia]", obj)
    End Function

    Public Function Cn_ObtenerDatosTrabajadorPorDNI(obj As coControlAsistencia) As String
        Return cls_at.Cd_ObtenerDatosTrabajadorPorDNI("[r_pa_obtener_datos_trabajador_x_dni]", obj)
    End Function

    Public Function Cn_ListarPlanteles() As DataTable
        Return cls_at.Cd_ListarPlanteles("[r_pa_listar_planteles_asistencia]")
    End Function

    Public Function Cn_ListarAñosDeHorarios() As DataTable
        Return cls_at.Cd_ListarAñosDeHorarios("[r_pa_listar_años_de_horarios]")
    End Function
    Public Function Cn_ConsultarAsistencia(obj As coControlAsistencia) As DataTable
        Return cls_at.Cd_ConsultarAsistencia("[r_pa_cons_asistencia]", obj)
    End Function
    Public Function Cn_ActualizarEstadoAsistencia(obj As coControlAsistencia) As String
        Return cls_at.Cd_ActualizarEstadoAsistencia("[r_pa_actualizar_estado_asistencia]", obj)
    End Function
    Public Function Cn_ActualizarEnviadoAsistencia(obj As coControlAsistencia) As String
        Return cls_at.Cd_ActualizarEnviadoAsistencia("[r_pa_actualizar_enviado_asistencia]", obj)
    End Function
    Public Function Cn_ActualizarObservadoAsistencia(obj As coControlAsistencia) As String
        Return cls_at.Cd_ActualizarObservadoAsistencia("[r_pa_actualizar_observado_asistencia]", obj)
    End Function
    Public Function Cn_CancelarAprobacionAsistencia(obj As coControlAsistencia) As String
        Return cls_at.Cd_CancelarAprobacionAsistencia("[r_pa_cancelar_aprobacion_asistencia]", obj)
    End Function
    Public Function Cn_ConsultarAsistenciaExistente(obj As coControlAsistencia) As String
        Return cls_at.Cd_ConsultarAsistenciaExistente("[r_pa_cons_asistencia_existente]", obj)
    End Function
    Public Function Cn_ListarAsistenciaPorHorario(obj As coControlAsistencia) As DataTable
        Return cls_at.Cd_ListarAsistenciaPorHorario("[r_pa_listar_asistencia_x_horario]", obj)
    End Function
    Public Function Cn_ActualizarAsistencia(obj As coControlAsistencia) As String
        Return cls_at.Cd_ActualizarAsistencia("r_pa_actualizar_asistencia", obj)
    End Function
    Public Function Cn_ObtenerUltimoDiaRegistroAsistencia(obj As coControlAsistencia) As String
        Return cls_at.Cd_ObtenerUltimoDiaRegistroAsistencia("[r_pa_obtener_ultimo_dia_registro_asistencia]", obj)
    End Function
    Public Function Cn_ListarTrabajadoresPorPlanillaEventual(ByRef tipoTrabajador As String) As DataTable
        Return cls_at.Cd_ListarTrabajadoresPorPlanillaEventual("[r_pa_listar_trabajadores_x_planilla_eventual]", tipoTrabajador)
    End Function
    Public Function Cn_ActualizarEstadoEnviadoSemanalAsistencia(obj As coControlAsistencia) As String
        Return cls_at.Cd_ActualizarEstadoEnviadoSemanalAsistencia("[r_pa_estado_enviado_semanal_asistencia]", obj)
    End Function
    Public Function Cn_ConsAsistenciaExistenteEventual(obj As coControlAsistencia) As String
        Return cls_at.Cd_ConsAsistenciaExistenteEventual("[r_pa_cons_asistencia_existente_eventual]", obj)
    End Function
    Public Function Cn_EnviarPagoAsistencias(obj As coControlAsistencia) As String
        Return cls_at.Cd_EnviarPagoAsistencias("[r_pa_enviar_pago_asistencia]", obj)
    End Function
    Public Function Cn_AnularAsistencia(obj As coControlAsistencia) As String
        Return cls_at.Cd_AnularAsistencia("[r_pa_anular_asistencia]", obj)
    End Function
    Public Function Cn_Anularbssociales(obj As coControlAsistencia) As String
        Return cls_at.Cd_Anularenviocuentas("[j_pa_anular_bs]", obj)
    End Function
    Public Function Cn_Anularenviocuentas(obj As coControlAsistencia) As String
        Return cls_at.Cd_Anularenviocuentas("[j_pa_anular_envio_cuentas]", obj)
    End Function
    Public Function Cn_AplicarVacacionesPorTrabajadorAsistencia(obj As coControlAsistencia) As String
        Return cls_at.Cd_AplicarVacacionesPorTrabajadorAsistencia("[r_pa_aplicar_vacaciones_x_trabajador_asistencia]", obj)
    End Function
    Public Function Cn_EliminarTrabajadorAsistencia(obj As coControlAsistencia) As String
        Return cls_at.Cd_EliminarTrabajadorAsistencia("[r_pa_eliminar_trabajador_asistencia]", obj)
    End Function
    Public Function Cn_ConsOperariosAsistencia(obj As coControlAsistencia) As String
        Return cls_at.Cd_ConsOperariosAsistencia("[r_pa_cons_operarios_asistencia]", obj)
    End Function
    Public Function Cn_InvalidarAsistencia(obj As coControlAsistencia) As String
        Return cls_at.Cd_InvalidarAsistencia("[r_pa_eliminar_lista_asistencia]", obj)
    End Function
    Public Function Cn_ReportePagosPorPlantel(obj As coControlAsistencia) As DataTable
        Return cls_at.Cd_ReportePagosPorPlantel("[r_pa_cons_reporte_pagos_x_plantel]", obj)
    End Function
    Public Function Cn_ReporteAsistenciaTrabajadoresPorPlantel(obj As coControlAsistencia) As DataTable
        Return cls_at.Cd_ReporteAsistenciaTrabajadoresPorPlantel("[r_pa_reporte_asistencia_trabajadores_x_plantel]", obj)
    End Function
End Class
