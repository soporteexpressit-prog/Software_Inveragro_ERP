Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmReportePartoDetallado
    Dim cn As New cnControlAnimal
    Public idPlantel As Integer = 0
    Dim ds As New DataSet
    Private search As Boolean = False

    Private Sub FrmReportePartoDetallado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.LlenarComboAnios(CmbAnios)
            ListarLotes()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarLotes()
        Dim cn As New cnControlLoteDestete
        Dim obj As New coControlLoteDestete With {
           .Anio = CmbAnios.Text,
           .IdPlantel = idPlantel
        }
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarLotesAnioCombo(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbLotes
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
        search = True
    End Sub

    Private Sub CmbAnios_TextChanged(sender As Object, e As EventArgs) Handles CmbAnios.TextChanged
        If (search) Then
            ListarLotes()
        End If
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            Dim obj As New coControlAnimal With {
                .IdLote = CmbLotes.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            ds = cn.Cn_ReportePartoDetallado(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
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
            ToolStrip1.Enabled = True
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            dtgListado.DisplayLayout.Bands(1).Columns(0).Hidden = True
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim cumplio As Integer = 13

            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                Dim cell = row.Cells(cumplio)
                Dim v As Integer
                If Integer.TryParse(cell.Value?.ToString(), v) Then
                    ' configurar los tres estados de la celda
                    With cell.Appearance
                        .BackColor = If(v = 0, Color.LightGreen, Color.Red)
                        .ForeColor = If(v = 0, Color.LightGreen, Color.Red)
                        .FontData.Bold = DefaultableBoolean.True
                    End With
                    With cell.ActiveAppearance
                        .BackColor = cell.Appearance.BackColor
                        .ForeColor = cell.Appearance.ForeColor
                        .FontData.Bold = DefaultableBoolean.True
                    End With
                    With cell.SelectedAppearance
                        .BackColor = cell.Appearance.BackColor
                        .ForeColor = cell.Appearance.ForeColor
                        .FontData.Bold = DefaultableBoolean.True
                    End With
                End If
            Next

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(cumplio).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub CmbLotes_ValueChanged(sender As Object, e As EventArgs) Handles CmbLotes.ValueChanged
        Consultar()
    End Sub

    Private Sub BtnExportarhistoricomortalidad_Click(sender As Object, e As EventArgs) Handles BtnExportarhistoricomortalidad.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE DE PARTO DETALLADO", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class