Imports System.IO
Imports System.Net
Imports System.Net.Mail

Public Class MailService
    Private ReadOnly smtpServer As String
    Private ReadOnly smtpPort As Integer
    Private ReadOnly smtpUser As String
    Private ReadOnly smtpPassword As String
    Private ReadOnly enableSsl As Boolean

    Public Sub New(server As String, port As Integer, user As String, password As String, ssl As Boolean)
        smtpServer = server
        smtpPort = port
        smtpUser = user
        smtpPassword = password
        enableSsl = ssl
    End Sub

    Public Sub SendEmail(toAddress As String, subject As String, bodyHtml As String, Optional fromName As String = "Sistema de Notificaciones")
        Try
            Using mailMessage As New MailMessage()
                mailMessage.From = New MailAddress(smtpUser, fromName)
                mailMessage.To.Add(toAddress)
                mailMessage.Subject = subject
                mailMessage.Body = bodyHtml
                mailMessage.IsBodyHtml = True

                Using smtpClient As New SmtpClient(smtpServer, smtpPort)
                    smtpClient.Credentials = New NetworkCredential(smtpUser, smtpPassword)
                    smtpClient.EnableSsl = enableSsl

                    smtpClient.Send(mailMessage)
                End Using
            End Using

            Console.WriteLine("Correo enviado correctamente.")
        Catch ex As SmtpException
            Throw New Exception($"Error SMTP: {ex.Message}")
        Catch ex As Exception
            Throw New Exception($"Error al enviar el correo: {ex.Message}")
        End Try
    End Sub

    Public Sub SendEmailWithAttachment(toAddress As String, subject As String, bodyHtml As String,
                                  attachmentPath As String,
                                  Optional fromName As String = "PEDIDO INVERAGRO S.A.C")
        Try
            Using mailMessage As New MailMessage()
                mailMessage.From = New MailAddress(smtpUser, fromName)
                mailMessage.To.Add(toAddress)
                mailMessage.Subject = subject
                mailMessage.Body = bodyHtml
                mailMessage.IsBodyHtml = True

                ' Add attachment if the file exists
                If Not String.IsNullOrEmpty(attachmentPath) AndAlso File.Exists(attachmentPath) Then
                    Dim attachment As New Attachment(attachmentPath)
                    mailMessage.Attachments.Add(attachment)
                End If

                Using smtpClient As New SmtpClient(smtpServer, smtpPort)
                    smtpClient.Credentials = New NetworkCredential(smtpUser, smtpPassword)
                    smtpClient.EnableSsl = enableSsl
                    smtpClient.Send(mailMessage)
                End Using
            End Using
            Console.WriteLine("Correo con archivo adjunto enviado correctamente.")
        Catch ex As SmtpException
            Throw New Exception($"Error SMTP: {ex.Message}")
        Catch ex As Exception
            Throw New Exception($"Error al enviar el correo con archivo adjunto: {ex.Message}")
        End Try
    End Sub
End Class
