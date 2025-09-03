Imports CapaNegocio
Imports CapaObjetos

Public Class FrmReporteTrabajadoresAsistencia

    Dim cn As New cnControlAsistencia
    Dim tbtmp As New DataTable

    Private Sub FrmReporteTrabajadoresAsistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cbxMeses.SelectedIndex = 12
            cbxTipoPlanilla.SelectedIndex = 0
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
            With cbxListarPlanteles
                .DataSource = dt
                .DisplayMember = dt.Columns(1).ColumnName
                .ValueMember = dt.Columns(0).ColumnName
                If (dt.Rows.Count > 0) Then
                    .Value = dt.Rows(0)(0)
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            Dim mesSeleccionado As Integer
            If cbxMeses.SelectedIndex = cbxMeses.Items.Count - 1 Then
                mesSeleccionado = 0
            Else
                mesSeleccionado = cbxMeses.SelectedIndex + 1
            End If

            Dim obj As New coControlAsistencia With {
                .Anio = cbxAños.Value,
                .Mes = mesSeleccionado,
                .IdUbicacion = cbxListarPlanteles.Value,
                .Tipo = cbxTipoPlanilla.SelectedItem.ToString()
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAsistencia = CType(e.Argument, coControlAsistencia)
            tbtmp = cn.Cn_ReporteAsistenciaTrabajadoresPorPlantel(obj).Copy
            tbtmp.TableName = "tmp"
            tbtmp.Columns("idPersona").ColumnMapping = MappingType.Hidden
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
            'Colorear()
        End If
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        If dtgListado.Rows.Count = 0 Then
            msj_advert("No hay datos para exportar.")
            Return
        Else
            clsBasicas.ExportarExcel("REPORTE DE DÍAS DE ASISTENCIA DE TRABAJADORES", dtgListado)
        End If
    End Sub
End Class