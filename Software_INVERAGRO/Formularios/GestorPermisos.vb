Imports CapaNegocio

Public Class GestorPermisos
    Private loginNegocio As New cnLogin()
    Public Sub AplicarPermisosFormulario(formulario As Form, idPersona As Integer)
        Dim modulos As List(Of (NombreBoton As String, Estado As Boolean)) = loginNegocio.ObtenerModulosPorUsuario(idPersona)
        Dim subModulos1 As List(Of (NombreBoton As String, Estado As Boolean)) = loginNegocio.ObtenerSubModulos1PorUsuario(idPersona)
        Dim subModulos2 As List(Of (NombreBoton As String, Estado As Boolean)) = loginNegocio.ObtenerSubModulos2PorUsuario(idPersona)
        ' Combinar todas las listas de permisos
        Dim permisos As New List(Of (NombreBoton As String, Estado As Boolean))
        permisos.AddRange(modulos)
        permisos.AddRange(subModulos1)
        permisos.AddRange(subModulos2)
        For Each control As Control In formulario.Controls
            If TypeOf control Is Button Then
                Dim boton As Button = DirectCast(control, Button)
                Dim permiso = permisos.FirstOrDefault(Function(p) p.NombreBoton = boton.Name)
                If permiso.NombreBoton IsNot Nothing Then
                    boton.Enabled = permiso.Estado
                End If
            End If
        Next
    End Sub
End Class
