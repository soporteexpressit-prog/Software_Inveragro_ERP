Imports CapaDatos
Imports CapaObjetos

Public Class cnCategoriaProducto
    Private cls_at As New cdCategoriaProducto
    Public Function Cn_Mantenimiento(ByRef obj As coCategoriaProducto) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_categoria]", obj)
    End Function
    Public Function Cn_Consultar(obj As coCategoriaProducto) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_categoria]", obj)
    End Function
End Class
