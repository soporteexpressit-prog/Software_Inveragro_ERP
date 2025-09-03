Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmVerFormulaBase
    Dim cn As New cnControlFormulacion
    Public idFormulaBase As Integer = 0
    Public estadoFormula As String = ""
    Private idsSeleccionados As New List(Of Integer)

    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1200, 760)
    End Sub

    Private Sub FrmVerFormulaBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid_UltimaColumnaEditable(DtgListadoAntiPlanMedicado)
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        Try
            Dim obj As New coControlFormulacion With {
                .Codigo = idFormulaBase
            }
            Dim dtFormulacion As DataTable = cn.Cn_ObtenerFormulaBasexId(obj)
            DtgListado.DataSource = dtFormulacion

            If DtgListado.Rows.Count > 0 Then
                DtgListado.Rows(0).Hidden = True
            End If

            AgregarFilaCheckboxesConAddNew()
            CargarTodosLosIdsIniciales()

            clsBasicas.Formato_Tablas_Grid_Simulacion(DtgListado)
            clsBasicas.Formato_Tablas_Grid(DtgListadoAntiPlanMedicado)
            clsBasicas.Filtrar_Tabla(DtgListado, True)
            DtgListado.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True

            Dim costoFormulacion As Decimal = CalcularCostoTotalFormulacion(dtFormulacion)
            LblTotalCostoBase.Text = costoFormulacion.ToString("C3")
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CargarTodosLosIdsIniciales()
        Try
            idsSeleccionados.Clear()

            If DtgListado.Rows.Count >= 2 Then
                Dim primeraFilaOculta = DtgListado.Rows(1)

                For i As Integer = 3 To primeraFilaOculta.Cells.Count - 1
                    Dim valorId As Object = primeraFilaOculta.Cells(i).Value

                    If valorId IsNot Nothing AndAlso IsNumeric(valorId) Then
                        Dim idRacion As Integer = Convert.ToInt32(valorId)

                        If Not idsSeleccionados.Contains(idRacion) Then
                            idsSeleccionados.Add(idRacion)
                        End If
                    End If
                Next

                Dim idsSeleccionadosRacion As String = ObtenerListaComoString()
                Dim obj As New coControlFormulacion With {
                    .ListaIdsInsumos = idsSeleccionadosRacion
                }

                DtgListadoAntiPlanMedicado.DataSource = cn.Cn_ObtenerCostoPlanMedicadoAnti(obj)
                CalcularYMostrarTotalesPorTipo()
            End If
        Catch ex As Exception
            clsBasicas.controlException("CargarTodosLosIdsIniciales", ex)
        End Try
    End Sub

    Private Sub CalcularYMostrarTotalesPorTipo()
        Try
            Dim totalAnti As Decimal = 0
            Dim totalPlanMedicado As Decimal = 0

            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoAntiPlanMedicado.Rows
                If Not row.IsGroupByRow AndAlso Not row.IsSummaryRow Then
                    Dim tipoValue As Object = row.Cells("Tipo").Value

                    Dim cantidadValue As Object = row.Cells("Costo Total").Value

                    If tipoValue IsNot Nothing AndAlso cantidadValue IsNot Nothing Then
                        Dim tipo As String = tipoValue.ToString().Trim().ToUpper()
                        Dim cantidad As Decimal = 0

                        If Decimal.TryParse(cantidadValue.ToString(), cantidad) Then
                            If tipo.Contains("ANTI") Then
                                totalAnti += cantidad
                            ElseIf tipo.Contains("PLAN MEDICADO") Then
                                totalPlanMedicado += cantidad
                            End If
                        End If
                    End If
                End If
            Next

            totalAnti = totalAnti / 1000
            totalPlanMedicado = totalPlanMedicado / 1000

            Dim dtFormulacion As DataTable = CType(DtgListado.DataSource, DataTable)
            Dim costoFormulacion As Decimal = CalcularCostoTotalFormulacion(dtFormulacion)

            LblTotalPlanMedicado.Text = (totalPlanMedicado + costoFormulacion).ToString("C3")
            LblTotalAnti.Text = (totalAnti + totalPlanMedicado + costoFormulacion).ToString("C3")
        Catch ex As Exception
            clsBasicas.controlException("CalcularYMostrarTotalesPorTipo", ex)
        End Try
    End Sub

    Private Sub AgregarFilaCheckboxesConAddNew()
        Try
            Dim band As Infragistics.Win.UltraWinGrid.UltraGridBand = DtgListado.DisplayLayout.Bands(0)
            Dim newRow As Infragistics.Win.UltraWinGrid.UltraGridRow = DtgListado.DisplayLayout.Bands(0).AddNew()

            ' Configurar valores básicos para las primeras dos columnas
            newRow.Cells(0).Value = 0  ' Indice
            newRow.Cells(1).Value = 0  ' idProducto
            newRow.Cells(2).Value = ""  ' Insumo

            ' Configurar dinámicamente todas las columnas desde la posición 3 en adelante como checkboxes
            For i As Integer = 3 To band.Columns.Count - 1
                newRow.Cells(i).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                newRow.Cells(i).Value = True ' Marcar todos por defecto
            Next

            DtgListado.Rows.Move(newRow, 0)
        Catch ex As Exception
            clsBasicas.controlException("AgregarFilaCheckboxesConAddNew", ex)
        End Try
    End Sub

    Public Function CalcularCostoTotalFormulacion(ByVal dtFormulacion As DataTable) As Decimal
        Try
            Dim costoTotal As Decimal = 0

            For Each row As DataRow In dtFormulacion.Rows
                If row("Insumo").ToString().Trim() = "COSTO X KG" Then
                    For i As Integer = 3 To dtFormulacion.Columns.Count - 1
                        Dim valorColumna As Object = row(i)

                        If Not IsDBNull(valorColumna) AndAlso IsNumeric(valorColumna) Then
                            Dim checkboxValue As Boolean = GetCheckboxState(i)

                            If checkboxValue Then
                                costoTotal += Convert.ToDecimal(valorColumna)
                            End If
                        End If
                    Next
                    Exit For
                End If
            Next

            Return costoTotal / 1000
        Catch ex As Exception
            clsBasicas.controlException("CalcularCostoTotalFormulacion", ex)
            Return 0
        End Try
    End Function

    Private Function GetCheckboxState(columnIndex As Integer) As Boolean
        Try
            If DtgListado.Rows.Count > 0 Then
                Dim firstRow As Infragistics.Win.UltraWinGrid.UltraGridRow = DtgListado.Rows(0)
                If columnIndex < firstRow.Cells.Count Then
                    Dim cellValue As Object = firstRow.Cells(columnIndex).Value
                    If Not IsDBNull(cellValue) Then
                        Return Convert.ToBoolean(cellValue)
                    End If
                End If
            End If

            Return True
        Catch ex As Exception
            clsBasicas.controlException("GetCheckboxState", ex)
            Return True
        End Try
    End Function

    Private Sub DtgListado_CellChange(sender As Object, e As CellEventArgs) Handles DtgListado.CellChange
        Try
            If e.Cell.Row.Index = 0 AndAlso e.Cell.Column.Index >= 3 Then
                DtgListado.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
                RecalcularCostosFormulacion()

                Dim columnIndex As Integer = e.Cell.Column.Index
                Dim columnName As String = e.Cell.Column.Key

                Dim valorPrimeraFilaOculta As Object = Nothing
                If DtgListado.Rows.Count > 1 Then
                    valorPrimeraFilaOculta = DtgListado.Rows(1).Cells(columnIndex).Value
                End If

                Dim isChecked As Boolean = Convert.ToBoolean(e.Cell.Value)

                If valorPrimeraFilaOculta IsNot Nothing AndAlso IsNumeric(valorPrimeraFilaOculta) Then
                    Dim idRacion As Integer = Convert.ToInt32(valorPrimeraFilaOculta)

                    If isChecked Then
                        If Not idsSeleccionados.Contains(idRacion) Then
                            idsSeleccionados.Add(idRacion)
                        End If
                    Else
                        If idsSeleccionados.Contains(idRacion) Then
                            idsSeleccionados.Remove(idRacion)
                        End If
                    End If
                End If

                Dim idsSeleccionadosRacion As String = ObtenerListaComoString()
                Dim obj As New coControlFormulacion With {
                    .ListaIdsInsumos = idsSeleccionadosRacion
                }

                DtgListadoAntiPlanMedicado.DataSource = cn.Cn_ObtenerCostoPlanMedicadoAnti(obj)
                CalcularYMostrarTotalesPorTipo()
            End If
        Catch ex As Exception
            clsBasicas.controlException("DtgListado_AfterCellUpdate", ex)
        End Try
    End Sub

    Public Function ObtenerListaComoString() As String
        Try
            If idsSeleccionados.Count > 0 Then
                Return String.Join(",", idsSeleccionados)
            Else
                Return ""
            End If
        Catch ex As Exception
            clsBasicas.controlException("ObtenerListaComoString", ex)
            Return ""
        End Try
    End Function

    Private Sub RecalcularCostosFormulacion()
        Try
            Dim dtFormulacion As DataTable = CType(DtgListado.DataSource, DataTable)
            Dim dtAntiPlanMedicado As DataTable = CType(DtgListadoAntiPlanMedicado.DataSource, DataTable)
            Dim costoFormulacion As Decimal = CalcularCostoTotalFormulacion(dtFormulacion)

            LblTotalCostoBase.Text = costoFormulacion.ToString("C3")
        Catch ex As Exception
            clsBasicas.controlException("RecalcularCostos", ex)
        End Try
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportar.Click
        Try
            If (DtgListado.Rows.Count = 0) Then
                msj_advert("No existen Registros vuelva a Buscar por Favor")
                Return
            Else
                DtgListado.Rows(0).Hidden = True
                clsBasicas.ExportarExcel("Formulación Base", DtgListado)
                DtgListado.Rows(0).Hidden = False
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCambiarProducto_Click(sender As Object, e As EventArgs) Handles BtnCambiarProducto.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = DtgListado.ActiveRow
        If (DtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim idProducto As Integer = activeRow.Cells("idProducto").Value

                If idProducto = 0 Then
                    msj_advert("Por favor seleeciones un insumo válido")
                    Return
                End If

                If estadoFormula = "CANCELADO" Or estadoFormula = "FINALIZADO" Then
                    msj_advert("No se puede cambiar el producto de una formulación cancelada y/o finalizada")
                    Return
                End If

                Dim frm As New FrmListarProductoNuevoFormula With {
                    .idProducto = idProducto,
                    .idFormula = idFormulaBase,
                    .valorProducto = activeRow.Cells("Insumo").Value
                }
                frm.ShowDialog()
                Consultar()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub DtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles DtgListado.InitializeRow
        Try
            If e.Row.Cells("Insumo").Value.ToString().Trim() = "COSTO X KG" Then
                e.Row.Appearance.BackColor = Color.Silver

                e.Row.Appearance.ForeColor = Color.Black
                e.Row.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            End If

            If e.Row.Cells("Insumo").Value.ToString().Trim() = "CANTIDAD TOTAL" Then
                e.Row.Appearance.BackColor = Color.Silver

                e.Row.Appearance.ForeColor = Color.Black
                e.Row.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            End If
        Catch ex As Exception
            clsBasicas.controlException("DtgListado_InitializeRow", ex)
        End Try
    End Sub

    Private Sub DtgListadoAntiPlanMedicado_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles DtgListadoAntiPlanMedicado.InitializeRow
        If e.Row.Cells.Exists("Costo Total") Then
            With e.Row.Cells("Costo Total").Appearance
                .BackColor = Color.Silver
                .FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            End With
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class