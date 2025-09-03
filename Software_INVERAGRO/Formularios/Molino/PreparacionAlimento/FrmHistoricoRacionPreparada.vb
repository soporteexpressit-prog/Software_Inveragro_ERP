Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports System.ComponentModel

Public Class FrmHistoricoRacionPreparada
    Dim cn As New cnControlPreparacionAlimento
    Dim tbtmp As New DataTable

    Private Sub FrmHistoricoRacionPreparada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtpFechaDesde.Value = Now.Date
            dtpFechaHasta.Value = Now.Date
            ConsultarRacionesPreparadas()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ConsultarRacionesPreparadas()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            btnConsultar.Enabled = False

            Dim obj As New coControlPreparacionAlimento With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim cn As New cnControlPreparacionAlimento
            Dim obj As coControlPreparacionAlimento = CType(e.Argument, coControlPreparacionAlimento)
            tbtmp = cn.Cn_ConsultarAlimentoPreparado(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
            clsBasicas.Formato_Tablas_Grid(dtgListadoInsumoPreparado)
        Catch ex As Exception
            e.Cancel = True
            MessageBox.Show("Error en DoWork: " & ex.Message)
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListadoInsumoPreparado.DataSource = CType(e.Result, DataTable)
            btnConsultar.Enabled = True
            dtgListadoInsumoPreparado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            Colorear()
        End If
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Exit Sub
        End If

        ConsultarRacionesPreparadas()
    End Sub

    Sub Colorear()
        If (dtgListadoInsumoPreparado.Rows.Count > 0) Then
            For index As Integer = 0 To dtgListadoInsumoPreparado.Rows.Count - 1
                Dim estado As String = dtgListadoInsumoPreparado.Rows(index).Cells(8).Value.ToString
                If (estado = "PREPARADO") Then
                    Dim i As Integer = 8
                    With dtgListadoInsumoPreparado.Rows(index).Cells(i).SelectedAppearance
                        .BackColor = Color.Green
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color.White
                    End With

                    With dtgListadoInsumoPreparado.Rows(index).Cells(i).Appearance
                        .BackColor = Color.Green
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color.White
                    End With

                    With dtgListadoInsumoPreparado.Rows(index).Cells(i).ActiveAppearance
                        .BackColor = Color.Green
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color.White
                    End With
                End If
            Next
        End If
    End Sub

    Private Sub btnExportarMolinoalica_Click(sender As Object, e As EventArgs) Handles btnExportarMolinoalica.Click
        Try
            If (dtgListadoInsumoPreparado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("RACIONES DE ALIMENTO PREPARADAS", dtgListadoInsumoPreparado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class