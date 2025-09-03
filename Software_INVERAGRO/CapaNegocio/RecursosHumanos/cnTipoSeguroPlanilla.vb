Imports CapaDatos

Public Class cnTipoSeguroPlanilla
    Private cls_at As New cdTipoSeguroPlanilla
    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_Listar("[w_pa_listar_tipo_seguro_planilla]")
    End Function
End Class
