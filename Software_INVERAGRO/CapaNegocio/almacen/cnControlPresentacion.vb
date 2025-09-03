Imports CapaDatos
Imports CapaObjetos

Public Class cnControlPresentacion
    Private cls_at As New cdControlPresentacion
    Public Function Cn_Mantenimiento(ByRef obj As coControlPresentacion) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_presentacion_producto]", obj)
    End Function

    Public Function Cn_Consultar() As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_presentaciones_productos]")
    End Function
End Class
