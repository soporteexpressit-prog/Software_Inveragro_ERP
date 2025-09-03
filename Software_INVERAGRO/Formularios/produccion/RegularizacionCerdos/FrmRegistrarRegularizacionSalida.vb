Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmRegistrarRegularizacionSalida
    Dim cnLote As New cnControlLoteDestete
    Dim cnAnimal As New cnControlAnimal
    Dim cn As New cnJaulaCorral
    Dim idMotivoMortalidad As Integer = 0
    Public valorPlantel As String = ""
    Public idPlantel As Integer = 0
    Public idJaulaCorral As Integer = 0
    Dim seleccionadasConCod As New List(Of Integer)

    Private Sub FrmRegistrarRegularizacionCerdo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RbtCorrales.Checked = True

            If idPlantel = 1 OrElse idPlantel = 2 Then
                RbtJaulas.Enabled = True
                RbtJaulas.Visible = True
            Else
                RbtJaulas.Enabled = False
                RbtJaulas.Visible = False
            End If

            TxtMotivoMortalidad.ReadOnly = True
            LblPlantel.Text = valorPlantel
            TextTatuadas.ReadOnly = True
            TxtEngorde.ReadOnly = True
            DtpFechaControl.Value = Now.Date
            ListarCorralesJaula()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ListarCorralesJaula()
        Try
            Dim obj As New coJaulaCorral With {
                .IdUbicacion = idPlantel,
                .Tipo = IIf(RbtCorrales.Checked, "CORRAL", "JAULA")
            }

            dtgListado.DataSource = cn.Cn_ConsultarJaulaCorralxUbicacionTipo(obj)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns(4).Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns(7).Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns(8).Hidden = True
            If dtgListado.Rows.Count > 0 Then
                LblCorralJaula.Text = dtgListado.Rows(0).Cells(1).Value.ToString
                idJaulaCorral = dtgListado.Rows(0).Cells(0).Value

                If (idJaulaCorral <> 0) Then
                    ListarAnimalesJaulaCorral()
                End If
            Else
                LblCorralJaula.Text = "- - -"
            End If
            Colorear()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ListarAnimalesJaulaCorral()
        Try
            Dim obj As New coControlLoteDestete With {
                .IdJaulaCorral = idJaulaCorral
            }

            Dim ds As DataSet = cnLote.Cn_ConsultarAnimalesxIdJaulaCorralRegularizacion(obj)

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                DtgListadoCerdos.DataSource = ds.Tables(0)
                clsBasicas.Formato_Tablas_Grid(DtgListadoCerdos)
                DtgListadoCerdos.DisplayLayout.Bands(0).Columns(0).Hidden = True

                If ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 0 Then
                    TextTatuadas.Text = CInt(ds.Tables(1).Rows(0)("CantidadTatuados"))
                    TxtEngorde.Text = CInt(ds.Tables(1).Rows(0)("CantidadSinTatuar"))
                End If
            End If
            clsBasicas.Filtrar_Tabla(DtgListadoCerdos, True)
            clsBasicas.Formato_Tablas_Grid(DtgListadoCerdos)
            DtgListadoCerdos.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estadoCapacidad As Integer = 6

            'estadoCapacidad
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "LIBRE", estadoCapacidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightYellow, Color.DarkGoldenrod, "PARCIAL", estadoCapacidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "LLENO", estadoCapacidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "NO DISPONIBLE", estadoCapacidad)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estadoCapacidad).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub RbtCorrales_CheckedChanged(sender As Object, e As EventArgs) Handles RbtCorrales.CheckedChanged
        If RbtCorrales.Checked Then
            ListarCorralesJaula()
            LimpiarCampoMotivoMortalidad()
        End If
    End Sub

    Private Sub RbtJaulas_CheckedChanged(sender As Object, e As EventArgs) Handles RbtJaulas.CheckedChanged
        If RbtJaulas.Checked Then
            ListarCorralesJaula()
            LimpiarCampoMotivoMortalidad()
        End If
    End Sub

    Private Sub dtgListado_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles dtgListado.ClickCell
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow

        If activeRow IsNot Nothing AndAlso Not activeRow.IsFilterRow Then
            LblCorralJaula.Text = activeRow.Cells(1).Value?.ToString()
            ConsultarAnimalesJaulaCorral()
        Else
            LblCorralJaula.Text = "- - -"
        End If
    End Sub

    Private Sub ConsultarAnimalesJaulaCorral()
        Try
            Dim activeRow As UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    idJaulaCorral = activeRow.Cells(0).Value
                    Dim obj As New coControlLoteDestete With {
                        .IdJaulaCorral = idJaulaCorral
                    }

                    Dim ds As DataSet = cnLote.Cn_ConsultarAnimalesxIdJaulaCorralRegularizacion(obj)

                    If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                        DtgListadoCerdos.DataSource = ds.Tables(0)
                        clsBasicas.Formato_Tablas_Grid(DtgListadoCerdos)
                        DtgListadoCerdos.DisplayLayout.Bands(0).Columns(0).Hidden = True

                        If ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 0 Then
                            TextTatuadas.Text = CInt(ds.Tables(1).Rows(0)("CantidadTatuados"))
                            TxtEngorde.Text = CInt(ds.Tables(1).Rows(0)("CantidadSinTatuar"))
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

    Private Sub BtnMotivoMortalidad_Click(sender As Object, e As EventArgs) Handles BtnMotivoMortalidad.Click
        Try
            Dim frm As New FrmListarMotivosRegularizacion(Me)
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCampoMotivoMortalidad(id As Integer, motivo As String)
        idMotivoMortalidad = id
        TxtMotivoMortalidad.Text = motivo
    End Sub

    Public Sub LimpiarCampoMotivoMortalidad()
        idMotivoMortalidad = 0
        TxtMotivoMortalidad.Text = ""
    End Sub

    Private Sub DtgListadoCerdos_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles DtgListadoCerdos.DoubleClickCell
        Dim fila As Infragistics.Win.UltraWinGrid.UltraGridRow = e.Cell.Row

        If fila IsNot Nothing AndAlso fila.Cells IsNot Nothing AndAlso fila.Cells.Count > 0 AndAlso
       fila.Cells(0) IsNot Nothing AndAlso Not IsDBNull(fila.Cells(0).Value) AndAlso
       Not String.IsNullOrWhiteSpace(fila.Cells(0).Value?.ToString()) Then

            If seleccionadasConCod.Contains(fila.Index) Then
                seleccionadasConCod.Remove(fila.Index)
                fila.Appearance.BackColor = Color.White
            Else
                seleccionadasConCod.Add(fila.Index)
                fila.Appearance.BackColor = Color.LightBlue
            End If
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If seleccionadasConCod.Count = 0 And NumCamborough.Value = 0 And NumEngorde.Value = 0 Then
                msj_advert("Seleccione al menos un cerdo")
                Return
            ElseIf NumCamborough.Value > CInt(TextTatuadas.Text) Then
                msj_advert("La cantidad de cerdos Camborough no puede ser mayor a la cantidad de cerdos disponibles")
                Return
            ElseIf NumEngorde.Value > CInt(TxtEngorde.Text) Then
                msj_advert("La cantidad de cerdos de engorde no puede ser mayor a la cantidad de cerdos disponibles")
                Return
            ElseIf idMotivoMortalidad = 0 Then
                msj_advert("Seleccione un motivo de mortalidad")
                Return
            End If

            Dim cantidad As Integer = 0

            cantidad = seleccionadasConCod.Count + NumCamborough.Value + NumEngorde.Value

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR REGULARIZACIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAnimal With {
                .FechaControl = DtpFechaControl.Value,
                .Observacion = TxtObservacion.Text,
                .CantidadCrias = cantidad,
                .IdJaulaCorral = idJaulaCorral,
                .IdMotivoMortalidadCamal = idMotivoMortalidad,
                .ListaCriasRegistrar = CrearStringIdsCerdoConCod(),
                .CantidadCamalTatuaje = NumCamborough.Value,
                .CantidadCamalEngorde = NumEngorde.Value,
                .IdUsuario = VP_IdUser,
                .TipoControl = "SALIDA"
            }

            Dim MensajeBgWk As String = cnAnimal.Cn_RegistrarRegularizacionCerdos(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Dispose()
            Else
                msj_advert(MensajeBgWk)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function CrearStringIdsCerdoConCod() As String
        Dim seleccionados As String = ""

        For Each filaIndex As Integer In seleccionadasConCod
            seleccionados &= DtgListadoCerdos.Rows(filaIndex).Cells(0).Value.ToString() & ", "
        Next

        If seleccionados.Length > 2 Then
            seleccionados = seleccionados.Substring(0, seleccionados.Length - 2)
        End If

        Return seleccionados
    End Function

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class