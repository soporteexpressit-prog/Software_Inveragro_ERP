Imports System.Data.SqlClient
Imports CapaDatos
Imports CapaObjetos

Public Class cnControlPagosyDes
    Private cd As New cdControlPagosyDes()
    'Formulario de agregar concepto:
    Public Function Cn_RegConceptoSueldo(obj As coControlPagosyDes) As String
        Return cd.Cd_Agregamosconcepto("[j_insert_tipo_concepto]", obj)
    End Function
    Public Function Cn_ELIMINARSUELDO(obj As coControlPagosyDes) As String
        Return cd.Cd_elimnarsueldoextra("[j_eliminar_sueldo]", obj)
    End Function

    Public Function Cn_RegimenPensionario(obj As coControlPagosyDes) As String
        Return cd.Cd_Agregamosregimen("[j_insert_regimen_pensionario]", obj)
    End Function
    Public Function Cn_actualizar_estado_detallesueldo(obj As coControlPagosyDes) As String
        Return cd.Cd_actualizar_estado_detallesueldo("[j_actualizar_estado_detallesueldo]", obj)
    End Function
    Public Function Cn_AgregamosDetallesueldo(obj As coControlPagosyDes) As String
        Return cd.Cd_AgregamosDetallesueldo("[j_insertarDetalleSueldo]", obj)
    End Function
    Public Function Cn_Consultar(obj As coControlPagosyDes) As DataTable
        Return cd.Cd_Consultar("[JIHF_tb_ControlPagosYDESp]", obj)
    End Function
    Public Function Cn_Consultarsemana(obj As coControlPagosyDes) As DataTable
        Return cd.Cd_Consultarsemana("[jtb_tb_ControlPagos_Semana_update]", obj)
    End Function
    Public Function Cn_Consultarsueldos(obj As coControlPagosyDes) As DataTable
        Return cd.Cd_Consultarsemana("[j_mostrar_sueldos_personal]", obj)
    End Function
    Public Function Cn_Consultarconceptos(obj As coControlPagosyDes) As DataTable
        Return cd.Cd_ConsultarConceptos("[j_mostrar_tb_concepto]", obj)
    End Function

    Public Function Cn_Consultarregimenpensionario() As DataTable
        Return cd.Cd_ConsultarregimenAFP("[j_sp_tb_RegimenPensionarioAFP]")
    End Function
    Public Function Cn_Consultarhistorial() As DataTable
        Return cd.Cd_ConsultarregimenAFP("[j_sp_tb_Historial_RegimenPensionarioAFP]")
    End Function
    Public Function Cn_validarfecharegimen(ByRef resultado As String) As Boolean
        Return cd.Cd_validarfecha("[j_sp_validarfecha_regimenpensionario]", resultado)
    End Function

    Public Function Cn_ListarTablasMaestrasConceptos() As DataSet
        Return cd.ListarTablasMaestrasConceptos("[j_tb_maestras_tipos_conceptos]")
    End Function
    Public Function Cn_ConsultarId(obj As coControlPagosyDes, tipoQuincena As Integer) As DataSet
        Return cd.Cd_ConsultarId("JIHF_BoletaPago_ObtenerDatosPersonaPeriodoQ", obj, tipoQuincena)
    End Function

    Public Function Cn_ConsultarPagosYDes(obj As coControlPagosyDes, id As Integer) As coControlPagosyDes
        Return cd.Cd_ConsultarPagosYDes("[JIHF_Datos_Remuneracion_X_Persona]", obj, id)
    End Function
    Public Function Cn_ConsultarPagosYDeseventual(obj As coControlPagosyDes, id As Integer) As coControlPagosyDes
        Return cd.Cd_ConsultarPagosYDeseven("[JIHF_Datos_Remuneracion_X_Persona_eventual]", obj, id)
    End Function
    Public Function Cn_ListarAñosDeHorarios() As DataTable
        Return cd.Cd_ListarAñosDeHorarios("[r_pa_listar_años_de_horarios]")
    End Function
    Public Function Cn_ListarPlanteles() As DataTable
        Return cd.Cd_ListarPlanteles("[w_pa_listar_planteles]")
    End Function

    Public Function Cn_ConsultarControldepagos(obj As coControlPagosyDes) As DataTable
        Return cd.Cd_ConsultarControldepagos("[jihf_pa_cons_pagosydescuentosv2]", obj)
    End Function
    Public Function Cn_ListarTablasMaestrasTrabajadores(id As Integer, idpago As Integer, periodo As String) As DataSet
        Return cd.ListarTablasMaestras("[j_mant_tbgeneralpagosydesc]", id, idpago, periodo)
    End Function
    Public Function Cn_EliminarConceptospagos(obj As coControlPagosyDes) As DataTable
        Return cd.Cd_EliminarConceptospagos("[jihf_eliminar_detalleconceptos]", obj)
    End Function
    Public Function Cn_EliminarConceptospagoseventual(obj As coControlPagosyDes) As DataTable
        Return cd.Cd_EliminarConceptospagos("[jihf_eliminar_detalleconceptos_eventual]", obj)
    End Function
    Public Function Cn_Consultaragregarsueldo(obj As coControlPagosyDes)
        Return cd.Cd_AgregamosSueldo("[j_InsertarSueldoBase]", obj)
    End Function
    Public Function Cn_agregarsueldoeventual(obj As coControlPagosyDes)
        Return cd.Cd_AgregamosSueldo("[j_InsertarSueldoeventual]", obj)
    End Function

    Public Function Cn_GenerarMontostotales(obj As coControlPagosyDes)
        Return cd.Cd_GenerarMontostotales("[j_GenerartotalPagocuentas]", obj)
    End Function
    Public Function Cn_GenerarMontostotaleseventual(obj As coControlPagosyDes)
        Return cd.Cd_GenerarMontostotales("[j_GenerartotalPagocuentasEventual]", obj)
    End Function
    Public Function Cn_AprobarpagosEventuales(obj As coControlPagosyDes)
        Return cd.Aprobarpagos("[j_AprobarPagosEventuales]", obj)
    End Function
    Public Function Cn_EnviarCuentasPagarbs(obj As coControlPagosyDes)
        Return cd.EnviarCuentasPagar("[j_enviar_cuenta_pagar_Beneficios_sociales]", obj)
    End Function
    Public Function Cn_EnviarCuentasPagar(obj As coControlPagosyDes)
        Return cd.EnviarCuentasPagar("[j_enviar_cuenta_pagar_planilla]", obj)
    End Function
    Public Function Cn_EnviarCuentasPagarEventuales(obj As coControlPagosyDes)
        Return cd.EnviarCuentasPagar("[j_enviar_cuenta_pagar_eventual]", obj)
    End Function
    Public Function Cn_GenerarReportepagoPlanilla(obj As coControlPagosyDes) As DataSet
        Return cd.GenerarReportepago("[JIHF_reportepagosplanilla]", obj)
    End Function
    Public Function Cn_GenerarReportepagoPlanillacts(obj As coControlPagosyDes) As DataSet
        Return cd.GenerarReportepago("[j_reporte_con_cuenta]", obj)
    End Function
    Public Function Cn_GenerarReportepagogratificacion(obj As coControlPagosyDes) As DataSet
        Return cd.GenerarReportepago("[j_reporte_pagos_gratificacion]", obj)
    End Function
    Public Function Cn_GenerarReportepagoCTS(obj As coControlPagosyDes) As DataSet
        Return cd.GenerarReportepago("[j_reporte_pagos_cts]", obj)
    End Function
    Public Function Cn_GenerarReportepagoPlanilla_oficina(obj As coControlPagosyDes) As DataSet
        Return cd.GenerarReportepago("[J_reportepagosplanilla_oficina]", obj)
    End Function

    Public Function Cn_GenerarReporteEventual(obj As coControlPagosyDes) As DataSet
        Return cd.GenerarReportepago("[JIHF_reportepagoseventual]", obj)
    End Function
    Public Function Cn_GenerarReporteEventual_oficina(obj As coControlPagosyDes) As DataSet
        Return cd.GenerarReportepago("[j_reportepagoseventual_oficina]", obj)
    End Function
    Public Function Cn_AprobarPagoMultiple(obj As coControlPagosyDes) As String
        Return cd.Cd_AprobarPagoMultiple("[r_aprobar_pago_multiple]", obj)
    End Function
End Class
