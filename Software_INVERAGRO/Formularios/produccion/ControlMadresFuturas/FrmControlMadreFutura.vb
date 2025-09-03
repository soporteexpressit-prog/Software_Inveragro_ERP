Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmControlMadreFutura
    Dim cnAnimal As New cnControlAnimal
    Dim tbtmp As New DataTable
    Dim cn As New cnControlLoteDestete
    Dim ds As New DataSet

    Private Sub FrmControlMadreFutura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
            Consultar1()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Me.KeyPreview = True
        Ptbx_Cargando.Visible = True
        CmbEstadoVivo.Visible = False
        LblEstado.Visible = False
        BtnMortalidadAnimal.Visible = False
        BtnMandarCamalprocontrolcerdos.Visible = False
        BtnActualizarDatosprocontrolcerdos.Visible = False
        CmbEstadoVivo.SelectedIndex = 0
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlantelesReproduccion().Copy
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

    Sub Consultar1()
        dtgListado.DataSource = Nothing
        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()
            Dim obj As New coControlLoteDestete With {
                .IdPlantel = CmbUbicacion.Value,
                .Anio = CmbAnios.Text
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Sub Consultar2()
        dtgListado.DataSource = Nothing
        If Not BackgroundWorker2.IsBusy Then
            BloquearControles()
            Dim obj As New coControlAnimal With {
                .EstadoVivo = CmbEstadoVivo.Text,
                .IdPlantel = CmbUbicacion.Value
            }

            BackgroundWorker2.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)

            ds = cn.Cn_ConsultarMovimientoRetornoxLote(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Tables(0).Columns("idLote").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("idPlantel").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("Plantel").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idLote").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idMovimientoBajada").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idUbicacionSalida").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idUbicacionLlegada").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("Lote").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("Plantel Llegada").ColumnMapping = MappingType.Hidden
            ds.Relations.Add(relation1)
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DesbloquearControles()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = ds.Tables(0)
            ColorearSubItems()
        End If
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            tbtmp = cnAnimal.Cn_ConsultarChanchillaCelador(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        DesbloquearControles()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            dtgListado.DisplayLayout.Bands(0).Columns("idAnimal").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Ubicación").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Arete Madre").Hidden = True
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estadoVivo As Integer = 12
            Dim condicionReproductiva As Integer = 13
            Dim estadoCamal As Integer = 14
            Dim estadoVenta As Integer = 15

            'estadoVivo
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "VIVO", estadoVivo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "MUERTO", estadoVivo)

            'estadoVenta
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estadoVenta)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightBlue, Color.DarkBlue, "EN VENTA", estadoVenta)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "VENDIDO", estadoVenta)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "DESCARTE", estadoVenta)

            'condicionReproductiva
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "APTO", condicionReproductiva)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "NO APTO", condicionReproductiva)

            'estadoCamal
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightSlateGray, Color.White, "ENVIADO", estadoCamal)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightSkyBlue, Color.MidnightBlue, "EN PRODUCCION", estadoCamal)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "DESCARTE", estadoCamal)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estadoVivo).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoVenta).CellAppearance.TextHAlign = HAlign.Center
                .Columns(condicionReproductiva).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoCamal).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub ColorearSubItems()
        If (dtgListado.Rows.Count > 0) Then
            For Each row As UltraGridRow In dtgListado.Rows
                For Each childRow As UltraGridRow In row.ChildBands(0).Rows
                    Dim estadoCell As UltraGridCell = childRow.Cells("Recepción")
                    Dim tipoCell As UltraGridCell = childRow.Cells("Tipo Movimiento")

                    Select Case estadoCell.Text
                        Case "SI"
                            With estadoCell.Appearance
                                .BackColor = Color.Green
                                .ForeColor = Color.White
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With estadoCell.ActiveAppearance
                                .BackColor = Color.Green
                                .ForeColor = Color.White
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With estadoCell.SelectedAppearance
                                .BackColor = Color.Green
                                .ForeColor = Color.White
                                .FontData.Bold = DefaultableBoolean.True
                            End With

                        Case "NO"
                            With estadoCell.Appearance
                                .BackColor = Color.LightGray
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With estadoCell.ActiveAppearance
                                .BackColor = Color.LightGray
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With estadoCell.SelectedAppearance
                                .BackColor = Color.LightGray
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                    End Select

                    Select Case tipoCell.Text
                        Case "ENVIO"
                            With tipoCell.Appearance
                                .BackColor = Color.LightSkyBlue
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With tipoCell.ActiveAppearance
                                .BackColor = Color.LightSkyBlue
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With tipoCell.SelectedAppearance
                                .BackColor = Color.LightSkyBlue
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With

                        Case "RETORNO"
                            With tipoCell.Appearance
                                .BackColor = Color.LightSalmon
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With tipoCell.ActiveAppearance
                                .BackColor = Color.LightSalmon
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With tipoCell.SelectedAppearance
                                .BackColor = Color.LightSalmon
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                    End Select
                Next
            Next

            With dtgListado.DisplayLayout.Bands(1)
                .Columns("Recepción").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Tipo Movimiento").CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        If e.Row.Band.Index = 0 And Not ChkVisualizarApartadoChanchilla.Checked Then
            Dim colVerPDF As Infragistics.Win.UltraWinGrid.UltraGridColumn
            If dtgListado.DisplayLayout.Bands(0).Columns.Exists("Información") Then
                colVerPDF = dtgListado.DisplayLayout.Bands(0).Columns("Información")
                colVerPDF.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerPDF.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                If Not e.ReInitialize Then
                    e.Row.Cells("Información").Value = "Información"
                    e.Row.Cells("Información").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                End If
            End If
        End If

        If e.Row.Band.Index = 1 Then
            e.Row.Cells("Más (+)").Value = "[+]"
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count > 0) Then
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 1)
                If Not ChkVisualizarApartadoChanchilla.Checked Then
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 3)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 4)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 8)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 9)
                    clsBasicas.SumarTotales_Formato(dtgListado, e, 10)
                End If
            End If

            If Not ChkVisualizarApartadoChanchilla.Checked Then
                With e.Layout.Bands(1)
                    .Columns("Más (+)").Style = UltraWinGrid.ColumnStyle.Button
                    .Columns("Más (+)").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                    .Columns("Más (+)").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                    .Columns("Más (+)").Width = 80
                End With
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            If Not ChkVisualizarApartadoChanchilla.Checked Then
                With dtgListado
                    If (e.Cell.Column.Key = "Información") Then
                        Dim frm As New FrmInformacionDepuracionMadreFutura
                        frm.idLote = .ActiveRow.Cells("idLote").Value.ToString
                        frm.valorLote = .ActiveRow.Cells("Lote").Value.ToString
                        frm.valorPlantel = .ActiveRow.Cells("Plantel").Value.ToString
                        frm.idPlantel = .ActiveRow.Cells("idPlantel").Value.ToString
                        frm.ShowDialog()
                        Consultar1()
                    End If

                    If (e.Cell.Column.Key = "Más (+)") Then
                        Dim frm As New FrmDetalleRetornoxLote
                        frm.idRetorno = CInt(.ActiveRow.Cells("idMovimientoBajada").Value)
                        frm.ShowDialog()
                    End If
                End With
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnUbicarCerdas_Click(sender As Object, e As EventArgs) Handles BtnUbicarCerdasprocontrolmadresfuturas.Click
        If ChkVisualizarApartadoChanchilla.Checked Then
            msj_advert("Para ubicar animales, debe salir del apartado de chanchillas")
            Return
        End If

        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim idPlantelValue As Integer = CInt(activeRow.Cells("idPlantel").Value)
                    Dim cerdosTransito As Integer = CInt(activeRow.Cells("Cerdos Transito").Value)

                    Dim frm As New FrmGestionarUbicacionMadreFutura With {
                        .idUbicacion = CmbUbicacion.Value,
                        .idLote = activeRow.Cells("idLote").Value,
                        .idPlantelOrigen = idPlantelValue,
                        .cantidadCerdasOriginal = activeRow.Cells("Total Animales").Value,
                        .cantidadCerdas = activeRow.Cells("Total Animales").Value,
                        .cerdosTransito = cerdosTransito
                    }
                    frm.ShowDialog()
                    Consultar1()
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

    Private Sub BtnDepurarCerda_Click(sender As Object, e As EventArgs) Handles BtnDepurarCerdaprocontrolmadresfuturas.Click
        If ChkVisualizarApartadoChanchilla.Checked Then
            msj_advert("Para depurar cerdas, debe salir del apartado de chanchillas")
            Return
        End If

        Dim activeRow As UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim totalAnimales As Integer = CInt(activeRow.Cells("Total Animales").Value)

                    If totalAnimales = 0 Then
                        msj_advert("No hay animales para depurar en este lote")
                        Return
                    End If

                    Dim frm As New FrmPrimerFiltroCerda With {
                        .idLote = CInt(activeRow.Cells("idLote").Value),
                        .valorLote = activeRow.Cells("Lote").Value.ToString,
                        .valorPlantel = activeRow.Cells("Plantel").Value.ToString,
                        .idPlantel = activeRow.Cells("idPlantel").Value,
                        .numFiltroDescarte = 2
                    }
                    frm.ShowDialog()
                    Consultar1()
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

    Private Sub BtnCodificarMadreFutura_Click(sender As Object, e As EventArgs) Handles BtnCodificarMadreFuturaprocontrolmadresfuturas.Click
        Try
            If ChkVisualizarApartadoChanchilla.Checked Then
                msj_advert("Para codificar cerdas, debe salir del apartado de chanchillas")
                Return
            End If

            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim totalAnimales As Integer = CInt(activeRow.Cells("Total Animales").Value)

                        If totalAnimales = 0 Then
                            msj_advert("No hay animales para codificar en este lote")
                            Return
                        End If

                        Dim frm As New FrmCodificarMasivo With {
                            .IdLote = CInt(activeRow.Cells("idLote").Value),
                            .IdPlantel = CmbUbicacion.Value
                        }
                        frm.ShowDialog()
                        Consultar1()
                    Else
                        msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
                    End If
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

    Private Sub BtnMortalidadCamalMadreFutura_Click(sender As Object, e As EventArgs) Handles BtnMortalidadCamalMadreFuturaprocontrolmadresfuturas.Click
        Try
            If ChkVisualizarApartadoChanchilla.Checked Then
                msj_advert("Para registrar mortalidad o envío a camal, debe salir del apartado de chanchillas")
                Return
            End If

            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim totalAnimales As Integer = CInt(activeRow.Cells("Total Animales").Value)

                        If totalAnimales = 0 Then
                            msj_advert("No hay animales para registrar mortalidad o envio a camal en este lote")
                            Return
                        End If

                        Dim frm As New FrmMandarCamalMortalidadMadreFutura With {
                            .valorPlantel = CmbUbicacion.Text,
                            .valorLote = activeRow.Cells("Lote").Value.ToString,
                            .idPlantel = CmbUbicacion.Value,
                            .idLote = CInt(dtgListado.ActiveRow.Cells("idLote").Value)
                        }
                        frm.ShowDialog()
                        Consultar1()
                    Else
                        msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
                    End If
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

    Private Sub BtnConfirmarLlegada_Click(sender As Object, e As EventArgs) Handles BtnConfirmarLlegada.Click
        Try
            If ChkVisualizarApartadoChanchilla.Checked Then
                msj_advert("Para confirmar llegada, debe salir del apartado de chanchillas")
                Return
            End If

            Dim filaSeleccionada As UltraGridRow = dtgListado.ActiveRow

            If filaSeleccionada Is Nothing Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Exit Sub
            End If

            If Not filaSeleccionada.IsDataRow Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            ElseIf filaSeleccionada.Band.Index = 0 Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILAS_CONTENIDAS"))
            Else

                Dim idLote As Integer = CInt(filaSeleccionada.Cells("idLote").Value)
                Dim idMovimientoBajada As Integer = CInt(filaSeleccionada.Cells("idMovimientoBajada").Value)
                Dim plantelSalida As String = filaSeleccionada.Cells("Plantel Salida").Text
                Dim idUbicacionSalida As String = CInt(filaSeleccionada.Cells("idUbicacionSalida").Value)
                Dim idUbicacionLlegada As String = CInt(filaSeleccionada.Cells("idUbicacionLlegada").Value)
                Dim recepcion As String = filaSeleccionada.Cells("Recepción").Text

                If recepcion = "SI" Then
                    msj_advert("No se puede confirmar la bajada, porque ya fue confirmada")
                    Return
                End If

                Dim frm As New FrmMortalidadTransporteRetorno With {
                    .idLote = idLote,
                    .idPlantel = idUbicacionLlegada,
                    .valorPlantelSalida = plantelSalida,
                    .codigo = idMovimientoBajada
                }
                frm.ShowDialog()
                Consultar1()
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCancelarConfirmacion_Click(sender As Object, e As EventArgs) Handles BtnCancelarConfirmacion.Click
        Try
            If ChkVisualizarApartadoChanchilla.Checked Then
                msj_advert("Para cancelar llegada, debe salir del apartado de chanchillas")
                Return
            End If

            Dim filaSeleccionada As UltraGridRow = dtgListado.ActiveRow

            If filaSeleccionada Is Nothing Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Exit Sub
            End If

            If Not filaSeleccionada.IsDataRow Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            ElseIf filaSeleccionada.Band.Index = 0 Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILAS_CONTENIDAS"))
            Else
                Dim recepcion As String = filaSeleccionada.Cells("Recepción").Text
                Dim idUbicacionLlegada As String = CInt(filaSeleccionada.Cells("idUbicacionLlegada").Value)
                Dim idMovimientoBajada As Integer = CInt(filaSeleccionada.Cells("idMovimientoBajada").Value)

                If recepcion = "NO" Then
                    msj_advert("No se puede cancelar la confirmación. Aún no se ha confirmado la recepción de la bajada")
                    Return
                End If

                If (MessageBox.Show("¿ESTÁ SEGURO QUE DESEA CANCELAR LA CONFIRMACIÓN DE LLEGADA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim obj As New coControlLoteDestete With {
                    .IdMovimientoBajada = idMovimientoBajada,
                    .IdPlantel = idUbicacionLlegada
                }

                Dim MensajeBgWk As String = cn.Cn_CancelarConfirmacionRetorno(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Consultar1()
                Else
                    msj_advert(MensajeBgWk)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCancelarRetorno_Click(sender As Object, e As EventArgs) Handles BtnCancelarRetorno.Click
        Try
            If ChkVisualizarApartadoChanchilla.Checked Then
                msj_advert("Para cancelar envio de animales, debe salir del apartado de chanchillas")
                Return
            End If

            Dim filaSeleccionada As UltraGridRow = dtgListado.ActiveRow

            If filaSeleccionada Is Nothing Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Exit Sub
            End If

            If Not filaSeleccionada.IsDataRow Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            ElseIf filaSeleccionada.Band.Index = 0 Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILAS_CONTENIDAS"))
            Else
                Dim idUbicacionSalida As String = CInt(filaSeleccionada.Cells("idUbicacionSalida").Value)
                Dim idMovimientoBajada As Integer = CInt(filaSeleccionada.Cells("idMovimientoBajada").Value)
                Dim idLote As Integer = CInt(filaSeleccionada.Cells("idLote").Value)

                If (MessageBox.Show("¿ESTÁ SEGURO QUE DESEA CANCELAR LA LLEGADA DE CHANCHILLAS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim obj As New coControlLoteDestete With {
                    .IdLote = idLote,
                    .IdPlantel = idUbicacionSalida,
                    .IdMovimientoBajada = idMovimientoBajada
                }

                Dim MensajeBgWk As String = cn.Cn_CancelarRetorno(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Consultar1()
                Else
                    msj_advert(MensajeBgWk)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportarControlCerda_Click(sender As Object, e As EventArgs) Handles BtnExportarControlCerdaprocontrolmadresfuturas.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL DE CERDAS DE RETORNO MADRE FUTURA", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnHistorialMortalidad_Click(sender As Object, e As EventArgs) Handles BtnHistorialMortalidad.Click
        If ChkVisualizarApartadoChanchilla.Checked Then
            msj_advert("Para visualizar historial de mortalidad, debe salir del apartado de chanchillas")
            Return
        End If

        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then

                    Dim frm As New FrmHistorialMortalidadLote With {
                        .idLote = CInt(activeRow.Cells("idLote").Value),
                        .idPlantel = CInt(activeRow.Cells("idPlantel").Value)
                    }
                    frm.ShowDialog()
                    Consultar1()
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

    Private Sub ChkVisualizarApartadoChanchilla_CheckedChanged(sender As Object, e As EventArgs) Handles ChkVisualizarApartadoChanchilla.CheckedChanged
        If ChkVisualizarApartadoChanchilla.Checked Then
            BtnConfirmarLlegada.Visible = False
            BtnCancelarConfirmacion.Visible = False
            BtnCancelarRetorno.Visible = False
            BtnUbicarCerdasprocontrolmadresfuturas.Visible = False
            BtnDepurarCerdaprocontrolmadresfuturas.Visible = False
            BtnMortalidadCamalMadreFuturaprocontrolmadresfuturas.Visible = False
            BtnHistorialMortalidad.Visible = False
            BtnCodificarMadreFuturaprocontrolmadresfuturas.Visible = False
            BtnMovimientoAnimal.Visible = False
            CmbAnios.Visible = False
            LblAnios.Visible = False
            CmbEstadoVivo.Visible = True
            LblEstado.Visible = True
            BtnMortalidadAnimal.Visible = True
            BtnMandarCamalprocontrolcerdos.Visible = True
            BtnActualizarDatosprocontrolcerdos.Visible = True
            Consultar2()
        Else
            BtnConfirmarLlegada.Visible = True
            BtnCancelarConfirmacion.Visible = True
            BtnCancelarRetorno.Visible = True
            BtnUbicarCerdasprocontrolmadresfuturas.Visible = True
            BtnDepurarCerdaprocontrolmadresfuturas.Visible = True
            BtnMortalidadCamalMadreFuturaprocontrolmadresfuturas.Visible = True
            BtnHistorialMortalidad.Visible = True
            BtnCodificarMadreFuturaprocontrolmadresfuturas.Visible = True
            BtnMovimientoAnimal.Visible = True
            CmbAnios.Visible = True
            LblAnios.Visible = True
            CmbEstadoVivo.Visible = False
            LblEstado.Visible = False
            BtnMortalidadAnimal.Visible = False
            BtnMandarCamalprocontrolcerdos.Visible = False
            BtnActualizarDatosprocontrolcerdos.Visible = False
            Consultar1()
        End If
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        If ChkVisualizarApartadoChanchilla.Checked Then
            Consultar2()
        Else
            Consultar1()
        End If
    End Sub

    Private Sub BtnMortalidadAnimal_Click(sender As Object, e As EventArgs) Handles BtnMortalidadAnimal.Click
        If Not ChkVisualizarApartadoChanchilla.Checked Then
            msj_advert("Debe estar en el apartado de chanchillas")
            Return
        End If

        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim estado As String = activeRow.Cells("Condición").Value.ToString()

                    If estado = "MUERTO" Then
                        msj_advert("La cerda ya está registrada como muerta")
                        Exit Sub
                    End If

                    Dim frm As New FrmMortalidadCerda With {
                        .idAnimal = activeRow.Cells(0).Value,
                        .arete = activeRow.Cells(1).Value.ToString()
                    }
                    frm.ShowDialog()
                    Consultar2()
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

    Private Sub BtnMandarCamalprocontrolcerdos_Click(sender As Object, e As EventArgs) Handles BtnMandarCamalprocontrolcerdos.Click
        If Not ChkVisualizarApartadoChanchilla.Checked Then
            msj_advert("Debe estar en el apartado de chanchillas")
            Return
        End If

        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim estadoVivo As String = activeRow.Cells("Condición").Value.ToString
                    Dim estadoCamal As String = activeRow.Cells("Envio Camal").Value
                    Dim clasificacion As String = activeRow.Cells("Clasificación").Value

                    If (estadoVivo = "MUERTO") Then
                        msj_advert("NO SE PUEDE ACTUALIZAR LOS DATOS DE UNA CERDA MUERTA")
                        Exit Sub
                    End If

                    If (estadoCamal = "ENVIADO") Then
                        msj_advert("La cerda ya fue enviada al camal")
                        Exit Sub
                    End If

                    Dim frm As New FrmMandarCamalAnimal With {
                        .idAnimal = dtgListado.ActiveRow.Cells(0).Value,
                        .arete = activeRow.Cells(1).Value.ToString(),
                        .clasificacion = clasificacion
                    }
                    frm.ShowDialog()
                    Consultar2()
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

    Private Sub BtnActualizarDatosprocontrolcerdos_Click(sender As Object, e As EventArgs) Handles BtnActualizarDatosprocontrolcerdos.Click
        If Not ChkVisualizarApartadoChanchilla.Checked Then
            msj_advert("Debe estar en el apartado de chanchillas")
            Return
        End If

        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim estadoVivo As String = activeRow.Cells("Condición").Value.ToString
                    Dim sexo As String = activeRow.Cells("Sexo").Value.ToString

                    If (estadoVivo = "MUERTO") Then
                        msj_advert("NO SE PUEDE ACTUALIZAR LOS DATOS DE UNA CERDA MUERTA")
                        Exit Sub
                    End If

                    If sexo = "MACHO" Then
                        Dim frm As New FrmActualizarDatosVerraco With {
                            .idVerraco = activeRow.Cells(0).Value
                        }
                        frm.ShowDialog()
                    Else
                        Dim frm As New FrmActualizarDatosCerda With {
                            .idCerda = activeRow.Cells(0).Value,
                            .diasVida = activeRow.Cells("Edad").Value,
                            .etapaReproductiva = "NO INICIADO"
                        }
                        frm.ShowDialog()
                    End If

                    Consultar2()
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

    Private Sub FrmControlMadreFutura_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnBuscar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BtnMovimientoAnimal_Click(sender As Object, e As EventArgs) Handles BtnMovimientoAnimal.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim numPuras As Integer = CInt(activeRow.Cells("Total Animales").Value)

                    If numPuras = 0 Then
                        msj_advert("No hay animales para hacer movimiento en este lote")
                        Return
                    End If

                    Dim frm As New FrmMovimientoChanchillaLote With {
                        .valorLote = activeRow.Cells("Lote").Value.ToString,
                        .idLote = CInt(activeRow.Cells("idLote").Value),
                        .idPlantel = CInt(activeRow.Cells("idPlantel").Value),
                        .valorUbicacion = CmbUbicacion.Text
                    }
                    frm.ShowDialog()
                    Consultar1()
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
End Class