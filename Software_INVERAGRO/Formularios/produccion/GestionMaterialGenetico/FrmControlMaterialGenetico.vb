Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlMaterialGenetico
    Dim cn As New cnControlMaterialGenetico
    Dim ds As New DataSet

    Private Sub FrmControlMaterialGenetico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        Ptbx_Cargando.Visible = True
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        CmbTipo.SelectedIndex = 0
        CmbEstado.SelectedIndex = 0
    End Sub

    Private Sub BloquearControles()
        Ptbx_Cargando.Visible = True
        ToolStrip1.Enabled = False
        GrupoFiltros.Enabled = False
    End Sub

    Private Sub DesbloquearControles()
        Ptbx_Cargando.Visible = False
        ToolStrip1.Enabled = True
        GrupoFiltros.Enabled = True
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlantelesReproduccion().Copy
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
        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()

            Dim obj As New coControlMaterialGenetico With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .Tipo = CmbTipo.Text,
                .IdUbicacionOrigen = CmbUbicacion.Value,
                .Estado = CmbEstado.Text
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlMaterialGenetico = CType(e.Argument, coControlMaterialGenetico)
            ds = cn.Cn_Consultar(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(1).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(1).ColumnMapping = MappingType.Hidden
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
            DesbloquearControles()
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim tipoAdquisicion As Integer = 11
            Dim estadoConsumo As Integer = 12
            Dim estadoSemen As Integer = 13
            Dim estado As Integer = 14

            'tipoAdquisicion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "GRANJA", tipoAdquisicion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightBlue, Color.Black, "COMPRADO", tipoAdquisicion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightPink, Color.Black, "REGULARIZACIÓN", tipoAdquisicion)

            'estadoConsumo
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "COMPLETO", estadoConsumo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightYellow, Color.Goldenrod, "PARCIAL", estadoConsumo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estadoConsumo)

            'estadoSemen
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "ÓPTIMO", estadoSemen)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightYellow, Color.Goldenrod, "PRÓXIMO VENCER", estadoSemen)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.MistyRose, Color.IndianRed, "NO ÓPTIMO", estadoSemen)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "DESCARTADO", estadoSemen)

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "ACTIVO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(tipoAdquisicion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoConsumo).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoSemen).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub BtnBuscarMG_Click(sender As Object, e As EventArgs) Handles BtnBuscarMG.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        Consultar()
    End Sub

    Private Sub btnNuevoMaterialGenetico_Click(sender As Object, e As EventArgs) Handles btnNuevoMaterialGeneticopro.Click
        Try
            Dim frm As New FrmMantMaterialGenetico With {
                .idUbicacion = CmbUbicacion.Value
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportarMG_Click(sender As Object, e As EventArgs) Handles BtnExportarMaterialGeneticopro.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL MATERIAL GENETICO", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnFiltros_Click(sender As Object, e As EventArgs) Handles BtnFiltros.Click
        Dim isFilterActive As Boolean = Not BtnFiltros.Checked
        BtnFiltros.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub BtnAnular_Click(sender As Object, e As EventArgs) Handles BtnAnularMaterialGeneticopro.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim utilizado As String = activeRow.Cells("Utilizado").Value
                        Dim estado As String = activeRow.Cells("Estado").Value.ToString

                        If (estado = "ANULADO") Then
                            msj_advert("El registro ya fue anulado")
                            Return
                        End If

                        If (utilizado <> "PENDIENTE") Then
                            msj_advert("No se puede anular un registro que ya ha sido utilizado")
                            Return
                        End If

                        If (MessageBox.Show("¿ESTÁ SEGURO DE ANULAR ESTE REGISTRO DE SEMEN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                            Return
                        End If

                        Dim obj As New coControlMaterialGenetico With {
                            .Codigo = activeRow.Cells(0).Value
                        }

                        Dim MensajeBgWk As String = cn.Cn_AnularMaterialGenetico(obj)
                        If (obj.Coderror = 0) Then
                            msj_ok(MensajeBgWk)
                            Consultar()
                        Else
                            msj_advert(MensajeBgWk)
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
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnInhabilitar_Click(sender As Object, e As EventArgs) Handles BtnInhabilitarMaterialGeneticopro.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim estado As String = dtgListado.ActiveRow.Cells("Estado").Value.ToString

                        If (estado = "ANULADO") Then
                            msj_advert("No se puede inhabilitar un registro anulado")
                            Return
                        End If

                        If (estado = "DESCARTADO") Then
                            msj_advert("No se puede editar un registro descartado")
                            Return
                        End If

                        If (estado <> "NO ÓPTIMO") Then
                            If (MessageBox.Show("EL SEMEN AUN ESTA APTO PARA SU USO, ¿ESTÁ SEGURO DE INHABILITARLO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                                Return
                            End If
                        End If

                        Dim obj As New coControlMaterialGenetico With {
                            .Codigo = dtgListado.ActiveRow.Cells(0).Value
                        }

                        Dim MensajeBgWk As String = cn.Cn_DescartarMaterialGenetico(obj)
                        If (obj.Coderror = 0) Then
                            msj_ok(MensajeBgWk)
                            Consultar()
                        Else
                            msj_advert(MensajeBgWk)
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
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnAprobarUso_Click(sender As Object, e As EventArgs) Handles BtnActualizarMotilidad.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim estado As String = activeRow.Cells("Estado").Value.ToString

                        If (estado = "ANULADO") Then
                            msj_advert("No se puede editar un registro anulado")
                            Return
                        End If

                        Dim frm As New FrmActualizarMotilidad With {
                            .idMaterialGentico = activeRow.Cells(0).Value
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
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnParticion_Click(sender As Object, e As EventArgs) Handles BtnParticion.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim dosisInicial As Integer = CInt(activeRow.Cells("N° Dosis").Value)
                        Dim dosisUtilizadas As Integer = CInt(activeRow.Cells("N° Dosis Utilizadas").Value)
                        Dim estado As String = activeRow.Cells("Estado").Value.ToString

                        If (estado = "ANULADO") Then
                            msj_advert("No se puede aplicar partición a un registro anulado")
                            Return
                        End If

                        Dim frm As New FrmAplicarParticion With {
                            .idMaterialGentico = activeRow.Cells(0).Value,
                            .numDosisInicial = dosisInicial,
                            .numDosisUtilizadas = dosisUtilizadas
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
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmControlMaterialGenetico_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnBuscarMG.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class