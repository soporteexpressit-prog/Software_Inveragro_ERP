Imports CapaNegocio
Imports CapaObjetos

Public Class FrmReporteAlimentoReproduccion
    Dim cn As New cnControlAlimento
    Dim ds As New DataSet
    Public idUbicacion As Integer = 0
    Dim idAlimento As Integer = 0

    Private Sub FrmReporteAlimentoReproduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarAreas()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Inicializar()
        CmbModalidad.SelectedIndex = 0
        DtpFechaDesde.Value = Now.Date
        DtpFechaHasta.Value = Now.Date
        CbxOmitirArea.Checked = True
        cmbArea.Visible = False
        LblArea.Visible = False
        clsBasicas.Formato_Tablas_Grid(DtgListado)
        clsBasicas.Formato_Tablas_Grid(DtgListadoConsumoALimento)
        clsBasicas.Filtrar_Tabla(DtgListado, True)
    End Sub

    Sub ListarAreas()
        Dim cn As New cnArea
        Dim tb As New DataTable
        tb = cn.Cn_Listar().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Área"
        With cmbArea
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub Consultar()
        If DtpFechaDesde.Value > DtpFechaHasta.Value Then
            msj_advert("La fecha 'Desde' debe ser anterior o igual a la fecha 'Hasta'.")
            Return
        End If

        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True

            Dim obj As New coControlAlimento With {
                .IdUbicacion = idUbicacion,
                .FechaDesde = DtpFechaDesde.Value,
                .FechaHasta = DtpFechaHasta.Value,
                .Tipo = CmbModalidad.Text,
                .IdArea = If(CbxOmitirArea.Checked, 0, cmbArea.Value)
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)

            ds = cn.Cn_ReporteAlimentoPorPlantelReproductor(obj).Copy
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Consultar()
    End Sub

    Private Sub CbxOmitirArea_CheckedChanged(sender As Object, e As EventArgs) Handles CbxOmitirArea.CheckedChanged
        cmbArea.Visible = Not CbxOmitirArea.Checked
        LblArea.Visible = Not CbxOmitirArea.Checked
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class