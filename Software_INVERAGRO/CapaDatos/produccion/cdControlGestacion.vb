Imports CapaObjetos
Imports System.Data.SqlClient

Public Class cdControlGestacion
    Private con As New cdConexion

    Public Function Cd_RegistrarInseminacion(name As String, obj As coControlGestacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@idControlServicio", SqlDbType.Int).Value = obj.IdControlFicha
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idCerda", SqlDbType.Int).Value = obj.IdCerda
                .AddWithValue("@condCorporal", SqlDbType.Decimal).Value = obj.CodCorporal
                .AddWithValue("@listaServicios", SqlDbType.VarChar).Value = obj.ListaServicios
                .AddWithValue("@peso", SqlDbType.Decimal).Value = obj.Peso
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

    Public Function Cd_Consultar(name As String, obj As coControlGestacion) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarPerdidaReproductiva(name As String, obj As coControlGestacion) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarInseminacionxIdCerda(name As String, obj As coControlGestacion) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idDetInseminacion", obj.IdDetalleInseminacion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_EditarInseminacion(name As String, obj As coControlGestacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@cantExpulsada", SqlDbType.Int).Value = obj.CantidadExpulsada
                .AddWithValue("@numDosis", SqlDbType.Int).Value = obj.NumDosis
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idCerda", SqlDbType.Int).Value = obj.IdCerda
                .AddWithValue("@idMaterialGeneticoRemplazo", SqlDbType.Int).Value = obj.IdMaterialGenetico
                .AddWithValue("@idDetalleInseminacion", SqlDbType.Int).Value = obj.IdDetalleInseminacion
                .AddWithValue("@fMonta", SqlDbType.DateTime).Value = obj.FechaMonta
                .AddWithValue("@condCorporal", SqlDbType.Decimal).Value = obj.CodCorporal
                .AddWithValue("@via", SqlDbType.VarChar).Value = obj.ViaAplicacion
                .AddWithValue("@idPersona", SqlDbType.Int).Value = obj.IdPersona
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

    Public Function Cd_ConsultarInseminacionxIdServicio(name As String, obj As coControlGestacion) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idControlFicha", obj.IdControlFicha)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function
End Class
