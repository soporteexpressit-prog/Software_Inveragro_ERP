Imports CapaNegocio
Imports CapaObjetos
Imports Stimulsoft.Base.Json.Linq
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.IO
Imports CapaDatos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Stimulsoft.Base.StiDbType
Public Class Mant_Conductores
    Dim api As New apiServices()
    Dim cn_item As New cnTrabajador
    Dim _mensajeBgWk As String = ""
    Public _operacion As Integer = 0
    Dim _codtipodoc As Integer = 0
    Public _Codigo As Integer = 0
    Public idcontrato As Integer = 0
    Dim vista As New DataView
    Dim _estado As String = ""
    Dim imagefoto As Byte() = Nothing
    Dim imagefirma As Byte() = Nothing
    Dim ds As New DataSet
    Dim idDistrito As Integer
    Dim idOcupacion As Integer
    Private loadNewImageFoto As Boolean = False
    Private leadNewImageFirma As Boolean = False
    Private DtDetalle As New DataTable("TemPDerechoHabiento")
    Public contadorClicsGuardar As Integer = 0
    Public _tipotrabajador As String = ""
    Private Sub Mant_Conductores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If (_Codigo = 0) Then
                Me.Size = New Size(1200, 300)
            Else
                Me.Size = New Size(1200, 300)
            End If
            ListarTipoDocumento()
            ListarDocPasaporte()
            cbxestadocivil.SelectedIndex = 0
            cbxsexo.SelectedIndex = 0
            cbxtipo.SelectedIndex = 0
            If (_Codigo <> 0) Then
                _operacion = 1
                Consultar()
            Else
                cbxestado.SelectedIndex = 0
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub ListarDocPasaporte()
        Dim dt As New DataTable
        dt = cn_item.Cn_ListarPasaportes().Copy
        dt.TableName = "tmp"
        dt.Columns(2).ColumnName = "Seleccione un País"
        With cbxListarPasaporte
            .DataSource = dt
            .DisplayMember = dt.Columns(2).ColumnName
            .ValueMember = dt.Columns(0).ColumnName
            If (dt.Rows.Count > 0) Then
                .Value = dt.Rows(15)(0)
            End If
        End With
    End Sub
    Sub ListarTipoDocumento()
        Dim cn As New cnTrabajador
        Dim tb As New DataTable
        tb = cn.Cn_ListarTipoDocIdentidad().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Tipo Documento Identidad"
        With cbxtipodocidentidad
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub
    Sub Consultar()
        Dim obj As New coTrabajador
        Dim cn As New cnTrabajador
        obj.IdPersona = _Codigo
        obj.idcontrato = idcontrato
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarxCodigo(obj).Copy
        tb.TableName = "tmp"
        If tb.Rows.Count > 0 Then
            With tb.Rows(0)
                txtCodigo.Text = .Item(0).ToString()
                cbxtipo.Text = .Item(1).ToString()
                txtnumdoc.Text = .Item(2).ToString()
                txtnombre.Text = .Item(22).ToString()
                txtpaterno.Text = .Item(23).ToString()
                txtmaterno.Text = .Item(24).ToString()
                cbxsexo.SelectedItem = .Item(4).ToString()
                cbxestadocivil.SelectedItem = .Item(5).ToString()
                dtfechanacimiento.Value = Convert.ToDateTime(.Item(6))
                txtdireccion.Text = .Item(7).ToString()
                txtcelular.Text = .Item(8).ToString()
                txtcorreo.Text = .Item(9).ToString()
                cbxestado.SelectedItem = .Item(13).ToString()
                Dim firma As Byte() = Nothing
                If Not IsDBNull(.Item(15)) Then
                    firma = CType(.Item(15), Byte())
                End If
                cbxtipodocidentidad.Value = .Item(17).ToString()
            End With
        Else
            MessageBox.Show("No se encontró ningún registro con el código especificado.")
        End If
    End Sub

    Private Async Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            Dim razonSocial As String
            Dim domicilioFiscal As String
            Dim nombre As String
            Dim apellidop As String
            Dim apellidom As String
            If cbxtipodocidentidad.Text = "Registro Único de Contribuyentes" Then
                If String.IsNullOrEmpty(txtnumdoc.Text) Or txtnumdoc.Text.Length < 11 Then
                    msj_advert("Ingrese un RUC válido")
                Else
                    Dim ser As JObject = Await api.ObtenerDatosProveedorRuc(txtnumdoc.Text)

                    If ser IsNot Nothing Then
                        razonSocial = ser("nombreCompleto")?.ToString()
                        domicilioFiscal = ser("direccion")?.ToString()
                        nombre = ser("nombres")?.ToString()
                        apellidop = ser("apellidoPaterno")?.ToString()
                        apellidom = ser("apellidoMaterno")?.ToString()

                        If Not String.IsNullOrEmpty(razonSocial) Then
                            txtnombre.Text = razonSocial
                        End If

                        If Not String.IsNullOrEmpty(domicilioFiscal) Then
                            txtdireccion.Text = domicilioFiscal
                        End If
                    Else
                        msj_advert("No se encontraron datos para el RUC proporcionado.")
                    End If
                End If
            Else
                If String.IsNullOrEmpty(txtnumdoc.Text) OrElse txtnumdoc.Text.Length < 8 Then
                    msj_advert("Ingrese un DNI válido")
                Else
                    Dim ser As JObject = Await api.ObtenerDatosPersonaDNI(txtnumdoc.Text)

                    ' Primero verificamos si se obtuvo respuesta
                    If ser Is Nothing Then
                        msj_advert("No se encontraron datos para el DNI proporcionado o se excedió el límite de solicitudes.")
                        Exit Sub
                    End If

                    ' Luego, extraemos las propiedades
                    Try
                        nombre = ser("nombres")?.ToString()
                        apellidop = ser("apellidoPaterno")?.ToString()
                        apellidom = ser("apellidoMaterno")?.ToString()

                        If Not String.IsNullOrEmpty(nombre) Then
                            txtnombre.Text = nombre
                            txtpaterno.Text = apellidop
                            txtmaterno.Text = apellidom
                        Else
                            msj_advert("No se encontraron datos para el DNI proporcionado.")
                        End If
                    Catch ex As Exception
                        msj_advert("Error al procesar los datos recibidos.")
                    End Try
                End If
            End If

        Catch ex As Exception
            msj_advert("Ingrese un DNI válido")
        End Try
    End Sub

    Private Sub btnBuscarDistrito_Click(sender As Object, e As EventArgs)
        Dim f As New FrmListarDistritos(Me)
        f.ShowDialog()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que deseas continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Mantenimiento()
        End If
    End Sub
    Sub Mantenimiento()
        Try
            If _operacion <> 1 AndAlso _operacion <> 2 OrElse txtCodigo.Text <> "" AndAlso txtCodigo.Text.Length <> 0 Then
                If _operacion = 0 OrElse _operacion = 1 Then
                    If cbxtipodocidentidad.Value Is Nothing Then
                        msj_advert("Seleccione un Tipo de Documento de Identidad")
                        Return
                    End If

                    If txtnumdoc.Text.Length = 0 Then
                        txtnumdoc.Focus()
                        msj_advert("N° Documento no Válido")
                        Return
                    End If
                    If txtnombre.Text.Length = 0 Then
                        txtnombre.Focus()
                        msj_advert("Datos no Válidos")
                        Return
                    End If
                    If txtpaterno.Text.Length = 0 Then
                        txtpaterno.Focus()
                        msj_advert("Datos no Válidos")
                        Return
                    End If
                    If txtmaterno.Text.Length = 0 Then
                        txtmaterno.Focus()
                        msj_advert("Datos no Válidos")
                        Return
                    End If
                    If txtdireccion.Text.Length = 0 Then
                        txtdireccion.Focus()
                        msj_advert("Dirección no Válida")
                        Return
                    End If
                    If txtcelular.Text.Length = 0 Then
                        txtcelular.Focus()
                        msj_advert("Celular no Válido")
                        Return
                    End If


                    If txtcorreo.Text.Length = 0 Then
                        txtcorreo.Focus()
                        msj_advert("Correo no Válido")
                        Return
                    End If
                    Dim edadCalculada As Integer = DateTime.Now.Year - dtfechanacimiento.Value.Year
                    If edadCalculada < 18 Then
                        Dim resultado As DialogResult = MessageBox.Show("El Trabajador es menor de edad. ¿Está seguro que desea continuar?",
                                                                        "Confirmación",
                                                                        MessageBoxButtons.YesNo,
                                                                        MessageBoxIcon.Warning)

                        If resultado = DialogResult.No Then
                            Return
                        End If
                    End If
                End If

                'lo referente para la tabla persona
                Dim obj As New coTrabajador
                obj.Operacion = _operacion
                obj.IdPersona = _Codigo
                obj.idcontrato = idcontrato
                obj.Tipo = cbxtipo.Text
                obj.NumDocumento = txtnumdoc.Text
                obj.IdTipoDocIdentidad = cbxtipodocidentidad.Value
                obj.Datos = txtnombre.Text
                obj.apaterno = txtpaterno.Text
                obj.amaterno = txtmaterno.Text
                obj.Sexo = cbxsexo.Text
                obj.EstadoCivil = cbxestadocivil.Text
                obj.FNacimiento = dtfechanacimiento.Value
                obj.Direccion = txtdireccion.Text
                obj.IdDistrito = Me.idDistrito
                obj.Correo = txtcorreo.Text
                obj.Celular = txtcelular.Text
                obj.Estado = cbxestado.Text
                obj.ArchivoFoto = If(loadNewImageFoto AndAlso imagefoto IsNot Nothing, imagefoto, Nothing)
                obj.ArchivoFirma = If(leadNewImageFirma AndAlso imagefirma IsNot Nothing, imagefirma, Nothing)
                obj.IdUsuario = VariablesGlobales.VP_IdUser
                obj.idCargosistena = 4

                _mensajeBgWk = cn_item.Cn_Mantenimientoconductores(obj)
                If obj.Coderror = 0 Then
                    MessageBox.Show("Operación exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dispose()
                Else
                    msj_ok(_mensajeBgWk)
                End If

            Else
                msj_advert("Seleccione un Registro")
                Return
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class