Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmReporteCumplimientoPresupuesto
    Dim cn As New cnControlAlimento
    Public idUbicacion As Integer = 0
    Public valorPlantel As String = ""
    Dim tbtmp As New DataTable

    Private Sub FrmReporteConsumoDiario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LblPlantel.Text = valorPlantel
            ListarCampañas()
            ListarGalpones(idUbicacion)
            Consultar()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarCampañas()
        Dim obj As New coControlAlimento With {
            .IdUbicacion = idUbicacion
        }
        Dim tb As New DataTable
        tb = cn.Cn_ListarCampañasPorPlantel(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Campaña"
        With CmbCampanias
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarGalpones(idplantel As Integer)
        Dim cn As New cnGalpon
        Dim tb As New DataTable
        Dim obj As New coGalpon With {
            .IdUbicacion = idplantel
        }
        tb = cn.Cn_Listar_Galpones_Por_Plantel(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Galpón"
        With cmbGalpon
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False
            Dim obj As New coControlAlimento With {
                .IdCampana = CmbCampanias.Value,
                .IdGalpon = cmbGalpon.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)
            tbtmp = cn.Cn_ConsultarCumplimientoPresupuestoAli(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            ToolStrip1.Enabled = True
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim cumplio As Integer = 4

            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                Dim cell = row.Cells(cumplio)
                Dim v As Integer
                If Integer.TryParse(cell.Value?.ToString(), v) Then
                    ' configurar los tres estados de la celda
                    With cell.Appearance
                        .BackColor = If(v = 1, Color.LightGreen, Color.Red)
                        .ForeColor = If(v = 1, Color.LightGreen, Color.Red)
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

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE DE CUMPLIMIENTO DE PRESUPUESTO ALIMENTICIO", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class