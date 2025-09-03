Imports CapaNegocio
Imports System.IO
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Public Class FrmRecepcionarRequerimiento
    Dim cn As New cnIngreso

    Public _codigo As Integer = 0
    Public _fecha_emisio As Date
    Private Sub FrmRecepcionarRequerimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Consultar()
        ' Configurar la fecha mínima y máxima
        dtfecha.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid(dtglistado)
    End Sub

    Private DtDetalle As New DataTable("TempDetProd")


    Private Sub Dtg_Listado_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtglistado.ClickCellButton
        Try
            If (e.Cell.Column.Key = "btnEditar") Then
                If dtglistado.ActiveRow IsNot Nothing Then
                    txtproducto.AccessibleDescription = dtglistado.ActiveRow.Cells(0).Value.ToString
                    txtproducto.Text = dtglistado.ActiveRow.Cells(1).Value.ToString
                    txtcantidadpedido.Text = dtglistado.ActiveRow.Cells(3).Value.ToString
                    btnagregar.Enabled = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
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
            Else

                VerificarCompletoRecepcion()
                If (cktodo.Checked = False) Then
                    If (recepcionado_cantidad() = 0) Then
                        msj_advert("No ha indicado las Cantidades Recepcionadas")
                        Return
                    End If
                End If

                Dim obj As New coIngreso
                obj.Codigo = _codigo
                obj.Todo = IIf(cktodo.Checked, 1, 0)
                obj.FEmision = dtfecha.Value
                obj.Iduser = VP_IdUser
                obj.Observacion = txtobservacion.Text
                obj.Lista_items = creacion_de_arrary()
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_RecepcionProductosrequerimientos(obj)
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
                                .Cells(7).Value.ToString.Trim & ","
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
            Dim dtConsulta As DataTable = cn.Cn_ConsultarDetallexCodigorequerimiento(obj)
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
            DtDetalle.Rows.Add(newRow)
        Next

        ' Set the DataSource for dtglistado
        dtglistado.DataSource = DtDetalle
    End Sub

    Private Sub txtcantrecibido_KeyPress(sender As Object, e As KeyPressEventArgs)
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub
    Sub EditarCantidadRecibida()
        Try
            ' Validar que se haya ingresado una cantidad válida
            If txtcantrecibido.Text.Length = 0 Then
                msj_advert("Ingrese una Cantidad Válida")
                Exit Sub
            End If

            Dim cantidadRecibida As Decimal = CDec(txtcantrecibido.Text)
            Dim cantidadPedido As Decimal = CDec(txtcantidadpedido.Text)

            ' Validar que la cantidad recibida no sea cero o mayor que la cantidad pendiente
            If cantidadRecibida <= 0 Then
                msj_advert("Ingrese una Cantidad Válida")
                Exit Sub
            End If

            If cantidadRecibida > cantidadPedido Then
                msj_advert("La Cantidad recibida no puede ser mayor a la pendiente")
                Exit Sub
            End If

            ' Asumir que tienes una forma de identificar la fila a actualizar, como una fila seleccionada o ID
            Dim idDetalleToUpdate As Integer = CInt(txtproducto.AccessibleDescription) ' Obtener el ID de la fila a actualizar

            ' Buscar la fila en DtDetalle que coincide con idDetalleToUpdate
            For Each row As DataRow In DtDetalle.Rows
                If CInt(row("iddetalle")) = idDetalleToUpdate Then
                    ' Actualizar la columna cantidadrecibido
                    row("cantidadrecibido") = cantidadRecibida

                    ' Actualizar la columna saldo si es necesario
                    row("saldo") = CDec(row("cantidadpedido")) - CDec(row("cantidadrecibido"))
                    Exit For
                End If
            Next

            ' Refrescar la UltraGrid para mostrar los datos actualizados
            dtglistado.DataSource = DtDetalle
            dtglistado.Refresh()


            txtproducto.Clear()
            txtproducto.AccessibleDescription = ""
            txtcantidadpedido.Clear()
            txtcantrecibido.Clear()
            btnagregar.Enabled = False
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
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

    'Private Sub cktodo_CheckedChanged(sender As Object, e As EventArgs) Handles cktodo.CheckedChanged
    '    If (cktodo.Checked) Then
    '        grupo_detalle.Enabled = False

    '    Else
    '        grupo_detalle.Enabled = True
    '    End If
    '    recepcion()
    'End Sub



    Private Sub btnagregar_Click_1(sender As Object, e As EventArgs) Handles btnagregar.Click
        If (txtproducto.Text.Length = 0) Then
            msj_advert("Seleccione un producto")
            Return
        End If
        EditarCantidadRecibida()
    End Sub
End Class