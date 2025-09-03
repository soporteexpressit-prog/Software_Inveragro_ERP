Imports CapaNegocio
Imports CapaObjetos

Public Class FrmActualizarPerfilMovil

    Dim cn As New cnAdministrarUsuarios
    Dim idUsuario As Integer
    Dim idPerfil As Integer

    Private Sub FrmActualizarPerfil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ListarUsuariosConPerfil()
            DeshabilitarTxt()
            Me.Size = New Size(1240, 690)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try

    End Sub
    Sub ListarUsuariosConPerfil()
        Try
            Dim dt As New DataTable
            dt = cn.Cn_ListarUsuariosConPerfilMovil
            dtgListado.DataSource = dt
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try

    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                Dim activeRow = dtgListado.ActiveRow
                If activeRow IsNot Nothing AndAlso activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(0).Value.ToString().Length <> 0 Then
                    If activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(1).Value IsNot Nothing AndAlso
                   activeRow.Cells(2).Value IsNot Nothing Then

                        LlenarCamposUsuario(
                        activeRow.Cells(0).Value.ToString(),
                        activeRow.Cells(1).Value.ToString(),
                        activeRow.Cells(2).Value.ToString()
                    )
                    Else
                        msj_advert("Algunas celdas no tienen valores válidos.")
                    End If
                Else
                    msj_advert("Seleccione un Perfil válido.")
                End If
            Else
                msj_advert("Seleccione un Perfil.")
            End If
        Catch ex As Exception
            clsBasicas.controlException("", ex)
        End Try
    End Sub

    Private Sub LlenarCamposUsuario(codUsuario As Integer, usuario As String, datos As String)
        idUsuario = codUsuario
        txtUsuario.Text = usuario
        txtDatos.Text = datos
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim f As New FrmListarPerfilesMovil(Me)
        f.ShowDialog()
    End Sub

    Public Sub LlenarCamposCapacitador(codigo As Integer, codPerfil As Integer, rol As String)
        idPerfil = codigo
        txtCodigo.Text = codPerfil
        txtRol.Text = rol
        DeshabilitarTxt()
    End Sub

    Sub DeshabilitarTxt()
        txtUsuario.Enabled = False
        txtRol.Enabled = False
        txtCodigo.Enabled = False
        txtDatos.Enabled = False
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try

            If idUsuario = 0 Then
                msj_advert("Seleccione un usuario.")
                Return
            End If

            If idPerfil = 0 Then
                msj_advert("Seleccione un perfil.")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE ACTUALIZAR EL PERFIL DEL USUARIO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coAdministrarUsuarios
            Dim msj As String
            obj.IdPersona = idUsuario
            obj.IdPerfil = idPerfil
            msj = cn.Cn_ActualizarPersonaxPerfil(obj)
            If obj.Coderror <> 0 Then
                msj_advert(msj)
            Else
                msj_ok(msj)
                ListarUsuariosConPerfil()
                LimpiarCampos()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub LimpiarCampos()
        txtUsuario.Text = ""
        txtRol.Text = ""
        txtCodigo.Text = ""
        txtDatos.Text = ""
        idPerfil = 0
        idUsuario = 0
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class