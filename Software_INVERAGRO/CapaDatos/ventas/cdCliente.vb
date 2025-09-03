Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdCliente
    Private con As New cdConexion

    Public Function Cd_Mantenimiento(name As String, obj As coCliente) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@idPersona", SqlDbType.Int).Value = obj.IdPersona
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .AddWithValue("@numDocumento", SqlDbType.VarChar).Value = obj.NumDocumento
                .AddWithValue("@datos", SqlDbType.VarChar).Value = obj.Datos
                .AddWithValue("@direccion", SqlDbType.VarChar).Value = obj.Direccion
                .AddWithValue("@celular", SqlDbType.VarChar).Value = obj.Celular
                .AddWithValue("@correo", SqlDbType.Char).Value = obj.Correo
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
                .AddWithValue("@idTipoDocIdentidad", SqlDbType.Int).Value = obj.IdTipoDocIdentidad
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
                .AddWithValue("@idDistrito", SqlDbType.Int).Value = obj.IdDistrito
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
    Public Function Cd_ConsultarxCodigo(name As String, obj As coCliente) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idpersona", SqlDbType.Int).Value = obj.IdPersona
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ListarTipoDocIdentidad(name As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_Consultar(name As String, obj As coCliente) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@valor", SqlDbType.VarChar).Value = obj.Datos
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarxCodigoUbicacion(name As String, obj As coCliente) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idpersona", SqlDbType.Int).Value = obj.IdPersona
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function CargarDepartamentos(name As String) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            'da.SelectCommand.Parameters.AddWithValue("@valor", SqlDbType.VarChar).Value = ""
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function CargarProvincias(name As String, departamentoId As Integer) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@departamentoId", departamentoId)
            da.SelectCommand.Parameters.AddWithValue("@provinciaId", DBNull.Value)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Function CargarDistritos(idProvincia As Integer) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Using cmd As New SqlCommand("JIHFCargarDatosProvinciaDistrito", con.con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@departamentoId", DBNull.Value)
                cmd.Parameters.AddWithValue("@provinciaId", idProvincia)
                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function


    Public Function EjecutarConsulta(cmd As SqlCommand) As DataTable
        Dim dt As New DataTable()
        Try
            con.Abrir()
            cmd.Connection = con.con
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function

    Public Sub Cd_ConvertirProveedor(idPersona As Integer, ByRef mensaje As SqlParameter)
        Try
            con.Abrir()
            Dim cmd As New SqlCommand("JIHF_Convertir_a_Proveedor", con.con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idPersona", idPersona)
            cmd.Parameters.Add(mensaje) ' Añade el parámetro de salida
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
    End Sub
    Public Sub Cd_ConvertirTrabajador(idPersona As Integer, ByRef mensaje As SqlParameter)
        Try
            con.Abrir()
            Dim cmd As New SqlCommand("JIHF_Convertir_a_Trabajador", con.con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idPersona", idPersona)
            cmd.Parameters.Add(mensaje) ' Añade el parámetro de salida

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
    End Sub

    Public Function Cd_ConsUbicacionPorUbigeo(name As String, obj As coCliente) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@ubigeo", SqlDbType.VarChar).Value = obj.Ubigeo
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@coderror", SqlDbType.Int).Direction = 2
            End With
            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    If Not IsDBNull(reader("distrito")) Then
                        obj.Distrito = reader("distrito").ToString()
                    End If
                    If Not IsDBNull(reader("provincia")) Then
                        obj.Provincia = reader("provincia")
                    End If
                    If Not IsDBNull(reader("departamento")) Then
                        obj.Departamento = reader("departamento")
                    End If
                End If
            End Using
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.Coderror = cmd.Parameters("@coderror").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
