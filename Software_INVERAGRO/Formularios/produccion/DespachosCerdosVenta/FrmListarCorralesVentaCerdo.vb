Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarCorralesVentaCerdo
    Dim cn As New cnControlDespachoCerdoVenta
    Public idPlantel As Integer
    Private CorralCantidades As New Dictionary(Of Integer, Integer)
    Private ReadOnly _frmAtenderPedidoCerdoVenta As FrmAtenderPedidoCerdoVenta

    Public Sub New(frmAtenderPedidoCerdoVenta As FrmAtenderPedidoCerdoVenta, corrales As Dictionary(Of Integer, Integer))
        InitializeComponent()
        _frmAtenderPedidoCerdoVenta = frmAtenderPedidoCerdoVenta
        CorralCantidades = corrales
    End Sub

    Private Sub FrmListarCorralesVentaCerdo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarCorralesVenta()
    End Sub

    Sub ListarCorralesVenta()
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Dim obj As New coControlDespachoCerdoVenta With {
            .IdPlantel = idPlantel
        }

            Dim dt As DataTable = cn.Cn_ConsultarLotesVenta(obj)

            For Each row As DataRow In dt.Rows
                Dim idLote As Integer = CInt(row("idLote"))
                ' Usamos solo idLote como clave
                If CorralCantidades.ContainsKey(idLote) Then
                    Dim cantidadVenta As Integer = CInt(row(2))
                    Dim cantidadDescontar As Integer = CorralCantidades(idLote)

                    row(2) = Math.Max(0, cantidadVenta - cantidadDescontar)
                End If
            Next

            dtgListado.DataSource = dt
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim idLote As Integer = CInt(dtgListado.ActiveRow.Cells(0).Value)
                    Dim lote As String = dtgListado.ActiveRow.Cells(1).Value.ToString
                    Dim cantidad As Integer = CInt(dtgListado.ActiveRow.Cells(2).Value)

                    _frmAtenderPedidoCerdoVenta.LlenarCamposCorral(idLote, lote, cantidad)
                    Dispose()
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class