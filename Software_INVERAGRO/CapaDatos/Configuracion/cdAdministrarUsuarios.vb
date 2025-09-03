Imports CapaObjetos
Imports System.Data.SqlClient
Public Class cdAdministrarUsuarios
    Dim con As New cdConexion

    Public Function Cd_ListarModulosSubModulos(name As String) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ListarModulosSubModulosCelular(name As String) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ListarUsuariosxTipo(name As String, tipo As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.Add(New SqlParameter("@tipo", tipo))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ObtenerDatosUsuarioXId(name As String, idPersona As Integer) As coAdministrarUsuarios
        Dim obj As New coAdministrarUsuarios
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@idPersona", idPersona)
            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    If Not IsDBNull(reader("usuario")) Then
                        obj.Usuario = reader("usuario").ToString()
                    End If
                    If Not IsDBNull(reader("nombreCompleto")) Then
                        obj.NombreCompleto = reader("nombreCompleto").ToString()
                    End If
                    If Not IsDBNull(reader("tipo")) Then
                        obj.Tipo = reader("tipo").ToString()
                    End If
                    If Not IsDBNull(reader("estado")) Then
                        obj.Estado = reader("estado").ToString()
                    End If
                End If
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return obj
    End Function

    Public Function Cd_ObtenerBotonesxId(name As String, obj As coAdministrarUsuarios) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add(New SqlParameter("@idSubModuloNivel1", obj.IdSubModuloNivel1))
            da.SelectCommand.Parameters.Add(New SqlParameter("@idSubModuloNivel2", obj.IdSubModuloNivel2))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_ObtenerSubModuloNivel1xId(name As String, obj As coAdministrarUsuarios) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add(New SqlParameter("@idModulo", obj.IdModulo))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_ObtenerSubModuloCelularPorId(name As String, obj As coAdministrarUsuarios) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add(New SqlParameter("@idModuloCelular", obj.IdModulo))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_ObtenerSubModuloNivel2xId(name As String, obj As coAdministrarUsuarios) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add(New SqlParameter("@idSubModuloNivel1", obj.IdSubModuloNivel1))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_ListarModulos(name As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_RegDetallePermiso(name As String, obj As coAdministrarUsuarios) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4
            With cmd.Parameters
                .AddWithValue("@idPerfil", SqlDbType.Int).Value = obj.IdPerfil
                .AddWithValue("@lista_Permisos", SqlDbType.VarChar).Value = obj.Lista_Permisos
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.Coderror = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
        Catch ex As Exception
            Throw ex
        End Try
        Return mensaje
    End Function

    Public Function Cd_RegDetallePermisoCelular(name As String, obj As coAdministrarUsuarios) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4
            With cmd.Parameters
                .AddWithValue("@idPerfil", SqlDbType.Int).Value = obj.IdPerfil
                .AddWithValue("@lista_Permisos", SqlDbType.VarChar).Value = obj.Lista_Permisos
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.Coderror = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
        Catch ex As Exception
            Throw ex
        End Try
        Return mensaje
    End Function

    Public Function Cd_AsignarPerfilAPersona(name As String, obj As coAdministrarUsuarios) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4
            With cmd.Parameters
                .AddWithValue("@idPerfil", SqlDbType.Int).Value = obj.IdPerfil
                .AddWithValue("@lista_Personas", SqlDbType.VarChar).Value = obj.Lista_Personas
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.Coderror = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
        Catch ex As Exception
            Throw ex
        End Try
        Return mensaje
    End Function

    Public Function Cd_ListarUsuariosConPerfil(name As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_ListarUsuariosConPerfilMovil(name As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_ActualizarPersonaxPerfil(name As String, obj As coAdministrarUsuarios) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4
            With cmd.Parameters
                .AddWithValue("@idPersona", SqlDbType.Int).Value = obj.IdPersona
                .AddWithValue("@idPerfil", SqlDbType.VarChar).Value = obj.IdPerfil
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.Coderror = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
        Catch ex As Exception
            Throw ex
        End Try
        Return mensaje
    End Function

    Public Function Cd_ObtenerPermisosModuloPorId(name As String, obj As coAdministrarUsuarios) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add(New SqlParameter("@idPerfil", obj.IdPerfil))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_ObtenerPermisosModuloCelularPorId(name As String, obj As coAdministrarUsuarios) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add(New SqlParameter("@idPerfil", obj.IdPerfil))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function


    Public Function Cd_ObtenerPermisosSubModuloNivel2PorId(name As String, obj As coAdministrarUsuarios) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add(New SqlParameter("@idPerfil", obj.IdPerfil))
            da.SelectCommand.Parameters.Add(New SqlParameter("@idSubModuloNivel1", obj.IdSubModuloNivel1))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function
    Public Function Cd_ObtenerPermisosBotonesPorId(name As String, obj As coAdministrarUsuarios) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add(New SqlParameter("@idPerfil", obj.IdPerfil))
            da.SelectCommand.Parameters.Add(New SqlParameter("@idSubModuloNivel1", obj.IdSubModuloNivel1))
            da.SelectCommand.Parameters.Add(New SqlParameter("@idSubModuloNivel2", obj.IdSubModuloNivel2))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_ObtenerPermisosSubModuloNivel1PorId(name As String, obj As coAdministrarUsuarios) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add(New SqlParameter("@idPerfil", obj.IdPerfil))
            da.SelectCommand.Parameters.Add(New SqlParameter("@idModulo", obj.IdModulo))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_ObtenerPermisosSubModuloCelularPorId(name As String, obj As coAdministrarUsuarios) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add(New SqlParameter("@idPerfil", obj.IdPerfil))
            da.SelectCommand.Parameters.Add(New SqlParameter("@idModulo", obj.IdModulo))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_ListarModulosCelular(name As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function
End Class
