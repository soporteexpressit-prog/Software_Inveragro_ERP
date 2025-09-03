Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmBuscarPedidosVentasPendientesFacturacion
    Dim cn As New cnVentas
    Dim ds As New DataSet


    Private _selectedIds As New List(Of Integer)()
    Private _selectedIdsString As String = ""
    Private _totalSelectedAmount As Decimal = 0.0D
    Private _currentPersonaId As Integer? = Nothing
    Private _currentWeekStart As Date? = Nothing
    Private _currentWeekEnd As Date? = Nothing


    Private Sub dtgListado_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles dtgListado.ClickCell
        Try
            If e.Cell Is Nothing OrElse e.Cell.Row Is Nothing Then Exit Sub

            ' 5) Si ya no hay seleccionados, reseteamos la persona actual y la semana
            If _selectedIds.Count = 0 Then
                _currentPersonaId = Nothing
                _currentWeekStart = Nothing
                _currentWeekEnd = Nothing
            End If

            ' Fecha de pedido en columna 2 (índice 2)
            Dim fechaPedido As Date = CDate(e.Cell.Row.Cells(2).Value)

            ' Si es la primera fila seleccionada, calcular semana (domingo a sábado)
            If Not _currentWeekStart.HasValue Then
                Dim diaSemana As Integer = CInt(fechaPedido.DayOfWeek) ' Sunday = 0 ... Saturday = 6
                _currentWeekStart = fechaPedido.AddDays(-diaSemana)    ' domingo
                _currentWeekEnd = _currentWeekStart.Value.AddDays(6)   ' sábado
            End If

            ' Validar si la fecha está dentro de la semana
            If fechaPedido < _currentWeekStart.Value OrElse fechaPedido > _currentWeekEnd.Value Then
                msj_advert("Solo puedes seleccionar fechas dentro de la misma semana: " &
                       _currentWeekStart.Value.ToShortDateString() & " al " &
                       _currentWeekEnd.Value.ToShortDateString())
                Return
            End If

            ' 1) IdPersona de la columna 15 (índice 15)
            Dim thisPersonaId As Integer = CInt(e.Cell.Row.Cells(15).Value)

            ' 2) Si no hay aún una "persona actual", la estableces
            If Not _currentPersonaId.HasValue Then
                _currentPersonaId = thisPersonaId
            End If

            ' 3) Si la fila clicada NO coincide con la persona actual, mensaje y sales
            If thisPersonaId <> _currentPersonaId.Value Then
                msj_advert("Por favor seleccione a la misma persona")
                Return
            End If

            ' 4) Toggle selección
            Dim id As Integer = CInt(e.Cell.Row.Cells(0).Value)
            Dim amount As Decimal = CDec(e.Cell.Row.Cells(11).Value)

            If Not _selectedIds.Contains(id) Then
                _selectedIds.Add(id)
                If _selectedIdsString.Length > 0 Then _selectedIdsString &= ","
                _selectedIdsString &= id.ToString()
                _totalSelectedAmount += amount
                e.Cell.Row.Appearance.BackColor = Color.LightBlue
            Else
                _selectedIds.Remove(id)
                _selectedIdsString = String.Join(",", _selectedIds)
                _totalSelectedAmount -= amount
                e.Cell.Row.Appearance.ResetBackColor()
            End If

        Catch ex As Exception
        End Try
    End Sub

    ' Add a method to clear the selection
    Public Sub ClearSelection()
        _selectedIds.Clear()
        _selectedIdsString = ""
        _totalSelectedAmount = 0.0D
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            row.Appearance.ResetBackColor()
        Next
    End Sub

    Public ReadOnly Property SelectedIdsString As String
        Get
            Return _selectedIdsString
        End Get
    End Property
    Public ReadOnly Property TotalSelectedAmount As Decimal
        Get
            Return _totalSelectedAmount
        End Get
    End Property

    Private Sub FrmControlEpp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaDesde.Value = Now.Date.AddDays(-4)
        dtpFechaHasta.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub
    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coVentas
            obj.Fechadesde = dtpFechaDesde.Value
            obj.Fechahasta = dtpFechaHasta.Value
            ds = New DataSet
            ds = cn.Cn_ConsultarPedidosVentaEnviadasaFacturacion(obj).Copy
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        btnConsultar.Enabled = True
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            ds.DataSetName = "tmp"

            Dim relation1 As New DataRelation("tabla_relacion_32", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(5), False)

            ds.Relations.Add(relation1)
            dtgListado.DataSource = ds
            If (ds.Tables(0).Rows.Count > 0) Then
                'clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", 17)
                'clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 17)

                'clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "RECEPCIONADO", 18)
                'clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "PARCIAL", 18)
                'clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "SIN RECEPCION", 18)
            End If
            ToolStrip1.Enabled = True
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try

            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True
                .Columns(15).Hidden = True
                .Columns("codpedido").Header.VisiblePosition = 0
                .Columns("codpedido").Header.Caption = "Código Pedido"
                .Columns("codpedido").Width = 130
                '.Columns(3).Hidden = True
                '.Columns(4).Hidden = True
                '.Columns(8).Hidden = True
                '.Columns(15).Hidden = True
                '.Columns("btnver").Header.Caption = "Cotización"
                '.Columns("btnver").Width = 80
                '.Columns("btnver").Style = UltraWinGrid.ColumnStyle.Button
                '.Columns("btnver").CellButtonAppearance.Image = My.Resources.adjuntar
                '.Columns("btnver").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always

            End With

            With e.Layout.Bands(1)
                .Columns(5).Hidden = True
            End With
            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 1)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 8)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        Consultar()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub btnfacturar_Click(sender As Object, e As EventArgs) Handles btnfacturar.Click
        Try
            If (dtgListado.Rows.Count > 0) Then

                Dim row As UltraGridRow = dtgListado.ActiveRow
                If row Is Nothing Then
                    msj_advert("Seleccione una fila válida.")
                    Return
                End If

                If _selectedIdsString = "" Then
                    msj_advert("Seleccione un Pedido de Venta")
                    Return
                End If
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length = 0) Then
                    msj_advert("Seleccione un Pedido de Venta")
                Else
                    Dim f As New FrmFacturacion
                    f._codordencompra = _selectedIdsString
                    f.txtnumorden.Text = dtgListado.ActiveRow.Cells("codpedido").Value.ToString
                    f._IGV = dtgListado.ActiveRow.Cells(7).Value.ToString
                    f.ShowDialog() ' Muestra el nuevo formulario
                    _currentPersonaId = Nothing
                    _currentWeekStart = Nothing
                    _currentWeekEnd = Nothing
                    _selectedIdsString = ""
                    Consultar()
                    ClearSelection()
                End If
            Else
                msj_advert("Seleccione una Orden de Compra")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class