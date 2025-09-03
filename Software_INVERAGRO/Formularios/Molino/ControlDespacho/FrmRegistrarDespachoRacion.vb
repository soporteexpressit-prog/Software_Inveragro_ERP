Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmRegistrarDespachoRacion
    Dim cn As New cnControlDespacho
    Dim idRacion As Integer = 0
    Dim idDetalleSalida As Integer = 0
    Dim descripcionMedicacionPlus As String = ""
    Dim tipoAlimento As String = ""
    Public idSalida As Integer = 0
    Private DtDetalleRacionDespacho As New DataTable("TempDetRacionDespachar")
    Private idConductor As Integer
    Private idTransporte As Integer
    Public idUbicacionOrigen As Integer
    Public idUbicacionDestino As Integer
    Private DtTempRacionDespachar As DataTable

    Private Sub FrmRegistrarDespachoRacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Formato_Tablas_Grid(dtgListadoRacionDespachar)
        CargarTablaDetalleRacionDespachar()
        Inicializar()
    End Sub

    Private Sub Inicializar()
        TxtNumDoc.ReadOnly = True
        TxtDatos.ReadOnly = True
        TxtTransporte.ReadOnly = True
        TxtPlaca.ReadOnly = True
        TxtCapacidad.ReadOnly = True
        TxtRacion.ReadOnly = True
        TxtStock.ReadOnly = True
        TxtCantidadSolicitada.ReadOnly = True
        TxtSacosExtra.Text = "0"
        DtpFecha.Value = Now.Date
    End Sub

    Public Sub LlenarCamposConductor(codigo As Integer, numDoc As String, datos As String)
        idConductor = codigo
        TxtNumDoc.Text = numDoc
        TxtDatos.Text = datos
    End Sub

    Public Sub LlenarCamposTransporte(codigo As Integer, numPlaca As String, tipoVehiculo As String, capacidad As Decimal)
        idTransporte = codigo
        TxtTransporte.Text = tipoVehiculo
        TxtPlaca.Text = numPlaca
        TxtCapacidad.Text = capacidad
    End Sub

    Public Sub LlenarTablaDespacho(idDetalleSalidaLr As Integer, codigo As Integer, racion As String, cantidadTotal As Decimal, cantidadEnviada As Decimal, stock As Decimal, descripcionMedicacionPlusLr As String, tipoAlimentoLr As String)
        idDetalleSalida = idDetalleSalidaLr
        idRacion = codigo
        TxtRacion.Text = racion
        TxtCantidadSolicitada.Text = (cantidadTotal - cantidadEnviada).ToString("N2")
        TxtCantidadDespachar.Text = (cantidadTotal - cantidadEnviada).ToString("N2")
        TxtSacos.Text = (cantidadTotal * 20).ToString("N2")
        TxtStock.Text = stock.ToString("N2")
        descripcionMedicacionPlus = descripcionMedicacionPlusLr
        If descripcionMedicacionPlus <> "-" Then
            LblMedicacionPlus.Text = descripcionMedicacionPlus
        Else
            LblMedicacionPlus.Text = ""
        End If
        tipoAlimento = tipoAlimentoLr
    End Sub

    Sub CargarTablaDetalleRacionDespachar()
        DtDetalleRacionDespacho = New DataTable("TempDetRacionDespachar")
        DtDetalleRacionDespacho.Columns.Add("idDetalleSalida", GetType(Integer))
        DtDetalleRacionDespacho.Columns.Add("codRacion", GetType(Integer))
        DtDetalleRacionDespacho.Columns.Add("racion", GetType(String))
        DtDetalleRacionDespacho.Columns.Add("cantidad", GetType(Decimal))
        DtDetalleRacionDespacho.Columns.Add("cantidadEnviar", GetType(Decimal))
        DtDetalleRacionDespacho.Columns.Add("cantidadSacos", GetType(Decimal))
        DtDetalleRacionDespacho.Columns.Add("cantidadSacosExtra", GetType(Decimal))
        DtDetalleRacionDespacho.Columns.Add("btnEliminar", GetType(String))
        DtDetalleRacionDespacho.Columns.Add("tipoAlimento", GetType(String))
        dtgListadoRacionDespachar.DataSource = DtDetalleRacionDespacho
    End Sub

    Private Sub dtgListadoRacionDespachar_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListadoRacionDespachar.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True
                .Columns(2).Header.Caption = "Ración"
                .Columns(3).Header.Caption = "Cantidad Solicitada (tn)"
                .Columns(4).Header.Caption = "Cantidad Enviar (tn)"
                .Columns(5).Header.Caption = "Sacos (50kg)"
                .Columns(6).Header.Caption = "Sacos Extra (50kg)"
                .Columns(7).Header.Caption = "Eliminar"
                .Columns(7).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(7).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(7).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns(8).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListadoRacionDespachar_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListadoRacionDespachar.ClickCellButton
        If e.Cell.Column.Key = "btnEliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTA RACIÓN?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetalleRacionDespacho.Rows.RemoveAt(rowIndex)
                DtDetalleRacionDespacho.AcceptChanges()
                dtgListadoRacionDespachar.DataSource = DtDetalleRacionDespacho
            End If
        End If
    End Sub

    Private Sub BtnBuscarConductor_Click(sender As Object, e As EventArgs) Handles BtnBuscarConductor.Click
        Try
            Dim f As New FrmListarConductor(Me)
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscarVehiculo_Click(sender As Object, e As EventArgs) Handles BtnBuscarVehiculo.Click
        Try
            Dim f As New FrmListarTransporte(Me)
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscarRacion_Click(sender As Object, e As EventArgs) Handles BtnBuscarRacion.Click
        Try
            Dim f As New FrmListarRacionesPreparadas(Me) With {
                .idRequerimiento = idSalida
            }
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (idConductor = 0) Then
                msj_advert("Seleccione un Conductor")
                Return
            ElseIf (idTransporte = 0) Then
                msj_advert("Seleccione un Vehículo")
                Return
            ElseIf (dtgListadoRacionDespachar.Rows.Count = 0) Then
                msj_advert("Seleccione una Ración")
                Return
            ElseIf (DtpFecha.Value > Now.Date) Then
                msj_advert("La fecha no puede ser mayor a la fecha actual")
                Return
            End If


            Dim obj As New coControlDespacho With {
                .Codigo = VP_IdUser,
                .Observacion = TxtObservacion.Text,
                .IdSalida = idSalida,
                .IdUbicacionOrigen = idUbicacionOrigen,
                .IdUbicacionDestino = idUbicacionDestino,
                .IdTransporte = idTransporte,
                .IdConductor = idConductor,
                .DespachoCompleto = If(CkxDespachoTotal.Checked, 1, 0),
                .ListaDetalleRecepcion = creacionStringEnvioAlimento(),
                .Fecha = DtpFecha.Value
            }

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR ESTE DEPACHO DE ALIMENTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim MensajeBgWk As String = cn.Cn_RegistrarEnvioAlimentoPlantel(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Close()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function creacionStringEnvioAlimento() As String
        Dim array_valvulas As String = ""
        If (dtgListadoRacionDespachar.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgListadoRacionDespachar.Rows.Count - 1
                If (dtgListadoRacionDespachar.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtgListadoRacionDespachar.Rows(i)
                        array_valvulas = array_valvulas & .Cells("cantidadEnviar").Value.ToString.Trim & "+" &
                            .Cells("codRacion").Value.ToString.Trim & "+" &
                            .Cells("cantidadSacosExtra").Value.ToString.Trim & "+" &
                            .Cells("tipoAlimento").Value.ToString.Trim & "+" &
                            .Cells("idDetalleSalida").Value.ToString.Trim & ","
                    End With
                End If
            Next

            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub BtnAgregarRacion_Click(sender As Object, e As EventArgs) Handles BtnAgregarRacion.Click
        Dim filtro As String = "idDetalleSalida = " & idDetalleSalida

        Dim existeInsumo = DtDetalleRacionDespacho.Select(filtro)

        If existeInsumo.Length > 0 Then
            msj_advert("La racion " & TxtRacion.Text & " ya existe en la lista")
            Return
        End If

        If (Convert.ToDecimal(TxtCantidadDespachar.Text) > Convert.ToDecimal(TxtCantidadSolicitada.Text)) Then
            msj_advert("LA CANTIDAD A DESPACHAR NO PUEDE SER MAYOR A LA CANTIDAD SOLICITADA")
            Return
        End If

        If (Convert.ToDecimal(TxtCantidadDespachar.Text) > Convert.ToDecimal(TxtStock.Text)) Then
            msj_advert("LA CANTIDAD A DESPACHAR NO PUEDE SER MAYOR AL STOCK")
            Return
        End If

        If (String.IsNullOrWhiteSpace(TxtSacosExtra.Text)) Then
            msj_advert("INGRESE UNA CANTIDAD VALIDA EN SACOS EXTRA")
            Return
        End If

        If (idRacion = 0) Then
            msj_advert("DEBE SELECCIONAR UNA RACIÓN")
            Return
        End If

        If (CDec(TxtCantidadDespachar.Text) <= 0) Then
            msj_advert("DEBE INGRESAR LA CANTIDAD A DESPACHAR")
            Return
        End If

        Dim dr As DataRow
        dr = DtDetalleRacionDespacho.NewRow
        dr("idDetalleSalida") = idDetalleSalida
        dr("codRacion") = idRacion
        dr("racion") = TxtRacion.Text
        dr("cantidad") = Convert.ToDecimal(TxtCantidadSolicitada.Text)
        dr("cantidadEnviar") = Convert.ToDecimal(TxtCantidadDespachar.Text)
        dr("cantidadSacos") = Convert.ToDecimal(TxtSacos.Text)
        dr("cantidadSacosExtra") = Convert.ToDecimal(TxtSacosExtra.Text)
        dr("btnEliminar") = "Eliminar"
        dr("tipoAlimento") = tipoAlimento
        DtDetalleRacionDespacho.Rows.Add(dr)
        DtDetalleRacionDespacho.AcceptChanges()
        dtgListadoRacionDespachar.DataSource = DtDetalleRacionDespacho
        LimpiarCampos()
    End Sub

    Private Sub LimpiarCampos()
        idRacion = 0
        TxtRacion.Text = ""
        TxtStock.Text = "0"
        TxtCantidadSolicitada.Text = "0.0"
        TxtCantidadDespachar.Text = "0.0"
        TxtSacos.Text = "0"
        TxtSacosExtra.Text = "0"
        LblMedicacionPlus.Text = ""
    End Sub

    Private Sub TxtCantidadDespachar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidadDespachar.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtSacosExtra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSacosExtra.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtCantidadDespachar_TextChanged(sender As Object, e As EventArgs) Handles TxtCantidadDespachar.TextChanged
        If (TxtCantidadDespachar.Text.Trim.Length <> 0) Then
            TxtSacos.Text = (Convert.ToDecimal(TxtCantidadDespachar.Text) * 20).ToString("N2")
        End If
    End Sub

    Private Sub CkxDespachoTotal_CheckedChanged(sender As Object, e As EventArgs) Handles CkxDespachoTotal.CheckedChanged
        If (CkxDespachoTotal.Checked) Then
            BtnAgregarRacion.Enabled = False
            dtgListadoRacionDespachar.Enabled = False
            TxtCantidadDespachar.Enabled = False
            BtnBuscarRacion.Enabled = False
            If DtTempRacionDespachar Is Nothing Then
                ConsultarRaciones()
            Else
                LlenarTablaDetalleRacionDespachar(False)
            End If
        Else
            BtnAgregarRacion.Enabled = True
            dtgListadoRacionDespachar.Enabled = True
            TxtCantidadDespachar.Enabled = True
            BtnBuscarRacion.Enabled = True
            LimpiarTablaDetalleRacionDespachar()
        End If
    End Sub

    Private Sub ConsultarRaciones()
        Try
            Dim obj As New coControlDespacho With {
                .Codigo = idSalida
            }
            DtTempRacionDespachar = cn.Cn_ConsultarRacionPreparadaCerdoDespachoTotal(obj)
            LlenarTablaDetalleRacionDespachar(True)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub LlenarTablaDetalleRacionDespachar(cargarDesdeConsulta As Boolean)
        DtDetalleRacionDespacho = New DataTable("TempDetRacionDespachar")
        DtDetalleRacionDespacho.Columns.Add("idDetalleSalida", GetType(Integer))
        DtDetalleRacionDespacho.Columns.Add("codRacion", GetType(Integer))
        DtDetalleRacionDespacho.Columns.Add("racion", GetType(String))
        DtDetalleRacionDespacho.Columns.Add("cantidad", GetType(Decimal))
        DtDetalleRacionDespacho.Columns.Add("cantidadEnviar", GetType(Decimal))
        DtDetalleRacionDespacho.Columns.Add("cantidadSacos", GetType(Decimal))
        DtDetalleRacionDespacho.Columns.Add("cantidadSacosExtra", GetType(Decimal))
        DtDetalleRacionDespacho.Columns.Add("btnEliminar", GetType(String))
        DtDetalleRacionDespacho.Columns.Add("tipoAlimento", GetType(String))

        Dim sourceData As DataTable = If(cargarDesdeConsulta, DtTempRacionDespachar, DtTempRacionDespachar)

        For Each row As DataRow In sourceData.Rows
            Dim cantidad As Decimal = CDec(row("Cantidad Solicitada (tn)")) - CDec(row("Cantidad Enviada (tn)"))

            If cantidad > 0 Then
                Dim newRow As DataRow = DtDetalleRacionDespacho.NewRow()
                newRow("idDetalleSalida") = row("idDetalleSalida")
                newRow("codRacion") = row("Código")
                newRow("racion") = row("Ración")
                newRow("cantidad") = cantidad
                newRow("cantidadEnviar") = cantidad
                newRow("cantidadSacos") = Math.Round(cantidad * 20, 2)
                newRow("cantidadSacosExtra") = 0
                newRow("btnEliminar") = "Eliminar"
                newRow("tipoAlimento") = row("Tipo Alimento")
                DtDetalleRacionDespacho.Rows.Add(newRow)
            End If
        Next

        dtgListadoRacionDespachar.DataSource = DtDetalleRacionDespacho
    End Sub

    Private Sub LimpiarTablaDetalleRacionDespachar()
        If DtDetalleRacionDespacho IsNot Nothing Then
            DtDetalleRacionDespacho.Clear()
        End If
        dtgListadoRacionDespachar.DataSource = DtDetalleRacionDespacho
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class