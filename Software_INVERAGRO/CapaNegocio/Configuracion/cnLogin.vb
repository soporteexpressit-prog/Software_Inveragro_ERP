Imports System.Data.SqlClient
Imports CapaDatos
Imports CapaObjetos
Public Class cnLogin
    Dim datosLogin As New cdLogin()
    'Metodo para validar inicio de sesion
    Public Function ValidarInicioSesion(usuario As String, clave As String) As (String, Integer, Boolean, String, String)
        Dim datosLogin As New cdLogin()
        Return datosLogin.ValidarInicioSesion(usuario, clave)
    End Function
    Public Function actualizarclave(obj As coLogin) As String
        Return datosLogin.ActualizarContraseña("JIHFActualizarContraseña", obj)
    End Function

    Public Function ObtenerModulosPorUsuario(idPersona As Integer) As List(Of (NombreBoton As String, Estado As Boolean))
        Try
            Dim modulosConPermisos = datosLogin.ObtenerModulosPorUsuario(idPersona)
            If modulosConPermisos Is Nothing OrElse modulosConPermisos.Count = Nothing Then
                Return New List(Of (NombreBoton As String, Estado As Boolean))()
            End If
            Return modulosConPermisos.Select(Function(m) (NombreBoton:=m.NombreModulo, Estado:=m.EstadoModulo)).ToList()
        Catch sqlEx As SqlException
            MessageBox.Show("" & sqlEx.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return New List(Of (NombreBoton As String, Estado As Boolean))()
        Catch ex As Exception
            MessageBox.Show("" & ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return New List(Of (NombreBoton As String, Estado As Boolean))()
        End Try
    End Function
    Public Function ObtenerSubModulos1PorUsuario(idPersona As Integer) As List(Of (NombresubBoton As String, Estado As Boolean))
        Try
            Dim subModulos = datosLogin.ObtenerSubModulosNivel1PorUsuario(idPersona)
            Return subModulos.Select(Function(sm) (NombresubBoton:=sm.NombreSubModulo1, Estado:=sm.EstadoSubModuloNivel1)).ToList()
        Catch sqlEx As SqlException
            MessageBox.Show("" & sqlEx.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return New List(Of (NombreBoton As String, Estado As Boolean))() '
        Catch ex As Exception
            MessageBox.Show("" & ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return New List(Of (NombreBoton As String, Estado As Boolean))() ' Devuelve una lista vacía
        End Try
    End Function
    Public Function ObtenerSubModulos2PorUsuario(idPersona As Integer) As List(Of (NombresubBoton2 As String, Estado As Boolean))
        Try
            Dim subModulos = datosLogin.ObtenerSubModulosNivel2PorUsuario(idPersona)
            Return subModulos.Select(Function(sm) (NombresubBoton2:=sm.NombreSubModulo2, Estado:=sm.EstadoSubModuloNivel2)).ToList()
        Catch sqlEx As SqlException
            MessageBox.Show("" & sqlEx.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return New List(Of (NombreBoton As String, Estado As Boolean))() ' Devuelve una lista vacía
        Catch ex As Exception
            MessageBox.Show("" & ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return New List(Of (NombreBoton As String, Estado As Boolean))() ' Devuelve una lista vacía
        End Try
    End Function
    Public Function ObtenerBotonesPorUsuario(idPersona As Integer) As List(Of (Nombrebtn As String, Estado As Boolean))
        Try
            Dim botones = datosLogin.ObtenerBotonesPorUsuario(idPersona)
            Return botones.Select(Function(b) (Nombrebtn:=b.NombreBoton, Estado:=b.EstadoBoton)).ToList()
        Catch ex As Exception
            'Throw New Exception("" & ex.Message)

        End Try
    End Function
    Public Function ObtenerEstadoBotonesPorUsuario(idPersona As Integer) As List(Of (NombreBoton As String, Estado As Boolean))
        Try
            Dim botones = datosLogin.ObtenerBotonesPorUsuario(idPersona)
            Return botones.Select(Function(b) (NombreBoton:=b.NombreBoton, Estado:=b.EstadoBoton)).ToList()
        Catch ex As Exception
            Throw New Exception("" & ex.Message)
        End Try
    End Function

    'Solo para adquirir el ID, no borrar que con esto sirve el resto de validaciones
    Public Function ObtenerIdPersona(usuario As String) As Integer
        Dim idPersona As Integer = 0
        Dim con As New cdConexion()
        Dim connection As SqlConnection = con.Abrir()
        If connection IsNot Nothing Then
            Try
                Dim command As New SqlCommand("[j_obtener_iduser_login]", connection)
                command.Parameters.AddWithValue("@usuario", usuario)

                Using reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        idPersona = Convert.ToInt32(reader("idPersona"))
                    End If
                End Using
            Catch ex As Exception
                Throw New Exception("Error al obtener el ID de la persona: " & ex.Message)
            Finally
                con.Salir()
            End Try
        End If

        Return idPersona
    End Function

End Class
