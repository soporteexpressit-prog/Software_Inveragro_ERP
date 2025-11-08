Imports System.ComponentModel
Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports OfficeOpenXml
Imports LicenseContext = OfficeOpenXml.LicenseContext

Public Class FrmRegistrarFormula
    Dim cn As New cnControlFormulacion
    Dim cnNucleo As New cnNucleo
    Dim tbtmp As New DataTable
    Dim obj As New coControlFormulacion
    Dim idNucleoBusqueda As Integer = 0
    Dim cantidadFilas As Integer = 0
    Dim cantidadColumnas As Integer = 0
    Private limiteInferior As Decimal = 0.0
    Private limiteSuperior As Decimal = 0.0
    Private datosTemporales As New List(Of String)
    Private valoresPorCelda As New Dictionary(Of String, (Cantidad As Decimal, LimInferior As Decimal, LimSuperior As Decimal, IdNucleo As Integer))
    Private valoresRealesParaGuardar As New Dictionary(Of String, (Cantidad As Decimal, LimInferior As Decimal, LimSuperior As Decimal))
    Private dicNucleos As New Dictionary(Of String, Integer)
    Public idNutricionista As Integer = 0

    Private Sub FrmRegistrarFormula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarTablaEnUltraGrid()
    End Sub

    Sub Inicializar()
        txtCantidad.Enabled = False
        txtInferior.Enabled = False
        txtSuperior.Enabled = False
        btnMoveUp.Enabled = False
        btnMoveDown.Enabled = False
        btnVerificarCantidades.Enabled = False
        txtLimInferior.Text = "0.0"
        txtLimInferior.Enabled = False
        txtLimSuperior.Text = "0.0"
        txtLimSuperior.Enabled = False
        DtpFechaElaboracion.Value = Now.Date
        Me.Width = 1515
        Me.CenterToScreen()
    End Sub

    Private Sub CargarTablaEnUltraGrid()
        Try
            Dim obj As New coControlFormulacion With {
                .IdNutricionista = idNutricionista
            }

            Dim resultado As Object = cn.Cn_ConsultarInsumosFormula(obj)

            If TypeOf resultado Is String Then
                msj_advert(resultado.ToString())
                Dispose()
            Else
                Dim dtNucleos As DataTable = cnNucleo.Cn_Consultar(obj)
                Dim dt As New DataTable()
                Inicializar()

                dtgListadoInsumos.DataSource = resultado
                dtgListadoInsumos.DisplayLayout.Bands(0).Columns(0).Hidden = True
                dtgListadoInsumos.DisplayLayout.Bands(0).Columns(2).Hidden = True
                dt.Columns.Add("Insumo", GetType(String))

                For Each row As DataRow In dtNucleos.Rows
                    Dim columnaNucleo As String = row("Núcleo").ToString()
                    Dim codigoNucleo As Integer = CInt(row("Código"))
                    dt.Columns.Add(columnaNucleo, GetType(Decimal))
                    dicNucleos.Add(columnaNucleo, codigoNucleo)
                Next

                For Each producto As DataRow In resultado.Rows
                    Dim nuevaFila As DataRow = dt.NewRow()
                    nuevaFila("Insumo") = DBNull.Value

                    For Each nucleo As DataRow In dtNucleos.Rows
                        Dim columnaNucleo As String = nucleo("Núcleo").ToString()
                        nuevaFila(columnaNucleo) = 0.0
                    Next

                    dt.Rows.Add(nuevaFila)
                Next

                Dim filaTotal As DataRow = dt.NewRow()
                filaTotal("Insumo") = "Total"

                Dim filaCostos As DataRow = dt.NewRow()
                filaCostos("Insumo") = "Costos"

                For Each columna As DataColumn In dt.Columns
                    If columna.ColumnName <> "Insumo" Then
                        filaTotal(columna.ColumnName) = dt.AsEnumerable().Sum(Function(row) If(IsDBNull(row(columna.ColumnName)), 0, CDec(row(columna.ColumnName))))
                        filaCostos(columna.ColumnName) = 0.0
                    End If
                Next

                dt.Rows.Add(filaTotal)
                dt.Rows.Add(filaCostos)

                dtgListadoExcel.DataSource = dt
                cantidadFilas = dt.Rows.Count + 1 ' -2 por las filas de totales y costos
                cantidadColumnas = dt.Columns.Count + 1 '+1 por la columna de insumo
                idNucleoBusqueda = dicNucleos.Values.First()
                ConfigurarUltraGrid()
                HeaderEncabezado.Text = "FORMULACIÓN DE RACIONES NUTRICIONALES - " & dtgListadoInsumos.Rows.Count & " INSUMOS ASIGNADOS Y " & dtNucleos.Rows.Count & " RACIONES ASIGNADAS"
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ConfigurarUltraGrid()
        dtgListadoInsumos.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
        clsBasicas.Formato_Tablas_Grid(dtgListadoExcel)

        dtgListadoExcel.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
        clsBasicas.Formato_Tablas_Grid(dtgListadoInsumos)

        Dim totalRow As UltraGridRow = dtgListadoExcel.Rows(dtgListadoExcel.Rows.Count - 2)
        Dim costosRow As UltraGridRow = dtgListadoExcel.Rows(dtgListadoExcel.Rows.Count - 1)

        totalRow.Cells("Insumo").Appearance.BackColor = Color.LightGray
        totalRow.Cells("Insumo").Appearance.TextHAlign = HAlign.Center
        totalRow.Cells("Insumo").Appearance.FontData.Bold = DefaultableBoolean.True

        costosRow.Cells("Insumo").Appearance.BackColor = Color.LightGray
        costosRow.Cells("Insumo").Appearance.TextHAlign = HAlign.Center
        costosRow.Cells("Insumo").Appearance.FontData.Bold = DefaultableBoolean.True

        For Each cell In totalRow.Cells
            cell.Activation = Activation.NoEdit
        Next

        For Each cell In costosRow.Cells
            cell.Activation = Activation.NoEdit
        Next

        dtgListadoExcel.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(226, 242, 167)
        dtgListadoExcel.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Black
        dtgListadoExcel.DisplayLayout.Override.SelectedCellAppearance.BackColor = Color.FromArgb(226, 242, 167)
        dtgListadoExcel.DisplayLayout.Override.SelectedCellAppearance.ForeColor = Color.Black
        dtgListadoExcel.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(226, 242, 167)
        dtgListadoExcel.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If DtpFechaElaboracion.Value > Now.Date Then
                msj_advert("LA FECHA DE ELABORACION NO PUEDE SER MAYOR A LA FECHA ACTUAL")
                Return
            End If

            If String.IsNullOrEmpty(TxtMotivo.Text) Then
                msj_advert("DEBE INGRESAR UN MOTIVO")
                Return
            End If

            If Not ValidarCantidadPorNucleo() Then
                msj_advert("DEBE INGRESAR INFORMACIÓN DE FORMULA")
                Exit Sub
            End If

            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR FÓRMULA?", "Confirmar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                UnirTablasYObtenerResultado()
                Dim detalleRacion As String = String.Join(",", valoresRealesParaGuardar.Select(Function(kvp) $"{kvp.Value.Cantidad}+{kvp.Key.Split("@"c)(1)}+{kvp.Key.Split("@"c)(0)}+{kvp.Value.LimInferior}+{kvp.Value.LimSuperior}"))
                Dim obj As New coControlFormulacion With {
                    .Descripcion = "FORMULA-" & DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss"),
                    .Iduser = VP_IdUser,
                    .ListaDetalleRacion = detalleRacion,
                    .IdNutricionista = idNutricionista,
                    .FechaElaboracion = DtpFechaElaboracion.Value,
                    .Motivo = TxtMotivo.Text
                }

                Dim MensajeBgWk As String = cn.Cn_RegistrarFormula(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Dispose()
                Else
                    msj_advert(MensajeBgWk)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub UnirTablasYObtenerResultado()
        valoresRealesParaGuardar.Clear()

        Dim dtExcel As DataTable = CType(dtgListadoExcel.DataSource, DataTable)
        Dim dtCopiaExcel As DataTable = dtExcel.Copy()

        If dtCopiaExcel.Rows.Count > 4 Then
            For i As Integer = dtCopiaExcel.Rows.Count - 1 To 0 Step -1
                If dtCopiaExcel.Rows(i)(0).ToString() = "Totales" OrElse
                   dtCopiaExcel.Rows(i)(0).ToString() = "Costos" Then
                    dtCopiaExcel.Rows.RemoveAt(i)
                End If
            Next
            dtCopiaExcel.AcceptChanges()
        End If

        Dim dtUnion As New DataTable()

        For Each col As DataColumn In dtCopiaExcel.Columns
            dtUnion.Columns.Add(col.ColumnName, col.DataType)
        Next

        For Each col As UltraGridColumn In dtgListadoInsumos.DisplayLayout.Bands(0).Columns
            If Not dtUnion.Columns.Contains(col.Key) Then
                dtUnion.Columns.Add(col.Key, col.DataType)
            End If
        Next

        Dim totalFilas As Integer = Math.Min(dtCopiaExcel.Rows.Count, dtgListadoInsumos.Rows.Count)
        Dim totalColumnas As Integer = dtCopiaExcel.Columns.Count

        For i As Integer = 0 To totalFilas - 1
            Dim filaExcel As UltraGridRow = dtgListadoExcel.Rows(i)
            Dim filaInsumos As UltraGridRow = dtgListadoInsumos.Rows(i)

            Dim nuevaFila As DataRow = dtUnion.NewRow()

            For j As Integer = 0 To dtCopiaExcel.Columns.Count - 1
                nuevaFila(j) = filaExcel.Cells(j).Value
            Next

            For j As Integer = 0 To dtgListadoInsumos.DisplayLayout.Bands(0).Columns.Count - 1
                Dim nombreColumna As String = dtgListadoInsumos.DisplayLayout.Bands(0).Columns(j).Key
                If dtUnion.Columns.Contains(nombreColumna) Then
                    nuevaFila(nombreColumna) = filaInsumos.Cells(j).Value
                End If
            Next

            dtUnion.Rows.Add(nuevaFila)
        Next

        For Each fila As DataRow In dtUnion.Rows
            For Each col As DataColumn In dtUnion.Columns
                If IsNumeric(fila(col.ColumnName)) Then
                    Dim valorCantidad As Decimal = CDec(fila(col.ColumnName))

                    If valorCantidad = 0 Then
                        Continue For
                    End If

                    Dim nombreProducto As String = fila(0).ToString()
                    Dim nombreNucleo As String = col.ColumnName
                    Dim claveCelda As String = $"{nombreProducto}@{nombreNucleo}"
                    Dim idProducto As Integer = CInt(fila(totalColumnas))

                    If valoresPorCelda.ContainsKey(claveCelda) Then
                        Dim valoresGuardados = valoresPorCelda(claveCelda)
                        Dim idNucleo As Integer = valoresGuardados.IdNucleo
                        Dim claveReal As String = $"{idProducto}@{idNucleo}"
                        valoresRealesParaGuardar(claveReal) = (valoresGuardados.Cantidad, valoresGuardados.LimInferior, valoresGuardados.LimSuperior)
                    End If
                End If
            Next
        Next
    End Sub

    Private Function ValidarCantidadPorNucleo() As Boolean
        For i As Integer = 1 To dtgListadoExcel.DisplayLayout.Bands(0).Columns.Count - 1
            Dim columna As UltraGridColumn = dtgListadoExcel.DisplayLayout.Bands(0).Columns(i)
            Dim contador As Integer = 0

            For Each fila As UltraGridRow In dtgListadoExcel.Rows
                Dim valor As Decimal
                If Decimal.TryParse(fila.Cells(columna.Key).Value.ToString(), valor) AndAlso valor > 0 Then
                    contador += 1
                End If
            Next

            If contador < 5 Then
                Return False
            End If
        Next

        Return True
    End Function

    Private Sub btnMoveUp_Click(sender As Object, e As EventArgs) Handles btnMoveUp.Click
        Dim activeRow As UltraGridRow = dtgListadoExcel.ActiveRow
        Dim totalFilas As Integer = dtgListadoExcel.Rows.Count - 2

        If activeRow IsNot Nothing AndAlso activeRow.Index > 0 AndAlso activeRow.Index <= totalFilas - 1 Then
            Dim dt As DataTable = CType(dtgListadoExcel.DataSource, DataTable)
            Dim currentIndex As Integer = activeRow.Index
            Dim tempValues As Object() = dt.Rows(currentIndex).ItemArray
            dt.Rows(currentIndex).ItemArray = dt.Rows(currentIndex - 1).ItemArray
            dt.Rows(currentIndex - 1).ItemArray = tempValues

            dtgListadoExcel.DataSource = dt
            dtgListadoExcel.Rows(currentIndex - 1).Activate()
            CalcularCostos()
        End If
    End Sub

    Private Sub btnMoveDown_Click(sender As Object, e As EventArgs) Handles btnMoveDown.Click
        Dim activeRow As UltraGridRow = dtgListadoExcel.ActiveRow
        Dim totalFilas As Integer = dtgListadoExcel.Rows.Count - 2

        If activeRow IsNot Nothing AndAlso activeRow.Index < totalFilas - 1 Then
            Dim dt As DataTable = CType(dtgListadoExcel.DataSource, DataTable)
            Dim currentIndex As Integer = activeRow.Index
            Dim tempValues As Object() = dt.Rows(currentIndex).ItemArray
            dt.Rows(currentIndex).ItemArray = dt.Rows(currentIndex + 1).ItemArray
            dt.Rows(currentIndex + 1).ItemArray = tempValues

            dtgListadoExcel.DataSource = dt
            dtgListadoExcel.Rows(currentIndex + 1).Activate()
            CalcularCostos()
        End If
    End Sub

    Private Sub CalcularCostos()
        Dim dt As DataTable = CType(dtgListadoExcel.DataSource, DataTable)

        If dt.Rows.Count > 0 AndAlso dt.Rows(dt.Rows.Count - 1)(0).ToString() = "Costos" Then
            dt.Rows.RemoveAt(dt.Rows.Count - 1)
        End If

        Dim filaCostos As DataRow = dt.NewRow()
        filaCostos(0) = "Costos"

        For col As Integer = 1 To dt.Columns.Count - 1
            Dim totalCostos As Decimal = 0

            For fila As Integer = 0 To dt.Rows.Count - 2
                Dim valorCeldaExcel As Decimal = 0
                If Decimal.TryParse(dt.Rows(fila)(col).ToString(), valorCeldaExcel) Then

                    Dim costoInsumo As Decimal = 0
                    If fila < dtgListadoInsumos.Rows.Count Then
                        Dim valorCostoInsumo As String = dtgListadoInsumos.Rows(fila).Cells(2).Value.ToString()
                        Decimal.TryParse(valorCostoInsumo, costoInsumo)
                    End If

                    totalCostos += valorCeldaExcel * costoInsumo
                End If
            Next

            filaCostos(col) = totalCostos
        Next

        dt.Rows.Add(filaCostos)
        dtgListadoExcel.DataSource = dt

        FormatoCeldaCostoTotal()
    End Sub


    Private Sub btnImportarExcel_Click(sender As Object, e As EventArgs) Handles btnImportarExcel.Click
        Try
            If dtgListadoInsumos.Rows.Count = 0 Then
                msj_advert("ASIGNE INSUMOS BASE PARA LA FORMULACIÓN")
                Return
            End If

            Dim openFileDialog As New OpenFileDialog With {
                .Filter = "Archivos de Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*",
                .Title = "Seleccione un archivo Excel"
            }

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath As String = openFileDialog.FileName
                CargarExcelEnUltraGrid(filePath)
                GuardarTodosLosValoresEnDiccionario()

                FormatoCeldaCostoTotal()
                btnMoveUp.Enabled = True
                btnMoveDown.Enabled = True
                btnVerificarCantidades.Enabled = True
                txtLimInferior.Enabled = True
                txtLimSuperior.Enabled = True
                clsBasicas.Formato_Tablas_Grid_Formula_Base(dtgListadoExcel)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CargarExcelEnUltraGrid(filePath As String)
        Try
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial
            Dim dt As New DataTable()

            Dim nuevoDicNucleos As New Dictionary(Of String, Integer) From {{"", 0}}

            For Each kvp As KeyValuePair(Of String, Integer) In dicNucleos
                nuevoDicNucleos.Add(kvp.Key, kvp.Value)
            Next

            Using package As New ExcelPackage(New FileInfo(filePath))
                Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.First()

                If worksheet.Dimension Is Nothing Then
                    msj_advert("FORMATO NO PERMITIDO. El archivo Excel no tiene datos o la estructura no es válida.")
                    Return
                End If

                Dim totalFilas As Integer = worksheet.Dimension.End.Row

                Dim colIndex As Integer = 2
                For Each key In nuevoDicNucleos.Keys
                    Dim columnHeader As String = worksheet.Cells(1, colIndex).Text
                    Dim cabeceraCombinada As String = $"{key}({columnHeader})"
                    dt.Columns.Add(cabeceraCombinada)
                    colIndex += 1
                Next

                Dim totalColumnas As Integer = worksheet.Dimension.End.Column

                'msj_advert(
                '"CANTIDAD FILAS EXCEL: " & cantidadFilas & vbCrLf &
                '"CANTIDAD COLUMNAS EXCEL: " & cantidadColumnas & vbCrLf &
                '"CANTIDAD FILAS TABLA: " & totalFilas & vbCrLf &
                '"CANTIDAD COLUMNAS TABLA: " & totalColumnas
                ')

                If totalColumnas <> cantidadColumnas OrElse totalFilas <> cantidadFilas Then
                    msj_advert("El archivo Excel no tiene la misma cantidad de columnas o filas que la tabla. Por favor, verifique.")
                    Return
                End If

                ' CARGAR TODA LA DATA DEL EXCEL PRIMERO
                For row As Integer = 2 To worksheet.Dimension.End.Row - 2
                    Dim nuevaFila As DataRow = dt.NewRow()

                    For col As Integer = 2 To worksheet.Dimension.End.Column
                        Dim celda As ExcelRange = worksheet.Cells(row, col)
                        If celda.Merge Then
                            Exit For
                        End If
                        If col - 2 < dt.Columns.Count Then
                            nuevaFila(col - 2) = celda.Text
                        End If
                    Next

                    dt.Rows.Add(nuevaFila)
                Next
            End Using

            ' AHORA SÍ CALCULAR TOTALES Y COSTOS DESPUÉS DE CARGAR TODO
            Dim filaSumatoria As DataRow = dt.NewRow()
            filaSumatoria(0) = "Totales"
            For col As Integer = 1 To dt.Columns.Count - 1
                Dim currentCol As Integer = col
                filaSumatoria(currentCol) = dt.AsEnumerable().Where(Function(r) Not IsDBNull(r(currentCol))).Sum(Function(r) Convert.ToDecimal(r(currentCol)))
            Next
            dt.Rows.Add(filaSumatoria)

            Dim filaCostos As DataRow = dt.NewRow()
            filaCostos(0) = "Costos"
            For col As Integer = 1 To dt.Columns.Count - 1
                Dim totalCostos As Decimal = 0
                For fila As Integer = 0 To dt.Rows.Count - 2  ' Cambiado de -3 a -2 porque ya no está la fila de totales
                    Dim valorCeldaExcel As Decimal = 0
                    If Decimal.TryParse(dt.Rows(fila)(col).ToString(), valorCeldaExcel) Then
                        Dim costoInsumo As Decimal = 0
                        If fila < dtgListadoInsumos.Rows.Count Then
                            Dim valorCostoInsumo As String = dtgListadoInsumos.Rows(fila).Cells(2).Value.ToString()
                            Decimal.TryParse(valorCostoInsumo, costoInsumo)
                        End If
                        totalCostos += valorCeldaExcel * costoInsumo
                    End If
                Next
                filaCostos(col) = totalCostos
            Next
            dt.Rows.Add(filaCostos)

            dtgListadoExcel.DataSource = dt
            ' Ahora sí ocultar las 2 últimas filas (Totales y Costos)
            'dtgListadoExcel.Rows(dtgListadoExcel.Rows.Count - 1).Hidden = True  ' Costos
            'dtgListadoExcel.Rows(dtgListadoExcel.Rows.Count - 2).Hidden = True  ' Totales
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub GuardarTodosLosValoresEnDiccionario()
        Dim totalFilas As Integer = dtgListadoExcel.Rows.Count - 2
        For i As Integer = 0 To totalFilas - 1
            Dim fila As UltraGridRow = dtgListadoExcel.Rows(i)

            For Each celda As UltraGridCell In fila.Cells
                If celda.Column.Index > 0 Then
                    If IsNumeric(celda.Value) Then
                        Dim valorCantidad As Decimal = CDec(celda.Value)

                        If valorCantidad = 0 Then
                            Continue For
                        End If

                        Dim nombreProducto As String = fila.Cells(0).Value.ToString()
                        Dim nombreNucleo As String = celda.Column.Key
                        Dim claveCelda As String = $"{nombreProducto}@{nombreNucleo}"
                        Dim limiteInferiorValor As Decimal = If(String.IsNullOrEmpty(txtLimInferior.Text), 0.0, CDec(txtLimInferior.Text))
                        Dim limiteSuperiorValor As Decimal = If(String.IsNullOrEmpty(txtLimSuperior.Text), 0.0, CDec(txtLimSuperior.Text))
                        Dim codigoNucleo As Integer = dicNucleos(EncontrarNucleoEnDiccionario(nombreNucleo, dicNucleos))

                        valoresPorCelda(claveCelda) = (valorCantidad, limiteInferiorValor, limiteSuperiorValor, codigoNucleo)
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub dtgListadoExcel_CellChange(sender As Object, e As CellEventArgs) Handles dtgListadoExcel.CellChange
        Try
            If dtgListadoExcel.ActiveCell IsNot Nothing Then
                Dim valorCantidad As String = dtgListadoExcel.ActiveCell.Text.Trim()
                Dim cantidadDecimal As Decimal
                Dim columnaActual As String = dtgListadoExcel.ActiveCell.Column.Key

                Dim valorTemporal As String = dtgListadoExcel.ActiveCell.Text
                valorTemporal = System.Text.RegularExpressions.Regex.Replace(valorTemporal, "[^0-9.]", "")

                If IsNumeric(valorTemporal) Then
                    RecalcularSumaColumnaEnTiempoReal(columnaActual, CDec(valorTemporal))
                End If

                If Decimal.TryParse(valorCantidad, cantidadDecimal) Then
                    txtCantidad.Text = cantidadDecimal.ToString("F2")
                    txtInferior.Text = calcularHolgura("inferior", cantidadDecimal).ToString("F2")
                    txtSuperior.Text = calcularHolgura("superior", cantidadDecimal).ToString("F2")
                Else
                    txtCantidad.Clear()
                    txtInferior.Clear()
                    txtSuperior.Clear()
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_AfterExitEditMode(sender As Object, e As EventArgs) Handles dtgListadoExcel.AfterExitEditMode
        Try
            GuardarValoresCeldaActual()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub GuardarValoresCeldaActual()
        If dtgListadoExcel.ActiveCell IsNot Nothing AndAlso IsNumeric(dtgListadoExcel.ActiveCell.Value) Then
            Dim valorCantidad As Decimal = CDec(dtgListadoExcel.ActiveCell.Value)

            If valorCantidad = 0 Then
                Exit Sub
            End If

            If IsDBNull(dtgListadoExcel.ActiveRow.Cells(0).Value) OrElse dtgListadoExcel.ActiveRow.Cells(0).Value Is Nothing Then
                FormatearLimSuperiorInferior()
                Return
            End If

            Dim nombreProducto As String = dtgListadoExcel.ActiveRow.Cells(0).Value
            Dim nombreNucleo As String = dtgListadoExcel.ActiveCell.Column.Key
            Dim claveCelda As String = $"{nombreProducto}@{nombreNucleo}"
            Dim limiteInferiorValor As Decimal = If(String.IsNullOrEmpty(txtLimInferior.Text), 0.0, CDec(txtLimInferior.Text))
            Dim limiteSuperiorValor As Decimal = If(String.IsNullOrEmpty(txtLimSuperior.Text), 0.0, CDec(txtLimSuperior.Text))
            Dim codigoNucleo As Integer = dicNucleos(EncontrarNucleoEnDiccionario(nombreNucleo, dicNucleos))

            valoresPorCelda(claveCelda) = (valorCantidad, limiteInferiorValor, limiteSuperiorValor, codigoNucleo)
        End If
    End Sub

    Private Sub txtLimInferior_Leave(sender As Object, e As EventArgs) Handles txtLimInferior.Leave
        GuardarValoresCeldaActual()
    End Sub

    Private Sub txtLimSuperior_Leave(sender As Object, e As EventArgs) Handles txtLimSuperior.Leave
        GuardarValoresCeldaActual()
    End Sub

    Private Function EncontrarNucleoEnDiccionario(nombreNucleo As String, dicNucleos As Dictionary(Of String, Integer)) As String
        For Each kvp As KeyValuePair(Of String, Integer) In dicNucleos
            If nombreNucleo.Contains(kvp.Key) Then
                Return kvp.Key
            End If
        Next
        Return Nothing
    End Function

    Private Sub dtgListadoExcel_AfterCellActivate(sender As Object, e As EventArgs) Handles dtgListadoExcel.AfterCellActivate
        Try
            If dtgListadoExcel.ActiveCell IsNot Nothing Then
                If IsDBNull(dtgListadoExcel.ActiveRow.Cells(0).Value) OrElse dtgListadoExcel.ActiveRow.Cells(0).Value Is Nothing Then
                    FormatearLimSuperiorInferior()
                    Return
                End If

                Dim nombreProducto As String = dtgListadoExcel.ActiveRow.Cells(0).Value
                Dim nombreNucleo As String = dtgListadoExcel.ActiveCell.Column.Key
                Dim claveCelda As String = $"{nombreProducto}@{nombreNucleo}"

                If valoresPorCelda.ContainsKey(claveCelda) Then
                    Dim valoresGuardados = valoresPorCelda(claveCelda)
                    txtLimInferior.Text = valoresGuardados.LimInferior.ToString("F2")
                    txtLimSuperior.Text = valoresGuardados.LimSuperior.ToString("F2")
                Else
                    FormatearLimSuperiorInferior()
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FormatearLimSuperiorInferior()
        txtLimInferior.Text = "0.0"
        txtLimSuperior.Text = "0.0"
        txtInferior.Text = "0.0"
        txtSuperior.Text = "0.0"
    End Sub

    Private Sub RecalcularSumaColumnaEnTiempoReal(columna As String, valorTemporal As Decimal)
        Dim sumaTotal As Decimal = 0

        For Each row As UltraGridRow In dtgListadoExcel.Rows
            If row.Index < dtgListadoExcel.Rows.Count - 2 Then
                If row Is dtgListadoExcel.ActiveRow AndAlso row.Cells(columna).Column.Key = dtgListadoExcel.ActiveCell.Column.Key Then
                    sumaTotal += valorTemporal
                Else
                    If IsNumeric(row.Cells(columna).Value) Then
                        sumaTotal += CDec(row.Cells(columna).Value)
                    End If
                End If
            End If
        Next
        Dim filaTotal As UltraGridRow = dtgListadoExcel.Rows(dtgListadoExcel.Rows.Count - 2)
        filaTotal.Cells(columna).Value = sumaTotal
    End Sub

    Private Sub dtgListado_ClickCell(sender As Object, e As ClickCellEventArgs) Handles dtgListadoExcel.ClickCell
        Try
            If dtgListadoExcel.ActiveCell IsNot Nothing Then
                Dim valorCantidad As Decimal
                Dim columnaActual As String = dtgListadoExcel.ActiveCell.Column.Key
                Dim idNucleo As Integer

                If Decimal.TryParse(dtgListadoExcel.ActiveCell.Value.ToString(), valorCantidad) Then
                    txtCantidad.Text = valorCantidad.ToString("F2")
                    txtInferior.Text = calcularHolgura("inferior", valorCantidad).ToString("F2")
                    txtSuperior.Text = calcularHolgura("superior", valorCantidad).ToString("F2")
                End If

                If dicNucleos.ContainsKey(columnaActual) Then
                    idNucleo = dicNucleos(columnaActual)
                Else
                    idNucleo = -1
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub txtLimInferior_TextChanged(sender As Object, e As EventArgs) Handles txtLimInferior.TextChanged
        Dim cantidad As Decimal

        If Decimal.TryParse(txtCantidad.Text, cantidad) Then
            txtInferior.Text = calcularHolgura("inferior", cantidad).ToString("F2")
        Else
            txtInferior.Text = "0.00"
        End If
    End Sub

    Private Sub txtLimSuperior_TextChanged(sender As Object, e As EventArgs) Handles txtLimSuperior.TextChanged
        Dim cantidad As Decimal

        If Decimal.TryParse(txtCantidad.Text, cantidad) Then
            txtSuperior.Text = calcularHolgura("superior", cantidad).ToString("F2")
        Else
            txtSuperior.Text = "0.00"
        End If
    End Sub

    Private Function calcularHolgura(tipo As String, cantidad As Decimal) As Decimal
        Dim limiteInferior As Decimal = 0
        Dim limiteSuperior As Decimal = 0

        If Decimal.TryParse(txtLimInferior.Text, limiteInferior) Then
            limiteInferior /= 100
        Else
            limiteInferior = 0
        End If

        If Decimal.TryParse(txtLimSuperior.Text, limiteSuperior) Then
            limiteSuperior /= 100
        Else
            limiteSuperior = 0
        End If

        Return If(tipo = "inferior", cantidad - (cantidad * limiteInferior), cantidad + (cantidad * limiteSuperior))
    End Function

    Private Sub txtLimInferior_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLimInferior.KeyPress
        ValidarEntrada(sender, e)
    End Sub

    Private Sub txtLimSuperior_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLimSuperior.KeyPress
        ValidarEntrada(sender, e)
    End Sub

    Private Sub ValidarEntrada(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If

        If e.KeyChar = "." AndAlso CType(sender, TextBox).Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub FormatoCeldaCostoTotal()
        Dim filaTotalesGrid As UltraGridRow = dtgListadoExcel.Rows(dtgListadoExcel.Rows.Count - 2)
        Dim filaCostosGrid As UltraGridRow = dtgListadoExcel.Rows(dtgListadoExcel.Rows.Count - 1)

        filaTotalesGrid.Cells(0).Appearance.BackColor = Color.LightGray
        filaTotalesGrid.Cells(0).Appearance.FontData.Bold = DefaultableBoolean.True
        filaTotalesGrid.Cells(0).Appearance.TextHAlign = HAlign.Center
        filaCostosGrid.Cells(0).Appearance.BackColor = Color.LightGray
        filaCostosGrid.Cells(0).Appearance.FontData.Bold = DefaultableBoolean.True
        filaCostosGrid.Cells(0).Appearance.TextHAlign = HAlign.Center

        For Each cell In filaTotalesGrid.Cells
            cell.Activation = Activation.NoEdit
        Next

        For Each cell In filaCostosGrid.Cells
            cell.Activation = Activation.NoEdit
        Next
    End Sub

    Private Sub btnVerificarCantidades_Click(sender As Object, e As EventArgs) Handles btnVerificarCantidades.Click
        If Not BackgroundWorker1.IsBusy Then
            BackgroundWorker1.RunWorkerAsync()
            Ptbx_Cargando.Visible = True
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        UnirTablasYObtenerResultado()
        Dim obj As New coControlFormulacion
        Dim listadetalleRacion As String = String.Join(",", valoresRealesParaGuardar.Select(Function(kvp) $"{kvp.Value.Cantidad}+{kvp.Key.Split("@"c)(1)}+{kvp.Key.Split("@"c)(0)}"))
        obj.ListaDetalleRacion = listadetalleRacion
        e.Result = cn.Cn_VerificarCantidades(obj)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        tvResultados.Nodes.Clear()
        Dim ds As DataSet = CType(e.Result, DataSet)

        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
            Dim tabla1 As DataTable = ds.Tables(0)
            Dim tabla2 As DataTable = ds.Tables(1)

            If tabla1.Rows.Count = 0 AndAlso tabla2.Rows.Count = 0 Then
                Dim nodoMensaje As TreeNode = tvResultados.Nodes.Add("CANTIDADES DENTRO DEL RANGO PERMITIDO")
            Else
                For Each fila As DataRow In tabla1.Rows
                    Dim nodoNucleo As TreeNode = tvResultados.Nodes.Add(fila("abreviatura").ToString())
                    nodoNucleo.Tag = fila("codigo").ToString()
                Next
                For Each fila As DataRow In tabla2.Rows
                    For Each nodoNucleo As TreeNode In tvResultados.Nodes
                        If nodoNucleo.Tag.ToString() = fila("codigo").ToString() Then
                            nodoNucleo.Nodes.Add(fila("mensaje").ToString())
                        End If
                    Next
                Next
            End If
        Else
            Dim nodoMensaje As TreeNode = tvResultados.Nodes.Add("CANTIDADES DENTRO DEL RANGO PERMITIDO")
        End If

        tvResultados.ExpandAll()
        Ptbx_Cargando.Visible = False
    End Sub

    Private Sub dtgListadoInsumos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListadoInsumos.InitializeLayout
        Try
            If (dtgListadoInsumos.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListadoInsumos, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class