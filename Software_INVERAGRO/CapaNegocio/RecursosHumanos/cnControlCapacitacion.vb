Imports CapaDatos
Imports CapaObjetos

Public Class cnControlCapacitacion
    Private cls_at As New cdControlCapacitacion
    Public Function Cn_Consultar(obj As coControlCapacitacion) As DataSet
        Return cls_at.Cd_Consultar("[w_pa_cons_capacitacion]", obj)
    End Function
    Public Function Cn_ConsultarId(obj As coControlCapacitacion) As DataSet
        Return cls_at.Cd_ConsultarId("[w_pa_cons_capacitacion_por_id]", obj)
    End Function
    Public Function Cn_RegistrarCapacitacion(obj As coControlCapacitacion) As String
        Return cls_at.Cd_RegistrarCapacitacion("[w_pa_reg_capacitacion]", obj)
    End Function

    Public Function Cn_CancelarCapacitacion(obj As coControlCapacitacion) As String
        Return cls_at.Cd_CancelarCapacitacion("[w_pa_cancelar_capacitacion]", obj)
    End Function

    Public Function Cn_ConsultarPorTrabajador(obj As coTrabajador) As DataSet
        Return cls_at.Cd_ConsultarPorTrabajador("[w_cons_capacitacion_por_persona]", obj)
    End Function

    Public Function Cn_RegistrarRutaEvidencia(ByRef obj As coControlCapacitacion) As String
        Return cls_at.Cd_RegistrarRutaEvidencia("[w_reg_ruta_evidencia_capacitacion]", obj)
    End Function

    Public Function Cn_ObtenerRutaEvidencia(ByRef obj As coControlCapacitacion) As String
        Return cls_at.Cd_ObtenerRutaEvidencia("[w_pa_obtener_ruta_archivo_capacitacion]", obj)
    End Function
End Class
