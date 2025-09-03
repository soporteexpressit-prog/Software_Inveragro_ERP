Imports CapaDatos
Imports CapaObjetos

Public Class cnControlDespachoCerdoVenta
    Private cls_at As New cdControlDespachoCerdoVenta

    Public Function Cn_ConsultarPedidoVentasCerdo(ByRef obj As coControlDespachoCerdoVenta) As DataSet
        Return cls_at.ConsultarPedidoVentaCerdo("[w_pa_cons_control_pedidos_venta_cerdo_produccion]", obj)
    End Function

    'Public Function Cn_ConsultarCorralesCerdosVenta(ByRef obj As coControlDespachoCerdoVenta) As DataTable
    '    Return cls_at.Cd_ConsultarxIdUbicacion("[w_pa_cons_animales_venta_ubicacion]", obj)
    'End Function

    Public Function Cn_RegistrarPedidoCerdoAtendido(ByRef obj As coControlDespachoCerdoVenta) As String
        Return cls_at.Cd_RegistrarPedidoCerdoAtendido("[w_pa_reg_pedido_cerdo_atendido]", obj)
    End Function

    Public Function Cn_RegistrarPedidoCerdoAtendidoCod(ByRef obj As coControlDespachoCerdoVenta) As String
        Return cls_at.Cd_RegistrarPedidoCerdoAtendidoCod("[w_pa_pedido_atendido_cerdo_cod]", obj)
    End Function

    Public Function Cn_ConsultarLotesVenta(ByRef obj As coControlDespachoCerdoVenta) As DataTable
        Return cls_at.Cd_ConsultarxIdUbicacion("[w_pa_cons_lotes_venta_ubicacion]", obj)
    End Function

    Public Function Cn_CancelarPedidoCerdoAtendido(ByRef obj As coControlDespachoCerdoVenta) As String
        Return cls_at.Cd_CancelarPedidoCerdoAtendido("[w_pa_cancelar_pedido_cerdo_atendido]", obj)
    End Function

    Public Function Cn_CancelarPedidoCerdoAtendidoCod(ByRef obj As coControlDespachoCerdoVenta) As String
        Return cls_at.Cd_CancelarPedidoCerdoAtendido("[w_pa_cancelar_pedido_cerdo_con_cod_atendido]", obj)
    End Function
End Class
