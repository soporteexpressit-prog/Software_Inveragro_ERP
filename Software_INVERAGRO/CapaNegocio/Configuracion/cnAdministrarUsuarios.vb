Imports CapaDatos
Imports CapaObjetos

Public Class cnAdministrarUsuarios
    Private cls_at As New cdAdministrarUsuarios
    Public Function Cn_ListarModulosSubModulos() As DataSet
        Return cls_at.Cd_ListarModulosSubModulos("[r_pa_listar_modulos_submodulos]")
    End Function

    Public Function Cn_ListarModulosSubModulosCelular() As DataSet
        Return cls_at.Cd_ListarModulosSubModulosCelular("[r_pa_listar_modulos_submodulos_celular]")
    End Function

    Public Function Cn_ListarUsuariosxTipo(ByRef tipo As String) As DataTable
        Return cls_at.Cd_ListarUsuariosxTipo("[r_pa_listar_usuarios_x_tipo]", tipo)
    End Function

    Public Function Cn_ObtenerDatosUsuarioXId(idPersona As Integer) As coAdministrarUsuarios
        Return cls_at.Cd_ObtenerDatosUsuarioXId("[r_pa_obtener_datos_usuario_x_id]", idPersona)
    End Function

    Public Function Cn_ObtenerBotonesxId(obj As coAdministrarUsuarios) As DataTable
        Return cls_at.Cd_ObtenerBotonesxId("[r_pa_obtener_botones_x_id]", obj)
    End Function

    'Public Function Cn_ObtenerModulosxId(obj As coAdministrarUsuarios) As DataTable
    '    Return cls_at.Cd_ObtenerModulosxId("[r_pa_obtener_modulos_x_id]", obj)
    'End Function

    Public Function Cn_ObtenerSubModuloNivel1xId(obj As coAdministrarUsuarios) As DataTable
        Return cls_at.Cd_ObtenerSubModuloNivel1xId("[r_pa_obtener_submodulonivel1_x_id]", obj)
    End Function

    Public Function Cn_ObtenerSubModuloCelularPorId(obj As coAdministrarUsuarios) As DataTable
        Return cls_at.Cd_ObtenerSubModuloCelularPorId("[r_pa_obtener_submodulocelular_x_id]", obj)
    End Function

    Public Function Cn_ObtenerSubModuloNivel2xId(obj As coAdministrarUsuarios) As DataTable
        Return cls_at.Cd_ObtenerSubModuloNivel2xId("[r_pa_obtener_submodulonivel2_x_id]", obj)
    End Function

    Public Function Cn_ListarModulos() As DataTable
        Return cls_at.Cd_ListarModulos("[r_pa_listar_modulos]")
    End Function

    Public Function Cn_ListarModulosCelular() As DataTable
        Return cls_at.Cd_ListarModulosCelular("[r_pa_listar_modulos_celular]")
    End Function

    Public Function Cn_RegDetallePermiso(obj As coAdministrarUsuarios) As String
        Return cls_at.Cd_RegDetallePermiso("[r_pa_reg_detallepermiso]", obj)
    End Function

    Public Function Cn_RegDetallePermisoCelular(obj As coAdministrarUsuarios) As String
        Return cls_at.Cd_RegDetallePermisoCelular("[r_pa_reg_detallepermiso_celular]", obj)
    End Function

    Public Function Cn_AsignarPerfilAPersona(obj As coAdministrarUsuarios) As String
        Return cls_at.Cd_AsignarPerfilAPersona("[r_pa_asignar_perfil_a_persona]", obj)
    End Function

    Public Function Cn_ListarUsuariosConPerfil() As DataTable
        Return cls_at.Cd_ListarUsuariosConPerfil("[r_pa_listar_usuarios_con_perfil]")
    End Function

    Public Function Cn_ListarUsuariosConPerfilMovil() As DataTable
        Return cls_at.Cd_ListarUsuariosConPerfilMovil("[r_pa_listar_usuarios_con_perfil_movil]")
    End Function

    Public Function Cn_ActualizarPersonaxPerfil(obj As coAdministrarUsuarios) As String
        Return cls_at.Cd_ActualizarPersonaxPerfil("[r_pa_actualizar_persona_x_perfil]", obj)
    End Function

    Public Function Cn_ObtenerPermisosModuloPorId(obj As coAdministrarUsuarios) As DataTable
        Return cls_at.Cd_ObtenerPermisosModuloPorId("[r_pa_obtener_permisos_modulo_x_id]", obj)
    End Function

    Public Function Cn_ObtenerPermisosModuloCelularPorId(obj As coAdministrarUsuarios) As DataTable
        Return cls_at.Cd_ObtenerPermisosModuloCelularPorId("[r_pa_obtener_permisos_modulocelular_x_id]", obj)
    End Function
    Public Function Cn_ObtenerPermisosSubModuloNivel1PorId(obj As coAdministrarUsuarios) As DataTable
        Return cls_at.Cd_ObtenerPermisosSubModuloNivel1PorId("[r_pa_obtener_permisos_submodulonivel1_x_id]", obj)
    End Function
    Public Function Cn_ObtenerPermisosSubModuloCelularPorId(obj As coAdministrarUsuarios) As DataTable
        Return cls_at.Cd_ObtenerPermisosSubModuloCelularPorId("[r_pa_obtener_permisos_submodulocelular_x_id]", obj)
    End Function
    Public Function Cn_ObtenerPermisosSubModuloNivel2PorId(obj As coAdministrarUsuarios) As DataTable
        Return cls_at.Cd_ObtenerPermisosSubModuloNivel2PorId("[r_pa_obtener_permisos_submodulonivel2_x_id]", obj)
    End Function
    Public Function Cn_ObtenerPermisosBotonesPorId(obj As coAdministrarUsuarios) As DataTable
        Return cls_at.Cd_ObtenerPermisosBotonesPorId("[r_pa_obtener_permisos_botones_x_id]", obj)
    End Function

End Class
