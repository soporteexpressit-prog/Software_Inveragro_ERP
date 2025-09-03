Imports CapaObjetos
Imports System.Data.SqlClient

Public Class cdMedicamentoRacion
    Private con As New cdConexion

    Public Function Cd_RegistrarPeriodoMedicamentoRacion(name As String, obj As coMedicamentoRacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@fInicio", SqlDbType.Date).Value = obj.FechaInicio
                .AddWithValue("@fFin", SqlDbType.Date).Value = obj.FechaFin
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
                .AddWithValue("@idRacion", SqlDbType.Int).Value = obj.IdRacion
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@lista_medicamentos", SqlDbType.VarChar).Value = obj.ListaMedicamentos
                .AddWithValue("@tipoPremixero", SqlDbType.VarChar).Value = obj.TipoPremixero
                .AddWithValue("@incluirEnNucleo", SqlDbType.VarChar).Value = obj.IncluirEnNucleo
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .AddWithValue("@nota", SqlDbType.VarChar).Value = obj.Nota
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

    Public Function Cd_ConsultarPeriodoMedicamentoRacion(name As String, obj As coMedicamentoRacion) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", If(obj.FechaInicio.HasValue, obj.FechaInicio.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", If(obj.FechaFin.HasValue, obj.FechaFin.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ActualizarFechaFinPeriodoMedicamentoRacion(name As String, obj As coMedicamentoRacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idPeriodoMedicacion", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@nuevaFechaFin", SqlDbType.Date).Value = obj.FechaFin
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

    Public Function Cd_CancelarPeriodoMedicamentoRacion(name As String, obj As coMedicamentoRacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idPeriodoMedicacion", SqlDbType.Int).Value = obj.Codigo
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
