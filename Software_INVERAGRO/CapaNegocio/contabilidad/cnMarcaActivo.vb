Imports CapaDatos
Imports CapaObjetos

Public Class cnMarcaActivo
    Private cls_at As New cdMarcaActivo
    Public Function Cn_Mantenimiento(ByRef obj As coMarcaActivo) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_marca_activo]", obj)
    End Function

    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_marca_activo]")
    End Function

    Public Function Cn_Listar_Marca_Activo_Por_Tipo(obj As coMarcaActivo) As DataTable
        Return cls_at.Cd_Listar_Marca_Activo_Por_Tipo("[w_pa_cons_marca_activo_x_tipo_activo]", obj)
    End Function
End Class
