Imports CapaDatos
Imports CapaObjetos

Public Class cnControlPreparacionAlimento
    Private cls_at As New cdControlPreparacionAlimento

    Public Function Cn_RegistrarRequerimientoAlimento(obj As coControlPreparacionAlimento) As String
        Return cls_at.Cd_RegistrarSalidaInsumoYIngresoRecepcionAlimento("[w_pa_reg_salida_insumos_y_ingreso_recepcion_alimento]", obj)
    End Function

    Public Function Cn_ConsultarAlimentoPreparado(obj As coControlPreparacionAlimento) As DataTable
        Return cls_at.Cd_ConsultarAlimentoPreparado("[w_pa_cons_requerimiento_alimento_preparados]", obj)
    End Function

    Public Function Cn_ObtenerRecetaAlimentoPremixeroPorIdRacion(ByRef obj As coControlPreparacionAlimento) As Object
        Dim resultado As Object = cls_at.Cd_ObtenerRecetaAlimentoPremixeroPorIdRacion("[w_pa_obtener_receta_alimento_premixero_x_id_racion]", obj)

        If TypeOf resultado Is String Then
            Return resultado
        Else
            Return CType(resultado, DataSet)
        End If
    End Function
End Class
