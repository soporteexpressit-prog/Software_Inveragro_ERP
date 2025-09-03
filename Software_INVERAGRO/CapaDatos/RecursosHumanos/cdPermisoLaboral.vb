Imports System.Data.SqlClient
Imports CapaObjetos
Public Class cdPermisoLaboral
    Private conexion As New cdConexion()
    Public Function ObtenerDatosPorID(idPersona As Integer) As coPermisoLaboral
        Dim incidencia As New coPermisoLaboral()
        Using connection As SqlConnection = conexion.Abrir()
            Using command As New SqlCommand("ObtenerDatosPersona", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@idPersona", idPersona)
                Try
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            If Not IsDBNull(reader("DatosPersona")) Then
                                incidencia.NombrePersona = reader("DatosPersona").ToString()
                            End If
                            If Not IsDBNull(reader("numDocumento")) Then
                                incidencia.DNI = reader("numDocumento").ToString()
                            End If
                            If Not IsDBNull(reader("Edad")) Then
                                incidencia.Edad = Convert.ToInt32(reader("Edad"))
                            End If
                            If Not IsDBNull(reader("sexo")) Then
                                incidencia.Sexo = reader("sexo").ToString()
                            End If
                            If Not IsDBNull(reader("DatosAseguradora")) Then
                                incidencia.NombreAseguradora = reader("DatosAseguradora").ToString()
                            End If
                            If Not IsDBNull(reader("Area")) Then
                                incidencia.Area = reader("Area").ToString()
                            End If
                            If Not IsDBNull(reader("Cargo")) Then
                                incidencia.Cargo = reader("Cargo").ToString()
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error al obtener datos: " & ex.Message)
                Finally
                    conexion.Salir()
                End Try
            End Using
        End Using
        Return incidencia
    End Function

    Public Function ObtenerDatosPorIDpermiso(idPersona As Integer) As coPermisoLaboral
        Dim incidencia As New coPermisoLaboral()
        Using connection As SqlConnection = conexion.Abrir()
            Using command As New SqlCommand("[j_ObtenerDatosPersona_permiso]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@idPersona", idPersona)
                Try
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            If Not IsDBNull(reader("DatosPersona")) Then
                                incidencia.NombrePersona = reader("DatosPersona").ToString()
                            End If
                            If Not IsDBNull(reader("numDocumento")) Then
                                incidencia.DNI = reader("numDocumento").ToString()
                            End If
                            If Not IsDBNull(reader("Edad")) Then
                                incidencia.Edad = Convert.ToInt32(reader("Edad"))
                            End If
                            If Not IsDBNull(reader("sexo")) Then
                                incidencia.Sexo = reader("sexo").ToString()
                            End If
                            If Not IsDBNull(reader("DatosAseguradora")) Then
                                incidencia.NombreAseguradora = reader("DatosAseguradora").ToString()
                            End If
                            If Not IsDBNull(reader("Area")) Then
                                incidencia.Area = reader("Area").ToString()
                            End If
                            If Not IsDBNull(reader("Cargo")) Then
                                incidencia.Cargo = reader("Cargo").ToString()
                            End If
                            If Not IsDBNull(reader("DiasPendientes")) Then
                                incidencia.DiasPendientes = Convert.ToInt32(reader("DiasPendientes"))
                            End If
                            If Not IsDBNull(reader("idauditoria")) Then
                                incidencia.idauditoria = Convert.ToInt32(reader("idauditoria"))
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error al obtener datos: " & ex.Message)
                Finally
                    conexion.Salir()
                End Try
            End Using
        End Using
        Return incidencia
    End Function

    Public Function InsertarPermisoLaboral(permiso As coPermisoLaboral) As (success As Boolean, message As String)
        Dim mensaje As String = ""
        Using connection As SqlConnection = conexion.Abrir()
            Using command As New SqlCommand("JIHFInsertarPermisoLaboral", connection)
                command.CommandType = CommandType.StoredProcedure

                ' Agregar parámetros básicos
                command.Parameters.Add("@operacion", SqlDbType.Int).Value = permiso.operacion
                command.Parameters.Add("@idPersona", SqlDbType.Int).Value = permiso.IdPersona
                command.Parameters.Add("@idPermisoLaboral", SqlDbType.Int).Value = permiso.idpermisolaboral
                command.Parameters.Add("@tipoPermisoLaboral", SqlDbType.Int).Value = permiso.TipoPermiso
                command.Parameters.Add("@fechaInicio", SqlDbType.Date).Value = permiso.FechaInicio
                command.Parameters.Add("@fechaFin", SqlDbType.Date).Value = permiso.FechaFin
                command.Parameters.Add("@nroDiasDescanso", SqlDbType.Int).Value = permiso.NumDias
                command.Parameters.Add("@idauditoria", SqlDbType.Int).Value = permiso.idauditoria
                command.Parameters.Add("@ventaV", SqlDbType.VarChar).Value = permiso.ventaV
                command.Parameters.Add("@adelantoDias", SqlDbType.Bit).Value = permiso.adelantoDias
                command.Parameters.Add("@descripcionPermiso", SqlDbType.VarChar).Value = If(permiso.Descripcion, DBNull.Value)

                ' Archivo PDF
                If permiso.docPaternidad IsNot Nothing Then
                    command.Parameters.Add("@docPaternidad", SqlDbType.VarBinary).Value = permiso.docPaternidad
                Else
                    command.Parameters.Add("@docPaternidad", SqlDbType.VarBinary).Value = DBNull.Value
                End If

                ' Parámetros de salida
                Dim paramMensaje As SqlParameter = command.Parameters.Add("@mensaje", SqlDbType.VarChar, 500)
                paramMensaje.Direction = ParameterDirection.Output
                Dim paramCodError As SqlParameter = command.Parameters.Add("@codError", SqlDbType.Int)
                paramCodError.Direction = ParameterDirection.Output

                Try
                    command.ExecuteNonQuery()
                    Dim codError As Integer = Convert.ToInt32(paramCodError.Value)
                    mensaje = paramMensaje.Value.ToString()
                    Return (codError = 0, mensaje)
                Catch ex As Exception
                    Return (False, "Error al insertar permiso laboral: " & ex.Message)
                End Try
            End Using
        End Using
    End Function

    Public Function Cd_Consultar(name As String, obj As coPermisoLaboral) As DataTable
        Dim dt As New DataTable
        Try
            conexion.Abrir()
            Dim da As New SqlDataAdapter(name, conexion.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaInicio)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaFin)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        conexion.Salir()
        Return dt
    End Function

    Public Function CancelarPermisoLaboral(permiso As coPermisoLaboral) As (success As Boolean, message As String)
        Dim mensaje As String = ""
        Using connection As SqlConnection = conexion.Abrir()
            Using command As New SqlCommand("JIHFCancelarPermisoLaboral", connection)
                command.CommandType = CommandType.StoredProcedure

                ' Agregar parámetros
                command.Parameters.Add("@idPermisoLaboral", SqlDbType.Int).Value = permiso.idpermisolaboral

                ' Parámetros de salida
                Dim paramMensaje As SqlParameter = command.Parameters.Add("@mensaje", SqlDbType.VarChar, 500)
                paramMensaje.Direction = ParameterDirection.Output
                Dim paramCodError As SqlParameter = command.Parameters.Add("@codError", SqlDbType.Int)
                paramCodError.Direction = ParameterDirection.Output

                Try
                    command.ExecuteNonQuery()
                    Dim codError As Integer = Convert.ToInt32(paramCodError.Value)
                    mensaje = paramMensaje.Value.ToString()
                    Return (codError = 0, mensaje)
                Catch ex As Exception
                    Return (False, "Error al cancelar permiso laboral: " & ex.Message)
                End Try
            End Using
        End Using
    End Function


    Public Function Cd_ActualizarArchivo(name As String, obj As coPermisoLaboral) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, conexion.con)
        Try
            conexion.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idpermiso", SqlDbType.Int).Value = obj.codigo
                If obj.docPaternidad IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.docPaternidad
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With

            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)
            conexion.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cd_obtenerArchivo(name As String, idpermiso As Integer) As Byte()
        Dim pdfData As Byte() = Nothing
        Try
            conexion.Abrir()
            Dim cmd As New SqlCommand(name, conexion.con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idPermiso", idpermiso)

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
            conexion.Salir()
        End Try

        Return pdfData
    End Function
    Public Function Cd_Consultarconceptos(name As String, obj As coPermisoLaboral) As DataTable
        Dim dt As New DataTable
        Try
            conexion.Abrir()
            Dim da As New SqlDataAdapter(name, conexion.con)
            da.SelectCommand.CommandType = 4
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        conexion.Salir()
        Return dt
    End Function

    Public Function Cd_Consultarpermisoporid(name As String, obj As coPermisoLaboral) As DataTable
        Dim dt As New DataTable
        Try
            conexion.Abrir()
            Dim cmd As New SqlCommand(name, conexion.con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idpermisolaboral", obj.idpermisolaboral)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            conexion.Salir()
        End Try
        Return dt
    End Function



    Public Function Cd_Agregamosconcepto(name As String, obj As coPermisoLaboral) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, conexion.con)
        Try
            conexion.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.operacion
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.codigo
                .AddWithValue("@nombre", SqlDbType.VarChar).Value = obj.Descripcion
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.Coderror = cmd.Parameters("@coderror").Value.ToString
            conexion.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
