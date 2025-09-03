Imports CapaDatos
Imports CapaObjetos

Public Class cnTipoCapacitacion
    Private cls_at As New cdTipoCapacitacion
    Public Function Cn_Mantenimiento(ByRef obj As coTipoCapacitacion) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_tipo_capacitacion]", obj)
    End Function
    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_tipo_capacitacion]")
    End Function
End Class
