Imports CapaDatos
Imports CapaObjetos

Public Class cnTipoCurso
    Private cls_at As New cdTipoCurso
    Public Function Cn_Mantenimiento(ByRef obj As coTipoCurso) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_tipo_curso]", obj)
    End Function
    Public Function Cn_Consultar(obj As coTipoCurso) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_tipo_curso]", obj)
    End Function

    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_tipo_curso_activo]")
    End Function
End Class
