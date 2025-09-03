Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdControlSeguro
    Private con As New cdConexion
    Public Function Cd_ConsultarSeguroTrabajador(name As String, obj As coControlSeguro) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", If(obj.FechaDesde, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", If(obj.FechaHasta, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_RegistrarSeguroSCTR(name As String, obj As coControlSeguro) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@numPoliza", SqlDbType.VarChar).Value = obj.NumDocumento
                .AddWithValue("@numContratoSalud", SqlDbType.VarChar).Value = obj.NumContratoSalud
                .AddWithValue("@fEmision", SqlDbType.Date).Value = obj.FechaEmision
                .AddWithValue("@fInicio", SqlDbType.Date).Value = obj.FechaInicio
                .AddWithValue("@fFin", SqlDbType.Date).Value = obj.FechaFin
                If obj.Archivo IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.Archivo
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .AddWithValue("@idTipoSeguro", SqlDbType.Int).Value = obj.IdTipoSeguro
                .AddWithValue("@idPersona", SqlDbType.Int).Value = obj.IdProveedorSeguro
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUser
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With

            cmd.ExecuteNonQuery()

            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)

            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_obtenerArchivoTrabajador(name As String, idSeguro As Integer) As Byte()
        Dim archivoEvidencia As Byte() = Nothing
        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idSeguro", idSeguro)

            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                If Not reader.IsDBNull(0) Then
                    archivoEvidencia = DirectCast(reader(0), Byte())
                End If
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try

        Return archivoEvidencia
    End Function

    Public Function Cd_ActualizarArchivoSeguro(name As String, obj As coControlSeguro) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idSeguro", SqlDbType.Int).Value = obj.Codigo
                If obj.Archivo IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.Archivo
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With

            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_CancelarSeguro(name As String, obj As coControlSeguro) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idSeguro", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@motivoAnulacion", SqlDbType.VarChar).Value = obj.MotivoAnulacion
                .AddWithValue("@idUserAnulacion", SqlDbType.Int).Value = obj.IdUsuarioAnulacion
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With

            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_RegistrarSeguroActivo(name As String, obj As coControlSeguro) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@numPoliza", SqlDbType.VarChar).Value = obj.NumDocumento
                .AddWithValue("@fEmision", SqlDbType.Date).Value = obj.FechaEmision
                .AddWithValue("@fInicio", SqlDbType.Date).Value = obj.FechaInicio
                .AddWithValue("@fFin", SqlDbType.Date).Value = obj.FechaFin
                If obj.Archivo IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.Archivo
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .AddWithValue("@idTipoSeguro", SqlDbType.Int).Value = obj.IdTipoSeguro
                .AddWithValue("@idPersona", SqlDbType.Int).Value = obj.IdProveedorSeguro
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUser
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With

            cmd.ExecuteNonQuery()

            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)

            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cd_ConsultarSeguroActivo(name As String, obj As coControlSeguro) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", If(obj.FechaDesde, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", If(obj.FechaHasta, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
End Class
