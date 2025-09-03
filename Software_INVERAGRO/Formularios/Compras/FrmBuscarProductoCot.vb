Imports CapaNegocio

Public Class FrmBuscarProductoCot
    Dim cn As New cnCotizacion
    Public _codalmacendestino As Integer
    Public Property codproducto As Integer
    Public Property descripcion As String
    Public Property presentacion As String
    Public Property unidadmedida As String
    Sub Consultar()
        Try
            dtgListado.DataSource = cn.Cn_ListarProductosActivos(_codalmacendestino)
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
                descripcion = dtgListado.DisplayLayout.ActiveRow.Cells(3).Value.ToString
                presentacion = dtgListado.DisplayLayout.ActiveRow.Cells(4).Value.ToString
                unidadmedida = dtgListado.DisplayLayout.ActiveRow.Cells(5).Value.ToString
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
                .Columns(4).Hidden = True
                .Columns(5).Width = 250
                .Columns(5).Header.Caption = "U.M Mínima"
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub
End Class