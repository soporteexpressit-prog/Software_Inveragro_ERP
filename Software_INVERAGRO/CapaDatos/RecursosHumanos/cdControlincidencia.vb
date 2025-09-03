Imports System.Data
Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdControlIncidencia
    Private conexion As New cdConexion()
    Public Function ObtenerDatosPorID(idPersona As Integer) As coControlincidencia
        Dim incidencia As New coControlincidencia()
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
                                incidencia.cargo = reader("Cargo").ToString()
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

    Public Function Cd_Consultar(name As String, obj As coControlincidencia) As DataTable
        Dim dt As New DataTable
        Try
            conexion.Abrir()
            Dim da As New SqlDataAdapter(name, conexion.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        conexion.Salir()
        Return dt
    End Function
    Public Function Cd_obtenerArchivo(name As String, idincidente As Integer) As Byte()
        Dim pdfData As Byte() = Nothing
        Try
            conexion.Abrir()
            Dim cmd As New SqlCommand(name, conexion.con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idIncidente", idincidente)

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
    Public Function Cn_Consultaralmacen(name As String, obj As coControlincidencia) As DataSet
        Dim ds As New DataSet()
        Try
            Using connection As SqlConnection = conexion.Abrir()
                Using command As New SqlCommand(name, connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@fecha", obj.FechaDesde)
                    command.Parameters.AddWithValue("@fechahasta", obj.FechaHasta)
                    Using adapter As New SqlDataAdapter(command)
                        adapter.Fill(ds)
                    End Using
                End Using
            End Using
        Catch ex As SqlException
            MessageBox.Show("Error al obtener las incidencias: " & ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error inesperado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Salir()
        End Try

        Return ds
    End Function

    Public Function InsertarIncidenteConCausas(nuevoIncidente As coControlincidencia, Optional listaCausas As List(Of String) = Nothing) As Boolean
        Dim resultado As Boolean = False
        If Not ValidarFechas(nuevoIncidente) Then
            MessageBox.Show("Una o más fechas no son válidas. Deben estar entre 01/01/1753 y 31/12/9999.")
            Return False
        End If
        Using connection As SqlConnection = conexion.Abrir()
            Dim command As New SqlCommand("InsertarIncidente", connection)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@tipoAccidente", nuevoIncidente.TipoDeAccidente)
            command.Parameters.AddWithValue("@idPersona", nuevoIncidente.IdPersona)
            command.Parameters.AddWithValue("@turno", nuevoIncidente.Turno)
            command.Parameters.AddWithValue("@lugarOcurrencia", nuevoIncidente.LugarExacto)
            Dim horasTrabajadasFormatted As String = nuevoIncidente.HorasTrabajadas.ToString("hh\:mm\:ss")
            command.Parameters.AddWithValue("@horasTrabajadas", horasTrabajadasFormatted)
            command.Parameters.AddWithValue("@numHorasTrabajadas", nuevoIncidente.HorasTrabajadas)
            If nuevoIncidente.FechaOcurrencia <> DateTime.MinValue Then
                command.Parameters.AddWithValue("@fechaOcurrencia", nuevoIncidente.FechaOcurrencia)
            Else
                command.Parameters.AddWithValue("@fechaOcurrencia", DBNull.Value)
            End If
            If nuevoIncidente.FechaInicioInv <> DateTime.MinValue Then
                command.Parameters.AddWithValue("@fechaInicioInvestigacion", nuevoIncidente.FechaInicioInv)
            Else
                command.Parameters.AddWithValue("@fechaInicioInvestigacion", DBNull.Value)
            End If
            command.Parameters.AddWithValue("@gravedadAccidente", nuevoIncidente.Gravedad)
            command.Parameters.AddWithValue("@gradoAccidente", nuevoIncidente.Grado)
            command.Parameters.AddWithValue("@numDiasDescanso", nuevoIncidente.NumDias)
            command.Parameters.AddWithValue("@numPersonasAfectadas", nuevoIncidente.NumPersonas)
            command.Parameters.AddWithValue("@descripcionParteLesionada", nuevoIncidente.Descripcion)
            command.Parameters.AddWithValue("@descripcionSuceso", nuevoIncidente.DescripcionClaramente)
            command.Parameters.AddWithValue("@probabilidad", nuevoIncidente.Probabilidad)
            command.Parameters.AddWithValue("@consecuencia", nuevoIncidente.Consecuencia)
            command.Parameters.AddWithValue("@idEncargado", nuevoIncidente.IdEncargado)
            command.Parameters.AddWithValue("@idUsuarioLogueado", nuevoIncidente.IdUsuarioLogueado)
            If listaCausas IsNot Nothing AndAlso listaCausas.Count > 0 Then
                Dim listaCausasString As String = String.Join(",", listaCausas)
                command.Parameters.AddWithValue("@listaCausas", listaCausasString)
            Else
                command.Parameters.AddWithValue("@listaCausas", DBNull.Value)
            End If
            command.Parameters.Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
            command.Parameters.Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            Try
                command.ExecuteNonQuery()
                Dim mensaje As String = command.Parameters("@msj").Value.ToString()
                Dim codError As Integer = Convert.ToInt32(command.Parameters("@coderror").Value)
                If codError = 0 Then
                    resultado = True
                Else
                    MessageBox.Show($"Error en el procedimiento almacenado: {mensaje} (Código: {codError})")
                End If
            Catch ex As SqlException
                Dim errorMessage As String = $"Error SQL: {ex.Message}{vbCrLf}StackTrace: {ex.StackTrace}"
                MessageBox.Show(errorMessage)
                resultado = False
            Catch ex As Exception
                Dim errorMessage As String = $"Error: {ex.Message}{vbCrLf}StackTrace: {ex.StackTrace}"
                MessageBox.Show(errorMessage)
                resultado = False
            End Try
        End Using

        Return resultado
    End Function
    Private Function ValidarFechas(nuevoIncidente As coControlincidencia) As Boolean
        Dim fechaMin As DateTime = New DateTime(1753, 1, 1)
        Dim fechaMax As DateTime = New DateTime(9999, 12, 31)

        If nuevoIncidente.FechaOcurrencia < fechaMin OrElse nuevoIncidente.FechaOcurrencia > fechaMax Then
            MessageBox.Show("La fecha de ocurrencia está fuera del rango permitido.")
            Return False
        End If

        If nuevoIncidente.FechaInicioInv < fechaMin OrElse nuevoIncidente.FechaInicioInv > fechaMax Then
            MessageBox.Show("La fecha de inicio de investigación está fuera del rango permitido.")
            Return False
        End If
        Return True
    End Function
    Public Function ObtenerIncidencias() As DataTable
        Dim dt As New DataTable()
        Using connection As SqlConnection = conexion.Abrir()
            Using command As New SqlCommand("ObtenerIncidencias", connection)
                command.CommandType = CommandType.StoredProcedure
                Try
                    Using reader As SqlDataReader = command.ExecuteReader()
                        dt.Load(reader)
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error al obtener las incidencias: " & ex.Message)
                    conexion.Salir()
                End Try
            End Using
        End Using
        Return dt
    End Function

    Public Function ObtenerConteoAseguradosTrabajadores() As coControlincidencia
        Dim incidencia As New coControlincidencia()

        ' Variables locales para almacenar los datos temporales
        Dim totalTrabajadores As Integer = 0
        Dim noAsegurados As Integer = 0
        Dim asegurados As Integer = 0

        Using connection As SqlConnection = conexion.Abrir()
            Using command As New SqlCommand("JIHFContadorAseguradosTrabajadores", connection)
                command.CommandType = CommandType.StoredProcedure

                Try
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            ' Almacenar en variables locales
                            If Not IsDBNull(reader("TotalPersonasTrabajador")) Then
                                totalTrabajadores = Convert.ToInt32(reader("TotalPersonasTrabajador"))
                            End If
                            If Not IsDBNull(reader("NoAsegurados")) Then
                                noAsegurados = Convert.ToInt32(reader("NoAsegurados"))
                            End If
                            If Not IsDBNull(reader("Asegurados")) Then
                                asegurados = Convert.ToInt32(reader("Asegurados"))
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

        ' Asignar las variables locales a las propiedades del objeto
        incidencia.TotalTrabajadores = totalTrabajadores
        incidencia.NoAsegurados = noAsegurados
        incidencia.Asegurados = asegurados

        Return incidencia
    End Function

    Public Function Cd_ConsultarId(name As String, obj As coControlincidencia) As DataSet
        Dim dt As New DataSet
        Try
            conexion.Abrir()
            Dim da As New SqlDataAdapter(name, conexion.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idIncidente", obj.codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        conexion.Salir()
        Return dt
    End Function
    Public Function Cd_ActualizarArchivo(name As String, obj As coControlincidencia) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, conexion.con)
        Try
            conexion.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idIncidente", SqlDbType.Int).Value = obj.codigo
                If obj.Archivo IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.Archivo
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

    Public Function Cn_ConsultarFechas(name As String, obj As coControlincidencia) As DataSet
        Dim ds As New DataSet()
        Try
            Using connection As SqlConnection = conexion.Abrir()
                Using command As New SqlCommand(name, connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@fechaDesde", obj.FechaDesde)
                    command.Parameters.AddWithValue("@fechaHasta", obj.FechaHasta)
                    Using adapter As New SqlDataAdapter(command)
                        adapter.Fill(ds)
                    End Using
                End Using
            End Using
        Catch ex As SqlException
            MessageBox.Show("Error al obtener las incidencias: " & ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error inesperado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Salir()
        End Try

        Return ds
    End Function
End Class
