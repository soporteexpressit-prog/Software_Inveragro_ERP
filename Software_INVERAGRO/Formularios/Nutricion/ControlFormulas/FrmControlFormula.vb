Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlFormula
    Dim cn As New cnControlFormulacion
    Dim search As Boolean = True
    Dim tbtmp As New DataTable

    Private Sub FrmControlFormula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Inicializar()
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        CmbEstado.SelectedIndex = 0
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Filtrar_Tabla(dtgListado, True)
    End Sub

    Private Sub BloquearControles()
        GrupoFiltros.Enabled = False
        Ptbx_Cargando.Visible = True
        BarraOpciones.Enabled = False
    End Sub

    Private Sub DesbloquearControles()
        GrupoFiltros.Enabled = True
        Ptbx_Cargando.Visible = False
        BarraOpciones.Enabled = True
    End Sub

    Sub Consultar()
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If

        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()

            Dim obj As New coControlFormulacion
            If (search) Then
                obj.FechaDesde = Nothing
                obj.FechaHasta = Nothing
            Else
                obj.FechaDesde = dtpFechaDesde.Value
                obj.FechaHasta = dtpFechaHasta.Value
            End If
            obj.Tipo = CmbEstado.Text

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlFormulacion = CType(e.Argument, coControlFormulacion)
            tbtmp = cn.Cn_Listar(obj).Copy
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
            DesbloquearControles()
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("idNutricionista").Hidden = True
            Colorear()
        End If
    End Sub

    Private Sub btnCrearFormula_Click(sender As Object, e As EventArgs) Handles btnCrearFormulaNctrfor.Click
        Try
            Dim frm As New FrmSeleccionarNutricionista
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estado As Integer = 8

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "CANCELADO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "FINALIZADO", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportarNctrfor.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL DE FORMULACIONES", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnInsumos_Click(sender As Object, e As EventArgs) Handles btnInsumosNctrfor.Click
        Try
            Dim frm As New FrmSeleccionesNutricionistaGesInsumos
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnNuevaNucleo_Click(sender As Object, e As EventArgs) Handles btnNuevaNucleoNctrfor.Click
        Try
            Dim f As New FrmMantNucleo
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnAsignarFormula_Click(sender As Object, e As EventArgs) Handles btnAsignarFormulaNctrfor.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim estado As String = activeRow.Cells("Estado").Value.ToString

                If (estado = "FINALIZADO") Then
                    msj_advert("SOLO SE PERMITE ASIGNAR FORMULAS PENDIENTES O ACTIVAS")
                    Return
                End If

                If (estado = "CANCELADO") Then
                    msj_advert("ESTA FORMULA YA SE ENCUENTRA CANCELADA")
                    Return
                End If

                Dim f As New FrmAsignarFormula With {
                    .idFormula = CInt(dtgListado.ActiveRow.Cells(0).Value)
                }
                f.ShowDialog()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub BtnVerFormula_Click(sender As Object, e As EventArgs) Handles BtnVerFormulamolinocontrolformula.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim f As New FrmVerFormulaBase With {
                    .idFormulaBase = CInt(dtgListado.ActiveRow.Cells(0).Value),
                    .estadoFormula = dtgListado.ActiveRow.Cells("Estado").Value.ToString
                }
                f.ShowDialog()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub BtnRacionesAsignadas_Click(sender As Object, e As EventArgs) Handles BtnRacionesAsignadasMolinocontrolform.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim f As New FrmRacionesAsignadasFormula With {
                    .idFormulaBase = CInt(dtgListado.ActiveRow.Cells(0).Value)
                }
                f.ShowDialog()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelarnutricionmodulo.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim estado As String = activeRow.Cells("Estado").Value.ToString

                If (estado = "CANCELADO") Then
                    msj_advert("ESTA FORMULA YA SE ENCUENTRA CANCELADA")
                    Return
                End If

                If (estado <> "PENDIENTE" And estado <> "ACTIVO") Then
                    msj_advert("SOLO SE PERMITE CANCELAR FORMULAS PENDIENTES O ACTIVAS")
                    Return
                End If

                If (MessageBox.Show("¿ESTÁ SEGURO DE CANCELAR ESTA FÓRMULA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim obj As New coControlFormulacion With {
                    .IdFormulaBase = activeRow.Cells(0).Value
                }

                Dim mensaje As String = cn.Cn_CancelarFormulaBase(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(mensaje)
                    Consultar()
                Else
                    msj_advert(mensaje)
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub BtnActivar_Click(sender As Object, e As EventArgs) Handles BtnActivar.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim estado As String = activeRow.Cells("Estado").Value.ToString

                If (estado <> "FINALIZADO") Then
                    msj_advert("SOLO SE PERMITE ACTIVAR FÓRMULAS FINALIZADAS")
                    Return
                End If

                If (MessageBox.Show("¿ESTÁ SEGURO DE ACTIVAR ESTA FÓRMULA FINALIZADA?, RECUERDA QUE LA FÓRMULA ACTIVA PASARA A ESTADO FINALIZADO", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim obj As New coControlFormulacion With {
                    .IdFormulaBase = activeRow.Cells(0).Value,
                    .IdNutricionista = activeRow.Cells("idNutricionista").Value
                }

                Dim mensaje As String = cn.Cn_ActivarFormulaBase(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(mensaje)
                    Consultar()
                Else
                    msj_advert(mensaje)
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub BtnNutricionista_Click(sender As Object, e As EventArgs) Handles BtnNutricionista.Click
        Try
            Dim frm As New FrmMantenimientoNutricionista
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnAccesoVisualizacion_Click(sender As Object, e As EventArgs) Handles BtnAccesoVisualizacion.Click
        Try
            Dim frm As New FrmListaUbicacionxRacion
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        search = False
        Consultar()
    End Sub
End Class