Imports CapaNegocio
Imports CapaObjetos

Public Class FrmAmpliarPeriodoMedicamentoRacion
    Dim cn As New cnMedicamentoRacion
    Public idPeriodoMedicacion As Integer
    Public ubicacion As String
    Public racion As String
    Public fechaInicio As Date
    Public fechaFin As Date

    Private Sub FrmAmpliarPeriodoMedicamentoRacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtpFechaInicio.Enabled = False
            dtpFechaInicio.Value = fechaInicio
            dtpFechaFin.Value = fechaFin
            txtUbicacion.Text = ubicacion
            txtRacion.Text = racion
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnAmpliar_Click(sender As Object, e As EventArgs) Handles btnAmpliar.Click
        Try
            If dtpFechaInicio.Value > dtpFechaFin.Value Then
                msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
                Return
            End If

            Dim obj As New coMedicamentoRacion With {
                .Codigo = idPeriodoMedicacion,
                .FechaFin = dtpFechaFin.Value
            }

            Dim MensajeBgWk As String = cn.Cn_ActualizarFechaFinPeriodoMedicamentoRacion(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Dispose()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class