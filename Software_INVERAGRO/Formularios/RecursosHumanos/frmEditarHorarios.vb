Public Class frmEditarHorarios
    Public Property Entrada As String
    Public Property Salida As String
    Public Property Observacion As String
    Public Property HorasExtras As String
    Public Property PagoEspecial As String
    Public Property HorasLaboradas As String
    Public Property HorasRefrigerio As String
    Public Property PermisoMedico As String
    Public Property Feriado As String
    Public Property HorasExtrasMarranas As String

    Private Sub frmEditarHorarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtHorasExtras.Enabled = False
    End Sub
    Public Sub New(ByVal entrada As String, ByVal salida As String, ByVal observacion As String, ByVal horasExtras As Double,
                   ByVal pagoEspecial As Double, ByVal horasLaboradas As Integer, ByVal horasRefrigerio As Integer, ByVal permisoMedico As String,
                   ByVal feriado As String, ByVal horasExtrasMarranas As Double)
        InitializeComponent()

        ' Inicializar los valores de entrada y salida
        If String.IsNullOrWhiteSpace(entrada) Then
            dtpHoraEntrada.Value = DateTime.Parse("00:00") 'Si la entrada es vacía se le coloca como valor inicial 08:00
        Else
            dtpHoraEntrada.Value = DateTime.Parse(entrada)
        End If
        If String.IsNullOrWhiteSpace(salida) Then
            dtpHoraSalida.Value = DateTime.Parse("00:00") 'Si la salida es vacía se le coloca como valor inicial 17:00 
        Else
            dtpHoraSalida.Value = DateTime.Parse(salida)
        End If
        txtObservacion.Text = observacion
        txtHorasExtras.Text = horasExtras
        txtPagoEspecial.Text = pagoEspecial
        txtHorasLaboradas.Text = horasLaboradas
        txtHorasRefrigerio.Text = horasRefrigerio
        cbxPermisoMedico.SelectedItem = permisoMedico
        cbxFeriado.SelectedItem = feriado
        txtHorasExtrasMarranas.Text = horasExtrasMarranas.ToString("0.0")

        AddHandler dtpHoraEntrada.TextChanged, AddressOf CalcularHorasExtras
        AddHandler dtpHoraSalida.TextChanged, AddressOf CalcularHorasExtras
        AddHandler txtHorasRefrigerio.TextChanged, AddressOf CalcularHorasExtras

        AddHandler dtpHoraEntrada.TextChanged, AddressOf ActualizarHorasRefrigerio
        AddHandler dtpHoraSalida.TextChanged, AddressOf ActualizarHorasRefrigerio
    End Sub


    Private Sub ActualizarHorasRefrigerio(sender As Object, e As EventArgs)
        Dim horaEntrada As DateTime
        Dim horaSalida As DateTime

        ' Comprobar si entrada y salida son válidas
        horaEntrada = dtpHoraEntrada.Value
        horaSalida = dtpHoraSalida.Value
    End Sub
    Private Sub CalcularHorasExtras(sender As Object, e As EventArgs)
        Dim horaEntrada As DateTime = dtpHoraEntrada.Value
        Dim horaSalida As DateTime = dtpHoraSalida.Value
        Dim horasRefrigerio As Integer

        Integer.TryParse(txtHorasRefrigerio.Text, horasRefrigerio)

        Dim diferencia As TimeSpan
        Dim esTurnoNocturno As Boolean = False

        ' Comprobar si es un turno nocturno (entrada mayor que salida)
        If horaEntrada > horaSalida Then
            ' Es un turno nocturno que cruza la medianoche
            esTurnoNocturno = True
            ' Calculamos hasta medianoche
            Dim medianoche As DateTime = DateTime.Today.AddDays(1).Date
            Dim hastaMedianoche As TimeSpan = medianoche - horaEntrada
            ' Calculamos desde medianoche hasta la salida
            Dim desdeMedianoche As TimeSpan = horaSalida - DateTime.Today.Date
            ' Sumamos ambos periodos
            diferencia = hastaMedianoche.Add(desdeMedianoche)
        Else
            ' Turno normal dentro del mismo día
            diferencia = horaSalida - horaEntrada
        End If

        ' Calcular horas y minutos totales
        Dim horasTotales As Double = diferencia.TotalHours
        Dim minutosExtra As Integer = diferencia.Minutes

        ' Restar tiempo de refrigerio
        horasTotales = Math.Max(0, horasTotales - horasRefrigerio)

        ' Calcular horas normales y extras
        Dim horasNormales As Integer = Math.Min(Math.Floor(horasTotales), 8)
        Dim horasExtrasBase As Integer = If(horasTotales > 8, Math.Floor(horasTotales - 8), 0)

        ' Calcular la parte decimal de las horas extras
        Dim horasExtrasDecimal As Double = 0
        If horasTotales > 8 Then
            Dim minutosExtras As Integer = minutosExtra
            If minutosExtras >= 30 Then
                horasExtrasDecimal = 0.5
            End If
        End If

        ' Sumar las horas extras base más la parte decimal
        Dim horasExtrasTotal As Double = horasExtrasBase + horasExtrasDecimal

        ' Actualizar los campos
        txtHorasExtras.Text = horasExtrasTotal.ToString("0.0")
        txtHorasLaboradas.Text = horasNormales.ToString()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If cbxInasistencia.Checked Then
            Entrada = "" 'txtEntrada.Text
            Salida = "" 'txtSalida.Text
            Observacion = If(String.IsNullOrWhiteSpace(txtObservacion.Text), "Sin Observación", txtObservacion.Text)
            HorasExtras = If(String.IsNullOrWhiteSpace(txtHorasExtras.Text), 0, Convert.ToDouble(txtHorasExtras.Text))
            PagoEspecial = If(String.IsNullOrWhiteSpace(txtPagoEspecial.Text), 0, Convert.ToDouble(txtPagoEspecial.Text))
            HorasLaboradas = If(String.IsNullOrWhiteSpace(txtHorasLaboradas.Text), 0, Convert.ToInt32(txtHorasLaboradas.Text))
            HorasRefrigerio = If(String.IsNullOrWhiteSpace(txtHorasRefrigerio.Text), 0, Convert.ToInt32(txtHorasRefrigerio.Text))
            PermisoMedico = If(cbxPermisoMedico.SelectedItem IsNot Nothing, cbxPermisoMedico.SelectedItem.ToString(), "NO")
            Feriado = If(cbxFeriado.SelectedItem IsNot Nothing, cbxFeriado.SelectedItem.ToString(), "SIN ASIGNAR")
            HorasExtrasMarranas = If(String.IsNullOrWhiteSpace(txtHorasExtrasMarranas.Text), 0, Convert.ToDouble(txtHorasExtrasMarranas.Text))
            DialogResult = DialogResult.OK
            Close()
            Return
        End If

        If cbxPermisoMedico.SelectedItem IsNot Nothing AndAlso cbxPermisoMedico.SelectedItem.ToString() = "SI" Then
            Entrada = dtpHoraEntrada.Value.ToString("HH:mm") 'txtEntrada.Text
            Salida = dtpHoraSalida.Value.ToString("HH:mm") 'txtSalida.Text
            Observacion = If(String.IsNullOrWhiteSpace(txtObservacion.Text), "Sin Observación", txtObservacion.Text)
            HorasExtras = If(String.IsNullOrWhiteSpace(txtHorasExtras.Text), 0, Convert.ToDouble(txtHorasExtras.Text))
            PagoEspecial = If(String.IsNullOrWhiteSpace(txtPagoEspecial.Text), 0, Convert.ToDouble(txtPagoEspecial.Text))
            HorasLaboradas = If(String.IsNullOrWhiteSpace(txtHorasLaboradas.Text), 0, Convert.ToInt32(txtHorasLaboradas.Text))
            HorasRefrigerio = If(String.IsNullOrWhiteSpace(txtHorasRefrigerio.Text), 0, Convert.ToInt32(txtHorasRefrigerio.Text))
            PermisoMedico = cbxPermisoMedico.SelectedItem.ToString()
            Feriado = If(cbxFeriado.SelectedItem IsNot Nothing, cbxFeriado.SelectedItem.ToString(), "SIN ASIGNAR")
            HorasExtrasMarranas = If(String.IsNullOrWhiteSpace(txtHorasExtrasMarranas.Text), 0, Convert.ToDouble(txtHorasExtrasMarranas.Text))
            DialogResult = DialogResult.OK
            Close()
            Return
        End If

        If cbxFeriado.SelectedItem IsNot Nothing AndAlso cbxFeriado.SelectedItem.ToString() = "SI" Then
            Entrada = dtpHoraEntrada.Value.ToString("HH:mm") 'txtEntrada.Text
            Salida = dtpHoraSalida.Value.ToString("HH:mm") 'txtSalida.Text
            Observacion = If(String.IsNullOrWhiteSpace(txtObservacion.Text), "Sin Observación", txtObservacion.Text)
            HorasExtras = If(String.IsNullOrWhiteSpace(txtHorasExtras.Text), 0, Convert.ToDouble(txtHorasExtras.Text))
            PagoEspecial = If(String.IsNullOrWhiteSpace(txtPagoEspecial.Text), 0, Convert.ToDouble(txtPagoEspecial.Text))
            HorasLaboradas = If(String.IsNullOrWhiteSpace(txtHorasLaboradas.Text), 0, Convert.ToInt32(txtHorasLaboradas.Text))
            HorasRefrigerio = If(String.IsNullOrWhiteSpace(txtHorasRefrigerio.Text), 0, Convert.ToInt32(txtHorasRefrigerio.Text))
            PermisoMedico = If(cbxPermisoMedico.SelectedItem IsNot Nothing, cbxPermisoMedico.SelectedItem.ToString(), "NO")
            Feriado = cbxFeriado.SelectedItem.ToString()
            HorasExtrasMarranas = If(String.IsNullOrWhiteSpace(txtHorasExtrasMarranas.Text), 0, Convert.ToDouble(txtHorasExtrasMarranas.Text))
            DialogResult = DialogResult.OK
            Close()
            Return
        End If

        If cbxFeriado.SelectedItem IsNot Nothing AndAlso cbxFeriado.SelectedItem.ToString() = "NO" Then
            Entrada = dtpHoraEntrada.Value.ToString("HH:mm") 'txtEntrada.Text
            Salida = dtpHoraSalida.Value.ToString("HH:mm") 'txtSalida.Text
            Observacion = If(String.IsNullOrWhiteSpace(txtObservacion.Text), "Sin Observación", txtObservacion.Text)
            HorasExtras = If(String.IsNullOrWhiteSpace(txtHorasExtras.Text), 0, Convert.ToDouble(txtHorasExtras.Text))
            PagoEspecial = If(String.IsNullOrWhiteSpace(txtPagoEspecial.Text), 0, Convert.ToDouble(txtPagoEspecial.Text))
            HorasLaboradas = If(String.IsNullOrWhiteSpace(txtHorasLaboradas.Text), 0, Convert.ToInt32(txtHorasLaboradas.Text))
            HorasRefrigerio = If(String.IsNullOrWhiteSpace(txtHorasRefrigerio.Text), 0, Convert.ToInt32(txtHorasRefrigerio.Text))
            PermisoMedico = If(cbxPermisoMedico.SelectedItem IsNot Nothing, cbxPermisoMedico.SelectedItem.ToString(), "NO")
            Feriado = cbxFeriado.SelectedItem.ToString()
            HorasExtrasMarranas = If(String.IsNullOrWhiteSpace(txtHorasExtrasMarranas.Text), 0, Convert.ToDouble(txtHorasExtrasMarranas.Text))
            DialogResult = DialogResult.OK
            Close()
            Return
        End If

        ' Validación de entrada y salida
        Dim horaEntrada As DateTime
        Dim horaSalida As DateTime

        horaEntrada = dtpHoraEntrada.Value
        horaSalida = dtpHoraSalida.Value

        ' Si ambas horas son iguales a 00:00, podría ser un error
        If horaEntrada.Hour = 0 And horaEntrada.Minute = 0 And
       horaSalida.Hour = 0 And horaSalida.Minute = 0 Then
            msj_advert("Verifique las horas de entrada y salida.")
            Return
        End If

        ' Guardar valores si las horas son válidas
        Entrada = dtpHoraEntrada.Value.ToString("HH:mm")
        Salida = dtpHoraSalida.Value.ToString("HH:mm")
        Observacion = If(String.IsNullOrWhiteSpace(txtObservacion.Text), "Sin Observación", txtObservacion.Text)
        HorasExtras = If(String.IsNullOrWhiteSpace(txtHorasExtras.Text), 0, Convert.ToDouble(txtHorasExtras.Text))
        PagoEspecial = If(String.IsNullOrWhiteSpace(txtPagoEspecial.Text), 0, Convert.ToDouble(txtPagoEspecial.Text))
        HorasLaboradas = If(String.IsNullOrWhiteSpace(txtHorasLaboradas.Text), 0, Convert.ToInt32(txtHorasLaboradas.Text))
        HorasRefrigerio = If(String.IsNullOrWhiteSpace(txtHorasRefrigerio.Text), 0, Convert.ToInt32(txtHorasRefrigerio.Text))
        PermisoMedico = If(cbxPermisoMedico.SelectedItem IsNot Nothing, cbxPermisoMedico.SelectedItem.ToString(), "NO")
        Feriado = If(cbxFeriado.SelectedItem IsNot Nothing, cbxFeriado.SelectedItem.ToString(), "SIN ASIGNAR")
        HorasExtrasMarranas = If(String.IsNullOrWhiteSpace(txtHorasExtrasMarranas.Text), 0, Convert.ToDouble(txtHorasExtrasMarranas.Text))
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub cbHabilitarHEX_CheckedChanged(sender As Object, e As EventArgs) Handles cbHabilitarHEX.CheckedChanged
        txtHorasExtras.Enabled = cbHabilitarHEX.Checked
    End Sub

    Private Sub cbxPermisoMedico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPermisoMedico.SelectedIndexChanged
        If cbxPermisoMedico.SelectedItem IsNot Nothing AndAlso cbxPermisoMedico.SelectedItem.ToString() = "NO" Then
            ' Solo establece "Sin Observación" si está vacío
            If String.IsNullOrWhiteSpace(txtObservacion.Text) Then
                txtObservacion.Text = "Sin Observación"
            End If
        ElseIf cbxPermisoMedico.SelectedItem IsNot Nothing AndAlso cbxPermisoMedico.SelectedItem.ToString() = "SI" Then
            dtpHoraEntrada.Value = DateTime.Today.AddHours(8).AddMinutes(0) ' 08:00
            dtpHoraSalida.Value = DateTime.Today.AddHours(17).AddMinutes(0) ' 17:00
        End If
    End Sub

    Private Sub cbxFeriado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxFeriado.SelectedIndexChanged
        If cbxFeriado.SelectedItem IsNot Nothing AndAlso cbxFeriado.SelectedItem.ToString() = "SIN ASIGNAR" Then
            If String.IsNullOrWhiteSpace(txtObservacion.Text) Then
                txtObservacion.Text = "Sin Observación"
            End If
        ElseIf cbxFeriado.SelectedItem IsNot Nothing AndAlso cbxFeriado.SelectedItem.ToString() = "SI" Then
            If (dtpHoraEntrada.Value.Hour = 0 AndAlso dtpHoraEntrada.Value.Minute = 0) AndAlso
                (dtpHoraSalida.Value.Hour = 0 AndAlso dtpHoraSalida.Value.Minute = 0) Then
                dtpHoraEntrada.Value = DateTime.Today.AddHours(8).AddMinutes(0) ' 08:00
                dtpHoraSalida.Value = DateTime.Today.AddHours(17).AddMinutes(0) ' 17:00
            End If
        ElseIf cbxFeriado.SelectedItem IsNot Nothing AndAlso cbxFeriado.SelectedItem.ToString() = "NO" Then
            dtpHoraEntrada.Value = DateTime.Today.AddHours(0).AddMinutes(0) ' 00:00
            dtpHoraSalida.Value = DateTime.Today.AddHours(0).AddMinutes(0) ' 00:00
        End If
    End Sub

    Private Sub cbxInasistencia_CheckedChanged(sender As Object, e As EventArgs) Handles cbxInasistencia.CheckedChanged
        If cbxInasistencia.Checked Then
            dtpHoraEntrada.Value = DateTime.Today.AddHours(0).AddMinutes(0) ' 00:00
            dtpHoraSalida.Value = DateTime.Today.AddHours(0).AddMinutes(0) ' 00:00
            txtObservacion.Text = "Sin observación"
        End If
    End Sub

    Private Sub cbxAsistencia_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAsistencia.CheckedChanged
        If cbxAsistencia.Checked Then
            dtpHoraEntrada.Value = DateTime.Today.AddHours(8).AddMinutes(0) ' 08:00
            dtpHoraSalida.Value = DateTime.Today.AddHours(17).AddMinutes(0) ' 17:00
            txtObservacion.Text = "Sin observación"
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservacion.KeyPress
        ' Verifica si el carácter presionado es '+' o ','
        If e.KeyChar = "+"c Or e.KeyChar = ","c Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxDescanso_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDescanso.CheckedChanged
        If cbxDescanso.Checked Then
            dtpHoraEntrada.Value = DateTime.Today.AddHours(8).AddMinutes(0) ' 00:00
            dtpHoraSalida.Value = DateTime.Today.AddHours(17).AddMinutes(0) ' 00:00
            txtObservacion.Text = "DESCANSO"
        End If
    End Sub

    Private Sub cbHorasExtrasMarranas_CheckedChanged(sender As Object, e As EventArgs) Handles cbHorasExtrasMarranas.CheckedChanged
        If cbHorasExtrasMarranas.Checked Then
            txtHorasExtrasMarranas.ReadOnly = False
        Else
            txtHorasExtrasMarranas.ReadOnly = True
        End If
    End Sub
End Class