Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmRegistrarSCTR
    Dim cn As New cnControlSeguro
    Public DtDetalle As New DataTable("TempDetAsegurado")
    Public SelectedParticipants As New HashSet(Of Integer)
    Dim _CodProveedorSeguro As Integer
    Private Sub FrmRegistrarSCTR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializar()
        ListarTipoSeguro()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub
    Sub ListarTipoSeguro()
        Dim cn As New cnTipoSeguro
        Dim tb As New DataTable
        tb = cn.Cn_Listar().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Tema de Capacitación"
        With cmbTipoSeguro
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub
    Sub Inicializar()
        txtNumDocumento.Text = ""
        txtNumContratoSalud.Text = ""
        dtpFechaEmision.Value = Now.Date
        dtpFechaInicio.Value = Now.Date
        dtpFechaFin.Value = Now.Date
        txtArchivo.Enabled = False
        txtEmpresaAseguradora.Enabled = False
        txtNumDocProveedor.Enabled = False
        CargarTablaAsegurados()
    End Sub
    Sub CargarTablaAsegurados()
        DtDetalle = New DataTable("TempDetAsegurado")
        DtDetalle.Columns.Add("codParticipante", GetType(Integer))
        DtDetalle.Columns.Add("nroDocumento", GetType(String))
        DtDetalle.Columns.Add("datos", GetType(String))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        dtgListado.DataSource = DtDetalle
    End Sub
    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este Trabajador?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim f As New FrmListarAsegurado(Me)
        f.ShowDialog()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If String.IsNullOrWhiteSpace(txtNumDocumento.Text) Then
                msj_advert("Numero de documento es un campo requerido")
            ElseIf String.IsNullOrWhiteSpace(txtNumContratoSalud.Text) Then
                msj_advert("Numero de documento de salud es un campo requerido")
            ElseIf dtpFechaInicio.Value < dtpFechaEmision.Value Then
                msj_advert("La fecha de inicio no puede ser menor a la fecha de Emisión")
            ElseIf dtpFechaFin.Value < dtpFechaEmision.Value Then
                msj_advert("La fecha de fin no puede ser menor a la fecha de Emisión")
            ElseIf dtpFechaFin.Value < dtpFechaInicio.Value Then
                msj_advert("La fecha de fin no puede ser menor a la fecha de inicio")
            ElseIf String.IsNullOrWhiteSpace(txtNumDocProveedor.Text) Then
                msj_advert("Seleccione una Aseguradora")
            ElseIf dtgListado.Rows.Count = 0 Then
                msj_advert("Seleccione un Asegurado")
            Else
                Dim obj As New coControlSeguro

                obj.NumDocumento = txtNumDocumento.Text
                obj.NumContratoSalud = txtNumContratoSalud.Text
                obj.FechaEmision = dtpFechaEmision.Value
                obj.FechaInicio = dtpFechaInicio.Value
                obj.FechaFin = dtpFechaFin.Value
                obj.IdProveedorSeguro = _CodProveedorSeguro
                obj.IdUser = VP_IdUser
                obj.IdTipoSeguro = cmbTipoSeguro.Value
                If Not String.IsNullOrEmpty(txtArchivo.Text) Then
                    Dim fileInfo As New FileInfo(txtArchivo.Text)
                    If fileInfo.Length > 400 * 1024 Then
                        msj_advert("El archivo excede el tamaño máximo permitido de 400 kB.")
                        Return
                    End If
                    Dim pdfData As Byte() = File.ReadAllBytes(txtArchivo.Text)
                    obj.SetArchivo(pdfData)
                End If
                obj.Lista_items = creacion_de_arrary()

                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_RegistrarSeguroSCTR(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Dispose()
                Else
                    msj_advert(MensajeBgWk)
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
                    With dtgListado.Rows(i)
                        array_valvulas = array_valvulas & .Cells(0).Value.ToString.Replace(".", "_") & "+" &
                            .Cells(3).Value.ToString.Trim & ","
                    End With
                End If
            Next
            If (dtgListado.Rows.Count = 1) Then
                array_valvulas = array_valvulas & ","
            End If
            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub btnBuscarAseguradora_Click(sender As Object, e As EventArgs) Handles btnBuscarAseguradora.Click
        Dim f As New FrmListarAseguradora(Me)
        f.ShowDialog()
    End Sub

    Public Sub LlenarCamposAseguradora(codigo As Integer, numDocumento As String, datos As String)
        _CodProveedorSeguro = codigo
        txtNumDocProveedor.Text = numDocumento
        txtEmpresaAseguradora.Text = datos
    End Sub

    Private Sub btnSubirArchivo_Click(sender As Object, e As EventArgs) Handles btnSubirArchivo.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Archivos PDF|*.pdf|Todos los archivos|*.*"
        openFileDialog.Title = "Selecciona un archivo PDF"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = openFileDialog.FileName
            txtArchivo.Text = selectedFilePath
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class