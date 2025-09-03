Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmAsignarPerfilMovil
    Public SelectedParticipants As New HashSet(Of Integer)
    Public DtDetalle As New DataTable("TempDetUsuario")
    Dim idPerfil As Integer
    Dim cn As New cnAdministrarUsuarios()

    Private Sub FrmAsignarPerfil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CargarTablaUsuarios()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            DeshabilitarTxt()
            Me.Size = New Size(1240, 690)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub CargarTablaUsuarios()
        DtDetalle = New DataTable("TempDetUsuario")
        DtDetalle.Columns.Add("codUsuario", GetType(Integer))
        DtDetalle.Columns.Add("nombreUsuario", GetType(String))
        DtDetalle.Columns.Add("datos", GetType(String))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        dtgListado.DataSource = DtDetalle
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este Participante?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                Dim codParticipante As Integer = CInt(dtgListado.Rows(rowIndex).Cells(0).Value)

                DtDetalle.Rows.RemoveAt(rowIndex)
                SelectedParticipants.Remove(codParticipante)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle
            End If
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "Codigo"
                .Columns(0).Width = 70
                .Columns(1).Header.Caption = "Usuario"
                .Columns(1).Width = 200
                .Columns(2).Header.Caption = "Datos"
                .Columns(2).Width = 190
                .Columns(3).Header.Caption = "Eliminar"
                .Columns(3).Width = 60
                .Columns(3).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(3).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(3).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim f As New FrmListarUsuarios(Me)
        f.tipo = "MOVIL"
        f.ShowDialog()
    End Sub

    Public Function ObtenerCodigos() As String
        Dim codigos As String = ""

        For Each row As UltraGridRow In dtgListado.Rows
            Dim codigo As String = row.Cells("codUsuario").Value.ToString()
            codigos &= codigo & ","
        Next

        Return codigos
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
        txtCodigo.Enabled = False
        txtRol.Enabled = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim msj As String
        Dim codPerfil As Integer
        Dim obj As New coAdministrarUsuarios

        If (MessageBox.Show("¿ESTÁ SEGURO DE ASIGNAR EL PERFIL?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
            Return
        End If

        If Integer.TryParse(txtCodigo.Text, codPerfil) Then
            obj.IdPerfil = codPerfil
            obj.Lista_Personas = ObtenerCodigos()
            msj = cn.Cn_AsignarPerfilAPersona(obj)
            Console.WriteLine("IdPerfil: " & idPerfil)
            Console.WriteLine("Lista de Personas: " & obj.Lista_Personas)
            If obj.Coderror <> 0 Then
                msj_advert(msj)
                Dispose()
            Else
                msj_ok(msj)
            End If
        Else
            msj_advert("Por favor, introduce un número válido.")
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class