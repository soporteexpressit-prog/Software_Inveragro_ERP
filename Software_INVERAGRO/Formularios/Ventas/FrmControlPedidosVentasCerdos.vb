Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlPedidosVentasCerdos
    Dim cn As New cnVentas
    Private _estado As String
    Private _Idtipodocumento As String
    Dim ds As New DataSet

    Private Sub FrmControlEpp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = Windows.Forms.FormWindowState.Maximized
        cbxestado.SelectedIndex = 1
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListado)
        cbxestado.SelectedIndex = 1
        Consultar()
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

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coVentas
            obj.Fechadesde = dtpFechaDesde.Value
            obj.Fechahasta = dtpFechaHasta.Value
            obj.Estado = _estado
            obj.NombreProveedor = txtProveedor.Text
            obj.Iduser = VP_IdUser
            ds = New DataSet
            ds = cn.Cn_ConsultarPedidoVentasCerdo(obj).Copy
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

            If (ds.Tables(0).Rows.Count > 0) Then
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
                    clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "FACTURADO", 19)
                    clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "ENVIADO", 19)


                    clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "AJUSTE IRRECUPERABLE", 4)
                    clsBasicas.Colorear_SegunValor(dtgListado, Color.Yellow, Color.Black, "VENTA DIRECTA POR CONDUCTOR", 4)
                    clsBasicas.Colorear_SegunValor(dtgListado, Color.DarkViolet, Color.White, "VENTA POR KILOS", 4)
                    clsBasicas.Colorear_SegunValor(dtgListado, Color.DarkViolet, Color.White, "CONSUMO INTERNO", 4)

                    clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "PENDIENTE", 28)
                    clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ATENDIDO", 28)
                End If
            End If
            GrupoMasOpcionesBusqueda.Enabled = True
            ToolStrip1.Enabled = True
        End If

    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try

            With e.Layout.Bands(0)
                .Columns("codpedido").Header.VisiblePosition = 0
                .Columns("codpedido").Header.Caption = "Código Pedido"
                .Columns("codpedido").Width = 80
                .Columns(13).Width = 80
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True
                .Columns(2).Hidden = True
                .Columns(3).Hidden = True
                .Columns(4).Width = 200
                .Columns(7).Width = 200
                .Columns(25).Width = 200
                .Columns(5).Width = 80
                .Columns(6).Width = 80
                .Columns(8).Hidden = True
                .Columns(9).Hidden = True
                .Columns(10).Hidden = True
                .Columns(11).Hidden = True
                .Columns(14).Hidden = True
                .Columns(15).Hidden = True
                .Columns("btnver").Hidden = True
                .Columns("direccion").Hidden = True
                .Columns(25).Header.VisiblePosition = 9
                .Columns(27).Header.VisiblePosition = 7
                .Columns(7).Header.VisiblePosition = 8
                .Columns(28).Header.VisiblePosition = 21
                .Columns(26).Hidden = True
                .Columns(13).Header.VisiblePosition = 20
                .Columns(6).Header.VisiblePosition = 21
                .Columns(24).Header.VisiblePosition = 15
                .Columns(29).Header.VisiblePosition = 5
                .Columns(29).Width = 170
                .Columns(22).Width = 110
            End With

            With e.Layout.Bands(1)
                .Columns(6).Hidden = True
                .Columns(4).Header.VisiblePosition = 6
                .Columns(11).Header.VisiblePosition = 4
                .Columns(12).Header.VisiblePosition = 5
            End With
            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 4)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 10)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 11)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 12)
            ' Desplazamiento horizontal



        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert("La fecha 'Desde' debe ser anterior o igual a la fecha 'Hasta'.")
            Return
        End If
        Consultar()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevopedidocerdoventas.Click
        Dim f As New FrmPedidoVentaCerdosEngorde
        f.ShowDialog()
        Consultar()

    End Sub

    Sub ConsultarArchivo(codigo As Integer)

        Dim obj As New coVentas
        obj.Codigo = codigo
        cn.Cn_ObtenerArchivoPedidoVenta(obj)


        Dim pdfData As Byte() = obj.ArchivoRecepcion
        If pdfData IsNot Nothing AndAlso pdfData.Length > 0 Then
            Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "PedidoVenta_archivo" & codigo.ToString & ".pdf")

            File.WriteAllBytes(tempFilePath, pdfData)
            Process.Start(tempFilePath)
        Else
            MessageBox.Show("No se encontró el archivo PDF en la base de datos.")
        End If


    End Sub
    Private Sub Dtg_Listado_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            If (e.Cell.Column.Key = "btnver") Then
                If dtgListado.ActiveRow IsNot Nothing Then
                    ConsultarArchivo(dtgListado.ActiveRow.Cells(0).Value.ToString)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub btnconfirmar_facturacion_Click(sender As Object, e As EventArgs) Handles btnconfirmar_facturacionpedidocerdoventas.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Validar si se seleccionó una fila
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            ' Validación del tipo de transacción
            Dim tipoTransaccion As String = activeRow.Cells(26).Value.ToString()
            Select Case tipoTransaccion
                Case "29", "30", "31", "35", "36", "22", "18", "38", "39", "45", "46", "47", "48", "1051"
                    ' Validación de estado de despacho
                    If activeRow.Cells(18).Value.ToString() = "SIN DESPACHO" Then
                        msj_advert("Pedido de Venta no puede ser enviado a facturación porque no tiene ningún despacho de productos.")
                        Return
                    End If
                    ' Validación de estado de facturación
                    If activeRow.Cells(19).Value.ToString() <> "PENDIENTE" Then
                        msj_advert("Pedido de Venta ya fue enviado a facturación.")
                        Return
                    End If

                    ' Crear objeto de facturación
                    Dim objPedidoVenta As New coVentas With {
                    .Codigo = activeRow.Cells(0).Value
                }

                    Dim f As New FrmModificacionPedidoVenta
                    f._codordencompra = dtgListado.ActiveRow.Cells(0).Value.ToString
                    f.txtnumorden.Text = dtgListado.ActiveRow.Cells("codpedido").Value.ToString
                    f.ShowDialog() ' Muestra el nuevo formulario
                    Consultar()
                Case Else
                    msj_advert("El registro seleccionado no puede ser enviado a facturación por su tipo de transacción.")
                    Return
            End Select

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub CONGUIADETRASLADOToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            If activeRow.Cells(28).Value = "PENDIENTE" Then
                msj_advert("Pedido de Venta no puede ser Despachado por que aun no fue atendido por Producción")
                Return
            End If
            If activeRow.Cells(19).Value <> "PENDIENTE" Then
                msj_advert("Pedido de Venta no puede ser Despachado por que ya fue Enviado a Facturación")
                Return
            End If
            If activeRow.Cells(17).Value = "ANULADO" Then
                msj_advert("Pedido de Venta no puede ser Despachado porque fue Anulado")
                Return
            End If
            If (activeRow.Cells(18).Value.ToString <> "ENTREGADO") Then
                Dim f As New FrmRecepcionProductosPedidoVenta
                f._transferencia = "NO"
                f._codigo = activeRow.Cells(0).Value.ToString
                f.txtdestino.Text = activeRow.Cells("direccion").Value.ToString
                f.ShowDialog()
                Consultar()
            Else
                msj_advert("Ya fue Entregado todos los productos")
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub SINGUIADETRASLADOToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            If activeRow.Cells(29).Value = "PENDIENTE" Then
                msj_advert("Pedido de Venta no puede ser Despachado por que aun no fue atendido por Producción")
                Return
            End If
            If activeRow.Cells(19).Value <> "PENDIENTE" Then
                msj_advert("Pedido de Venta no puede ser Despachado por que ya fue Enviado a Facturación")
                Return
            End If
            If activeRow.Cells(17).Value = "ANULADO" Then
                msj_advert("Pedido de Venta no puede ser Despachado porque fue Anulado")
                Return
            End If
            If activeRow.Cells(18).Value = "PARCIAL" Then
                msj_advert("Pedido de Venta no puede ser Despachado sin Guia por que ya esta siendo Despachado de Forma PARCIAL")
                Return
            End If
            If (activeRow.Cells(18).Value.ToString <> "ENTREGADO") Then
                Dim f As New FrmRecepcionProductosPedidoVentaSinGuia
                f._codigo = activeRow.Cells(0).Value.ToString
                f.txtcliente.Text = activeRow.Cells(7).Value.ToString
                f.ShowDialog()
                Consultar()
            Else
                msj_advert("Ya fue Entregado todos los productos")
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

    Private Sub btnguia_Click(sender As Object, e As EventArgs) Handles btnguia.Click
        Dim g As New FrmVerGuiaTraslado
        g.idpedido = dtgListado.ActiveRow.Cells(0).Value.ToString
        g.ShowDialog()
    End Sub
    Sub imprimir_reporte_venta()
        Dim selectedRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If selectedRow Is Nothing Then
            MsgBox("Por favor, seleccione un registro.")
            Return
        End If
        Dim selectedId As Integer = CInt(selectedRow.Cells(0).Value)
        Dim obj As New coVentas
        Dim dsCapacitacion As New DataSet
        obj.Idcotizacion = selectedId
        dsCapacitacion = cn.Cn_imprimir_reporte_venta(obj).Copy

        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_Venta.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnnueva_venta_x_kilos_Click(sender As Object, e As EventArgs) Handles btnnueva_venta_x_kilosMODUVENTAS.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            If (dtgListado.Rows.Count > 0) Then
                If {"31", "45", "46", "47", "48"}.Contains(activeRow.Cells(26).Value.ToString) Then
                    If activeRow.Cells(19).Value.ToString() <> "PENDIENTE" Then
                        msj_advert("No se puede Anexar una Nueva Venta por Kilos porque el Pedido Seleccionado ya fue enviado a Facturación")
                        Return
                    End If

                    Dim f As New FrmPedidoVentaxKilos
                    f._codigo = dtgListado.ActiveRow.Cells(0).Value.ToString
                    f.ShowDialog()
                Else
                    msj_advert("Solo se puede Aplicar la Venta por Kilos a un Pedido de Cerdo de Emergencia")
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
        Consultar()
    End Sub

    Private Sub ConvertirAConductorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertirAConductorToolStripMenuItem.Click
        Try
            Dim frm As New FrmReporteDespachoCerdoGranja
            frm.operacion = 2
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        imprimir_reporte_venta()
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        clsBasicas.ExportarExcel("Lista de Pedidos de Ventas", dtgListado)
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            If activeRow.Cells(18).Value.ToString.Equals("SIN DESPACHO") Then
                If activeRow.Cells(19).Value <> "PENDIENTE" Then
                    msj_advert("Pedido de Venta no puede ser Anulado porque ya fue Enviado a Facturación")
                ElseIf activeRow.Cells(28).Value = "ATENDIDO" Then
                    msj_advert("Pedido de Venta no puede ser Anulado porque ya fue atendido por Producción")
                Else
                    Dim f As New FrmAnularPedidoVenta
                    f.idordencompra = activeRow.Cells(0).Value.ToString
                    f.ShowDialog()
                    Consultar()
                End If
            Else
                msj_advert("Pedido de Venta no puede ser Anulada por que tiene Recepciones de Productos")
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            If activeRow.Cells(19).Value.ToString() = "PENDIENTE" Then
                If activeRow.Cells(17).Value.ToString() = "ACTIVO" Then
                    If activeRow.Cells(18).Value.ToString() = "ENTREGADO" Then
                        Dim f As New FrmAnularventavendedoras
                        f.idordencompra = activeRow.Cells(0).Value.ToString
                        f.ShowDialog()
                        Consultar()
                    Else
                        msj_advert("El pedido no puede ser anulado, ya que aún no ha sido despachado al cliente.")
                    End If
                Else
                    msj_advert("Distribución ya fue anulada")
                End If

            Else
                msj_advert("Este pedido ya se enviado a facturación, anulación denegada")
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            If activeRow.Cells(17).Value = "ANULADO" Then
                msj_advert("Pedido de Venta no puede ser editado porque fue Anulado")
                Return
            End If
            If activeRow.Cells(19).Value.ToString() <> "PENDIENTE" Then
                msj_advert("Pedido de Venta ya fue enviado a facturación.")
                Return
            End If
            If activeRow.Cells(28).Value.ToString() <> "PENDIENTE" Then
                msj_advert("Pedido de Venta ya atendido.")
                Return
            End If
            If dtgListado.ActiveRow IsNot Nothing Then
                Dim codigo As String = dtgListado.ActiveRow.Cells(0).Value.ToString()
                Dim f As New FrmPedidoVentaCerdosEngorde
                f._codigo = codigo
                f.operacion = 1
                f.ShowDialog()
                Consultar()
            Else
                MessageBox.Show("Seleccione una fila para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Consultar()
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            If dtgListado.ActiveRow IsNot Nothing Then
                Dim filaSeleccionada = dtgListado.ActiveRow ' Obtener la fila activa
                Dim f As New FrmEditarclienteBanco
                f.codigo = filaSeleccionada.Cells(0).Value
                f.operacion = 1 ' Valor de la primera columna
                If f.ShowDialog() = DialogResult.OK Then
                    Consultar()
                End If
            Else
                MessageBox.Show("Por favor, seleccione una fila para editar.", "Editar Transporte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Consultar()
    End Sub


    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            Dim resultado As DialogResult = MessageBox.Show(
                "¿Estás seguro de que deseas revertir el envío? Se eliminarán los pesos ingresados, así como el precio y el total.",
                "Confirmar reversión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)
            If resultado = DialogResult.Yes Then
                If activeRow.Cells(19).Value.ToString() = "FACTURADO" Then
                    msj_advert("Este pedido ya ha sido facturado y no puede volver a procesarse.")
                    Return
                End If
                If activeRow.Cells(19).Value.ToString() = "PENDIENTE" Then
                    msj_advert("Este pedido aún no ha sido enviado a facturación.")
                    Return
                End If
                Dim filaSeleccionada = dtgListado.ActiveRow ' Obtener la fila activa
                Dim obj As New coVentas
                obj.Codigo = filaSeleccionada.Cells(0).Value
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_anularnevioafacturacion(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                Else
                    msj_advert(MensajeBgWk)
                End If
            Else
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Consultar()
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            If activeRow.Cells(19).Value.ToString() = "FACTURADO" Then
                msj_advert("Este pedido ya ha sido facturado y no puede volver a procesarse.")
                Return
            End If
            If activeRow.Cells(18).Value.ToString() = "SIN DESPACHO" Then
                msj_advert("No puedes realizar un ajuste porque el pedido aún no ha sido despachado.")
                Return
            End If
            If activeRow.Cells(26).Value.ToString() = "24" Or activeRow.Cells(26).Value.ToString() = "22" Then
                msj_advert("No es posible ajustar el registro seleccionado debido al tipo de transacción.")
                Return
            End If
            Dim f As New FrmPedidoVentaAjusteIrrecuperableCerdos
            f._idguia = activeRow.Cells(0).Value.ToString
            f.operacion = 1
            f.ShowDialog()
            Consultar()

        Catch ex As Exception
            msj_advert("Seleccione un Registro Correcto")
        End Try
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            If activeRow.Cells(19).Value.ToString() = "FACTURADO" Then
                msj_advert("Este pedido ya ha sido facturado y no puede volver a procesarse.")
                Return
            End If
            If activeRow.Cells(18).Value.ToString() = "SIN DESPACHO" Then
                msj_advert("No puedes realizar un ajuste porque el pedido aún no ha sido despachado.")
                Return
            End If
            If activeRow.Cells(26).Value.ToString() = "24" Or activeRow.Cells(26).Value.ToString() = "22" Then
                msj_advert("No es posible ajustar el registro seleccionado debido al tipo de transacción.")
                Return
            End If
            Dim f As New FrmAjustepositivoVentas
            f._idguia = activeRow.Cells(0).Value.ToString
            f.operacion = 1
            f.ShowDialog()
            Consultar()

        Catch ex As Exception
            msj_advert("Seleccione un Registro Correcto")
        End Try
    End Sub

    Private Sub AnularAjusteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularAjusteToolStripMenuItem.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            If activeRow.Cells(19).Value.ToString() = "FACTURADO" Then
                msj_advert("Este pedido ya ha sido facturado y no puede volver a procesarse.")
                Return
            End If
            Dim f As New FrmAjustepositivoVentas
            f._idguia = activeRow.Cells(0).Value.ToString
            f.operacion = 2
            f.ShowDialog()
            Consultar()

        Catch ex As Exception
            msj_advert("Seleccione un Registro Correcto")
        End Try
    End Sub

    Private Sub btneditarpedidos_Click(sender As Object, e As EventArgs) Handles btneditarpedidos.Click

    End Sub

    Private Sub PesosPorVendedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PesosPorVendedorToolStripMenuItem.Click
        Try
            Dim frm As New FrmReportePesosVendedor
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub VentaDeCerdosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaDeCerdosToolStripMenuItem.Click
        Try
            Dim frm As New FrmReporteVentaCerdos
            frm.operacion = 1
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
        Consultar()
    End Sub

    Private Sub ActualizarVendedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarVendedorToolStripMenuItem.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Validar si se seleccionó una fila
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            Dim frm As New FrmActualizarVendedor
            frm._codigo = dtgListado.ActiveRow.Cells(0).Value.ToString
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub EditarTipoCerdoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarTipoCerdoToolStripMenuItem.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Validar si se seleccionó una fila
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            Dim frm As New FrmActualizarVendedor
            frm._codigo = dtgListado.ActiveRow.Cells(0).Value.ToString
            frm.operacion = 1
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnVentaAnual_Click(sender As Object, e As EventArgs) Handles btnVentaAnual.Click
        Try
            Dim frm As New FrmVentaAnual
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim f As New FrmPedidoVentaDirecta
        f.ShowDialog()
        Consultar()
    End Sub

    Private Sub ProyecciónDeProyecciónVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProyecciónDeProyecciónVentaToolStripMenuItem.Click
        Try
            Dim frm As New FrmReporteProyeccionVenta
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub EditarTipoDePrecioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarTipoDePrecioToolStripMenuItem.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            ' Validar si se seleccionó una fila
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If
            Dim frm As New FrmActualizarVendedor
            frm._codigo = dtgListado.ActiveRow.Cells(0).Value.ToString
            frm.operacion = 2
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub ResumenDePedidosDeVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResumenDePedidosDeVentaToolStripMenuItem.Click
        Try
            Dim frm As New FrmReporteDespachoCerdoGranja
            frm.operacion = 1
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert("La fecha 'Desde' debe ser anterior o igual a la fecha 'Hasta'.")
            Return
        End If
        Consultar()
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles btnventaoirrecuperablespedidocerdoventas.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If


            If (activeRow.Cells(26).Value.ToString = "29" Or activeRow.Cells(26).Value.ToString = "35" Or activeRow.Cells(26).Value.ToString = "36" Or activeRow.Cells(26).Value.ToString = "31") Then
                Dim f As New FrmHistoricoVentasAnexadasTransportista
                f.lblCodigo.Text = dtgListado.ActiveRow.Cells(0).Value.ToString
                f.lblcodOrden.Text = dtgListado.ActiveRow.Cells(22).Value.ToString
                f.lblMotivoTransaccion.Text = dtgListado.ActiveRow.Cells(4).Value.ToString
                f.lblFechaPedido.Text = DateTime.Parse(dtgListado.ActiveRow.Cells(5).Value).ToString("dd/MM/yyyy")
                f.lblProveedor.Text = dtgListado.ActiveRow.Cells(7).Value.ToString
                f.ShowDialog()
            Else
                msj_advert("Las Ventas o Ajustes por Irrecuperable, solo estan habilitados para las Ventas ")
            End If


        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        Try

            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            ' If (activeRow.Cells(26).Value.ToString = "29" Or activeRow.Cells(26).Value.ToString = "30" Or activeRow.Cells(26).Value.ToString = "31") Then
            Dim f As New FrmHistoricoRecepcionDespachos
            f.lblCodigo.Text = activeRow.Cells(0).Value.ToString
            f.lblcodOrden.Text = activeRow.Cells(22).Value.ToString
            f.lblMotivoTransaccion.Text = activeRow.Cells(4).Value.ToString
            f.lblFechaPedido.Text = DateTime.Parse(activeRow.Cells(5).Value).ToString("dd/MM/yyyy")
            f.lblProveedor.Text = activeRow.Cells(7).Value.ToString
            f.ShowDialog()
            Consultar()

            'Else
            'msj_advert("Los Historicos de Recepciones solo estan habilitados para las Ventas o Transferencias ")
            'End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub PesosGanchosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PesosGanchosToolStripMenuItem.Click
        Try
            If dtgListado.ActiveRow Is Nothing OrElse dtgListado.ActiveRow.Cells(0).Value Is Nothing OrElse String.IsNullOrWhiteSpace(dtgListado.ActiveRow.Cells(0).Value.ToString()) Then
                msj_advert("Seleccione un Pedido de Venta para ver los Pesos de Gancho")
                Return
            End If
            Dim frm As New FrmVerPesosGancho
            frm._codigo = dtgListado.ActiveRow.Cells(0).Value.ToString
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub PesosGranjaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PesosGranjaToolStripMenuItem.Click
        Try
            Dim frm As New FrmReportePesosGranja
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub MermasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MermasToolStripMenuItem.Click
        Try
            Dim frm As New FrmReporteMermas
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub VentasCobrosPorClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasCobrosPorClienteToolStripMenuItem.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            Dim frm As New FrmReporteVentasyContabilidad
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub AnularGuiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularGuiaToolStripMenuItem.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            Dim f As New FrmAnularPedidoVenta
            f.idordencompra = activeRow.Cells(0).Value.ToString
            f.operacion = 1
            f.ShowDialog()
            Consultar()

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub StockDeCerdosParaVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockDeCerdosParaVentaToolStripMenuItem.Click
        Try
            Dim frm As New FrmReporteStockCerdosVenta
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub AnularVentaPorKilosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularVentaPorKilosToolStripMenuItem.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing

            ' Llamar a la función de validación de selección
            If Not clsBasicas.ValidarSeleccionFila(activeRow, dtgListado) Then
                Return
            End If

            Dim f As New FrmAnularPedidoVenta
            f.idordencompra = activeRow.Cells(0).Value.ToString
            f.operacion = 3
            f.ShowDialog()
            Consultar()

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class