Imports CapaDatos
Imports CapaObjetos

Public Class cnMoneda
    Private cls_at As New cdMoneda
    Public Function Cn_Mantenimiento(ByRef obj As coMoneda) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_moneda]", obj)
    End Function
    Public Function Cn_Consultar(obj As coMoneda) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_moneda]", obj)
    End Function
    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_moneda]")
    End Function
    Public Function Cn_ConsultarHistorial(obj As coMoneda) As DataTable
        Return cls_at.Cd_Consultar("[j_pa_cons_moneda_historial]", obj)
    End Function
End Class
