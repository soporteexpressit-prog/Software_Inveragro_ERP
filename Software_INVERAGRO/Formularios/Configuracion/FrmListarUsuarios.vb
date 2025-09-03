Imports CapaNegocio

Public Class FrmListarUsuarios
    Private ReadOnly _frmAsignarPerfil As FrmAsignarPerfil
    Private ReadOnly _frmAsignarPerfilMovil As FrmAsignarPerfilMovil
    Dim cn As New cnAdministrarUsuarios
    Private SelectedRows As New List(Of DataRow)
    Public tipo As String = ""
    Public Sub New(frmAsignarPerfil As FrmAsignarPerfil)
        InitializeComponent()
        _frmAsignarPerfil = frmAsignarPerfil
    End Sub

    Public Sub New(frmAsignarPerfilMovil As FrmAsignarPerfilMovil)
        InitializeComponent()
        _frmAsignarPerfilMovil = frmAsignarPerfilMovil
    End Sub

    Private Sub FrmListarUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarTrabajadores()

        If _frmAsignarPerfil IsNot Nothing Then
            For Each row As DataRow In CType(dtgListado.DataSource, DataTable).Rows
                Dim codParticipante As Integer = CInt(row(0))
                If _frmAsignarPerfil.SelectedParticipants.Contains(codParticipante) Then
                    Dim gridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.Rows.Where(Function(r) r.Cells(0).Value = codParticipante).FirstOrDefault()
                    If gridRow IsNot Nothing Then
                        gridRow.Appearance.BackColor = Color.LightBlue
                    End If
                End If
            Next
        ElseIf _frmAsignarPerfilMovil IsNot Nothing Then
            For Each row As DataRow In CType(dtgListado.DataSource, DataTable).Rows
                Dim codParticipante As Integer = CInt(row(0))
                If _frmAsignarPerfilMovil.SelectedParticipants.Contains(codParticipante) Then
                    Dim gridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.Rows.Where(Function(r) r.Cells(0).Value = codParticipante).FirstOrDefault()
                    If gridRow IsNot Nothing Then
                        gridRow.Appearance.BackColor = Color.LightBlue
                    End If
                End If
            Next
        End If


    End Sub

    Sub ListarTrabajadores()
        Dim dt As DataTable = cn.Cn_ListarUsuariosxTipo(tipo)
        dtgListado.DataSource = dt
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.Rows.Count = 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If
        If e.Cell Is Nothing OrElse e.Cell.Row Is Nothing Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If

        If e.Cell.Row.Index < 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then

                Dim selectedRow As DataRow = CType(dtgListado.DataSource, DataTable).Rows(e.Cell.Row.Index)
                Dim codParticipante As Integer = CInt(selectedRow(0))

                dtgListado.Rows(e.Cell.Row.Index).Appearance.BackColor = Color.LightBlue

                If _frmAsignarPerfil IsNot Nothing Then
                    If Not _frmAsignarPerfil.SelectedParticipants.Contains(codParticipante) Then
                        _frmAsignarPerfil.SelectedParticipants.Add(codParticipante)
                        SelectedRows.Add(selectedRow)
                    End If
                ElseIf _frmAsignarPerfilMovil IsNot Nothing Then
                    If Not _frmAsignarPerfilMovil.SelectedParticipants.Contains(codParticipante) Then
                        _frmAsignarPerfilMovil.SelectedParticipants.Add(codParticipante)
                        SelectedRows.Add(selectedRow)
                    End If
                End If


            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        For Each row As DataRow In SelectedRows
            ' Crear una nueva fila
            Dim dr As DataRow = Nothing

            ' Verificar si estamos trabajando con FrmAsignarPerfil
            If _frmAsignarPerfil IsNot Nothing Then
                dr = _frmAsignarPerfil.DtDetalle.NewRow()
                dr("codUsuario") = row(0)
                dr("nombreUsuario") = row(1)
                dr("datos") = row(2)
                dr("btneliminar") = ""

                _frmAsignarPerfil.DtDetalle.Rows.Add(dr)
            ElseIf _frmAsignarPerfilMovil IsNot Nothing Then
                ' Lógica similar para FrmAsignarPerfilMovil (si tiene propiedad DtDetalle)
                dr = _frmAsignarPerfilMovil.DtDetalle.NewRow()
                dr("codUsuario") = row(0)
                dr("nombreUsuario") = row(1)
                dr("datos") = row(2)
                dr("btneliminar") = ""

                _frmAsignarPerfilMovil.DtDetalle.Rows.Add(dr)
            End If
        Next

        ' Confirmar los cambios
        If _frmAsignarPerfil IsNot Nothing Then
            _frmAsignarPerfil.DtDetalle.AcceptChanges()
        ElseIf _frmAsignarPerfilMovil IsNot Nothing Then
            _frmAsignarPerfilMovil.DtDetalle.AcceptChanges()
        End If

        ' Cerrar el formulario
        Me.Close()
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        ' Verificar si estamos trabajando con FrmAsignarPerfil
        If _frmAsignarPerfil IsNot Nothing Then
            If _frmAsignarPerfil.DtDetalle.Rows.Count = 0 Then
                _frmAsignarPerfil.SelectedParticipants.Clear()
            End If
        ElseIf _frmAsignarPerfilMovil IsNot Nothing Then
            ' Lógica similar para FrmAsignarPerfilMovil
            If _frmAsignarPerfilMovil.DtDetalle.Rows.Count = 0 Then
                _frmAsignarPerfilMovil.SelectedParticipants.Clear()
            End If
        End If

        ' Liberar los recursos
        Dispose()
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class