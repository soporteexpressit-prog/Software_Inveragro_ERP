Imports CapaDatos
Imports CapaObjetos

Public Class cnControlMedico
    Private cls_at As New cdControlMedico

    Public Function Cn_RegistrarTratamiento(ByRef obj As coControlMedico) As String
        Return cls_at.Cd_RegistrarTratamiento("[w_pa_reg_control_tratamiento]", obj)
    End Function

    Public Function Cn_RegistrarVacunacion(ByRef obj As coControlMedico) As String
        Return cls_at.Cd_RegistrarVacunacion("[w_pa_reg_control_vacunacion]", obj)
    End Function

    Public Function Cn_ConsultarMedicacion(ByRef obj As coControlMedico) As DataSet
        Return cls_at.Cd_ConsultarMedicacion("[w_pa_cons_control_vacunacion_tratamiento]", obj)
    End Function

    Public Function Cn_CancelarMedicacion(ByRef obj As coControlMedico) As String
        Return cls_at.Cd_CancelarMedicacion("[r_pa_cancelar_medicacion]", obj)
    End Function

    Public Function Cn_ConsultarMedicacionxLote(ByRef obj As coControlMedico) As DataSet
        Return cls_at.Cd_ConsultarMedicacionxLote("[w_pa_cons_medicacion_lote]", obj)
    End Function

    Public Function Cn_RegistrarProtocoloSanidad(ByRef obj As coControlMedico) As String
        Return cls_at.Cd_RegistrarProtocoloSanidad("[w_pa_mantenimiento_protocolo_sanitario]", obj)
    End Function

    Public Function Cn_ConsultarProtocoloSanitario(ByRef obj As coControlMedico) As DataSet
        Return cls_at.Cd_ConsultaPlanSanitario("[w_pa_consultar_protocolo_sanitario]", obj)
    End Function

    Public Function Cn_ConsultarProtocoloSanitarioxId(ByRef obj As coControlMedico) As DataSet
        Return cls_at.Cd_ConsultarProtocoloSanitarioxId("[w_pa_consultar_protocolo_sanitario_por_id]", obj)
    End Function

    Public Function Cn_ConsultarMedicamentoxId(ByRef obj As coControlMedico) As DataTable
        Return cls_at.Cd_ConsultarMedicamentoxId("[w_pa_obtener_ultimo_proveedor_producto]", obj)
    End Function

    Public Function Cn_MantenimientoHistoricoEnfermedades(ByRef obj As coControlMedico) As String
        Return cls_at.Cd_MantenimientoHistoricoEnfermedades("[r_pa_mant_historico_enfermedades_granja]", obj)
    End Function

    Public Function Cn_RegistrarAnalisis(ByRef obj As coControlMedico) As String
        Return cls_at.Cd_RegistrarAnalisis("[r_pa_registrar_analisis]", obj)
    End Function

    Public Function Cn_ObtenerArchivoAnalisis(ByRef obj As coControlMedico) As String
        Return cls_at.Cd_ObtenerArchivoAnalisis("[r_pa_obtener_archivo_analisis]", obj)
    End Function

    Public Function Cn_ObtenerArchivoRegistroPrincipal(ByRef obj As coControlMedico) As String
        Return cls_at.Cd_ObtenerArchivoRegistroPrincipal("[r_pa_obtener_archivo_registro_principal]", obj)
    End Function

    Public Function Cn_ConsultarHistorialEnfermedad(ByRef obj As coControlMedico) As DataSet
        Return cls_at.Cd_ConsultarHistorialEnfermedad("[r_pa_cons_historial_enfermedad]", obj)
    End Function

    Public Function Cn_ConsultarLotesSanidad(ByRef obj As coControlMedico) As DataTable
        Return cls_at.Cd_ConsultarLotesSanidad("[w_pa_lotecampaña_x_campaña]", obj)
    End Function

    Public Function Cn_ConsultarCumplimientoVacunacion(ByRef obj As coControlMedico) As DataTable
        Return cls_at.Cd_ConsultarCumplimientoVacunacion("[w_pa_cumplimiento_vacunacion]", obj)
    End Function
End Class
