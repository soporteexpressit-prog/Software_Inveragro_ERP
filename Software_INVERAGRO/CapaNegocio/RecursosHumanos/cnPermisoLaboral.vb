Imports System.Data.SqlClient
Imports CapaDatos
Imports CapaObjetos

Public Class cnPermisoLaboral
    Private cd As New cdPermisoLaboral()
    Public Function ObtenerDatosIncidencia(idPersona As Integer) As coPermisoLaboral
        Return cd.ObtenerDatosPorID(idPersona)
    End Function

    Public Function ObtenerDatosIncidenciapermiso(idPersona As Integer) As coPermisoLaboral
        Return cd.ObtenerDatosPorIDpermiso(idPersona)
    End Function
    Public Function InsertarPermisoLaboral(permiso As coPermisoLaboral) As (success As Boolean, message As String)
        Try
            Return cd.InsertarPermisoLaboral(permiso)
        Catch ex As Exception
            Return (False, "Error en la capa de negocio: " & ex.Message)
        End Try
    End Function
    Public Function cn_cancelarpermisolaboral(permiso As coPermisoLaboral) As (success As Boolean, message As String)
        Try
            Return cd.CancelarPermisoLaboral(permiso)
        Catch ex As Exception
            Return (False, "Error en la capa de negocio: " & ex.Message)
        End Try
    End Function
    Public Function Cn_Consultar(obj As coPermisoLaboral) As DataTable
        Return cd.Cd_Consultar("[JIHFObtenerPermisosLaborales]", obj)
    End Function
    Public Function Cn_ObtenerArchivo3(idpermiso As Integer) As Byte()
        Return cd.Cd_obtenerArchivo("[JIHF_obtener_archivo_paternidad]", idpermiso)
    End Function

    Public Function Cn_ActualizarArchivo(ByRef obj As coPermisoLaboral) As String
        Return cd.Cd_ActualizarArchivo("[JIHF_actualizar_archivo_permiso]", obj)
    End Function

    Public Function Cn_Consultarconceptos(ByRef obj As coPermisoLaboral) As DataTable
        Return cd.Cd_Consultarconceptos("[j_mostrar_tb_concepto_permisos]", obj)
    End Function

    Public Function Cn_Consultarpermisoporid(ByRef obj As coPermisoLaboral) As DataTable
        Return cd.Cd_Consultarpermisoporid("[j_consultar_permiso_por_id]", obj)
    End Function

    Public Function Cn_RegConceptoSueldo(obj As coPermisoLaboral) As String
        Return cd.Cd_Agregamosconcepto("[j_insert_tipo_concepto_permisos]", obj)
    End Function

End Class
