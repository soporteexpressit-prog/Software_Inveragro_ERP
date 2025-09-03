Imports System.Data.SqlClient
Imports CapaObjetos
Public Class cdTrabjador
    Private con As New cdConexion
    'REGISTRAR  / MODIFICAR / ELIMINAR
    Public Function Cd_Mantenimiento(name As String, obj As coTrabajador) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                ' Persona
                .Add("@operacion", SqlDbType.Int).Value = obj.Operacion
                .Add("@idPersona", SqlDbType.Int).Value = obj.IdPersona
                .Add("@idcargo", SqlDbType.Int).Value = obj.idCargosistena
                .Add("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .Add("@numDocumento", SqlDbType.VarChar).Value = obj.NumDocumento
                .Add("@datos", SqlDbType.VarChar).Value = obj.Datos
                .Add("@apaterno", SqlDbType.VarChar).Value = obj.apaterno
                .Add("@amaterno", SqlDbType.VarChar).Value = obj.amaterno
                .Add("@sexo", SqlDbType.VarChar).Value = obj.Sexo
                .Add("@estadoCivil", SqlDbType.VarChar).Value = obj.EstadoCivil
                .Add("@fNacimiento", SqlDbType.DateTime).Value = obj.FNacimiento
                .Add("@direccion", SqlDbType.VarChar).Value = obj.Direccion
                .Add("@celular", SqlDbType.VarChar).Value = obj.Celular
                .Add("@sinpagoextra", SqlDbType.VarChar).Value = obj.sinpagoextra
                .Add("@correo", SqlDbType.Char).Value = obj.Correo
                .Add("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .Add("@estado", SqlDbType.VarChar).Value = obj.Estado
                .Add("@archivoFoto", SqlDbType.VarBinary).Value = If(obj.ArchivoFoto Is Nothing, DBNull.Value, obj.ArchivoFoto)
                .Add("@archivoFirma", SqlDbType.VarBinary).Value = If(obj.ArchivoFirma Is Nothing, DBNull.Value, obj.ArchivoFirma)
                .Add("@idTipoDocIdentidad", SqlDbType.Int).Value = obj.IdTipoDocIdentidad
                .Add("@ListaNegra", SqlDbType.Bit).Value = obj.ListaNegra

                .Add("@asignacionfamiliar", SqlDbType.VarChar).Value = obj.Asignacionfamiliar
                .Add("@Personalconfianza", SqlDbType.Bit).Value = obj.Personaconfianza
                .Add("@idDistrito", SqlDbType.Int).Value = obj.IdDistrito
                'Lista Hijos
                .AddWithValue("@listaHijos", SqlDbType.VarChar).Value = obj.lista_vinculofamiliar
                .Add("@msj", SqlDbType.VarChar, 700).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
                'Listacodsunat
                .AddWithValue("@lista_cods_sunat", SqlDbType.VarChar).Value = obj.Lista_Cods_Sunat
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)
            con.Salir()
            Return mensaje
        Catch ex As Exception
            con.Salir()
            Throw ex
        End Try
    End Function

    Public Function Cd_Mantenimientoconductor(name As String, obj As coTrabajador) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                ' Persona
                .Add("@operacion", SqlDbType.Int).Value = obj.Operacion
                .Add("@idPersona", SqlDbType.Int).Value = obj.IdPersona
                .Add("@idcargo", SqlDbType.Int).Value = obj.idCargosistena
                .Add("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .Add("@numDocumento", SqlDbType.VarChar).Value = obj.NumDocumento
                .Add("@datos", SqlDbType.VarChar).Value = obj.Datos
                .Add("@apaterno", SqlDbType.VarChar).Value = obj.apaterno
                .Add("@amaterno", SqlDbType.VarChar).Value = obj.amaterno
                .Add("@sexo", SqlDbType.VarChar).Value = obj.Sexo
                .Add("@estadoCivil", SqlDbType.VarChar).Value = obj.EstadoCivil
                .Add("@fNacimiento", SqlDbType.DateTime).Value = obj.FNacimiento
                .Add("@direccion", SqlDbType.VarChar).Value = obj.Direccion
                .Add("@celular", SqlDbType.VarChar).Value = obj.Celular
                .Add("@correo", SqlDbType.Char).Value = obj.Correo
                .Add("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .Add("@estado", SqlDbType.VarChar).Value = obj.Estado
                .Add("@archivoFoto", SqlDbType.VarBinary).Value = If(obj.ArchivoFoto Is Nothing, DBNull.Value, obj.ArchivoFoto)
                .Add("@archivoFirma", SqlDbType.VarBinary).Value = If(obj.ArchivoFirma Is Nothing, DBNull.Value, obj.ArchivoFirma)
                .Add("@idTipoDocIdentidad", SqlDbType.Int).Value = obj.IdTipoDocIdentidad
                .Add("@ListaNegra", SqlDbType.Bit).Value = obj.ListaNegra

                .Add("@asignacionfamiliar", SqlDbType.VarChar).Value = obj.Asignacionfamiliar
                .Add("@Personalconfianza", SqlDbType.Bit).Value = obj.Personaconfianza
                .Add("@idDistrito", SqlDbType.Int).Value = obj.IdDistrito
                'Lista Hijos
                .AddWithValue("@listaHijos", SqlDbType.VarChar).Value = obj.lista_vinculofamiliar
                .Add("@msj", SqlDbType.VarChar, 700).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
                'Listacodsunat
                .AddWithValue("@lista_cods_sunat", SqlDbType.VarChar).Value = obj.Lista_Cods_Sunat
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)
            con.Salir()
            Return mensaje
        Catch ex As Exception
            con.Salir()
            Throw ex
        End Try
    End Function


    Public Function Cd_MantenimientoContrato(name As String, obj As coTrabajador) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                ' Persona
                .Add("@operacion", SqlDbType.Int).Value = obj.Operacion
                .Add("@idPersona", SqlDbType.Int).Value = obj.IdPersona
                .Add("@idcontrato", SqlDbType.Int).Value = obj.idcontrato
                .Add("@CUSPP", SqlDbType.VarChar).Value = If(String.IsNullOrEmpty(obj.CUSSP), DBNull.Value, obj.CUSSP)
                .Add("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .Add("@estado", SqlDbType.VarChar).Value = obj.EstadoContrato
                '' Contrato
                .Add("@fIngreso", SqlDbType.DateTime).Value = obj.FechaIngreso
                .Add("@fFincontrato", SqlDbType.DateTime).Value = obj.FechaFinContrato
                .Add("@Tipocontrato", SqlDbType.Int).Value = obj.Idtiporegistrosunat
                .Add("@remuneracion", SqlDbType.Money).Value = If(obj.Remuneracion = 0, DBNull.Value, obj.Remuneracion)
                .Add("@idtipocargoocupacional", SqlDbType.Int).Value = obj.IdCargoocupacional
                .Add("@idTipoSegurosocial", SqlDbType.Int).Value = obj.idSeguroSocial
                .Add("@idRegimenLaboral", SqlDbType.Int).Value = obj.idRegimenLaboral
                .Add("@idRegimenPnnsionario", SqlDbType.Int).Value = obj.idRegimenPnnsionario
                .Add("@fRegimenpensionario", SqlDbType.DateTime).Value = obj.FechaRegPensionario
                .Add("@fSeguroSocial", SqlDbType.DateTime).Value = obj.FechaSeguroSocial

                ' Cuenta Trabajador SUELDO BASE
                .Add("@nrocuentabase", SqlDbType.VarChar).Value = If(String.IsNullOrEmpty(obj.NroCuenta), DBNull.Value, obj.NroCuenta)
                .Add("@tipocuentaBase", SqlDbType.VarChar).Value = obj.Tipocuenta
                .Add("@FormaDePagoBase", SqlDbType.Int).Value = obj.idFormadePago
                .Add("@BancoBase", SqlDbType.Int).Value = obj.idBanco
                .Add("@idfrecuenciadepago", SqlDbType.Int).Value = obj.idfrecuenciadepago
                .Add("@sibono", SqlDbType.Int).Value = obj.sibono
                ' Validar si todos los campos necesarios tienen valor
                If Not String.IsNullOrEmpty(obj.NroCuentaextra) AndAlso
                       Not String.IsNullOrEmpty(obj.Tipocuentaextra) AndAlso
                       obj.idFormadePagoextra <> 0 AndAlso
                       obj.idBancoextra <> 0 Then
                    .Add("@nroCuentaExtra", SqlDbType.VarChar).Value = obj.NroCuentaextra
                    .Add("@tipocuentaExtra", SqlDbType.VarChar).Value = obj.Tipocuentaextra
                    .Add("@FormaDePagoExtra", SqlDbType.Int).Value = obj.idFormadePagoextra
                    .Add("@BancoExtra", SqlDbType.Int).Value = obj.idBancoextra
                End If
                .Add("@extraBono", SqlDbType.Money).Value = If(String.IsNullOrEmpty(obj.ExtraBono), 0, obj.ExtraBono)
                .Add("@msj", SqlDbType.VarChar, 700).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)
            con.Salir()
            Return mensaje
        Catch ex As Exception
            con.Salir()
            Throw ex
        End Try
    End Function
    Public Function Cd_MantenimientoTrabajadorEventual(name As String, obj As coTrabajador) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                ' Persona
                .Add("@operacion", SqlDbType.Int).Value = obj.Operacion
                .Add("@idPersona", SqlDbType.Int).Value = obj.IdPersona
                .Add("@tipo", SqlDbType.VarChar).Value = obj.Tipo
                .Add("@numDocumento", SqlDbType.VarChar).Value = obj.NumDocumento
                .Add("@datos", SqlDbType.VarChar).Value = obj.Datos
                .Add("@apaterno", SqlDbType.VarChar).Value = obj.apaterno
                .Add("@amaterno", SqlDbType.VarChar).Value = obj.amaterno
                .Add("@sexo", SqlDbType.VarChar).Value = obj.Sexo
                .Add("@estadoCivil", SqlDbType.VarChar).Value = obj.EstadoCivil
                .Add("@fNacimiento", SqlDbType.DateTime).Value = obj.FNacimiento
                .Add("@direccion", SqlDbType.VarChar).Value = obj.Direccion
                .Add("@celular", SqlDbType.VarChar).Value = obj.Celular
                .Add("@correo", SqlDbType.Char).Value = obj.Correo
                .Add("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .Add("@estado", SqlDbType.VarChar).Value = obj.Estado
                .Add("@archivoFoto", SqlDbType.VarBinary).Value = If(obj.ArchivoFoto Is Nothing, DBNull.Value, obj.ArchivoFoto)
                .Add("@archivoFirma", SqlDbType.VarBinary).Value = If(obj.ArchivoFirma Is Nothing, DBNull.Value, obj.ArchivoFirma)
                .Add("@idTipoDocIdentidad", SqlDbType.Int).Value = obj.IdTipoDocIdentidad
                .Add("@idDistrito", SqlDbType.Int).Value = obj.IdDistrito
                .Add("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
                .Add("@idArea", SqlDbType.Int).Value = obj.IdArea
                .Add("@msj", SqlDbType.VarChar, 700).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)
            con.Salir()
            Return mensaje
        Catch ex As Exception
            con.Salir()
            Throw ex
        End Try
    End Function
    Public Function Cd_Consultar(name As String, obj As coTrabajador) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@valor", SqlDbType.VarChar).Value = ""
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ConsultarxCodigo(name As String, obj As coTrabajador) As DataTable
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
    Public Function Cd_EliminarHijo(name As String, obj As coTrabajador) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idhijo", SqlDbType.Int).Value = obj.idhijo
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ConsultarxCodigoTbhijo(name As String, obj As coTrabajador) As DataTable
        Try
            Dim dt As New DataTable("TempDetProdEpp")
            dt.Columns.Add("N°Doc", GetType(String))
            dt.Columns.Add("Mes concepcion", GetType(DateTime))
            dt.Columns.Add("FechaNacimiento", GetType(DateTime))
            dt.Columns.Add("Sexo", GetType(String))
            dt.Columns.Add("TipodocHijo", GetType(Integer))
            dt.Columns.Add("Nombre", GetType(String))
            dt.Columns.Add("Apellido Paterno", GetType(String))
            dt.Columns.Add("Apellido Materno", GetType(String))
            dt.Columns.Add("Vinculofamiliar", GetType(Integer))
            dt.Columns.Add("TipoDocVinculante", GetType(Integer))
            dt.Columns.Add("N_Doc_Vinculo", GetType(String))
            dt.Columns.Add("PDF", GetType(Byte()))
            dt.Columns.Add("btneliminar", GetType(String))
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@idpersona", SqlDbType.Int).Value = obj.IdPersona
            Dim dtSQL As New DataTable()
            da.Fill(dtSQL)
            For Each row As DataRow In dtSQL.Rows
                Dim newRow As DataRow = dt.NewRow()
                newRow("N°Doc") = row("Num_DNI").ToString()
                newRow("FechaNacimiento") = If(IsDBNull(row("Fecha")), DBNull.Value, row("Fecha"))
                newRow("Mes concepcion") = If(IsDBNull(row("Concepcion")), DBNull.Value, row("Concepcion"))
                newRow("Sexo") = row("sexo").ToString()
                newRow("TipodocHijo") = If(IsDBNull(row("Tipo")), DBNull.Value, row("Tipo"))
                newRow("Nombre") = row("Nombre").ToString()
                newRow("Apellido Paterno") = row("A. paterno").ToString()
                newRow("Apellido Materno") = row("A. Materno").ToString()
                newRow("Vinculofamiliar") = If(IsDBNull(row("idvinculo")), DBNull.Value, row("idvinculo"))
                newRow("TipoDocVinculante") = If(IsDBNull(row("IDtipodocvinculo")), DBNull.Value, row("IDtipodocvinculo"))
                newRow("N_Doc_Vinculo") = row("nroDocVinculante").ToString()
                newRow("PDF") = DBNull.Value
                newRow("btneliminar") = "Eliminar"
                dt.Rows.Add(newRow)
            Next
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
    End Function
    Public Function Cd_ListarTipoDocIdentidad(name As String) As DataTable
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
    Public Function Cd_ListarTrabajadoresActivos(name As String) As DataTable
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
    Public Function Cd_Consultarvacaciones(name As String, obj As coControlPagosyDes) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@tipopago", SqlDbType.Int).Value = obj.frecuenciapago
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarxCodigoUbicacion(name As String, obj As coTrabajador) As DataTable
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
    Public Function Cd_ConsultarxCodigoContrato(name As String, obj As coTrabajador) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idpersona", SqlDbType.Int).Value = obj.idcontrato
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ConsultarxCodigoregistrosunat(name As String, obj As coTrabajador) As DataTable
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
    Public Function Cd_ListarDistritos(name As String) As DataTable
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
    Public Function Cd_ListarOcupacion(name As String) As DataTable
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
    Public Function Cd_ListarPasaportes(name As String) As DataTable
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
    Public Function Cd_ListarVINCULO_FAMILIAR(name As String) As DataTable
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
    Public Function Cd_ListarTPDOC_VINCULO(name As String) As DataTable
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
    Public Function Cd_ObtenerCuentaBancoPorIdPersona(name As String, obj As coTrabajador) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idPersona", SqlDbType.Int).Value = obj.idcontrato
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
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
    Public Function Cd_EliminarUbicacion(name As String, obj As coTrabajador) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@idubicacion", obj.idubicacionpersona)

            Dim paramMsj As SqlParameter = da.SelectCommand.Parameters.Add("@msj", SqlDbType.VarChar, 700)
            paramMsj.Direction = ParameterDirection.Output

            Dim paramCodError As SqlParameter = da.SelectCommand.Parameters.Add("@coderror", SqlDbType.Int)
            paramCodError.Direction = ParameterDirection.Output

            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)

            ' Asignamos los valores al objeto trabajador
            obj.Mensaje = paramMsj.Value.ToString()
            obj.Coderror = Convert.ToInt32(paramCodError.Value)

        Catch ex As Exception
            obj.Mensaje = ex.Message
            obj.Coderror = 0
            Throw ex
        Finally
            con.Salir()
        End Try
        Return dt
    End Function
    Public Function Cd_InsertarUbicacion(name As String, obj As coTrabajador) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                ' Persona
                .Add("@idPersona", SqlDbType.Int).Value = obj.IdPersona
                .Add("@idUsuario", SqlDbType.Int).Value = obj.IdUsuario
                .Add("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
                .Add("@idArea", SqlDbType.Int).Value = obj.IdArea
                .Add("@msj", SqlDbType.VarChar, 700).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)
            con.Salir()
            Return mensaje
        Catch ex As Exception
            con.Salir()
            Throw ex
        End Try
    End Function
    Public Function Cd_ConsultarxCodigoHijo(name As String, obj As coTrabajador) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@hijos", SqlDbType.Int).Value = obj.idhijo
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_InsertarBajatrabajador(ByVal name As String, ByRef obj As coTrabajador) As String
        Dim mensaje As String = String.Empty
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .Add("@idpersona", SqlDbType.Int).Value = obj.IdPersona
                .Add("@idusuario", SqlDbType.Int).Value = obj.IdUsuario
                .Add("@idmotivo", SqlDbType.Int).Value = obj.idmotivobajatrabajador
                .Add("@fbaja", SqlDbType.DateTime).Value = obj.FechaBaja
                .Add("@MSJ", SqlDbType.NVarChar, 255).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@MSJ").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)
            If obj.Coderror <> 0 Then
                Return mensaje
            End If
            con.Salir()
        Catch ex As Exception
            con.Salir()
            mensaje = "Error: " & ex.Message
        End Try

        Return mensaje
    End Function

    Public Function Cd_Consultardocsunat(name As String) As DataTable
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
    Public Function Cd_ConsultarIdpersonacontrato(name As String, obj As coTrabajador) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idpersona", obj.IdPersona)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_generarfotocheck(name As String, obj As coTrabajador) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idpersona", obj.IdPersona)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarsunatxempleadoE4(name As String, idPersonas As String) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@idpersonas", idPersonas)  ' Usando la lista de idpersonas
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ProcesarExcelAfp(name As String, dataString As String) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@ExcelData", dataString)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ListarTrabajadoresActivosxPlantel(name As String, obj As coTrabajador) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", SqlDbType.Int).Value = obj.IdUbicacion
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ListarCargoTrabajadorProduccion(name As String) As DataTable
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

    Public Function Cd_MantPersonalProduccion(name As String, obj As coTrabajador) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .Add("@operacion", SqlDbType.Int).Value = obj.Operacion
                .Add("@idPersona", SqlDbType.Int).Value = obj.IdPersona
                .Add("@idCargo", SqlDbType.Int).Value = obj.IdCargo
                .Add("@estado", SqlDbType.VarChar).Value = obj.Estado
                .Add("@msj", SqlDbType.VarChar, 700).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)
            con.Salir()
            Return mensaje
        Catch ex As Exception
            con.Salir()
            Throw ex
        End Try
    End Function

    Public Function Cd_ConsultarPersonalProduccionFiltrado(name As String, obj As coTrabajador) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@tipoPersonal", SqlDbType.VarChar).Value = obj.Tipo
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ActualizarDiasVacaciones(name As String, obj As coTrabajador) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .Add("@idPersona", SqlDbType.Int).Value = obj.IdPersona
                .Add("@diasActualizados", SqlDbType.Int).Value = obj.Dias
                .Add("@msj", SqlDbType.VarChar, 700).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)
            con.Salir()
            Return mensaje
        Catch ex As Exception
            con.Salir()
            Throw ex
        End Try
    End Function
End Class
