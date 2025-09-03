Imports CapaNegocio

Public Class FrmListarConductorRetorno
    Dim cn As New cnTrabajador
    Private ReadOnly _frmRetornarChanchillasPuras As FrmRetornarChanchillasPuras

    Public Sub New(frmRetornarChanchillasPuras As FrmRetornarChanchillasPuras)
        InitializeComponent()
        _frmRetornarChanchillasPuras = frmRetornarChanchillasPuras
    End Sub

    Private Sub FrmListarConductorRetorno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarTrabajadoresActivos()
    End Sub

    Sub ListarTrabajadoresActivos()
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            dtgListado.DataSource = cn.Cn_ListarConductores()
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim id As Integer = dtgListado.ActiveRow.Cells(0).Value
                    Dim numDoc As String = dtgListado.ActiveRow.Cells(1).Value
                    Dim datos As String = dtgListado.ActiveRow.Cells(2).Value
                    _frmRetornarChanchillasPuras.LlenarCamposConductor(id, numDoc, datos)
                    Me.Close()
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class