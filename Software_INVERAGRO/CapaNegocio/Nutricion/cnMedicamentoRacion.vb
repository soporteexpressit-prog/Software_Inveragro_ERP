Imports CapaDatos
Imports CapaObjetos

Public Class cnMedicamentoRacion
    Dim cls_at As New cdMedicamentoRacion

    Public Function Cn_RegistrarPeriodoMedicamentoRacion(ByRef obj As coMedicamentoRacion) As String
        Return cls_at.Cd_RegistrarPeriodoMedicamentoRacion("[w_pa_reg_periodo_medicacion]", obj)
    End Function

    Public Function Cn_ConsultarPeriodoMedicamentoRacion(obj As coMedicamentoRacion) As DataSet
        Return cls_at.Cd_ConsultarPeriodoMedicamentoRacion("[w_pa_cons_periodo_medicacion]", obj)
    End Function

    Public Function Cn_ActualizarFechaFinPeriodoMedicamentoRacion(ByRef obj As coMedicamentoRacion) As String
        Return cls_at.Cd_ActualizarFechaFinPeriodoMedicamentoRacion("[w_actualizar_fecha_fin_periodo_medicacion]", obj)
    End Function

    Public Function Cn_CancelarPeriodoMedicamentoRacionPlus(ByRef obj As coMedicamentoRacion) As String
        Return cls_at.Cd_CancelarPeriodoMedicamentoRacion("[w_cancelar_periodo_medicacion]", obj)
    End Function

    Public Function Cn_ActivarPeriodoMedicamentoRacionPlus(ByRef obj As coMedicamentoRacion) As String
        Return cls_at.Cd_CancelarPeriodoMedicamentoRacion("[w_activar_periodo_medicacion_plus]", obj)
    End Function
End Class
