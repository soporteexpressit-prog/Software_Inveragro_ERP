Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmMandarCamalMortalidadMadreFutura
    Dim cnAnimal As New cnControlAnimal
    Dim cnLote As New cnControlLoteDestete
    Dim idMotivoMortalidad As Integer = 0
    Dim idJaulaCorral As Integer = 0
    Dim listaIdCerdosReg As New List(Of String)
    Public idLote As Integer = 0
    Public idPlantel As Integer = 0
    Public valorPlantel As String = ""
    Public valorLote As String = ""

    Private Sub FrmMandarCamalMortalidadMadreFutura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializar()
        ListarDetalleCorralesLote()
    End Sub

    Private Sub Inicializar()
        TxtMotivo.ReadOnly = True
        RbtMortalidad.Checked = True
        LblLote.Text = valorLote
        LblPlantel.Text = valorPlantel
        DtpFecha.Value = Now.Date
        LblPeso.Visible = False
        TxtPeso.Visible = False
        NoVisibleCantCerdos()
    End Sub

    Private Sub ListarDetalleCorralesLote()
        Try
            Dim obj As New coControlLoteDestete With {
                .IdLote = idLote,
                .IdPlantel = idPlantel
            }

            DtgListadoCorrales.DataSource = cnLote.Cn_ConsultarCorralesMadreFutura(obj)
            clsBasicas.Formato_Tablas_Grid(DtgListadoCorrales)
            DtgListadoCorrales.DisplayLayout.Bands(0).Columns(0).Hidden = True

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
                .IdLote = idLote
            }

            DtgListadoCerdos.DataSource = cnLote.Cn_ConsultarAnimalesxIdJaulaCorralMadreFutura(obj)
            ColorearAnimalesJaulaCorral()
            clsBasicas.Filtrar_Tabla(DtgListadoCerdos, True)
            clsBasicas.Formato_Tablas_Grid(DtgListadoCerdos)
            DtgListadoCerdos.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub RbtMortalidad_CheckedChanged(sender As Object, e As EventArgs) Handles RbtMortalidad.CheckedChanged
        If RbtMortalidad.Checked Then
            LblTipo2.Text = "Mortalidad"
            LimpiarCamposIncidencia()

            LimpiarSelecciones()
        End If
    End Sub

    Private Sub RbtMandarCamal_CheckedChanged(sender As Object, e As EventArgs) Handles RbtMandarCamal.CheckedChanged
        If RbtMandarCamal.Checked Then
            LblTipo2.Text = "Mandar Camal"
            LimpiarCamposIncidencia()

            LimpiarSelecciones()
        End If
    End Sub

    Private Sub LimpiarCamposIncidencia()
        idMotivoMortalidad = 0
        TxtMotivo.Text = ""

        TxtPeso.Text = "0"
        TxtPeso.Visible = False
        LblPeso.Visible = False
    End Sub

    Public Sub LlenarCampoMotivoMortalidad(id As String, motivo As String)
        idMotivoMortalidad = id
        TxtMotivo.Text = motivo
    End Sub

    Private Sub BtnMotivoMortalidad_Click(sender As Object, e As EventArgs) Handles BtnMotivoMortalidad.Click
        Try
            Dim frm As New FrmListarMotivoMortalidadMadreFutura(Me) With {
                .tipoRegistro = If(RbtMortalidad.Checked, "MORTALIDAD", "INCIDENCIA")
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
                        .IdLote = idLote
                    }
                    DtgListadoCerdos.DataSource = cnLote.Cn_ConsultarAnimalesxIdJaulaCorralMadreFutura(obj)
                    ColorearAnimalesJaulaCorral()
                    NoVisibleCantCerdos()
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
        If fila Is Nothing Then Exit Sub

        Dim idCerdo As String = If(fila.Cells(0).Value, "").ToString()
        If String.IsNullOrWhiteSpace(idCerdo) Then Exit Sub

        Dim tipoCerdo As String = If(fila.Cells(1).Value, "").ToString().ToUpper()
        Dim yaSeleccionado As Boolean = (fila.Appearance.BackColor = Color.LightSkyBlue)

        If yaSeleccionado Then
            fila.Appearance.BackColor = Color.White
            listaIdCerdosReg.Remove(idCerdo)
            NoVisibleCantCerdos()
            LblCantidadCerdos.Text = ""
        Else
            ClearSelection()

            fila.Appearance.BackColor = Color.LightSkyBlue
            listaIdCerdosReg.Add(idCerdo)

            Select Case tipoCerdo
                Case "CAMBOROUGH"
                    LblCantidadCerdos.Text = "Cantidad Camborough :"
                    VisibleCantCerdos()

                Case "CELADOR"
                    LblCantidadCerdos.Text = "Cantidad Celador :"
                    VisibleCantCerdos()

                Case "M. MEISHAN"
                    LblCantidadCerdos.Text = "Cantidad M. Meishan :"
                    VisibleCantCerdos()

                Case Else
                    LblCantidadCerdos.Text = ""
                    NoVisibleCantCerdos()
            End Select
        End If
    End Sub

    Private Sub ClearSelection()
        For Each r As UltraGridRow In DtgListadoCerdos.Rows
            r.Appearance.BackColor = Color.White
        Next
        listaIdCerdosReg.Clear()
        NoVisibleCantCerdos()
        LblCantidadCerdos.Text = ""
    End Sub

    Private Sub VisibleCantCerdos()
        LblCantidadCerdos.Visible = True
        TxtCantidadCerdosTatuadas.Visible = True
        LblTipo2.Visible = True
        If RbtMortalidad.Checked Then
            TxtCantidadCerdosTatuadas.Text = "0"
        Else
            TxtCantidadCerdosTatuadas.Text = "0"
        End If
    End Sub

    Private Sub NoVisibleCantCerdos()
        LblCantidadCerdos.Visible = False
        TxtCantidadCerdosTatuadas.Visible = False
        LblTipo2.Visible = False
        TxtCantidadCerdosTatuadas.Text = "0"
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            Dim ultimaFilaSeleccionada As UltraGridRow = Nothing

            For Each fila As UltraGridRow In DtgListadoCerdos.Rows
                If fila.Appearance.BackColor = Color.LightSkyBlue Then
                    ultimaFilaSeleccionada = fila
                End If
            Next

            If (idMotivoMortalidad = 0) Then
                msj_advert("Debe seleccionar un motivo de mortalidad")
                Exit Sub
            Else
                If (TxtCantidadCerdosTatuadas.Visible = True) Then
                    Dim criasTatuadas As String = ultimaFilaSeleccionada.Cells(4).Value.ToString()
                    Dim criasTatuadasEnviadasCamal As String = ultimaFilaSeleccionada.Cells(5).Value.ToString()
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
                    Dim frm As New FrmEvidenciaMortalidadMadreFutura With {
                        .listaIdsCriasConCod = idsCerdosReg,
                        .cantidadMuertosEngorde = If(TxtCantidadCerdosTatuadas.Text = "", 0, CInt(TxtCantidadCerdosTatuadas.Text)),
                        .idLote = idLote,
                        .idPlantel = idPlantel,
                        .cantidadMuertosConCod = listaIdCerdosReg.Count,
                        .observacion = TxtObservacion.Text,
                        .idMotivoMortalidad = idMotivoMortalidad,
                        .idJaulaCorral = idJaulaCorral,
                        .fecha = DtpFecha.Value,
                        .tipo = DefinirTipo(),
                        .frmMortalidad = Me
                    }
                    frm.ShowDialog()
                    LimpiarCampos()
                    ConsultarAnimalesJaulaCorral()
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

                    Dim frm As New FrmEvidenciaCamalMadreFutura With {
                        .listaIdsCriasConCod = idsCerdosReg,
                        .cantidadEngordeCamal = If(TxtCantidadCerdosTatuadas.Text = "", 0, CInt(TxtCantidadCerdosTatuadas.Text)),
                        .idLote = idLote,
                        .idPlantel = idPlantel,
                        .idMotivoEnvioCamal = idMotivoMortalidad,
                        .observacion = TxtObservacion.Text,
                        .idJaulaCorral = idJaulaCorral,
                        .fecha = DtpFecha.Value,
                        .tipo = DefinirTipo(),
                        .peso = If(TxtPeso.Text = "", 0, CDec(TxtPeso.Text)),
                        .frmMandarCamal = Me
                    }
                    frm.ShowDialog()
                    LimpiarCampos()
                    ConsultarAnimalesJaulaCorral()
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LimpiarCampos()
        LimpiarCamposIncidencia()
        TxtCantidadCerdosTatuadas.Text = ""
        listaIdCerdosReg.Clear()
        NoVisibleCantCerdos()
        TxtPeso.Text = "0"
        TxtPeso.Visible = False
        LblPeso.Visible = False
    End Sub

    Private Function DefinirTipo() As String
        Dim tipo As String = ""

        If LblCantidadCerdos.Text = "Cantidad Camborough :" Then
            tipo = "CAMBOROUGH"
        ElseIf LblCantidadCerdos.Text = "Cantidad Celador :" Then
            tipo = "CELADOR"
        ElseIf LblCantidadCerdos.Text = "Cantidad M. Meishan :" Then
            tipo = "MEISHAN"
        End If

        Return tipo
    End Function

    Private Sub TxtCantidadCerdosTatuadas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidadCerdosTatuadas.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub LimpiarSelecciones()
        For Each fila As UltraGridRow In DtgListadoCerdos.Rows
            fila.Appearance.BackColor = Color.White
        Next

        listaIdCerdosReg.Clear()
        NoVisibleCantCerdos()
    End Sub

    Private Sub TxtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPeso.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class