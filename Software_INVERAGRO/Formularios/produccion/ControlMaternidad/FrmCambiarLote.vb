Imports CapaNegocio
Imports CapaObjetos

Public Class FrmCambiarLote
    Dim cn As New cnControlLoteDestete
    Public idUbicacion As Integer = 0
    Dim idCerda As Integer = 0
    Dim idLoteAnimal As Integer = 0

    Private Sub FrmCambiarLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtLote.ReadOnly = True
    End Sub

    Private Sub BtnAsignarLote_Click(sender As Object, e As EventArgs) Handles BtnAsignarLote.Click
        Try
            Dim frm As New FrmListarLoteCambio(Me) With {
                .idUbicacion = idUbicacion
            }
            frm.ShowDialog()

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCambioLote(codigo As Integer, descripcion As String, fApertura As String, fCierre As String)
        idLoteAnimal = codigo
        TxtLote.Text = descripcion
        LblFechaApertura.Text = fApertura
        LblFechaCierre.Text = fCierre
    End Sub

    Private Sub BtnGuardarLote_Click(sender As Object, e As EventArgs) Handles BtnGuardarLote.Click
        Try
            If idCerda = 0 Then
                msj_advert("Seleccione una cerda para cambiar del lote")
                Return
            End If

            If (idLoteAnimal = 0) Then
                msj_advert("selecciona una lote")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE CAMBIAR DEL LOTE A ESTA CERDA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .IdLote = idLoteAnimal,
                .IdAnimal = idCerda
            }
            Dim MensajeBgWk As String = cn.Cn_CambiarLoteCerdaCrias(obj)
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

    Private Sub BtnBuscarCerda_Click(sender As Object, e As EventArgs) Handles BtnBuscarCerda.Click
        Try
            Dim frm As New FrmListarCerdasCambiarLote(Me) With {
                .idPlantel = idUbicacion
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposCerda(id As Integer, codigo As String)
        idCerda = id
        LblCodArete.Text = codigo
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Dispose()
    End Sub
End Class