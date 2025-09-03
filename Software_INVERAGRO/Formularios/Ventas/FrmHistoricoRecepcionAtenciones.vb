Imports System.IO
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmHistoricoRecepcionAtenciones
    Dim cn As New cnVentas
    Dim ds As New DataSet
    Private Sub FrmHistoricoRecepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultarHistoricoRecepcion()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub
    Private Sub ConsultarHistoricoRecepcion()
        Dim obj As New coVentas
        obj.Codigo = CInt(lblCodigo.Text)
        ds = cn.Cn_ConsultarDespachoxCodigoRequerimiento(obj).Copy

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

                    Dim idRecepcion As Integer = CInt(.ActiveRow.Cells(0).Value)
                    Dim pdfData As Byte() = cn.Cn_ObtenerArchivo(idRecepcion)
                    If pdfData IsNot Nothing AndAlso pdfData.Length > 0 Then
                        Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "documento.pdf")

                        File.WriteAllBytes(tempFilePath, pdfData)
                        Process.Start(tempFilePath)
                    Else
                        MessageBox.Show("No se encontró el archivo PDF en la base de datos.")
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

                .Columns("Conductor").Hidden = True
                .Columns("Placa").Hidden = True
                .Columns("Transportista").Hidden = True
                .Columns("PesoBruto").Hidden = True
                .Columns("Punto.Llegado").Hidden = True
                .Columns("Punto.Partida").Hidden = True
                .Columns("F.Traslado").Hidden = True
                .Columns("Estado PDF").Hidden = True
                .Columns("Ver PDF").Hidden = True
                .Columns("N° Guia").Hidden = True
                .Columns("horometro_inicial").Hidden = True
                .Columns("horometro_fin").Hidden = True
                .Columns("idrecepcion").Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub



    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class