Imports CapaDatos
Imports CapaObjetos

Public Class cnTemarioCapacitacion
    Private cls_at As New cdTemarioCapacitacion
    Public Function Cn_Mantenimiento(ByRef obj As coTemarioCapacitacion) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_temario_capacitacion]", obj)
    End Function
    Public Function Cn_Consultar(obj As coTemarioCapacitacion) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_temario_capacitacion]", obj)
    End Function
    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_temario_capacitacion]")
    End Function
End Class
