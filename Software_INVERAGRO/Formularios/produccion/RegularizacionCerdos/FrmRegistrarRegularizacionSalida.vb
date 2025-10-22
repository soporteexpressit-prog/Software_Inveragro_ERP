Imports CapaDatos
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
    Public idLote As Integer = 0
    Dim seleccionadasConCod As New List(Of Integer)
    Dim tbtmp As New DataTable

    Private Sub FrmRegistrarRegularizacionCerdo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            If idPlantel = 1 OrElse idPlantel = 2 Then
                RbtJaulas.Enabled = True
                RbtJaulas.Visible = True
            Else
                RbtJaulas.Enabled = False
                RbtJaulas.Visible = False
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        clsBasicas.LlenarComboAnios(CmbAnios)
        TxtMotivoMortalidad.ReadOnly = True
        LblPlantel.Text = valorPlantel
        TextTatuadas.ReadOnly = True
        TxtEngorde.ReadOnly = True
        DtpFechaControl.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Sub ListarCampañas()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        Dim obj As New coUbicacion With {
            .Codigo = idPlantel,
            .Anio = CmbAnios.Text
        }
        tb = cn.Cn_ListarCampañas(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbCampañas
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        ToolStrip1.Enabled = True
    End Sub

    Sub ListarCorralesJaula()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coJaulaCorral With {
                .IdUbicacion = idPlantel,
                .IdCampaña = CmbCampañas.Value,
                .Tipo = IIf(RbtCorrales.Checked, "CORRAL", "JAULA")
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coJaulaCorral = CType(e.Argument, coJaulaCorral)
            tbtmp = cn.Cn_ConsultarJaulaCorralxCampaña(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DesbloquearControladores()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            dtgListado.DisplayLayout.Bands(0).Columns("idJaulaCorral").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("idLote").Hidden = True
            If dtgListado.Rows.Count > 0 Then
                dtgListado.ActiveRow = dtgListado.Rows(0)
                idJaulaCorral = dtgListado.Rows(0).Cells("idJaulaCorral").Value
                idLote = dtgListado.Rows(0).Cells("idLote").Value
                LblCorralJaula.Text = dtgListado.Rows(0).Cells("Corral").Value?.ToString()
                ListarAnimalesJaulaCorral()
            Else
                idJaulaCorral = 0
                LblCorralJaula.Text = "- - -"
            End If
        End If
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

    Private Sub dtgListado_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles dtgListado.ClickCell
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow

        If activeRow IsNot Nothing AndAlso Not activeRow.IsFilterRow Then
            LblCorralJaula.Text = activeRow.Cells("Corral").Value?.ToString()
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
                    idJaulaCorral = activeRow.Cells("idJaulaCorral").Value
                    idLote = activeRow.Cells("idLote").Value
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
                .IdCampaña = If(CmbCampañas.Value, 0),
                .IdLote = idLote,
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

    Private Sub CmbAnios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbAnios.SelectedIndexChanged
        If CmbAnios.Text.Length > 0 Then
            ListarCampañas()
        End If
    End Sub

    Private Sub CmbCampañas_ValueChanged(sender As Object, e As EventArgs) Handles CmbCampañas.ValueChanged
        If CmbCampañas.Value IsNot Nothing AndAlso CmbCampañas.Value.ToString().Length > 0 Then
            ListarCorralesJaula()
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class