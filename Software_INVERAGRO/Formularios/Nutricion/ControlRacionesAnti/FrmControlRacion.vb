Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlRacion
    Dim cn As New cnNucleo
    Dim tbtmp As New DataTable
    Private Sub FrmControlRacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Ptbx_Cargando.Visible = True
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BloquearControles()
        Ptbx_Cargando.Visible = True
        BarraOpciones.Enabled = False
    End Sub

    Private Sub DesbloquearControles()
        Ptbx_Cargando.Visible = False
        BarraOpciones.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            tbtmp = cn.Cn_ListarRacionExtra().Copy
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
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estadoAnti As Integer = 4
            Dim estadoPlanMedicado As Integer = 5
            Dim rotacion As Integer = 9

            'estadoAnti
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Yellow, Color.Black, "CON ANTI", estadoAnti)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.White, Color.Black, "SIN ANTI", estadoAnti)

            'estadoPlanMedicado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.White, Color.Black, "SIN PLAN MEDICADO", estadoPlanMedicado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.Black, "CON PLAN MEDICADO", estadoPlanMedicado)

            'Alerta 
            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                Dim cell = row.Cells(rotacion)
                Dim v As Integer
                If Integer.TryParse(cell.Value?.ToString(), v) Then
                    ' configurar los tres estados de la celda
                    With cell.Appearance
                        .BackColor = If(v = 1, Color.LightGreen, Color.Red)
                        .ForeColor = If(v = 1, Color.LightGreen, Color.Red)
                        .FontData.Bold = DefaultableBoolean.True
                    End With
                    With cell.ActiveAppearance
                        .BackColor = cell.Appearance.BackColor
                        .ForeColor = cell.Appearance.ForeColor
                        .FontData.Bold = DefaultableBoolean.True
                    End With
                    With cell.SelectedAppearance
                        .BackColor = cell.Appearance.BackColor
                        .ForeColor = cell.Appearance.ForeColor
                        .FontData.Bold = DefaultableBoolean.True
                    End With
                End If
            Next

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(rotacion).CellAppearance.TextHAlign = HAlign.Center
            End With

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estadoAnti).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoPlanMedicado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnGestionAnti_Click(sender As Object, e As EventArgs) Handles btnGestionAntiNctrra.Click
        Try
            Dim f As New FrmGestionExtra With {
                .tipo = "ANTI"
            }
            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportarNctrra.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("LISTA DE RACIONES", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnGestionPlanMedicado_Click(sender As Object, e As EventArgs) Handles btnGestionPlanMedicadoNctrra.Click
        Try
            Dim f As New FrmGestionExtra With {
                .tipo = "PLAN MEDICADO"
            }
            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnVincularQuitarAnti_Click(sender As Object, e As EventArgs) Handles btnVincularQuitarAntiNctrra.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If (dtgListado.Rows.Count = 0) Then
                        msj_advert("Seleccione un Registro")
                    Else
                        Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE VINCULAR / QUITAR ANTI DE ESTA RACIÓN?", "CONFIRMAR REGISTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If result = DialogResult.Yes Then
                            Dim estadoAnti As String = dtgListado.DisplayLayout.ActiveRow.Cells(4).Value.ToString
                            Dim obj As New coNucleo With {
                                .Codigo = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString),
                                .Tipo = "ANTI"
                            }
                            Dim MensajeBgWk As String = ""

                            If (estadoAnti = "CON ANTI") Then
                                MensajeBgWk = cn.Cn_CancelarExtra(obj)
                            Else
                                MensajeBgWk = cn.Cn_VincularExtra(obj)
                            End If

                            If (obj.Coderror = 0) Then
                                msj_ok(MensajeBgWk)
                                Consultar()
                            Else
                                msj_advert(MensajeBgWk)
                            End If
                        End If
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

    Private Sub btnQuitarPlanMedicado_Click(sender As Object, e As EventArgs) Handles btnQuitarPlanMedicadoNctrra.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim estadoPlanMedicado As String = dtgListado.DisplayLayout.ActiveRow.Cells(5).Value.ToString

                    If (estadoPlanMedicado = "SIN PLAN MEDICADO") Then
                        msj_advert("No se puede quitar un plan medicado que no ha sido asignado")
                        Exit Sub
                    End If

                    If (dtgListado.Rows.Count = 0) Then
                        msj_advert("Seleccione un Registro")
                    Else
                        Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE QUITAR PLAN MEDICADO DE ESTA RACIÓN?", "CONFIRMAR REGISTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If result = DialogResult.Yes Then
                            Dim estadoAnti As String = dtgListado.DisplayLayout.ActiveRow.Cells(5).Value.ToString
                            Dim obj As New coNucleo With {
                                .Codigo = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString),
                                .Tipo = "PLAN MEDICADO"
                            }

                            Dim MensajeBgWk As String = ""
                            MensajeBgWk = cn.Cn_CancelarExtra(obj)

                            If (obj.Coderror = 0) Then
                                msj_ok(MensajeBgWk)
                                Consultar()
                            Else
                                msj_advert(MensajeBgWk)
                            End If
                        End If
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class