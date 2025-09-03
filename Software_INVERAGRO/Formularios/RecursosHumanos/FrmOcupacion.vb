Imports CapaNegocio

Public Class FrmOcupacion
    Private ReadOnly _frmTrabajador As FrmTrabajador
    Dim cn As New cnTrabajador

    Public Sub New(frmTrabajador As FrmTrabajador)
        InitializeComponent()
        _frmTrabajador = frmTrabajador
    End Sub

    Private Sub FrmListarDistritos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarOcupacion()
    End Sub

    Sub ListarOcupacion()
        Dim dt As DataTable = cn.Cn_ListarOcupacion()
        dtgListado.DataSource = dt
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                Dim activeRow = dtgListado.ActiveRow
                If activeRow IsNot Nothing AndAlso activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(0).Value.ToString().Length <> 0 Then
                    If activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(1).Value IsNot Nothing AndAlso
                   activeRow.Cells(2).Value IsNot Nothing Then

                        _frmTrabajador.LlenarCamposOcupacion(
                        activeRow.Cells(0).Value.ToString(),
                        activeRow.Cells(2).Value.ToString())
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
    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class