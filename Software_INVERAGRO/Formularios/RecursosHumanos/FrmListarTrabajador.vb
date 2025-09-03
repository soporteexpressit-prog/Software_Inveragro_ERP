Imports CapaNegocio

Public Class FrmListarTrabajador
    Dim cn As New cnTrabajador
    Private ReadOnly _frmRegMemorandum As FrmRegMemoDespido
    Private SelectedRows As New List(Of DataRow)

    Public Sub New(formularioRegMemo As FrmRegMemoDespido)
        InitializeComponent()
        _frmRegMemorandum = formularioRegMemo
    End Sub

    Private Sub FrmListarTrabajador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarTrabajadoresActivos()

        For Each row As DataRow In CType(dtgListado.DataSource, DataTable).Rows
            Dim codParticipante As Integer = CInt(row(0))
            If _frmRegMemorandum.SelectedTrabajadores.Contains(codParticipante) Then
                Dim gridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.Rows.Where(Function(r) r.Cells(0).Value = codParticipante).FirstOrDefault()
                If gridRow IsNot Nothing Then
                    gridRow.Appearance.BackColor = Color.LightBlue
                End If
            End If
        Next
    End Sub

    Sub ListarTrabajadoresActivos()
        dtgListado.DataSource = cn.Cn_ListarTrabajadoresActivos()
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.Rows.Count = 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If
        If e.Cell Is Nothing OrElse e.Cell.Row Is Nothing Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If

        If e.Cell.Row.Index < 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If

        Try
            Dim selectedRow As DataRow = CType(dtgListado.DataSource, DataTable).Rows(e.Cell.Row.Index)

            ' Validamos que la celda tenga un valor válido
            If selectedRow IsNot Nothing AndAlso Not IsDBNull(selectedRow(0)) Then
                Dim codParticipante As Integer = CInt(selectedRow(0))
                dtgListado.Rows(e.Cell.Row.Index).Appearance.BackColor = Color.LightBlue

                If Not _frmRegMemorandum.SelectedTrabajadores.Contains(codParticipante) Then
                    _frmRegMemorandum.SelectedTrabajadores.Add(codParticipante)
                    SelectedRows.Add(selectedRow)
                End If
            Else
                msj_advert("Por favor selecciona un trabajador válido.")
            End If
        Catch ex As Exception
            msj_advert("Ocurrió un error al seleccionar el trabajador. Por favor intenta nuevamente.")
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        For Each row As DataRow In SelectedRows
            Dim dr As DataRow = _frmRegMemorandum.DtDetalle.NewRow()

            dr("codParticipante") = row(0)
            dr("nroDocumento") = row(1)
            dr("datos") = row(2)
            dr("btneliminar") = ""

            _frmRegMemorandum.DtDetalle.Rows.Add(dr)
        Next

        _frmRegMemorandum.DtDetalle.AcceptChanges()
        Me.Close()
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If _frmRegMemorandum.DtDetalle.Rows.Count = 0 Then
            _frmRegMemorandum.SelectedTrabajadores.Clear()
        End If
        Dispose()
    End Sub
End Class