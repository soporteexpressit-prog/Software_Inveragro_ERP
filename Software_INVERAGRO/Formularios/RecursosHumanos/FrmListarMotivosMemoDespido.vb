Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarMotivosMemoDespido
    Dim cn As New cnMotivoMemoDespido
    Private ReadOnly _frmRegMemorandum As FrmRegMemoDespido
    Public tipo As String

    Public Sub New(formularioRegMemo As FrmRegMemoDespido)
        InitializeComponent()
        _frmRegMemorandum = formularioRegMemo
    End Sub
    Private Sub FrmListarMotivosMemorandum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarMotivosMemorandum()
    End Sub
    Sub ListarMotivosMemorandum()
        Dim obj As New coMotivoMemoDespido
        If (tipo = "MEMORANDUM") Then
            obj.Tipo = "SANCIÓN"
            dtgListado.DataSource = cn.Cn_ConsultarPorTipo(obj)
        Else
            obj.Tipo = "DESPIDO"
            dtgListado.DataSource = cn.Cn_ConsultarPorTipo(obj)
        End If
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                Dim activeRow = dtgListado.ActiveRow
                If activeRow IsNot Nothing AndAlso activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(0).Value.ToString().Length <> 0 Then
                    If activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(1).Value IsNot Nothing AndAlso
                   activeRow.Cells(2).Value IsNot Nothing Then

                        _frmRegMemorandum.LlenarCamposMotivoMemo(
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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim f As New FrmMotivoMemoDespido()
        f.ShowDialog()
        ListarMotivosMemorandum()
    End Sub
End Class