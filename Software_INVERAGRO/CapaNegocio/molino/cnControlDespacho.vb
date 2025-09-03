Imports CapaDatos
Imports CapaObjetos

Public Class cnControlDespacho
    Private cls_at As New cdControlDespacho

    Public Function Cn_ConsultarRacionPreparadaCerdo(obj As coControlDespacho) As DataSet
        Return cls_at.Cd_ConsultarRacionPreparadaCerdo("[w_pa_cons_racion_preparada_cerdo]", obj)
    End Function

    Public Function Cn_ConsultarRacionPreparadaCerdoxId(obj As coControlDespacho) As DataTable
        Return cls_at.Cd_ConsultarRacionPreparadaCerdoxId("[w_pa_cons_requerimiento_alimento_x_id]", obj)
    End Function

    Public Function Cn_ConsultarRacionPreparadaCerdoDespachoTotal(obj As coControlDespacho) As DataTable
        Return cls_at.Cd_ConsultarRacionPreparadaCerdoxId("[w_pa_cons_requerimiento_alimento_x_despacho_total]", obj)
    End Function

    Public Function Cn_RegistrarEnvioAlimentoPlantel(obj As coControlDespacho) As String
        Return cls_at.Cd_RegistrarEnvioAlimentoPlantel("[w_pa_registrar_envio_alimento_plantel]", obj)
    End Function

    Public Function Cn_FinalizarRequerimientoAlimento(obj As coControlDespacho) As String
        Return cls_at.Cd_FinalizarRequerimientoAlimento("[w_pa_finalizar_despacho_pedido_alimento]", obj)
    End Function

    Public Function Cn_ListarTransporteActivo() As DataTable
        Return cls_at.Cd_ListarGeneral("[w_pa_listar_transportes_activos]")
    End Function
End Class
