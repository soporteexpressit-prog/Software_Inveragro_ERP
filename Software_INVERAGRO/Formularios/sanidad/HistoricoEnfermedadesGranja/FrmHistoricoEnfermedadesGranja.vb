Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports System.ComponentModel
Imports System.IO

Public Class FrmHistoricoEnfermedadesGranja
    Dim cn As New cnControlMedico
    Dim ds As New DataSet

    Private Sub FrmHistoricoEnfermedadesGranja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Consultar()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        GrupoFiltros.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        GrupoFiltros.Enabled = True
        ToolStrip1.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlMedico With {
                .FechaInicio = dtpFechaDesde.Value,
                .FechaFin = dtpFechaHasta.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlMedico = CType(e.Argument, coControlMedico)

            ds = cn.Cn_ConsultarHistorialEnfermedad(obj).Copy
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
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = ds.Tables(0)
            DesbloquearControladores()
            dtgListado.DisplayLayout.Bands(0).Columns("idArea").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("idUbicacion").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("idEnfermedad").Hidden = True
            dtgListado.DisplayLayout.Bands(1).Columns("idDetHistorialProtocolo").Hidden = True
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns("btnVerArchivo").ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                .Columns("btnVerArchivo").Width = 100
                .Columns("btnVerArchivo").Header.Caption = "Ver Archivo"
                .Columns("btnVerArchivo").Style = UltraWinGrid.ColumnStyle.Button
                .Columns("btnVerArchivo").CellButtonAppearance.Image = My.Resources.adjuntar
                .Columns("btnVerArchivo").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With

            With e.Layout.Bands(1)
                .Columns("btnVerAnalisis").ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                .Columns("btnVerAnalisis").Width = 120
                .Columns("btnVerAnalisis").Header.Caption = "Ver Análisis"
                .Columns("btnVerAnalisis").Style = UltraWinGrid.ColumnStyle.Button
                .Columns("btnVerAnalisis").CellButtonAppearance.Image = My.Resources.adjuntar
                .Columns("btnVerAnalisis").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            Dim activeRow As UltraWinGrid.UltraGridRow = e.Cell.Row

            If activeRow IsNot Nothing Then
                Select Case activeRow.Band.Index
                    Case 0 ' Primer nivel (Plantel, Área, Enfermedad, etc.)
                        If e.Cell.Column.Key = "btnVerArchivo" Then
                            Dim idProtocoloSanitario As Integer = CInt(activeRow.Cells("idProtocoloSanitario").Value)
                            ConsultarArchivoPrincipal(idProtocoloSanitario)
                        End If

                    Case 1 ' Segundo nivel (Detalle análisis)
                        If e.Cell.Column.Key = "btnVerAnalisis" Then
                            Dim idDetHistorialProtocolo As Integer = CInt(activeRow.Cells("idDetHistorialProtocolo").Value)
                            ConsultarArchivo(idDetHistorialProtocolo)
                        End If

                    Case Else
                        msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
                End Select
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ConsultarArchivo(codigo As Integer)
        Try
            Dim obj As New coControlMedico
            obj.Codigo = codigo
            cn.Cn_ObtenerArchivoAnalisis(obj)

            Dim pdfData As Byte() = obj.Archivo
            If pdfData IsNot Nothing AndAlso pdfData.Length > 0 Then
                Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "archivo_analisis_" & codigo.ToString & ".pdf")
                File.WriteAllBytes(tempFilePath, pdfData)
                Process.Start(tempFilePath)
            Else
                msj_advert("No se encontró el archivo para este detalle.")
            End If
        Catch ex As Exception
            msj_advert("No se encontró el archivo para este detalle.")
        End Try
    End Sub

    Private Sub ConsultarArchivoPrincipal(codigo As Integer)
        Try
            Dim obj As New coControlMedico
            obj.Codigo = codigo
            cn.Cn_ObtenerArchivoRegistroPrincipal(obj)

            Dim pdfData As Byte() = obj.Archivo
            If pdfData IsNot Nothing AndAlso pdfData.Length > 0 Then
                Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "archivo_" & codigo.ToString & ".pdf")
                File.WriteAllBytes(tempFilePath, pdfData)
                Process.Start(tempFilePath)
            Else
                msj_advert("No se encontró el archivo para este registro.")
            End If
        Catch ex As Exception
            msj_advert("No se encontró el archivo para este registro.")
        End Try
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Try
            Dim frm As New FrmMantHistoricoEnfermedades With {
                .operacion = 0,
                .codigo = 0
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click

        Dim activeRow As UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim idProtocoloSanitario As Integer = CInt(activeRow.Cells("idProtocoloSanitario").Value)
                    Dim idUbicacion As Integer = CInt(activeRow.Cells("idUbicacion").Value)
                    Dim idArea As Integer = CInt(activeRow.Cells("idArea").Value)
                    Dim idEnfermedad As Integer = CInt(activeRow.Cells("idEnfermedad").Value)
                    Dim enfermedad As String = activeRow.Cells("Enfermedad").Value.ToString
                    Dim costoPrograma As String = activeRow.Cells("Costo Programa").Value.ToString
                    Dim metodo As String = activeRow.Cells("Método").Value.ToString
                    Dim fechaRegistro As Date = CDate(activeRow.Cells("Fecha Registro").Value)

                    Dim frm As New FrmMantHistoricoEnfermedades With {
                        .operacion = 1,
                        .codigo = idProtocoloSanitario,
                        .idUbicacion = idUbicacion,
                        .idArea = idArea,
                        .idEnfermedad = idEnfermedad,
                        .enfermedad = enfermedad,
                        .costoPrograma = costoPrograma,
                        .metodo = metodo,
                        .fecha = fechaRegistro
                    }
                    frm.ShowDialog()
                    Consultar()
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

    Private Sub BtnAdjuntarAnalisis_Click(sender As Object, e As EventArgs) Handles BtnAdjuntarAnalisis.Click
        Dim activeRow As UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim idProtocoloSanitario As Integer = CInt(activeRow.Cells("idProtocoloSanitario").Value)

                    If activeRow.HasChild() Then
                        Dim nroFilas As Integer = activeRow.ChildBands(0).Rows.Count
                        If nroFilas = 3 Then
                            msj_advert("No se puede adjuntar más de 3 análisis por registro.")
                            Return
                        End If
                    End If

                    Dim frm As New FrmRegistrarAnalisis With {
                        .codigo = idProtocoloSanitario
                    }
                    frm.ShowDialog()
                    Consultar()
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

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click

        If dtgListado.Rows.Count = 0 Then
            msj_advert("No hay datos para exportar")
            Return
        End If

        clsBasicas.ExportarExcel("Reporte Histórico de Enfermedades de Alto Impacto en Granja", dtgListado)
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Close()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub
End Class