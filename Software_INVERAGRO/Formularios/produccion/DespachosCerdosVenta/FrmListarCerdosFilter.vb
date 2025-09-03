Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmListarCerdosFilter
    Dim cn As New cnControlAnimal
    Private ReadOnly _frmAtenderPedidoCerdasCodificadas As FrmAtenderPedidoCerdasCodificadas
    Private SelectedIds As New List(Of Integer)
    Public idPlantel As Integer = 0
    Public idMotivoTransaccion As String = ""
    Public listaIDsAOcultar As New List(Of Integer)

    Public Sub New(frmAtenderPedidoCerdasCodificadas As FrmAtenderPedidoCerdasCodificadas)
        InitializeComponent()
        _frmAtenderPedidoCerdasCodificadas = frmAtenderPedidoCerdasCodificadas
    End Sub

    Private Sub FrmListarCerdosFilter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Dim obj As New coControlAnimal With {
                .IdPlantel = idPlantel,
                .IdMotivoTransaccion = idMotivoTransaccion
            }
            dtgListado.DataSource = cn.Cn_ConsultarCerdosVentaIncidencia(obj)
            dtgListado.DisplayLayout.Bands(0).Columns("idAnimal").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("idJaulaCorral").Hidden = True

            OcultarFilasPorListaIDs()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub OcultarFilasPorListaIDs()
        If listaIDsAOcultar IsNot Nothing AndAlso listaIDsAOcultar.Count > 0 Then
            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                If listaIDsAOcultar.Contains(CInt(row.Cells("idAnimal").Value)) Then
                    row.Hidden = True
                End If
            Next
        End If
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If dtgListado.Rows.Count > 0 AndAlso dtgListado.ActiveRow IsNot Nothing Then
                Dim celda = dtgListado.ActiveRow.Cells(0)
                If celda IsNot Nothing AndAlso celda.Value IsNot Nothing AndAlso celda.Value.ToString().Length > 0 Then
                    Dim idCorral As Integer = Convert.ToInt32(e.Cell.Row.Cells("idJaulaCorral").Value)
                    Dim idAnimal As Integer = Convert.ToInt32(e.Cell.Row.Cells("idAnimal").Value)
                    Dim codArete As String = e.Cell.Row.Cells("Arete").Value?.ToString()
                    Dim tipo As String = e.Cell.Row.Cells("Tipo").Value?.ToString()
                    Dim ubicacion As String = $"{e.Cell.Row.Cells("Galpón").Value} - {e.Cell.Row.Cells("Corral").Value}"

                    _frmAtenderPedidoCerdasCodificadas.LlenarCamposCerdoVenta(idCorral, idAnimal, codArete, tipo, ubicacion)
                    Dispose()
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
End Class