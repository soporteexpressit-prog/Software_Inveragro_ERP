Imports CapaDatos
Imports CapaObjetos

Public Class cnCotizacion
    Private cls_at As New cdCotizacion
    Public Function Cn_Mantenimiento(ByRef obj As coCotizacion) As String
        Return cls_at.Cd_Mantenimiento("[i_pa_regcotizacion]", obj)
    End Function
    Public Function Cn_ListarProductosActivosVentas(ByVal idalmacendestino As Integer) As DataTable
        Return cls_at.Cd_ListarProductosActivos("[i_pa_listar_productos_activos_ventas]", idalmacendestino)
    End Function
    Public Function Cn_ListarProductosActivos(ByVal idalmacendestino As Integer) As DataTable
        Return cls_at.Cd_ListarProductosActivos("[i_pa_listar_productos_activos]", idalmacendestino)
    End Function
    Public Function Cn_ListarProductosActivosGuias(ByVal idguia As Integer) As DataTable
        Return cls_at.Cd_ListarProductosActivosGuia("[i_pa_listar_productos_activos_de_guia]", idguia)
    End Function
    Public Function Cn_ListarProductosActivosparaVenta(ByVal idalmacendestino As Integer) As DataTable
        Return cls_at.Cd_ListarProductosActivosparaVenta("[i_pa_listar_productos_activos_para_venta]", idalmacendestino)
    End Function
    Public Function Cn_ListarProductosActivosPedidosSolicitados(ByVal idalmacendestino As Integer) As DataTable
        Return cls_at.Cd_ListarProductosActivos("[i_pa_listar_productos_activos_pendientes_solicitados]", idalmacendestino)
    End Function
    Public Function Cn_ListarProductosActivosSinStock(ByVal idalmacendestino As Integer) As DataTable
        Return cls_at.Cd_ListarProductosActivos("[i_pa_listar_productos_activos_sin_stock]", idalmacendestino)
    End Function

    Public Function Cn_ListarProveedoresActivos() As DataTable
        Return cls_at.Cd_ListarProveedoresActivos("[i_pa_listar_proveedores_activos]")
    End Function
    Public Function Cn_ListarTrabajadoresActivos() As DataTable
        Return cls_at.Cd_ListarTrabajadoresActivos("[i_pa_listar_trabajadores_activos]")
    End Function
    Public Function Cn_ListarConductoresActivos() As DataTable
        Return cls_at.Cd_ListarTrabajadoresActivos("[i_pa_listar_conductores_activos]")
    End Function
    Public Function Cn_ListarClientes() As DataTable
        Return cls_at.Cd_ListarProveedoresActivos("[i_pa_listar_clientes_activos]")
    End Function
    Public Function Cn_ListarActivos() As DataTable
        Return cls_at.Cd_ListarProveedoresActivos("[i_pa_listar_activos]")

    End Function
    Public Function Cn_ListarProveedoresTrabajadores() As DataTable
        Return cls_at.Cd_ListarProveedoresActivos("[i_pa_listar_proveedores_trabajadores_activos]")

    End Function
    Public Function Cn_Anularpedidousuario(ByRef obj As coCotizacion) As String
        Return cls_at.Cd_Anularpedidousuario("[j_anular_pedido_usuario]", obj)
    End Function
    Public Function Cn_ListarCuentasContables() As DataTable
        Return cls_at.Cd_ListarProveedoresActivos("[i_pa_listar_cuentas_contables]")
    End Function
    Public Function Cn_ListarTablasMaestras() As DataSet
        Return cls_at.ListarTablasMaestras("[i_pa_listar_tablas_maestras_cotizacion]")
    End Function
    Public Function Cn_Consultar(obj As coCotizacion) As DataSet
        Return cls_at.Cd_Consultar("[i_pa_cons_control_cotizaciones]", obj)
    End Function
    Public Function Cn_ConsultarxProveedor(obj As coCotizacion) As DataSet
        Return cls_at.Cd_ConsultarxProveedor("[i_pa_cons_control_cotizaciones_x_proveedor]", obj)
    End Function
    Public Function Cn_ConsultarxProveedorCuentaspagar(obj As coCotizacion) As DataSet
        Return cls_at.Cd_ConsultarxProveedor("[j_pa_cons_control_ctas_pagar_pendientesporabonar]", obj)
    End Function
    Public Function Cn_ConsultarxProveedorCuentacobrarsaldofavor(obj As coCotizacion) As DataSet
        Return cls_at.Cd_ConsultarxProveedor("[j_pa_cons_control_ctas_cobrar_saldo_favor]", obj)
    End Function
    Public Function Cn_Anular(ByRef obj As coCotizacion) As String
        Return cls_at.Cd_Anulado("[i_pa_anularcotizacion]", obj)
    End Function

    Public Function Cn_ListarCentrodeCostos() As DataTable
        Return cls_at.Cd_ConsultarCentroCostos("i_pa_cons_centro_de_costos")
    End Function
End Class
