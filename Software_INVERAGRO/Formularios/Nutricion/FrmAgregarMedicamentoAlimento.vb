Imports CapaNegocio
Imports Infragistics.Win

Public Class FrmAgregarMedicamentoAlimento
    Dim cn As New cnProducto
    Public idAlmacen As Integer
    Public idAlimento As Integer
    Public nombreAlimento As String
    Public DtDetalleMedicSelect As New DataTable("TempDetMedicSelect")

    Private Sub FrmAgregarMedicamentoAlimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UltraGroupBox1.Text = "LISTA DE MEDICAMENTO PARA " & nombreAlimento
        ListarMedicamentos()
        If DtDetalleMedicSelect IsNot Nothing AndAlso DtDetalleMedicSelect.Rows.Count > 0 Then
            dtgListadoMedicSelect.DataSource = DtDetalleMedicSelect
            clsBasicas.Formato_Tablas_Grid(dtgListadoMedicSelect)
        Else
            CargarTablaDetalleMedicamentoSelect()
        End If
    End Sub

    Sub ListarMedicamentos()
        dtgListadoMedicamento.DataSource = cn.Cn_ListarMedicamentosActivos(idAlmacen)
        clsBasicas.Filtrar_Tabla(dtgListadoMedicamento, True)
        clsBasicas.Formato_Tablas_Grid(dtgListadoMedicamento)
        dtgListadoMedicamento.DisplayLayout.Bands(0).Columns(2).Hidden = True
    End Sub

    Sub CargarTablaDetalleMedicamentoSelect()
        DtDetalleMedicSelect = New DataTable("TempDetMedicamento")
        DtDetalleMedicSelect.Columns.Add("codprod", GetType(Integer))
        DtDetalleMedicSelect.Columns.Add("producto", GetType(String))
        DtDetalleMedicSelect.Columns.Add("btneliminar", GetType(String))
        dtgListadoMedicSelect.DataSource = DtDetalleMedicSelect
        clsBasicas.Formato_Tablas_Grid(dtgListadoMedicSelect)
    End Sub

    Private Sub dtgListadoMedicamento_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dtgListadoMedicamento.InitializeRow
        Dim column As Infragistics.Win.UltraWinGrid.UltraGridColumn = dtgListadoMedicamento.DisplayLayout.Bands(0).Columns("Seleccionar")
        column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        If Not e.ReInitialize Then
            e.Row.Cells("Seleccionar").Value = "Seleccionar"
            e.Row.Cells("Seleccionar").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        End If
    End Sub

    Private Sub dtgListadoMedicSelect_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListadoMedicSelect.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Header.Caption = "Medicamento"
                .Columns(1).Width = 200
                .Columns(2).Header.Caption = "Eliminar"
                .Columns(2).Width = 50
                .Columns(2).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(2).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(2).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListadoMedicSelect_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListadoMedicSelect.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este Medicamento?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetalleMedicSelect.Rows.RemoveAt(rowIndex)
                DtDetalleMedicSelect.AcceptChanges()
                dtgListadoMedicSelect.DataSource = DtDetalleMedicSelect
            End If
        End If
    End Sub

    Private Sub dtgListadoMedicamento_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListadoMedicamento.ClickCellButton
        If e.Cell.Column.Key = "Seleccionar" Then
            For Each dr As DataRow In DtDetalleMedicSelect.Rows
                If dr(0) = dtgListadoMedicamento.Rows(e.Cell.Row.Index).Cells(0).Value Then
                    msj_advert("El medicamento ya se encuentra en la lista")
                    Exit Sub
                End If
            Next
            Dim row As DataRow = DtDetalleMedicSelect.NewRow

            row(0) = dtgListadoMedicamento.Rows(e.Cell.Row.Index).Cells(0).Value
            row(1) = dtgListadoMedicamento.Rows(e.Cell.Row.Index).Cells(1).Value
            DtDetalleMedicSelect.Rows.Add(row)
            dtgListadoMedicSelect.DataSource = DtDetalleMedicSelect
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If DtDetalleMedicSelect.Rows.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("Hay medicamentos registrados ¿Está seguro de que desea salir?", "Confirmar Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub
End Class