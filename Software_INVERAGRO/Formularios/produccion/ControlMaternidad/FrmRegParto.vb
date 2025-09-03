Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmRegParto
    Dim cnAnimal As New cnControlAnimal
    Private DtDetalle As New DataTable("TempDetPesoCria")
    Private cargandoDatos As Boolean = False
    Public idControlParto As Integer = 0
    Dim operacion As Integer = 0
    Dim idCerda As String
    Dim idGenetica As Integer
    Dim compCamborough As String = ""
    Dim numCriasTotalVivo As Integer = 0
    Dim idPartero As Integer = 0
    Dim pesoPromedioCria As Decimal
    Dim idJaulaCorral As Integer = 0
    Dim idLote As Integer = 0
    Dim tatuaje As String = ""
    Public idUbicacion As Integer = 0
    Public arete As String = ""

    Private Sub FrmRegParto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarGalpones(idUbicacion)
            InicializarValores()
            If idControlParto = 0 Then
                BloquearDesbloquearCampos()
            Else
                NoMostrarCandados()
                LblSeleccionarCerda.Visible = False
                BtnBuscarCerda.Visible = False
                ConsultarxId()
                LblNumCriasTotal.Text = NumVivoMacho.Value + NumVivoHembra.Value
                LblTotalBallicos.Text = ContarPorTipoCria(dtgListado, "BALLICO").ToString()
                If DtDetalle.Rows.Count >= 1 Then
                    TxtPesoTotal.ReadOnly = False
                    numCriasTotalVivo = NumVivoHembra.Value + NumVivoMacho.Value
                    CalcularPesoPromedioCria()
                Else
                    TxtPesoTotal.ReadOnly = True
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub InicializarValores()
        RbnJaula.Checked = True
        TxtJaulaCorral.ReadOnly = True
        TxtSala.ReadOnly = True
        TxtPesoTotal.ReadOnly = True
        TxtLote.ReadOnly = True
        TxtDniEncargado.ReadOnly = True
        TxtNombreEncargado.ReadOnly = True
        LblCodArete.Text = arete
        CargarTablaDetallePesoCria()
    End Sub

    Private Sub NoMostrarCandados()
        BtnBloquearFecha.Visible = False
        BtnBloquearCondCorporal.Visible = False
        BtnBloquearLote.Visible = False
        BtnBloquearHrInicio.Visible = False
        BtnBloquearHrFin.Visible = False
        BtnBloquearGalpon.Visible = False
        BtnBloquearPartero.Visible = False
        BtnBloquearTatuaje.Visible = False
    End Sub

    Sub ConsultarxId()
        Try
            Dim obj As New coControlAnimal With {
                .Codigo = idControlParto
            }
            Dim ds As New DataSet
            ds = cnAnimal.Cn_ConsultarControlFichaParto(obj).Copy
            If (ds.Tables(0).Rows.Count > 0) Then
                cargandoDatos = True
                DtpFechaParto.Value = ds.Tables(0).Rows(0)("fControl")
                NumVivoMacho.Value = ds.Tables(0).Rows(0)("totalNacidosMachos")
                NumVivoHembra.Value = ds.Tables(0).Rows(0)("totalNacidosHembras")
                TxtCondCorporal.Text = ds.Tables(0).Rows(0)("condCorporal")
                idLote = ds.Tables(0).Rows(0)("idLote")
                TxtLote.Text = ds.Tables(0).Rows(0)("lote")
                TxtObservacion.Text = ds.Tables(0).Rows(0)("observacion")
                CmbGalpon.Value = ds.Tables(0).Rows(0)("idGalpon")
                idJaulaCorral = ds.Tables(0).Rows(0)("idJaulaCorral")
                TxtJaulaCorral.Text = ds.Tables(0).Rows(0)("jaula")
                TxtSala.Text = ds.Tables(0).Rows(0)("sala")
                idPartero = ds.Tables(0).Rows(0)("idResponsable")
                TxtDniEncargado.Text = ds.Tables(0).Rows(0)("numDocumento")
                TxtNombreEncargado.Text = ds.Tables(0).Rows(0)("datos")
                TxtPesoTotal.Text = ds.Tables(0).Rows(0)("pesoTotalCrias").ToString()
                LblPesoPromedio.Text = ds.Tables(0).Rows(0)("pesoPromCrias").ToString()
                NumMuertos.Value = ds.Tables(0).Rows(0)("totalMuertos")
                NumMomias.Value = ds.Tables(0).Rows(0)("totalMomias")
                idCerda = ds.Tables(0).Rows(0)("idAnimal")
                idGenetica = ds.Tables(0).Rows(0)("idGenetica")
                compCamborough = ds.Tables(0).Rows(0)("comCamborough")
                cargandoDatos = False
            End If

            If (ds.Tables(1).Rows.Count > 0) Then
                For i = 0 To ds.Tables(1).Rows.Count - 1
                    Dim dr As DataRow = DtDetalle.NewRow
                    dr(0) = ds.Tables(1).Rows(i)("indice")
                    dr(1) = ds.Tables(1).Rows(i)("idAnimal")
                    dr(2) = ds.Tables(1).Rows(i)("peso")
                    dr(3) = ds.Tables(1).Rows(i)("genero")
                    dr(4) = ds.Tables(1).Rows(i)("condicionNacimiento")
                    dr(5) = ds.Tables(1).Rows(i)("checkCondicion")
                    dr(6) = ds.Tables(1).Rows(i)("valorTatuaje")
                    dr(7) = ds.Tables(1).Rows(i)("checkRegistrar")
                    DtDetalle.Rows.Add(dr)
                Next
                dtgListado.DataSource = DtDetalle
                If idGenetica <> 1 Then
                    TxtTatuajeCrias.Text = ObtenerValorTatuaje()
                End If
            End If
            OcultarVisualizarColumnas()
            RenombrarColumnas()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function ObtenerValorTatuaje() As String
        Dim valorTatuaje As String = ""
        For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If Not IsDBNull(fila.Cells("tatuaje").Value) AndAlso fila.Cells("tatuaje").Value.ToString() <> "-" Then
                valorTatuaje = fila.Cells("tatuaje").Value.ToString()
                Exit For
            End If
        Next
        Return valorTatuaje
    End Function

    Private Sub BloquearDesbloquearCampos()
        ConsultarInicializarDiccionario()
        If idCerda = 0 Then
            DtpFechaParto.Enabled = False
            BtnBloquearFecha.Enabled = False
            NumVivoMacho.Enabled = False
            NumVivoHembra.Enabled = False
            TxtCondCorporal.Enabled = False
            BtnBloquearCondCorporal.Enabled = False
            BtnAsignarLote.Enabled = False
            BtnBloquearLote.Enabled = False
            TxtObservacion.Enabled = False
            DtpHoraEntrada.Enabled = False
            BtnBloquearHrInicio.Enabled = False
            dtgListado.Enabled = False
            DtpHoraSalida.Enabled = False
            BtnBloquearHrFin.Enabled = False
            NumMuertos.Enabled = False
            NumMomias.Enabled = False
            CmbGalpon.Enabled = False
            BtnBloquearGalpon.Enabled = False
            BtnBuscarJaulaCorral.Enabled = False
            BtnEncargado.Enabled = False
            BtnBloquearPartero.Enabled = False
            TxtTatuajeCrias.Enabled = False
            BtnBloquearTatuaje.Enabled = False
        Else
            DtpFechaParto.Enabled = True
            BtnBloquearFecha.Enabled = True
            NumVivoMacho.Enabled = True
            NumVivoHembra.Enabled = True
            TxtCondCorporal.Enabled = True
            BtnBloquearCondCorporal.Enabled = True
            BtnAsignarLote.Enabled = True
            BtnBloquearLote.Enabled = True
            TxtObservacion.Enabled = True
            DtpHoraEntrada.Enabled = True
            BtnBloquearHrInicio.Enabled = True
            dtgListado.Enabled = True
            DtpHoraSalida.Enabled = True
            BtnBloquearHrFin.Enabled = True
            NumMuertos.Enabled = True
            NumMomias.Enabled = True
            CmbGalpon.Enabled = True
            BtnBloquearGalpon.Enabled = True
            BtnBuscarJaulaCorral.Enabled = True
            BtnEncargado.Enabled = True
            BtnBloquearPartero.Enabled = True
            TxtTatuajeCrias.Enabled = True
            BtnBloquearTatuaje.Enabled = True
        End If
    End Sub

    Private Sub ConsultarInicializarDiccionario()
        DtpFechaParto.Value = VariablesGlobales.ParametrosParto("fParto")
        DtpFechaParto.Enabled = If(VariablesGlobales.ParametrosParto("fPartoBloqueo") = 1, False, True)
        TxtCondCorporal.Text = VariablesGlobales.ParametrosParto("condCorporal")
        TxtCondCorporal.Enabled = If(VariablesGlobales.ParametrosParto("condCorporalBloqueo") = 1, False, True)
        If VariablesGlobales.ParametrosParto("galponBloqueo") = 1 Then
            CmbGalpon.Value = VariablesGlobales.ParametrosParto("idGalpon")
            CmbGalpon.Enabled = False
        End If

        If VariablesGlobales.ParametrosParto("loteBloqueo") = 1 Then
            idLote = VariablesGlobales.ParametrosParto("idLote")
            TxtLote.Text = VariablesGlobales.ParametrosParto("valorLote")
            BtnAsignarLote.Enabled = False
        End If

        If VariablesGlobales.ParametrosParto("parteroBloqueo") = 1 Then
            idPartero = VariablesGlobales.ParametrosParto("idPartero")
            TxtDniEncargado.Text = VariablesGlobales.ParametrosParto("valorDni")
            TxtNombreEncargado.Text = VariablesGlobales.ParametrosParto("valorNombre")
            BtnEncargado.Enabled = False
        End If

        If VariablesGlobales.ParametrosParto("horaInicioBloqueo") = 1 Then
            DtpHoraEntrada.Value = VariablesGlobales.ParametrosParto("horaInicio")
            DtpHoraEntrada.Enabled = False
        End If

        If VariablesGlobales.ParametrosParto("horaFinBloqueo") = 1 Then
            DtpHoraSalida.Value = VariablesGlobales.ParametrosParto("horaFin")
            DtpHoraSalida.Enabled = False
        End If

        If VariablesGlobales.ParametrosParto("tatuajeBloqueo") = 1 Then
            TxtTatuajeCrias.Text = VariablesGlobales.ParametrosParto("tatuaje")
            TxtTatuajeCrias.Enabled = False
        End If

        FormateamosRegistros()
    End Sub

    Private Sub FormateamosRegistros()
        dtgListado.DataSource = Nothing
        CargarTablaDetallePesoCria()
        OcultarVisualizarColumnas()
        RenombrarColumnas()
        NumVivoMacho.Value = 0
        NumVivoHembra.Value = 0
        NumMuertos.Value = 0
        NumMomias.Value = 0
    End Sub

    Sub ListarGalpones(idplantel As Integer)
        Dim cn As New cnGalpon
        Dim tb As New DataTable
        Dim obj As New coGalpon With {
            .IdUbicacion = idplantel
        }
        tb = cn.Cn_Listar_Galpones_Por_Plantel(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Galpón"
        With CmbGalpon
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Public Sub LlenarCamposCerdaGestante(codigo As String, datos As String, comportamiento As String, genetica As Integer, valorGenetica As String)
        idCerda = codigo
        LblCodArete.Text = datos
        compCamborough = comportamiento
        idGenetica = genetica
        LblGenetica.Text = valorGenetica

        BloquearDesbloquearCampos()
        If (idGenetica = 1) Then
            LblCodArete.BackColor = Color.White
            LblGenetica.BackColor = Color.White
        ElseIf (idGenetica = 2) Then
            LblCodArete.BackColor = Color.LightSkyBlue
            LblGenetica.BackColor = Color.LightSkyBlue
        ElseIf (idGenetica = 3) Then
            LblCodArete.BackColor = Color.LightGreen
            LblGenetica.BackColor = Color.LightGreen
        End If
    End Sub

    Private Sub BtnBuscarCerda_Click(sender As Object, e As EventArgs) Handles BtnBuscarCerda.Click
        Try
            Dim frm As New FrmListarCerdaParto(Me) With {
                .idPlantel = idUbicacion
            }
            frm.ShowDialog()
            ConsultarInicializarDiccionario()
            If ((idGenetica = 1 And compCamborough = "NO") Or (idGenetica = 2 And compCamborough = "NO")) Then
                TxtTatuajeCrias.Text = ConsultarTatuaje()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposJaulaCorral(codigo As Integer, descripcion As String, sala As String)
        idJaulaCorral = codigo
        TxtJaulaCorral.Text = descripcion
        TxtSala.Text = sala
    End Sub

    Private Function ConsultarTatuaje() As String
        Try
            Dim dt As New DataTable
            Dim tatuaje As String = ""
            Dim obj As New coControlAnimal With {
                .IdPlantel = idUbicacion
            }
            dt = cnAnimal.Cn_ConsultarTatuajeCambor(obj).Copy
            If (dt.Rows.Count > 0) Then
                tatuaje = dt.Rows(0)("SiguienteTatuaje").ToString()
            End If
            Return tatuaje
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
            Return ""
        End Try
    End Function

    Sub CargarTablaDetallePesoCria()
        DtDetalle = New DataTable("TempDetPesoCria")
        DtDetalle.Columns.Add("numero", GetType(Integer))
        DtDetalle.Columns.Add("idCria", GetType(Integer))
        DtDetalle.Columns.Add("peso", GetType(String))
        DtDetalle.Columns.Add("genero", GetType(String))
        DtDetalle.Columns.Add("tipoCria", GetType(String))
        DtDetalle.Columns.Add("condicion", GetType(Boolean))
        DtDetalle.Columns.Add("tatuaje", GetType(String))
        DtDetalle.Columns.Add("tatuar", GetType(Boolean))
        dtgListado.DataSource = DtDetalle
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            clsBasicas.Formato_Tablas_Grid_TresUltimasColumnaEditable(dtgListado)
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True
                .Columns(2).Header.Caption = "Peso"
                .Columns(3).Header.Caption = "Sexo"
                .Columns(4).Header.Caption = "Tipo"
                .Columns(5).Header.Caption = "Condición"
                .Columns(6).Header.Caption = "Tatuaje"
                .Columns(7).Header.Caption = "Tatuar"
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function SumarPesosCrias() As Decimal
        Dim suma As Decimal = 0
        For Each row As DataRow In DtDetalle.Rows
            If Not String.IsNullOrWhiteSpace(row("peso").ToString()) Then
                suma += CDec(row("peso"))
            End If
        Next
        Return suma
    End Function

    Private Sub NumVivoMacho_ValueChanged(sender As Object, e As EventArgs) Handles NumVivoMacho.ValueChanged
        If Not cargandoDatos Then
            ActualizarTablaDetallePesoCria()
        End If
    End Sub

    Private Sub NumVivoHembra_ValueChanged(sender As Object, e As EventArgs) Handles NumVivoHembra.ValueChanged
        If Not cargandoDatos Then
            ActualizarTablaDetallePesoCria()
        End If
    End Sub

    Private Sub ActualizarTablaDetallePesoCria()
        dtgListado.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
        numCriasTotalVivo = NumVivoHembra.Value + NumVivoMacho.Value

        Dim currentRowCount As Integer = DtDetalle.Rows.Count
        Dim currentMachoCount As Integer = DtDetalle.Select("genero = 'MACHO'").Count()
        Dim currentHembraCount As Integer = DtDetalle.Select("genero = 'HEMBRA'").Count()

        If numCriasTotalVivo > currentRowCount Then
            For i As Integer = currentRowCount + 1 To numCriasTotalVivo
                Dim row As DataRow = DtDetalle.NewRow()
                row("idCria") = 0
                row("peso") = ""
                row("tatuaje") = "-"
                row("tatuar") = False
                row("condicion") = False
                row("tipoCria") = "NORMAL"

                If currentMachoCount < NumVivoMacho.Value Then
                    row("genero") = "MACHO"
                    currentMachoCount += 1
                Else
                    row("genero") = "HEMBRA"
                    currentHembraCount += 1
                End If

                DtDetalle.Rows.Add(row)
            Next
        ElseIf numCriasTotalVivo < currentRowCount Then
            While currentMachoCount > NumVivoMacho.Value
                For Each row As DataRow In DtDetalle.Rows
                    If row("genero").ToString() = "MACHO" Then
                        DtDetalle.Rows.Remove(row)
                        currentMachoCount -= 1
                        Exit For
                    End If
                Next
            End While

            While currentHembraCount > NumVivoHembra.Value
                For Each row As DataRow In DtDetalle.Rows
                    If row("genero").ToString() = "HEMBRA" Then
                        DtDetalle.Rows.Remove(row)
                        currentHembraCount -= 1
                        Exit For
                    End If
                Next
            End While
        End If

        Dim counter As Integer = 1
        For Each row As DataRow In DtDetalle.Rows
            row("numero") = counter.ToString()
            counter += 1
        Next

        dtgListado.DataSource = Nothing
        dtgListado.DataSource = DtDetalle

        OcultarVisualizarColumnas()
        RenombrarColumnas()

        If DtDetalle.Rows.Count >= 1 Then
            TxtPesoTotal.ReadOnly = False
            CalcularPesoPromedioCria()
        Else
            TxtPesoTotal.ReadOnly = True
            TxtPesoTotal.Text = "0.0"
        End If

        LblNumCriasTotal.Text = numCriasTotalVivo.ToString()
        LblTotalBallicos.Text = ContarPorTipoCria(dtgListado, "BALLICO").ToString()
    End Sub

    Private Sub OcultarVisualizarColumnas()
        If ((idGenetica = 1 And compCamborough = "NO") Or (idGenetica = 2 And compCamborough = "NO")) Then
            dtgListado.DisplayLayout.Bands(0).Columns("tatuaje").Hidden = False
            dtgListado.DisplayLayout.Bands(0).Columns("tatuar").Hidden = False
            TxtTatuajeCrias.Visible = True
            LblTatuajeCria.Visible = True
            BtnBloquearTatuaje.Visible = True
        Else
            dtgListado.DisplayLayout.Bands(0).Columns("tatuaje").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("tatuar").Hidden = True
            TxtTatuajeCrias.Visible = False
            LblTatuajeCria.Visible = False
            BtnBloquearTatuaje.Visible = False
        End If

        If idGenetica = 1 And compCamborough = "NO" Then
            TxtTatuajeCrias.Visible = False
            LblTatuajeCria.Visible = False
            BtnBloquearTatuaje.Visible = False
        End If
    End Sub

    Private Sub RenombrarColumnas()
        If (idGenetica = 1) Then
            dtgListado.DisplayLayout.Bands(0).Columns("tatuaje").Header.Caption = "T. Pic Track"
            dtgListado.DisplayLayout.Bands(0).Columns("tatuar").Header.Caption = "Registrar"
        Else
            dtgListado.DisplayLayout.Bands(0).Columns("tatuaje").Header.Caption = "Tatuaje"
            dtgListado.DisplayLayout.Bands(0).Columns("tatuar").Header.Caption = "Tatuar"
        End If
    End Sub

    Private Sub TxtPeso_KeyPress(sender As Object, e As KeyPressEventArgs)
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub NumVivoMacho_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NumVivoMacho.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub NumMuertoMacho_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NumMuertos.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub NumVivoHembra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NumVivoHembra.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub NumMuertoHembra_KeyPress(sender As Object, e As KeyPressEventArgs)
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub NumTotalMomia_KeyPress(sender As Object, e As KeyPressEventArgs)
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub TxtCondCorporal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCondCorporal.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            dtgListado.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)

            Dim tiempoTranscurrido As TimeSpan = DtpHoraSalida.Value.Subtract(DtpHoraEntrada.Value)
            Dim minutosTranscurridos As Double = tiempoTranscurrido.TotalMinutes
            Dim minutosEnteros As Integer = CInt(tiempoTranscurrido.TotalMinutes)

            If DtpFechaParto.Value > Now.Date Then
                msj_advert("La fecha de parto no puede ser mayor a la fecha actual.")
                Return
            End If

            If minutosTranscurridos < 0 Then
                msj_advert("La hora de salida no puede ser menor que la hora de entrada.")
                Return
            ElseIf (idJaulaCorral = 0) Then
                msj_advert("Por favor, seleccione una jaula o corral.")
                Return
            ElseIf (TxtCondCorporal.Text.Length = 0) Then
                msj_advert("Por favor, ingrese la condición corporal de la cerda.")
                Return
            ElseIf (CDec(TxtCondCorporal.Text) <= 0) Then
                msj_advert("La condición corporal de la cerda debe ser un valor numérico positivo.")
                Return
            ElseIf idLote = 0 Then
                msj_advert("Por favor, seleccione un lote.")
                Return
            ElseIf idPartero = 0 Then
                msj_advert("Por favor, seleccione un encargado.")
                Return
            End If

            If (numCriasTotalVivo = DtDetalle.Rows.Count And DtDetalle.Rows.Count <> 0) Then
                For Each row As DataRow In DtDetalle.Rows
                    If String.IsNullOrWhiteSpace(row("peso").ToString()) OrElse (CDec(row("peso")) <= 0) Then
                        msj_advert("Por favor, ingrese un peso válido para todas las crías.")
                        Return
                    End If
                Next
            End If

            'VALIDAMOS QUE SI EL LA TABLA TIENE CHECKS EN LA COLUMNA TATUAR LA CELDA TATUAJE NO SEA VACIA EN LAS QUE TIENE CHECK
            For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                If Not IsDBNull(fila.Cells("tatuar").Value) AndAlso Convert.ToBoolean(fila.Cells("tatuar").Value) Then
                    If String.IsNullOrWhiteSpace(fila.Cells("tatuaje").Value.ToString()) Then
                        msj_advert("Por favor, ingrese un tatuaje válido.")
                        Return
                    End If
                End If
            Next

            'SI EL IDGENETICA DE LA CERDA ES = 1 ENTONCES LOS TATUAJES NO DEBEN SER IGUALES
            If (idGenetica = 1) Then
                Dim tatuajes As New List(Of String)
                For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                    If Not IsDBNull(fila.Cells("tatuar").Value) AndAlso Convert.ToBoolean(fila.Cells("tatuar").Value) Then
                        Dim tatuaje As String = fila.Cells("tatuaje").Value.ToString()
                        If tatuajes.Contains(tatuaje) Then
                            msj_advert("Los tatuajes no pueden ser iguales.")
                            Return
                        End If
                        tatuajes.Add(tatuaje)
                    End If
                Next
            End If

            If pesoPromedioCria > 3 Then
                msj_advert("El peso promedio de las crías es mayor a 3 kg, por favor verifique los datos ingresados.")
                Return
            ElseIf pesoPromedioCria < 0.4 Then
                msj_advert("El peso promedio de las crías es menor a 0.4 kg, por favor verifique los datos ingresados.")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR ESTE PARTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAnimal With {
                .Operacion = If(idControlParto = 0, 0, 1),
                .IdControlParto = idControlParto,
                .Codigo = idCerda,
                .FechaControl = DtpFechaParto.Value,
                .TotalNacidosMachos = NumVivoMacho.Value,
                .TotalNacidosHembras = NumVivoHembra.Value,
                .TotalMuertos = NumMuertos.Value,
                .TotalBallicos = ContarPorTipoCria(dtgListado, "BALLICO"),
                .TotalMomias = NumMomias.Value,
                .Observacion = TxtObservacion.Text,
                .PesoPromedioCrias = pesoPromedioCria,
                .PesoTotalCrias = CDec(TxtPesoTotal.Text),
                .Duracion = minutosEnteros,
                .IdUsuario = VP_IdUser,
                .IdResponsable = idPartero,
                .CondCorporal = CDec(TxtCondCorporal.Text),
                .ListaCrias = CreacionArrayCrias(),
                .ValorTatuaje = TxtTatuajeCrias.Text,
                .IdJaulaCorral = idJaulaCorral,
                .IdLote = idLote
            }

            Dim MensajeBgWk As String = cnAnimal.Cn_RegistrarParto(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                LimpiarCampos()
                If idControlParto = 0 Then
                    ConsultarInicializarDiccionario()
                Else
                    Dispose()
                End If
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        idCerda = 0
        LblCodArete.Text = ""
        LblGenetica.Text = ""
        LblPesoPromedio.Text = "0.0"
        idJaulaCorral = 0
        TxtJaulaCorral.Text = ""
        TxtSala.Text = ""
        idLote = 0
        TxtLote.Text = ""
        idPartero = 0
        TxtDniEncargado.Text = ""
        TxtNombreEncargado.Text = ""
        TxtCondCorporal.Text = ""
        TxtPesoTotal.Text = "0.0"
        TxtObservacion.Text = ""
        TxtTatuajeCrias.Text = ""
        TxtTatuajeCrias.Visible = False
        LblTatuajeCria.Visible = False
        BtnBloquearTatuaje.Visible = False
    End Sub

    Function CreacionArrayCrias() As String
        Dim array_valvulas As String = ""

        If (DtDetalle.Rows.Count = 0) Then
            Return ""
        End If

        For i = 0 To dtgListado.Rows.Count - 1
            If (dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                With dtgListado.Rows(i)
                    Dim tatuajeValue As String = If(.Cells("tatuar").Value.ToString.Trim.ToUpper() = "TRUE", "1", "0")
                    array_valvulas = array_valvulas & .Cells("idCria").Value.ToString.Trim & "+" &
                        .Cells("peso").Value.ToString.Trim & "+" &
                        .Cells("genero").Value.ToString.Trim & "+" &
                        tatuajeValue & "+" &
                        .Cells("tatuaje").Value.ToString.Trim & "+" &
                        .Cells("tipoCria").Value.ToString.Trim & ","
                End With
            End If
        Next

        If (dtgListado.Rows.Count = 1) Then
            array_valvulas = array_valvulas & ","
        End If

        array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)

        Return array_valvulas
    End Function

    Public Function ContarPorTipoCria(dtgListado As UltraGrid, tipoBuscar As String) As Integer
        Dim contador As Integer = 0

        If dtgListado.Rows.Count <> 0 Then
            For Each row As UltraGridRow In dtgListado.Rows
                If Not row.IsGroupByRow AndAlso row.Cells("tipoCria").Value IsNot Nothing Then
                    If row.Cells("tipoCria").Value.ToString().ToUpper() = tipoBuscar.ToUpper() Then
                        contador += 1
                    End If
                End If
            Next
        End If

        Return contador
    End Function

    Private Sub dtgListado_CellChange(sender As Object, e As CellEventArgs) Handles dtgListado.CellChange
        Dim grid As UltraGrid = DirectCast(sender, UltraGrid)

        If e.Cell.Column.Key = "tatuar" Then
            Dim currentRow As UltraGridRow = e.Cell.Row
            Dim sexoCria As String = currentRow.Cells("genero").Value.ToString().ToUpper()
            If sexoCria = "MACHO" Then
                If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR UN MACHO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    currentRow.Cells("tatuar").Value = False
                    currentRow.Cells("tatuaje").Value = "-"
                    Return
                End If
            End If

            Dim checkBoxValue As Boolean = Convert.ToBoolean(e.Cell.Value)


            If checkBoxValue Then
                currentRow.Cells("tatuaje").Value = "-"
            Else
                currentRow.Cells("tatuaje").Value = TxtTatuajeCrias.Text
            End If

            grid.UpdateData()
        End If

        If e.Cell.Column.Key = "condicion" Then
            Dim currentRow As UltraGridRow = e.Cell.Row
            Dim checkBoxValue As Boolean = Convert.ToBoolean(e.Cell.Value)

            If checkBoxValue Then
                currentRow.Cells("tipoCria").Value = "NORMAL"
            Else
                currentRow.Cells("tipoCria").Value = "BALLICO"
            End If

            grid.PerformAction(UltraGridAction.ExitEditMode)
            grid.UpdateData()
            LblTotalBallicos.Text = ContarPorTipoCria(dtgListado, "BALLICO").ToString()
        End If
    End Sub

    Private Sub BtnBuscarJaulaCorral_Click(sender As Object, e As EventArgs) Handles BtnBuscarJaulaCorral.Click
        Try
            Dim frm As New FrmListarJaulaCorralParto(Me) With {
                .idGalpon = CmbGalpon.Value,
                .tipo = If(RbnCorral.Checked, "CORRAL", "JAULA")
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TxtPesoTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPesoTotal.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtPesoTotal_TextChanged(sender As Object, e As EventArgs) Handles TxtPesoTotal.TextChanged
        CalcularPesoPromedioCria()
    End Sub

    Private Sub CalcularPesoPromedioCria()
        dtgListado.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)

        If TxtPesoTotal.Text.Length <> 0 And numCriasTotalVivo <> 0 Then
            For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                pesoPromedioCria = Math.Round(TxtPesoTotal.Text / numCriasTotalVivo, 2)
                fila.Cells("peso").Value = pesoPromedioCria
                LblPesoPromedio.Text = pesoPromedioCria
            Next
        End If

        If TxtPesoTotal.Text.Length = 0 Then
            LblPesoPromedio.Text = "0.0"

            For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                fila.Cells("peso").Value = "0"
            Next
        End If
    End Sub

    Public Sub LlenarLoteParto(codigo As Integer, descripcion As String)
        idLote = codigo
        TxtLote.Text = descripcion
    End Sub

    Private Sub BtnAsignarTatuaje_Click(sender As Object, e As EventArgs)
        Try
            If String.IsNullOrWhiteSpace(TxtTatuajeCrias.Text) Then
                msj_advert("Por favor, ingrese un tatuaje válido.")
                Return
            End If

            For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                If Not IsDBNull(fila.Cells("tatuar").Value) AndAlso Convert.ToBoolean(fila.Cells("tatuar").Value) Then
                    fila.Cells("tatuaje").Value = TxtTatuajeCrias.Text
                End If
            Next
            dtgListado.UpdateData()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposPartero(codigo As Integer, numDocumento As String, datos As String)
        idPartero = codigo
        TxtDniEncargado.Text = numDocumento
        TxtNombreEncargado.Text = datos
    End Sub

    Private Sub BtnEncargado_Click(sender As Object, e As EventArgs) Handles BtnEncargado.Click
        Try
            Dim frm As New FrmListarPartero(Me)
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TxtTatuajeCrias_TextChanged(sender As Object, e As EventArgs) Handles TxtTatuajeCrias.TextChanged
        Try
            If idCerda <> 0 Then
                If String.IsNullOrWhiteSpace(TxtTatuajeCrias.Text) Then
                    msj_advert("Por favor, ingrese un tatuaje válido.")
                    Return
                End If

                For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                    If Not IsDBNull(fila.Cells("tatuar").Value) AndAlso Convert.ToBoolean(fila.Cells("tatuar").Value) Then
                        fila.Cells("tatuaje").Value = TxtTatuajeCrias.Text
                    End If
                Next
                dtgListado.UpdateData()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnAsignarLote_Click(sender As Object, e As EventArgs) Handles BtnAsignarLote.Click
        Try
            Dim frm As New FrmListarLotesParto(Me) With {
                .idUbicacion = idUbicacion
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBloquearFecha_Click(sender As Object, e As EventArgs) Handles BtnBloquearFecha.Click
        If CInt(VariablesGlobales.ParametrosParto("fPartoBloqueo")) = 1 Then
            DtpFechaParto.Enabled = True
            VariablesGlobales.ParametrosParto("fParto") = Now.Date
            VariablesGlobales.ParametrosParto("fPartoBloqueo") = 0
        Else
            DtpFechaParto.Enabled = False
            VariablesGlobales.ParametrosParto("fParto") = DtpFechaParto.Value
            VariablesGlobales.ParametrosParto("fPartoBloqueo") = 1
        End If
    End Sub

    Private Sub BtnBloquearCondCorporal_Click(sender As Object, e As EventArgs) Handles BtnBloquearCondCorporal.Click
        If CInt(VariablesGlobales.ParametrosParto("condCorporalBloqueo")) = 1 Then
            TxtCondCorporal.Enabled = True
            VariablesGlobales.ParametrosParto("condCorporal") = 0
            VariablesGlobales.ParametrosParto("condCorporalBloqueo") = 0
        Else
            TxtCondCorporal.Enabled = False
            VariablesGlobales.ParametrosParto("condCorporal") = CDec(TxtCondCorporal.Text)
            VariablesGlobales.ParametrosParto("condCorporalBloqueo") = 1
        End If
    End Sub

    Private Sub BtnBloquearLote_Click(sender As Object, e As EventArgs) Handles BtnBloquearLote.Click
        If CInt(VariablesGlobales.ParametrosParto("loteBloqueo")) = 1 Then
            BtnAsignarLote.Enabled = True
            VariablesGlobales.ParametrosParto("loteBloqueo") = 0
        Else
            BtnAsignarLote.Enabled = False
            VariablesGlobales.ParametrosParto("loteBloqueo") = 1
        End If
        VariablesGlobales.ParametrosParto("idLote") = idLote
        VariablesGlobales.ParametrosParto("valorLote") = TxtLote.Text
    End Sub

    Private Sub BtnBloquearPartero_Click(sender As Object, e As EventArgs) Handles BtnBloquearPartero.Click
        If CInt(VariablesGlobales.ParametrosParto("parteroBloqueo")) = 1 Then
            BtnEncargado.Enabled = True
            VariablesGlobales.ParametrosParto("parteroBloqueo") = 0
        Else
            BtnEncargado.Enabled = False
            VariablesGlobales.ParametrosParto("parteroBloqueo") = 1
        End If
        VariablesGlobales.ParametrosParto("idPartero") = idPartero
        VariablesGlobales.ParametrosParto("valorDni") = TxtDniEncargado.Text
        VariablesGlobales.ParametrosParto("valorNombre") = TxtNombreEncargado.Text
    End Sub

    Private Sub BtnBloquearHrInicio_Click(sender As Object, e As EventArgs) Handles BtnBloquearHrInicio.Click
        If CInt(VariablesGlobales.ParametrosParto("horaInicioBloqueo")) = 1 Then
            DtpHoraEntrada.Enabled = True
            VariablesGlobales.ParametrosParto("horaInicioBloqueo") = 0
        Else
            DtpHoraEntrada.Enabled = False
            VariablesGlobales.ParametrosParto("horaInicioBloqueo") = 1
        End If
        VariablesGlobales.ParametrosParto("horaInicio") = DtpHoraEntrada.Value
    End Sub

    Private Sub BtnBloquearHrFin_Click(sender As Object, e As EventArgs) Handles BtnBloquearHrFin.Click
        If CInt(VariablesGlobales.ParametrosParto("horaFinBloqueo")) = 1 Then
            DtpHoraSalida.Enabled = True
            VariablesGlobales.ParametrosParto("horaFinBloqueo") = 0
        Else
            DtpHoraSalida.Enabled = False
            VariablesGlobales.ParametrosParto("horaFinBloqueo") = 1
        End If
        VariablesGlobales.ParametrosParto("horaFin") = DtpHoraSalida.Value
    End Sub

    Private Sub BtnBloquearTatuaje_Click(sender As Object, e As EventArgs) Handles BtnBloquearTatuaje.Click
        If CInt(VariablesGlobales.ParametrosParto("tatuajeBloqueo")) = 1 Then
            TxtTatuajeCrias.Enabled = True
            VariablesGlobales.ParametrosParto("tatuajeBloqueo") = 0
        Else
            TxtTatuajeCrias.Enabled = False
            VariablesGlobales.ParametrosParto("tatuajeBloqueo") = 1
        End If
        VariablesGlobales.ParametrosParto("tatuaje") = TxtTatuajeCrias.Text
    End Sub

    Private Sub BtnBloquearGalpon_Click(sender As Object, e As EventArgs) Handles BtnBloquearGalpon.Click
        If VariablesGlobales.ParametrosParto("galponBloqueo") = 1 Then
            CmbGalpon.Enabled = True
            VariablesGlobales.ParametrosParto("galponBloqueo") = 0
        Else
            CmbGalpon.Enabled = False
            VariablesGlobales.ParametrosParto("galponBloqueo") = 1
        End If
        VariablesGlobales.ParametrosParto("idGalpon") = CmbGalpon.Value
    End Sub

    Private Sub CmbGalpon_TextChanged(sender As Object, e As EventArgs) Handles CmbGalpon.TextChanged
        idJaulaCorral = 0
        TxtJaulaCorral.Text = ""
        TxtSala.Text = ""
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class