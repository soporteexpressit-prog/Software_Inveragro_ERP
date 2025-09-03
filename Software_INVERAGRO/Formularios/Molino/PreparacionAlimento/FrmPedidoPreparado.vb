Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmPedidoPreparado
    Dim cn As New cnControlAlimento
    Dim semana As Tuple(Of Date, Date)
    Dim ds As New DataSet

    Private Sub FrmPedidoPreparado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListadoPreparacionRacion)
            Ptbx_Cargando.Visible = True
            Timer1.Interval = 500
            Timer1.Enabled = False
            dtpFecha.Value = DateTime.Now
            ConsultarPedidosAlimentoPorTipoAlimento()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Consultar(Optional ByVal fechaDesde As Date? = Nothing, Optional ByVal fechaHasta As Date? = Nothing)
        Try
            If Not BackgroundWorker1.IsBusy Then
                Ptbx_Cargando.Visible = True
                Dim obj As New coControlAlimento With {
                    .FechaDesde = semana.Item1,
                    .FechaHasta = semana.Item2,
                    .Estado = "PREPARADO"
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

            ds = cn.Cn_AgruparPedidoAlimentoxTipoAlimento(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(1).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(2).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("Ver Medicación").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idUbicacionDestino").ColumnMapping = MappingType.Hidden
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
            dtgListadoPreparacionRacion.DataSource = ds.Tables(0)
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListadoPreparacionRacion.Rows.Count > 0) Then
            Dim estado As Integer = 5

            'estadoRepetidora
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.Green, Color.White, "PREPARADO", estado)

            'centrar columnas
            With dtgListadoPreparacionRacion.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Public Function ObtenerSemana(fecha As Date) As Tuple(Of Date, Date)
        Dim diaSemana As Integer = fecha.DayOfWeek
        Dim fechaInicioSemana As Date = fecha.AddDays(-diaSemana)
        Dim fechaFinSemana As Date = fechaInicioSemana.AddDays(6)

        Return Tuple.Create(fechaInicioSemana, fechaFinSemana)
    End Function

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        Timer1.Stop()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        ConsultarPedidosAlimentoPorTipoAlimento()
    End Sub

    Private Sub ConsultarPedidosAlimentoPorTipoAlimento()
        semana = ObtenerSemana(dtpFecha.Value)
        lblPeriodo.Text = "Del " & semana.Item1.ToString("dd/MM/yyyy") & " al " & semana.Item2.ToString("dd/MM/yyyy")
        Consultar()
    End Sub

    Private Sub btnExportarMolinoalica_Click(sender As Object, e As EventArgs) Handles btnExportarMolinoalica.Click
        Try
            If (dtgListadoPreparacionRacion.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("PEDIDOS PREPARADOS", dtgListadoPreparacionRacion)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class