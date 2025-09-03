Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdLogin
    Dim con As New cdConexion()

    Public Function ValidarInicioSesion(usuario As String, clave As String) As (String, Integer, Boolean, String, String)
        Dim tipoPersona As String = Nothing
        Dim idPersona As Integer = -1
        Dim cambiarClave As Boolean = False
        Dim mensaje As String = ""
        Dim nombre As String = Nothing
        Dim con As New cdConexion()
        Dim connection As SqlConnection = con.Abrir()

        If connection IsNot Nothing Then
            Try
                ' Convertir clave a byte array
                Dim claveBytes As Byte() = ConvertHexStringToByteArray(clave)

                Using command As New SqlCommand("JIHFValidarInicioSesion", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add(New SqlParameter("@usuario", SqlDbType.NVarChar, 50)).Value = usuario
                    command.Parameters.Add(New SqlParameter("@clave", SqlDbType.VarBinary, -1)).Value = claveBytes
                    command.Parameters.Add(New SqlParameter("@mensaje", SqlDbType.NVarChar, 255)).Direction = ParameterDirection.Output

                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.HasRows AndAlso reader.Read() Then
                            tipoPersona = reader("Tipo").ToString()
                            idPersona = Convert.ToInt32(reader("idPersona"))
                            cambiarClave = Convert.ToBoolean(reader("cambiarClave"))
                            nombre = reader("datos").ToString()
                        End If
                    End Using

                    mensaje = command.Parameters("@mensaje").Value.ToString()
                End Using
            Catch ex As Exception
                Throw New Exception("Error al validar inicio de sesión: " & ex.Message)
            Finally
                con.Salir()
            End Try
        End If

        Return (tipoPersona, idPersona, cambiarClave, mensaje, nombre)
    End Function

    Private Function ConvertHexStringToByteArray(hexString As String) As Byte()
        If hexString.StartsWith("0x") Then
            hexString = hexString.Substring(2)
        End If
        Dim numberChars As Integer = hexString.Length
        Dim bytes As Byte() = New Byte(numberChars \ 2 - 1) {}

        For i As Integer = 0 To bytes.Length - 1
            bytes(i) = Convert.ToByte(hexString.Substring(i * 2, 2), 16)
        Next

        Return bytes
    End Function

    Public Function ObtenerModulosPorUsuario(idPersona As Integer) As List(Of (IdPersona As Integer, NombreModulo As String, EstadoModulo As Boolean))
        Dim modulos As New List(Of (Integer, String, Boolean))()
        Dim con As New cdConexion()
        Dim connection As SqlConnection = con.Abrir()
        If connection IsNot Nothing Then
            Try
                Dim command As New SqlCommand("JIHFObtenerEstadoModulo", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@idPersona", idPersona)
                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim idPersonaResult As Integer = Convert.ToInt32(reader("idPersona"))
                        Dim nombreModulo As String = reader("Nombremodulo").ToString()
                        Dim estadoModulo As Boolean = Convert.ToBoolean(reader("EstadoModulo"))
                        modulos.Add((idPersonaResult, nombreModulo, estadoModulo))
                    End While
                End Using
            Catch ex As Exception
                Throw New Exception("" & ex.Message)
            Finally
                con.Salir()
            End Try
        End If
        Return modulos
    End Function

    Public Function ObtenerSubModulosNivel1PorUsuario(idPersona As Integer) As List(Of (IdPersona As Integer, NombreSubModulo1 As String, EstadoSubModuloNivel1 As Boolean))
        Dim subModulos As New List(Of (Integer, String, Boolean))()
        Dim con As New cdConexion()
        Dim connection As SqlConnection = con.Abrir()
        If connection IsNot Nothing Then
            Try
                Dim command As New SqlCommand("JIHFObtenerEstadoSubModuloNivel1", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@idPersona", idPersona)
                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim idPersonaResult As Integer = Convert.ToInt32(reader("idPersona"))
                        Dim nombreSubModulo1 As String = reader("Nombrebtnsubmodulo1").ToString()
                        Dim estadoSubModuloNivel1 As Boolean = If(reader("EstadoSubModuloNivel1") IsNot DBNull.Value, Convert.ToBoolean(reader("EstadoSubModuloNivel1")), False)
                        subModulos.Add((idPersonaResult, nombreSubModulo1, estadoSubModuloNivel1))
                    End While
                End Using
            Catch ex As Exception
                Throw New Exception("" & ex.Message)
            Finally
                con.Salir()
            End Try
        End If
        Return subModulos
    End Function

    Public Function ObtenerSubModulosNivel2PorUsuario(idPersona As Integer) As List(Of (IdPersona As Integer, NombreSubModulo2 As String, EstadoSubModuloNivel2 As Boolean))
        Dim subModulos As New List(Of (Integer, String, Boolean))()
        Dim con As New cdConexion()
        Dim connection As SqlConnection = con.Abrir()
        If connection IsNot Nothing Then
            Try
                Dim command As New SqlCommand("JIHFObtenerEstadoSubModuloNivel2", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@idPersona", idPersona)
                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim idPersonaResult As Integer = Convert.ToInt32(reader("idPersona"))
                        Dim nombreSubModulo2 As String = reader("Nombrebtnsub2").ToString()
                        Dim estadoSubModuloNivel2 As Boolean = If(reader("EstadoSubModuloNivel2") IsNot DBNull.Value, Convert.ToBoolean(reader("EstadoSubModuloNivel2")), False)
                        subModulos.Add((idPersonaResult, nombreSubModulo2, estadoSubModuloNivel2))
                    End While
                End Using
            Catch ex As Exception
                Throw New Exception("" & ex.Message)
            Finally
                con.Salir()
            End Try
        End If
        Return subModulos
    End Function

    Public Function ObtenerBotonesPorUsuario(idPersona As Integer) As List(Of (IdPersona As Integer, NombreBoton As String, EstadoBoton As Boolean))
        Dim botones As New List(Of (Integer, String, Boolean))()
        Dim con As New cdConexion()
        Dim connection As SqlConnection = con.Abrir()
        If connection IsNot Nothing Then
            Try
                Dim command As New SqlCommand("JIHFObtenerEstadoBotones", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@idPersona", idPersona)
                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim idPersonaResult As Integer = Convert.ToInt32(reader("idPersona"))
                        Dim nombreBoton As String = reader("btnnombre").ToString()
                        Dim estadoBoton As Boolean = If(reader("EstadoBoton") IsNot DBNull.Value, Convert.ToBoolean(reader("EstadoBoton")), False)
                        botones.Add((idPersonaResult, nombreBoton, estadoBoton))
                    End While
                End Using
            Catch ex As Exception
                Throw New Exception("" & ex.Message)
            Finally
                con.Salir()
            End Try
        End If
        Return botones
    End Function

    Public Function ActualizarContraseña(name As String, obj As coLogin) As String
        Dim actualizado As String = ""
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                Dim claveBytes As Byte() = ConvertHexStringToByteArray(obj.clave)
                .AddWithValue("@idPersona", obj.IdPersona)
                .AddWithValue("@nuevaClave", claveBytes)

                Dim msjParam As New SqlParameter("@msj", SqlDbType.VarChar, 100)
                msjParam.Direction = ParameterDirection.Output
                .Add(msjParam)

                Dim coderrorParam As New SqlParameter("@coderror", SqlDbType.Int)
                coderrorParam.Direction = ParameterDirection.Output
                .Add(coderrorParam)
            End With

            cmd.ExecuteNonQuery()

            actualizado = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)

            con.Salir()
            Return actualizado
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
