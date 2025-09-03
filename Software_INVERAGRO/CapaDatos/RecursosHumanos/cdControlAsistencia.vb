

Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdControlAsistencia
    Private con As New cdConexion
    Public Function Cd_ListarTrabajadores(name As String, obj As coControlAsistencia) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add(New SqlParameter("@idHorario", obj.idHorario))
            da.SelectCommand.Parameters.Add(New SqlParameter("@Mes", obj.Mes))
            da.SelectCommand.Parameters.Add(New SqlParameter("@Anio", obj.Anio))
            da.SelectCommand.Parameters.Add(New SqlParameter("@IdUbicacion", obj.IdUbicacion))
            da.SelectCommand.Parameters.Add(New SqlParameter("@TipoQuincena", obj.TipoQuincena))
            da.SelectCommand.Parameters.Add(New SqlParameter("@TipoRegistro", obj.Tipo))

            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_Mantenimiento(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@ultimoDiaReg", SqlDbType.Int).Value = obj.UltimoDiaReg
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .Add("@idHorario", SqlDbType.Int).Direction = ParameterDirection.Output
                .AddWithValue("@lista_Asistencias", SqlDbType.VarChar).Value = obj.Lista_Asistencias
                .AddWithValue("@lista_Asistencias_Eventuales", If(String.IsNullOrEmpty(obj.Lista_Asistencias_Eventuales), DBNull.Value, obj.Lista_Asistencias_Eventuales))
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .AddWithValue("@tipoPeriodo", If(String.IsNullOrEmpty(obj.Tipoperiodo), DBNull.Value, obj.Tipoperiodo))
                .AddWithValue("@mes", SqlDbType.Int).Value = obj.Mes
                .AddWithValue("@anio", SqlDbType.Int).Value = obj.Anio
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@codeError", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@codeError").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_ObtenerDatosTrabajadorPorDNI(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@lista_NumDocumentos", SqlDbType.VarChar).Value = obj.Lista_NumDocumentos
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    If Not IsDBNull(reader("datos")) Then
                        obj.Datos = reader("datos").ToString()
                    End If
                End If
            End Using
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_ListarPlanteles(name As String) As DataTable
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

    Public Function Cd_ListarAñosDeHorarios(name As String) As DataTable
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

    Public Function Cd_ConsultarAsistencia(name As String, obj As coControlAsistencia) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@Mes", If(obj.Mes.HasValue, obj.Mes.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@Anio", obj.Anio)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ActualizarEstadoAsistencia(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cd_ActualizarEnviadoAsistencia(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_ActualizarObservadoAsistencia(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_CancelarAprobacionAsistencia(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_ConsultarAsistenciaExistente(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
                .AddWithValue("@Mes", SqlDbType.Int).Value = obj.Mes
                .AddWithValue("@Anio", SqlDbType.Int).Value = obj.Anio
                .AddWithValue("@Dia", SqlDbType.Int).Value = obj.Dia
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cd_ListarAsistenciaPorHorario(name As String, obj As coControlAsistencia) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add(New SqlParameter("@idHorario", obj.idHorario))
            da.SelectCommand.Parameters.Add(New SqlParameter("@Mes", obj.Mes))
            da.SelectCommand.Parameters.Add(New SqlParameter("@Anio", obj.Anio))
            da.SelectCommand.Parameters.Add(New SqlParameter("@IdUbicacion", obj.IdUbicacion))
            da.SelectCommand.Parameters.Add(New SqlParameter("@tipoRegistro", obj.Tipo))

            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_ActualizarAsistencia(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@lista_Asistencias", SqlDbType.VarChar).Value = obj.Lista_Asistencias
                .AddWithValue("@idHorario", SqlDbType.Int).Value = obj.idHorario
                .AddWithValue("@ultimoDiaReg", If(obj.UltimoDiaRegEventual.HasValue, obj.UltimoDiaRegEventual.Value, DBNull.Value))
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@codeError", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@codeError").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cd_ObtenerUltimoDiaRegistroAsistencia(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
                .AddWithValue("@mes", SqlDbType.Int).Value = obj.Mes
                .AddWithValue("@anio", SqlDbType.Int).Value = obj.Anio
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .AddWithValue("@idHorario", SqlDbType.Int).Value = If(obj.idHorario.HasValue, obj.idHorario.Value, DBNull.Value)
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    If Not IsDBNull(reader("UltimoDiaConRegistro")) Then
                        obj.UltimoDiaReg = reader("UltimoDiaConRegistro")
                    End If
                End If
            End Using
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cd_ListarTrabajadoresPorPlanillaEventual(name As String, ByRef tipoTrabajador As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add(New SqlParameter("@tipo_trabajador", tipoTrabajador))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function
    Public Function Cd_ActualizarEstadoEnviadoSemanalAsistencia(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cd_ConsAsistenciaExistenteEventual(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
                .AddWithValue("@Mes", SqlDbType.Int).Value = obj.Mes
                .AddWithValue("@Anio", SqlDbType.Int).Value = obj.Anio
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cd_EnviarPagoAsistencias(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idHorario", SqlDbType.Int).Value = obj.idHorario
                .AddWithValue("@fInicio", SqlDbType.DateTime).Value = obj.FechaInicio
                .AddWithValue("@fFin", SqlDbType.DateTime).Value = obj.FechaFin
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
                .AddWithValue("@tipoPeriodo", SqlDbType.VarChar).Value = obj.Tipoperiodo
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_AnularAsistencia(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.idHorario
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.observacion
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_Anularenviocuentas(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.idHorario
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.observacion
                .AddWithValue("@idusuario", SqlDbType.Int).Value = obj.IdUsuario
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_AplicarVacacionesPorTrabajadorAsistencia(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("dni", SqlDbType.VarChar).Value = obj.NumDocumento
                .AddWithValue("anio", SqlDbType.Int).Value = obj.Anio
                .AddWithValue("mes", SqlDbType.Int).Value = obj.Mes
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    If Not IsDBNull(reader("DNI")) Then
                        obj.NumDocumento = reader("DNI").ToString()
                    End If
                    If Not IsDBNull(reader("DiaInicio")) Then
                        obj.DiaInicio = reader("DiaInicio")
                    End If
                    If Not IsDBNull(reader("DiaFin")) Then
                        obj.DiaFin = reader("DiaFin")
                    End If
                End If
            End Using
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_EliminarTrabajadorAsistencia(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@dni", SqlDbType.VarChar).Value = obj.NumDocumento
                .AddWithValue("@idHorario", SqlDbType.Int).Value = obj.idHorario
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@codeError", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@codeError").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_ConsOperariosAsistencia(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
                .AddWithValue("@anio", SqlDbType.Int).Value = obj.Anio
                .AddWithValue("@mes", SqlDbType.Int).Value = obj.Mes
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    If Not IsDBNull(reader("TipoPeriodo")) Then
                        obj.Tipoperiodo = reader("TipoPeriodo")
                    End If
                End If
            End Using
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_InvalidarAsistencia(name As String, obj As coControlAsistencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.idHorario
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.CodeError = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_ReportePagosPorPlantel(name As String, obj As coControlAsistencia) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@mes", If(obj.Mes.HasValue, obj.Mes.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.Anio)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.Tipo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ReporteAsistenciaTrabajadoresPorPlantel(name As String, obj As coControlAsistencia) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@mes", If(obj.Mes.HasValue, obj.Mes.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.Anio)
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", obj.IdUbicacion)
            da.SelectCommand.Parameters.AddWithValue("@tipo", obj.Tipo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
End Class

