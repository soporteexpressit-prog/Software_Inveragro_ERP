Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlEnvioCamal
    Dim cn As New cnControlAnimal
    Dim tbtmp As New DataTable
    Dim idsControlCamal As New List(Of Integer)

    Private Sub FrmControlEnvioCamal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Inicializar()
        Me.KeyPreview = True
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        CmbEstado.SelectedIndex = 0
        CmbTipo.SelectedIndex = 0
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

            Dim obj As New coControlAnimal With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value,
                .IdPlantel = CmbUbicacion.Value,
                .Estado = CmbEstado.Text,
                .TipoControl = CmbTipo.Text
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            tbtmp = cn.Cn_ConsultarEnvioCamal(obj).Copy
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
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("idTipoIncidencia").Hidden = True
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estadoPdf As Integer = 14
            Dim estado As Integer = 15
            Dim estadoAtendido As Integer = 16
            Dim estadoVivo As Integer = 18

            'estadoPdf
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "CON EVIDENCIA", estadoPdf)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "SIN EVIDENCIA", estadoPdf)

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "CONFIRMADO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "CANCELADO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.IndianRed, Color.White, "ANULADO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estado)

            'estadoAtendido
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ATENDIDO", estadoAtendido)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "NO ATENDIDO", estadoAtendido)

            'estadoVivo
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "VIVO", estadoVivo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "MUERTO", estadoVivo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "VENDIDO", estadoVivo)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estadoPdf).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoAtendido).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoVivo).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub



    Private Sub BtnConfirmarVenta_Click(sender As Object, e As EventArgs) Handles BtnConfirmarVentaenvioscamalpro.Click
        Try
            If (idsControlCamal.Count = 0) Then
                msj_advert("DEBE SELECCIONAR AL MENOS UN REGISTRO PARA CONFIRMAR ENVIO A CAMAL")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE CONFIRMAR ENVIO PARA VENTA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAnimal With {
                .ListaIdsControlFicha = CrearStringIdsControlCamal(),
                .IdPlantel = CmbUbicacion.Value,
                .IdUsuario = VP_IdUser
            }

            Dim _mensaje As String = cn.Cn_ConfirmarVentaEnvioCamal(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Consultar()
                idsControlCamal.Clear()
                LblCriasSeleccionadas.Text = "0"
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function CrearStringIdsControlCamal() As String
        Dim seleccionados As String = ""

        For Each filaIndex As Integer In idsControlCamal
            seleccionados &= dtgListado.Rows(filaIndex).Cells(0).Value.ToString() & ", "
        Next

        If seleccionados.Length > 2 Then
            seleccionados = seleccionados.Substring(0, seleccionados.Length - 2)
        End If

        Return seleccionados
    End Function

    Private Sub BtnExportarControlCerda_Click(sender As Object, e As EventArgs) Handles BtnExportarControlCerdaenvioscamalpro.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                FormatearFilas()
                clsBasicas.ExportarExcel("CONTROL DE ENVIO A CAMAL", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        Dim column As Infragistics.Win.UltraWinGrid.UltraGridColumn = dtgListado.DisplayLayout.Bands(0).Columns("Ver Evidencia")
        column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        If Not e.ReInitialize Then
            e.Row.Cells("Ver Evidencia").Value = "Ver Evidencia"
            e.Row.Cells("Ver Evidencia").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        End If
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            With dtgListado
                If (e.Cell.Column.Key = "Ver Evidencia") Then

                    Dim estadoPDF As String = .ActiveRow.Cells("Estado Evidencia").Value.ToString()
                    If estadoPDF = "SIN EVIDENCIA" Then
                        msj_advert("EL REGISTRO NO TIENE EVIDENCIA ADJUNTO")
                        Return
                    End If

                    Dim idHistorialEnvioCamal As Integer = CInt(.ActiveRow.Cells(0).Value)
                    Dim frm As New FrmVerEvidenciaEnvioCamal With {
                        .idHistorialEnvioCamal = idHistorialEnvioCamal
                    }
                    frm.ShowDialog()
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCancelarVenta_Click(sender As Object, e As EventArgs) Handles BtnCancelarVentaenvioscamalpro.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim estado As String = activeRow.Cells("Estado").Value.ToString()
                    Dim cantidad As Integer = CInt(activeRow.Cells("Cantidad").Value)
                    Dim estadoAtendido As String = activeRow.Cells("Despacho").Value.ToString()

                    If idsControlCamal.Count > 0 Then
                        msj_advert("AQUÍ NO SE PERMITE MULTISELECCIÓN")
                        FormatearFilas()
                        Return
                    End If

                    If estado = "PENDIENTE" Then
                        msj_advert("EL ENVIO TIENE QUE SER CONFIRMADO PARA PODER CANCELARSE")
                        Return
                    ElseIf estado = "CANCELADO" Then
                        msj_advert("EL ENVIO DE VENTA YA FUE CANCELADO")
                        Return
                    ElseIf estado = "ANULADO" Then
                        msj_advert("EL ENVIO A CAMAL YA FUE ANULADO")
                        Return
                    ElseIf estadoAtendido = "ATENDIDO" Then
                        msj_advert("EL ENVIO DE ESTE CERDO(S) A CAMAL YA FUE ATENDIDO")
                        Return
                    End If

                    Dim frm As New FrmCancelarVentaCamal With {
                        .idHistorialEnvioCamal = CInt(activeRow.Cells(0).Value),
                        .idUbicacion = CmbUbicacion.Value
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

    Private Sub BtnAnularEnvio_Click(sender As Object, e As EventArgs) Handles BtnAnularEnvioenvioscamalpro.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim estado As String = activeRow.Cells("Estado").Value.ToString()

                    If idsControlCamal.Count > 0 Then
                        msj_advert("AQUÍ NO SE PERMITE MULTISELECCIÓN")
                        FormatearFilas()
                        Return
                    End If

                    If estado = "ANULADO" Then
                        msj_advert("EL ENVIO A CAMAL YA FUE ANULADO")
                        Return
                    ElseIf estado = "CANCELADO" Then
                        msj_advert("EL ENVIO DE VENTA YA FUE CANCELADO")
                        Return
                    ElseIf estado = "CONFIRMADO" Then
                        msj_advert("EL ENVIO DE VENTA YA FUE CONFIRMADO")
                        Return
                    End If

                    Dim frm As New FrmAnularEnvioCamal With {
                        .idHistorialEnvioCamal = CInt(activeRow.Cells(0).Value),
                        .idUbicacion = CmbUbicacion.Value
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

    Private Sub FormatearFilas()
        For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            fila.Appearance.BackColor = Color.White
        Next
        LblCriasSeleccionadas.Text = "0"
        idsControlCamal.Clear()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub

    Private Sub BtnStockAnimales_Click(sender As Object, e As EventArgs) Handles BtnStockAnimales.Click
        Try
            Dim frm As New FrmReporteStockCerdosVenta
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmControlEnvioCamal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnBuscar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Dim fila As Infragistics.Win.UltraWinGrid.UltraGridRow = e.Cell.Row

        If fila IsNot Nothing AndAlso fila.Cells IsNot Nothing AndAlso fila.Cells.Count > 0 AndAlso
       fila.Cells(0) IsNot Nothing AndAlso Not IsDBNull(fila.Cells(0).Value) AndAlso
       Not String.IsNullOrWhiteSpace(fila.Cells(0).Value?.ToString()) Then
            Dim estado As String = fila.Cells("Estado").Value.ToString()
            Dim estadoVivo As String = fila.Cells("Condición").Value.ToString()

            If estadoVivo = "MUERTO" Then
                msj_advert("YA SE REGISTRO MORTALIDAD DE ESTE ANIMAL. NO SE PUEDE SELECCIONAR")
                Return
            End If

            If estado = "CONFIRMADO" Then
                msj_advert("EL ENVIO DE VENTA YA FUE CONFIRMADO")
                Return
            ElseIf estado = "CANCELADO" Then
                msj_advert("EL ENVIO DE VENTA YA FUE CANCELADO")
                Return
            ElseIf estado = "ANULADO" Then
                msj_advert("EL ENVIO A CAMAL YA FUE ANULADO")
                Return
            End If

            If idsControlCamal.Contains(fila.Index) Then
                idsControlCamal.Remove(fila.Index)
                fila.Appearance.BackColor = Color.White
            Else
                idsControlCamal.Add(fila.Index)
                fila.Appearance.BackColor = Color.LightBlue
            End If

            LblCriasSeleccionadas.Text = ContarFilasSeleccionadasPorColor().ToString()
        End If
    End Sub

    Private Function ContarFilasSeleccionadasPorColor() As Integer
        Dim contador As Integer = 0
        For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If fila.Appearance.BackColor = Color.LightBlue Then
                contador += 1
            End If
        Next
        Return contador
    End Function

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class