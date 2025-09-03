Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdCtaPagar
    Private con As New cdConexion


    Public Function Consultar(name As String, ByRef obj As coCtaPagar) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fdesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fhasta)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.SelectCommand.Parameters.AddWithValue("@idproveedor", obj.Idpersona)
            da.SelectCommand.Parameters.AddWithValue("@idbancodestino", obj.Iddestino)
            da.SelectCommand.Parameters.AddWithValue("@fechatodos", obj.Id)
            da.SelectCommand.Parameters.AddWithValue("@liquidado", obj.estadoliquidado)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function ConsultarCajaChica(name As String, ByRef obj As coCtaPagar) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fdesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fhasta)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.SelectCommand.Parameters.AddWithValue("@idproveedor", obj.Idpersona)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ObtenerDatosdeCuentaPagar(name As String, ByRef obj As coCtaPagar) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idcta", obj.Id)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ObtenerDatosdeorden(name As String, ByRef obj As coCtaPagar) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idcta", obj.Id)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function ObtenerDatosdeCuentaPagarTrabajores(name As String, ByRef obj As coCtaPagar) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idPersona", obj.Idpersona)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function ListarTablasMaestrasAbonar(name As String) As DataSet
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
    Public Function ListarTablasMaestrasPrestamo(name As String) As DataSet
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
    Public Function Cd_Consultarxid(name As String, obj As coCtaCobrar) As DataSet
        Dim dt As New DataSet()
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idcuentacobrar", obj.Id)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
        Catch ex As Exception
            Throw New Exception("Error al consultar los datos del transporte: " & ex.Message)
        Finally
            con.Salir()
        End Try
        Return dt
    End Function
    Public Function Cd_Mantenimiento(name As String, obj As coCtaPagar) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@serie", SqlDbType.VarChar).Value = obj.Serie
                .AddWithValue("@correlativo", SqlDbType.VarChar).Value = obj.Correlativo
                .AddWithValue("@numdocreferencia", SqlDbType.VarChar).Value = obj.Numdocreferencia
                .AddWithValue("@total", SqlDbType.Money).Value = obj.Total
                .AddWithValue("@fpago", SqlDbType.DateTime).Value = obj.Fpago
                .AddWithValue("@comentario", SqlDbType.VarChar).Value = obj.Comentario
                .AddWithValue("@estado", SqlDbType.Char).Value = obj.Estado
                .AddWithValue("@idusuario", SqlDbType.VarChar).Value = obj.Idusuario
                .AddWithValue("@idcuentapagar", SqlDbType.Int).Value = obj.Idcuentapagar
                .AddWithValue("@idformapago", SqlDbType.Int).Value = obj.Idformapago
                .AddWithValue("@tipocambio", SqlDbType.Money).Value = obj.Tipocambio
                .AddWithValue("@idctabancoorigen", SqlDbType.Int).Value = obj.Idctabancoorigen
                .AddWithValue("@idctabancodestino", SqlDbType.Int).Value = obj.Idctabancodestino
                .AddWithValue("@idtipodocumento", SqlDbType.Int).Value = obj.Idtipodocumento
                .AddWithValue("@idmoneda", SqlDbType.Int).Value = obj.Idmoneda
                .AddWithValue("@idcuota", SqlDbType.Int).Value = obj.Idcuota
                .AddWithValue("@fotopdf", SqlDbType.Int).Value = obj.fotopdf
                .AddWithValue("@liquidado", SqlDbType.Int).Value = obj.Liquidado
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .AddWithValue("@idcuentabancotrabajador", SqlDbType.Int).Value = obj.idcuentabancotrabajador
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


    Public Function Cd_MantenimientoAjuste(name As String, obj As coCtaPagar) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@numdocreferencia", SqlDbType.VarChar).Value = obj.Numdocreferencia
                .AddWithValue("@total", SqlDbType.Money).Value = obj.Total
                .AddWithValue("@fpago", SqlDbType.DateTime).Value = obj.Fpago
                .AddWithValue("@comentario", SqlDbType.VarChar).Value = obj.Comentario
                .AddWithValue("@estado", SqlDbType.Char).Value = obj.Estado
                .AddWithValue("@idusuario", SqlDbType.VarChar).Value = obj.Idusuario
                .AddWithValue("@tipocambio", SqlDbType.Money).Value = obj.Tipocambio
                .AddWithValue("@idtipodocumento", SqlDbType.Int).Value = obj.Idtipodocumento
                .AddWithValue("@Idcuentapagar", SqlDbType.Int).Value = obj.Idcuentapagar
                .AddWithValue("@idmoneda", SqlDbType.Int).Value = obj.Idmoneda
                .AddWithValue("@fotopdf", SqlDbType.Int).Value = obj.fotopdf
                .AddWithValue("@liquidado", SqlDbType.Int).Value = obj.Liquidado
                .AddWithValue("@Serie", SqlDbType.VarChar).Value = obj.Serie
                .AddWithValue("@Correlativo", SqlDbType.VarChar).Value = obj.Correlativo
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
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



    Public Function Cd_Mantenimientopagomultiple(name As String, obj As coCtaPagar) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@serie", SqlDbType.VarChar).Value = obj.Serie
                .AddWithValue("@correlativo", SqlDbType.VarChar).Value = obj.Correlativo
                .AddWithValue("@numdocreferencia", SqlDbType.VarChar).Value = obj.Numdocreferencia
                .AddWithValue("@fpago", SqlDbType.DateTime).Value = obj.Fpago
                .AddWithValue("@comentario", SqlDbType.VarChar).Value = obj.Comentario
                .AddWithValue("@estado", SqlDbType.Char).Value = obj.Estado
                .AddWithValue("@idusuario", SqlDbType.VarChar).Value = obj.Idusuario
                .AddWithValue("@idformapago", SqlDbType.Int).Value = obj.Idformapago
                .AddWithValue("@tipocambio", SqlDbType.Money).Value = obj.Tipocambio
                .AddWithValue("@idctabancoorigen", SqlDbType.Int).Value = obj.Idctabancoorigen
                .AddWithValue("@idctabancodestino", SqlDbType.Int).Value = obj.Idctabancodestino
                .AddWithValue("@idtipodocumento", SqlDbType.Int).Value = obj.Idtipodocumento
                .AddWithValue("@idmoneda", SqlDbType.Int).Value = obj.Idmoneda
                .AddWithValue("@listadeidspagos", SqlDbType.VarChar).Value = obj.listaidspagos
                .AddWithValue("@fotopdf", SqlDbType.Int).Value = obj.fotopdf
                If obj.ArchivoRecepcion IsNot Nothing Then
                    .Add("@archivo", SqlDbType.VarBinary).Value = obj.ArchivoRecepcion
                Else
                    .Add("@archivo", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .AddWithValue("@idcuentabancotrabajador", SqlDbType.Int).Value = obj.idcuentabancotrabajador
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

    Public Function ConsultarPrestamoYCuotasxId(name As String, obj As coPrestamo) As DataSet
        ' Crear un DataSet para almacenar los resultados (prestamo y cuotas)
        Dim dsPrestamo As New DataSet()

        Try
            ' Crear la conexión SQL

            ' Crear el comando SQL
            Using cmd As New SqlCommand(name, con.con)
                cmd.CommandType = CommandType.StoredProcedure

                ' Añadir el parámetro
                cmd.Parameters.AddWithValue("@id", obj.Idprestamo)

                ' Crear un SqlDataAdapter para llenar el DataSet
                Using da As New SqlDataAdapter(cmd)
                    ' Llenar el DataSet con los resultados del procedimiento almacenado
                    da.Fill(dsPrestamo)
                End Using
            End Using

            ' Devolver el DataSet con los datos del préstamo y las cuotas
            Return dsPrestamo

        Catch ex As Exception
            ' Manejo de errores
            MessageBox.Show("Error al consultar el préstamo y las cuotas: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Public Function Cd_RegPrestamo(name As String, obj As coPrestamo) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                ' Agregar parámetros al comando, mapeando con la clase coPrestamoCtaPagar
                .AddWithValue("@codReferencia", SqlDbType.VarChar).Value = obj.CodReferencia
                .AddWithValue("@totalCuotas", SqlDbType.Int).Value = obj.TotalCuotas
                .AddWithValue("@importe", SqlDbType.Money).Value = If(obj.Importe <> 0, obj.Importe, DBNull.Value)
                .AddWithValue("@fSolicitud", SqlDbType.Date).Value = obj.FSolicitud
                .AddWithValue("@fAprobacion", SqlDbType.Date).Value = If(obj.FAprobacion.HasValue, obj.FAprobacion.Value, DBNull.Value)
                .AddWithValue("@fCuota", SqlDbType.Date).Value = obj.FCuota
                .AddWithValue("@tasaInteres", SqlDbType.Decimal).Value = obj.TasaInteres
                .AddWithValue("@estadoPrestamo", SqlDbType.VarChar).Value = obj.EstadoPrestamo
                .AddWithValue("@comentario", SqlDbType.VarChar).Value = obj.Comentario
                .AddWithValue("@idUsuario", SqlDbType.VarChar).Value = obj.IdUsuario
                .AddWithValue("@idBanco", SqlDbType.Int).Value = obj.IdBanco
                .AddWithValue("@idCuentaBancoDestDepo", SqlDbType.Int).Value = obj.IdCuentaBancoDestDepo
                .AddWithValue("@idTipoPrestamo", SqlDbType.Int).Value = obj.IdTipoPrestamo
                .AddWithValue("@idSolicitante", SqlDbType.Int).Value = obj.IdSolicitante
                .AddWithValue("@idmoneda", SqlDbType.Int).Value = obj.IdMoneda
                .AddWithValue("@tipocambio", SqlDbType.Money).Value = If(obj.TipoCambio <> 0, obj.TipoCambio, DBNull.Value)
                .AddWithValue("@lista_items", SqlDbType.VarChar).Value = obj.Lista_items
                ' Parámetros de salida
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
    Public Function Cd_AnularCtaPagar(name As String, obj As coCtaPagar) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idcuentapagar", SqlDbType.Int).Value = obj.Idcuentapagar
                .AddWithValue("@idusuario", SqlDbType.Int).Value = obj.Idusuario
                .AddWithValue("@motivoanulacion", SqlDbType.VarChar).Value = obj.Motivoanulacion
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
    Public Function Cd_AnularAbonoCtaPagar(name As String, obj As coCtaPagar) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idDetCuentaPagar", SqlDbType.Int).Value = obj.Idcuentapagar
                .AddWithValue("@idusuario", SqlDbType.Int).Value = obj.Idusuario
                .AddWithValue("@motivoanulacion", SqlDbType.VarChar).Value = obj.Motivoanulacion
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
    Public Function Cd_RegNuevaCuentaCobraractualizar(name As String, obj As coCtaCobrar) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@numdocreferencia", SqlDbType.VarChar).Value = obj.Numdocreferencia
                .AddWithValue("@total", SqlDbType.Money).Value = obj.Total
                .AddWithValue("@fpago", SqlDbType.DateTime).Value = obj.Fpago
                .AddWithValue("@comentario", SqlDbType.VarChar).Value = obj.Comentario
                .AddWithValue("@idformapago", SqlDbType.Int).Value = obj.Idformapago
                .AddWithValue("@idusuario", SqlDbType.Int).Value = obj.Idusuario
                .AddWithValue("@tipocambio", SqlDbType.Money).Value = obj.Tipocambio
                .AddWithValue("@idctabancoorigen", SqlDbType.Int).Value = obj.Idctabancoorigen
                .AddWithValue("@idtipodocumento", SqlDbType.Int).Value = obj.Idtipodocumento
                .AddWithValue("@idmoneda", SqlDbType.Int).Value = obj.Idmoneda
                .AddWithValue("@liquidado", SqlDbType.Int).Value = obj.Liquidado
                .AddWithValue("@iddestino", SqlDbType.Int).Value = obj.Iddestino
                .AddWithValue("@idcondicionpago", SqlDbType.Int).Value = obj.Idcondicionpago
                .AddWithValue("@idplancuenta", SqlDbType.Int).Value = obj.Idcuentapagar
                .AddWithValue("@idcuentacobrar", SqlDbType.Int).Value = obj.Id
                .AddWithValue("@serie", SqlDbType.VarChar).Value = obj.Serie
                .AddWithValue("@correlativo", SqlDbType.VarChar).Value = obj.Correlativo
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

    Public Function Cd_NuevaCtaPagar(name As String, obj As coCtaPagar) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@total", SqlDbType.Money).Value = obj.Total
                .AddWithValue("@fecha", SqlDbType.Date).Value = obj.Fpago
                .AddWithValue("@idusuario", SqlDbType.Int).Value = obj.Idusuario
                .AddWithValue("@liquidado", SqlDbType.Int).Value = obj.Liquidado
                .AddWithValue("@iddestinopagar", SqlDbType.Int).Value = obj.Iddestino
                .AddWithValue("@idactivo", SqlDbType.Int).Value = obj.Idactivo
                .AddWithValue("@idctacontable", SqlDbType.Int).Value = obj.Idctacontable
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@numreferencia", SqlDbType.VarChar).Value = obj.Numdocreferencia
                .AddWithValue("@idcondicionpago", SqlDbType.Int).Value = obj.Idcondicionpago
                .AddWithValue("@idmoneda", SqlDbType.Int).Value = obj.Idmoneda
                .AddWithValue("@Idctabancoorigen", SqlDbType.Int).Value = obj.Idctabancoorigen
                .AddWithValue("@Idformapago", SqlDbType.Int).Value = obj.Idformapago
                .AddWithValue("@tipocambio", SqlDbType.Money).Value = obj.Tipocambio
                .AddWithValue("@serie", SqlDbType.VarChar).Value = obj.Serie
                .AddWithValue("@correlativo", SqlDbType.VarChar).Value = obj.Correlativo
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
                .Add("@codigocta", SqlDbType.Int).Direction = ParameterDirection.Output
            End With

            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(cmd.Parameters("@coderror").Value)
            obj.Id = Convert.ToInt32(cmd.Parameters("@codigocta").Value)

            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Cd_NuevaCtaPagarDetalle(name As String, obj As coCtaPagar) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .AddWithValue("@idtipodocumento", SqlDbType.Int).Value = obj.Idtipodocumento
                .AddWithValue("@nrodocumento", SqlDbType.VarChar).Value = obj.Numdocreferencia
                .AddWithValue("@detalle", SqlDbType.VarChar).Value = obj.Detalle
                .AddWithValue("@cantidad", SqlDbType.Money).Value = obj.Cantidad
                .AddWithValue("@precio", SqlDbType.Money).Value = obj.Precio
                .AddWithValue("@idcuentapagar", SqlDbType.Int).Value = obj.Idctacontable
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


    Public Function Cd_ObtenerArchivoAbono(name As String, ByRef obj As coCtaPagar) As String
        Dim mensaje As String = String.Empty
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                ' Parámetro de entrada
                .AddWithValue("@id", SqlDbType.Int).Value = obj.Id
                .Add("@archivo", SqlDbType.VarBinary, -1).Direction = ParameterDirection.Output
            End With
            ' Ejecutar el procedimiento almacenado
            cmd.ExecuteNonQuery()
            ' Verificar si el valor de archivo es NULL o tiene contenido
            If IsDBNull(cmd.Parameters("@archivo").Value) Then
                obj.ArchivoRecepcion = Nothing
            Else
                obj.ArchivoRecepcion = CType(cmd.Parameters("@archivo").Value, Byte())
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

    Public Function ConsultarResumenCaja(name As String, ByRef obj As coCtaPagar) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", obj.Fdesde)
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", obj.Fhasta)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarPrestamosPendientesxIdBanco(name As String, ByRef obj As coCtaPagar) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idbanco", obj.IdBanco)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_RegistrarMontoDebitadoCtaPagar(name As String, obj As coCtaPagar) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idCtaBancoDestino", SqlDbType.Int).Value = obj.Idctabancodestino
                .AddWithValue("@total", SqlDbType.Money).Value = obj.Total
                .AddWithValue("@fpago", SqlDbType.DateTime).Value = obj.Fpago
                .AddWithValue("@idcuentapagar", SqlDbType.Int).Value = obj.Idcuentapagar
                .AddWithValue("@tipocambio", SqlDbType.Money).Value = obj.Tipocambio
                .AddWithValue("@idmoneda", SqlDbType.Int).Value = obj.Idmoneda
                .AddWithValue("@idcuota", SqlDbType.Int).Value = obj.Idcuota
                .AddWithValue("@idusuario", SqlDbType.Int).Value = obj.Idusuario
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
End Class
