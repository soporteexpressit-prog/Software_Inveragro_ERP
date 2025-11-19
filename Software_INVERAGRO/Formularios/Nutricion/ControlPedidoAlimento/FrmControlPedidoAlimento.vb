Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlPedidoAlimento
    Dim cn As New cnControlAlimento
    Dim ds As New DataSet
    Dim search As Boolean = True

    Private Sub FrmControlPedidoAlimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Inicializar()
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        Try
            Me.KeyPreview = True
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            Ptbx_Cargando.Visible = True
            cmbEstado.SelectedIndex = 0
            dtpFechaDesde.Value = Now.Date
            dtpFechaHasta.Value = Now.Date
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
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

            Dim obj As New coControlAlimento With {
                .Estado = cmbEstado.Text,
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Public Function ObtenerIntervaloSemana(ByVal fecha As Date) As Tuple(Of Date, Date)
        Dim primerDiaSemana As Date = fecha.AddDays(-(fecha.DayOfWeek))
        Dim ultimoDiaSemana As Date = primerDiaSemana.AddDays(6)

        Return New Tuple(Of Date, Date)(primerDiaSemana, ultimoDiaSemana)
    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)

            ds = cn.Cn_ListarRequerimientoAlimento(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("idUbicacion").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(1).ColumnMapping = MappingType.Hidden
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
            Dim estado As Integer = 4
            Dim estadoAprobacion As Integer = 5
            Dim estadoPreparacion As Integer = 6
            Dim estadoRecepcion As Integer = 7

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", estado)

            'estadoAprobacion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "CANCELADO", estadoAprobacion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estadoAprobacion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "APROBADO", estadoAprobacion)

            'estadoPreparacion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estadoPreparacion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightYellow, Color.Black, "PARCIAL", estadoPreparacion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.Black, "PREPARADO", estadoPreparacion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "CANCELADO", estadoPreparacion)

            'estadoRecepcion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "DESPACHADO", estadoRecepcion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.OrangeRed, Color.White, "SIN DESPACHO", estadoRecepcion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightYellow, Color.Black, "PARCIAL", estadoRecepcion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "CANCELADO", estadoRecepcion)


            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoAprobacion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoPreparacion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoRecepcion).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoNpea.Click
        Try
            Dim f As New FrmRegistrarPedidoAlimento
            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelarNpea.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim estado As String = activeRow.Cells("Estado").Value.ToString()
                    Dim estadoPreparacion As String = activeRow.Cells("Estado Preparación").Value.ToString()

                    If estado = "ANULADO" Then
                        msj_advert("ESTE PEDIDO YA FUE ANULADO.")
                        Return
                    ElseIf estadoPreparacion = "PARCIAL" Then
                        msj_advert("ESTE PEDIDO YA FUE PARCIALMENTE PREPARADO, FINALICE EL PEDIDO EN EL MÓDULO CONTROL DE DESPACHOS")
                        Return
                    Else
                        Dim id As Integer = Convert.ToInt32(activeRow.Cells(0).Value)
                        Dim f As New FrmCancelarPedidoAlimento With {
                            .IdPedidoAlimento = id
                        }
                        f.ShowDialog()
                        Consultar()
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        search = False
        Consultar()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportarNpea.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REQUERIMIENTO DE ALIMENTOS", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobarNpea.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim estado As String = dtgListado.ActiveRow.Cells(4).Value.ToString()
                    Dim estadoAprobacion As String = dtgListado.ActiveRow.Cells(5).Value.ToString()

                    If estado <> "ACTIVO" Then
                        msj_advert("EL REQUERIMIENTO YA FUE " & estado)
                        Return
                    End If

                    If estadoAprobacion = "APROBADO" Then
                        msj_advert("EL REQUERIMIENTO YA FUE APROBADO")
                        Return
                    End If

                    Dim f As New FrmMantRequerimientoAlimento With {
                        .idSalida = CInt(dtgListado.ActiveRow.Cells(0).Value)
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

    Private Sub BtnConsolidadoRacion_Click(sender As Object, e As EventArgs) Handles BtnConsolidadoRacionmodulonutricion.Click
        Try
            Dim f As New FrmConsolidadoAlimento
            f.ShowDialog()
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

    Private Sub FrmControlPedidoAlimento_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BtnModificarCampaña_Click(sender As Object, e As EventArgs) Handles BtnModificarCampaña.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim idUbicacion As Integer = Convert.ToInt32(activeRow.Cells("idUbicacion").Value)
                    Dim valorPlantel As String = activeRow.Cells("Destino").Value.ToString()
                    Dim idPedido As Integer = Convert.ToInt32(activeRow.Cells(0).Value)

                    Dim f As New FrmModificarCampaña With {
                        .idUbicacion = idUbicacion,
                        .valorPlantel = valorPlantel,
                        .idPedido = idPedido
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

    Private Sub BtnReportePreparaciones_Click(sender As Object, e As EventArgs) Handles BtnReportePreparaciones.Click
        Try
            Dim frm As New FrmReportePreparacionesAlimento
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnReporteSemanal_Click(sender As Object, e As EventArgs) Handles BtnReporteSemanal.Click
        Try
            Dim frm As New FrmReporteSemanalAlimentoxRacion
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnHistoricoPreparaciones_Click(sender As Object, e As EventArgs) Handles BtnHistoricoPreparaciones.Click
        Try
            Dim frm As New FrmHistoricoPreparaciones
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class