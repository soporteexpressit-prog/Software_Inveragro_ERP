Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmAsignarNucleo
    Dim cn As New cnControlFormulacion
    Private premixeros As DataTable
    Private idPremixeroSeleccionado As Integer
    Private idNucleo As Integer
    Private idFormulaBase As Integer
    Private ReadOnly _frmAsignarFormula As FrmAsignarFormula
    Private SelectedRows As New List(Of DataRow)
    Private listaIdsInsumos As New List(Of Integer)

    Public Sub New(frmAsignarNucleo As FrmAsignarFormula, premixerosUnicos As DataTable, idPremixero As Integer, idNucleo As Integer, idFormulaBase As Integer, listaIdsInsumos As List(Of Integer))
        InitializeComponent()
        Me.premixeros = premixerosUnicos
        Me.idPremixeroSeleccionado = idPremixero
        Me.idNucleo = idNucleo
        Me.idFormulaBase = idFormulaBase
        Me.listaIdsInsumos = listaIdsInsumos
        _frmAsignarFormula = frmAsignarNucleo
    End Sub

    Private Sub FrmRegistrarNucleo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarInsumos()
            txtTipoPremixero.Enabled = False
            cmbPremixero.DropDownStyle = ComboBoxStyle.DropDownList
            ListarPremixeros()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarInsumos()
        Dim obj As New coControlFormulacion
        obj.Codigo = idFormulaBase
        obj.IdNucleo = idNucleo

        Dim dt As DataTable = cn.Cn_ObtenerInsumosxFormulaNucleo(obj)
        dtgListado.DataSource = cn.Cn_ObtenerInsumosxFormulaNucleo(obj)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        PintarFilasConIdsInsumos()
    End Sub

    Private Sub PintarFilasConIdsInsumos()
        For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            Dim codProducto As Integer = CInt(fila.Cells(0).Value)

            If listaIdsInsumos.Contains(codProducto) Then
                fila.Appearance.BackColor = Color.LightGray
            End If
        Next
    End Sub

    Sub ListarPremixeros()
        With cmbPremixero
            .DataSource = premixeros
            .DisplayMember = "premixero"
            .ValueMember = "idpremixero"
            .SelectedIndex = 0
        End With

        If idPremixeroSeleccionado > 0 Then
            cmbPremixero.SelectedValue = idPremixeroSeleccionado
        End If

        If cmbPremixero.SelectedIndex >= 0 Then
            txtTipoPremixero.Text = premixeros.Rows(cmbPremixero.SelectedIndex)("tipo_premixero").ToString()
        End If

        AddHandler cmbPremixero.SelectedIndexChanged, AddressOf cmbPremixero_SelectedIndexChanged
    End Sub

    Private Sub cmbPremixero_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cmbPremixero.SelectedIndex >= 0 Then
            txtTipoPremixero.Text = premixeros.Rows(cmbPremixero.SelectedIndex)("tipo_premixero").ToString()
        End If
    End Sub

    Public Function ObtenerDatosPremixeroSeleccionado() As Tuple(Of Integer, String, String)
        Dim idPremixero As Integer = CInt(cmbPremixero.SelectedValue)
        Dim nombrePremixero As String = cmbPremixero.Text
        Dim tipoPremixero As String = txtTipoPremixero.Text

        Return Tuple.Create(idPremixero, nombrePremixero, tipoPremixero)
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If _frmAsignarFormula.DtDetalleNucleo.Rows.Count = 0 Then
            _frmAsignarFormula.SelectedInsumos.Clear()
        End If
        Me.Close()
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If e.Cell.Row.Index >= 0 Then
            If dtgListado.Rows(e.Cell.Row.Index).Appearance.BackColor = Color.LightGray Then
                msj_advert("El insumo seleccionado ya ha sido asignado.")
                Return
            End If

            Dim selectedRow As DataRow = CType(dtgListado.DataSource, DataTable).Rows(e.Cell.Row.Index)
            Dim codParticipante As Integer = CInt(selectedRow(0))

            dtgListado.Rows(e.Cell.Row.Index).Appearance.BackColor = Color.LightBlue

            If Not _frmAsignarFormula.SelectedInsumos.Contains(codParticipante) Then
                _frmAsignarFormula.SelectedInsumos.Add(codParticipante)
                SelectedRows.Add(selectedRow)
            End If
        Else
            Return
        End If
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        For Each row As DataRow In SelectedRows
            Dim dr As DataRow = _frmAsignarFormula.DtDetalleNucleo.NewRow()

            dr("etiqueta") = "-"
            dr("codprod") = row(0)
            dr("producto") = row(1)
            dr("cantidad") = row(3) / 2
            dr("btneliminar") = ""
            dr("cantUnaTonelada") = row(3)

            _frmAsignarFormula.DtDetalleNucleo.Rows.Add(dr)
        Next

        _frmAsignarFormula.DtDetalleNucleo.AcceptChanges()
        CType(Me.Owner, FrmAsignarFormula).PintarPrimeraColumnaNucleo()
        Me.Close()
    End Sub
End Class