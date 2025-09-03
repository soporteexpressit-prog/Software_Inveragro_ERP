Imports CapaNegocio
Imports Infragistics.Win

Public Class FrmAsignarInsumoPremixero
    Dim CodPremixero As Integer
    Dim DatosPremixero As String
    Public listaIdsInsumos As New List(Of Integer)
    Public SelectedInsumos As New HashSet(Of Integer)
    Public DtDetalle As New DataTable("TempDetInsumosPremixero")
    Public idFormulaBase As Integer = 0
    Public idNucleo As Integer = 0
    Public cantidadPreparacion As Double = 0.00
    Public ListaInsumosRecibidos As List(Of Integer)

    Private Sub FrmAsignarInsumoPremixero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTipo.ReadOnly = True
        CargarTablaDetalleInsumosPremixero()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarPremixeros()
    End Sub

    Sub ListarPremixeros()
        Try
            Dim cn As New cnControlPremixero
            Dim tb As New DataTable
            tb = cn.Cn_ListarTrabajadorPremixeroActivo().Copy
            tb.TableName = "tmp"
            tb.Columns(1).ColumnName = "Seleccione una Premixero"
            With cmbPremixero
                .DataSource = tb
                .DisplayMember = tb.Columns(1).ColumnName
                .ValueMember = tb.Columns(0).ColumnName
                If (tb.Rows.Count > 0) Then
                    .Value = tb.Rows(0)(0)
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub CargarTablaDetalleInsumosPremixero()
        DtDetalle = New DataTable("TempDetInsumosPremixero")
        DtDetalle.Columns.Add("codprod", GetType(Integer))
        DtDetalle.Columns.Add("producto", GetType(String))
        DtDetalle.Columns.Add("cantidad", GetType(Double))
        DtDetalle.Columns.Add("idPremixero", GetType(Integer))
        DtDetalle.Columns.Add("premixero", GetType(String))
        DtDetalle.Columns.Add("tipo", GetType(String))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        DtDetalle.Columns.Add("cantUnaTonelada", GetType(Double))
        dtgListado.DataSource = DtDetalle
        dtgListado.DisplayLayout.Bands(0).Columns("idPremixero").Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns("premixero").Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns("tipo").Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns("cantUnaTonelada").Hidden = True
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If (CodPremixero < 1) Then
                msj_advert("Seleccione un Premixero")
                Exit Sub
            End If

            Dim f As New FrmListarProductoFormula(Me) With {
                .Owner = Me,
                .idFormulaBase = idFormulaBase,
                .idNucleo = idNucleo,
                .cantidadPreparacion = cantidadPreparacion,
                .listaIdsInsumos = listaIdsInsumos,
                .tipoPremixero = txtTipo.Text
            }
            f.ShowDialog()

            If f.listaIdsInsumosFormula IsNot Nothing Then
                ListaInsumosRecibidos = f.listaIdsInsumosFormula
            End If

            If dtgListado.Rows.Count <> 0 Then
                cmbPremixero.Enabled = False
            Else
                cmbPremixero.Enabled = True
            End If

            If (txtTipo.Text = "PREMIXERO 3") Then
                For Each row As DataRow In DtDetalle.Rows
                    row("cantidad") = CDbl(row("cantidad")) / (cantidadPreparacion * 2)
                Next
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(0).Width = 70
                .Columns(1).Header.Caption = "Producto"
                .Columns(1).Width = 200
                .Columns(2).Header.Caption = "Cantidad"
                .Columns(2).Width = 90
                .Columns(6).Header.Caption = "Eliminar"
                .Columns(6).Width = 60
                .Columns(6).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(6).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(6).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO QUE DESEA ELIMINAR ESTE INSUMO?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                Dim codProducto As Integer = CInt(dtgListado.Rows(rowIndex).Cells(0).Value)

                DtDetalle.Rows.RemoveAt(rowIndex)
                SelectedInsumos.Remove(codProducto)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle

                If dtgListado.Rows.Count <> 0 Then
                    cmbPremixero.Enabled = False
                Else
                    cmbPremixero.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (CodPremixero < 1) Then
                msj_advert("SELECCIONE UN PREMIXERO")
            ElseIf (dtgListado.Rows.Count = 0) Then
                msj_advert("Seleccione por lo menos un Producto")
            Else
                For Each row As DataRow In DtDetalle.Rows
                    row("premixero") = DatosPremixero
                    row("idPremixero") = CodPremixero
                    row("tipo") = txtTipo.Text
                Next

                Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE LA ASIGNACION DE INSUMOS AL PREMIXERO?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If result = DialogResult.Yes Then
                    Dim frmPadre As FrmAsignarFormula = CType(Me.Owner, FrmAsignarFormula)
                    frmPadre.listaIdsInsumosFormula = ListaInsumosRecibidos
                    frmPadre.AgregarInsumos(DtDetalle)
                    If Not HayConflictos(DtDetalle, frmPadre) Then
                        Me.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function HayConflictos(detalleInsumos As DataTable, frmPadre As FrmAsignarFormula) As Boolean
        Dim conflictos As Boolean = False

        For Each row As DataRow In detalleInsumos.Rows
            Dim nuevoTipo As String = row("tipo").ToString()
            Dim nuevoPremixero As String = row("premixero").ToString()

            For Each detalleRow As DataRow In frmPadre.DtDetalle.Rows
                Dim tipoExistente As String = detalleRow("tipo_premixero").ToString()
                Dim premixeroExistente As String = detalleRow("premixero").ToString()

                If tipoExistente = nuevoTipo AndAlso premixeroExistente <> nuevoPremixero Then
                    conflictos = True
                    Exit For
                End If
            Next
        Next

        Return conflictos
    End Function

    'Private Sub btnInsumoMacro_CheckedChanged(sender As Object, e As EventArgs)
    '    If btnInsumoMacro.Checked Then
    '        For Each row As DataRow In DtDetalle.Rows
    '            row("cantidad") = CDbl(row("cantidad")) / (cantidadPreparacion * 2)
    '        Next
    '    Else
    '        For Each row As DataRow In DtDetalle.Rows
    '            row("cantidad") = CDbl(row("cantidad")) * (cantidadPreparacion * 2)
    '        Next
    '    End If

    '    DtDetalle.AcceptChanges()
    '    dtgListado.DataSource = DtDetalle
    'End Sub

    Private Sub btnAgregarPlus_Click(sender As Object, e As EventArgs) Handles btnAgregarPlus.Click
        Try
            Dim f As New FrmListarEnInsumoPlus(Me) With {
                .idNucleo = idNucleo,
                .idFormulaBase = idFormulaBase
            }
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cmbPremixero_ValueChanged(sender As Object, e As EventArgs) Handles cmbPremixero.ValueChanged
        Dim codigo As Integer = CInt(cmbPremixero.SelectedRow.Cells(0).Value)
        Dim datos As String = cmbPremixero.SelectedRow.Cells(1).Value.ToString()
        Dim tipo As String = cmbPremixero.SelectedRow.Cells(2).Value.ToString()
        CodPremixero = codigo
        txtTipo.Text = tipo
        DatosPremixero = datos

        'If (txtTipo.Text = "PREMIXERO 3") Then
        '    For Each row As DataRow In DtDetalle.Rows
        '        row("cantidad") = CDbl(row("cantidad")) / (cantidadPreparacion * 2)
        '    Next
        'Else
        '    For Each row As DataRow In DtDetalle.Rows
        '        row("cantidad") = CDbl(row("cantidad")) * (cantidadPreparacion * 2)
        '    Next
        'End If

        'DtDetalle.AcceptChanges()
        'dtgListado.DataSource = DtDetalle
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class