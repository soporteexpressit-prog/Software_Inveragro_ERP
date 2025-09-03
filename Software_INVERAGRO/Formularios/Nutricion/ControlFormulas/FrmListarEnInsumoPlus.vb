Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarEnInsumoPlus
    Dim cn As New cnControlFormulacion
    Private ReadOnly _frmAsignarInsumoPremixero As FrmAsignarInsumoPremixero
    Private SelectedRows As New List(Of DataRow)
    Public idNucleo As Integer = 0
    Public idFormulaBase As Integer = 0

    Public Sub New(frmAsignarInsumoPremixero As FrmAsignarInsumoPremixero)
        InitializeComponent()
        _frmAsignarInsumoPremixero = frmAsignarInsumoPremixero
    End Sub

    Private Sub FrmListarProductoPlus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarInsumos()
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True

            For Each row As DataRow In CType(dtgListado.DataSource, DataTable).Rows
                Dim codParticipante As Integer = CInt(row(0))
                If _frmAsignarInsumoPremixero.SelectedInsumos.Contains(codParticipante) Then
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

    Sub ListarInsumos()
        Dim obj As New coControlFormulacion With {
            .Codigo = idFormulaBase,
            .IdNucleo = idNucleo
        }

        Dim dt As DataTable = cn.Cn_ObtenerInsumosActivoNoPerteneceFormula(obj)
        dtgListado.DataSource = dt
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub


    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.DataSource IsNot Nothing AndAlso TypeOf dtgListado.DataSource Is DataTable Then
            Dim dt As DataTable = CType(dtgListado.DataSource, DataTable)

            If e.Cell.Row.Index >= 0 AndAlso e.Cell.Row.Index < dt.Rows.Count Then
                Dim selectedRow As DataRow = dt.Rows(e.Cell.Row.Index)
                Dim codParticipante As Integer

                If Integer.TryParse(selectedRow(0).ToString(), codParticipante) Then
                    If dtgListado.Rows(e.Cell.Row.Index).Appearance.BackColor = Color.LightGray Then
                        msj_advert("El insumo seleccionado ya ha sido asignado.")
                        Return
                    End If

                    If _frmAsignarInsumoPremixero.SelectedInsumos.Contains(codParticipante) Then
                        _frmAsignarInsumoPremixero.SelectedInsumos.Remove(codParticipante)
                        dtgListado.Rows(e.Cell.Row.Index).Appearance.BackColor = Color.White
                        SelectedRows.Remove(selectedRow)
                    Else
                        _frmAsignarInsumoPremixero.SelectedInsumos.Add(codParticipante)
                        dtgListado.Rows(e.Cell.Row.Index).Appearance.BackColor = Color.LightBlue
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

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        For Each row As DataRow In SelectedRows
            Dim dr As DataRow = _frmAsignarInsumoPremixero.DtDetalle.NewRow()

            dr("codprod") = row(0)
            dr("producto") = row(1)
            dr("cantidad") = 0
            dr("btneliminar") = ""

            _frmAsignarInsumoPremixero.DtDetalle.Rows.Add(dr)
        Next

        _frmAsignarInsumoPremixero.DtDetalle.AcceptChanges()
        Me.Close()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If _frmAsignarInsumoPremixero.DtDetalle.Rows.Count = 0 Then
            _frmAsignarInsumoPremixero.SelectedInsumos.Clear()
        End If
        Me.Close()
    End Sub
End Class