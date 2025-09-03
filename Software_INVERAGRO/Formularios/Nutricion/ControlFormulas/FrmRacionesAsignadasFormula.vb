Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRacionesAsignadasFormula
    Public idFormulaBase As Integer
    Dim cn As New cnControlFormulacion

    Private Sub FrmRacionesAsignadasFormula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarRaciones()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ListarRaciones()
        Dim obj As New coControlFormulacion With {
            .Codigo = idFormulaBase
        }
        Dim dt As DataTable = cn.Cn_ObtenerRacionesxIdFormulacionBase(obj).Tables(0)
        dtgListadoRaciones.DataSource = dt
        clsBasicas.Formato_Tablas_Grid(dtgListadoRaciones)
        dtgListadoRaciones.DisplayLayout.Bands(0).Columns(0).Hidden = True
        dtgListadoRaciones.DisplayLayout.Bands(0).Columns("idRacion").Hidden = True
    End Sub

    Private Sub dtgListadoRaciones_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListadoRaciones.InitializeRow
        Dim columnVisualizar As Infragistics.Win.UltraWinGrid.UltraGridColumn = dtgListadoRaciones.DisplayLayout.Bands(0).Columns("Imprimir")
        columnVisualizar.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        columnVisualizar.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always

        If Not e.ReInitialize Then
            e.Row.Cells("Imprimir").Value = "Imprimir"
            e.Row.Cells("Imprimir").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        End If
    End Sub

    Private Sub dtgListadoRaciones_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListadoRaciones.ClickCellButton
        Try
            With dtgListadoRaciones
                If (e.Cell.Column.Key = "Imprimir") Then
                    'Dim f As New FrmVerAsignacionRacion
                    'f._CodigoFormula = CInt(.ActiveRow.Cells(0).Value)
                    'f.ShowDialog()
                    Dim frm As New FrmImpresionFormula
                    frm.idFormulaRacion = CInt(.ActiveRow.Cells(0).Value)
                    frm.racion = .ActiveRow.Cells("Ración").Value
                    frm.idRacion = CInt(.ActiveRow.Cells("idRacion").Value)
                    frm.ShowDialog()
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    'Private Sub BtnImprimirReceta_Click(sender As Object, e As EventArgs) Handles BtnImprimirReceta.Click
    '    Dim filas As Integer = dtgListadoRaciones.Rows.Count
    '    Dim obj As New coControlFormulacion With {
    '        .IdFormulaBase = idFormulaBase
    '    }

    '    If filas = 0 Then
    '        msj_advert("No hay raciones asignadas para la fórmula seleccionada")
    '        Return
    '    End If

    '    Dim dsRaciones As DataSet = cn.Cn_ObtenerRacionesAsignadasReceta(obj)
    '    Dim dsFinal As New DataSet
    '    Dim tablaIndex As Integer = 1

    '    For Each tablaOriginal As DataTable In dsRaciones.Tables
    '        Dim tiposPremixero = tablaOriginal.AsEnumerable().
    '                      Select(Function(row) row.Field(Of String)("tipoPremixero")).
    '                      Distinct().ToList()

    '        For Each tipoPremixero In tiposPremixero
    '            ' Tabla General: Registros con esNucleo = 0 por tipoPremixero
    '            Dim tablaGeneral As DataTable = tablaOriginal.Clone()
    '            tablaGeneral.TableName = $"Tabla{tablaIndex}Premixero{tipoPremixero}"
    '            Dim registrosGeneral = tablaOriginal.AsEnumerable().
    '                            Where(Function(row) row.Field(Of String)("tipoPremixero") = tipoPremixero AndAlso row.Field(Of Boolean)("esNucleo") = False)
    '            For Each registro In registrosGeneral
    '                tablaGeneral.ImportRow(registro)
    '            Next

    '            ' Agregar columna cantidadTotal a la tabla general
    '            If Not tablaGeneral.Columns.Contains("cantidadTotal") Then
    '                tablaGeneral.Columns.Add("cantidadTotal", GetType(Decimal))
    '            End If
    '            Dim sumaGeneral = If(tablaGeneral.AsEnumerable().Any(), tablaGeneral.AsEnumerable().Sum(Function(row) If(row.IsNull("cantidad"), 0D, row.Field(Of Decimal)("cantidad"))), 0D)
    '            For Each row As DataRow In tablaGeneral.Rows
    '                row("cantidadTotal") = sumaGeneral
    '            Next
    '            dsFinal.Tables.Add(tablaGeneral)

    '            ' Tabla Núcleo: Registros con esNucleo = 1 por tipoPremixero
    '            Dim tablaNucleo As DataTable = tablaOriginal.Clone()
    '            tablaNucleo.TableName = $"Tabla{tablaIndex}Premixero{tipoPremixero}Nucleo"
    '            Dim registrosNucleo = tablaOriginal.AsEnumerable().
    '                            Where(Function(row) row.Field(Of String)("tipoPremixero") = tipoPremixero AndAlso row.Field(Of Boolean)("esNucleo") = True)
    '            For Each registro In registrosNucleo
    '                tablaNucleo.ImportRow(registro)
    '            Next

    '            ' Agregar columna cantidadTotal a la tabla núcleo
    '            If Not tablaNucleo.Columns.Contains("cantidadTotal") Then
    '                tablaNucleo.Columns.Add("cantidadTotal", GetType(Decimal))
    '            End If
    '            Dim sumaNucleo = If(tablaNucleo.AsEnumerable().Any(), tablaNucleo.AsEnumerable().Sum(Function(row) If(row.IsNull("cantidad"), 0D, row.Field(Of Decimal)("cantidad"))), 0D)
    '            For Each row As DataRow In tablaNucleo.Rows
    '                row("cantidadTotal") = sumaNucleo
    '            Next

    '            ' Si no hay registros con esNucleo = 1, añade una tabla vacía con cantidadTotal en 0
    '            If registrosNucleo.Any() Then
    '                dsFinal.Tables.Add(tablaNucleo)
    '            Else
    '                Dim tablaVacia As DataTable = tablaOriginal.Clone()
    '                tablaVacia.TableName = $"Tabla{tablaIndex}Premixero{tipoPremixero}Nucleo"
    '                tablaVacia.Columns.Add("cantidadTotal", GetType(Decimal))
    '                Dim emptyRow = tablaVacia.NewRow()
    '                emptyRow("cantidadTotal") = 0D
    '                tablaVacia.Rows.Add(emptyRow)
    '                dsFinal.Tables.Add(tablaVacia)
    '            End If
    '        Next

    '        tablaIndex += 1
    '    Next

    '    GenerarReporteTotal(dsFinal, filas)
    'End Sub

    Private Sub BtnImprimirReceta_Click(sender As Object, e As EventArgs) Handles BtnImprimirReceta.Click
        Dim filas As Integer = dtgListadoRaciones.Rows.Count
        Dim obj As New coControlFormulacion With {
        .IdFormulaBase = idFormulaBase
    }
        If filas = 0 Then
            msj_advert("No hay raciones asignadas para la fórmula seleccionada")
            Return
        End If
        Dim dsRaciones As DataSet = cn.Cn_ObtenerRacionesAsignadasReceta(obj)
        Dim dsFinal As New DataSet
        Dim tablaIndex As Integer = 1
        For Each tablaOriginal As DataTable In dsRaciones.Tables
            Dim tiposPremixero = tablaOriginal.AsEnumerable().
                      Select(Function(row) row.Field(Of String)("tipoPremixero")).
                      Distinct().ToList()
            For Each tipoPremixero In tiposPremixero
                ' Tabla General: Registros con esNucleo = 0 por tipoPremixero
                Dim tablaGeneral As DataTable = tablaOriginal.Clone()
                tablaGeneral.TableName = $"Tabla{tablaIndex}Premixero{tipoPremixero}"
                Dim registrosGeneral = tablaOriginal.AsEnumerable().
                            Where(Function(row) row.Field(Of String)("tipoPremixero") = tipoPremixero AndAlso row.Field(Of Boolean)("esNucleo") = False)
                For Each registro In registrosGeneral
                    tablaGeneral.ImportRow(registro)
                Next
                ' Agregar columnas cantidadTotal y CantidadSumatoria a la tabla general
                If Not tablaGeneral.Columns.Contains("cantidadTotal") Then
                    tablaGeneral.Columns.Add("cantidadTotal", GetType(Decimal))
                End If
                If Not tablaGeneral.Columns.Contains("CantidadSumatoria") Then
                    tablaGeneral.Columns.Add("CantidadSumatoria", GetType(Decimal))
                End If

                Dim sumaGeneral = If(tablaGeneral.AsEnumerable().Any(), tablaGeneral.AsEnumerable().Sum(Function(row) If(row.IsNull("cantidad"), 0D, row.Field(Of Decimal)("cantidad"))), 0D)

                ' Calcular la suma acumulativa para la tabla general
                Dim sumaAcumulada As Decimal = 0
                For Each row As DataRow In tablaGeneral.Rows
                    row("cantidadTotal") = sumaGeneral
                    sumaAcumulada += If(row.IsNull("cantidad"), 0D, row.Field(Of Decimal)("cantidad"))
                    row("CantidadSumatoria") = sumaAcumulada
                Next

                dsFinal.Tables.Add(tablaGeneral)

                ' Tabla Núcleo: Registros con esNucleo = 1 por tipoPremixero
                Dim tablaNucleo As DataTable = tablaOriginal.Clone()
                tablaNucleo.TableName = $"Tabla{tablaIndex}Premixero{tipoPremixero}Nucleo"
                Dim registrosNucleo = tablaOriginal.AsEnumerable().
                            Where(Function(row) row.Field(Of String)("tipoPremixero") = tipoPremixero AndAlso row.Field(Of Boolean)("esNucleo") = True)
                For Each registro In registrosNucleo
                    tablaNucleo.ImportRow(registro)
                Next
                ' Agregar columnas cantidadTotal y CantidadSumatoria a la tabla núcleo
                If Not tablaNucleo.Columns.Contains("cantidadTotal") Then
                    tablaNucleo.Columns.Add("cantidadTotal", GetType(Decimal))
                End If
                If Not tablaNucleo.Columns.Contains("CantidadSumatoria") Then
                    tablaNucleo.Columns.Add("CantidadSumatoria", GetType(Decimal))
                End If

                Dim sumaNucleo = If(tablaNucleo.AsEnumerable().Any(), tablaNucleo.AsEnumerable().Sum(Function(row) If(row.IsNull("cantidad"), 0D, row.Field(Of Decimal)("cantidad"))), 0D)

                ' Calcular la suma acumulativa para la tabla núcleo
                sumaAcumulada = 0
                For Each row As DataRow In tablaNucleo.Rows
                    row("cantidadTotal") = sumaNucleo
                    sumaAcumulada += If(row.IsNull("cantidad"), 0D, row.Field(Of Decimal)("cantidad"))
                    row("CantidadSumatoria") = sumaAcumulada
                Next

                ' Si no hay registros con esNucleo = 1, añade una tabla vacía con cantidadTotal y CantidadSumatoria en 0
                If registrosNucleo.Any() Then
                    dsFinal.Tables.Add(tablaNucleo)
                Else
                    Dim tablaVacia As DataTable = tablaOriginal.Clone()
                    tablaVacia.TableName = $"Tabla{tablaIndex}Premixero{tipoPremixero}Nucleo"
                    tablaVacia.Columns.Add("cantidadTotal", GetType(Decimal))
                    tablaVacia.Columns.Add("CantidadSumatoria", GetType(Decimal))
                    Dim emptyRow = tablaVacia.NewRow()
                    emptyRow("cantidadTotal") = 0D
                    emptyRow("CantidadSumatoria") = 0D
                    tablaVacia.Rows.Add(emptyRow)
                    dsFinal.Tables.Add(tablaVacia)
                End If
            Next
            tablaIndex += 1
        Next
        GenerarReporteTotal(dsFinal, filas)
    End Sub

    Sub GenerarReporteTotal(ByVal dsFiltrado As DataSet, cantidadRaciones As Integer)
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            If cantidadRaciones = 1 Then
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpts_RacionesReceta\Rpt_TotalRacionesReceta1.mrt"))
            ElseIf cantidadRaciones = 2 Then
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpts_RacionesReceta\Rpt_TotalRacionesReceta2.mrt"))
            ElseIf cantidadRaciones = 3 Then
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpts_RacionesReceta\Rpt_TotalRacionesReceta3.mrt"))
            ElseIf cantidadRaciones = 4 Then
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpts_RacionesReceta\Rpt_TotalRacionesReceta4.mrt"))
            ElseIf cantidadRaciones = 5 Then
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpts_RacionesReceta\Rpt_TotalRacionesReceta5.mrt"))
            ElseIf cantidadRaciones = 6 Then
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpts_RacionesReceta\Rpt_TotalRacionesReceta6.mrt"))
            ElseIf cantidadRaciones = 7 Then
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpts_RacionesReceta\Rpt_TotalRacionesReceta7.mrt"))
            ElseIf cantidadRaciones = 8 Then
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpts_RacionesReceta\Rpt_TotalRacionesReceta8.mrt"))
            ElseIf cantidadRaciones = 9 Then
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpts_RacionesReceta\Rpt_TotalRacionesReceta9.mrt"))
            ElseIf cantidadRaciones = 10 Then
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpts_RacionesReceta\Rpt_TotalRacionesReceta10.mrt"))
            Else
                msj_advert("No se puede imprimir más de 10 raciones a la vez")
                Return
            End If
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsFiltrado)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            msj_advert("Error al generar el reporte")
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class