Imports CapaNegocio

Public Class FrmListarCapacitador
    Dim cn As New cnTrabajador
    Private ReadOnly _frmRegCapacitacion As FrmRegistrarCapacitacion

    Public Sub New(formularioRegCapacitacion As FrmRegistrarCapacitacion)
        InitializeComponent()
        _frmRegCapacitacion = formularioRegCapacitacion
    End Sub

    Private Sub FrmListarCapacitador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarTrabajadoresActivos()
    End Sub
    Sub ListarTrabajadoresActivos()
        dtgListado.DataSource = cn.Cn_ListarTrabajadoresActivos()
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
    End Sub
    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                Dim activeRow = dtgListado.ActiveRow
                If activeRow IsNot Nothing AndAlso activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(0).Value.ToString().Length <> 0 Then
                    If activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(1).Value IsNot Nothing AndAlso
                   activeRow.Cells(2).Value IsNot Nothing Then

                        _frmRegCapacitacion.LlenarCamposCapacitador(
                        activeRow.Cells(0).Value.ToString(),
                        activeRow.Cells(1).Value.ToString(),
                        activeRow.Cells(2).Value.ToString()
                    )
                        Me.Dispose()
                    Else
                        msj_advert("Algunas celdas no tienen valores válidos.")
                    End If
                Else
                    msj_advert("Seleccione un Registro válido.")
                End If
            Else
                msj_advert("Seleccione un Registro.")
            End If
        Catch ex As Exception
            clsBasicas.controlException("", ex)
        End Try
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class