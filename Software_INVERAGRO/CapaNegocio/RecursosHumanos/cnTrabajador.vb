Imports System.Data.SqlClient
Imports CapaDatos
Imports CapaObjetos

Public Class cnTrabajador
    Private cls_at As New cdTrabjador

    Public Function Cn_Mantenimiento(ByRef obj As coTrabajador) As String
        Return cls_at.Cd_Mantenimiento("[jihf_mant_trabajadores]", obj)
    End Function
    Public Function Cn_Mantenimientoconductores(ByRef obj As coTrabajador) As String
        Return cls_at.Cd_Mantenimientoconductor("[jihf_mant_conductores]", obj)
    End Function
    Public Function Cn_MantenimientoContrato(ByRef obj As coTrabajador) As String
        Return cls_at.Cd_MantenimientoContrato("[jihf_mant_contrato_trabajadores]", obj)
    End Function

    Public Function Cn_InsertarBajatrabajador(ByRef obj As coTrabajador) As String
        Return cls_at.Cd_InsertarBajatrabajador("[j_sp_AgregarBajaTrabajador]", obj)
    End Function

    Public Function Cn_InsertarUbicacion(ByRef obj As coTrabajador) As String
        Return cls_at.Cd_InsertarUbicacion("[jihf_insertar_ubicacion]", obj)
    End Function

    Public Function Cn_MantenimientoTrabajadoreventual(ByRef obj As coTrabajador) As String
        Return cls_at.Cd_MantenimientoTrabajadorEventual("[jihf_mant_trabajadores_eventuales]", obj)
    End Function

    Public Function Cn_Consultar(obj As coTrabajador) As DataTable
        Return cls_at.Cd_Consultar("[i_pa_cons_trabajadores]", obj)
    End Function
    Public Function Cn_Consultarsueldo(obj As coTrabajador) As DataTable
        Return cls_at.Cd_Consultar("[j_pa_listar_sueldo_trabajadores]", obj)
    End Function
    Public Function Cn_Consultarconductores(obj As coTrabajador) As DataTable
        Return cls_at.Cd_Consultar("[i_pa_cons_trabajadores_conductores]", obj)
    End Function
    Public Function Cn_ConsultartrabajadoresSunat(obj As coTrabajador) As DataTable
        Return cls_at.Cd_Consultar("[j_pa_cons_trabajadoresSunat]", obj)
    End Function


    Public Function Cn_ConsultarxCodigoTbhijo(obj As coTrabajador) As DataTable
        Return cls_at.Cd_ConsultarxCodigoTbhijo("[jihf_mostrar_tb_Hijos]", obj)
    End Function

    Public Function Cn_ConsultarxCodigo(obj As coTrabajador) As DataTable
        Return cls_at.Cd_ConsultarxCodigo("[i_pa_cons_trabajadores_x_codigo]", obj)
    End Function

    Public Function Cn_EliminarHijo(obj As coTrabajador) As DataTable
        Return cls_at.Cd_EliminarHijo("[jihf_eliminar_hijo]", obj)
    End Function

    Public Function Cn_ListarTipoDocIdentidad() As DataTable
        Return cls_at.Cd_ListarTipoDocIdentidad("[i_pa_listar_tipodocidentidad]")
    End Function

    Public Function Cn_ListarTrabajadoresActivos() As DataTable
        Return cls_at.Cd_ListarTrabajadoresActivos("[w_pa_listar_trabajadores_activos]")
    End Function

    Public Function Cn_ListarConductores() As DataTable
        Return cls_at.Cd_ListarTrabajadoresActivos("[w_pa_cons_trabajadores_conductores]")
    End Function

    Public Function Cn_ListarTrabajadoresvacaciones(ByRef obj As coControlPagosyDes) As DataTable
        Return cls_at.Cd_Consultarvacaciones("[j_tb_listar_control_pagos]", obj)
    End Function
    Public Function Cn_ListarTrabajadoresActivospermiso() As DataTable
        Return cls_at.Cd_ListarTrabajadoresActivos("[j_pa_listar_trabajadores_activos_permiso_vacaciones]")
    End Function

    Public Function Cn_ListarTrabajadoresActivosxPlantel(ByRef obj As coTrabajador) As DataTable
        Return cls_at.Cd_ListarTrabajadoresActivosxPlantel("[w_pa_listar_trabajadores_activos_x_ubicacion]", obj)
    End Function

    Public Function ObtenerDepartamentos() As DataTable
        Return cls_at.CargarDepartamentos("[JIHF_listar_departamentos]")
    End Function

    Public Function Cc_ConsultarxCodigoUbicacion(obj As coTrabajador) As DataTable
        Return cls_at.Cd_ConsultarxCodigoUbicacion("[JIHFObtenerUbicacionPorPersona]", obj)
    End Function

    Public Function Cc_Consultarhistorialpersona(obj As coTrabajador) As DataTable
        Return cls_at.Cd_ConsultarxCodigoUbicacion("[j_pa_listar_historial_vacaciones]", obj)
    End Function

    Public Function Cc_ConsultarxCodigoContrato(obj As coTrabajador) As DataTable
        Return cls_at.Cd_ConsultarxCodigoContrato("[jihf_pa_obtener_contrato]", obj)
    End Function
    Public Function Cc_ConsultarxCodigoregistrosunat(obj As coTrabajador) As DataTable
        Return cls_at.Cd_ConsultarxCodigoregistrosunat("[jihf_pa_RegistrosSunat]", obj)
    End Function
    Public Function Cn_ListarDistritos() As DataTable
        Return cls_at.Cd_ListarDistritos("[r_pa_listar_distritos]")
    End Function
    Public Function Cn_ListarPasaportes() As DataTable
        Return cls_at.Cd_ListarPasaportes("[r_pa_listar_doc_pasaporte]")
    End Function
    Public Function Cn_ListarOcupacion() As DataTable
        Return cls_at.Cd_ListarOcupacion("[JIHF_CbOCUPACION]")
    End Function
    Public Function Cn_ListarVINCULO_FAMILIAR() As DataTable
        Return cls_at.Cd_ListarVINCULO_FAMILIAR("[JIHF_CbVINCULO_FAMILIAR]")
    End Function
    Public Function Cn_ListarTPDOC_VINCULO() As DataTable
        Return cls_at.Cd_ListarTPDOC_VINCULO("[JIHF_CbTPDOC_VINCULO]")
    End Function
    Public Function Cn_ObtenerCuentaBancoPorIdPersona(obj As coTrabajador) As DataTable
        Return cls_at.Cd_ObtenerCuentaBancoPorIdPersona("[r_pa_obtener_cuenta_banco_x_id_persona]", obj)
    End Function
    Public Function Cn_ListarTablasMaestrasTrabajadores() As DataSet
        Return cls_at.ListarTablasMaestras("[JIHF_listar_tablas_maestras_trabajadores]")
    End Function

    Public Function Cn_EliminarUbicacion(obj As coTrabajador) As DataTable
        Return cls_at.Cd_EliminarUbicacion("[jihf_eliminar_ubicacion]", obj)
    End Function
    Public Function Cc_ConsultarxCodigoHijos(obj As coTrabajador) As DataTable
        Return cls_at.Cd_ConsultarxCodigoHijo("[jihf_mostrar_x_codigo_hijos]", obj)
    End Function

    Public Function Cn_Consultardocsunat() As DataTable
        Return cls_at.Cd_Consultardocsunat("[j_doc_registro_sunat_E4]")
    End Function
    Public Function Cn_ConsultardocsunatE5() As DataTable
        Return cls_at.Cd_Consultardocsunat("[j_doc_registro_sunat_E5]")
    End Function
    Public Function Cn_ConsultardocsunatE11() As DataTable
        Return cls_at.Cd_Consultardocsunat("[j_doc_registro_sunat_E11]")
    End Function
    Public Function Cn_ConsultardocsunatE17p1() As DataTable
        Return cls_at.Cd_Consultardocsunat("[j_doc_registro_sunat_E11P1]")
    End Function
    Public Function Cn_Consultaragrario() As DataTable
        Return cls_at.Cd_Consultardocsunat("[j_datos_regimen_agrario]")
    End Function

    Public Function Cn_ConsultardocsunatE17p2() As DataTable
        Return cls_at.Cd_Consultardocsunat("[j_doc_registro_sunat_E17P2]")
    End Function
    Public Function Cn_ConsultardocsunatE17p3() As DataTable
        Return cls_at.Cd_Consultardocsunat("[j_doc_registro_sunat_E17P3]")
    End Function
    Public Function Cn_ConsultardocsunatE13() As DataTable
        Return cls_at.Cd_Consultardocsunat("[j_doc_registro_sunat_E13]")
    End Function
    Public Function Cn_ConsultardocsunatE24() As DataTable
        Return cls_at.Cd_Consultardocsunat("[j_doc_registro_sunat_E24]")
    End Function
    Public Function Cn_ConsultarIdpersonacontrato(obj As coTrabajador) As DataSet
        Return cls_at.Cd_ConsultarIdpersonacontrato("[j_pa_cons_trabajador_reporte]", obj)
    End Function
    Public Function Cn_ConsultarsunatxempleadoE4(idPersonas As String) As DataSet
        Return cls_at.Cd_ConsultarsunatxempleadoE4("[j_doc_registro_sunat_E4_X_empleado]", idPersonas)
    End Function
    Public Function Cn_ConsultarsunatxempleadoE5(idPersonas As String) As DataSet
        Return cls_at.Cd_ConsultarsunatxempleadoE4("[j_doc_registro_sunat_E5_X_empleado]", idPersonas)
    End Function
    Public Function Cn_ConsultarsunatxempleadoE11(idPersonas As String) As DataSet
        Return cls_at.Cd_ConsultarsunatxempleadoE4("[j_doc_registro_sunat_E11_X_empleado]", idPersonas)
    End Function
    Public Function Cn_ConsultarsunatxempleadoE17p1(idPersonas As String) As DataSet
        Return cls_at.Cd_ConsultarsunatxempleadoE4("[j_doc_registro_sunat_E17P1_X_empleado]", idPersonas)
    End Function
    Public Function Cn_ConsultarsunatxempleadoE17p2(idPersonas As String) As DataSet
        Return cls_at.Cd_ConsultarsunatxempleadoE4("[j_doc_registro_sunat_E17p2_X_empleado]", idPersonas)
    End Function
    Public Function Cn_ConsultarsunatxempleadoE17p3(idPersonas As String) As DataSet
        Return cls_at.Cd_ConsultarsunatxempleadoE4("[j_doc_registro_sunat_E17p3_X_empleado]", idPersonas)
    End Function
    Public Function Cn_ConsultarsunatxempleadoE13(idPersonas As String) As DataSet
        Return cls_at.Cd_ConsultarsunatxempleadoE4("[j_doc_registro_sunat_E13_X_empleado]", idPersonas)
    End Function
    Public Function Cn_ConsultarsunatxempleadoE24(idPersonas As String) As DataSet
        Return cls_at.Cd_ConsultarsunatxempleadoE4("[j_doc_registro_sunat_E24_X_empleado]", idPersonas)
    End Function
    Public Function Cn_Generarfotocheck(obj As coTrabajador) As DataSet
        Return cls_at.Cd_Generarfotocheck("[j_generar_fotocheck]", obj)
    End Function
    Public Function Cn_ConsultarExportarExcelAFP() As DataTable
        Return cls_at.Cd_Consultardocsunat("[J_exportar_excel_afp]")
    End Function
    Public Function Cn_ConsultarExportarExcelAFPxempleado(idPersonas As String) As DataSet
        Return cls_at.Cd_ConsultarsunatxempleadoE4("[J_exportar_excel_afp_x_empleados]", idPersonas)
    End Function

    Public Function Cn_ProcesarExcelAfp(dataString As String) As DataSet
        Return cls_at.Cd_ProcesarExcelAfp("[j_procesar_excel_afp]", dataString)
    End Function

    Public Function Cn_ConsultarCargosProduccion() As DataTable
        Return cls_at.Cd_ListarCargoTrabajadorProduccion("[w_pa_cons_cargo_produccion]")
    End Function

    Public Function Cn_ConsultarPersonalProduccion() As DataTable
        Return cls_at.Cd_ListarCargoTrabajadorProduccion("[w_pa_cons_personal_produccion]")
    End Function

    Public Function Cn_MantPersonalProduccion(ByRef obj As coTrabajador) As String
        Return cls_at.Cd_MantPersonalProduccion("[w_pa_mant_personal_cargo]", obj)
    End Function

    Public Function Cn_ConsultarPersonalProduccionFiltrado(ByRef obj As coTrabajador) As DataTable
        Return cls_at.Cd_ConsultarPersonalProduccionFiltrado("[w_pa_cons_personal_produccion_filtrado]", obj)
    End Function
    Public Function Cn_ActualizarDiasVacaciones(ByRef obj As coTrabajador) As String
        Return cls_at.Cd_ActualizarDiasVacaciones("[r_pa_actualizar_dias_vacaciones_x_persona]", obj)
    End Function
End Class
