Imports CapaObjetos
Imports System.Data.SqlClient

Public Class cdConfiguracion
    Private con As New cdConexion

    Public Function Cd_MantenimientoContenido(name As String, obj As coConfiguracion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.IdConfiguracion
                .AddWithValue("@texto", SqlDbType.VarChar).Value = obj.Texto
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

    Public Function Cd_ObtenerContenido(name As String, configuracionId As Integer) As String
        Dim rutaEvidencia As String = ""
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@codigo", configuracionId)
            End With

            Dim resultado As Object = cmd.ExecuteScalar()

            If resultado IsNot Nothing AndAlso Not IsDBNull(resultado) Then
                rutaEvidencia = Convert.ToString(resultado)
            End If

            con.Salir()
            Return rutaEvidencia
        Catch ex As Exception
            con.Salir()
            Throw ex
        End Try
    End Function

    Public Function Cd_MantenimientoLogo(name As String, obj As coConfiguracion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idCondiguracion", SqlDbType.Int).Value = obj.IdConfiguracion
                If obj.Imagen IsNot Nothing Then
                    .Add("@imagen", SqlDbType.VarBinary).Value = obj.Imagen
                Else
                    .Add("@imagen", SqlDbType.VarBinary).Value = DBNull.Value
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

    Public Function Cd_ObtenerLogo(name As String, configuracionId As Integer) As Byte()
        Dim logoBytes As Byte() = Nothing
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@idConfiguracion", configuracionId)
            End With

            Dim resultado As Object = cmd.ExecuteScalar()

            If resultado IsNot Nothing AndAlso Not IsDBNull(resultado) Then
                logoBytes = DirectCast(resultado, Byte())
            End If

            con.Salir()
            Return logoBytes
        Catch ex As Exception
            con.Salir()
            Throw ex
        End Try
    End Function

    Public Function Cd_ListarGeneral(name As String) As DataTable
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

    Public Function Cd_ActualizarParametroProduccion(name As String, obj As coConfiguracion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idmaestro", SqlDbType.Int).Value = obj.IdConfiguracion
                .AddWithValue("@valor", SqlDbType.VarChar).Value = obj.Valor
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
