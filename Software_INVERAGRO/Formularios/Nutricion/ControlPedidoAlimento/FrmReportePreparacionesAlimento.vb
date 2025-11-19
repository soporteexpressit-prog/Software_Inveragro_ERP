Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmReportePreparacionesAlimento
    Dim cn As New cnControlAlimento
    Dim ds As New DataSet
    Dim tbtmp As New DataTable
    Dim semana As (Date, Date)

    Private Sub FrmReportePreparacionesAlimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid_SegundaColumnaEditable(dtgListadoPedidosAlimento)
            clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListadoCantidadInsumos)
            Inicializar()
            ConsultarPedidoAlimento()
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

    Private Sub BloquearControles()
        CmbAnios.Enabled = False
        Ptbx_Cargando.Visible = True
        NumSemana.Enabled = False
        CargandoIcon.Visible = True
    End Sub

    Private Sub DesbloquearControles()
        CmbAnios.Enabled = True
        Ptbx_Cargando.Visible = False
        NumSemana.Enabled = True
        CargandoIcon.Visible = False
    End Sub


    Sub ConsultarPedidoAlimento()
        If CmbAnios.Text = "" Then
            Return
        End If

        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()

            Dim obj As New coControlAlimento With {
                .Estado = "TODOS",
                .FechaDesde = semana.Item1,
                .FechaHasta = semana.Item2
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)

            ds = cn.Cn_ListarRequerimientoAlimentoReportePreparacion(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns("idSalida").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idSalida").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idDetalleSalida").ColumnMapping = MappingType.Hidden
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListadoPedidosAlimento.DataSource = ds.Tables(0)
            DesbloquearControles()
            Colorear()

            ' Consultar insumos con todos los IDs al cargar por primera vez
            ConsultarInsumosUtilizadosPreparacion()
        End If
    End Sub

    Sub Colorear()
        If (dtgListadoPedidosAlimento.Rows.Count > 0) Then
            Dim estadoPreparacion As Integer = 4
            Dim estadoRecepcion As Integer = 5

            'estadoPreparacion
            clsBasicas.Colorear_SegunValor(dtgListadoPedidosAlimento, Color.LightGray, Color.Black, "PENDIENTE", estadoPreparacion)
            clsBasicas.Colorear_SegunValor(dtgListadoPedidosAlimento, Color.LightYellow, Color.Black, "PARCIAL", estadoPreparacion)
            clsBasicas.Colorear_SegunValor(dtgListadoPedidosAlimento, Color.LightGreen, Color.Black, "PREPARADO", estadoPreparacion)
            clsBasicas.Colorear_SegunValor(dtgListadoPedidosAlimento, Color.Red, Color.White, "CANCELADO", estadoPreparacion)

            'estadoRecepcion
            clsBasicas.Colorear_SegunValor(dtgListadoPedidosAlimento, Color.Green, Color.White, "DESPACHADO", estadoRecepcion)
            clsBasicas.Colorear_SegunValor(dtgListadoPedidosAlimento, Color.OrangeRed, Color.White, "SIN DESPACHO", estadoRecepcion)
            clsBasicas.Colorear_SegunValor(dtgListadoPedidosAlimento, Color.LightYellow, Color.Black, "PARCIAL", estadoRecepcion)
            clsBasicas.Colorear_SegunValor(dtgListadoPedidosAlimento, Color.Red, Color.White, "CANCELADO", estadoRecepcion)


            'centrar columnas
            With dtgListadoPedidosAlimento.DisplayLayout.Bands(0)
                .Columns(estadoPreparacion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoRecepcion).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ConsultarPedidoAlimento()
    End Sub

    Private Sub dtgListadoPedidosAlimento_CellChange(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListadoPedidosAlimento.CellChange
        Try
            ' Verificar que sea la columna de check (columna 1, la segunda columna)
            If e.Cell.Column.Index = 1 AndAlso TypeOf e.Cell.Value Is Boolean Then
                ' Consultar los insumos utilizados con las filas seleccionadas
                ConsultarInsumosUtilizadosPreparacion()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ConsultarInsumosUtilizadosPreparacion()
        Try
            dtgListadoCantidadInsumos.DataSource = Nothing
            dtgListadoCantidadInsumos.Refresh()
            If dtgListadoPedidosAlimento.Rows.Count = 0 Then
                Return
            End If

            ' Obtener los IDs de las filas con check marcado
            Dim idsSeleccionados As String = ObtenerIdsSeleccionados()

            ' Si no hay ningún check marcado, limpiar el grid de insumos
            If String.IsNullOrEmpty(idsSeleccionados) OrElse idsSeleccionados = "0" Then
                dtgListadoCantidadInsumos.DataSource = Nothing
                Return
            End If

            If Not BackgroundWorker2.IsBusy Then
                CargandoIcon.Visible = True

                Dim obj As New coControlAlimento With {
                    .IdsSalida = idsSeleccionados
                }

                BackgroundWorker2.RunWorkerAsync(obj)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function ObtenerIdsSeleccionados() As String
        Try
            dtgListadoPedidosAlimento.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
            Dim ids As New List(Of String)()

            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListadoPedidosAlimento.Rows
                ' Verificar que no sea una fila de filtro o de resumen
                If row.IsDataRow AndAlso Not row.IsFilteredOut Then
                    ' Verificar si existe la columna del checkbox (índice 1) y si está marcado
                    If row.Cells.Count > 1 AndAlso TypeOf row.Cells(1).Value Is Boolean Then
                        If CBool(row.Cells(1).Value) = True Then
                            ' Agregar el idSalida (columna oculta, ajusta el índice según tu estructura)
                            Dim idSalida As String = row.Cells("idSalida").Value.ToString()
                            If Not String.IsNullOrEmpty(idSalida) Then
                                ids.Add(idSalida)
                            End If
                        End If
                    End If
                End If
            Next

            ' Si no hay IDs seleccionados, retornar "0" o string vacío
            If ids.Count = 0 Then
                Return "0"
            End If

            ' Retornar los IDs en formato "123,354,245"
            Return String.Join(",", ids)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
            Return "0"
        End Try
    End Function

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)

            ' Consultar los insumos utilizados en las preparaciones seleccionadas
            tbtmp = cn.Cn_InsumosUtilizadoPreparacionxIdSalida(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        CargandoIcon.Visible = False

        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Insumos Utilizados")
        Else
            dtgListadoCantidadInsumos.DataSource = CType(e.Result, DataTable)

            ' Aplicar formato al grid de insumos si es necesario
            If dtgListadoCantidadInsumos.Rows.Count > 0 Then
                clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListadoCantidadInsumos)
            End If
        End If
    End Sub

    Private Sub dtgListadoCantidadInsumos_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListadoCantidadInsumos.InitializeLayout
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class