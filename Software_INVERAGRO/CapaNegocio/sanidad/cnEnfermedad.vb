Imports CapaDatos
Imports CapaObjetos

Public Class cnEnfermedad
    Private cls_at As New cdEnfermedad
    Public Function Cn_Mantenimiento(ByRef obj As coEnfermedad) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_enfermedad]", obj)
    End Function
    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_Listar("[w_pa_list_enfermedad]")
    End Function
    Public Function Cn_ListarProductosMedicina() As DataTable
        Return cls_at.Cd_ListarProductosMedicina("[r_pa_listar_productos_medicinales]")
    End Function
    Public Function Cn_RegistrarDetalleTratamiento(ByRef obj As coEnfermedad) As String
        Return cls_at.Cd_RegistrarDetalleTratamiento("[r_pa_reg_detalle_tratamiento]", obj)
    End Function
    Public Function Cn_ConsultarDetalleTratamiento(ByRef obj As coEnfermedad) As DataTable
        Return cls_at.Cd_ConsultarDetalleTratamiento("[r_pa_cons_detalle_tratamiento]", obj)
    End Function
    Public Function Cn_ActualizarDetalleTratamiento(ByRef obj As coEnfermedad) As String
        Return cls_at.Cd_ActualizarDetalleTratamiento("[r_pa_actualizar_detalle_tratamiento]", obj)
    End Function
    Public Function Cn_ConsultarMedicamentoRecomendadoPorEnfermedad(ByRef obj As coEnfermedad) As DataTable
        Return cls_at.Cd_ConsultarMedicamentoRecomendadoPorEnfermedad("[r_pa_cons_medicamento_recomendado_x_enfermedad]", obj)
    End Function

    Public Function Cn_EliminarEnfermedad(ByRef obj As coEnfermedad) As String
        Return cls_at.Cd_EliminarEnfermedad("[w_pa_eliminar_enfermedad]", obj)
    End Function
End Class
