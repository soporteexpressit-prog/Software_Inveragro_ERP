Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdControlCombustible
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

    Public Function Cd_ListarTiposDocumento(name As String) As DataTable
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

    Public Function Cd_RegGrifo(name As String, obj As coControlCombustible) As String
        Dim mensaje As String
        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con)
            cmd.CommandType = 4
            With cmd.Parameters
                .AddWithValue("@fEmision", SqlDbType.Date).Value = obj.Fecha_Emision
                .AddWithValue("@estadoRecepcion", SqlDbType.Int).Value = obj.Estado_Recepcion
                .AddWithValue("@liquidado", SqlDbType.VarChar).Value = obj.Liquidado
                .AddWithValue("@idUser", SqlDbType.Int).Value = obj.IdUser
                .AddWithValue("@idTipoDocumento", SqlDbType.Int).Value = obj.IdTipoDocumento
                .AddWithValue("@idResponsable", SqlDbType.Int).Value = obj.IdResponsable
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_Items
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
