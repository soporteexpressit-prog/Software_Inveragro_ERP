Imports CapaDatos
Imports CapaObjetos

Public Class cnControlBonificacionVehiculoNN
    Private cls_at As New cdControlBonificacionVehiculoNN
    Public Function Cn_Registrar(obj As coControlBonificacionVehiculoNN) As String
        Return cls_at.Cd_Registrar("[w_pa_reg_bonificacion_suspencion]", obj)
    End Function
    Public Function Cn_Consultar(ByRef obj As coControlBonificacionVehiculoNN) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_bonificacion_suspencion_nn]", obj)
    End Function
    Public Function Cn_AnularBonificacionVehiculoNN(ByRef obj As coControlBonificacionVehiculoNN) As String
        Return cls_at.Cd_AnularBonificacionVehiculoNN("[w_cancelar_bonificacion_suspencion]", obj)
    End Function
End Class
