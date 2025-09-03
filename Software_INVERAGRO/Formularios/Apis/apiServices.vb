Imports System.Net
Imports System.Net.Http
Imports Stimulsoft.Base.Json.Linq

Public Class apiServices
    Public Async Function ObtenerDatosProveedorRuc(nrodoc As String) As Task(Of JObject)
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim url As String = $"https://dniruc.apisperu.com/api/v1/ruc/{nrodoc}?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6InNvcG9ydGVAcGVyc29uYWx0b29scy5wZSJ9.y1MFyHl02Mo8fYPbDXfbEwEd2WZM3E_YO1wVEEqpCig"

        Using client As New HttpClient()
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))

            Try
                Dim response As HttpResponseMessage = Await client.GetAsync(url)
                If response.IsSuccessStatusCode Then
                    Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                    Dim ser As JObject = JObject.Parse(responseBody)

                    Return ser
                ElseIf response.StatusCode = HttpStatusCode.Unauthorized Then
                    MessageBox.Show("Autenticación fallida. Verifique su token de autorización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return Nothing
                Else
                    Return Nothing
                End If
            Catch ex As HttpRequestException
                MessageBox.Show("Error en la conexión: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            Catch ex As Exception
                MessageBox.Show("Error inesperado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try
        End Using
    End Function

    Public Async Function ObtenerDatosPersonaDNI(nrodoc As String) As Task(Of JObject)
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim url As String = $"https://api.apis.net.pe/v2/reniec/dni?numero={nrodoc}"
        Dim token As String = "apis-token-13023.B576X4E0yA0l15z80SMLYrwXIFFX0GMr"

        Using client As New HttpClient()
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
            client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Bearer", token)

            Try
                Dim response As HttpResponseMessage = Await client.GetAsync(url)

                If response.IsSuccessStatusCode Then
                    Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                    Dim ser As JObject = JObject.Parse(responseBody)

                    Return ser
                ElseIf response.StatusCode = HttpStatusCode.Unauthorized Then
                    MessageBox.Show("Autenticación fallida. Verifique su token de autorización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return Nothing
                Else
                    MessageBox.Show("Error al obtener datos: " & response.ReasonPhrase, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return Nothing
                End If
            Catch ex As HttpRequestException
                MessageBox.Show("Error en la conexión: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            Catch ex As Exception
                MessageBox.Show("Error inesperado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try
        End Using
    End Function

End Class
