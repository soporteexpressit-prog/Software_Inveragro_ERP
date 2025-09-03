Imports System.IO
Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmRecepcionProductos
    Dim cn As New cnIngreso

    Public _codigo As Integer = 0
    Public _fecha_emisio As Date
    Dim valorServicio As Integer

    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Consultar()
        dtfecha.Value = Now.Date
        txtArchivoRuta.Enabled = False
        clsBasicas.Formato_Tablas_Grid(dtglistado)
        CargarTablaDetalleLote()
        CheckBox1.Checked = False
        If pagesubicaciones.TabPages.Contains(paginalotes) Then
            pagesubicaciones.TabPages.Remove(paginalotes)
        End If
    End Sub

    Private DtDetalle As New DataTable("TempDetProd")
    Private DtDetallelote As New DataTable("TempDetLote")

    Sub CargarTablaDetalleLote()
        DtDetallelote = New DataTable("TempDetLote")
        DtDetallelote.Columns.Add("numLote", GetType(String))
        DtDetallelote.Columns.Add("fechaVencimiento", GetType(Date))
        DtDetallelote.Columns.Add("cantidad", GetType(Integer))
        DtDetallelote.Columns.Add("btneliminar", GetType(String))
        DtDetallelote.Columns.Add("producto", GetType(String))
        dtglistadolote.DataSource = DtDetallelote
    End Sub

    Private Sub Dtg_Listado_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtglistado.ClickCellButton
        Try
            If (e.Cell.Column.Key = "btnEditar") Then
                If dtglistado.ActiveRow IsNot Nothing Then
                    txtproducto.AccessibleDescription = dtglistado.ActiveRow.Cells(0).Value.ToString
                    txtproducto.Text = dtglistado.ActiveRow.Cells(1).Value.ToString
                    txtcantidadpedido.Text = dtglistado.ActiveRow.Cells(3).Value.ToString
                    txtcantrecibido.AccessibleDescription = dtglistado.ActiveRow.Cells(7).Value.ToString
                    btnagregar.Enabled = True
                    ListarUnidadMedidaPorProducto(dtglistado.ActiveRow.Cells(7).Value.ToString)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub ListarUnidadMedidaPorProducto(ByVal idProducto As Integer)
        Try
            Dim cnProducto As New cnProducto
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
    Private Sub dtg_detalles_cob_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtglistado.InitializeLayout
        Try
            Dim band As UltraGridBand = Me.dtglistado.DisplayLayout.Bands.Item(0)

            ' Configurar columnas
            band.Columns.Item(0).Hidden = True
            band.Columns.Item("producto").Width = 135
            band.Columns.Item("producto").Header.Caption = "Producto"
            band.Columns.Item("producto").CellActivation = Activation.NoEdit
            band.Columns.Item("unidad").CellActivation = Activation.NoEdit
            band.Columns.Item("unidad").Header.Caption = "U.M Mínima"
            band.Columns.Item("cantidadpedido").Header.Caption = "Cant.Pedido"
            band.Columns.Item("cantidadpedido").CellActivation = Activation.NoEdit
            band.Columns.Item("cantidadpedido").CellAppearance.TextHAlign = HAlign.Right
            band.Columns.Item("cantidadpedido").Format = "0.00"

            ' Configurar columna cantidadrecibido
            band.Columns.Item("cantidadrecibido").Header.Caption = "Cant.Recibido"
            band.Columns.Item("cantidadrecibido").CellAppearance.TextHAlign = HAlign.Right
            band.Columns.Item("cantidadrecibido").CellActivation = Activation.NoEdit
            band.Columns.Item("cantidadrecibido").CellAppearance.FontData.Bold = DefaultableBoolean.True
            band.Columns.Item("cantidadrecibido").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositiveWithSpin ' Permitir decimales


            band.Columns.Item("cantidadrecibido").Format = "0.00" ' Formato decimal

            ' Asegurarte de que se permita la entrada de decimales
            band.Columns.Item("cantidadrecibido").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositiveWithSpin
            band.Columns.Item("saldo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositiveWithSpin ' Permitir decimales
            band.Columns.Item("saldo").Header.Caption = "Saldo"
            band.Columns.Item("saldo").CellActivation = Activation.NoEdit
            band.Columns.Item("saldo").CellAppearance.TextHAlign = HAlign.Right
            band.Columns.Item("saldo").Format = "0.00"
            band.Columns.Item("idproducto").Hidden = True
            band.Columns.Item("idunidadmedida").Hidden = True
            band.Columns.Item("presentacion").Header.VisiblePosition = 3
            band.Columns("presentacion").Header.Caption = "Presentación"
            band.Columns(6).Header.Caption = "Recepcionar"
            band.Columns(6).Width = 80
            band.Columns(6).Style = UltraWinGrid.ColumnStyle.Button
            band.Columns(6).CellButtonAppearance.Image = My.Resources.Actualizar
            band.Columns(6).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            ' Otras configuraciones

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Esta Seguro de Registrar la Recepción?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If
            If _fecha_emisio > dtfecha.Value Then
                msj_advert("La Fecha de Recepción no puede ser menor que la Fecha del Pedido")
                Return
            End If
            If (dtglistado.Rows.Count = 0) Then
                msj_advert("Seleccione un Producto")
                Return
            ElseIf (txtobservacion.Text.Length = 0) Then
                msj_advert("Ingrese una Observacion")
                txtobservacion.Select()
                Return
            ElseIf (txtArchivoRuta.Text.Length <> 0 And txtNumDocumento.Text.Length = 0) Then
                msj_advert("Ingrese el N° de la Guia Adjuntada")
                txtNumDocumento.Select()
                Return
            Else

                If (cktodo.Checked = False) Then
                    If (recepcionado_cantidad() = 0) Then
                        msj_advert("No ha indicado las Cantidades Recepcionadas")
                        Return
                    End If
                Else
                    VerificarCompletoRecepcion()
                End If
                Dim obj As New coIngreso
                obj.Codigo = _codigo
                obj.Todo = IIf(cktodo.Checked, 1, 0)
                obj.lotizacion = IIf(CheckBox1.Checked, 1, 0)
                obj.FEmision = dtfecha.Value
                obj.Iduser = VP_IdUser
                obj.Observacion = txtobservacion.Text
                obj.Lista_items = creacion_de_arrary()
                obj.NumDocumentoRecepcion = txtNumDocumento.Text
                obj.numdocumentoguiatran = txtnumguiatra.Text
                obj.valorServicio = valorServicio
                obj.ListaItemslotes = CreacionArrayLoteProducto()

                If Not String.IsNullOrEmpty(txtArchivoRuta.Text) Then
                    Dim fileInfo As New FileInfo(txtArchivoRuta.Text)
                    If fileInfo.Length > 500 * 1024 Then
                        msj_advert("El archivo excede el tamaño máximo permitido de 500 kB.")
                        Return
                    End If
                    Dim pdfData As Byte() = File.ReadAllBytes(txtArchivoRuta.Text)
                    obj.SetArchivo(pdfData)
                End If

                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_RecepcionProductos(obj)
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

    Sub VerificarCompletoRecepcion()
        Dim total As Decimal = 0
        If (dtglistado.Rows.Count > 0) Then

            For Each Fila As DataRow In DtDetalle.Rows
                total += CDec(Fila("saldo").ToString)
            Next
            If (total = 0) Then
                cktodo.Checked = True
            End If
        End If
    End Sub
    Function creacion_de_arrary() As String
        Dim array_valvulas As String = ""
        If (dtglistado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtglistado.Rows.Count - 1
                If (dtglistado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtglistado.Rows(i)
                        array_valvulas = array_valvulas & .Cells(0).Value.ToString.Trim & "+" &
                        .Cells(4).Value.ToString & "+" &
                        .Cells(7).Value.ToString.Trim & "+" &
                        .Cells(9).Value.ToString.Trim & "," ' <-- Aquí agregas la unidad de medida
                    End With
                End If
            Next
            If (dtglistado.Rows.Count = 1) Then
                array_valvulas = array_valvulas & ","
            End If
            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub
    Sub Consultar()
        Try
            Dim obj As New coIngreso
            obj.Codigo = _codigo
            Dim dtConsulta As DataTable = cn.Cn_ConsultarDetallexCodigo(obj)
            If dtConsulta.Rows.Count > 0 Then
                valorServicio = dtConsulta.Rows(0)("idCategoriaProducto").ToString
                If Not IsDBNull(valorServicio) AndAlso CInt(valorServicio) = 1022 Then
                    cktodo.Checked = True
                    cktodo.Enabled = False
                End If
            End If
            ' Assuming dtConsulta has the columns you need, map the data to DtDetalle
            CargarTablaDetalle(dtConsulta)

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub CargarTablaDetalle(ByVal dtConsulta As DataTable)
        ' Create DtDetalle
        DtDetalle = New DataTable("TempDetProd")
        DtDetalle.Columns.Add("iddetalle", GetType(Integer))
        DtDetalle.Columns.Add("producto", GetType(String))
        DtDetalle.Columns.Add("unidad", GetType(String))
        DtDetalle.Columns.Add("cantidadpedido", GetType(Decimal))
        DtDetalle.Columns.Add("cantidadrecibido", GetType(Decimal))
        DtDetalle.Columns.Add("saldo", GetType(Decimal))
        DtDetalle.Columns.Add("btnEditar", GetType(String))
        DtDetalle.Columns.Add("idproducto", GetType(Integer))
        DtDetalle.Columns.Add("presentacion", GetType(String))
        DtDetalle.Columns.Add("idunidadmedida", GetType(Integer))

        ' Load data from dtConsulta into DtDetalle
        For Each row As DataRow In dtConsulta.Rows
            Dim newRow As DataRow = DtDetalle.NewRow()
            newRow("iddetalle") = row("iddetalle") ' Assuming the column name matches
            newRow("producto") = row("producto")
            newRow("unidad") = row("unidad")
            newRow("cantidadpedido") = row("cantidadpedido")
            newRow("cantidadrecibido") = row("cantidadrecibido")
            newRow("saldo") = row("saldo")
            newRow("btnEditar") = "" ' Or whatever default value is needed
            newRow("idproducto") = row("idproducto")
            newRow("presentacion") = row("presentacion")
            newRow("idunidadmedida") = 0
            DtDetalle.Rows.Add(newRow)
        Next

        ' Set the DataSource for dtglistado
        dtglistado.DataSource = DtDetalle
    End Sub

    Private Sub txtcantrecibido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantrecibido.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub
    Sub EditarCantidadRecibida()
        Try
            If txtcantrecibido.Text.Length = 0 Then
                msj_advert("Ingrese una Cantidad Válida")
                Exit Sub
            End If

            Dim cantidadIngresada As Decimal = CDec(txtcantrecibido.Text)
            Dim cantidadPedido As Decimal = CDec(txtcantidadpedido.Text)

            ' Obtener equivalencia de la unidad seleccionada
            Dim dtUnidades As DataTable = CType(cbUnidadMedida.DataSource, DataTable)
            Dim equivalencia As Decimal = 1
            Dim selectedRows() As DataRow = dtUnidades.Select("codigo = " & cbUnidadMedida.Value)
            If selectedRows.Length > 0 Then
                equivalencia = CDec(selectedRows(0)(2)) ' Columna 2: Cant. Equivalente
            End If

            ' Multiplicar cantidad ingresada por equivalencia
            Dim cantidadFinal As Decimal = cantidadIngresada * equivalencia

            If cantidadFinal <= 0 Then
                msj_advert("Ingrese una Cantidad Válida")
                Exit Sub
            End If

            If cantidadFinal > cantidadPedido Then
                msj_advert("La Cantidad recibida no puede ser mayor a la pendiente")
                Exit Sub
            End If

            Dim idDetalleToUpdate As Integer = CInt(txtproducto.AccessibleDescription)

            For Each row As DataRow In DtDetalle.Rows
                If CInt(row("iddetalle")) = idDetalleToUpdate Then
                    row("cantidadrecibido") = cantidadFinal
                    row("saldo") = CDec(row("cantidadpedido")) - cantidadFinal
                    row("idunidadmedida") = CInt(cbUnidadMedida.Value)
                    Exit For
                End If
            Next

            dtglistado.DataSource = DtDetalle
            dtglistado.Refresh()

            If CheckBox1.Checked Then
            Else
                txtproducto.Clear()
                txtproducto.AccessibleDescription = ""
                txtcantidadpedido.Clear()
                txtcantrecibido.Clear()
                btnagregar.Enabled = False
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub Añadirlotizacion()
        Try
            If String.IsNullOrWhiteSpace(TxtNumLote.Text) Then
                msj_advert("Ingrese número de lote")
                Return
            End If
            If txtcantrecibido.Value = 0 Then
                msj_advert("Por favor, ingrese una cantidad válida")
                Return
            End If

            ' Validar que la cantidad ingresada no exceda la cantidad faltante
            If txtcantrecibido.Value > CInt(txtcantidadpedido.Text) Then
                msj_advert("La cantidad ingresada es mayor a la cantidad que falta lotizar")
                Return
            End If
            ' Validar si la columna "producto" existe en la tabla DtDetallelote
            If Not DtDetallelote.Columns.Contains("producto") Then
                msj_advert("La columna 'producto' no existe en la tabla")
                Return
            End If
            Dim idProducto As String = txtcantrecibido.AccessibleDescription
            ' Validar si la columna "numLote" existe en la tabla DtDetalle
            If Not DtDetallelote.Columns.Contains("numLote") Then
                msj_advert("La columna 'numLote' no existe en la tabla")
                Return
            End If

            ' Validar si el lote ya existe en la lista
            Dim loteFiltro As String = TxtNumLote.Text.Replace("'", "''") ' Escapar comillas simples
            Dim existeProducto As DataRow() = DtDetallelote.Select("numLote = '" & loteFiltro & "'")
            If existeProducto.Length > 0 Then
                msj_advert("El número de lote ya existe en la lista")
                Return
            End If
            ' Buscar si ya existe el producto en la tabla de lotes
            Dim filasExistentes As DataRow() = DtDetallelote.Select("producto = '" & idProducto & "'")

            If filasExistentes.Length > 0 Then
                ' Si existe, solo actualiza la cantidad
                filasExistentes(0)("cantidad") = CInt(txtcantrecibido.Value)
            Else
                ' Si no existe, agrega una nueva fila
                Dim dr As DataRow = DtDetallelote.NewRow()
                dr("numLote") = TxtNumLote.Text
                dr("fechaVencimiento") = dtpFechaVencimiento.Value
                dr("cantidad") = txtcantrecibido.Value
                dr("btneliminar") = "Eliminar"
                dr("producto") = idProducto
                DtDetallelote.Rows.Add(dr)
            End If

            ' Actualizar el DataGridView
            dtglistadolote.DataSource = DtDetallelote
            dtglistadolote.DataBind()

            ' Limpiar campos después de agregar
            LimpiarCampos()
        Catch ex As Exception
            MsgBox("Ocurrió un error: " & ex.Message)
        End Try
    End Sub
    Function recepcionado_cantidad() As Decimal        ' Declarar una variable para almacenar la suma total de la cantidad recibida
        Dim totalCantidadRecibida As Decimal = 0

        ' Recorrer todas las filas del DataTable para sumar la cantidad recibida
        For Each row As DataRow In DtDetalle.Rows
            totalCantidadRecibida += CDec(row("cantidadrecibido"))
        Next
        Return totalCantidadRecibida
    End Function
    Sub recepcion()
        If (DtDetalle.Rows.Count = 0) Then
            Return
        End If
        If (cktodo.Checked) Then

            For Each row As DataRow In DtDetalle.Rows
                ' Actualizar la columna cantidadrecibido
                row("cantidadrecibido") = CDec(row("cantidadpedido"))
                ' Actualizar la columna saldo si es necesario
                row("saldo") = 0
            Next

            ' Refrescar la UltraGrid para mostrar los datos actualizados
            dtglistado.DataSource = DtDetalle
            dtglistado.Refresh()

        Else
            For Each row As DataRow In DtDetalle.Rows
                ' Actualizar la columna cantidadrecibido
                row("cantidadrecibido") = 0
                ' Actualizar la columna saldo si es necesario
                row("saldo") = CDec(row("cantidadpedido"))
            Next

            ' Refrescar la UltraGrid para mostrar los datos actualizados
            dtglistado.DataSource = DtDetalle
            dtglistado.Refresh()
        End If
    End Sub
    Function CreacionArrayLoteProducto() As String
        Dim array_valvulas As New Text.StringBuilder()

        If dtglistadolote.Rows.Count = 0 Then
            Return "0"
        End If

        For i = 0 To dtglistadolote.Rows.Count - 1
            With dtglistadolote.Rows(i)
                ' Validamos que numLote no esté vacío
                If Not IsDBNull(.Cells("numLote").Value) AndAlso
               .Cells("numLote").Value.ToString().Trim().Length <> 0 Then

                    Dim numLote As String = .Cells("numLote").Value.ToString().Trim()
                    Dim cantidad As String = .Cells("cantidad").Value.ToString().Trim()
                    Dim fecha As String = Convert.ToDateTime(.Cells("fechaVencimiento").Value).ToString("yyyy-MM-dd")
                    Dim idProducto As String = .Cells("producto").Value.ToString().Trim()

                    ' Formato: numLote+cantidad+fecha+idProducto
                    array_valvulas.Append($"{numLote}+{cantidad}+{fecha}+{idProducto},")
                End If
            End With
        Next

        ' Quitamos la coma final si hay contenido
        If array_valvulas.Length > 0 Then
            array_valvulas.Length -= 1
        Else
            Return "0"
        End If

        Return array_valvulas.ToString()
    End Function

    Private Sub cktodo_CheckedChanged(sender As Object, e As EventArgs) Handles cktodo.CheckedChanged
        If (cktodo.Checked) Then
            grupo_detalle.Enabled = False

        Else
            grupo_detalle.Enabled = True
        End If
        recepcion()
    End Sub

    Private Sub btnagregar_Click(sender As Object, e As EventArgs) Handles btnagregar.Click
        If (txtproducto.Text.Length = 0) Then
            msj_advert("Seleccione un producto")
            Return
        End If
        EditarCantidadRecibida()
        If CheckBox1.Checked Then
            Añadirlotizacion()
        End If
    End Sub

    Private Sub LimpiarCampos()
        txtproducto.Clear()
        txtproducto.AccessibleDescription = ""
        txtcantidadpedido.Clear()
        txtcantrecibido.Clear()
        btnagregar.Enabled = False
        TxtNumLote.Text = ""
        txtcantrecibido.Text = ""
        dtpFechaVencimiento.Value = Now.Date
    End Sub
    Private Sub btnSubirArchivo_Click(sender As Object, e As EventArgs) Handles btnSubirArchivo.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Archivos PDF|*.pdf|Todos los archivos|*.*"
        openFileDialog.Title = "Selecciona un archivo PDF"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = openFileDialog.FileName
            txtArchivoRuta.Text = selectedFilePath
        End If
    End Sub

    Private Sub UltraGrid1_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtglistadolote.InitializeLayout
        Try
            clsBasicas.Formato_Tablas_Grid(dtglistadolote)
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "Nro Lote"
                .Columns(1).Header.Caption = "Fecha Vencimiento"
                .Columns(2).Header.Caption = "Cantidad"
                .Columns(3).Header.Caption = "Eliminar"
                .Columns(3).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(3).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(3).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub dtglistadolote_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtglistadolote.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE REGISTRO?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetallelote.Rows.RemoveAt(rowIndex)
                DtDetallelote.AcceptChanges()
                dtglistadolote.DataSource = DtDetallelote
                dtglistadolote.DataBind()
                txtcantrecibido.Text = txtcantidadpedido.Text - SumarCantidad()
            End If
        End If
    End Sub
    Private Function SumarCantidad() As Integer
        Dim total As Integer = 0
        For Each row As DataRow In DtDetallelote.Rows
            total += row(2)
        Next
        Return total
    End Function
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TxtNumLote.Visible = True
            If Not pagesubicaciones.TabPages.Contains(paginalotes) Then
                pagesubicaciones.TabPages.Add(paginalotes)
            End If
            Label10.Visible = True
            Label9.Visible = True
            dtpFechaVencimiento.Visible = True
        Else
            TxtNumLote.Visible = False
            If pagesubicaciones.TabPages.Contains(paginalotes) Then
                pagesubicaciones.TabPages.Remove(paginalotes)
            End If
            Label10.Visible = False
            Label9.Visible = False
            dtpFechaVencimiento.Visible = False

            ' Limpiar la tabla de lotes y refrescar el grid
            DtDetallelote.Rows.Clear()
            DtDetallelote.AcceptChanges()
            dtglistadolote.DataSource = DtDetallelote
            dtglistadolote.DataBind()
        End If
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

End Class