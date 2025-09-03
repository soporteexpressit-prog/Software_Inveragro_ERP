Imports System.IO
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmControlMemoDespido
    Dim cn As New cnControlMemoDespido
    Dim tbtmp As New DataTable
    Private Sub FrmMemorandum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        cmbGrado.SelectedIndex = 0
        Consultar()
    End Sub

    Sub Consultar()
        Try
            If dtpFechaDesde.Value > dtpFechaHasta.Value Then
                msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
                Return
            End If

            Dim obj As New coControlMemoDespido With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .Nivel = cmbGrado.Text
            }
            dtgListado.DataSource = cn.Cn_Consultar(obj)
            dtgListado.DisplayLayout.Bands(0).Columns(8).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center

            clsBasicas.Colorear_SegunValor(dtgListado, Color.Gray, Color.White, "BAJO", 4)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "MEDIO", 4)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ALTO", 4)

            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "Sin PDF", 9)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "Con PDF", 9)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        Dim column As Infragistics.Win.UltraWinGrid.UltraGridColumn = dtgListado.DisplayLayout.Bands(0).Columns("Ver PDF")
        column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        If Not e.ReInitialize Then
            e.Row.Cells("Ver PDF").Value = "Ver PDF"
            e.Row.Cells("Ver PDF").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        End If
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoRrhhSanyd.Click
        Dim f As New FrmRegMemoDespido
        f.ShowDialog()
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportarRrhhSanyd.Click
        Try
            clsBasicas.ExportarExcel("Control Memoradum", dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
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
                    Dim pdfData As Byte() = cn.Cn_ObtenerArchivo(idMemorandum)
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
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1RrhhSanyd.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim idMemorandum As Integer
                Integer.TryParse(dtgListado.ActiveRow.Cells(0).Value.ToString(), idMemorandum)
                Dim f As New FrmMantArchivoMemoDespido()
                f.MemorandumId = idMemorandum
                f.ShowDialog()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub ImprimirFormatoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirFormatoToolStripMenuItem.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim tipoArchivo = dtgListado.ActiveRow.Cells(5).Value.ToString()

                If tipoArchivo = "MEMORANDUM" Then
                    ImprimirFormatoMemorandum()
                Else
                    ImprimirFormatoDespido()
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Sub ImprimirFormatoMemorandum()
        Dim selectedRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If selectedRow Is Nothing Then
            MsgBox("Por favor, seleccione un registro.")
            Return
        End If

        Dim obj As New coControlMemoDespido With {
            .IdMotivoMemoDespido = CInt(dtgListado.ActiveRow.Cells(0).Value)
        }

        Dim tbMemo As DataTable = cn.Cn_ConsultarPorId(obj)
        Dim tbContenidoFormato As DataTable = cn.Cn_ContenidoFormatoMemo()

        Dim ds As New DataSet("bd")
        ds.Tables.Add(tbMemo.Copy)
        ds.Tables.Add(tbContenidoFormato.Copy)

        Dim StiReport1 As New Stimulsoft.Report.StiReport
        StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_FormatoMemorandum.mrt"))
        StiReport1.Compile()

        StiReport1.Dictionary.Clear()
        StiReport1.RegData(ds)
        StiReport1.Dictionary.Synchronize()
        StiReport1.Show()
    End Sub

    Sub ImprimirFormatoDespido()
        Dim selectedRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If selectedRow Is Nothing Then
            MsgBox("Por favor, seleccione un registro.")
            Return
        End If

        Dim obj As New coControlMemoDespido With {
            .IdMotivoMemoDespido = CInt(dtgListado.ActiveRow.Cells(0).Value)
        }

        Dim tbMemo As DataTable = cn.Cn_ConsultarPorId(obj)
        Dim tbContenidoFormato As DataTable = cn.Cn_ContenidoFormatoDespido()

        Dim ds As New DataSet("bd")
        ds.Tables.Add(tbMemo.Copy)
        ds.Tables.Add(tbContenidoFormato.Copy)

        Dim StiReport1 As New Stimulsoft.Report.StiReport
        StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_FormatoDespido.mrt"))
        StiReport1.Compile()

        StiReport1.Dictionary.Clear()
        StiReport1.RegData(ds)
        StiReport1.Dictionary.Synchronize()
        StiReport1.Show()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Consultar()
    End Sub

    Private Sub ckfiltro_CheckedChanged(sender As Object, e As EventArgs) Handles ckfiltro.CheckedChanged
        clsBasicas.Filtrar_Tabla(dtgListado, ckfiltro.Checked)
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class