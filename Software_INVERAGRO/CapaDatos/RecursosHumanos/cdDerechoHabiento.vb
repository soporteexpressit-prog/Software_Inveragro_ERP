Imports CapaObjetos
Imports System.Data.SqlClient

Public Class cdDerechoHabiento
    Private con As New cdConexion
    Public Function Cd_Mantenimiento(name As String, obj As coDerechoHabiento) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .Add("@numDocumentoHijo", SqlDbType.VarChar).Value = obj.numDocumentoHijo
                .Add("@mesConcepcion", SqlDbType.DateTime).Value = obj.mesConcepcion
                .Add("@fNacimientoHijo", SqlDbType.DateTime).Value = obj.fNacimientoHijo
                .Add("@sexoHijo", SqlDbType.VarChar).Value = obj.sexoHijo
                .Add("@idTipoDocIdentidadHijo", SqlDbType.Int).Value = obj.idTipoDocIdentidadHijo
                .Add("@nombresHijo", SqlDbType.VarChar).Value = obj.nombresHijo
                .Add("@apellidoPaternoHijo", SqlDbType.VarChar).Value = obj.apellidoPaternoHijo
                .Add("@apellidoMaternoHijo", SqlDbType.VarChar).Value = obj.apellidoMaternoHijo
                .Add("@idVinculoFamiliar", SqlDbType.Int).Value = obj.idVinculoFamiliar
                .Add("@idTipoDocVinculante", SqlDbType.Int).Value = obj.idTipoDocVinculante
                .Add("@nroDocVinculante", SqlDbType.VarChar).Value = obj.nroDocVinculante
                .Add("@documentoHijo", SqlDbType.VarBinary).Value = If(obj.documentoHijo Is Nothing, DBNull.Value, obj.documentoHijo)
                .Add("@idPersona", SqlDbType.Int).Value = obj.idPersona
                .Add("@msj", SqlDbType.VarChar, 700).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            If cmd.Parameters("@msj").Value IsNot Nothing Then
                mensaje = cmd.Parameters("@msj").Value.ToString()
            Else
                mensaje = "Sin mensaje de salida."
            End If
            obj.Coderror = If(IsDBNull(cmd.Parameters("@coderror").Value), -1, Convert.ToInt32(cmd.Parameters("@coderror").Value))
            con.Salir()
            Return mensaje
        Catch ex As Exception
            con.Salir()
            Throw ex
        End Try
    End Function

    Public Function Cd_Actualizahijo(name As String, obj As coDerechoHabiento, obj2 As coTrabajador) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .Add("@idHijo", SqlDbType.Int).Value = obj2.idhijo
                .Add("@numDocumentoHijo", SqlDbType.VarChar).Value = obj.numDocumentoHijo
                .Add("@mesConcepcion", SqlDbType.DateTime).Value = obj.mesConcepcion
                .Add("@fNacimientoHijo", SqlDbType.DateTime).Value = obj.fNacimientoHijo
                .Add("@sexoHijo", SqlDbType.VarChar).Value = obj.sexoHijo
                .Add("@idTipoDocIdentidadHijo", SqlDbType.Int).Value = obj.idTipoDocIdentidadHijo
                .Add("@nombresHijo", SqlDbType.VarChar).Value = obj.nombresHijo
                .Add("@apellidoPaternoHijo", SqlDbType.VarChar).Value = obj.apellidoPaternoHijo
                .Add("@apellidoMaternoHijo", SqlDbType.VarChar).Value = obj.apellidoMaternoHijo
                .Add("@idVinculoFamiliar", SqlDbType.Int).Value = obj.idVinculoFamiliar
                .Add("@idTipoDocVinculante", SqlDbType.Int).Value = obj.idTipoDocVinculante
                .Add("@nroDocVinculante", SqlDbType.VarChar).Value = obj.nroDocVinculante
                .Add("@documentoHijo", SqlDbType.VarBinary).Value = If(obj.documentoHijo Is Nothing, DBNull.Value, obj.documentoHijo)
                .Add("@msj", SqlDbType.VarChar, 700).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            If cmd.Parameters("@msj").Value IsNot Nothing Then
                mensaje = cmd.Parameters("@msj").Value.ToString()
            Else
                mensaje = "Sin mensaje de salida."
            End If
            obj.Coderror = If(IsDBNull(cmd.Parameters("@coderror").Value), -1, Convert.ToInt32(cmd.Parameters("@coderror").Value))
            con.Salir()
            Return mensaje
        Catch ex As Exception
            con.Salir()
            Throw ex
        End Try
    End Function

    Public Function Cd_Actualizabajafamilia(name As String, obj As coDerechoHabiento, obj2 As coTrabajador) As String
        Dim mensaje As String
        Dim cmd As New SqlCommand(name, con.con)
        Try
            con.Abrir()
            cmd.CommandType = CommandType.StoredProcedure
            With cmd.Parameters
                .Add("@idHijo", SqlDbType.Int).Value = obj2.idhijo
                .Add("@motivobaja", SqlDbType.Int).Value = obj.idmotivobaja
                .Add("@baja", SqlDbType.DateTime).Value = obj.fbaja
                .Add("@msj", SqlDbType.VarChar, 700).Direction = ParameterDirection.Output
                .Add("@coderror", SqlDbType.Int).Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            If cmd.Parameters("@msj").Value IsNot Nothing Then
                mensaje = cmd.Parameters("@msj").Value.ToString()
            Else
                mensaje = "Sin mensaje de salida."
            End If
            obj.Coderror = If(IsDBNull(cmd.Parameters("@coderror").Value), -1, Convert.ToInt32(cmd.Parameters("@coderror").Value))
            con.Salir()
            Return mensaje
        Catch ex As Exception
            con.Salir()
            Throw ex
        End Try
    End Function



End Class
