Imports CapaDatos
Imports CapaObjetos

Public Class cnTipoSeguro
    Private cls_at As New cdTipoSeguro
    Public Function Cn_Mantenimiento(ByRef obj As coTipoSeguro) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_tipo_seguro]", obj)
    End Function
    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_tipo_seguro]")
    End Function
End Class
