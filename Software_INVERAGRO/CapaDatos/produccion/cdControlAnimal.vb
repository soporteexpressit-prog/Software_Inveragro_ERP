Imports CapaObjetos
Imports System.Data.SqlClient

Public Class cdControlAnimal
    Private con As New cdConexion

    Public Function Cd_RegistrarVerraco(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@fNacimiento", SqlDbType.Date).Value = obj.FechaNacimiento
                .AddWithValue("@fLlegada", SqlDbType.Date).Value = obj.FechaLlegada
                .AddWithValue("@peso", SqlDbType.Decimal).Value = obj.Peso
                .AddWithValue("@indice", SqlDbType.Decimal).Value = obj.Indice
                .AddWithValue("@idGenetica", SqlDbType.Int).Value = obj.IdGenetica
                .AddWithValue("@idJaulaCorral", SqlDbType.Int).Value = obj.IdJaulaCorral
                .AddWithValue("@tipoAdquisicion", SqlDbType.VarChar).Value = obj.TipoAdquisicion
                .AddWithValue("@idProducto", SqlDbType.Int).Value = obj.IdProducto
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@tatuaje", SqlDbType.VarChar).Value = obj.ValorTatuaje
                .AddWithValue("@codCerdo", SqlDbType.VarChar).Value = obj.CodArete
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

    Public Function Cd_RegistrarCodificacionAnimal(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@fLlegada", SqlDbType.Date).Value = obj.FechaLlegada
                .AddWithValue("@idGenetica", SqlDbType.Int).Value = obj.IdGenetica
                .AddWithValue("@idJaulaCorral", SqlDbType.Int).Value = obj.IdJaulaCorral
                .AddWithValue("@listaCodificadas", SqlDbType.VarChar).Value = obj.ListaCriasRegistrar
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

    Public Function Cd_ConsultarAnimal(name As String, obj As coControlAnimal) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@estadoVivo", obj.EstadoVivo)
            da.SelectCommand.Parameters.AddWithValue("@estadoVenta", obj.EstadoVenta)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarAnimalCerda(name As String, obj As coControlAnimal) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@estadoVivo", obj.EstadoVivo)
            da.SelectCommand.Parameters.AddWithValue("@estadoVenta", obj.EstadoVenta)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.SelectCommand.Parameters.AddWithValue("@filtrarSinCelo", obj.Filtro)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarChanchillaCelador(name As String, obj As coControlAnimal) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@estadoVivo", obj.EstadoVivo)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_GeneralxIdUbicacion(name As String, obj As coControlAnimal) As DataTable
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

    Public Function Cd_ConsultarCerdasGestacion(name As String, obj As coControlAnimal) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.SelectCommand.Parameters.AddWithValue("@codArete", obj.CodArete)
            da.SelectCommand.Parameters.AddWithValue("@condicion", obj.EtapaReproductiva)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarCerdasMaternidad(name As String, obj As coControlAnimal) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.SelectCommand.Parameters.AddWithValue("@arete", obj.CodArete)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarxIdAnimal(name As String, obj As coControlAnimal) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idAnimal", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
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

    Public Function Cd_RegistrarCerda(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@fNacimiento", SqlDbType.Date).Value = obj.FechaNacimiento
                .AddWithValue("@fLlegada", SqlDbType.Date).Value = obj.FechaLlegada
                .AddWithValue("@peso", SqlDbType.Decimal).Value = obj.Peso
                .AddWithValue("@indice", SqlDbType.Decimal).Value = obj.Indice
                .AddWithValue("@idGenetica", SqlDbType.Int).Value = obj.IdGenetica
                .AddWithValue("@idJaulaCorral", SqlDbType.Int).Value = obj.IdJaulaCorral
                .AddWithValue("@numTetillas", SqlDbType.Int).Value = obj.NumTetillas
                .AddWithValue("@condCorporal", SqlDbType.Decimal).Value = obj.CondCorporal
                .AddWithValue("@numPartos", SqlDbType.Int).Value = obj.NumPartos
                .AddWithValue("@tipoAdquisicion", SqlDbType.VarChar).Value = obj.TipoAdquisicion
                .AddWithValue("@idProducto", SqlDbType.Int).Value = obj.IdProducto
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@tatuaje", SqlDbType.VarChar).Value = obj.ValorTatuaje
                .AddWithValue("@codCerdo", SqlDbType.VarChar).Value = obj.CodArete
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

    Public Function Cd_ActualizarDatosCerda(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idAnimal", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@condCorporal", SqlDbType.Decimal).Value = obj.CondCorporal
                .AddWithValue("@numTetillas", SqlDbType.Int).Value = obj.NumTetillas
                .AddWithValue("@peso", SqlDbType.Decimal).Value = obj.Peso
                .AddWithValue("@idJaulaCorral", SqlDbType.Int).Value = obj.IdJaulaCorral
                .AddWithValue("@calificacionPatas", SqlDbType.Int).Value = obj.CalificacionPatas
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@etapaMaternidad", SqlDbType.VarChar).Value = obj.EtapaReproductiva
                .AddWithValue("@tatuaje", SqlDbType.VarChar).Value = obj.ValorTatuaje
                .AddWithValue("@codCerdo", SqlDbType.VarChar).Value = obj.CodArete
                .AddWithValue("@indice", SqlDbType.Int).Value = obj.Indice
                .AddWithValue("@fNacimiento", SqlDbType.Date).Value = obj.FechaNacimiento
                .AddWithValue("@idGenetica", SqlDbType.Int).Value = obj.IdGenetica
                .AddWithValue("@comCamborough", SqlDbType.Bit).Value = obj.ComportamientoCamborough
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

    Public Function Cd_ActualizarDatosVerraco(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idAnimal", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@peso", SqlDbType.Decimal).Value = obj.Peso
                .AddWithValue("@idJaulaCorral", SqlDbType.Int).Value = obj.IdJaulaCorral
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@tatuaje", SqlDbType.VarChar).Value = obj.ValorTatuaje
                .AddWithValue("@codCerdo", SqlDbType.VarChar).Value = obj.CodArete
                .AddWithValue("@indice", SqlDbType.Int).Value = obj.Indice
                .AddWithValue("@fNacimiento", SqlDbType.Date).Value = obj.FechaNacimiento
                .AddWithValue("@idGenetica", SqlDbType.Int).Value = obj.IdGenetica
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

    Public Function Cd_RegistrarTestGestacion(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idControlFicha", SqlDbType.Int).Value = obj.IdControlFicha
                .AddWithValue("@idCerda", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@resultado", SqlDbType.VarChar).Value = obj.Resultado
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@idEncargado", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@fechaControl", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@canMuertos", SqlDbType.Int).Value = obj.CantidadCrias
                .AddWithValue("@envioCamal", SqlDbType.VarChar).Value = obj.EnvioCamal
                Dim paramFoto As SqlParameter = cmd.Parameters.Add("@archivoFoto", SqlDbType.VarBinary)
                If obj.ArchivoFotoCamal Is Nothing Then
                    paramFoto.Value = DBNull.Value
                Else
                    paramFoto.Value = obj.ArchivoFotoCamal
                End If
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

    Public Function Cd_RegistrarMonitoreCondCorporal(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idCerda", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@condCorporal", SqlDbType.VarChar).Value = obj.CondCorporal
                .AddWithValue("@diasEtapa", SqlDbType.Int).Value = obj.DiasTranscurridos
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

    Public Function Cd_ConsultarGeneralxIdCerda(name As String, obj As coControlAnimal) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idCerda", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_RegistrarParto(name As String, obj As coControlAnimal) As String

        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.IdControlParto
                .AddWithValue("@fControl", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@totalNacidosMachos", SqlDbType.Int).Value = obj.TotalNacidosMachos
                .AddWithValue("@totalNacidosHembras", SqlDbType.Int).Value = obj.TotalNacidosHembras
                .AddWithValue("@totalBallicos", SqlDbType.Int).Value = obj.TotalBallicos
                .AddWithValue("@totalMomias", SqlDbType.Int).Value = obj.TotalMomias
                .AddWithValue("@totalMuertos", SqlDbType.Int).Value = obj.TotalMuertos
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@pesoPromCrias", SqlDbType.Decimal).Value = obj.PesoPromedioCrias
                .AddWithValue("@pesoTotalCrias", SqlDbType.Decimal).Value = obj.PesoTotalCrias
                .AddWithValue("@duracion", SqlDbType.Decimal).Value = obj.Duracion
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idResponsable", SqlDbType.Int).Value = obj.IdResponsable
                .AddWithValue("@idAnimal", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@codCorporal", SqlDbType.Decimal).Value = obj.CondCorporal
                .AddWithValue("@listaCrias", SqlDbType.VarChar).Value = obj.ListaCrias
                .AddWithValue("@idJaulaCorral", SqlDbType.Int).Value = obj.IdJaulaCorral
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

    Public Function Cd_ConsultarDetallePartoMortalidad(name As String, obj As coControlAnimal) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idCerda", obj.Codigo)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_MantenimientoMortalidadCerdo(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@fControl", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@listaIdsCrias", SqlDbType.VarChar).Value = obj.ListaIdsCriasConCod
                .AddWithValue("@idMotivoMortalidad", SqlDbType.Int).Value = obj.IdMotivoMortalidadCamal
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idResponsable", SqlDbType.Int).Value = obj.IdResponsable
                .AddWithValue("@idCerdaMadre", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@dejarVacia", SqlDbType.VarChar).Value = obj.DejarVaciaoLactando
                .AddWithValue("@idControlFichaMortalidad", SqlDbType.Int).Value = obj.IdControlFichaMortalidad
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

    Public Function Cd_RegistrarEnvioCamalMaternidad(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@listaIdsAnimalesConCod", SqlDbType.VarChar).Value = obj.ListaIdsCriasConCod
                .AddWithValue("@listaIdsAnimalesSinCod", SqlDbType.VarChar).Value = obj.ListaIdsCriasSinCod
                .AddWithValue("@archivoFoto", SqlDbType.VarBinary).Value = If(obj.ArchivoFotoCamal Is Nothing, DBNull.Value, obj.ArchivoFotoCamal)
                .AddWithValue("@idTipoIncidencia", SqlDbType.Int).Value = obj.IdMotivoMortalidadCamal
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@cantAnimalesSinCod", SqlDbType.Int).Value = obj.CantidadCrias
                .AddWithValue("@idJaulaCorralMadre", SqlDbType.Int).Value = obj.IdJaulaCorral
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

    Public Function Cd_RegistrarMortalidadLote(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@listaIdsCriasConCod", SqlDbType.VarChar).Value = obj.ListaIdsCriasConCod
                .AddWithValue("@cantMuertosEngorde", SqlDbType.Int).Value = obj.CantidadMuertosEngorde
                .AddWithValue("@cantMuertosTatuados", SqlDbType.Int).Value = obj.CantidadMuertosTatuaje
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                .AddWithValue("@cantidadMuertoConCod", SqlDbType.Int).Value = obj.CantidadMuertoConCod
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@idMotivoMortalidad", SqlDbType.Int).Value = obj.IdMotivoMortalidadCamal
                .AddWithValue("@idJaulaCorralMadre", SqlDbType.Int).Value = obj.IdJaulaCorral
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@archivoFoto", SqlDbType.VarBinary).Value = If(obj.ArchivoFotoMortalidad Is Nothing, DBNull.Value, obj.ArchivoFotoMortalidad)
                .AddWithValue("@fechaControl", SqlDbType.Date).Value = obj.FechaControl
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

    Public Function Cd_RegistrarMortalidadMadreFutura(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@listaIdsCriasConCod", SqlDbType.VarChar).Value = obj.ListaIdsCriasConCod
                .AddWithValue("@cantAnimalesMuertos", SqlDbType.Int).Value = obj.CantidadMuertosEngorde
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                .AddWithValue("@cantidadMuertoConCod", SqlDbType.Int).Value = obj.CantidadMuertoConCod
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@idMotivoMortalidad", SqlDbType.Int).Value = obj.IdMotivoMortalidadCamal
                .AddWithValue("@idJaulaCorral", SqlDbType.Int).Value = obj.IdJaulaCorral
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@archivoFoto", SqlDbType.VarBinary).Value = If(obj.ArchivoFotoMortalidad Is Nothing, DBNull.Value, obj.ArchivoFotoMortalidad)
                .AddWithValue("@fechaControl", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.TipoControl
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

    Public Function Cd_ConsultarHistorialEtapaxIdCerda(name As String, obj As coControlAnimal) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.Anio)
            da.SelectCommand.Parameters.AddWithValue("@idAnimal", obj.Codigo)
            da.SelectCommand.Parameters.AddWithValue("@etapa", obj.EtapaReproductiva)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarxIdAnimalAnio(name As String, obj As coControlAnimal) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idAnimal", obj.Codigo)
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.Anio)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarMedicacionxIdAnimal(name As String, obj As coControlAnimal) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idAnimal", obj.Codigo)
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_RegistrarEnvioCamal(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .Add("@idAnimal", SqlDbType.Int).Value = obj.Codigo
                .Add("@idTipoIncidencia", SqlDbType.Int).Value = obj.IdMotivoMortalidadCamal
                .Add("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                Dim paramFoto As SqlParameter = cmd.Parameters.Add("@archivoFoto", SqlDbType.VarBinary)
                If obj.ArchivoFotoCamal Is Nothing Then
                    paramFoto.Value = DBNull.Value
                Else
                    paramFoto.Value = obj.ArchivoFotoCamal
                End If
                .Add("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .Add("@fControl", SqlDbType.Date).Value = obj.FechaControl
                .Add("@peso", SqlDbType.Decimal).Value = obj.Peso
                .Add("@chanchillaEngorde", SqlDbType.Bit).Value = obj.ChanchillaEngorde
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

    Public Function Cd_RegistrarEnvioCamalMasivo(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .Add("@listaIdsAnimal", SqlDbType.VarChar).Value = obj.ListaCriasRegistrar
                .Add("@idTipoIncidencia", SqlDbType.Int).Value = obj.IdMotivoMortalidadCamal
                .Add("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .Add("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .Add("@fControl", SqlDbType.Date).Value = obj.FechaControl
                .Add("@peso", SqlDbType.Decimal).Value = obj.Peso
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

    Public Function Cd_ConsultarEnvioCamal(name As String, obj As coControlAnimal) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.TipoControl)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarArchivoCamal(name As String, obj As coControlAnimal) As Byte()
        Dim archivo() As Byte = Nothing
        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con) With {
                .CommandType = CommandType.StoredProcedure
            }
            cmd.Parameters.AddWithValue("@idHistorialEnvioCamal", obj.IdHistorialEnvioCamal)

            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                archivo = DirectCast(result, Byte())
            End If
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return archivo
    End Function

    Public Function Cd_RegistrarEnvioCamalLote(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@listaIdsAnimalesConCod", SqlDbType.VarChar).Value = obj.ListaIdsCriasConCod
                .AddWithValue("@cantidadEngorde", SqlDbType.Int).Value = obj.CantidadCamalEngorde
                .AddWithValue("@cantidadTatuada", SqlDbType.Int).Value = obj.CantidadCamalTatuaje
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                Dim paramFoto As SqlParameter = cmd.Parameters.Add("@archivoFoto", SqlDbType.VarBinary)
                If obj.ArchivoFotoCamal Is Nothing Then
                    paramFoto.Value = DBNull.Value
                Else
                    paramFoto.Value = obj.ArchivoFotoCamal
                End If
                .AddWithValue("@idTipoIncidencia", SqlDbType.Int).Value = obj.IdMotivoMortalidadCamal
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idJaulaCorral", SqlDbType.Int).Value = obj.IdJaulaCorral
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@fechaControl", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@peso", SqlDbType.Decimal).Value = obj.Peso
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

    Public Function Cd_RegistrarMortalidadAnimal(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@fControl", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@idAnimal", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@idMotivoMortalidad", SqlDbType.Int).Value = obj.IdControlFichaMortalidad
                Dim paramFoto As SqlParameter = cmd.Parameters.Add("@archivoFoto", SqlDbType.VarBinary)
                If obj.ArchivoFotoMortalidad Is Nothing Then
                    paramFoto.Value = DBNull.Value
                Else
                    paramFoto.Value = obj.ArchivoFotoMortalidad
                End If
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

    Public Function Cd_RegistrarEnvioCamalMadreFuturaLote(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@listaIdsAnimalesConCod", SqlDbType.VarChar).Value = obj.ListaIdsCriasConCod
                .AddWithValue("@cantidadAnimal", SqlDbType.Int).Value = obj.CantidadCamalEngorde
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.IdLote
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                Dim paramFoto As SqlParameter = cmd.Parameters.Add("@archivoFoto", SqlDbType.VarBinary)
                If obj.ArchivoFotoCamal Is Nothing Then
                    paramFoto.Value = DBNull.Value
                Else
                    paramFoto.Value = obj.ArchivoFotoCamal
                End If
                .AddWithValue("@idTipoIncidencia", SqlDbType.Int).Value = obj.IdMotivoMortalidadCamal
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idJaulaCorral", SqlDbType.Int).Value = obj.IdJaulaCorral
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@fechaControl", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.TipoControl
                .AddWithValue("@peso", SqlDbType.Decimal).Value = obj.Peso
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

    Public Function Cd_ConsultarxFechasUbicacionDs(name As String, obj As coControlAnimal) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarxFechasUbicacionLoteDs(name As String, obj As coControlAnimal) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarxMortalidadUbicacionLoteDs(name As String, obj As coControlAnimal) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.SelectCommand.Parameters.AddWithValue("@chanchillas", obj.ChanchillaEngorde)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarxFechasUbicacionTipoLoteDt(name As String, obj As coControlAnimal) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.SelectCommand.Parameters.AddWithValue("@filtro", obj.TipoControl)
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarxFechasUbicacionLoteDt(name As String, obj As coControlAnimal) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_RegistrarNodrizaje(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .Add("@fControl", SqlDbType.Date).Value = obj.FechaControl
                .Add("@idCerdaNodriza", SqlDbType.Int).Value = obj.Codigo
                .Add("@listaCerdasDonante", SqlDbType.VarChar).Value = obj.ListaCerdasDonantes
                .Add("@listaIdsCriasDonadas", SqlDbType.VarChar).Value = obj.ListaIdsCriasDonantes
                .Add("@totalCriasDonar", SqlDbType.Int).Value = obj.TotalCriasDonar
                .Add("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .Add("@idLoteDonante", SqlDbType.Int).Value = obj.IdLote
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

    Public Function Cd_EliminarMovimientoCriasMaternidad(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .Add("@idControlFichaDonacion", SqlDbType.Int).Value = obj.IdControlFichaDonacion
                .Add("@idCerdaDonadora", SqlDbType.Int).Value = obj.Codigo
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

    Public Function Cd_RegistrarMovimientoCriaMaternidad(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .Add("@fControl", SqlDbType.Date).Value = obj.FechaControl
                .Add("@dejarVacia", SqlDbType.VarChar).Value = obj.DejarVaciaoLactando
                .Add("@idCerdaReceptora", SqlDbType.Int).Value = obj.Codigo
                .Add("@listaCerdasDonante", SqlDbType.VarChar).Value = obj.ListaCerdasDonantes
                .Add("@listaIdsCriasDonadas", SqlDbType.VarChar).Value = obj.ListaIdsCriasDonantes
                .Add("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
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

    Public Function Cd_ActualizarEtapaReproduccion(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .Add("@idCerda", SqlDbType.Int).Value = obj.Codigo
                .Add("@etapa", SqlDbType.VarChar).Value = obj.EtapaReproductiva
                .Add("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
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

    Public Function Cd_RegistrarTestCelo(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .Add("@idAnimal", SqlDbType.Int).Value = obj.Codigo
                .Add("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .Add("@observacion", SqlDbType.VarChar).Value = obj.Observacion
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

    Public Function Cd_ConsultarTestCeloPorAnimal(name As String, obj As coControlAnimal) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idAnimal", obj.Codigo)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConfirmarVentaEnvioCamal(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .Add("@idHistorialEnvioCamal", SqlDbType.VarChar).Value = obj.ListaIdsControlFicha
                .Add("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                .Add("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
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

    Public Function Cd_CancelarVentaEnvioCamal(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .Add("@idHistorialEnvioCamal", SqlDbType.Int).Value = obj.IdHistorialEnvioCamal
                .Add("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                .Add("@motivoAnulacion", SqlDbType.VarChar).Value = obj.MotivoAnulacion
                .Add("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
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

    Public Function Cd_ConsultarArchivoMortalidad(name As String, obj As coControlAnimal) As Byte()
        Dim archivo() As Byte = Nothing
        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con) With {
                .CommandType = CommandType.StoredProcedure
            }
            cmd.Parameters.AddWithValue("@idControlFicha", obj.IdControlFichaMortalidad)

            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                archivo = DirectCast(result, Byte())
            End If
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return archivo
    End Function

    Public Function Cd_RegistrarRegularizacionCerdos(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .Add("@fControl", SqlDbType.Date).Value = obj.FechaControl
                .Add("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .Add("@cantidad", SqlDbType.Int).Value = obj.CantidadCrias
                .Add("@idJaulaCorral", SqlDbType.Int).Value = obj.IdJaulaCorral
                .Add("@idTipoIncidencia", SqlDbType.Int).Value = obj.IdMotivoMortalidadCamal
                .Add("@listaCriasRegistradas", SqlDbType.VarChar).Value = obj.ListaCriasRegistrar
                .Add("@cantidadCamborough", SqlDbType.Int).Value = obj.CantidadCamalTatuaje
                .Add("@CantidadEngorde", SqlDbType.Int).Value = obj.CantidadCamalEngorde
                .Add("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .Add("@tipo", SqlDbType.VarChar).Value = obj.TipoControl
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

    Public Function Cd_EliminarEventoCerda(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .Add("@idControlFicha", SqlDbType.Int).Value = obj.IdControlFicha
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

    Public Function Cd_ConsultarVaciasMasMenosSiete(name As String, obj As coControlAnimal) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@filtro", obj.Filtro)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_AnularEnvioCamal(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .Add("@idHistorialEnvioCamal", SqlDbType.Int).Value = obj.IdHistorialEnvioCamal
                .Add("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                .Add("@motivoAnulacion", SqlDbType.VarChar).Value = obj.MotivoAnulacion
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

    Public Function Cd_ConsultarCerdosVentaIncidencia(name As String, obj As coControlAnimal) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.SelectCommand.Parameters.AddWithValue("@idMotivoTransaccion", obj.IdMotivoTransaccion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarControlFichaDs(name As String, obj As coControlAnimal) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idControlFicha", obj.Codigo)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarControlFichaDt(name As String, obj As coControlAnimal) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idControlFicha", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ListarCerdasMaternidadGestacion(name As String, obj As coControlAnimal) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.TipoControl)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_EnvioxIdAnimal(name As String, obj As coControlAnimal) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idAnimal", SqlDbType.Int).Value = obj.Codigo
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

    Public Function Cd_ConsultarFechas(name As String, obj As coControlAnimal) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarxLoteDs(name As String, obj As coControlAnimal) As DataSet
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

    Public Function Cd_GeneralxIdUbicacionArea(name As String, obj As coControlAnimal) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.SelectCommand.Parameters.AddWithValue("@idArea", obj.idArea)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
End Class
