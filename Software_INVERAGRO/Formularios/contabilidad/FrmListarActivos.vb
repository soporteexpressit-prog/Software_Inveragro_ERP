Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarActivos
    Dim cn As New cnActivo
    Private ReadOnly _frmRegistrarSeguroActivo As FrmRegistrarSeguroActivo
    Private SelectedRows As New List(Of DataRow)

    Public Sub New(frmRegistrarSeguroActivo As FrmRegistrarSeguroActivo)
        InitializeComponent()
        _frmRegistrarSeguroActivo = frmRegistrarSeguroActivo
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If _frmRegistrarSeguroActivo.DtDetalle.Rows.Count = 0 Then
            _frmRegistrarSeguroActivo.SelectedActivos.Clear()
        End If
        Dispose()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        For Each row As DataRow In SelectedRows
            Dim dr As DataRow = _frmRegistrarSeguroActivo.DtDetalle.NewRow()

            dr("codActivo") = row(0)
            dr("nroSerie") = row(1)
            dr("descripcion") = row(2)
            dr("btneliminar") = ""

            _frmRegistrarSeguroActivo.DtDetalle.Rows.Add(dr)
        Next

        _frmRegistrarSeguroActivo.DtDetalle.AcceptChanges()
        Me.Close()
    End Sub

    Private Sub FrmListarActivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        Inicializar()

        For Each row As DataRow In CType(dtgListado.DataSource, DataTable).Rows
            Dim codActivo As Integer = CInt(row(0))
            If _frmRegistrarSeguroActivo.SelectedActivos.Contains(codActivo) Then
                Dim gridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.Rows.Where(Function(r) r.Cells(0).Value = codActivo).FirstOrDefault()
                If gridRow IsNot Nothing Then
                    gridRow.Appearance.BackColor = Color.LightBlue
                End If
            End If
        Next
    End Sub
    Sub Inicializar()
        dtpFechaDesde.Value = DateTime.Now
        dtpFechaHasta.Value = DateTime.Now

        Dim obj As New coActivo
        obj.FechaDesde = Nothing
        obj.FechaHasta = Nothing

        Dim dt As DataTable = cn.Cn_ListarActivos(obj)
        dtgListado.DataSource = dt
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Sub ListarActivos()
        Dim obj As New coActivo

        If dtpFechaDesde.Value = DateTimePicker.MinimumDateTime Then
            obj.FechaDesde = Nothing
        Else
            obj.FechaDesde = dtpFechaDesde.Value
        End If

        If dtpFechaHasta.Value = DateTimePicker.MinimumDateTime Then
            obj.FechaHasta = Nothing
        Else
            obj.FechaHasta = dtpFechaHasta.Value
        End If

        Dim dt As DataTable = cn.Cn_ListarActivos(obj)
        dtgListado.DataSource = dt
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        ListarActivos()
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.Rows.Count > 0 Then
            If dtgListado.ActiveRow IsNot Nothing AndAlso dtgListado.ActiveRow.Index >= 0 Then
                If dtgListado.ActiveRow.Cells(0).Value.ToString().Length <> 0 Then
                    Dim selectedRow As DataRow = CType(dtgListado.DataSource, DataTable).Rows(dtgListado.ActiveRow.Index)
                    Dim codParticipante As Integer = CInt(selectedRow(0))

                    dtgListado.Rows(dtgListado.ActiveRow.Index).Appearance.BackColor = Color.LightBlue

                    If Not _frmRegistrarSeguroActivo.SelectedActivos.Contains(codParticipante) Then
                        _frmRegistrarSeguroActivo.SelectedActivos.Add(codParticipante)
                        SelectedRows.Add(selectedRow)
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub
End Class