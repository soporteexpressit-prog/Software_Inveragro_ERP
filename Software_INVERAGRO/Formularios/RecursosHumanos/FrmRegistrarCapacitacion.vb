Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmRegistrarCapacitacion
    Dim cn As New cnControlCapacitacion
    Dim _CodCapacitador As Integer
    Dim _CodTema As Integer
    Public DtDetalle As New DataTable("TempDetParticipante")
    Public SelectedParticipants As New HashSet(Of Integer)
    Dim seleccionar1 As Boolean = False
    Dim seleccionar2 As Boolean = False
    Dim seleccionar3 As Boolean = False
    Dim seleccionar4 As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New FrmListarCapacitador(Me)
        f.ShowDialog()
    End Sub
    
    Public Sub LlenarCamposCapacitador(codigo As Integer, numDocumento As String, datos As String)
        _CodCapacitador = codigo
        txtNumDocCapa.Text = numDocumento
        txtDatosCapa.Text = datos
    End Sub

    Public Sub LlenarCamposTemario(codigo As Integer, tema As String, area As String)
        _CodTema = codigo
        txtTema.Text = tema
        txtAreaCapacitadora.Text = area
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlanteles().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbUbicacion
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub FrmRegistrarCapacitacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaCapacitacion.Value = Now.Date
        txtNumDocCapa.Enabled = False
        txtDatosCapa.Enabled = False
        txtAreaCapacitadora.Enabled = False
        txtTema.Enabled = False
        NumericUpDown1.Minimum = 3
        NumericUpDown1.Maximum = 4
        NumericUpDown1.Value = 3

        picEvidencia4.Visible = False
        btnSubirEvidencia4.Visible = False
        CargarTablaParticipantes()
        ListarTiposCapacitacion()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarPlanteles()
    End Sub

    Sub ListarTiposCapacitacion()
        Dim cn As New cnTipoCapacitacion
        Dim tb As New DataTable
        tb = cn.Cn_Listar().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Tipo de Capacitacion"
        With cmbTipoCapacitacion
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub CargarTablaParticipantes()
        DtDetalle = New DataTable("TempDetParticipante")
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim totalImagensEsperadas As Integer = NumericUpDown1.Value
            Dim imagenesCargadas As Integer = 0
            Dim carpetaCreada As Boolean = False
            Dim rutaCarpeta As String = Nothing

            If (dtpFechaCapacitacion.Value > Now.Date) Then
                msj_advert("La fecha de la capacitación no puede ser mayor a la fecha actual.")
                Return
            End If

            If (_CodCapacitador < 1) Then
                msj_advert("Seleccione un Capacitador")
            ElseIf (_CodTema < 1) Then
                msj_advert("Seleccione un Tema")
            ElseIf (dtgListado.Rows.Count = 0) Then
                msj_advert("Seleccione un Participante")
            Else

                If Not ckbOmitirEvidencia.Checked Then
                    If ValidarImagenSeleccionada() Then
                        Dim fechaHora As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
                        Dim nombreCarpeta As String = fechaHora
                        Dim rutaBase As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "evidencia_capacitaciones")
                        rutaCarpeta = Path.Combine(rutaBase, nombreCarpeta)

                        If Not Directory.Exists(rutaBase) Then
                            Directory.CreateDirectory(rutaBase)
                            carpetaCreada = True
                        End If

                        ' Verificar si la carpeta con la fecha existe, si no, crearla
                        If Not Directory.Exists(rutaCarpeta) Then
                            Directory.CreateDirectory(rutaCarpeta)
                            carpetaCreada = True
                        End If

                        If carpetaCreada Then
                            If seleccionar1 Then
                                GuardarImagen(picEvidencia1, rutaCarpeta, "Evidencia1")
                                imagenesCargadas += 1
                            End If

                            If seleccionar2 Then
                                GuardarImagen(picEvidencia2, rutaCarpeta, "Evidencia2")
                                imagenesCargadas += 1
                            End If

                            If seleccionar3 Then
                                GuardarImagen(picEvidencia3, rutaCarpeta, "Evidencia3")
                                imagenesCargadas += 1
                            End If

                            If totalImagensEsperadas = 4 AndAlso seleccionar4 Then
                                GuardarImagen(picEvidencia4, rutaCarpeta, "Evidencia4")
                                imagenesCargadas += 1
                            End If

                            If imagenesCargadas <> totalImagensEsperadas Then
                                msj_advert("No se han cargado todas las imágenes requeridas.")
                                Return
                            End If
                        End If
                    Else
                        Return
                    End If
                End If


                If (MessageBox.Show("¿ESTÁ SEGURO DE GUARDAR ESTA CAPACITACIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim obj As New coControlCapacitacion With {
                    .FechaCapacitacion = dtpFechaCapacitacion.Value,
                    .IdCapacitador = _CodCapacitador,
                    .IdTipoCapacitacion = cmbTipoCapacitacion.Value,
                    .IdUsuario = VP_IdUser,
                    .IdTemarioCapacitacion = _CodTema,
                    .Lista_items = creacion_de_arrary(),
                    .RutaEvidencia = If(ckbOmitirEvidencia.Checked, Nothing, rutaCarpeta),
                    .IdPlantel = CmbUbicacion.Value
                }

                Dim MensajeBgWk As String = cn.Cn_RegistrarCapacitacion(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Dispose()
                Else
                    msj_advert(MensajeBgWk)
                    carpetaCreada = False
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

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim f As New FrmListarParticipante(Me) With {
            .idPlantel = CmbUbicacion.Value
        }
        f.ShowDialog()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If NumericUpDown1.Value = 4 Then
            picEvidencia4.Visible = True
            btnSubirEvidencia4.Visible = True
        ElseIf NumericUpDown1.Value = 3 Then
            picEvidencia4.Visible = False
            btnSubirEvidencia4.Visible = False

            picEvidencia4.Image = Formularios.My.Resources.Resources.sinimagen
            picEvidencia4.Tag = Nothing
            seleccionar4 = False
        End If
    End Sub

    Private Sub btnSubirEvidencia1_Click(sender As Object, e As EventArgs) Handles btnSubirEvidencia1.Click
        CargarImagen(picEvidencia1, 1)
    End Sub

    Private Sub btnSubirEvidencia2_Click(sender As Object, e As EventArgs) Handles btnSubirEvidencia2.Click
        CargarImagen(picEvidencia2, 2)
    End Sub

    Private Sub btnSubirEvidencia3_Click(sender As Object, e As EventArgs) Handles btnSubirEvidencia3.Click
        CargarImagen(picEvidencia3, 3)
    End Sub

    Private Sub btnSubirEvidencia4_Click(sender As Object, e As EventArgs) Handles btnSubirEvidencia4.Click
        CargarImagen(picEvidencia4, 4)
    End Sub

    Private Sub CargarImagen(pic As PictureBox, numEvidencia As Integer)
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            pic.Image = Image.FromFile(openFileDialog.FileName)
            pic.Tag = openFileDialog.FileName

            If (numEvidencia = 1) Then
                seleccionar1 = True
            ElseIf (numEvidencia = 2) Then
                seleccionar2 = True
            ElseIf (numEvidencia = 3) Then
                seleccionar3 = True
            Else
                seleccionar4 = True
            End If
        End If
    End Sub

    Private Function ValidarImagenSeleccionada() As Boolean
        Dim totalImagensEsperadas As Integer = NumericUpDown1.Value

        If totalImagensEsperadas >= 1 AndAlso Not seleccionar1 Then
            msj_advert("Seleccione un archivo de evidencia 01. Debe cargar todas las imágenes antes de guardar.")
            Return False
        End If

        If totalImagensEsperadas >= 2 AndAlso Not seleccionar2 Then
            msj_advert("Seleccione un archivo de evidencia 02. Debe cargar todas las imágenes antes de guardar.")
            Return False
        End If

        If totalImagensEsperadas >= 3 AndAlso Not seleccionar3 Then
            msj_advert("Seleccione un archivo de evidencia 03. Debe cargar todas las imágenes antes de guardar.")
            Return False
        End If

        If totalImagensEsperadas = 4 AndAlso Not seleccionar4 Then
            msj_advert("Seleccione un archivo de evidencia 04. Debe cargar todas las imágenes antes de guardar.")
            Return False
        End If

        Return True
    End Function

    Private Sub GuardarImagen(pic As PictureBox, rutaCarpeta As String, nombreImagen As String)
        If pic.Image IsNot Nothing AndAlso pic.Tag IsNot Nothing Then
            Dim extension As String = Path.GetExtension(pic.Tag.ToString())
            Dim rutaDestino As String = Path.Combine(rutaCarpeta, nombreImagen & extension)
            pic.Image.Save(rutaDestino)
        End If
    End Sub

    Private Sub CmbUbicacion_ValueChanged(sender As Object, e As EventArgs) Handles CmbUbicacion.ValueChanged
        CargarTablaParticipantes()
        SelectedParticipants.Clear()
    End Sub

    Private Sub BtnBuscarAreaTema_Click(sender As Object, e As EventArgs) Handles BtnBuscarAreaTema.Click
        Try
            Dim f As New FrmListarTemario(Me)
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Dispose()
    End Sub
End Class