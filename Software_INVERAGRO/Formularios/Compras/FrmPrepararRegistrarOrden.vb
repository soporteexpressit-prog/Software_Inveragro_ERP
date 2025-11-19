Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmPrepararRegistrarOrden
    Dim cn As New cnControlAlimento
    Dim tbtmp As New DataTable
    Dim semana As (Date, Date)

    Private Sub FrmPrepararRegistrarOrden_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ConsultarOrdenAlimentoPedir()
            Me.CenterToScreen()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Inicializar()
        clsBasicas.LlenarComboAnios(CmbAnios)
        NumSemana.Value = ObtenerNumeroSemana(DateTime.Now)
        semana = ObtenerIntervaloSemana(CmbAnios.Text, NumSemana.Value)

        Ptbx_Cargando.Visible = True
        Me.Width = 1545
        Me.Height = 800
        Timer1.Interval = 500
        Timer1.Enabled = False
    End Sub

    Sub ConsultarConsolidadoAlimentoPedir(Optional ByVal fechaDesde As Date? = Nothing, Optional ByVal fechaHasta As Date? = Nothing)
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            Dim obj As New coControlAlimento With {
                .FechaDesde = semana.Item1,
                .FechaHasta = semana.Item2
            }
            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Function SumarValoresColumna(columnName As String) As Decimal
        Dim total As Decimal = 0

        If dtgListadoConsolidado IsNot Nothing AndAlso dtgListadoConsolidado.Rows.Count > 0 Then
            For Each row As UltraGridRow In dtgListadoConsolidado.Rows
                If row.Cells(columnName).Value IsNot Nothing AndAlso IsNumeric(row.Cells(columnName).Value) Then
                    total += CDec(row.Cells(columnName).Value)
                End If
            Next
        End If

        Return total
    End Function

    Private Function ObtenerIntervaloSemana(ByVal anio As Integer, ByVal numeroSemana As Integer) As (Date, Date)
        Dim primerDiaAño As Date = New Date(anio, 1, 1)

        ' Encontrar el primer domingo del año
        Dim primerDomingo As Date = primerDiaAño
        While primerDomingo.DayOfWeek <> DayOfWeek.Sunday
            primerDomingo = primerDomingo.AddDays(1)
        End While

        ' Calcular el inicio y fin de la semana deseada
        Dim fechaInicio As Date = primerDomingo.AddDays((numeroSemana - 2) * 7)
        Dim fechaFin As Date = fechaInicio.AddDays(6) ' Sábado de la semana siguiente

        Return (fechaInicio, fechaFin)
    End Function

    Private Sub ConsultarOrdenAlimentoPedir()
        lblPeriodo.Text = "Del " & semana.Item1.ToString("dd/MM/yyyy") & " al " & semana.Item2.ToString("dd/MM/yyyy")
        AsignarTablas()
        ConsultarConsolidadoAlimentoPedir()
    End Sub


    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)
            Dim resultado As Object = cn.Cn_ConsolidadoAlimentoPedirxSemana(obj)

            If TypeOf resultado Is String Then
                e.Result = resultado
            ElseIf TypeOf resultado Is DataTable Then
                Dim tbtmp As DataTable = CType(resultado, DataTable).Copy()
                tbtmp.TableName = "tmp"
                e.Result = tbtmp
            End If
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al cargar los datos")
        ElseIf TypeOf e.Result Is String Then
            msj_advert(e.Result.ToString())
        Else
            clsBasicas.Formato_Tablas_Grid(dtgListadoCantidadInsumos)

            dtgListadoCantidadInsumos.DataSource = Nothing
            Dim tbtmp As DataTable = CType(e.Result, DataTable)
            dtgListadoCantidadInsumos.DataSource = tbtmp

            ColorearColumnas()
        End If
    End Sub

    Sub AsignarTablas()
        Try
            Dim obj As New coControlAlimento With {
                .FechaDesde = semana.Item1,
                .FechaHasta = semana.Item2
            }
            Dim ds As DataSet = cn.Cn_RequerimientoAlimentoxSemana(obj)

            If ds IsNot Nothing AndAlso ds.Tables.Count >= 3 Then
                dtgListadoConsolidado.DataSource = ds.Tables(0)
                clsBasicas.Formato_Tablas_Grid(dtgListadoConsolidado)
                clsBasicas.Filtrar_Tabla(dtgListadoCantidadInsumos, True)
                dtgListadoConsolidado.DisplayLayout.Bands(0).Columns(0).Hidden = True

                Dim dsRequerimientos As New DataSet("tmp")

                dsRequerimientos.Tables.Add(ds.Tables(1).Copy())
                dsRequerimientos.Tables.Add(ds.Tables(2).Copy())
                Dim relation1 As New DataRelation("tb_relacion1", dsRequerimientos.Tables(0).Columns(0), dsRequerimientos.Tables(1).Columns(0), False)
                dsRequerimientos.Relations.Add(relation1)

                dtgListadoRequerimientos.DataSource = dsRequerimientos
                clsBasicas.Formato_Tablas_Grid(dtgListadoRequerimientos)
                dtgListadoRequerimientos.DisplayLayout.Bands(0).Columns(0).Hidden = True
                dtgListadoRequerimientos.DisplayLayout.Bands(0).Columns(0).Hidden = True
                dtgListadoRequerimientos.DisplayLayout.Bands(1).Columns(0).Hidden = True
                dtgListadoRequerimientos.DisplayLayout.Bands(1).Columns(1).Hidden = True

                LblTotalRacionesPreparadas.Text = SumarValoresColumna("Consolidado (TN)").ToString("F2")
            Else
                msj_advert("No se encontraron datos suficientes para las fechas seleccionadas.")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ColorearColumnas()
        If dtgListadoCantidadInsumos.Rows.Count > 0 Then
            Dim colorGrisClaro As Color = Color.LightGray
            Dim totalColumnas As Integer = dtgListadoCantidadInsumos.DisplayLayout.Bands(0).Columns.Count

            If totalColumnas >= 2 Then
                dtgListadoCantidadInsumos.DisplayLayout.Bands(0).Columns(totalColumnas - 1).CellAppearance.BackColor = colorGrisClaro
            End If
        End If
    End Sub

    Public Function ObtenerNumeroSemana(fecha As Date) As Integer
        Dim primerDiaAño As Date = New Date(fecha.Year, 1, 1)
        Dim primerDomingo As Date = primerDiaAño.AddDays((6 - primerDiaAño.DayOfWeek + 7) Mod 7)

        If primerDomingo > primerDiaAño Then
            primerDomingo = primerDomingo.AddDays(-7)
        End If

        Dim numeroSemana As Integer = CInt(Math.Ceiling((fecha - primerDomingo).Days / 7))

        Return numeroSemana
    End Function

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            If (dtgListadoCantidadInsumos.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("INSUMOS UTILIZADOS PARA ALIMENTO CERDO", dtgListadoCantidadInsumos)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListadoCantidadInsumos.InitializeLayout
        Try
            If dtgListadoCantidadInsumos.Rows.Count > 0 Then
                e.Layout.Bands(0).Summaries.Clear()

                Dim totalColumnas As Integer = dtgListadoCantidadInsumos.DisplayLayout.Bands(0).Columns.Count

                For i As Integer = totalColumnas - 1 To 2 Step -1
                    Console.WriteLine(i)
                    clsBasicas.SumarTotales_Formato(dtgListadoCantidadInsumos, e, i)
                Next
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            semana = ObtenerIntervaloSemana(CmbAnios.Text, NumSemana.Value)
            ConsultarOrdenAlimentoPedir()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListadoRequerimientos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListadoRequerimientos.InitializeLayout
        Try
            If (dtgListadoRequerimientos.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListadoRequerimientos, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListadoConsolidado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListadoConsolidado.InitializeLayout
        Try
            If (dtgListadoConsolidado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListadoConsolidado, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListadoConsolidado, e, 2)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub NumSemana_ValueChanged(sender As Object, e As EventArgs) Handles NumSemana.ValueChanged
        If Not String.IsNullOrEmpty(CmbAnios.Text) Then
            semana = ObtenerIntervaloSemana(CmbAnios.Text, NumSemana.Value)
            lblPeriodo.Text = "Del " & semana.Item1.ToString("dd/MM/yyyy") &
                          " al " & semana.Item2.ToString("dd/MM/yyyy")
        End If
    End Sub

    Private Sub CmbAnios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbAnios.SelectedIndexChanged
        If Not String.IsNullOrEmpty(CmbAnios.Text) Then
            semana = ObtenerIntervaloSemana(CmbAnios.Text, NumSemana.Value)
            lblPeriodo.Text = "Del " & semana.Item1.ToString("dd/MM/yyyy") &
                          " al " & semana.Item2.ToString("dd/MM/yyyy")
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class