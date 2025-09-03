Imports CapaNegocio
Imports CapaObjetos
Public Class FrmDeterminacionCausas
    Private Shared _instance As FrmDeterminacionCausas
    Public Shared ReadOnly Property Instance As FrmDeterminacionCausas
        Get
            If _instance Is Nothing Then
                _instance = New FrmDeterminacionCausas()
            End If
            Return _instance
        End Get
    End Property
    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtcodigoCI.TextChanged
        Dim caracteresRestantes As Integer = 250 - txtcodigoCI.Text.Length
        lblContador.Text = "250/" & caracteresRestantes.ToString()
        lblContador.Location = New Point(txtcodigoCI.Location.X + txtcodigoCI.Width - lblContador.Width, txtcodigoCI.Location.Y + txtcodigoCI.Height + 3)
    End Sub
    Private Sub txtdescripcionCI_TextChanged(sender As Object, e As EventArgs) Handles txtdescripcionCI.TextChanged
        Dim caracteresRestantes As Integer = 250 - txtdescripcionCI.Text.Length
        lblContador1.Text = "250/" & caracteresRestantes.ToString()
        lblContador1.Location = New Point(txtdescripcionCI.Location.X + txtdescripcionCI.Width - lblContador1.Width, txtdescripcionCI.Location.Y + txtdescripcionCI.Height + 3)
    End Sub
    Private Sub txtcodigoCB_TextChanged(sender As Object, e As EventArgs) Handles txtcodigoCB.TextChanged
        Dim caracteresRestantes As Integer = 250 - txtcodigoCB.Text.Length
        lblContador2.Text = "250/" & caracteresRestantes.ToString()
        lblContador2.Location = New Point(txtcodigoCB.Location.X + txtcodigoCB.Width - lblContador2.Width, txtcodigoCB.Location.Y + txtcodigoCB.Height + 3)
    End Sub
    Private Sub txtdescripCB_TextChanged(sender As Object, e As EventArgs) Handles txtdescripCB.TextChanged
        Dim caracteresRestantes As Integer = 250 - txtdescripCB.Text.Length
        lblContador3.Text = "250/" & caracteresRestantes.ToString()
        lblContador3.Location = New Point(txtdescripCB.Location.X + txtdescripCB.Width - lblContador3.Width, txtdescripCB.Location.Y + txtdescripCB.Height + 3)
    End Sub
    Public Function CrearArrayList() As List(Of String)
        Dim listaValores As New List(Of String)()
        If Not String.IsNullOrWhiteSpace(txtcsci.Text) Then
            listaValores.Add($"Tipo 1:{txtcsci.Text}")
        End If
        If Not String.IsNullOrWhiteSpace(txtasci.Text) Then
            listaValores.Add($"Tipo 1:{txtasci.Text}")
        End If
        If Not String.IsNullOrWhiteSpace(txtcodigoCI.Text) Then
            listaValores.Add($"Tipo 1:{txtcodigoCI.Text}")
        End If
        If Not String.IsNullOrWhiteSpace(txtdescripcionCI.Text) Then
            listaValores.Add($"Tipo 1:{txtdescripcionCI.Text}")
        End If
        If Not String.IsNullOrWhiteSpace(txtftcb.Text) Then
            listaValores.Add($"Tipo 2:{txtftcb.Text}")
        End If
        If Not String.IsNullOrWhiteSpace(txtfpcb.Text) Then
            listaValores.Add($"Tipo 2:{txtfpcb.Text}")
        End If
        If Not String.IsNullOrWhiteSpace(txtcodigoCB.Text) Then
            listaValores.Add($"Tipo 2:{txtcodigoCB.Text}")
        End If
        If Not String.IsNullOrWhiteSpace(txtdescripCB.Text) Then
            listaValores.Add($"Tipo 2:{txtdescripCB.Text}")
        End If
        If Not String.IsNullOrWhiteSpace(txtcodfc.Text) Then
            listaValores.Add($"Tipo 3:{txtcodfc.Text}")
        End If
        If Not String.IsNullOrWhiteSpace(txtfaltafc.Text) Then
            listaValores.Add($"Tipo 3:{txtfaltafc.Text}")
        End If
        Return listaValores
    End Function
    Public listaIncidentesTemporales As New List(Of coControlincidencia)()
    Public listaCausas As List(Of String)
    Private Sub btnGuardarmodelu_Click(sender As Object, e As EventArgs) Handles btnGuardarmodelu.Click
        listaCausas = CrearArrayList()
        If listaCausas Is Nothing OrElse listaCausas.Count = 0 Then
            MessageBox.Show("No hay datos para guardar. Por favor, complete la información de causas.")
            Return
        End If
        MessageBox.Show("Guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

End Class