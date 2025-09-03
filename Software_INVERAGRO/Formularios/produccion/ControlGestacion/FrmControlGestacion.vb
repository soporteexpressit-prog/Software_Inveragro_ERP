Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlGestacion
    Dim cn As New cnControlAnimal
    Dim tbtmp As New DataTable

    Private Sub FrmControlGestacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarPlanteles()
            Inicializar()
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        TxtCodArete.Text = ""
        CmbCondicacion.SelectedIndex = 0
        CmbUbicacion.Value = VariablesGlobales.idPlantelGlobal
        clsBasicas.Formato_Tablas_Grid(dtgListado)
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

    Private Sub BtnTestGestacion_Click(sender As Object, e As EventArgs) Handles BtnTestGestacionpro.Click
        Try
            Dim frm As New FrmRegistrarTestGestacion With {
                .idUbicacion = CmbUbicacion.Value
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlAnimal With {
                .IdPlantel = CmbUbicacion.Value,
                .CodArete = TxtCodArete.Text,
                .EtapaReproductiva = CmbCondicacion.Text
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            tbtmp = cn.Cn_ConsultarCerdaEtapaGestacion(obj).Copy
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
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estadoGestacion As Integer = 11
            Dim etapaReproductiva As Integer = 12

            'estadoGestacion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LemonChiffon, Color.Peru, "PREÑADA", estadoGestacion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.MistyRose, Color.Maroon, "NO PREÑADA", estadoGestacion)

            'etapaReproductiva
            clsBasicas.Colorear_SegunValor(dtgListado, Color.AntiqueWhite, Color.DarkOliveGreen, "GESTANTE", etapaReproductiva)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Beige, Color.SaddleBrown, "VACÍA", etapaReproductiva)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Beige, Color.SaddleBrown, "NO INICIADO", etapaReproductiva)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estadoGestacion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(etapaReproductiva).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub BtnMonitoreoCondicionCorporal_Click(sender As Object, e As EventArgs) Handles BtnMonitoreoCondicionCorporalprogestacion.Click
        Try
            Dim frm As New FrmMonitoreoCondicionCorporal With {
                .idUbicacion = CmbUbicacion.Value,
                .tipoControl = "GESTANTE"
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportarControlCerda_Click(sender As Object, e As EventArgs) Handles BtnExportartestgestapro.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REGISTRO DE ETAPA DE GESTACIÓN", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnHistorialPerdidaRepro_Click(sender As Object, e As EventArgs) Handles BtnHistorialPerdidaReprogestpro.Click
        Try
            Dim frm As New FrmHistorialPerdidaReproductiva With {
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
            End If
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
                    .idUbicacion = CmbUbicacion.Value,
                    .etapa = "GESTANTE"
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

    Private Sub BtnNuevaColecta_Click(sender As Object, e As EventArgs) Handles BtnNuevaColecta.Click
        Try
            Dim frm As New FrmMantMaterialGenetico With {
                .idUbicacion = CmbUbicacion.Value
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Consultar()
    End Sub

    Private Sub BtnNuevaInseminacion_Click(sender As Object, e As EventArgs) Handles BtnNuevaInseminacion.Click
        Try
            Dim frm As New FrmRegistrarInseminacion With {
                .idPlantel = CmbUbicacion.Value
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnReporteInseminaciones_Click(sender As Object, e As EventArgs) Handles BtnReporteInseminaciones.Click
        Try
            Dim frm As New FrmControlInseminacion With {
                .idPlantel = CmbUbicacion.Value,
                .valorPlantel = CmbUbicacion.Text
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_KeyDown(sender As Object, e As KeyEventArgs) Handles dtgListado.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
End Class