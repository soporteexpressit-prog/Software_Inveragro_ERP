Imports CapaObjetos
Imports System.Data.SqlClient

Public Class cdControlPagosyDes
    Private conexion As New cdConexion()
    Public Function Cd_Consultar(name As String, obj As coControlPagosyDes) As DataTable
        Dim dt As New DataTable
        Try
            conexion.Abrir()
            Dim da As New SqlDataAdapter(name, conexion.con)
            da.SelectCommand.Parameters.AddWithValue("@quincena", obj.TipoQuincena)
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.Anio)
            da.SelectCommand.Parameters.AddWithValue("@mes", obj.Mes)
            da.SelectCommand.CommandType = 4
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        conexion.Salir()
        Return dt
    End Function
    Public Function Cd_Consultarsemana(name As String, obj As coControlPagosyDes) As DataTable
        Dim dt As New DataTable
        Try
            conexion.Abrir()
            Dim da As New SqlDataAdapter(name, conexion.con)
            da.SelectCommand.Parameters.AddWithValue("@idpago", obj.idpago)
            da.SelectCommand.CommandType = 4
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        conexion.Salir()
        Return dt
    End Function

    Public Function ListarTablasMaestrasConceptos(name As String) As DataSet
        Dim dt As New DataSet
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
    Public Function Cd_ConsultarConceptos(name As String, obj As coControlPagosyDes) As DataTable
        Dim dt As New DataTable
        Try
            conexion.Abrir()
            Dim da As New SqlDataAdapter(name, conexion.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@descripcion", If(String.IsNullOrEmpty(obj.Descripcion), DBNull.Value, obj.Descripcion))
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        conexion.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarregimenAFP(name As String) As DataTable
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

    Public Function Cd_validarfecha(name As String, ByRef resultado As String) As Boolean
        Try
            conexion.Abrir()
            Dim cmd As New SqlCommand(name, conexion.con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                resultado = reader("Resultado").ToString() ' Capturar el resultado en la variable
            End If
            reader.Close()
            Return resultado = "Verdadero"
        Catch ex As Exception
            Throw ex
        Finally
            conexion.Salir()
        End Try
    End Function


    Public Function Cd_ConsultarId(name As String, obj As coControlPagosyDes, tipoQuincena As Integer) As DataSet
        Dim dt As New DataSet
        Try
            conexion.Abrir()
            Dim da As New SqlDataAdapter(name, conexion.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure

            da.SelectCommand.Parameters.AddWithValue("@idpersona", obj.IdPersona)
            da.SelectCommand.Parameters.AddWithValue("@idpago", obj.idpago)
            da.SelectCommand.Parameters.AddWithValue("@quincena", tipoQuincena)

            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            conexion.Salir()
        End Try
        Return dt
    End Function


    Public Function Cd_ConsultarPagosYDes(procedimiento As String, obj As coControlPagosyDes, id As Integer) As coControlPagosyDes

        Try
            conexion.Abrir()
            Dim da As New SqlDataAdapter(procedimiento, conexion.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@idpersona", id)
            da.SelectCommand.Parameters.AddWithValue("@idpago", obj.idpago)
            Dim ds As New DataSet()
            da.Fill(ds)

            If ds.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables(0).Rows(0)

                obj.Salario = If(IsDBNull(row("SALARIO")), 0, Convert.ToDecimal(row("SALARIO")))
                obj.AsignacionFamiliar = If(IsDBNull(row("ASIGNACION_FAMILIAR")), 0, Convert.ToDecimal(row("ASIGNACION_FAMILIAR")))
                obj.IngresoBasico = If(IsDBNull(row("INGRESO_BASICO")), 0, Convert.ToDecimal(row("INGRESO_BASICO")))
                obj.CostoDia = If(IsDBNull(row("CostoDia")), 0, Convert.ToDecimal(row("CostoDia")))
                obj.CostoPorHoraSinAsigFam = If(IsDBNull(row("COSTO_POR_HORA_SINASIGFAM")), 0, Convert.ToDecimal(row("COSTO_POR_HORA_SINASIGFAM")))
                obj.DiasAsistidos = If(IsDBNull(row("DIASASISTIDOS")), 0, Convert.ToInt32(row("DIASASISTIDOS")))
                obj.idregimenlaboral = If(IsDBNull(row("idregimenlaboral")), 0, Convert.ToInt32(row("idregimenlaboral")))
                obj.TotalHorasTrabajadas = If(IsDBNull(row("TotalHorasTrabajadas")), 0, Convert.ToDecimal(row("TotalHorasTrabajadas")))
                obj.DiasNoAsistidos = If(IsDBNull(row("DIASNOASISTIDOS")), 0, Convert.ToDecimal(row("DIASNOASISTIDOS")))
                obj.Extrabono = If(IsDBNull(row("Extrabono")), 0, Convert.ToDecimal(row("Extrabono")))
                obj.valorspdec = If(IsDBNull(row("valordeseg")), 0, Convert.ToDecimal(row("valordeseg")))
                obj.valorsp = If(IsDBNull(row("Valorseguro")), 0, Convert.ToDecimal(row("Valorseguro")))
                obj.Descripcionsp = If(IsDBNull(row("DescripcionSeguro")), 0, Convert.ToString(row("DescripcionSeguro")))
                obj.idsegurosocial = If(IsDBNull(row("segurosocial")), 0, Convert.ToString(row("segurosocial")))
                obj.idregimenp = If(IsDBNull(row("idregimenpensionario")), 0, Convert.ToString(row("idregimenpensionario")))
                obj.bonoagrario = If(IsDBNull(row("Bonoagrario")), 0, Convert.ToDecimal(row("Bonoagrario")))
                obj.essalud = If(IsDBNull(row("essalud")), 0, Convert.ToDecimal(row("essalud")))
                obj.montoeventual = If(IsDBNull(row("montoeventual")), 0, Convert.ToDecimal(row("montoeventual")))
                obj.numdiasvacaciones = If(IsDBNull(row("numdiasvacaciones")), 0, Convert.ToDecimal(row("numdiasvacaciones")))
                obj.fechavacacion = If(IsDBNull(row("fechapermiso")), 0, Convert.ToString(row("fechapermiso")))
                obj.valorhoraextra = If(IsDBNull(row("valorhoraplantel")), 0, Convert.ToDecimal(row("valorhoraplantel")))
                obj.salariobase = If(IsDBNull(row("sueldominimo")), 0, Convert.ToDecimal(row("sueldominimo")))
                obj.validarcuenta = If(IsDBNull(row("validarcuentasiguales")), 0, Convert.ToDecimal(row("validarcuentasiguales")))
                obj.observacion = If(IsDBNull(row("observacion")), 0, Convert.ToString(row("observacion")))
                obj.diasdescanso = If(IsDBNull(row("DIASDESCANSO")), 0, Convert.ToString(row("DIASDESCANSO")))
                obj.ultimoDiaMarcacion = If(IsDBNull(row("ultimoDiaMarcacion")), 0, Convert.ToString(row("ultimoDiaMarcacion")))
                obj.diasvacaciones = If(IsDBNull(row("diasvacaciones")), 0, Convert.ToString(row("diasvacaciones")))
                obj.diasdescansoeti = If(IsDBNull(row("diasdescansoeti")), 0, Convert.ToString(row("diasdescansoeti")))
                obj.Nfetrabajado = If(IsDBNull(row("Nfetrabajado")), 0, Convert.ToString(row("Nfetrabajado")))
                obj.Nfenotrabajado = If(IsDBNull(row("Nfenotrabajado")), 0, Convert.ToString(row("Nfenotrabajado")))
                obj.diapermisomedico = If(IsDBNull(row("permisomedico")), 0, Convert.ToString(row("permisomedico")))
                obj.horasmarrana = If(IsDBNull(row("horasmarranas")), 0, Convert.ToDecimal(row("horasmarranas")))
                obj.costohorasmarrana = If(IsDBNull(row("costoHmarrana")), 0, Convert.ToDecimal(row("costoHmarrana")))
                obj.importevacacionesvendidas = If(IsDBNull(row("importevacacionesvendidas")), 0, Convert.ToDecimal(row("importevacacionesvendidas")))
                obj.diasvendidos = If(IsDBNull(row("diasvendidos")), 0, Convert.ToDecimal(row("diasvendidos")))
                obj.montograti = If(IsDBNull(row("montograti")), 0, Convert.ToDecimal(row("montograti")))
                obj.MontoCts = If(IsDBNull(row("MontoCts")), 0, Convert.ToDecimal(row("MontoCts")))
            End If
        Catch ex As Exception
            Throw ex
        Finally
            conexion.Salir()
        End Try

        Return obj
    End Function

    Public Function Cd_ConsultarPagosYDeseven(procedimiento As String, obj As coControlPagosyDes, id As Integer) As coControlPagosyDes

        Try
            conexion.Abrir()
            Dim da As New SqlDataAdapter(procedimiento, conexion.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@idpersona", id)
            da.SelectCommand.Parameters.AddWithValue("@idpago", obj.idpago)
            Dim ds As New DataSet()
            da.Fill(ds)

            If ds.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables(0).Rows(0)
                obj.montoeventual = If(IsDBNull(row("montoeventual")), 0, Convert.ToDecimal(row("montoeventual")))
                obj.diasdescanso = If(IsDBNull(row("diasdescanso")), 0, Convert.ToDecimal(row("diasdescanso")))
                obj.DiasNoAsistidos = If(IsDBNull(row("faltas")), 0, Convert.ToDecimal(row("faltas")))
                obj.observacion = If(IsDBNull(row("Observacion")), 0, Convert.ToString(row("Observacion")))
                obj.valorhoraextra = If(IsDBNull(row("valorhoraplantel")), 0, Convert.ToString(row("valorhoraplantel")))
                obj.diasdescansoeti = If(IsDBNull(row("diasdescansoeti")), 0, Convert.ToString(row("diasdescansoeti")))
                obj.costohorasmarrana = If(IsDBNull(row("costoHmarrana")), 0, Convert.ToString(row("costoHmarrana")))
                obj.horasmarrana = If(IsDBNull(row("horamarranas")), 0, Convert.ToString(row("horamarranas")))
            End If
        Catch ex As Exception
            Throw ex
        Finally
            conexion.Salir()
        End Try

        Return obj
    End Function

    Public Function Cd_ListarAñosDeHorarios(name As String) As DataTable
        Dim dt As New DataTable
        Try
            conexion.Abrir()
            Dim da As New SqlDataAdapter(name, conexion.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            conexion.Salir()
        End Try
        Return dt
    End Function
    Public Function Cd_ListarPlanteles(name As String) As DataTable
        Dim dt As New DataTable
        Try
            conexion.Abrir()
            Dim da As New SqlDataAdapter(name, conexion.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        Finally
            conexion.Salir()
        End Try
        Return dt
    End Function

    Public Function Cd_Agregamosconcepto(name As String, obj As coControlPagosyDes) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, conexion.con)
        Try
            conexion.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@nombre", SqlDbType.VarChar).Value = obj.Descripcion
                .AddWithValue("@tipo", SqlDbType.VarChar).Value = obj.TipoConcepto
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

    Public Function Cd_elimnarsueldoextra(name As String, obj As coControlPagosyDes) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, conexion.con)
        Try
            conexion.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idsueldo", SqlDbType.VarChar).Value = obj.IdConceptoSueldo
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


    Public Function Cd_Agregamosregimen(name As String, obj As coControlPagosyDes) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, conexion.con)
        Try
            conexion.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion
                .AddWithValue("@porcentaje", SqlDbType.VarChar).Value = obj.porcentaje
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


    Public Function InsertarCuentaPagar(idPersona As Integer, quincena As Integer, sueldoBaseNeto As Decimal) As String
        Dim mensaje As String
        Try
            Dim cmd As New SqlCommand("JIHF_InsertarCuentaPagarSueldobase", conexion.con)
            conexion.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .Add(New SqlParameter("@idPersona", SqlDbType.Int)).Value = idPersona
                .Add(New SqlParameter("@sueldoBaseNeto", SqlDbType.Money)).Value = sueldoBaseNeto
                .Add(New SqlParameter("@quincena", SqlDbType.Int)).Value = quincena
                .Add(New SqlParameter("@msj", SqlDbType.NVarChar, 200)).Direction = ParameterDirection.Output
                .Add(New SqlParameter("@coderror", SqlDbType.Int)).Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()

            ' Obtener valores de los parámetros de salida
            mensaje = cmd.Parameters("@msj").Value.ToString()
            Dim coderror As Integer = Convert.ToInt32(cmd.Parameters("@coderror").Value)
            conexion.Salir()

            If coderror = 0 Then
                Return mensaje
            Else
                Return "Error: " & mensaje
            End If

        Catch ex As Exception
            conexion.Salir()
            Throw New Exception("Error al insertar cuenta por pagar: " & ex.Message)
        End Try
    End Function

    Public Function InsertarCuentaPagarExtra(idPersona As Integer, quincena As Integer, sueldoextra As Decimal) As String
        Dim mensaje As String
        Try
            Dim cmd As New SqlCommand("JIHF_InsertarCuentaPagarSueldoExtra", conexion.con)
            conexion.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .Add(New SqlParameter("@idPersona", SqlDbType.Int)).Value = idPersona
                .Add(New SqlParameter("@sueldoBaseNeto", SqlDbType.Money)).Value = sueldoextra
                .Add(New SqlParameter("@quincena", SqlDbType.Int)).Value = quincena
                .Add(New SqlParameter("@msj", SqlDbType.NVarChar, 200)).Direction = ParameterDirection.Output
                .Add(New SqlParameter("@coderror", SqlDbType.Int)).Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()

            ' Obtener valores de los parámetros de salida
            mensaje = cmd.Parameters("@msj").Value.ToString()
            Dim coderror As Integer = Convert.ToInt32(cmd.Parameters("@coderror").Value)
            conexion.Salir()

            If coderror = 0 Then
                Return mensaje
            Else
                Return "Error: " & mensaje
            End If

        Catch ex As Exception
            conexion.Salir()
            Throw New Exception("Error al insertar cuenta por pagar: " & ex.Message)
        End Try
    End Function

    Public Function Cd_ConsultarControldepagos(name As String, obj As coControlPagosyDes) As DataTable
        Dim dt As New DataTable
        Try
            conexion.Abrir()
            Dim da As New SqlDataAdapter(name, conexion.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@Mes", If(obj.Mes.HasValue, obj.Mes.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@Anio", obj.Anio)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        conexion.Salir()
        Return dt
    End Function

    Public Function Cd_AgregamosDetallesueldo(name As String, obj As coControlPagosyDes) As String
        Dim mensaje As String = String.Empty
        Dim cmd As New SqlCommand(name, conexion.con)
        Try
            conexion.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@importe", obj.Importe)
                .AddWithValue("@idpersona", obj.IdPersona)
                .AddWithValue("@idConceptoSueldo", obj.IdConceptoSueldo)
                .AddWithValue("@tquincena", obj.TipoQuincena)
            End With
            Dim msjParam As New SqlParameter("@msj", SqlDbType.VarChar, 255)
            msjParam.Direction = ParameterDirection.Output
            cmd.Parameters.Add(msjParam)
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString()
        Catch ex As Exception
            Throw New Exception("Error al ejecutar el procedimiento almacenado: " & ex.Message)
        Finally
            If conexion.con.State = ConnectionState.Open Then
                conexion.Salir()
            End If
        End Try
        Return mensaje
    End Function


    Public Function Cd_actualizar_estado_detallesueldo(name As String, obj As coControlPagosyDes) As String
        Dim mensaje As String = String.Empty
        Dim cmd As New SqlCommand(name, conexion.con)
        Try
            conexion.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@idpersona", obj.IdPersona)
                .AddWithValue("@idpago", obj.idpago)
                .AddWithValue("@estado", obj.estado)
            End With
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Error al ejecutar el procedimiento almacenado: " & ex.Message)
        Finally
            If conexion.con.State = ConnectionState.Open Then
                conexion.Salir()
            End If
        End Try
        Return mensaje
    End Function


    Public Function Cd_AgregamosSueldo(name As String, obj As coControlPagosyDes) As String
        Dim mensaje As String = String.Empty
        Dim cmd As New SqlCommand(name, conexion.con)
        Try
            conexion.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@idPersona", obj.IdPersona)
                .AddWithValue("@salarioreal", obj.Salario)
                .AddWithValue("@estado", obj.estado)
                .AddWithValue("@tquincena", obj.TipoQuincena)
                .AddWithValue("@idusuario", obj.Iduser)
                .AddWithValue("@periodo", obj.Periodo)
                .AddWithValue("@tiposueldo", obj.tiposueldo)
            End With
            Dim msjParam As New SqlParameter("@msj", SqlDbType.VarChar, 255)
            msjParam.Direction = ParameterDirection.Output
            cmd.Parameters.Add(msjParam)
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString()
        Catch ex As Exception
            Throw New Exception("Error al ejecutar el procedimiento almacenado: " & ex.Message)
        Finally
            If conexion.con.State = ConnectionState.Open Then
                conexion.Salir()
            End If
        End Try
        Return mensaje
    End Function


    Public Function ListarTablasMaestras(name As String, id As Integer, idpago As Integer, periodo As String) As DataSet
        Dim dt As New DataSet
        Try
            conexion.Abrir()
            Dim da As New SqlDataAdapter(name, conexion.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idpersona", SqlDbType.Int).Value = id
            da.SelectCommand.Parameters.AddWithValue("@tipoquincena", SqlDbType.Int).Value = idpago
            da.SelectCommand.Parameters.AddWithValue("@periodo", SqlDbType.VarChar).Value = periodo
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        conexion.Salir()
        Return dt
    End Function

    Public Function Cd_EliminarConceptospagos(name As String, obj As coControlPagosyDes) As DataTable
        Dim dt As New DataTable
        Try
            conexion.Abrir()
            Dim da As New SqlDataAdapter(name, conexion.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@conceptopersona", SqlDbType.Int).Value = obj.iddetalleconcepto
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        conexion.Salir()
        Return dt
    End Function


    Public Function Cd_GenerarMontostotales(name As String, obj As coControlPagosyDes) As String
        Dim mensaje As String = String.Empty
        Dim cmd As New SqlCommand(name, conexion.con)
        Try
            conexion.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Quincena", obj.TipoQuincena)
                .AddWithValue("@periodo", obj.Periodo)
            End With
            Dim msjParam As New SqlParameter("@msj", SqlDbType.VarChar, 255)
            msjParam.Direction = ParameterDirection.Output
            cmd.Parameters.Add(msjParam)
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString()
        Catch ex As Exception
            Throw New Exception("Error al ejecutar el procedimiento almacenado: " & ex.Message)
        Finally
            If conexion.con.State = ConnectionState.Open Then
                conexion.Salir()
            End If
        End Try
        Return mensaje
    End Function


    Public Function Aprobarpagos(name As String, obj As coControlPagosyDes) As String
        Dim mensaje As String = String.Empty
        Dim cmd As New SqlCommand(name, conexion.con)
        Try
            conexion.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Quincena", obj.TipoQuincena)
            End With
            Dim msjParam As New SqlParameter("@msj", SqlDbType.VarChar, 255)
            msjParam.Direction = ParameterDirection.Output
            cmd.Parameters.Add(msjParam)
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString()
        Catch ex As Exception
            Throw New Exception("Error al ejecutar el procedimiento almacenado: " & ex.Message)
        Finally
            If conexion.con.State = ConnectionState.Open Then
                conexion.Salir()
            End If
        End Try
        Return mensaje
    End Function

    Public Function EnviarCuentasPagar(name As String, obj As coControlPagosyDes) As String
        Dim mensaje As String = String.Empty
        Dim cmd As New SqlCommand(name, conexion.con)
        Try
            conexion.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Quincena", obj.TipoQuincena)
                .AddWithValue("@iduser", obj.Iduser)
            End With
            Dim msjParam As New SqlParameter("@msj", SqlDbType.VarChar, 255)
            msjParam.Direction = ParameterDirection.Output
            cmd.Parameters.Add(msjParam)
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString()
        Catch ex As Exception
            Throw New Exception("Error al ejecutar el procedimiento almacenado: " & ex.Message)
        Finally
            If conexion.con.State = ConnectionState.Open Then
                conexion.Salir()
            End If
        End Try
        Return mensaje
    End Function

    Public Function GenerarReportepago(name As String, obj As coControlPagosyDes) As DataSet
        Dim dt As New DataSet
        Try
            Dim cmd As New SqlCommand(name, conexion.con)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@Quincena", obj.TipoQuincena)
            End With
            Dim msjParam As New SqlParameter("@msj", SqlDbType.VarChar, 255)
            msjParam.Direction = ParameterDirection.Output
            cmd.Parameters.Add(msjParam)
            Dim da As New SqlDataAdapter(cmd)
            conexion.Abrir()
            da.Fill(dt)
        Catch ex As Exception
            Throw New Exception("Error al ejecutar el procedimiento almacenado: " & ex.Message)
        Finally
            If conexion.con.State = ConnectionState.Open Then
                conexion.Salir()
            End If
        End Try
        Return dt
    End Function

    Public Function Cd_AprobarPagoMultiple(name As String, obj As coControlPagosyDes) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, conexion.con)
        Try
            conexion.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@listaIdsPago", SqlDbType.VarChar).Value = obj.ListaIdsPago
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
