Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmRegistrarPreparacionRacion
    Dim cnAlimento As New cnControlAlimento
    Dim cnFormulacion As New cnControlFormulacion
    Dim cnControlPreparacionAlimento As New cnControlPreparacionAlimento
    Dim listaIdSalida As String
    Dim listaIdDetalleSalida As String
    Public nombreAlimento As String
    Public idsDetalleAlimento As String
    Public cantidad As Double
    Public idRacion As Integer
    Public tipoRacion As String
    Dim ds As New DataSet

    ' Diccionario para guardar los valores originales de cada fila
    Private valoresOriginales As New Dictionary(Of Integer, Dictionary(Of String, Object))

    Private Sub FrmRegistrarPreparacionRacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lblNombreAlimento.Text = nombreAlimento & " = " & cantidad.ToString() & "TN"
            DtpFecha.Value = Now.Date
            ConsultarDetallePedidoAlimento()
            ObtenerInsumosPorNucleo()
            txtPreparacion.Text = cantidad.ToString()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ConsultarDetallePedidoAlimento()
        Dim obj As New coControlAlimento With {
            .IdsDetalleAlimento = idsDetalleAlimento
        }
        dtgListadoConsolidado.DataSource = cnAlimento.Cn_ListarDetalleAlimentoxIds(obj)
        dtgListadoConsolidado.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
        dtgListadoConsolidado.DisplayLayout.Bands(0).Columns("idDetalleSalida").Hidden = True
        dtgListadoConsolidado.DisplayLayout.Bands(0).Columns("idSalida").Hidden = True
        clsBasicas.Formato_Tablas_Grid(dtgListadoConsolidado)
        ObtenerIdsConcatenados()
    End Sub

    Private Sub ObtenerIdsConcatenados()
        Dim listaIdSalidaTemp As New List(Of String)
        Dim listaIdDetalleSalidaTemp As New List(Of String)

        For Each row As UltraGridRow In dtgListadoConsolidado.Rows
            Dim idSalida As String = row.Cells("idSalida").Value.ToString()
            Dim idDetalleSalida As String = row.Cells("idDetalleSalida").Value.ToString()

            If Not listaIdSalidaTemp.Contains(idSalida) Then
                listaIdSalidaTemp.Add(idSalida)
            End If

            listaIdDetalleSalidaTemp.Add(idDetalleSalida)
        Next

        listaIdDetalleSalida = String.Join(",", listaIdDetalleSalidaTemp) & ","
        listaIdSalida = String.Join(",", listaIdSalidaTemp) & ","
    End Sub


    Private Sub ObtenerInsumosPorNucleo()
        Try
            Dim obj As New coControlFormulacion With {
                .Codigo = idRacion,
                .ListaIdsDetalleSalida = listaIdDetalleSalida,
                .Tipo = tipoRacion
            }

            Dim resultado As Object = cnFormulacion.Cn_ObtenerFormulaBasexIdNucleo(obj)

            If TypeOf resultado Is String Then
                msj_advert(resultado.ToString())
                Dispose()
            Else
                dtgListadoCantidadInsumos.DataSource = CType(resultado, DataTable)

                ' Ocultar las columnas de equivalencia que no son necesarias visualmente
                With dtgListadoCantidadInsumos.DisplayLayout.Bands(0)
                    .Columns("idProducto").Hidden = True
                    .Columns("idProductoEquivalencia").Hidden = True
                    .Columns("nombreProductoEquivalencia").Hidden = True
                    .Columns("equivalencia").Hidden = True
                End With

                clsBasicas.Formato_Tablas_Grid_UltimaColumnaEditable(dtgListadoCantidadInsumos)
                GuardarValoresOriginales()
                Colorear()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    ' Guardar los valores originales de cada fila al cargar
    Private Sub GuardarValoresOriginales()
        Try
            valoresOriginales.Clear()

            For Each row As UltraGridRow In dtgListadoCantidadInsumos.Rows
                If Not row.IsFilteredOut Then
                    Dim rowIndex As Integer = row.Index
                    Dim valores As New Dictionary(Of String, Object)

                    valores.Add("idProducto", row.Cells("idProducto").Value)
                    valores.Add("Nombre del Producto", row.Cells("Nombre del Producto").Value)
                    valores.Add("Total", row.Cells("Total").Value)
                    valores.Add("idProductoEquivalencia", row.Cells("idProductoEquivalencia").Value)
                    valores.Add("nombreProductoEquivalencia", row.Cells("nombreProductoEquivalencia").Value)
                    valores.Add("equivalencia", row.Cells("equivalencia").Value)

                    valoresOriginales.Add(rowIndex, valores)
                End If
            Next
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    ' Evento que se dispara cuando cambia el valor de una celda
    Private Sub dtgListadoCantidadInsumos_CellChange(sender As Object, e As CellEventArgs) Handles dtgListadoCantidadInsumos.CellChange
        Try
            ' Verificar que sea la columna "Utilizar Eq."
            If e.Cell.Column.Key = "Utilizar Eq." Then
                ' Forzar salida del modo edición para obtener el valor actualizado
                dtgListadoCantidadInsumos.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)

                Dim row As UltraGridRow = e.Cell.Row
                ' Obtener el valor DESPUÉS del cambio
                Dim utilizarEquivalencia As Boolean = CBool(e.Cell.Value)

                AplicarEquivalencia(row, utilizarEquivalencia)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    ' Aplicar o revertir la equivalencia según el estado del checkbox
    Private Sub AplicarEquivalencia(row As UltraGridRow, utilizarEquivalencia As Boolean)
        Try
            Dim rowIndex As Integer = row.Index

            If Not valoresOriginales.ContainsKey(rowIndex) Then
                Return
            End If

            Dim valoresOriginalesRow As Dictionary(Of String, Object) = valoresOriginales(rowIndex)

            If utilizarEquivalencia Then
                ' VALIDAR TIPO DE PREMIXERO ANTES DE APLICAR EQUIVALENCIA
                Dim tipoPremixero As String = row.Cells("Tipo de Premixero").Value?.ToString()

                If String.IsNullOrEmpty(tipoPremixero) OrElse tipoPremixero.Trim().ToUpper() <> "PREMIXERO 3" Then
                    msj_advert("Solo se puede utilizar equivalencia para productos de tipo PREMIXERO 3")
                    row.Cells("Utilizar Eq.").Value = False
                    Return
                End If

                ' MARCAR CHECK: Aplicar equivalencia
                Dim idProductoEq As Object = valoresOriginalesRow("idProductoEquivalencia")
                Dim nombreProductoEq As Object = valoresOriginalesRow("nombreProductoEquivalencia")
                Dim equivalencia As Object = valoresOriginalesRow("equivalencia")

                If IsDBNull(idProductoEq) OrElse IsDBNull(nombreProductoEq) OrElse IsDBNull(equivalencia) OrElse
                   String.IsNullOrEmpty(idProductoEq?.ToString()) OrElse
                   String.IsNullOrEmpty(nombreProductoEq?.ToString()) OrElse
                   CDec(equivalencia) = 0 Then

                    msj_advert("No hay producto de equivalencia disponible para este insumo")
                    row.Cells("Utilizar Eq.").Value = False
                    Return
                End If

                ' Cambiar a producto equivalente
                row.Cells("idProducto").Value = idProductoEq
                row.Cells("Nombre del Producto").Value = nombreProductoEq

                Dim totalOriginal As Decimal = CDec(valoresOriginalesRow("Total"))
                Dim factorEquivalencia As Decimal = CDec(equivalencia)
                Dim nuevoTotal As Decimal = totalOriginal / factorEquivalencia

                row.Cells("Total").Value = Math.Round(nuevoTotal, 2)
            Else
                ' DESMARCAR CHECK: Revertir a valores originales
                row.Cells("idProducto").Value = valoresOriginalesRow("idProducto")
                row.Cells("Nombre del Producto").Value = valoresOriginalesRow("Nombre del Producto")
                row.Cells("Total").Value = valoresOriginalesRow("Total")
            End If

            ' Refrescar la fila
            row.Refresh()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Colorear()
        If (dtgListadoCantidadInsumos.Rows.Count > 0) Then
            Dim disposeStock As Integer = 5

            'estadoRepetidora
            clsBasicas.Colorear_SegunValor(dtgListadoCantidadInsumos, Color.LightGreen, Color.DarkGreen, "DISPONIBLE", disposeStock)
            clsBasicas.Colorear_SegunValor(dtgListadoCantidadInsumos, Color.LightCoral, Color.White, "NO DISPONIBLE", disposeStock)

            'centrar columnas
            With dtgListadoCantidadInsumos.DisplayLayout.Bands(0)
                .Columns(disposeStock).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnIniciarPreparacion_Click(sender As Object, e As EventArgs) Handles btnIniciarPreparacion.Click
        Try
            If DtpFecha.Value.Date > Now.Date Then
                msj_advert("La fecha no puede ser mayor a la actual")
                Exit Sub
            End If

            Dim mensaje As String = ""
            For Each row As UltraGridRow In dtgListadoCantidadInsumos.Rows
                If Not row.IsFilteredOut Then
                    Dim estado As String = row.Cells("Dispone Stock").Value.ToString()
                    If estado <> "DISPONIBLE" Then
                        mensaje = "LAS CANTIDADES NO CUMPLEN CON STOCK"
                        Exit For
                    End If
                End If
            Next

            If mensaje <> "" Then
                msj_advert(mensaje)
                Exit Sub
            End If

            If Not MsgBox("¿ESTÁ SEGURO DE REGISTRAR EL INICIO DE PREPARACIÓN DEL ALIMENTO?", MsgBoxStyle.YesNo Or MsgBoxStyle.Information, "Preparación de ración") = MsgBoxResult.Yes Then
                Exit Sub
            End If

            Dim obj As New coControlPreparacionAlimento With {
                .IdUsuario = VP_IdUser,
                .IdUbicacion = 6,
                .ListaInsumoPreparacion = InsumosNecesariosRacionString(),
                .ListaRaciones = ConsolidadoRacionAString(),
                .ListaIdsSalida = listaIdSalida,
                .ListaIdsDetalleSalida = listaIdDetalleSalida,
                .Tipo = tipoRacion,
                .Fecha = DtpFecha.Value
               }

            Dim MensajeBgWk As String = cnControlPreparacionAlimento.Cn_RegistrarRequerimientoAlimento(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Dispose()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function InsumosNecesariosRacionString() As String
        Dim resultados As New List(Of String)

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListadoCantidadInsumos.Rows
            If Not row.IsFilteredOut Then
                Dim total As String = row.Cells("Total").Value.ToString()
                Dim insumo As String = row.Cells("idProducto").Value.ToString()
                resultados.Add($"{total}+{insumo}")
            End If
        Next

        Return String.Join(",", resultados)
    End Function

    Function ConsolidadoRacionAString() As String
        Dim consolidado As New Dictionary(Of String, Decimal)

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListadoConsolidado.Rows
            If Not row.IsFilteredOut Then
                Dim idProducto As String = row.Cells("idProducto").Value.ToString()
                Dim cantidad As Decimal = Convert.ToDecimal(row.Cells("Cantidad").Value)

                If consolidado.ContainsKey(idProducto) Then
                    consolidado(idProducto) += cantidad
                Else
                    consolidado.Add(idProducto, cantidad)
                End If
            End If
        Next

        Dim resultados As New List(Of String)
        For Each kvp As KeyValuePair(Of String, Decimal) In consolidado
            resultados.Add($"{kvp.Value}+{kvp.Key}")
        Next

        Dim resultadoString As String = String.Join(",", resultados)
        If consolidado.Count = 1 Then
            resultadoString &= ","
        End If

        Return resultadoString
    End Function

    Private Sub BtnImprimirReceta_Click(sender As Object, e As EventArgs) Handles BtnImprimirReceta.Click
        Try
            If (txtPreparacion.Text = "") Then
                msj_advert("La cantidad de preparación no puede ser vacía")
                Return
            End If

            If (CDec(txtPreparacion.Text) <= 0) Then
                msj_advert("La cantidad de preparación debe ser mayor a 0")
                Return
            End If

            Dim obj As New coControlFormulacion With {
                .IdFormulaRacion = idRacion,
                .Diseño = CDec(txtPreparacion.Text),
                .Descripcion = nombreAlimento,
                .Tipo = tipoRacion,
                .Nota = "",
                .ListaIdsDetalleSalida = listaIdDetalleSalida
            }

            ds = cnFormulacion.Cn_ObtenerPreparacionFormulaTotalMolino(obj)
            GenerarReporteTotal(ds, tipoRacion)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub GenerarReporteTotal(ByVal dsFiltrado As DataSet, tipoRacion As String)
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            If (tipoRacion.Contains("ANTI")) Then
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_TotalPremixerosConAnti.mrt"))
            Else
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_TotalPremixeros.mrt"))
            End If
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

    Private Sub txtPreparacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPreparacion.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub dtgListadoCantidadInsumos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListadoCantidadInsumos.InitializeLayout
        Try
            If (dtgListadoCantidadInsumos.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListadoCantidadInsumos, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListadoCantidadInsumos, e, 2)
                clsBasicas.SumarTotales_Formato(dtgListadoCantidadInsumos, e, 4)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class