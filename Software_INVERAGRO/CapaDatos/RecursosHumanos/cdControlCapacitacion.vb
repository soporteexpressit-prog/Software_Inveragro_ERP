Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdControlCapacitacion
    Private con As New cdConexion
    Public Function Cd_Consultar(name As String, obj As coControlCapacitacion) As DataSet
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
    Public Function Cd_ConsultarId(name As String, obj As coControlCapacitacion) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idCapacitacion", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_RegistrarCapacitacion(name As String, obj As coControlCapacitacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@fCapacitacion", SqlDbType.Date).Value = obj.FechaCapacitacion
                .AddWithValue("@idCapacitador", SqlDbType.Int).Value = obj.IdCapacitador
                .AddWithValue("@idUser", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idTipoCapacitacion", SqlDbType.Int).Value = obj.IdTipoCapacitacion
                .AddWithValue("@idTema", SqlDbType.Int).Value = obj.IdTemarioCapacitacion
                .AddWithValue("@rutaEvidencia", SqlDbType.VarChar).Value = obj.RutaEvidencia
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
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

    Public Function Cd_CancelarCapacitacion(name As String, obj As coControlCapacitacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
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

    Public Function Cd_ConsultarPorTrabajador(name As String, obj As coTrabajador) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idPersona", obj.IdPersona)
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", If(obj.FechaDesde.HasValue, obj.FechaDesde.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", If(obj.FechaHasta.HasValue, obj.FechaHasta.Value, DBNull.Value))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_RegistrarRutaEvidencia(name As String, obj As coControlCapacitacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idCapacitacion", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@rutaEvidencia", SqlDbType.VarBinary).Value = obj.RutaEvidencia
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

    Public Function Cd_ObtenerRutaEvidencia(name As String, obj As coControlCapacitacion) As String
        Dim rutaEvidencia As String = ""
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@idCapacitacion", obj.Codigo)
            End With

            Dim resultado As Object = cmd.ExecuteScalar()

            If resultado IsNot Nothing AndAlso Not IsDBNull(resultado) Then
                rutaEvidencia = Convert.ToString(resultado)
            End If

            con.Salir()
            Return rutaEvidencia
        Catch ex As Exception
            con.Salir()
            Throw ex
        End Try
    End Function
End Class
