Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdUbicacion
    Private con As New cdConexion

    Public Function Cd_Mantenimiento(name As String, obj As coUbicacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@densidad", SqlDbType.Int).Value = obj.Densidad
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

    Public Function Cd_MantenimientoPlanteles(name As String, obj As coUbicacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@densidad", SqlDbType.Int).Value = obj.Densidad
                .AddWithValue("@numChachillas", SqlDbType.Int).Value = obj.NumChanchillas
                .AddWithValue("@direccion", SqlDbType.VarChar).Value = obj.Direccion
                .AddWithValue("@clasificacion", SqlDbType.VarChar).Value = obj.Clasificacion
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

    Public Function Cd_ConsultarxId(name As String, obj As coUbicacion) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_Consultar(name As String, obj As coUbicacion) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@descripcion", If(String.IsNullOrEmpty(obj.Descripcion), DBNull.Value, obj.Descripcion))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ListarPlanteles(name As String) As DataTable
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

    Public Function Cd_ConsultarPlantelAlmacen(name As String, flag As Integer) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@flag", flag)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_MantenimientoAlcance1(name As String, obj As coUbicacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@Codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@Descripcion", SqlDbType.VarChar).Value = obj.Descripcion
                .Add("@msj", SqlDbType.VarChar, 150).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
                .Add("@codreturn", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.Coderror = cmd.Parameters("@coderror").Value.ToString
            obj.Codreturn = cmd.Parameters("@codreturn").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function Cd_MantenimientoAlcance2(name As String, obj As coUbicacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@Codalcance1", SqlDbType.Int).Value = obj.Codigo2
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@Descripcion", SqlDbType.VarChar).Value = obj.Descripcion
                .Add("@msj", SqlDbType.VarChar, 150).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
                .Add("@codreturn", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.Coderror = cmd.Parameters("@coderror").Value.ToString
            obj.Codreturn = cmd.Parameters("@codreturn").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_MantenimientoAlcance3(name As String, obj As coUbicacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@Codalcance2", SqlDbType.Int).Value = obj.Codigo2
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@Descripcion", SqlDbType.VarChar).Value = obj.Descripcion
                .Add("@msj", SqlDbType.VarChar, 150).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
                .Add("@codreturn", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.Coderror = cmd.Parameters("@coderror").Value.ToString
            obj.Codreturn = cmd.Parameters("@codreturn").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_ConsultarCentrodeCostos(name As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            'da.SelectCommand.Parameters.AddWithValue("@valor", obj.Descripcion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ConsultarNivel1(name As String, obj As coUbicacion) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@valor", obj.Descripcion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarNivel2(name As String, obj As coUbicacion) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@valor", obj.Descripcion)
            da.SelectCommand.Parameters.AddWithValue("@idalcance1", obj.Codigo2)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ConsultarNivel3(name As String, obj As coUbicacion) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@valor", obj.Descripcion)
            da.SelectCommand.Parameters.AddWithValue("@idalcance2", obj.Codigo2)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_AplicarDesidadPlantel(name As String, obj As coUbicacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@densidad", SqlDbType.Int).Value = obj.Densidad
                .AddWithValue("@numChanchillas", SqlDbType.Int).Value = obj.NumChanchillas
                .Add("@msj", SqlDbType.VarChar, 150).Direction = 2
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

    Public Function Cd_ListarCampañas(name As String, obj As coUbicacion) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.Codigo)
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.Anio)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
End Class
