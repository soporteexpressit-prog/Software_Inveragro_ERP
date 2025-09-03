Imports CapaNegocio
Imports CapaObjetos

Public Class FrmLineaProduccionReproductiva
    Dim cn As New cnControlAnimal
    Dim tbtmp As New DataTable
    Dim tbtmp2 As New DataTable
    Dim search As Boolean = True

    Private Sub FrmLineaProduccionReproductiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        Try
            Me.KeyPreview = True
            Ptbx_Cargando.Visible = True
            dtpFechaDesde.Value = Now.Date
            dtpFechaHasta.Value = Now.Date
            tbtmp2 = cn.Cn_ListarUltimas2Campañas().Copy
            If tbtmp2 IsNot Nothing AndAlso tbtmp2.Rows.Count > 0 Then
                LlenarLabelsCampañas(tbtmp2)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            BtnBuscar.Enabled = False

            If search Then
                Dim intervalo = ObtenerIntervaloSemana(Now.Date)
                dtpFechaDesde.Value = intervalo.Item1
                dtpFechaHasta.Value = Now.Date
            End If

            Dim obj As New coControlAnimal With {
                .FechaDesde = dtpFechaDesde.Value,
                .FechaHasta = dtpFechaHasta.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Public Function ObtenerIntervaloSemana(ByVal fecha As Date) As Tuple(Of Date, Date)
        Dim primerDiaSemana As Date = fecha.AddDays(-(fecha.DayOfWeek))
        Dim ultimoDiaSemana As Date = primerDiaSemana.AddDays(6)

        Return New Tuple(Of Date, Date)(primerDiaSemana, ultimoDiaSemana)
    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            tbtmp = cn.Cn_LineaProduccionReproductiva(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        BtnBuscar.Enabled = True
        search = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            LimpiarLabels()

            Dim dt As DataTable = CType(e.Result, DataTable)

            For Each row As DataRow In dt.Rows
                Dim tipoEvento As String = row("TipoEvento").ToString()
                Dim cantidad As String = FormatNumber(row("Cantidad"), 0)

                Select Case tipoEvento
                    Case "SEMEN_COMPRADO"
                        LblSemenComprado.Text = cantidad

                    Case "SEMEN_GRANJA"
                        LblSemenGranja.Text = cantidad

                    Case "SERVICIOS"
                        LblServicios.Text = cantidad

                    Case "REPETICION_CELO"
                        LblRepeticionCelo.Text = cantidad

                    Case "FALSA_PRENEZ"
                        LblFalsaPrenez.Text = cantidad

                    Case "ABORTOS"
                        LblAbortos.Text = cantidad

                    Case "PARTOS"
                        LblPartos.Text = cantidad

                    Case "TOTAL_CRIAS_NACIDAS"
                        LblTotalCriasNacidas.Text = cantidad

                    Case "TOTAL_MUERTES_PARTO"
                        lblTotalMuertesParto.Text = cantidad

                    Case "MORTALIDAD_CRIAS"
                        LblMortalidadCrias.Text = cantidad

                    Case "DESTETES"
                        LblDestetes.Text = cantidad

                    Case "DESTETES_NULOS"
                        LblDestetesNulos.Text = cantidad

                    Case "TOTAL_CRIAS_DESTETADAS"
                        LblTotalCriasDestetadas.Text = cantidad

                    Case "CERDOS_MENOS_40_DIAS"
                        LblCerdosMenos40.Text = cantidad

                    Case "CERDOS_40_80_DIAS"
                        LblCerdos40a80.Text = cantidad

                    Case "CERDOS_81_120_DIAS"
                        LblCerdos81a120.Text = cantidad

                    Case "CERDOS_MAS_120_DIAS"
                        LblCerdosMas120.Text = cantidad

                End Select
            Next

            LblTotalAnimales.Text = (CInt(LblCerdosMenos40.Text) +
                                    CInt(LblCerdos40a80.Text) +
                                    CInt(LblCerdos81a120.Text) +
                                    CInt(LblCerdosMas120.Text)).ToString("N0")

            LblTotalDosis.Text = CInt(LblSemenComprado.Text) + CInt(LblSemenGranja.Text)
            CalcularIndicadores()
        End If
    End Sub

    Private Sub CalcularIndicadores()
        Try
            Dim servicios As Integer = If(IsNumeric(LblServicios.Text), CInt(LblServicios.Text), 0)
            Dim repeticionCelo As Integer = If(IsNumeric(LblRepeticionCelo.Text), CInt(LblRepeticionCelo.Text), 0)
            Dim abortos As Integer = If(IsNumeric(LblAbortos.Text), CInt(LblAbortos.Text), 0)
            Dim partos As Integer = If(IsNumeric(LblPartos.Text), CInt(LblPartos.Text), 0)
            Dim totalCriasNacidas As Integer = If(IsNumeric(LblTotalCriasNacidas.Text), CInt(LblTotalCriasNacidas.Text), 0)
            Dim muertesParto As Integer = If(IsNumeric(lblTotalMuertesParto.Text), CInt(lblTotalMuertesParto.Text), 0)
            Dim mortalidadCrias As Integer = If(IsNumeric(LblMortalidadCrias.Text), CInt(LblMortalidadCrias.Text), 0)
            Dim totalCriasDestetadas As Integer = If(IsNumeric(LblTotalCriasDestetadas.Text), CInt(LblTotalCriasDestetadas.Text), 0)
            Dim totalDosis As Integer = If(IsNumeric(LblTotalDosis.Text), CInt(LblTotalDosis.Text), 0)
            Dim totalAnimales As Integer = If(IsNumeric(LblTotalAnimales.Text), CInt(LblTotalAnimales.Text), 0)

            ' Tasa de Concepción
            If servicios > 0 Then
                Dim tasaConcepcion As Double = ((servicios - repeticionCelo) / servicios) * 100
                LblTasaConcepcion.Text = FormatNumber(tasaConcepcion, 1) & "%"
            Else
                LblTasaConcepcion.Text = "0.0%"
            End If

            ' Fertilidad (Partos/Servicios)
            If servicios > 0 Then
                Dim fertilidad As Double = (partos / servicios) * 100
                LblFertilidad.Text = FormatNumber(fertilidad, 1) & "%"
            Else
                LblFertilidad.Text = "0.0%"
            End If

            ' Tasa de Abortos
            If (partos + abortos) > 0 Then
                Dim tasaAbortos As Double = (abortos / (partos + abortos)) * 100
                LblTasaAbortos.Text = FormatNumber(tasaAbortos, 1) & "%"
            Else
                LblTasaAbortos.Text = "0.0%"
            End If

            ' Lechones por Parto
            If partos > 0 Then
                Dim lechonesPorParto As Double = totalCriasNacidas / partos
                LblLechonesPorParto.Text = FormatNumber(lechonesPorParto, 1)
            Else
                LblLechonesPorParto.Text = "0.0"
            End If

            ' Mortalidad al Parto
            If totalCriasNacidas > 0 Then
                Dim mortalidadParto As Double = (muertesParto / totalCriasNacidas) * 100
                LblMortalidadParto.Text = FormatNumber(mortalidadParto, 1) & "%"
            Else
                LblMortalidadParto.Text = "0.0%"
            End If

            ' Tasa de Destete
            If totalCriasNacidas > 0 Then
                Dim tasaDestete As Double = (totalCriasDestetadas / totalCriasNacidas) * 100
                LblTasaDestete.Text = FormatNumber(tasaDestete, 1) & "%"
            Else
                LblTasaDestete.Text = "0.0%"
            End If

            ' Mortalidad Pre-destete
            If totalCriasNacidas > 0 Then
                Dim mortalidadPreDestete As Double = (mortalidadCrias / totalCriasNacidas) * 100
                LblMortalidadPreDestete.Text = FormatNumber(mortalidadPreDestete, 1) & "%"
            Else
                LblMortalidadPreDestete.Text = "0.0%"
            End If

            ' Supervivencia Total (desde nacimiento a destete)
            If totalCriasNacidas > 0 Then
                Dim supervivenciaTotal As Double = (totalCriasDestetadas / totalCriasNacidas) * 100
                LblSupervivenciaTotal.Text = FormatNumber(supervivenciaTotal, 1) & "%"
            Else
                LblSupervivenciaTotal.Text = "0.0%"
            End If
        Catch ex As Exception
            msj_advert("Error al calcular indicadores")
        End Try
    End Sub

    Private Sub LimpiarLabels()
        LblServicios.Text = "0"
        LblRepeticionCelo.Text = "0"
        LblSemenComprado.Text = "0"
        LblSemenGranja.Text = "0"
        LblFalsaPrenez.Text = "0"
        LblAbortos.Text = "0"
        LblPartos.Text = "0"
        LblTotalCriasNacidas.Text = "0"
        lblTotalMuertesParto.Text = "0"
        lblTotalMuertesParto.Text = "0"
        LblDestetes.Text = "0"
        LblDestetesNulos.Text = "0"
        LblTotalCriasDestetadas.Text = "0"
        LblCerdosMenos40.Text = "0"
        LblCerdos40a80.Text = "0"
        LblCerdos81a120.Text = "0"
        LblCerdosMas120.Text = "0"
    End Sub

    Private Sub FrmLineaProduccionReproductiva_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnBuscar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub LlenarLabelsCampañas(dt As DataTable)
        Try
            For Each row As DataRow In dt.Rows
                Dim estadoCampaña As String = row("estadoCampaña").ToString()
                Dim campaña As String = row("campaña").ToString()
                Dim ubicacion As String = row("ubicacion").ToString()
                Dim fechaInicio As String = row("fAperturaLlenado").ToString()
                Dim fechaFin As String = row("fFinVenta").ToString()
                Dim ingreso As String = FormatNumber(row("ingreso"), 0)
                Dim retorno As String = FormatNumber(row("retorno"), 0)
                Dim muertos As String = FormatNumber(row("muertos"), 0)
                Dim emergencias As String = FormatNumber(row("emergencias"), 0)
                Dim donacion As String = FormatNumber(row("donacion"), 0)
                Dim consumo As String = FormatNumber(row("consumo"), 0)
                Dim totalAnimalCampaña As String = FormatNumber(row("TotalAnimalCampaña"), 0)

                Select Case estadoCampaña.ToUpper()
                    Case "LLENANDO"
                        LblCampañaEnCurso.Text = campaña + " - LLENADO"
                        LblPlantelEnCurso.Text = ubicacion
                        LblFechaAperturaEnCurso.Text = fechaInicio
                        LblIngresoEnCurso.Text = ingreso
                        LblRetornoEnCurso.Text = retorno
                        LblMortalidadEnCurso.Text = muertos
                        LblEmergenciaEnCurso.Text = emergencias
                        LblDonacionEnCurso.Text = donacion
                        LblConsumoEnCurso.Text = consumo
                        LblAnimalesEnCurso.Text = totalAnimalCampaña
                        If LblCampañaEnCurso.Text <> "0" Then
                            LblCampañaEnCurso.ForeColor = Color.Green
                        End If
                    Case "CERRADA"
                        LblCampañaCerrado.Text = campaña + " - CERRADO"
                        LblPlantelCerrado.Text = ubicacion
                        LblFechaAperturaCerrado.Text = fechaInicio
                        LblFechaCierreCerrado.Text = fechaFin
                        LblIngresoCerrado.Text = ingreso
                        LblRetornoCerrado.Text = retorno
                        LblMortalidadCerrado.Text = muertos
                        LblEmergenciaCerrado.Text = emergencias
                        LblDonacionCerrado.Text = donacion
                        LblConsumoCerrado.Text = consumo
                        LblAnimalesCerrado.Text = totalAnimalCampaña
                        If LblCampañaCerrado.Text <> "0" Then
                            LblCampañaCerrado.ForeColor = Color.Red
                        End If
                End Select
            Next

        Catch ex As Exception
            msj_advert("Error al procesar datos de campañas: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub
End Class