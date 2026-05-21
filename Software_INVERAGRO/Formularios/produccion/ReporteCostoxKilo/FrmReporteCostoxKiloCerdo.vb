Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmReporteCostoxKiloCerdo
    Dim cn As New cnControlAnimal
    Dim ds As New DataSet

    Private Sub FrmReporteCostoxKiloCerdo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.Formato_Tablas_Grid(dtgListado1)
        clsBasicas.Formato_Tablas_Grid(dtgListado2)
        clsBasicas.Formato_Tablas_Grid(dtgListado3)
        clsBasicas.Formato_Tablas_Grid(dtgListado4)
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlantelesEngorde().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbUbicacion
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarCampañas()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        Dim obj As New coUbicacion With {
            .Codigo = CmbUbicacion.Value,
            .Anio = CmbAnios.Text
        }
        tb = cn.Cn_ListarCampañasCerradas(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbCampaña
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub BloquearFiltros()
        GrupoFiltros.Enabled = False
    End Sub

    Private Sub CmbAnios_TextChanged(sender As Object, e As EventArgs) Handles CmbAnios.TextChanged
        If CmbAnios Is Nothing OrElse String.IsNullOrEmpty(CmbAnios.Text) Then
            Return
        End If
        ListarCampañas()
    End Sub

    Private Sub CmbUbicacion_ValueChanged(sender As Object, e As EventArgs) Handles CmbUbicacion.ValueChanged
        If CmbAnios Is Nothing OrElse String.IsNullOrEmpty(CmbAnios.Text) Then
            Return
        End If
        ListarCampañas()
    End Sub

    Private Sub BloquearControladores1()
        Ptbx_Cargando1.Visible = True
        BarraOpciones1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores1()
        Ptbx_Cargando1.Visible = False
        BarraOpciones1.Enabled = True
    End Sub

    Sub ConsultarReproduccion()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores1()

            Dim obj As New coControlAnimal With {
                .IdCampaña = CmbCampaña.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            ds = cn.Cn_CostoxKiloLechonReproduccion(obj).Copy
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DesbloquearControladores1()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            Dim dsResult As DataSet = CType(e.Result, DataSet)
            Dim dtResult As DataTable = dsResult.Tables(0)

            LblInicioCampana1.Text = If(IsDBNull(dtResult.Rows(0)("Campaña_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Campaña_Inicio")).ToString("dd/MM/yyyy"))
            LblFinCampana1.Text = If(IsDBNull(dtResult.Rows(0)("Campaña_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Campaña_Fin")).ToString("dd/MM/yyyy"))
            LblInicioInseminacion1.Text = If(IsDBNull(dtResult.Rows(0)("Monta_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Monta_Inicio")).ToString("dd/MM/yyyy"))
            LblFinInseminacion1.Text = If(IsDBNull(dtResult.Rows(0)("Monta_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Monta_Fin")).ToString("dd/MM/yyyy"))
            LblInicioChanchilla1.Text = If(IsDBNull(dtResult.Rows(0)("Chanchilla_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Chanchilla_Inicio")).ToString("dd/MM/yyyy"))
            LblFinChanchilla1.Text = If(IsDBNull(dtResult.Rows(0)("Chanchilla_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Chanchilla_Fin")).ToString("dd/MM/yyyy"))
            LblLotesInvolucrados1.Text = If(IsDBNull(dtResult.Rows(0)("LotesInvolucrados")), "- / - / -", dtResult.Rows(0)("LotesInvolucrados").ToString().Replace(",", Environment.NewLine))

            dtgListado1.DataSource = dsResult.Tables(1)
        End If
    End Sub

    Private Sub BtnGenerar1_Click(sender As Object, e As EventArgs) Handles BtnGenerar1.Click
        If CmbCampaña Is Nothing OrElse String.IsNullOrEmpty(CmbCampaña.Text) Then
            Return
        End If
        ConsultarReproduccion()
    End Sub

    Private Sub dtgListado1_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado1.InitializeRow
        If e.Row.Band.Index = 0 Then
            Dim colVerPDF As Infragistics.Win.UltraWinGrid.UltraGridColumn
            If dtgListado1.DisplayLayout.Bands(0).Columns.Exists("[+]") Then
                colVerPDF = dtgListado1.DisplayLayout.Bands(0).Columns("[+]")
                colVerPDF.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerPDF.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                If Not e.ReInitialize Then
                    e.Row.Cells("[+]").Value = "[+]"
                    e.Row.Cells("[+]").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                End If
            End If
        End If
    End Sub

    Private Sub dtgListado1_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado1.ClickCellButton
        Try
            With dtgListado1
                If (e.Cell.Column.Key = "[+]") Then
                    Dim idDetalleVal As String = .ActiveRow.Cells("Id").Value.ToString()

                    If idDetalleVal = "RP2" Then
                        Dim frm As New FrmRptCostoxKiloDetalleF1 With {
                            .idDetalle = idDetalleVal,
                            .idCampaña = CmbCampaña.Value
                        }
                        frm.ShowDialog()
                    ElseIf idDetalleVal = "RP6" Then
                        Dim frm As New FrmRptCostoxKiloDetalleF2 With {
                            .idDetalle = idDetalleVal,
                            .idCampaña = CmbCampaña.Value
                        }
                        frm.ShowDialog()
                    ElseIf idDetalleVal = "RP7" Then
                        Dim frm As New FrmRptCostoxKiloDetalleF3 With {
                            .idDetalle = idDetalleVal,
                            .idCampaña = CmbCampaña.Value
                        }
                        frm.ShowDialog()
                    ElseIf idDetalleVal = "RP8" Then
                        Dim frm As New FrmRptCostoxKiloDetalleF4 With {
                            .idDetalle = idDetalleVal,
                            .idCampaña = CmbCampaña.Value
                        }
                        frm.ShowDialog()
                    ElseIf idDetalleVal = "RP10" Then
                        Dim frm As New FrmRptCostoxKiloDetalleF5 With {
                            .idDetalle = idDetalleVal,
                            .idCampaña = CmbCampaña.Value
                        }
                        frm.ShowDialog()
                    End If
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BloquearControladores2()
        Ptbx_Cargando2.Visible = True
        BarraOpciones2.Enabled = False
    End Sub

    Private Sub DesbloquearControladores2()
        Ptbx_Cargando2.Visible = False
        BarraOpciones2.Enabled = True
    End Sub

    Sub ConsultarMaternidad()
        If Not BackgroundWorker2.IsBusy Then
            BloquearControladores2()

            Dim obj As New coControlAnimal With {
                .IdCampaña = CmbCampaña.Value
            }

            BackgroundWorker2.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            ds = cn.Cn_CostoxKiloLechonMaternidad(obj).Copy
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        DesbloquearControladores2()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            Dim dsResult As DataSet = CType(e.Result, DataSet)
            Dim dtResult As DataTable = dsResult.Tables(0)

            LblInicioCampana2.Text = If(IsDBNull(dtResult.Rows(0)("Campaña_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Campaña_Inicio")).ToString("dd/MM/yyyy"))
            LblFinCampana2.Text = If(IsDBNull(dtResult.Rows(0)("Campaña_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Campaña_Fin")).ToString("dd/MM/yyyy"))
            LblInicioInseminacion2.Text = If(IsDBNull(dtResult.Rows(0)("Monta_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Monta_Inicio")).ToString("dd/MM/yyyy"))
            LblFinInseminacion2.Text = If(IsDBNull(dtResult.Rows(0)("Monta_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Monta_Fin")).ToString("dd/MM/yyyy"))
            LblInicioChanchilla2.Text = If(IsDBNull(dtResult.Rows(0)("Chanchilla_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Chanchilla_Inicio")).ToString("dd/MM/yyyy"))
            LblFinChanchilla2.Text = If(IsDBNull(dtResult.Rows(0)("Chanchilla_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Chanchilla_Fin")).ToString("dd/MM/yyyy"))
            LblLotesInvolucrados2.Text = If(IsDBNull(dtResult.Rows(0)("LotesInvolucrados")), "- / - / -", dtResult.Rows(0)("LotesInvolucrados").ToString().Replace(",", Environment.NewLine))

            dtgListado2.DataSource = dsResult.Tables(1)
        End If
    End Sub

    Private Sub BtnGenerar2_Click(sender As Object, e As EventArgs) Handles BtnGenerar2.Click
        If CmbCampaña Is Nothing OrElse String.IsNullOrEmpty(CmbCampaña.Text) Then
            Return
        End If
        ConsultarMaternidad()
    End Sub

    Private Sub dtgListado2_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado2.InitializeRow
        If e.Row.Band.Index = 0 Then
            Dim colVerPDF As Infragistics.Win.UltraWinGrid.UltraGridColumn
            If dtgListado2.DisplayLayout.Bands(0).Columns.Exists("[+]") Then
                colVerPDF = dtgListado2.DisplayLayout.Bands(0).Columns("[+]")
                colVerPDF.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerPDF.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                If Not e.ReInitialize Then
                    e.Row.Cells("[+]").Value = "[+]"
                    e.Row.Cells("[+]").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                End If
            End If
        End If
    End Sub

    Private Sub dtgListado2_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado2.ClickCellButton
        Try
            With dtgListado2
                If (e.Cell.Column.Key = "[+]") Then
                    Dim idDetalleVal As String = .ActiveRow.Cells("Id").Value.ToString()

                    If idDetalleVal = "RP12" Then
                        Dim frm As New FrmRptCostoxKiloDetalleF6 With {
                            .idDetalle = idDetalleVal,
                            .idCampaña = CmbCampaña.Value
                        }
                        frm.ShowDialog()
                    ElseIf idDetalleVal = "RP13" Then
                        Dim frm As New FrmRptCostoxKiloDetalleF7 With {
                            .idDetalle = idDetalleVal,
                            .idCampaña = CmbCampaña.Value
                        }
                        frm.ShowDialog()
                    End If
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class