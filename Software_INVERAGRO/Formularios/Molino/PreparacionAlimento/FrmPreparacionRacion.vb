Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmPreparacionRacion
    Dim cn As New cnControlAlimento
    Dim semana As Tuple(Of Date, Date)
    Dim ds As New DataSet
    Private selectedRows As New List(Of Infragistics.Win.UltraWinGrid.UltraGridRow)

    Private Sub FrmPreparacionRacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListadoPreparacionRacion)
            dtgListadoPreparacionRacion.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
            Ptbx_Cargando.Visible = True
            Timer1.Interval = 500
            Timer1.Enabled = False
            dtpFecha.Value = DateTime.Now
            ConsultarPedidosAlimentoPorTipoAlimento()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtgListadoPreparacionRacion_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dtgListadoPreparacionRacion.DoubleClickRow
        Try
            Dim row = e.Row
            If row.Band.Index > 0 Then
                If String.IsNullOrEmpty(row.Cells(0).Value.ToString()) Then
                    Return
                End If

                Dim tipoRacion As String = row.ParentRow.Cells("Tipo Alimento").Value.ToString()

                If String.IsNullOrEmpty(tipoRacion) Then
                    Return
                End If

                If selectedRows.Contains(row) Then
                        selectedRows.Remove(row)
                        row.Appearance.BackColor = Color.White
                    Else
                        If selectedRows.Count > 0 Then
                            For Each selectedRow As Infragistics.Win.UltraWinGrid.UltraGridRow In selectedRows
                                selectedRow.Appearance.BackColor = Color.White
                                selectedRow.RowSelectorAppearance.BackColor = Color.White
                                selectedRow.PreviewAppearance.BackColor = Color.White
                            Next
                            selectedRows.Clear()
                        End If

                        selectedRows.Add(row)
                        row.Appearance.BackColor = Color.LightBlue
                        row.RowSelectorAppearance.BackColor = Color.LightBlue
                        row.PreviewAppearance.BackColor = Color.LightBlue
                    End If
                'End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar(Optional ByVal fechaDesde As Date? = Nothing, Optional ByVal fechaHasta As Date? = Nothing)
        Try
            If Not BackgroundWorker1.IsBusy Then
                Ptbx_Cargando.Visible = True

                Dim obj As New coControlAlimento With {
                    .FechaDesde = semana.Item1,
                    .FechaHasta = semana.Item2,
                    .Estado = "PARCIAL-PENDIENTE"
                }

                BackgroundWorker1.RunWorkerAsync(obj)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)

            ds = cn.Cn_AgruparPedidoAlimentoxTipoAlimento(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns("Código").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("Código").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("Identificador").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idProducto").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idUbicacionDestino").ColumnMapping = MappingType.Hidden
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
            dtgListadoPreparacionRacion.DataSource = ds.Tables(0)
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListadoPreparacionRacion.Rows.Count > 0) Then
            Dim estado As Integer = 5

            'estado
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.Yellow, Color.Black, "PARCIAL", estado)
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.LightGray, Color.Black, "PENDIENTE", estado)

            'centrar columnas
            With dtgListadoPreparacionRacion.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Public Function ObtenerSemana(fecha As Date) As Tuple(Of Date, Date)
        Dim diaSemana As Integer = fecha.DayOfWeek
        Dim fechaInicioSemana As Date = fecha.AddDays(-diaSemana)
        Dim fechaFinSemana As Date = fechaInicioSemana.AddDays(6)

        Return Tuple.Create(fechaInicioSemana, fechaFinSemana)
    End Function

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        Timer1.Stop()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        ConsultarPedidosAlimentoPorTipoAlimento()
    End Sub

    Private Sub ConsultarPedidosAlimentoPorTipoAlimento()
        LimpiarSeleccion()
        semana = ObtenerSemana(dtpFecha.Value)
        lblPeriodo.Text = "Del " & semana.Item1.ToString("dd/MM/yyyy") & " al " & semana.Item2.ToString("dd/MM/yyyy")
        Consultar()
    End Sub

    Private Sub btnPrepararRacion_Click(sender As Object, e As EventArgs) Handles btnPrepararRacionMolinoalica.Click
        Try
            If selectedRows.Count > 0 Then
                Dim primerRow = selectedRows(0)
                Dim tipoAlimento = primerRow.ParentRow.Cells(2).Value.ToString()
                Dim nombreRacion = primerRow.ParentRow.Cells(1).Value.ToString() + " - " + primerRow.ParentRow.Cells(2).Value.ToString()
                Dim idsDetalleAlimento As String = ""
                Dim cantidad As Double = 0

                For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In selectedRows
                    If row.Band.Index > 0 Then
                        idsDetalleAlimento &= row.Cells(1).Value.ToString() & ","
                        cantidad += CDbl(row.Cells(6).Value)
                    End If
                Next

                If Not String.IsNullOrEmpty(idsDetalleAlimento) Then
                    idsDetalleAlimento = idsDetalleAlimento.TrimEnd(","c)

                    Dim f As New FrmRegistrarPreparacionRacion With {
                            .nombreAlimento = nombreRacion,
                            .idsDetalleAlimento = idsDetalleAlimento,
                            .cantidad = cantidad,
                            .tipoRacion = tipoAlimento,
                            .idRacion = selectedRows(0).Cells(2).Value
                        }
                    f.ShowDialog()

                    ConsultarPedidosAlimentoPorTipoAlimento()
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO_HIJO_MOLINO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO_HIJO_MOLINO"))
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnExportar_Click_1(sender As Object, e As EventArgs) Handles btnExportarMolinoalica.Click
        Try
            If (dtgListadoPreparacionRacion.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("PEDIDOS DE ALIMENTO PREPARADAS", dtgListadoPreparacionRacion)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnConsultarPedidosPreparado_Click(sender As Object, e As EventArgs) Handles btnConsultarPedidosPreparadoMolinoalica.Click
        Try
            Dim f As New FrmPedidoPreparado
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnHistoricoRacionPreparada_Click(sender As Object, e As EventArgs) Handles btnHistoricoRacionPreparadaMolinoalica.Click
        Try
            Dim f As New FrmHistoricoRacionPreparada
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub LimpiarSeleccion()
        For Each row In selectedRows
            row.Appearance.BackColor = Color.White
        Next
        selectedRows.Clear()
    End Sub

    Private Sub dtgListadoPreparacionRacion_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListadoPreparacionRacion.InitializeLayout
        With e.Layout.Bands(1)
            .Columns(8).Style = UltraWinGrid.ColumnStyle.Button
            .Columns(8).CellButtonAppearance.Image = My.Resources.buscar16px
            .Columns(8).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
        End With
    End Sub

    Private Sub dtgListadoPreparacionRacion_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dtgListadoPreparacionRacion.InitializeRow
        If e.Row.Band.Index = 1 Then
            e.Row.Cells(8).Value = "Ver Medicación / Plus"
        End If
    End Sub

    Private Sub dtgListadoPreparacionRacion_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListadoPreparacionRacion.ClickCellButton
        Try
            Dim tipoAlimento As String = e.Cell.Row.ParentRow.Cells("Tipo Alimento").Value.ToString()
            Dim idDetalleRacion As Integer = Convert.ToInt32(e.Cell.Row.Cells("Identificador").Value)

            If tipoAlimento <> "NORMAL" Then
                Dim f As New FrmVerMedicacionRacion With {
                    .idDetalleRacion = idDetalleRacion
                }
                f.ShowDialog()
            Else
                msj_advert("No se puede ver la medicación de un alimento que no tiene anti, medicado o plus")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnHistoricoPreparacion_Click(sender As Object, e As EventArgs) Handles BtnHistoricoPreparacion.Click
        Try
            Dim frm As New FrmHistoricoPreparaciones
            frm.ShowDialog()
            ConsultarPedidosAlimentoPorTipoAlimento()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class