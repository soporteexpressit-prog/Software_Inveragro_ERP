Imports System.IO
Imports System.Text
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmRecepcionProductosPedidoVentaSinGuia
    Dim cn As New cnVentas

    Public _codigo As Integer = 0

    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Consultar()
        ' Configurar la fecha mínima y máxima
        'dtfecharecepcion.MinDate = Now.Date.AddDays(-5) ' Fecha mínima: 5 días antes de hoy
        dtfecharecepcion.MaxDate = Now.Date ' Fecha máxima: el día de hoy
        dtfecharecepcion.Value = Now.Date
        txtArchivoRuta.Enabled = False
        clsBasicas.Formato_Tablas_Grid(dtglistado)
        recepcion()
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
            ' Obtener la banda principal del grid
            Dim band As UltraGridBand = Me.dtglistado.DisplayLayout.Bands.Item(0)

            ' Configurar columnas comunes
            With band.Columns
                ' Ocultar columna de ID
                .Item(0).Hidden = True

                ' Configuración para la columna "producto"
                With .Item("producto")
                    .Width = 135
                    .Header.Caption = "Producto"
                    .CellActivation = Activation.NoEdit
                End With

                ' Configuración para la columna "unidad"
                With .Item("unidad")
                    .Header.Caption = "U.M Mínima"
                    .CellActivation = Activation.NoEdit
                End With

                ' Configuración para la columna "cantidadpedido"
                With .Item("cantidadpedido")
                    .Header.Caption = "Cant Pendiente"
                    .CellActivation = Activation.NoEdit
                    .CellAppearance.TextHAlign = HAlign.Right
                    .Format = "0.00"
                End With

                ' Configuración para la columna "cantidadrecibido"
                With .Item("cantidadrecibido")
                    .Header.Caption = "Cant a Enviar"
                    .CellAppearance.TextHAlign = HAlign.Right
                    .CellActivation = Activation.NoEdit
                    .CellAppearance.FontData.Bold = DefaultableBoolean.True
                    .Format = "0.00" ' Formato decimal
                    .Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositiveWithSpin ' Permitir decimales
                End With

                ' Configuración para la columna "saldo"
                With .Item("saldo")
                    .Header.Caption = "Saldo"
                    .CellActivation = Activation.NoEdit
                    .CellAppearance.TextHAlign = HAlign.Right
                    .Format = "0.00"
                    .Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositiveWithSpin ' Permitir decimales
                End With

                ' Ocultar la columna "idproducto"
                .Item("idproducto").Hidden = True

                ' Configuración para el botón en la columna 6
                With .Item(6)
                    .Header.Caption = "Recepcionar"
                    .Width = 80
                    .Style = UltraWinGrid.ColumnStyle.Button
                    .CellButtonAppearance.Image = My.Resources.Actualizar
                    .ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                End With
            End With

        Catch ex As Exception
            ' Manejo de excepciones
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (dtglistado.Rows.Count = 0) Then
                msj_advert("Seleccione un Producto")
                Return
            ElseIf (txtobservacion.Text.Length = 0) Then
                msj_advert("Ingrese una Observacion")
                txtobservacion.Select()
                Return

            Else
                If MsgBox("¿Esta Seguro de Guardar ?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                    Return
                End If

                If (cktodo.Checked = False) Then
                    If (recepcionado_cantidad() = 0) Then
                        msj_advert("No ha indicado las Cantidades Enviadas")
                        Return
                    End If
                End If


                'VerificarCompletoRecepcion()
                Dim obj As New coVentas
                obj.Codigo = _codigo
                obj.Todo = IIf(cktodo.Checked, 1, 0)
                obj.FEmision = dtfecharecepcion.Value
                obj.Iduser = VP_IdUser
                obj.Observacion = txtobservacion.Text
                obj.Lista_items = creacion_de_arrary()
                obj.NumDocumentoRecepcion = txtNumDocumento.Text

                obj.Fechahasta = dtfecharecepcion.Value
                obj.Puntopartida = ""
                obj.Puntollegada = ""
                obj.Pesobrudo = 0
                obj.Idtransportista = Nothing
                obj.Placa = ""
                obj.Idconductor = Nothing

                If Not String.IsNullOrEmpty(txtArchivoRuta.Text) Then
                    Dim fileInfo As New FileInfo(txtArchivoRuta.Text)
                    If fileInfo.Length > 400 * 1024 Then
                        msj_advert("El archivo excede el tamaño máximo permitido de 400 kB.")
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
    Function recepcionado_cantidad() As Decimal        ' Declarar una variable para almacenar la suma total de la cantidad recibida
        Dim totalCantidadRecibida As Decimal = 0

        ' Recorrer todas las filas del DataTable para sumar la cantidad recibida
        For Each row As DataRow In DtDetalle.Rows
            totalCantidadRecibida += CDec(row("cantidadrecibido"))
        Next
        Return totalCantidadRecibida
    End Function
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
        Dim sb As New StringBuilder()

        If dtglistado.Rows.Count = 0 Then
            Return "0"
        End If

        For i As Integer = 0 To dtglistado.Rows.Count - 1
            Dim row = dtglistado.Rows(i)
            If Not String.IsNullOrWhiteSpace(row.Cells(0).Value?.ToString()) Then
                sb.Append(row.Cells(0).Value.ToString().Trim()) _
              .Append("+") _
              .Append(row.Cells(4).Value.ToString().Trim()) _
              .Append("+") _
              .Append(row.Cells(7).Value.ToString().Trim()) _
              .Append(",")
            End If
        Next

        ' Remover la última coma
        If sb.Length > 0 Then
            sb.Length -= 1
        End If

        Return sb.ToString()
    End Function



    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub
    Sub Consultar()
        Try
            Dim obj As New coVentas
            obj.Codigo = _codigo
            Dim dtConsulta As DataTable = cn.Cn_ConsultarDetallexCodigo(obj)
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
            ' Validar que se haya ingresado una cantidad válida
            If txtcantrecibido.Text.Length = 0 Then
                msj_advert("Ingrese una Cantidad Válida")
                Return
            End If

            Dim cantidadRecibida As Decimal = CDec(txtcantrecibido.Text)
            Dim cantidadPedido As Decimal = CDec(txtcantidadpedido.Text)

            ' Validar que la cantidad recibida no sea cero o mayor que la cantidad pendiente
            If cantidadRecibida <= 0 Then
                msj_advert("Ingrese una Cantidad Válida")
                Return
            End If

            If cantidadRecibida > cantidadPedido Then
                msj_advert("La Cantidad recibida no puede ser mayor a la pendiente")
                Return
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

    Private Sub ckentrega_CheckedChanged(sender As Object, e As EventArgs)
    End Sub
    Private Sub txtNumDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumDocumento.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

End Class