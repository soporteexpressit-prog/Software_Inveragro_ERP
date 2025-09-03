Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmRetornarChanchillasPuras
    Dim cn As New cnControlLoteDestete
    Dim idConductor As Integer = 0
    Dim idTransporte As Integer = 0
    Dim numAnimales As Integer = 0
    Dim numPuras As Integer = 0
    Dim numCamborough As Integer = 0
    Dim numCelador As Integer = 0
    Dim numMeishan As Integer = 0
    Public listaIdsLotes As String = 0
    Public edadLote As Integer = 0
    Public idPlantelSalida As Integer = 0

    Private Sub FrmRetornarChanchillasPuras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlantelesLlegada()
            ConsultarPurasChanchillasRetorno()
            clsBasicas.ListarAlmacenesAsignados(cbxalmacendestino)
            cbxalmacendestino.SelectedValue = idPlantelSalida
            cbxalmacendestino.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ConsultarPurasChanchillasRetorno()
        Try
            Dim obj As New coControlLoteDestete With {
                .ListaIdsLotes = listaIdsLotes,
                .IdPlantel = idPlantelSalida
            }
            Dim ds As New DataSet
            ds = cn.Cn_ConsultarCerdasRetornarxLotes(obj).Copy

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                If ds.Tables.Count > 1 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    LblNumPuras.Text = CInt(ds.Tables(0).Rows(0)("CantPura"))
                    LblNumCambo.Text = CInt(ds.Tables(0).Rows(0)("CantCamborough"))
                End If

                If ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 0 Then
                    clsBasicas.Formato_Tablas_Grid_CuatroUltimasColumnaEditable(DtgListadoLote)
                    DtgListadoLote.DataSource = ds.Tables(1)
                    DtgListadoLote.DisplayLayout.Bands(0).Columns("idLote").Hidden = True
                    FormatoColumnas()
                    ConfigurarUltraGrid()
                End If
            End If

            numAnimales = CInt(LblNumPuras.Text) + CInt(LblNumCambo.Text)

            If numAnimales = 0 Then
                msj_advert("No se encontraron animales para retornar")
                Dispose()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub FormatoColumnas()
        Try
            If DtgListadoLote.Rows.Count > 0 Then
                Dim colorCantidadRecibida As Color = Color.LightGray

                For Each fila As UltraGridRow In DtgListadoLote.Rows
                    If fila.Cells.Exists("Puras") Or fila.Cells.Exists("Camborough") Or fila.Cells.Exists("Celador") Then
                        fila.Cells("Puras").Appearance.BackColor = colorCantidadRecibida
                        fila.Cells("Puras").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        fila.Cells("Camborough").Appearance.BackColor = colorCantidadRecibida
                        fila.Cells("Camborough").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        fila.Cells("Celador").Appearance.BackColor = colorCantidadRecibida
                        fila.Cells("Celador").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        fila.Cells("Madre Meishan").Appearance.BackColor = colorCantidadRecibida
                        fila.Cells("Madre Meishan").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                    End If
                Next
                DtgListadoLote.Refresh()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ConfigurarUltraGrid()
        With DtgListadoLote.DisplayLayout.Bands(0)
            .Groups.Clear()
            .RowLayoutStyle = RowLayoutStyle.GroupLayout

            Dim group1 As UltraGridGroup = .Groups.Add("Información Actual", "Información Actual")
            Dim group2 As UltraGridGroup = .Groups.Add("N° Retornar", "N° Retornar")

            .Columns(0).RowLayoutColumnInfo.ParentGroup = group1
            .Columns(1).RowLayoutColumnInfo.ParentGroup = group1
            .Columns(2).RowLayoutColumnInfo.ParentGroup = group1
            .Columns(3).RowLayoutColumnInfo.ParentGroup = group1
            .Columns(4).RowLayoutColumnInfo.ParentGroup = group2
            .Columns(5).RowLayoutColumnInfo.ParentGroup = group2
            .Columns(6).RowLayoutColumnInfo.ParentGroup = group2
            .Columns(7).RowLayoutColumnInfo.ParentGroup = group2
        End With

        DtgListadoLote.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        clsBasicas.Filtrar_Tabla(DtgListadoLote, False)
    End Sub

    Private Sub DtgListadoLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DtgListadoLote.KeyPress
        If DtgListadoLote.ActiveCell IsNot Nothing AndAlso DtgListadoLote.ActiveCell.Column.Key = "Puras" Then
            Dim activeText As String = DtgListadoLote.ActiveCell.Text

            If Char.IsDigit(e.KeyChar) Then
                If activeText.Length >= 3 Then
                    e.Handled = True
                End If

            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End If

        If DtgListadoLote.ActiveCell IsNot Nothing AndAlso DtgListadoLote.ActiveCell.Column.Key = "Camborough" Then
            Dim activeText As String = DtgListadoLote.ActiveCell.Text

            If Char.IsDigit(e.KeyChar) Then
                If activeText.Length >= 3 Then
                    e.Handled = True
                End If

            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End If

        If DtgListadoLote.ActiveCell IsNot Nothing AndAlso DtgListadoLote.ActiveCell.Column.Key = "Celador" Then
            Dim activeText As String = DtgListadoLote.ActiveCell.Text

            If Char.IsDigit(e.KeyChar) Then
                If activeText.Length >= 3 Then
                    e.Handled = True
                End If

            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub DtgListadoLote_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles DtgListadoLote.AfterCellUpdate
        If e.Cell.Column.Key = "Puras" OrElse
       e.Cell.Column.Key = "Camborough" OrElse
       e.Cell.Column.Key = "Celador" Then

            TxtTotalAnimales.Text = SumarValoresRetornar(DtgListadoLote).ToString()
        End If
    End Sub

    Private Sub DtgListadoLote_AfterExitEditMode(sender As Object, e As EventArgs) Handles DtgListadoLote.AfterExitEditMode
        TxtTotalAnimales.Text = SumarValoresRetornar(DtgListadoLote).ToString()
    End Sub

    Private Function SumarValoresRetornar(grid As UltraGrid) As Integer
        Dim total As Integer = 0
        For Each row As UltraGridRow In grid.Rows
            If row.IsDataRow Then
                Dim v1 As Object = row.Cells("Puras").Value
                Dim v2 As Object = row.Cells("Camborough").Value
                Dim v3 As Object = row.Cells("Celador").Value
                Dim v4 As Object = row.Cells("Madre Meishan").Value
                If IsNumeric(v1) Then total += CInt(v1)
                If IsNumeric(v2) Then total += CInt(v2)
                If IsNumeric(v3) Then total += CInt(v3)
                If IsNumeric(v4) Then total += CInt(v4)
            End If
        Next
        TxtPesoTotal.Text = "0.0"
        TxtPesoPromedio.Text = "0.0"
        Return total
    End Function

    Public Sub LlenarCamposConductor(codigo As Integer, numDoc As String, datos As String)
        idConductor = codigo
        TxtNumDoc.Text = numDoc
        TxtDatos.Text = datos
    End Sub

    Public Sub LlenarCamposTransporte(codigo As Integer, numPlaca As String, tipoVehiculo As String)
        idTransporte = codigo
        TxtTransporte.Text = tipoVehiculo
        TxtPlaca.Text = numPlaca
    End Sub

    Private Sub Inicializar()
        DtpFechaRetorno.Value = Now.Date
        TxtNumDoc.ReadOnly = True
        TxtTransporte.ReadOnly = True
        TxtDatos.ReadOnly = True
        TxtPlaca.ReadOnly = True
        TxtPesoPromedio.ReadOnly = True
        TxtTotalAnimales.ReadOnly = True
    End Sub

    Sub ListarPlantelesLlegada()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlantelesReproduccion().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbUbicacionLLegada
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub BtnBuscarConductor_Click(sender As Object, e As EventArgs) Handles BtnBuscarConductor.Click
        Try
            Dim f As New FrmListarConductorRetorno(Me)
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscarVehiculo_Click(sender As Object, e As EventArgs) Handles BtnBuscarVehiculo.Click
        Try
            Dim f As New FrmListarTransporteRetorno(Me)
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            DtgListadoLote.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)

            If DtpFechaRetorno.Value.Date > Date.Now.Date Then
                msj_advert("La fecha de bajada no puede ser mayor a la fecha actual")
                DtpFechaRetorno.Value = Date.Now.Date
                Return
            End If

            If (idConductor = 0) Then
                msj_advert("Debe seleccionar un conductor")
                Return
            ElseIf (idTransporte = 0) Then
                msj_advert("Debe seleccionar un transporte")
                Return
            ElseIf (TxtObservacion.Text.Length = 0) Then
                msj_advert("Debe ingresar observación")
                Return
            ElseIf (TxtPesoTotal.Text.Length = 0) Then
                msj_advert("Debe ingresar el peso total")
                Return
            ElseIf (CInt(TxtPesoTotal.Text) <= 0) Then
                msj_advert("Debe ingresar el peso total mayor a 0")
                Return
            ElseIf (TxtPesoPromedio.Text.Length = 0) Then
                msj_advert("Debe ingresar el peso promedio")
                Return
            ElseIf (CInt(TxtPesoPromedio.Text) <= 0) Then
                msj_advert("Debe ingresar el peso promedio mayor a 0")
                Return
            End If

            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoLote.Rows
                Dim lote As String = row.Cells("Lote").Text

                Dim purasRetornar As Integer = If(IsNumeric(row.Cells("Puras").Value), CInt(row.Cells("Puras").Value), 0)
                Dim totalPuras As Integer = If(IsNumeric(row.Cells("Total Puras").Value), CInt(row.Cells("Total Puras").Value), 0)

                Dim camboroughRetornar As Integer = If(IsNumeric(row.Cells("Camborough").Value), CInt(row.Cells("Camborough").Value), 0)
                Dim totalCamborough As Integer = If(IsNumeric(row.Cells("Total Camborough").Value), CInt(row.Cells("Total Camborough").Value), 0)

                If purasRetornar > totalPuras Then
                    msj_advert($"En el {lote}, la cantidad de 'Puras' ({purasRetornar}) excede el total disponible ({totalPuras}).")
                    Return
                End If

                If camboroughRetornar > totalCamborough Then
                    msj_advert($"En el {lote}, la cantidad de 'Camborough Retornar' ({camboroughRetornar}) excede el total disponible ({totalCamborough}).")
                    Return
                End If
            Next

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR RETORNO DE CHANCHILLAS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            numPuras = DtgListadoLote.Rows.Sum(Function(row) If(IsNumeric(row.Cells("Puras").Value), CInt(row.Cells("Puras").Value), 0))
            numCamborough = DtgListadoLote.Rows.Sum(Function(row) If(IsNumeric(row.Cells("Camborough").Value), CInt(row.Cells("Camborough").Value), 0))
            numCelador = DtgListadoLote.Rows.Sum(Function(row) If(IsNumeric(row.Cells("Celador").Value), CInt(row.Cells("Celador").Value), 0))
            numMeishan = DtgListadoLote.Rows.Sum(Function(row) If(IsNumeric(row.Cells("Madre Meishan").Value), CInt(row.Cells("Madre Meishan").Value), 0))

            Dim obj As New coControlLoteDestete With {
                .Observacion = TxtObservacion.Text,
                .CantidadTatuadas = numCamborough,
                .CantidadPuras = numPuras,
                .CantidadVenta = numCelador,
                .CantidadMeishan = numMeishan,
                .PesoTotal = CDec(TxtPesoTotal.Text),
                .PesoPromedio = CDec(TxtPesoPromedio.Text),
                .IdPlantelSalida = cbxalmacendestino.SelectedValue,
                .IdPlantelLlegada = CmbUbicacionLLegada.Value,
                .IdTransporte = idTransporte,
                .IdConductor = idConductor,
                .ListaIdsLotes = CreacionStringChanchillasxLote(),
                .IdUsuario = VP_IdUser,
                .FechaControl = DtpFechaRetorno.Value
            }

            Dim mensaje As String = cn.Cn_RegistrarRetorno(obj)
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

    Function CreacionStringChanchillasxLote() As String
        Dim array_valvulas As String = ""
        If (DtgListadoLote.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To DtgListadoLote.Rows.Count - 1
                If (DtgListadoLote.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With DtgListadoLote.Rows(i)
                        array_valvulas = array_valvulas & .Cells("idLote").Value.ToString.Trim & "+" &
                            .Cells("Puras").Value.ToString.Trim & "+" &
                            .Cells("Camborough").Value.ToString.Trim & "+" &
                            .Cells("Celador").Value.ToString.Trim & "+" &
                            .Cells("Madre Meishan").Value.ToString.Trim & ","
                    End With
                End If
            Next
            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub TxtPesoTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPesoTotal.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtPesoTotal_TextChanged(sender As Object, e As EventArgs) Handles TxtPesoTotal.TextChanged
        Try
            If IsNumeric(TxtPesoTotal.Text) AndAlso IsNumeric(TxtTotalAnimales.Text) AndAlso CDec(TxtTotalAnimales.Text) > 0 Then
                TxtPesoPromedio.Text = (CDec(TxtPesoTotal.Text) / CDec(TxtTotalAnimales.Text)).ToString("F2")
            Else
                TxtPesoPromedio.Text = "0.0"
            End If
        Catch ex As Exception
            TxtPesoPromedio.Text = "0.0"
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class