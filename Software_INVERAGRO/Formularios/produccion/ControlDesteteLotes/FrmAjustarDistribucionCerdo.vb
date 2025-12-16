Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmAjustarDistribucionCerdo
    Dim cnLote As New cnControlLoteDestete
    Dim idJaulaCorral As Integer = 0
    Dim totalTatuadas As Integer = 0
    Dim totalEngorde As Integer = 0
    Private numAnimalesCorral As Integer = 0
    Public idLote As Integer = 0
    Public valorPlantel As String = ""
    Public valorLote As String = ""
    Public idPlantel As Integer = 0
    Public DtDetalle As New DataTable("TempDetCerdas")
    Public SelectedAnimales As New HashSet(Of Integer)

    Private Sub FrmAjustarUbicacionLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarDetalleCorralesLote()
        Me.Size = New Size(1180, 680)
    End Sub

    Private Sub ListarDetalleCorralesLote()
        Try
            Dim obj As New coControlLoteDestete With {
                .IdLote = idLote,
                .IdPlantel = idPlantel
            }

            Dim ds As DataSet = cnLote.Cn_ConsultarCorralesPorLote(obj)

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                DtgListadoCorrales.DataSource = ds.Tables(0)
                clsBasicas.Formato_Tablas_Grid(DtgListadoCorrales)
                DtgListadoCorrales.DisplayLayout.Bands(0).Columns("idJaulaCorral").Hidden = True
                DtgListadoCorrales.DisplayLayout.Bands(0).Columns("engordeAjus").Hidden = True
                DtgListadoCorrales.DisplayLayout.Bands(0).Columns("camboAjus").Hidden = True
                DtgListadoCorrales.DisplayLayout.Bands(0).Columns("purasAjus").Hidden = True
                numAnimalesCorral = CInt(ds.Tables(0).Rows(0)("Total Animales"))
                Colorear()

                If ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 0 Then
                    TxtPuras.Text = CInt(ds.Tables(1).Rows(0)("CantPura"))
                    TextTatuadas.Text = CInt(ds.Tables(1).Rows(0)("CantTatuaje"))
                    TxtEngorde.Text = CInt(ds.Tables(1).Rows(0)("CantEngorde"))
                End If

                If (ds.Tables(0).Rows.Count > 0) Then
                    idJaulaCorral = DtgListadoCorrales.Rows(0).Cells(0).Value

                    If (idJaulaCorral <> 0) Then
                        ListarAnimalesJaulaCorral()
                    End If
                End If
            End If
            Inicializar()
        Catch ex As Exception
            msj_advert("debe ubicar a los animales en corrales")
            Dispose()
        End Try
    End Sub

    Private Sub Inicializar()
        LblLote.Text = valorLote
        LblPlantel.Text = valorPlantel
        BtnAgregarCerdas.Enabled = False
        NumCerdasTatuadas.Enabled = False
        NumCerdasEngorde.Enabled = False
        OpcionesGuardar.Enabled = False
        TxtPuras.ReadOnly = True
        TextTatuadas.ReadOnly = True
        TxtEngorde.ReadOnly = True
        LblTotalPorAjustarPuras.Text = CInt(TxtPuras.Text) - SumarCantPurasAjustadas()
        LblTotalPorAjustarCambo.Text = CInt(TextTatuadas.Text) - SumarCantCamboroughAjustadas()
        LblTotalPorAjustarEngorde.Text = CInt(TxtEngorde.Text) - SumarCantEngordeAjustadas()
    End Sub

    Sub Colorear()
        If (DtgListadoCorrales.Rows.Count > 0) Then
            Dim estado As Integer = 6

            'estado
            clsBasicas.Colorear_SegunValor(DtgListadoCorrales, Color.Green, Color.White, "SI", estado)
            clsBasicas.Colorear_SegunValor(DtgListadoCorrales, Color.LightGray, Color.Black, "NO", estado)

            'centrar columnas
            With DtgListadoCorrales.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub InicializarDtDetalle()
        DtDetalle = New DataTable("TempDetCerdas")
        DtDetalle.Columns.Add("idAnimal", GetType(Integer))
        DtDetalle.Columns.Add("Tatuaje", GetType(String))
        DtDetalle.Columns.Add("Edad", GetType(Integer))
        DtDetalle.Columns.Add("Sexo", GetType(String))
        DtDetalle.Columns.Add("Eliminar", GetType(String))
        DtgListadoCerdos.DataSource = DtDetalle
    End Sub

    Private Sub ListarAnimalesJaulaCorral()
        Try
            Dim obj As New coControlLoteDestete With {
                .IdJaulaCorral = idJaulaCorral,
                .IdLote = idLote
            }

            Dim ds As DataSet = cnLote.Cn_ConsultarAnimalesxIdJaulaCorralAjustar(obj)

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                InicializarDtDetalle()

                For Each row As DataRow In ds.Tables(0).Rows
                    DtDetalle.Rows.Add(
                    row("idAnimal"),
                    row("Tatuaje"),
                    row("Edad"),
                    row("Sexo"),
                    "Eliminar"
                )
                Next

                RealizarIdentificacionIdAnimal()

                If ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 0 Then
                    totalTatuadas = CInt(ds.Tables(1).Rows(0)("CantTatuaje"))
                    totalEngorde = CInt(ds.Tables(1).Rows(0)("CantEngorde"))
                End If

                NumCerdasTatuadas.Value = totalTatuadas
                NumCerdasEngorde.Value = totalEngorde
                CalcularTotalCriasCorral()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BloquearOpciones(ajustado As String)
        If (ajustado = "SI") Then
            BtnAgregarCerdas.Enabled = False
            NumCerdasTatuadas.Enabled = False
            NumCerdasEngorde.Enabled = False
            OpcionesGuardar.Enabled = False
        Else
            BtnAgregarCerdas.Enabled = True
            NumCerdasTatuadas.Enabled = True
            NumCerdasEngorde.Enabled = True
            OpcionesGuardar.Enabled = True
        End If
    End Sub

    Private Sub ConsultarAnimalesJaulaCorral()
        Try
            Dim activeRow As UltraGridRow = DtgListadoCorrales.ActiveRow
            If (DtgListadoCorrales.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim ajustado As String = activeRow.Cells("Ajustado").Value
                    BloquearOpciones(ajustado)

                    idJaulaCorral = activeRow.Cells(0).Value
                    Dim obj As New coControlLoteDestete With {
                        .IdJaulaCorral = idJaulaCorral,
                        .IdLote = idLote
                    }

                    Dim ds As DataSet = cnLote.Cn_ConsultarAnimalesxIdJaulaCorralAjustar(obj)

                    If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                        InicializarDtDetalle()

                        For Each row As DataRow In ds.Tables(0).Rows
                            DtDetalle.Rows.Add(
                            row("idAnimal"),
                            row("Tatuaje"),
                            row("Edad"),
                            row("Sexo"),
                            "Eliminar"
                        )
                        Next

                        RealizarIdentificacionIdAnimal()

                        If ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 0 Then
                            totalTatuadas = CInt(ds.Tables(1).Rows(0)("CantTatuaje"))
                            totalEngorde = CInt(ds.Tables(1).Rows(0)("CantEngorde"))
                        End If

                        NumCerdasTatuadas.Value = totalTatuadas
                        NumCerdasEngorde.Value = totalEngorde
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

    Private Sub RealizarIdentificacionIdAnimal()
        DtgListadoCerdos.DataSource = DtDetalle
        clsBasicas.Filtrar_Tabla(DtgListadoCerdos, True)
        clsBasicas.Formato_Tablas_Grid(DtgListadoCerdos)
        DtgListadoCerdos.DisplayLayout.Bands(0).Columns("idAnimal").Hidden = True

        SelectedAnimales.Clear()
        For Each row As DataRow In DtDetalle.Rows
            Dim idAnimal As Integer = CInt(row("idAnimal"))
            If Not SelectedAnimales.Contains(idAnimal) Then
                SelectedAnimales.Add(idAnimal)
            End If
        Next
    End Sub

    Private Sub DtgListadoCorrales_ClickCell(sender As Object, e As ClickCellEventArgs) Handles DtgListadoCorrales.ClickCell
        SelectedAnimales.Clear()
        InicializarDtDetalle()
        If DtgListadoCorrales.ActiveRow IsNot Nothing Then
            numAnimalesCorral = CInt(DtgListadoCorrales.ActiveRow.Cells("Total Animales").Value)
        End If
        ConsultarAnimalesJaulaCorral()
        CalcularTotalCriasCorral()
    End Sub

    Private Sub DtgListadoCerdos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles DtgListadoCerdos.InitializeRow
        Dim column As Infragistics.Win.UltraWinGrid.UltraGridColumn = DtgListadoCerdos.DisplayLayout.Bands(0).Columns("Eliminar")
        column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        If Not e.ReInitialize Then
            e.Row.Cells("Eliminar").Value = "Eliminar"
            e.Row.Cells("Eliminar").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        End If
    End Sub

    Private Sub BtnAgregarCerdas_Click(sender As Object, e As EventArgs) Handles BtnAgregarCerdas.Click
        Try
            Dim frm As New FrmListaCerdosRegistradosxCorral(Me) With {
                .idLote = idLote
            }
            frm.ShowDialog()

            DtgListadoCerdos.DataSource = Nothing
            DtgListadoCerdos.DataSource = DtDetalle
            DtgListadoCerdos.Refresh()
            CalcularTotalCriasCorral()
            DtgListadoCerdos.DisplayLayout.Bands(0).Columns("idAnimal").Hidden = True

            SelectedAnimales.Clear()
            For Each row As DataRow In DtDetalle.Rows
                Dim idAnimal As Integer = CInt(row("idAnimal"))
                If Not SelectedAnimales.Contains(idAnimal) Then
                    SelectedAnimales.Add(idAnimal)
                End If
            Next
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CalcularTotalCriasCorral()
        Dim totalCerdos As Integer = DtgListadoCerdos.Rows.Count
        Dim resultado As Integer = numAnimalesCorral - (NumCerdasTatuadas.Value + totalCerdos)

        If resultado < 0 Then
            msj_advert("Se esta excediendo el total de animales de este corral.")
            resultado = 0
        End If

        NumCerdasEngorde.Value = resultado
        LblTotalPurasCorral.Text = totalCerdos
        LblTotalCerdosCorral.Text = totalCerdos + NumCerdasTatuadas.Value + NumCerdasEngorde.Value
    End Sub


    Private Sub DtgListadoCerdos_ClickCellButton(sender As Object, e As CellEventArgs) Handles DtgListadoCerdos.ClickCellButton
        Try
            With DtgListadoCerdos
                If (e.Cell.Column.Key = "Eliminar") Then
                    Dim ajustado As String = DtgListadoCorrales.ActiveRow.Cells("Ajustado").Value

                    If (ajustado = "SI") Then
                        msj_advert("El corral ya está ajustado, no se puede eliminar cerdos.")
                        Return
                    End If

                    If (MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE CERDO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    Dim dt As DataTable = CType(.DataSource, DataTable)
                    If dt IsNot Nothing AndAlso e.Cell.Row IsNot Nothing Then
                        Dim idAnimal As Integer = Convert.ToInt32(e.Cell.Row.Cells("idAnimal").Value)

                        Dim rowToDelete = dt.AsEnumerable().FirstOrDefault(Function(r) Convert.ToInt32(r("idAnimal")) = idAnimal)
                        If rowToDelete IsNot Nothing Then
                            dt.Rows.Remove(rowToDelete)
                            dt.AcceptChanges()
                            SelectedAnimales.Remove(idAnimal)

                            DtgListadoCerdos.DataSource = Nothing
                            DtgListadoCerdos.DataSource = dt
                            DtgListadoCerdos.Refresh()

                            CalcularTotalCriasCorral()
                            DtgListadoCerdos.DisplayLayout.Bands(0).Columns("idAnimal").Hidden = True
                        End If
                    End If
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposCerda(idAnimal As Integer, codArete As String, diasVida As Integer, sexo As String)
        Try
            Dim dt As DataTable = CType(DtgListadoCerdos.DataSource, DataTable)

            If dt IsNot Nothing AndAlso dt.Rows.Cast(Of DataRow).Any(Function(r) Convert.ToInt32(r(0)) = idAnimal) Then
                msj_advert("El cerdo ya se encuentra en la lista.")
                Return
            End If

            Dim row As DataRow = dt.NewRow()
            row(0) = idAnimal
            row(1) = codArete
            row(2) = diasVida
            row(3) = sexo

            dt.Rows.Add(row)
            DtgListadoCerdos.DataBind()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgListadoCorrales_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles DtgListadoCorrales.InitializeRow
        Dim column As Infragistics.Win.UltraWinGrid.UltraGridColumn = DtgListadoCorrales.DisplayLayout.Bands(0).Columns("Corregir")
        column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        If Not e.ReInitialize Then
            e.Row.Cells("Corregir").Value = "Corregir"
            e.Row.Cells("Corregir").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        End If
    End Sub

    Private Sub DtgListadoCorrales_ClickCellButton(sender As Object, e As CellEventArgs) Handles DtgListadoCorrales.ClickCellButton
        Try
            With DtgListadoCorrales
                If (e.Cell.Column.Key = "Corregir") Then
                    Dim ajustado As String = e.Cell.Row.Cells("Ajustado").Value

                    idJaulaCorral = e.Cell.Row.Cells("idJaulaCorral").Value
                    ListarAnimalesJaulaCorral()
                    BloquearOpciones(ajustado)

                    If (ajustado = "SI") Then
                        If (MessageBox.Show("¿EL CORRAL YA ESTA AJUSTADO QUIERE CONTINUAR?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                            Return
                        End If
                    Else
                        msj_advert("El corral esta libre para ser corregido.")
                        Return
                    End If

                    Dim obj As New coControlLoteDestete With {
                        .IdLote = idLote,
                        .IdJaulaCorral = idJaulaCorral
                    }

                    Dim MensajeBgWk As String = cnLote.Cn_AjustarAnimalesxJaulaCorral(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(MensajeBgWk)
                        ListarDetalleCorralesLote()
                    Else
                        msj_advert(MensajeBgWk)
                    End If
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            Dim numCerdasRegistradas As Integer = DtgListadoCerdos.Rows.Count
            Dim numTotalAnimales As Integer = NumCerdasTatuadas.Value + NumCerdasEngorde.Value + numCerdasRegistradas
            Dim activeRow As UltraGridRow = DtgListadoCorrales.ActiveRow
            Dim capacidadCorral As Integer = activeRow.Cells("Total Animales").Value
            Dim numCorralesAjustados As Integer = 0
            Dim numCerdasPuras = DtgListadoCerdos.Rows.Count

            If (numCerdasPuras > CInt(LblTotalPorAjustarPuras.Text)) Then
                msj_advert("La cantidad de puras no puede ser mayor a la cantidad de puras por ajustar.")
                Return
            End If

            If (NumCerdasTatuadas.Value > CInt(LblTotalPorAjustarCambo.Text)) Then
                msj_advert("La cantidad de Camborough no puede ser mayor a la cantidad de Camborough por ajustar.")
                Return
            End If

            If (NumCerdasEngorde.Value > CInt(LblTotalPorAjustarEngorde.Text)) Then
                msj_advert("La cantidad de engorde no puede ser mayor a la cantidad de engorde por ajustar.")
                Return
            End If

            For i As Integer = 0 To DtgListadoCorrales.Rows.Count - 1
                If DtgListadoCorrales.Rows(i).Cells("Ajustado").Value.ToString.Trim = "NO" Then
                    numCorralesAjustados += 1
                End If
            Next

            If (numTotalAnimales <> capacidadCorral) Then
                msj_advert("La cantidad de cerdos debe ser igual a la capacidad definida del corral.")
                Return
            End If

            If numCorralesAjustados < 2 Then
                msj_advert("Para ajustar la distribución de cerdos debe tener al menos 2 corrales con ajuste = NO.")
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .ListaIdsCorralCantidad = CrearStringJaulaCapacidad(idJaulaCorral),
                .ListaIdsCerdosRegistrados = ObtenerIdsAnimalesHabitados(),
                .IdLote = idLote,
                .IdJaulaCorral = idJaulaCorral,
                .CantidadTatuadas = NumCerdasTatuadas.Value,
                .CantidadVenta = NumCerdasEngorde.Value
            }

            If (MessageBox.Show("¿ESTÁ SEGURO DE AJUSTAR UBICACIÓN DE CERDOS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim MensajeBgWk As String = cnLote.Cn_AjustarCerdosCorral(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                ListarDetalleCorralesLote()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function CrearStringJaulaCapacidad(ByVal idJaulaCorralSeleccionado As Integer) As String
        Dim resultado As String = ""

        If DtgListadoCorrales.Rows.Count = 0 Then
            Return "0"
        End If

        For i As Integer = 0 To DtgListadoCorrales.Rows.Count - 1
            Dim idJaulaCorral As String = DtgListadoCorrales.Rows(i).Cells("idJaulaCorral").Value.ToString.Trim
            Dim capacidad As String = DtgListadoCorrales.Rows(i).Cells("Total Animales").Value.ToString.Trim

            If DtgListadoCorrales.Rows(i).Cells("Ajustado").Value.ToString.Trim = "NO" AndAlso idJaulaCorral <> idJaulaCorralSeleccionado Then
                resultado &= idJaulaCorral & "+" & capacidad & ","
            End If
        Next

        If resultado.Length > 0 Then
            resultado = resultado.Substring(0, resultado.Length - 1)
        End If

        Return resultado
    End Function


    Function ObtenerIdsAnimalesHabitados() As String
        Dim idsAnimales As String = ""

        If DtgListadoCerdos.Rows.Count = 0 Then
            Return "0"
        End If

        For i As Integer = 0 To DtgListadoCerdos.Rows.Count - 1
            Dim idAnimal As String = DtgListadoCerdos.Rows(i).Cells(0).Value.ToString.Trim

            If idAnimal.Length > 0 Then
                idsAnimales &= idAnimal & ","
            End If
        Next

        If idsAnimales.Length > 0 Then
            idsAnimales = idsAnimales.Substring(0, idsAnimales.Length - 1)
        End If

        Return idsAnimales
    End Function

    Private Function SumarCantPurasAjustadas() As Integer
        Dim total As Integer = 0

        For i As Integer = 0 To DtgListadoCorrales.Rows.Count - 1
            If DtgListadoCorrales.Rows(i).Cells("Ajustado").Value.ToString.Trim = "SI" Then
                total += CInt(DtgListadoCorrales.Rows(i).Cells("purasAjus").Value)
            End If
        Next

        Return total
    End Function

    Private Function SumarCantCamboroughAjustadas() As Integer
        Dim total As Integer = 0

        For i As Integer = 0 To DtgListadoCorrales.Rows.Count - 1
            If DtgListadoCorrales.Rows(i).Cells("Ajustado").Value.ToString.Trim = "SI" Then
                total += CInt(DtgListadoCorrales.Rows(i).Cells("camboAjus").Value)
            End If
        Next

        Return total
    End Function

    Private Function SumarCantEngordeAjustadas() As Integer
        Dim total As Integer = 0

        For i As Integer = 0 To DtgListadoCorrales.Rows.Count - 1
            If DtgListadoCorrales.Rows(i).Cells("Ajustado").Value.ToString.Trim = "SI" Then
                total += CInt(DtgListadoCorrales.Rows(i).Cells("engordeAjus").Value)
            End If
        Next

        Return total
    End Function

    Private Sub NumCerdasTatuadas_ValueChanged(sender As Object, e As EventArgs) Handles NumCerdasTatuadas.ValueChanged
        CalcularTotalCriasCorral()
    End Sub

    Private Sub DtgListadoCorrales_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles DtgListadoCorrales.InitializeLayout
        Try
            If (DtgListadoCorrales.Rows.Count = 0) Then
            Else
                clsBasicas.Totales_Formato(DtgListadoCorrales, e, 1)
                clsBasicas.SumarTotales_Formato(DtgListadoCorrales, e, 5)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class