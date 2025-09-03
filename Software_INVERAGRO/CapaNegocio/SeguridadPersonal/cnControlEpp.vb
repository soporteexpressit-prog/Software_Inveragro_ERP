Imports CapaDatos
Imports CapaObjetos

Public Class cnControlEpp
    Private cls_at As New cdControlEpp

    Public Function Cn_Consultar(obj As coControlEpp) As DataSet
        Return cls_at.Cd_Consultar("[w_pa_cons_control_epp]", obj)
    End Function
    Public Function Cn_RegistrarEpp(obj As coControlEpp) As String
        Return cls_at.Cd_RegistrarEpp("[w_pa_reg_entrega_epp]", obj)
    End Function
    Public Function Cn_AnularEpp(obj As coControlEpp) As String
        Return cls_at.Cd_AnularRegistroEpp("[w_pa_anular_entrega_epp]", obj)
    End Function

    Public Function Cn_ConsultarPorTrabajador(obj As coTrabajador) As DataSet
        Return cls_at.Cd_ConsultarPorTrabajador("[w_cons_control_epp_por_persona]", obj)
    End Function

    Public Function Cn_ConsultarContratoPorTrabajador(obj As coTrabajador) As DataSet
        Return cls_at.Cd_ConsultarContratoPorTrabajador("[j_tb_mostrar_tb_contratos_x_persona]", obj)
    End Function
    Public Function Cn_ConsultarSCTRPorTrabajador(obj As coTrabajador) As DataSet
        Return cls_at.Cd_ConsultarSCTRPorTrabajador("[j_pa_listar_sctr]", obj)
    End Function

    Public Function Cn_ConsultarPermisosTrabajador(obj As coTrabajador) As DataSet
        Return cls_at.Cd_ConsultarSCTRPorTrabajador("[j_pa_listar_permisolaboral_x_id]", obj)
    End Function

    Public Function Cn_ConsultarUbicacionPorTrabajador(obj As coTrabajador) As DataSet
        Return cls_at.Cd_ConsultarUbicacionPorTrabajador("[j_tb_mostrar_tb_Ubicacion_x_persona]", obj)
    End Function
    Public Function Cn_Consultarsueldosporidpersona(obj As coTrabajador) As DataSet
        Return cls_at.Cd_ConsultarUbicacionPorTrabajador("[j_tb_sueldos_trabajador]", obj)
    End Function

    Public Function Cn_ConsultarBajaTrabajador(obj As coTrabajador) As DataSet
        Return cls_at.Cd_ConsultarBajaTrabajador("[j_tb_mostrar_tb_motivobaja_x_persona]", obj)
    End Function

    Public Function Cn_ConsultarHijosPorTrabajador(obj As coTrabajador) As DataSet
        Return cls_at.Cd_ConsultarHijosPorTrabajador("[jihf_mostrar_tb_Hijos]", obj)
    End Function
    Public Function Cn_ObtenerArchivo(idhijo As Integer) As Byte()
        Return cls_at.Cd_obtenerArchivo("[JIHF_obtener_archivo_derechohabientos]", idhijo)
    End Function

End Class
