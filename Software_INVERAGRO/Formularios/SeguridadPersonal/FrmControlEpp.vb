Imports CapaNegocio
Imports CapaObjetos

Public Class FrmControlEpp
    Dim cn As New cnControlEpp
    Dim _Operacion As Integer
    Dim ds As New DataSet

    Private Sub FrmControlEpp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        cmbEstadoEpp.SelectedIndex = 0
        Consultar()
    End Sub
    Sub Consultar()
        Try
            If dtpFechaDesde.Value > dtpFechaHasta.Value Then
                msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
                Return
            End If

            Dim obj As New coControlEpp With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .Estado = cmbEstadoEpp.Text
            }
            ds = cn.Cn_Consultar(obj).Copy
            ds.DataSetName = "tmp"

            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(0), False)

            ds.Relations.Add(relation1)
            dtgListado.DataSource = ds
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            dtgListado.DisplayLayout.Bands(1).Columns(0).Hidden = True

            AjustarColumnasPorEstado(cmbEstadoEpp.Text)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnBuscarEpp_Click(sender As Object, e As EventArgs) Handles btnBuscarEpp.Click
        Consultar()
    End Sub

    Private Sub AjustarColumnasPorEstado(estado As String)
        If estado <> "ANULADO" Then
            dtgListado.DisplayLayout.Bands(0).Columns(8).Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns(9).Hidden = True
        End If

        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", 7)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ATENDIDO", 7)
    End Sub


    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(1)
                .Columns(0).Hidden = True
            End With
            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 1)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoSGctrleqpro.Click
        Try
            Dim f As New FrmMantenimientoEpp
            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
    Sub ImprimirListado()
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_FormatoEpp.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(ds)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ReporteDeEntregaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeEntregaToolStripMenuItem.Click
        ImprimirListado()
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportarSGctrleqpro.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL-EPP", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnularSGctrleqpro.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim estado As String = activeRow.Cells(7).Value.ToString()
                    If estado = "ANULADO" Then
                        msj_advert(MensajesSistema.mensajesGenerales("YA_FUE_ANULADO_CANCELADO"))
                    Else
                        Dim idEntrega As Integer = Convert.ToInt32(activeRow.Cells(0).Value)
                        Dim f As New FrmAnularEntregaEpp With {
                            .Id_EntregaEpp = idEntrega
                        }
                        f.ShowDialog()
                        Consultar()
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class