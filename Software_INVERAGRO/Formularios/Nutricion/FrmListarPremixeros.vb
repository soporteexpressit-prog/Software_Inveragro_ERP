Imports CapaNegocio

Public Class FrmListarPremixeros
    Dim cn As New cnControlPremixero
    Private ReadOnly _frmAsignarInsumoPremixero As FrmAsignarInsumoPremixero

    Public Sub New(frmAsignarInsumoPremixero As FrmAsignarInsumoPremixero)
        InitializeComponent()
        _frmAsignarInsumoPremixero = frmAsignarInsumoPremixero
    End Sub
    Private Sub FrmListarPremixeros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarPremixerosActivos()
    End Sub
    Sub ListarPremixerosActivos()
        dtgListado.DataSource = cn.Cn_ListarTrabajadorPremixeroActivo()
    End Sub
    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                Dim activeRow = dtgListado.ActiveRow
                If activeRow IsNot Nothing AndAlso activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(0).Value.ToString().Length <> 0 Then
                    If activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(1).Value IsNot Nothing AndAlso
                       activeRow.Cells(2).Value IsNot Nothing AndAlso activeRow.Cells(3).Value IsNot Nothing Then

                        _frmAsignarInsumoPremixero.LlenarCamposPremixero(
                            activeRow.Cells(0).Value.ToString(),
                            activeRow.Cells(1).Value.ToString(),
                            activeRow.Cells(2).Value.ToString(),
                            activeRow.Cells(3).Value.ToString()
                        )
                        Me.Close()
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class