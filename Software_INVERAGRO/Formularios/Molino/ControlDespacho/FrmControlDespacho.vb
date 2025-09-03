Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmControlDespacho
    Dim cn As New cnControlDespacho
    Dim ds As New DataSet
    Dim search As Boolean = True

    Private Sub FrmControlDespacho_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListadoPreparacionRacion)
            Inicializar()
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Inicializar()
        Me.KeyPreview = True
        Ptbx_Cargando.Visible = True
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        cmbEstadoPreparacion.SelectedIndex = 0
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

    Sub Consultar()
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()

            If search Then
                Dim intervalo = ObtenerIntervaloSemana(Now.Date)
                dtpFechaDesde.Value = intervalo.Item1
                dtpFechaHasta.Value = intervalo.Item2
            End If

            Dim obj As New coControlDespacho With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .EstadoPreparacion = cmbEstadoPreparacion.Text
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlDespacho = CType(e.Argument, coControlDespacho)

            ds = cn.Cn_ConsultarRacionPreparadaCerdo(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns(3).ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns(5).ColumnMapping = MappingType.Hidden
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
            dtgListadoPreparacionRacion.DataSource = ds.Tables(0)
            DesbloquearControles()
            Colorear()
            PintarFilas()
        End If
    End Sub

    Private Sub PintarFilas()
        For Each fila As UltraGridRow In dtgListadoPreparacionRacion.Rows
            Dim valor As String = fila.Cells("Motivo Finalización").Value?.ToString().Trim()

            If Not String.IsNullOrEmpty(valor) Then
                fila.Appearance.BackColor = Color.FromArgb(255, 220, 220)
            End If
        Next
    End Sub

    Public Function ObtenerIntervaloSemana(ByVal fecha As Date) As Tuple(Of Date, Date)
        Dim primerDiaSemana As Date = fecha.AddDays(-(fecha.DayOfWeek))
        Dim ultimoDiaSemana As Date = primerDiaSemana.AddDays(6)

        Return New Tuple(Of Date, Date)(primerDiaSemana, ultimoDiaSemana)
    End Function

    Sub Colorear()
        If (dtgListadoPreparacionRacion.Rows.Count > 0) Then
            Dim estadoPreparacion As Integer = 7
            Dim estadoRecepcion As Integer = 8
            Dim estadoDespacho As Integer = 9

            'estadoPreparacion
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.LightGreen, Color.Black, "PREPARADO", estadoPreparacion)
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.LightYellow, Color.Black, "PARCIAL", estadoPreparacion)
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.LightGray, Color.Black, "PENDIENTE", estadoPreparacion)

            'estadoRecepcion
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.Red, Color.White, "SIN DESPACHO", estadoRecepcion)
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.Green, Color.White, "DESPACHADO", estadoRecepcion)
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.LightYellow, Color.Black, "PARCIAL", estadoRecepcion)

            'estadoDespacho
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.LightGray, Color.Black, "PENDIENTE", estadoDespacho)
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.Green, Color.White, "FINALIZADO", estadoDespacho)

            'centrar columnas
            With dtgListadoPreparacionRacion.DisplayLayout.Bands(0)
                .Columns(estadoPreparacion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoRecepcion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoDespacho).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            search = False
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnDespacharRacion_Click(sender As Object, e As EventArgs) Handles BtnDespacharRacionMolino.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListadoPreparacionRacion.ActiveRow
        If (dtgListadoPreparacionRacion.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim estadoDespacho = activeRow.Cells(8).Value.ToString()

                    If estadoDespacho = "DESPACHADO" Then
                        msj_advert("ESTE PEDIDO DE ALIMENTO YA FUE DESPACHADO EN SU TOTALIDAD")
                        Return
                    End If

                    Dim f As New FrmRegistrarDespachoRacion With {
                        .idSalida = activeRow.Cells(0).Value,
                        .idUbicacionOrigen = activeRow.Cells(3).Value,
                        .idUbicacionDestino = activeRow.Cells(5).Value
                    }
                    f.ShowDialog()
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

    Private Sub BtnFinalizarDespacho_Click(sender As Object, e As EventArgs) Handles BtnFinalizarDespachoMolino.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListadoPreparacionRacion.ActiveRow
            If (dtgListadoPreparacionRacion.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim estadoRecepcion = activeRow.Cells(8).Value.ToString()
                        Dim estadoDespacho = activeRow.Cells(9).Value.ToString()

                        If estadoDespacho = "FINALIZADO" Then
                            msj_advert("ESTE PEDIDO DE ALIMENTO YA FUE FINALIZADO")
                            Return
                        End If

                        If estadoRecepcion = "SIN DESPACHO" Then
                            msj_advert("ESTE PEDIDO DE ALIMENTO NO HA SIDO DESPACHADO")
                            Return
                        End If

                        Dim f As New FrmFinalizarDespacho With {
                                .IdSalida = dtgListadoPreparacionRacion.ActiveRow.Cells(0).Value
                            }
                        f.ShowDialog()
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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListadoPreparacionRacion, isFilterActive)
    End Sub

    Private Sub BtnExportarMolinodes_Click(sender As Object, e As EventArgs) Handles BtnExportarMolinodes.Click
        Try
            If (dtgListadoPreparacionRacion.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("LISTA DE DESPACHOS", dtgListadoPreparacionRacion)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnHistoricoDespacho_Click(sender As Object, e As EventArgs) Handles BtnHistoricoDespacho.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListadoPreparacionRacion.ActiveRow
            If (dtgListadoPreparacionRacion.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim f As New FrmListaDespachosPedido With {
                        .idSalida = dtgListadoPreparacionRacion.ActiveRow.Cells(0).Value
                    }
                    f.ShowDialog()
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

    Private Sub dtgListadoPreparacionRacion_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListadoPreparacionRacion.InitializeLayout
        Try
            If (dtgListadoPreparacionRacion.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListadoPreparacionRacion, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmControlDespacho_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class