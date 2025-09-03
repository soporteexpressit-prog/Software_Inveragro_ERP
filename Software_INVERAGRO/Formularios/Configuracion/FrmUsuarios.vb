Imports System.Security.Cryptography
Imports System.Text
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmUsuarios

    Dim cn As New cnUsuarios
    Private _CodPersona As Integer
    Dim _Operacion As Integer
    Private Sub FrmUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cancelar()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarPersonasConUsuarioClave()
    End Sub
    Sub ListarPersonasConUsuarioClave()
        Try
            Dim dt As New DataTable
            dt = cn.Cn_ListarPersonasConUsuarioClave().Copy
            dtgListado.DataSource = dt
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Crear()
        _Operacion = 0
        Cambio()
        Limpiar()
    End Sub

    Sub Limpiar()

        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _CodPersona = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodPersona.ToString
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If

        txtUsuario.Text = ""
        txtClave.Text = ""
        txtUsuario.Select()

        GenerarNombreUsuario()
    End Sub

    Sub Cambio()
        btnNuevo.Visible = False
        btnEditar.Visible = False
        btnGuardar.Visible = True
        btnCancelar.Visible = True
        txtUsuario.Enabled = False
        txtClave.Enabled = True
    End Sub

    Sub Cancelar()
        btnNuevo.Visible = True
        btnEditar.Visible = True
        btnGuardar.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtUsuario.Clear()
        txtUsuario.Enabled = False
        txtClave.Clear()
        txtClave.Enabled = False
    End Sub

    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (_Operacion = 1 OrElse _Operacion = 2) AndAlso (txtCodigo.Text = "" OrElse txtCodigo.Text.Length = 0) Then
                msj_advert("Seleccione un Registro")
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtUsuario.Text = "" OrElse txtUsuario.Text.Length = 0) AndAlso (txtClave.Text = "" OrElse txtClave.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If
            Dim obj As New coUsuarios
            obj.Operacion = _Operacion
            obj.Codigo = _CodPersona
            obj.Usuario = txtUsuario.Text
            ' Convertir la clave a un hash (Byte())
            obj.Clave = ConvertirClaveSHA256(txtClave.Text)
            obj.cambiarclave = If(CheckBox1.Checked, 1, 0) ' Asignar 1 si está marcado, 0 si no
            _mensaje = cn.Cn_Mantenimiento(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Cancelar()
                ListarPersonasConUsuarioClave()
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub GenerarNombreUsuario()
        If dtgListado.Rows.Count > 0 AndAlso dtgListado.ActiveRow IsNot Nothing Then
            Dim usuario As String = dtgListado.ActiveRow.Cells(6).Value.ToString() ' Nombre

            txtUsuario.Text = usuario
        End If
    End Sub

    Private Sub GenerarClave()

        If String.IsNullOrWhiteSpace(txtCodigo.Text) OrElse String.IsNullOrWhiteSpace(txtUsuario.Text) Then
            msj_advert("El código y el usuario no pueden estar vacíos.")
            Return
        End If

        If dtgListado.Rows.Count > 0 AndAlso dtgListado.ActiveRow IsNot Nothing Then
            Dim numeroDocumento As String = dtgListado.ActiveRow.Cells(6).Value.ToString()
            txtClave.Text = numeroDocumento
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    ' La función ConvertirClaveSHA256 ya devuelve un Byte(), que es lo esperado para el procedimiento almacenado
    Private Function ConvertirClaveSHA256(clave As String) As Byte()
        Using sha256 As SHA256 = SHA256.Create()
            ' Convertir el texto a bytes y calcular el hash
            Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(clave)
            Dim hashBytes As Byte() = sha256.ComputeHash(inputBytes)
            Return hashBytes
        End Using
    End Function
    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        GenerarClave()
    End Sub

    Private Sub btnNuevo_Click_1(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Crear()
    End Sub
    Private Sub btnEditar_Click_1(sender As Object, e As EventArgs) Handles btnEditar.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodPersona = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodPersona.ToString
                txtUsuario.Text = dtgListado.DisplayLayout.ActiveRow.Cells(4).Value.ToString
                txtUsuario.Focus()
                txtClave.Text = ""
                txtClave.Focus()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub
    Private Sub btnCancelar_Click_1(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub
    Private Sub btnGuardar_Click_1(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Mantenimiento()
    End Sub
    Private Sub btnCerrar_Click_1(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Dim isFilterActive As Boolean = Not btnFiltrar.Checked
        btnFiltrar.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub


End Class