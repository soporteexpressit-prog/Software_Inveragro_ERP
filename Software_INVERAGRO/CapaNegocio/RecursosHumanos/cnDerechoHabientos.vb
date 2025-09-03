Imports CapaDatos
Imports CapaObjetos

Public Class cnDerechoHabientos
    Private cls_at As New cdDerechoHabiento
    Public Function Cn_Mantenimiento(ByRef obj As coDerechoHabiento) As String
        Return cls_at.Cd_Mantenimiento("[JIHF_mant_inserta_hijo]", obj)
    End Function

    Public Function Cn_Actualizahijo(ByRef obj As coDerechoHabiento, obj2 As coTrabajador) As String
        Return cls_at.Cd_Actualizahijo("[JIHF_mant_actualiza_hijo]", obj, obj2)
    End Function

    Public Function Cn_Actualizabajafamilia(ByRef obj As coDerechoHabiento, obj2 As coTrabajador) As String
        Return cls_at.Cd_Actualizabajafamilia("[JIHF_mant_actualiza_Bajafamiliar]", obj, obj2)
    End Function
End Class
