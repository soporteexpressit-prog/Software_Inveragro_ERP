Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmRegularizacionCerdo
    Dim cn As New cnControlLoteDestete
    Dim ds As New DataSet

    Private Sub FrmRegularizacionCerdo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarPlanteles()
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        CmbEstado.SelectedIndex = 0
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid(dtgListado)
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

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlanteles().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbUbicacion
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub Consultar()
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If

        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlLoteDestete With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .IdPlantel = CmbUbicacion.Value,
                .Estado = CmbEstado.Text
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)

            ds = cn.Cn_ConsultarRegularizacionPlantel(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns("idRegularizarCerdo").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idRegularizarCerdo").ColumnMapping = MappingType.Hidden
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
            If CmbUbicacion.Value = 1 Or CmbUbicacion.Value = 2 Then
                dtgListado.DisplayLayout.Bands(0).Columns("Campaña").Hidden = True
            Else
                dtgListado.DisplayLayout.Bands(0).Columns("Campaña").Hidden = False
            End If
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim tipo As Integer = 10
            Dim estado As Integer = 11

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", estado)

            'tipo
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "SALIDA", tipo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "INGRESO", tipo)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(tipo).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub

    Private Sub BtnAnular_Click(sender As Object, e As EventArgs) Handles BtnAnularregularizaciondecerdospro.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim estado As String = activeRow.Cells(8).Value.ToString()
                    If estado = "ANULADO" Then
                        msj_advert(MensajesSistema.mensajesGenerales("YA_FUE_ANULADO_CANCELADO"))
                    Else
                        Dim obj As New coControlLoteDestete With {
                            .IdRegularizarCerdo = activeRow.Cells(0).Value
                        }

                        If (MessageBox.Show("¿ESTÁ SEGURO DE CANCELAR ESTA REGULARIZACIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                            Return
                        End If

                        Dim MensajeBgWk As String = cn.Cn_AnularRegularizacionCerdo(obj)
                        If (obj.Coderror = 0) Then
                            msj_ok(MensajeBgWk)
                            Consultar()
                        Else
                            msj_advert(MensajeBgWk)
                        End If
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

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportarregularizaciondecerdospro.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL-REGULARIZACIÓN", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnNuevoregularizaciondecerdospro_Click(sender As Object, e As EventArgs) Handles BtnNuevoregularizaciondecerdospro.Click
        Try
            If CmbUbicacion.Value = 1 OrElse CmbUbicacion.Value = 2 Then
                Dim frm As New FrmRegularizarCerdosReproduccion With {
                    .valorPlantel = CmbUbicacion.Text,
                    .idPlantel = CmbUbicacion.Value
                }
                frm.ShowDialog()
            Else
                Dim frm As New FrmRegistrarRegularizacionSalida With {
                    .valorPlantel = CmbUbicacion.Text,
                    .idPlantel = CmbUbicacion.Value
                }
                frm.ShowDialog()
            End If

            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmRegularizacionCerdo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnBuscar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class