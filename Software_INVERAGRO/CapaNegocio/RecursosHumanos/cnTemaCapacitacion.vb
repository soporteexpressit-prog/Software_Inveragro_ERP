Imports CapaDatos
Imports CapaObjetos

Public Class cnTemaCapacitacion
    Private cls_at As New cdTemaCapacitacion
    Public Function Cn_Mantenimiento(ByRef obj As coTemaCapacitacion) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_tema_capacitacion]", obj)
    End Function
    Public Function Cn_Consultar() As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_tema_capacitacion]")
    End Function

    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_tema_capacitacion_activo]")
    End Function
End Class
