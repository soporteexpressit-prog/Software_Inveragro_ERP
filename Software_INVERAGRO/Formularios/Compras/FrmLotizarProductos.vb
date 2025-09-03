Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmLotizarProductos
    Dim cn As New cnProducto
    Private DtDetalle As New DataTable("TempDetLote")
    Public idProducto As Integer = 0
    Public nombreProducto As String = ""
    Public cantidadLotizar As Integer = 0
    Public idIngreso As Integer = 0
    Public idUbicacionDestino As Integer = 0

    Private Sub FrmLotizarProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LblProducto.Text = nombreProducto
            LblCantidadIngresar.Text = cantidadLotizar
            LblCantidadFaltante.Text = cantidadLotizar
            dtpFechaVencimiento.Value = Now.Date
            CargarTablaDetalleLote()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub CargarTablaDetalleLote()
        DtDetalle = New DataTable("TempDetLote")
        DtDetalle.Columns.Add("numLote", GetType(String))
        DtDetalle.Columns.Add("fechaVencimiento", GetType(Date))
        DtDetalle.Columns.Add("cantidad", GetType(Integer))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        dtgListado.DataSource = DtDetalle
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
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

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE REGISTRO?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetalle.Rows.RemoveAt(rowIndex)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle
                dtgListado.DataBind()
                LblCantidadFaltante.Text = cantidadLotizar - SumarCantidad()
            End If
        End If
    End Sub

    'Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
    '    Try
    '        If idProducto = 0 Then
    '            msj_advert("Seleccione un Producto")
    '            Return
    '        ElseIf TxtNumLote.Text.Length = 0 Then
    '            msj_advert("Ingrese número de lote")
    '            Return
    '        ElseIf NumCantidad.Value = 0 Then
    '            msj_advert("Por Favor Ingrese Cantidad válida")
    '            Return
    '        ElseIf NumCantidad.Value > CInt(LblCantidadFaltante.Text) Then
    '            msj_advert("La cantidad ingresada es mayor a la cantidad que falta lotizar")
    '            Return
    '        Else
    '            Dim existeProducto As DataRow() = DtDetalle.Select("numLote = " & TxtNumLote.Text)
    '            If existeProducto.Length > 0 Then
    '                msj_advert("El nombre de lote ya existe en la lista")
    '                Return
    '            End If

    '            Dim dr As DataRow = DtDetalle.NewRow
    '            dr(0) = TxtNumLote.Text
    '            dr(1) = dtpFechaVencimiento.Value
    '            dr(2) = NumCantidad.Value
    '            DtDetalle.Rows.Add(dr)
    '            DtDetalle.AcceptChanges()
    '            dtgListado.DataSource = DtDetalle
    '            dtgListado.DataBind()

    '            LimpiarCampos()
    '            LblCantidadFaltante.Text = cantidadLotizar - SumarCantidad()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            ' Validar que se haya seleccionado un producto
            If idProducto = 0 Then
                msj_advert("Seleccione un Producto")
                Return
            End If

            ' Validar que se haya ingresado un número de lote
            If String.IsNullOrWhiteSpace(TxtNumLote.Text) Then
                msj_advert("Ingrese número de lote")
                Return
            End If

            ' Validar que la cantidad ingresada sea mayor a 0
            If NumCantidad.Value = 0 Then
                msj_advert("Por favor, ingrese una cantidad válida")
                Return
            End If

            ' Validar que la cantidad ingresada no exceda la cantidad faltante
            If NumCantidad.Value > CInt(LblCantidadFaltante.Text) Then
                msj_advert("La cantidad ingresada es mayor a la cantidad que falta lotizar")
                Return
            End If

            ' Validar si la columna "numLote" existe en la tabla DtDetalle
            If Not DtDetalle.Columns.Contains("numLote") Then
                msj_advert("La columna 'numLote' no existe en la tabla")
                Return
            End If

            ' Validar si el lote ya existe en la lista
            Dim loteFiltro As String = TxtNumLote.Text.Replace("'", "''") ' Escapar comillas simples
            Dim existeProducto As DataRow() = DtDetalle.Select("numLote = '" & loteFiltro & "'")
            If existeProducto.Length > 0 Then
                msj_advert("El número de lote ya existe en la lista")
                Return
            End If

            ' Crear una nueva fila y agregarla a la tabla
            Dim dr As DataRow = DtDetalle.NewRow()
            dr("numLote") = TxtNumLote.Text
            dr("fechaVencimiento") = dtpFechaVencimiento.Value
            dr("cantidad") = NumCantidad.Value
            dr("btneliminar") = "Eliminar"
            DtDetalle.Rows.Add(dr)
            DtDetalle.AcceptChanges()

            ' Actualizar el DataGridView
            dtgListado.DataSource = DtDetalle
            dtgListado.DataBind()

            ' Limpiar campos después de agregar
            LimpiarCampos()

            ' Actualizar la cantidad faltante
            LblCantidadFaltante.Text = (cantidadLotizar - SumarCantidad()).ToString()
        Catch ex As Exception
            MsgBox("Ocurrió un error: " & ex.Message)
        End Try
    End Sub


    Private Sub LimpiarCampos()
        TxtNumLote.Text = ""
        NumCantidad.Text = ""
        dtpFechaVencimiento.Value = Now.Date
    End Sub

    Private Sub TxtNumLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumLote.KeyPress
        clsBasicas.ValidarLetrasyNumeros(e)
    End Sub

    Private Function SumarCantidad() As Integer
        Dim total As Integer = 0
        For Each row As DataRow In DtDetalle.Rows
            total += row(2)
        Next
        Return total
    End Function

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If (DtDetalle.Rows.Count = 0) Then
                msj_advert("Debe ingresar al menos un lote")
                Return
            End If

            If (CInt(LblCantidadFaltante.Text) <> 0) Then
                msj_advert("La cantidad lotizada no coincide con la cantidad a lotizar")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE LOTIZAR ESTE PRODUCTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coProductos With {
                .Idproducto = idProducto,
                .IdIngreso = idIngreso,
                .IdUbicacion = idUbicacionDestino,
                .ListaItems = CreacionArrayLoteProducto()
            }

            Dim MensajeBgWk As String = cn.Cn_RegistrarLotizarProductoFecVenc(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Dispose()
            Else
                msj_advert(MensajeBgWk)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function CreacionArrayLoteProducto() As String
        Dim array_valvulas As String = ""
        If (dtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgListado.Rows.Count - 1
                If (dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtgListado.Rows(i)
                        Dim fecha As String = Convert.ToDateTime(.Cells("fechaVencimiento").Value).ToString("yyyy-MM-dd")

                        array_valvulas = array_valvulas & .Cells("numLote").Value.ToString.Trim & "+" &
                        .Cells("cantidad").Value.ToString.Trim & "+" &
                        fecha & ","
                    End With
                End If
            Next
            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class