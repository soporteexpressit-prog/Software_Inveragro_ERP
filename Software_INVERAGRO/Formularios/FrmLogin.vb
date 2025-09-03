Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Text
Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmLogin
    Dim formMenu As New FrmMenu()
    Dim cn As New cnLogin()
    Dim obj As New coLogin()
    Public Property IdPersona As Integer
    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtusuario.Text = "Usuario"
        txtusuario.ForeColor = Color.Gray
        RtnProduccion.Checked = True

        txtclave.Text = "Contraseña"
        txtclave.ForeColor = Color.Gray
        If txtclave.Text = "" Then
            txtclave.Text = "Contraseña"
            txtclave.ForeColor = Color.Gray
        End If
        txtclave.PasswordChar = "*"c
        txtusuario.Select()
    End Sub
    Private Sub ConfigurarPermisos(formMenu As FrmMenu, tipoUsuario As String, idPersona As Integer)
        Dim modulos As List(Of (NombreBoton As String, Estado As Boolean)) = cn.ObtenerModulosPorUsuario(idPersona)

        For Each modulo In modulos
            Dim control As ToolStripMenuItem = BuscarMenuItemPorNombre(formMenu.MenuStrip1, modulo.NombreBoton)
            If control IsNot Nothing Then
                control.Visible = modulo.Estado
            End If
        Next
        If tipoUsuario = "ADMINISTRADOR" Then
            Dim formAdministrador As New FrmMenu()
        ElseIf tipoUsuario = "TRABAJADOR" Then
            HabilitarSubModulos(formMenu, idPersona, 1)
            HabilitarSubModulos(formMenu, idPersona, 2)
            formMenu.BackColor = Color.LightGray
        End If
    End Sub

    Private Async Sub btningresar_Click(sender As Object, e As EventArgs) Handles btningresar.Click
        If String.IsNullOrWhiteSpace(txtusuario.Text) OrElse txtusuario.Text = "Usuario" Then
            MessageBox.Show("Por favor, ingrese su usuario.", "Validación de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtusuario.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtclave.Text) OrElse txtclave.Text = "Contraseña" Then
            MessageBox.Show("Por favor, ingrese su contraseña.", "Validación de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtclave.Focus()
            Return
        End If
        Dim hashClaveIngresada As String = ConvertirClaveSHA256(txtclave.Text)
        Dim resultado As (tipoUsuario As String, idPersona As Integer, debeCambiarContraseña As Boolean, mensaje As String, nombre As String) =
        cn.ValidarInicioSesion(txtusuario.Text, hashClaveIngresada)
        obj.TipoUsuario = resultado.tipoUsuario
        obj.IdPersona = resultado.idPersona
        obj.DebeCambiarClave = resultado.debeCambiarContraseña
        obj.Usuario = txtusuario.Text
        If obj IsNot Nothing Then
            GlobalReferences.ActiveSessionId = obj.IdPersona
            GlobalReferences.nombreuser = resultado.nombre
            VariablesGlobales.VP_IdUser = obj.IdPersona
        End If
        GlobalReferences.loginFormInstance = Me

        ' Verificar permisos antes de continuar
        Dim permisos = cn.ObtenerModulosPorUsuario(obj.IdPersona)


        If obj.TipoUsuario = "ADMINISTRADOR" Then
            Dim formAdministrador As New FrmMenu()
            Me.Hide()
            formAdministrador.ShowDialog()
        Else
            Dim mensaje As String = resultado.mensaje
            If Not String.IsNullOrEmpty(mensaje) Then
                MessageBox.Show(mensaje, "Validación de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf permisos Is Nothing OrElse permisos.Count = 0 Then
                MessageBox.Show("El usuario no tiene permisos activados", "Sin permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If mensaje = Nothing Then
                If obj.DebeCambiarClave Then
                    Dim frmCambioContraseña As New CambiarClave(obj.IdPersona)
                    frmCambioContraseña.ShowDialog()
                    Return
                End If
                If permisos Is Nothing OrElse permisos.Count = 0 Then
                    MessageBox.Show("El usuario no tiene permisos activados", "Sin permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                Select Case obj.TipoUsuario
                    Case "TRABAJADOR"
                        'formMenu.toolConfiguracion.Enabled = False
                        ConfigurarPermisos(formMenu, obj.TipoUsuario, obj.IdPersona)
                        Me.Hide()
                        formMenu.ShowDialog()
                End Select
            End If
        End If
    End Sub

    Private Function ConvertirClaveSHA256(clave As String) As String
        Using sha256 As SHA256 = sha256.Create()
            Dim inputBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(clave)
            Dim hashBytes As Byte() = sha256.ComputeHash(inputBytes)
            Dim hashString As New StringBuilder()
            hashString.Append("0x")
            For Each byteValue As Byte In hashBytes
                hashString.Append(byteValue.ToString("X2"))
            Next
            Return hashString.ToString()
        End Using
    End Function
    Private Function BuscarMenuItemPorNombreRecursivo(item As ToolStripItem, itemName As String) As ToolStripMenuItem
        Dim menuItem As ToolStripMenuItem = TryCast(item, ToolStripMenuItem)
        ' Si es un ToolStripMenuItem y coincide el nombre, devolverlo
        If menuItem IsNot Nothing AndAlso menuItem.Name = itemName Then
            Return menuItem
        End If
        ' Buscar recursivamente en los submenús
        If menuItem IsNot Nothing Then
            For Each subItem As ToolStripItem In menuItem.DropDownItems
                Dim foundItem As ToolStripMenuItem = BuscarMenuItemPorNombreRecursivo(subItem, itemName)
                If foundItem IsNot Nothing Then
                    Return foundItem
                End If
            Next
        End If

        Return Nothing
    End Function
    Private Function BuscarMenuItemPorNombre(menu As MenuStrip, itemName As String) As ToolStripMenuItem
        For Each item As ToolStripItem In menu.Items
            Dim foundItem As ToolStripMenuItem = BuscarMenuItemPorNombreRecursivo(item, itemName)
            If foundItem IsNot Nothing Then
                Return foundItem
            End If
        Next
        Return Nothing
    End Function
    Private Sub HabilitarSubModulos(formMenu As FrmMenu, idPersona As Integer, nivel As Integer)
        Dim submodulos As List(Of (NombresubBoton As String, Estado As Boolean)) =
        If(nivel = 1, cn.ObtenerSubModulos1PorUsuario(idPersona),
           cn.ObtenerSubModulos2PorUsuario(idPersona))

        If submodulos Is Nothing OrElse submodulos.Count = 0 Then
            Exit Sub ' 
        End If

        Dim toolStrips As ToolStripMenuItem() = {
        formMenu.toolAlmacen,
        formMenu.toolCompras,
        formMenu.toolContabilidad,
        formMenu.toolMolino,
        formMenu.toolNutricion,
        formMenu.toolProduccion,
        formMenu.toolRRHH,
        formMenu.toolSanidad,
        formMenu.toolVentas,
        formMenu.toolSegPersonal,
        formMenu.toolConfiguracion
    }

        For Each submodulo In submodulos
            Dim control As ToolStripMenuItem = toolStrips _
            .Select(Function(tool) BuscarMenuItemPorNombreRecursivo(tool, submodulo.NombresubBoton)) _
            .FirstOrDefault(Function(item) item IsNot Nothing)
            If control IsNot Nothing Then
                control.Visible = submodulo.Estado

            End If
        Next
    End Sub

    Private Sub txtusuario_GotFocus(sender As Object, e As EventArgs) Handles txtusuario.GotFocus
        If txtusuario.Text = "Usuario" Then
            txtusuario.Text = ""
            txtusuario.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtUsuario_LostFocus(sender As Object, e As EventArgs) Handles txtusuario.LostFocus
        If txtusuario.Text = "" Then
            txtusuario.Text = "Usuario"
            txtusuario.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtclave.GotFocus
        If txtclave.Text = "Contraseña" Then
            txtclave.Text = ""
            txtclave.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtPassword_LostFocus(sender As Object, e As EventArgs) Handles txtclave.LostFocus
        If txtclave.Text = "" Then
            txtclave.Text = "Contraseña"
            txtclave.ForeColor = Color.Gray
        End If
        txtclave.PasswordChar = "*"c
    End Sub
    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub txtclave_KeyDown(sender As Object, e As KeyEventArgs) Handles txtclave.KeyDown
        If (e.KeyData = Keys.Enter) Then
            btningresar.PerformClick()
        End If
    End Sub

    Private Sub txtusuario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtusuario.KeyDown
        If (e.KeyData = Keys.Enter) Then
            txtclave.Select()
        End If
    End Sub

    Private Sub RbtTest_CheckedChanged(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub RbtLive_CheckedChanged(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnverclave_Click(sender As Object, e As EventArgs) Handles btnverclave.Click
        If txtclave.PasswordChar = "*"c Then
            txtclave.PasswordChar = ControlChars.NullChar ' Muestra la contraseña
            btnverclave.Image = My.Resources.ojo_abierto ' Cambia al icono de ojo abierto
        Else
            txtclave.PasswordChar = "*"c ' Oculta la contraseña
            btnverclave.Image = My.Resources.ojo_cerrado ' Cambia al icono de ojo cerrado
        End If
    End Sub

    Private Sub RtnProduccion_CheckedChanged(sender As Object, e As EventArgs) Handles RtnProduccion.CheckedChanged
        If RtnProduccion.Checked Then
            cdConexion.EsProduccion = True
        End If
    End Sub

    Private Sub RtnPruebas_CheckedChanged(sender As Object, e As EventArgs) Handles RtnPruebas.CheckedChanged
        If RtnPruebas.Checked Then
            msj_advert("Atención: Has seleccionado el entorno de PRUEBAS. Los datos que ingreses no afectarán la información real del sistema.")
            cdConexion.EsProduccion = False
        End If
    End Sub
End Class