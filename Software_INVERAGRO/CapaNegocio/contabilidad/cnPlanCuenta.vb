Imports CapaDatos
Imports CapaObjetos

Public Class cnPlanCuenta
    Private cls_at As New cdPlanCuenta
    Public Function Cn_Mantenimiento(ByRef obj As coPlanCuenta) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_plan_cuenta]", obj)
    End Function
    Public Function Cn_Consultar(obj As coPlanCuenta) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_plan_cuenta]", obj)
    End Function
End Class
