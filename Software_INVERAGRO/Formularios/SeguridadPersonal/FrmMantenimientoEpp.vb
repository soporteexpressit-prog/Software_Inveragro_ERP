Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmMantenimientoEpp
    Dim _CodSolicitante As Integer
    Private DtDetalle As New DataTable("TempDetProdEpp")
    Dim cn As New cnControlEpp
    Dim idProducto As Integer = 0

    Private Sub FrmMantenimientoEpp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            CargarTablaDetalleProductoEpp()
            ListarTipoMotivoEpp()
            clsBasicas.ListarAlmacenesAsignados(CmbUbicacion)
            LimpiarCamposProductoEpp()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        dtpFecha.Value = Now.Date
        txtNumDoc.ReadOnly = True
        txtDatos.ReadOnly = True
        txtDescripcionEpp.ReadOnly = True
        txtPresentacion.ReadOnly = True
        TxtStock.ReadOnly = True
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
                .SelectedValue = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New FrmBuscarTrabajador(Me)
        f.ShowDialog()
    End Sub

    Public Sub LlenarCamposSolicitante(codigo As Integer, numDocumento As String, datos As String)
        _CodSolicitante = codigo
        txtNumDoc.Text = numDocumento
        txtDatos.Text = datos
    End Sub

    Public Sub LlenarCamposEpp(codigo As Integer, descripcion As String, presentacion As String, stock As Integer)
        idProducto = codigo
        txtDescripcionEpp.Text = descripcion
        txtPresentacion.Text = presentacion
        TxtStock.Text = stock
    End Sub

    Sub ListarTipoMotivoEpp()
        Dim cn As New cnTipoMotivoEpp
        Dim tb As New DataTable
        tb = cn.Cn_Listar().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Motivo de Entrega Epp"
        With cmbTipoMotivoEpp
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim epp As New FrmBuscarEpp(Me)
        epp.idplantel = CmbUbicacion.SelectedValue
        epp.ShowDialog()
    End Sub

    Sub CargarTablaDetalleProductoEpp()
        DtDetalle = New DataTable("TempDetProdEpp")
        DtDetalle.Columns.Add("codprod", GetType(Integer))
        DtDetalle.Columns.Add("producto", GetType(String))
        DtDetalle.Columns.Add("unidad", GetType(String))
        DtDetalle.Columns.Add("cantidad", GetType(Decimal))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        dtgListado.DataSource = DtDetalle
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(0).Width = 70
                .Columns(1).Header.Caption = "Producto"
                .Columns(1).Width = 200
                .Columns(2).Header.Caption = "Presentacion"
                .Columns(2).Width = 90
                .Columns(3).Header.Caption = "Cantidad"
                .Columns(3).Width = 65
                .Columns(4).Header.Caption = "Eliminar"
                .Columns(4).Width = 60
                .Columns(4).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(4).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(4).CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center
                .Columns(4).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE PRODUCTO?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetalle.Rows.RemoveAt(rowIndex)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle
            End If
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (_CodSolicitante < 1) Then
                msj_advert("Seleccione un Solicitante")
            ElseIf (dtgListado.Rows.Count = 0) Then
                msj_advert("Seleccione un Producto")
            Else

                If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR ENTREGA DE EPP?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim obj As New coControlEpp With {
                    .Fecha = dtpFecha.Value,
                    .IdSolicitante = _CodSolicitante,
                    .IdTipoMotivoEpp = cmbTipoMotivoEpp.Value,
                    .Iduser = VP_IdUser,
                    .IdUbicacion = CmbUbicacion.SelectedValue,
                    .Lista_items = CreacionArrayProductoEpp(),
                    .observacion = txtobservacion.Text
                }

                Dim MensajeBgWk As String = cn.Cn_RegistrarEpp(obj)
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

    Function CreacionArrayProductoEpp() As String
        Dim array_valvulas As String = ""
        If (dtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgListado.Rows.Count - 1
                If (dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtgListado.Rows(i)
                        array_valvulas = array_valvulas & .Cells("cantidad").Value.ToString.Trim & "+" &
                            .Cells("codprod").Value.ToString.Trim & ","
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
        Try
            If idProducto = 0 Then
                msj_advert("Seleccione un Producto")
                Return
            ElseIf txtCantidad.Text.Length = 0 Then
                msj_advert("Ingrese una Cantidad")
                Return
            ElseIf CDec(txtCantidad.Text) = 0 Then
                msj_advert("Por Favor Ingrese Cantidad válida")
                txtCantidad.Select()
                Return
            ElseIf txtCantidad.Text = 0 Then
                msj_advert("Por Favor Ingrese la Cantidad")
                txtCantidad.Select()
                Return
            ElseIf CDec(txtCantidad.Text) > CDec(TxtStock.Text) Then
                msj_advert("La cantidad ingresada supera el stock disponible")
                Return
            Else
                Dim existeProducto = DtDetalle.Select("codprod = " & idProducto)
                If existeProducto.Length > 0 Then
                    msj_advert("El producto ya existe en la lista")
                    Return
                End If

                Dim dr As DataRow = DtDetalle.NewRow
                dr(0) = idProducto
                dr(1) = txtDescripcionEpp.Text
                dr(2) = txtPresentacion.Text
                Dim c As Double
                c = CDbl(txtCantidad.Text.Trim).ToString(P_FormatoDecimales)
                dr(3) = c
                DtDetalle.Rows.Add(dr)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle
                dtgListado.DataBind()

                LimpiarCamposProductoEpp()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarCamposProductoEpp()
        idProducto = 0
        txtDescripcionEpp.Text = ""
        txtPresentacion.Text = ""
        txtCantidad.Text = 1
        TxtStock.Text = 0
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub


End Class