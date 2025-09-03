Imports CapaDatos
Imports CapaObjetos

Public Class cnGiroEmpresa
    Private cls_at As New cdGiroEmpresa
    Public Function Cn_Mantenimiento(ByRef obj As coGiroEmpresa) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_giro_empresa]", obj)
    End Function
    Public Function Cn_Consultar(obj As coGiroEmpresa) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_giro_empresa]", obj)
    End Function
End Class
