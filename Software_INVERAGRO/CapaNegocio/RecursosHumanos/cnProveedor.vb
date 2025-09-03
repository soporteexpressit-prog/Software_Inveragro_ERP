Imports System.Data.SqlClient
Imports CapaDatos
Imports CapaObjetos

Public Class cnProveedor
    Private cls_at As New cdProveedor
    Public Function Cn_Mantenimiento(ByRef obj As coProveedor) As String
        Return cls_at.Cd_Mantenimiento("[i_pa_mant_proveedor]", obj)
    End Function
    Public Function Cn_MantenimientoAseguradora(ByRef obj As coProveedor) As String
        Return cls_at.Cd_MantenimientoAseguradora("[w_pa_mant_proveedor_aseguradora]", obj)
    End Function
    Public Function Cn_Consultar(obj As coProveedor) As DataTable
        Return cls_at.Cd_Consultar("[i_pa_cons_proveedor]", obj)
    End Function
    Public Sub Cn_ConvertirACliente(idPersona As Integer, ByRef mensaje As SqlParameter)
        cls_at.Cd_ConvertirACliente(idPersona, mensaje)
    End Sub

    Public Function Cn_ConsultarxCodigo(obj As coProveedor) As DataTable
        Return cls_at.Cd_ConsultarxCodigo("[w_pa_cons_persona_x_id]", obj)
    End Function
    Public Function Cn_ListarTipoDocIdentidad() As DataTable
        Return cls_at.Cd_ListarTipoDocIdentidad("[i_pa_listar_tipodocidentidad]")
    End Function

    Public Function Cn_ListarTodasAseguradoras() As DataTable
        Return cls_at.Cd_ListarTodasAseguradoras("[w_pa_cons_proveedor_seguro]")
    End Function

    Public Function Cn_ListarAseguradora() As DataTable
        Return cls_at.Cd_ListarAseguradora("[w_pa_listar_proveedor_seguro]")
    End Function

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
    Public Function Cc_ConsultarxCodigoUbicacion(obj As coProveedor) As DataTable
        Return cls_at.Cd_ConsultarxCodigoUbicacion("[JIHFObtenerUbicacionPorPersona]", obj)
    End Function
End Class
