Imports CapaNegocio
Imports CapaObjetos

Public Class FrmReporteMortalidadLoteCompleto
    Dim cn As New cnControlLoteDestete
    Dim tbtmp As New DataTable
    Private search As Boolean = False

    Private Sub FrmReporteMortalidadLoteCompleto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarLotes()
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Sub ListarLotes()
        Dim cn As New cnControlLoteDestete
        Dim obj As New coControlLoteDestete With {
           .Anio = CmbAnios.Text
        }
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarLotesUnicos(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Lote"
        With CmbLotes
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
        search = True
    End Sub


    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            BarraNavegacion.Enabled = False
            Dim obj As New coControlLoteDestete With {
                .IdLote = CmbLotes.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ConsultarMortalidadGeneralxLote(obj).Copy
            tbtmp.TableName = "tmp"
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
            BarraNavegacion.Enabled = True
        End If
    End Sub

    Private Sub BtnExportarhistoricomortalidad_Click(sender As Object, e As EventArgs) Handles BtnExportarhistoricomortalidad.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE DE MORTALIDAD POR LOTE", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CmbAnios_TextChanged(sender As Object, e As EventArgs) Handles CmbAnios.TextChanged
        If (search) Then
            ListarLotes()
        End If
    End Sub

    Private Sub CmbLotes_ValueChanged(sender As Object, e As EventArgs) Handles CmbLotes.ValueChanged
        If CmbLotes.Value IsNot Nothing Then
            Consultar()
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 0)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class