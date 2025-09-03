Imports CapaNegocio
Imports Infragistics.Win

Public Class FrmlistarTrabajadorespermisos
    Dim cn As New cnTrabajador
    Private SelectedRows As New List(Of DataRow)
    Private _callback As Action(Of DataRow)
    Public operacion As Integer
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
        dtgListado.DataSource = cn.Cn_ListarTrabajadoresActivospermiso()
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
        Try
            If operacion = 2 Then
            Else
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
            End If
        Catch ex As Exception
            MessageBox.Show("Error al seleccionar trabajador: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        With e.Layout.Bands(0)
            If Not .Columns.Exists("Ver Historial") Then
                .Columns.Add("Ver Historial", "Ver Historial")
            End If
            .Columns("Ver Historial").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
            .Columns("Ver Historial").ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
            .Columns("Ver Historial").Header.Caption = "Ver Historial"
        End With
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "Ver Historial" Then
            Dim idPersona As Integer = Convert.ToInt32(e.Cell.Row.Cells(0).Value)
            Dim frm As New FrmListarHistorialVacaciones(idPersona)
            frm.ShowDialog()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            Dim activeRow As UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then

                        Dim frm As New FrmEditarDiasVacaciones With {
                            .idPersona = CInt(activeRow.Cells(0).Value)
                        }
                        frm.ShowDialog()
                        ListarTrabajadoresActivos()
                    Else
                        msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class