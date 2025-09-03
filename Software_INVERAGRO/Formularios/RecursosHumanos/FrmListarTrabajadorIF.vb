Imports CapaNegocio
Imports Infragistics.Win
Public Class FrmListarTrabajadorIF
    Dim cn As New cnTrabajador
    Private SelectedRows As New List(Of DataRow)
    Private _callback As Action(Of DataRow)
    Public Sub New(callback As Action(Of DataRow))
        InitializeComponent()
        _callback = callback
    End Sub
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub FrmLisrtarTrabajadorIF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarTrabajadoresActivos()
    End Sub
    Sub ListarTrabajadoresActivos()
        dtgListado.DataSource = cn.Cn_ListarTrabajadoresActivos()
    End Sub
    Private Sub dtgListado_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles dtgListado.ClickCell
        SeleccionarFila(e.Cell.Row.Index)
    End Sub
    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        SeleccionarFilaYGuardar(e.Cell.Row.Index)
    End Sub
    Private clicCount As Integer = 0 ' Variable para controlar los clics
    Private Sub SeleccionarFila(rowIndex As Integer)
        If rowIndex < 0 Then
            Exit Sub
        End If
        clicCount += 1
        If clicCount = 2 Then
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                        row.Appearance.BackColor = Color.White
                    Next
                    Dim selectedRow As DataRow = CType(dtgListado.DataSource, DataTable).Rows(rowIndex)
                    dtgListado.Rows(rowIndex).Appearance.BackColor = Color.Yellow
                    SelectedRows.Clear()
                    SelectedRows.Add(selectedRow)
                Else
                    msj_advert("SELECCIONE REGISTRO")
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE REGISTRO"))
            End If
            clicCount = 0
        End If
    End Sub


    Private Sub SeleccionarFilaYGuardar(rowIndex As Integer)
        ' Verifica que el índice de la fila sea válido
        If rowIndex < 0 Or rowIndex >= dtgListado.Rows.Count Then
            msj_advert("SELECCIONE REGISTRO")
            Exit Sub
        End If
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            row.Appearance.BackColor = Color.White
        Next
        Dim selectedRow As DataRow = CType(dtgListado.DataSource, DataTable).Rows(rowIndex)
        dtgListado.Rows(rowIndex).Appearance.BackColor = Color.Yellow
        SelectedRows.Clear()
        SelectedRows.Add(selectedRow)
        If _callback IsNot Nothing Then
            _callback(selectedRow)
            dtgListado.Rows(rowIndex).Appearance.BackColor = Color.Green
            Me.Close()
        Else
            MessageBox.Show("Debe seleccionar un trabajador antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If _callback IsNot Nothing AndAlso SelectedRows.Count > 0 Then
            Dim rowIndex As Integer = dtgListado.Rows.IndexOf(dtgListado.Rows.First(Function(r) r.Appearance.BackColor = Color.Yellow))
            If rowIndex >= 0 Then
                dtgListado.Rows(rowIndex).Appearance.BackColor = Color.Green
            End If
            _callback(SelectedRows(0))
            Me.Close()
        Else
            MessageBox.Show("Debe seleccionar un trabajador antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout

    End Sub
End Class
