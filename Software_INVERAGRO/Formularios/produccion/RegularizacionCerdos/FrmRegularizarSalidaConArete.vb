Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRegularizarSalidaConArete
    Dim cn As New cnControlAnimal
    Dim tbtmp As New DataTable
    Public valorPlantel As String
    Public idPlantel As Integer
    Public idJaulaCorral As Integer
    Public idMotivoMortalidad As Integer
    Public idAnimal As Integer
    Public idLote As Integer

    Private Sub FrmRegularizarSalidaConArete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        LblPlantel.Text = valorPlantel
        DtpFechaControl.Value = Now.Date
        TxtAreteAnimal.ReadOnly = True
        TxtMotivoMortalidad.ReadOnly = True
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            Dim cantidad As Integer = 0

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR REGULARIZACIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAnimal With {
                .FechaControl = DtpFechaControl.Value,
                .Observacion = TxtObservacion.Text,
                .CantidadCrias = cantidad,
                .IdJaulaCorral = idJaulaCorral,
                .IdMotivoMortalidadCamal = idMotivoMortalidad,
                .Codigo = idAnimal,
                .IdUsuario = VP_IdUser,
                .IdCampaña = 0,
                .IdLote = idLote,
                .TipoControl = "SALIDA"
            }

            Dim MensajeBgWk As String = cn.Cn_RegistrarRegularizacionCerdosCodificado(obj)
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

    Public Sub LlenarCampoMotivoMortalidad(id As Integer, motivo As String)
        idMotivoMortalidad = id
        TxtMotivoMortalidad.Text = motivo
    End Sub

    Public Sub LlenarCampoMotivoAnimal(id As Integer, loteID As Integer, arete As String, idAmbiente As Integer)
        idAnimal = id
        idLote = loteID
        TxtAreteAnimal.Text = arete
        idJaulaCorral = idAmbiente
    End Sub

    Private Sub BtnMotivoMortalidad_Click(sender As Object, e As EventArgs) Handles BtnMotivoMortalidad.Click
        Try
            Dim frm As New FrmListarMotivoRegularCodificados(Me)
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscarAnimal_Click(sender As Object, e As EventArgs) Handles BtnBuscarAnimal.Click
        Try
            Dim frm As New FrmListarAnimalesCodificadosRegu(Me) With {
                .idPlantel = idPlantel
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class