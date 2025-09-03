Imports CapaNegocio

Public Class FrmListarAseguradora
    Dim cn As New cnProveedor
    Private ReadOnly _frmRegistrarSctr As FrmRegistrarSCTR

    Public Sub New(frmRegistrarSctr As FrmRegistrarSCTR)
        InitializeComponent()
        _frmRegistrarSctr = frmRegistrarSctr
    End Sub
    Private Sub FrmListarAseguradora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        ListarAseguradorasActivas()
    End Sub
    Sub ListarAseguradorasActivas()
        dtgListado.DataSource = cn.Cn_ListarAseguradora()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub
    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If dtgListado.Rows.Count > 0 Then
                Dim activeRow = dtgListado.ActiveRow
                If activeRow IsNot Nothing AndAlso Not String.IsNullOrEmpty(activeRow.Cells(0).Value?.ToString()) Then
                    If activeRow.Cells(1).Value IsNot Nothing AndAlso activeRow.Cells(2).Value IsNot Nothing Then
                        _frmRegistrarSctr.LlenarCamposAseguradora(
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