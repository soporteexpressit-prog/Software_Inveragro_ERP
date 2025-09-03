Imports CapaDatos

Public Class cnControlCombustible
    Private cls_at As New cdControlCombustible

    Public Function Cn_Consultar() As DataTable
        Return cls_at.Cd_Consultar("[r_pa_listar_producto_grifo]")
    End Function

    Public Function Cn_ListarTiposDocumento() As DataTable
        Return cls_at.Cd_ListarTiposDocumento("[r_pa_listar_tipos_documento]")
    End Function
End Class
