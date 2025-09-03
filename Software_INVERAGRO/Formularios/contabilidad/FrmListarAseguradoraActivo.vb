Imports CapaNegocio

Public Class FrmListarAseguradoraActivo
    Dim cn As New cnProveedor
    Private ReadOnly _frmRegistrarSeguroActivo As FrmRegistrarSeguroActivo

    Public Sub New(frmRegistrarSeguroActivo As FrmRegistrarSeguroActivo)
        InitializeComponent()
        _frmRegistrarSeguroActivo = frmRegistrarSeguroActivo
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
    Private Sub FrmListarAseguradoraActivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        ListarAseguradorasActivas()
    End Sub
    Sub ListarAseguradorasActivas()
        dtgListado.DataSource = cn.Cn_ListarAseguradora()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub
    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _frmRegistrarSeguroActivo.LlenarCamposAseguradora(
                     e.Cell.Row.Cells(0).Value.ToString(),
                    e.Cell.Row.Cells(1).Value.ToString(),
                     e.Cell.Row.Cells(2).Value.ToString()
                    )
                Dispose()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub
End Class