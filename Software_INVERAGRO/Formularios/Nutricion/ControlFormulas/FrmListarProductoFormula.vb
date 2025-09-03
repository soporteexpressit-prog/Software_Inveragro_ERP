Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarProductoFormula
    Dim cn As New cnControlFormulacion
    Dim codigoMaiz As Integer
    Public listaIdsInsumos As New List(Of Integer)
    Public listaIdsInsumosFormula As New List(Of Integer)
    Private ReadOnly _frmAsignarInsumoPremixero As FrmAsignarInsumoPremixero
    Private SelectedRows As New List(Of DataRow)
    Public idFormulaBase As Integer = 0
    Public idNucleo As Integer = 0
    Public cantidadPreparacion As Double = 0.00
    Public tipoPremixero As String = ""

    Public Sub New(frmAsignarInsumoPremixero As FrmAsignarInsumoPremixero)
        InitializeComponent()
        _frmAsignarInsumoPremixero = frmAsignarInsumoPremixero
    End Sub

    Private Sub FrmListarProductoFormula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarInsumos()
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True

            For Each row As DataRow In CType(dtgListado.DataSource, DataTable).Rows
                Dim codInsumo As Integer = CInt(row("Código"))
                Dim descripcion As String = row("Descripción").ToString()
                Dim descripcionNormalizada As String = descripcion.ToLower().Replace("í", "i")

                If descripcionNormalizada.Contains("maiz") Then
                    codigoMaiz = codInsumo
                    Exit For
                End If

                If _frmAsignarInsumoPremixero.SelectedInsumos.Contains(codInsumo) Then
                    Dim gridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.Rows.
                Where(Function(r) CInt(r.Cells("Código").Value) = codInsumo).FirstOrDefault()

                    If gridRow IsNot Nothing Then
                        gridRow.Appearance.BackColor = Color.LightBlue
                    End If
                End If
            Next

            PintarFilasConIdsInsumos()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarInsumos()
        Dim obj As New coControlFormulacion With {
            .Codigo = idFormulaBase,
            .IdNucleo = idNucleo
        }

        Dim dt As DataTable = cn.Cn_ObtenerInsumosxFormulaNucleo(obj)
        dtgListado.DataSource = dt

        listaIdsInsumosFormula.Clear()

        For Each row As DataRow In dt.Rows
            Dim descripcion As String = row("Descripción").ToString()
            Dim codInsumo As Integer = CInt(row("Código"))

            If descripcion.Contains("MAIZ") Then
                codigoMaiz = codInsumo
            Else
                listaIdsInsumosFormula.Add(codInsumo)
            End If
        Next
    End Sub

    Private Sub PintarFilasConIdsInsumos()
        Dim countMaiz As Integer = listaIdsInsumos.Where(Function(id) id = codigoMaiz).Count()

        For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            Dim codProducto As Integer = CInt(fila.Cells(0).Value)

            If codProducto = codigoMaiz Then
                If countMaiz = 2 Then
                    fila.Appearance.BackColor = Color.LightGray
                End If
            ElseIf listaIdsInsumos.Contains(codProducto) Then
                fila.Appearance.BackColor = Color.LightGray
            End If
        Next
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If e.Cell.Row.Index >= 0 Then
            If dtgListado.Rows(e.Cell.Row.Index).Appearance.BackColor = Color.LightGray Then
                msj_advert("El insumo seleccionado ya ha sido asignado.")
                Return
            End If

            Dim selectedRow As DataRow = CType(dtgListado.DataSource, DataTable).Rows(e.Cell.Row.Index)
            Dim codParticipante As Integer = CInt(selectedRow(0))

            dtgListado.Rows(e.Cell.Row.Index).Appearance.BackColor = Color.LightBlue

            If Not _frmAsignarInsumoPremixero.SelectedInsumos.Contains(codParticipante) Then
                _frmAsignarInsumoPremixero.SelectedInsumos.Add(codParticipante)
                SelectedRows.Add(selectedRow)
            End If
        Else
            Return
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        For Each row As DataRow In SelectedRows
            Dim dr As DataRow = _frmAsignarInsumoPremixero.DtDetalle.NewRow()

            dr("codprod") = row(0)
            dr("producto") = row(1)

            If (tipoPremixero = "PREMIXERO 1" OrElse tipoPremixero = "PREMIXERO 2") AndAlso CInt(row(0)) = codigoMaiz Then
                dr("cantidad") = 0
            Else
                dr("cantidad") = row(3) * cantidadPreparacion
            End If

            dr("btneliminar") = ""
            dr("cantUnaTonelada") = row(3)

            _frmAsignarInsumoPremixero.DtDetalle.Rows.Add(dr)
        Next

        _frmAsignarInsumoPremixero.DtDetalle.AcceptChanges()
        DirectCast(Me.Owner, FrmAsignarInsumoPremixero).ListaInsumosRecibidos = listaIdsInsumosFormula
        Me.Close()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If _frmAsignarInsumoPremixero.DtDetalle.Rows.Count = 0 Then
            _frmAsignarInsumoPremixero.SelectedInsumos.Clear()
        End If
        Me.Close()
    End Sub
End Class