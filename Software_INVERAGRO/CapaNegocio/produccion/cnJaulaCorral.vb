Imports CapaDatos
Imports CapaObjetos

Public Class cnJaulaCorral
    Private cls_at As New cdJaulaCorral

    Public Function Cn_Mantenimiento(ByRef obj As coJaulaCorral) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_jaulacorral]", obj)
    End Function

    Public Function Cn_Consultar(obj As coJaulaCorral) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_jaulacorral]", obj)
    End Function

    Public Function Cn_ConsultarxId(obj As coJaulaCorral) As DataTable
        Return cls_at.Cd_ConsultarxId("[w_pa_cons_jaulacorral_x_id]", obj)
    End Function

    Public Function Cn_ConsultarDisponible(obj As coJaulaCorral) As DataTable
        Return cls_at.Cd_ConsultarDisponible("[w_pa_cons_jaulacorral_disponible]", obj)
    End Function

    Public Function Cn_ConsultarJaulaCorralxUbicacionTipo(obj As coJaulaCorral) As DataTable
        Return cls_at.Cd_ConsultarJaulaCorralxUbicacionTipo("[w_pa_obtener_corrales_jaulas_por_ubicacion_tipo]", obj)
    End Function

    Public Function Cn_ConsultarJaulaCorralxCampaña(obj As coJaulaCorral) As DataTable
        Return cls_at.Cd_ConsultarJaulaCorralxCampaña("[w_pa_obtener_corrales_jaulas_por_campañas]", obj)
    End Function

    Public Function Cn_ConsultarAmbientesRecriaEngorde(obj As coJaulaCorral) As DataTable
        Return cls_at.Cd_ConsultarJaulaCorralxUbicacionTipo("[w_pa_obtener_ambientes_recria_engorde]", obj)
    End Function

    Public Function Cn_ConsultarAmbientesxArea(obj As coJaulaCorral) As DataTable
        Return cls_at.Cd_ConsultarJaulaCorralxArea("[w_pa_obtener_ambientes_x_area]", obj)
    End Function

    Public Function Cn_ListarCorralesPorUbicacion(obj As coJaulaCorral) As DataTable
        Return cls_at.Cd_ListarCorralesPorUbicacion("[r_pa_listar_corrales_x_ubicacion]", obj)
    End Function

    Public Function Cn_ConsultarAnimalesCroquis(obj As coJaulaCorral) As DataSet
        Return cls_at.Cd_ConsultarAnimalesCroquis("[w_pa_obtener_corrales_animales_croquis]", obj)
    End Function

    Public Function Cn_ConsultarAnimalesCroquisReproduccion(obj As coJaulaCorral) As DataSet
        Return cls_at.Cd_ConsultarAnimalesCroquis("[w_pa_obtener_corrales_animales_croquis_reproduccion]", obj)
    End Function

    Public Function Cn_ConsultarJaulasCorralesPorGalpon(obj As coJaulaCorral) As DataTable
        Return cls_at.Cd_ConsultarJaulasCorralesPorGalpon("[w_pa_cons_corrales_jaulas_x_galpon]", obj)
    End Function

    Public Function Cn_RegistrarJaulaPorCantidad(obj As coJaulaCorral) As String
        Return cls_at.Cd_RegistrarJaulaPorCantidad("[r_pa_registrar_jaulacorral_por_cantidad]", obj)
    End Function
End Class
