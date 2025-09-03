Imports CapaDatos
Imports CapaObjetos

Public Class cnUnidadMedida
    Private cls_at As New cdUnidadMedida
    Public Function Cn_Mantenimiento(ByRef obj As coUnidadMedida) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_unidad_medida]", obj)
    End Function

    Public Function Cn_Consultar(obj As coUnidadMedida) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_unidad_medida]", obj)
    End Function

    Public Function Cn_ConsultarUnidadMedidaSanidad(ByRef tipo As String) As DataTable
        Return cls_at.Cd_ListarUniMedSanidad("[w_pa_list_unidades_medida_sanidad]", tipo)
    End Function
End Class
