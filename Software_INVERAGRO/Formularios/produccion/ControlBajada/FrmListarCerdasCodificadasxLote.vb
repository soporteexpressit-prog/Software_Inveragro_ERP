Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmListarCerdasCodificadasxLote
    Dim cn As New cnControlLoteDestete
    Private ReadOnly _frmPrimerFiltroCerda As FrmPrimerFiltroCerda
    Private SelectedRows As New List(Of DataRow)
    Public idLote As Integer = 0
    Public idPlantel As Integer = 0
    Public numDepuracion As Integer = 0

    Public Sub New(frmPrimerFiltroCerda As FrmPrimerFiltroCerda)
        InitializeComponent()
        _frmPrimerFiltroCerda = frmPrimerFiltroCerda
    End Sub

    Private Sub FrmListarCerdasCodificadasxLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ListarAnimalesxLote()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarAnimalesxLote()
        Dim obj As New coControlLoteDestete With {
            .IdLote = idLote,
            .IdPlantel = idPlantel,
            .NumDepuracion = numDepuracion
        }
        dtgListado.DataSource = cn.Cn_ConsultarAnimalesRegistradosxLote(obj)
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.Rows.Count > 0 AndAlso dtgListado.ActiveRow IsNot Nothing AndAlso dtgListado.ActiveRow.Index >= 0 Then
            Dim dt As DataTable = TryCast(dtgListado.DataSource, DataTable)

            If dt IsNot Nothing AndAlso dt.Rows.Count > dtgListado.ActiveRow.Index Then
                Dim selectedRow As DataRow = dt.Rows(dtgListado.ActiveRow.Index)
                Dim idAnimal As Integer = CInt(selectedRow(0))

                dtgListado.ActiveRow.Appearance.BackColor = Color.LightBlue

                If Not _frmPrimerFiltroCerda.SelectedPuras.Contains(idAnimal) Then
                    _frmPrimerFiltroCerda.SelectedPuras.Add(idAnimal)
                    SelectedRows.Add(selectedRow)
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        For Each row As DataRow In SelectedRows
            Dim dr As DataRow = _frmPrimerFiltroCerda.DtDetallePura.NewRow()

            dr("idCerda") = row(0)
            dr("codArete") = row(1)

            _frmPrimerFiltroCerda.DtDetallePura.Rows.Add(dr)
        Next

        _frmPrimerFiltroCerda.DtDetallePura.AcceptChanges()
        Me.Close()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class