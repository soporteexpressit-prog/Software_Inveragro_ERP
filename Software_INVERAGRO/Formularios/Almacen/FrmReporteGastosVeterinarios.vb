Imports CapaNegocio
Imports CapaObjetos

Public Class FrmReporteGastosVeterinarios

    Dim tbtmp As New DataTable
    Dim cn As New cnProducto
    Public op As Integer
    Private Sub FrmReporteGastosVeterinarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtpFechaDesde.Value = Date.Now
            dtpFechaHasta.Value = Date.Now
            ListarPlanteles()
            If op = 1 Then
                Me.Text = "Reporte Valorizado de Almacén"
                lbltitulo.Text = "Reporte Valorizado de Almacén"
                Label1.Visible = False
                dtpFechaDesde.Visible = False
                Label2.Visible = False
                dtpFechaHasta.Visible = False
            End If
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
            If op = 1 Then
                tbtmp = cn.Cn_ReportevalorizadoAlmacen(obj).Copy
            Else
                tbtmp = cn.Cn_ReporteGastosVeterinarios(obj).Copy
            End If
            tbtmp.TableName = "tmp"
            If op <> 1 Then
                tbtmp.Columns("idProducto").ColumnMapping = MappingType.Hidden
            End If
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

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            ' Antes de agregar la fila de totales
            If dtgListado.DisplayLayout.Bands(0).Summaries.Count > 0 Then
                dtgListado.DisplayLayout.Bands(0).Summaries.Clear()
            End If
            ' Ahora sí agrega los totales
            clsBasicas.SumarTotales_Formato(dtgListado, e, 4)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        If dtgListado.Rows.Count = 0 Then
            msj_advert("No hay datos para exportar.")
            Return
        Else
            clsBasicas.ExportarExcel("REPORTE DE GASTOS VETERINARIOS", dtgListado)
        End If
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub
End Class