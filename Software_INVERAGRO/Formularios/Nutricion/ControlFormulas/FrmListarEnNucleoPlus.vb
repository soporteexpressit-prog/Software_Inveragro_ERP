Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarEnNucleoPlus
    Dim cn As New cnControlFormulacion
    Private ReadOnly _frmAsignarFormula As FrmAsignarFormula
    Private SelectedRows As New List(Of DataRow)
    Public listaIdsInsumos As New List(Of Integer)
    Public idNucleo As Integer = 0
    Public idFormulaBase As Integer = 0

    Public Sub New(frmAsignarFormula As FrmAsignarFormula)
        InitializeComponent()
        _frmAsignarFormula = frmAsignarFormula
    End Sub

    Private Sub FrmListarEnNucleoPlus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarInsumos()
    End Sub

    Sub ListarInsumos()
        Try
            Dim obj As New coControlFormulacion With {
                .Codigo = idFormulaBase,
                .IdNucleo = idNucleo
            }

            Dim dt As DataTable = cn.Cn_ObtenerInsumosActivoNoPerteneceFormula(obj)
            dtgListado.DataSource = dt
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True

            PintarFilasConIdsInsumos()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub PintarFilasConIdsInsumos()
        For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            Dim codProducto As Integer = CInt(fila.Cells(0).Value)

            If listaIdsInsumos.Contains(codProducto) Then
                fila.Appearance.BackColor = Color.LightGray
            End If
        Next
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If dtgListado.DataSource IsNot Nothing AndAlso TypeOf dtgListado.DataSource Is DataTable Then
                Dim dt As DataTable = CType(dtgListado.DataSource, DataTable)

                If dtgListado.Rows.Count > 0 AndAlso dtgListado.ActiveRow IsNot Nothing AndAlso dtgListado.ActiveRow.Cells.Count > 0 Then
                    If dtgListado.ActiveRow.Cells(0).Value IsNot Nothing AndAlso dtgListado.ActiveRow.Cells(0).Value.ToString().Trim().Length > 0 Then

                        If dtgListado.ActiveRow.Index >= 0 AndAlso dtgListado.ActiveRow.Index < dt.Rows.Count Then
                            Dim selectedRow As DataRow = dt.Rows(dtgListado.ActiveRow.Index)
                            Dim codParticipante As Integer

                            If Integer.TryParse(selectedRow(0).ToString(), codParticipante) Then

                                If dtgListado.Rows(dtgListado.ActiveRow.Index).Appearance.BackColor = Color.LightGray Then
                                    msj_advert("El insumo seleccionado ya ha sido asignado.")
                                    Return
                                End If

                                If _frmAsignarFormula.SelectedInsumos.Contains(codParticipante) Then
                                    _frmAsignarFormula.SelectedInsumos.Remove(codParticipante)
                                    dtgListado.Rows(dtgListado.ActiveRow.Index).Appearance.BackColor = Color.White
                                    SelectedRows.Remove(selectedRow)
                                Else
                                    _frmAsignarFormula.SelectedInsumos.Add(codParticipante)
                                    dtgListado.Rows(dtgListado.ActiveRow.Index).Appearance.BackColor = Color.LightBlue
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
            Dim dr As DataRow = _frmAsignarFormula.DtDetalleNucleo.NewRow()

            dr("etiqueta") = "-"
            dr("codprod") = row(0)
            dr("producto") = row(1)
            dr("cantidad") = 0
            dr("btneliminar") = ""

            _frmAsignarFormula.DtDetalleNucleo.Rows.Add(dr)
        Next

        _frmAsignarFormula.DtDetalleNucleo.AcceptChanges()
        CType(Me.Owner, FrmAsignarFormula).PintarPrimeraColumnaNucleo()
        Me.Close()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If _frmAsignarFormula.DtDetalleNucleo.Rows.Count = 0 Then
            _frmAsignarFormula.SelectedInsumos.Clear()
        End If
        Me.Close()
    End Sub
End Class