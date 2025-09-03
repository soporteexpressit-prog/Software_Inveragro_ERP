Imports CapaDatos
Imports CapaObjetos

Public Class cnMotivoMemoDespido
    Private cls_at As New cdMotivoMemoDespido
    Public Function Cn_Mantenimiento(ByRef obj As coMotivoMemoDespido) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_motivo_memo_despido]", obj)
    End Function
    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_motivo_memo_despido]")
    End Function

    Public Function Cn_ConsultarPorTipo(ByRef obj As coMotivoMemoDespido) As DataTable
        Return cls_at.Cd_ConsultarPorTipo("[w_pa_listar_motivo_memo_despido_x_tipo]", obj)
    End Function

End Class
