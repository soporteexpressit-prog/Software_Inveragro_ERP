Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdIngreso
    Private con As New cdConexion
    Public Function Cd_Mantenimiento(name As String, obj As coIngreso) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@serie", SqlDbType.VarChar).Value = obj.Serie
                .AddWithValue("@correlativo", SqlDbType.VarChar).Value = obj.Correlativo
                .AddWithValue("@fEmision", SqlDbType.Date).Value = obj.FEmision
                .AddWithValue("@fpedido", SqlDbType.Date).Value = obj.Fpedido
                .AddWithValue("@total", SqlDbType.Money).Value = obj.Total
                .AddWithValue("@igv", SqlDbType.Money).Value = obj.Igv
                .AddWithValue("@flete", SqlDbType.Money).Value = obj.Flete
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@idCondicionpago", SqlDbType.Int).Value = obj.IdCondicionpago
                .AddWithValue("@idMotivoTransaccion", SqlDbType.Int).Value = obj.IdMotivoTransaccion
                .AddWithValue("@frecepcion", SqlDbType.Date).Value = If(obj.Frecepcion IsNot Nothing, obj.Frecepcion, DBNull.Value)
                .AddWithValue("@idubicacion_origen", SqlDbType.Int).Value = If(obj.IdUbicacionOrigen IsNot Nothing, obj.IdUbicacionOrigen, DBNull.Value)
                .AddWithValue("@idubicacion_destino", SqlDbType.Int).Value = If(obj.IdUbicacionDestino IsNot Nothing, obj.IdUbicacionDestino, DBNull.Value)
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .AddWithValue("@idtipodocumento", SqlDbType.Int).Value = obj.Idtipodocumento
                .AddWithValue("@idmoneda", SqlDbType.Int).Value = obj.Idmoneda
                .AddWithValue("@tipocambio", SqlDbType.Money).Value = obj.Tipocambio
                .AddWithValue("@idcotizacion", SqlDbType.Int).Value = obj.Idcotizacion
                .AddWithValue("@idproveedor", SqlDbType.Int).Value = obj.Idproveedor
                .AddWithValue("@recepcion", SqlDbType.VarChar).Value = obj.EstadoRecepcion
                .AddWithValue("@listafacturas", SqlDbType.VarChar).Value = obj.listafacturas
                .AddWithValue("@conigv", If(String.IsNullOrEmpty(obj.Conigv), DBNull.Value, obj.Conigv))
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


    Public Function Cd_Mantenimientoregistrarorden(name As String, obj As coIngreso) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@total", SqlDbType.Money).Value = obj.Total
                .AddWithValue("@igv", SqlDbType.Money).Value = obj.Igv
                .AddWithValue("@flete", SqlDbType.Money).Value = obj.Flete
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@idCondicionpago", SqlDbType.Int).Value = obj.IdCondicionpago
                .AddWithValue("@frecepcion", SqlDbType.Date).Value = If(obj.Frecepcion IsNot Nothing, obj.Frecepcion, DBNull.Value)
                .AddWithValue("@idubicacion_origen", SqlDbType.Int).Value = If(obj.IdUbicacionOrigen IsNot Nothing, obj.IdUbicacionOrigen, DBNull.Value)
                .AddWithValue("@idubicacion_destino", SqlDbType.Int).Value = If(obj.IdUbicacionDestino IsNot Nothing, obj.IdUbicacionDestino, DBNull.Value)
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .AddWithValue("@idtipodocumento", SqlDbType.Int).Value = obj.Idtipodocumento
                .AddWithValue("@idmoneda", SqlDbType.Int).Value = obj.Idmoneda
                .AddWithValue("@tipocambio", SqlDbType.Money).Value = obj.Tipocambio
                .AddWithValue("@idcotizacion", SqlDbType.Int).Value = obj.Idcotizacion
                .AddWithValue("@idproveedor", SqlDbType.Int).Value = obj.Idproveedor
                .AddWithValue("@recepcion", SqlDbType.VarChar).Value = obj.EstadoRecepcion
                .AddWithValue("@listafacturas", SqlDbType.VarChar).Value = obj.listafacturas
                .AddWithValue("@conigv", If(String.IsNullOrEmpty(obj.Conigv), DBNull.Value, obj.Conigv))
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
    Public Function Cd_RegOrdenCompra(name As String, obj As coIngreso) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@serie", SqlDbType.VarChar).Value = obj.Serie
                .AddWithValue("@correlativo", SqlDbType.VarChar).Value = obj.Correlativo
                .AddWithValue("@fEmision", SqlDbType.Date).Value = obj.FEmision
                .AddWithValue("@fpedido", SqlDbType.Date).Value = obj.Fpedido
                .AddWithValue("@total", SqlDbType.Money).Value = obj.Total
                .AddWithValue("@igv", SqlDbType.Money).Value = obj.Igv
                .AddWithValue("@flete", SqlDbType.Money).Value = obj.Flete
                .AddWithValue("@fleteinterno", SqlDbType.Money).Value = obj.Fleteinterno
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@idCondicionpago", SqlDbType.Int).Value = obj.IdCondicionpago
                .AddWithValue("@idMotivoTransaccion", SqlDbType.Int).Value = obj.IdMotivoTransaccion
                .AddWithValue("@frecepcion", SqlDbType.Date).Value = If(obj.Frecepcion IsNot Nothing, obj.Frecepcion, DBNull.Value)
                .AddWithValue("@idubicacion_origen", SqlDbType.Int).Value = If(obj.IdUbicacionOrigen IsNot Nothing, obj.IdUbicacionOrigen, DBNull.Value)
                .AddWithValue("@idubicacion_destino", SqlDbType.Int).Value = If(obj.IdUbicacionDestino IsNot Nothing, obj.IdUbicacionDestino, DBNull.Value)
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .AddWithValue("@idtipodocumento", SqlDbType.Int).Value = obj.Idtipodocumento
                .AddWithValue("@idmoneda", SqlDbType.Int).Value = obj.Idmoneda
                .AddWithValue("@tipocambio", SqlDbType.Money).Value = obj.Tipocambio
                .AddWithValue("@idcotizacion", SqlDbType.Int).Value = obj.Idcotizacion
                .AddWithValue("@idproveedor", SqlDbType.Int).Value = obj.Idproveedor
                .AddWithValue("@recepcion", SqlDbType.VarChar).Value = obj.EstadoRecepcion
                .AddWithValue("@pagoanticipado", SqlDbType.VarChar).Value = obj.pagoanticipado
                .AddWithValue("@conigv", If(String.IsNullOrEmpty(obj.Conigv), DBNull.Value, obj.Conigv))
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
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
    Public Function Cd_RegPedidoUsuario(name As String, obj As coIngreso) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@fpedido", SqlDbType.Date).Value = obj.Fpedido
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@idubicacion_origen", SqlDbType.Int).Value = If(obj.IdUbicacionOrigen IsNot Nothing, obj.IdUbicacionOrigen, DBNull.Value)
                .AddWithValue("@idubicacion_destino", SqlDbType.Int).Value = If(obj.IdUbicacionDestino IsNot Nothing, obj.IdUbicacionDestino, DBNull.Value)
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .AddWithValue("@idproveedor", SqlDbType.Int).Value = obj.Idproveedor
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
    Public Function ListarTablasMaestras(name As String) As DataSet
        Dim dt As New DataSet
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
    Public Function ListarTipoDocumento(name As String) As DataTable
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
    Public Function Consultar(name As String, ByRef obj As coIngreso) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fechadesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fechahasta)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.SelectCommand.Parameters.AddWithValue("@idtipodoc", obj.Idtipodocumento)
            da.SelectCommand.Parameters.AddWithValue("@nombreProducto", obj.NombreProducto)
            da.SelectCommand.Parameters.AddWithValue("@nombreProveedor", obj.NombreProveedor)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Consultarxproductoordencompra(name As String, ByRef obj As coIngreso) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fechadesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fechahasta)
            da.SelectCommand.Parameters.AddWithValue("@idproducto", obj.Idproveedor)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function ConsultarInventario(name As String, ByRef obj As coIngreso) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fechadesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fechahasta)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ConsultarDetallexCodigo(name As String, ByRef obj As coIngreso) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@codigo", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ConsultarOrdenCompraxCodigo(name As String, ByRef obj As coIngreso) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idingreso", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ConsultarPedidoxCodigo(name As String, ByRef obj As coIngreso) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idpedido", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_RecepcionProductos(name As String, obj As coIngreso) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codingreso", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@todo", SqlDbType.Int).Value = obj.Todo
                .AddWithValue("@lotizacion", SqlDbType.Int).Value = obj.lotizacion
                .AddWithValue("@fecharecepcion", SqlDbType.Date).Value = obj.FEmision
                .AddWithValue("@idusuario", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .AddWithValue("@lista_itemslotes", SqlDbType.VarChar).Value = obj.ListaItemslotes
                .AddWithValue("@numDocumento", SqlDbType.VarChar).Value = obj.NumDocumentoRecepcion
                .AddWithValue("@numguiatransportista", SqlDbType.VarChar).Value = obj.NumDocumentoRecepcion
                .AddWithValue("@valorServicio", SqlDbType.Int).Value = obj.valorServicio
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .Add("@msj", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output
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

    Public Function Cd_RecepcionRequerimientoProductos(name As String, obj As coIngreso) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codingreso", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@todo", SqlDbType.Int).Value = obj.Todo
                .AddWithValue("@fecharecepcion", SqlDbType.Date).Value = obj.FEmision
                .AddWithValue("@idusuario", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .Add("@msj", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output
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


    Public Function Cd_ObtenerArchivoCotizaciondeOrdenCompra(name As String, ByRef obj As coIngreso) As String
        Dim mensaje As String = String.Empty
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                ' Parámetro de entrada
                .AddWithValue("@idIngreso", SqlDbType.Int).Value = obj.Codigo

                ' Parámetro de salida para el archivo, especificando el tamaño (-1 para VARBINARY(MAX))
                .Add("@archivo", SqlDbType.VarBinary, -1).Direction = ParameterDirection.Output
            End With

            ' Ejecutar el procedimiento almacenado
            cmd.ExecuteNonQuery()

            ' Verificar si el valor de archivo es NULL o tiene contenido
            If IsDBNull(cmd.Parameters("@archivo").Value) Then
                obj.ArchivoRecepcion = Nothing
            Else
                obj.ArchivoRecepcion = CType(cmd.Parameters("@archivo").Value, Byte())
            End If

            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        Finally
            If con.con.State = ConnectionState.Open Then
                con.Salir()
            End If
        End Try
    End Function
    Public Function Cd_ActualizarArchivoCotizacionOrdenCompra(name As String, obj As coIngreso) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idingreso", SqlDbType.Int).Value = obj.Codigo
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
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
    Public Function Cd_AprobarFacturacionOrdenCompra(name As String, obj As coIngreso) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idingreso", SqlDbType.Int).Value = obj.Codigo
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
    Public Function Cd_crearsueldosbonificaciones(name As String, obj As coIngreso) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@ListaPersonasImportes", SqlDbType.VarChar).Value = obj.Lista_items
                .AddWithValue("@fechapago", SqlDbType.Date).Value = obj.Fechadesde
                .AddWithValue("@idUsuario", SqlDbType.Date).Value = obj.Iduser
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

    Public Function Cd_ConsultarRecepcionxCodigo(name As String, ByRef obj As coIngreso) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idIngreso", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ConsultarAtencionesOrdenesCompra(name As String, ByRef obj As coIngreso) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idDetallePedidoUsuario", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_obtenerArchivo(name As String, idRecepcion As Integer) As Byte()
        Dim pdfData As Byte() = Nothing
        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idRecepcion", idRecepcion)

            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                If Not reader.IsDBNull(0) Then
                    pdfData = DirectCast(reader(0), Byte())
                End If
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try

        Return pdfData
    End Function
    Public Function Cd_AnularOrdenCompra(name As String, obj As coIngreso) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@motivo", SqlDbType.VarChar).Value = obj.Motivoanulacion
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Iduser
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

    Public Function Cd_ConsultarRecepcionProductos(name As String, obj As coIngreso) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@FechaDesde", If(obj.Fechadesde.HasValue, obj.Fechadesde.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@FechaHasta", If(obj.Fechahasta.HasValue, obj.Fechahasta.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@MontoMinimo", If(obj.MontoMinimo.HasValue, obj.MontoMinimo.Value, DBNull.Value))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function ReporteGuiaTrasladoxCodigo(name As String, ByRef obj As coIngreso) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idguia", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ValidarPedido(name As String, obj As coIngreso) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Iduser
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

    Public Function ConsultarSemenPorcino(name As String, ByRef obj As coIngreso) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fechadesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fechahasta)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_EnviarCorreoOrdenCompra(name As String, obj As coIngreso) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idIngreso", SqlDbType.Int).Value = obj.Codigo
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

    Public Function Cd_ReporteFacturasVinculadas(name As String, obj As coIngreso) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idOrdenCompra", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ReportePagosGratificacion(name As String, obj As coIngreso) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@ffin", obj.Fechadesde)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
End Class
