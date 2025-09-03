Imports System.Data.SqlClient
Imports CapaDatos
Imports CapaObjetos

Public Class cnCliente
    Private cls_at As New cdCliente
    Public Function Cn_Mantenimiento(ByRef obj As coCliente) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_cliente]", obj)
    End Function
    Public Function Cn_ConsultarxCodigo(obj As coCliente) As DataTable
        Return cls_at.Cd_ConsultarxCodigo("[w_pa_cons_persona_x_id]", obj)
    End Function
    Public Function Cn_ListarTipoDocIdentidad() As DataTable
        Return cls_at.Cd_ListarTipoDocIdentidad("[i_pa_listar_tipodocidentidad]")
    End Function
    Public Function Cn_Consultar(obj As coCliente) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_cliente]", obj)
    End Function
    Public Sub Cn_ConvertirProveedor(idPersona As Integer, ByRef mensaje As SqlParameter)
        cls_at.Cd_ConvertirProveedor(idPersona, mensaje)
    End Sub
    ' Método para obtener departamentos
    Public Function ObtenerDepartamentos() As DataTable
        Return cls_at.CargarDepartamentos("[JIHF_listar_departamentos]")
    End Function

    Public Function ObtenerProvincias(departamentoId As Integer) As DataTable
        Return cls_at.CargarProvincias("JIHFCargarDatosProvinciaDistrito", departamentoId)
    End Function
    Public Function ObtenerDistritos(idProvincia As Integer) As DataTable
        Dim dt As DataTable = cls_at.CargarDistritos(idProvincia)
        Return dt
    End Function
    Public Function Cc_ConsultarxCodigoUbicacion(obj As coCliente) As DataTable
        Return cls_at.Cd_ConsultarxCodigoUbicacion("[JIHFObtenerUbicacionPorPersona]", obj)
    End Function
    Public Sub Cn_ConvertirTrabajador(idPersona As Integer, ByRef mensaje As SqlParameter)
        cls_at.Cd_ConvertirTrabajador(idPersona, mensaje)
    End Sub

    Public Function Cn_ConsUbicacionPorUbigeo(ByRef obj As coCliente) As String
        Return cls_at.Cd_ConsUbicacionPorUbigeo("[r_pa_cons_ubicacion_x_ubigeo]", obj)
    End Function
End Class
