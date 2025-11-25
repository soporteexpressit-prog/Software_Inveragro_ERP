Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdControlLoteDestete
    Private con As New cdConexion

    Public Function Cd_MantenimientoLote(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@numLote", SqlDbType.Int).Value = obj.NumeroLote
                .AddWithValue("@anio", SqlDbType.Int).Value = obj.Anio
                .AddWithValue("@fApertura", SqlDbType.Date).Value = obj.FechaDesde
                .AddWithValue("@fCierre", SqlDbType.Date).Value = obj.FechaHasta
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
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

    Public Function Cd_ConsultarLoteAnio(name As String, obj As coControlLoteDestete) As DataTable
        Dim ds As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.Anio)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarxIdLote(name As String, obj As coControlLoteDestete) As DataTable
        Dim ds As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarxIdLoteDs(name As String, obj As coControlLoteDestete) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_CambiarLoteCerdaCrias(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idCerda", SqlDbType.Int).Value = obj.IdAnimal
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
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

    Public Function Cd_ConsultarxAnioUbicacion(name As String, obj As coControlLoteDestete) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.Anio)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarDepuracionxIdLote(name As String, obj As coControlLoteDestete) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.SelectCommand.Parameters.AddWithValue("@flag", obj.NumDepuracion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarxLoteUbicacionDs(name As String, obj As coControlLoteDestete) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ObtenerAnimalesLoteBajada(name As String, obj As coControlLoteDestete) As Object
        Dim ds As New DataSet
        Dim mensaje As String
        Dim coderror As Integer
        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idLote", obj.IdLote)
            cmd.Parameters.AddWithValue("@idMovimientoBajada", obj.IdMovimientoBajada)
            cmd.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            cmd.Parameters.AddWithValue("@tipo", obj.TipoFiltro)
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

    Public Function Cd_ConsultarAnimalesxIdJaulaCorral(name As String, obj As coControlLoteDestete) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idJaulaCorral", obj.IdJaulaCorral)
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarAnimalesxIdJaulaCorralRegularizacion(name As String, obj As coControlLoteDestete) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idJaulaCorral", obj.IdJaulaCorral)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_RegistrarBajada(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@numChanchillas", SqlDbType.Int).Value = obj.CantidadTatuadas
                .AddWithValue("@numPuras", SqlDbType.Int).Value = obj.CantidadPuras
                .AddWithValue("@numEngorde", SqlDbType.Int).Value = obj.CantidadVenta
                .AddWithValue("@pesoTotal", SqlDbType.Decimal).Value = obj.PesoTotal
                .AddWithValue("@pesoPromedio", SqlDbType.Decimal).Value = obj.PesoPromedio
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.TipoBajada
                .AddWithValue("@idPlantelSalida", SqlDbType.Int).Value = obj.IdPlantelSalida
                .AddWithValue("@idPlantelLlegada", SqlDbType.Int).Value = obj.IdPlantelLlegada
                .AddWithValue("@idTransporte", SqlDbType.Int).Value = obj.IdTransporte
                .AddWithValue("@idConductor", SqlDbType.Int).Value = obj.IdConductor
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@edadLote", SqlDbType.Int).Value = obj.EdadLote
                .AddWithValue("@fControl", SqlDbType.Date).Value = obj.FechaControl
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

    Public Function Cd_RegistrarRetorno(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@numChanchillas", SqlDbType.Int).Value = obj.CantidadTatuadas
                .AddWithValue("@numPuras", SqlDbType.Int).Value = obj.CantidadPuras
                .AddWithValue("@numEngorde", SqlDbType.Int).Value = obj.CantidadVenta
                .AddWithValue("@numMadreMeishan", SqlDbType.Int).Value = obj.CantidadMeishan
                .AddWithValue("@pesoTotal", SqlDbType.Decimal).Value = obj.PesoTotal
                .AddWithValue("@pesoPromedio", SqlDbType.Decimal).Value = obj.PesoPromedio
                .AddWithValue("@idPlantelSalida", SqlDbType.Int).Value = obj.IdPlantelSalida
                .AddWithValue("@idPlantelLlegada", SqlDbType.Int).Value = obj.IdPlantelLlegada
                .AddWithValue("@idTransporte", SqlDbType.Int).Value = obj.IdTransporte
                .AddWithValue("@idConductor", SqlDbType.Int).Value = obj.IdConductor
                .AddWithValue("@idsLotes", SqlDbType.Int).Value = obj.ListaIdsLotes
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@fControl", SqlDbType.Date).Value = obj.FechaControl
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

    Public Function Cd_ConsultarAnimalesxIdJaulaCorralAjuste(name As String, obj As coControlLoteDestete) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idJaulaCorral", obj.IdJaulaCorral)
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_AjustarAnimalesxJaulaCorral(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idJaulaCorral", SqlDbType.Int).Value = obj.IdJaulaCorral
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

    Public Function Cd_AjustarCerdosCorral(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@listaIdsCorralCantidad", SqlDbType.VarChar).Value = obj.ListaIdsCorralCantidad
                .AddWithValue("@listaIdsCerdosRegistrados", SqlDbType.VarChar).Value = obj.ListaIdsCerdosRegistrados
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idCorralAjustar", SqlDbType.Int).Value = obj.IdJaulaCorral
                .AddWithValue("@cantidadTatuadas", SqlDbType.Int).Value = obj.CantidadTatuadas
                .AddWithValue("@cantidadVenta", SqlDbType.Int).Value = obj.CantidadVenta
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

    Public Function Cd_RegistrarMovimientoUbicacion(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@listaIdsCorralCantidad", SqlDbType.VarChar).Value = obj.ListaIdsCorralCantidad
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                .AddWithValue("@esBajada", SqlDbType.VarChar).Value = obj.EsBajada
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

    Public Function Cd_RegistrarMovimientoUbicacionxLote(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@listaIdsCorralCantidad", SqlDbType.VarChar).Value = obj.ListaIdsCorralCantidad
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
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

    Public Function Cd_RegistrarMovimientoZonaEspera(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@listaIdsCorralCantidad", SqlDbType.VarChar).Value = obj.ListaIdsCorralCantidad
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
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

    Public Function Cd_RegistrarControlDescarteMadreFutura(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@listaAnimalesDescarte", SqlDbType.VarChar).Value = obj.ListaCerdoDescarte
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                .AddWithValue("@numDepuracion", SqlDbType.Int).Value = obj.NumDepuracion
                .AddWithValue("@fControl", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@esEnvioCamalChanchilla", SqlDbType.Bit).Value = obj.EsChanchilla
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

    Public Function Cd_ConsCriasMortalidadLote(name As String, obj As coControlLoteDestete) As DataSet
        Dim dS As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(dS)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dS
    End Function

    Public Function Cd_EliminarEventoMortalidadLote(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .Add("@idControlFichaMortalidad", SqlDbType.Int).Value = obj.IdControlFichaMortalidad
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

    Public Function Cd_MovimientoMadreFutura(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@listaIdsCorralCantidad", SqlDbType.VarChar).Value = obj.ListaIdsCorralCantidad
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                .AddWithValue("@esRetorno", SqlDbType.VarChar).Value = obj.EsRetorno
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

    Public Function Cd_CancelarDepuracionMadreFutura(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idControlFicha", SqlDbType.Int).Value = obj.IdControlFicha
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

    Public Function Cd_RegistrarDesteteCrias(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@listaIdsCerdasDestetar", SqlDbType.VarChar).Value = obj.ListaDatosDestete
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@fControl", SqlDbType.Date).Value = obj.FechaControl
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

    Public Function Cd_ConsultarRegularizacionPlantel(name As String, obj As coControlLoteDestete) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_AnularRegularizacionCerdo(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idRegularizacionCerdo", SqlDbType.Int).Value = obj.IdRegularizarCerdo
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

    Public Function Cd_RegistrarAnimalClinica(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@listaIdPuras", SqlDbType.VarChar).Value = obj.ListaCriasRegistrar
                .AddWithValue("@cantidadCambo", SqlDbType.Int).Value = obj.CantidadTatuadas
                .AddWithValue("@cantidadEngorde", SqlDbType.Int).Value = obj.CantidadVenta
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                .AddWithValue("@idJaulaCorral", SqlDbType.Int).Value = obj.IdJaulaCorral
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

    Public Function Cd_RetirarAnimalClinica(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idAnimal", SqlDbType.Int).Value = obj.IdAnimal
                .AddWithValue("@cantidadCambo", SqlDbType.Int).Value = obj.CantidadTatuadas
                .AddWithValue("@cantidadEngorde", SqlDbType.Int).Value = obj.CantidadVenta
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.TipoFiltro
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
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

    Public Function Cd_RegistrarConfirmacionBajada(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idsListaPuras", SqlDbType.VarChar).Value = obj.ListaIdsCerdosRegistrados
                .AddWithValue("@cantidadCambo", SqlDbType.Int).Value = obj.CantidadTatuadas
                .AddWithValue("@cantidadEngorde", SqlDbType.Int).Value = obj.CantidadVenta
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idMovimientoBajadaRetorno", SqlDbType.Int).Value = obj.IdMovimientoBajada
                .AddWithValue("@fControl", SqlDbType.Date).Value = obj.FechaControl
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

    Public Function Cd_CancelarConfirmacionEnvio(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                .AddWithValue("@idMovimientoBajada", SqlDbType.Int).Value = obj.IdMovimientoBajada
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

    Public Function Cd_CancelarConfirmacionChanchillas(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                .AddWithValue("@idMovimientoRetorno", SqlDbType.Int).Value = obj.IdMovimientoBajada
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

    Public Function Cd_RegistrarPesoBajada(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@pesoTotal", SqlDbType.Decimal).Value = obj.PesoTotal
                .AddWithValue("@pesoPromedio", SqlDbType.Decimal).Value = obj.PesoPromedio
                .AddWithValue("@idPlantelSalida", SqlDbType.Int).Value = obj.IdPlantelSalida
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

    Public Function Cd_RegistrarVentaLote(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
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

    Public Function Cd_CancelarVentaLote(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
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

    Public Function Cd_ConsultarxIdUbicacion(name As String, obj As coControlLoteDestete) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarReporteGeneralLote(name As String, obj As coControlLoteDestete) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idCampaña", obj.IdCampana)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarxIdMovimiento(name As String, obj As coControlLoteDestete) As DataTable
        Dim ds As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idMovimientoBajada", obj.IdMovimientoBajada)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarCerdasRetornarxLotes(name As String, obj As coControlLoteDestete) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idsLote", obj.ListaIdsLotes)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarxUbicacionDs(name As String, obj As coControlLoteDestete) As DataSet
        Dim dS As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(dS)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dS
    End Function

    Public Function Cd_RegistrarConfirmacionRetorno(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idsListaPuras", SqlDbType.VarChar).Value = obj.ListaIdsCerdosRegistrados
                .AddWithValue("@listaCamboMortalidad", SqlDbType.Int).Value = obj.ListaIdsLotes
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idMovimientoBajadaRetorno", SqlDbType.Int).Value = obj.IdMovimientoBajada
                .AddWithValue("@fControl", SqlDbType.Date).Value = obj.FechaControl
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

    Public Function Cd_ConsultarxLoteUbicacionDt(name As String, obj As coControlLoteDestete) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarDepuracionHistorico(name As String, obj As coControlLoteDestete) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarxLoteUbicacionChanchillaDt(name As String, obj As coControlLoteDestete) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.SelectCommand.Parameters.AddWithValue("@chanchillasSinRetorno", obj.TipoFiltro)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarxAnioDs(name As String, obj As coControlLoteDestete) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.Anio)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarxAnioDt(name As String, obj As coControlLoteDestete) As DataTable
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

    Public Function Cd_ConsultarxAnioMesSemDt(name As String, obj As coControlLoteDestete) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.Anio)
            da.SelectCommand.Parameters.AddWithValue("@numMes", obj.Mes)
            da.SelectCommand.Parameters.AddWithValue("@numSemana", obj.Semana)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarxAnioMesSemOtrosDt(name As String, obj As coControlLoteDestete) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.Anio)
            da.SelectCommand.Parameters.AddWithValue("@numMes", obj.Mes)
            da.SelectCommand.Parameters.AddWithValue("@numSemana", obj.Semana)
            da.SelectCommand.Parameters.AddWithValue("@utilizarFecha", obj.Estado)
            da.SelectCommand.Parameters.AddWithValue("@fecha", obj.FechaControl)
            da.SelectCommand.Parameters.AddWithValue("@fechahasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@tipoFiltro", obj.TipoFiltro)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultaxIdLoteDs(name As String, obj As coControlLoteDestete) As DataSet
        Dim dS As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.Fill(dS)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dS
    End Function

    Public Function Cd_ConsultarGeneral(name As String) As DataTable
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

    Public Function ConsultarxLoteDt(name As String, obj As coControlLoteDestete) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarPartoVsDestete(name As String, obj As coControlLoteDestete) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.Anio)
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.SelectCommand.Parameters.AddWithValue("@flag", obj.TipoFiltro)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarxIdDespacho(name As String, obj As coControlLoteDestete) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idSalida", obj.IdSalida)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ActualizarMetaPartos(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@meta", SqlDbType.Int).Value = obj.Meta
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

    Public Function Cd_RegistrarPesosBajada(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@cantidadAnimales", SqlDbType.Int).Value = obj.CantidadVenta
                .AddWithValue("@peso", SqlDbType.Decimal).Value = obj.PesoTotal
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.TipoFiltro
                .AddWithValue("@fRegistro", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@clasificacion", SqlDbType.VarChar).Value = obj.TipoBajada
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

    Public Function Cd_CancelarPesosBajada(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
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

    Public Function Cd_EliminarPesoBajada(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idPesoBajada", SqlDbType.Int).Value = obj.IdControlFicha
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

    Public Function Cd_ConsultarxIdLoteTipoClasificacion(name As String, obj As coControlLoteDestete) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.TipoFiltro)
            da.SelectCommand.Parameters.AddWithValue("@clasificacion", obj.TipoBajada)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_RegMovimientoChanchillaMeishan(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@numPura", SqlDbType.Int).Value = obj.CantidadPuras
                .AddWithValue("@numCambor", SqlDbType.Int).Value = obj.CantidadTatuadas
                .AddWithValue("@numCelador", SqlDbType.Int).Value = obj.CantidadVenta
                .AddWithValue("@numMeishan", SqlDbType.Int).Value = obj.CantidadMeishan
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
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

    Public Function Cd_RegistrarGrupos(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                .AddWithValue("@listaGrupos", SqlDbType.VarChar).Value = obj.ListaItems
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

    Public Function Cd_RegistrarPresupuestoAlimentoGrupo(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idGrupo", SqlDbType.Int).Value = obj.IdGrupo
                .AddWithValue("@idAlimento", SqlDbType.Int).Value = obj.IdRacion
                .AddWithValue("@objetivo", SqlDbType.Decimal).Value = obj.Objetivo
                .AddWithValue("@pesoDestete", SqlDbType.Decimal).Value = obj.PesoDestete
                .AddWithValue("@ca", SqlDbType.Decimal).Value = obj.Ca
                .AddWithValue("@presentacionSacos", SqlDbType.Decimal).Value = obj.PresentacionSacos
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

    Public Function Cd_ConsultarxGrupoLoteAlimento(name As String, obj As coControlLoteDestete) As DataTable
        Dim ds As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idGrupo", obj.IdGrupo)
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.SelectCommand.Parameters.AddWithValue("@idAlimento", obj.IdRacion)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarxIdControlFicha(name As String, obj As coControlLoteDestete) As DataTable
        Dim ds As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idControlFicha", obj.IdControlFicha)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ReporteEngordeCampana(name As String, obj As coControlLoteDestete) As DataTable
        Dim ds As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idCampaña", obj.IdCampana)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_FinalizarVentaxCampaña(name As String, obj As coControlLoteDestete) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@fechaFinVenta", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@idCampaña", SqlDbType.Int).Value = obj.IdCampana
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
