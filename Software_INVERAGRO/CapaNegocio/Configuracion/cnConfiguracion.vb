Imports CapaDatos
Imports CapaObjetos

Public Class cnConfiguracion
    Private cls_at As New cdConfiguracion
    Public Function Cn_MantenimientoContenido(ByRef obj As coConfiguracion) As String
        Return cls_at.Cd_MantenimientoContenido("[w_pa_mant_contenido_configuracion]", obj)
    End Function

    Public Function Cn_ObtenerContenido(configuracionId As Integer) As String
        Return cls_at.Cd_ObtenerContenido("[w_pa_obt_contenido_configuracion]", configuracionId)
    End Function

    Public Function Cn_ObtenerLogo(configuracionId As Integer) As Byte()
        Return cls_at.Cd_ObtenerLogo("[w_pa_obt_logo_configuracion]", configuracionId)
    End Function

    Public Function Cn_MantenimientoLogo(ByRef obj As coConfiguracion) As String
        Return cls_at.Cd_MantenimientoLogo("[w_pa_mant_logo_configuracion]", obj)
    End Function

    Public Function Cn_ListarParametroProduccion() As DataTable
        Return cls_at.Cd_ListarGeneral("[w_pa_cons_config_parametro_produccion]")
    End Function

    Public Function Cn_ActualizarParametroProduccion(ByRef obj As coConfiguracion) As String
        Return cls_at.Cd_ActualizarParametroProduccion("[w_pa_actualizar_config_parametro]", obj)
    End Function
End Class
