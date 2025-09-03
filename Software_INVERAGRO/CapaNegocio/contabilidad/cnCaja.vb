Imports CapaDatos
Imports CapaObjetos

Public Class cnCaja
    Private cls_at As New cdCaja

    Public Function Cn_AperturaCaja(ByRef obj As coCaja) As String
        Return cls_at.Cd_AperturaCaja("[i_pa_proc_aperturar_caja]", obj)
    End Function
    Public Function Cn_ObtenerSaldoCajaAnterior() As Decimal
        Return cls_at.Cd_ObtenerSaldoCajaAnterior("[i_pa_cons_obtener_saldo_caja_anterior]")
    End Function
    Public Function Cn_ConsultarSaldoCaja() As DataTable
        Return cls_at.Cd_ConsultarSaldoCaja("[i_pa_cons_obtener_saldo_caja]")
    End Function
    'Public Function Cn_ConsultarStockCerdosPlantel(idplantel As Integer) As DataTable
    '    Return cls_at.Cd_ConsultarStockCerdosxPlantel("[i_pa_cons_obtener_stock_x_plantel]", idplantel)
    'End Function
    Public Function Cn_ConsultarStockCerdosPlantel(idplantel As Integer, idMotivo As Integer) As DataTable
        Return cls_at.Cd_ConsultarStockCerdosxPlantel("[w_pa_consultar_stock_cerdos_venta_plantel]", idplantel, idMotivo)
    End Function
    Public Function Cn_ConsultarCajaResumen() As DataSet
        Return cls_at.ConsultarCajaResumen("[i_pa_cons_caja_resumen]")
    End Function
    Public Function Cn_CerrarCaja(ByRef obj As coCaja) As String
        Return cls_at.Cd_CierreCaja("[i_pa_regcierrecaja]", obj)
    End Function

    Public Function Cn_ConsultarConfiguracionParametros() As DataSet
        Return cls_at.ConsultarConfiguracionParametros("[i_pa_cons_maestros_parametros]")
    End Function
    Public Function Cn_GuardarConfigirucaionParametros(ByRef obj As coCaja) As String
        Return cls_at.Cd_GuardaConfiguracionParametros("[i_pa_regconfiguracionparametrizacion]", obj)
    End Function
    Public Function Cn_ConsultarCentroCostos(ByVal obj As coCaja) As DataTable
        Return cls_at.Cd_ConsultarCentroCostos("[i_pa_cons_obtener_centro_costos]", obj)
    End Function
End Class
