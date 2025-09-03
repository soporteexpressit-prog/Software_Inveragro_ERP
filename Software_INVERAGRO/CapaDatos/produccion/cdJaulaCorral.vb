Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdJaulaCorral
    Private con As New cdConexion

    Public Function Cd_Mantenimiento(name As String, obj As coJaulaCorral) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion
                .AddWithValue("@capacidad", SqlDbType.Int).Value = obj.Capacidad
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
                .AddWithValue("@idGalpon", SqlDbType.Int).Value = obj.IdGalpon
                .AddWithValue("@idSala", SqlDbType.Int).Value = obj.IdSala
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .AddWithValue("@largo", SqlDbType.Decimal).Value = obj.Largo
                .AddWithValue("@ancho", SqlDbType.Decimal).Value = obj.Ancho
                .AddWithValue("@abreviatura", SqlDbType.VarChar).Value = obj.Abreviatura
                .AddWithValue("@esClinica", SqlDbType.VarChar).Value = obj.EsClinica
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

    Public Function Cd_Consultar(name As String, obj As coJaulaCorral) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@descripcion", obj.Descripcion)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.Tipo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarDisponible(name As String, obj As coJaulaCorral) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@descripcion", obj.Descripcion)
            da.SelectCommand.Parameters.AddWithValue("@idGalpon", obj.IdGalpon)
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.Tipo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarxId(name As String, obj As coJaulaCorral) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idJaulaCorral", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarJaulaCorralxUbicacionTipo(name As String, obj As coJaulaCorral) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.Tipo)
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarJaulaCorralxArea(name As String, obj As coJaulaCorral) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.Tipo)
            da.SelectCommand.Parameters.AddWithValue("@idArea", obj.IdArea)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ListarCorralesPorUbicacion(name As String, obj As coJaulaCorral) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarAnimalesCroquis(name As String, obj As coJaulaCorral) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarJaulasCorralesPorGalpon(name As String, obj As coJaulaCorral) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idGalpon", obj.IdGalpon)
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.Tipo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_RegistrarJaulaPorCantidad(name As String, obj As coJaulaCorral) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@cantidad", SqlDbType.Int).Value = obj.Cantidad
                .AddWithValue("@capacidad", SqlDbType.Int).Value = obj.Capacidad
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
                .AddWithValue("@idGalpon", SqlDbType.Int).Value = obj.IdGalpon
                .AddWithValue("@idSala", SqlDbType.Int).Value = obj.IdSala
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
