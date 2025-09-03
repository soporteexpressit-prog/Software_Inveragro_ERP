Imports CapaNegocio
Imports CapaObjetos
Imports Stimulsoft.Base.Json.Linq

Public Class FrmMantenimientoCliente
    Dim cn As New cnCliente
    Dim _mensajeBgWk As String = ""
    Dim _operacion As Integer = 0
    Public _Codigo As Integer = 0
    Dim api As New apiServices()
    Dim estadoContribuyente As String = ""
    Dim condicionContribuyente As String = ""
    Dim valorcbtipodoc As Integer = 0
    Private Sub FrmMantenimientoCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarTipoDocumento()
            ListarDepartamentos()
            cbxestado.SelectedIndex = 0
            cbxtipo.SelectedIndex = 1
            txtnumdoc.Select()

            If (_Codigo <> 0) Then
                _operacion = 1
                Consultar()
            Else
                cbxestado.SelectedIndex = 0
                cbxestado.Enabled = False
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Mantenimiento()
        Try
            If _operacion <> 1 AndAlso _operacion <> 2 OrElse txtCodigo.Text <> "" AndAlso txtCodigo.Text.Length <> 0 Then
                If _operacion = 0 OrElse _operacion = 1 Then
                    If cbtipodocidentidad.Value Is Nothing Then
                        msj_advert("Seleccione un Tipo de Documento de Identidad")
                        Return
                    End If

                    If txtnumdoc.Text.Length = 0 Then
                        txtnumdoc.Focus()
                        msj_advert("N° Documento no Válido")
                        Return
                    End If
                    If txtdatos.Text.Length = 0 Then
                        txtdatos.Focus()
                        msj_advert("Datos no Válidos")
                        Return
                    End If
                End If

                Dim obj As New coCliente
                obj.Operacion = _operacion
                obj.IdPersona = _Codigo
                obj.Tipo = cbxtipo.Text
                obj.NumDocumento = txtnumdoc.Text
                obj.Datos = txtdatos.Text
                obj.Direccion = txtdireccion.Text
                obj.Celular = txtcelular.Text
                obj.Correo = txtcorreo.Text
                obj.IdUsuario = 1
                obj.Estado = cbxestado.Text
                obj.IdTipoDocIdentidad = cbtipodocidentidad.Value
                obj.IdDistrito = idDistritoSeleccionado
                Dim result As DialogResult
                Dim continuar As Boolean = False

                If cbxtipodocidentidad.Text = "Registro Único de Contribuyentes" Then
                    Dim estadoValido As Boolean = String.IsNullOrEmpty(estadoContribuyente) OrElse estadoContribuyente = "ACTIVO"

                    Dim condicionValida As Boolean = String.IsNullOrEmpty(condicionContribuyente) OrElse condicionContribuyente = "HABIDO"

                    If estadoValido AndAlso condicionValida Then
                        result = MessageBox.Show("¿Estás seguro de que deseas continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        continuar = (result = DialogResult.Yes)
                    Else
                        result = MessageBox.Show("El contribuyente no se encuentra en estado ACTIVO o HABIDO.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        continuar = (result = DialogResult.Yes)
                    End If
                Else
                    result = MessageBox.Show("¿Estás seguro de que deseas continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    continuar = (result = DialogResult.Yes)
                End If

                If continuar Then
                    _mensajeBgWk = cn.Cn_Mantenimiento(obj)

                    If obj.Coderror = 0 Then
                        msj_ok(_mensajeBgWk)
                        Close()
                    Else
                        msj_advert(_mensajeBgWk)
                    End If
                End If
            Else
                msj_advert("Seleccione un Registro")
                Return
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub ListarTipoDocumento()
        Dim tb As New DataTable
        tb = cn.Cn_ListarTipoDocIdentidad().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Tipo Documento Identidad"
        With cbtipodocidentidad
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub
    Dim selectedDepartmentId As Integer
    Sub ListarDepartamentos()
        Dim cn As New cnCliente
        Dim tb As New DataTable
        tb = cn.ObtenerDepartamentos().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Nombre"
        With ComboBox1
            .DataSource = tb
            .DisplayMember = "Nombre"
            .ValueMember = "idDepartamento"
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Mantenimiento()
    End Sub
    Sub Consultar()
        Dim obj As New coCliente
        Dim cn As New cnCliente
        obj.IdPersona = _Codigo
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarxCodigo(obj).Copy
        tb.TableName = "tmp"

        If tb.Rows.Count > 0 Then
            With tb.Rows(0)
                txtCodigo.Text = .Item(0).ToString()
                cbxtipo.Text = .Item(1).ToString()
                txtnumdoc.Text = .Item(2).ToString()
                txtdatos.Text = .Item(3).ToString()
                txtdireccion.Text = .Item(7).ToString()
                txtcelular.Text = .Item(8).ToString()
                txtcorreo.Text = .Item(9).ToString()
                cbxestado.Text = .Item(34).ToString()
                cbtipodocidentidad.Value = .Item(17).ToString()
                valorcbtipodoc = .Item(17).ToString()
            End With
            Dim tbUbicacion As DataTable = cn.Cc_ConsultarxCodigoUbicacion(obj)
            If tbUbicacion.Rows.Count > 0 Then
                With tbUbicacion.Rows(0)
                    ComboBox1.Text = .Item("Departamento").ToString()
                    ComboBox2.Text = .Item("Provincia").ToString()
                    ComboBox3.Text = .Item("Distrito").ToString()
                End With
            Else
                MessageBox.Show("No se encontró la ubicación para el trabajador especificado.")
            End If
        Else
            MessageBox.Show("No se encontró ningún registro con el código especificado.")
        End If
    End Sub

    Private Async Sub btnbuscarsunat_Click(sender As Object, e As EventArgs) Handles btnbuscarsunat.Click
        If cbtipodocidentidad.Text = "Registro Único de Contribuyentes" Then

            If String.IsNullOrEmpty(txtnumdoc.Text) Or txtnumdoc.Text.Length < 11 Then
                msj_advert("Ingrese un RUC válido")
            Else
                Dim ser As JObject = Await api.ObtenerDatosProveedorRuc(txtnumdoc.Text)

                If ser IsNot Nothing Then
                    Dim razonSocial As String = ser("razonSocial")?.ToString()
                    Dim domicilioFiscal As String = ser("direccion")?.ToString()
                    Dim ubigeo As String = ser("ubigeo")?.ToString()
                    estadoContribuyente = ser("estado")?.ToString()
                    condicionContribuyente = ser("condicion")?.ToString()

                    If Not String.IsNullOrEmpty(razonSocial) Then
                        txtdatos.Text = razonSocial
                    End If

                    If Not String.IsNullOrEmpty(domicilioFiscal) Then
                        txtdireccion.Text = domicilioFiscal
                    End If

                    If Not String.IsNullOrEmpty(estadoContribuyente) Then
                        If estadoContribuyente = "ACTIVO" Then
                            lblEstado.BackColor = Color.LightGreen
                            lblEstado.ForeColor = Color.Black
                        Else
                            lblEstado.BackColor = Color.Red
                            lblEstado.ForeColor = Color.White
                        End If
                        lblEstado.Text = "ESTADO DEL CONTRIBUYENTE : " & estadoContribuyente
                    End If


                    If Not String.IsNullOrEmpty(condicionContribuyente) Then
                        If condicionContribuyente = "HABIDO" Then
                            lblCondicion.BackColor = Color.LightGreen
                            lblCondicion.ForeColor = Color.Black
                        Else
                            lblCondicion.BackColor = Color.Red
                            lblCondicion.ForeColor = Color.White
                        End If
                        lblCondicion.Text = "CONDICIÓN DEL CONTRIBUYENTE : " & condicionContribuyente
                    End If

                    If Not String.IsNullOrEmpty(ubigeo) Then
                        Dim obj As New coCliente
                        obj.Ubigeo = ubigeo.Trim()
                        Dim mensaje As String = cn.Cn_ConsUbicacionPorUbigeo(obj)
                        If obj.Coderror = 0 Then
                            ComboBox1.Text = obj.Departamento
                            ComboBox2.Text = obj.Provincia
                            ComboBox3.Text = obj.Distrito
                        End If
                    End If
                Else
                    msj_advert("No se encontraron datos para el RUC proporcionado.")
                End If
            End If
        Else
            If String.IsNullOrEmpty(txtnumdoc.Text) Or txtnumdoc.Text.Length < 8 Then
                msj_advert("Ingrese un DNI válido")
            Else
                Dim ser As JObject = Await api.ObtenerDatosPersonaDNI(txtnumdoc.Text)

                If ser IsNot Nothing Then
                    Dim razonSocial As String = ser("nombres")?.ToString() & " " & ser("apellidoPaterno")?.ToString() & " " & ser("apellidoMaterno")?.ToString()

                    If Not String.IsNullOrEmpty(razonSocial) Then
                        txtdatos.Text = razonSocial
                    End If
                Else
                    msj_advert("No se encontraron datos para el RUC proporcionado.")
                End If
            End If
        End If
    End Sub

    Private Sub cbxtipodocidentidad_AfterRowActivate(sender As Object, e As EventArgs) Handles cbxtipodocidentidad.ValueChanged
        Try
            If cbxtipodocidentidad.Text = "Registro Único de Contribuyentes" Or cbxtipodocidentidad.Text = "Documento de Identidad" Then
                btnbuscarsunat.Visible = True
                If cbxtipodocidentidad.Text = "Registro Único de Contribuyentes" Then
                    lblEstado.Visible = True
                    lblCondicion.Visible = True
                Else
                    lblEstado.Visible = False
                    lblCondicion.Visible = False
                End If
            Else
                btnbuscarsunat.Visible = False
            End If

            If cbxtipodocidentidad.ActiveRow IsNot Nothing Then
                If (_operacion = 0) Then
                    txtnumdoc.Clear()
                    txtdatos.Clear()
                    txtdireccion.Clear()
                End If
                Dim maxLengthValue As String = cbxtipodocidentidad.ActiveRow.Cells(2).Value.ToString()


                If IsNumeric(maxLengthValue) Then
                    txtnumdoc.MaxLength = Convert.ToInt32(maxLengthValue)
                Else
                    txtnumdoc.MaxLength = 0
                End If
            Else
                txtnumdoc.MaxLength = 0
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxtipodocidentidad_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cbxtipodocidentidad.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(2).Hidden = True
                .Columns(1).Width = 250
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex <> -1 Then
            Dim selectedRow As DataRowView = TryCast(ComboBox1.SelectedItem, DataRowView)
            If selectedRow IsNot Nothing Then
                Dim idDepartamento As Integer = Convert.ToInt32(selectedRow("idDepartamento"))
                CargarProvincias(idDepartamento)
            End If
        End If
    End Sub
    Sub CargarProvincias(idDepartamento As Integer)
        Dim cn As New cnCliente
        Dim tb As New DataTable
        tb = cn.ObtenerProvincias(idDepartamento).Copy
        tb.TableName = "tmpProvincias"
        With ComboBox2
            .DataSource = tb
            .DisplayMember = "nombre"
            .ValueMember = "idProvincia"
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex <> -1 Then
            Dim selectedRow As DataRowView = TryCast(ComboBox2.SelectedItem, DataRowView)
            If selectedRow IsNot Nothing Then
                Dim idProvincia As Integer = Convert.ToInt32(selectedRow("idProvincia"))
                CargarDistritos(idProvincia)
            End If
        End If
    End Sub
    Sub CargarDistritos(idProvincia As Integer)
        Dim cn As New cnCliente
        Dim tb As New DataTable
        tb = cn.ObtenerDistritos(idProvincia).Copy
        tb.TableName = "tmpDistritos"
        With ComboBox3
            .DataSource = tb
            .DisplayMember = "nombre"
            .ValueMember = "idDistrito"
            .SelectedIndex = -1
        End With
    End Sub
    Private idDistritoSeleccionado As Integer
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.SelectedIndex <> -1 Then
            Dim selectedRow As DataRowView = TryCast(ComboBox3.SelectedItem, DataRowView)
            If selectedRow IsNot Nothing Then
                idDistritoSeleccionado = Convert.ToInt32(selectedRow("idDistrito"))
            End If
        End If
    End Sub
    Private Sub txtnumdoc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumdoc.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub UltraGroupBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub UltraCombo1_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(2).Hidden = True
                .Columns(1).Width = 250
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbtipodocidentidad_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cbtipodocidentidad.InitializeLayout

    End Sub

    Private Sub txtnumdoc_TextChanged(sender As Object, e As EventArgs) Handles txtnumdoc.TextChanged
        Dim maxLength As Integer = 0
        Dim valorevisar As Integer = 0
        If (_Codigo <> 0) Then
            valorevisar = valorcbtipodoc
        Else
            valorevisar = cbtipodocidentidad.SelectedRow.Cells(0).Value
        End If

        Select Case valorevisar
            Case 1
                maxLength = 8
            Case 2
                maxLength = 9
            Case 3
                maxLength = 12
            Case 4
                maxLength = 11
            Case Else
                maxLength = 0
        End Select
        If maxLength > 0 Then
            txtnumdoc.Text = New String(txtnumdoc.Text.Where(Function(c) Char.IsDigit(c)).ToArray())
            If txtnumdoc.Text.Length > maxLength Then
                txtnumdoc.Text = txtnumdoc.Text.Substring(0, maxLength)
                txtnumdoc.SelectionStart = txtnumdoc.Text.Length ' Mantener el cursor al final
            End If
        End If
    End Sub

    Private Sub txtcelular_TextChanged(sender As Object, e As EventArgs) Handles txtcelular.TextChanged
        txtcelular.Text = System.Text.RegularExpressions.Regex.Replace(txtcelular.Text, "[^\d]", "")
        If txtcelular.Text.Length > 9 Then
            txtcelular.Text = txtcelular.Text.Substring(0, 9)
            txtcelular.SelectionStart = txtcelular.Text.Length ' Mantiene el cursor al final
        End If
    End Sub

End Class