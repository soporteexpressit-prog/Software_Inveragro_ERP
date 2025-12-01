Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlExcedente
    Dim cnAlimento As New cnControlAlimento
    Dim ds As New DataSet
    Dim search As Boolean = True

    Private Sub FrmControlExcedente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmbEstado.SelectedIndex = 0
            dtpFechaDesde.Value = Now.Date
            dtpFechaHasta.Value = Now.Date
            clsBasicas.Formato_Tablas_Grid(dtgListadoInsumoExcedente)
            clsBasicas.Filtrar_Tabla(dtgListadoInsumoExcedente, True)
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmHistoricoPreparaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmbEstado.SelectedIndex = 0
            dtpFechaDesde.Value = Now.Date
            dtpFechaHasta.Value = Now.Date
            clsBasicas.Formato_Tablas_Grid(dtgListadoInsumoExcedente)
            clsBasicas.Filtrar_Tabla(dtgListadoInsumoExcedente, True)
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        Try
            If dtpFechaDesde.Value > dtpFechaHasta.Value Then
                msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
                Return
            End If
            If Not BackgroundWorker1.IsBusy Then
                Ptbx_Cargando.Visible = True
                btnBuscar.Enabled = False
                BarraOpciones.Enabled = False

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
            btnBuscar.Enabled = True
            BarraOpciones.Enabled = True
            dtgListadoInsumoExcedente.DataSource = ds.Tables(0)
            Colorear()
        End If
    End Sub

    Sub Colorear()
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

    Public Function ObtenerIntervaloSemana(ByVal fecha As Date) As Tuple(Of Date, Date)
        Dim primerDiaSemana As Date = fecha.AddDays(-(fecha.DayOfWeek))
        Dim ultimoDiaSemana As Date = primerDiaSemana.AddDays(6)

        Return New Tuple(Of Date, Date)(primerDiaSemana, ultimoDiaSemana)
    End Function

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        search = False
        Consultar()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) 
        Try
            Dim f As New FrmRegistrarInsumoExcedente
            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) 
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
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
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
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
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

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class