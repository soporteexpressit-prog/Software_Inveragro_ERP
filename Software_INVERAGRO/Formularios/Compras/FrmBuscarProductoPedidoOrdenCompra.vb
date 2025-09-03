Imports CapaNegocio
Imports CapaObjetos

Public Class FrmBuscarProductoPedidoOrdenCompra
    Dim cn As New cnCotizacion
    Public _codalmacendestino As Integer
    Public Property codproducto As Integer
    Public Property servicio As Integer
    Public Property descripcion As String
    Public Property presentacion As String
    Public Property unidadmedida As String
    Public Property cantidad As Decimal
    Public Property categoria As String

    Sub Consultar()
        Try
            dtgListado.DataSource = cn.Cn_ListarProductosActivosPedidosSolicitados(servicio)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub FrmBuscarProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub
    Sub Seleccionar()
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                codproducto = dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString
                categoria = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                descripcion = dtgListado.DisplayLayout.ActiveRow.Cells(3).Value.ToString
                presentacion = dtgListado.DisplayLayout.ActiveRow.Cells(4).Value.ToString
                unidadmedida = dtgListado.DisplayLayout.ActiveRow.Cells(5).Value.ToString
                cantidad = dtgListado.DisplayLayout.ActiveRow.Cells(6).Value.ToString
                Dispose()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub
    Private Sub Dtg_ListaProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgListado.KeyDown
        If e.KeyData = Keys.Enter Then
            Seleccionar()
        End If

    End Sub
    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Seleccionar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Width = 90
                .Columns(1).Width = 110
                .Columns(2).Width = 110
                .Columns(3).Width = 300
                .Columns(4).Width = 150
                .Columns(8).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim result As DialogResult = MessageBox.Show("¿Desea realmente anular este producto del pedido del cliente?", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    If result = DialogResult.Yes Then
                        Dim obj As New coCotizacion
                        obj.Codigo = dtgListado.ActiveRow.Cells(0).Value
                        obj.IdTipoDocumento = dtgListado.ActiveRow.Cells(8).Value
                        Dim MensajeBgWk As String = ""
                        MensajeBgWk = cn.Cn_Anularpedidousuario(obj)
                        If (obj.Coderror = 0) Then
                            msj_ok(MensajeBgWk)
                            Dispose()
                        Else
                            msj_advert(MensajeBgWk)
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class