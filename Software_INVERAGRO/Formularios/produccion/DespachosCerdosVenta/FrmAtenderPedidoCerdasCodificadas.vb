
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmAtenderPedidoCerdasCodificadas
    Dim cn As New cnControlDespachoCerdoVenta
    Dim idCorral As Integer = 0
    Dim idAnimal As Integer = 0
    Dim codigoArete As String = ""
    Dim valueGalpon As String = ""
    Public idSalida As Integer = 0
    Public idPlantel As Integer = 0
    Public cliente As String = ""
    Public cantidadSolicitada As Integer = 0
    Public observacion As String = ""
    Public idMotivoTransaccion As Integer = 0
    Private DtDetalle As New DataTable("TempDetVentaCerdo")
    Private cantidadCerdos As New Dictionary(Of Integer, Integer)
    Private listaIDsAnimalesSeleccionados As New List(Of Integer)
    Public fPedido As Date

    Private Sub FrmAtenderPedidoCerdasCodificadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            CargarTablaDetalleVentaCerdo()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        TxtUbicacion.ReadOnly = True
        TxtTipo.ReadOnly = True
        TxtObservacion.ReadOnly = True
        LblCliente.Text = cliente
        LblCantidadSolicitada.Text = cantidadSolicitada
        TxtObservacion.Text = observacion
        TxtAnimales.ReadOnly = True
        TxtPesoTotal.ReadOnly = True
        DtpFecha.Value = Now.Date
    End Sub

    Public Sub LlenarCamposCerdoVenta(idJaulaCorral As Integer, idCerdo As Integer, codArete As String, tipo As String, ubicacion As String)
        idCorral = idJaulaCorral
        idAnimal = idCerdo
        codigoArete = codArete
        TxtTipo.Text = tipo
        TxtUbicacion.Text = ubicacion
    End Sub

    Sub CargarTablaDetalleVentaCerdo()
        DtDetalle = New DataTable("TempDetVentaCerdo")
        DtDetalle.Columns.Add("idCorral", GetType(Integer))
        DtDetalle.Columns.Add("idAnimal", GetType(Integer))
        DtDetalle.Columns.Add("tipo", GetType(String))
        DtDetalle.Columns.Add("codArete", GetType(String))
        DtDetalle.Columns.Add("cantidad", GetType(Integer))
        DtDetalle.Columns.Add("peso", GetType(Decimal))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        dtgListado.DataSource = DtDetalle
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True
                .Columns(2).Header.Caption = "Tipo"
                .Columns(3).Header.Caption = "Arete"
                .Columns(4).Header.Caption = "Cantidad"
                .Columns(5).Header.Caption = "Peso"
                .Columns(6).Header.Caption = "Eliminar"
                .Columns(6).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(6).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(6).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
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
                CalcularNumAnimales()
            End If
        End If
    End Sub

    Private Sub CalcularNumAnimales()
        TxtAnimales.Text = dtgListado.Rows.Count.ToString()
    End Sub

    Private Sub NumCantidad_KeyPress(sender As Object, e As KeyPressEventArgs)
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub TxtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPeso.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnListarCerdos_Click(sender As Object, e As EventArgs) Handles BtnListarCerdos.Click
        Try
            Dim idsAnimales As List(Of Integer) = ObtenerIDsAnimalesSeleccionados()

            Dim frm As New FrmListarCerdosFilter(Me) With {
                .idPlantel = idPlantel,
                .idMotivoTransaccion = idMotivoTransaccion,
                .listaIDsAOcultar = idsAnimales
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function ObtenerIDsAnimalesSeleccionados() As List(Of Integer)
        listaIDsAnimalesSeleccionados.Clear()

        For Each row As DataRow In DtDetalle.Rows
            If Not IsDBNull(row("idAnimal")) Then
                listaIDsAnimalesSeleccionados.Add(CInt(row("idAnimal")))
            End If
        Next

        Return listaIDsAnimalesSeleccionados
    End Function

    Private Sub BtnIngresar_Click(sender As Object, e As EventArgs) Handles BtnIngresar.Click
        Try
            Dim totalCantidades As Integer = dtgListado.Rows.Count

            If idAnimal = 0 Then
                msj_advert("Seleccione un cerdo")
                Return
            ElseIf TxtPeso.Text.Length = 0 Then
                msj_advert("Ingrese el peso del cerdo")
                Return
            ElseIf CDec(TxtPeso.Text) = 0 Then
                msj_advert("Ingrese el peso del cerdo")
                Return
            End If

            If totalCantidades >= cantidadSolicitada Then
                msj_advert("La cantidad despachada no puede ser mayor a la cantidad solicitada")
                Return
            End If

            Dim existeAnimal = DtDetalle.Select("idAnimal = " & idAnimal)
            If existeAnimal.Length > 0 Then
                msj_advert("El animal ya esta registrado en la lista")
                LimpiarCampos()
                Return
            End If

            Dim row As DataRow = DtDetalle.NewRow()
            row("idCorral") = idCorral
            row("idAnimal") = idAnimal
            row("tipo") = TxtTipo.Text
            row("codArete") = codigoArete
            row("cantidad") = 1
            row("peso") = CDec(TxtPeso.Text)
            row("btneliminar") = "Eliminar"
            DtDetalle.Rows.Add(row)
            dtgListado.DataSource = DtDetalle
            LimpiarCampos()
            ActualizarPeso()
            CalcularNumAnimales()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        idAnimal = 0
        codigoArete = ""
        TxtTipo.Text = ""
        TxtUbicacion.Text = ""
        TxtPeso.Text = ""
    End Sub

    Private Sub ActualizarPeso()
        Dim total As Decimal = 0
        For Each row As DataRow In DtDetalle.Rows
            total += CDec(row("peso"))
        Next
        TxtPesoTotal.Text = total
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If DtpFecha.Value > Now.Date Then
                msj_advert("La fecha no puede ser mayor a la fecha actual")
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

            Dim totalCantidades As Integer = dtgListado.Rows.Count
            Dim totalPesos As Decimal = 0
            Dim pesoPromedio As Decimal = 0

            For Each row As DataRow In DtDetalle.Rows
                Dim peso As Decimal = CDec(row("peso"))
                totalPesos += peso
            Next

            pesoPromedio = totalPesos / totalCantidades

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
                .IdMotivoTransaccion = idMotivoTransaccion,
                .IdUsuario = VP_IdUser,
                .PesoBruto = totalPesos,
                .FechaControl = DtpFecha.Value
            }

            Dim mensaje As String = cn.Cn_RegistrarPedidoCerdoAtendidoCod(obj)
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
                        array_valvulas = array_valvulas & .Cells(5).Value.ToString.Trim & "+" &
                            .Cells(1).Value.ToString.Trim & "+" &
                            .Cells(0).Value.ToString.Trim & ","
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

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class