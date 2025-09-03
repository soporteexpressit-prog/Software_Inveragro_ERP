Imports CapaDatos
Imports CapaObjetos

Public Class cnCtaCobrar
    Private cls_at As New cdCtaCobrar
    Public Function Cn_ConsultarCtasCobrar(obj As coCtaCobrar) As DataSet
        Return cls_at.ConsultarCtasCobrar("[i_pa_cons_control_ctas_cobrar]", obj)
    End Function
    Public Function Cn_ListarTablasMaestrasAbonar() As DataSet
        Return cls_at.ListarTablasMaestrasAbonar("[i_pa_listar_tablas_maestras_abonarctacobrar]")
    End Function
    Public Function Cn_ObtenerDatosdeCuentaPagar(obj As coCtaCobrar) As DataSet
        Return cls_at.ObtenerDatosdeCuentaPagar("[i_pa_obtener_cuenta_cobrar]", obj)
    End Function
    Public Function Cn_ObtenerDatosdeCuentaPagarSFP(obj As coCtaCobrar) As DataSet
        Return cls_at.ObtenerDatosdeCuentaPagarSFP("[i_pa_obtener_cuenta_cobrar_por_persona]", obj)
    End Function
    Public Function Cn_ObtenerArchivo(iddetallecuentapagar As Integer) As (Byte(), Integer)
        Return cls_at.Cd_obtenerArchivo("[i_obtener_archivo_cuentacobrar]", iddetallecuentapagar)
    End Function
    Public Function Cn_ObtenerArchivopagar(iddetallecuentapagar As Integer) As (Byte(), Integer)
        Return cls_at.Cd_obtenerArchivo("[i_obtener_archivo_cuentapagar]", iddetallecuentapagar)
    End Function

    Public Function Cn_consultarxidcobrar(obj As coCtaCobrar) As DataTable
        Return cls_at.Cd_Consultarxid("[j_Obtener_cuentacobrar_x_id]", obj)
    End Function
    Public Function Cn_consultarxidcobrarEDITAR(obj As coCtaCobrar) As DataTable
        Return cls_at.Cd_Consultarxid("[j_pa_consultar_cuenta_cobrarxid_editar]", obj)
    End Function
    Public Function Cn_consultarxidventacobrar(obj As coCtaCobrar) As DataTable
        Return cls_at.Cd_Consultarxid("[j_Obtener_proveedor_venta_id]", obj)
    End Function
    Public Function Cn_ListarTablasMaestrasPrestamo() As DataSet
        Return cls_at.ListarTablasMaestrasPrestamo("[i_pa_listar_tablas_maestras_prestamo]")
    End Function
    Public Function Cn_Mantenimiento(ByRef obj As coCtaCobrar) As String
        Return cls_at.Cd_Mantenimiento("[i_pa_reg_abono_ctacobrar]", obj)
    End Function
    Public Function Cn_CrearCuentaCobrar(ByRef obj As coCtaCobrar) As String
        Return cls_at.Cd_RegNuevaCuentaCobrar("[i_pa_reg_nueva_cuentacobrar]", obj)
    End Function
    Public Function Cn_RegNuevaCuentaCobraractualizar(ByRef obj As coCtaCobrar) As String
        Return cls_at.Cd_RegNuevaCuentaCobraractualizar("[i_pa_reg_nueva_cuentacobrar_update]", obj)
    End Function

    Public Function Cn_AnularAbonoCtaPagar(ByRef obj As coCtaCobrar) As String
        Return cls_at.Cd_AnularAbonoCtaPagar("[i_pa_anular_abonoctacobrar]", obj)
    End Function

    Public Function Cn_RegNuevaCuentaPagar(ByRef obj As coCtaCobrar) As String
        Return cls_at.Cd_NuevaCtaPagar("[i_pa_reg_nueva_ctapagar]", obj)
    End Function
    Public Function Cn_NuevaCtaPagarDetalle(ByRef obj As coCtaCobrar) As String
        Return cls_at.Cd_NuevaCtaPagarDetalle("[i_pa_reg_detalle_ctapagar]", obj)
    End Function
    Public Function Cn_ListarTablasMaestrasGasto() As DataSet
        Return cls_at.ListarTablasMaestrasAbonar("[i_pa_listar_tablas_maestras_nuevogasto]")
    End Function
    Public Function Cn_ConsultarArchivodeAbono(ByRef obj As coCtaCobrar) As String
        Return cls_at.Cd_ObtenerArchivoAbono("[i_pa_obtenerArchivoAbono]", obj)
    End Function

    Public Function Cn_actualizar_cliente(obj As coCtaCobrar) As String
        Return cls_at.cd_actualizar_cliente("[j_pa_actualizar_cliente_cta_cobrar]", obj)
    End Function
    Public Function Cn_actualizar_clienteventa(obj As coCtaCobrar) As String
        Return cls_at.cd_actualizar_cliente("[j_pa_actualizar_cliente_venta]", obj)
    End Function
    Public Function Cn_ConsultarControlCaja(obj As coCtaCobrar) As DataSet
        Return cls_at.Consultar("[i_pa_cons_control_caja]", obj)
    End Function
    Public Function Cn_ConsultarResumenesCaja(obj As coCtaCobrar) As DataSet
        Return cls_at.ConsultarResumenCaja("[i_pa_cons_control_resumen_caja]", obj)
    End Function
End Class
