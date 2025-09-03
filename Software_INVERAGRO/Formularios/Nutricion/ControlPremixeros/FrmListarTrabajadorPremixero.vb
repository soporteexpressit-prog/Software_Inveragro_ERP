Imports CapaNegocio

Public Class FrmListarTrabajadorPremixero
    Dim cn As New cnTrabajador
    Private ReadOnly _frmMantAsignarPremixero As FrmMantAsignarPremixero

    Public Sub New(frmControlPremixero As FrmMantAsignarPremixero)
        InitializeComponent()
        _frmMantAsignarPremixero = frmControlPremixero
    End Sub
    Private Sub FrmListarTrabajadorPremixero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarTrabajadoresActivos()
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
    End Sub
    Sub ListarTrabajadoresActivos()
        dtgListado.DataSource = cn.Cn_ListarTrabajadoresActivos()
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.Rows.Count > 0 Then
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow

            If activeRow IsNot Nothing AndAlso activeRow.Cells.Count > 0 AndAlso activeRow.Cells(0).Value IsNot Nothing Then
                If activeRow.Cells(0).Value.ToString().Trim().Length > 0 Then
                    _frmMantAsignarPremixero.LlenarCamposPremixero(
                    activeRow.Cells(0).Value.ToString(),
                    If(activeRow.Cells.Count > 1 AndAlso activeRow.Cells(1).Value IsNot Nothing, activeRow.Cells(1).Value.ToString(), ""),
                    If(activeRow.Cells.Count > 2 AndAlso activeRow.Cells(2).Value IsNot Nothing, activeRow.Cells(2).Value.ToString(), "")
                )
                    Me.Close()
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class