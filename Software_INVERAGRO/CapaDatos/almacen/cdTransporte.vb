Imports CapaObjetos
Imports System.Data.SqlClient

Public Class cdTransporte
    Private con As New cdConexion
    Public Function Cd_Consultar(name As String) As DataTable
        Dim dt As New DataTable
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

    Public Function cd_insertar_transporte(name As String, obj As coTransporte) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.operacion
                If obj.operacion = 2 Then
                    .AddWithValue("@idTransporte", SqlDbType.Int).Value = obj.Codigo
                End If
                .AddWithValue("@numPlaca", SqlDbType.Int).Value = obj.numplaca
                .AddWithValue("@tipoVehiculo", SqlDbType.VarChar).Value = obj.tipovehiculo
                .AddWithValue("@marca", SqlDbType.Int).Value = obj.marca
                .AddWithValue("@modelo", SqlDbType.Int).Value = obj.modelo
                .AddWithValue("@anioFabricacion", SqlDbType.Int).Value = obj.aniofabricacion
                .AddWithValue("@capacidadCarga", SqlDbType.Int).Value = obj.capacidadcarga
                .AddWithValue("@estado", SqlDbType.Int).Value = obj.estado
                .AddWithValue("@pesotara", SqlDbType.Int).Value = obj.pesotara
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
    Public Function Cd_Consultarxid(name As String, obj As coTransporte) As DataTable
        Dim dt As New DataTable()
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idtransporte", obj.Codigo)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
        Catch ex As Exception
            Throw New Exception("Error al consultar los datos del transporte: " & ex.Message)
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_consultarMantenedor(name As String, obj As coTransporte) As DataTable
        Dim dt As New DataTable()
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@tipomarca", obj.tipoestado)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
        Catch ex As Exception
            Throw New Exception("Error al consultar los datos del transporte: " & ex.Message)
        Finally
            con.Salir()
        End Try
        Return dt
    End Function
    Public Function ListarTablasMaestras(name As String) As DataSet
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

    Public Function Cd_Mantenimientotipomarca(name As String, obj As coTransporte) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.operacion
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion
                .AddWithValue("@tipo", SqlDbType.Int).Value = obj.tipoestado
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
End Class
