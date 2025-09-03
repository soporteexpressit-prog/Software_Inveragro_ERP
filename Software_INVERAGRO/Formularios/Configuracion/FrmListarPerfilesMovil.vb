Imports CapaNegocio

Public Class FrmListarPerfilesMovil
    Private ReadOnly _frmAsignarPerfilMovil As FrmAsignarPerfilMovil
    Private ReadOnly _frmActualizarPerfilMovil As FrmActualizarPerfilMovil
    Dim cn As New cnPerfil

    Public Sub New(formularioAsignarPerfilMovil As FrmAsignarPerfilMovil)
        InitializeComponent()
        _frmAsignarPerfilMovil = formularioAsignarPerfilMovil
    End Sub

    Public Sub New(formularioActualizarPerfilMovil As FrmActualizarPerfilMovil)
        InitializeComponent()
        _frmActualizarPerfilMovil = formularioActualizarPerfilMovil
    End Sub

    Private Sub FrmListarPerfilesDispositivoMovil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarPerfiles()
    End Sub
    Sub ListarPerfiles()
        dtgListado.DataSource = cn.Cn_ListarPerfilesDispositivoMovil()
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                Dim activeRow = dtgListado.ActiveRow
                If activeRow IsNot Nothing AndAlso activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(0).Value.ToString().Length <> 0 Then
                    If activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(1).Value IsNot Nothing AndAlso
                   activeRow.Cells(2).Value IsNot Nothing Then

                        If _frmAsignarPerfilMovil IsNot Nothing Then
                            _frmAsignarPerfilMovil.LlenarCamposCapacitador(
                            activeRow.Cells(0).Value.ToString(),
                            activeRow.Cells(0).Value.ToString(),
                            activeRow.Cells(1).Value.ToString()
                        )
                        ElseIf _frmActualizarPerfilMovil IsNot Nothing Then
                            _frmActualizarPerfilMovil.LlenarCamposCapacitador(
                            activeRow.Cells(0).Value.ToString(),
                            activeRow.Cells(0).Value.ToString(),
                            activeRow.Cells(1).Value.ToString()
                        )
                        End If

                        Me.Dispose()
                    Else
                        msj_advert("Algunas celdas no tienen valores válidos.")
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException("", ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

End Class