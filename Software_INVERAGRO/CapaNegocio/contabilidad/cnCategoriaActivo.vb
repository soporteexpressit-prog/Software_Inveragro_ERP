Imports CapaDatos
Imports CapaObjetos

Public Class cnCategoriaActivo
    Private cls_at As New cdCategoriaActivo
    Public Function Cn_Mantenimiento(ByRef obj As coCategoriaActivo) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_categoria_activo]", obj)
    End Function

    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_categoria_activo]")
    End Function

    Public Function Cn_ListarConTipoActivo() As DataTable
        Return cls_at.Cd_ListarConTipoActivo("[w_pa_listar_categoria_activo_con_tipo_activo]")
    End Function
End Class
