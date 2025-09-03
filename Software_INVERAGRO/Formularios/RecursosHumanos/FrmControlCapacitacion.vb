Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmControlCapacitacion
    Dim cn As New cnControlCapacitacion
    Dim _Operacion As Integer
    Dim ds As New DataSet

    Private Sub FrmControlCapacitacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        CmbEstado.SelectedIndex = 0
        Consultar()
    End Sub

    Sub Consultar()
        Try
            If dtpFechaDesde.Value > dtpFechaHasta.Value Then
                msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
                Return
            End If

            Dim obj As New coControlCapacitacion With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .Estado = CmbEstado.Text
            }
            ds = cn.Cn_Consultar(obj).Copy
            ds.DataSetName = "tmp"

            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(0), False)

            ds.Relations.Add(relation1)
            dtgListado.DataSource = ds
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            dtgListado.DisplayLayout.Bands(1).Columns(0).Hidden = True
            dtgListado.DisplayLayout.Bands(1).Columns(1).Hidden = True

            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "Sin Evidencia", 8)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "Con Evidencia", 8)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "CANCELADO", 9)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "REGISTRADO", 9)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnBuscarCapacitaciones_Click(sender As Object, e As EventArgs) Handles btnBuscarCapacitaciones.Click
        Consultar()
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportarRrhhctrlcapaci.Click
        Try
            clsBasicas.ExportarExcel("Control Capacitaciones", dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ReporteDeEntregaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeEntregaToolStripMenuItem.Click
        ImprimirReportePorCapacitacion()
    End Sub

    Sub ImprimirReportePorCapacitacion()
        Dim selectedRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If selectedRow Is Nothing Then
            MsgBox("Por favor, seleccione un registro.")
            Return
        End If
        Dim selectedId As Integer = CInt(selectedRow.Cells(0).Value)
        Dim obj As New coControlCapacitacion
        Dim dsCapacitacion As New DataSet
        obj.Codigo = selectedId
        dsCapacitacion = cn.Cn_ConsultarId(obj).Copy

        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_ParticipantesCapacitacion.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ReporteDeCapacitacionesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ImprimirReporteDeCapacitaciones()
    End Sub

    Sub ImprimirReporteDeCapacitaciones()
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_Capacitaciones.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(ds.Tables.Item(0))
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ReporteDeCapacitacionesToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ReporteDeCapacitacionesToolStripMenuItem.Click
        ImprimirReporteDeCapacitaciones()
    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        If e.Row.Band.Index = 0 Then
            Dim colVerPDF As Infragistics.Win.UltraWinGrid.UltraGridColumn
            If dtgListado.DisplayLayout.Bands(0).Columns.Exists("Ver Evidencia") Then
                colVerPDF = dtgListado.DisplayLayout.Bands(0).Columns("Ver Evidencia")
                colVerPDF.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerPDF.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                If Not e.ReInitialize Then
                    e.Row.Cells("Ver Evidencia").Value = "Ver Evidencia"
                    e.Row.Cells("Ver Evidencia").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                End If
            End If
        End If
    End Sub
    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            With dtgListado
                If (e.Cell.Column.Key = "Ver Evidencia") Then
                    Dim estadoPDF As String = .ActiveRow.Cells("Estado Evidencia").Value.ToString()
                    If estadoPDF = "Sin Evidencia" Then
                        msj_advert(MensajesSistema.mensajesGenerales("SIN_ARCHIVO_EVIDENCIA"))
                        Return
                    End If

                    Dim idCapacitacion As Integer = CInt(.ActiveRow.Cells(0).Value)
                    Dim obj As New coControlCapacitacion With {
                        .Codigo = idCapacitacion
                    }

                    Dim rutaArchivoEvidencia As String = cn.Cn_ObtenerRutaEvidencia(obj)
                    If rutaArchivoEvidencia IsNot Nothing AndAlso rutaArchivoEvidencia.Length > 0 Then
                        Dim f As New FrmEvidenciaCapacitacion With {
                            .rutaArchivoEvidencia = rutaArchivoEvidencia
                        }
                        f.ShowDialog()
                    Else
                        msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAdjuntar_Click(sender As Object, e As EventArgs) Handles btnAdjuntarRrhhctrlcapaci.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim estadoEvidencia = dtgListado.ActiveRow.Cells(9).Value.ToString()
                    If estadoEvidencia = "Con Evidencia" Then
                        msj_advert(MensajesSistema.mensajesGenerales("CON_ARCHIVO_EVIDENCIA"))
                        Return
                    End If
                    Dim CapacitacionId As Integer
                    Integer.TryParse(dtgListado.ActiveRow.Cells(0).Value.ToString(), CapacitacionId)
                    Dim f As New FrmGuardarEvidenciaCapacitacion With {
                        .CapacitacionId = CapacitacionId
                    }
                    f.ShowDialog()
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

    Private Sub BtnNuevaCapacitacion_Click(sender As Object, e As EventArgs) Handles BtnNuevaCapacitacion.Click
        Try
            Dim f As New FrmRegistrarCapacitacion
            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Try
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE CANCELAR ESTA CAPACITACIÓN?", "CONFIRMAR REGISTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim obj As New coControlCapacitacion With {
                    .Codigo = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                }

                Dim MensajeBgWk As String = cn.Cn_CancelarCapacitacion(obj)

                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Consultar()
                Else
                    msj_advert(MensajeBgWk)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class