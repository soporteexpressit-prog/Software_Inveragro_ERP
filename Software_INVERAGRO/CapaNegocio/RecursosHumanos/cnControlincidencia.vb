Imports System.Data.SqlClient
Imports CapaDatos
Imports CapaObjetos

Public Class cnControlIncidencia
    Private cd As New cdControlIncidencia()
    Public Function ObtenerDatosIncidencia(idPersona As Integer) As coControlincidencia
        Return cd.ObtenerDatosPorID(idPersona)
    End Function
    Public Function InsertarIncidenteConCausas(nuevoIncidente As coControlincidencia, listaCausas As List(Of String)) As Boolean
        If listaCausas Is Nothing Then
            listaCausas = New List(Of String)() ' Inicializa listaCausas como una lista vacía si es nula
        End If
        Return cd.InsertarIncidenteConCausas(nuevoIncidente, listaCausas)
    End Function
    Public Function ObtenerIncidencias() As DataTable
        Return cd.ObtenerIncidencias()
    End Function
    Public Function ObtenerConteoAseguradosTrabajadores() As coControlincidencia
        Return cd.ObtenerConteoAseguradosTrabajadores()
    End Function
    Public Function Cn_Consultar(obj As coControlincidencia) As DataTable
        Return cd.Cd_Consultar("[JIHFporfechaObtenerIncidencias]", obj)
    End Function
    Public Function Cn_Consultaralmacen(obj As coControlincidencia) As DataSet
        Return cd.Cn_Consultaralmacen("[j_reporte_almacen]", obj)
    End Function

    Public Function Cn_Consultarlistaproductos(obj As coControlincidencia) As DataSet
        Return cd.Cn_Consultaralmacen("[j_pa_cons_producto]", obj)
    End Function
    Public Function Cn_ConsultarreporteContabilidad(obj As coControlincidencia) As DataSet
        Return cd.Cn_Consultaralmacen("[j_reporte_contabilidad]", obj)
    End Function

    Public Function Cn_ConsultarreporteContabilidadgeneral(obj As coControlincidencia) As DataSet
        Return cd.Cn_Consultaralmacen("[j_pa_reporte_general_contabilidad]", obj)
    End Function
    Public Function Cn_ConsultarreporteCajachica(obj As coControlincidencia) As DataSet
        Return cd.Cn_Consultaralmacen("[i_pa_cons_control_caja_reporte]", obj)
    End Function
    Public Function Cn_Consultarreporterrhhgeneral(obj As coControlincidencia) As DataSet
        Return cd.Cn_Consultaralmacen("[j_pa_reporte_general_rrhh]", obj)
    End Function

    Public Function Cn_Consultarreportecomprasgeneral(obj As coControlincidencia) As DataSet
        Return cd.Cn_Consultaralmacen("[j_pa_reporte_general_compras]", obj)
    End Function

    Public Function Cn_ConsultarId(obj As coControlincidencia) As DataSet
        Return cd.Cd_ConsultarId("[JIHF_obtener_informacion_completa_por_incidente]", obj)
    End Function

    Public Function Cn_ActualizarArchivo(ByRef obj As coControlincidencia) As String
        Return cd.Cd_ActualizarArchivo("[JIHF_actualizar_archivo_incidente]", obj)
    End Function

    Public Function Cn_ObtenerArchivo(idincidente As Integer) As Byte()
        Return cd.Cd_obtenerArchivo("[JIHF_obtener_archivo_incidente]", idincidente)
    End Function

    Public Function Cn_ConsultaTotalModuloSistema(obj As coControlincidencia) As DataSet
        Return cd.Cn_ConsultarFechas("[reporte_consolidado_completo]", obj)
    End Function
End Class
