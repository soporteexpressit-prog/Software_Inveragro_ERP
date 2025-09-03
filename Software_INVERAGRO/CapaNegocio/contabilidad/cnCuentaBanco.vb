Imports CapaDatos
Imports CapaObjetos

Public Class cnCuentaBanco
    Private cls_at As New cdCuentaBanco
    Public Function Cn_Mantenimiento(ByRef obj As coCuentaBanco) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_cuenta_banco]", obj)
    End Function
    Public Function Cn_Consultar(obj As coCuentaBanco) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_cuenta_banco]", obj)
    End Function
End Class
