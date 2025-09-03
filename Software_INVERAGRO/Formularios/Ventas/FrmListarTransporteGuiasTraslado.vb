Imports CapaNegocio

Public Class FrmListarTransporteGuiasTraslado
    Dim cn As New cnControlDespacho
    Private ReadOnly _frmRegistrarDespachoRacion As FrmRecepcionProductosPedidoVenta

    Public Sub New(frmRegistrarDespachoRacion As FrmRecepcionProductosPedidoVenta)
        InitializeComponent()
        _frmRegistrarDespachoRacion = frmRegistrarDespachoRacion
    End Sub

    Private Sub FrmListarTransporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarTransportesActivos()
    End Sub

    Sub ListarTransportesActivos()
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            dtgListado.DataSource = cn.Cn_ListarTransporteActivo()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles dtgListado.ClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim id As Integer = dtgListado.ActiveRow.Cells(0).Value
                    Dim numPlaca As String = dtgListado.ActiveRow.Cells(1).Value
                    Dim tipoVehiculo As String = dtgListado.ActiveRow.Cells(2).Value
                    Dim capacidad As Decimal = dtgListado.ActiveRow.Cells(4).Value
                    Dim pesovacio As Decimal = dtgListado.ActiveRow.Cells(5).Value
                    _frmRegistrarDespachoRacion.LlenarCamposTransporte(id, numPlaca, tipoVehiculo, capacidad, pesovacio)
                    Me.Close()
                Else
                    '   msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                '   msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class