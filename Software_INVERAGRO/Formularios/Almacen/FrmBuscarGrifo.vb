Imports CapaNegocio

Public Class FrmBuscarGrifo
    Dim cn As New cnControlCombustible
    Private ReadOnly _formularioPedidoCombustible As FrmRegistrarPedidoCombustible

    Public Sub New(formularioPedidoCombustible As FrmRegistrarPedidoCombustible)
        InitializeComponent()
        _formularioPedidoCombustible = formularioPedidoCombustible
    End Sub

    Private Sub FrmBuscarGrifo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarProductosCombustible()
    End Sub
    Sub ListarProductosCombustible()
        dtgListado.DataSource = cn.Cn_Consultar().Copy
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim codigo As String = e.Cell.Row.Cells(0).Value.ToString()
                Dim descripcion As String = e.Cell.Row.Cells(1).Value.ToString()
                Dim presentacion As String = e.Cell.Row.Cells(2).Value.ToString()
                _formularioPedidoCombustible.LlenarCamposCombustible(codigo, descripcion, presentacion)
                Dispose()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class