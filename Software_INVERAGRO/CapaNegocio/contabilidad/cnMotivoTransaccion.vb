Imports CapaDatos
Imports CapaObjetos

Public Class cnMotivoTransaccion
    Private cls_at As New cdMotivoTransaccion
    Public Function Cn_Mantenimiento(ByRef obj As coMotivoTransaccion) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_motivo_transaccion]", obj)
    End Function
    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_motivo_transaccion]")
    End Function
End Class
