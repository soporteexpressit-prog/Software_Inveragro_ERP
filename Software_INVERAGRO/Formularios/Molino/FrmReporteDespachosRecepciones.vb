Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmReporteDespachosRecepciones
    Dim cn As New cnNucleo
    Dim tbtmp As New DataTable
    Dim semana As (Date, Date)

    Private Sub FrmReporteDespachosRecepciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        clsBasicas.LlenarComboAnios(CmbAnios)
        NumSemana.Value = ObtenerNumeroSemana(DateTime.Now)
        semana = ObtenerIntervaloSemana(CmbAnios.Text, NumSemana.Value)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Public Function ObtenerNumeroSemana(fecha As Date) As Integer
        Dim primerDiaAño As Date = New Date(fecha.Year, 1, 1)
        Dim primerDomingo As Date = primerDiaAño.AddDays((6 - primerDiaAño.DayOfWeek + 7) Mod 7)

        If primerDomingo > primerDiaAño Then
            primerDomingo = primerDomingo.AddDays(-7)
        End If

        Dim numeroSemana As Integer = CInt(Math.Ceiling((fecha - primerDomingo).Days / 7))

        Return numeroSemana
    End Function

    Private Function ObtenerIntervaloSemana(ByVal anio As Integer, ByVal numeroSemana As Integer) As (Date, Date)
        Dim primerDiaAño As Date = New Date(anio, 1, 1)

        ' Encontrar el primer domingo del año
        Dim primerDomingo As Date = primerDiaAño
        While primerDomingo.DayOfWeek <> DayOfWeek.Sunday
            primerDomingo = primerDomingo.AddDays(1)
        End While

        ' Calcular el inicio y fin de la semana deseada
        Dim fechaInicio As Date = primerDomingo.AddDays((numeroSemana - 2) * 7)
        Dim fechaFin As Date = fechaInicio.AddDays(6) ' Sábado de la semana siguiente

        Return (fechaInicio, fechaFin)
    End Function

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        GrupoFiltros.Enabled = False
        GrupoFiltros.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        GrupoFiltros.Enabled = True
        GrupoFiltros.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coNucleo With {
                .FechaDesde = semana.Item1,
                .FechaHasta = semana.Item2
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coNucleo = CType(e.Argument, coNucleo)
            tbtmp = cn.Cn_ReporteDespachoRecepcion(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DesbloquearControladores()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            dtgListado.DisplayLayout.Bands(0).Columns("idSalida").Hidden = True
            PintarColumnaPorIndiceDespacho(4)
            PintarColumnaPorIndiceDespacho(5)
            PintarColumnaPorIndiceRecepcion(6)
            PintarColumnaPorIndiceRecepcion(7)
        End If
    End Sub

    Private Sub PintarColumnaPorIndiceDespacho(indiceColumna As Integer)
        For Each fila As UltraGridRow In dtgListado.Rows
            If fila.Cells.Count > indiceColumna Then
                With fila.Cells(indiceColumna).Appearance
                    .BackColor = Color.FromArgb(234, 239, 239)
                    .FontData.Bold = DefaultableBoolean.True
                End With
            End If
        Next
    End Sub

    Private Sub PintarColumnaPorIndiceRecepcion(indiceColumna As Integer)
        For Each fila As UltraGridRow In dtgListado.Rows
            If fila.Cells.Count > indiceColumna Then
                With fila.Cells(indiceColumna).Appearance
                    .BackColor = Color.FromArgb(220, 240, 220)
                    .FontData.Bold = DefaultableBoolean.True
                End With
            End If
        Next
    End Sub

    Private Sub btnExportarNpea_Click(sender As Object, e As EventArgs) Handles btnExportarNpea.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE DEPACHOS Y RECEPCIONES", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        semana = ObtenerIntervaloSemana(CmbAnios.Text, NumSemana.Value)
        Consultar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 2)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 3)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 4)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub NumSemana_ValueChanged(sender As Object, e As EventArgs) Handles NumSemana.ValueChanged
        If Not String.IsNullOrEmpty(CmbAnios.Text) Then
            semana = ObtenerIntervaloSemana(CmbAnios.Text, NumSemana.Value)
            lblPeriodo.Text = "Del " & semana.Item1.ToString("dd/MM/yyyy") &
                          " al " & semana.Item2.ToString("dd/MM/yyyy")
        End If
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class