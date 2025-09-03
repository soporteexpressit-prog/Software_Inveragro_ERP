Imports CapaObjetos
Imports System.Data.SqlClient

Public Class cdControlDespacho
    Private con As New cdConexion

    Public Function Cd_ConsultarRacionPreparadaCerdo(name As String, obj As coControlDespacho) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", If(obj.FechaDesde, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", If(obj.FechaHasta, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@estadoPreparacion", obj.EstadoPreparacion)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarRacionPreparadaCerdoxId(name As String, obj As coControlDespacho) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idSalida", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_RegistrarEnvioAlimentoPlantel(name As String, obj As coControlDespacho) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idResponsable", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@idSalida", SqlDbType.Int).Value = obj.IdSalida
                .AddWithValue("@idUbicacionOrigen", SqlDbType.Int).Value = obj.IdUbicacionOrigen
                .AddWithValue("@idUbicacionDestino", SqlDbType.Int).Value = obj.IdUbicacionDestino
                .AddWithValue("@idTransporte", SqlDbType.Int).Value = obj.IdTransporte
                .AddWithValue("@idConductor", SqlDbType.Int).Value = obj.IdConductor
                .AddWithValue("@despachoCompleto", SqlDbType.Int).Value = obj.DespachoCompleto
                .AddWithValue("@listaDetalleRecepcion", SqlDbType.VarChar).Value = obj.ListaDetalleRecepcion
                .AddWithValue("@fechaDespacho", SqlDbType.Date).Value = obj.Fecha
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

    Public Function Cd_FinalizarRequerimientoAlimento(name As String, obj As coControlDespacho) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idSalida", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@idUserAnulacion", SqlDbType.Int).Value = obj.IdUserAnulacion
                .AddWithValue("@motivoAnulacion", SqlDbType.VarChar).Value = obj.MotivoAnulacion
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
End Class
