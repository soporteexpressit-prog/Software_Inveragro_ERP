Imports CapaDatos
Imports CapaObjetos

Public Class cnTipoIncidencia
    Private cls_at As New cdTipoIncidencia

    Public Function Cn_Mantenimiento(ByRef obj As coTipoIncidencia) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_tipo_incidencia]", obj)
    End Function

    Public Function Cn_ConsultarTipoIncidencia() As DataTable
        Return cls_at.Cd_Listar("[w_pa_cons_tipo_incidencia]")
    End Function

    Public Function Cn_ListarAmbiente() As DataTable
        Return cls_at.Cd_Listar("[w_pa_cons_ambiente]")
    End Function

    Public Function Cn_ConsultarxIdTipoIncidencia(ByRef obj As coTipoIncidencia) As DataTable
        Return cls_at.Cd_ConsultarxIdTipoIncidencia("[w_pa_cons_id_tipo_incidencia]", obj)
    End Function

    Public Function Cn_ConsultarMotivoGeneral() As DataTable
        Return cls_at.Cd_Listar("[w_pa_cons_motivo_general]")
    End Function

    Public Function Cn_ConsultarTipoAmbiente(ByRef obj As coTipoIncidencia) As DataTable
        Return cls_at.Cd_ConsultarMotivoTipoAmbiente("[w_pa_cons_motivo_tipo_ambiente]", obj)
    End Function

    Public Function Cn_ConsultarTipo(ByRef obj As coTipoIncidencia) As DataTable
        Return cls_at.Cd_ConsultarMotivoTipo("[w_pa_cons_motivo_tipo]", obj)
    End Function
End Class
