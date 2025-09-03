Imports CapaObjetos
Imports System.Data.SqlClient

Public Class cdControlDespachoCerdoVenta
    Dim con As New cdConexion

    Public Function ConsultarPedidoVentaCerdo(name As String, ByRef obj As coControlDespachoCerdoVenta) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.SelectCommand.Parameters.AddWithValue("@nombreProveedor", obj.NombreProveedor)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarxIdUbicacion(name As String, obj As coControlDespachoCerdoVenta) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_RegistrarPedidoCerdoAtendido(name As String, obj As coControlDespachoCerdoVenta) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@fControl", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@idSalida", SqlDbType.Int).Value = obj.IdSalida
                .AddWithValue("@pesoPromedio", SqlDbType.Date).Value = obj.PesoPromedio
                .AddWithValue("@observacion", SqlDbType.Date).Value = obj.Observacion
                .AddWithValue("@listaCerdosPeso", SqlDbType.Decimal).Value = obj.ListaCerdosPeso
                .AddWithValue("@cantidadCerdos", SqlDbType.Int).Value = obj.CantidadCerdos
                .AddWithValue("@idProducto", SqlDbType.Int).Value = obj.IdRacion
                .AddWithValue("@cantSacosDespachados", SqlDbType.Int).Value = obj.NumSacosDespachados
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
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

    Public Function Cd_RegistrarPedidoCerdoAtendidoCod(name As String, obj As coControlDespachoCerdoVenta) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@fControl", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@idSalida", SqlDbType.Int).Value = obj.IdSalida
                .AddWithValue("@pesoPromedio", SqlDbType.Date).Value = obj.PesoPromedio
                .AddWithValue("@observacion", SqlDbType.Date).Value = obj.Observacion
                .AddWithValue("@listaCerdosPeso", SqlDbType.Decimal).Value = obj.ListaCerdosPeso
                .AddWithValue("@idMotivoTransaccion", SqlDbType.VarChar).Value = obj.IdMotivoTransaccion
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@pesoBruto", SqlDbType.Decimal).Value = obj.PesoBruto
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

    Public Function Cd_CancelarPedidoCerdoAtendido(name As String, obj As coControlDespachoCerdoVenta) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idSalida", SqlDbType.Int).Value = obj.IdSalida
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
