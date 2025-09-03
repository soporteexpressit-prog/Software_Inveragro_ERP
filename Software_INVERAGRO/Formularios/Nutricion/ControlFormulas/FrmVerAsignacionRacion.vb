Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmVerAsignacionRacion
    Public _CodigoFormula As Integer
    Dim cn As New cnControlFormulacion
    Dim ds As New DataSet
    Private originalCantidad As New Dictionary(Of Integer, Double)


    Private Sub FrmVisualizarFormulacionTotal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ConsultarFormula()
            CalcularTotal()
            Me.Size = New Size(1160, 750)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ConsultarFormula()
        Dim obj As New coControlFormulacion
        obj.Codigo = _CodigoFormula

        ds = cn.Cn_ObtenerFormulaRacionxId(obj)
        If ds.Tables.Count > 0 Then
            dtgListadoFormula.DataSource = ds.Tables(0)
            clsBasicas.Formato_Tablas_Grid(dtgListadoFormula)
            If ds.Tables.Count > 1 Then
                dtgListadoNucleo.DataSource = ds.Tables(1)
                clsBasicas.Formato_Tablas_Grid(dtgListadoNucleo)
            End If
        End If

        lblNombre.Text = ds.Tables(1).Rows(0).Item(2)
        lblTipo.Text = ds.Tables(1).Rows(0).Item(3)

        dtgListadoFormula.DisplayLayout.Bands(0).Columns(4).Hidden = True
        dtgListadoNucleo.DisplayLayout.Bands(0).Columns(2).Hidden = True
        dtgListadoNucleo.DisplayLayout.Bands(0).Columns(3).Hidden = True
        dtgListadoNucleo.DisplayLayout.Bands(0).Columns(4).Hidden = True
    End Sub

    Private Sub CalcularTotal()
        Dim totalSuma As Double = 0

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListadoFormula.Rows
            If Not row.IsFilterRow Then
                Dim cantidad As Double = Convert.ToDouble(row.Cells("Cantidad").Value) / 2
                row.Cells("Cantidad").Value = cantidad
                totalSuma += cantidad
            End If
        Next

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListadoNucleo.Rows
            If Not row.IsFilterRow Then
                Dim cantidad As Double = Convert.ToDouble(row.Cells("Cantidad").Value) / 2
                row.Cells("Cantidad").Value = cantidad
                totalSuma += cantidad
            End If
        Next

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListadoFormula.Rows
            If Not row.IsFilterRow Then
                Dim rowIndex As Integer = row.Index
                Dim cantidad As Double = Convert.ToDouble(row.Cells("Cantidad").Value)
                originalCantidad(rowIndex) = cantidad
            End If
        Next

        txtPreparacion.Text = "5"
        lblTotal.Text = totalSuma.ToString("N3")
    End Sub

    'REPORTES TOTALES
    Private Sub btnReporteTotal_Click(sender As Object, e As EventArgs) Handles btnReporteTotal.Click
        Try
            Dim tablaActualizadaFormula As DataTable = CopiarTablaDesdeUltraGrid(dtgListadoFormula)
            Dim tablaActualizadaNucleo As DataTable = CopiarTablaDesdeUltraGrid(dtgListadoNucleo)

            Dim tiposPremixero As List(Of String) = ObtenerTiposDePremixero(tablaActualizadaFormula)
            Dim dsFiltrado As New DataSet

            Dim AddDisenioColumn As Action(Of DataTable) = Sub(tabla)
                                                               If Not tabla.Columns.Contains("disenio") Then
                                                                   tabla.Columns.Add("disenio", GetType(Integer))
                                                                   For Each row As DataRow In tabla.Rows
                                                                       row("disenio") = CDec(txtPreparacion.Text) * 2
                                                                   Next
                                                               End If
                                                           End Sub

            Dim AddTotalSumaColumn As Action(Of DataTable) = Sub(tabla)
                                                                 If Not tabla.Columns.Contains("TotalSuma") Then
                                                                     tabla.Columns.Add("TotalSuma", GetType(Decimal))
                                                                     Dim sumaTotal As Decimal = If(tabla.AsEnumerable().Any(Function(row) Not row.IsNull("Cantidad")),
                                                                                            tabla.AsEnumerable().Sum(Function(row) CDec(row("Cantidad"))),
                                                                                            0D)
                                                                     For Each row As DataRow In tabla.Rows
                                                                         row("TotalSuma") = sumaTotal
                                                                     Next
                                                                 End If
                                                             End Sub

            Dim tablaPremixero1 As DataTable = If(tiposPremixero.Count > 0, FiltrarTablaPorPremixero(tablaActualizadaFormula, tiposPremixero(0)), CrearTablaVacia(tablaActualizadaFormula))
            Dim tablaPremixero2 As DataTable = If(tiposPremixero.Count > 1, FiltrarTablaPorPremixero(tablaActualizadaFormula, tiposPremixero(1)), CrearTablaVacia(tablaActualizadaFormula))
            Dim tablaPremixero3 As DataTable = If(tiposPremixero.Count > 2, FiltrarTablaPorPremixero(tablaActualizadaFormula, tiposPremixero(2)), CrearTablaVacia(tablaActualizadaFormula))

            ' Añadir columnas "disenio" y "TotalSuma" a Tabla1
            tablaPremixero1.TableName = "Tabla1"
            AddDisenioColumn(tablaPremixero1)
            AddTotalSumaColumn(tablaPremixero1)
            dsFiltrado.Tables.Add(tablaPremixero1)

            tablaPremixero2.TableName = "Tabla2"
            AddDisenioColumn(tablaPremixero2)
            AddTotalSumaColumn(tablaPremixero2)
            dsFiltrado.Tables.Add(tablaPremixero2)

            tablaPremixero3.TableName = "Tabla3"
            AddDisenioColumn(tablaPremixero3)
            AddTotalSumaColumn(tablaPremixero3)
            dsFiltrado.Tables.Add(tablaPremixero3)

            ' Tablas Nucleo
            Dim tablaNucleo1 As DataTable = FiltrarNucleoPorPremixero(tablaActualizadaNucleo, tiposPremixero(0))
            tablaNucleo1.TableName = "Nucleo1"
            AddDisenioColumn(tablaNucleo1)
            AddTotalSumaColumn(tablaNucleo1)
            dsFiltrado.Tables.Add(tablaNucleo1)

            Dim tablaNucleo2 As DataTable = If(tiposPremixero.Count > 1, FiltrarNucleoPorPremixero(tablaActualizadaNucleo, tiposPremixero(1)), CrearTablaVacia(tablaActualizadaNucleo))
            tablaNucleo2.TableName = "Nucleo2"
            AddDisenioColumn(tablaNucleo2)
            AddTotalSumaColumn(tablaNucleo2)
            dsFiltrado.Tables.Add(tablaNucleo2)

            Dim tablaNucleo3 As DataTable = If(tiposPremixero.Count > 2, FiltrarNucleoPorPremixero(tablaActualizadaNucleo, tiposPremixero(2)), CrearTablaVacia(tablaActualizadaNucleo))
            tablaNucleo3.TableName = "Nucleo3"
            AddDisenioColumn(tablaNucleo3)
            AddTotalSumaColumn(tablaNucleo3)
            dsFiltrado.Tables.Add(tablaNucleo3)

            GenerarReporteTotal(dsFiltrado)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function CopiarTablaDesdeUltraGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid) As DataTable
        Dim dataTable As New DataTable()

        For Each column As Infragistics.Win.UltraWinGrid.UltraGridColumn In grid.DisplayLayout.Bands(0).Columns
            dataTable.Columns.Add(column.Key, column.DataType)
        Next

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grid.Rows
            If Not row.IsFilterRow Then
                Dim dataRow As DataRow = dataTable.NewRow()
                For Each column As Infragistics.Win.UltraWinGrid.UltraGridColumn In grid.DisplayLayout.Bands(0).Columns
                    dataRow(column.Key) = row.Cells(column.Key).Value
                Next
                dataTable.Rows.Add(dataRow)
            End If
        Next

        Return dataTable
    End Function

    Function FiltrarNucleoPorPremixero(ByVal tablaNucleo As DataTable, ByVal tipoPremixero As String) As DataTable
        Dim tablaFiltrada As DataTable = tablaNucleo.Clone()

        For Each row As DataRow In tablaNucleo.Rows
            If row(3).ToString() = tipoPremixero Then
                tablaFiltrada.ImportRow(row)
            End If
        Next

        If tablaFiltrada.Rows.Count = 0 Then
            tablaFiltrada = CrearTablaVacia(tablaNucleo)
        End If

        Return tablaFiltrada
    End Function

    Function ObtenerTiposDePremixero(ByVal tabla As DataTable) As List(Of String)
        Dim tipos As New List(Of String)
        Dim distinctTipos = (From row In tabla.AsEnumerable()
                             Select row.Field(Of String)(3)).Distinct()

        tipos.AddRange(distinctTipos)
        Return tipos
    End Function

    Sub GenerarReporteTotal(ByVal dsFiltrado As DataSet)
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_TotalPremixeros.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsFiltrado)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'REPORTES PARCIALES
    Private Sub btnReporteParcial_Click(sender As Object, e As EventArgs) Handles btnReporteParcial.Click
        Try
            Dim tipoPremixero As String = dtgListadoFormula.DisplayLayout.ActiveRow.Cells(3).Value.ToString
            GenerarReportePorPremixero(tipoPremixero)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try

    End Sub
    Sub GenerarReportePorPremixero(ByVal tipoPremixero As String)
        Try
            Dim tablaFiltradaFormula As DataTable = FiltrarTablaPorTipo(UltraGridToDataTable(dtgListadoFormula), tipoPremixero)
            Dim tablaFiltradaNucleo As DataTable = FiltrarTablaPorTipo(UltraGridToDataTable(dtgListadoNucleo), tipoPremixero)

            GenerarReporteParcial(tablaFiltradaFormula, tablaFiltradaNucleo)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function UltraGridToDataTable(ByVal ultraGrid As UltraGrid) As DataTable
        Dim dataTable As New DataTable()

        For Each column As UltraGridColumn In ultraGrid.DisplayLayout.Bands(0).Columns
            dataTable.Columns.Add(column.Key, column.DataType)
        Next

        For Each row As UltraGridRow In ultraGrid.Rows
            Dim dataRow As DataRow = dataTable.NewRow()
            For Each column As UltraGridColumn In ultraGrid.DisplayLayout.Bands(0).Columns
                dataRow(column.Key) = row.Cells(column.Key).Value
            Next
            dataTable.Rows.Add(dataRow)
        Next

        Return dataTable
    End Function

    Function FiltrarTablaPorTipo(ByVal dataTable As DataTable, ByVal tipoPremixero As String) As DataTable
        Dim vistaFiltrada As DataView = New DataView(dataTable)
        vistaFiltrada.RowFilter = $"[Tipo de Premixero] = '{tipoPremixero}'"

        Return vistaFiltrada.ToTable()
    End Function

    Sub GenerarReporteParcial(ByVal tablaFiltradaFormula As DataTable, ByVal tablaFiltradaNucleo As DataTable)
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_PorPremixero.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            Dim dsFiltrado As New DataSet
            dsFiltrado.Tables.Add(tablaFiltradaFormula)
            dsFiltrado.Tables.Add(tablaFiltradaNucleo)
            StiReport1.RegData(dsFiltrado)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function CrearTablaVacia(ByVal tablaOriginal As DataTable) As DataTable
        Dim tablaVacia As DataTable = tablaOriginal.Clone()
        Return tablaVacia
    End Function

    Function FiltrarTablaPorPremixero(ByVal tabla As DataTable, ByVal premixero As String) As DataTable
        Dim tablaFiltrada As DataTable = tabla.Clone()

        For Each row As DataRow In tabla.Rows
            If row(3).ToString() = premixero Then
                tablaFiltrada.ImportRow(row)
            End If
        Next

        Return tablaFiltrada
    End Function

    Private Sub txtPreparacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPreparacion.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If

        If e.KeyChar = "." AndAlso txtPreparacion.Text.Contains(".") Then
            e.Handled = True
        End If

        If e.KeyChar = "." AndAlso txtPreparacion.Text.Length = 0 Then
            e.Handled = True
        End If

        If txtPreparacion.Text.Contains(".") Then
            Dim decimalPart As String = txtPreparacion.Text.Split("."c)(1)
            If decimalPart.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtPreparacion_TextChanged(sender As Object, e As EventArgs) Handles txtPreparacion.TextChanged
        Dim preparacionFactor As Double
        If Not Double.TryParse(txtPreparacion.Text, preparacionFactor) Then
            preparacionFactor = 1
        End If

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListadoFormula.Rows
            If Not row.IsFilterRow Then
                Dim tipoPremixero As String = row.Cells("Tipo de Premixero").Value.ToString()
                Dim rowIndex As Integer = row.Index

                If tipoPremixero = "PREMIXERO 1" OrElse tipoPremixero = "PREMIXERO 2" Then
                    Dim cantidadOriginal As Double = originalCantidad(rowIndex)
                    row.Cells("Cantidad").Value = cantidadOriginal * preparacionFactor * 2
                End If
            End If
        Next
        lblCantidadSacos.Text = (preparacionFactor * 2).ToString("N2")
        calcularCantidadTipoPremixero()
    End Sub

    Private Sub calcularCantidadTipoPremixero()
        Dim totalPremix01 As Double = 0
        Dim totalPremix02 As Double = 0
        Dim totalPremix03 As Double = 0
        Dim tipoPremixeroNucleo As String = dtgListadoNucleo.Text

        For Each row As UltraGridRow In dtgListadoFormula.Rows
            If Not row.IsFilterRow AndAlso Not row.IsGroupByRow Then
                Dim tipo As String = row.Cells("Tipo de Premixero").Value.ToString()
                Dim cantidad As Double = 0

                If Double.TryParse(row.Cells("cantidad").Value.ToString(), cantidad) Then
                    Select Case tipo
                        Case "PREMIXERO 1"
                            totalPremix01 += cantidad
                        Case "PREMIXERO 2"
                            totalPremix02 += cantidad
                        Case "PREMIXERO 3"
                            totalPremix03 += cantidad
                    End Select
                End If
            End If
        Next

        For Each row As UltraGridRow In dtgListadoNucleo.Rows
            If Not row.IsFilterRow AndAlso Not row.IsGroupByRow Then
                Dim cantidad As Double = 0

                If Double.TryParse(row.Cells("cantidad").Value.ToString(), cantidad) Then
                    Select Case tipoPremixeroNucleo
                        Case "PREMIXERO 1"
                            totalPremix01 += cantidad
                        Case "PREMIXERO 2"
                            totalPremix02 += cantidad
                        Case "PREMIXERO 3"
                            totalPremix03 += cantidad
                    End Select
                End If
            End If
        Next

        lblPremix01.Text = totalPremix01.ToString("N3")
        lblPremix02.Text = totalPremix02.ToString("N3")
        lblPremix03.Text = totalPremix03.ToString("N3")
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class