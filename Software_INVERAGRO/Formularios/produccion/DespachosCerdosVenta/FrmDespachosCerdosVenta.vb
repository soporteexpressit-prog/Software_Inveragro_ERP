Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmDespachosCerdosVenta
    Dim cn As New cnControlDespachoCerdoVenta
    Dim ds As New DataSet
    Private _estado As String

    Private Sub FrmDespachosCerdosVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True
            cbxestado.SelectedIndex = 0
            dtpFechaDesde.Value = Now.Date
            dtpFechaHasta.Value = Now.Date
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            cbxestado.SelectedIndex = 0
            Consultar()
            ListarPlanteles()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            _estado = cbxestado.Text
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlanteles().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbUbicacion
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coControlDespachoCerdoVenta With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .Estado = _estado,
                .NombreProveedor = txtProveedor.Text,
                .IdPlantel = CmbUbicacion.Value
            }
            ds = New DataSet
            ds = cn.Cn_ConsultarPedidoVentasCerdo(obj).Copy
            'ds.Tables(0).Columns("Codigo").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("Producto").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("idUbicacion").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("idMotivoTransaccion").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idSalida").ColumnMapping = MappingType.Hidden
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        BtnConsultar.Enabled = True
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tabla_relacion_32", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(2), False)
            ds.Relations.Add(relation1)
            dtgListado.DataSource = ds
            Colorear()
            GrupoMasOpcionesBusqueda.Enabled = True
            ToolStrip1.Enabled = True
            If CmbUbicacion.Value = 1 Or CmbUbicacion.Value = 2 Then
                dtgListado.DisplayLayout.Bands(0).Columns("[+]").Hidden = False
            Else
                dtgListado.DisplayLayout.Bands(0).Columns("[+]").Hidden = True
            End If
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estadoDespacho As Integer = 11
            Dim estado As Integer = 12

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ATENDIDO", estadoDespacho)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estadoDespacho)

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estadoDespacho).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub BtnConsultar_Click(sender As Object, e As EventArgs) Handles BtnConsultar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert("La fecha 'Desde' debe ser anterior o igual a la fecha 'Hasta'.")
            Return
        End If
        Consultar()
    End Sub

    Private Sub BtnAtenderPedido_Click(sender As Object, e As EventArgs) Handles BtnAtenderPedidodespachoscerdopro.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim idSalida As Integer = activeRow.Cells("Codigo").Value
                    Dim estadoDespacho As String = activeRow.Cells("Estado Despacho").Value.ToString()
                    Dim estadoPedido As String = activeRow.Cells("Estado").Value.ToString()
                    Dim cantidadSolitada As Integer = activeRow.Cells("Cantidad Pedido").Value
                    Dim idPlantel As Integer = activeRow.Cells("idUbicacion").Value
                    Dim idMotivoTransaccion As String = activeRow.Cells("idMotivoTransaccion").Value.ToString()

                    If estadoDespacho = "ATENDIDO" Then
                        msj_advert("El pedido ya fue atendido")
                        Return
                    End If

                    If estadoPedido = "ANULADO" Then
                        msj_advert("El pedido esta anulado")
                        Return
                    End If

                    Try
                        Dim frm As Form

                        If idPlantel = 1 Or idPlantel = 2 OrElse idMotivoTransaccion = 31 Then
                            frm = New FrmAtenderPedidoCerdasCodificadas With {
                            .idPlantel = CmbUbicacion.Value,
                            .cliente = activeRow.Cells("Cliente / Solicitante").Value,
                            .cantidadSolicitada = cantidadSolitada,
                            .observacion = activeRow.Cells("Observación").Value,
                            .idSalida = idSalida,
                            .idMotivoTransaccion = idMotivoTransaccion,
                            .fPedido = activeRow.Cells("F.Pedido").Value
                        }
                        Else
                            frm = New FrmAtenderPedidoCerdoVenta With {
                            .idPlantel = CmbUbicacion.Value,
                            .cliente = activeRow.Cells("Cliente / Solicitante").Value,
                            .cantidadSolicitada = cantidadSolitada,
                            .observacion = activeRow.Cells("Observación").Value,
                            .idSalida = idSalida,
                            .sacosEngorde = activeRow.Cells("Sacos Engorde").Value,
                            .fPedido = activeRow.Cells("F.Pedido").Value
                        }
                        End If

                        frm.ShowDialog()
                        Consultar()
                    Catch ex As Exception
                        clsBasicas.controlException(Name, ex)
                    End Try
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub BtnExportarControlCerda_Click(sender As Object, e As EventArgs) Handles BtnExportarControlCerdadespachoscerdospro.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("DESPACHOS-VENTA", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCancelarPedidoAtendido_Click(sender As Object, e As EventArgs) Handles BtnCancelarPedidoAtendido.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim estadoDespacho As String = activeRow.Cells("Estado Despacho").Value.ToString()
                    Dim idMotivoTransaccion As String = activeRow.Cells("idMotivoTransaccion").Value.ToString()
                    Dim idPlantel As Integer = activeRow.Cells("idUbicacion").Value
                    Dim mensaje As String = ""

                    If estadoDespacho = "PENDIENTE" Then
                        msj_advert("NO PUEDE CANCELAR UN PEDIDO DE CERDO QUE AÚN NO HA SIDO ANTENDIDO")
                        Return
                    End If

                    If (MessageBox.Show("¿ESTÁ SEGURO QUE DESEA CANCELAR EL PEDIDO DE CERDOS ATENDIDO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    Dim obj As New coControlDespachoCerdoVenta With {
                        .IdSalida = activeRow.Cells("Codigo").Value
                    }

                    If idPlantel = 1 Or idPlantel = 2 OrElse idMotivoTransaccion = 31 Then
                        mensaje = cn.Cn_CancelarPedidoCerdoAtendidoCod(obj)
                    Else
                        mensaje = cn.Cn_CancelarPedidoCerdoAtendido(obj)
                    End If

                    If (obj.Coderror = 0) Then
                        msj_ok(mensaje)
                        Consultar()
                    Else
                        msj_advert(mensaje)
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                clsBasicas.Totales_Formato(dtgListado, e, 2)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 14)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmDespachosCerdosVenta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnConsultar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        If e.Row.Band.Index = 0 Then
            Dim colVerPDF As Infragistics.Win.UltraWinGrid.UltraGridColumn
            If dtgListado.DisplayLayout.Bands(0).Columns.Exists("[+]") Then
                colVerPDF = dtgListado.DisplayLayout.Bands(0).Columns("[+]")
                colVerPDF.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerPDF.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                If Not e.ReInitialize Then
                    e.Row.Cells("[+]").Value = "[+]"
                    e.Row.Cells("[+]").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                End If
            End If
        End If
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            With dtgListado
                If (e.Cell.Column.Key = "[+]") Then
                    Dim frm As New FrmAretesAnimalesVenta
                    frm.idSalida = .ActiveRow.Cells("Codigo").Value.ToString
                    frm.ShowDialog()
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class