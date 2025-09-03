Imports System.Data.SqlClient
Imports CapaNegocio
Public Class FrmPanelprincipal
    Private Sub btnMincidentes_Click(sender As Object, e As EventArgs)
        Try
        Catch ex As Exception
            MessageBox.Show("Error al obtener las incidencias: " & ex.Message)
        End Try
    End Sub
    Public Sub CargarEstados(cbFestado As ComboBox)
        cbFestado.Items.Clear()
        cbFestado.Items.Add("Abierta")
        cbFestado.Items.Add("En proceso")
        cbFestado.Items.Add("Resuelta")
    End Sub
    Private Sub btnaincidencia_Click_1(sender As Object, e As EventArgs) Handles btnaincidencia.Click
        Dim formAgregar As New FrmAgregarincidencia()
        formAgregar.ShowDialog()
    End Sub
    Private Sub btnMincidentes_Click_1(sender As Object, e As EventArgs) Handles btnMincidentes.Click
        Dim cn As New cnControlIncidencia()
        Dim dt As DataTable = cn.ObtenerIncidencias()
        dtgListado.DataSource = dt
    End Sub
    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Me.Close()
    End Sub
    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        e.Layout.Bands(0).Columns("idIncidente").Header.Caption = "ID Incidencia"
        e.Layout.Bands(0).Columns("DNI").Header.Caption = "DNI"
        e.Layout.Bands(0).Columns("Empleado").Header.Caption = "Empleado"
        e.Layout.Bands(0).Columns("Tipo").Header.Caption = "Tipo"
        e.Layout.Bands(0).Columns("Descripcion").Header.Caption = "Descripción"
        e.Layout.Bands(0).Columns("FechaOcurrencia").Header.Caption = "Fecha Ocurrencia"
        e.Layout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
    End Sub
End Class
