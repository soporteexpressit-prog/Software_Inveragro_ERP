Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmReporteCondicionCorporal
    Dim cn As New cnControlLoteDestete
    Dim tbtmp As New DataTable
    Public idUbicacion As Integer

    Private Sub FrmReporteCondicionCorporal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        clsBasicas.LlenarComboAnios(CmbAnios)
        NumLote.Value = clsBasicas.ObtenerNumeroSemanaFecha(DateTime.Now)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub
    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        FiltrosBusqueda.Enabled = False
        BarraNavegacion.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        FiltrosBusqueda.Enabled = True
        BarraNavegacion.Enabled = True
    End Sub

    Private Sub NumLote_ValueChanged(sender As Object, e As EventArgs) Handles NumLote.ValueChanged
        If CmbAnios.Text = "" Or NumLote.Value = 0 Then
            LblPeriodo.Text = ""
            Return
        End If

        LblPeriodo.Text = clsBasicas.ObtenerPeriodoDeSemana(CmbAnios.Text, NumLote.Value)
        LblLote.Text = CInt(NumLote.Value) + 17
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Consultar()
    End Sub

    Sub Consultar()
        dtgListado.DataSource = Nothing
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlLoteDestete With {
                .Anio = CmbAnios.Text,
                .NumeroLote = NumLote.Value,
                .IdPlantel = idUbicacion
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ReporteCondicionCorporal(obj).Copy
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
            Dim etapa As Integer = 0

            'ETAPA
            'GESTACIÓN
            clsBasicas.Colorear_SegunClave(dtgListado, Color.AntiqueWhite, Color.DarkOliveGreen, "GESTACIÓN", etapa)
            'MATERNIDAD
            clsBasicas.Colorear_SegunClave(dtgListado, Color.MistyRose, Color.Maroon, "MATERNIDAD", etapa)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(etapa).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub


    Private Sub BtnExportarControlCerdacontrollotespro_Click(sender As Object, e As EventArgs) Handles BtnExportarControlCerdacontrollotespro.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE DE CONDICION CORPORAL", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class