Imports CapaDatos
Imports CapaObjetos

Public Class cnTipoCambio
    Private cls_at As New cdTipoCambio
    Public Function Cn_Mantenimiento(ByRef obj As coTipoCambio) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_tipo_cambio]", obj)
    End Function
    Public Function Cn_Consultar(obj As coTipoCambio) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_tipo_cambio]", obj)
    End Function
End Class
