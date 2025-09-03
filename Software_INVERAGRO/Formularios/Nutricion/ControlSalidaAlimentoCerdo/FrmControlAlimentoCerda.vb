Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlAlimentoCerda
    Dim cn As New cnControlLoteDestete
    Dim cnAlimento As New cnControlAlimento
    Dim ds As New DataSet


    Private Sub FrmControlAlimentoCerda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        CmbEstado.SelectedIndex = 0
        Ptbx_Cargando.Visible = True
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub BloquearControles()
        GrupoFiltros.Enabled = False
        Ptbx_Cargando.Visible = True
        BarraOpciones.Enabled = False
    End Sub

    Private Sub DesbloquearControles()
        GrupoFiltros.Enabled = True
        Ptbx_Cargando.Visible = False
        BarraOpciones.Enabled = True
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

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()

            Dim obj As New coControlAlimento With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .IdUbicacion = CmbUbicacion.Value,
                .Estado = CmbEstado.Text
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)

            ds = cnAlimento.Cn_ConsultarAlimentoCerdo(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("Plantel").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(0).ColumnMapping = MappingType.Hidden
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
        If (dtgListado.Rows.Count > 0) Then
            Dim estado As Integer = 8

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.PaleGreen, Color.DarkGreen, "ACTIVO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.IndianRed, Color.White, "ANULADO", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevoNutricionSaalice.Click
        Try
            Dim frm As New FrmNuevoAlimento With {
                .idPlantel = CmbUbicacion.Value,
                .valorPlantel = CmbUbicacion.Text
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        Consultar()
    End Sub

    Private Sub BtnAnular_Click(sender As Object, e As EventArgs) Handles BtnAnularNutricionSaalice.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim estado As String = activeRow.Cells(7).Value.ToString

                    If estado = "ANULADO" Then
                        msj_advert("EL PEDIDO DE ALIMENTO YA HA SIDO ANULADO")
                        Return
                    End If

                    Dim frm As New FrmAnularAlimento With {
                        .idSalida = activeRow.Cells(0).Value
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

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportarNutricionSaalice.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("SALIDA DE ALIMENTOS DEL CERDO", dtgListado)
            End If
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

    Private Sub BtnReporteAlimentovsMolino_Click(sender As Object, e As EventArgs) Handles BtnReporteAlimentovsMolino.Click
        Try
            If CmbUbicacion.Value = 2 Or CmbUbicacion.Value = 1 Then
                Dim frm As New FrmReporteAlimentoReproduccion With {
                    .idUbicacion = CmbUbicacion.Value
                }
                frm.ShowDialog()
            Else
                Dim frm As New FrmReporteAlimentoEngorde With {
                    .idUbicacion = CmbUbicacion.Value,
                    .valorPlantel = CmbUbicacion.Text
                }
                frm.ShowDialog()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnReportePresupuestoAlimenticio_Click(sender As Object, e As EventArgs) Handles BtnReportePresupuestoAlimenticio.Click
        Try
            If CmbUbicacion.Value = 1 Or CmbUbicacion.Value = 2 Then
                msj_advert("EL REPORTE DE CUMPLIMIENTO DE PRESUPUESTO SOLO SE PUEDE GENERAR EN PLANTELES DE ENGORDE")
                Return
            End If

            Dim frm As New FrmReporteCumplimientoPresupuesto With {
                .idUbicacion = CmbUbicacion.Value,
                .valorPlantel = CmbUbicacion.Text
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnReporteConsumoDiario_Click(sender As Object, e As EventArgs) Handles BtnReporteConsumoDiario.Click
        Try
            If CmbUbicacion.Value = 1 Or CmbUbicacion.Value = 2 Then
                msj_advert("EL REPORTE DE CONSUMO DIARIO SOLO SE PUEDE GENERAR EN PLANTELES DE ENGORDE")
                Return
            End If

            Dim frm As New FrmReporteConsumoDiario With {
                .idUbicacion = CmbUbicacion.Value,
                .valorPlantel = CmbUbicacion.Text
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmControlAlimentoCerda_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnBuscar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BtnPermisoVisualizacion_Click(sender As Object, e As EventArgs) Handles BtnPermisoVisualizacion.Click
        Try
            Dim frm As New FrmVisualizacionAlimentacionPresupuesto
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnGenerarGrupos_Click(sender As Object, e As EventArgs) Handles BtnGenerarGrupos.Click
        Try
            If CmbUbicacion.Value = 1 Or CmbUbicacion.Value = 2 Then
                Dim frm As New FrmDefinirGruposDestete With {
                    .idPlantel = CmbUbicacion.Value
                }
                frm.ShowDialog()
            Else
                msj_advert("Solo esta disponible para P1 y P2")
                Return
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnVerPresupuesto_Click(sender As Object, e As EventArgs) Handles BtnVerPresupuesto.Click
        Try
            If CmbUbicacion.Value = 1 Or CmbUbicacion.Value = 2 Then
                Dim frm As New FrmAlimentacionPresupuesto With {
                    .idPlantel = CmbUbicacion.Value
                }
                frm.ShowDialog()
            Else
                msj_advert("Solo esta disponible para P1 y P2")
                Return
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Close()
    End Sub
End Class