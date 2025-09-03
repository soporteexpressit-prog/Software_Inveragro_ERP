Imports CapaNegocio
Imports CapaObjetos

Public Class FrmAplicarParticion
    Dim cn As New cnControlMaterialGenetico
    Public idMaterialGentico As Integer = 0
    Public numDosisInicial As Integer = 0
    Public numDosisUtilizadas As Integer = 0

    Private Sub FrmAplicarParticion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblDosisInicial.Text = numDosisInicial
        LblDosisUtilizadas.Text = numDosisUtilizadas
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If NumNuevaCantidad.Value <= 0 Then
                msj_advert("El número de dosis que va añadir debe ser mayor a 0")
                Exit Sub
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO ACTUALIZAR PARTICIÓN DE MATERIAL GENÉTICO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlMaterialGenetico With {
                .Codigo = idMaterialGentico,
                .Dosis = NumNuevaCantidad.Value,
                .IdUsuario = VP_IdUser
            }

            Dim MensajeBgWk As String = cn.Cn_ParticionDosisMaterialGenetico(obj)
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

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class