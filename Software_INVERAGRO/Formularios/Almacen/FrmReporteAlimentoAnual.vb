Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmReporteAlimentoAnual
    Dim cn As New cnControlAlimento
    Dim tbtmp As New DataTable

    Private Sub FrmReporteAlimentoAnual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        For i As Integer = DateTime.Now.Year - 10 To DateTime.Now.Year + 10
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
            ToolStrip1.Enabled = False
            CmbAnios.Enabled = False
            Dim obj As New coControlAlimento With {
                .Anio = CInt(CmbAnios.Text)
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)
            tbtmp = cn.Cn_ConsultarAlimentoAnual(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        CmbAnios.Enabled = True
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            ToolStrip1.Enabled = True
            PintarFilasTotal()
            PintarColumnaPorIndice(5)
            PintarColumnaPorIndice(6)
            PintarColumnaPorIndice(7)
        End If
    End Sub

    Private Sub PintarFilasTotal()
        For Each fila As UltraGridRow In dtgListado.Rows
            Dim valorCelda As Object = fila.Cells("Total Solicitada").Value

            If valorCelda IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(valorCelda.ToString()) Then
                Dim total As Double

                If Double.TryParse(valorCelda.ToString(), total) Then
                    If total >= 0 Then
                        fila.Appearance.BackColor = Color.FromArgb(234, 239, 239)
                        fila.Appearance.FontData.Bold = DefaultableBoolean.True
                    End If
                End If
            End If
        Next
    End Sub


    Private Sub PintarColumnaPorIndice(indiceColumna As Integer)
        For Each fila As UltraGridRow In dtgListado.Rows
            If fila.Cells.Count > indiceColumna Then
                With fila.Cells(indiceColumna).Appearance
                    .BackColor = Color.FromArgb(234, 239, 239)
                    .FontData.Bold = DefaultableBoolean.True
                End With
            End If
        Next
    End Sub

    Private Sub CmbAnios_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbAnios.SelectedValueChanged
        Consultar()
    End Sub

    Private Sub btnExportaralmacenali_Click(sender As Object, e As EventArgs) Handles btnExportaralmacenali.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE DE ALIMENTO ANUAL", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                clsBasicas.SumarTotales_Formato(dtgListado, e, 2)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 3)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 4)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class