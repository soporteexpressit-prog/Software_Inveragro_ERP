Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmReporteCostoxKiloCerdo
    Dim cn As New cnControlAnimal
    Dim ds As New DataSet
    Dim sizeButtonConcepto As Integer = 275
    Dim sizeButtonVerPDF As Integer = 50

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
        clsBasicas.Formato_Tablas_Grid_AnteAntePenultimaColumnaEditable(dtgListado1)
        clsBasicas.Formato_Tablas_Grid_AnteAntePenultimaColumnaEditable(dtgListado2)
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

    Private Sub BtnGenerar1_Click(sender As Object, e As EventArgs) Handles BtnGenerar1.Click
        If CmbCampaña Is Nothing OrElse String.IsNullOrEmpty(CmbCampaña.Text) Then
            Return
        End If
        ConsultarReproduccion()
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
            ds.Tables(1).Columns("Id").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("Calculado").ColumnMapping = MappingType.Hidden
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

    Private Sub dtgListado1_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado1.InitializeRow
        If e.Row.Band.Index = 0 Then
            Dim colVerPDF As Infragistics.Win.UltraWinGrid.UltraGridColumn
            If dtgListado1.DisplayLayout.Bands(0).Columns.Exists("[+]") Then
                colVerPDF = dtgListado1.DisplayLayout.Bands(0).Columns("[+]")
                colVerPDF.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerPDF.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                colVerPDF.Width = sizeButtonVerPDF
                colVerPDF.MinWidth = sizeButtonVerPDF
                colVerPDF.MaxWidth = sizeButtonVerPDF

                If Not e.ReInitialize Then
                    e.Row.Cells("[+]").Value = "[+]"
                    e.Row.Cells("[+]").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                End If
            End If

            ' === Ancho fijo para la columna Concepto ===
            If dtgListado1.DisplayLayout.Bands(0).Columns.Exists("Concepto") Then
                Dim colConcepto As Infragistics.Win.UltraWinGrid.UltraGridColumn
                colConcepto = dtgListado1.DisplayLayout.Bands(0).Columns("Concepto")
                colConcepto.Width = sizeButtonConcepto
                colConcepto.MinWidth = sizeButtonConcepto
                colConcepto.MaxWidth = sizeButtonConcepto
            End If

            ' === Bloquear celdas calculadas por Id ===
            If e.Row.Cells.Exists("Id") AndAlso e.Row.Cells.Exists("Monto") Then
                Dim idFila As String = e.Row.Cells("Id").Value.ToString()
                Dim idsCalculados As New List(Of String) From {"RP2", "RP4", "RP6", "RP7", "RP8", "RP9", "RP10", "RP11"}

                If idsCalculados.Contains(idFila) Then
                    ' Bloqueado - fondo gris
                    e.Row.Cells("Monto").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    e.Row.Cells("Monto").Appearance.BackColor = Color.FromArgb(220, 220, 220)
                Else
                    ' Editable - fondo blanco
                    e.Row.Cells("Monto").Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                    e.Row.Cells("Monto").Appearance.BackColor = Color.White
                End If
            End If

            ' === Colores especiales por Id ===
            If e.Row.Cells.Exists("Id") Then
                Dim idFila As String = e.Row.Cells("Id").Value.ToString()
                Dim idsSubtotal As New List(Of String) From {"RP4", "RP9"}
                Dim idCostoLechon As String = "RP11"

                If idsSubtotal.Contains(idFila) Then
                    ' Fila completa naranja
                    e.Row.Appearance.BackColor = Color.FromArgb(255, 140, 0)
                    e.Row.Appearance.BackColor2 = Color.FromArgb(255, 140, 0)
                    e.Row.Appearance.ForeColor = Color.White
                    e.Row.Appearance.FontData.Bold = DefaultableBoolean.True

                    ' Monto con su propio color - texto oscuro legible
                    e.Row.Cells("Monto").Appearance.BackColor = Color.FromArgb(255, 140, 0)
                    e.Row.Cells("Monto").Appearance.BackColor2 = Color.FromArgb(255, 140, 0)
                    e.Row.Cells("Monto").Appearance.FontData.Bold = DefaultableBoolean.True

                ElseIf idFila = idCostoLechon Then
                    ' Fila completa verde
                    e.Row.Appearance.BackColor = Color.FromArgb(34, 139, 34)
                    e.Row.Appearance.BackColor2 = Color.FromArgb(34, 139, 34)
                    e.Row.Appearance.ForeColor = Color.White
                    e.Row.Appearance.FontData.Bold = DefaultableBoolean.True

                    ' Monto con su propio color - texto oscuro legible
                    e.Row.Cells("Monto").Appearance.BackColor = Color.FromArgb(34, 139, 34)
                    e.Row.Cells("Monto").Appearance.BackColor2 = Color.FromArgb(34, 139, 34)
                    e.Row.Cells("Monto").Appearance.FontData.Bold = DefaultableBoolean.True
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

    Private Sub dtgListado1_AfterCellUpdate(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado1.AfterCellUpdate
        If e.Cell.Column.Key = "Monto" Then
            RecalcularReproduccion()
        End If
    End Sub

    Private Sub RecalcularReproduccion()
        Try
            ' Obtener valores editables del grid por ID
            Dim rp1 As Decimal = ObtenerMonto(dtgListado1, "RP1")
            Dim rp2 As Decimal = ObtenerMonto(dtgListado1, "RP2")
            Dim rp3 As Decimal = ObtenerMonto(dtgListado1, "RP3")
            Dim rp5 As Decimal = ObtenerMonto(dtgListado1, "RP5")
            Dim rp6 As Decimal = ObtenerMonto(dtgListado1, "RP6")
            Dim rp7 As Decimal = ObtenerMonto(dtgListado1, "RP7")
            Dim rp8 As Decimal = ObtenerMonto(dtgListado1, "RP8")
            Dim rp10 As Decimal = ObtenerMonto(dtgListado1, "RP10")

            ' Calcular subtotales
            Dim rp4 As Decimal = (rp1 + rp2 + rp3) / 6
            Dim rp9 As Decimal = rp5 + rp6 + rp7 + rp8
            Dim rp11 As Decimal = (rp4 + rp9) / 14.5D + rp10

            ' Escribir resultados en el grid
            EscribirMonto(dtgListado1, "RP4", rp4)
            EscribirMonto(dtgListado1, "RP9", rp9)
            EscribirMonto(dtgListado1, "RP11", rp11)

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    ' Función auxiliar: obtiene el Monto de una fila según su Id
    Private Function ObtenerMonto(grid As UltraGrid, idBuscado As String) As Decimal
        For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In grid.Rows
            If fila.Cells("Id").Value.ToString() = idBuscado Then
                Dim val As Object = fila.Cells("Monto").Value
                If val Is Nothing OrElse IsDBNull(val) OrElse val.ToString() = "" Then
                    Return 0D
                End If
                Return Convert.ToDecimal(val)
            End If
        Next
        Return 0D
    End Function

    ' Función auxiliar: escribe el Monto en una fila según su Id
    Private Sub EscribirMonto(grid As UltraGrid, idBuscado As String, valor As Decimal)
        For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In grid.Rows
            If fila.Cells("Id").Value.ToString() = idBuscado Then
                fila.Cells("Monto").Value = Math.Round(valor, 4)
                Exit For
            End If
        Next
    End Sub

    Private Sub BtnGenerar2_Click(sender As Object, e As EventArgs) Handles BtnGenerar2.Click
        If CmbCampaña Is Nothing OrElse String.IsNullOrEmpty(CmbCampaña.Text) Then
            Return
        End If
        ConsultarMaternidad()
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
            ds.Tables(1).Columns("Id").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("Calculado").ColumnMapping = MappingType.Hidden
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

    Private Sub dtgListado2_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado2.InitializeRow
        If e.Row.Band.Index = 0 Then
            Dim colVerPDF As Infragistics.Win.UltraWinGrid.UltraGridColumn
            If dtgListado2.DisplayLayout.Bands(0).Columns.Exists("[+]") Then
                colVerPDF = dtgListado2.DisplayLayout.Bands(0).Columns("[+]")
                colVerPDF.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerPDF.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always +
                colVerPDF.Width = sizeButtonVerPDF
                colVerPDF.MinWidth = sizeButtonVerPDF
                colVerPDF.MaxWidth = sizeButtonVerPDF

                If Not e.ReInitialize Then
                    e.Row.Cells("[+]").Value = "[+]"
                    e.Row.Cells("[+]").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                End If
            End If

            ' === Ancho fijo para la columna Concepto ===
            If dtgListado2.DisplayLayout.Bands(0).Columns.Exists("Concepto") Then
                Dim colConcepto As Infragistics.Win.UltraWinGrid.UltraGridColumn
                colConcepto = dtgListado2.DisplayLayout.Bands(0).Columns("Concepto")
                colConcepto.Width = sizeButtonConcepto
                colConcepto.MinWidth = sizeButtonConcepto
                colConcepto.MaxWidth = sizeButtonConcepto
            End If

            ' === Bloquear celdas calculadas por Id ===
            If e.Row.Cells.Exists("Id") AndAlso e.Row.Cells.Exists("Monto") Then
                Dim idFila As String = e.Row.Cells("Id").Value.ToString()
                Dim idsCalculados As New List(Of String) From {"RP12", "RP13", "RP14", "RP15", "RP16"}

                If idsCalculados.Contains(idFila) Then
                    ' Bloqueado - fondo gris
                    e.Row.Cells("Monto").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    e.Row.Cells("Monto").Appearance.BackColor = Color.FromArgb(220, 220, 220)
                Else
                    ' Editable - fondo blanco
                    e.Row.Cells("Monto").Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                    e.Row.Cells("Monto").Appearance.BackColor = Color.White
                End If
            End If

            ' === Colores especiales por Id ===
            If e.Row.Cells.Exists("Id") Then
                Dim idFila As String = e.Row.Cells("Id").Value.ToString()
                Dim idCostoLechonDestetado As String = "RP17"

                If idFila = idCostoLechonDestetado Then
                    ' Fila completa verde
                    e.Row.Appearance.BackColor = Color.FromArgb(34, 139, 34)
                    e.Row.Appearance.BackColor2 = Color.FromArgb(34, 139, 34)
                    e.Row.Appearance.ForeColor = Color.White
                    e.Row.Appearance.FontData.Bold = DefaultableBoolean.True

                    ' Monto con su propio color - texto oscuro legible
                    e.Row.Cells("Monto").Appearance.BackColor = Color.FromArgb(34, 139, 34)
                    e.Row.Cells("Monto").Appearance.BackColor2 = Color.FromArgb(34, 139, 34)
                    e.Row.Cells("Monto").Appearance.FontData.Bold = DefaultableBoolean.True
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
                    ElseIf idDetalleVal = "RP14" Then
                        Dim frm As New FrmRptCostoxKiloDetalleF8 With {
                            .idDetalle = idDetalleVal,
                            .idCampaña = CmbCampaña.Value
                        }
                        frm.ShowDialog()
                    ElseIf idDetalleVal = "RP15" Then
                        Dim frm As New FrmRptCostoxKiloDetalleF9 With {
                            .idDetalle = idDetalleVal,
                            .idCampaña = CmbCampaña.Value
                        }
                        frm.ShowDialog()
                    ElseIf idDetalleVal = "RP16" Then
                        Dim frm As New FrmRptCostoxKiloDetalleF10 With {
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

    Private Sub BtnGenerar3_Click(sender As Object, e As EventArgs) Handles BtnGenerar3.Click
        If CmbCampaña Is Nothing OrElse String.IsNullOrEmpty(CmbCampaña.Text) Then
            Return
        End If
        ConsultarRecria()
    End Sub

    Private Sub BloquearControladores3()
        Ptbx_Cargando3.Visible = True
        BarraOpciones3.Enabled = False
    End Sub

    Private Sub DesbloquearControladores3()
        Ptbx_Cargando3.Visible = False
        BarraOpciones3.Enabled = True
    End Sub

    Sub ConsultarRecria()
        If Not BackgroundWorker3.IsBusy Then
            BloquearControladores3()

            Dim obj As New coControlAnimal With {
                .IdCampaña = CmbCampaña.Value
            }

            BackgroundWorker3.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            ds = cn.Cn_CostoxKiloLechonRecria(obj).Copy
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker3_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
        DesbloquearControladores3()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            Dim dsResult As DataSet = CType(e.Result, DataSet)
            Dim dtResult As DataTable = dsResult.Tables(0)

            LblInicioCampana3.Text = If(IsDBNull(dtResult.Rows(0)("Campaña_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Campaña_Inicio")).ToString("dd/MM/yyyy"))
            LblFinCampana3.Text = If(IsDBNull(dtResult.Rows(0)("Campaña_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Campaña_Fin")).ToString("dd/MM/yyyy"))
            LblInicioInseminacion3.Text = If(IsDBNull(dtResult.Rows(0)("Monta_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Monta_Inicio")).ToString("dd/MM/yyyy"))
            LblFinInseminacion3.Text = If(IsDBNull(dtResult.Rows(0)("Monta_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Monta_Fin")).ToString("dd/MM/yyyy"))
            LblInicioChanchilla3.Text = If(IsDBNull(dtResult.Rows(0)("Chanchilla_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Chanchilla_Inicio")).ToString("dd/MM/yyyy"))
            LblFinChanchilla3.Text = If(IsDBNull(dtResult.Rows(0)("Chanchilla_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Chanchilla_Fin")).ToString("dd/MM/yyyy"))
            LblLotesInvolucrados3.Text = If(IsDBNull(dtResult.Rows(0)("LotesInvolucrados")), "- / - / -", dtResult.Rows(0)("LotesInvolucrados").ToString().Replace(",", Environment.NewLine))

            dtgListado3.DataSource = dsResult.Tables(1)
        End If
    End Sub

    Private Sub dtgListado3_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado3.InitializeRow
        If e.Row.Band.Index = 0 Then
            Dim colVerPDF As Infragistics.Win.UltraWinGrid.UltraGridColumn
            If dtgListado3.DisplayLayout.Bands(0).Columns.Exists("[+]") Then
                colVerPDF = dtgListado3.DisplayLayout.Bands(0).Columns("[+]")
                colVerPDF.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerPDF.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                If Not e.ReInitialize Then
                    e.Row.Cells("[+]").Value = "[+]"
                    e.Row.Cells("[+]").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                End If
            End If
        End If
    End Sub

    Private Sub dtgListado3_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado3.ClickCellButton
        Try
            With dtgListado3
                If (e.Cell.Column.Key = "[+]") Then
                    Dim idDetalleVal As String = .ActiveRow.Cells("Id").Value.ToString()

                    If idDetalleVal = "RP18" Then
                        Dim frm As New FrmRptCostoxKiloDetalleF11 With {
                            .idDetalle = idDetalleVal,
                            .idCampaña = CmbCampaña.Value
                        }
                        frm.ShowDialog()
                    ElseIf idDetalleVal = "RP19" Then
                        Dim frm As New FrmRptCostoxKiloDetalleF12 With {
                            .idDetalle = idDetalleVal,
                            .idCampaña = CmbCampaña.Value
                        }
                        frm.ShowDialog()
                    ElseIf idDetalleVal = "RP20" Then
                        Dim frm As New FrmRptCostoxKiloDetalleF8 With {
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