Imports CapaDatos
Imports CapaObjetos

Public Class cnAreaCapacitadora
    Private cls_at As New cdAreaCapacitadora
    Public Function Cn_Mantenimiento(ByRef obj As coAreaCapacitadora) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_area_capacitadora]", obj)
    End Function
    Public Function Cn_Consultar() As DataTable
        Return cls_at.Cd_Listar("[w_pa_cons_area_capacitadora]")
    End Function
    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_area_capa_activo]")
    End Function
End Class
