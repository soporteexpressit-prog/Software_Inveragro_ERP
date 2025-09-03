Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRegistrarBajada
    Dim cn As New cnControlLoteDestete
    Dim idConductor As Integer = 0
    Dim idTransporte As Integer = 0
    Public nombreLote As String = ""
    Public idLote As Integer = 0
    Public numPuras As Integer = 0
    Public numChanchillas As Integer = 0
    Public numEngorde As Integer = 0
    Public edadLote As Integer = 0
    Public idPlantelSalida As Integer = 0
    Public numBajadas As Integer = 0

    Private Sub FrmRegistrarBajada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlantelesLlegada()
            clsBasicas.ListarAlmacenesAsignados(cbxalmacendestino)
            cbxalmacendestino.SelectedValue = idPlantelSalida
            cbxalmacendestino.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        dtpFechaBajada.Value = Now.Date
        LblNombreLote.Text = nombreLote
        TxtNumDoc.ReadOnly = True
        TxtTransporte.ReadOnly = True
        TxtDatos.ReadOnly = True
        TxtPlaca.ReadOnly = True
        TxtNumAnimales.ReadOnly = True
        TxtNumAnimales.Text = numPuras + numChanchillas + numEngorde
        TxtNumPuras.ReadOnly = True
        TxtNumPuras.Text = numPuras
        LblNumPuras.Text = numPuras
        TxtNumChanchillas.ReadOnly = True
        TxtNumChanchillas.Text = numChanchillas
        LblNumChanchillas.Text = numChanchillas
        TxtEngorde.ReadOnly = True
        TxtEngorde.Text = numEngorde
        LblEngorde.Text = numEngorde
        TxtEdadLote.ReadOnly = True
        TxtEdadLote.Text = edadLote
        CbxEnvioTotal.Checked = True
    End Sub

    Sub ListarPlantelesLlegada()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlantelesEngorde().Copy
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

    Private Sub BtnBuscarConductor_Click(sender As Object, e As EventArgs) Handles BtnBuscarConductor.Click
        Try
            Dim f As New FrmListarConductorBajada(Me)
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscarVehiculo_Click(sender As Object, e As EventArgs) Handles BtnBuscarVehiculo.Click
        Try
            Dim f As New FrmListarTransporteBajada(Me)
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If dtpFechaBajada.Value.Date > Date.Now.Date Then
                msj_advert("La fecha de bajada no puede ser mayor a la fecha actual")
                dtpFechaBajada.Value = Date.Now.Date
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
            ElseIf (CInt(TxtNumPuras.Text) > numPuras) Then
                msj_advert("La cantidad de puras no puede ser mayor a " & numPuras)
                Return
            ElseIf (CInt(TxtNumChanchillas.Text) > numChanchillas) Then
                msj_advert("La cantidad de chanchillas no puede ser mayor a " & numChanchillas)
                Return
            ElseIf (CInt(TxtEngorde.Text) > numEngorde) Then
                msj_advert("La cantidad de engorde no puede ser mayor a " & numEngorde)
                Return
            ElseIf (CInt(TxtEdadLote.Text) <= 0) Then
                msj_advert("La edad del lote no puede ser menor o igual a 40")
                Return
            End If

            If (CInt(TxtNumPuras.Text) = numPuras And CInt(TxtNumChanchillas.Text) = numChanchillas And CInt(TxtEngorde.Text) = numEngorde) And Not CbxEnvioTotal.Checked Then
                If (MessageBox.Show("LAS CANTIDADES SON IGUALES A LAS QUE TIENE REGISTRADAS EN EL LOTE, SE VA A REGISTRAR UN ENVÍO TOTAL ¿DESEA CONTINUAR?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If
                CbxEnvioTotal.Checked = True
            Else
                If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR BAJADA DE ANIMALES?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If
            End If

            Dim obj As New coControlLoteDestete With {
                .Observacion = TxtObservacion.Text,
                .CantidadTatuadas = CInt(TxtNumChanchillas.Text),
                .CantidadPuras = CInt(TxtNumPuras.Text),
                .CantidadVenta = CInt(TxtEngorde.Text),
                .PesoTotal = 0,
                .PesoPromedio = 0,
                .TipoBajada = "ENVIO",
                .IdPlantelSalida = cbxalmacendestino.SelectedValue,
                .IdPlantelLlegada = CmbUbicacionLLegada.Value,
                .IdTransporte = idTransporte,
                .IdConductor = idConductor,
                .IdLote = idLote,
                .IdUsuario = VP_IdUser,
                .EdadLote = CInt(TxtEdadLote.Text),
                .FechaControl = dtpFechaBajada.Value
            }

            Dim mensaje As String = cn.Cn_RegistrarBajada(obj)
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

    Private Sub TxtPesoTotal_KeyPress(sender As Object, e As KeyPressEventArgs)
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub NumericUpDown1_KeyPress(sender As Object, e As KeyPressEventArgs)
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub CbxEnvioTotal_CheckedChanged(sender As Object, e As EventArgs) Handles CbxEnvioTotal.CheckedChanged
        If (CbxEnvioTotal.Checked) Then
            TxtNumChanchillas.ReadOnly = True
            TxtNumChanchillas.Text = numChanchillas
            TxtNumPuras.ReadOnly = True
            TxtNumPuras.Text = numPuras
            TxtEngorde.ReadOnly = True
            TxtEngorde.Text = numEngorde
        Else
            TxtNumChanchillas.ReadOnly = False
            TxtNumPuras.ReadOnly = False
            TxtEngorde.ReadOnly = False
        End If
    End Sub

    Private Sub ActualizarNumeroAnimales()
        Try
            If String.IsNullOrWhiteSpace(TxtNumChanchillas.Text) OrElse Not IsNumeric(TxtNumChanchillas.Text) Then
                TxtNumChanchillas.Text = "0"
            End If

            If String.IsNullOrWhiteSpace(TxtEngorde.Text) OrElse Not IsNumeric(TxtEngorde.Text) Then
                TxtEngorde.Text = "0"
            End If

            If String.IsNullOrWhiteSpace(TxtNumPuras.Text) OrElse Not IsNumeric(TxtNumPuras.Text) Then
                TxtNumPuras.Text = "0"
            End If

            Dim numChanchillas As Decimal = Convert.ToDecimal(TxtNumChanchillas.Text)
            Dim numEngorde As Decimal = Convert.ToDecimal(TxtEngorde.Text)
            Dim numPuras As Decimal = Convert.ToDecimal(TxtNumPuras.Text)

            TxtNumAnimales.Text = (numChanchillas + numEngorde + numPuras).ToString()
        Catch ex As Exception
            TxtNumAnimales.Text = "0"
        End Try
    End Sub

    Private Sub TxtNumChanchillas_TextChanged(sender As Object, e As EventArgs) Handles TxtNumChanchillas.TextChanged
        ActualizarNumeroAnimales()
    End Sub

    Private Sub TxtEngorde_TextChanged(sender As Object, e As EventArgs) Handles TxtEngorde.TextChanged
        ActualizarNumeroAnimales()
    End Sub

    Private Sub TxtNumPuras_TextChanged(sender As Object, e As EventArgs) Handles TxtNumPuras.TextChanged
        ActualizarNumeroAnimales()
    End Sub


    Private Sub TxtNumChanchillas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumChanchillas.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtEngorde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtEngorde.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtNumPuras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumPuras.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub dtpFechaBajada_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaBajada.ValueChanged
        Try
            If dtpFechaBajada.Value.Date > Date.Now.Date Then
                msj_advert("La fecha de bajada no puede ser mayor a la fecha actual")
                dtpFechaBajada.Value = Date.Now.Date
                Return
            End If
            Dim diaPicActual As Integer = clsBasicas.ObtenerDiaPIC(Date.Now.Date)
            Dim edadLotePic = diaPicActual - edadLote

            TxtEdadLote.Text = clsBasicas.ObtenerDiaPIC(dtpFechaBajada.Value) - edadLotePic
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class