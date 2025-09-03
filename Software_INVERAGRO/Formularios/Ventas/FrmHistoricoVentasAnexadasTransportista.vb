Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmHistoricoVentasAnexadasTransportista
    Dim cn As New cnVentas
    Dim ds As New DataSet
    Private Sub FrmHistoricoRecepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultarHistoricoRecepcion()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub
    Private Sub ConsultarHistoricoRecepcion()
        Dim obj As New coVentas
        obj.Codigo = CInt(lblCodigo.Text)
        ds = cn.Cn_ConsultarVentasAnexadasaPedidosVentas(obj).Copy


        ds.DataSetName = "tmp"

        Dim relation1 As New DataRelation("tabla_relacion_32", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(6), False)
        ds.Relations.Add(relation1)
        dtgListado.DataSource = ds
        If (ds.Tables(0).Rows.Count > 0) Then
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", 17)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 17)

            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ENTREGADO", 18)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "PARCIAL", 18)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "SIN DESPACHO", 18)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "PENDIENTE", 19)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ENVIADO", 19)
        End If
        GrupoMasOpcionesBusqueda.Enabled = True
        ToolStrip1.Enabled = True

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub


    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try

            With e.Layout.Bands(0)
                .Columns("codpedido").Header.VisiblePosition = 0
                .Columns("codpedido").Header.Caption = "Código Pedido"
                .Columns("codpedido").Width = 130
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True
                .Columns(2).Hidden = True
                .Columns(3).Hidden = True
                .Columns(4).Hidden = True
                .Columns(5).Width = 80
                .Columns(6).Width = 80
                .Columns(7).Width = 80

                .Columns(9).Hidden = True
                .Columns(15).Hidden = True
                .Columns("btnver").Header.Caption = "Cotización"
                .Columns("btnver").Width = 80
                .Columns("btnver").Style = UltraWinGrid.ColumnStyle.Button
                .Columns("btnver").CellButtonAppearance.Image = My.Resources.adjuntar
                .Columns("btnver").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns("btnver").Hidden = True
                .Columns("direccion").Hidden = True
                .Columns(25).Header.VisiblePosition = 1
            End With

            With e.Layout.Bands(1)
                .Columns(6).Hidden = True
            End With
            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 1)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 10)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 11)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 12)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class