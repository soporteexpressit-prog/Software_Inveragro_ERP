Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmReporteAlimentoEngorde
    Dim cn As New cnControlAlimento
    Dim ds As New DataSet
    Public idUbicacion As Integer = 0
    Public valorPlantel As String = ""
    Dim idAlimento As Integer = 0

    Private Sub FrmReporteAlimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LblPlantel.Text = valorPlantel
            ListarCampañas()
            Consultar()
            clsBasicas.Formato_Tablas_Grid(DtgListado)
            clsBasicas.Formato_Tablas_Grid(DtgListadoConsumoALimento)
            clsBasicas.Filtrar_Tabla(DtgListado, True)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarCampañas()
        Dim obj As New coControlAlimento
        obj.IdUbicacion = idUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarCampañasPorPlantel(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Campaña"
        With CmbCampanias
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True

            Dim obj As New coControlAlimento With {
                .IdUbicacion = idUbicacion,
                .Codigo = CmbCampanias.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)

            ds = cn.Cn_ReporteAlimentoPorPlantel(obj).Copy
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
            DtgListado.DataSource = ds.Tables(0)
            DtgListadoConsumoALimento.DataSource = ds.Tables(2)
        End If
    End Sub

    Private Sub CmbCampanias_ValueChanged(sender As Object, e As EventArgs) Handles CmbCampanias.ValueChanged
        If CmbCampanias.Value IsNot Nothing Then
            Consultar()
        End If
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            If (DtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE DE ALIMENTO POR CAMPAÑA", DtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class