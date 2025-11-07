Imports CapaObjetos
Imports System.Data.SqlClient

Public Class cdControlMedico
    Private con As New cdConexion

    Public Function Cd_RegistrarTratamiento(name As String, obj As coControlMedico) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@modoAplicacion", SqlDbType.VarChar).Value = obj.ModoAplicacion
                .AddWithValue("@fechaControl", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@listaDestinadoCerdoLote", SqlDbType.VarChar).Value = obj.ListaDestinadoCerdoLote
                .AddWithValue("@idResponsable", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idGalpon", SqlDbType.Int).Value = obj.IdGalpon
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                .AddWithValue("@diasTratamiento", SqlDbType.Int).Value = obj.Duracion
                .AddWithValue("@idEnfermedad", SqlDbType.Int).Value = obj.IdEnfermedad
                .AddWithValue("@idMedicamento", SqlDbType.Int).Value = obj.IdMedicamento
                .AddWithValue("@via", SqlDbType.VarChar).Value = obj.Via
                .AddWithValue("@dosis", SqlDbType.Decimal).Value = obj.Dosis
                .AddWithValue("@cantDiaria", SqlDbType.Decimal).Value = obj.CantDiaria
                .AddWithValue("@totalAnimales", SqlDbType.Int).Value = obj.CantAnimales
                .AddWithValue("@idConversion", SqlDbType.Int).Value = obj.IdConversion
                .AddWithValue("@cantidadUnidadOrigen", SqlDbType.Int).Value = obj.CantidadOrigen
                .AddWithValue("@idArea", SqlDbType.Int).Value = obj.IdArea
                .AddWithValue("@numSemana", SqlDbType.Int).Value = obj.NumSemana
                .AddWithValue("@fechaInicio", SqlDbType.Date).Value = obj.FechaInicio
                .AddWithValue("@fechaFin", SqlDbType.Date).Value = obj.FechaFin
                .AddWithValue("@numTratados", SqlDbType.Int).Value = obj.Afectados
                .AddWithValue("@mlAnimal", SqlDbType.Decimal).Value = obj.MlAnimal
                .AddWithValue("@gestacionIndividual", SqlDbType.Int).Value = obj.GestacionIndividual
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

    Public Function Cd_RegistrarVacunacion(name As String, obj As coControlMedico) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@modoAplicacion", SqlDbType.VarChar).Value = obj.ModoAplicacion
                .AddWithValue("@idLote", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@fechaControl", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@nota", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@cantidad", SqlDbType.Int).Value = obj.Afectados
                .AddWithValue("@idResponsable", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdPlantel
                .AddWithValue("@codVacuna", SqlDbType.VarChar).Value = obj.CodVacuna
                .AddWithValue("@fVencimientoVacuna", SqlDbType.Date).Value = obj.FVencimientoVacuna
                .AddWithValue("@numAplicacion", SqlDbType.Int).Value = obj.NumAplicacion
                .AddWithValue("@idMedicamento", SqlDbType.Int).Value = obj.IdMedicamento
                .AddWithValue("@idEnfermedad", SqlDbType.Int).Value = obj.IdEnfermedad
                .AddWithValue("@via", SqlDbType.VarChar).Value = obj.Via
                .AddWithValue("@idConversion", SqlDbType.Int).Value = obj.IdConversion
                .AddWithValue("@cantidadUnidadOrigen", SqlDbType.Int).Value = obj.CantidadOrigen
                .AddWithValue("@idArea", SqlDbType.Int).Value = obj.IdArea
                .AddWithValue("@numSemana", SqlDbType.Int).Value = obj.NumSemana
                .AddWithValue("@fechaInicio", SqlDbType.Date).Value = obj.FechaInicio
                .AddWithValue("@fechaFin", SqlDbType.Date).Value = obj.FechaFin
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

    Public Function Cd_ConsultarMedicacion(name As String, obj As coControlMedico) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaInicio)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaFin)
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.ModoAplicacion)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdPlantel)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarRegistrosMedicamentoProgramado(name As String, obj As coControlMedico) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idControlFicha", obj.IdControlMedico)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_CancelarMedicacion(name As String, obj As coControlMedico) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idControlFicha", SqlDbType.Int).Value = obj.IdControlFicha
                .AddWithValue("@motivoAnulacion", SqlDbType.VarChar).Value = obj.MotivoAnulacion
                .AddWithValue("idUsuario", SqlDbType.Int).Value = obj.IdUsuario
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

    Public Function Cd_ConsultarMedicacionxLote(name As String, obj As coControlMedico) As DataSet
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

    Public Function Cd_RegistrarProtocoloSanidad(name As String, obj As coControlMedico) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@fControl", SqlDbType.Date).Value = obj.FechaControl
                .AddWithValue("@nota", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
                .AddWithValue("@idArea", SqlDbType.Int).Value = obj.IdArea
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@listaDetalleHistorialProtocolo", SqlDbType.VarChar).Value = obj.ListaMedicamentoEnfermedad
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

    Public Function Cd_ConsultaPlanSanitario(name As String, obj As coControlMedico) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.Anio)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarProtocoloSanitarioxId(name As String, obj As coControlMedico) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idProtocoloSanitario", obj.Codigo)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarMedicamentoxId(name As String, obj As coControlMedico) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idProducto", obj.IdMedicamento)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_MantenimientoHistoricoEnfermedades(name As String, obj As coControlMedico) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .Add("@idEnfermedad", SqlDbType.Int).Value = obj.IdEnfermedad
                .Add("@fControl", SqlDbType.Date).Value = obj.FechaControl
                .Add("@metodo", SqlDbType.VarChar, 200).Value = obj.Observacion
                .Add("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .Add("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
                .Add("@costoPrograma", SqlDbType.Money).Value = obj.CostoPrograma
                .Add("@idArea", SqlDbType.Int).Value = obj.IdArea
                .Add("@operacion", SqlDbType.Int).Value = obj.Operacion
                .Add("@codigo", SqlDbType.Int).Value = obj.Codigo
                If obj.Archivo IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary, -1).Value = obj.Archivo
                Else
                    .Add("@archivo", SqlDbType.VarBinary, -1).Value = DBNull.Value
                End If
                .Add("@nombreVacunaComercial", SqlDbType.VarChar, 50).Value = obj.NombreVacunaComercial
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
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

    Public Function Cd_RegistrarAnalisis(name As String, obj As coControlMedico) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .Add("@idProtocoloSanitario", SqlDbType.Int).Value = obj.Codigo
                .Add("@fRegistro", SqlDbType.Date).Value = obj.FechaControl
                .Add("@observacion", SqlDbType.VarChar, 200).Value = obj.Observacion
                If obj.Archivo IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary, -1).Value = obj.Archivo
                Else
                    .Add("@archivo", SqlDbType.VarBinary, -1).Value = DBNull.Value
                End If
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
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

    Public Function Cd_ObtenerArchivoAnalisis(name As String, obj As coControlMedico) As String
        Dim mensaje As String = String.Empty
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                ' Parámetro de entrada
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo

                ' Parámetro de salida para el archivo, especificando el tamaño (-1 para VARBINARY(MAX))
                .Add("@archivo", SqlDbType.VarBinary, -1).Direction = ParameterDirection.Output
            End With

            ' Ejecutar el procedimiento almacenado
            cmd.ExecuteNonQuery()

            ' Verificar si el valor de archivo es NULL o tiene contenido
            If IsDBNull(cmd.Parameters("@archivo").Value) Then
                obj.Archivo = Nothing
            Else
                obj.Archivo = CType(cmd.Parameters("@archivo").Value, Byte())
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

    Public Function Cd_ObtenerArchivoRegistroPrincipal(name As String, obj As coControlMedico) As String
        Dim mensaje As String = String.Empty
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                ' Parámetro de entrada
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo

                ' Parámetro de salida para el archivo, especificando el tamaño (-1 para VARBINARY(MAX))
                .Add("@archivo", SqlDbType.VarBinary, -1).Direction = ParameterDirection.Output
            End With

            ' Ejecutar el procedimiento almacenado
            cmd.ExecuteNonQuery()

            ' Verificar si el valor de archivo es NULL o tiene contenido
            If IsDBNull(cmd.Parameters("@archivo").Value) Then
                obj.Archivo = Nothing
            Else
                obj.Archivo = CType(cmd.Parameters("@archivo").Value, Byte())
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

    Public Function Cd_ConsultarHistorialEnfermedad(name As String, obj As coControlMedico) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaInicio)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaFin)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_ConsultarLotesSanidad(name As String, obj As coControlMedico) As DataTable
        Dim ds As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idCampaña", obj.Codigo)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_CronogramaVacEngorde(name As String, obj As coControlMedico) As DataTable
        Dim ds As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idCampaña", obj.Codigo)
            da.SelectCommand.Parameters.AddWithValue("@idLote", obj.IdLote)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function

    Public Function Cd_CronogramaVacGestacion(name As String, obj As coControlMedico) As DataTable
        Dim ds As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaInicio)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaFin)
            da.SelectCommand.Parameters.AddWithValue("@numSemana", obj.NumSemana)
            da.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return ds
    End Function
End Class
