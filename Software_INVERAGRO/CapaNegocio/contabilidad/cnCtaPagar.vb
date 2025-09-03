Imports CapaDatos
Imports CapaObjetos

Public Class cnCtaPagar
    Private cls_at As New cdCtaPagar
    Public Function Cn_Consultar(obj As coCtaPagar) As DataSet
        Return cls_at.Consultar("[i_pa_cons_control_ctas_pagar]", obj)
    End Function
    Public Function Cn_ListarTablasMaestrasAbonar() As DataSet
        Return cls_at.ListarTablasMaestrasAbonar("[i_pa_listar_tablas_maestras_abonarctapagar]")
    End Function

    Public Function Cn_ListarTablasMaestrasNotacredito() As DataSet
        Return cls_at.ListarTablasMaestrasAbonar("[j_pa_listar_tablas_maestras_ajustar]")
    End Function
    Public Function Cn_ObtenerDatosdeCuentaPagar(obj As coCtaPagar) As DataTable
        Return cls_at.ObtenerDatosdeCuentaPagar("[i_pa_obtener_cuenta_pagar]", obj)
    End Function
    Public Function Cn_ObtenerDatosdeLAORDEN(obj As coCtaPagar) As DataSet
        Return cls_at.ObtenerDatosdeorden("[j_obtener_detalleorden]", obj)
    End Function
    Public Function Cn_ObtenerDatosdeLAORDENventa(obj As coCtaPagar) As DataSet
        Return cls_at.ObtenerDatosdeorden("[j_obtener_detalleordenventa]", obj)
    End Function
    Public Function Cn_ObtenerDatosdeCuentaPagarTrabajador(obj As coCtaPagar) As DataTable
        Return cls_at.ObtenerDatosdeCuentaPagarTrabajores("[j_detalle_cuentas_por_pagar_planilla]", obj)
    End Function
    Public Function Cn_ListarTablasMaestrasPrestamo() As DataSet
        Return cls_at.ListarTablasMaestrasPrestamo("[i_pa_listar_tablas_maestras_prestamo]")
    End Function
    Public Function Cn_consultarxidcobrarEDITAR(obj As coCtaCobrar) As DataSet
        Return cls_at.Cd_Consultarxid("[j_pa_consultar_cuenta_pagarxid_editar]", obj)
    End Function
    Public Function Cn_Mantenimiento(ByRef obj As coCtaPagar) As String
        Return cls_at.Cd_Mantenimiento("[i_pa_reg_abono_ctapagar]", obj)
    End Function
    Public Function Cn_Mantenimientoajustecobrar(ByRef obj As coCtaPagar) As String
        Return cls_at.Cd_MantenimientoAjuste("[j_pa_reg_ajuste_ctacobrar]", obj)
    End Function
    Public Function Cn_Mantenimientoajuste(ByRef obj As coCtaPagar) As String
        Return cls_at.Cd_MantenimientoAjuste("[j_pa_reg_ajuste_ctapagar]", obj)
    End Function
    Public Function Cn_Mantenimientopagomultiple(ByRef obj As coCtaPagar) As String
        Return cls_at.Cd_Mantenimientopagomultiple("[j_pa_reg_abono_ctapagar_multiple]", obj)
    End Function
    Public Function Cn_ResPrestamo(ByRef obj As coPrestamo) As String
        Return cls_at.Cd_RegPrestamo("[i_pa_reg_prestamo_cuentapagar]", obj)
    End Function
    Public Function Cn_AnularCtaPagar(ByRef obj As coCtaPagar) As String
        Return cls_at.Cd_AnularCtaPagar("[i_pa_anular_ctapagar]", obj)
    End Function
    Public Function Cn_AnularCtaCobrar(ByRef obj As coCtaPagar) As String
        Return cls_at.Cd_AnularCtaPagar("[i_pa_anular_ctacobrar]", obj)
    End Function
    Public Function Cn_AnularAbonoCtaPagar(ByRef obj As coCtaPagar) As String
        Return cls_at.Cd_AnularAbonoCtaPagar("[i_pa_anular_abonoctapagar]", obj)
    End Function
    Public Function Cn_ConsultarPrestamoxCodigo(obj As coPrestamo) As DataSet
        Return cls_at.ConsultarPrestamoYCuotasxId("[i_pa_consultar_prestamo_por_codigo]", obj)
    End Function
    Public Function Cn_ConsultarPrestamopPendientePagoxCodigo(obj As coPrestamo) As DataSet
        Return cls_at.ConsultarPrestamoYCuotasxId("[i_pa_consultar_prestamo_pendiente_pago_por_codigo]", obj)
    End Function
    Public Function Cn_RegNuevaCuentaPagar(ByRef obj As coCtaPagar) As String
        Return cls_at.Cd_NuevaCtaPagar("[i_pa_reg_nueva_ctapagar]", obj)
    End Function
    Public Function Cn_RegNuevaCuentaCobraractualizar(ByRef obj As coCtaCobrar) As String
        Return cls_at.Cd_RegNuevaCuentaCobraractualizar("[i_pa_reg_nueva_cuentapagar_update]", obj)
    End Function
    Public Function Cn_NuevaCtaPagarDetalle(ByRef obj As coCtaPagar) As String
        Return cls_at.Cd_NuevaCtaPagarDetalle("[i_pa_reg_detalle_ctapagar]", obj)
    End Function
    Public Function Cn_ListarTablasMaestrasGasto() As DataSet
        Return cls_at.ListarTablasMaestrasAbonar("[i_pa_listar_tablas_maestras_nuevogasto]")
    End Function
    Public Function Cn_ConsultarArchivodeAbono(ByRef obj As coCtaPagar) As String
        Return cls_at.Cd_ObtenerArchivoAbono("[i_pa_obtenerArchivoAbono]", obj)
    End Function

    Public Function Cn_ConsultarControlCaja(obj As coCtaPagar) As DataSet
        Return cls_at.ConsultarCajaChica("[i_pa_cons_control_caja]", obj)
    End Function
    Public Function Cn_ConsultarResumenesCaja(obj As coCtaPagar) As DataSet
        Return cls_at.ConsultarResumenCaja("[i_pa_cons_control_resumen_caja]", obj)
    End Function

    Public Function Cn_ConsultarPrestamosPendientesxIdBanco(obj As coCtaPagar) As DataTable
        Return cls_at.Cd_ConsultarPrestamosPendientesxIdBanco("[w_pa_cons_prestamo_pendiente_x_banco]", obj)
    End Function
    Public Function Cn_RegistrarMontoDebitadoCtaPagar(obj As coCtaPagar) As String
        Return cls_at.Cd_RegistrarMontoDebitadoCtaPagar("[w_pa_reg_monto_debitado_ctapagar]", obj)
    End Function
End Class
