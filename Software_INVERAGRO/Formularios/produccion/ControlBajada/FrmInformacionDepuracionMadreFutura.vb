Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmInformacionDepuracionMadreFutura
    Dim cnLote As New cnControlLoteDestete
    Public idLote As Integer = 0
    Public valorLote As String = ""
    Public valorPlantel As String = ""
    Public idPlantel As Integer = 0
    Dim tbtmp As New DataTable

    Private Sub FrmInformacionDepuracionMadreFutura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LblLote.Text = valorLote
            LblPlantel.Text = valorPlantel
            clsBasicas.Formato_Tablas_Grid(DtgListado)
            clsBasicas.Filtrar_Tabla(DtgListado, True)
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        ToolStrip1.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlLoteDestete With {
                .IdLote = idLote,
                .IdPlantel = idPlantel
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cnLote.Cn_ConsultarDepuracionCerdaxLotexUbicacion(obj).Copy
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
            DtgListado.DataSource = CType(e.Result, DataTable)
            DtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            DtgListado.DisplayLayout.Bands(0).Columns("estadoEliminacion").Hidden = True
            Colorear()
        End If
    End Sub


    Sub Colorear()
        If (DtgListado.Rows.Count > 0) Then
            Dim ambiente As Integer = 8

            'ambiente
            clsBasicas.Colorear_SegunValor(DtgListado, Color.LightGreen, Color.DarkGreen, "REPRODUCTOR", ambiente)
            clsBasicas.Colorear_SegunValor(DtgListado, Color.LightPink, Color.Black, "ENGORDE", ambiente)

            'centrar columnas
            With DtgListado.DisplayLayout.Bands(0)
                .Columns(ambiente).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub DtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles DtgListado.InitializeRow
        If e.Row.Band.Index = 0 Then
            Dim colVerPDF As Infragistics.Win.UltraWinGrid.UltraGridColumn
            If DtgListado.DisplayLayout.Bands(0).Columns.Exists("Acción") Then
                colVerPDF = DtgListado.DisplayLayout.Bands(0).Columns("Acción")
                colVerPDF.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerPDF.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                If Not e.ReInitialize Then
                    e.Row.Cells("Acción").Value = "Cancelar"
                    e.Row.Cells("Acción").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                End If
            End If
        End If
    End Sub

    Private Sub DtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles DtgListado.ClickCellButton
        Try
            With DtgListado
                If (e.Cell.Column.Key = "Acción") Then
                    Dim estadoEliminacion As Integer = .Rows(e.Cell.Row.Index).Cells("estadoEliminacion").Value

                    If estadoEliminacion = 1 Then
                        msj_advert("No se puede cancelar la depuración el lote ya retorno chanchillas.")
                        Exit Sub
                    End If

                    If (MessageBox.Show("¿ESTÁ SEGURO DE CANCELAR ESTA DEPURACIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    Dim obj As New coControlLoteDestete
                    obj.IdControlFicha = CInt(.ActiveRow.Cells("idControlFicha").Value.ToString)
                    obj.IdPlantel = idPlantel

                    Dim MensajeBgWk As String = cnLote.Cn_CancelarDepuracionMadreFutura(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(MensajeBgWk)
                        Consultar()
                    Else
                        msj_advert(MensajeBgWk)
                    End If
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            If (DtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE DEPURACION DE CHANCHILLAS", DtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListado.InitializeLayout
        Try
            If (DtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(DtgListado, e, 0)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class