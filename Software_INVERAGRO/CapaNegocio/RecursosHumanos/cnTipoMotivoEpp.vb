Imports CapaDatos
Imports CapaObjetos

Public Class cnTipoMotivoEpp
    Private cls_at As New cdTipoMotivoEpp
    Public Function Cn_Mantenimiento(ByRef obj As coTipoMotivoEpp) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_tipo_motivo_epp]", obj)
    End Function
    Public Function Cn_Consultar(obj As coTipoMotivoEpp) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_tipo_motivo_epp]", obj)
    End Function
    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_ListarTipoMotivoEpp("[w_pa_listar_tipo_motivo_epp]")
    End Function
End Class
