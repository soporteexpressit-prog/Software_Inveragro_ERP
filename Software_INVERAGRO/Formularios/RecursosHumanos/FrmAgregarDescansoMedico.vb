Imports System.IO
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmAgregarDescansoMedico
    Dim cn As New cnPermisoLaboral
    Dim idauditoria As Integer
    Public _operacion As Integer
    Public _idpermisolaboral As Integer
    Private _idPersona As Integer
    Private adelantodias As Boolean
    Public permisotipo As String
    Private Sub FrmAgregarDescansoMedico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        checkpendiete.Visible = False
        cbxventaVaca.Checked = False
        CargarComboboxes()
        If _operacion = 2 Then
            Consultar()
            cbtpdescanso.Enabled = False
        End If
    End Sub
    Private Sub CargarComboboxes()
        Try
            Dim dt As New DataTable
            Dim obj As New coPermisoLaboral
            obj.Descripcion = ""
            dt = cn.Cn_Consultarconceptos(obj).Copy
            dt.TableName = "tmp"
            dt.Columns(1).ColumnName = "Concepto"
            Dim newRow As DataRow = dt.NewRow()
            newRow(0) = 0 ' ID ficticio para evitar errores de conversión
            newRow(1) = "Seleccione un tipo de permiso"
            dt.Rows.InsertAt(newRow, 0)
            With cbtpdescanso
                .DataSource = dt
                .DisplayMember = "Concepto"
                .ValueMember = dt.Columns(0).ColumnName
                .SelectedIndex = 0 ' Seleccionar la opción por defecto
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Sub Consultar()
        Dim tb As New DataTable
        Dim obj As New coPermisoLaboral
        obj.idpermisolaboral = _idpermisolaboral
        tb = cn.Cn_Consultarpermisoporid(obj).Copy
        tb.TableName = "tmp"
        If tb.Rows.Count > 0 Then
            With tb.Rows(0)
                _idpermisolaboral = .Item(0).ToString()
                _idPersona = .Item(1).ToString()
                cbtpdescanso.SelectedValue = .Item(2).ToString()
                dtpFechaInicio.Value = .Item(3).ToString()
                dtpFechaFin.Value = .Item(4).ToString()
                lblDiasDiferencia.Text = .Item(5).ToString()
                idauditoria = .Item(6).ToString()
                txtmotivopermiso.Text = .Item(7).ToString()
                txtnombre.Text = .Item(8).ToString()
                txtdni.Text = .Item(9).ToString()
                txtcargo.Text = .Item(10).ToString()
                txtsexo.Text = .Item(11).ToString()
                txtedad.Text = .Item(12).ToString()
                checkpendiete.Checked = .Item(13).ToString()
                adelantodias = .Item(13).ToString()
                lb_dias_disponibles.Text = .Item(14).ToString()
                If .Item(15).ToString() = "SI" Then
                    cbxventaVaca.Checked = True
                Else
                    cbxventaVaca.Checked = False
                End If
            End With

        Else
            MessageBox.Show("No se encontró ningún registro con el código especificado.")
        End If
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged, dtpFechaFin.ValueChanged
        Dim diasDiferencia As Integer = (dtpFechaFin.Value - dtpFechaInicio.Value).Days + 1 ' Se suma 1 para incluir el día de inicio
        If diasDiferencia < 1 Then
            diasDiferencia = 0 ' Si el resultado es menor que 1, se establece en 0
        End If

        lblDiasDiferencia.Text = diasDiferencia.ToString()
    End Sub


    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        cbtpdescanso.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Private Sub cbtpdescanso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbtpdescanso.SelectedIndexChanged
        Dim diasDisponibles As Integer = 0
        Dim diasSolicitados As Integer = 0
        If cbtpdescanso.SelectedItem IsNot Nothing Then
            ' Verifica la opción seleccionada
            Select Case cbtpdescanso.SelectedValue.ToString()
                Case 1
                    ' Habilita txtCampo1 y deshabilita txtCampo2
                    txt_dias_pendientes.Visible = False
                    checkpendiete.Visible = False
                    lb_dias_disponibles.Visible = False
                    ct22.Clear()
                Case 2
                    ' Habilita txtCampo2 y deshabilita txtCampo1
                    txt_dias_pendientes.Visible = False
                    lb_dias_disponibles.Visible = False
                    checkpendiete.Visible = False
                    ct21.Visible = True
                    ct22.Visible = True
                    ct23.Visible = True
                Case 3
                    txt_dias_pendientes.Visible = True
                    checkpendiete.Visible = True
                    lb_dias_disponibles.Visible = True
                    If Not String.IsNullOrEmpty(lb_dias_disponibles.Text) AndAlso
                   Not String.IsNullOrEmpty(lblDiasDiferencia.Text) Then
                        diasDisponibles = Convert.ToInt32(lb_dias_disponibles.Text)
                        diasSolicitados = Convert.ToInt32(lblDiasDiferencia.Text)
                        checkpendiete.Visible = diasSolicitados > diasDisponibles
                    Else
                        checkpendiete.Visible = False
                    End If
                    ct21.Visible = False
                    ct22.Visible = False
                    ct23.Visible = False
                    ct22.Clear()
                Case Else
                    ' Deshabilita ambos campos en cualquier otra opción
                    checkpendiete.Visible = False
                    txt_dias_pendientes.Visible = False
                    lb_dias_disponibles.Visible = False
            End Select
        End If
    End Sub
    Private diasConsumidosAnterior As Integer = 0
    Private Sub dtpFechaFin_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged, dtpFechaFin.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
        If _operacion = 1 Then
            Dim diasDiferencia As Integer = DateDiff(DateInterval.Day, dtpFechaInicio.Value.Date, dtpFechaFin.Value.Date) + 1
            lblDiasDiferencia.Text = diasDiferencia.ToString()
            If cbtpdescanso.SelectedValue IsNot Nothing AndAlso cbtpdescanso.SelectedValue.ToString() = "3" Then
                If Not String.IsNullOrEmpty(lb_dias_disponibles.Text) Then
                    Dim diasDisponibles As Integer = Convert.ToInt32(lb_dias_disponibles.Text)
                    Dim diasSolicitados As Integer = Convert.ToInt32(lblDiasDiferencia.Text)
                    checkpendiete.Visible = diasSolicitados > diasDisponibles
                End If
            End If
        ElseIf _operacion = 2 Then
            If String.IsNullOrEmpty(lb_dias_disponibles.Text) Then
                msj_advert("Error: No hay un valor válido en días disponibles.")
                Exit Sub
            End If
            Dim diasDisponibles As Integer = Convert.ToInt32(lb_dias_disponibles.Text)
            Dim diasConsumidosNuevo As Integer = DateDiff(DateInterval.Day, dtpFechaInicio.Value.Date, dtpFechaFin.Value.Date) + 1
            Dim diferencia As Integer = diasConsumidosNuevo - diasConsumidosAnterior
            If diferencia > 0 Then
                diasDisponibles -= diferencia
            ElseIf diferencia < 0 Then
                diasDisponibles += Math.Abs(diferencia)
            End If
            If diasDisponibles < 0 Then
                diasDisponibles = 0
            End If
            lblDiasDiferencia.Text = diasConsumidosNuevo.ToString()
            lb_dias_disponibles.Text = diasDisponibles.ToString()
            diasConsumidosAnterior = diasConsumidosNuevo
            If cbtpdescanso.SelectedValue IsNot Nothing AndAlso cbtpdescanso.SelectedValue.ToString() = "3" Then
                checkpendiete.Visible = diasConsumidosNuevo > diasDisponibles
            End If
        End If
    End Sub
    Private Sub RecibirTrabajadorpermiso(selectedRow As DataRow)
        If selectedRow IsNot Nothing Then
            If selectedRow.Table.Columns.Contains("Cod.") Then
                Dim cod As String = selectedRow("Cod.").ToString()
                txtnombre.Text = cod
                Dim cn As New cnPermisoLaboral()
                _idPersona = Convert.ToInt32(cod)
                Dim datosIncidencia As coPermisoLaboral = cn.ObtenerDatosIncidenciapermiso(_idPersona)
                If datosIncidencia IsNot Nothing Then
                    txtnombre.Text = datosIncidencia.NombrePersona
                    txtdni.Text = datosIncidencia.DNI
                    txtedad.Text = datosIncidencia.Edad.ToString()
                    txtsexo.Text = datosIncidencia.Sexo
                    txtcargo.Text = datosIncidencia.Cargo
                    lb_dias_disponibles.Text = datosIncidencia.DiasPendientes
                    idauditoria = datosIncidencia.idauditoria
                Else '
                    msj_advert("No se encontraron datos para la persona seleccionada.")
                End If
            Else
                msj_advert("La columna 'Cod' no existe en la tabla.")
            End If
        Else
            msj_advert("La columna 'Cod' no existe en la tabla.")
        End If

    End Sub
    Private Sub RecibirTrabajador(selectedRow As DataRow)
        If selectedRow IsNot Nothing Then
            If selectedRow.Table.Columns.Contains("Cod.") Then
                Dim cod As String = selectedRow("Cod.").ToString()
                txtnombre.Text = cod
                Dim cn As New cnPermisoLaboral()
                _idPersona = Convert.ToInt32(cod)
                Dim datosIncidencia As coPermisoLaboral = cn.ObtenerDatosIncidencia(_idPersona)
                If datosIncidencia IsNot Nothing Then
                    txtnombre.Text = datosIncidencia.NombrePersona
                    txtdni.Text = datosIncidencia.DNI
                    txtedad.Text = datosIncidencia.Edad.ToString()
                    txtsexo.Text = datosIncidencia.Sexo
                    txtcargo.Text = datosIncidencia.Cargo
                Else '
                    msj_advert("No se encontraron datos para la persona seleccionada.")
                End If
            Else
                msj_advert("La columna 'Cod' no existe en la tabla.")
            End If
        Else
            msj_advert("La columna 'Cod' no existe en la tabla.")
        End If

    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If cbtpdescanso.SelectedItem IsNot Nothing Then
            Select Case cbtpdescanso.SelectedValue.ToString()
                Case 0
                    msj_advert("Seleccione un tipo de permiso.")
                Case 3
                    Dim frmListarpermisos As New FrmlistarTrabajadorespermisos(AddressOf RecibirTrabajadorpermiso)
                    frmListarpermisos.operacion = _operacion
                    frmListarpermisos.ShowDialog()
                Case Else
                    Dim frmListar As New FrmListarTrabajadorIF(AddressOf RecibirTrabajador)
                    frmListar.ShowDialog()
            End Select
        End If


    End Sub
    Private Sub LimpiartodosLosCampos()
        txtnombre.Clear()
        txtdni.Clear()
        txtcargo.Clear()
        txtedad.Clear()
        txtsexo.Clear()
        txtmotivopermiso.Clear()
        cbtpdescanso.SelectedIndex = -1
        dtpFechaInicio.Value = DateTime.Now
        dtpFechaFin.Value = DateTime.Now
        ct22.Clear()
    End Sub
    Private Sub guardar()
        Try
            Dim permiso As New coPermisoLaboral()
            permiso.operacion = _operacion
            permiso.idpermisolaboral = _idpermisolaboral
            permiso.TipoPermiso = cbtpdescanso.SelectedValue.ToString()
            permiso.IdPersona = _idPersona
            permiso.FechaInicio = dtpFechaInicio.Value
            permiso.FechaFin = dtpFechaFin.Value
            permiso.NumDias = lblDiasDiferencia.Text
            permiso.Descripcion = txtmotivopermiso.Text
            permiso.idauditoria = idauditoria
            permiso.ventaV = If(cbxventaVaca.Checked, "SI", "NO")
            If checkpendiete.Checked Then
                permiso.adelantoDias = 1
            Else
                permiso.adelantoDias = 0
            End If
            If Not String.IsNullOrEmpty(ct22.Text) Then
                Dim fileInfo3 As New FileInfo(ct22.Text)
                If fileInfo3.Length > 400 * 1024 Then
                    msj_advert("El archivo PDF excede el tamaño máximo permitido de 400 kB.")
                    Return
                End If
                Dim pdfData3 As Byte() = File.ReadAllBytes(ct22.Text)
                permiso.SetdocPaternidad(pdfData3)
            End If
            Dim cn As New cnPermisoLaboral()
            Dim resultado = cn.InsertarPermisoLaboral(permiso)
            If resultado.success Then
                MessageBox.Show(resultado.message, "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiartodosLosCampos()
                Me.Close()
            Else
                MessageBox.Show(resultado.message, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub ct23_Click(sender As Object, e As EventArgs) Handles ct23.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Archivos PDF|*.pdf|Todos los archivos|*.*"
        openFileDialog.Title = "Selecciona un archivo PDF"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = openFileDialog.FileName
            ct22.Text = selectedFilePath
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If String.IsNullOrEmpty(txtmotivopermiso.Text) Then
            msj_advert("Por favor, complete la descripción del permiso.")
            Return
        End If
        If cbtpdescanso.SelectedIndex = 0 Then
            msj_advert("Por favor, Seleccione una opción.")
            Return
        End If
        If dtpFechaInicio.Value > dtpFechaFin.Value Then
            msj_advert("La fecha de inicio debe ser anterior a la fecha de fin.")
            Return
        End If
        If adelantodias = True Then
            If cbtpdescanso.SelectedIndex = 3 Then
                If CInt(lblDiasDiferencia.Text) > CInt(lb_dias_disponibles.Text) AndAlso Not checkpendiete.Checked Then
                    msj_advert("Por favor, active la opción de adelanto de días")
                    Return
                End If
            End If
        Else
            If cbtpdescanso.SelectedIndex = 3 Then
                If CInt(lblDiasDiferencia.Text) > CInt(lb_dias_disponibles.Text) AndAlso Not checkpendiete.Checked Then
                    msj_advert("Por favor, active la opción de adelanto de días")
                    Return
                End If
            End If
        End If
        guardar()
    End Sub


End Class