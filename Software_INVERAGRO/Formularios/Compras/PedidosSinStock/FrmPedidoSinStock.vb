Imports System.IO
Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Stimulsoft.Report.StiOptions.Export

Public Class FrmPedidoSinStock
    Dim cn As New cnIngreso
    Dim cnProducto As New cnProducto
    Public _codigo As Integer = 0
    Private unidadMedidaOriginal As String = ""

    Sub ListarTablas()
        Try

            clsBasicas.ListarAlmacenesAsignados(cbxalmacen_origen)
            clsBasicas.ListarAlmacenesAsignados(cbxalmacendestino)
            cbxalmacen_origen.SelectedValue = P_IdAlmacenPrincipal
            cbxalmacendestino.SelectedValue = P_IdAlmacenPrincipal
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub InicializarUnidadMedidaPorDefecto()
        Try
            Dim tb As New DataTable("temp")
            tb.Columns.Add("codigo", GetType(Integer))
            tb.Columns.Add("Seleccione Unidad de Medida", GetType(String))

            Dim newRow As DataRow = tb.NewRow()
            newRow(0) = 0
            newRow(1) = "SELECCIONA EL PRODUCTO"
            tb.Rows.Add(newRow)

            With cbUnidadMedida
                .DataSource = tb
                .DisplayMember = "Seleccione Unidad de Medida"
                .ValueMember = "codigo"
                .Value = 0
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub ActualizarConversion()
        Try
            If cbUnidadMedida.Rows.Count = 0 OrElse cbUnidadMedida.Value Is Nothing Then
                lblConversion.Text = "Conversión: -"
                Return
            End If

            Dim cantidadOrigen As Decimal = 0
            If Not Decimal.TryParse(txtcantidad.Text, cantidadOrigen) Then
                lblConversion.Text = "Conversión: -"
                Return
            End If

            Dim row As UltraWinGrid.UltraGridRow = cbUnidadMedida.ActiveRow
            If row Is Nothing Then
                lblConversion.Text = "Conversión: -"
                Return
            End If

            Dim factor As Decimal = 0
            Decimal.TryParse(row.Cells(2).Value.ToString(), factor)

            Dim resultado As Decimal = cantidadOrigen * factor
            lblConversion.Text = $"Conversión: {resultado:N2} {unidadMedidaOriginal}"

        Catch ex As Exception
            lblConversion.Text = "Conversión: -"
        End Try
    End Sub


    Sub ListarUnidadMedidaPorProducto(ByVal idProducto As Integer)
        Try
            Dim obj As New coProductos With {
                .Idproducto = idProducto
            }
            Dim tb As New DataTable
            tb = cnProducto.Cn_ListarUnidadesMedidaPorProducto(obj)
            tb.TableName = "temp"
            tb.Columns(1).ColumnName = "Seleccione Unidad de Medida"

            If tb.Rows.Count = 0 Then
                Dim newRow As DataRow = tb.NewRow()
                newRow(0) = 0
                newRow(1) = "SIN UNIDAD DE MEDIDA"
                newRow(2) = "0"
                tb.Rows.Add(newRow)
            End If

            With cbUnidadMedida
                .DataSource = tb
                .DisplayMember = tb.Columns(1).ColumnName
                .ValueMember = tb.Columns(0).ColumnName
                If (tb.Rows.Count > 0) Then
                    .Value = tb.Rows(0)(0)
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1067, 816)
        ListarTablas()
        dtpedido.Value = Now.Date
        CargarTablaDetalle()
        InicializarUnidadMedidaPorDefecto()
        btnbuscarpoveedor.Select()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        txtcodproveedor.Text = VP_IdUser
        txtproveedor.Text = nombreuser

        If (_codigo <> 0) Then
            ConsultarPedido()
        End If
    End Sub
    Sub ConsultarPedido()
        Dim obj As New coIngreso
        Dim cn As New cnIngreso
        obj.Codigo = _codigo
        Dim ds As New DataSet
        ds = cn.Cn_ConsultarPedidoxCodigo(obj).Copy
        DtDetalle = ds.Tables(1).Copy

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0) ' Tomar la primera fila

            ' Llenar los campos del formulario con los valores de la fila

            dtpedido.Value = Convert.ToDateTime(row(1))
            txtcodproveedor.Text = row(2)
            txtproveedor.Text = row(3)
            cbxalmacen_origen.SelectedValue = row(4)
            cbxalmacendestino.SelectedValue = row(5)
            txtobservacion.Text = row(6)

            ' Llenar el DataGrid con los detalles
            dtgListado.DataSource = DtDetalle
        Else
            ' Si no hay datos, dejar los campos vacíos o con valores predeterminados
            dtgListado.DataSource = Nothing
        End If

    End Sub
    Sub BuscarProducto()
        Dim f As New FrmBuscarProductoPedidoUsuario()
        f._codalmacendestino = cbxalmacendestino.SelectedValue
        f.ShowDialog()
        If (f.codproducto <> 0) Then
            txtcodprod.Text = f.codproducto
            txtproducto.Text = f.descripcion
            cbUnidadMedida.Text = f.unidadmedida
            unidadMedidaOriginal = f.unidadmedida
            f.codproducto = 0
            txtcantidad.Select()
            ListarUnidadMedidaPorProducto(txtcodprod.Text.Trim())
        End If
    End Sub

    Private DtDetalle As New DataTable("TempDetProd")
    Sub CargarTablaDetalle()
        ' Create Columns
        DtDetalle = New DataTable("TempDetProd")
        DtDetalle.Columns.Add("codprod", GetType(Integer))
        DtDetalle.Columns.Add("producto", GetType(String))
        DtDetalle.Columns.Add("unidad", GetType(String))
        DtDetalle.Columns.Add("cantidad", GetType(Decimal))
        DtDetalle.Columns.Add("precunit", GetType(Decimal))
        DtDetalle.Columns.Add("idalcance", GetType(Integer))
        DtDetalle.Columns.Add("idConversion", GetType(Integer))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        dtgListado.DataSource = DtDetalle
    End Sub
    Sub Agregar()
        Try
            ' Validaciones iniciales
            If txtcodprod.Text.Length = 0 Then
                msj_advert("Seleccione un Producto")
                Return
            ElseIf txtcantidad.Text.Length = 0 Then
                msj_advert("Ingrese una Cantidad")
                Return
            ElseIf CDec(txtcantidad.Text) = 0 Then
                msj_advert("Por Favor Ingrese la Cantidad")
                txtcantidad.Select()
                Return
            ElseIf txtcantidad.Text = 0 Then
                msj_advert("Por Favor Ingrese la Cantidad")
                txtcantidad.Select()
                Return
            ElseIf cbUnidadMedida.Value Is Nothing OrElse cbUnidadMedida.Value = 0 Then
                msj_advert("Seleccione una Unidad de Medida")
                Return
            End If


            ' Verificación de código de producto repetido
            For Each row As DataRow In DtDetalle.Rows
                If row("codprod").ToString() = txtcodprod.Text.Trim() Then
                    msj_advert("El Producto ya ha sido agregado.")
                    Return
                End If
            Next

            ' Si pasa las validaciones, se agrega el nuevo producto
            Dim dr As DataRow = DtDetalle.NewRow
            dr(0) = txtcodprod.Text
            dr(1) = txtproducto.Text
            dr(2) = cbUnidadMedida.Text
            Dim c As Double = CDbl(txtcantidad.Text.Trim).ToString(P_FormatoDecimales)
            dr(3) = c
            dr(4) = 1
            dr(5) = 0
            dr(6) = cbUnidadMedida.Value
            dr(7) = ""

            DtDetalle.Rows.Add(dr)
            DtDetalle.AcceptChanges()

            ' Actualiza el DataGridView o Listado
            dtgListado.DataSource = DtDetalle
            dtgListado.DataBind()

            ' Limpiar los campos
            txtcodprod.Text = ""
            txtproducto.Text = ""
            txtcantidad.Text = ""
            btnbuscarproducto.Select()
            unidadMedidaOriginal = ""
            InicializarUnidadMedidaPorDefecto()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "Codigo"
                .Columns(0).Width = 80
                .Columns(1).Header.Caption = "Producto"
                .Columns(1).Width = 160
                .Columns(2).Header.Caption = "Unidad Medida"
                .Columns(2).Width = 120
                .Columns(3).Header.Caption = "Cantidad"
                .Columns(3).Width = 90
                .Columns(4).Header.Caption = "Precio"
                .Columns(4).Width = 90
                .Columns(4).Hidden = True
                .Columns(5).Hidden = True
                .Columns(6).Hidden = True
                .Columns(7).Header.Caption = "Eliminar"
                .Columns(7).Width = 80
                .Columns(7).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(7).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(7).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always


            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Esta Seguro de Guardar el Pedido de Usuario?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If

            If (txtcodproveedor.Text.Length = 0) Then
                msj_advert("Seleccione un Trabajador")
                Return
            ElseIf (dtgListado.Rows.Count = 0) Then
                msj_advert("Seleccione un Producto")
                Return
                'ElseIf (cbxalmacendestino.SelectedValue = cbxalmacen_origen.SelectedValue) Then
                '    msj_advert("Seleccione un Almacen Destino diferente al de Origen")
                '    Return
            Else
                Dim obj As New coIngreso
                obj.Codigo = _codigo
                obj.Fpedido = dtpedido.Value
                obj.Observacion = txtobservacion.Text
                obj.Estado = "ACTIVO"
                obj.Iduser = VP_IdUser
                obj.IdUbicacionOrigen = cbxalmacen_origen.SelectedValue
                obj.IdUbicacionDestino = cbxalmacendestino.SelectedValue
                obj.Lista_items = creacion_de_arrary()
                obj.Idproveedor = txtcodproveedor.Text

                Dim MensajeBgWk As String = ""

                MensajeBgWk = cn.Cn_RegPedidoUsuario(obj)
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
                        array_valvulas = array_valvulas & .Cells(3).Value.ToString.Trim & "+" &
                            .Cells(4).Value.ToString & "+" &
                            .Cells(0).Value.ToString & "+" &
                            .Cells(6).Value.ToString.Trim & ","
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
    Private Sub Dtg_Listado_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            If (e.Cell.Column.Key = "btneliminar") Then
                If dtgListado.ActiveRow IsNot Nothing Then
                    If MsgBox("¿Esta Seguro de Eliminar el Producto ?" & ChrW(13) & ChrW(13) & " Código  :" & dtgListado.ActiveRow.Cells(1).Value.ToString, MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Ok Then
                        DtDetalle.Rows.RemoveAt(dtgListado.ActiveRow.Index)
                        dtgListado.DataSource = DtDetalle

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtflete_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress, txtcantidad.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub


    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub cbxagregar_Click(sender As Object, e As EventArgs) Handles cbxagregar.Click
        Agregar()
    End Sub


    Private Sub btnbuscarpoveedor_Click(sender As Object, e As EventArgs) Handles btnbuscarpoveedor.Click
        Dim f As New FrmBuscarTrabajadores()
        f.ShowDialog()
        If (f.codtrabajador <> 0) Then
            txtcodproveedor.Text = f.codtrabajador
            txtproveedor.Text = f.datos
            f.codtrabajador = 0
        Else
            txtcodproveedor.Clear()
            txtproveedor.Clear()
        End If
        btnbuscarproducto.Select()
    End Sub

    Private Sub btnbuscarproducto_Click(sender As Object, e As EventArgs) Handles btnbuscarproducto.Click
        BuscarProducto()
    End Sub
    Private Sub txtCantidadOrigen_TextChanged(sender As Object, e As EventArgs) Handles txtcantidad.TextChanged
        ActualizarConversion()
    End Sub

    Private Sub cbUnidadMedida_ValueChanged(sender As Object, e As EventArgs) Handles cbUnidadMedida.ValueChanged
        ActualizarConversion()
    End Sub
End Class