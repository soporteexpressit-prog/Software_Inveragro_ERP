Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmControlInseminacion
    Dim cn As New cnControlGestacion
    Dim ds As New DataSet
    Public valorPlantel As String = ""
    Public idPlantel As Integer = 0

    Private Sub FrmControlInseminacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
            Me.Size = New Size(1280, 750)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        clsBasicas.LlenarComboAnios(CmbAnios)
        NumLote.Value = clsBasicas.ObtenerNumeroSemanaFecha(DateTime.Now)
        Ptbx_Cargando.Visible = True
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        LblPlantel.Text = valorPlantel
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False
            Dim intervalo As (Date, Date) = clsBasicas.ObtenerIntervaloSemana(CmbAnios.Text, NumLote.Value)
            LblPeriodo.Text = clsBasicas.ObtenerPeriodoDeSemana(CmbAnios.Text, NumLote.Value)

            Dim obj As New coControlGestacion With {
                .FechaDesde = intervalo.Item1,
                .FechaHasta = intervalo.Item2,
                .IdPlantel = idPlantel
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 2)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlGestacion = CType(e.Argument, coControlGestacion)
            ds = cn.Cn_Consultar(obj).Copy
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
            dtgListado.DisplayLayout.Bands(0).Columns("idControlFicha").Hidden = True
            dtgListado.DisplayLayout.Bands(1).Columns("idControlFicha").Hidden = True
            PintarFilasPorEtapa()
            PintarFilasPorEstadoParto()
            Colorear()
        End If
    End Sub

    Private Sub PintarFilasPorEtapa()
        For Each fila As UltraGridRow In dtgListado.Rows
            Dim etapa As String = fila.Cells("Tipo Pérdida").Value?.ToString().ToUpper().Trim()

            Select Case etapa
                Case "ABORTO"
                    fila.Appearance.BackColor = Color.LightSalmon
                Case "REPETICIÓN CELO"
                    fila.Appearance.BackColor = Color.LightYellow
                Case "FALSA PREÑEZ"
                    fila.Appearance.BackColor = Color.LightGray
            End Select
        Next
    End Sub

    Private Sub PintarFilasPorEstadoParto()
        For Each fila As UltraGridRow In dtgListado.Rows
            Dim estadoParto As String = fila.Cells("Estado Parto").Value?.ToString().ToUpper().Trim()

            Select Case estadoParto
                Case "MORTALIDAD"
                    fila.Appearance.BackColor = Color.LightCoral
            End Select
        Next
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estadoParto As Integer = 10

            'estadoParto
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "PARIÓ", estadoParto)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "PÉRDIDA", estadoParto)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estadoParto)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "MORTALIDAD", estadoParto)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estadoParto).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Consultar()
    End Sub

    Private Sub BtnExportarInseminacion_Click(sender As Object, e As EventArgs) Handles BtnExportarInseminacionpro.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL-INSEMINACIONES", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmControlInseminacion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub NumLote_ValueChanged(sender As Object, e As EventArgs) Handles NumLote.ValueChanged
        If CmbAnios.Text = "" Or NumLote.Value = 0 Then
            LblPeriodo.Text = ""
            Return
        End If

        LblPeriodo.Text = clsBasicas.ObtenerPeriodoDeSemana(CmbAnios.Text, NumLote.Value)
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class