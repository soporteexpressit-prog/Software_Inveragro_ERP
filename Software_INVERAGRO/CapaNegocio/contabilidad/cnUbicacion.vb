Imports CapaDatos
Imports CapaObjetos

Public Class cnUbicacion
    Private cls_at As New cdUbicacion

    Public Function Cn_Mantenimiento(ByRef obj As coUbicacion) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_ubicacion]", obj)
    End Function

    Public Function Cn_MantenimientoPlanteles(ByRef obj As coUbicacion) As String
        Return cls_at.Cd_MantenimientoPlanteles("[w_pa_mant_ubicacion_v2]", obj)
    End Function

    Public Function Cn_Consultar(obj As coUbicacion) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_ubicacion]", obj)
    End Function

    Public Function Cn_ConsultarxId(obj As coUbicacion) As DataTable
        Return cls_at.Cd_ConsultarxId("[w_pa_cons_ubicacion_x_id]", obj)
    End Function

    Public Function Cn_ConsultarPlanteles() As DataTable
        Return cls_at.Cd_ListarPlanteles("[w_pa_cons_planteles]")
    End Function

    Public Function Cn_AplicarDensidadPlantel(ByRef obj As coUbicacion) As String
        Return cls_at.Cd_AplicarDesidadPlantel("w_pa_actualizar_capacidad_corrales_por_plantel", obj)
    End Function

    Public Function Cn_ListarPlanteles() As DataTable
        Return cls_at.Cd_ListarPlanteles("[w_pa_listar_planteles]")
    End Function

    Public Function Cn_ListarCampañas(ByRef obj As coUbicacion) As DataTable
        Return cls_at.Cd_ListarCampañas("[w_pa_campañas_x_plantel]", obj)
    End Function

    Public Function Cn_ListarPlantelesEngorde() As DataTable
        Return cls_at.Cd_ListarPlanteles("[w_pa_listar_planteles_engorde]")
    End Function

    Public Function Cn_ListarPlantelesReproduccion(Optional ByVal flag As Integer = 0) As DataTable
        Return cls_at.Cd_ConsultarPlantelAlmacen("[w_pa_listar_planteles_reproduccion]", flag)
    End Function

    Public Function Cn_MantenimientoNivel1(ByRef obj As coUbicacion) As String
        Return cls_at.Cd_MantenimientoAlcance1("i_pa_mant_alcance1", obj)
    End Function
    Public Function Cn_MantenimientoAlcance2(ByRef obj As coUbicacion) As String
        Return cls_at.Cd_MantenimientoAlcance2("i_pa_mant_alcance2", obj)
    End Function
    Public Function Cn_MantenimientoAlcance3(ByRef obj As coUbicacion) As String
        Return cls_at.Cd_MantenimientoAlcance3("i_pa_mant_alcance3", obj)
    End Function

    Public Function Cn_ConsultarAlcance1(obj As coUbicacion) As DataTable
        Return cls_at.Cd_ConsultarNivel1("i_pa_cons_alcance1", obj)
    End Function
    Public Function Cn_ConsultarAlcance2(obj As coUbicacion) As DataTable
        Return cls_at.Cd_ConsultarNivel2("i_pa_cons_alcance2", obj)
    End Function
    Public Function Cn_ConsultarAlcance3(obj As coUbicacion) As DataTable
        Return cls_at.Cd_ConsultarNivel3("i_pa_cons_alcance3", obj)
    End Function
    Public Function Cn_ConsultarCentrodeCostos() As DataTable
        Return cls_at.Cd_ConsultarCentrodeCostos("[i_pa_cons_centro_de_costos]")
    End Function
End Class
