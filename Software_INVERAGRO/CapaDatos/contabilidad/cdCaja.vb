Imports System.Data.SqlClient
Imports CapaObjetos

Public Class cdCaja
    Private con As New cdConexion
    Public Function Cd_AperturaCaja(name As String, obj As coCaja) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = 4

            With cmd.Parameters
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Iduser
                .AddWithValue("@mi", SqlDbType.Money).Value = obj.Mi
                .AddWithValue("@observacion", SqlDbType.VarChar).Value = obj.Observacion
                .AddWithValue("@saldoanterior", SqlDbType.Money).Value = obj.Saldoanterior
                .Add("@msj", SqlDbType.VarChar, 100).Direction = 2
                .Add("@codreturn", SqlDbType.Int).Direction = 2
            End With
            cmd.ExecuteNonQuery()
            mensaje = cmd.Parameters("@msj").Value.ToString
            obj.Codreturn = cmd.Parameters("@codreturn").Value.ToString
            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_ObtenerSaldoCajaAnterior(name As String) As Decimal
        Dim mensaje As Decimal

        Using cmd As New SqlCommand(name, con.con)

            Try
                con.Abrir()
                cmd.CommandType = 4

                With cmd.Parameters
                    '.AddWithValue("@codmoneda", SqlDbType.Int).Value = obj.Cod
                    .Add("@saldo", SqlDbType.Money).Direction = 2
                End With
                cmd.ExecuteNonQuery()
                mensaje = cmd.Parameters("@saldo").Value.ToString
                con.Salir()
                Return mensaje
            Catch ex As Exception
                Throw ex
            End Try
        End Using
    End Function

    Public Function Cd_ConsultarSaldoCaja(name As String) As DataTable
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

    Public Function Cd_ConsultarStockCerdosxPlantel(name As String, idplantel As Integer, idMotivo As Integer) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idUbicacion", idplantel)
            da.SelectCommand.Parameters.AddWithValue("@idMotivo", idMotivo)
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_ConsultarCentroCostos(name As String, obj As coCaja) As DataTable
        Dim dt As New DataTable
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@idalcance3", obj.Idalcance3)
            da.SelectCommand.ExecuteNonQuery()
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ConsultarCajaResumen(name As String) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            'da.SelectCommand.Parameters.AddWithValue("@idingreso", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function ConsultarConfiguracionParametros(name As String) As DataSet
        Dim dt As New DataSet
        Try
            con.Abrir()
            Dim da As New SqlDataAdapter(name, con.con)
            da.SelectCommand.CommandType = 4
            'da.SelectCommand.Parameters.AddWithValue("@idingreso", obj.Codigo)
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
        con.Salir()
        Return dt
    End Function
    Public Function Cd_CierreCaja(name As String, obj As coCaja) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@codcm", SqlDbType.Int).Value = obj.Idcaja
                .AddWithValue("@iduser", SqlDbType.Int).Value = obj.Iduser

                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@codreturn", SqlDbType.Int).Direction = ParameterDirection.Output
            End With


            cmd.ExecuteNonQuery()

            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Codreturn = Convert.ToInt32(cmd.Parameters("@codreturn").Value)

            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Cd_GuardaConfiguracionParametros(name As String, obj As coCaja) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@v1", SqlDbType.Int).Value = obj.V1
                .AddWithValue("@sueldominimo", SqlDbType.Money).Value = obj.sueldominimo
                .AddWithValue("@masvida", SqlDbType.Money).Value = obj.masvida
                .AddWithValue("@asigfami", SqlDbType.Money).Value = obj.asigfamiliar
                .AddWithValue("@bono", SqlDbType.Money).Value = obj.bonoagrario
                .AddWithValue("@essalud", SqlDbType.Money).Value = obj.essalud
                .AddWithValue("@montoeventual", SqlDbType.Money).Value = obj.montoeventual
                .AddWithValue("@plantel1", SqlDbType.Money).Value = obj.plantel1
                .AddWithValue("@plantel1molinero", SqlDbType.Decimal).Value = obj.plantel1monitoreo
                .AddWithValue("@plantel2", SqlDbType.Decimal).Value = obj.plantel2
                .AddWithValue("@plantel3", SqlDbType.Decimal).Value = obj.plantel3
                .AddWithValue("@plantel4", SqlDbType.Decimal).Value = obj.plantel4
                .AddWithValue("@plantel5", SqlDbType.Decimal).Value = obj.plantel5
                .AddWithValue("@costomolino", SqlDbType.Decimal).Value = obj.costomolino
                .AddWithValue("@costomarrana", SqlDbType.Decimal).Value = obj.costomarrana
                If obj.Img IsNot Nothing Then
                    .Add("@img", SqlDbType.VarBinary).Value = obj.Img
                Else
                    .Add("@img", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                .Add("@msj", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                .Add("@codreturn", SqlDbType.Int).Direction = ParameterDirection.Output
            End With


            cmd.ExecuteNonQuery()

            mensaje = cmd.Parameters("@msj").Value.ToString()
            obj.Codreturn = Convert.ToInt32(cmd.Parameters("@codreturn").Value)

            con.Salir()
            Return mensaje
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
