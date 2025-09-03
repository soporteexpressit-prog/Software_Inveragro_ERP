Imports CapaDatos
Imports CapaObjetos

Public Class cnMarca
    Private cls_at As New cdMarca
    Public Function Cn_Mantenimiento(ByRef obj As coMarca) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_marca]", obj)
    End Function
    Public Function Cn_Consultar(obj As coMarca) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_marca]", obj)
    End Function
End Class
