Imports System.IO
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmVerGuiaTraslado
    Public idpedido As Integer
    Dim cn As New cnVentas
    Dim ds As New DataSet
    Private Sub FrmHistoricoRecepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Consultar()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub
    Private Sub Consultar()
        Dim obj As New coVentas
        obj.Codigo = idpedido
        ds = New DataSet
        ds = cn.Cn_VerGuiasTrasladoPedidosCerdo(obj).Copy

        ds.DataSetName = "tmp"

        Dim relation1 As New DataRelation("tb_relacion1", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(0), False)

        ds.Relations.Add(relation1)
        dtgListado.DataSource = ds

        dtgListado.DisplayLayout.Bands(1).Columns(0).Hidden = True

        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "Sin PDF", 5)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "Con PDF", 5)

        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", 14)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.OrangeRed, Color.White, "PENDIENTE", 14)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ENTREGADO", 14)

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub


    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        If e.Row.Band.Index = 0 Then
            Dim colVerPDF As Infragistics.Win.UltraWinGrid.UltraGridColumn
            If dtgListado.DisplayLayout.Bands(0).Columns.Exists("Ver PDF") Then
                colVerPDF = dtgListado.DisplayLayout.Bands(0).Columns("Ver PDF")
                colVerPDF.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerPDF.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                If Not e.ReInitialize Then
                    e.Row.Cells("Ver PDF").Value = "Ver Archivo"
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

                    Dim idRecepcion As Integer = CInt(.ActiveRow.Cells(0).Value)
                    Dim imagenData As Byte() = cn.Cn_ObtenerArchivo(idRecepcion)

                    If imagenData IsNot Nothing AndAlso imagenData.Length > 0 Then
                        Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "documento.pdf")

                        ' Guarda la imagen en el disco
                        File.WriteAllBytes(tempFilePath, imagenData)

                        ' Abre la imagen en el visor de imágenes predeterminado
                        Process.Start(tempFilePath)
                    Else
                        MessageBox.Show("No se encontró la imagen en la base de datos.")
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub




    Private Sub btnreporte_Click(sender As Object, e As EventArgs) Handles btnreporte.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            Dim obj As New coIngreso
            Dim cn As New cnIngreso
            obj.Codigo = activeRow.Cells(0).Value.ToString
            Dim ds As New DataSet
            ds = cn.Cn_ReporteGuiaTrasladoVentaxCodigo(obj).Copy
            ds.DataSetName = "bd"
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_GuiaTraslado.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(ds)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try

    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub


End Class


