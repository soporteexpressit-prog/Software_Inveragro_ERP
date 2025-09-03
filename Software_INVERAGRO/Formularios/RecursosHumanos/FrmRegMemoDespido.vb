Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmRegMemoDespido
    Dim _CodMotivoMemoDespido As Integer
    Dim cn As New cnControlMemoDespido
    Dim numRegistrosMemo = cn.Cn_ComprobarNumRegistrosMemo()
    Dim numRegistrosDespido = cn.Cn_ComprobarNumRegistrosDespido()
    Dim tipo As String = ""
    Public SelectedTrabajadores As New HashSet(Of Integer)
    Public DtDetalle As New DataTable("TempDetTrabajadores")

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim f As New FrmListarTrabajador(Me)
        f.ShowDialog()
    End Sub

    Private Sub FrmRegMemoDespido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializar()
        CargarTablaTrabajadores()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Sub CargarTablaTrabajadores()
        DtDetalle = New DataTable("TempDetTrabajadores")
        DtDetalle.Columns.Add("codParticipante", GetType(Integer))
        DtDetalle.Columns.Add("nroDocumento", GetType(String))
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
                SelectedTrabajadores.Remove(codParticipante)
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
                .Columns(1).Header.Caption = "N° Documento"
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

    Private Sub Inicializar()
        rbMemorandum.Checked = True
        dtpFechaEmision.Value = Now.Date
        txtMotivo.Text = ""
        txtMotivo.Enabled = False
        txtNivel.Enabled = False
    End Sub

    Private Sub TextNumMemo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextNumMemoDesp.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub btnBuscarMemo_Click(sender As Object, e As EventArgs) Handles btnBuscarMemo.Click
        Dim f As New FrmListarMotivosMemoDespido(Me)
        f.tipo = tipo
        f.ShowDialog()
    End Sub

    Public Sub LlenarCamposMotivoMemo(codigo As Integer, motivo As String, nivel As String)
        _CodMotivoMemoDespido = codigo
        txtMotivo.Text = motivo
        txtNivel.Text = nivel
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (TextNumMemoDesp.Text.Length = 0) Then
                msj_advert("Ingrese el Número de Memorándum")
            ElseIf (dtgListado.Rows.Count = 0) Then
                msj_advert("Seleccione al menos un Trabajador")
            ElseIf (_CodMotivoMemoDespido < 1) Then
                msj_advert("Seleccione el Motivo por el cual se esta asignando el Memorándum")
            Else

                Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea registrar el memorándum/despido?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    Dim obj As New coControlMemoDespido
                    obj.NumMemoDespido = TextNumMemoDesp.Text
                    obj.FechaEmision = dtpFechaEmision.Value
                    obj.IdMotivoMemoDespido = _CodMotivoMemoDespido
                    obj.IdsTrabajador = creacion_de_arrary()
                    obj.IdUsuario = VP_IdUser
                    obj.Tipo = tipo

                    Dim MensajeBgWk As String = ""
                    MensajeBgWk = cn.Cn_Registrar(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(MensajeBgWk)
                        Dispose()
                    Else
                        msj_advert(MensajeBgWk)
                    End If
                Else
                    Return
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function creacion_de_arrary() As String
        Dim array_valvulas As String = ""

        If (dtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgListado.Rows.Count - 1
                If (dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    array_valvulas &= dtgListado.Rows(i).Cells(0).Value.ToString.Trim & ","
                End If
            Next

            array_valvulas = array_valvulas.TrimEnd(","c)
        End If

        Return array_valvulas
    End Function


    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim f As New FrmListarTrabajador(Me)
        f.ShowDialog()
    End Sub

    Private Sub rbMemorandum_CheckedChanged(sender As Object, e As EventArgs) Handles rbMemorandum.CheckedChanged
        If rbMemorandum.Checked Then
            tipo = "MEMORANDUM"
            If (numRegistrosMemo = 1) Then
                Dim siguienteNum = cn.Cn_ObtenerSiguienteNumMemorandum()
                TextNumMemoDesp.ReadOnly = True
                TextNumMemoDesp.Text = siguienteNum
            Else
                TextNumMemoDesp.Text = ""
                TextNumMemoDesp.ReadOnly = False
            End If
            txtMotivo.Text = ""
            _CodMotivoMemoDespido = 0
            txtNivel.Text = ""
        End If
    End Sub

    Private Sub rbDespido_CheckedChanged(sender As Object, e As EventArgs) Handles rbDespido.CheckedChanged
        If rbDespido.Checked Then
            tipo = "DESPIDO"
            If (numRegistrosDespido = 1) Then
                Dim siguienteNum = cn.Cn_ObtenerSiguienteNumDespido()
                TextNumMemoDesp.ReadOnly = True
                TextNumMemoDesp.Text = siguienteNum

            Else
                TextNumMemoDesp.Text = ""
                TextNumMemoDesp.ReadOnly = False
            End If
            txtMotivo.Text = ""
            _CodMotivoMemoDespido = 0
            txtNivel.Text = ""
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class