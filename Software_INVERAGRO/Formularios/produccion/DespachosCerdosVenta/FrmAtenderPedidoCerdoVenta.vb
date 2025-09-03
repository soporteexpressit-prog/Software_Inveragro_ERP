Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmAtenderPedidoCerdoVenta
    Dim cn As New cnControlDespachoCerdoVenta
    Dim idCorral As Integer = 0
    Dim idLote As Integer = 0
    Dim valorLote As String = ""
    Dim valueGalpon As String = ""
    Dim cantidadOriginal As Integer = 0
    Public idSalida As Integer = 0
    Public idPlantel As Integer = 0
    Public cliente As String = ""
    Public cantidadSolicitada As Integer = 0
    Public observacion As String = ""
    Private DtDetalle As New DataTable("TempDetVentaCerdo")
    Private CorralCantidades As New Dictionary(Of Integer, Integer)
    Public sacosEngorde As Integer = 0
    Dim idProducto As Integer = 0
    Public fPedido As Date

    Private Sub FrmAtenderPedidoCerdoVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtLote.ReadOnly = True
        TxtObservacion.ReadOnly = True
        LblCliente.Text = cliente
        LblCantidadSolicitada.Text = cantidadSolicitada
        TxtObservacion.Text = observacion
        TxtPesoTotal.ReadOnly = True
        TxtCantidadAnimales.ReadOnly = True
        LblSolicitudSacosEngorde.Text = sacosEngorde
        CargarTablaDetalleVentaCerdo()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        TxtNombreAlimento.ReadOnly = True
        DtpFecha.Value = Now.Date

        If sacosEngorde = 0 Then
            LblAlimento.Visible = False
            TxtNombreAlimento.Visible = False
            BtnBuscarAlimento.Visible = False
            LblStock.Visible = False
            LblStockAlimento.Visible = False
            LblCantidadSacos.Visible = False
            NumSacos.Visible = False
            LblMensaje.Visible = True
        Else
            LblAlimento.Visible = True
            TxtNombreAlimento.Visible = True
            BtnBuscarAlimento.Visible = True
            LblStock.Visible = True
            LblStockAlimento.Visible = True
            LblCantidadSacos.Visible = True
            NumSacos.Visible = True
            LblMensaje.Visible = False
        End If

    End Sub

    Private Sub BtnBuscarCorralVenta_Click(sender As Object, e As EventArgs) Handles BtnBuscarCorralVenta.Click
        Try
            CorralCantidades.Clear()

            For Each row As DataRow In DtDetalle.Rows
                Dim idLote As Integer = CInt(row("idLote"))
                Dim cantidad As Integer = CInt(row("cantidad"))

                If CorralCantidades.ContainsKey(idLote) Then
                    CorralCantidades(idLote) += cantidad
                Else
                    CorralCantidades.Add(idLote, cantidad)
                End If
            Next

            Dim frm As New FrmListarCorralesVentaCerdo(Me, CorralCantidades) With {
                .idPlantel = idPlantel
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposCorral(codLote As Integer, lote As String, cantidad As Integer)
        idLote = codLote
        valorLote = lote
        TxtLote.Text = lote
        TxtCantidadCrias.Text = cantidad
        cantidadOriginal = cantidad
        NumCantidad.Value = 5
    End Sub

    Sub CargarTablaDetalleVentaCerdo()
        DtDetalle = New DataTable("TempDetVentaCerdo")
        DtDetalle.Columns.Add("idLote", GetType(Integer))
        DtDetalle.Columns.Add("lote", GetType(String))
        DtDetalle.Columns.Add("cantidad", GetType(Integer))
        DtDetalle.Columns.Add("peso", GetType(Decimal))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        dtgListado.DataSource = DtDetalle
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Header.Caption = "Lote"
                .Columns(2).Header.Caption = "Cantidad"
                .Columns(3).Header.Caption = "Peso"
                .Columns(4).Header.Caption = "Eliminar"
                .Columns(4).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(4).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(4).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO QUE DESEA ELIMINAR ESTE REGISTRO?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetalle.Rows.RemoveAt(rowIndex)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle
                ActualizarPeso()
                ActualizarCantAnimales()
                ActualizarCampos()
            End If
        End If
    End Sub

    Private Sub NumCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NumCantidad.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub TxtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPeso.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnIngresar_Click(sender As Object, e As EventArgs) Handles BtnIngresar.Click
        Try
            Dim cantidadFaltante As Integer = cantidadSolicitada - CInt(TxtCantidadAnimales.Text)

            If idLote = 0 Then
                msj_advert("Debe seleccionar un lote")
                Return
            End If

            If NumCantidad.Value = 0 Then
                msj_advert("Debe ingresar una cantidad")
                Return
            End If

            If NumCantidad.Value > CInt(LblCantidadSolicitada.Text) Then
                msj_advert("La cantidad no puede ser mayor a la cantidad de solicitada")
                Return
            End If

            If NumCantidad.Value > cantidadFaltante Then
                msj_advert("La cantidad no puede ser mayor a la cantidad que falta por atender")
                Return
            End If

            If TxtPeso.Text = "" Then
                msj_advert("Debe ingresar un peso")
                Return
            ElseIf CDec(TxtPeso.Text) = 0 Then
                msj_advert("El peso debe ser mayor a 0")
                Return
            End If

            Dim row As DataRow = DtDetalle.NewRow()
            row("idLote") = idLote
            row("lote") = valorLote
            row("cantidad") = NumCantidad.Value
            row("peso") = TxtPeso.Text
            row("btneliminar") = "Eliminar"
            DtDetalle.Rows.Add(row)
            dtgListado.DataSource = DtDetalle
            ActualizarPeso()
            ActualizarCantAnimales()
            ActualizarCampos()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ActualizarPeso()
        Dim total As Decimal = 0
        For Each row As DataRow In DtDetalle.Rows
            total += CDec(row("peso"))
        Next
        TxtPesoTotal.Text = total
    End Sub

    Private Sub ActualizarCantAnimales()
        Dim total As Decimal = 0
        For Each row As DataRow In DtDetalle.Rows
            total += CDec(row("cantidad"))
        Next
        TxtCantidadAnimales.Text = total
    End Sub

    Private Sub ActualizarCampos()
        TxtCantidadCrias.Text = cantidadOriginal - ObtenerSumaCantidadPorLote(idLote)
        NumCantidad.Value = 5
        TxtPeso.Text = ""
    End Sub

    Private Function ObtenerSumaCantidadPorLote(idLoteBuscado As Integer) As Integer
        If DtDetalle Is Nothing OrElse DtDetalle.Rows.Count = 0 Then Return 0

        Dim suma As Integer = 0

        For Each row As DataRow In DtDetalle.Rows
            If row.Field(Of Integer)("idLote") = idLoteBuscado Then
                If Not IsDBNull(row("cantidad")) Then
                    suma += CInt(row("cantidad"))
                End If
            End If
        Next

        Return suma
    End Function


    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If DtpFecha.Value > Now.Date Then
                msj_advert("La fecha de despacho no puede ser mayor a la fecha actual")
                Return
            End If

            If fPedido > DtpFecha.Value Then
                msj_advert("La fecha del pedido no puede ser mayor a la fecha de despacho")
                Return
            End If

            If DtDetalle.Rows.Count = 0 Then
                msj_advert("Debe ingresar al menos un registro")
                Return
            End If

            Dim totalCantidades As Integer = 0
            Dim totalPesos As Decimal = 0
            Dim pesoPromedio As Decimal = 0
            Dim conversionSacosKilos As Decimal = 0

            For Each row As DataRow In DtDetalle.Rows
                totalCantidades += CInt(row("cantidad"))
            Next

            For Each row As DataRow In DtDetalle.Rows
                Dim peso As Decimal = CDec(row("peso"))
                totalPesos += peso
            Next

            pesoPromedio = totalPesos / totalCantidades
            conversionSacosKilos = NumSacos.Value * 0.05

            If sacosEngorde > 0 Then
                If conversionSacosKilos > CDec(LblStockAlimento.Text) Then
                    msj_advert("La cantidad de sacos ingresada supera el stock de alimento")
                    Return
                End If
            End If

            If NumSacos.Value > sacosEngorde Then
                msj_advert("La cantidad de sacos ingresada no puede superar la cantidad de sacos de engorde")
                Return
            End If

            If totalCantidades <> cantidadSolicitada Then
                msj_advert("La cantidad despachada debe ser igual a la cantidad solicitada")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REALIZAR EL DESPACHO DE ESTE PEDIDO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If


            Dim obj As New coControlDespachoCerdoVenta With {
                .IdSalida = idSalida,
                .PesoPromedio = pesoPromedio,
                .Observacion = TxtDetalleColores.Text,
                .ListaCerdosPeso = CreacionArrayCerdosPeso(),
                .NumSacosDespachados = conversionSacosKilos,
                .IdRacion = idProducto,
                .CantidadCerdos = totalCantidades,
                .IdUsuario = VP_IdUser,
                .FechaControl = DtpFecha.Value
            }

            Dim mensaje As String = cn.Cn_RegistrarPedidoCerdoAtendido(obj)
            If (obj.Coderror = 0) Then
                msj_ok(mensaje)
                Dispose()
            Else
                msj_advert(mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function CreacionArrayCerdosPeso() As String
        Dim array_valvulas As String = ""
        If (dtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgListado.Rows.Count - 1
                If (dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtgListado.Rows(i)
                        array_valvulas = array_valvulas & .Cells("peso").Value.ToString.Trim & "+" &
                            .Cells("cantidad").Value.ToString.Trim & "+" &
                            .Cells("idLote").Value.ToString.Trim & ","
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

    Public Sub LlenarCamposAlimento(codigo As Integer, descripcion As String, stock As Decimal)
        idProducto = codigo
        TxtNombreAlimento.Text = descripcion
        LblStockAlimento.Text = stock.ToString("F2")
    End Sub

    Private Sub BtnBuscarAlimento_Click(sender As Object, e As EventArgs) Handles BtnBuscarAlimento.Click
        Try
            Dim frm As New FrmListarRacionDespacharPedido(Me) With {
                .idUbicacion = idPlantel
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class