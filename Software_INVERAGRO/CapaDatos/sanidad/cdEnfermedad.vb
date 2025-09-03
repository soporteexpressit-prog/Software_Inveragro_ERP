Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdEnfermedad
    Private con As New cdConexion

    Public Function Cd_Mantenimiento(name As String, obj As coEnfermedad) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@nombre", SqlDbType.Int).Value = obj.Nombre
                .AddWithValue("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion
                .AddWithValue("@tipoNivel", SqlDbType.VarChar).Value = obj.TipoNivel
                .AddWithValue("@viaAplicacion", SqlDbType.VarChar).Value = obj.ViaAplicacion
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Iduser
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

    Public Function Cd_ListarProductosMedicina(name As String) As DataTable
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

    Public Function Cd_Listar(name As String) As DataTable
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

    Public Function Cd_RegistrarDetalleTratamiento(name As String, obj As coEnfermedad) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@listaDetalleTratamiento", SqlDbType.Int).Value = obj.Lista_Detalle_Tratamiento
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.Iduser
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

    Public Function Cd_ConsultarDetalleTratamiento(name As String, obj As coEnfermedad) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@nombre", If(obj.Nombre Is Nothing, DBNull.Value, obj.Nombre))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ActualizarDetalleTratamiento(name As String, obj As coEnfermedad) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@edadLote", SqlDbType.Int).Value = obj.EdadLote
                .AddWithValue("@observacion", SqlDbType.Int).Value = obj.Observacion
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
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

    Public Function Cd_ConsultarMedicamentoRecomendadoPorEnfermedad(name As String, obj As coEnfermedad) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idEnfermedad", SqlDbType.Int).Value = obj.Codigo
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_EliminarEnfermedad(name As String, obj As coEnfermedad) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
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
