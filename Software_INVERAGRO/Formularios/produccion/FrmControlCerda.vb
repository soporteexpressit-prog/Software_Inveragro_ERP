Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlCerda
    Dim cn As New cnControlAnimal
    Dim tbtmp As New DataTable

    Private Sub FrmControlCerda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
            CmbUbicacion.Value = VariablesGlobales.idPlantelGlobal
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        Ptbx_Cargando.Visible = True
        clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListado)
        CmbEstadoVivo.SelectedIndex = 0
        CmbEstadoVenta.SelectedIndex = 0
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

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        GrupoFiltros.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        GrupoFiltros.Enabled = True
        ToolStrip1.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlAnimal With {
                .EstadoVivo = CmbEstadoVivo.Text,
                .EstadoVenta = CmbEstadoVenta.Text,
                .IdPlantel = CmbUbicacion.Value,
                .Filtro = If(CbxSinCelo.Checked, "SI", "NO")
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            tbtmp = cn.Cn_ConsultarCerda(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DesbloquearControladores()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            dtgListado.DisplayLayout.Bands(0).Columns("idAnimal").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Tipo").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Repetidora").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Estado Venta").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Ubicación").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Arete Madre").Hidden = True
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim tipoAdquisicion As Integer = 10
            Dim estadoVivo As Integer = 13
            Dim condicionReproductiva As Integer = 14
            Dim etapaReproductiva As Integer = 15
            Dim estadoDisponibilidad As Integer = 16
            Dim estadoCamal As Integer = 17
            Dim estadoRepetidora As Integer = 18
            Dim estadoVenta As Integer = 19
            Dim comportamientoCamborough As Integer = 22

            'tipoAdquisicion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "GRANJA", tipoAdquisicion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightBlue, Color.Black, "COMPRADO", tipoAdquisicion)

            'estadoVivo
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "VIVO", estadoVivo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "MUERTO", estadoVivo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "VENDIDO", estadoVivo)

            'estadoVenta
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estadoVenta)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightBlue, Color.DarkBlue, "EN VENTA", estadoVenta)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "VENDIDO", estadoVenta)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "DESCARTE", estadoVenta)

            'condicionReproductiva
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "APTO", condicionReproductiva)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "NO APTO", condicionReproductiva)

            'etapaReproductiva
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Beige, Color.SaddleBrown, "NO INICIADO", etapaReproductiva)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.AntiqueWhite, Color.DarkOliveGreen, "GESTANTE", etapaReproductiva)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.MistyRose, Color.Maroon, "LACTANTE", etapaReproductiva)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Beige, Color.SaddleBrown, "VACÍA", etapaReproductiva)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "DESCARTE", etapaReproductiva)

            'estadoDisponibilidad
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Beige, Color.SaddleBrown, "EN PROCESO", estadoDisponibilidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "DISPONIBLE", estadoDisponibilidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "NO DISPONIBLE", estadoDisponibilidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Thistle, Color.DarkOrchid, "RECUPERACIÓN", estadoDisponibilidad)

            'estadoRepetidora
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.DarkRed, "REPETIDORA", estadoRepetidora)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.ForestGreen, "NO REPETIDORA", estadoRepetidora)

            'estadoCamal
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightSlateGray, Color.White, "ENVIADO", estadoCamal)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightSkyBlue, Color.MidnightBlue, "EN PRODUCCION", estadoCamal)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "DESCARTE", estadoCamal)

            'comportamientoCamborough
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "NO", comportamientoCamborough)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "SI", comportamientoCamborough)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(tipoAdquisicion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoVivo).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoVenta).CellAppearance.TextHAlign = HAlign.Center
                .Columns(condicionReproductiva).CellAppearance.TextHAlign = HAlign.Center
                .Columns(etapaReproductiva).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoDisponibilidad).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoRepetidora).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoCamal).CellAppearance.TextHAlign = HAlign.Center
                .Columns(comportamientoCamborough).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub BtnNuevaCerda_Click(sender As Object, e As EventArgs) Handles BtnNuevaCerdaprocontrolcerdos.Click
        Dim frm As New FrmMantenimientoCerda With {
            .idUbicacion = CmbUbicacion.Value
        }
        frm.ShowDialog()
        Consultar()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        CkbMostrarUbicacion.Checked = False
        CkbRepetidoras.Checked = False
        CkbEnVenta.Checked = False
        CkbMadre.Checked = False
        Consultar()
    End Sub

    Private Sub BtnActualizarDatos_Click(sender As Object, e As EventArgs) Handles BtnActualizarDatosprocontrolcerdos.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim estadoVivo As String = activeRow.Cells("Condición").Value.ToString
                    Dim etapaReproductiva As String = activeRow.Cells("Cond. Reproductiva").Value

                    If (estadoVivo = "MUERTO") Then
                        msj_advert("NO SE PUEDE ACTUALIZAR LOS DATOS DE UNA CERDA MUERTA")
                        Exit Sub
                    End If

                    Dim frm As New FrmActualizarDatosCerda With {
                        .idCerda = activeRow.Cells(0).Value,
                        .diasVida = activeRow.Cells("Edad").Value,
                        .etapaReproductiva = etapaReproductiva
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

    Private Sub CbxTipoAdquisicion_CheckedChanged(sender As Object, e As EventArgs) Handles CbxTipoAdquisicion.CheckedChanged
        If CbxTipoAdquisicion.Checked Then
            dtgListado.DisplayLayout.Bands(0).Columns("Tipo").Hidden = False
        Else
            dtgListado.DisplayLayout.Bands(0).Columns("Tipo").Hidden = True
        End If
    End Sub

    Private Sub CkbRepetidoras_CheckedChanged(sender As Object, e As EventArgs) Handles CkbRepetidoras.CheckedChanged
        If CkbRepetidoras.Checked Then
            dtgListado.DisplayLayout.Bands(0).Columns("Repetidora").Hidden = False
        Else
            dtgListado.DisplayLayout.Bands(0).Columns("Repetidora").Hidden = True
        End If
    End Sub

    Private Sub CkbEnVenta_CheckedChanged(sender As Object, e As EventArgs) Handles CkbEnVenta.CheckedChanged
        If CkbEnVenta.Checked Then
            dtgListado.DisplayLayout.Bands(0).Columns("Estado Venta").Hidden = False
        Else
            dtgListado.DisplayLayout.Bands(0).Columns("Estado Venta").Hidden = True
        End If
    End Sub

    Private Sub CkbMostrarUbicacion_CheckedChanged(sender As Object, e As EventArgs) Handles CkbMostrarUbicacion.CheckedChanged
        If CkbMostrarUbicacion.Checked Then
            dtgListado.DisplayLayout.Bands(0).Columns("Ubicación").Hidden = False
        Else
            dtgListado.DisplayLayout.Bands(0).Columns("Ubicación").Hidden = True
        End If
    End Sub

    Private Sub CkbMadre_CheckedChanged(sender As Object, e As EventArgs) Handles CkbMadre.CheckedChanged
        If CkbMadre.Checked Then
            dtgListado.DisplayLayout.Bands(0).Columns("Arete Madre").Hidden = False
        Else
            dtgListado.DisplayLayout.Bands(0).Columns("Arete Madre").Hidden = True
        End If
    End Sub

    Private Sub BtnHistorialCerda_Click(sender As Object, e As EventArgs) Handles BtnHistorialCerdaprocontrolcerdos.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim frm As New FrmFichaCicloVidaCerda With {
                        .idCerda = activeRow.Cells(0).Value
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

    Private Sub BtnMandarCamal_Click(sender As Object, e As EventArgs) Handles BtnMandarCamalprocontrolcerdos.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim estadoVivo As String = activeRow.Cells("Condición").Value.ToString
                    Dim estadoCamal As String = activeRow.Cells("Envio Camal").Value
                    Dim etapaReproductiva As String = activeRow.Cells("Etapa Reproducción").Value
                    Dim clasificacion As String = activeRow.Cells("Clasificación").Value

                    If (estadoVivo = "MUERTO") Then
                        msj_advert("NO SE PUEDE ACTUALIZAR LOS DATOS DE UNA CERDA MUERTA")
                        Exit Sub
                    End If

                    If (estadoCamal = "ENVIADO") Then
                        msj_advert("La cerda ya fue enviada al camal")
                        Exit Sub
                    End If

                    If etapaReproductiva.Contains("LACTANTE") Or etapaReproductiva.Contains("GESTANTE") Then
                        msj_advert("La cerda tiene que estar VACÍA para enviar a camal")
                        Exit Sub
                    End If

                    Dim frm As New FrmMandarCamalAnimal With {
                            .idAnimal = dtgListado.ActiveRow.Cells(0).Value,
                            .arete = activeRow.Cells(1).Value.ToString(),
                            .clasificacion = clasificacion
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

    Private Sub BtnExportarControlCerda_Click(sender As Object, e As EventArgs) Handles BtnExportarprocontrolcerdos.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL DE CERDAS", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnVaciaMasMenos7_Click(sender As Object, e As EventArgs) Handles BtnVaciaMasMenos7procontrolcerdos.Click
        Try
            Dim frm As New FrmVaciasMasMenosSiete With {
                .idPlantel = CmbUbicacion.Value
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnHistorial_Click(sender As Object, e As EventArgs) Handles BtnHistorial.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim frm As New FrmHistoricoCerda With {
                    .idCerda = activeRow.Cells("idAnimal").Value,
                    .codAnimal = activeRow.Cells("Arete").Value,
                    .etapa = activeRow.Cells("Etapa Reproducción").Value
                }
                frm.ShowDialog()
                Consultar()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub FrmControlCerda_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnBuscar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BtnMortalidadAnimal_Click(sender As Object, e As EventArgs) Handles BtnMortalidadAnimal.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim estado As String = activeRow.Cells("Condición").Value.ToString()
                    Dim etapaReproductiva As String = activeRow.Cells("Etapa Reproducción").Value.ToString()

                    If estado = "MUERTO" Then
                        msj_advert("La cerda ya está registrada como muerta")
                        Exit Sub
                    End If

                    If etapaReproductiva = "LACTANTE" Then
                        msj_advert("No puede registrar mortalidad de una hembra lactante")
                        Exit Sub
                    End If

                    Dim frm As New FrmMortalidadCerda With {
                        .idAnimal = activeRow.Cells(0).Value,
                        .arete = activeRow.Cells(1).Value.ToString()
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

    Private Sub BtnEnvioCamalMasivo_Click(sender As Object, e As EventArgs) Handles BtnEnvioCamalMasivo.Click
        Try
            Dim frm As New FrmEnvioCamalMasivo With {
                .idUbicacion = CmbUbicacion.Value
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnReportePartos_Click(sender As Object, e As EventArgs) Handles BtnReportePartos.Click
        Try
            Dim frm As New FrmReportePartoDetallado With {
                .idPlantel = CmbUbicacion.Value
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub MortalidadMaternidadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MortalidadMaternidadToolStripMenuItem.Click
        Try
            Dim frm As New FrmHistoricoParaDescarte With {
                .idPlantel = CmbUbicacion.Value
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim codCerdo = activeRow.Cells("Arete").Value.ToString()

                If (MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR AL ANIMAL CON ARETE : " & codCerdo & " ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim obj As New coControlAnimal With {
                    .Codigo = activeRow.Cells("idAnimal").Value.ToString()
                }

                Dim MensajeBgWk As String = cn.Cn_EliminarAnimal(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Consultar()
                Else
                    msj_advert(MensajeBgWk)
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub HistoricoDeDesteteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoricoDeDesteteToolStripMenuItem.Click
        Try
            Dim frm As New FrmHistoricoDestete With {
                .idUbicacion = CmbUbicacion.Value
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub HistoricoDePartosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoricoDePartosToolStripMenuItem.Click
        Try
            Dim frm As New FrmHistoricoParto With {
                .idUbicacion = CmbUbicacion.Value
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class