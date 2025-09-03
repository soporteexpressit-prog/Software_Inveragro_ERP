Imports CapaDatos
Imports CapaObjetos

Public Class cnControlMemoDespido
    Private cls_at As New cdControlMemoDespido
    Public Function Cn_Consultar(obj As coControlMemoDespido) As DataTable
        Return cls_at.Cd_Consultar("[w_pa_cons_memorandum_despido]", obj)
    End Function

    Public Function Cn_ComprobarNumRegistrosMemo() As Integer
        Return cls_at.Cd_ComprobarNumRegistrosMemo("[w_comprobar_reg_memorandum]")
    End Function

    Public Function Cn_ComprobarNumRegistrosDespido() As Integer
        Return cls_at.Cd_ComprobarNumRegistrosDespido("[w_comprobar_reg_despido]")
    End Function

    Public Function Cn_ObtenerSiguienteNumMemorandum() As Integer
        Return cls_at.Cd_ObtenerSiguienteNumMemorandum("[w_obtener_siguiente_num_memorandum]")
    End Function

    Public Function Cn_ObtenerSiguienteNumDespido() As Integer
        Return cls_at.Cd_ObtenerSiguienteNumDespido("[w_obtener_siguiente_num_despido]")
    End Function

    Public Function Cn_Registrar(ByRef obj As coControlMemoDespido) As String
        Return cls_at.Cd_Registrar("[w_pa_reg_memorandum_despido]", obj)
    End Function

    Public Function Cn_ConsultarPorTrabajador(obj As coTrabajador) As DataSet
        Return cls_at.Cd_ConsultarPorTrabajador("[w_cons_memo_despido_por_persona]", obj)
    End Function

    Public Function Cn_ConsultarPorId(obj As coControlMemoDespido) As DataTable
        Return cls_at.Cd_ConsultarPorId("[w_pa_cons_memo_despido_por_id]", obj)
    End Function

    Public Function Cn_ActualizarArchivo(ByRef obj As coControlMemoDespido) As String
        Return cls_at.Cd_ActualizarArchivo("[w_actualizar_archivo_memo_despido]", obj)
    End Function

    Public Function Cn_ObtenerArchivo(idMemoDespido As Integer) As Byte()
        Return cls_at.Cd_obtenerArchivo("[w_obtener_archivo_memo_despido]", idMemoDespido)
    End Function

    Public Function Cn_ContenidoFormatoMemo() As DataTable
        Return cls_at.Cd_ContenidoFormatoMemo("[w_pa_obt_contenido_memorandum]")
    End Function

    Public Function Cn_ContenidoFormatoDespido() As DataTable
        Return cls_at.Cd_ContenidoFormatoDespido("[w_pa_obt_contenido_despido]")
    End Function
End Class
