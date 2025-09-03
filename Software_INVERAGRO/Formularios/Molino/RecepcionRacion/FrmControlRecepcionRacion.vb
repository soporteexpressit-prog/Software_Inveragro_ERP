Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmControlRecepcionRacion
    Dim cn As New cnControlRecepcionAlimento
    Dim ds As New DataSet
    Dim search As Boolean = True

    Private Sub FrmControlRecepcionRacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        cmbEstadoPedido.SelectedIndex = 0
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

            Dim obj As New coControlRecepcionAlimento With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .EstadoPedido = cmbEstadoPedido.Text
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlRecepcionAlimento = CType(e.Argument, coControlRecepcionAlimento)

            ds = cn.Cn_ConsultarPedidoAlimentoRecepcionar(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns(0).ColumnMapping = MappingType.Hidden
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
            dtgListadoPreparacionRacion.DataSource = ds.Tables(0)
            DesbloquearControles()
            Colorear()
            ColorearSubItems()
        End If
    End Sub

    Sub Colorear()
        If (dtgListadoPreparacionRacion.Rows.Count > 0) Then
            Dim estadoPreparacion As Integer = 5
            Dim estadoRecepcion As Integer = 6
            Dim estadoDespacho As Integer = 7

            'estadoPreparacion
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.LightGreen, Color.Black, "PREPARADO", estadoPreparacion)
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.LightYellow, Color.Black, "PARCIAL", estadoPreparacion)
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.LightYellow, Color.Black, "PENDIENTE", estadoPreparacion)

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

    Public Function ObtenerIntervaloSemana(ByVal fecha As Date) As Tuple(Of Date, Date)
        Dim primerDiaSemana As Date = fecha.AddDays(-(fecha.DayOfWeek))
        Dim ultimoDiaSemana As Date = primerDiaSemana.AddDays(6)

        Return New Tuple(Of Date, Date)(primerDiaSemana, ultimoDiaSemana)
    End Function

    Private Sub ColorearSubItems()
        If (dtgListadoPreparacionRacion.Rows.Count > 0) Then
            For Each row As UltraGridRow In dtgListadoPreparacionRacion.Rows
                For Each childRow As UltraGridRow In row.ChildBands(0).Rows
                    Dim estadoCell As UltraGridCell = childRow.Cells("Estado")

                    Select Case estadoCell.Text
                        Case "ENTREGADO"
                            With estadoCell.Appearance
                                .BackColor = Color.LightBlue
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With estadoCell.ActiveAppearance
                                .BackColor = Color.LightBlue
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With estadoCell.SelectedAppearance
                                .BackColor = Color.LightBlue
                                .ForeColor = Color.Black
                                .FontData.Bold = DefaultableBoolean.True
                            End With

                        Case "PENDIENTE"
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
                Next
            Next

            With dtgListadoPreparacionRacion.DisplayLayout.Bands(1)
                .Columns("Estado").CellAppearance.TextHAlign = HAlign.Center
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

    Private Sub btnExportarMolinorecep_Click(sender As Object, e As EventArgs) Handles btnExportarMolinorecep.Click
        Try
            If (dtgListadoPreparacionRacion.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL DE RECEPCIONES DE ALIMENTO CERDO", dtgListadoPreparacionRacion)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnRecepcionarAlimento_Click(sender As Object, e As EventArgs) Handles BtnRecepcionarAlimento.Click
        Try
            Dim filaSeleccionada As UltraGridRow = dtgListadoPreparacionRacion.ActiveRow

            If filaSeleccionada Is Nothing Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Exit Sub
            End If

            If Not filaSeleccionada.IsDataRow Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            ElseIf filaSeleccionada.Band.Index = 0 Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILAS_CONTENIDAS"))
            Else
                Dim idRecepcion As Integer = CInt(filaSeleccionada.Cells("idrecepcion").Value)
                Dim estadoDespacho As String = filaSeleccionada.Cells("Estado").Value

                If estadoDespacho = "ENTREGADO" Then
                    msj_advert("LA RECEPCIÓN DE ALIMENTO YA FUE ATENDIDA")
                    Return
                End If

                Dim f As New FrmRecepcionarDespachoPedido With {
                    .idRecepcion = idRecepcion
                }
                f.ShowDialog()
                Consultar()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListadoPreparacionRacion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListadoPreparacionRacion.InitializeLayout
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

    Private Sub FrmControlRecepcionRacion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class