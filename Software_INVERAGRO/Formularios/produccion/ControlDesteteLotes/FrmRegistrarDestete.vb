Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmRegistrarDestete
    Dim cn As New cnControlLoteDestete
    Dim tabla As New DataTable
    Dim listaSeleccionados As New List(Of String)
    Dim numeroCrias As Integer = 1
    Public idPlantel As Integer = 0
    Public valorPlantel As String = ""
    Private search As Boolean = False

    Private Sub FrmRegistrarDestete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarLotes()
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        clsBasicas.LlenarComboAnios(CmbAnios)
        TxtCondCorporal.Select()
        LblUbicacion.Text = valorPlantel
        DtpFechaDestete.Value = Now.Date
        TxtCantidadCrias.ReadOnly = True
        TxtPesoTotal.ReadOnly = True
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        TxtPesoPromCamada.ReadOnly = True
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        CmbLotes.Enabled = False
        GrupoOpciones.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        CmbLotes.Enabled = True
        GrupoOpciones.Enabled = True
        ToolStrip1.Enabled = True
    End Sub

    Sub ListarLotes()
        Dim cn As New cnControlLoteDestete
        Dim obj As New coControlLoteDestete With {
           .Anio = CmbAnios.Text,
           .IdPlantel = idPlantel
        }
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarLotesAnioCombo(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Lote"
        With CmbLotes
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
        search = True
    End Sub

    Private Sub CmbAnios_TextChanged(sender As Object, e As EventArgs) Handles CmbAnios.TextChanged
        If (search) Then
            ListarLotes()
        End If
    End Sub

    Private Sub CmbLotes_ValueChanged(sender As Object, e As EventArgs) Handles CmbLotes.ValueChanged
        Consultar()
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()
            TxtCantidadCrias.Text = "0"

            Dim obj As New coControlLoteDestete With {
                .IdLote = CmbLotes.Value,
                .IdPlantel = idPlantel
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tabla = cn.Cn_ConsultarCerdaLoteUbicacionDestete(obj).Copy
            tabla.TableName = "tmp"
            e.Result = tabla
            tabla.Columns(0).ColumnMapping = MappingType.Hidden
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
            TxtCondCorporal.Enabled = True
            If dtgListado.Rows.Count > 1 Then
                LblCodigoArete.Text = dtgListado.Rows(1).Cells("Arete").Value.ToString()
                numeroCrias = dtgListado.Rows(1).Cells("Número de Crías").Value
            ElseIf dtgListado.Rows.Count = 1 Then
                LblCodigoArete.Text = dtgListado.Rows(0).Cells("Arete").Value.ToString()
                numeroCrias = dtgListado.Rows(0).Cells("Número de Crías").Value
            End If
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim codigo As Integer = 1

            'colorear segun clave
            clsBasicas.Colorear_SegunClave(dtgListado, Color.Yellow, Color.Black, "NODRIZA", codigo)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(codigo).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub dtgListado_ClickCell(sender As Object, e As ClickCellEventArgs) Handles dtgListado.ClickCell
        Try
            If e.Cell IsNot Nothing AndAlso e.Cell.Row IsNot Nothing AndAlso e.Cell.Row.Cells(2).Value IsNot Nothing Then
                TxtCondCorporal.Text = ""
                TxtPesoCamada.Text = ""
                TxtPesoPromCamada.Text = "0.0"

                If Not IsDBNull(e.Cell.Row.Cells("Arete").Value) AndAlso Not IsDBNull(e.Cell.Row.Cells("Número de Crías").Value) Then
                    LblCodigoArete.Text = e.Cell.Row.Cells("Arete").Value.ToString()
                    numeroCrias = e.Cell.Row.Cells("Número de Crías").Value
                Else
                    LblCodigoArete.Text = String.Empty
                    numeroCrias = Nothing
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub BtnGuardarPesoCamada_Click(sender As Object, e As EventArgs) Handles BtnGuardarPesoCamada.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then

                'validamos que ingrese una condición corporal
                If (TxtCondCorporal.Text.Length = 0) Then
                    msj_advert("Ingrese una condición corporal válida")
                    Return
                ElseIf (ValidarDecimal(TxtCondCorporal.Text) <= 0) Then
                    msj_advert("Ingrese una condición corporal mayor a cero")
                    Return
                ElseIf (TxtPesoCamada.Text.Length = 0) Then
                    msj_advert("Ingrese un peso válido")
                    Return
                ElseIf (ValidarDecimal(TxtPesoCamada.Text) <= 0) Then
                    msj_advert("Ingrese un peso mayor a cero")
                    Return
                ElseIf (TxtPesoPromCamada.Text.Length = 0) Then
                    msj_advert("Ingrese un peso promedio válido")
                    Return
                ElseIf (ValidarDecimal(TxtPesoPromCamada.Text) <= 0) Then
                    msj_advert("Ingrese un peso promedio mayor a cero")
                    Return
                ElseIf (ValidarDecimal(TxtPesoPromCamada.Text) < 3) Then
                    msj_advert("El peso promedio de la camada debe ser mayor a 3")
                    Return
                End If

                activeRow.Cells("Cond. Corporal").Value = TxtCondCorporal.Text
                activeRow.Cells("Peso Total").Value = ValidarDecimal(TxtPesoCamada.Text).ToString("F2")
                activeRow.Cells("Peso Promedio").Value = ValidarDecimal(TxtPesoPromCamada.Text).ToString("F2")

                TxtCondCorporal.Text = ""
                TxtPesoCamada.Text = ""
                TxtPesoPromCamada.Text = "0.0"
                TxtPesoTotal.Text = SumarPesoTotal().ToString("F2")

                calcularCriasDestetar()
                PintarFilasDestete()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Function SumarPesoTotal() As Decimal
        Dim suma As Decimal = 0
        For i As Integer = 0 To dtgListado.Rows.Count - 1
            suma += dtgListado.Rows(i).Cells("Peso Total").Value
        Next
        Return suma
    End Function

    Private Function ValidarDecimal(valorTexto As String) As Decimal
        Dim textoLimpio As String = valorTexto.Trim()

        If textoLimpio.EndsWith(".") Then
            textoLimpio &= "0"
        End If

        Return CDec(textoLimpio)
    End Function

    Private Sub calcularCriasDestetar()
        Dim totalCrias As Integer = 0

        For Each fila As UltraGridRow In dtgListado.Rows
            If fila.Cells("Peso Total").Value IsNot Nothing AndAlso CDec(fila.Cells("Peso Total").Value) > 0 Then
                totalCrias += CInt(fila.Cells("Número de Crías").Value)
            End If
        Next
        TxtCantidadCrias.Text = totalCrias.ToString()
    End Sub

    Private Sub TxtTatuaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPesoCamada.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtPesoPromCamada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPesoPromCamada.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dtgListado.InitializeRow
        Dim column As Infragistics.Win.UltraWinGrid.UltraGridColumn = dtgListado.DisplayLayout.Bands(0).Columns("Editar")
        column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        If Not e.ReInitialize Then
            e.Row.Cells("Editar").Value = "Editar"
            e.Row.Cells("Editar").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        End If
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            With dtgListado
                If (e.Cell.Column.Key = "Editar") Then
                    If (LblCodigoArete.Text = "- - -") Then
                        msj_advert("Seleccione un cerda")
                        Return
                    End If

                    Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow

                    If activeRow IsNot Nothing AndAlso Not activeRow.IsFilterRow Then
                        activeRow.Cells("Cond. Corporal").Value = TxtCondCorporal.Text
                        activeRow.Cells("Peso Total").Value = 0
                        activeRow.Cells("Peso Promedio").Value = 0
                        numeroCrias = activeRow.Cells("Número de Crías").Value
                        TxtPesoCamada.Text = activeRow.Cells("Peso Total").Value.ToString()
                        TxtPesoPromCamada.Text = activeRow.Cells("Peso Promedio").Value.ToString()
                        TxtPesoTotal.Text = SumarPesoTotal().ToString("F2")

                        calcularCriasDestetar()
                        PintarFilasDestete()
                    End If
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TxtPesoCamada_TextChanged(sender As Object, e As EventArgs) Handles TxtPesoCamada.TextChanged
        Try
            If TxtPesoCamada.Text.Trim() = "" Then
                Exit Sub
            End If

            If numeroCrias = 0 Then
                msj_advert("Seleccione un registro válido, está utilizando el filtro de búsqueda")
                Exit Sub
            End If

            TxtPesoPromCamada.Text = If(TxtPesoCamada.Text = "0", "0.0", (CDec(TxtPesoCamada.Text) / numeroCrias).ToString("0.0"))
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnDestetearCrias_Click(sender As Object, e As EventArgs) Handles BtnDestetearCrias.Click
        Try
            Dim listaDatosCerdas As String = ObtenerIdsCerdasDestete()

            If DtpFechaDestete.Value > Now.Date Then
                msj_advert("La fecha de destete no puede ser mayor a la fecha actual")
                Return
            End If

            If listaDatosCerdas.Trim().Length = 0 Then
                msj_advert("Debe ingresar el peso total y peso promedio de al menos una camada a destetar")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR EL DESTETE DE LAS CRIAS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .ListaDatosDestete = listaDatosCerdas,
                .IdUsuario = VP_IdUser,
                .IdLote = CmbLotes.Value,
                .FechaControl = DtpFechaDestete.Value
            }

            Dim MensajeBgWk As String = cn.Cn_RegistrarDesteteCrias(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                TxtCantidadCrias.Text = "0"
                TxtPesoTotal.Text = "0.0"
                Consultar()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function ObtenerIdsCerdasDestete() As String
        Dim listaDatosCerdas As New List(Of String)

        For Each fila As UltraGridRow In dtgListado.Rows
            If fila.Cells("Peso Total").Value IsNot Nothing AndAlso CDec(fila.Cells("Peso Total").Value) > 0 Then
                Dim idCerda As String = fila.Cells(0).Value.ToString()
                Dim condCorporal As Decimal = fila.Cells("Cond. Corporal").Value.ToString()
                Dim pesoTotal As Decimal = Convert.ToDecimal(fila.Cells("Peso Total").Value)
                Dim pesoPromedio As Decimal = Convert.ToDecimal(fila.Cells("Peso Promedio").Value)

                Dim datosCerda As String = $"{idCerda}+{condCorporal}+{pesoTotal}+{pesoPromedio}"
                listaDatosCerdas.Add(datosCerda)
            End If
        Next

        If listaDatosCerdas.Count = 1 Then
            Return listaDatosCerdas(0) & ","
        Else
            Return String.Join(", ", listaDatosCerdas)
        End If
    End Function

    Private Sub PintarFilasDestete()
        For Each fila As UltraGridRow In dtgListado.Rows
            If fila.Cells("Peso Total").Value IsNot Nothing AndAlso CDec(fila.Cells("Peso Total").Value) > 0 Then
                fila.Appearance.BackColor = Color.LightPink ' Rosado claro
            Else
                fila.Appearance.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TxtCondCorporal_TextChanged(sender As Object, e As EventArgs) Handles TxtCondCorporal.TextChanged
        Try
            If numeroCrias = 0 Then
                msj_advert("Seleccione un registro válido, está utilizando el filtro de búsqueda")
                TxtCondCorporal.Text = ""
                Exit Sub
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TxtCondCorporal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCondCorporal.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class