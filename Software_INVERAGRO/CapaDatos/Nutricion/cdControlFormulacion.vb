Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdControlFormulacion
    Private con As New cdConexion

    Public Function Cd_Listar(name As String, obj As coControlFormulacion) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@fechaDesde", If(obj.FechaDesde.HasValue, obj.FechaDesde.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@fechaHasta", If(obj.FechaHasta.HasValue, obj.FechaHasta.Value, DBNull.Value))
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Tipo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ObtenerFormulaRacionxId(name As String, obj As coControlFormulacion) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idFormulaRacion", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ObtenerRacionesxIdFormulacionBase(name As String, obj As coControlFormulacion) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idFormulaBase", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_RegistrarFormula(name As String, obj As coControlFormulacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion
                .AddWithValue("@id_user", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@lista_detalle_racion", SqlDbType.VarChar).Value = obj.ListaDetalleRacion
                .AddWithValue("@idNutricionista", SqlDbType.Int).Value = obj.IdNutricionista
                .AddWithValue("@fElaboracion", SqlDbType.Date).Value = obj.FechaElaboracion
                .AddWithValue("@motivo", SqlDbType.VarChar).Value = obj.Motivo
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

    Public Function Cd_MantenimientoProductoFormula(name As String, obj As coControlFormulacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@estado", SqlDbType.Bit).Value = obj.EstadoProductoFormula
                .AddWithValue("@listaIdsInsumos", SqlDbType.VarChar).Value = obj.ListaIdsInsumos
                .AddWithValue("@idNutricionista", SqlDbType.Int).Value = obj.IdNutricionista
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

    Public Function Cd_CancelarFormulaBase(name As String, obj As coControlFormulacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idFormulaBase", SqlDbType.Int).Value = obj.IdFormulaBase
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

    Public Function Cd_ActivarFormulaBase(name As String, obj As coControlFormulacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idFormulaBase", SqlDbType.Int).Value = obj.IdFormulaBase
                .AddWithValue("@idNutricionista", SqlDbType.Int).Value = obj.IdNutricionista
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

    Public Function Cd_ListarGeneralDt(name As String) As DataTable
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

    Public Function Cd_InsumosxNucleoUltimaFormula(name As String, obj As coControlFormulacion) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idNucleo", obj.IdNucleo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ObtenerInsumosxFormulaNucleo(name As String, obj As coControlFormulacion) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idFormulaBase", obj.Codigo)
            da.SelectCommand.Parameters.AddWithValue("@idNucleo", obj.IdNucleo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ObtenerRacionesxFormulaBase(name As String, obj As coControlFormulacion) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idFormulaBase", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_RegistrarAsignacionRacionxFormula(name As String, obj As coControlFormulacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion
                .AddWithValue("@preparacion", SqlDbType.Decimal).Value = obj.Preparacion
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
                .AddWithValue("@idNucleo", SqlDbType.Int).Value = obj.IdNucleo
                .AddWithValue("@idFormulaBase", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@listaAsignacion", SqlDbType.VarChar).Value = obj.ListaAsignacionRacion
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

    Public Function Cd_ObtenerFormulaBasexId(name As String, obj As coControlFormulacion) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idFormulaBase", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_VerificarCantidades(name As String, obj As coControlFormulacion) As DataSet
        Dim ds As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@lista_detalle_racion", obj.ListaDetalleRacion)
            da.SelectCommand.Parameters.Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
            da.SelectCommand.Parameters.Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            da.Fill(ds)
            obj.Msj = da.SelectCommand.Parameters("@msj").Value.ToString()
            obj.Coderror = Convert.ToInt32(da.SelectCommand.Parameters("@coderror").Value)

        Catch ex As Exception
            Throw ex
        Finally
            con.Salir()
        End Try
        Return ds
    End Function

    Public Function Cd_ObtenerFormulaBasexIdNucleo(name As String, obj As coControlFormulacion) As Object
        Dim dt As New DataTable
        Dim mensaje As String
        Dim coderror As Integer
        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idRacion", obj.Codigo)
            cmd.Parameters.AddWithValue("@idsDetalleSalida", obj.ListaIdsDetalleSalida)
            cmd.Parameters.AddWithValue("@Tipo", obj.Tipo)
            cmd.Parameters.Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)

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
        Return dt
    End Function

    Public Function Cd_PonerEnCursoNuevaFormulaBase(name As String, obj As coControlFormulacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idNutricionista", SqlDbType.Int).Value = obj.IdNutricionista
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

    Public Function Cd_ObtenerRacionesAsignadasReceta(name As String, obj As coControlFormulacion) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idFormulaBase", obj.IdFormulaBase)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    'Public Function Cd_ListarInsumosFormulaNutricionista(name As String, obj As coControlFormulacion) As DataTable
    '    Dim dt As New DataTable
    '    Try
    '        con.Abrir()
    '        Dim da As New SqlDataAdapter(name, con.con)
    '        da.SelectCommand.Parameters.AddWithValue("@idNutricionista", obj.IdNutricionista)
    '        da.SelectCommand.CommandType = CommandType.StoredProcedure
    '        da.Fill(dt)
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        con.Salir()
    '    End Try
    '    Return dt
    'End Function

    Public Function Cd_ListarInsumosFormulaNutricionista(name As String, obj As coControlFormulacion) As Object
        Dim dt As New DataTable
        Dim mensaje As String
        Dim coderror As Integer
        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idNutricionista", obj.IdNutricionista)
            cmd.Parameters.Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)

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
        Return dt
    End Function

    Public Function Cd_ConsultarInsumosFormulaRacionUnidad(name As String, obj As coControlFormulacion) As Object
        Dim dt As New DataTable
        Dim mensaje As String
        Dim coderror As Integer
        Try
            con.Abrir()
            Dim cmd As New SqlCommand(name, con.con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idRacion", obj.IdNucleo)
            cmd.Parameters.AddWithValue("@Tipo", obj.Tipo)
            cmd.Parameters.AddWithValue("@idPeriodoMedicacion", obj.IdPeriodoMedicion)
            cmd.Parameters.AddWithValue("@idPeriodoPlus", obj.IdPeriodoPlus)
            cmd.Parameters.Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)

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
        Return dt
    End Function

    Public Function Cd_ObtenerPreparacionFormulaTotal(name As String, obj As coControlFormulacion) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idFormulaRacion", obj.IdFormulaRacion)
            da.SelectCommand.Parameters.AddWithValue("@diseño", obj.Diseño)
            da.SelectCommand.Parameters.AddWithValue("@racion", obj.Descripcion)
            da.SelectCommand.Parameters.AddWithValue("@Tipo", obj.Tipo)
            da.SelectCommand.Parameters.AddWithValue("@nota", obj.Nota)
            da.SelectCommand.Parameters.AddWithValue("@idPeriodoMedicacion", obj.IdPeriodoMedicion)
            da.SelectCommand.Parameters.AddWithValue("@idPeriodoPlus", obj.IdPeriodoPlus)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ObtenerPreparacionFormulaTotalMolino(name As String, obj As coControlFormulacion) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idRacion", obj.IdFormulaRacion)
            da.SelectCommand.Parameters.AddWithValue("@diseño", obj.Diseño)
            da.SelectCommand.Parameters.AddWithValue("@racion", obj.Descripcion)
            da.SelectCommand.Parameters.AddWithValue("@Tipo", obj.Tipo)
            da.SelectCommand.Parameters.AddWithValue("@nota", obj.Nota)
            da.SelectCommand.Parameters.AddWithValue("@idsDetalleSalida", obj.ListaIdsDetalleSalida)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ObtenerPreparacionFormulaTipoPremixero(name As String, obj As coControlFormulacion) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idFormulaRacion", obj.IdFormulaRacion)
            da.SelectCommand.Parameters.AddWithValue("@diseño", obj.Diseño)
            da.SelectCommand.Parameters.AddWithValue("@racion", obj.Descripcion)
            da.SelectCommand.Parameters.AddWithValue("@Tipo", obj.Tipo)
            da.SelectCommand.Parameters.AddWithValue("@nota", obj.Nota)
            da.SelectCommand.Parameters.AddWithValue("@tipoPremixero", obj.TipoPremixero)
            da.SelectCommand.Parameters.AddWithValue("@idPeriodoMedicacion", obj.IdPeriodoMedicion)
            da.SelectCommand.Parameters.AddWithValue("@idPeriodoPlus", obj.IdPeriodoPlus)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ObtenerPreparacionFormulaTotalPremixero(name As String, obj As coControlFormulacion) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idRacion", obj.IdFormulaRacion)
            da.SelectCommand.Parameters.AddWithValue("@diseño", obj.Diseño)
            da.SelectCommand.Parameters.AddWithValue("@racion", obj.Descripcion)
            da.SelectCommand.Parameters.AddWithValue("@idsDetalleSalida", obj.ListaIdsDetalleSalida)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarAntiMedicadoRacion(name As String, obj As coControlFormulacion) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idFormulaRacion", obj.IdFormulaRacion)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ListarInsumosFormulaxNutricionista(name As String, obj As coControlFormulacion) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idNutricionista", obj.IdNutricionista)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ClonarAsignacionPremixeroRacion(name As String, obj As coControlFormulacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idFormulaBaseActual", SqlDbType.Int).Value = obj.IdFormulaBase
                .AddWithValue("@idRacion", SqlDbType.Int).Value = obj.IdNucleo
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

    Public Function Cd_ActualizarProductoFormula(name As String, obj As coControlFormulacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@idFormulaBase", SqlDbType.Int).Value = obj.IdFormulaBase
                .AddWithValue("@idProductoActual", SqlDbType.Int).Value = obj.IdProductoFormula
                .AddWithValue("@idProductoNuevo", SqlDbType.Int).Value = obj.IdProductoNuevo
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

    Public Function Cd_ConsultarProgramaAlimentacion(name As String, obj As coControlFormulacion) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@anio", obj.Anio)
            da.SelectCommand.Parameters.AddWithValue("@estado", obj.Estado)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_MantenimientoProgramaAlimentacion(name As String, obj As coControlFormulacion) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@operacion", SqlDbType.Int).Value = obj.Operacion
                .AddWithValue("@codigo", SqlDbType.Int).Value = obj.Codigo
                .AddWithValue("@fControl", SqlDbType.Date).Value = obj.FechaElaboracion
                .AddWithValue("@fControlFin", SqlDbType.Date).Value = obj.FechaHasta
                .AddWithValue("@idPlantel", SqlDbType.Int).Value = obj.IdUbicacion
                .AddWithValue("@descripcion", SqlDbType.VarChar).Value = obj.Descripcion
                .AddWithValue("@nota", SqlDbType.VarChar).Value = obj.Motivo
                .AddWithValue("@idUsuario", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@estado", SqlDbType.VarChar).Value = obj.Estado
                .AddWithValue("@listaDetProgAlimentacion", SqlDbType.VarChar).Value = obj.ListaAsignacionRacion
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

    Public Function Cd_ConsultarProgramaAlimentacionxId(name As String, obj As coControlFormulacion) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idProgramaAlimentacion", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarAntiPlanMedicado(name As String, obj As coControlFormulacion) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idsRaciones", obj.ListaIdsInsumos)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function

    Public Function Cd_ConsultarFormulaBasexIdNutricionista(name As String, obj As coControlFormulacion) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idNutricionista", obj.IdNutricionista)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
End Class
