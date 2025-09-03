Imports CapaNegocio

Public Class FrmListarPerfiles
    Private ReadOnly _frmAsignarPerfil As FrmAsignarPerfil
    Private ReadOnly _frmActualizarPerfil As FrmActualizarPerfil
    Dim cn As New cnPerfil
    Public Sub New(formularioAsignarPerfil As FrmAsignarPerfil)
        InitializeComponent()
        _frmAsignarPerfil = formularioAsignarPerfil
    End Sub

    Public Sub New(formularioActualizarPerfil As FrmActualizarPerfil)
        InitializeComponent()
        _frmActualizarPerfil = formularioActualizarPerfil
    End Sub

    Private Sub FrmListarPerfiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarPerfiles()
    End Sub
    Sub ListarPerfiles()
        dtgListado.DataSource = cn.Cn_ListarPerfiles()
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                Dim activeRow = dtgListado.ActiveRow
                If activeRow IsNot Nothing AndAlso activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(0).Value.ToString().Length <> 0 Then
                    If activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(1).Value IsNot Nothing AndAlso
                   activeRow.Cells(2).Value IsNot Nothing Then

                        If _frmAsignarPerfil IsNot Nothing Then
                            _frmAsignarPerfil.LlenarCamposCapacitador(
                            activeRow.Cells(0).Value.ToString(),
                            activeRow.Cells(0).Value.ToString(),
                            activeRow.Cells(1).Value.ToString()
                        )
                        ElseIf _frmActualizarPerfil IsNot Nothing Then
                            _frmActualizarPerfil.LlenarCamposCapacitador(
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