Imports CapaObjetos
Imports System.Data.SqlClient

Public Class cdControlMaterialGenetico
    Private con As New cdConexion

    Public Function Cd_Mantenimiento(name As String, obj As coControlMaterialGenetico) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@fExtraccion", SqlDbType.Date).Value = obj.FechaExtraccion
                .AddWithValue("@fProcesamiento", SqlDbType.Date).Value = obj.FechaProcesamiento
                .AddWithValue("@volSemen", SqlDbType.Decimal).Value = obj.Volumen
                .AddWithValue("@motilidadPura", SqlDbType.Decimal).Value = obj.MotilidadPura
                .AddWithValue("@motilidadDiluida", SqlDbType.Decimal).Value = obj.MotilidadDiluida
                .AddWithValue("@dosis", SqlDbType.Int).Value = obj.Dosis
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idVerraco", SqlDbType.Int).Value = If(obj.IdVerraco.HasValue, obj.IdVerraco, DBNull.Value)
                .AddWithValue("@idUbicacionOrigen", SqlDbType.Int).Value = obj.IdUbicacionOrigen
                .AddWithValue("@idUbicacionDestino", SqlDbType.Int).Value = obj.IdUbicacionDestino
                .AddWithValue("@idPersona", SqlDbType.Int).Value = obj.IdEncargado
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .AddWithValue("@idProducto", SqlDbType.Int).Value = obj.IdProducto
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@codSemenCompra", SqlDbType.VarChar).Value = obj.CodSemenCompra
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

    Public Function Cd_Consultar(name As String, obj As coControlMaterialGenetico) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.Tipo)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacionOrigen)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarxIdVerraco(name As String, obj As coControlMaterialGenetico) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idVerraco", obj.IdVerraco)
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarxUbicacionDestino(name As String, obj As coControlMaterialGenetico) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacionDestino)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_RegistrarPedidoSemenCerdoProveedor(name As String, obj As coControlMaterialGenetico) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@fControl", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idUbicacionOrigen", SqlDbType.Int).Value = obj.IdAlmacenPrincipal
                .AddWithValue("@idUbicacionDestino", SqlDbType.Int).Value = obj.IdAlmacenSolicitante
                .AddWithValue("@listaItemsProductos", SqlDbType.VarChar).Value = obj.ListaProductos
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

    Public Function Cd_DescartarMaterialGenetico(name As String, obj As coControlMaterialGenetico) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idMaterialGenetico", SqlDbType.Int).Value = obj.Codigo
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

    Public Function Cd_ActualizarMotilidadDiluMaterialGenetico(name As String, obj As coControlMaterialGenetico) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idMaterialGenetico", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@motilidadDiluida", SqlDbType.Int).Value = obj.MotilidadDiluida
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

    Public Function Cd_ParticionDosisMaterialGenetico(name As String, obj As coControlMaterialGenetico) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idMaterialGenetico", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@dosis", SqlDbType.Int).Value = obj.Dosis
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
End Class
