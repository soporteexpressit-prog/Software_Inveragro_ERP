Imports System.IO
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmControlSCTR
    Dim cn As New cnControlSeguro
    Dim ds As New DataSet
    Private Sub FrmControlSCTR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializar()
        Consultar()
    End Sub

    Sub Consultar()
        Try
            If dtpFechaDesde.Value > dtpFechaHasta.Value Then
                msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
                Return
            End If

            Dim obj As New coControlSeguro With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .Estado = cmbEstado.Text
            }
            ds = cn.Cn_ConsultarSeguroTrabajador(obj).Copy

            ds.DataSetName = "tmp"

            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(0), False)

            ds.Relations.Add(relation1)
            dtgListado.DataSource = ds

            dtgListado.DisplayLayout.Bands(1).Columns(0).Hidden = True

            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "Sin PDF", 10)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "Con PDF", 10)

            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "CANCELADO", 11)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 11)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoRrhhCrtlSegt.Click
        Try
            Dim f As New FrmRegistrarSCTR
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Consultar()
    End Sub

    Sub Inicializar()
        dtpFechaDesde.Text = Nothing
        dtpFechaHasta.Text = Nothing
        cmbEstado.SelectedIndex = 0
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportarRrhhCrtlSegt.Click
        Try
            clsBasicas.ExportarExcel("Control Seguros Trabajadores", dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        If e.Row.Band.Index = 0 Then
            Dim colVerPDF As Infragistics.Win.UltraWinGrid.UltraGridColumn
            If dtgListado.DisplayLayout.Bands(0).Columns.Exists("Ver PDF") Then
                colVerPDF = dtgListado.DisplayLayout.Bands(0).Columns("Ver PDF")
                colVerPDF.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerPDF.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                If Not e.ReInitialize Then
                    e.Row.Cells("Ver PDF").Value = "Ver PDF"
                    e.Row.Cells("Ver PDF").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                End If
            End If
        End If
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            With dtgListado
                If (e.Cell.Column.Key = "Ver PDF") Then

                    Dim estadoPDF As String = .ActiveRow.Cells("Estado PDF").Value.ToString()
                    If estadoPDF = "Sin PDF" Then
                        msj_advert("EL REGISTRO NO TIENE DOCUMENTO EN ADJUNTO")
                        Return
                    End If

                    Dim idMemorandum As Integer = CInt(.ActiveRow.Cells(0).Value)
                    Dim pdfData As Byte() = cn.Cn_ObtenerArchivoTrabajador(idMemorandum)
                    If pdfData IsNot Nothing AndAlso pdfData.Length > 0 Then
                        Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "seguro.pdf")

                        File.WriteAllBytes(tempFilePath, pdfData)
                        Process.Start(tempFilePath)
                    Else
                        MessageBox.Show("No se encontró el archivo PDF en la base de datos.")
                    End If
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnAdjuntar_Click(sender As Object, e As EventArgs) Handles btnAdjuntarRrhhCrtlSegt.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim seguroId As Integer
                Integer.TryParse(dtgListado.ActiveRow.Cells(0).Value.ToString(), seguroId)
                Dim f As New FrmMantArchivoSeguro()
                f.SeguroId = seguroId
                f.ShowDialog()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelarRrhhCrtlSegt.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim estado As String = dtgListado.ActiveRow.Cells(11).Value.ToString()
                If estado = "CANCELADO" Or estado = "FINALIZADO" Then
                    msj_advert("El seguro ya se encuentra cancelado o finalizado")
                    Return
                End If

                Dim f As New FrmMotivoCancelarSeguro
                f.Id_Seguro = CInt(dtgListado.ActiveRow.Cells(0).Value.ToString())
                f.ShowDialog()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

End Class