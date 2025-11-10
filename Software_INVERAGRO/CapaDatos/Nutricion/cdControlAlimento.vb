Imports CapaObjetos
Imports System.Data.SqlClient

Public Class cdControlAlimento
    Private con As New cdConexion

    Public Function Cd_RegistrarRequerimientoAlimento(name As String, obj As coControlAlimento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idUser", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idAlmacenPrincipal", SqlDbType.Int).Value = obj.IdAlmacenPrincipal
                .AddWithValue("@idAlmacenSolicitante", SqlDbType.Int).Value = obj.IdAlmacenSolicitante
                .AddWithValue("@listaAlimento", SqlDbType.VarChar).Value = obj.ListaAlimentos
                .AddWithValue("@fPedido", SqlDbType.Date).Value = obj.FechaPedido
                .AddWithValue("@nota", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@idCampaña", SqlDbType.Int).Value = obj.IdCampana
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

    Public Function Cd_ListarRequerimientoAlimento(name As String, obj As coControlAlimento) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", If(obj.FechaDesde.HasValue, obj.FechaDesde.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", If(obj.FechaHasta.HasValue, obj.FechaHasta.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ObtenerRequerimientoAlimentoxId(name As String, obj As coControlAlimento) As DataTable
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

    Public Function Cd_ActualizarRequerimientoAlimento(name As String, obj As coControlAlimento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idSalida", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@idUser", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@listaAlimento", SqlDbType.VarChar).Value = obj.ListaAlimentos
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

    Public Function Cd_RegistrarMedicamentoExtra(name As String, obj As coControlAlimento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@descripcion", SqlDbType.Int).Value = obj.Descripcion
                .AddWithValue("@idUser", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .AddWithValue("@listaProductosExtra", SqlDbType.Decimal).Value = obj.ListaMedicamentos
                .AddWithValue("@tipoPremixero", SqlDbType.VarChar).Value = obj.TipoPremixero
                .AddWithValue("@incluirEnNucleo", SqlDbType.VarChar).Value = obj.IncluirEnNucleo
                .AddWithValue("@fRotacion", SqlDbType.Date).Value = obj.FechaRecepcion
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

    Public Function Cd_ConsultarExtra(name As String, obj As coControlAlimento) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", If(obj.FechaDesde.HasValue, obj.FechaDesde.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", If(obj.FechaHasta.HasValue, obj.FechaHasta.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.Tipo)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ActualizarEstadoExtra(name As String, obj As coControlAlimento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idExtra", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
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

    Public Function Cd_ConsolidadoAlimentoxSemana(name As String, obj As coControlAlimento) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaInicio", If(obj.FechaDesde.HasValue, obj.FechaDesde.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaFin", If(obj.FechaHasta.HasValue, obj.FechaHasta.Value, DBNull.Value))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsolidadoAlimentoxSemanaNutricionista(name As String, obj As coControlAlimento) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaInicio", If(obj.FechaDesde.HasValue, obj.FechaDesde.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaFin", If(obj.FechaHasta.HasValue, obj.FechaHasta.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@idNutricionista", obj.IdNutricionista)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_RequerimientoAlimentoxSemana(name As String, obj As coControlAlimento) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaInicio", If(obj.FechaDesde.HasValue, obj.FechaDesde.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaFin", If(obj.FechaHasta.HasValue, obj.FechaHasta.Value, DBNull.Value))
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    'Public Function Cd_ConsolidadoAlimentoPlusPedirxSemana(name As String, obj As coControlAlimento) As DataTable
    '    Dim dt As New DataTable
    '    Try
    '        con.Abrir()
    '        Dim da As New SqlDataAdapter(name, con.con)
    '        da.SelectCommand.CommandType = 4
    '        da.SelectCommand.Parameters.AddWithValue("@fechaInicio", If(obj.FechaDesde, DBNull.Value))
    '        da.SelectCommand.Parameters.AddWithValue("@fechaFin", If(obj.FechaHasta, DBNull.Value))
    '        da.Fill(dt)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    con.Salir()
    '    Return dt
    'End Function

    Public Function Cd_ConsolidadoAlimentoPedirxSemana(name As String, obj As coControlAlimento) As Object
        Dim dt As New DataTable
        Dim mensaje As String
        Dim coderror As Integer
        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@fechaInicio", If(obj.FechaDesde, DBNull.Value))
            cmd.Parameters.AddWithValue("@fechaFin", If(obj.FechaHasta, DBNull.Value))
            cmd.Parameters.Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output

            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)

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
        Return dt
    End Function

    Public Function Cd_ConsolidadoAlimentoPedirxSemanaNutricionista(name As String, obj As coControlAlimento) As Object
        Dim dt As New DataTable
        Dim mensaje As String
        Dim coderror As Integer
        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@fechaInicio", If(obj.FechaDesde, DBNull.Value))
            cmd.Parameters.AddWithValue("@fechaFin", If(obj.FechaHasta, DBNull.Value))
            cmd.Parameters.AddWithValue("@idNutricionista", obj.IdNutricionista)
            cmd.Parameters.Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            mensaje = cmd.Parameters("@msj").Value.ToString()
            coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)

            If coderror <> 0 Or dt.Rows.Count = 0 Then
                Return mensaje
            End If
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_AnularRequerimientoAlimento(name As String, obj As coControlAlimento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idSalida", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@motivoAnulacion", SqlDbType.VarChar).Value = obj.MotivoAnulacion
                .AddWithValue("@idUserAnulacion", SqlDbType.Int).Value = obj.IdUserAnulacion
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

    Public Function Cd_ConsultarAlimentoPedir(name As String, obj As coControlAlimento) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", If(obj.FechaDesde.HasValue, obj.FechaDesde.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", If(obj.FechaHasta.HasValue, obj.FechaHasta.Value, DBNull.Value))
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_RegistrarListaInsumosPedir(name As String, obj As coControlAlimento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@listaDetalleAlimPedir", SqlDbType.VarChar).Value = obj.ListaAlimentoPedir
                .AddWithValue("@listaSalidaListAlimento", SqlDbType.VarChar).Value = obj.ListaSalidaAlimento
                .AddWithValue("@idUbicacionOrigen", SqlDbType.Int).Value = obj.IdAlmacenPrincipal
                .AddWithValue("@idUbicacionDestino", SqlDbType.Int).Value = obj.IdAlmacenSolicitante
                .AddWithValue("@listaItemsProductos", SqlDbType.VarChar).Value = obj.ListaAlimentos
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

    Public Function Cd_AgruparPedidoAlimentoxTipoAlimento(name As String, obj As coControlAlimento) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaInicio", If(obj.FechaDesde.HasValue, obj.FechaDesde.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaFin", If(obj.FechaHasta.HasValue, obj.FechaHasta.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@tipoEstado", obj.Estado)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function
    Public Function Cd_pa_cancelar_molino_racion(name As String, obj As coControlAlimento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idsDetalle", SqlDbType.Int).Value = obj.idsdetallesalida
                .AddWithValue("@motivoAnulacion", SqlDbType.VarChar).Value = obj.MotivoAnulacion
                .AddWithValue("@idUserAnulacion", SqlDbType.Int).Value = obj.IdUserAnulacion
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
    Public Function Cd_ListarDetalleAlimentoxIds(name As String, obj As coControlAlimento) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idsDetalleSalida", obj.IdsDetalleAlimento)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_MantenimientoPlanMedicado(name As String, obj As coControlFormulacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idExtra", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@listaIdsRaciones", SqlDbType.VarChar).Value = obj.ListaIdsInsumos
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

    Public Function Cd_ListarAlimentoCerdoActivo(name As String, ByVal idAlmacen As Integer) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@idAlmacen", idAlmacen)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_RegistrarAlimentoCerdo(name As String, obj As coControlAlimento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@fControl", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idProducto", SqlDbType.Int).Value = obj.IdProducto
                .AddWithValue("@cantidad", SqlDbType.Decimal).Value = obj.Cantidad
                .AddWithValue("@tipoAlimento", SqlDbType.VarChar).Value = obj.TipoAlimento
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .AddWithValue("@idCampaña", SqlDbType.Int).Value = obj.IdCampana
                .AddWithValue("@idArea", SqlDbType.Int).Value = obj.IdArea
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
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

    Public Function Cd_ConsultarAlimentoCerdo(name As String, obj As coControlAlimento) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", If(obj.FechaDesde.HasValue, obj.FechaDesde.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", If(obj.FechaHasta.HasValue, obj.FechaHasta.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_AnularAlimentoCerdo(name As String, obj As coControlAlimento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idSalida", SqlDbType.Int).Value = obj.IdSalida
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@motivoAnulacion", SqlDbType.VarChar).Value = obj.MotivoAnulacion
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

    'Public Function Cd_ConsultarDetalleSalidaAntiMedicadoRacion(name As String) As DataSet
    '    Dim ds As New DataSet
    '    Try
    '        con.Abrir()
    '        Dim da As New SqlDataAdapter(name, con.con)
    '        da.SelectCommand.CommandType = 4
    '        da.Fill(ds)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    con.Salir()
    '    Return ds
    'End Function

    Public Function Cd_ConsultarDetalleSalidaAntiMedicadoRacion(name As String, obj As coControlAlimento) As DataTable
        Dim ds As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@fechaInicio", If(obj.FechaDesde, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaFin", If(obj.FechaHasta, DBNull.Value))
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarMedicacionesRacion(name As String, obj As coControlAlimento) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@idRacion", obj.IdRacion)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.Tipo)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarMedicacionesPlusRacion(name As String, obj As coControlAlimento) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@idRacion", obj.IdRacion)
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.Tipo)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ObtenerPeriodoMedicacionRacion(name As String, obj As coControlAlimento) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idDetalleSalida", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ObtenerHistorioPreparaciones(name As String, obj As coControlAlimento) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_CancelarPreparacionAlimento(name As String, obj As coControlAlimento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idPreparacionAlimento", SqlDbType.Int).Value = obj.IdPreparacionAlimento
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

    Public Function Cd_ListarDetalleCorrales(name As String, obj As coControlAlimento) As DataTable
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

    Public Function Cd_ReporteAlimentoPorPlantel(name As String, obj As coControlAlimento) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idCampaña", obj.Codigo)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ListarCampañasPorPlantel(name As String, obj As coControlAlimento) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_ConsultarCampañaGalpon(name As String, obj As coControlAlimento) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idCampaña", obj.IdCampana)
            da.SelectCommand.Parameters.AddWithValue("@idGalpon", obj.IdGalpon)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarAlimentoAnual(name As String, obj As coControlAlimento) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.Anio)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ReporteAlimentoPorPlantelReproductor(name As String, obj As coControlAlimento) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.Tipo)
            da.SelectCommand.Parameters.AddWithValue("@idArea", obj.IdArea)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ActualizarEstadoPresupuestoProducto(name As String, obj As coControlAlimento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@listaProductos", SqlDbType.Int).Value = obj.ListaAlimentos
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

    Public Function Cd_RegistrarAlimentacionPresupuesto(name As String, obj As coControlAlimento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@fecha", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@cantidadAlimento", SqlDbType.Decimal).Value = obj.Cantidad
                .AddWithValue("@idAlimento", SqlDbType.Int).Value = obj.IdProducto
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idGrupo", SqlDbType.Int).Value = obj.IdGrupo
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
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

    Public Function Cd_ListarxUbicacionLoteGrupoProducto(name As String, obj As coControlAlimento) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.SelectCommand.Parameters.AddWithValue("@idGrupo", obj.IdGrupo)
            da.SelectCommand.Parameters.AddWithValue("@idProducto", obj.IdProducto)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ListarxUbicacionGrupoProducto(name As String, obj As coControlAlimento) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.SelectCommand.Parameters.AddWithValue("@idGrupo", obj.IdGrupo)
            da.SelectCommand.Parameters.AddWithValue("@idProducto", obj.IdProducto)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_EliminarDetalleAlimentoGrupo(name As String, obj As coControlAlimento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idDetGrupo", SqlDbType.Int).Value = obj.Codigo
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

    Public Function Cd_ReporteSemanalPedidoAlimento(name As String, obj As coControlAlimento) As DataTable
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

    Public Function Cd_ModificarCampañaPedido(name As String, obj As coControlAlimento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idSalida", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@idCampaña", SqlDbType.Int).Value = obj.IdCampana
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
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
