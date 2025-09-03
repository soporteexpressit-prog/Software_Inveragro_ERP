Imports CapaDatos
Imports CapaObjetos

Public Class cnCargo
    Private cls_at As New cdCargo
    Public Function Cn_Mantenimiento(ByRef obj As coCargo) As String
        Return cls_at.Cd_Mantenimiento("[pa_mant_cargo]", obj)
    End Function
    Public Function Cn_Consultar(obj As coCargo) As DataTable
        Return cls_at.Cd_Consultar("[pa_cons_cargo]", obj)
    End Function
End Class
