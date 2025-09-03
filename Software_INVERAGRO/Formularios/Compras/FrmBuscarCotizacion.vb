Imports CapaNegocio
Imports CapaObjetos

Public Class FrmBuscarCotizacion
    Dim cn As New cnCotizacion
    Public Property codproveedor As Integer

    Public Property codcotizacion As Integer
    Public Property codmoneda As Integer
    Public Property codcondicionpago As Integer
    Public Property dtdetalle_coti As New DataTable
    Sub Consultar()
        Try
            Dim obj As New coCotizacion
            obj.IdDestino = codproveedor
            Dim ds As New DataSet
            ds.DataSetName = "tmds"
            ds = cn.Cn_ConsultarxProveedor(obj).Copy
            dtdetalle_coti = ds.Tables(1).Copy
            Dim relation1 As New DataRelation("tabla_relacion_32", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(5), False)

            ds.Relations.Add(relation1)
            dtgListado.DataSource = ds
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
                codcotizacion = dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString
                codcondicionpago = dtgListado.DisplayLayout.ActiveRow.Cells(7).Value.ToString
                codmoneda = dtgListado.DisplayLayout.ActiveRow.Cells(8).Value.ToString
                Dispose()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub
    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Seleccionar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(6).Hidden = True
                .Columns(7).Hidden = True
                .Columns(8).Hidden = True
            End With
            With e.Layout.Bands(1)
                .Columns(4).Hidden = True
                .Columns(5).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub

    Private Sub dtgListado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgListado.KeyDown
        If e.KeyData = Keys.Enter Then
            Seleccionar()
        End If

    End Sub
End Class