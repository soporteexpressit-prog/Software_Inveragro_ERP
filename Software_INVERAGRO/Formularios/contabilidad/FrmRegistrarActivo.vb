Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRegistrarActivo
    Dim cn As New cnActivo
    Public _Codigo As Integer = 0
    Public idDetalleRecepcion As Integer = 0
    Public numOrden As Integer = 0
    Public nombreProducto As String = ""
    Public fechaAdquisicion As Date = Nothing
    Public tipo As String = ""
    Public precioUnitario As Decimal = 0
    Dim _operacion As Integer = 0
    Dim _mensajeBgWk As String = ""
    Public Property formListarActivoRegistrar As FrmListaActivoRegistrar
    Public Property formControlActivo As FrmControlActivo


    Private Sub FrmRegistrarActivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarCategoriaActivo()
        If (_Codigo <> 0) Then
            _operacion = 1
            Consultar()
        Else
            cmbEstado.SelectedIndex = 0
            txtDescripcion.Text = nombreProducto
            cmbEstado.Enabled = False
        End If

        If (tipo = "INDIVIDUAL") Then
            Me.Size = New Size(790, 450)
            Me.CenterToScreen()
        Else
            Me.Size = New Size(282, 470)
            lblCategoria.Location = New Point(12, 40)
            cmbCategoria.Location = New Point(12, 60)
            lblTipoActivo.Location = New Point(12, 100)
            cmbTipoActivo.Location = New Point(12, 120)
            lblMarca.Location = New Point(12, 160)
            cmbMarca.Location = New Point(12, 180)
            lblDescripcion.Location = New Point(12, 220)
            txtDescripcion.Location = New Point(12, 240)
            lblVidaUtil.Location = New Point(12, 280)
            txtVidaUtil.Location = New Point(12, 300)
            lblNumSerie.Visible = False
            txtNumSerie.Visible = False
            lblNota.Visible = False
            txtNota.Visible = False
            lblPlaca.Visible = False
            txtPlaca.Visible = False
            lblCapacidad.Visible = False
            txtCapacidad.Visible = False
            lblEstado.Visible = False
            cmbEstado.Visible = False
            Me.CenterToScreen()
        End If
    End Sub

    Sub ListarCategoriaActivo()
        Dim cn As New cnCategoriaActivo
        Dim tb As New DataTable
        tb = cn.Cn_ListarConTipoActivo().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Categoria"
        With cmbCategoria
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub
    Sub ListarTiposActivo(idCategoria As Integer)
        Dim cn As New cnTipoActivo
        Dim tb As New DataTable
        Dim obj As New coTipoActivo
        obj.IdCategoriaActivo = idCategoria
        tb = cn.Cn_Listar_Tipo_Activo_Por_Categoria(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Galpón"
        With cmbTipoActivo
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarMarcaActivo(idTipo As Integer)
        Dim cn As New cnMarcaActivo
        Dim tb As New DataTable
        Dim obj As New coMarcaActivo
        obj.IdTipoActivo = idTipo
        tb = cn.Cn_Listar_Marca_Activo_Por_Tipo(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Marca"
        With cmbMarca
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub cmbCategoria_ValueChanged(sender As Object, e As EventArgs) Handles cmbCategoria.ValueChanged
        Try
            ListarTiposActivo(cmbCategoria.Value)
            If (cmbCategoria.Text = "VEHÍCULOS" And tipo = "INDIVIDUAL") Then
                txtPlaca.Visible = True
                txtCapacidad.Visible = True
                lblPlaca.Visible = True
                lblCapacidad.Visible = True
            Else
                lblPlaca.Visible = False
                txtPlaca.Visible = False
                lblCapacidad.Visible = False
                txtCapacidad.Visible = False
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cmbTipoActivo_ValueChanged(sender As Object, e As EventArgs) Handles cmbTipoActivo.ValueChanged
        Try
            ListarMarcaActivo(cmbTipoActivo.Value)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Mantenimiento()
        Try
            If (tipo = "INDIVIDUAL") Then
                Dim _mensaje As String = ""
                If (txtDescripcion.Text = "" OrElse txtDescripcion.Text.Length = 0) Then
                    msj_advert("Descripción no válido")
                    Return
                ElseIf (txtNumSerie.Text = "" OrElse txtNumSerie.Text.Length = 0) Then
                    msj_advert("Nro Serie no Valida")
                    Return
                ElseIf txtVidaUtil.Value <= 0 Then
                    msj_advert("El valor de Vida Útil debe ser mayor a 0")
                    Return
                ElseIf (txtNota.Text = "" OrElse txtNota.Text.Length = 0) Then
                    msj_advert("Ingrese alguna caracteristica del activo")
                    Return
                End If

                Dim obj As New coActivo
                obj.Operacion = _operacion
                obj.Codigo = _Codigo
                obj.Descripcion = txtDescripcion.Text
                obj.FechaAdquisicion = fechaAdquisicion
                obj.Nota = txtNota.Text
                If String.IsNullOrWhiteSpace(txtPlaca.Text) OrElse txtPlaca.Text.ToUpper() = "NO APLICA" Then
                    obj.Placa = Nothing
                Else
                    obj.Placa = txtPlaca.Text
                End If
                obj.NumSerie = txtNumSerie.Text
                If String.IsNullOrWhiteSpace(txtCapacidad.Text) Then
                    obj.Capacidad = 0
                Else
                    obj.Capacidad = Convert.ToDecimal(txtCapacidad.Text)
                End If
                obj.Estado = cmbEstado.Text
                obj.IdUser = 1
                obj.CostoAdquisicion = precioUnitario
                obj.IdMarca = cmbMarca.Value
                obj.VidaUtil = txtVidaUtil.Text
                obj.IdDetalleRecepcion = idDetalleRecepcion
                obj.NumOrden = numOrden
                obj.Tipo = tipo

                _mensaje = cn.Cn_Mantenimiento(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(_mensaje)
                    If formListarActivoRegistrar IsNot Nothing Then
                        formListarActivoRegistrar.Consultar()
                    End If
                    If formControlActivo IsNot Nothing Then
                        formControlActivo.Consultar()
                    End If
                    Dispose()
                Else
                    msj_advert(_mensaje)
                End If
            Else
                Dim _mensaje As String = ""
                If txtVidaUtil.Value <= 0 Then
                    msj_advert("El valor de Vida Útil debe ser mayor a 0")
                    Return
                End If

                If (_operacion = 0) Then
                    txtNumSerie.Text = GenerarNumSerie(fechaAdquisicion, idDetalleRecepcion)
                End If

                Dim obj As New coActivo
                obj.Operacion = _operacion
                obj.Codigo = _Codigo
                obj.Descripcion = txtDescripcion.Text
                obj.FechaAdquisicion = fechaAdquisicion
                obj.Nota = txtNota.Text
                If String.IsNullOrWhiteSpace(txtPlaca.Text) Then
                    obj.Placa = Nothing
                Else
                    obj.Placa = txtPlaca.Text
                End If
                obj.NumSerie = txtNumSerie.Text
                If String.IsNullOrWhiteSpace(txtCapacidad.Text) Then
                    obj.Capacidad = 0
                Else
                    obj.Capacidad = Convert.ToDecimal(txtCapacidad.Text)
                End If
                obj.Estado = cmbEstado.Text
                obj.IdUser = 1
                obj.CostoAdquisicion = precioUnitario
                obj.IdMarca = cmbMarca.Value
                obj.VidaUtil = txtVidaUtil.Text
                obj.IdDetalleRecepcion = idDetalleRecepcion
                obj.NumOrden = numOrden
                obj.Tipo = tipo

                _mensaje = cn.Cn_Mantenimiento(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(_mensaje)
                    If formListarActivoRegistrar IsNot Nothing Then
                        formListarActivoRegistrar.Consultar()
                    End If
                    If formControlActivo IsNot Nothing Then
                        formControlActivo.Consultar()
                    End If
                    Dispose()
                Else
                    msj_advert(_mensaje)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub btnGuardarActivo_Click(sender As Object, e As EventArgs) Handles btnGuardarActivo.Click
        Mantenimiento()
    End Sub

    Private Sub txtVidaUtil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVidaUtil.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Function GenerarNumSerie(fechaAdquisicion As Date, idDetalleRecepcion As Integer) As String
        Dim año As String = fechaAdquisicion.Year.ToString()
        Dim horaActual As String = DateTime.Now.ToString("HHmmss")
        Dim numSerie As String = año & idDetalleRecepcion.ToString() & horaActual
        Return numSerie
    End Function

    Sub Consultar()
        Dim obj As New coActivo
        Dim cn As New cnActivo
        obj.Codigo = _Codigo
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarxId(obj).Copy
        tb.TableName = "tmp"
        Dim idTipoActivo As Integer = 0

        If tb.Rows.Count > 0 Then
            With tb.Rows(0)
                cmbCategoria.Text = .Item(9).ToString()
                idTipoActivo = Convert.ToInt32(.Item(10))
                txtDescripcion.Text = .Item(1).ToString()
                txtNumSerie.Text = .Item(2).ToString()
                cmbEstado.Text = .Item(3).ToString()
                txtPlaca.Text = .Item(4).ToString()
                txtCapacidad.Text = .Item(5).ToString()
                txtVidaUtil.Text = .Item(6).ToString()
                txtNota.Text = .Item(7).ToString()
                fechaAdquisicion = Convert.ToDateTime(.Item(8))
            End With
            Dim idCategoria As Integer = cmbCategoria.Value
            ListarTiposActivo(idCategoria)
            ListarMarcaActivo(idTipoActivo)
            cmbTipoActivo.Text = tb.Rows(0)(11).ToString()
            cmbMarca.Text = tb.Rows(0)(12).ToString()
        Else
            msj_advert("No se encontró ningún registro con el código especificado.")
        End If
    End Sub

    Private Sub txtCapacidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCapacidad.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class