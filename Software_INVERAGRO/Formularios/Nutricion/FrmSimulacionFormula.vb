Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmSimulacionFormula
    Dim cnFormulacion As New cnControlFormulacion
    Dim cnAlimento As New cnControlAlimento
    Dim semana As Tuple(Of Date, Date)
    Dim tbtmp As New DataTable
    Dim posicionColumnaRacionTabla As New List(Of Integer)
    Dim searchCombo As Boolean = False

    Private Sub FrmSimulacionFormula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtpFecha.Value = DateTime.Now
            Timer1.Interval = 500
            Timer1.Enabled = False
            ListarNutricionista()
            ListarInsumos()
            RealizarBusquedaConsolidado()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarNutricionista()
        Dim cn As New cnNucleo
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarNutricionistaCombo().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione Nutricionista"
        With CmbNutricionista
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarInsumos()
        dtgListadoInsumo.DataSource = cnFormulacion.Cn_ListarInsumosFormula()
        dtgListadoInsumo.DisplayLayout.Bands(0).Columns(0).Hidden = True
        dtgListadoInsumo.DisplayLayout.Bands(0).Columns(1).Hidden = True
        dtgListadoInsumo.DisplayLayout.Bands(0).Columns(2).Hidden = True
        dtgListadoInsumo.DisplayLayout.Bands(0).Columns(4).Hidden = True
        dtgListadoInsumo.DisplayLayout.Bands(0).Columns(5).Hidden = True
        dtgListadoInsumo.DisplayLayout.Bands(0).Columns(7).Hidden = True
        clsBasicas.Formato_Tablas_Grid(dtgListadoInsumo)
    End Sub

    Sub ListarConsolidadoPedidoAlimentoAprobado()
        Dim obj As New coControlAlimento With {
            .FechaDesde = semana.Item1,
            .FechaHasta = semana.Item2,
            .IdNutricionista = CmbNutricionista.Value
        }
        dtgListadoConsolidado.DataSource = cnAlimento.Cn_ConsolidadoAlimentoxSemanaAprobado(obj)
        dtgListadoConsolidado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        clsBasicas.Formato_Tablas_Grid(dtgListadoConsolidado)
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
        RealizarBusquedaConsolidado()
    End Sub

    Private Sub RealizarBusquedaConsolidado()
        semana = ObtenerSemana(dtpFecha.Value)
        lblPeriodo.Text = "Del " & semana.Item1.ToString("dd/MM/yyyy") & " al " & semana.Item2.ToString("dd/MM/yyyy")
        posicionColumnaRacionTabla.Clear()
        ListarConsolidadoPedidoAlimentoAprobado()
        ConsultarConsolidadoAlimentoPedir()
        searchCombo = True
    End Sub

    Sub ConsultarConsolidadoAlimentoPedir(Optional ByVal fechaDesde As Date? = Nothing, Optional ByVal fechaHasta As Date? = Nothing)
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            Dim obj As New coControlAlimento With {
                .FechaDesde = semana.Item1,
                .FechaHasta = semana.Item2,
                .IdNutricionista = CmbNutricionista.Value
            }
            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)
            Dim resultado As Object = cnAlimento.Cn_ConsolidadoAlimentoPedirxSemanaNutricionista(obj)

            If TypeOf resultado Is String Then
                e.Result = resultado
            ElseIf TypeOf resultado Is DataTable Then
                Dim tbtmp As DataTable = CType(resultado, DataTable).Copy()
                tbtmp.TableName = "tmp"
                e.Result = tbtmp
                tbtmp.Columns(1).ColumnMapping = MappingType.Hidden
                tbtmp.Columns(3).ColumnMapping = MappingType.Hidden
                tbtmp.Columns(tbtmp.Columns.Count - 1).ColumnMapping = MappingType.Hidden
                tbtmp.Columns(tbtmp.Columns.Count - 2).ColumnMapping = MappingType.Hidden
                tbtmp.Columns(tbtmp.Columns.Count - 3).ColumnMapping = MappingType.Hidden
                dtgListadoCantidadInsumos.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
            End If
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al cargar los datos")
        ElseIf TypeOf e.Result Is String Then
            msj_advert(e.Result.ToString())
            dtgListadoCantidadInsumos.DataSource = Nothing
            treeObservacionesCantidad.Nodes.Clear()
        Else
            dtgListadoCantidadInsumos.DataSource = Nothing
            Dim tbtmp As DataTable = CType(e.Result, DataTable)

            If tbtmp Is Nothing OrElse tbtmp.Rows.Count = 0 Then
                msj_advert("No se encontraron registros")
                treeObservacionesCantidad.Nodes.Clear()
                dtgListadoCantidadInsumos.DataSource = Nothing
                Exit Sub
            End If

             dtgListadoCantidadInsumos.DataSource = tbtmp
            Dim band As Infragistics.Win.UltraWinGrid.UltraGridBand = dtgListadoCantidadInsumos.DisplayLayout.Bands(0)
            Dim newRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListadoCantidadInsumos.DisplayLayout.Bands(0).AddNew()

            For i As Integer = 4 To band.Columns.Count - 5
                newRow.Cells(i).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                newRow.Cells(i).Value = True
            Next
            newRow.Cells(band.Columns.Count - 3).Value = ""
            dtgListadoCantidadInsumos.Rows.Move(newRow, 0)
            clsBasicas.Formato_Tablas_Grid_Simulacion(dtgListadoCantidadInsumos)

            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListadoCantidadInsumos.Rows
                If row.Index > 0 Then
                    Dim sum As Decimal = 0

                    If posicionColumnaRacionTabla.Count = 0 Then
                        For i As Integer = 4 To band.Columns.Count - 5
                            posicionColumnaRacionTabla.Add(i)
                        Next
                    End If

                    For i As Integer = 4 To band.Columns.Count - 4
                        If IsNumeric(row.Cells(i).Value) Then
                            sum += Convert.ToDecimal(row.Cells(i).Value)
                        End If
                    Next
                    row.Cells(band.Columns.Count - 4).Value = sum
                End If
            Next

            CompararTotalConStock()
        End If
    End Sub

    Private Sub dtgListadoCantidadInsumos_CellChange(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListadoCantidadInsumos.CellChange
        Dim cell As Infragistics.Win.UltraWinGrid.UltraGridCell = e.Cell

        If cell.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox Then
            Dim columnIndex As Integer = cell.Column.Index
            Dim isChecked As Boolean = CBool(cell.EditorResolved.Value)

            If isChecked Then
                posicionColumnaRacionTabla.Add(columnIndex)
            Else
                posicionColumnaRacionTabla.Remove(columnIndex)
            End If

            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListadoCantidadInsumos.Rows
                If row.Index > 0 Then
                    Dim sum As Decimal = 0

                    For Each pos As Integer In posicionColumnaRacionTabla
                        If IsNumeric(row.Cells(pos).Value) Then
                            sum += Convert.ToDecimal(row.Cells(pos).Value)
                        End If
                    Next
                    row.Cells(dtgListadoCantidadInsumos.DisplayLayout.Bands(0).Columns.Count - 4).Value = sum
                End If
            Next

            CompararTotalConStock()
        End If
    End Sub

    Private Sub CompararTotalConStock()
        treeObservacionesCantidad.Nodes.Clear()

        Dim mensaje As String = "LAS CANTIDADES CUMPLEN CON STOCK"
        Dim hayObservaciones As Boolean = False
        Dim rootNode As TreeNode = treeObservacionesCantidad.Nodes.Add("Observaciones")

        For Each rowCantidad As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListadoCantidadInsumos.Rows
            If rowCantidad.Index > 0 Then
                Dim codigoCantidad As String = rowCantidad.Cells("Codigo").Value.ToString()
                Dim totalCantidad As Decimal = Convert.ToDecimal(rowCantidad.Cells("Total(Tn)").Value)

                For Each rowInsumo As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListadoInsumo.Rows
                    Dim codigoInsumo As String = rowInsumo.Cells("Codigo").Value.ToString()

                    If codigoCantidad = codigoInsumo Then
                        Dim stockInsumo As Decimal = Convert.ToDecimal(rowInsumo.Cells("Stock").Value)

                        If totalCantidad > stockInsumo Then
                            rowCantidad.Cells("Total(Tn)").Appearance.ForeColor = Color.Red
                            rowCantidad.Cells("Total(Tn)").Appearance.FontData.Bold = DefaultableBoolean.True

                            Dim nombreProducto As String = rowCantidad.Cells("Insumo").Value.ToString()
                            mensaje = $"{nombreProducto} NO CUENTA CON STOCK DISPONIBLE"
                            rootNode.Nodes.Add(mensaje)
                            hayObservaciones = True
                        Else
                            rowCantidad.Cells("Total(Tn)").Appearance.ForeColor = Color.DarkGreen
                            rowCantidad.Cells("Total(Tn)").Appearance.FontData.Bold = DefaultableBoolean.True
                        End If
                        Exit For
                    End If
                Next
            End If
        Next

        If Not hayObservaciones Then
            rootNode.Nodes.Add(mensaje)
        End If

        rootNode.Expand()
    End Sub

    Private Sub btnActivarFormula_Click(sender As Object, e As EventArgs) Handles btnActivarFormulaNsimu.Click
        Try
            If dtgListadoCantidadInsumos.Rows.Count = 0 Then
                msj_advert("NO SE PUEDE ACTIVAR LA FORMULA, NO SE HA CARGADO NINGUNA CANTIDAD")
                Exit Sub
            End If

            Dim sumaTotal As Decimal = 0

            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListadoCantidadInsumos.Rows
                If row.Index > 0 Then
                    sumaTotal += Convert.ToDecimal(row.Cells("Total(Tn)").Value)
                End If
            Next

            If sumaTotal = 0 Then
                msj_advert("LA SUMA TOTAL DE LAS CANTIDADES NO PUEDE SER 0")
                Exit Sub
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE ACTIVAR LA ÚLTIMA FÓRMULA REGISTRADA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlFormulacion With {
                .IdNutricionista = CmbNutricionista.Value
            }
            Dim _mensaje As String = cnFormulacion.Cn_PonerCursoNuevaFormulaBase(obj)

            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CmbNutricionista_ValueChanged(sender As Object, e As EventArgs) Handles CmbNutricionista.ValueChanged
        If (searchCombo) Then
            RealizarBusquedaConsolidado()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class