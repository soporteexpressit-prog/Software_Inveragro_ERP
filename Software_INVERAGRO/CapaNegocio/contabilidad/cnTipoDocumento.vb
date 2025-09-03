Imports CapaDatos
Imports CapaObjetos

Public Class cnTipoDocumento
    Private cls_at As New cdTipoDocumento
    Public Function Cn_Mantenimiento(ByRef obj As coTipoDocumento) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_tipo_documento]", obj)
    End Function
    Public Function Cn_Consultar(obj As coTipoDocumento) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_tipo_documento]", obj)
    End Function
End Class
