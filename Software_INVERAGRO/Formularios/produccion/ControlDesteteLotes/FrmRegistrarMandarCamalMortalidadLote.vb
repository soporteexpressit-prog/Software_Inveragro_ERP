Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmRegistrarMandarCamalMortalidadLote
    Dim cnAnimal As New cnControlAnimal
    Dim cnLote As New cnControlLoteDestete
    Dim idMotivoMortalidad As Integer = 0
    Dim idJaulaCorral As Integer = 0
    Dim listaIdCerdosReg As New List(Of String)
    Dim tipoRegistro As String = ""
    Public valorPlantel As String = ""
    Public valorLote As String = ""
    Public idPlantel As Integer = 0
    Public idLoteOriginal As Integer = 0
    Dim cantCerdaDisponibleCamborEngorde As Decimal = 0
    Public habilitarOpcionChanchilla As Boolean = False

    Private Sub FrmRegistrarMortalidadLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarDetalleCorralesLote()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        TxtMotivoMortalidad.ReadOnly = True
        RbtMortalidad.Checked = True
        LblLote.Text = valorLote
        LblPlantel.Text = valorPlantel
        LblPeso.Visible = False
        TxtPeso.Visible = False
        FiltroEnvioAnimales.Visible = habilitarOpcionChanchilla
        FiltroEnvioAnimales.Enabled = habilitarOpcionChanchilla
        If (habilitarOpcionChanchilla) Then
            RbnLechon.Checked = True
        End If
        NoVisibleCantCerdosNoReg()
        NoVisibleCantCerdosTatuados()
    End Sub

    Private Sub ListarDetalleCorralesLote()
        Try
            Dim obj As New coControlLoteDestete With {
                .IdLote = idLoteOriginal,
                .IdPlantel = idPlantel
            }

            DtgListadoCorrales.DataSource = cnLote.Cn_ConsultarCorralesPorLoteMortalidad(obj)
            clsBasicas.Formato_Tablas_Grid(DtgListadoCorrales)
            DtgListadoCorrales.DisplayLayout.Bands(0).Columns("idJaulaCorral").Hidden = True

            If (DtgListadoCorrales.Rows.Count > 0) Then
                idJaulaCorral = DtgListadoCorrales.Rows(0).Cells(0).Value

                If (idJaulaCorral <> 0) Then
                    ListarAnimalesJaulaCorral()
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ListarAnimalesJaulaCorral()
        Try
            Dim obj As New coControlLoteDestete With {
                .IdJaulaCorral = idJaulaCorral,
                .IdLote = idLoteOriginal
            }

            DtgListadoCerdos.DataSource = cnLote.Cn_ConsultarAnimalesxIdJaulaCorral(obj)
            ColorearAnimalesJaulaCorral()
            clsBasicas.Filtrar_Tabla(DtgListadoCerdos, True)
            clsBasicas.Formato_Tablas_Grid(DtgListadoCerdos)
            DtgListadoCerdos.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCampoMotivoMortalidad(id As String, motivo As String)
        idMotivoMortalidad = id
        TxtMotivoMortalidad.Text = motivo
    End Sub

    Private Sub BtnMotivoMortalidad_Click(sender As Object, e As EventArgs) Handles BtnMotivoMortalidad.Click
        Try
            Dim filtroAmbiente As String = ""

            If idPlantel = 1 Or idPlantel = 2 Then
                filtroAmbiente = "RECRÍA"
            Else
                filtroAmbiente = "ENGORDE"
            End If

            Dim frm As New FrmListarMotivoMortalidadLote(Me) With {
                .tipoRegistro = tipoRegistro,
                .ambiente = filtroAmbiente
            }
            frm.ShowDialog()

            If idMotivoMortalidad = 87 Or idMotivoMortalidad = 88 Then
                LblPeso.Visible = True
                TxtPeso.Visible = True
                TxtPeso.Text = "0"
            Else
                LblPeso.Visible = False
                TxtPeso.Visible = False
                TxtPeso.Text = "0"
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgListadoCorrales_ClickCell(sender As Object, e As ClickCellEventArgs) Handles DtgListadoCorrales.ClickCell
        ConsultarAnimalesJaulaCorral()
    End Sub

    Private Sub ConsultarAnimalesJaulaCorral()
        Try
            Dim activeRow As UltraGridRow = DtgListadoCorrales.ActiveRow
            If (DtgListadoCorrales.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    idJaulaCorral = activeRow.Cells(0).Value
                    Dim obj As New coControlLoteDestete With {
                        .IdJaulaCorral = idJaulaCorral,
                        .IdLote = idLoteOriginal
                    }
                    DtgListadoCerdos.DataSource = cnLote.Cn_ConsultarAnimalesxIdJaulaCorral(obj)
                    ColorearAnimalesJaulaCorral()
                    NoVisibleCantCerdosTatuados()
                    NoVisibleCantCerdosNoReg()
                    LimpiarCampos()
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

    Sub ColorearAnimalesJaulaCorral()
        If (DtgListadoCerdos.Rows.Count > 0) Then
            Dim estadoCamal As Integer = 6

            ''estadoCamal
            clsBasicas.Colorear_SegunValor(DtgListadoCerdos, Color.LightSlateGray, Color.White, "ENVIADO", estadoCamal)
            clsBasicas.Colorear_SegunValor(DtgListadoCerdos, Color.LightSkyBlue, Color.MidnightBlue, "EN PRODUCCION", estadoCamal)
            clsBasicas.Colorear_SegunValor(DtgListadoCerdos, Color.LightCoral, Color.White, "DESCARTE", estadoCamal)
            clsBasicas.Colorear_SegunValor(DtgListadoCerdos, Color.LightGray, Color.Black, "-", estadoCamal)

            'centrar columnas
            With DtgListadoCerdos.DisplayLayout.Bands(0)
                .Columns(estadoCamal).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub DtgListadoCerdos_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles DtgListadoCerdos.DoubleClickCell
        Dim fila As UltraGridRow = DtgListadoCerdos.ActiveRow

        If fila IsNot Nothing Then
            If fila.Cells(0).Value Is Nothing OrElse String.IsNullOrWhiteSpace(fila.Cells(0).Value.ToString()) Then
                Return
            End If

            If fila.Cells.Exists("Cantidad") Then
                If Not IsDBNull(fila.Cells("Cantidad").Value) AndAlso Not IsNothing(fila.Cells("Cantidad").Value) Then
                    Decimal.TryParse(fila.Cells("Cantidad").Value.ToString(), cantCerdaDisponibleCamborEngorde)
                End If
            ElseIf fila.Cells.Exists("cantidad") Then
                If Not IsDBNull(fila.Cells("cantidad").Value) AndAlso Not IsNothing(fila.Cells("cantidad").Value) Then
                    Decimal.TryParse(fila.Cells("cantidad").Value.ToString(), cantCerdaDisponibleCamborEngorde)
                End If
            End If

            ' limpiar selecciones
            For Each r As UltraGridRow In DtgListadoCerdos.Rows
                r.Appearance.BackColor = Color.White
            Next
            listaIdCerdosReg.Clear()
            NoVisibleCantCerdosNoReg()
            NoVisibleCantCerdosTatuados()

            If fila.Cells(1).Value IsNot Nothing Then
                Dim tipoCerdo As String = fila.Cells(1).Value.ToString().ToUpper()
                Dim idCerdoRegistrado As String = fila.Cells(0).Value.ToString()

                ' Always allow multiple selection when RbtMortalidad is checked
                If RbtMortalidad.Checked Then
                    Select Case tipoCerdo
                        Case "ENGORDE"
                            ToggleRowSelection(fila, idCerdoRegistrado, "ENGORDE", AddressOf NoVisibleCantCerdosNoReg, AddressOf VisibleCantCerdosNoReg)

                        Case "CAMBOROUGH"
                            ToggleRowSelection(fila, idCerdoRegistrado, "CAMBOROUGH", AddressOf NoVisibleCantCerdosTatuados, AddressOf VisibleCantCerdosTatuados)

                        Case Else
                            ' Toggle selection for other types
                            If listaIdCerdosReg.Contains(idCerdoRegistrado) Then
                                listaIdCerdosReg.Remove(idCerdoRegistrado)
                                fila.Appearance.BackColor = Color.White
                            Else
                                listaIdCerdosReg.Add(idCerdoRegistrado)
                                fila.Appearance.BackColor = Color.LightSkyBlue
                            End If
                    End Select
                Else
                    Dim estadoCamal As String = fila.Cells("Estado Camal").Value.ToString()

                    If estadoCamal = "ENVIADO" Then
                        msj_advert("este animal ya fue enviado a camal")
                        Return
                    End If

                    Select Case tipoCerdo
                        Case "ENGORDE"
                            ToggleRowSelection(fila, idCerdoRegistrado, "ENGORDE", AddressOf NoVisibleCantCerdosNoReg, AddressOf VisibleCantCerdosNoReg)

                        Case "CAMBOROUGH"
                            ToggleRowSelection(fila, idCerdoRegistrado, "CAMBOROUGH", AddressOf NoVisibleCantCerdosTatuados, AddressOf VisibleCantCerdosTatuados)

                        Case Else
                            If listaIdCerdosReg.Contains(idCerdoRegistrado) Then
                                listaIdCerdosReg.Remove(idCerdoRegistrado)
                                fila.Appearance.BackColor = Color.White
                            Else
                                listaIdCerdosReg.Add(idCerdoRegistrado)
                                fila.Appearance.BackColor = Color.LightSkyBlue
                            End If
                    End Select
                End If
            End If
        End If
    End Sub

    Private Sub ToggleRowSelection(fila As UltraGridRow, idCerdoRegistrado As String, tipoToCheck As String, noVisibleAction As Action, visibleAction As Action)
        If fila.Appearance.BackColor = Color.LightSkyBlue Then
            fila.Appearance.BackColor = Color.White
            If listaIdCerdosReg.Contains(idCerdoRegistrado) Then
                listaIdCerdosReg.Remove(idCerdoRegistrado)
            End If
            If Not DtgListadoCerdos.Rows.Cast(Of UltraGridRow).Any(Function(r) r.Cells(1).Value.ToString().ToUpper() = tipoToCheck AndAlso r.Appearance.BackColor = Color.LightSkyBlue) Then
                noVisibleAction()
            End If
        Else
            fila.Appearance.BackColor = Color.LightSkyBlue
            If Not listaIdCerdosReg.Contains(idCerdoRegistrado) Then
                listaIdCerdosReg.Add(idCerdoRegistrado)
            End If
            visibleAction()
        End If
    End Sub
    Private Sub VisibleCantCerdosNoReg()
        LblCantidadCerdos.Visible = True
        TxtCantidadCerdosEngorde.Visible = True
        LblTipo.Visible = True
        If RbtMortalidad.Checked Then
            TxtCantidadCerdosEngorde.Text = "0"
        Else
            TxtCantidadCerdosEngorde.Text = "0"
        End If
    End Sub

    Private Sub VisibleCantCerdosTatuados()
        LblCantidadTatuadas.Visible = True
        TxtCantidadCerdosTatuadas.Visible = True
        LblTipo2.Visible = True
        If RbtMortalidad.Checked Then
            TxtCantidadCerdosTatuadas.Text = "0"
        Else
            TxtCantidadCerdosTatuadas.Text = "0"
        End If
    End Sub

    Private Sub NoVisibleCantCerdosNoReg()
        LblCantidadCerdos.Visible = False
        TxtCantidadCerdosEngorde.Visible = False
        LblTipo.Visible = False
        TxtCantidadCerdosEngorde.Text = "0"
    End Sub

    Private Sub NoVisibleCantCerdosTatuados()
        LblCantidadTatuadas.Visible = False
        TxtCantidadCerdosTatuadas.Visible = False
        LblTipo2.Visible = False
        TxtCantidadCerdosTatuadas.Text = "0"
    End Sub

    Private Sub RbtMortalidad_CheckedChanged(sender As Object, e As EventArgs) Handles RbtMortalidad.CheckedChanged
        If RbtMortalidad.Checked Then
            LblTipo.Text = "Mortalidad"
            LblTipo2.Text = "Mortalidad"
            tipoRegistro = "MORTALIDAD"
            RbnChanchillaEngorde.Visible = False
            RbnLechon.Checked = True
            LimpiarCamposIncidencia()

            LimpiarSelecciones()
        End If
    End Sub

    Private Sub RbtMandarCamal_CheckedChanged(sender As Object, e As EventArgs) Handles RbtMandarCamal.CheckedChanged
        If RbtMandarCamal.Checked Then
            LblTipo.Text = "Mandar Camal"
            LblTipo2.Text = "Mandar Camal"
            tipoRegistro = "EMERGENCIA"
            RbnChanchillaEngorde.Visible = True
            RbnLechon.Checked = True
            LimpiarCamposIncidencia()

            LimpiarSelecciones()
        End If
    End Sub

    Private Sub LimpiarSelecciones()
        For Each fila As UltraGridRow In DtgListadoCerdos.Rows
            fila.Appearance.BackColor = Color.White
        Next

        listaIdCerdosReg.Clear()

        NoVisibleCantCerdosNoReg()
        NoVisibleCantCerdosTatuados()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            Dim tipoEnvioCamal As Integer = 0

            If RbnLechon.Checked Then
                tipoEnvioCamal = 0 ' ENVIO LECHÓN
            Else
                If RbnChanchilla.Checked Then
                    tipoEnvioCamal = 1 ' ENVIO CHANCHILLA
                Else
                    tipoEnvioCamal = 2 ' ENVIO CHANCHILLA ENGORDE
                End If
            End If

            If (TxtObservacion.Text = "") Then
                msj_advert("Debe ingresar una observación")
                Exit Sub
            ElseIf (idMotivoMortalidad = 0) Then
                msj_advert("Debe seleccionar un motivo")
                Exit Sub
            Else
                If (TxtCantidadCerdosEngorde.Visible = True) Then
                    Dim filaEngorde As UltraGridRow = Nothing
                    For Each fila As UltraGridRow In DtgListadoCerdos.Rows
                        If fila.Cells(1).Value IsNot Nothing AndAlso fila.Cells(1).Value.ToString().ToUpper() = "ENGORDE" Then
                            filaEngorde = fila
                            Exit For
                        End If
                    Next

                    Dim numCriasNoRegistradas As String = filaEngorde.Cells(4).Value.ToString()
                    Dim numCriasEngordeEnviadasCamal As String = filaEngorde.Cells(5).Value.ToString()
                    Dim numCriasDisponiblesEnviarCamal As Integer = CInt(numCriasNoRegistradas) - CInt(numCriasEngordeEnviadasCamal)

                    If (listaIdCerdosReg.Count = 0 And TxtCantidadCerdosEngorde.Visible = False) Then
                        msj_advert("Debe seleccionar al menos un cerdo")
                        Exit Sub
                    End If

                    If (TxtCantidadCerdosEngorde.Text = "") Then
                        msj_advert("Debe ingresar la cantidad de cerdos de engorde")
                        Exit Sub
                    ElseIf (CInt(TxtCantidadCerdosEngorde.Text) <= 0) Then
                        msj_advert("La cantidad de cerdos de engorde no debe ser cero")
                        Exit Sub
                    End If

                    If (RbtMandarCamal.Checked) Then
                        If (CInt(TxtCantidadCerdosEngorde.Text) > CInt(numCriasDisponiblesEnviarCamal)) Then
                            msj_advert("La cantidad de cerdos de engorde para enviar a camal no debe ser mayor a lo disponible")
                            Exit Sub
                        End If
                    Else
                        If (CInt(TxtCantidadCerdosEngorde.Text) > CInt(numCriasNoRegistradas)) Then
                            msj_advert("La cantidad de cerdos de engorde no debe ser mayor a lo disponible")
                            Exit Sub
                        End If
                    End If
                End If

                If (TxtCantidadCerdosTatuadas.Visible = True) Then
                    Dim criasTatuadas As String = DtgListadoCerdos.Rows(DtgListadoCerdos.Rows.Count - 1).Cells(4).Value.ToString()
                    Dim criasTatuadasEnviadasCamal As String = DtgListadoCerdos.Rows(DtgListadoCerdos.Rows.Count - 1).Cells(5).Value.ToString()
                    Dim criasDisponiblesEnviarCamal As Integer = CInt(criasTatuadas) - CInt(criasTatuadasEnviadasCamal)

                    If (listaIdCerdosReg.Count = 0 And TxtCantidadCerdosTatuadas.Visible = False) Then
                        msj_advert("Debe seleccionar al menos un cerdo")
                        Exit Sub
                    End If

                    If (TxtCantidadCerdosTatuadas.Text = "") Then
                        msj_advert("Debe ingresar la cantidad de cerdos tatuados")
                        Exit Sub
                    ElseIf (CInt(TxtCantidadCerdosTatuadas.Text) <= 0) Then
                        msj_advert("La cantidad de cerdos tatuados no debe ser cero")
                        Exit Sub
                    End If

                    If (RbtMandarCamal.Checked) Then
                        If (CInt(TxtCantidadCerdosTatuadas.Text) > CInt(criasDisponiblesEnviarCamal)) Then
                            msj_advert("La cantidad de cerdos tatuados para enviar a camal no debe ser mayor a lo disponible")
                            Exit Sub
                        End If
                    Else

                        If (CInt(TxtCantidadCerdosTatuadas.Text) > CInt(criasTatuadas)) Then
                            msj_advert("La cantidad de cerdos de tatuados no debe ser mayor a lo disponible")
                            Exit Sub
                        End If
                    End If

                    If CInt(TxtCantidadCerdosTatuadas.Text) > cantCerdaDisponibleCamborEngorde Then
                        msj_advert("La cantidad de cerdos tatuados no debe ser cero")
                        Exit Sub
                    End If
                End If

                Dim filasSeleccionadas As Integer = 0
                For Each fila As UltraGridRow In DtgListadoCerdos.Rows
                    If fila.Appearance.BackColor = Color.LightSkyBlue Then
                        filasSeleccionadas += 1
                    End If
                Next
                If filasSeleccionadas = 0 Then
                    msj_advert("Debe seleccionar al menos un registro")
                    Return
                End If


                Dim listaFiltrada As List(Of String) = listaIdCerdosReg.Where(Function(x) x <> "0").ToList()
                Dim idsCerdosReg As String = String.Join(",", listaFiltrada)

                If (RbtMortalidad.Checked) Then

                    Dim frm As New FrmRegistrarMortalidadLote With {
                        .listaIdsCriasConCod = idsCerdosReg,
                        .cantidadMuertosEngorde = If(TxtCantidadCerdosEngorde.Text = "", 0, CInt(TxtCantidadCerdosEngorde.Text)),
                        .cantidadMuertosTatuaje = If(TxtCantidadCerdosTatuadas.Text = "", 0, CInt(TxtCantidadCerdosTatuadas.Text)),
                        .idLote = idLoteOriginal,
                        .idPlantel = idPlantel,
                        .cantidadMuertosConCod = listaFiltrada.Count,
                        .observacion = TxtObservacion.Text,
                        .idMotivoMortalidad = idMotivoMortalidad,
                        .idJaulaCorral = idJaulaCorral,
                        .fecha = DtpFecha.Value,
                        .esChanchilla = RbnChanchilla.Checked,
                        .frmMortalidad = Me
                    }
                    frm.ShowDialog()
                    LimpiarCampos()
                    listaIdCerdosReg.Clear()
                    ListarDetalleCorralesLote()
                Else
                    If idMotivoMortalidad = 87 Or idMotivoMortalidad = 88 Then
                        If TxtPeso.Text = "" Then
                            msj_advert("Debe ingresar el peso del cerdo")
                            Exit Sub
                        ElseIf CDec(TxtPeso.Text) <= 0 Then
                            msj_advert("El peso del cerdo no debe ser cero")
                            Exit Sub
                        End If
                    End If

                    Dim frm As New FrmRegistrarEnvioCamalLote With {
                        .listaIdsCriasConCod = idsCerdosReg,
                        .cantidadEngordeCamal = If(TxtCantidadCerdosEngorde.Text = "", 0, CInt(TxtCantidadCerdosEngorde.Text)),
                        .cantidadTatuajeCamal = If(TxtCantidadCerdosTatuadas.Text = "", 0, CInt(TxtCantidadCerdosTatuadas.Text)),
                        .idLote = idLoteOriginal,
                        .idPlantel = idPlantel,
                        .idMotivoEnvioCamal = idMotivoMortalidad,
                        .idJaulaCorral = idJaulaCorral,
                        .observacion = TxtObservacion.Text,
                        .fecha = DtpFecha.Value,
                        .peso = If(TxtPeso.Text = "", 0, CDec(TxtPeso.Text)),
                        .tipoEnvioCamal = tipoEnvioCamal,
                        .frmMandarCamal = Me
                    }
                    frm.ShowDialog()
                    LimpiarCampos()
                    listaIdCerdosReg.Clear()
                    ListarDetalleCorralesLote()
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LimpiarCampos()
        LimpiarCamposIncidencia()
        TxtCantidadCerdosEngorde.Text = ""
        TxtCantidadCerdosTatuadas.Text = ""
        listaIdCerdosReg.Clear()
        TxtPeso.Text = "0"
        TxtPeso.Visible = False
        LblPeso.Visible = False
        RbnLechon.Checked = True
        RbnChanchillaEngorde.Checked = False
        NoVisibleCantCerdosNoReg()
        NoVisibleCantCerdosTatuados()
    End Sub

    Private Sub LimpiarCamposIncidencia()
        idMotivoMortalidad = 0
        TxtMotivoMortalidad.Text = ""
        TxtPeso.Text = "0"
        TxtPeso.Visible = False
        LblPeso.Visible = False
    End Sub

    Private Sub TxtCantidadCerdosEngorde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidadCerdosEngorde.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub TxtCantidadCerdosTatuadas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidadCerdosTatuadas.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub TxtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPeso.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub DtgListadoCorrales_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles DtgListadoCorrales.InitializeLayout
        Try
            If (DtgListadoCorrales.Rows.Count = 0) Then
            Else
                clsBasicas.Totales_Formato(DtgListadoCorrales, e, 1)
                clsBasicas.SumarTotales_Formato(DtgListadoCorrales, e, 3)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class