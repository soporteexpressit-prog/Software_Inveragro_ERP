Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmRegPrestamo
    Dim cn As New cnCtaPagar
    Public _codigo As Integer = 0
    Dim ds As New DataSet
    Private DtDetalle As New DataTable("TempDetCuota")

    Sub ListarTablas()
        Try
            ds = New DataSet
            ds = cn.Cn_ListarTablasMaestrasPrestamo().Copy
            ds.DataSetName = "tmp"

            Dim indice_tabla As Integer = 0

            ' Cargar Monedas
            ds.Tables(0).Columns(1).ColumnName = "Seleccione una Moneda"
            With cbxmoneda
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = 1
                End If
            End With

            ' Cargar Forma de Pago
            indice_tabla = 1
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Seleccione un Tipo de Prestamo"
            With cbxtipoprestamo
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With


            ' Cargar Bancos filtrados por la Moneda seleccionada
            FiltrarBancosPorMoneda(ds.Tables(2), cbxbanco_origen, cbxmoneda.Value)

            ds.Tables(3).Columns(1).ColumnName = "Seleccione un Banco"
            With cbxbanco
                .DataSource = ds.Tables(3)
                .DisplayMember = ds.Tables(3).Columns(1).ColumnName
                .ValueMember = ds.Tables(3).Columns(0).ColumnName
                If (ds.Tables(3).Rows.Count > 0) Then
                    .Value = 1
                End If
            End With

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FiltrarBancosPorMoneda(tablaBancos As DataTable, comboBanco As UltraCombo, idMoneda As Integer)
        Try
            Dim vistaFiltrada As DataView = New DataView(tablaBancos)
            vistaFiltrada.RowFilter = "IdMoneda = " & idMoneda ' Filtra por la columna IdMoneda

            With comboBanco
                .DataSource = vistaFiltrada
                .DisplayMember = tablaBancos.Columns(1).ColumnName
                .ValueMember = tablaBancos.Columns(0).ColumnName
                If vistaFiltrada.Count > 0 Then
                    .Value = vistaFiltrada(0)(0)
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmRegPrestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtfechaaprobacion.Value = Now.Date
        dtfFechaCuota.Value = Now.Date
        dtfechasolicitud.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarTablas()
        CargarTablaDetalleCuota()
        dtfechasolicitud.Value = Now.Date
        If (_codigo <> 0) Then
            ' grupo_cabecera.Enabled = False
            pnlEditarCuota.Enabled = False
            btnGuardar.Visible = False
            dtfFechaCuota.ReadOnly = True
            txtcodigoreferencia.ReadOnly = True
            txtcomentario.ReadOnly = True
            ConsultarxId()
        Else
            btnGuardar.Visible = True
        End If
        Me.KeyPreview = True
    End Sub

    Private Sub FrmRegPrestamo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' Verifica si se presionan Control y Espacio al mismo tiempo
        If e.Control AndAlso e.KeyCode = Keys.Space Then
            btnGuardar.PerformClick()  ' Ejecuta el clic del botón
        End If
    End Sub


    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If dtfechasolicitud.Value > dtfechaaprobacion.Value Then
                msj_advert("La fecha de 'Solicitud' debe ser anterior o igual a la fecha 'Aprobación'.")
                Return
            End If
            If (txtcomentario.TextLength = 0) Then
                msj_advert("Ingrese una Observación")
                Return
            ElseIf (txtcodigoreferencia.TextLength = 0) Then
                msj_advert("Ingrese el Codigo de Referencia del Prestamo")
                Return
            ElseIf (txtimporteprestamo.TextLength = 0 OrElse CDec(txtimporteprestamo.Text) = 0) Then
                msj_advert("Ingrese el Importe del Prestamo válido")
                Return
            ElseIf (txttasa.TextLength = 0) Then
                msj_advert("Ingrese una Tasa de Interés")
                Return
            ElseIf (txtimporteprestamo.Text.Length = 0) Then
                msj_advert("Ingrese el Importe del Prestamo")
                Return
            ElseIf (CDec(txtimporteprestamo.Text) <> CDec(txttotalcuotas.Text)) Then
                msj_advert("El importe total de las cuotas debe ser igual al importe del prestamo")
                Return
            Else
                Dim prestamoCtaPagar As New coPrestamo

                prestamoCtaPagar.CodReferencia = txtcodigoreferencia.Text
                prestamoCtaPagar.TotalCuotas = numcuotas.Value
                prestamoCtaPagar.Importe = txtimporteprestamo.Text
                prestamoCtaPagar.FSolicitud = dtfechasolicitud.Value
                prestamoCtaPagar.FAprobacion = dtfechaaprobacion.Value ' Aprobación pendiente
                prestamoCtaPagar.FCuota = DateTime.Now.AddMonths(1) ' Primera cuota en un mes
                prestamoCtaPagar.TasaInteres = Decimal.Parse(txttasa.Text) ' 5% de interés
                prestamoCtaPagar.EstadoPrestamo = "APROBADO"
                prestamoCtaPagar.Comentario = txtcomentario.Text
                prestamoCtaPagar.IdUsuario = VP_IdUser
                prestamoCtaPagar.IdBanco = cbxbanco.Value
                prestamoCtaPagar.IdCuentaBancoDestDepo = cbxbanco_origen.ActiveRow.Cells(3).Value.ToString
                prestamoCtaPagar.IdTipoPrestamo = cbxtipoprestamo.Value
                prestamoCtaPagar.IdSolicitante = VP_IdUser
                prestamoCtaPagar.IdMoneda = cbxmoneda.Value
                prestamoCtaPagar.TipoCambio = txttc.Text
                prestamoCtaPagar.Lista_items = creacion_de_arrary()

                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_ResPrestamo(prestamoCtaPagar)

                If (prestamoCtaPagar.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Dispose()
                Else
                    msj_advert(MensajeBgWk)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub ConsultarxId()
        Try
            Dim obj As New coPrestamo
            obj.Idprestamo = _codigo
            Dim dsPrestamo As DataSet = cn.Cn_ConsultarPrestamoxCodigo(obj)

            If dsPrestamo IsNot Nothing AndAlso dsPrestamo.Tables.Count > 0 Then
                ' Obtener datos del préstamo


                txtcodigoreferencia.Text = dsPrestamo.Tables(0).Rows(0)(1).ToString()
                'numcuota.Value = dsPrestamo.Tables(0).Rows(0)(2).ToString()
                txtimporteprestamo.Text = Convert.ToDecimal(dsPrestamo.Tables(0).Rows(0)(3))
                dtfechasolicitud.Value = dsPrestamo.Tables(0).Rows(0)(4).ToString()
                dtfechaaprobacion.Value = dsPrestamo.Tables(0).Rows(0)(5).ToString()
                txttasa.Text = dsPrestamo.Tables(0).Rows(0)(6).ToString()
                txtcomentario.Text = dsPrestamo.Tables(0).Rows(0)(7).ToString()

                cbxbanco.Value = dsPrestamo.Tables(0).Rows(0)(11).ToString()
                cbxbanco_origen.ActiveRow.Cells(3).Value = dsPrestamo.Tables(0).Rows(0)(12).ToString()
                cbxtipoprestamo.Value = dsPrestamo.Tables(0).Rows(0)(13).ToString()

                cbxmoneda.Value = dsPrestamo.Tables(0).Rows(0)(15).ToString()

                dtgListado.DataSource = dsPrestamo.Tables(1)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "PENDIENTE", 3)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "PAGADO", 3)
            Else
                MessageBox.Show("No se encontró el préstamo.")
            End If


        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub


    Private Sub cbxmoneda_ValueChanged(sender As Object, e As EventArgs) Handles cbxmoneda.ValueChanged
        Try
            ' Verifica que ActiveRow no sea Nothing
            If cbxmoneda.ActiveRow IsNot Nothing Then
                ' Verifica que la celda 2 exista
                If cbxmoneda.ActiveRow.Cells.Count > 2 Then
                    txttc.Text = cbxmoneda.ActiveRow.Cells(2).Value.ToString
                    FiltrarBancosPorMoneda(ds.Tables(2), cbxbanco_origen, cbxmoneda.Value)
                Else
                    ' Manejar el caso donde la celda 2 no existe
                    txttc.Text = String.Empty
                End If
            Else
                ' Manejar el caso donde no hay ninguna fila activa
                txttc.Text = String.Empty
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub txtimporte_KeyPress(sender As Object, e As KeyPressEventArgs)
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub cbxbanco_origen_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxbanco_origen.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(2).Hidden = True
                .Columns(1).Width = 220
                .Columns(3).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxtipoprestamo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxtipoprestamo.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxmoneda_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxmoneda.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(2).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxbanco_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxbanco.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Width = 200
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Sub CargarTablaDetalleCuota()
        DtDetalle = New DataTable("TempDetProd")
        DtDetalle.Columns.Add("fechaCuota", GetType(DateTime))
        DtDetalle.Columns.Add("importe", GetType(Decimal))
        DtDetalle.Columns.Add("fechapago", GetType(DateTime))
        DtDetalle.Columns.Add("estado", GetType(String))
        DtDetalle.Columns.Add("btneditar", GetType(String))
        DtDetalle.Columns.Add("btnpagar", GetType(String))
        dtgListado.DataSource = DtDetalle
        dtgListado.Refresh()
    End Sub


    Private Sub Mostrarmmonto()
        If IsNumeric(txtimportecapital.Text) AndAlso IsNumeric(txttasa.Text) Then
            ' Realiza el cálculo de los intereses y el monto total
            Dim montoCapital As Double = Convert.ToDouble(txtimportecapital.Text)
            Dim porcentajeTasa As Double = Convert.ToDouble(txttasa.Text)
            Dim gananciaIntereses As Double = montoCapital * (porcentajeTasa / 100)
            Dim montoTotal As Double = montoCapital + gananciaIntereses
            If montoTotal = Math.Floor(montoTotal) Then
                txtimporteprestamo.Text = montoTotal.ToString("F0")
            Else
                txtimporteprestamo.Text = montoTotal.ToString("F2")
            End If
        Else
            txtimporteprestamo.Clear()
        End If
    End Sub


    Private Sub CalcularCuotas()
        Try
            ' Variables de control
            Dim importeTotal As Decimal
            Dim fechaPrimeraCuota As DateTime = dtfFechaCuota.Value
            Dim diasEntreCuotas As Integer
            Dim numeroCuotas As Integer

            ' Validar que el importe no esté vacío y sea un número positivo
            If Not Decimal.TryParse(txtimporteprestamo.Text, importeTotal) OrElse importeTotal <= 0 Then
                'msj_advert("Por favor, ingrese un importe total válido y mayor a cero.")
                'txtimporteprestamo.Focus()
                Return
            End If

            ' Validar que los días entre cuotas sea un número positivo
            If Not Integer.TryParse(numdiascuotas.Value.ToString(), diasEntreCuotas) OrElse diasEntreCuotas <= 0 Then
                'msj_advert("Por favor, ingrese un número de días válido y mayor a cero.")
                'numdiascuotas.Focus()
                Return
            End If

            ' Validar que el número de cuotas sea mayor a 0
            If Not Integer.TryParse(numcuotas.Value.ToString(), numeroCuotas) OrElse numeroCuotas <= 0 Then
                'msj_advert("Por favor, ingrese un número de cuotas válido y mayor a cero.")
                'numcuotas.Focus()
                Return
            End If

            ' Limpiar la tabla anterior
            DtDetalle.Rows.Clear()

            ' Calcular el importe por cuota
            Dim importeCuota As Decimal = Decimal.Round(importeTotal / numeroCuotas, 2)

            ' Variables para la fecha de cada cuota
            Dim fechaCuota As DateTime = fechaPrimeraCuota

            ' Llenar la tabla con las cuotas calculadas
            For i As Integer = 1 To numeroCuotas
                Dim nuevaFila As DataRow = DtDetalle.NewRow()

                nuevaFila("fechaCuota") = fechaCuota
                nuevaFila("importe") = importeCuota
                nuevaFila("fechapago") = DBNull.Value  ' La fecha de pago inicialmente es nula
                nuevaFila("estado") = "Pendiente"      ' Estado inicial de la cuota
                DtDetalle.Rows.Add(nuevaFila)

                ' Incrementar la fecha de la siguiente cuota
                fechaCuota = fechaCuota.AddDays(diasEntreCuotas)
            Next

            ' Calcular la suma de los importes de las cuotas
            Dim sumaImportes As Decimal = 0
            For Each row As DataRow In DtDetalle.Rows
                sumaImportes += row.Field(Of Decimal)("importe")
            Next

            ' Mostrar la suma de las cuotas en el control correspondiente
            txttotalcuotas.Text = sumaImportes

            ' Refrescar el DataGridView
            dtgListado.Refresh()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub




    'Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
    '    Try
    '        If e.Cell.Column.Key = "btneliminar" Then
    '            ' Verifica si la cuota seleccionada es la última en el cronograma
    '            Dim rowIndex As Integer = e.Cell.Row.Index
    '            Dim maxRowIndex As Integer = DtDetalle.Rows.Count - 1

    '            If rowIndex <> maxRowIndex Then
    '                MessageBox.Show("Solo puede eliminar la última cuota agregada para mantener el orden cronológico.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Return
    '            End If

    '            ' Preguntar si se desea eliminar la cuota
    '            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar esta cuota?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '            If result = DialogResult.Yes Then
    '                ' Eliminar la cuota seleccionada (última cuota)
    '                DtDetalle.Rows.RemoveAt(rowIndex)
    '                DtDetalle.AcceptChanges()
    '                dtgListado.DataSource = DtDetalle

    '                ' Actualizar el número de cuota
    '                Dim numCuota As Integer
    '                If Integer.TryParse(txtNumCuota.Text, numCuota) Then
    '                    txtNumCuota.Text = (numCuota - 1).ToString()
    '                Else
    '                    txtNumCuota.Text = "1"
    '                End If

    '                ' Recalcular la suma de importes
    '                Dim sumaImportes As Decimal = 0
    '                For Each row As DataRow In DtDetalle.Rows
    '                    sumaImportes += row.Field(Of Decimal)(1) ' Campo de importe debe ser el índice correcto
    '                Next
    '                txtimporte.Text = sumaImportes.ToString()
    '            End If
    '        End If
    '    Catch ex As Exception
    '        clsBasicas.controlException(Name, ex)
    '    End Try
    'End Sub
    Private SelectedRowIndex As Integer
    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            ' Verifica si se hizo clic en el botón de la columna "btneditar"
            If e.Cell.Column.Key = "btneditar" Then
                ' Obtener el índice de la fila seleccionada
                SelectedRowIndex = e.Cell.Row.Index

                ' Obtener el importe actual de la cuota
                Dim importeActual As Decimal = DtDetalle.Rows(SelectedRowIndex)("importe")

                ' Mostrar el importe actual en el TextBox del "modal"
                txtImporteNuevoModal.Text = importeActual.ToString()
                dtfechacuota.Value = DtDetalle.Rows(SelectedRowIndex)("fechaCuota")
                ' Mostrar el panel modal
                pnlEditarCuota.Visible = True
                pnlEditarCuota.BringToFront() ' Traer el panel al frente
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al intentar editar la cuota.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAceptarModal_Click(sender As Object, e As EventArgs) Handles btnAceptarModal.Click
        Try
            ' Validar el nuevo importe
            Dim nuevoImporte As Decimal
            If Decimal.TryParse(txtImporteNuevoModal.Text, nuevoImporte) AndAlso nuevoImporte > 0 Then
                ' Actualizar el importe en la fila seleccionada utilizando SelectedRowIndex
                DtDetalle.Rows(SelectedRowIndex)("importe") = nuevoImporte
                DtDetalle.Rows(SelectedRowIndex)("fechaCuota") = dtfechacuota.Value
                DtDetalle.AcceptChanges()

                ' Refrescar el DataGridView
                dtgListado.Refresh()

                ' Ocultar el panel modal
                pnlEditarCuota.Visible = False

                ' Recalcular la suma total de los importes si corresponde
                Dim sumaImportes As Decimal = 0
                For Each row As DataRow In DtDetalle.Rows
                    sumaImportes += row.Field(Of Decimal)("importe")
                Next
                txttotalcuotas.Text = sumaImportes
            Else
                MessageBox.Show("Por favor, ingrese un importe válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al intentar actualizar la cuota.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)

                If (_codigo <> 0) Then
                    '.Columns(4).Hidden = True
                    .Columns(0).Hidden = True
                    .Columns(1).Header.Caption = "Fecha Cuota"
                    .Columns(2).Header.Caption = "Importe"
                    .Columns(3).Header.Caption = "Estado"
                    .Columns(4).Header.Caption = "Fecha Pago"
                    .Columns(5).Header.Caption = "Pagar"
                    .Columns(5).Width = 60
                    .Columns(5).Style = UltraWinGrid.ColumnStyle.Button
                    .Columns(5).CellButtonAppearance.Image = My.Resources.Pagar_24_px
                    .Columns(5).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                    .Columns(5).Hidden = True

                Else
                    .Columns(2).Hidden = True
                    .Columns(3).Hidden = True
                    .Columns(5).Hidden = True

                    .Columns(0).Header.Caption = "Fecha de Cuota"
                    .Columns(0).Width = 200

                    .Columns(1).Header.Caption = "Importe"
                    .Columns(1).Width = 65


                    .Columns(4).Header.Caption = "Eliminar"
                    .Columns(4).Width = 60
                    .Columns(4).Style = UltraWinGrid.ColumnStyle.Button
                    .Columns(4).CellAppearance.BackColor = Color.DarkGreen
                    .Columns(4).CellAppearance.BackColor2 = Color.DarkGreen
                    .Columns(4).CellButtonAppearance.Image = My.Resources.editar
                    .Columns(4).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                End If
            End With
            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 0)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 1)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub txtImporteCuota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImporteNuevoModal.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Function creacion_de_arrary() As String
        Dim array_valvulas As String = ""
        If (dtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgListado.Rows.Count - 1
                If (dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtgListado.Rows(i)
                        array_valvulas = array_valvulas & Convert.ToDateTime(.Cells(0).Value.ToString.Trim).ToString("yyyy-MM-dd") & "+" &
                            .Cells(1).Value.ToString & ","
                    End With
                End If
            Next
            If (dtgListado.Rows.Count = 1) Then
                array_valvulas = array_valvulas & ","
            End If
            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub txttasa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttasa.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub txtimporteprestamo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtimporteprestamo.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub dtfFechaCuota_ValueChanged(sender As Object, e As EventArgs) Handles dtfFechaCuota.ValueChanged
        CalcularCuotas()
    End Sub

    Private Sub txtimporteprestamo_TextChanged(sender As Object, e As EventArgs) Handles txtimporteprestamo.TextChanged
        CalcularCuotas()
    End Sub

    Private Sub numcuotas_ValueChanged(sender As Object, e As EventArgs) Handles numcuotas.ValueChanged
        CalcularCuotas()
    End Sub

    Private Sub numdiascuotas_ValueChanged(sender As Object, e As EventArgs) Handles numdiascuotas.ValueChanged
        CalcularCuotas()
    End Sub

    Private Sub txtimportecapital_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtimportecapital.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub


    Private Sub txtimportecapital_TextChanged(sender As Object, e As EventArgs) Handles txtimportecapital.TextChanged
        Mostrarmmonto()
    End Sub

    Private Sub txttasa_TextChanged(sender As Object, e As EventArgs) Handles txttasa.TextChanged
        Mostrarmmonto()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pnlEditarCuota.Visible = False
    End Sub
End Class