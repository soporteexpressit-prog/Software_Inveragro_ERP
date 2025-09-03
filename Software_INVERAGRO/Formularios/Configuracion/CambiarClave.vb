Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class CambiarClave
    Private idPersona As Integer
    Public Sub New(idPersona As Integer)
        InitializeComponent()
        Me.idPersona = idPersona ' Asignamos el valor a la variable local
    End Sub
    Private Function ValidarContraseña(nuevaContraseña As String, confirmarContraseña As String) As String
        ' Validaciones de contraseña
        If nuevaContraseña.Length < 8 Then
            Return "La contraseña debe tener al menos 8 caracteres."
        ElseIf Not Regex.IsMatch(nuevaContraseña, "[a-z]") Then
            Return "La contraseña debe contener al menos una letra minúscula."
        ElseIf Not Regex.IsMatch(nuevaContraseña, "[A-Z]") Then
            Return "La contraseña debe contener al menos una letra mayúscula."
        ElseIf Not Regex.IsMatch(nuevaContraseña, "[0-9]") Then
            Return "La contraseña debe contener al menos un número."
        ElseIf Not Regex.IsMatch(nuevaContraseña, "[@._#]") Then
            Return "La contraseña debe incluir al menos uno de los siguientes caracteres especiales: @, ., _, #."
        ElseIf nuevaContraseña <> confirmarContraseña Then
            Return "Las contraseñas no coinciden."
        End If

        Return "" ' Sin errores
    End Function

    Private Sub btningresar_Click(sender As Object, e As EventArgs) Handles btningresar.Click
        Dim nuevaContraseña As String = txtclave.Text
        Dim confirmarContraseña As String = TextBox1.Text
        Dim clave As String = ConvertirClaveSHA256(txtclave.Text)
        ' Dim mensaje As String = ValidarContraseña(nuevaContraseña, confirmarContraseña)
        Dim mensaje As String = ""
        If mensaje = "" Then
            Dim cn As New cnLogin()
            Dim obj As New coLogin With {
                        .IdPersona = idPersona,
                        .clave = clave
                    }
            Dim actualizado As String = cn.actualizarclave(obj)
            If (obj.Coderror = 0) Then
                msj_ok(actualizado)
                DialogResult = DialogResult.OK
                Me.Close()
            Else
                msj_advert(actualizado)
            End If
            Dispose()

        Else
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Function ConvertirClaveSHA256(clave As String) As String
        Using sha256 As SHA256 = sha256.Create()
            Dim inputBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(clave)
            Dim hashBytes As Byte() = sha256.ComputeHash(inputBytes)
            Dim hashString As New StringBuilder()
            hashString.Append("0x")
            For Each byteValue As Byte In hashBytes
                hashString.Append(byteValue.ToString("X2")) ' "X2" convierte a formato hexadecimal en mayúsculas
            Next
            Return hashString.ToString()
        End Using
    End Function

    Private Sub CambiarClave_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
