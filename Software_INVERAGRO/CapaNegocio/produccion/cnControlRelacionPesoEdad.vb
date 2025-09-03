Imports CapaDatos
Imports CapaObjetos

Public Class cnControlRelacionPesoEdad
    Private cls_at As New cdControlRelacionPesoEdad

    Public Function Cn_RegistrarRelacionPesoEdad(ByRef obj As coControlRelacionPesoEdad) As String
        Return cls_at.Cd_RegistrarRelacionPesoEdad("[w_pa_reg_relacion_peso_edad]", obj)
    End Function

    Public Function Cn_CancelarRelacionPesoEdad(ByRef obj As coControlRelacionPesoEdad) As String
        Return cls_at.Cd_CancelarRelacionPesoEdad("[w_pa_cancelar_relacion_edad_peso]", obj)
    End Function

    Public Function Cn_ConsultarRelacionPesoEdad(ByRef obj As coControlRelacionPesoEdad) As DataSet
        Return cls_at.Cd_ConsultarRelacionPesoEdad("[w_pa_cons_relacion_peso_edad]", obj)
    End Function
End Class
