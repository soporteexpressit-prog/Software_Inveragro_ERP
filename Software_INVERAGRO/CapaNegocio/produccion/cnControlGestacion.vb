Imports CapaDatos
Imports CapaObjetos

Public Class cnControlGestacion
    Private cls_at As New cdControlGestacion

    Public Function Cn_RegistrarInseminacion(ByRef obj As coControlGestacion) As String
        Return cls_at.Cd_RegistrarInseminacion("[w_pa_reg_inseminacion_multiple]", obj)
    End Function

    Public Function Cn_Consultar(ByRef obj As coControlGestacion) As DataSet
        Return cls_at.Cd_Consultar("[w_pa_cons_gestacion_inseminacion]", obj)
    End Function

    Public Function Cn_ConsultarPerdidaReproductiva(ByRef obj As coControlGestacion) As DataTable
        Return cls_at.Cd_ConsultarPerdidaReproductiva("[w_pa_cons_perdida_reproductiva]", obj)
    End Function

    Public Function Cn_ConsultarInseminacionxIdCerda(ByRef obj As coControlGestacion) As DataTable
        Return cls_at.Cd_ConsultarInseminacionxIdCerda("[w_pa_cons_inseminacion_x_idcerda]", obj)
    End Function

    Public Function Cn_EditarInseminacion(ByRef obj As coControlGestacion) As String
        Return cls_at.Cd_EditarInseminacion("[w_pa_editar_inseminacion_cerda]", obj)
    End Function

    Public Function Cn_ConsultarInseminacionxIdServicio(ByRef obj As coControlGestacion) As DataSet
        Return cls_at.Cd_ConsultarInseminacionxIdServicio("[w_pa_cons_inseminacion_x_servicio]", obj)
    End Function
End Class
