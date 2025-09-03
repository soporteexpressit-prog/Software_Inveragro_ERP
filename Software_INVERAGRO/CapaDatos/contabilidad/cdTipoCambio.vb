Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdTipoCambio
    Private con As New cdConexion

    Public Function Cd_Mantenimiento(name As String, obj As coTipoCambio) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@fecha", SqlDbType.Date).Value = obj.Fecha
                .AddWithValue("@precioCompra", SqlDbType.Money).Value = obj.PrecioCompra
                .AddWithValue("@precioVenta", SqlDbType.Money).Value = obj.PrecioVenta
                .AddWithValue("@idMoneda", SqlDbType.Int).Value = obj.IdMoneda
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

    Public Function Cd_Consultar(name As String, obj As coTipoCambio) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fecha", If(obj.Fecha.HasValue, CType(obj.Fecha.Value, Object), DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@idMoneda", If(obj.IdMoneda.HasValue, CType(obj.IdMoneda.Value, Object), DBNull.Value))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
End Class
