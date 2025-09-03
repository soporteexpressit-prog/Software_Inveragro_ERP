Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmResumenLotes
    Dim cn As New cnControlLoteDestete
    Dim ds As New DataSet

    Private Sub FrmResumenLotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        For i As Integer = DateTime.Now.Year - 5 To DateTime.Now.Year + 5
            CmbAnios.Items.Add(i.ToString())
        Next
        CmbAnios.DropDownStyle = ComboBoxStyle.DropDownList
        CmbAnios.Text = DateTime.Now.Year.ToString()
        Ptbx_Cargando.Visible = True
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True

            Dim obj As New coControlLoteDestete With {
                .Anio = CInt(CmbAnios.Text)
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)

            ds = cn.Cn_ConsultarResumenLotes(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns("idLote").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idLote").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idControlFicha").ColumnMapping = MappingType.Hidden
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = ds.Tables(0)
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estado As Integer = 9
            Dim tipoBajada As Integer = 10

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "CERRADO", estado)

            'tipoBajada
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "COMPLETO", tipoBajada)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightYellow, Color.Black, "PARCIAL", tipoBajada)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", tipoBajada)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
                .Columns(tipoBajada).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub CmbAnios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbAnios.SelectedIndexChanged
        Consultar()
    End Sub

    Private Sub BtnExportarControlCerda_Click(sender As Object, e As EventArgs) Handles BtnExportarControlCerda.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("RESUMEN DE LOTES ANUAL", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class