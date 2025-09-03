Imports CapaDatos
Imports CapaObjetos

Public Class cnControlFormulacion
    Dim cls_at As New cdControlFormulacion

    Public Function Cn_Listar(ByRef obj As coControlFormulacion) As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_formulacion]", obj)
    End Function

    Public Function Cn_RegistrarFormula(ByRef obj As coControlFormulacion) As String
        Return cls_at.Cd_RegistrarFormula("[w_pa_reg_formulacion_base]", obj)
    End Function

    Public Function Cn_MantenimientoProductoFormula(ByRef obj As coControlFormulacion) As String
        Return cls_at.Cd_MantenimientoProductoFormula("[w_pa_mant_producto_formula]", obj)
    End Function

    Public Function Cn_ListarInsumosFormula() As DataTable
        Return cls_at.Cd_ListarGeneralDt("[w_pa_listar_insumo_formula]")
    End Function

    Public Function Cn_ListarInsumosFormulaxNutricionista(ByRef obj As coControlFormulacion) As DataTable
        Return cls_at.Cd_ListarInsumosFormulaxNutricionista("[w_pa_listar_insumo_formula_x_nutricionista]", obj)
    End Function

    Public Function Cn_CancelarFormulaBase(ByRef obj As coControlFormulacion) As String
        Return cls_at.Cd_CancelarFormulaBase("[w_pa_cancelar_formula_base]", obj)
    End Function

    Public Function Cn_ActivarFormulaBase(ByRef obj As coControlFormulacion) As String
        Return cls_at.Cd_ActivarFormulaBase("[w_pa_activar_formula_base]", obj)
    End Function

    'Public Function Cn_ConsultarInsumosFormula(ByRef obj As coControlFormulacion) As DataTable
    '    Return cls_at.Cd_ListarInsumosFormulaNutricionista("[w_pa_cons_insumo_formula]", obj)
    'End Function
    Public Function Cn_ConsultarInsumosFormula(ByRef obj As coControlFormulacion) As Object
        Dim resultado As Object = cls_at.Cd_ListarInsumosFormulaNutricionista("[w_pa_cons_insumo_formula]", obj)

        If TypeOf resultado Is String Then
            Return resultado
        Else
            Return CType(resultado, DataTable)
        End If
    End Function

    Public Function Cn_ObtenerInsumosxFormulaNucleo(ByRef obj As coControlFormulacion) As DataTable
        Return cls_at.Cd_ObtenerInsumosxFormulaNucleo("[w_pa_obtener_insumos_x_formulacion_nucleo]", obj)
    End Function

    Public Function Cn_ObtenerInsumosActivoNoPerteneceFormula(ByRef obj As coControlFormulacion) As DataTable
        Return cls_at.Cd_ObtenerInsumosxFormulaNucleo("[w_pa_listar_insumos_activos_no_pertenece_formula]", obj)
    End Function

    Public Function Cn_ObtenerRacionesxFormulaBase(ByRef obj As coControlFormulacion) As DataTable
        Return cls_at.Cd_ObtenerRacionesxFormulaBase("[w_pa_obtener_nucleos_por_formula_base]", obj)
    End Function

    Public Function Cn_RegistrarAsignacionRacionxFormula(ByRef obj As coControlFormulacion) As String
        Return cls_at.Cd_RegistrarAsignacionRacionxFormula("[w_pa_reg_formula_racion]", obj)
    End Function

    Public Function Cn_ObtenerFormulaRacionxId(ByRef obj As coControlFormulacion) As DataSet
        Return cls_at.Cd_ObtenerFormulaRacionxId("[w_pa_obtener_formula_racion_x_id]", obj)
    End Function

    Public Function Cn_ObtenerRacionesxIdFormulacionBase(ByRef obj As coControlFormulacion) As DataSet
        Return cls_at.Cd_ObtenerRacionesxIdFormulacionBase("[w_pa_listar_raciones_x_idformulabase]", obj)
    End Function

    Public Function Cn_ObtenerFormulaBasexId(ByRef obj As coControlFormulacion) As DataTable
        Return cls_at.Cd_ObtenerFormulaBasexId("[w_pa_obtener_formulacion_base_x_id]", obj)
    End Function

    Public Function Cn_VerificarCantidades(ByRef obj As coControlFormulacion) As DataSet
        Return cls_at.Cd_VerificarCantidades("[w_pa_verificar_cantidades]", obj)
    End Function

    Public Function Cn_ObtenerFormulaBasexIdNucleo(ByRef obj As coControlFormulacion) As Object
        Dim resultado As Object = cls_at.Cd_ObtenerFormulaBasexIdNucleo("[w_pa_insumos_totales_preparacion_racion]", obj)

        If TypeOf resultado Is String Then
            Return resultado
        Else
            Return CType(resultado, DataTable)
        End If
    End Function

    Public Function Cn_PonerCursoNuevaFormulaBase(ByRef obj As coControlFormulacion) As String
        Return cls_at.Cd_PonerEnCursoNuevaFormulaBase("[w_actualizar_estado_formulabase]", obj)
    End Function

    Public Function Cn_ObtenerRacionesAsignadasReceta(ByRef obj As coControlFormulacion) As DataSet
        Return cls_at.Cd_ObtenerRacionesAsignadasReceta("[w_pa_obtener_raciones_asignadas_receta]", obj)
    End Function

    'Public Function Cn_ObtenerPreparacionFormulaTipoPremixero(ByRef obj As coControlFormulacion) As DataSet
    '    Return cls_at.Cd_ObtenerPreparacionFormulaTipoPremixero("[w_pa_obtener_preparacion_formula_tipo_premixero]", obj)
    'End Function

    'Public Function Cn_ObtenerPreparacionFormulaTotal(ByRef obj As coControlFormulacion) As DataSet
    '    Return cls_at.Cd_ObtenerPreparacionFormulaTotal("[w_pa_obtener_preparacion_formula_completo]", obj)
    'End Function
    Public Function Cn_ObtenerPreparacionFormulaTotal(ByRef obj As coControlFormulacion) As DataSet
        Return cls_at.Cd_ObtenerPreparacionFormulaTotal("[w_pa_obtener_formula_anti_medicado_total_racion]", obj)
    End Function

    Public Function Cn_ObtenerPreparacionFormulaTotalMolino(ByRef obj As coControlFormulacion) As DataSet
        Return cls_at.Cd_ObtenerPreparacionFormulaTotalMolino("[w_pa_obtener_formula_anti_medicado_total_racion_molino]", obj)
    End Function

    Public Function Cn_ObtenerPreparacionFormulaTipoPremixero(ByRef obj As coControlFormulacion) As DataSet
        Return cls_at.Cd_ObtenerPreparacionFormulaTipoPremixero("[w_pa_obtener_formula_anti_medicado_total_racion_por_premixero]", obj)
    End Function

    Public Function Cn_ObtenerPreparacionFormulaTotalPremixero(ByRef obj As coControlFormulacion) As DataSet
        Return cls_at.Cd_ObtenerPreparacionFormulaTotalPremixero("[w_pa_obtener_preparacion_formula_completo_premixero]", obj)
    End Function

    Public Function Cn_ConsultarAntiMedicadoRacion(obj As coControlFormulacion) As DataSet
        Return cls_at.Cd_ConsultarAntiMedicadoRacion("[w_pa_obtener_anti_medicado_racion]", obj)
    End Function

    Public Function Cn_ClonarAsignacionPremixeroRacion(ByRef obj As coControlFormulacion) As String
        Return cls_at.Cd_ClonarAsignacionPremixeroRacion("[w_pa_clonar_asignacion_premixero]", obj)
    End Function

    Public Function Cn_ActualizarProductoFormula(ByRef obj As coControlFormulacion) As String
        Return cls_at.Cd_ActualizarProductoFormula("[w_pa_actualizar_producto_formula]", obj)
    End Function

    Public Function Cn_ObtenerCostoPlanMedicadoAnti(ByRef obj As coControlFormulacion) As DataTable
        Return cls_at.Cd_ConsultarAntiPlanMedicado("[w_pa_consolidado_costo_plan_medicado_anti]", obj)
    End Function

    Public Function Cn_ConsultarProgramaAlimentacion(ByRef obj As coControlFormulacion) As DataSet
        Return cls_at.Cd_ConsultarProgramaAlimentacion("[w_pa_const_programa_alimentacion]", obj)
    End Function

    Public Function Cn_MantenimientoProgramaAlimentacion(ByRef obj As coControlFormulacion) As String
        Return cls_at.Cd_MantenimientoProgramaAlimentacion("[w_pa_mant_programa_alimentacion]", obj)
    End Function

    Public Function Cn_ConsultarProgramaAlimentacionxId(ByRef obj As coControlFormulacion) As DataSet
        Return cls_at.Cd_ConsultarProgramaAlimentacionxId("[w_pa_consultar_programa_alimentacion_x_id]", obj)
    End Function

    Public Function Cn_ConsultarFormulaBasexIdNutricionista(ByRef obj As coControlFormulacion) As DataTable
        Return cls_at.Cd_ConsultarFormulaBasexIdNutricionista("[w_pa_obtener_formulacion_base_x_id_almacen]", obj)
    End Function
End Class
