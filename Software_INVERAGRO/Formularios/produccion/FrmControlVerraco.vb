Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlVerraco
    Dim cn As New cnControlAnimal
    Dim tbtmp As New DataTable
    Dim seach As Boolean = True

    Private Sub FrmControlVerraco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
            CmbUbicacion.Value = VariablesGlobales.idPlantelGlobal
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        Ptbx_Cargando.Visible = True
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        CmbEstadoVivo.SelectedIndex = 0
        CmbEstadoVenta.SelectedIndex = 0
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        GrupoFiltros.Enabled = False
        BarraOpciones.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        GrupoFiltros.Enabled = True
        BarraOpciones.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlAnimal With {
                .EstadoVivo = CmbEstadoVivo.Text,
                .EstadoVenta = CmbEstadoVenta.Text,
                .IdPlantel = CmbUbicacion.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
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

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            tbtmp = cn.Cn_ConsultarVerraco(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            DesbloquearControladores()
            dtgListado.DisplayLayout.Bands(0).Columns("idAnimal").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Tipo").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Estado Venta").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Cod.Arete Madre").Hidden = True
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim tipoAdquisicion As Integer = 8
            Dim estadoVivo As Integer = 10
            Dim estadoVenta As Integer = 11
            Dim estadoExtraccion As Integer = 12
            Dim condicionReproductiva As Integer = 13
            Dim estadoCamal As Integer = 14
            Dim aplicadoInossure As Integer = 17

            'tipoAdquisicion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "GRANJA", tipoAdquisicion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightBlue, Color.Black, "COMPRADO", tipoAdquisicion)

            'estadoVivo
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "VIVO", estadoVivo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "MUERTO", estadoVivo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "VENDIDO", estadoVivo)

            'estadoVenta
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estadoVenta)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightBlue, Color.DarkBlue, "EN VENTA", estadoVenta)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "VENDIDO", estadoVenta)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "DESCARTE", estadoVenta)

            'estadoExtraccion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "INMADURO", estadoExtraccion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "ENTRENAR", estadoExtraccion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "DISPONIBLE", estadoExtraccion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "NO DISPONIBLE", estadoExtraccion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "INACTIVO", estadoExtraccion)

            'condicionReproductiva
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "APTO", condicionReproductiva)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "NO APTO", condicionReproductiva)

            'estadoCamal
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightSlateGray, Color.White, "ENVIADO", estadoCamal)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightSkyBlue, Color.MidnightBlue, "EN PRODUCCION", estadoCamal)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "DESCARTE", estadoCamal)

            'aplicadoInossure
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Yellow, Color.Black, "SI", aplicadoInossure)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "NO", aplicadoInossure)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(tipoAdquisicion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoVivo).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoVenta).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoExtraccion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(condicionReproductiva).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoCamal).CellAppearance.TextHAlign = HAlign.Center
                .Columns(aplicadoInossure).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnNuevoSGctrleqpro_Click(sender As Object, e As EventArgs) Handles btnNuevoprocontrolverracos.Click
        Try
            Dim frm As New FrmMantenimientoVerraco With {
                .idUbicacion = CmbUbicacion.Value
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnFiltros_Click(sender As Object, e As EventArgs) Handles BtnFiltros.Click
        Dim isFilterActive As Boolean = Not BtnFiltros.Checked
        BtnFiltros.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub btnBuscarVerracos_Click(sender As Object, e As EventArgs) Handles btnBuscarVerracos.Click
        CkbMadre.Checked = False
        Consultar()
    End Sub

    Private Sub CkbMadre_CheckedChanged(sender As Object, e As EventArgs) Handles CkbMadre.CheckedChanged
        If CkbMadre.Checked Then
            dtgListado.DisplayLayout.Bands(0).Columns("Cod.Arete Madre").Hidden = False
        Else
            dtgListado.DisplayLayout.Bands(0).Columns("Cod.Arete Madre").Hidden = True
        End If
    End Sub

    Private Sub BtnHistorialExtraccion_Click(sender As Object, e As EventArgs) Handles BtnHistorialExtraccionprocontrolverracos.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim frm As New FrmFichaCicloVidaVerraco With {
                        .idVerraco = activeRow.Cells(0).Value
                    }
                    frm.ShowDialog()
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

    Private Sub BtnActualizarDatos_Click(sender As Object, e As EventArgs) Handles BtnActualizarDatosprocontrolverracos.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim estadoVivo As String = activeRow.Cells("Condición").Value.ToString

                    If (estadoVivo = "MUERTO") Then
                        msj_advert("NO SE PUEDE ACTUALIZAR LOS DATOS DE UN VERRACO MUERTO")
                        Exit Sub
                    End If

                    Dim frm As New FrmActualizarDatosVerraco With {
                            .idVerraco = activeRow.Cells(0).Value
                        }
                    frm.ShowDialog()
                    Consultar()
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

    Private Sub BtnMandarCamal_Click(sender As Object, e As EventArgs) Handles BtnMandarCamalprocontrolverracos.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim estadoVivo As String = activeRow.Cells("Condición").Value.ToString
                    Dim estadoCamal As String = activeRow.Cells("Envio Camal").Value

                    If (estadoVivo = "MUERTO") Then
                        msj_advert("NO SE PUEDE ACTUALIZAR LOS DATOS DE UNA CERDA MUERTA")
                        Exit Sub
                    End If

                    If (estadoCamal = "ENVIADO") Then
                        msj_advert("EL VERRACO YA FUE ENVIADO A CAMAL")
                        Exit Sub
                    End If

                    Dim frm As New FrmMandarCamalAnimal With {
                        .idAnimal = dtgListado.ActiveRow.Cells(0).Value,
                        .arete = dtgListado.ActiveRow.Cells(1).Value.ToString(),
                        .clasificacion = "VARRACO"
                    }
                    frm.ShowDialog()
                    Consultar()
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

    Private Sub BtnExportarControlVerraco_Click(sender As Object, e As EventArgs) Handles BtnExportarBtnMandarCamalprocontrolverracos.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL-VERRACO", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
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

    Private Sub CbxTipoAdquisicion_CheckedChanged(sender As Object, e As EventArgs) Handles CbxTipoAdquisicion.CheckedChanged
        If CbxTipoAdquisicion.Checked Then
            dtgListado.DisplayLayout.Bands(0).Columns("Tipo").Hidden = False
        Else
            dtgListado.DisplayLayout.Bands(0).Columns("Tipo").Hidden = True
        End If
    End Sub

    Private Sub CbxEstadoVenta_CheckedChanged(sender As Object, e As EventArgs) Handles CbxEstadoVenta.CheckedChanged
        If CbxEstadoVenta.Checked Then
            dtgListado.DisplayLayout.Bands(0).Columns("Estado Venta").Hidden = False
        Else
            dtgListado.DisplayLayout.Bands(0).Columns("Estado Venta").Hidden = True
        End If
    End Sub

    Private Sub FrmControlVerraco_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscarVerracos.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BtnMortalidadAnimal_Click(sender As Object, e As EventArgs) Handles BtnMortalidadAnimal.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim estado As String = activeRow.Cells("Condición").Value.ToString()

                    If estado = "MUERTO" Then
                        msj_advert("La cerda ya está registrada como muerta")
                        Exit Sub
                    End If

                    Dim frm As New FrmMortalidadVerraco With {
                        .idAnimal = activeRow.Cells(0).Value,
                        .arete = activeRow.Cells(1).Value.ToString()
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

    Private Sub BtnHistorial_Click(sender As Object, e As EventArgs) Handles BtnHistorial.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim frm As New FrmHistoricoCerda With {
                    .idCerda = activeRow.Cells("idAnimal").Value,
                    .codAnimal = activeRow.Cells("Código").Value,
                    .etapa = ""
                }
                frm.ShowDialog()
                Consultar()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim codCerdo = activeRow.Cells("Código").Value.ToString()

                If (MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR AL ANIMAL CON ARETE : " & codCerdo & " ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim obj As New coControlAnimal With {
                    .Codigo = activeRow.Cells("idAnimal").Value.ToString()
                }

                Dim MensajeBgWk As String = cn.Cn_EliminarAnimal(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Consultar()
                Else
                    msj_advert(MensajeBgWk)
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class