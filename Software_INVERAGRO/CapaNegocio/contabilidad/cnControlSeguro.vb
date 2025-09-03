Imports CapaDatos
Imports CapaObjetos

Public Class cnControlSeguro
    Private cls_at As New cdControlSeguro
    Public Function Cn_RegistrarSeguroSCTR(obj As coControlSeguro) As String
        Return cls_at.Cd_RegistrarSeguroSCTR("[w_pa_reg_seguro_sctr]", obj)
    End Function
    Public Function Cn_ConsultarSeguroTrabajador(obj As coControlSeguro) As DataSet
        Return cls_at.Cd_ConsultarSeguroTrabajador("[w_pa_cons_seguro_trabajador]", obj)
    End Function
    Public Function Cn_ObtenerArchivoTrabajador(idSeguro As Integer) As Byte()
        Return cls_at.Cd_obtenerArchivoTrabajador("[w_obtener_archivo_seguro]", idSeguro)
    End Function
    Public Function Cn_ActualizarArchivoSeguro(ByRef obj As coControlSeguro) As String
        Return cls_at.Cd_ActualizarArchivoSeguro("[w_actualizar_archivo_seguro]", obj)
    End Function
    Public Function Cn_CancelarSeguro(ByRef obj As coControlSeguro) As String
        Return cls_at.Cd_CancelarSeguro("[w_cancelar_seguro]", obj)
    End Function
    Public Function Cn_RegistrarSeguroActivo(obj As coControlSeguro) As String
        Return cls_at.Cd_RegistrarSeguroActivo("[w_pa_reg_seguro_activo]", obj)
    End Function

    Public Function Cn_ConsultarSeguroActivos(obj As coControlSeguro) As DataSet
        Return cls_at.Cd_ConsultarSeguroActivo("[w_pa_cons_seguro_activo]", obj)
    End Function
End Class
