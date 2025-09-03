Imports System.Data.SqlClient
Imports CapaNegocio
Imports CapaObjetos
Imports System.IO

Public Class FrmControlIncidenteAccidente
    Dim ds As New DataSet
    Dim cn As New cnControlIncidencia
    Private Sub FrmControlIncidenteAccidente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        Consultar()
    End Sub
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
    Dim formincidencia = New FrmAgregarincidencia()

    Private Sub btnaincidencia_Click_1(sender As Object, e As EventArgs) Handles btnaincidenciaRrhhctrlinyac.Click
        Dim formAgregar As New FrmAgregarincidencia()
        formAgregar.ShowDialog()
        Consultar()
    End Sub


    Sub Consultar()
        Dim obj As New coControlincidencia
        obj.FechaDesde = dtpFechaDesde.Value
        obj.FechaHasta = dtpFechaHasta.Value

        ' Verifica que las fechas no sean nulas o inválidas
        If obj.FechaDesde > obj.FechaHasta Then
            MessageBox.Show("La fecha desde debe ser anterior a la fecha hasta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        ' Convertir a formato correcto si es necesario
        Dim fechaDesdeStr As String = obj.FechaDesde.ToString("yyyy-MM-dd HH:mm:ss")
        Dim fechaHastaStr As String = obj.FechaHasta.ToString("yyyy-MM-dd HH:mm:ss")

        ' Asignar las fechas al objeto
        obj.FechaDesde = DateTime.Parse(fechaDesdeStr)
        obj.FechaHasta = DateTime.Parse(fechaHastaStr)

        Dim dt As DataTable = cn.Cn_Consultar(obj)
        dtgListado.DataSource = dt
    End Sub

    Private Sub btnMincidentes_Click_1(sender As Object, e As EventArgs) Handles btnMincidentes.Click
        Dim cn As New cnControlIncidencia()
        Consultar()
    End Sub
    Private Sub btncerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        e.Layout.Bands(0).Columns("idIncidente").Header.Caption = "ID Incidencia"
        If Not e.Layout.Bands(0).Columns.Exists("Ver PDF") Then
            Dim column As Infragistics.Win.UltraWinGrid.UltraGridColumn = e.Layout.Bands(0).Columns.Add("Ver PDF")
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        End If
        e.Layout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns

    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        Dim column As Infragistics.Win.UltraWinGrid.UltraGridColumn = dtgListado.DisplayLayout.Bands(0).Columns("Ver PDF")
        column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always

        If e.Row.Cells.Exists("Ver PDF") Then
            e.Row.Cells("Ver PDF").Value = "Ver PDF"
            e.Row.Cells("Ver PDF").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        End If

        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "MORTAL", 4)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACCIDENTE LEVE", 4)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "ACCIDENTE INCAPACITANTE", 4)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "Con PDF", 9)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "Sin PDF", 9)
    End Sub
    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            With dtgListado
                If (e.Cell.Column.Key = "Ver PDF") Then
                    Dim estadoPDF As String = .ActiveRow.Cells("Estado PDF").Value.ToString()
                    If estadoPDF = "Sin PDF" Then
                        MessageBox.Show("EL REGISTRO NO TIENE DOCUMENTO EN ADJUNTO")
                        Return
                    End If

                    Dim idIncidente As Integer = CInt(.ActiveRow.Cells("idIncidente").Value) ' Usa la columna "idIncidente"
                    Dim pdfData As Byte() = cn.Cn_ObtenerArchivo(idIncidente)
                    If pdfData IsNot Nothing AndAlso pdfData.Length > 0 Then
                        Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "recepcion.pdf")

                        File.WriteAllBytes(tempFilePath, pdfData)
                        Process.Start(tempFilePath)
                    Else
                        MessageBox.Show("No se encontró el archivo PDF en la base de datos.")
                    End If
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message) ' Cambia aquí para mostrar un mensaje de error genérico
            ' clsBasicas.controlException(Name, ex) ' Si tienes un método de manejo de excepciones
        End Try
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportarRrhhctrlinyac.Click

        ImprimirReportePorIncidente()
    End Sub


    Sub ImprimirReportePorIncidente()
        Dim selectedRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If selectedRow Is Nothing Then
            MsgBox("Por favor, seleccione un registro.")
            Return
        End If
        Dim selectedId As Integer = CInt(selectedRow.Cells(0).Value)
        Dim obj As New coControlincidencia
        Dim dsCapacitacion As New DataSet
        obj.codigo = selectedId
        dsCapacitacion = cn.Cn_ConsultarId(obj).Copy

        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_Incidentes.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1Rrhhctrlinyac.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim incidenciaId As Integer
                Integer.TryParse(dtgListado.ActiveRow.Cells(0).Value.ToString(), incidenciaId)
                Dim f As New FrmInsertarPdfIncidente()
                f.incidenciaId = incidenciaId
                f.ShowDialog()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class
