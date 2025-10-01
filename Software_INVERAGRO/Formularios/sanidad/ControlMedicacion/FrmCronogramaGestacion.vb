Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmCronogramaGestacion
    Dim cn As New cnControlMedico
    Dim tbtmp As New DataTable
    Public idUbicacion As Integer = 0

    Private Sub FrmCronogramaGestacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        clsBasicas.LlenarComboAnios(CmbAnios)
        NumLote.Value = clsBasicas.ObtenerNumeroSemanaFecha(DateTime.Now)
        Ptbx_Cargando.Visible = True
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        GrupoFiltros.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        GrupoFiltros.Enabled = True
        ToolStrip1.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False
            Dim intervalo As (Date, Date) = clsBasicas.ObtenerIntervaloSemana(CmbAnios.Text, NumLote.Value)
            LblPeriodo.Text = clsBasicas.ObtenerPeriodoDeSemana(CmbAnios.Text, NumLote.Value)

            Dim obj As New coControlMedico With {
                .NumSemana = NumLote.Value,
                .FechaInicio = intervalo.Item1,
                .FechaFin = intervalo.Item2,
                .IdUbicacion = idUbicacion
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlMedico = CType(e.Argument, coControlMedico)
            tbtmp = cn.Cn_CronogramaVacGestacion(obj).Copy
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
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim observacionTiempo As Integer = 6
            Dim estado As Integer = 7

            'observacionTiempo
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "-", observacionTiempo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightBlue, Color.DarkBlue, "TEMPRANO", observacionTiempo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "EN TIEMPO", observacionTiempo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "TARDÍO", observacionTiempo)

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "-", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "CUMPLIDO", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(observacionTiempo).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub NumLote_ValueChanged(sender As Object, e As EventArgs) Handles NumLote.ValueChanged
        If CmbAnios.Text = "" Or NumLote.Value = 0 Then
            LblPeriodo.Text = ""
            Return
        End If

        LblPeriodo.Text = clsBasicas.ObtenerPeriodoDeSemana(CmbAnios.Text, NumLote.Value)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Consultar()
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class