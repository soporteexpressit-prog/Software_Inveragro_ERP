Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlMaternidadDestete
    Dim cn As New cnControlAnimal
    Dim tbtmp As New DataTable

    Private Sub FrmControlMaternidadDestete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        ListarPlanteles()
        Me.KeyPreview = True
        TxtCodArete.Text = ""
        CmbUbicacion.Value = VariablesGlobales.idPlantelGlobal
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

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlAnimal With {
                .IdPlantel = CmbUbicacion.Value,
                .CodArete = TxtCodArete.Text
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            tbtmp = cn.Cn_ConsultarCerdaEtapaMaternidad(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            DesbloquearControladores()
            dtgListado.DisplayLayout.Bands(0).Columns("idAnimal").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("numPartos").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("idLoteAnimal").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("idUbicacion").Hidden = True
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estadoGestacion As Integer = 9
            Dim etapaReproductiva As Integer = 10
            Dim codigo As Integer = 1

            'colorear segun clave
            clsBasicas.Colorear_SegunClave(dtgListado, Color.Yellow, Color.Black, "NODRIZA", codigo)

            'estadoGestacion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LemonChiffon, Color.Peru, "PREÑADA", estadoGestacion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.MistyRose, Color.Maroon, "NO PREÑADA", estadoGestacion)

            'etapaReproductiva
            clsBasicas.Colorear_SegunValor(dtgListado, Color.AntiqueWhite, Color.DarkOliveGreen, "GESTANTE", etapaReproductiva)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.MistyRose, Color.Maroon, "LACTANTE", etapaReproductiva)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Beige, Color.SaddleBrown, "VACÍA", etapaReproductiva)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estadoGestacion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(etapaReproductiva).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub BtnMonitoreo_Click(sender As Object, e As EventArgs) Handles BtnMonitoreomaternidadpro.Click
        Try
            Dim frm As New FrmMonitoreoCondicionCorporal With {
                .idUbicacion = CmbUbicacion.Value,
                .tipoControl = "LACTANTE"
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportarControlMD_Click(sender As Object, e As EventArgs) Handles BtnExportarControlMDmaternidadpro.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REGISTRO DE ETAPA DE MATERNIDAD", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnNodriza_Click(sender As Object, e As EventArgs) Handles BtnNodrizamaternidadpro.Click
        Try
            Dim frm As New FrmRegistrarNodriza With {
                .idUbicacion = CmbUbicacion.Value
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnMovimientoLechon_Click(sender As Object, e As EventArgs) Handles BtnMovimientoLechonmaternidadpro.Click
        Try
            Dim frm As New FrmRegistrarMovimientoLechon With {
                   .idUbicacion = CmbUbicacion.Value
                }
            frm.ShowDialog()
            Consultar()
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
                clsBasicas.SumarTotales_Formato(dtgListado, e, 13)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCambiarLote_Click(sender As Object, e As EventArgs) Handles BtnCambiarLote.Click
        Try
            Dim frm As New FrmCambiarLote With {
                .idUbicacion = CmbUbicacion.Value
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnHistorialCerda_Click(sender As Object, e As EventArgs) Handles BtnHistorialCerda.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim frm As New FrmHistoricoCerda With {
                    .idCerda = activeRow.Cells("idAnimal").Value,
                    .codAnimal = activeRow.Cells("Código").Value,
                    .etapa = activeRow.Cells("Condición").Value,
                    .idUbicacion = activeRow.Cells("idUbicacion").Value
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

    Private Sub BtnMortalidadCrias_Click(sender As Object, e As EventArgs) Handles BtnMortalidadCrias.Click
        Try
            Dim frm As New FrmMandarCamalMortalidadCriaCerda With {
                .idUbicacion = CmbUbicacion.Value
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Consultar()
    End Sub

    Private Sub BtnReportePartos_Click(sender As Object, e As EventArgs) Handles BtnReportePartos.Click
        Try
            Dim frm As New FrmReporteLotePartos With {
                .idPlantel = CmbUbicacion.Value
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnReporteDestete_Click(sender As Object, e As EventArgs) Handles BtnReporteDestete.Click
        Try
            Dim frm As New FrmReporteLoteDestete With {
                .idPlantel = CmbUbicacion.Value
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnRegistrarDestetecontroldestetepro_Click(sender As Object, e As EventArgs) Handles BtnRegistrarDestetecontroldestetepro.Click
        Try
            Dim frm As New FrmRegistrarDestete With {
                .idPlantel = CmbUbicacion.Value,
                .valorPlantel = CmbUbicacion.Text
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnRegistrarParto_Click(sender As Object, e As EventArgs) Handles BtnRegistrarParto.Click
        Try
            Dim frm As New FrmRegParto With {
                .idUbicacion = CmbUbicacion.Value
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmControlMaternidadDestete_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BtnDejarVacia_Click(sender As Object, e As EventArgs) Handles BtnDejarVacia.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim numCrias As Integer = CInt(activeRow.Cells("Número de Crías").Value)

                    If numCrias > 0 Then
                        msj_advert("NO SE PUEDE DEJAR VACÍA UNA CERDA CON CRÍAS")
                        Return
                    End If

                    If (MessageBox.Show("¿ESTÁ SEGURO DE VACIAR A ESTA CERDA?", "Aprobar Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    Dim obj As New coControlAnimal With {
                        .Codigo = activeRow.Cells("idAnimal").Value.ToString()
                    }

                    Dim MensajeBgWk As String = cn.Cn_VaciarCerda(obj)
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
    End Sub

    Private Sub MortalidadMaternidadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MortalidadMaternidadToolStripMenuItem.Click
        Try
            Dim frm As New FrmHistorialMortalidadLechon With {
               .idUbicacion = CmbUbicacion.Value
           }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub PartosVsDesteteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartosVsDesteteToolStripMenuItem.Click
        Try
            Dim frm As New FrmReportePartosVsDestete With {
               .idPlantel = CmbUbicacion.Value
           }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnObjetivoPartos_Click(sender As Object, e As EventArgs) Handles BtnObjetivoPartos.Click
        Try
            Dim frm As New FrmObjetivoPartos With {
                .idPlantel = CmbUbicacion.Value
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class