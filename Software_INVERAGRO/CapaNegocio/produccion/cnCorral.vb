Imports CapaDatos
Imports CapaObjetos

Public Class cnCorral
    Private cls_at As New cdCorral
    Public Function Cn_Mantenimiento(ByRef obj As coCorral) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_corral]", obj)
    End Function
    Public Function Cn_Consultar(obj As coCorral) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_corral]", obj)
    End Function
End Class
