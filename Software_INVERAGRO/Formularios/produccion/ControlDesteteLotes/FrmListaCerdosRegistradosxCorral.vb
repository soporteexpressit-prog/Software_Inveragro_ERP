Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListaCerdosRegistradosxCorral
    Dim cn As New cnControlLoteDestete
    Private ReadOnly _frmAjustarDistribucionCerdo As FrmAjustarDistribucionCerdo
    Public idLote As Integer = 0
    Private SelectedRows As New List(Of DataRow)

    Public Sub New(frmAjustarDistribucionCerdo As FrmAjustarDistribucionCerdo)
        InitializeComponent()
        _frmAjustarDistribucionCerdo = frmAjustarDistribucionCerdo
    End Sub

    Private Sub FrmListaCerdosRegistradosxCorral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ListarAnimalesSinAjustar()

            OcultarFilasPorListaIDs()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub OcultarFilasPorListaIDs()
        Try
            ' Asegúrate de que la lista no sea nula
            If _frmAjustarDistribucionCerdo.SelectedAnimales Is Nothing Then
                Exit Sub
            End If

            ' Recorremos cada fila visible del grid
            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                If row.Cells.Exists("idAnimal") Then
                    Dim idActual As Integer = CInt(row.Cells("idAnimal").Value)
                    row.Hidden = _frmAjustarDistribucionCerdo.SelectedAnimales.Contains(idActual)
                End If
            Next
        Catch ex As Exception
            MsgBox("Error ocultando filas: " & ex.Message)
        End Try
    End Sub


    Sub ListarAnimalesSinAjustar()
        Dim obj As New coControlLoteDestete With {
            .IdLote = idLote
        }
        dtgListado.DataSource = cn.Cn_ConsultarAnimalesRegistradosxLoteSinAjustar(obj)
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.Rows.Count > 0 AndAlso dtgListado.ActiveRow IsNot Nothing AndAlso dtgListado.ActiveRow.Index >= 0 Then
            Dim dt As DataTable = TryCast(dtgListado.DataSource, DataTable)

            If dt IsNot Nothing AndAlso dt.Rows.Count > dtgListado.ActiveRow.Index Then
                Dim selectedRow As DataRow = dt.Rows(dtgListado.ActiveRow.Index)
                Dim idAnimal As Integer = CInt(selectedRow(0))

                dtgListado.ActiveRow.Appearance.BackColor = Color.LightBlue

                If Not _frmAjustarDistribucionCerdo.SelectedAnimales.Contains(idAnimal) Then
                    _frmAjustarDistribucionCerdo.SelectedAnimales.Add(idAnimal)
                    SelectedRows.Add(selectedRow)
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
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

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        For Each row As DataRow In SelectedRows
            Dim dr As DataRow = _frmAjustarDistribucionCerdo.DtDetalle.NewRow()
            dr("idAnimal") = row(0)
            dr("Tatuaje") = row(1)
            dr("Edad") = row(2)
            dr("Sexo") = row(3)
            dr("Eliminar") = "Eliminar"
            _frmAjustarDistribucionCerdo.DtDetalle.Rows.Add(dr)
        Next

        _frmAjustarDistribucionCerdo.DtDetalle.AcceptChanges()
        Me.Close()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class