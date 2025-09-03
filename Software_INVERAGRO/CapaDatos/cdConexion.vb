Imports System.Data.SqlClient

Public Class cdConexion

    Private Shared ReadOnly conexionProduccion As String = "Data Source=38.242.143.97,1433;Initial Catalog=BDINVERAGRO;User ID=wilmer;Password=devwilmer2024"
    Private Shared ReadOnly conexionPruebas As String = "Data Source=38.242.143.97,1433;Initial Catalog=BDINVERAGRO_TEST;User ID=wilmer;Password=devwilmer2024"
    Public Shared EsProduccion As Boolean = False

    Public con As SqlConnection

    Public Sub New()
        If EsProduccion Then
            con = New SqlConnection(conexionProduccion)
        Else
            con = New SqlConnection(conexionPruebas)
        End If
    End Sub

    Public Function Abrir()
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Return con
    End Function

    Public Function Salir() As Boolean
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Return True
    End Function
End Class