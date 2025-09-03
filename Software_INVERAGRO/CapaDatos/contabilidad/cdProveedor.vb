Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdProveedor
    Private con As New cdConexion

    'REGISTRAR  / MODIFICAR / ELIMINAR
    Public Function Cd_Mantenimiento(name As String, obj As coProveedor) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@idPersona", SqlDbType.Int).Value = obj.IdPersona
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .AddWithValue("@numDocumento", SqlDbType.VarChar).Value = obj.NumDocumento
                .AddWithValue("@datos", SqlDbType.VarChar).Value = obj.Datos
                .AddWithValue("@direccion", SqlDbType.VarChar).Value = obj.Direccion
                .AddWithValue("@celular", SqlDbType.VarChar).Value = obj.Celular
                .AddWithValue("@correo", SqlDbType.Char).Value = obj.Correo
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
                .AddWithValue("@idTipoDocIdentidad", SqlDbType.Int).Value = obj.IdTipoDocIdentidad
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
                .AddWithValue("@idDistrito", SqlDbType.Int).Value = obj.IdDistrito
            End With

            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.Coderror = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cd_Consultar(name As String, obj As coProveedor) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@valor", SqlDbType.VarChar).Value = ""
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Sub Cd_ConvertirACliente(idPersona As Integer, ByRef mensaje As SqlParameter)
        Try
            con.Abrir()
            Dim cmd As New SqlCommand("JIHF_Convertir_a_Cliente", con.con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idPersona", idPersona)
            cmd.Parameters.Add(mensaje) ' Añade el parámetro de salida

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
    End Sub


    Public Function Cd_ConsultarxCodigo(name As String, obj As coProveedor) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idpersona", SqlDbType.Int).Value = obj.IdPersona
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ListarTipoDocIdentidad(name As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            'da.SelectCommand.Parameters.AddWithValue("@valor", SqlDbType.VarChar).Value = ""
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ListarTodasAseguradoras(name As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ListarAseguradora(name As String) As DataTable
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

    Public Function Cd_MantenimientoAseguradora(name As String, obj As coProveedor) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@idPersona", SqlDbType.Int).Value = obj.IdPersona
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .AddWithValue("@numDocumento", SqlDbType.VarChar).Value = obj.NumDocumento
                .AddWithValue("@datos", SqlDbType.VarChar).Value = obj.Datos
                .AddWithValue("@direccion", SqlDbType.VarChar).Value = obj.Direccion
                .AddWithValue("@celular", SqlDbType.VarChar).Value = obj.Celular
                .AddWithValue("@correo", SqlDbType.Char).Value = obj.Correo
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
                .AddWithValue("@idTipoDocIdentidad", SqlDbType.Int).Value = obj.IdTipoDocIdentidad
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
                .AddWithValue("@idDistrito", SqlDbType.Int).Value = obj.IdDistrito
            End With

            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.Coderror = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cd_ConsultarxCodigoUbicacion(name As String, obj As coProveedor) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idpersona", SqlDbType.Int).Value = obj.IdPersona
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function CargarDepartamentos(name As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            'da.SelectCommand.Parameters.AddWithValue("@valor", SqlDbType.VarChar).Value = ""
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function CargarProvincias(name As String, departamentoId As Integer) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@departamentoId", departamentoId)
            da.SelectCommand.Parameters.AddWithValue("@provinciaId", DBNull.Value)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function CargarDistritos(idProvincia As Integer) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Using cmd As New SqlCommand("JIHFCargarDatosProvinciaDistrito", con.con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@departamentoId", DBNull.Value)
                cmd.Parameters.AddWithValue("@provinciaId", idProvincia)
                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function


    Public Function EjecutarConsulta(cmd As SqlCommand) As DataTable
        Dim dt As New DataTable()
        Try
            con.Abrir()
            cmd.Connection = con.con
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function
End Class
