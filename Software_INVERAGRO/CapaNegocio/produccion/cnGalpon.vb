Imports CapaDatos
Imports CapaObjetos

Public Class cnGalpon
    Private cls_at As New cdGapon

    Public Function Cn_Mantenimiento(ByRef obj As coGalpon) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_galpon]", obj)
    End Function

    Public Function Cn_Consultar(obj As coGalpon) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_galpon]", obj)
    End Function

    Public Function Cn_ListarGalpones() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_galpon]")
    End Function

    Public Function Cn_Listar_Galpones_Por_Plantel(obj As coGalpon) As DataTable
        Return cls_at.Cd_Listar_Galpones_Por_Ubicacion("[w_pa_listar_galpon_x_ubicacion]", obj)
    End Function

    Public Function Cn_ConsGalponesPorUbicacion(obj As coGalpon) As DataTable
        Return cls_at.Cd_ConsGalponesPorUbicacion("[r_pa_cons_galpon_por_ubicacion]", obj)
    End Function

    Public Function Cn_ConsLotesxGalpon(obj As coGalpon) As DataTable
        Return cls_at.Cd_ConsLotesxGalpon("[w_pa_cons_lotes_x_galpon]", obj)
    End Function

    Public Function Cn_ListarGalponesXPlantelArea(obj As coGalpon) As DataTable
        Return cls_at.Cd_ListarGalponesXPlantelArea("[w_pa_listar_galpon_x_ubicacion_x_area]", obj)
    End Function
End Class
