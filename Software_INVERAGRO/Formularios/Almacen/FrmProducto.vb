Imports CapaNegocio
Imports CapaObjetos

Public Class FrmProducto
    Dim cn_item As New cnProducto
    Dim _mensajeBgWk As String = ""
    Dim _operacion As Integer = 0
    Dim _Codmarca As Integer = 0
    Dim _Codcategoria As Integer = 0
    Public _Codigo As Integer = 0
    Private _Lotes As String = ""
    Private _AfectoIgv As String = ""
    Private _Comprar As String = ""
    Private _Vender As String = ""
    Private _esmolino As String = ""
    Private _esRacionExterna As Boolean
    Private _idunidadamedida As Integer
    Private _idpresentacion As Integer
    Dim vista As New DataView
    Dim codProductoEq As Integer = 0

    Sub Mantenimiento()
        Try
            If _operacion <> 1 AndAlso _operacion <> 2 OrElse txtCodigo.Text <> "" AndAlso txtCodigo.Text.Length <> 0 Then
                If _operacion = 0 OrElse _operacion = 1 Then
                    If cbxcategoria.Value Is Nothing Then
                        msj_advert("Seleccione una Categoría")
                        Return
                    End If
                    If cbxMarca.Value Is Nothing Then
                        msj_advert("Seleccione una Marca")
                        Return
                    End If
                    If cbxpresentacion.Value Is Nothing Then
                        msj_advert("Seleccione una Presentación")
                        Return
                    End If
                    If cbunidadmedida.Value Is Nothing Then
                        msj_advert("Seleccione una Unidad de Medida")
                        Return
                    End If
                    If (txtvalorcantidadporpresentacion.Text.Length = 0) Then
                        txtvalorcantidadporpresentacion.Select()
                        msj_advert("Valor Cantidad por Presentación no Válido")
                        Return
                    End If

                    If (txtDescripcion.Text.Length = 0) Then
                        txtDescripcion.Select()
                        msj_advert("Descripción no Válida")
                        Return
                    End If
                    If (txtObservacion.Text.Length = 0) Then
                        txtObservacion.Select()
                        msj_advert("Observación no Válida")
                        Return
                    End If

                    If (txtprincipioactivo.Text.Length = 0) Then
                        txtprincipioactivo.Select()
                        msj_advert("Principio Activo no Válido")
                        Return
                    End If
                    If (txtStockMinimo.Text.Length = 0) Then
                        txtStockMinimo.Select()
                        msj_advert("Stock Minimo no Válido")
                        Return
                    End If
                    If (txtequivalencia.Text.Length = 0) Then
                        txtequivalencia.Select()
                        msj_advert("Equivalencia no Válida")
                        Return
                    End If
                End If

                If Not BackgroundWorker2.IsBusy Then
                    estado = IIf(cbxEstado.SelectedIndex = 0, "A", "I")
                    _Codigo = IIf(txtCodigo.Text.Length = 0, 0, txtCodigo.Text)
                    _Lotes = IIf(rbtSi.Checked, "SI", "NO")
                    _idunidadamedida = cbunidadmedida.Value
                    _idpresentacion = cbxpresentacion.Value
                    _Comprar = IIf(ckcompras.Checked, "SI", "NO")
                    _Vender = IIf(ckventas.Checked, "SI", "NO")
                    _AfectoIgv = IIf(ckafectoigv.Checked, "SI", "NO")
                    _esmolino = cbesmolino.Text
                    _esRacionExterna = If(CbxRacionExterna.Checked, 1, 0)
                    If (_Codigo = 0) Then
                        Obtener_UltimoCodigo()
                    End If
                    BackgroundWorker2.RunWorkerAsync()
                End If
            Else
                msj_advert("Seleccione un Registro")
                Return
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Dim estado As String = ""
    Dim ultimo_codigo As String = ""
    Sub Obtener_UltimoCodigo()
        Try
            Dim obj As New coProductos
            ' ultimo_codigo = cn_item.Cn_ObtenerUltimoCodigoItem(obj)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            _mensajeBgWk = ""
            Dim obj As New coProductos
            obj.Operacion = _operacion
            obj.Idproducto = _Codigo
            obj.Idmarca = cbxMarca.Value
            obj.Descripcion = txtDescripcion.Text
            obj.Observacion = txtObservacion.Text
            obj.Stockminimo = txtStockMinimo.Text
            obj.IdUnidadMedida = _idunidadamedida
            obj.Codigobarras = "0"
            obj.PrincioActivo = txtprincipioactivo.Text
            obj.Estado = estado
            obj.Lotes = _Lotes
            obj.AfectoIgv = _AfectoIgv
            obj.Equivalencia = txtequivalencia.Text
            If String.IsNullOrWhiteSpace(txtvalorcantidadporpresentacion.Text) Then
                obj.uniporpresentacion = 1
            Else
                obj.uniporpresentacion = (Convert.ToDecimal(txtvalorcantidadporpresentacion.Text))
            End If
            obj.Idpresentacion = _idpresentacion
            obj.Comprar = _Comprar
            obj.Vender = _Vender
            obj.esmolino = _esmolino
            obj.EsRacionExterna = _esRacionExterna
            obj.IdProductoEquivalencia = codProductoEq
            _mensajeBgWk = cn_item.Cn_Mantenimiento(obj)

            e.Result = obj.Coderror
        Catch ex As Exception
            e.Cancel = True
            _mensajeBgWk = ex.Message
        End Try
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        Try
            If e.Error IsNot Nothing OrElse e.Cancelled Then
                MsgBox(_mensajeBgWk)
            Else
                If e.Result.ToString = 0 Then
                    msj_ok(_mensajeBgWk)
                    Close()
                Else
                    msj_advert(_mensajeBgWk)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub FMant_Linea_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Dim ruta_foto_editar As String = ""
    Sub ConsultarItems()
        Dim obj As New coProductos
        Dim cn As New cnProducto
        obj.Idproducto = _Codigo
        Dim tb As New DataTable
        tb = cn.Cn_Consultar_x_codigo(obj).Copy
        tb.TableName = "tmp"
        txtCodigo.Text = tb.Rows(0)(0).ToString()
        cbxcategoria.Value = tb.Rows(0)(1).ToString()
        cbxMarca.Value = tb.Rows(0)(2).ToString()

        txtDescripcion.Text = tb.Rows(0)(3).ToString()
        txtStockMinimo.Text = tb.Rows(0)(4).ToString()

        If (tb.Rows(0)(5).ToString() = "SI") Then
            rbtSi.Checked = True
        Else
            rbtNo.Checked = True
        End If
        If (tb.Rows(0)(6).ToString() = "SI") Then
            ckafectoigv.Checked = True
        Else
            ckafectoigv.Checked = False
        End If

        txtObservacion.Text = tb.Rows(0)(8).ToString()
        cbunidadmedida.Value = tb.Rows(0)(9).ToString()
        txtcodigobarras.Text = tb.Rows(0)(10).ToString()
        txtcodigobarras.Data = tb.Rows(0)(10).ToString()
        txtprincipioactivo.Text = tb.Rows(0)(11).ToString()
        ultimo_codigo = _Codigo
        If tb.Rows(0)(7).ToString.Trim = "A" Then
            cbxEstado.SelectedIndex = 0
        Else
            cbxEstado.SelectedIndex = 1
        End If
        cbxpresentacion.Value = tb.Rows(0)(12).ToString()
        txtequivalencia.Text = tb.Rows(0)(13).ToString()

        If tb.Rows(0)(14).ToString.Trim = "SI" Then
            ckcompras.Checked = True
        Else
            ckcompras.Checked = False
        End If
        If tb.Rows(0)(15).ToString.Trim = "SI" Then
            ckventas.Checked = True
        Else
            ckventas.Checked = False
        End If
        cbesmolino.Text = tb.Rows(0)(16).ToString()
        txtvalorcantidadporpresentacion.Text = tb.Rows(0)(17).ToString()
        CbxRacionExterna.Checked = If(tb.Rows(0)(18).ToString(), True, False)
        codProductoEq = tb.Rows(0)("idProductoEquivalencia").ToString()
        TxtNombreEqProducto.Text = tb.Rows(0)("nombreProductoEq").ToString()
        TxtEqProducto.Text = tb.Rows(0)("equivalenciaProEq").ToString()
    End Sub

    Private Sub FrmItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TxtNombreEqProducto.ReadOnly = True
            TxtEqProducto.ReadOnly = True
            ListarCategorias()
            ListarUnidadMedida()
            ListarPresentacion()
            cbxEstado.SelectedIndex = 0
            cbesmolino.SelectedIndex = 0
            If (_Codigo <> 0) Then
                _operacion = 1
                ConsultarItems()
            Else
                cbxEstado.Enabled = False
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Mantenimiento()
    End Sub

    Sub ListarCategorias()
        Dim cn As New cnProducto
        Dim tb As New DataTable
        tb = cn.Cn_ListCategoria().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Categoría"
        With cbxcategoria
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub
    Sub ListarUnidadMedida()
        Dim obj As New coProductos
        Dim cn As New cnProducto
        obj.Descripcion = ""
        Dim tb As New DataTable
        tb = cn.Cn_ListUnidadMedida(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Unidad Medida"
        With cbunidadmedida
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub
    Sub ListarPresentacion()
        Dim obj As New coProductos
        Dim cn As New cnProducto
        obj.Descripcion = ""
        Dim tb As New DataTable
        tb = cn.Cn_ListPresentaciones(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Presentacion"
        With cbxpresentacion
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub
    Sub ListarMarcas(codcategoria As Integer)
        Dim obj As New coProductos
        Dim cn As New cnProducto
        obj.IdCategoria = codcategoria
        Dim tb As New DataTable
        tb = cn.Cn_ListMarcas(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Marca"
        With cbxMarca
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub
    Private Sub cbxcategoria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbxcategoria.RowSelected
        Try
            ListarMarcas(cbxcategoria.Value)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub txtStockMinimo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStockMinimo.KeyPress
        clsBasicas.ValidarNumerosDecimales(e)
    End Sub

    Private Sub txtequivalencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtequivalencia.KeyPress
        clsBasicas.ValidarNumerosDecimales(e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim f As New FrmUnidadMedida
            f.ShowDialog()
            ListarUnidadMedida()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            Dim f As New FrmPresentacionProducto
            f.ShowDialog()
            ListarPresentacion()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Try
            Dim f As New FrmMarca
            f.ShowDialog()
            ListarMarcas(cbxcategoria.Value)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Try
            Dim f As New FrmCategoriaProducto
            f.ShowDialog()
            ListarCategorias()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxpresentacion_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cbxpresentacion.InitializeLayout, cbunidadmedida.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "Codigo"
                .Columns(1).Header.Caption = "Descripción"
                .Columns(2).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub txtequivalencia_TextChanged(sender As Object, e As EventArgs) Handles txtequivalencia.TextChanged

    End Sub

    Private Sub txtvalorcantidadporpresentacion_TextChanged(sender As Object, e As KeyPressEventArgs) Handles txtvalorcantidadporpresentacion.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub Servicio_CheckedChanged(sender As Object, e As EventArgs) Handles Servicio.CheckedChanged
        If Servicio.Checked Then
            txtcodigobarras.Enabled = False
            txtprincipioactivo.Enabled = False
            txtprincipioactivo.Text = " "
            txtStockMinimo.Enabled = False
            txtStockMinimo.Text = "1"
            txtequivalencia.Enabled = False
            txtequivalencia.Text = "1"
            txtvalorcantidadporpresentacion.Enabled = False
            txtvalorcantidadporpresentacion.Text = "1"
            cbxcategoria.Value = 1022
            cbxcategoria.Enabled = False
            Button4.Enabled = False
        Else
            txtcodigobarras.Enabled = True
            txtprincipioactivo.Enabled = True
            txtprincipioactivo.Text = ""
            txtStockMinimo.Enabled = True
            txtStockMinimo.Text = ""
            txtequivalencia.Enabled = True
            txtequivalencia.Text = ""
            txtvalorcantidadporpresentacion.Enabled = True
            txtvalorcantidadporpresentacion.Text = ""
            cbxcategoria.Enabled = True
            Button4.Enabled = True
        End If
    End Sub

    Private Sub BtnProductoEquivalencia_Click(sender As Object, e As EventArgs) Handles BtnProductoEquivalencia.Click
        Try
            Dim frm As New FrmListaProductoEquivalencia(Me)
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposProductoEquivalencia(codigo As Integer, nombre As String, equivalencia As String)
        codProductoEq = codigo
        TxtNombreEqProducto.Text = nombre
        TxtEqProducto.Text = equivalencia
    End Sub

    Private Sub CbxQuitarEquivalencia_CheckedChanged(sender As Object, e As EventArgs) Handles CbxQuitarEquivalencia.CheckedChanged
        If CbxQuitarEquivalencia.Checked Then
            codProductoEq = 0
            TxtNombreEqProducto.Text = ""
            TxtEqProducto.Text = ""
        End If
    End Sub

    Private Sub bcerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
End Class
