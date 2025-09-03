Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Public Class FrmAgregarincidencia
    Private _incidenciaID As Integer
    Dim cn As New cnControlIncidencia()

    Public Sub New(incidenciaID As Integer)
        InitializeComponent()
        _incidenciaID = incidenciaID
        CargarIncidencia(_incidenciaID)
    End Sub
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub CargarIncidencia(incidenciaID As Integer)

    End Sub
    Private Sub FrmAgregarincidencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarComboboxes()
        MostrarAfiliadosYNoAfiliados()
    End Sub
    Private Sub CargarComboboxes()
        cbTipoacidente.Items.AddRange({"ACCIDENTE LABORAL", "INCIDENTE", "INCIDENTE PELIGROSO"})
        cbTipoacidente.SelectedIndex = 0
        cbGravedadaccidente.Items.AddRange({"ACCIDENTE LEVE", "ACCIDENTE INCAPACITANTE", "MORTAL"})
        cbGravedadaccidente.SelectedIndex = 0
        cbGradoaccidente.Items.AddRange({"TOTAL PERMANENTE", "TOTAL TEMPORAL", "PARCIAL PERMANENTE", "PARCIAL TEMPORAL"})
        cbGradoaccidente.SelectedIndex = 0
        cbprobabilidad.Items.AddRange({"ALTA - 4", "MEDIA - 2", "BAJA - 1"})
        cbprobabilidad.SelectedIndex = 0
        cbConsecuencia.Items.AddRange({"ALTA - 4", "MEDIA - 2", "BAJA - 1"})
        cbConsecuencia.SelectedIndex = 0
        cbturno.Items.AddRange({"MAÑANA", "TARDE", "NOCHE"})
        cbturno.SelectedIndex = 0
    End Sub
    Private Sub cbTipoacidente_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cbTipoacidente.SelectedItem IsNot Nothing Then
            Dim tipoElegido As String = cbTipoacidente.SelectedItem.ToString()
        End If
    End Sub
    Private Sub cbGravedadaccidente_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cbGravedadaccidente.SelectedItem IsNot Nothing Then
            Dim gravedadElegida As String = cbGravedadaccidente.SelectedItem.ToString()
        End If
    End Sub
    Private Sub cbGradoaccidente_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cbGradoaccidente.SelectedItem IsNot Nothing Then
            Dim gradoElegido As String = cbGradoaccidente.SelectedItem.ToString()
        End If
    End Sub
    Private Sub LimpiarCampos()
        TextBox4.Clear()
        cbTipoacidente.SelectedIndex = -1
        cbturno.SelectedIndex = -1
        cbGravedadaccidente.SelectedIndex = -1
        cbGradoaccidente.SelectedIndex = -1
        dtpfechayhoraocurrencia.Value = DateTime.Now
        dtpfechainvestigacion.Value = DateTime.Now
        txtdescripcioncuerpoafe.Clear()
        txtdescripcion.Clear()
        TextBox5.Clear()
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
    Private Sub cbprobabilidad_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim probabilidadElegido As String = cbprobabilidad.SelectedItem.ToString()
    End Sub
    Private Sub cbConsecuencia_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim consecuenciaElegido As String = cbConsecuencia.SelectedItem.ToString()
    End Sub
    Private _idPersona As Integer
    Private _idEncargado As Integer
    Private Sub RecibirTrabajador(selectedRow As DataRow)
        If selectedRow IsNot Nothing Then
            If selectedRow.Table.Columns.Contains("Cod.") Then
                Dim cod As String = selectedRow("Cod.").ToString()
                TextBox4.Text = cod
                Dim cn As New cnControlIncidencia()
                _idPersona = Convert.ToInt32(cod)
                Dim datosIncidencia As coControlincidencia = cn.ObtenerDatosIncidencia(_idPersona)
                If datosIncidencia IsNot Nothing Then
                    TextBox4.Text = datosIncidencia.NombrePersona
                    txtdni.Text = datosIncidencia.DNI
                    txtnombreaseguradora.Text = datosIncidencia.NombreAseguradora
                    txtedad.Text = datosIncidencia.Edad.ToString()
                    txtsexo.Text = datosIncidencia.Sexo
                    txtarea.Text = datosIncidencia.Area
                    txtCargo.Text = datosIncidencia.cargo
                Else
                    MessageBox.Show("No se encontraron datos para la persona seleccionada.")
                End If
            Else
                MessageBox.Show("La columna 'Cod' no existe en la tabla.")
            End If
        Else
            MessageBox.Show("No se seleccionó ninguna fila.")
        End If
    End Sub
    Private Function RecibirEncargado(selectedRow As DataRow) As Integer
        Dim idEncargado As Integer = -1
        If selectedRow IsNot Nothing Then
            If selectedRow.Table.Columns.Contains("Cod.") Then
                Dim cod As String = selectedRow("Cod.").ToString()
                Dim cn As New cnControlIncidencia()
                _idEncargado = Convert.ToInt32(cod)
                Dim datosEncargado As coControlincidencia = cn.ObtenerDatosIncidencia(_idEncargado)
                If datosEncargado IsNot Nothing Then
                    TextBox5.Text = datosEncargado.NombrePersona
                Else
                    MessageBox.Show("No se encontraron datos para el encargado seleccionado.")
                End If
            Else
                MessageBox.Show("La columna 'Cod' no existe en la tabla.")
            End If
        Else
            MessageBox.Show("No se seleccionó ninguna fila.")
        End If
        Return idEncargado
    End Function
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtlugarocurrencia.Text.Length = 0 Then
            msj_advert("Llene el campo de Lugar Ocurrencia")
            Return
        End If
        If cbTipoacidente.SelectedIndex = -1 Then
            msj_advert("Seleccione un tipo de accidente")
            Return
        End If
        If cbturno.SelectedIndex = -1 Then
            msj_advert("Seleccione el turno")
            Return
        End If
        If dtpfechayhoraocurrencia.Value > DateTime.Now Then
            msj_advert("La fecha y hora de ocurrencia no puede ser futura")
            Return
        End If
        If cbGravedadaccidente.SelectedIndex = -1 Then
            msj_advert("Seleccione la gravedad del accidente")
            Return
        End If
        If cbGradoaccidente.SelectedIndex = -1 Then
            msj_advert("Seleccione el grado del accidente")
            Return
        End If
        If Not Integer.TryParse(numdiasdes.Text, Nothing) OrElse Convert.ToInt32(numdiasdes.Text) < 0 Then
            msj_advert("Ingrese un número válido de días")
            Return
        End If
        If Not Integer.TryParse(numpersonasafectadas.Text, Nothing) OrElse Convert.ToInt32(numpersonasafectadas.Text) <= 0 Then
            msj_advert("Ingrese un número válido de personas afectadas")
            Return
        End If
        If txtdescripcion.Text.Length = 0 Then
            msj_advert("Ingrese la descripción del accidente")
            Return
        End If

        If _idPersona = _idEncargado Then
            msj_advert("El encargado del incidente no puede ser la misma persona que el afectado.")
            Return
        End If
        If _idEncargado = 0 Then
            msj_advert("Seleccione un encargado")
            Return
        End If
        If _idPersona = 0 Then
            msj_advert("Seleccione un trabajador")
            Return
        End If
        If cbGradoaccidente.SelectedIndex = -1 Then
            msj_advert("Seleccione el grado del accidente")
            Return
        End If
        If cbConsecuencia.SelectedIndex = -1 Then
            msj_advert("Seleccione la consecuencia")
            Return
        End If
        If cbprobabilidad.SelectedIndex = -1 Then
            msj_advert("Seleccione la probabilidad")
            Return
        End If
        If txtlugarocurrencia.Text.Length = 0 Then
            msj_advert("Ingrese el lugar de ocurrencia")
            Return
        End If
        If dtphorastrabajadas.Value > DateTime.Now Then
            msj_advert("La fecha y hora de trabajo no puede ser futura")
            Return
        End If
        If dtpfechainvestigacion.Value > DateTime.Now Then
            msj_advert("La fecha de investigación no puede ser futura")
            Return
        End If
        If dtpfechainvestigacion.Value < dtpfechayhoraocurrencia.Value Then
            msj_advert("La fecha de investigación no puede ser anterior a la fecha de ocurrencia")
            Return
        End If
        If txtdescripcioncuerpoafe.Text.Length = 0 Then
            msj_advert("Ingrese la descripción del cuerpo afectado")
            Return
        End If
        If txtdescripcion.Text.Length = 0 Then
            msj_advert("Ingrese la descripción del accidente")
            Return
        End If

        guardar()
        Me.Close()
    End Sub
    Sub guardar()
        Try
            Dim nuevoIncidente As New coControlincidencia()
            Dim incidente As New coControlincidencia
            incidente.TipoDeAccidente = cbTipoacidente.Text
            incidente.IdPersona = _idPersona
            incidente.Turno = cbturno.Text
            incidente.LugarExacto = txtlugarocurrencia.Text
            Dim horas As Integer = dtphorastrabajadas.Value.Hour
            Dim minutos As Integer = dtphorastrabajadas.Value.Minute
            incidente.HorasTrabajadas = New TimeSpan(horas, minutos, 0)
            incidente.FechaOcurrencia = dtpfechayhoraocurrencia.Value
            incidente.FechaInicioInv = dtpfechainvestigacion.Value
            incidente.Gravedad = cbGravedadaccidente.Text
            incidente.Grado = cbGradoaccidente.Text
            incidente.NumDias = Convert.ToInt32(numdiasdes.Text)
            incidente.NumPersonas = Convert.ToInt32(numpersonasafectadas.Text)
            incidente.Descripcion = txtdescripcioncuerpoafe.Text
            incidente.DescripcionClaramente = txtdescripcion.Text
            incidente.Probabilidad = cbprobabilidad.Text
            incidente.Consecuencia = cbConsecuencia.Text
            incidente.IdEncargado = _idEncargado
            incidente.Causas = FrmDeterminacionCausas.CrearArrayList()
            incidente.Causas = listaCausas
            incidente.IdUsuarioLogueado = VariablesGlobales.VP_IdUser
            Dim resultado As Boolean = cn.InsertarIncidenteConCausas(incidente, incidente.Causas)
            If resultado Then
                MessageBox.Show("Guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error al guardar la incidencia. Intenta nuevamente.")
            End If
            LimpiarCampos()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub btnAgregar_Click_1(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim frmListar As New FrmListarTrabajadorIF(AddressOf RecibirTrabajador)
        frmListar.ShowDialog()
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frmListar As New FrmListarTrabajadorIF(AddressOf RecibirEncargado)
        frmListar.ShowDialog()
    End Sub
    Public listaCausas As List(Of String)
    Private Sub btnañadircausas_Click(sender As Object, e As EventArgs) Handles btnañadircausas.Click
        Dim frmCausa As New FrmDeterminacionCausas()
        frmCausa.ShowDialog()
        listaCausas = frmCausa.listaCausas
    End Sub
    Private Sub txtlugarocurrencia_TextChanged(sender As Object, e As EventArgs) Handles txtlugarocurrencia.TextChanged
        Dim caracteresRestantes As Integer = 1000 - txtlugarocurrencia.Text.Length
        lblContador.Text = "1000/" & caracteresRestantes.ToString()
        lblContador.Location = New Point(txtlugarocurrencia.Location.X + txtlugarocurrencia.Width - lblContador.Width, txtlugarocurrencia.Location.Y + txtlugarocurrencia.Height + 3)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbturno.DropDownStyle = ComboBoxStyle.DropDownList
        cbTipoacidente.DropDownStyle = ComboBoxStyle.DropDownList
        cbGravedadaccidente.DropDownStyle = ComboBoxStyle.DropDownList
        cbGradoaccidente.DropDownStyle = ComboBoxStyle.DropDownList
        cbConsecuencia.DropDownStyle = ComboBoxStyle.DropDownList
        cbprobabilidad.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Private Sub txtdescripcioncuerpoafe_TextChanged(sender As Object, e As EventArgs) Handles txtdescripcioncuerpoafe.TextChanged
        Dim caracteresRestantes As Integer = 500 - txtdescripcioncuerpoafe.Text.Length
        lblContador2.Text = "500/" & caracteresRestantes.ToString()
        lblContador2.Location = New Point(txtdescripcioncuerpoafe.Location.X + txtdescripcioncuerpoafe.Width - lblContador2.Width, txtdescripcioncuerpoafe.Location.Y + txtdescripcioncuerpoafe.Height + 3)
    End Sub
    Private Sub txtdescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtdescripcion.TextChanged
        Dim caracteresRestantes As Integer = 1000 - txtdescripcion.Text.Length
        lblContador3.Text = "1000/" & caracteresRestantes.ToString()
        lblContador3.Location = New Point(txtdescripcion.Location.X + txtdescripcion.Width - lblContador3.Width, txtdescripcion.Location.Y + txtdescripcion.Height + 3)
    End Sub
    Private Sub cbturno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbturno.SelectedIndexChanged
        cbturno.DropDownStyle = ComboBoxStyle.DropDownList

    End Sub
    Private Sub cbTipoacidente_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbTipoacidente.SelectedIndexChanged
        cbTipoacidente.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Private Sub cbGravedadaccidente_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbGravedadaccidente.SelectedIndexChanged
        cbGravedadaccidente.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Private Sub cbGradoaccidente_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbGradoaccidente.SelectedIndexChanged
        cbGradoaccidente.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Private Sub cbConsecuencia_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbConsecuencia.SelectedIndexChanged
        cbConsecuencia.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Private Sub cbprobabilidad_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbprobabilidad.SelectedIndexChanged
        cbprobabilidad.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Public Sub nafiliados_TextChanged(sender As Object, e As EventArgs) Handles nafiliados.TextChanged

    End Sub

    Public Sub noafiliados_TextChanged(sender As Object, e As EventArgs) Handles noafiliados.TextChanged

    End Sub

    Public Sub MostrarAfiliadosYNoAfiliados()
        Dim cn As New cnControlIncidencia()
        Dim datosConteo As coControlincidencia = cn.ObtenerConteoAseguradosTrabajadores()

        If datosConteo IsNot Nothing Then
            nafiliados.Text = datosConteo.Asegurados.ToString()   ' Asigna el número de afiliados
            noafiliados.Text = datosConteo.NoAsegurados.ToString() ' Asigna el número de no afiliados
        Else
            MessageBox.Show("No se encontraron datos para el conteo de afiliados.")
        End If
    End Sub

End Class
