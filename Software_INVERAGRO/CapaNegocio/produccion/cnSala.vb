Imports CapaDatos
Imports CapaObjetos

Public Class cnSala
    Private cls_at As New cdSala

    Public Function Cn_Mantenimiento(ByRef obj As coSala) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_sala]", obj)
    End Function

    Public Function Cn_Consultar() As DataTable
        Return cls_at.Cd_ListarGeneral("[w_pa_cons_sala]")
    End Function

    Public Function Cn_Listar() As DataTable
        Return cls_at.Cd_ListarGeneral("[w_pa_list_sala]")
    End Function
End Class
