Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmHistoricoPreparaciones
    Dim cnAlimento As New cnControlAlimento
    Dim ds As New DataSet
    Dim search As Boolean = True

    Private Sub FrmHistoricoPreparaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CmbEstado.SelectedIndex = 0
            DtpFechaDesde.Value = Now.Date
            DtpFechaHasta.Value = Now.Date
            clsBasicas.Formato_Tablas_Grid(dtgListadoRacionesPreparado)
            clsBasicas.Filtrar_Tabla(dtgListadoRacionesPreparado, True)
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        Try
            If DtpFechaDesde.Value > DtpFechaHasta.Value Then
                msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
                Return
            End If
            If Not BackgroundWorker1.IsBusy Then
                Ptbx_Cargando.Visible = True
                BtnConsultar.Enabled = False
                BarraOpciones.Enabled = False

                If search Then
                    Dim intervalo = ObtenerIntervaloSemana(Now.Date)
                    DtpFechaDesde.Value = intervalo.Item1
                    DtpFechaHasta.Value = intervalo.Item2
                End If

                Dim obj As New coControlAlimento With {
                    .FechaDesde = DtpFechaDesde.Value,
                    .FechaHasta = DtpFechaHasta.Value,
                    .Estado = CmbEstado.Text
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
            BtnConsultar.Enabled = True
            BarraOpciones.Enabled = True
            dtgListadoRacionesPreparado.DataSource = ds.Tables(0)
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListadoRacionesPreparado.Rows.Count > 0) Then
            Dim estado As Integer = 7

            'estadoRepetidora
            clsBasicas.Colorear_SegunValor(dtgListadoRacionesPreparado, Color.Green, Color.White, "REALIZADO", estado)
            clsBasicas.Colorear_SegunValor(dtgListadoRacionesPreparado, Color.Red, Color.White, "CANCELADO", estado)

            'centrar columnas
            With dtgListadoRacionesPreparado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Public Function ObtenerIntervaloSemana(ByVal fecha As Date) As Tuple(Of Date, Date)
        Dim primerDiaSemana As Date = fecha.AddDays(-(fecha.DayOfWeek))
        Dim ultimoDiaSemana As Date = primerDiaSemana.AddDays(6)

        Return New Tuple(Of Date, Date)(primerDiaSemana, ultimoDiaSemana)
    End Function

    Private Sub BtnCancelarPreparacion_Click(sender As Object, e As EventArgs) Handles BtnCancelarPreparacion.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListadoRacionesPreparado.ActiveRow
        If (dtgListadoRacionesPreparado.Rows.Count > 0) Then
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

                    Dim MensajeBgWk As String = cnAlimento.Cn_CancelarPreparacionAlimento(obj)
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

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            If (dtgListadoRacionesPreparado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("RACIONES-PREPARADAS", dtgListadoRacionesPreparado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnConsultar_Click(sender As Object, e As EventArgs) Handles BtnConsultar.Click
        search = False
        Consultar()
    End Sub

    Private Sub dtgListadoRacionesPreparado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListadoRacionesPreparado.InitializeLayout
        Try
            If (dtgListadoRacionesPreparado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListadoRacionesPreparado, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListadoRacionesPreparado, e, 2)
                clsBasicas.SumarTotales_Formato(dtgListadoRacionesPreparado, e, 5)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class