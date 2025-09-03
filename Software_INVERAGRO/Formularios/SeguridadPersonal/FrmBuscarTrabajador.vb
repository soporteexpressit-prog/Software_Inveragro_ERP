Imports CapaNegocio

Public Class FrmBuscarTrabajador
    Dim cn As New cnTrabajador
    Private ReadOnly _formularioMantenimientoEpp As FrmMantenimientoEpp

    Public Sub New(formularioMantEpp As FrmMantenimientoEpp)
        InitializeComponent()
        _formularioMantenimientoEpp = formularioMantEpp
    End Sub

    Private Sub FrmBuscarTrabajador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarTrabajadoresActivos()
    End Sub
    Sub ListarTrabajadoresActivos()
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            dtgListado.DataSource = cn.Cn_ListarTrabajadoresActivos()
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.Rows.Count = 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If
        If e.Cell Is Nothing OrElse e.Cell.Row Is Nothing Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If

        If e.Cell.Row.Index < 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    _formularioMantenimientoEpp.LlenarCamposSolicitante(
                     e.Cell.Row.Cells(0).Value.ToString(),
                    e.Cell.Row.Cells(1).Value.ToString(),
                     e.Cell.Row.Cells(2).Value.ToString()
                    )
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