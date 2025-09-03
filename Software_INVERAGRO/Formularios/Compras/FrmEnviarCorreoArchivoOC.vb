Imports CapaNegocio
Imports CapaObjetos
Imports System.IO

Public Class FrmEnviarCorreoArchivoOC
    Dim cn As New cnIngreso
    Public productosPedir As New List(Of String)
    Public correoRemitente As String
    Public correoDestinatario As String
    Public idIngreso As Integer
    Public fechaPedido As Date
    Public claveApliGoogle As String

    Private Sub FrmEnviarCorreoArchivoOC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReconstruirMensaje()
        txtArchivo.ReadOnly = True
        LblRemitente1.Text = correoRemitente
        TxtDestinatario1.Text = correoDestinatario.Trim()
        LblRemitente2.Text = correoRemitente
        TxtDestinatario2.Text = correoDestinatario.Trim()
    End Sub

    Private Sub ReconstruirMensaje()
        Dim momentoDia As String = clsBasicas.ObtenerMomentoDelDia()
        Dim saludo As String = ""
        Dim proximoDiaEnvio As String = CalcularProximoDiaEnvio(fechaPedido)

        If momentoDia = 1 Then
            saludo = "Buenos días"
        ElseIf momentoDia = 2 Then
            saludo = "Buenas tardes"
        ElseIf momentoDia = 3 Then
            saludo = "Buenas noches"
        End If

        TxtEncabezadoCorreo.Text = saludo & " señores." & Environment.NewLine &
                               "Por medio del presente hacemos el siguiente pedido, para el día " & proximoDiaEnvio & Environment.NewLine

        If productosPedir.Any() Then
            TxtCuerpoCorreo.Text = String.Join(Environment.NewLine, productosPedir) & Environment.NewLine
        Else
            TxtCuerpoCorreo.Text = ""
        End If

        TxtPieCorreo.Text = "El destino será Chiclayo, enviarlo a nombre de:" & Environment.NewLine &
                        "Nancy Rojas Visalot DNI: 08161197" & Environment.NewLine &
                        "Erick Espinoza Sánchez DNI: 42555387" & Environment.NewLine &
                        "# 949924090" & Environment.NewLine &
                        "Gracias." & Environment.NewLine
    End Sub

    Private Function CalcularProximoDiaEnvio(fechaActual As Date) As String
        Dim diaSemana As DayOfWeek = fechaActual.DayOfWeek
        Dim proximaFecha As Date

        Select Case diaSemana
            Case DayOfWeek.Thursday, DayOfWeek.Sunday
                proximaFecha = fechaActual

            Case DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday
                proximaFecha = fechaActual.AddDays(4 - CInt(diaSemana))

            Case DayOfWeek.Friday, DayOfWeek.Saturday
                proximaFecha = fechaActual.AddDays(7 - CInt(diaSemana))
        End Select

        Return proximaFecha.ToString("dddd dd", System.Globalization.CultureInfo.GetCultureInfo("es-ES"))
    End Function


    Private Sub btnSubirArchivo_Click(sender As Object, e As EventArgs) Handles btnSubirArchivo.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Archivos PDF|*.pdf|Todos los archivos|*.*"
        openFileDialog.Title = "Selecciona un archivo PDF"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = openFileDialog.FileName
            txtArchivo.Text = selectedFilePath
        End If
    End Sub

    Private Sub BtnEnviarCorreo_Click(sender As Object, e As EventArgs) Handles BtnEnviarCorreo.Click
        Try
            Dim pestañaActiva As String = TabControl1.SelectedTab.Name

            If claveApliGoogle = "" Then
                msj_advert("No se ha configurado la clave de aplicación de Google.")
                Return
            End If

            If TxtCuerpoCorreo.Text = " " Then
                msj_advert("No se ha ingresado el cuerpo del correo.")
                Return
            End If

            If pestañaActiva = "SegundoFormato" Then
                If String.IsNullOrWhiteSpace(TxtCuerpoCorreoArchivo.Text) Then
                    msj_advert("No se ha ingresado el cuerpo del correo.")
                    Return
                End If

                If String.IsNullOrWhiteSpace(txtArchivo.Text) Then
                    msj_advert("Debe adjuntar un archivo antes de enviar el correo.")
                    Return
                End If
            End If

            Select Case pestañaActiva
                Case "SegundoFormato"
                    Dim destinatarioSinEspacios2 As String = TxtDestinatario2.Text.Replace(" ", "").Trim()
                    Dim archivoAdjunto As String = txtArchivo.Text

                    ' Check if a file is selected
                    If Not String.IsNullOrEmpty(archivoAdjunto) Then
                        Dim fileInfo As New FileInfo(archivoAdjunto)

                        ' Check file size
                        If fileInfo.Length > 1000 * 1024 Then
                            msj_advert("El archivo excede el tamaño máximo permitido de 1000 kB.")
                            Return
                        End If
                    End If

                    If (MessageBox.Show("¿ESTÁ SEGURO DE ENVIAR ESTE CORREO A " & destinatarioSinEspacios2 & "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    ' Configuración del servicio de correo
                    Dim mailService As New MailService(
                        "smtp.gmail.com", ' Servidor SMTP
                        587,              ' Puerto SMTP
                        correoRemitente,  ' Correo remitente
                        claveApliGoogle,  ' Contraseña específica de aplicación
                        True              ' Habilitar SSL/TLS
                    )

                    ' Construir el mensaje final concatenando los textos de las cajas
                    Dim mensajeHTML As New Text.StringBuilder()
                    mensajeHTML.AppendLine($"<p>{TxtCuerpoCorreoArchivo.Text}</p>")

                    ' Enviar el correo con el contenido de las cajas de texto y el archivo adjunto
                    mailService.SendEmailWithAttachment(
                        destinatarioSinEspacios2,   ' Correo destinatario
                        "Solicitud de Pedido",     ' Asunto
                        mensajeHTML.ToString(),    ' Cuerpo del correo en HTML
                        archivoAdjunto             ' Ruta del archivo adjunto
                    )
                Case Else
                    Dim destinatarioSinEspacios1 As String = TxtDestinatario1.Text.Replace(" ", "").Trim()

                    If (MessageBox.Show("¿ESTÁ SEGURO DE ENVIAR ESTE CORREO A " & destinatarioSinEspacios1 & "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    ' Configuración del servicio de correo
                    Dim mailService As New MailService(
                        "smtp.gmail.com", ' Servidor SMTP
                        587,              ' Puerto SMTP
                        correoRemitente,  ' Correo remitente
                        claveApliGoogle,  ' Contraseña específica de aplicación
                        True                      ' Habilitar SSL/TLS
                    )

                    ' Construir el mensaje final concatenando los textos de las cajas
                    Dim mensajeHTML As New Text.StringBuilder()

                    mensajeHTML.AppendLine($"<p>{TxtEncabezadoCorreo.Text}</p>")
                    mensajeHTML.AppendLine($"<p>{TxtCuerpoCorreo.Text}</p>")
                    mensajeHTML.AppendLine($"<p>{TxtPieCorreo.Text}</p>")

                    ' Enviar el correo con el contenido de las cajas de texto
                    mailService.SendEmail(
                        destinatarioSinEspacios1,   ' Correo destinatario
                        "Solicitud de Pedido", ' Asunto
                        mensajeHTML.ToString(), ' Cuerpo del correo en HTML
                        "PEDIDO INVERAGRO S.A.C" ' Nombre del remitente (opcional)
                    )
            End Select

            ' Registrar el envío en la base de datos
            Dim obj As New coIngreso With {
                .Codigo = idIngreso
            }

            Dim MensajeBgWk As String = cn.Cn_EnviarCorreoOrdenCompra(obj)

            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Dispose()
            Else
                msj_advert(MensajeBgWk)
            End If

        Catch ex As Exception
            MessageBox.Show($"Error al enviar el correo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class