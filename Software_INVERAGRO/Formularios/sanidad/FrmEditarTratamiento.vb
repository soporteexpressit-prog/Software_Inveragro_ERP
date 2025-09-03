Imports CapaNegocio
Imports CapaObjetos

Public Class FrmEditarTratamiento
    Public idDetTratamiento As Integer = 0
    Public nombreEnfermedad As String = ""
    Public nombreProducto As String = ""
    Public edadLote As String = ""
    Public observacion As String = ""
    Public estado As String = ""
    Dim cn As New cnEnfermedad

    Private Sub FrmEditarTratamiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        TxtEnfermedad.ReadOnly = True
        TxtProducto.ReadOnly = True
        TxtCodigo.ReadOnly = True
        TxtCodigo.Text = idDetTratamiento
        TxtEnfermedad.Text = nombreEnfermedad
        TxtProducto.Text = nombreProducto
        TxtEdadLote.Text = edadLote
        txtObservacion.Text = observacion
        CbEstado.SelectedIndex = CbEstado.FindString(estado)
        TxtEdadLote.Select()
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If TxtEdadLote.Text.Length = 0 Then
                msj_advert("Ingrese una dosis")
                TxtEdadLote.Select()
                Return
            ElseIf txtObservacion.Text.Length = 0 Then
                msj_advert("Ingrese una observación")
                txtObservacion.Select()
                Return
            Else

                If (MessageBox.Show("¿ESTÁ SEGURO DE ACTUALIZAR EL DETALLE DEL TRATAMIENTO RECOMENDADO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim obj As New coEnfermedad With {
                    .Codigo = idDetTratamiento,
                    .EdadLote = TxtEdadLote.Text,
                    .Observacion = txtObservacion.Text,
                    .Estado = CbEstado.Text
                }
                Dim _mensaje As String = cn.Cn_ActualizarDetalleTratamiento(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(_mensaje)
                    Dispose()
                Else
                    msj_advert(_mensaje)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

End Class