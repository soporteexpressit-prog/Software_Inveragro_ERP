Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarParticipante
    Dim cn As New cnTrabajador
    Private ReadOnly _frmRegCapacitacion As FrmRegistrarCapacitacion
    Private SelectedRows As New List(Of DataRow)
    Public idPlantel As Integer

    Public Sub New(formularioRegCapacitacion As FrmRegistrarCapacitacion)
        InitializeComponent()
        _frmRegCapacitacion = formularioRegCapacitacion
    End Sub
    Private Sub FrmListarParticipante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Dim obj As New coTrabajador With {
            .IdUbicacion = idPlantel
        }
        dtgListado.DataSource = cn.Cn_ListarTrabajadoresActivosxPlantel(obj)
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True

        For Each row As DataRow In CType(dtgListado.DataSource, DataTable).Rows
            Dim codParticipante As Integer = CInt(row(0))
            If _frmRegCapacitacion.SelectedParticipants.Contains(codParticipante) Then
                Dim gridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.Rows.Where(Function(r) r.Cells(0).Value = codParticipante).FirstOrDefault()
                If gridRow IsNot Nothing Then
                    gridRow.Appearance.BackColor = Color.LightBlue
                End If
            End If
        Next
    End Sub
    Sub ListarTrabajadoresActivos()
        Dim dt As DataTable = cn.Cn_ListarTrabajadoresActivos()
        dtgListado.DataSource = dt
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.Rows.Count > 0 AndAlso dtgListado.ActiveRow IsNot Nothing AndAlso dtgListado.ActiveRow.Index >= 0 Then
            Dim dt As DataTable = TryCast(dtgListado.DataSource, DataTable)

            If dt IsNot Nothing AndAlso dt.Rows.Count > dtgListado.ActiveRow.Index Then
                Dim selectedRow As DataRow = dt.Rows(dtgListado.ActiveRow.Index)
                Dim codParticipante As Integer = CInt(selectedRow(0))

                dtgListado.ActiveRow.Appearance.BackColor = Color.LightBlue

                If Not _frmRegCapacitacion.SelectedParticipants.Contains(codParticipante) Then
                    _frmRegCapacitacion.SelectedParticipants.Add(codParticipante)
                    SelectedRows.Add(selectedRow)
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        For Each row As DataRow In SelectedRows
            Dim dr As DataRow = _frmRegCapacitacion.DtDetalle.NewRow()

            dr("codParticipante") = row(0)
            dr("nroDocumento") = row(1)
            dr("datos") = row(2)
            dr("btneliminar") = ""

            _frmRegCapacitacion.DtDetalle.Rows.Add(dr)
        Next

        _frmRegCapacitacion.DtDetalle.AcceptChanges()
        Me.Close()
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If _frmRegCapacitacion.DtDetalle.Rows.Count = 0 Then
            _frmRegCapacitacion.SelectedParticipants.Clear()
        End If
        Dispose()
    End Sub
End Class