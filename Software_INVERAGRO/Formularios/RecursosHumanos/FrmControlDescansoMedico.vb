Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports System.IO

Public Class FrmControlTransportesIF
    Dim cn As New cnPermisoLaboral
    Private Sub FrmControlDescansoMedico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        Consultar()
    End Sub
    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Close()
    End Sub

    Private Sub btnnuevodm_Click(sender As Object, e As EventArgs) Handles btnnuevoRrhhdm.Click
        Dim formAgregar As New FrmAgregarDescansoMedico()
        formAgregar._operacion = 1
        formAgregar.ShowDialog()
        Consultar()
    End Sub
    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        e.Layout.Bands(0).Columns("Cod.").Header.Caption = "Cod."

        With e.Layout.Bands(0)
            .Columns("verbtn3").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
            .Columns("verbtn3").ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
            .Columns("verbtn3").Header.Caption = "Ver PDF"
        End With


        e.Layout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        If e.Row.Cells.Exists("verbtn3") Then
            e.Row.Cells("verbtn3").Value = "Ver PDF"
            e.Row.Cells("verbtn3").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
            e.Row.Cells("verbtn3").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        End If

        If e.Row.Cells.Exists(7) Then
            e.Row.Cells(7).Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        End If
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "Con PDF", 7)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "Sin PDF", 7)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 10)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "CANCELADO", 10)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "CULMINADO", 10)
    End Sub
    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            With dtgListado
                Dim idpermiso As Integer = CInt(.ActiveRow.Cells(0).Value) ' Usa la columna "idIncidente"
                ' Verificar cuál botón fue clicado
                If (e.Cell.Column.Key = "verbtn3") Then
                    Dim estadoPDF As String = .ActiveRow.Cells(7).Value.ToString()
                    If estadoPDF = "Sin PDF" Then
                        MessageBox.Show("EL REGISTRO NO CUENTA CON DOCUMENTO ADJUNTO.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If

                    Dim pdfData As Byte() = cn.Cn_ObtenerArchivo3(idpermiso) ' Método para obtener archivo de paternidad
                    MostrarPDF(pdfData, "documento_adjunto.pdf")
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message) ' Cambia aquí para mostrar un mensaje de error genérico
            ' clsBasicas.controlException(Name, ex) ' Si tienes un método de manejo de excepciones
        End Try
    End Sub

    Private Sub MostrarPDF(pdfData As Byte(), fileName As String)
        If pdfData IsNot Nothing AndAlso pdfData.Length > 0 Then
            Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), fileName)
            File.WriteAllBytes(tempFilePath, pdfData)
            Process.Start(tempFilePath)
        Else
            MessageBox.Show("No se encontró el archivo PDF en la base de datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Sub Consultar()
        Dim obj As New coPermisoLaboral
        obj.FechaInicio = dtpFechaDesde.Value
        obj.FechaFin = dtpFechaHasta.Value
        If obj.FechaInicio > obj.FechaFin Then
            MessageBox.Show("La fecha desde debe ser anterior a la fecha hasta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim fechaDesdeStr As String = obj.FechaInicio.ToString("yyyy-MM-dd HH:mm:ss")
        Dim fechaHastaStr As String = obj.FechaFin.ToString("yyyy-MM-dd HH:mm:ss")
        obj.FechaInicio = DateTime.Parse(fechaDesdeStr)
        obj.FechaFin = DateTime.Parse(fechaHastaStr)
        Dim dt As DataTable = cn.Cn_Consultar(obj)
        dtgListado.DataSource = dt
    End Sub
    Private Sub btnMincidentes_Click(sender As Object, e As EventArgs) Handles btnMincidentes.Click
        Dim cn As New cnPermisoLaboral()
        Consultar()
    End Sub



    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportarRrhhdm.Click
        clsBasicas.ExportarExcel("Lista de Permisos", dtgListado)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2Rrhhdm.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim idpermiso As Integer
                Integer.TryParse(dtgListado.ActiveRow.Cells(0).Value.ToString(), idpermiso)
                Dim f As New FrmadjuntardoccPermiso()
                f.idpermiso = idpermiso
                f.ShowDialog()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub Conceptos_Click(sender As Object, e As EventArgs) Handles ConceptosRRHHVACACIONESPERMISOS.Click
        Dim f As New FrmAgregarConceptosPermisos
        f.ShowDialog()
    End Sub

    Private Sub btneditarpermisorrhh_Click(sender As Object, e As EventArgs) Handles btneditarpermisorrhh.Click
        Try
            If (dtgListado.Rows.Count > 0) Then
                Dim estado As String = dtgListado.ActiveRow.Cells(10).Value.ToString()
                If estado = "CANCELADO" Then
                    MessageBox.Show("El permiso seleccionado ya fue cancelado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                ElseIf estado = "CULMINADO" Then
                    MessageBox.Show("El permiso seleccionado ya culmino.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                Else
                    If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                        Dim f As New FrmAgregarDescansoMedico
                        f._idpermisolaboral = dtgListado.ActiveRow.Cells(0).Value.ToString
                        f._operacion = 2
                        f.permisotipo = dtgListado.ActiveRow.Cells(3).Value.ToString()
                        f.ShowDialog()
                        Consultar()
                    Else
                        msj_advert("Seleccione un Registro")
                    End If
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub btncancelarpermisorrrhh_Click(sender As Object, e As EventArgs) Handles btncancelarpermisorrrhh.Click
        Try
            If (dtgListado.Rows.Count > 0) Then
                Dim estado As String = dtgListado.ActiveRow.Cells(10).Value.ToString()
                If estado = "CANCELADO" Then
                    MessageBox.Show("El permiso seleccionado ya fue cancelado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                ElseIf estado = "CULMINADO" Then
                    MessageBox.Show("El permiso seleccionado ya culmino.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                Else
                    Dim result As DialogResult = MessageBox.Show("¿Realmente quiere cancelar el permiso?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result = DialogResult.Yes Then
                        Eliminar()
                    End If
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try

    End Sub
    Private Sub Eliminar()
        Try
            Dim permiso As New coPermisoLaboral()
            permiso.idpermisolaboral = dtgListado.ActiveRow.Cells(0).Value.ToString()
            Dim cn As New cnPermisoLaboral()
            Dim resultado = cn.cn_cancelarpermisolaboral(permiso)
            If resultado.success Then
                MessageBox.Show(resultado.message, "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Consultar()
            Else
                MessageBox.Show(resultado.message, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class