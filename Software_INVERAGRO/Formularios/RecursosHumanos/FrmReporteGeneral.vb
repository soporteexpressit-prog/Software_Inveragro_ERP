Imports CapaNegocio
Imports CapaObjetos

Public Class FrmReporteGeneral

    Dim cn As New cnControlAsistencia
    Dim tbtmp As New DataTable

    Private Sub FrmReporteGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cbxMeses.SelectedIndex = 12
            cbxTipo.SelectedIndex = 0
            ListarAños()
            ListarPlanteles()
            Consultar()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarAños()
        Try
            Dim dt As New DataTable
            dt = cn.Cn_ListarAñosDeHorarios().Copy
            dt.TableName = "tmp"
            dt.Columns(0).ColumnName = "Seleccione un Año"
            With cbxAños
                .DataSource = dt
                .DisplayMember = dt.Columns(0).ColumnName
                .ValueMember = dt.Columns(0).ColumnName
                If (dt.Rows.Count > 0) Then
                    .Value = dt.Rows(0)(0)
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub ListarPlanteles()
        Try
            Dim dt As New DataTable

            dt = cn.Cn_ListarPlanteles().Copy
            dt.TableName = "tmp"
            dt.Columns(1).ColumnName = "Seleccione un Plantel"

            Dim dtNew As New DataTable
            dtNew.TableName = "tmp"
            dtNew.Columns.Add(dt.Columns(0).ColumnName, dt.Columns(0).DataType)
            dtNew.Columns.Add("Seleccione un Plantel", dt.Columns(1).DataType)

            Dim newRow As DataRow = dtNew.NewRow()
            newRow(0) = 0
            newRow(1) = "TODOS LOS PLANTELES"
            dtNew.Rows.Add(newRow)

            For Each row As DataRow In dt.Rows
                dtNew.ImportRow(row)
            Next

            With cbxListarPlanteles
                .DataSource = dtNew
                .DisplayMember = "Seleccione un Plantel"
                .ValueMember = dt.Columns(0).ColumnName
                .Value = 0
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            Dim mesSeleccionado As Integer? = Nothing
            If cbxMeses.SelectedIndex <> 12 Then
                mesSeleccionado = cbxMeses.SelectedIndex + 1
            End If


            Dim obj As New coControlAsistencia With {
                .Mes = mesSeleccionado,
                .Anio = cbxAños.Value,
                .IdUbicacion = cbxListarPlanteles.Value,
                .Tipo = cbxTipo.SelectedItem
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAsistencia = CType(e.Argument, coControlAsistencia)
            tbtmp = cn.Cn_ReportePagosPorPlantel(obj).Copy
            tbtmp.TableName = "tmp"
            tbtmp.Columns("Codigo").ColumnMapping = MappingType.Hidden
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            ToolStrip1.Enabled = True
            Colorear()
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            clsBasicas.Totales_Formato(dtgListado, e, 1)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 2)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 3)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 4)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Colorear()
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "EVENTUAL", 6)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "PLANILLA", 6)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        If dtgListado.Rows.Count = 0 Then
            msj_advert("No hay datos para exportar.")
            Return
        Else
            clsBasicas.ExportarExcel("REPORTE DE PAGOS POR PLANTEL", dtgListado)
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Consultar()
    End Sub
End Class