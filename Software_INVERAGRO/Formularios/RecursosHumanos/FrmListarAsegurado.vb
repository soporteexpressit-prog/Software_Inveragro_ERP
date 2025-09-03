Imports CapaNegocio

Public Class FrmListarAsegurado
    Dim cn As New cnTrabajador
    Private ReadOnly _frmRegSctr As FrmRegistrarSCTR
    Private SelectedRows As New List(Of DataRow)

    Public Sub New(frmRegSctr As FrmRegistrarSCTR)
        InitializeComponent()
        _frmRegSctr = frmRegSctr
    End Sub
    Private Sub FrmListarAsegurado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ListarTrabajadoresActivos()

            For Each row As DataRow In CType(dtgListado.DataSource, DataTable).Rows
                Dim codParticipante As Integer = CInt(row(0))
                If _frmRegSctr.SelectedParticipants.Contains(codParticipante) Then
                    Dim gridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.Rows.Where(Function(r) r.Cells(0).Value = codParticipante).FirstOrDefault()
                    If gridRow IsNot Nothing Then
                        gridRow.Appearance.BackColor = Color.LightBlue
                    End If
                End If
            Next
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub ListarTrabajadoresActivos()
        Dim dt As DataTable = cn.Cn_ListarTrabajadoresActivos()
        dtgListado.DataSource = cn.Cn_ListarTrabajadoresActivos()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If _frmRegSctr.DtDetalle.Rows.Count = 0 Then
            _frmRegSctr.SelectedParticipants.Clear()
        End If
        Dispose()
    End Sub
    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim codParticipante As Integer = CInt(dtgListado.ActiveRow.Cells(0).Value)

                    dtgListado.ActiveRow.Appearance.BackColor = Color.LightBlue

                    If Not _frmRegSctr.SelectedParticipants.Contains(codParticipante) Then
                        _frmRegSctr.SelectedParticipants.Add(codParticipante)
                        SelectedRows.Add(CType(dtgListado.DataSource, DataTable).Rows(dtgListado.ActiveRow.Index))
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
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        For Each row As DataRow In SelectedRows
            Dim dr As DataRow = _frmRegSctr.DtDetalle.NewRow()

            dr("codParticipante") = row(0)
            dr("nroDocumento") = row(1)
            dr("datos") = row(2)
            dr("btneliminar") = ""

            _frmRegSctr.DtDetalle.Rows.Add(dr)
        Next

        _frmRegSctr.DtDetalle.AcceptChanges()
        Me.Close()
    End Sub
End Class