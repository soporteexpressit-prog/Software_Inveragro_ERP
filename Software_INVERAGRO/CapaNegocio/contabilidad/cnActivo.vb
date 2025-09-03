Imports CapaDatos
Imports CapaObjetos

Public Class cnActivo
    Private cls_at As New cdActivo
    Public Function Cn_Mantenimiento(ByRef obj As coActivo) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_activo]", obj)
    End Function

    Public Function Cn_ConsultarActivosRegistrados(ByRef obj As coActivo) As DataTable
        Return cls_at.Cd_ConsultarActivosRegistrados("[w_pa_cons_activos_registrados]", obj)
    End Function

    Public Function Cn_ConsultarActivos(ByRef obj As coActivo) As DataTable
        Return cls_at.Cd_ConsultarActivos("[w_pa_cons_activo]", obj)
    End Function

    Public Function Cn_ConsultarxId(obj As coActivo) As DataTable
        Return cls_at.Cd_ConsultarxId("[w_pa_cons_activo_x_id]", obj)
    End Function

    Public Function Cn_DarBajaActivo(ByRef obj As coActivo) As String
        Return cls_at.Cd_DarBajaActivo("[w_pa_dar_baja_activo]", obj)
    End Function

    Public Function Cn_ListarActivos(ByRef obj As coActivo) As DataTable
        Return cls_at.Cd_ListarActivos("[w_pa_listar_activo]", obj)
    End Function
    Public Function Cn_ListarActivosVehiculos(ByRef obj As coActivo) As DataTable
        Return cls_at.Cd_ListarActivosVehiculos("[w_pa_listar_activo_vehiculo]", obj)
    End Function
End Class
