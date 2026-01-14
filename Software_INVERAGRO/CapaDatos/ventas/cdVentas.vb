Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdVentas
    Private con As New cdConexion

    Public Function Cd_RegPedidoVenta(name As String, obj As coVentas) As String
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
                .AddWithValue("@idguia", SqlDbType.Int).Value = obj.Idguia
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .AddWithValue("@tipoprecio", SqlDbType.VarChar).Value = obj.Tipoprecio
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

    Public Function Cd_Regasignacionrequerimiento(name As String, obj As coVentas) As String
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
                .AddWithValue("@idguia", SqlDbType.Int).Value = obj.Idguia
                .AddWithValue("@idarea", SqlDbType.Int).Value = obj.idarea
                .AddWithValue("@idgalpon", SqlDbType.Int).Value = obj.idgalpon
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .AddWithValue("@tipoprecio", SqlDbType.VarChar).Value = obj.Tipoprecio
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


    Public Function Cd_RegAjusteNegativoOrdenCompra(name As String, obj As coVentas) As String
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
                .AddWithValue("@idguia", SqlDbType.Int).Value = obj.Idguia
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .AddWithValue("@tipoprecio", SqlDbType.VarChar).Value = obj.Tipoprecio
                .AddWithValue("@idordencompra", SqlDbType.Int).Value = obj.Idordencompra
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


    Public Function Cd_Updateordencompra(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@total", SqlDbType.Money).Value = obj.Total
                .AddWithValue("@igv", SqlDbType.Money).Value = obj.Igv
                .AddWithValue("@flete", SqlDbType.Money).Value = obj.Flete
                .AddWithValue("@Fleteinterno", SqlDbType.Money).Value = obj.Fleteinterno
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .AddWithValue("@idordencompra", SqlDbType.Int).Value = obj.Idordencompra
                .AddWithValue("@idmoneda", SqlDbType.Int).Value = obj.Idmoneda
                .AddWithValue("@tipocambio", SqlDbType.Money).Value = obj.Tipocambio
                .AddWithValue("@conigv", SqlDbType.VarChar).Value = obj.conigv
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


    Public Function Cd_imprimir_reporte_venta(name As String, obj As coVentas) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idSalida", obj.Idcotizacion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarxCodigo(name As String, obj As coVentas) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idguia", SqlDbType.Int).Value = obj.Codigo
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarxCodigovendedorcliente(name As String, obj As coVentas) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@iduser", SqlDbType.Int).Value = obj.Iduser
            da.SelectCommand.Parameters.AddWithValue("@idproducto", SqlDbType.Int).Value = obj.Idproducto
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_actualizarregistroguiapdf(name As String, obj As coVentas) As String
        Dim mensaje As String = ""
        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con) ' Asignar conexión y procedimiento
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idguia", obj.Codigo)
            cmd.Parameters.AddWithValue("@horometroinicial", obj.Horometro_incial)
            cmd.Parameters.AddWithValue("@odometro_inicial", obj.odometro_inicial)
            cmd.Parameters.Add("@fechadesde", SqlDbType.Date).Value =
    If(obj.Fechadesde = Date.MinValue, DBNull.Value, obj.Fechadesde)
            cmd.Parameters.Add("@fechahasta", SqlDbType.Date).Value =
    If(obj.Fechahasta = Date.MinValue, DBNull.Value, obj.Fechahasta)
            If obj.ArchivoRecepcion IsNot Nothing Then
                cmd.Parameters.Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
            Else
                cmd.Parameters.Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
            End If
            cmd.Parameters.Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()

            ' Obtener valores de salida
            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)

        Catch ex As Exception
            Throw ex
        Finally
            con.Salir() ' Asegurar cierre de conexión
        End Try

        Return mensaje
    End Function

    Public Function Cd_RegPedidoVentaProductos(name As String, obj As coVentas) As String
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
                .AddWithValue("@idguia", SqlDbType.Int).Value = obj.Idguia
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .AddWithValue("@tipoprecio", SqlDbType.VarChar).Value = obj.Tipoprecio
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
    Public Function Cd_RegPedidoVentaCerdo(name As String, obj As coVentas) As String
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
                .AddWithValue("@idguia", SqlDbType.Int).Value = obj.Idguia
                .AddWithValue("@entregadirecta", SqlDbType.Int).Value = obj.entregadirecta
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .AddWithValue("@tipoprecio", SqlDbType.VarChar).Value = obj.Tipoprecio
                .AddWithValue("@idplantel", SqlDbType.Int).Value = obj.Idplantel
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
    Public Function Cd_RegPedidoVentaCerdoupdatefecha(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@fpedido", SqlDbType.Date).Value = obj.Fpedido
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
    Public Function Cd_RegPedidoVentaCerdoupdate(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@fdespacho", SqlDbType.Date).Value = obj.Frecepcion
                .AddWithValue("@fpedido", SqlDbType.Date).Value = obj.Fpedido
                .AddWithValue("@idCondicionpago", SqlDbType.Int).Value = obj.IdCondicionpago
                .AddWithValue("@Idproveedor", SqlDbType.Int).Value = obj.Idproveedor
                .AddWithValue("@Cantidadcerdos", SqlDbType.Int).Value = obj.Cantidad
                .AddWithValue("@Cantidadsacos", SqlDbType.Int).Value = obj.Cantidadsacos
                .AddWithValue("@Observacion", SqlDbType.Int).Value = obj.Observacion
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
    Public Function Cd_RegPedidoVentaCerdoxConductor(name As String, obj As coVentas) As String
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
                .AddWithValue("@idguia", SqlDbType.Int).Value = obj.Idguia
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .AddWithValue("@tipoprecio", SqlDbType.VarChar).Value = obj.Tipoprecio
                .AddWithValue("@idplantel", SqlDbType.Int).Value = obj.Idplantel
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
    Public Function Cd_RegAjustenegativoventa(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idsalida", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@idproducto", SqlDbType.Int).Value = obj.Idproducto
                .AddWithValue("@cantidad_descuento", SqlDbType.Int).Value = obj.Cantidad
                .AddWithValue("@idusuario", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@Idproveedor", SqlDbType.Int).Value = obj.Idproveedor
                .AddWithValue("@motivo", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@idMotivoTransaccion", SqlDbType.Int).Value = obj.IdMotivoTransaccion
                .AddWithValue("@precio", SqlDbType.Money).Value = obj.Precio
                .AddWithValue("@fRecepcion", SqlDbType.Date).Value = If(obj.Frecepcion IsNot Nothing, obj.Frecepcion, DBNull.Value)
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
    Public Function Cd_RegAjustepositivoventa(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@idsalida", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@idproducto", SqlDbType.Int).Value = obj.Idproducto
                .AddWithValue("@cantidad", SqlDbType.Int).Value = obj.Cantidad
                .AddWithValue("@idusuario", SqlDbType.Int).Value = obj.Iduser
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

    Public Function Cd_Regactualizacionvendedor(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@idsalida", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@idusuario", SqlDbType.Int).Value = obj.Iduser
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


    Public Function Cd_Regactualizaciontipopeso(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@idsalida", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@idusuario", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@Valor", SqlDbType.VarChar).Value = obj.Observacion
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

    Public Function Cd_Reganulacionajuste(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@idsalida", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@idproducto", SqlDbType.Int).Value = obj.Idproducto
                .AddWithValue("@idMotivoTransaccion", SqlDbType.Int).Value = obj.IdMotivoTransaccion
                .AddWithValue("@observacion", SqlDbType.Int).Value = obj.Observacion
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
    Public Function Cd_RegPedidoVentaxKilos(name As String, obj As coVentas) As String
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
                .AddWithValue("@idguia", SqlDbType.Int).Value = obj.Idguia
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .AddWithValue("@tipoprecio", SqlDbType.VarChar).Value = obj.Tipoprecio
                .AddWithValue("@idplantel", SqlDbType.Int).Value = obj.Idplantel
                .AddWithValue("@precio", SqlDbType.Money).Value = obj.Precio
                .AddWithValue("@cantidad", SqlDbType.Money).Value = obj.Cantidad
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

    Public Function Cd_RegPedidoVentaDirecta(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@fEmision", SqlDbType.Date).Value = obj.FEmision
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .AddWithValue("@idcliente", SqlDbType.Int).Value = obj.Idproveedor
                .AddWithValue("@idguia", SqlDbType.Int).Value = obj.Idguia
                .AddWithValue("@idalmacenorigen", SqlDbType.Int).Value = obj.IdUbicacionOrigen
                .AddWithValue("@idtipoventa", SqlDbType.Int).Value = obj.IdMotivoTransaccion
                .Add("@msj", SqlDbType.VarChar, 400).Direction = ParameterDirection.Output
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
    Public Function Cd_RegAjustexIrrecuperable(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@fEmision", SqlDbType.Date).Value = obj.FEmision
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .AddWithValue("@idguia", SqlDbType.Int).Value = obj.Idguia
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
    Public Function Cd_RegPedidoRequerimiento(name As String, obj As coVentas) As String
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
                .AddWithValue("@idguia", SqlDbType.Int).Value = obj.Idguia
                .AddWithValue("@checkcampaña", SqlDbType.Int).Value = obj.checkcampaña
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
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
    Public Function Cd_ValidarRequerimiento(name As String, obj As coVentas) As String
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
    Public Function Cd_EliminarDetalleRequerimiento(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idproducto", SqlDbType.Int).Value = obj.Idproducto
                .AddWithValue("@idsalida", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@cantidad", SqlDbType.Money).Value = obj.Cantidad
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
    Public Function ListarAreasGalpones(name As String, obj As coVentas) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idubicacion", obj.IdUbicacionOrigen)
            da.SelectCommand.Parameters.AddWithValue("@estadocheck", obj.checkselecionado)
            da.SelectCommand.Parameters.AddWithValue("@idgalpon", obj.idgalpon)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ListarVendedores(name As String, obj As coProductos) As DataTable
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
    Public Function ListarDestinoScti(name As String) As DataTable
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
    Public Function Consultar(name As String, ByRef obj As coVentas) As DataSet
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
    Public Function ConsultarTransferencia(name As String, ByRef obj As coVentas) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fechadesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fechahasta)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.SelectCommand.Parameters.AddWithValue("@nombreProveedor", obj.NombreProveedor)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ConsultarPedidoVentaCerdo(name As String, ByRef obj As coVentas) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fechadesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fechahasta)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.SelectCommand.Parameters.AddWithValue("@nombreProveedor", obj.NombreProveedor)
            da.SelectCommand.Parameters.AddWithValue("@iduser", obj.Iduser)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function


    Public Function ConsultarGuiasTraslado(name As String, ByRef obj As coVentas) As DataSet
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
    Public Function VerGuiasTraslado(name As String, ByRef obj As coVentas) As DataSet
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
    Public Function ConsultarVentasAnexadasaPedidoVentas(name As String, ByRef obj As coVentas) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idsalida", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ConsultarAtencionesRequerimiento(name As String, ByRef obj As coVentas) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fechadesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fechahasta)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.SelectCommand.Parameters.AddWithValue("@nombreProducto", obj.NombreProducto)
            da.SelectCommand.Parameters.AddWithValue("@iduser", obj.Iduser)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ConsultarSolicitudesRequerimiento(name As String, ByRef obj As coVentas) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fechadesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fechahasta)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.SelectCommand.Parameters.AddWithValue("@nombreProducto", obj.NombreProducto)
            da.SelectCommand.Parameters.AddWithValue("@iduser", obj.Iduser)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ConsultarDetallexCodigo(name As String, ByRef obj As coVentas) As DataTable
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
    Public Function ConsultarKilosxCodigo(name As String, ByVal codigo As Integer) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@codigo", codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ConsultarPedidoAtendidoProduccion(name As String, idplantel As Integer, transferencia As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idplantel", idplantel)
            da.SelectCommand.Parameters.AddWithValue("@transferencia", transferencia)

            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_RecepcionProductos(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            ' Pasar los parámetros al procedimiento almacenado
            With cmd.Parameters
                .AddWithValue("@idsalida", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@todo", SqlDbType.Int).Value = obj.Todo
                .AddWithValue("@fecharecepcion", SqlDbType.Date).Value = obj.FEmision
                .AddWithValue("@idusuario", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@numDocumento", SqlDbType.VarChar).Value = obj.NumDocumentoRecepcion
                ' Manejar el archivo si está presente
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                ' Parámetros adicionales del procedimiento almacenado
                .AddWithValue("@fechatraslado", SqlDbType.Date).Value = If(obj.Fechahasta, DBNull.Value)
                .AddWithValue("@puntopartida", SqlDbType.VarChar).Value = If(String.IsNullOrEmpty(obj.Puntopartida), DBNull.Value, obj.Puntopartida)
                .AddWithValue("@puntollegada", SqlDbType.VarChar).Value = If(String.IsNullOrEmpty(obj.Puntollegada), DBNull.Value, obj.Puntollegada)
                .AddWithValue("@pesobruto", SqlDbType.Money).Value = If(obj.Pesobrudo, DBNull.Value)
                .AddWithValue("@idtransportista", SqlDbType.Int).Value = If(obj.Idtransportista, DBNull.Value)
                .AddWithValue("@placa", SqlDbType.VarChar).Value = If(String.IsNullOrEmpty(obj.Placa), DBNull.Value, obj.Placa)
                .AddWithValue("@idconductor", SqlDbType.Int).Value = If(obj.Idconductor, DBNull.Value)
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .AddWithValue("@horometro_inicial", SqlDbType.Int).Value = obj.Horometro_incial
                .AddWithValue("@pesobalanza", SqlDbType.Decimal).Value = obj.Pesobalanza
                .AddWithValue("@codigosenasa", SqlDbType.VarChar).Value = obj.Codigosenasa
                ' Parámetros de salida
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With

            ' Ejecutar el procedimiento almacenado
            cmd.ExecuteNonQuery()

            ' Obtener el mensaje y el código de error de los parámetros de salida
            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)

            con.Salir()
            Return mensaje
        Catch ex As Exception
            con.Salir()
            Throw ex
        End Try
    End Function
    Public Function Cd_RecepcionPedidoVentasCerdo(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            ' Pasar los parámetros al procedimiento almacenado
            With cmd.Parameters
                .AddWithValue("@todo", SqlDbType.Int).Value = obj.Todo
                .AddWithValue("@fecharecepcion", SqlDbType.Date).Value = obj.FEmision
                .AddWithValue("@idusuario", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@numDocumento", SqlDbType.VarChar).Value = obj.NumDocumentoRecepcion
                ' Manejar el archivo si está presente
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                ' Parámetros adicionales del procedimiento almacenado
                .AddWithValue("@fechatraslado", SqlDbType.Date).Value = If(obj.Fechahasta, DBNull.Value)
                .AddWithValue("@puntopartida", SqlDbType.VarChar).Value = If(String.IsNullOrEmpty(obj.Puntopartida), DBNull.Value, obj.Puntopartida)
                .AddWithValue("@puntollegada", SqlDbType.VarChar).Value = If(String.IsNullOrEmpty(obj.Puntollegada), DBNull.Value, obj.Puntollegada)
                .AddWithValue("@pesobruto", SqlDbType.Money).Value = If(obj.Pesobrudo, DBNull.Value)
                .AddWithValue("@idtransportista", SqlDbType.Int).Value = If(obj.Idtransportista, DBNull.Value)
                .AddWithValue("@placa", SqlDbType.VarChar).Value = If(String.IsNullOrEmpty(obj.Placa), DBNull.Value, obj.Placa)
                .AddWithValue("@idconductor", SqlDbType.Int).Value = If(obj.Idconductor, DBNull.Value)
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .AddWithValue("@horometro_inicial", SqlDbType.Int).Value = obj.Horometro_incial
                .AddWithValue("@odometro_inicial", SqlDbType.Int).Value = obj.odometro_inicial
                .AddWithValue("@pesobalanza", SqlDbType.Decimal).Value = obj.Pesobalanza
                .AddWithValue("@codigosenasa", SqlDbType.VarChar).Value = obj.Codigosenasa
                ' Parámetros de salida
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With

            ' Ejecutar el procedimiento almacenado
            cmd.ExecuteNonQuery()

            ' Obtener el mensaje y el código de error de los parámetros de salida
            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)

            con.Salir()
            Return mensaje
        Catch ex As Exception
            con.Salir()
            Throw ex
        End Try
    End Function
    Public Function Cd_AtencionProductos(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            ' Pasar los parámetros al procedimiento almacenado
            With cmd.Parameters
                .AddWithValue("@idsalida", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@todo", SqlDbType.Int).Value = obj.Todo
                .AddWithValue("@fecharecepcion", SqlDbType.Date).Value = obj.FEmision
                .AddWithValue("@idusuario", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@numDocumento", SqlDbType.VarChar).Value = obj.NumDocumentoRecepcion
                ' Manejar el archivo si está presente
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                ' Parámetros adicionales del procedimiento almacenado
                .AddWithValue("@fechatraslado", SqlDbType.Date).Value = If(obj.Fechahasta, DBNull.Value)
                .AddWithValue("@puntopartida", SqlDbType.VarChar).Value = If(String.IsNullOrEmpty(obj.Puntopartida), DBNull.Value, obj.Puntopartida)
                .AddWithValue("@puntollegada", SqlDbType.VarChar).Value = If(String.IsNullOrEmpty(obj.Puntollegada), DBNull.Value, obj.Puntollegada)
                .AddWithValue("@pesobruto", SqlDbType.Money).Value = If(obj.Pesobrudo, DBNull.Value)
                .AddWithValue("@idtransportista", SqlDbType.Int).Value = If(obj.Idtransportista, DBNull.Value)
                .AddWithValue("@placa", SqlDbType.VarChar).Value = If(String.IsNullOrEmpty(obj.Placa), DBNull.Value, obj.Placa)
                .AddWithValue("@idconductor", SqlDbType.Int).Value = If(obj.Idconductor, DBNull.Value)
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .AddWithValue("@horometro_inicial", SqlDbType.Int).Value = obj.Horometro_incial
                .AddWithValue("@pesobalanza", SqlDbType.Decimal).Value = obj.Pesobalanza

                ' Parámetros de salida
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With

            ' Ejecutar el procedimiento almacenado
            cmd.ExecuteNonQuery()

            ' Obtener el mensaje y el código de error de los parámetros de salida
            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)

            con.Salir()
            Return mensaje
        Catch ex As Exception
            con.Salir()
            Throw ex
        End Try
    End Function


    Public Function Cd_ObtenerArchivoPedidoVenta(name As String, ByRef obj As coVentas) As String
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

    Public Function Cn_AprobarFacturacionPedidoVenta(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idpedido", SqlDbType.Int).Value = obj.Codigo
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

    Public Function Cd_ConsultarDespachosxCodigo(name As String, ByRef obj As coVentas) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idsalida", obj.Codigo)
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
    Public Function Cd_AnularPedidoVenta(name As String, obj As coVentas) As String
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
    Public Function Cd_AnularPedidoVentadistribucionventa(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idsalida", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@motivoanulacion", SqlDbType.VarChar).Value = obj.Motivoanulacion
                .AddWithValue("@idusuarioanulacion", SqlDbType.Int).Value = obj.Iduser
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
    Public Function Cd_AnularRequerimiento(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@motivo", SqlDbType.VarChar).Value = obj.Motivoanulacion
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Codigo
                .Add("@msj", SqlDbType.VarChar, 150).Direction = ParameterDirection.Output
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

    Public Function Cd_AnularrecepcionRequerimiento(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idsalida", SqlDbType.Int).Value = obj.Codigo
                .Add("@msj", SqlDbType.VarChar, 150).Direction = ParameterDirection.Output
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


    Public Function Cd_AnularGuia(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@motivo", SqlDbType.VarChar).Value = obj.Motivoanulacion
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Codigo
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
    Public Function Cd_ActualizarConfirmarGuia(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@id", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@horometro_final", SqlDbType.Int).Value = obj.Horometro_final
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
    Public Function Cd_ConfirmarEntregaPedido(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idguia", SqlDbType.Int).Value = obj.Idguia
                .AddWithValue("@idsalida", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@cantidad", SqlDbType.Money).Value = obj.Cantidad
                .AddWithValue("@cantidadsacos", SqlDbType.Money).Value = obj.Cantidad
                .AddWithValue("@idprod", SqlDbType.Int).Value = obj.Idproducto
                .AddWithValue("@horometro_final", SqlDbType.Int).Value = obj.Horometro_final

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
    Public Function ConsultarVentasFacturadas(name As String, ByRef obj As coVentas) As DataSet
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

    Public Function Cd_ObtenerArchivoFacturacionVenta(name As String, ByRef obj As coVentas) As String
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

    Public Function ConsultarPedidoEnviadoFacturacion(name As String, ByRef obj As coVentas) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fechadesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fechahasta)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_FacturaciónVenta(name As String, obj As coVentas) As String
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
                .AddWithValue("@idcotizacion", SqlDbType.Int).Value = obj.Idcotizacionlista
                .AddWithValue("@idproveedor", SqlDbType.Int).Value = obj.Idproveedor
                .AddWithValue("@recepcion", SqlDbType.VarChar).Value = obj.EstadoRecepcion

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

    Public Function Cd_ModificarVenta(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@idtipopeso", SqlDbType.Int).Value = obj.Idtipopeso
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                .AddWithValue("@precio", SqlDbType.Money).Value = obj.Precio
                .AddWithValue("@Precioalimento", SqlDbType.Money).Value = obj.Precioalimento
                .AddWithValue("@igv", SqlDbType.Money).Value = obj.Igv
                .AddWithValue("@total", SqlDbType.Money).Value = obj.Total
                .AddWithValue("@peso_promedio_final", SqlDbType.Decimal).Value = obj.Peso_promediofinal
                .AddWithValue("@pesodescontado", SqlDbType.Money).Value = obj.pesodescontado
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
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
    Public Function Cd_anularnevioafacturacion(name As String, obj As coVentas) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
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
    Public Function ConsultarPedidoVentaxCodigo(name As String, ByRef obj As coVentas) As DataSet
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
    Public Function ConsultarPedidoVentaxCodigolista(name As String, ByRef obj As coVentas) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idingreso", obj.codigolista)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ConsultarPesosGancho(name As String, ByRef obj As coVentas) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@id", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ConsultarRequerimientoxCodigo(name As String, ByRef obj As coVentas) As DataSet
        Dim dt As New DataSet
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

    Public Function Cd_ConsultarDespachoCerdoGranja(name As String, obj As coVentas) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fechadesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fechahasta)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacionOrigen)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ReportePesosPorVendedor(name As String, obj As coVentas) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fechadesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fechahasta)
            da.SelectCommand.Parameters.AddWithValue("@idUsuario", obj.Iduser)
            da.SelectCommand.Parameters.AddWithValue("@idTipoPeso", obj.Idtipopeso)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ReporteVentaCerdosPorVendedor(name As String, obj As coVentas) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fechadesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fechahasta)
            da.SelectCommand.Parameters.AddWithValue("@idUsuario", obj.Iduser)
            da.SelectCommand.Parameters.AddWithValue("@nombreCliente", obj.NombreCliente)
            da.SelectCommand.Parameters.AddWithValue("@idMotivoTransaccion", obj.IdMotivoTransaccion)
            da.SelectCommand.Parameters.AddWithValue("@semanaMes", obj.Semana)
            da.SelectCommand.Parameters.AddWithValue("@tipoFiltro", obj.TipoFiltro)
            da.SelectCommand.Parameters.AddWithValue("@idTipoPeso", obj.Idtipopeso)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ReporteVentaCerdosPorVendedoranio(name As String, obj As coVentas) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fechadesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fechahasta)
            da.SelectCommand.Parameters.AddWithValue("@idUsuario", obj.Iduser)
            da.SelectCommand.Parameters.AddWithValue("@nombreCliente", obj.NombreCliente)
            da.SelectCommand.Parameters.AddWithValue("@idMotivoTransaccion", obj.IdMotivoTransaccion)
            da.SelectCommand.Parameters.AddWithValue("@semanaMes", obj.Semana)
            da.SelectCommand.Parameters.AddWithValue("@tipoFiltro", obj.TipoFiltro)
            da.SelectCommand.Parameters.AddWithValue("@idTipoPeso", obj.Idtipopeso)
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.anio)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ReporteVentaconsolidado(name As String, obj As coVentas) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUsuario", obj.Iduser)
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.anio)
            da.SelectCommand.Parameters.AddWithValue("@mes", obj.Semana)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ReporteVentaCerdosPorcliente(name As String, obj As coVentas) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fechadesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fechahasta)
            da.SelectCommand.Parameters.AddWithValue("@idUsuario", obj.Iduser)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ReporteVentaresumen(name As String, obj As coVentas) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fechadesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fechahasta)
            da.SelectCommand.Parameters.AddWithValue("@idTipoPeso", obj.Idtipopeso)
            da.SelectCommand.Parameters.AddWithValue("@idMotivoTransaccion", obj.IdMotivoTransaccion)
            da.SelectCommand.Parameters.AddWithValue("@semanaMes", obj.Semana)
            da.SelectCommand.Parameters.AddWithValue("@tipoFiltro", obj.TipoFiltro)
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.anio)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_Resumenstockmoyocha(name As String) As DataSet
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
    Public Function ListarVendedoresActivos(name As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ListarMotivoTransaccionCerdos(name As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ListarTipoPeso(name As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ReporteVentaAnualCerdos(name As String, obj As coVentas) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idTipoPeso", obj.Idtipopeso)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ReporteGuiasAsociadasVenta(name As String, obj As coVentas) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fechadesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fechahasta)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
End Class
