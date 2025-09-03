Imports CapaDatos
Imports CapaObjetos

Public Class cnControlCampanaEmbarque
    Private cls_at As New cdControlCampanaEmbarque

    Public Function Cn_ConsultarCampanas(obj As coControlCampanaEmbarque) As DataSet
        Return cls_at.Cd_ConsultarCampanasEmbarcadero("[w_pa_cons_campañas]", obj)
    End Function

    Public Function Cn_CerrarCapacidadCampana(ByRef obj As coControlCampanaEmbarque) As String
        Return cls_at.Cd_CerrarCapacidadCampana("[w_pa_cerrar_capacidad_campaña]", obj)
    End Function

    Public Function Cn_ConsultarHistorialEmbarcadero(obj As coControlCampanaEmbarque) As DataSet
        Return cls_at.Cd_ConsultarCampanasEmbarcadero("[r_pa_cons_historial_embarcadero]", obj)
    End Function

    Public Function Cn_ConsultarOtrasSalidasPlantel(ByRef obj As coControlCampanaEmbarque) As DataTable
        Return cls_at.Cd_ConsultarOtrasSalidasPlantel("[w_pa_cons_otras_salidas_plantel]", obj)
    End Function
End Class
