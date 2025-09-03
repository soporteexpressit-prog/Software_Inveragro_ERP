Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarRacionDespacharPedido
    Dim cn As New cnNucleo
    Private ReadOnly _frmAtenderPedidoCerdoVenta As FrmAtenderPedidoCerdoVenta
    Public idUbicacion As Integer = 0

    Public Sub New(frmAtenderPedidoCerdoVenta As FrmAtenderPedidoCerdoVenta)
        InitializeComponent()
        _frmAtenderPedidoCerdoVenta = frmAtenderPedidoCerdoVenta
    End Sub

    Private Sub FrmListarRacionDespacharPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarAlimento()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Sub ListarAlimento()
        Try
            Dim obj As New coProductos With {
                .IdUbicacion = idUbicacion
            }
            dtgListado.DataSource = cn.Cn_ListarRaciones(obj)
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Unidad Medida").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Descripción").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Fecha de Registro").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Stock Transito").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Estado").Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.Rows.Count = 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If

        ' Validamos que haya una fila seleccionada
        If e.Cell Is Nothing OrElse e.Cell.Row Is Nothing Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If

        ' Validamos que el índice sea válido
        If e.Cell.Row.Index < 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim codigo As String = e.Cell.Row.Cells(0).Value.ToString()
                    Dim descripcion As String = e.Cell.Row.Cells("Ración").Value.ToString()
                    Dim stock As Decimal = CDec(e.Cell.Row.Cells("Stock").Value)

                    _frmAtenderPedidoCerdoVenta.LlenarCamposAlimento(codigo, descripcion, stock)
                    Me.Close()
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
        Me.Close()
    End Sub
End Class