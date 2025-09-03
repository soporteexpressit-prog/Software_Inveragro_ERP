Imports CapaDatos
Imports CapaObjetos

Public Class cnArea
    Private cls_at As New cdArea

    Public Function Cn_Mantenimiento(ByRef obj As coArea) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_area]", obj)
    End Function

    Public Function Cn_Consultar() As DataTable
        Return cls_at.Cd_ListarGeneral("[w_pa_cons_area]")
    End Function

    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_ListarGeneral("[w_pa_list_area]")
    End Function
End Class
