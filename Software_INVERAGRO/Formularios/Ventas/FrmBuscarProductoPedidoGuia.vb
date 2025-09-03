Imports CapaNegocio

Public Class FrmBuscarProductoPedidoGuia
    Dim cn As New cnCotizacion
    Public _idguia As Integer
    Public Property codproducto As Integer
    Public Property descripcion As String
    Public Property presentacion As String
    Public Property unidadmedida As String
    Public Property stokdisponible As Decimal
    Sub Consultar()
        Try
            dtgListado.DataSource = cn.Cn_ListarProductosActivosGuias(_idguia)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Colorear_SegunValor_igual_a(dtgListado, Color.White, Color.Red, 0, 6)
            clsBasicas.Colorear_SegunValor_mayor_a(dtgListado, Color.White, Color.Green, 0, 6)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub FrmBuscarProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub
    Sub Seleccionar()
        If dtgListado.Rows.Count = 0 Then
            msj_advert("Seleccione un Registro")
            Return
        End If

        Dim activeRow = dtgListado.ActiveRow

        If activeRow IsNot Nothing AndAlso Not String.IsNullOrEmpty(activeRow.Cells(0).Value?.ToString()) Then
            codproducto = activeRow.Cells(0).Value.ToString()
            descripcion = activeRow.Cells(3).Value.ToString()
            presentacion = activeRow.Cells(4).Value.ToString()
            unidadmedida = activeRow.Cells(5).Value.ToString()
            stokdisponible = activeRow.Cells(6).Value.ToString()
            If (stokdisponible = 0) Then
                msj_advert("No cuenta con Stock Disponible para este producto")
            Else
                Dispose()
            End If

        Else
            msj_advert("Seleccione un Registro")
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
                .Columns(3).Width = 250
                .Columns(4).Width = 150
                .Columns(5).Width = 150
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub
End Class