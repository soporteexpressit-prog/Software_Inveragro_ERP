Imports CapaDatos
Imports CapaObjetos

Public Class cnPerfil
    Private cls_at As New cdPerfil
    Public Function Cn_ListarPerfiles() As DataTable
        Return cls_at.Cd_ListarPerfiles("[r_pa_listar_perfil]")
    End Function
    Public Function Cn_ListarPerfilesCompletos() As DataTable
        Return cls_at.Cd_ListarPerfilesCompletos("[r_pa_listar_perfiles_completos]")
    End Function

    Public Function Cn_ListarPerfilesDispositivoMovil() As DataTable
        Return cls_at.Cd_ListarPerfilesDispositivoMovil("[r_pa_listar_perfiles_dispositivo_movil]")
    End Function
    Public Function Cn_Mantenimiento(ByRef obj As coPerfil) As String
        Return cls_at.Cd_Mantenimiento("[r_pa_mant_perfil]", obj)
    End Function
    Public Function Cn_ListarPermisosxPerfil(obj As coPerfil) As DataTable
        Return cls_at.Cd_ListarPermisosxPerfil("[r_pa_listar_permisos_x_perfil]", obj)
    End Function
End Class
