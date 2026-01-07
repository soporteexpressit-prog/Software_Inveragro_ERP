Imports CapaDatos
Imports CapaObjetos

Public Class cnNucleo
    Private cls_at As New cdNucleo

    Public Function Cn_Listar() As DataSet
        Return cls_at.Cd_ListarNucleoNutricionista("[w_obtener_nutricionistas_raciones]")
    End Function

    Public Function Cn_ListarRaciones(ByVal obj As coProductos) As DataTable
        Return cls_at.Cd_ListarRaciones("[w_pa_listar_nucleo_x_almacen]", obj)
    End Function

    Public Function Cn_ListarRacionesAntiMedicadas(ByVal obj As coNucleo) As DataTable
        Return cls_at.Cd_ListarxUbicacion("[w_pa_listar_raciones_anti_medicado]", obj)
    End Function

    Public Function Cn_ListarRacionesPresupuesto(ByVal obj As coNucleo) As DataTable
        Return cls_at.Cd_ListarxUbicacion("[w_pa_listar_raciones_x_permisos]", obj)
    End Function

    Public Function Cn_ListarRaciones() As DataTable
        Return cls_at.Cd_ListarGeneral("[w_pa_listar_racion]")
    End Function

    Public Function Cn_ListarRacionesyExterna() As DataTable
        Return cls_at.Cd_ListarGeneral("[w_pa_listar_racion_y_externa]")
    End Function

    Public Function Cn_ListarRacionesSinPlanMedico() As DataTable
        Return cls_at.Cd_ListarGeneral("[w_pa_listar_racion_sin_plan_medico]")
    End Function

    Public Function Cn_Consultar(ByVal obj As coControlFormulacion) As DataTable
        Return cls_at.Cd_ListarNucleoNutricionista("[w_pa_cons_nucleo]", obj)
    End Function

    Public Function Cn_ConsultarNutricionista() As DataTable
        Return cls_at.Cd_ListarGeneral("[w_pa_cons_nutricionista]")
    End Function

    Public Function Cn_ConsultarNutricionistaCombo() As DataTable
        Return cls_at.Cd_ListarGeneral("[w_pa_cons_nutricionista_combo]")
    End Function

    Public Function Cn_Mantenimiento(ByVal obj As coNucleo) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_nucleo]", obj)
    End Function

    Public Function Cn_MantenimientoNutricionista(ByVal obj As coNucleo) As String
        Return cls_at.Cd_MantenimientoNutricionista("[w_pa_mant_nutricionista]", obj)
    End Function

    Public Function Cn_ListarRacionExtra() As DataTable
        Return cls_at.Cd_ListarGeneral("[w_pa_listar_racion_anti_plan_medicado]")
    End Function

    Public Function Cn_VincularExtra(ByVal obj As coNucleo) As String
        Return cls_at.Cd_MantenimientoExtra("[w_pa_insertar_racion_extra]", obj)
    End Function

    Public Function Cn_CancelarExtra(ByVal obj As coNucleo) As String
        Return cls_at.Cd_MantenimientoExtra("[w_pa_desactivar_racion_extra]", obj)
    End Function

    Public Function Cn_ConsultarRaciones(ByVal obj As coNucleo) As DataTable
        Return cls_at.Cd_ListarxUbicacion("[w_pa_cons_ver_racion_ubicacion]", obj)
    End Function

    Public Function Cn_PermisoVerRacioxUbicacion(ByVal obj As coNucleo) As String
        Return cls_at.Cd_PermisoVerRacioxUbicacion("[w_pa_permisos_visualizacion_racion_x_ubicacion]", obj)
    End Function

    Public Function Cn_ReporteDespachoRecepcion(ByVal obj As coNucleo) As DataTable
        Return cls_at.Cd_ReporteDespachoRecepcion("[w_pa_consolidado_pedido_rango]", obj)
    End Function
End Class
