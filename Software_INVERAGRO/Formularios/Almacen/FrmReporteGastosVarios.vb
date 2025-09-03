Imports CapaNegocio
Imports CapaObjetos

Public Class FrmReporteGastosVarios

    Dim tbtmp As New DataTable
    Dim cn As New cnProducto
    Private Sub FrmReporteGastosVarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtpFechaDesde.Value = Date.Now
            dtpFechaHasta.Value = Date.Now
            ListarPlanteles()
            Consultar()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable

        tb = cn.Cn_ListarPlanteles().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"

        Dim tbNew As New DataTable
        tbNew.TableName = "tmp"
        tbNew.Columns.Add(tb.Columns(0).ColumnName, tb.Columns(0).DataType)
        tbNew.Columns.Add("Seleccione un Plantel", tb.Columns(1).DataType)

        Dim newRow As DataRow = tbNew.NewRow()
        newRow(0) = 0
        newRow(1) = "TODOS LOS PLANTELES"
        tbNew.Rows.Add(newRow)

        For Each row As DataRow In tb.Rows
            tbNew.ImportRow(row)
        Next

        With CmbUbicacion
            .DataSource = tbNew
            .DisplayMember = "Seleccione un Plantel"
            .ValueMember = tb.Columns(0).ColumnName
            .Value = 0
        End With
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            Dim obj As New coProductos With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .IdUbicacion = CmbUbicacion.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coProductos = CType(e.Argument, coProductos)
            tbtmp = cn.Cn_ReporteGastosAsignaciones(obj).Copy
            tbtmp.TableName = "tmp"
            tbtmp.Columns("idProducto").ColumnMapping = MappingType.Hidden
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
        End If
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        If dtgListado.Rows.Count = 0 Then
            msj_advert("No hay datos para exportar.")
            Return
        Else
            clsBasicas.ExportarExcel("REPORTE DE GASTOS DE ASIGNACIÓN", dtgListado)
        End If
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub
End Class