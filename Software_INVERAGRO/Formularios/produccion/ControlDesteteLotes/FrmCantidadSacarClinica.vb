Imports CapaNegocio
Imports CapaObjetos

Public Class FrmCantidadSacarClinica
    Dim cnLote As New cnControlLoteDestete
    Public idLote As Integer = 0
    Public cantidadNoPuras As Integer = 0
    Public tipo As String = ""
    Public idPlantel As Integer = 0

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If NumCantidadNoPuras.Value > cantidadNoPuras Then
                msj_advert("NO PUEDE SACAR DE CLÍNICA UNA CANTIDAD MAYOR A LA QUE DISPONE")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE RETIRAR A ESTOS ANIMALES DE CLÍNICA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .IdAnimal = Nothing,
                .IdLote = idLote,
                .CantidadTatuadas = If(tipo = "CAMBOROUGH", NumCantidadNoPuras.Value, 0),
                .CantidadVenta = If(tipo = "ENGORDE", NumCantidadNoPuras.Value, 0),
                .TipoFiltro = "NOPURA",
                .IdPlantel = idPlantel
            }

            Dim _mensaje As String = cnLote.Cn_RetirarAnimalClinica(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Me.Close()
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
End Class