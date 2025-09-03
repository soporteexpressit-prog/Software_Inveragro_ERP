Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlPedidoSinStock
    Dim cn As New cnIngreso
    Private _estado As String
    Private _Idtipodocumento As String
    Dim ds As New DataSet

    Private Sub FrmControlEpp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = Windows.Forms.FormWindowState.Maximized
        cbxestado.SelectedIndex = 0
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        cbxestado.SelectedIndex = 0
        Consultar()
    End Sub

    Sub Consultar()
        'Pasamos todos los parametros y ejecutamos el hilo para cargar la busqueda
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            'GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            _estado = cbxestado.Text
            _Idtipodocumento = 0
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coIngreso
            obj.Fechadesde = dtpFechaDesde.Value
            obj.Fechahasta = dtpFechaHasta.Value
            obj.Estado = _estado
            obj.Idtipodocumento = _Idtipodocumento
            obj.NombreProducto = txtProducto.Text
            obj.NombreProveedor = txtProveedor.Text
            ds = New DataSet
            ds = cn.Cn_ConsultarPedidosUsuarios(obj).Copy
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        btnConsultar.Enabled = True
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            ds.DataSetName = "tmp"

            Dim relation1 As New DataRelation("tabla_relacion_32", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(5), False)

                ds.Relations.Add(relation1)
            dtgListado.DataSource = ds
            If (ds.Tables(0).Rows.Count > 0) Then
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", 6)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 6)

                clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "PENDIENTE", 8)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "APROBADO", 8)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ANULADO", 8)
            End If
            'GrupoMasOpcionesBusqueda.Enabled = True
            ToolStrip1.Enabled = True
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try

            With e.Layout.Bands(0)
                .Columns("codpedido").Header.VisiblePosition = 0
                .Columns("codpedido").Header.Caption = "Código Pedido"
                .Columns("codpedido").Width = 130
                '.Columns(0).Hidden = True
                '.Columns(1).Hidden = True
                '.Columns(2).Hidden = True
                '.Columns(3).Hidden = True
                '.Columns(4).Hidden = True
                '.Columns(5).Width = 80
                '.Columns(6).Width = 80
                '.Columns(7).Width = 80


            End With

            With e.Layout.Bands(1)
                .Columns(5).Hidden = True
                .Columns(6).Hidden = True

                .Columns(7).Header.Caption = "Ver Ordenes Atenciones"
                .Columns(7).Width = 80
                .Columns(7).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(7).CellButtonAppearance.Image = My.Resources.buscando__1_
                .Columns(7).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns(8).Header.VisiblePosition = 4
            End With
            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 1)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub Dtg_Listado_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            ' Verifica si la columna es "btneliminar"
            If e.Cell.Column.Key = "btnVerOrdenes" Then
                Dim activeRow = dtgListado.ActiveRow

                ' Verifica si hay una fila activa
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        Consultar()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportarpedidouser.Click
        clsBasicas.ExportarExcel("Lista de Pedidos", dtgListado)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnularpedidouser.Click
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    If dtgListado.ActiveRow.Cells(6).Value.ToString = "ACTIVO" Then
                        Dim f As New FrmAnularPedidoUsuario
                        f.idordencompra = dtgListado.ActiveRow.Cells(0).Value.ToString
                        f.ShowDialog()
                        Consultar()
                    Else
                        msj_advert("Pedido ya fue Anulado")
                    End If
                End If

            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevopedidouser.Click

        Dim f As New FrmPedidoSinStock
            f.ShowDialog()
        Consultar()

    End Sub
    Sub ValidarPedido(codigo As Integer)
        Try
            If MsgBox("¿Esta Seguro de Aprobar el Pedido?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If
            Dim obj As New coIngreso
            obj.Codigo = codigo
            obj.Iduser = VP_IdUser
            Dim msj As String
            msj = cn.Cn_ValidarPedido(obj)
            If (obj.Coderror = 0) Then
                msj_ok(msj)
            Else
                msj_advert(msj)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub btaprobar_Click(sender As Object, e As EventArgs) Handles btaprobarpedidouser.Click
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    If dtgListado.ActiveRow.Cells(8).Value.ToString.Equals("PENDIENTE") Then

                        If dtgListado.ActiveRow.Cells(6).Value.ToString = "ACTIVO" Then
                            ValidarPedido(dtgListado.ActiveRow.Cells(0).Value.ToString)
                            Consultar()
                        Else
                            msj_advert("Pedido ya fue Anulado")
                        End If
                    Else
                        msj_advert("Pedido ya fue Aprobado")
                    End If
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btneditar_Click(sender As Object, e As EventArgs) Handles btneditarpedidouser.Click
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    If dtgListado.ActiveRow.Cells(8).Value.ToString.Equals("PENDIENTE") Then

                        Dim f As New FrmPedidoSinStock
                            f._codigo = dtgListado.ActiveRow.Cells(0).Value.ToString
                            f.ShowDialog()
                            Consultar()

                    Else
                        msj_advert("Pedido no puede ser Editado por que ya fue Aprobado")
                    End If
                End If

            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class