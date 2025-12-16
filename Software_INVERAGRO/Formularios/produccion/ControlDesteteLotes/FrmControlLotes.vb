Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlLotes
    Dim cn As New cnControlLoteDestete
    Dim ds As New DataSet
    Dim flag As Boolean = False

    Private Sub FrmControlLotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
            Consultar()
        Catch ex As Exception
            msj_advert(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        GrupoFiltros.Enabled = False
        BarraNavegacion.Enabled = False
        btnBuscar.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        GrupoFiltros.Enabled = True
        BarraNavegacion.Enabled = True
        btnBuscar.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()
            flag = True

            Dim obj As New coControlLoteDestete With {
                .Anio = CInt(CmbAnios.Text),
                .IdPlantel = CmbUbicacion.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
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
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)

            ds = cn.Cn_ConsultarLotesxAnio(obj).Copy
            ds.DataSetName = "tmp"
            'ds.Tables(0).Columns("idLote").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("idPlantel").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("Día Actual").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("Fecha Apertura").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("Fecha Cierre").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("estadoDestete").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("Plantel").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("idCampaña").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("Estado").ColumnMapping = MappingType.Hidden
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
            DesbloquearControladores()

            If CmbUbicacion.Value = 1 Or CmbUbicacion.Value = 2 Then
                dtgListado.DisplayLayout.Bands(0).Columns("Estado Venta").Hidden = True
                dtgListado.DisplayLayout.Bands(0).Columns("Campaña").Hidden = True
                dtgListado.DisplayLayout.Bands(0).Columns("P. Salida").Hidden = True
                dtgListado.DisplayLayout.Bands(0).Columns("Cerdos Transito").Hidden = True
                dtgListado.DisplayLayout.Bands(0).Columns("Total Destetados").Hidden = False
                BtnVentaLotecontrollotespro.Visible = False
                BtnCancelarVenta.Visible = False
                BtnPesos.Visible = True
                BtnCodificarMadreFutura.Visible = True
            Else
                dtgListado.DisplayLayout.Bands(0).Columns("Estado Venta").Hidden = False
                dtgListado.DisplayLayout.Bands(0).Columns("P. Salida").Hidden = False
                dtgListado.DisplayLayout.Bands(0).Columns("Cerdos Transito").Hidden = False
                dtgListado.DisplayLayout.Bands(0).Columns("Total Destetados").Hidden = True
                BtnVentaLotecontrollotespro.Visible = True
                BtnCancelarVenta.Visible = True
                BtnPesos.Visible = True
                BtnCodificarMadreFutura.Visible = False
            End If

            If ds.Tables(0).Rows.Count <> 0 Then
                If CmbUbicacion.Value <> 1 Or CmbUbicacion.Value <> 2 Then
                    LblDiaPic.Text = "DÍA PIC: " & ds.Tables(0).Rows(0)("Día Actual").ToString()
                End If
            End If
            Colorear()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If flag Then
            Consultar()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estado As Integer = 14
            Dim estadoVenta As Integer = 18
            Dim estadoBajada As Integer = 21

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "CERRADO", estado)

            'estadoVenta
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estadoVenta)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightYellow, Color.Black, "PARCIAL", estadoVenta)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "EN VENTA", estadoVenta)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "VENDIDO", estadoVenta)

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "REALIZADO", estadoBajada)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estadoBajada)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoVenta).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoBajada).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub BtnRegistrarBajada_Click(sender As Object, e As EventArgs) Handles BtnRegistrarBajadacontrollotespro.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim estadoBajada As String = activeRow.Cells("Estado Bajada").Value.ToString
                    Dim estadoDestete As String = activeRow.Cells("estadoDestete").Value.ToString
                    Dim totalAnimales As Integer = CInt(activeRow.Cells("Total Animales").Value)
                    Dim totalDestetados As Integer = CInt(activeRow.Cells("Total Destetados").Value)

                    If totalAnimales = 0 Then
                        msj_advert("No se puede registrar la bajada de un lote que no tiene animales")
                        Return
                    End If

                    If estadoDestete = "PENDIENTE" Then
                        msj_advert("No se puede registrar la bajada de un lote que no ha sido destetado")
                        Return
                    End If

                    If estadoBajada = "REALIZADO" Then
                        msj_advert("No se puede registrar la bajada de un lote que ya ha sido enviado")
                        Return
                    End If

                    If totalAnimales <> totalDestetados Then
                        msj_advert("Para realizar la bajada todos los animales deben estar destetados")
                        Return
                    End If

                    Dim frm As New FrmRegistrarBajada With {
                        .idLote = CInt(activeRow.Cells("idLote").Value),
                        .nombreLote = activeRow.Cells("Lote").Value.ToString,
                        .numPuras = CInt(activeRow.Cells("Total Puras").Value),
                        .numChanchillas = CInt(activeRow.Cells("Total Camborough").Value),
                        .numEngorde = CInt(activeRow.Cells("Total Engorde").Value),
                        .edadLote = CInt(activeRow.Cells("Edad").Value),
                        .idPlantelSalida = CInt(activeRow.Cells("idPlantel").Value)
                    }
                    frm.ShowDialog()
                    Consultar()
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

    Private Sub BtnMandarCamalMortalidadLote_Click(sender As Object, e As EventArgs) Handles BtnMandarCamalMortalidadLotecontrollotespro.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim numCriasDestetadas As Integer = CInt(activeRow.Cells("Total Destetados").Value)
                    Dim estadoBajada As String = activeRow.Cells("Estado Bajada").Value.ToString

                    If numCriasDestetadas = 0 And estadoBajada = "ENVIADO" Then
                        msj_advert("Primero ubique los animales")
                        Return
                    End If

                    If numCriasDestetadas = 0 Then
                        msj_advert("No se puede registrar la mortalidad o envios a camal de un lote que no tiene animales destetados")
                        Return
                    End If

                    Dim frm As New FrmRegistrarMandarCamalMortalidadLote With {
                        .valorPlantel = activeRow.Cells("Plantel").Value.ToString,
                        .valorLote = activeRow.Cells("Lote").Value.ToString,
                        .idPlantel = CmbUbicacion.Value,
                        .idLoteOriginal = CInt(dtgListado.ActiveRow.Cells("idLote").Value),
                        .habilitarOpcionChanchilla = If(CmbUbicacion.Value = 1 Or CmbUbicacion.Value = 2, True, False)
                    }
                    frm.ShowDialog()
                    Consultar()
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

    Private Sub BtnMandarCamal_Click(sender As Object, e As EventArgs)
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then

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

    Private Sub BtnExportarControlCerda_Click(sender As Object, e As EventArgs) Handles BtnExportarControlCerdacontrollotespro.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REGISTRO DE LOTES", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnAjustarDistribucionCerdo_Click(sender As Object, e As EventArgs) Handles BtnAjustarDistribucionCerdocontrollotespro.Click
        Try
            Dim activeRow As UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim totalDestetados As Integer = CInt(activeRow.Cells("Total Destetados").Value)

                        If totalDestetados = 0 Then
                            msj_advert("No se puede ajustar la distribución de un lote que no tiene animales destetados")
                            Return
                        End If

                        Dim frm As New FrmAjustarDistribucionCerdo With {
                            .idLote = CInt(dtgListado.ActiveRow.Cells("idLote").Value),
                            .valorPlantel = activeRow.Cells("Plantel").Value.ToString,
                            .valorLote = activeRow.Cells("Lote").Value.ToString,
                            .idPlantel = CmbUbicacion.Value
                        }
                        frm.ShowDialog()
                        Consultar()
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

    Private Sub BtnCambiarUbicacion_Click(sender As Object, e As EventArgs) Handles BtnCambiarUbicacioncontrollotespro.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim totalCriasValor As Integer = CInt(activeRow.Cells("Total Destetados").Value)
                    Dim cerdosTransito As Integer = CInt(activeRow.Cells("Cerdos Transito").Value)

                    Dim frm As New FrmRegMovimientoUbicacionLote With {
                        .idLote = CInt(activeRow.Cells("idLote").Value),
                        .idPlantel = CInt(activeRow.Cells("idPlantel").Value),
                        .cantidadCrias = totalCriasValor,
                        .cantidadCriasOriginal = totalCriasValor,
                        .estadoBajada = activeRow.Cells("Estado Bajada").Value.ToString,
                        .cerdosTransito = cerdosTransito
                    }
                    frm.ShowDialog()
                    Consultar()
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

    Private Sub BtnVentaLote_Click(sender As Object, e As EventArgs) Handles BtnVentaLotecontrollotespro.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim edad As String = activeRow.Cells("Edad").Value.ToString
                        Dim numAnimales As Integer = CInt(activeRow.Cells("Total Animales").Value)
                        Dim estadoBajada As String = activeRow.Cells("Estado Bajada").Value.ToString
                        Dim idLote As Integer = CInt(activeRow.Cells("idLote").Value)
                        Dim idPlantel As Integer = CInt(activeRow.Cells("idPlantel").Value)
                        Dim estadoVenta As String = activeRow.Cells("Estado Venta").Value.ToString

                        If estadoVenta = "VENDIDO" Then
                            msj_advert("Este lote ya fue vendido")
                            Return
                        End If

                        If estadoVenta = "EN VENTA" Then
                            msj_advert("Este lote ya se encuentra en venta")
                            Return
                        End If

                        If numAnimales = 0 Then
                            msj_advert("No se puede enviar a venta un lote que no tiene animales")
                            Return
                        End If

                        If estadoBajada = "PENDIENTE" Then
                            msj_advert("No se puede enviar a venta un lote que no ha sido bajado")
                            Return
                        End If

                        If edad < 148 Then
                            If (MessageBox.Show("LOS CERDOS NO CUMPLEN CON EDAD DE 148 ¿ESTÁ SEGURO DE ENVIAR CERDOS A VENTA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                                Return
                            End If
                        Else
                            If (MessageBox.Show("¿ESTÁ SEGURO PONER EN VENTA ESTE LOTE?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                                Return
                            End If
                        End If

                        Dim obj As New coControlLoteDestete With {
                            .IdLote = idLote,
                            .IdPlantel = idPlantel,
                            .IdUsuario = VP_IdUser
                        }

                        Dim MensajeBgWk As String = cn.Cn_RegistrarVentaLote(obj)

                        If (obj.Coderror = 0) Then
                            msj_ok(MensajeBgWk)
                            Consultar()
                        Else
                            msj_advert(MensajeBgWk)
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
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCancelarVenta_Click(sender As Object, e As EventArgs) Handles BtnCancelarVenta.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim idLote As Integer = CInt(activeRow.Cells("idLote").Value)
                        Dim idPlantel As Integer = CInt(activeRow.Cells("idPlantel").Value)
                        Dim estadoVenta As String = activeRow.Cells("Estado Venta").Value.ToString

                        If estadoVenta = "VENDIDO" Then
                            msj_advert("Este lote ya fue vendido en su totalidad")
                            Return
                        End If

                        If estadoVenta <> "EN VENTA" Then
                            msj_advert("No se puede cancelar la venta de un lote que no ha sido enviado")
                            Return
                        End If

                        If (MessageBox.Show("¿ESTÁ SEGURO DE CANCELAR LA VENTA DE ESTE LOTE?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                            Return
                        End If

                        Dim obj As New coControlLoteDestete With {
                            .IdLote = idLote,
                            .IdPlantel = idPlantel
                        }

                        Dim MensajeBgWk As String = cn.Cn_CancelarVentaLote(obj)

                        If (obj.Coderror = 0) Then
                            msj_ok(MensajeBgWk)
                            Consultar()
                        Else
                            msj_advert(MensajeBgWk)
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
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnClinica_Click(sender As Object, e As EventArgs) Handles BtnClinica.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                Dim estadoBajada As String = activeRow.Cells("Estado Bajada").Value.ToString

                If estadoBajada = "ENVIADO" Then
                    msj_advert("No se puede mandar a clinica un lote que ya fue enviado a bajada")
                    Return
                End If

                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim frm As New FrmRegIngresoSalidaClinica With {
                        .idLote = CInt(activeRow.Cells("idLote").Value),
                        .idPlantel = CInt(activeRow.Cells("idPlantel").Value),
                        .valorPlantel = activeRow.Cells("Plantel").Value,
                        .valorLote = activeRow.Cells("Lote").Value
                    }
                    frm.ShowDialog()
                    Consultar()
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

    Private Sub BtnDepurar_Click(sender As Object, e As EventArgs) Handles BtnDepurar.Click
        Try
            Dim activeRow As UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim numPuras As Integer = CInt(activeRow.Cells("Total Puras").Value)
                    Dim numCamborough As Integer = CInt(activeRow.Cells("Total Camborough").Value)

                    If numPuras = 0 AndAlso numCamborough = 0 Then
                        msj_advert("No hay cerdas para depurar en este lote")
                        Return
                    End If

                    Dim frm As New FrmPrimerFiltroCerda With {
                            .idLote = CInt(activeRow.Cells("idLote").Value),
                            .valorLote = activeRow.Cells("Lote").Value.ToString,
                            .valorPlantel = activeRow.Cells("Plantel").Value.ToString,
                            .idPlantel = CmbUbicacion.Value,
                            .numFiltroDescarte = 1
                        }
                    frm.ShowDialog()
                    Consultar()
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

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                clsBasicas.Totales_Formato(dtgListado, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 8)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 9)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 10)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 11)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        If e.Row.Band.Index = 0 Then
            Dim colVerInformacion As Infragistics.Win.UltraWinGrid.UltraGridColumn

            If dtgListado.DisplayLayout.Bands(0).Columns.Exists("Información") Then
                colVerInformacion = dtgListado.DisplayLayout.Bands(0).Columns("Información")
                colVerInformacion.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerInformacion.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                If Not e.ReInitialize Then
                    e.Row.Cells("Información").Value = "Depuraciones"
                    e.Row.Cells("Información").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                End If
            End If

            If dtgListado.DisplayLayout.Bands(0).Columns.Exists("Hist. Mortalidad") Then
                colVerInformacion = dtgListado.DisplayLayout.Bands(0).Columns("Hist. Mortalidad")
                colVerInformacion.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerInformacion.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                If Not e.ReInitialize Then
                    e.Row.Cells("Hist. Mortalidad").Value = "Mortalidad"
                    e.Row.Cells("Hist. Mortalidad").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                End If
            End If
        End If
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            With dtgListado
                If (e.Cell.Column.Key = "Información") Then
                    Dim frm As New FrmInformacionDepuracionMadreFutura
                    frm.idLote = .ActiveRow.Cells("idLote").Value.ToString
                    frm.valorLote = .ActiveRow.Cells("Lote").Value.ToString
                    frm.valorPlantel = .ActiveRow.Cells("Plantel").Value.ToString
                    frm.idPlantel = CmbUbicacion.Value
                    frm.ShowDialog()
                    Consultar()
                End If

                If (e.Cell.Column.Key = "Hist. Mortalidad") Then
                    Dim frm As New FrmHistorialMortalidadLote
                    frm.idLote = .ActiveRow.Cells("idLote").Value.ToString
                    frm.idPlantel = CmbUbicacion.Value
                    frm.ShowDialog()
                    Consultar()
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnReporteGeneral_Click(sender As Object, e As EventArgs) Handles BtnReporteGeneral.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim idPlantel As Integer = activeRow.Cells("idPlantel").Value

                    If idPlantel = 1 Or idPlantel = 2 Then
                        msj_advert("Este reporte esta diseñado para planteles de engorde")
                        Return
                    End If

                    Dim frm As New FrmReporteAnimalesPlantel With {
                        .idPlantel = idPlantel,
                        .idCampana = activeRow.Cells("idCampaña").Value
                    }
                    frm.ShowDialog()
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

    Private Sub BtnReportePesos_Click(sender As Object, e As EventArgs) Handles BtnReportePesos.Click
        Try
            Dim frm As New FrmReporteDespachoCerdoGranja With {
                .idUbicacion = CmbUbicacion.Value,
                .flag = True
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmControlLotes_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BtnUbicarZonaEspera_Click(sender As Object, e As EventArgs) Handles BtnUbicarZonaEspera.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim numAnimales As Integer = CInt(activeRow.Cells("Total Animales").Value)
                    Dim totalCriasValor As Integer = CInt(activeRow.Cells("Total Destetados").Value)

                    If numAnimales = 0 AndAlso totalCriasValor = 0 Then
                        msj_advert("No se puede ubicar un lote que no tiene animales")
                        Return
                    End If

                    Dim frm As New FrmUbicarAnimalesZonaEspera With {
                        .idPlantel = CmbUbicacion.Value,
                        .idLote = CInt(activeRow.Cells("idLote").Value)
                    }
                    frm.ShowDialog()
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

    Private Sub ReporteDistribuciónDeCerdosXCorralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDistribuciónDeCerdosXCorralToolStripMenuItem.Click
        Try
            Dim frm As New FrmDistribucionLotesxCorral With {
                .idPlantel = CmbUbicacion.Value
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ReporteDeConsumoYDonacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeConsumoYDonacionesToolStripMenuItem.Click
        Try
            Dim frm As New FrmReporteConsumoDonacion
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub MortalidadRecríaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MortalidadRecríaToolStripMenuItem.Click
        Try
            Dim frm As New FrmReporteMortalidadRecriaEngorde With {
               .idUbicacion = CmbUbicacion.Value
           }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub HistorialLoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialLoteToolStripMenuItem.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim frm As New FrmHistorialLote With {
                        .idLote = activeRow.Cells("idLote").Value,
                        .idUbicacion = activeRow.Cells("idPlantel").Value
                    }
                    frm.ShowDialog()
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

    Private Sub BtnPesosChanchillas_Click(sender As Object, e As EventArgs) Handles BtnPesosChanchillas.Click
        Try
            Dim activeRow As UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim numPuras As Integer = CInt(activeRow.Cells("Total Puras").Value)
                    Dim numCamborough As Integer = CInt(activeRow.Cells("Total Camborough").Value)

                    If numPuras = 0 AndAlso numCamborough = 0 Then
                        msj_advert("No hay chanchillas para registrar pesos en este lote")
                        Return
                    End If

                    Dim frm As New FrmRegistrarPesosChanchillas With {
                        .idLote = CInt(activeRow.Cells("idLote").Value),
                        .valorLote = activeRow.Cells("Lote").Value.ToString(),
                        .numChanchillas = numPuras + numCamborough
                    }
                    frm.ShowDialog()
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

    Private Sub BtnPesosBajadas_Click(sender As Object, e As EventArgs) Handles BtnPesosBajadas.Click
        Try
            Dim activeRow As UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim totalEngorde As Integer = CInt(activeRow.Cells("Total Engorde").Value)

                    Dim frm As New FrmRegistrarPesosBajada With {
                        .idLote = CInt(activeRow.Cells("idLote").Value),
                        .valorLote = activeRow.Cells("Lote").Value.ToString(),
                        .totalEngorde = totalEngorde
                    }
                    frm.ShowDialog()
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

    Private Sub BtnMoverChanchillas_Click(sender As Object, e As EventArgs) Handles BtnMoverChanchillas.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim totaPuras As Integer = CInt(activeRow.Cells("Total Puras").Value)
                    Dim totalCamborough As Integer = CInt(activeRow.Cells("Total Camborough").Value)

                    If totaPuras = 0 AndAlso totalCamborough = 0 Then
                        msj_advert("No hay chanchillas para mover en este lote")
                        Return
                    End If

                    Dim frm As New FrmMovimientoAmbienteChanchillas With {
                        .idPlantel = CInt(activeRow.Cells("idPlantel").Value),
                        .cantidadCrias = totaPuras + totalCamborough,
                        .cantidadCriasOriginal = totaPuras + totalCamborough,
                        .idLote = CInt(activeRow.Cells("idLote").Value)
                    }
                    frm.ShowDialog()
                    Consultar()
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

    Private Sub BtnReporteMortalidadLote_Click(sender As Object, e As EventArgs) Handles BtnReporteMortalidadLote.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim frm As New FrmReporteMortalidadPlantelLoteEdad With {
                        .idPlantel = CmbUbicacion.Value,
                        .idLote = activeRow.Cells("idLote").Value
                    }
                    frm.ShowDialog()
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

    Private Sub BtnCodificarMadreFutura_Click(sender As Object, e As EventArgs) Handles BtnCodificarMadreFutura.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim totaPuras As Integer = CInt(activeRow.Cells("Total Puras").Value)
                        Dim totalCamborough As Integer = CInt(activeRow.Cells("Total Camborough").Value)

                        If totaPuras = 0 AndAlso totalCamborough = 0 Then
                            msj_advert("No hay chanchillas para codificar en este lote")
                            Return
                        End If

                        Dim frm As New FrmCodificarMasivo With {
                            .IdLote = CInt(activeRow.Cells("idLote").Value),
                            .IdPlantel = CmbUbicacion.Value,
                            .chanchillasSinBajada = "SI"
                        }
                        frm.ShowDialog()
                        Consultar()
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
End Class