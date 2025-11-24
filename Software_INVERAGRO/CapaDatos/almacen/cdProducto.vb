Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports CapaObjetos

Public Class cdProducto
    Private con As New cdConexion
    Public Function Cd_Mantenimiento(name As String, obj As coProductos) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Idproducto
                .AddWithValue("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion
                .AddWithValue("@stockminimo", SqlDbType.Money).Value = obj.Stockminimo
                .AddWithValue("@idunidadmedida", SqlDbType.Int).Value = obj.IdUnidadMedida
                .AddWithValue("@lote", SqlDbType.Char).Value = obj.Lotes
                .AddWithValue("@afectoigv", SqlDbType.Char).Value = obj.AfectoIgv
                .AddWithValue("@estado", SqlDbType.Char).Value = obj.Estado
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@idmarca", SqlDbType.Int).Value = obj.Idmarca
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@codigobarras", SqlDbType.VarChar).Value = obj.Codigobarras
                .AddWithValue("@principio_activo", SqlDbType.VarChar).Value = obj.PrincioActivo
                .AddWithValue("@idpresentacion", SqlDbType.Int).Value = obj.Idpresentacion
                .AddWithValue("@uniporpresentacion", SqlDbType.Int).Value = obj.uniporpresentacion
                .AddWithValue("@equivalencia", SqlDbType.Money).Value = obj.Equivalencia
                .AddWithValue("@comprar", SqlDbType.VarChar).Value = obj.Comprar
                .AddWithValue("@vender", SqlDbType.VarChar).Value = obj.Vender
                .AddWithValue("@esmolino", SqlDbType.VarChar).Value = obj.esmolino
                .AddWithValue("@esRacionExterna", SqlDbType.Bit).Value = obj.EsRacionExterna
                .AddWithValue("@idProductoEquivalencia", SqlDbType.Int).Value = obj.IdProductoEquivalencia
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
    Public Function Cd_ListarStockAlmacenes(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@valor", obj.Descripcion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_Listar(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@valor", obj.Descripcion)
            da.SelectCommand.Parameters.AddWithValue("@codalmacen", obj.IdUbicacion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_Listarunidadmedidas(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@codigo", obj.Operacion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ListarDashboard(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            'da.SelectCommand.Parameters.AddWithValue("@valor", obj.Descripcion)
            'da.SelectCommand.Parameters.AddWithValue("@codalmacen", obj.IdUbicacion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ListarAlmacen(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idusuario", obj.IdUsuario)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ListarPlanteles(name As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            'da.SelectCommand.Parameters.AddWithValue("@idusuario", obj.IdUsuario)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ListarPedidosCerdosxGuia(name As String, idguia As Integer) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idguia", idguia)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ListarUnidadMedida(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@valor", If(String.IsNullOrEmpty(obj.Descripcion), DBNull.Value, obj.Descripcion))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ListarPresentaciones(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@valor", If(String.IsNullOrEmpty(obj.Descripcion), DBNull.Value, obj.Descripcion))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ListaMarcasxCategoria(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idcategoria", obj.IdCategoria)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ListarxCodigo(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idproducto", obj.Idproducto)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ListadoGeneral(name As String) As DataTable
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
    Public Function Cd_listado_epps(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@codalmacen", obj.IdUbicacion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ConsultarIngresoProductoPorId(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idProducto", obj.Idproducto)
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ConsultarKardexProductoPorId(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idProducto", obj.Idproducto)
            da.SelectCommand.Parameters.AddWithValue("@fechaInicio", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaFin", obj.FechaHasta)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ConsultarKardexProductoPorIdyUbicacion(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idProducto", obj.Idproducto)
            da.SelectCommand.Parameters.AddWithValue("@fechaInicio", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaFin", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ConsultarEstadoCuentaBancario(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idCtaBanco", obj.Idproducto)
            da.SelectCommand.Parameters.AddWithValue("@fechaInicio", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaFin", obj.FechaHasta)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ListarAlertas(name As String, obj As coProductos) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@codalmacen", obj.IdUbicacion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ListarMedicamentosActivos(name As String, ByVal idAlmacen As Integer) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idAlmacen", SqlDbType.Int).Value = idAlmacen
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarProductoSemenPorcino(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@codalmacen", obj.IdUbicacion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_RegistrarLotizarProductoFecVenc(name As String, obj As coProductos) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idProducto", SqlDbType.Int).Value = obj.Idproducto
                .AddWithValue("@idIngreso", SqlDbType.Int).Value = obj.IdIngreso
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
                .AddWithValue("@listaLotesProductos", SqlDbType.VarChar).Value = obj.ListaItems
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

    Public Function Cd_ListarLoteProducto(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idProducto", obj.Idproducto)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ReporteGastosVeterinarios(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ReporteGastosAsignaciones(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_RegistrarAsignacionMultipleUnidadesMedida(name As String, obj As coProductos) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@listaProductos", SqlDbType.VarChar).Value = obj.ListaItems
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

    Public Function Cd_eliminarUnidadesMedida(name As String, obj As coProductos) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.IdIngreso
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
    Public Function Cd_ListarUnidadesMedidaPorProducto(name As String, obj As coProductos) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idProducto", obj.Idproducto)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
End Class
