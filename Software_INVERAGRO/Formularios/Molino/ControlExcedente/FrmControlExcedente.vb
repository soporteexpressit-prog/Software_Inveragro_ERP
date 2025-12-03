Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlExcedente
    Dim cn As New cnControlExcedente
    Dim cnAlimento As New cnControlAlimento
    Dim ds As New DataSet
    Dim search As Boolean = True

    Private Sub FrmControlExcedente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            BtnNuevoxRacion.Visible = True
            BtnCancelarxRacion.Visible = True
            BtnNuevoxRacion.Enabled = True
            BtnCancelarxRacion.Enabled = True
            BtnNuevoxInsumo.Visible = False
            BtnCancelarxInsumo.Visible = False
            BtnNuevoxInsumo.Enabled = False
            BtnCancelarxInsumo.Enabled = False

            ' Inicializar opciones del combo para vista de Raciones (por defecto)
            cmbEstado.Items.Clear()
            cmbEstado.Items.Add("REALIZADO")
            cmbEstado.Items.Add("CANCELADO")
            cmbEstado.SelectedIndex = 0

            dtpFechaDesde.Value = Now.Date
            dtpFechaHasta.Value = Now.Date
            clsBasicas.Formato_Tablas_Grid(dtgListadoInsumoExcedente)
            clsBasicas.Filtrar_Tabla(dtgListadoInsumoExcedente, True)
            Consultar1()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BloquearControles()
        Ptbx_Cargando.Visible = True
        BarraOpciones.Enabled = False
        GrupoFiltros.Enabled = False
    End Sub

    Private Sub DesbloquearControles()
        Ptbx_Cargando.Visible = False
        BarraOpciones.Enabled = True
        GrupoFiltros.Enabled = True
    End Sub

    Sub Consultar1()
        Try
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
                    .FechaDesde = dtpFechaDesde.Value,
                    .FechaHasta = dtpFechaHasta.Value,
                    .Tipo = "EXCEDENTE",
                    .Estado = cmbEstado.Text
                }

                BackgroundWorker1.RunWorkerAsync(obj)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)

            ds = cnAlimento.Cn_ObtenerHistorioPreparaciones(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(0).ColumnMapping = MappingType.Hidden
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListadoInsumoExcedente.DataSource = ds.Tables(0)
            DesbloquearControles()
            Colorear1()
        End If
    End Sub

    Sub Colorear1()
        If (dtgListadoInsumoExcedente.Rows.Count > 0) Then
            Dim estado As Integer = 8

            'estadoRepetidora
            clsBasicas.Colorear_SegunValor(dtgListadoInsumoExcedente, Color.Green, Color.White, "REALIZADO", estado)
            clsBasicas.Colorear_SegunValor(dtgListadoInsumoExcedente, Color.Red, Color.White, "CANCELADO", estado)

            'centrar columnas
            With dtgListadoInsumoExcedente.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Sub Consultar2()
        dtgListadoInsumoExcedente.DataSource = Nothing
        If Not BackgroundWorker2.IsBusy Then
            BloquearControles()
            Dim obj As New coControlExcedente With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .Estado = cmbEstado.Text
            }

            BackgroundWorker2.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            Dim obj As coControlExcedente = CType(e.Argument, coControlExcedente)
            ds = cn.Cn_ConsultarInsumoExcedenteAlimentoCerdo(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(0).ColumnMapping = MappingType.Hidden
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        DesbloquearControles()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListadoInsumoExcedente.DataSource = ds.Tables(0)
            DesbloquearControles()
            Colorear2()
        End If
    End Sub

    Sub Colorear2()
        If (dtgListadoInsumoExcedente.Rows.Count > 0) Then
            Dim estado As Integer = 8

            'estadoRepetidora
            clsBasicas.Colorear_SegunValor(dtgListadoInsumoExcedente, Color.Red, Color.White, "ANULADO", estado)
            clsBasicas.Colorear_SegunValor(dtgListadoInsumoExcedente, Color.Green, Color.White, "ACTIVO", estado)

            'centrar columnas
            With dtgListadoInsumoExcedente.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Public Function ObtenerIntervaloSemana(ByVal fecha As Date) As Tuple(Of Date, Date)
        Dim primerDiaSemana As Date = fecha.AddDays(-(fecha.DayOfWeek))
        Dim ultimoDiaSemana As Date = primerDiaSemana.AddDays(6)

        Return New Tuple(Of Date, Date)(primerDiaSemana, ultimoDiaSemana)
    End Function

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        search = False
        If ChkVisualizarxInsumo.Checked Then
            Consultar2()
        Else
            Consultar1()
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportarMolinoinexce.Click
        Try
            If (dtgListadoInsumoExcedente.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("LISTA DE INSUMOS EXCEDENTES - ALIMENTO CERDO", dtgListadoInsumoExcedente)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListadoInsumoExcedente, isFilterActive)
    End Sub

    Private Sub BtnNuevoxRacion_Click(sender As Object, e As EventArgs) Handles BtnNuevoxRacion.Click
        Try
            Dim f As New FrmRegistrarExcedentexRacion
            f.ShowDialog()
            Consultar1()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCancelarxRacion_Click(sender As Object, e As EventArgs) Handles BtnCancelarxRacion.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListadoInsumoExcedente.ActiveRow
        If (dtgListadoInsumoExcedente.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim estado As String = activeRow.Cells("Estado").Value.ToString()

                    If estado = "CANCELADO" Then
                        msj_advert("LA PREPARACIÓN DE ALIMENTO YA FUE CANCELADO")
                        Return
                    End If

                    If (MessageBox.Show("¿ESTÁ SEGURO DE CANCELAR LA PREPARACIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    Dim obj As New coControlAlimento With {
                        .IdPreparacionAlimento = activeRow.Cells("idPreparacionAlimento").Value
                    }

                    Dim MensajeBgWk As String = cnAlimento.Cn_CancelarPreparacionAlimentoExcedente(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(MensajeBgWk)
                        Consultar1()
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
    Private Sub ChkVisualizarxInsumo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkVisualizarxInsumo.CheckedChanged
        If ChkVisualizarxInsumo.Checked Then
            ' Cambiar opciones del combo para vista de Insumos
            cmbEstado.Items.Clear()
            cmbEstado.Items.Add("ACTIVO")
            cmbEstado.Items.Add("ANULADO")
            cmbEstado.SelectedIndex = 0

            ' Cambiar visibilidad de botones
            BtnNuevoxRacion.Visible = False
            BtnCancelarxRacion.Visible = False
            BtnNuevoxRacion.Enabled = False
            BtnCancelarxRacion.Enabled = False
            BtnNuevoxInsumo.Visible = True
            BtnCancelarxInsumo.Visible = True
            BtnNuevoxInsumo.Enabled = True
            BtnCancelarxInsumo.Enabled = True

            Consultar2()
        Else
            ' Cambiar opciones del combo para vista de Raciones
            cmbEstado.Items.Clear()
            cmbEstado.Items.Add("REALIZADO")
            cmbEstado.Items.Add("CANCELADO")
            cmbEstado.SelectedIndex = 0

            ' Cambiar visibilidad de botones
            BtnNuevoxRacion.Visible = True
            BtnCancelarxRacion.Visible = True
            BtnNuevoxRacion.Enabled = True
            BtnCancelarxRacion.Enabled = True
            BtnNuevoxInsumo.Visible = False
            BtnCancelarxInsumo.Visible = False
            BtnNuevoxInsumo.Enabled = False
            BtnCancelarxInsumo.Enabled = False

            Consultar1()
        End If
    End Sub

    Private Sub BtnNuevoxInsumo_Click(sender As Object, e As EventArgs) Handles BtnNuevoxInsumo.Click
        Try
            Dim f As New FrmRegistrarInsumoExcedente
            f.ShowDialog()
            Consultar2()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCancelarxInsumo_Click(sender As Object, e As EventArgs) Handles BtnCancelarxInsumo.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListadoInsumoExcedente.ActiveRow
            If (dtgListadoInsumoExcedente.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim estado As String = activeRow.Cells(5).Value.ToString()
                        If estado = "CANCELADO" Then
                            msj_advert(MensajesSistema.mensajesGenerales("YA_FUE_ANULADO_CANCELADO"))
                        Else
                            Dim idSalida As Integer = Convert.ToInt32(activeRow.Cells(0).Value)
                            Dim f As New FrmCancelarSalidaExcedente With {
                                .IdSalidaExcedente = idSalida
                            }
                            f.ShowDialog()
                            Consultar2()
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

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class