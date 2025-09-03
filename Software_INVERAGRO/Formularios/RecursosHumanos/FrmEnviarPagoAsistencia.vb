Imports CapaNegocio
Imports CapaObjetos

Public Class FrmEnviarPagoAsistencia

    Dim cn As New cnControlAsistencia
    Public idHorario As Integer
    Public tipoPeriodo As String
    Public anio As Integer
    Public mes As Integer

    ' Este método se llama cuando el formulario se carga
    Private Sub FrmEnviarPagoAsistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarFechas()
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click

        Dim obj As New coControlAsistencia
        Dim mensaje As String = ""

        If tipoPeriodo = "QUINCENA 1" Then
            dtpFechaInicio.Value = New DateTime(anio, mes, 1)
            dtpFechaFin.Value = New DateTime(anio, mes, 15)
        ElseIf tipoPeriodo = "QUINCENA 2" Then
            dtpFechaInicio.Value = New DateTime(anio, mes, 16)
            dtpFechaFin.Value = New DateTime(anio, mes, DateTime.DaysInMonth(anio, mes))
        End If

        obj.idHorario = idHorario
        obj.Tipoperiodo = tipoPeriodo
        obj.FechaInicio = dtpFechaInicio.Value
        obj.FechaFin = dtpFechaFin.Value
        obj.Estado = "ENVIADO"
        obj.IdUsuario = VariablesGlobales.VP_IdUser
        mensaje = cn.Cn_EnviarPagoAsistencias(obj)
        If obj.CodeError <> 0 Then
            msj_advert(mensaje)
        Else
            msj_ok(mensaje)
            Dispose()
        End If

    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub CargarFechas()
        If tipoPeriodo = "QUINCENA 1" Then
            dtpFechaInicio.Value = New DateTime(anio, mes, 1)
            dtpFechaFin.Value = New DateTime(anio, mes, 15)
            dtpFechaInicio.Enabled = False
            dtpFechaFin.Enabled = False
        ElseIf tipoPeriodo = "QUINCENA 2" Then
            dtpFechaInicio.Value = New DateTime(anio, mes, 16)
            dtpFechaFin.Value = New DateTime(anio, mes, DateTime.DaysInMonth(anio, mes))
            dtpFechaInicio.Enabled = False
            dtpFechaFin.Enabled = False
        End If
    End Sub
End Class