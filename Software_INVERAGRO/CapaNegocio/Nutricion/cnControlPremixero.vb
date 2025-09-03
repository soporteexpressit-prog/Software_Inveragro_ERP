Imports CapaDatos
Imports CapaObjetos

Public Class cnControlPremixero
    Private cls_at As New cdControlPremixero
    Public Function Cn_MantenimientoPremixero(ByRef obj As coControlPremixero) As String
        Return cls_at.Cd_MantenimientoPremixero("[w_pa_mant_premixero]", obj)
    End Function

    Public Function Cn_ListarPremixero() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_premixero]")
    End Function

    Public Function Cn_ListarPremixeroActivos() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_premixero_activo]")
    End Function

    Public Function Cn_MantenimientoAsignacionPremixero(ByRef obj As coControlPremixero) As String
        Return cls_at.Cd_MantenimientoAsignacionPremixero("[w_pa_mant_asignacion_premixero]", obj)
    End Function

    Public Function Cn_ListarAsignacionPremixero() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_asignacion_premixero]")
    End Function

    Public Function Cn_ConsultarAsignacionxId(ByRef obj As coControlPremixero) As DataTable
        Return cls_at.Cd_ConsultarAsignacionxId("[w_pa_cons_asignacion_premixero_por_id]", obj)
    End Function

    Public Function Cn_ListarTrabajadorPremixeroActivo() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_trabajador_premixero_activo]")
    End Function
End Class
