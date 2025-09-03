Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdActivo
    Private con As New cdConexion
    Public Function Cd_Mantenimiento(name As String, obj As coActivo) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@idActivo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion
                .AddWithValue("@fAdquisicion", SqlDbType.Date).Value = obj.FechaAdquisicion
                .AddWithValue("@nota", SqlDbType.VarChar).Value = obj.Nota
                .AddWithValue("@placa", SqlDbType.VarChar).Value = obj.Placa
                .AddWithValue("@numSerie", SqlDbType.DateTime).Value = obj.NumSerie
                .AddWithValue("@capacidad", SqlDbType.VarChar).Value = obj.Capacidad
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
                .AddWithValue("@idUsuario", SqlDbType.Char).Value = obj.IdUser
                .AddWithValue("@costoAdquisicion", SqlDbType.Int).Value = obj.CostoAdquisicion
                .AddWithValue("@idMarcaActivo", SqlDbType.VarChar).Value = obj.IdMarca
                .AddWithValue("@vidaUtil", SqlDbType.Int).Value = obj.VidaUtil
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .AddWithValue("@idDetalleRecepcion", SqlDbType.Int).Value = obj.IdDetalleRecepcion
                .AddWithValue("@numOrden", SqlDbType.Int).Value = obj.NumOrden
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
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

    Public Function Cd_ConsultarActivosRegistrados(name As String, obj As coActivo) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idDetalleRecepcion", obj.IdDetalleRecepcion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarActivos(name As String, obj As coActivo) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", If(obj.FechaDesde.HasValue, obj.FechaDesde.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", If(obj.FechaHasta.HasValue, obj.FechaHasta.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.Tipo)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarxId(name As String, obj As coActivo) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idActivo", SqlDbType.Int).Value = obj.Codigo
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_DarBajaActivo(name As String, obj As coActivo) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idActivo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@motivoAnulacion", SqlDbType.VarChar).Value = obj.MotivoAnulacion
                .AddWithValue("@idUsuarioAnulacion", SqlDbType.Int).Value = obj.IdUserAnulacion
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

    Public Function Cd_ListarActivos(name As String, obj As coActivo) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", If(obj.FechaDesde.HasValue, obj.FechaDesde.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", If(obj.FechaHasta.HasValue, obj.FechaHasta.Value, DBNull.Value))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ListarActivosVehiculos(name As String, obj As coActivo) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", If(obj.FechaDesde.HasValue, obj.FechaDesde.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", If(obj.FechaHasta.HasValue, obj.FechaHasta.Value, DBNull.Value))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
End Class
