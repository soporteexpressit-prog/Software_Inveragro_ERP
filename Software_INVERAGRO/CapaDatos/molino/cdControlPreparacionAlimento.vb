Imports CapaObjetos
Imports System.Data.SqlClient

Public Class cdControlPreparacionAlimento
    Private con As New cdConexion

    Public Function Cd_RegistrarSalidaInsumoYIngresoRecepcionAlimento(name As String, obj As coControlPreparacionAlimento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
                .AddWithValue("@listaInsumosPreparacion", SqlDbType.VarChar).Value = obj.ListaInsumoPreparacion
                .AddWithValue("@listaRaciones", SqlDbType.VarChar).Value = obj.ListaRaciones
                .AddWithValue("@listaIdsSalida", SqlDbType.VarChar).Value = obj.ListaIdsSalida
                .AddWithValue("@listaIdsDetalleSalida", SqlDbType.VarChar).Value = obj.ListaIdsDetalleSalida
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .AddWithValue("@fecha", SqlDbType.Date).Value = obj.Fecha
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

    Public Function Cd_RegistrarSalidaInsumosExcedente(name As String, obj As coControlPreparacionAlimento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idRacion", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@cantidadRacion", SqlDbType.Decimal).Value = obj.Cantidad
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
                .AddWithValue("@idPlantelDestino", SqlDbType.Int).Value = obj.IdUbicacionDestino
                .AddWithValue("@listaInsumosPreparacion", SqlDbType.VarChar).Value = obj.ListaInsumoPreparacion
                .AddWithValue("@fecha", SqlDbType.Date).Value = obj.Fecha
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.Tipo
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

    Public Function Cd_ConsultarAlimentoPreparado(name As String, obj As coControlPreparacionAlimento) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaInicio", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaFin", obj.FechaHasta)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ObtenerRecetaAlimentoPremixeroPorIdRacion(name As String, obj As coControlPreparacionAlimento) As Object
        Dim ds As New DataSet
        Dim mensaje As String
        Dim coderror As Integer
        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@idRacion", obj.Codigo)
            cmd.Parameters.AddWithValue("@listaIdsDetalleSalida", obj.ListaIdsDetalleSalida)
            cmd.Parameters.Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output

            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)

            mensaje = cmd.Parameters("@msj").Value.ToString()
            coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)

            If coderror <> 0 Then
                Return mensaje
            End If

        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return ds
    End Function
End Class
