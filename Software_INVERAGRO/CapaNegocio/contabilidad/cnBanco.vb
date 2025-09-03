Imports CapaDatos
Imports CapaObjetos

Public Class cnBanco
    Private cls_at As New cdBanco
    Public Function Cn_Mantenimiento(ByRef obj As coBanco) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_banco]", obj)
    End Function
    Public Function Cn_Mantenimientoccondicionpago(ByRef obj As coBanco) As String
        Return cls_at.Cd_Mantenimientocondicionpago("[j_pa_mant_condicion_pago]", obj)
    End Function
    Public Function Cn_Mantenimientocargos(ByRef obj As coBanco) As String
        Return cls_at.Cd_Mantenimiento("[j_pa_mant_cargos]", obj)
    End Function
    Public Function Cn_Consultar(obj As coBanco) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_banco]", obj)
    End Function
    Public Function Cn_Consultarcargo(obj As coBanco) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_cargos]", obj)
    End Function
    Public Function Cn_Consultarcondicionpago(obj As coBanco) As DataTable
        Return cls_at.Cd_Consultar("[l_pa_cons_condicion_pago]", obj)
    End Function
    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_banco]")
    End Function
    Public Function Cn_ReporteCtaBanco(obj As coBanco) As DataTable
        Return cls_at.Cd_ReporteCtaBanco("[r_pa_reporte_banco]", obj)
    End Function
End Class
