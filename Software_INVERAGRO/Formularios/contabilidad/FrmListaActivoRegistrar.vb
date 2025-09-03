Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListaActivoRegistrar
    Dim cn As New cnActivo
    Public Property cantidadActivos As Integer
    Public Property producto As String
    Public Property fechaCompra As Date
    Public Property fechaRecepcion As Date
    Public Property idDetalleRecepcion As Integer
    Public Property precioUnitario As Decimal

    Private Sub FrmListaActivoRegistrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtfFechaCompra.Value = fechaCompra
        dtfFechaCompra.Enabled = False
        dtfFechaAdquisicion.Value = fechaRecepcion
        dtfFechaAdquisicion.Enabled = False
        Consultar()
    End Sub


    Private Sub GenerarTablaActivos(dtActivosRegistrados As DataTable)
        Dim table As New DataTable()
        table.Columns.Add("Nro", GetType(Integer))
        table.Columns.Add("Producto", GetType(String))
        table.Columns.Add("Estado", GetType(String))
        table.Columns.Add("Registrar Activo", GetType(String))

        Dim estadoOrden(cantidadActivos) As String

        For i As Integer = 1 To cantidadActivos
            estadoOrden(i) = "PENDIENTE"
        Next

        Dim esPorLote As Boolean = False

        For Each row As DataRow In dtActivosRegistrados.Rows
            Dim tipo As String = row("Tipo").ToString()
            If tipo = "LOTE" Then
                esPorLote = True
            End If
            Dim numOrden As Integer = Convert.ToInt32(row("numOrden"))
            If numOrden <= cantidadActivos Then
                estadoOrden(numOrden) = "REGISTRADO"
            End If
        Next

        If esPorLote Then
            For i As Integer = 1 To cantidadActivos
                estadoOrden(i) = "REGISTRADO"
            Next
        End If

        For i As Integer = 1 To cantidadActivos
            Dim newRow As DataRow = table.NewRow()
            newRow("Nro") = i
            newRow("Producto") = producto
            newRow("Estado") = estadoOrden(i)
            newRow("Registrar Activo") = "Registrar"
            table.Rows.Add(newRow)
        Next

        dtgListado.DataSource = table
        dtgListado.DataBind()

        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "REGISTRADO", 2)
    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        Dim column As Infragistics.Win.UltraWinGrid.UltraGridColumn = dtgListado.DisplayLayout.Bands(0).Columns("Registrar Activo")
        column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        If Not e.ReInitialize Then
            e.Row.Cells("Registrar Activo").Value = "Registrar"
            e.Row.Cells("Registrar Activo").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        End If
    End Sub

    Sub Consultar()
        Dim obj As New coActivo
        obj.IdDetalleRecepcion = idDetalleRecepcion
        Dim dtActivosRegistrados As DataTable = cn.Cn_ConsultarActivosRegistrados(obj)

        If dtActivosRegistrados.Rows.Count > 0 Then
            Dim tipo As String = dtActivosRegistrados.Rows(0)("Tipo").ToString()
            lblModalidad.Text = tipo
        Else
            lblModalidad.Text = "NO DEFINIDO"
        End If

        GenerarTablaActivos(dtActivosRegistrados)
    End Sub

    Private Sub btnLotizarActivo_Click(sender As Object, e As EventArgs) Handles btnLotizarActivo.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                    If Not row.IsFilterRow Then ' Asegúrate de ignorar las filas de filtro
                        Dim estado As String = row.Cells("Estado").Value.ToString()

                        If estado = "REGISTRADO" Then
                            msj_advert("No se puede lotizar un producto que ya fue registrado como activo o ya fue Lotizado.")
                            Exit Sub
                        End If
                    End If
                Next

                Dim precioTotal As Decimal = cantidadActivos * precioUnitario

                Dim f As New FrmRegistrarActivo
                f.idDetalleRecepcion = idDetalleRecepcion
                f.tipo = "LOTE"
                f.fechaAdquisicion = dtfFechaAdquisicion.Value
                f.nombreProducto = producto
                f.precioUnitario = precioTotal
                f.formListarActivoRegistrar = Me
                f.ShowDialog()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub
    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            With dtgListado
                If (e.Cell.Column.Key = "Registrar Activo") Then
                    If (dtgListado.ActiveRow.Cells(2).Value.ToString = "PENDIENTE") Then
                        Dim f As New FrmRegistrarActivo
                        f.idDetalleRecepcion = idDetalleRecepcion
                        f.tipo = "INDIVIDUAL"
                        f.numOrden = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                        f.fechaAdquisicion = dtfFechaAdquisicion.Value
                        f.nombreProducto = producto
                        f.formListarActivoRegistrar = Me
                        f.precioUnitario = precioUnitario
                        f.ShowDialog()
                    Else
                        msj_advert("El Activo ya fue registrado")
                        Exit Sub
                    End If
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class