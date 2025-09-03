Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarCorrales
    Private ReadOnly _frmNuevoAlimento As FrmNuevoAlimento
    Public idPlantel As Integer = 0
    Private SelectedRows As New List(Of DataRow)
    Dim tbtmp As New DataTable
    Dim cn As New cnJaulaCorral

    Public Sub New(frmNuevoAlimento As FrmNuevoAlimento)
        InitializeComponent()
        _frmNuevoAlimento = frmNuevoAlimento
    End Sub

    Private Sub FrmListarCorrales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Consultar()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            Dim obj As New coJaulaCorral With {
                .IdUbicacion = idPlantel
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coJaulaCorral = CType(e.Argument, coJaulaCorral)
            tbtmp = cn.Cn_ListarCorralesPorUbicacion(obj).Copy
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
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True

            For Each row As DataRow In CType(dtgListado.DataSource, DataTable).Rows
                Dim codGalponCorral As Integer = CInt(row(0))
                If _frmNuevoAlimento.SelectedGalponCorral.Contains(codGalponCorral) Then
                    Dim gridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.Rows.Where(Function(r) r.Cells(0).Value = codGalponCorral).FirstOrDefault()
                    If gridRow IsNot Nothing Then
                        gridRow.Appearance.BackColor = Color.LightBlue
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If (dtgListado.Rows.Count > 0) Then
            If dtgListado.ActiveRow IsNot Nothing AndAlso e.Cell.Row.Index >= 0 Then
                If dtgListado.ActiveRow.Cells(0).Value IsNot Nothing AndAlso dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0 Then
                    Dim selectedRow As DataRow = CType(dtgListado.DataSource, DataTable).Rows(e.Cell.Row.Index)
                    Dim codParticipante As Integer = CInt(selectedRow(0))

                    dtgListado.Rows(e.Cell.Row.Index).Appearance.BackColor = Color.LightBlue

                    If Not _frmNuevoAlimento.SelectedGalponCorral.Contains(codParticipante) Then
                        _frmNuevoAlimento.SelectedGalponCorral.Add(codParticipante)
                        SelectedRows.Add(selectedRow)
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class