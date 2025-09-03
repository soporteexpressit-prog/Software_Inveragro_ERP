Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmMortalidadTransporteRetorno
    Dim cnLote As New cnControlLoteDestete
    Public idLote As Integer
    Public idPlantel As Integer
    Public valorPlantelSalida As String
    Public codigo As Integer = 0

    Private Sub FrmMortalidadTransporteRetorno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarDetalleCorralesLote()
        dtpFechaConfirmacion.Value = Now.Date
    End Sub

    Private Sub ListarDetalleCorralesLote()
        Try
            Dim obj As New coControlLoteDestete With {
                .IdLote = idLote,
                .IdMovimientoBajada = codigo,
                .IdPlantel = idPlantel,
                .TipoFiltro = "RETORNO"
            }

            Dim resultado As Object = cnLote.Cn_ConsultarAnimalesLoteTransitoBajadaRetorno(obj)

            If TypeOf resultado Is String Then
                msj_advert(resultado.ToString())
                Dispose()
            Else
                Dim ds As DataSet = CType(resultado, DataSet)

                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                    DtgListadoCerdasPuras.DataSource = ds.Tables(0)
                    DtgListadoCerdasPuras.DisplayLayout.Bands(0).Columns(0).Hidden = True
                    clsBasicas.Filtrar_Tabla(DtgListadoCerdasPuras, True)
                    clsBasicas.Formato_Tablas_Grid(DtgListadoCerdasPuras)

                    If ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 0 Then
                        TxtPuras.Text = CInt(ds.Tables(1).Rows(0)("CantPura"))
                        TxtCambo.Text = CInt(ds.Tables(1).Rows(0)("CantCambo"))
                        TxtCelador.Text = CInt(ds.Tables(1).Rows(0)("CantCelador"))
                        TxtMaMeishan.Text = CInt(ds.Tables(1).Rows(0)("CantMeishan"))
                        LblLotesAsociados.Text = ds.Tables(1).Rows(0)("LotesAsociados").ToString()
                    End If

                    If ds.Tables.Count > 2 AndAlso ds.Tables(2).Rows.Count > 0 Then
                        clsBasicas.Formato_Tablas_Grid_TresUltimasColumnaEditable(DtgListadoLotes)
                        DtgListadoLotes.DataSource = ds.Tables(2)
                        DtgListadoLotes.DisplayLayout.Bands(0).Columns(0).Hidden = True
                        FormatoColumnas()
                        ConfigurarUltraGrid()
                    End If
                End If
                Inicializar()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        TxtPuras.ReadOnly = True
        TxtCambo.ReadOnly = True
        TxtCelador.ReadOnly = True
        TxtMaMeishan.ReadOnly = True
        LblPlantelSalida.Text = valorPlantelSalida
    End Sub

    Sub FormatoColumnas()
        Try
            If DtgListadoLotes.Rows.Count > 0 Then
                Dim colorCantidadRecibida As Color = Color.LightGray

                For Each fila As UltraGridRow In DtgListadoLotes.Rows
                    If fila.Cells.Exists("N° Camborough") Or fila.Cells.Exists("N° Celador") Then
                        fila.Cells("N° Camborough").Appearance.BackColor = colorCantidadRecibida
                        fila.Cells("N° Camborough").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        fila.Cells("N° Celador").Appearance.BackColor = colorCantidadRecibida
                        fila.Cells("N° Celador").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        fila.Cells("N° Madre Meishan").Appearance.BackColor = colorCantidadRecibida
                        fila.Cells("N° Madre Meishan").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                    End If
                Next
                DtgListadoLotes.Refresh()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ConfigurarUltraGrid()
        With DtgListadoLotes.DisplayLayout.Bands(0)
            .Groups.Clear()
            .RowLayoutStyle = RowLayoutStyle.GroupLayout

            Dim group1 As UltraGridGroup = .Groups.Add("Enviados", "Enviados")
            Dim group2 As UltraGridGroup = .Groups.Add("Mortalidad", "Mortalidad")

            .Columns(0).RowLayoutColumnInfo.ParentGroup = group1
            .Columns(1).RowLayoutColumnInfo.ParentGroup = group1
            .Columns(2).RowLayoutColumnInfo.ParentGroup = group1
            .Columns(3).RowLayoutColumnInfo.ParentGroup = group1
            .Columns(4).RowLayoutColumnInfo.ParentGroup = group1
            .Columns(5).RowLayoutColumnInfo.ParentGroup = group2
            .Columns(6).RowLayoutColumnInfo.ParentGroup = group2
            .Columns(7).RowLayoutColumnInfo.ParentGroup = group2
        End With

        DtgListadoLotes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        clsBasicas.Filtrar_Tabla(DtgListadoLotes, False)
    End Sub

    Private Sub BtnConfirmarBajada_Click(sender As Object, e As EventArgs) Handles BtnConfirmarBajada.Click
        Try
            DtgListadoLotes.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
            Dim numPuras As Integer = 0
            Dim numCambor As Integer = 0
            Dim numCelador As Integer = 0
            Dim numMeishan As Integer = 0
            Dim totalMuertos As Integer = 0

            If dtpFechaConfirmacion.Value > Now.Date Then
                msj_advert("La fecha de confirmación no puede ser mayor a la fecha actual")
                Return
            End If

            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoCerdasPuras.Rows
                If row.Appearance.BackColor = Color.LightBlue Then
                    numPuras += 1
                End If
            Next

            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoLotes.Rows
                Dim lote As String = row.Cells("Lote").Text

                Dim mortalidadCambor As Integer = If(IsNumeric(row.Cells("N° Camborough").Value), CInt(row.Cells("N° Camborough").Value), 0)
                Dim totalCambor As Integer = If(IsNumeric(row.Cells("Camborough").Value), CInt(row.Cells("Camborough").Value), 0)

                Dim mortalidadCelador As Integer = If(IsNumeric(row.Cells("N° Celador").Value), CInt(row.Cells("N° Celador").Value), 0)
                Dim totalCelador As Integer = If(IsNumeric(row.Cells("Celador").Value), CInt(row.Cells("Celador").Value), 0)

                Dim mortalidadMeishan As Integer = If(IsNumeric(row.Cells("N° Madre Meishan").Value), CInt(row.Cells("N° Madre Meishan").Value), 0)
                Dim totalMeishan As Integer = If(IsNumeric(row.Cells("Madre Meishan").Value), CInt(row.Cells("Madre Meishan").Value), 0)

                If mortalidadCambor > totalCambor Then
                    msj_advert($"En el {lote}, la cantidad de 'Camborough' ({mortalidadCambor}) excede el total disponible ({totalCambor}).")
                    Return
                End If

                If mortalidadCelador > totalCelador Then
                    msj_advert($"En el {lote}, la cantidad de 'Celadores' ({mortalidadCelador}) excede el total disponible ({totalCelador}).")
                    Return
                End If

                If mortalidadMeishan > totalMeishan Then
                    msj_advert($"En el {lote}, la cantidad de 'Madre Meishan' ({mortalidadMeishan}) excede el total disponible ({totalMeishan}).")
                    Return
                End If
            Next

            numCambor = ObtenerMortalidadCamborCelador("N° Camborough")
            numCelador = ObtenerMortalidadCamborCelador("N° Celador")
            numMeishan = ObtenerMortalidadCamborCelador("N° Madre Meishan")

            totalMuertos = numPuras + numCambor + numCelador + numMeishan

            If (MessageBox.Show("¿ESTÁ SEGURO DE CONFIRMAR LLEGANDA CHANCHILLAS CON " & totalMuertos & " ANIMALES MUERTOS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .ListaIdsCerdosRegistrados = ObtenerPurasMortalidadString(),
                .ListaIdsLotes = CreacionArrayLoteCamborMortalidad(),
                .IdPlantel = idPlantel,
                .IdUsuario = VP_IdUser,
                .IdMovimientoBajada = codigo,
                .FechaControl = dtpFechaConfirmacion.Value
            }

            Dim mensaje As String = cnLote.Cn_RegistrarConfirmacionRetorno(obj)
            If (obj.Coderror = 0) Then
                msj_ok(mensaje)
                Close()
            Else
                msj_advert(mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function ObtenerPurasMortalidadString() As String
        Dim valores As New List(Of String)

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoCerdasPuras.Rows
            If row.Appearance.BackColor = Color.LightBlue Then
                If Not IsDBNull(row.Cells(0).Value) AndAlso Not String.IsNullOrEmpty(row.Cells(0).Text.Trim()) Then
                    valores.Add(row.Cells(0).Value.ToString())
                End If
            End If
        Next

        Return String.Join(",", valores)
    End Function

    Private Function ObtenerMortalidadCamborCelador(nombreColumna As String) As Integer
        Dim numMortalidad As Integer = 0

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoLotes.Rows
            If Not IsDBNull(row.Cells(nombreColumna).Value) Then
                If row.Cells(nombreColumna).Value.ToString.Trim.Length <> 0 Then
                    numMortalidad += CInt(row.Cells(nombreColumna).Value)
                End If
            End If
        Next

        Return numMortalidad
    End Function

    Function CreacionArrayLoteCamborMortalidad() As String
        Dim array_valvulas As String = ""
        If (DtgListadoLotes.Rows.Count = 0) Then
            array_valvulas = ""
        Else
            For i = 0 To DtgListadoLotes.Rows.Count - 1
                If (DtgListadoLotes.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With DtgListadoLotes.Rows(i)
                        array_valvulas = array_valvulas & .Cells("N° Camborough").Value.ToString.Trim & "+" &
                            .Cells("N° Celador").Value.ToString.Trim & "+" &
                            .Cells("N° Madre Meishan").Value.ToString.Trim & "+" &
                            .Cells("idLote").Value.ToString.Trim & ","
                    End With
                End If
            Next
            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub DtgListadoCerdasPuras_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles DtgListadoCerdasPuras.DoubleClickCell
        Dim row As Infragistics.Win.UltraWinGrid.UltraGridRow = e.Cell.Row
        Dim tieneValor As Boolean = False

        For Each cell As Infragistics.Win.UltraWinGrid.UltraGridCell In row.Cells
            If Not IsDBNull(cell.Value) AndAlso Not String.IsNullOrEmpty(cell.Text.Trim()) Then
                tieneValor = True
                Exit For
            End If
        Next

        If Not tieneValor Then Return

        If row.Appearance.BackColor = Color.LightBlue Then
            row.Appearance.BackColor = Color.White
        Else
            row.Appearance.BackColor = Color.LightBlue
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class