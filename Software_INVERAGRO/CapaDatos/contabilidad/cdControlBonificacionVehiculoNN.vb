Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdControlBonificacionVehiculoNN
    Private con As New cdConexion
    Public Function Cd_Registrar(name As String, obj As coControlBonificacionVehiculoNN) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@numPermiso", SqlDbType.VarChar).Value = obj.NumPermiso
                .AddWithValue("@numResolucion", SqlDbType.VarChar).Value = obj.NumResolucion
                .AddWithValue("@fResolucion", SqlDbType.Date).Value = obj.FechaResolucion
                .AddWithValue("@fInicio", SqlDbType.Date).Value = obj.FechaInicio
                .AddWithValue("@fFin", SqlDbType.Date).Value = obj.FechaFin
                If obj.PdfResolucion IsNot Nothing Then
                    .Add("@pdfResolucion", SqlDbType.VarBinary).Value = obj.PdfResolucion
                Else
                    .Add("@pdfResolucion", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .AddWithValue("@numExpediente", SqlDbType.VarChar).Value = obj.NumExpediente
                .AddWithValue("@fAperturaExp", SqlDbType.Date).Value = obj.FechaApertura
                If obj.PdfExpediente IsNot Nothing Then
                    .Add("@pdfExpediente", SqlDbType.VarBinary).Value = obj.PdfExpediente
                Else
                    .Add("@pdfExpediente", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@idActivo", SqlDbType.Int).Value = obj.IdActivo
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

    Public Function Cd_Consultar(name As String, obj As coControlBonificacionVehiculoNN) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", If(obj.FechaDesde.HasValue, obj.FechaDesde.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", If(obj.FechaHasta.HasValue, obj.FechaHasta.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@numPermiso", obj.NumPermiso)
            da.SelectCommand.Parameters.AddWithValue("@numResolucion", obj.NumResolucion)
            da.SelectCommand.Parameters.AddWithValue("@placa", obj.Placa)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_AnularBonificacionVehiculoNN(name As String, obj As coControlBonificacionVehiculoNN) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idBonSuspencion", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@motivoAnulacion", SqlDbType.VarChar).Value = obj.MotivoAnulacion
                .AddWithValue("@idUserAnulacion", SqlDbType.Int).Value = obj.IdUsuarioAnulacion
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
End Class
