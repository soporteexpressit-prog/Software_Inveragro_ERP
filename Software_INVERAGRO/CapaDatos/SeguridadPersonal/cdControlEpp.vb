Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdControlEpp
    Private con As New cdConexion

    Public Function Cd_Consultar(name As String, obj As coControlEpp) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", If(obj.FechaDesde.HasValue, obj.FechaDesde.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", If(obj.FechaHasta.HasValue, obj.FechaHasta.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@estado", If(String.IsNullOrEmpty(obj.Estado), DBNull.Value, obj.Estado))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_RegistrarEpp(name As String, obj As coControlEpp) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@fecha", SqlDbType.Date).Value = obj.Fecha
                .AddWithValue("@idSolicitante", SqlDbType.Int).Value = obj.IdSolicitante
                .AddWithValue("@idTipoMotivoEpp", SqlDbType.Int).Value = obj.IdTipoMotivoEpp
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.observacion
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
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

    Public Function Cd_AnularRegistroEpp(name As String, obj As coControlEpp) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@idUserAnulacion", SqlDbType.Int).Value = obj.IdUserAnulacion
                .AddWithValue("@motivoAnulacion", SqlDbType.VarChar).Value = obj.MotivoAnulacion
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
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

    Public Function Cd_ConsultarContratoPorTrabajador(name As String, obj As coTrabajador) As DataSet
        Dim dt As New DataSet
        Try
            If Not con.con.State = ConnectionState.Open Then
                con.Abrir()  ' Abre la conexión si no está abierta
            End If
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@idPersona", obj.IdPersona)
            da.Fill(dt)
        Catch ex As Exception
            Throw New Exception("Error al consultar los contratos por trabajador: " & ex.Message, ex)
        Finally
            con.Salir()
        End Try
        Return dt
    End Function
    Public Function Cd_ConsultarSCTRPorTrabajador(name As String, obj As coTrabajador) As DataSet
        Dim dt As New DataSet
        Try
            If Not con.con.State = ConnectionState.Open Then
                con.Abrir()  ' Abre la conexión si no está abierta
            End If
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@idPersona", obj.IdPersona)
            da.Fill(dt)
        Catch ex As Exception
            Throw New Exception("Error al consultar los contratos por trabajador: " & ex.Message, ex)
        Finally
            con.Salir()
        End Try
        Return dt
    End Function
    Public Function Cd_ConsultarUbicacionPorTrabajador(name As String, obj As coTrabajador) As DataSet
        Dim dt As New DataSet
        Try
            If Not con.con.State = ConnectionState.Open Then
                con.Abrir()  ' Abre la conexión si no está abierta
            End If
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@idPersona", obj.IdPersona)
            da.Fill(dt)
        Catch ex As Exception
            Throw New Exception("Error al consultar los contratos por trabajador: " & ex.Message, ex)
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_ConsultarBajaTrabajador(name As String, obj As coTrabajador) As DataSet
        Dim dt As New DataSet
        Try
            If Not con.con.State = ConnectionState.Open Then
                con.Abrir()  ' Abre la conexión si no está abierta
            End If
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@idPersona", obj.IdPersona)
            da.Fill(dt)
        Catch ex As Exception
            Throw New Exception("Error al consultar los contratos por trabajador: " & ex.Message, ex)
        Finally
            con.Salir()
        End Try
        Return dt
    End Function


    Public Function Cd_ConsultarHijosPorTrabajador(name As String, obj As coTrabajador) As DataSet
        Dim dt As New DataSet
        Try
            If Not con.con.State = ConnectionState.Open Then
                con.Abrir()  ' Abre la conexión si no está abierta
            End If
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@idPersona", obj.IdPersona)
            da.Fill(dt)
        Catch ex As Exception
            Throw New Exception("Error al consultar los contratos por trabajador: " & ex.Message, ex)
        Finally
            con.Salir()
        End Try
        Return dt
    End Function
    Public Function Cd_obtenerArchivo(name As String, idhiho As Integer) As Byte()
        Dim pdfData As Byte() = Nothing
        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@hijo", idhiho)

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
End Class
