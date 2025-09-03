Imports CapaDatos
Imports CapaObjetos

Public Class cnControlExcedente
    Private cls_at As New cdControlExcedente
    Public Function Cn_RegistrarInsumoExcedenteAlimentoCerdo(obj As coControlExcedente) As String
        Return cls_at.Cd_RegistrarInsumoExcedenteAlimentoCerdo("[w_pa_reg_insumo_excedente_alimento_cerdo]", obj)
    End Function

    Public Function Cn_ConsultarInsumoExcedenteAlimentoCerdo(obj As coControlExcedente) As DataSet
        Return cls_at.Cd_ConsultarInsumoExcedenteAlimentoCerdo("[w_pa_cons_insumo_excedente_alimento_cerdo]", obj)
    End Function

    Public Function Cn_CancelarSalidaInsumoExcedente(obj As coControlExcedente) As String
        Return cls_at.Cd_CancelarSalidaInsumoExcedente("[w_pa_cancelar_pedido_alimento]", obj)
    End Function
End Class
