Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmHistoricoRecepcion
    Dim cn As New cnIngreso
    Dim ds As New DataSet
    Private Sub FrmHistoricoRecepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultarHistoricoRecepcion()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub
    Private Sub ConsultarHistoricoRecepcion()
        Dim obj As New coIngreso
        obj.Codigo = CInt(lblCodigo.Text)
        ds = cn.Cn_ConsultarRecepcionxCodigo(obj).Copy

        ds.DataSetName = "tmp"

        Dim relation1 As New DataRelation("tb_relacion1", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(0), False)

        ds.Relations.Add(relation1)
        dtgListado.DataSource = ds

        dtgListado.DisplayLayout.Bands(1).Columns(0).Hidden = True

        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "Sin Evidencia", 5)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "Con Evidencia", 5)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            With dtgListado
                If (e.Cell.Column.Key = "Evidencia") Then

                    Dim estadoPDF As String = .ActiveRow.Cells(5).Value.ToString()
                    If estadoPDF = "Sin Evidencia" Then
                        msj_advert("EL REGISTRO NO TIENE DOCUMENTO EN ADJUNTO")
                        Return
                    End If
                    Dim idRecepcion As Integer = CInt(.ActiveRow.Cells(0).Value)
                    Dim dataarchivo As Byte() = cn.Cn_ObtenerArchivo(idRecepcion)

                    ProcesarArchivo(idRecepcion, dataarchivo)

                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ProcesarArchivo(ByVal idRecepcion As Integer, ByVal dataarchivo As Byte())
        Try
            If dataarchivo IsNot Nothing AndAlso dataarchivo.Length > 0 Then
                Dim tipoArchivo As String = ObtenerTipoArchivo(dataarchivo)

                Select Case tipoArchivo
                    Case "PDF"
                        Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "ArchivoEvidencia" & idRecepcion.ToString() & ".pdf")
                        File.WriteAllBytes(tempFilePath, dataarchivo)
                        Process.Start(tempFilePath)

                    Case "Imagen"
                        Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "documento.png")
                        File.WriteAllBytes(tempFilePath, dataarchivo)
                        Process.Start(tempFilePath)

                    Case Else
                        MessageBox.Show("El archivo no es una imagen ni un PDF válido.")
                End Select
            Else
                MessageBox.Show("No se encontró ningún archivo en la base de datos.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al procesar el archivo: " & ex.Message)
        End Try
    End Sub

    ' Función para determinar si el archivo es una imagen (PNG o JPG) o un PDF
    Public Function ObtenerTipoArchivo(ByVal data() As Byte) As String
        Dim pdfSignature As Byte() = {&H25, &H50, &H44, &H46} ' %PDF en ASCII
        Dim pngSignature As Byte() = {&H89, &H50, &H4E, &H47} ' PNG signature
        Dim jpgSignature As Byte() = {&HFF, &HD8, &HFF} ' JPG signature

        If data.Length >= 4 AndAlso data.Take(4).SequenceEqual(pdfSignature) Then
            Return "PDF"
        ElseIf data.Length >= 4 AndAlso data.Take(4).SequenceEqual(pngSignature) Then
            Return "Imagen"
        ElseIf data.Length >= 3 AndAlso data.Take(3).SequenceEqual(jpgSignature) Then
            Return "Imagen"
        Else
            Return "Desconocido"
        End If
    End Function

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(4).Hidden = True
                .Columns(5).Width = 80
                .Columns(5).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(5).CellButtonAppearance.Image = My.Resources.buscando__1_
                .Columns(5).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns(6).Header.VisiblePosition = 3
            End With
            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 1)
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