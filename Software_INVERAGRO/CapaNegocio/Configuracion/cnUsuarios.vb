Imports CapaDatos
Imports CapaObjetos

Public Class cnUsuarios
    Private cls_at As New cdUsuarios
    Public Function Cn_ListarPersonasConUsuarioClave() As DataTable
        Return cls_at.Cd_ListarPersonasConUsuarioClave("r_pa_listar_personas_con_usuario_clave")
    End Function

    Public Function Cn_Mantenimiento(obj As coUsuarios) As String
        Return cls_at.Cd_Mantenimiento("r_pa_mant_usuarios", obj)
    End Function
End Class
