Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.IO
Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Stimulsoft.Base.Json.Linq
Imports Stimulsoft.Base.StiDbType

Public Class FrmTrabajador
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
    Dim valorcbtipodoc As Integer = 0
    Public operacion As Integer = 0
    'Listar todas las tablas

    Sub ListarTablas()
        Try
            Dim ds As New DataSet
            ds = cn_item.Cn_ListarTablasMaestrasTrabajadores().Copy
            ds.DataSetName = "tmp"
            ds.Tables(0).Columns(1).ColumnName = "Motivos"
            Dim nuevaFila As DataRow = ds.Tables(0).NewRow()
            nuevaFila(0) = DBNull.Value
            nuevaFila(1) = "Selecciona el motivo"
            ds.Tables(0).Rows.InsertAt(nuevaFila, 0)
            Dim indice_tabla As Integer = 0
            With cbxmotivobaja
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With

            indice_tabla = 1
            ds.Tables(indice_tabla).Columns(1).ColumnName = "CARGOS"
            With cbCargosistema
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(12)(0)
                End If
            End With

            indice_tabla = 3
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Opciones"
            With cbxdiscapacidad
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(1)(0)
                End If
            End With

            indice_tabla = 10
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Descripción"
            With cbniveleducativo
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With


            indice_tabla = 12
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Descripción"
            With cbxarea
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With

            indice_tabla = 13
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Descripción"
            With cbxplantel
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub FrmItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtg_listadocontratos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            dtg_listadocontratos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            dtg_listadocontratos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
            dtg_listadocontratos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False
            dtg_listadocontratos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.DefaultableBoolean.False
            dtg_listadocontratos.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False
            ListarTablas()
            cbListanegra.SelectedIndex = 0
            cbxSinextra.SelectedIndex = 0
            cbxasignacionfamiliar.SelectedIndex = 0
            cbPconfianza.SelectedIndex = 1
            clsBasicas.Formato_Tablas_Grid(dtgListadodeHijos)
            If (_Codigo = 0) Then
                Me.Size = New Size(1375, 547)
                pagesubicaciones.TabPages.Remove(Capacitación)
                pagesubicaciones.TabPages.Remove(TabPage8)
                pagesubicaciones.TabPages.Remove(Memorándum)
                pagesubicaciones.TabPages.Remove(pageceseobajatrabajador)
                pagesubicaciones.TabPages.Remove(contratospage)
                pagesubicaciones.TabPages.Remove(pagespagos)
                pagesubicaciones.TabPages.Remove(pageUbicaciones)
                pagesubicaciones.TabPages.Remove(pageUbicaciones)
                pagesubicaciones.TabPages.Remove(pagederechohabietos)
                pagesubicaciones.TabPages.Remove(pagesctr)
                pagesubicaciones.TabPages.Remove(pagesvacaciones)
                btnnuevocontrato.Visible = False
                cbxasignacionfamiliar.Visible = False
                Label1.Visible = False
            Else
                Me.Size = New Size(1375, 547)
                AddHandler Capacitación.Enter, AddressOf TabPage1_Click
                AddHandler TabPage8.Enter, AddressOf TabPage2_Click
                AddHandler Memorándum.Enter, AddressOf TabPage3_Click
                AddHandler pageceseobajatrabajador.Enter, AddressOf TabPage3_Click
                AddHandler contratospage.Enter, AddressOf TabPage3_Click
                AddHandler pagespagos.Enter, AddressOf TabPage3_Click
                AddHandler pageUbicaciones.Enter, AddressOf TabPage3_Click
                AddHandler pagederechohabietos.Enter, AddressOf TabPage3_Click
                AddHandler pagesctr.Enter, AddressOf TabPage3_Click
                AddHandler pagesvacaciones.Enter, AddressOf TabPage3_Click
                cbxasignacionfamiliar.Visible = True
                Label1.Visible = True
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
                cbxestado.Enabled = False
            End If
            If _tipotrabajador = "EVENTUAL" Then
                btnGuardar.Enabled = True
                cbxestado.Enabled = True
            End If
        Catch ex As Exception
            'clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub pagesubicaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pagesubicaciones.SelectedIndexChanged
        Select Case pagesubicaciones.SelectedTab.Name
            Case "Capacitación"
                ConsultarCapacitacionPorIdPersona()
            Case "pagesvacaciones"
                ConsultarPermisosTrabajador()
            Case "Memorándum"
                ConsultarMemorandumPorIdPersona()
            Case "pageceseobajatrabajador"
                ConsultarBajatrabajador()
            Case "contratospage"
                ConsultarContratoPorIdPersona()
            Case "pagespagos"
                Consultarsueldosporidpersona()
            Case "pageUbicaciones"
                ConsultarUbicacionPorIdPersona()
            Case "pagederechohabietos"
                ConsultarHijosPorIdPersona()
            Case "pagesctr"
                ConsultarSCTRPorIdPersona()
            Case "TabPage8"
                ConsultarEppPorIdPersona()
        End Select
    End Sub

    Private Sub dtgListadodeHijos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListadodeHijos.InitializeRow
        clsBasicas.Colorear_SegunValor(dtgListadodeHijos, Color.Red, Color.White, "INACTIVO", 13)
        clsBasicas.Colorear_SegunValor(dtgListadodeHijos, Color.Green, Color.White, "ACTIVO", 13)
    End Sub
    Private Sub dtg_listadocontratos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtg_listadocontratos.InitializeRow
        clsBasicas.Colorear_SegunValor(dtg_listadocontratos, Color.Red, Color.White, "INACTIVO", 11)
        clsBasicas.Colorear_SegunValor(dtg_listadocontratos, Color.Green, Color.White, "ACTIVO", 11)
    End Sub

    Private Sub dtglistadopagos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtglistadopagos.InitializeRow
        clsBasicas.Colorear_SegunValor(dtglistadopagos, Color.Red, Color.White, "PENDIENTE", 3)
        clsBasicas.Colorear_SegunValor(dtglistadopagos, Color.Green, Color.White, "ENVIADO", 3)
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
                    If txtDistrito.Text.Length = 0 Then
                        txtDistrito.Focus()
                        msj_advert("Seleccione un distrito")
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

                If picFoto.Image IsNot Nothing Then
                    If (loadNewImageFoto) Then
                        Dim optimizedImageBytes As Byte() = clsBasicas.OptimizeImageFromPictureBox(picFoto)
                        picFoto.Image = clsBasicas.ByteArrayToImage(optimizedImageBytes)
                        imagefoto = optimizedImageBytes
                    End If
                End If

                If picfirma.Image IsNot Nothing Then
                    If (leadNewImageFirma) Then
                        Dim optimizedImageBytes As Byte() = clsBasicas.OptimizeImageFromPictureBox(picfirma)
                        picfirma.Image = clsBasicas.ByteArrayToImage(optimizedImageBytes)
                        imagefirma = optimizedImageBytes
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
                obj.Asignacionfamiliar = cbxasignacionfamiliar.Text
                If cbPconfianza.Text = "SI" Then
                    obj.Personaconfianza = 1
                ElseIf cbPconfianza.Text = "NO" Then
                    obj.Personaconfianza = 0
                Else
                    MessageBox.Show("Por favor, selecciona una opción válida.")
                End If
                obj.Celular = txtcelular.Text
                obj.Estado = cbxestado.Text
                obj.ArchivoFoto = If(loadNewImageFoto AndAlso imagefoto IsNot Nothing, imagefoto, Nothing)
                obj.ArchivoFirma = If(leadNewImageFirma AndAlso imagefirma IsNot Nothing, imagefirma, Nothing)
                obj.IdUsuario = VariablesGlobales.VP_IdUser
                obj.idCargosistena = cbCargosistema.Value
                obj.sinpagoextra = cbxSinextra.Text

                'Contrato
                obj.lista_vinculofamiliar = CreacionArrayVinculofamiliar()
                If _tipotrabajador = "PLANILLA" Then
                    If cbxestado.Text = "INACTIVO" Then
                        If cbListanegra.Text = "SI" Then
                            obj.ListaNegra = True
                        ElseIf cbListanegra.Text = "NO" Then
                            obj.ListaNegra = False
                        End If
                    ElseIf cbxestado.Text = "ACTIVO" Then
                        If cbListanegra.Text = "SI" Then
                            MessageBox.Show("Debe finalizar el contrato activo antes de incluirlo en la lista negra.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        ElseIf cbListanegra.Text = "NO" Then
                            obj.ListaNegra = False
                        End If
                    End If
                End If
                If _tipotrabajador = "EVENTUAL" Then
                    If cbxestado.Text = "INACTIVO" Then
                        If cbListanegra.Text = "SI" Then
                            obj.ListaNegra = True
                        ElseIf cbListanegra.Text = "NO" Then
                            obj.ListaNegra = False
                        End If
                    ElseIf cbxestado.Text = "ACTIVO" Then
                        If cbListanegra.Text = "SI" Then
                            MessageBox.Show("Para agregarlo a la lista negra, primero cambie el estado a inactivo.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        ElseIf cbListanegra.Text = "NO" Then
                            obj.ListaNegra = False
                        End If
                    End If
                End If

                obj.Lista_Cods_Sunat = GenerarCadenaValores()
                _mensajeBgWk = cn_item.Cn_Mantenimiento(obj)
                If obj.Coderror = 0 Then
                    If _operacion = 0 Then
                        contadorClicsGuardar += 1
                        btnnuevocontrato.Visible = True
                    End If
                    If _operacion = 1 Then
                        contadorClicsGuardar += 2
                        btnnuevocontrato.Visible = False
                    End If
                    MessageBox.Show("Operación exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'MessageBox.Show("Operación exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    Public Sub LlenarCamposUbicacion(codigo As Integer, nombreDistrito As String, nombreProvincia As String, nombreDepartamento As String)
        idDistrito = codigo
        txtDistrito.Text = nombreDistrito & " - " & nombreProvincia & " - " & nombreDepartamento
    End Sub
    Public Sub LlenarCamposOcupacion(codigo As Integer, nombre As String)
        idOcupacion = codigo
        txtocupacion.Text = nombre
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
                If operacion = 1 Then
                    cbxestado.SelectedIndex = 0
                Else
                    cbxestado.SelectedItem = .Item(13).ToString()
                End If
                cbListanegra.Text = If(.Item(19), "SI", "NO")
                If cbListanegra.Text = "SI" Then
                    Nuevocontrato.Enabled = False
                    lbestado.BackColor = Color.Black
                End If
                Dim foto As Byte() = Nothing
                If Not IsDBNull(.Item(14)) Then
                    foto = CType(.Item(14), Byte())
                End If
                clsBasicas.ConvertVarBinaryToPictureBox(foto, picFoto)
                Dim firma As Byte() = Nothing
                If Not IsDBNull(.Item(15)) Then
                    firma = CType(.Item(15), Byte())
                End If
                clsBasicas.ConvertVarBinaryToPictureBox(firma, picfirma)
                cbxtipodocidentidad.Value = .Item(17).ToString()
                valorcbtipodoc = .Item(17).ToString()
                cbxasignacionfamiliar.Text = .Item(18).ToString()
                cbPconfianza.Text = If(.Item(25), "SI", "NO")
                If cbPconfianza.Text = "SI" Then
                    cbxestado.Text = "ACTIVO"
                    lbestado.BackColor = Color.Green
                End If
                If cbxestado.Text = "INACTIVO" Then
                    btnGuardar.Enabled = False
                    btnAgregarHijo.Enabled = False
                    btnañadirplanteles.Enabled = False
                End If
                cbCargosistema.Value = .Item(29).ToString()
                cbxSinextra.Text = .Item(31).ToString()

            End With
            Dim tbUbicacion As DataTable = cn.Cc_ConsultarxCodigoUbicacion(obj)
            If tbUbicacion.Rows.Count > 0 Then
                With tbUbicacion.Rows(0)
                    Me.idDistrito = .Item("idDistrito").ToString()
                    txtDistrito.Text = .Item("Distrito").ToString() + " - " + .Item("Provincia").ToString() + " - " + .Item("Departamento").ToString()
                End With
            Else
            End If
            Dim tbRegistro As DataTable = cn.Cc_ConsultarxCodigoregistrosunat(obj)
            If tbRegistro.Rows.Count > 0 Then
                For Each row As DataRow In tbRegistro.Rows
                    Dim tipo As String = row("tiposunat").ToString()
                    Select Case tipo
                        Case "OCUPACION_PRI"
                            txtocupacion.Text = row("registro").ToString()
                            idOcupacion = row("idstipounat").ToString()
                        Case "NIVEL_EDUCATIVO"
                            cbniveleducativo.Value = row("idstipounat").ToString()
                        Case "DISCAPACIDAD"
                            cbxdiscapacidad.Value = row("idstipounat").ToString()
                        Case "TIPO_PASAPORTE"
                            cbxListarPasaporte.Value = row("idstipounat").ToString()
                        Case Else
                    End Select
                Next
            End If
        Else
            MessageBox.Show("No se encontró ningún registro con el código especificado.")
        End If
    End Sub

    Dim selectedDepartmentId As Integer
    Private Sub bcerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que deseas continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Mantenimiento()
            If contadorClicsGuardar = 2 Then
                Dispose()
            End If
        End If
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
    Private Sub TabPage1_Click(sender As Object, e As EventArgs)
        ConsultarCapacitacionPorIdPersona()
        dtpFechaDesdeCapa.Value = Now.Date
        dtpFechaHastaCapa.Value = Now.Date
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs)
        ConsultarEppPorIdPersona()
        dtpFechaDesdeEpp.Value = Now.Date
        dtpFechaHastaEpp.Value = Now.Date
    End Sub
    Private Sub TabPage3_Click(sender As Object, e As EventArgs)
        ConsultarMemorandumPorIdPersona()
        dtpFechaDesdeMemo.Value = Now.Date
        dtpFechaHastaMemo.Value = Now.Date
    End Sub
    Private Sub dtg_listadocontratos_DoubleClick(sender As Object, e As EventArgs) Handles dtg_listadocontratos.DoubleClick
        Dim activeRow = dtg_listadocontratos.ActiveRow
        If activeRow IsNot Nothing Then
            Dim idContrato As Integer = CInt(activeRow.Cells("idContrato").Value)
            Dim obj As New coTrabajador
            obj.idcontrato = idContrato
        Else
            MessageBox.Show("Por favor seleccione un contrato.")
        End If
    End Sub
    Sub ConsultarContratoPorIdPersona()
        Dim obj As New coTrabajador
        Dim cn As New cnControlEpp
        obj.IdPersona = _Codigo
        ds = cn.Cn_ConsultarContratoPorTrabajador(obj).Copy
        ds.DataSetName = "tmp"
        If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            dtg_listadocontratos.DataSource = ds.Tables(0)
            With dtg_listadocontratos.DisplayLayout.Bands(0)
                .Columns("idContrato").Hidden = True
            End With
            dtg_listadocontratos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
            dtg_listadocontratos.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
            dtg_listadocontratos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
            clsBasicas.Formato_Tablas_Grid(dtg_listadocontratos)
            Dim idContrato As Integer = CInt(ds.Tables(0).Rows(0)("idContrato"))
            obj.idcontrato = idContrato
            If ds.Tables.Count > 1 Then
                Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns("idContrato"), ds.Tables(1).Columns("idContrato"), False)
                ds.Relations.Add(relation1)
            End If
            ConfigurarUltraGrid()
        Else
            'msj_advert("No se encontraron contratos para esta persona en el rango de fechas especificado.")
        End If
    End Sub

    Sub ConsultarPermisosTrabajador()
        Dim obj As New coTrabajador
        Dim cn As New cnControlEpp
        obj.IdPersona = _Codigo
        ds = cn.Cn_ConsultarPermisosTrabajador(obj).Copy
        ds.DataSetName = "tmp"
        If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            dtgpermisoslaborales.DataSource = ds.Tables(0)
            dtgpermisoslaborales.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
            dtgpermisoslaborales.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
            dtgpermisoslaborales.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
            clsBasicas.Formato_Tablas_Grid(dtgpermisoslaborales)
        Else
            'msj_advert("No se encontraron contratos para esta persona en el rango de fechas especificado.")
        End If
    End Sub


    Sub ConsultarSCTRPorIdPersona()
        Dim obj As New coTrabajador
        Dim cn As New cnControlEpp
        obj.IdPersona = _Codigo
        ds = cn.Cn_ConsultarSCTRPorTrabajador(obj).Copy
        ds.DataSetName = "tmp"
        If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            dtgsctr.DataSource = ds.Tables(0)
            dtgsctr.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
            dtgsctr.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
            dtgsctr.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
            clsBasicas.Formato_Tablas_Grid(dtgsctr)
        Else
            'msj_advert("No se encontraron contratos para esta persona en el rango de fechas especificado.")
        End If
    End Sub
    Private Sub dtgsctr_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgsctr.InitializeRow
        If e.Row.Band.Index = 0 Then
            Dim colVerPDF As Infragistics.Win.UltraWinGrid.UltraGridColumn
            If dtgsctr.DisplayLayout.Bands(0).Columns.Exists("Ver PDF") Then
                colVerPDF = dtgsctr.DisplayLayout.Bands(0).Columns("Ver PDF")
                colVerPDF.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerPDF.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                If Not e.ReInitialize Then
                    e.Row.Cells("Ver PDF").Value = "Ver PDF"
                    e.Row.Cells("Ver PDF").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                End If
            End If
        End If
    End Sub
    Private Sub dtgsctr_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgsctr.ClickCellButton
        Try
            With dtgsctr
                If (e.Cell.Column.Key = "Ver PDF") Then
                    Dim cn As New cnControlSeguro
                    Dim idMemorandum As Integer = CInt(.ActiveRow.Cells(0).Value)
                    Dim pdfData As Byte() = cn.Cn_ObtenerArchivoTrabajador(idMemorandum)
                    If pdfData IsNot Nothing AndAlso pdfData.Length > 0 Then
                        Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "seguro.pdf")

                        File.WriteAllBytes(tempFilePath, pdfData)
                        Process.Start(tempFilePath)
                    Else
                        MessageBox.Show("No se encontró el archivo PDF en la base de datos.")
                    End If
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ConfigurarUltraGrid()
        With dtg_listadocontratos.DisplayLayout.Bands(0)

            ' Limpiar grupos existentes
            .Groups.Clear()
            .RowLayoutStyle = RowLayoutStyle.GroupLayout

            ' Crear grupos
            Dim groupGeneral As UltraGridGroup = .Groups.Add("Periodo", "Periodo")
            Dim group1 As UltraGridGroup = .Groups.Add("DATOS SALARIO BASE", "DATOS SALARIO BASE")
            Dim group2 As UltraGridGroup = .Groups.Add("DATOS SALARIO EXTRA", "DATOS SALARIO EXTRA")
            Dim group3 As UltraGridGroup = .Groups.Add("CONTRATO", "CONTRATO")

            ' Asignar columnas de información general
            .Columns("fInicio").RowLayoutColumnInfo.ParentGroup = groupGeneral
            .Columns("fFin").RowLayoutColumnInfo.ParentGroup = groupGeneral
            .Columns("Salario").RowLayoutColumnInfo.ParentGroup = group1
            .Columns("N° Cuenta").RowLayoutColumnInfo.ParentGroup = group1
            .Columns("Banco").RowLayoutColumnInfo.ParentGroup = group1
            .Columns("Salario Extra").RowLayoutColumnInfo.ParentGroup = group2
            .Columns("N° Cuenta Extra").RowLayoutColumnInfo.ParentGroup = group2
            .Columns("Banco Extra").RowLayoutColumnInfo.ParentGroup = group2
            .Columns("Codigo").RowLayoutColumnInfo.ParentGroup = group3
            .Columns("Tipo Contrato").RowLayoutColumnInfo.ParentGroup = group3
            .Columns("ESTADO").RowLayoutColumnInfo.ParentGroup = group3
        End With

        dtg_listadocontratos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        clsBasicas.Filtrar_Tabla(dtg_listadocontratos, False)
    End Sub
    Sub ConsultarUbicacionPorIdPersona()
        Dim obj As New coTrabajador
        Dim cn As New cnControlEpp
        obj.IdPersona = _Codigo
        ds = cn.Cn_ConsultarUbicacionPorTrabajador(obj).Copy
        ds.DataSetName = "tmp"
        If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            dtgubicacionpersona.DataSource = ds.Tables(0)
            'With dtgubicacionpersona.DisplayLayout.Bands(0)
            '    .Columns("idUbicacionPersona").Hidden = True
            'End With
            dtgubicacionpersona.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
            dtgubicacionpersona.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
            dtgubicacionpersona.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
            clsBasicas.Formato_Tablas_Grid(dtgubicacionpersona)
            Dim idubicacionpersona As Integer = CInt(ds.Tables(0).Rows(0)("idUbicacionPersona"))
            obj.idubicacionpersona = idubicacionpersona
            If ds.Tables.Count > 1 Then
                Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns("idUbicacionPersona"), ds.Tables(1).Columns("idUbicacionPersona"), False)
                ds.Relations.Add(relation1)
            End If
        Else
            'msj_advert("No se encontraron Ubicaciones para esta persona.")
        End If
    End Sub


    Sub Consultarsueldosporidpersona()
        Dim obj As New coTrabajador
        Dim cn As New cnControlEpp
        obj.IdPersona = _Codigo
        ds = cn.Cn_Consultarsueldosporidpersona(obj).Copy
        ds.DataSetName = "tmp"
        If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            dtglistadopagos.DataSource = ds.Tables(0)
            'With dtgubicacionpersona.DisplayLayout.Bands(0)
            '    .Columns("idUbicacionPersona").Hidden = True
            'End With
            dtglistadopagos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
            dtglistadopagos.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
            dtglistadopagos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
            clsBasicas.Formato_Tablas_Grid(dtglistadopagos)
        Else
            'msj_advert("No se encontraron Ubicaciones para esta persona.")
        End If
    End Sub

    Sub ConsultarBajatrabajador()
        Dim obj As New coTrabajador
        Dim cn As New cnControlEpp
        obj.IdPersona = _Codigo
        ds = cn.Cn_ConsultarBajaTrabajador(obj).Copy
        ds.DataSetName = "tmp"
        If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            dtgbajatrabajador.DataSource = ds.Tables(0)
            dtgbajatrabajador.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
            dtgbajatrabajador.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
            dtgbajatrabajador.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
            clsBasicas.Formato_Tablas_Grid(dtgbajatrabajador)

        Else
            'msj_advert("No se encontraron Ubicaciones para esta persona.")
        End If
    End Sub



    Sub ConsultarHijosPorIdPersona()
        Dim obj As New coTrabajador
        Dim cn As New cnControlEpp
        obj.IdPersona = _Codigo
        ds = cn.Cn_ConsultarHijosPorTrabajador(obj).Copy
        ds.DataSetName = "tmp"
        If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            dtgListadodeHijos.DataSource = ds.Tables(0)
            With dtgListadodeHijos.DisplayLayout.Bands(0)
                .Columns("idpersonahijo").Hidden = True
                .Columns("Concepcion").Hidden = True
                .Columns("TipodocHijo").Hidden = True
                .Columns("idpersonahijo").Hidden = True
            End With
            dtgListadodeHijos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
            dtgListadodeHijos.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
            dtgListadodeHijos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
            clsBasicas.Formato_Tablas_Grid(dtgListadodeHijos)
            Dim idhijo As Integer = CInt(ds.Tables(0).Rows(0)("idpersonahijo"))
            obj.idhijo = idhijo
            If ds.Tables.Count > 1 Then
                Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns("idpersonahijo"), ds.Tables(1).Columns("idpersonahijo"), False)
                ds.Relations.Add(relation1)
            End If
        Else
            'MessageBox.Show("No se encontraron hijos para esta persona.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub dtgListadodeHijos_DoubleClick(sender As Object, e As EventArgs) Handles dtgListadodeHijos.DoubleClick
        Dim activeRow = dtgListadodeHijos.ActiveRow
        If activeRow IsNot Nothing Then
            Dim idhijo As Integer = CInt(activeRow.Cells("idpersonahijo").Value)
            Dim obj As New coTrabajador
            obj.idhijo = idhijo
        Else
            MessageBox.Show("Por favor seleccione un contrato.")
        End If
    End Sub

    Private Sub dtgubicacionpersona_DoubleClick(sender As Object, e As EventArgs) Handles dtgubicacionpersona.DoubleClick
        Dim activeRow = dtgubicacionpersona.ActiveRow
        If activeRow IsNot Nothing Then
            Dim idubicacionpersona As Integer = CInt(activeRow.Cells("idUbicacionPersona").Value)
            Dim obj As New coTrabajador
            obj.idubicacionpersona = idubicacionpersona
            'MessageBox.Show("Ubicacion seleccionado: " & obj.idubicacionpersona.ToString())
        Else
            MessageBox.Show("Por favor seleccione un contrato.")
        End If
    End Sub
    Sub ConsultarEppPorIdPersona()
        Dim obj As New coTrabajador
        Dim cn As New cnControlEpp
        obj.IdPersona = _Codigo
        obj.FechaDesde = dtpFechaDesdeEpp.Value
        obj.FechaHasta = dtpFechaHastaEpp.Value
        ds = cn.Cn_ConsultarPorTrabajador(obj).Copy
        ds.DataSetName = "tmp"

        Dim relation1 As New DataRelation("tb_relacion1", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(0), False)

        ds.Relations.Add(relation1)
        dtgListadoEpp.DataSource = ds
        clsBasicas.Formato_Tablas_Grid(dtgListadoEpp)
    End Sub
    Sub ConsultarCapacitacionPorIdPersona()
        Dim obj As New coTrabajador
        Dim cn As New cnControlCapacitacion
        obj.IdPersona = _Codigo
        obj.FechaDesde = dtpFechaDesdeCapa.Value
        obj.FechaHasta = dtpFechaHastaCapa.Value
        dtgListadoCapa.DataSource = cn.Cn_ConsultarPorTrabajador(obj)
        clsBasicas.Formato_Tablas_Grid(dtgListadoCapa)
    End Sub
    Sub ConsultarMemorandumPorIdPersona()
        Dim obj As New coTrabajador
        Dim cn As New cnControlMemoDespido
        obj.IdPersona = _Codigo
        obj.FechaDesde = dtpFechaDesdeMemo.Value
        obj.FechaHasta = dtpFechaHastaMemo.Value
        dtgListadoMemo.DataSource = cn.Cn_ConsultarPorTrabajador(obj)
        clsBasicas.Formato_Tablas_Grid(dtgListadoMemo)
        clsBasicas.Colorear_SegunValor(dtgListadoMemo, Color.Gray, Color.White, "BAJO", 5)
        clsBasicas.Colorear_SegunValor(dtgListadoMemo, Color.Orange, Color.White, "MEDIO", 5)
        clsBasicas.Colorear_SegunValor(dtgListadoMemo, Color.Red, Color.White, "ALTO", 5)
    End Sub

    Private idDistritoSeleccionado As Integer
    Private Sub cbtipotrabajo_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
    End Sub
    Private Sub cbniveleducativo_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cbniveleducativo.InitializeLayout
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
    End Sub
    Private Sub btnBuscarDistrito_Click(sender As Object, e As EventArgs) Handles btnBuscarDistrito.Click
        Dim f As New FrmListarDistritos(Me)
        f.ShowDialog()
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

    Private Sub UltraCombo3_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
    End Sub

    Private Sub UltraCombo4_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New FrmOcupacion(Me)
        f.ShowDialog()
    End Sub

    Private Sub UltraCombo11_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxmotivobaja.InitializeLayout
        e.Layout.Bands(0).Columns("Codigo").Hidden = True
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
    End Sub

    Private Sub UltraCombo11_ValueChanged(sender As Object, e As EventArgs) Handles cbxmotivobaja.ValueChanged

    End Sub
    Private Sub UltraCombo12_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
    End Sub
    Private Function GenerarCadenaValores() As String
        Dim valores As New List(Of String)
        If Not String.IsNullOrEmpty(idOcupacion) AndAlso idOcupacion <> "0" Then valores.Add(idOcupacion)
        If cbniveleducativo.Value IsNot Nothing Then valores.Add(cbniveleducativo.Value.ToString())
        If cbxdiscapacidad.Value IsNot Nothing Then valores.Add(cbxdiscapacidad.Value.ToString())
        If cbxListarPasaporte.Value IsNot Nothing Then valores.Add(cbxListarPasaporte.Value.ToString())
        Return String.Join(",", valores)
    End Function
    Private Sub btnCapacitacion_Click_1(sender As Object, e As EventArgs) Handles btnCapacitacion.Click
        If dtpFechaDesdeCapa.Value > dtpFechaHastaCapa.Value Then
            msj_advert("La fecha 'Desde' debe ser anterior o igual a la fecha 'Hasta'.")
            Return
        End If
        ConsultarCapacitacionPorIdPersona()
    End Sub
    Private Sub btnBuscarEpp_Click_1(sender As Object, e As EventArgs) Handles btnBuscarEpp.Click
        If dtpFechaDesdeEpp.Value > dtpFechaHastaEpp.Value Then
            msj_advert("La fecha 'Desde' debe ser anterior o igual a la fecha 'Hasta'.")
            Return
        End If
        ConsultarEppPorIdPersona()
    End Sub

    Private Sub btnMemorandum_Click_1(sender As Object, e As EventArgs) Handles btnMemorandum.Click
        If dtpFechaDesdeMemo.Value > dtpFechaHastaMemo.Value Then
            msj_advert("La fecha 'Desde' debe ser anterior o igual a la fecha 'Hasta'.")
            Return
        End If
        ConsultarMemorandumPorIdPersona()
    End Sub

    Private Sub cbxbanco_sb_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
    End Sub
    Sub CargarTablaDetalleDerechoHabiente()
        DtDetalle = New DataTable("TempDetProdEpp")
        DtDetalle.Columns.Add("DNI", GetType(String))
        DtDetalle.Columns.Add("FechaNacimiento", GetType(DateTime))
        DtDetalle.Columns.Add("Sexo", GetType(String))
        DtDetalle.Columns.Add("Nombre", GetType(String))
        DtDetalle.Columns.Add("Apellido Paterno", GetType(String))
        DtDetalle.Columns.Add("Apellido Materno", GetType(String))
        DtDetalle.Columns.Add("Vinculofamiliar", GetType(Integer))
        DtDetalle.Columns.Add("TipoDocVinculante", GetType(Integer))
        DtDetalle.Columns.Add("N_Doc_Vinculo", GetType(String))
        DtDetalle.Columns.Add("PDF", GetType(Byte()))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        dtgListadodeHijos.DataSource = DtDetalle
    End Sub
    Public Function CreacionArrayVinculofamiliar() As String
        Dim array_vinculo As String = ""
        If _operacion = 0 Or _operacion = 1 Then
            If dtgListadodeHijos.Rows.Count = 0 Then
                array_vinculo = "0"
            Else
                For i = 0 To dtgListadodeHijos.Rows.Count - 1
                    If dtgListadodeHijos.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0 Then
                        Dim rowValues As New List(Of String)()
                        For j = 0 To dtgListadodeHijos.Rows(i).Cells.Count - 1
                            rowValues.Add(dtgListadodeHijos.Rows(i).Cells(j).Value.ToString.Trim)
                        Next

                        If _operacion = 1 AndAlso i = dtgListadodeHijos.Rows.Count - 1 Then
                            rowValues.RemoveAt(rowValues.Count - 1)
                        End If

                        ' Añadir a la cadena y manejar la coma extra
                        If i = dtgListadodeHijos.Rows.Count - 1 Then
                            array_vinculo &= String.Join("+", rowValues)
                        Else
                            array_vinculo &= String.Join("+", rowValues) & ","
                        End If
                    End If
                Next
            End If
        End If

        Return array_vinculo
    End Function
    Public Sub LlenarCamposDerechoHabiente(
    nroDocHijo As String,
    fechaConcepcion As String,
    fechaNacimientohijo As String,
    sexohijo As String,
    tipoDocIdentidadHijo As Integer,
    nombreHijo As String,
    apPaternoHijo As String,
    apMaternoHijo As String,
    vinculoFamiliar As Integer,
    tipoDocVinculante As Integer,
    nroDocVinculante As String,
    documentovinculofamiliar As String
)
        Dim nuevoRegistro As DataRow = DtDetalle.NewRow()
        nuevoRegistro("DNI") = nroDocHijo

        Dim fechaConcepcionDate As DateTime
        If DateTime.TryParse(fechaConcepcion, fechaConcepcionDate) Then
            nuevoRegistro("Mes concepcion") = fechaConcepcionDate
        Else
            nuevoRegistro("Mes concepcion") = DBNull.Value
        End If

        Dim fechaNacimientoh As DateTime
        If DateTime.TryParse(fechaNacimientohijo, fechaNacimientoh) Then
            nuevoRegistro("FechaNacimiento") = fechaNacimientoh
        Else
            nuevoRegistro("FechaNacimiento") = DBNull.Value
        End If
        nuevoRegistro("Sexo") = sexohijo
        nuevoRegistro("TipodocHijo") = tipoDocIdentidadHijo
        nuevoRegistro("Nombre") = nombreHijo
        nuevoRegistro("Apellido Paterno") = apPaternoHijo
        nuevoRegistro("Apellido Materno") = apMaternoHijo
        nuevoRegistro("Vinculofamiliar") = vinculoFamiliar
        nuevoRegistro("TipoDocVinculante") = tipoDocVinculante
        nuevoRegistro("N_Doc_Vinculo") = nroDocVinculante
        If System.IO.File.Exists(documentovinculofamiliar) Then
            Dim fileBytes As Byte() = System.IO.File.ReadAllBytes(documentovinculofamiliar)
            nuevoRegistro("PDF") = fileBytes
        Else
            nuevoRegistro("PDF") = DBNull.Value
        End If
        DtDetalle.Rows.Add(nuevoRegistro)

        ' Si necesitas actualizar un DataGridView para reflejar los cambios
        dtgListadodeHijos.DataSource = DtDetalle
        dtgListadodeHijos.Refresh() ' Actualiza la vista

    End Sub
    Private Sub dtgListadodeHijos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListadodeHijos.InitializeLayout
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListadodeHijos)
            With e.Layout.Bands(0)
                ' Configuración de columnas por índice
                .Columns(0).Header.Caption = "idpersonahijo"
                .Columns(1).Header.Caption = "DNI"
                .Columns(2).Header.Caption = "Fecha Nacimiento"
                .Columns(2).Format = "dd/MM/yyyy" ' Formato de fecha
                .Columns(3).Header.Caption = "Concepcion"
                .Columns(3).Format = "dd/MM/yyyy" ' Formato de fecha
                .Columns(4).Header.Caption = "Sexo"
                .Columns(5).Header.Caption = "TipodocHijo"
                .Columns(6).Header.Caption = "Nombre"
                .Columns(7).Header.Caption = "A. paterno"
                .Columns(8).Header.Caption = "A. Materno"
                .Columns(9).Header.Caption = "Vinculo"
                .Columns(10).Header.Caption = "Tipo de Vinculo"
                .Columns(11).Header.Caption = "N_Doc_Vinculo"
                If .Columns.Exists("Ver PDF") Then
                    .Columns("Ver PDF").Style = UltraWinGrid.ColumnStyle.Button
                    .Columns("Ver PDF").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                    .Columns("Ver PDF").Header.Caption = "Ver PDF"
                    .Columns("Ver PDF").CellAppearance.TextHAlign = HAlign.Center
                    For Each row As UltraGridRow In dtgListadodeHijos.Rows
                        row.Cells("Ver PDF").Value = "Ver PDF" ' Agregar texto en cada celda
                    Next
                Else
                    Dim column As UltraWinGrid.UltraGridColumn = .Columns.Add("Ver PDF")
                    column.Style = UltraWinGrid.ColumnStyle.Button
                    column.ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                    column.Header.Caption = "Ver PDF"
                    column.CellAppearance.TextHAlign = HAlign.Center
                    For Each row As UltraGridRow In dtgListadodeHijos.Rows
                        row.Cells("Ver PDF").Value = "Ver PDF" ' Agregar texto en cada celda
                    Next
                End If
                .Columns(13).Header.Caption = "Estado"
                .Columns(14).Header.Caption = "Motivo Baja"
                .Columns(15).Header.Caption = "Fecha de baja"
                If Not e.Layout.Bands(0).Columns.Exists("Ver PDF") Then
                    Dim column As Infragistics.Win.UltraWinGrid.UltraGridColumn = e.Layout.Bands(0).Columns.Add("Ver PDF")
                    column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                    column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                End If
                For Each columnns As UltraGridColumn In e.Layout.Bands(0).Columns
                    columnns.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                Next
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListadodeHijos_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListadodeHijos.ClickCellButton
        Try
            If e.Cell.Column.Key = "Ver PDF" Then
                Dim idhijo As Integer = CInt(e.Cell.Row.Cells("idpersonahijo").Value)
                Dim pdfData As Byte() = New cnControlEpp().Cn_ObtenerArchivo(idhijo)
                If pdfData IsNot Nothing AndAlso pdfData.Length > 0 Then
                    Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "recepcion.pdf")
                    File.WriteAllBytes(tempFilePath, pdfData)
                    Process.Start(tempFilePath)
                Else
                    MessageBox.Show("No se encontró el archivo PDF en la base de datos.")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub dtgListadodeHijos_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs)
        Try
            If e.Cell IsNot Nothing Then
                Dim dniHijo As String = e.Cell.Row.Cells(0).Text ' Ajusta "N°Doc" al nombre exacto de tu columna
            Else
                MessageBox.Show("Por favor, selecciona una fila válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cbxtipopago_sb_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
    End Sub
    Private Sub cbxtipopago_se_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
    End Sub

    Private Sub CheckBoxCapa_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBoxCapa.CheckedChanged
        clsBasicas.Filtrar_Tabla(dtgListadoCapa, CheckBoxCapa.Checked)
    End Sub
    Private Sub CheckBoxEpp_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBoxEpp.CheckedChanged
        clsBasicas.Filtrar_Tabla(dtgListadoEpp, CheckBoxEpp.Checked)
    End Sub
    Private Sub CheckBoxMemo_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMemo.CheckedChanged
        clsBasicas.Filtrar_Tabla(dtgListadoMemo, CheckBoxMemo.Checked)
    End Sub
    'Botones de agregar Fotos
    Private Sub btnseleccionar1_Click_1(sender As Object, e As EventArgs) Handles btnseleccionar1.Click
        Dim ofd As New OpenFileDialog()
        ofd.Title = "Seleccionar Imagen"
        ofd.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp"
        ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        If ofd.ShowDialog() = DialogResult.OK Then
            picFoto.Image = Image.FromFile(ofd.FileName)
            loadNewImageFoto = True
        End If
    End Sub
    Private Sub btnseleccionar2_Click_1(sender As Object, e As EventArgs) Handles btnseleccionar2.Click
        Dim ofd As New OpenFileDialog()
        ofd.Title = "Seleccionar Imagen"
        ofd.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp"
        ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        If ofd.ShowDialog() = DialogResult.OK Then
            picfirma.Image = Image.FromFile(ofd.FileName)
            leadNewImageFirma = True
        End If
    End Sub

    Private Sub cbxasignacionfamiliar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxasignacionfamiliar.SelectedIndexChanged
        If cbxasignacionfamiliar.Text = "NO" Then
            btnAgregarHijo.Visible = False
            btneditarhijos.Visible = False
            btnbajaderechodehabientos.Visible = False
        ElseIf cbxasignacionfamiliar.Text = "SI" Then
            btnAgregarHijo.Visible = True
            btneditarhijos.Visible = True
            btnbajaderechodehabientos.Visible = True
        End If
    End Sub
    Private Sub txtnombre_TextChanged(sender As Object, e As EventArgs) Handles txtnombre.TextChanged
        If System.Text.RegularExpressions.Regex.IsMatch(txtnombre.Text, "\d") Then
            txtnombre.Text = System.Text.RegularExpressions.Regex.Replace(txtnombre.Text, "\d", "")
            txtnombre.SelectionStart = txtnombre.Text.Length
        End If
    End Sub
    Private Sub txtpaterno_TextChanged(sender As Object, e As EventArgs) Handles txtpaterno.TextChanged
        If System.Text.RegularExpressions.Regex.IsMatch(txtpaterno.Text, "\d") Then
            txtpaterno.Text = System.Text.RegularExpressions.Regex.Replace(txtpaterno.Text, "\d", "")
            txtpaterno.SelectionStart = txtpaterno.Text.Length
        End If
    End Sub
    Private Sub txtmaterno_TextChanged(sender As Object, e As EventArgs) Handles txtmaterno.TextChanged
        If System.Text.RegularExpressions.Regex.IsMatch(txtmaterno.Text, "\d") Then
            txtmaterno.Text = System.Text.RegularExpressions.Regex.Replace(txtmaterno.Text, "\d", "")
            txtmaterno.SelectionStart = txtmaterno.Text.Length
        End If
    End Sub
    Private Sub txtocupacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtocupacion.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ConsultarContratoPorIdPersona()
    End Sub


    Private Sub CheckBoxX2_CheckedChanged(sender As Object, e As EventArgs)
        clsBasicas.Filtrar_Tabla(dtg_listadocontratos, CheckBoxMemo.Checked)
    End Sub
    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            If (dtg_listadocontratos.Rows.Count > 0) Then
                Dim idContrato As Integer = CInt(dtg_listadocontratos.ActiveRow.Cells("idContrato").Value)

                If idContrato > 0 Then
                    Dim f As New FrmContratos(Me)
                    f.esEdicion = 1
                    f.IdContrato = idContrato
                    f.Consultar2()
                    f.ShowDialog()
                    Dispose()
                Else
                    msj_advert("Seleccione un Registro válido")
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If
        Catch ex As Exception
            ' Controlar excepciones y mostrar detalles del error
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnnuevocontrato.Click
        Dim f As New FrmContratos(Me)
        f.esEdicion = 0
        f.ShowDialog()
        Dispose()
    End Sub

    Private Sub Nuevocontrato_Click(sender As Object, e As EventArgs) Handles Nuevocontrato.Click
        Dim f As New FrmContratos(Me)
        f.esEdicion = 0
        f.ShowDialog()
        Dispose()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ConsultarUbicacionPorIdPersona()
    End Sub

    Private Sub dtgubicacionpersona_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgubicacionpersona.InitializeLayout
        Try
            clsBasicas.Formato_Tablas_Grid(dtgubicacionpersona)
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "idUbicacionPersona"
                .Columns(1).Header.Caption = "Ubicacion Asignada"
                .Columns(2).Header.Caption = "Area Asignada"
                .Columns(3).Header.Caption = "Fecha de asignacion"
                .Columns(3).Format = "dd/MM/yyyy" ' Formato de fecha
                .Columns(4).Header.Caption = "ELIMINAR"
                .Columns(4).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(4).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(4).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns(4).CellClickAction = UltraWinGrid.CellClickAction.EditAndSelectText ' Para asegurar que el botón sea clickeable
                For Each columnns As UltraGridColumn In e.Layout.Bands(0).Columns
                    columnns.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                Next
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub dtgubicacionpersona_ClickCellButton(sender As Object, e As CellEventArgs) Handles dtgubicacionpersona.ClickCellButton
        If e.Cell.Column.Key = "ELIMINAR" Then
            Dim rowIndex As Integer = e.Cell.Row.Index
            If rowIndex >= 0 AndAlso rowIndex < ds.Tables(0).Rows.Count Then
                Dim idubicacion As String = ds.Tables(0).Rows(rowIndex)("idUbicacionPersona").ToString()
                Dim trabajador As New coTrabajador()
                trabajador.idubicacionpersona = idubicacion

                Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar esta ubicación?",
                                                    "Confirmar Eliminación",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    Try
                        cn_item.Cn_EliminarUbicacion(trabajador)
                        ' Después de la eliminación, verificamos el código de error
                        If trabajador.Coderror = 1 Then
                            MessageBox.Show(trabajador.Mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ds.Tables(0).Rows.RemoveAt(rowIndex)
                            ds.Tables(0).AcceptChanges()
                            dtgubicacionpersona.DataSource = ds.Tables(0)
                            dtgubicacionpersona.Refresh()
                        Else
                            MessageBox.Show(trabajador.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error al eliminar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Else
                MessageBox.Show("Fila no válida para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnañadirplanteles_Click(sender As Object, e As EventArgs) Handles btnañadirplanteles.Click
        Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea guardar la ubicación?", "Confirmar Guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            InsertarUbicacion()
            ConsultarUbicacionPorIdPersona()
        End If
    End Sub

    Sub InsertarUbicacion()
        Try
            If _operacion <> 1 AndAlso _operacion <> 2 OrElse txtCodigo.Text <> "" AndAlso txtCodigo.Text.Length <> 0 Then
                If _operacion = 0 OrElse _operacion = 1 Then
                    If cbxplantel.Value Is Nothing Then
                        msj_advert("Seleccione un Plantel")
                        Return
                    End If
                    If cbxarea.Value Is Nothing Then
                        msj_advert("Seleccione una area")
                        Return
                    End If
                End If

                Dim obj As New coTrabajador
                obj.IdPersona = _Codigo
                obj.IdUbicacion = cbxplantel.Value
                obj.IdArea = cbxarea.Value
                obj.IdUsuario = VariablesGlobales.VP_IdUser
                _mensajeBgWk = cn_item.Cn_InsertarUbicacion(obj)
                If obj.Coderror = 0 Then
                    MessageBox.Show("Operación exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    MessageBox.Show("Operación exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            Else
                msj_advert("Seleccione un Registro")
                Return
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Sub InsertarBajaTrabajador()
        Try


            Dim obj As New coTrabajador With {
            .IdPersona = _Codigo,
            .IdUsuario = VariablesGlobales.VP_IdUser,
            .idmotivobajatrabajador = cbxmotivobaja.Value,
            .FechaBaja = dtpfechabaja.Value
        }
            Dim mensaje As String = cn_item.Cn_InsertarBajatrabajador(obj)
            If obj.Coderror = 0 Then
                MessageBox.Show("Operación exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            ' Manejo de la excepción
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btnAgregarHijo.Click
        Dim f As New FrmDerechoHabientes(Me)
        f.esEdicion = 0
        f.ShowDialog()
    End Sub

    Private Sub btnbuscarhijo_Click(sender As Object, e As EventArgs) Handles btnbuscarhijo.Click
        ConsultarHijosPorIdPersona()
    End Sub


    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btneditarhijos.Click
        Try
            If (dtgListadodeHijos.Rows.Count > 0) Then
                Dim idhijo As Integer = CInt(dtgListadodeHijos.ActiveRow.Cells("idpersonahijo").Value)

                If idhijo > 0 Then
                    Dim f As New FrmDerechoHabientes(Me)
                    f.esEdicion = 1
                    f.idhijo = idhijo
                    f.Consultar3()
                    f.ShowDialog()

                Else
                    msj_advert("Seleccione un Registro válido")
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxplantel_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxplantel.InitializeLayout
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
    End Sub

    Private Sub cbxListarPasaporte_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxListarPasaporte.InitializeLayout
        e.Layout.Bands(0).Columns(0).Hidden = True
        e.Layout.Bands(0).Columns(1).Hidden = True
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
    End Sub
    Private Sub cbxListarPasaporte_Enter(sender As Object, e As EventArgs) Handles cbxListarPasaporte.Enter
        cbxListarPasaporte.PerformAction(UltraComboAction.Dropdown) 'clic directo
    End Sub
    Private Sub cbxListarPasaporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxListarPasaporte.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        ConsultarSCTRPorIdPersona()
    End Sub

    Private Sub dtgsctr_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgsctr.InitializeLayout
        e.Layout.Bands(0).Columns(0).Hidden = True
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea guardar?", "Confirmar Guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If cbxmotivobaja.SelectedRow IsNot Nothing AndAlso cbxmotivobaja.SelectedRow.Index > 0 Then
                cbxestado.SelectedIndex = 1 ' Inactivo
                btnGuardar.Enabled = False ' Inactivo
            Else
                cbxestado.SelectedIndex = 0 ' Activo
            End If
            If _operacion = 0 OrElse _operacion = 1 Then
                If cbxmotivobaja.Text.Length = 20 Then
                    msj_advert("Seleccione un motivo")
                    Return
                End If
                InsertarBajaTrabajador()
                ConsultarBajatrabajador()
                Dispose()
            End If


        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ConsultarBajatrabajador()
    End Sub

    Private Sub txtnumdoc_TextChanged(sender As Object, e As EventArgs) Handles txtnumdoc.TextChanged
        Dim maxLength As Integer = 0
        Dim valorevisar As Integer = 0
        If (_Codigo <> 0) Then
            valorevisar = valorcbtipodoc
        Else
            valorevisar = cbxtipodocidentidad.SelectedRow.Cells(0).Value
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
        Dim cursorPosition As Integer = txtnumdoc.SelectionStart ' Guardar posición del cursor
        txtnumdoc.Text = New String(txtnumdoc.Text.Where(Function(c) Char.IsDigit(c)).ToArray())
        txtnumdoc.SelectionStart = Math.Min(cursorPosition, txtnumdoc.Text.Length) ' Restaurar posición del cursor

    End Sub

    Private Sub txtcelular_TextChanged(sender As Object, e As EventArgs) Handles txtcelular.TextChanged
        Dim cursorPosition As Integer = txtcelular.SelectionStart ' Guardar posición del cursor
        txtcelular.Text = New String(txtcelular.Text.Where(Function(c) Char.IsDigit(c)).ToArray())
        txtcelular.SelectionStart = Math.Min(cursorPosition, txtcelular.Text.Length) ' Restaurar posición del cursor
    End Sub

    Private Sub cbxtipodocidentidad_ValueChanged(sender As Object, e As EventArgs) Handles cbxtipodocidentidad.ValueChanged
        Debug.Print("Evento ValueChanged ejecutado")
        Dim selectedRow = cbxtipodocidentidad.SelectedRow
        If selectedRow IsNot Nothing AndAlso selectedRow.Index = 1 Then
            cbxListarPasaporte.Enabled = True
        Else
            cbxListarPasaporte.Enabled = False
        End If
    End Sub

    Private Sub cbxtipodocidentidad_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxtipodocidentidad.InitializeLayout
        e.Layout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        e.Layout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
        For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In e.Layout.Bands(0).Columns
            col.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.None
        Next
        e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False
        e.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select
    End Sub
    Private Sub CrearTablaVisualizacion()
        Dim seguros As New DataTable
        seguros.Columns.Add("Fecha de Emisión", GetType(Integer))
        seguros.Columns.Add("Fecha de Fin", GetType(String))
        seguros.Columns.Add("N° de Documento", GetType(Integer))
        seguros.Columns.Add("Asegurado", GetType(String))
        seguros.Columns.Add("N°Poliza", GetType(String))
        seguros.Columns.Add("Proveedor", GetType(String))
        seguros.Columns.Add("N° Contrato", GetType(String))
        seguros.Columns.Add("Ver PDF", GetType(String))
        seguros.Columns.Add("Estado", GetType(String))
        dtgsctr.DataSource = seguros
        clsBasicas.Formato_Tablas_Grid(dtgsctr)

        Dim Contrato As New DataTable
        Contrato.Columns.Add("fInicio", GetType(Integer))
        Contrato.Columns.Add("fFin", GetType(String))
        Contrato.Columns.Add("Salario", GetType(Integer))
        Contrato.Columns.Add("N° Cuenta", GetType(String))
        Contrato.Columns.Add("Banco", GetType(String))
        Contrato.Columns.Add("Salario Extra", GetType(String))
        Contrato.Columns.Add("N°Cuenta Extra", GetType(String))
        Contrato.Columns.Add("Banco Extra", GetType(String))
        Contrato.Columns.Add("Codigo", GetType(String))
        Contrato.Columns.Add("Tipo Contrato", GetType(String))
        Contrato.Columns.Add("ESTADO", GetType(String))
        dtg_listadocontratos.DataSource = Contrato

        With dtg_listadocontratos.DisplayLayout.Bands(0)
            Dim groupGeneral As UltraGridGroup = .Groups.Add("Periodo", "Periodo")
            Dim group1 As UltraGridGroup = .Groups.Add("DATOS SALARIO BASE", "DATOS SALARIO BASE")
            Dim group2 As UltraGridGroup = .Groups.Add("DATOS SALARIO EXTRA", "DATOS SALARIO EXTRA")
            Dim group3 As UltraGridGroup = .Groups.Add("CONTRATO", "CONTRATO")
            ' Asignar columnas a los grupos
            .Columns("fInicio").Group = groupGeneral
            .Columns("fFin").Group = groupGeneral
            .Columns("Salario").Group = group1
            .Columns("N° Cuenta").Group = group1
            .Columns("Banco").Group = group1
            .Columns("Salario Extra").Group = group2
            .Columns("N°Cuenta Extra").Group = group2
            .Columns("Banco Extra").Group = group2
            .Columns("Codigo").Group = group3
            .Columns("Tipo Contrato").Group = group3
            .Columns("ESTADO").Group = group3
        End With
        clsBasicas.Formato_Tablas_Grid(dtg_listadocontratos)
    End Sub

    Private Sub cbPconfianza_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPconfianza.SelectedIndexChanged
        If cbPconfianza.SelectedItem.ToString() = "SI" Then
            cbListanegra.SelectedItem = "NO"
        End If
    End Sub

    Private Sub cbListanegra_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbListanegra.SelectedIndexChanged
        If cbListanegra.SelectedItem.ToString() = "SI" Then
            cbPconfianza.SelectedItem = "NO"
        End If
    End Sub

    Private Sub btnbajaderechodehabientos_Click(sender As Object, e As EventArgs) Handles btnbajaderechodehabientos.Click
        Try
            If (dtgListadodeHijos.Rows.Count > 0) Then
                Dim idhijo As Integer = CInt(dtgListadodeHijos.ActiveRow.Cells("idpersonahijo").Value)

                If idhijo > 0 Then
                    Dim f As New FrmBajaDerechoHabiento(Me)
                    f.idhijo = idhijo
                    f.Consultar3()
                    f.ShowDialog()

                Else
                    msj_advert("Seleccione un Registro válido")
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Consultarsueldosporidpersona()
    End Sub

    Private Sub cbCargosistema_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbCargosistema.InitializeLayout
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
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

    Private Sub UltraGrid1_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgpermisoslaborales.InitializeLayout

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        ConsultarPermisosTrabajador()
    End Sub

End Class
