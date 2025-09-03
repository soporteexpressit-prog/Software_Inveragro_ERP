Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdControlMemoDespido
    Private con As New cdConexion

    Public Function Cd_Registrar(name As String, obj As coControlMemoDespido) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@numero", SqlDbType.Int).Value = obj.NumMemoDespido
                .AddWithValue("@fEmision", SqlDbType.Date).Value = obj.FechaEmision
                .AddWithValue("@idMotivoMemoDes", SqlDbType.Int).Value = obj.IdMotivoMemoDespido
                .AddWithValue("@idUser", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idsTrabajador", SqlDbType.VarChar).Value = obj.IdsTrabajador
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.Tipo
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

    Public Function Cd_Consultar(name As String, obj As coControlMemoDespido) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@nivel", obj.Nivel)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarPorId(name As String, obj As coControlMemoDespido) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idMemoDespido", obj.IdMotivoMemoDespido)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ComprobarNumRegistrosMemo(name As String) As Integer
        Dim numRegistros As Integer = -1

        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim outputParam As New SqlParameter("@contador", SqlDbType.Int)
            outputParam.Direction = ParameterDirection.Output
            cmd.Parameters.Add(outputParam)
            cmd.ExecuteNonQuery()
            numRegistros = Convert.ToInt32(cmd.Parameters("@contador").Value)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return numRegistros
    End Function

    Public Function Cd_ComprobarNumRegistrosDespido(name As String) As Integer
        Dim numRegistros As Integer = -1

        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim outputParam As New SqlParameter("@contador", SqlDbType.Int)
            outputParam.Direction = ParameterDirection.Output
            cmd.Parameters.Add(outputParam)
            cmd.ExecuteNonQuery()
            numRegistros = Convert.ToInt32(cmd.Parameters("@contador").Value)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return numRegistros
    End Function

    Public Function Cd_ObtenerSiguienteNumMemorandum(name As String) As Integer
        Dim siguienteNumMemo As Integer = -1

        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim outputParam As New SqlParameter("@siguienteNumero", SqlDbType.Int)
            outputParam.Direction = ParameterDirection.Output
            cmd.Parameters.Add(outputParam)
            cmd.ExecuteNonQuery()
            siguienteNumMemo = Convert.ToInt32(cmd.Parameters("@siguienteNumero").Value)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return siguienteNumMemo
    End Function

    Public Function Cd_ObtenerSiguienteNumDespido(name As String) As Integer
        Dim siguienteNumMemo As Integer = -1

        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim outputParam As New SqlParameter("@siguienteNumero", SqlDbType.Int)
            outputParam.Direction = ParameterDirection.Output
            cmd.Parameters.Add(outputParam)
            cmd.ExecuteNonQuery()
            siguienteNumMemo = Convert.ToInt32(cmd.Parameters("@siguienteNumero").Value)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return siguienteNumMemo
    End Function

    Public Function Cd_ActualizarArchivo(name As String, obj As coControlMemoDespido) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idMemoDespido", SqlDbType.Int).Value = obj.Codigo
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

    Public Function Cd_obtenerArchivo(name As String, idMemoDespido As Integer) As Byte()
        Dim pdfData As Byte() = Nothing
        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idMemoDespido", idMemoDespido)

            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                If Not reader.IsDBNull(0) Then
                    pdfData = DirectCast(reader(0), Byte())
                End If
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try

        Return pdfData
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

    Public Function Cd_ContenidoFormatoMemo(name As String) As DataTable
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

    Public Function Cd_ContenidoFormatoDespido(name As String) As DataTable
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
