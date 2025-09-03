Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmPedidoGeneticoPorcino
    Dim cn As New cnIngreso
    Dim ds As New DataSet

    Private Sub FrmPedidoGeneticoPorcino_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        CmbEstado.SelectedIndex = 0
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        CmbEstado.SelectedIndex = 0
    End Sub

    Private Sub BloquearControles()
        Ptbx_Cargando.Visible = True
        ToolStrip1.Enabled = False
        GrupoFiltros.Enabled = False
    End Sub

    Private Sub DesbloquearControles()
        Ptbx_Cargando.Visible = False
        ToolStrip1.Enabled = True
        GrupoFiltros.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()

            Dim obj As New coIngreso With {
                .Fechadesde = dtpFechaDesde.Value,
                .Fechahasta = dtpFechaHasta.Value,
                .Estado = CmbEstado.Text
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coIngreso = CType(e.Argument, coIngreso)

            ds = cn.Cn_ConsultarPedidosUsuarioSemenPorcino(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(5), False)
            ds.Relations.Add(relation1)
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = ds.Tables(0)
            DesbloquearControles()
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (ds.Tables(0).Rows.Count > 0) Then
            Dim estado As Integer = 6
            Dim estadoValidacion As Integer = 8

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", estado)

            'estadoValidacion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "PENDIENTE", estadoValidacion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "APROBADO", estadoValidacion)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoValidacion).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try

            With e.Layout.Bands(0)
                .Columns("codpedido").Header.VisiblePosition = 0
                .Columns("codpedido").Header.Caption = "Código Pedido"
                .Columns("codpedido").Width = 130
            End With

            With e.Layout.Bands(1)
                .Columns(5).Hidden = True
                .Columns(6).Hidden = True

                .Columns(7).Header.Caption = "Ver Ordenes Atenciones"
                .Columns(7).Width = 80
                .Columns(7).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(7).CellButtonAppearance.Image = My.Resources.buscando__1_
                .Columns(7).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 1)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub Dtg_Listado_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            If e.Cell.Column.Key = "btnVerOrdenes" Then
                Dim activeRow = dtgListado.ActiveRow

                If activeRow IsNot Nothing Then
                    Dim codigo As Integer = activeRow.Cells(6).Value?.ToString()
                    Dim f As New FrmHistoricoOrdenesAtendidas
                    f.lblCodigo.Text = codigo
                    f.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnBuscarMG_Click(sender As Object, e As EventArgs) Handles BtnBuscarMG.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        Consultar()
    End Sub

    Private Sub btnNuevoPedidoMaterialGenetico_Click(sender As Object, e As EventArgs) Handles btnNuevoPedidoMaterialGenetico.Click
        Dim frm As New FrmRegistrarPedidoSemenPorcino
        frm.ShowDialog()
        Consultar()
    End Sub

    Private Sub BtnExportarMG_Click(sender As Object, e As EventArgs) Handles BtnExportarPedidoMaterialGenetico.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL PEDIDOS SEMEN Y PORCINO", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmPedidoGeneticoPorcino_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnBuscarMG.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class