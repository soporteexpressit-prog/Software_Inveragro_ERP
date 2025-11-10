Imports CapaObjetos

Public Class FrmFinalizarVenta
    Public idCampaña As Integer = 0
    Public nombrePlantel As String = ""

    Private Sub FrmFinalizarVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LblPlantel.Text = nombrePlantel
            DtpFechaFinVenta.Value = Date.Now
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnGuardarLote_Click(sender As Object, e As EventArgs) Handles BtnGuardarLote.Click
        Try
            If (MessageBox.Show("¿ESTÁ SEGURO DE ESTA REALIZAR ESTA ACCIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            'Dim obj As New coControlLoteDestete With {
            '    .Operacion = operacion,
            '    .IdLote = idLote,
            '    .Anio = CInt(CmbAnios.Text),
            '    .FechaDesde = DtpFechaApertura.Value,
            '    .FechaHasta = DtpFechaCierre.Value,
            '    .NumeroLote = NumeroLote.Value,
            '    .Estado = CmbEstado.Text,
            '    .IdPlantel = CmbUbicacion.Value
            '}

            'Dim _mensaje As String = cn.Cn_MantenimientoLote(obj)
            'If (obj.Coderror = 0) Then
            '    msj_ok(_mensaje)
            '    Dispose()
            'Else
            '    msj_advert(_mensaje)
            'End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Dispose()
    End Sub
End Class