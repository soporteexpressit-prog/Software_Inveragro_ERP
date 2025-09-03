Imports CapaDatos
Imports CapaObjetos

Public Class cnControlRecepcionAlimento
    Private cls_at As New cdControlRecepcionAlimento

    Public Function Cn_ConsultarPedidoAlimentoRecepcionar(obj As coControlRecepcionAlimento) As DataSet
        Return cls_at.Cd_ConsultarPedidoAlimentoRecepcionar("[w_pa_cons_pedidos_alimento_recepcionar]", obj)
    End Function

    Public Function Cn_ConsultarRecepcionesxIdSalida(obj As coControlRecepcionAlimento) As DataSet
        Return cls_at.Cd_ConsultarRecepcionesxIdSalida("[w_pa_cons_recepciones_x_id_salida]", obj)
    End Function

    Public Function Cn_ConsultarDetalleRecepcionAlimentoxId(obj As coControlRecepcionAlimento) As DataTable
        Return cls_at.Cd_ConsultarDetalleRecepcionAlimentoxId("[w_pa_consultar_detalle_recepcion_alimento_por_id]", obj)
    End Function

    Public Function Cn_RegistrarRecepcionRaciones(obj As coControlRecepcionAlimento) As String
        Return cls_at.Cd_RegistrarRecepcionRaciones("[w_pa_registrar_recepcion_raciones]", obj)
    End Function

    Public Function Cn_CancelarDespachoAlimento(obj As coControlRecepcionAlimento) As String
        Return cls_at.Cd_CancelarDespachoAlimento("[w_pa_cancelar_despacho_recepcion_alimento]", obj)
    End Function
End Class
