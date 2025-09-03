Imports CapaDatos
Imports CapaObjetos

Public Class cnTransporte
    Private cls_at As New cdTransporte
    Public Function Cn_Consultar() As DataTable
        Return cls_at.Cd_Consultar("[j_Obtener_transportes]")
    End Function
    Public Function Cn_insertar_transporte(obj As coTransporte) As String
        Return cls_at.cd_insertar_transporte("[j_pa_mant_transportes]", obj)
    End Function
    Public Function Cn_consultarxid(obj As coTransporte) As DataTable
        Return cls_at.Cd_Consultarxid("[j_Obtener_transportes_x_id]", obj)
    End Function

    Public Function Cn_consultarMantenedor(obj As coTransporte) As DataTable
        Return cls_at.Cd_consultarMantenedor("[j_mant_transporte_tipo_marca]", obj)
    End Function
    Public Function Cn_ListarTablasMaestrastranportes() As DataSet
        Return cls_at.ListarTablasMaestras("[J_listar_tablas_maestras_transportes]")
    End Function
    Public Function Cn_Mantenimientotipomarca(obj As coTransporte) As String
        Return cls_at.Cd_Mantenimientotipomarca("[j_pa_mant_tipo_marca]", obj)
    End Function
End Class
