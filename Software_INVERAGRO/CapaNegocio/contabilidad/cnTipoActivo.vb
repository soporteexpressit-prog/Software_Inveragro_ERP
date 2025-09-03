Imports CapaDatos
Imports CapaObjetos

Public Class cnTipoActivo
    Private cls_at As New cdTipoActivo
    Public Function Cn_Mantenimiento(ByRef obj As coTipoActivo) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_tipo_activo]", obj)
    End Function

    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_tipo_activo]")
    End Function

    Public Function Cn_Listar_Tipo_Activo_Por_Categoria(obj As coTipoActivo) As DataTable
        Return cls_at.Cd_Listar_Tipo_Activo_Por_Categoria("[w_pa_cons_tipo_activo_x_categoria_activo]", obj)
    End Function
End Class
