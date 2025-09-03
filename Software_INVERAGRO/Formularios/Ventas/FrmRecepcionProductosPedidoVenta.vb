Imports System.IO
Imports System.Text
Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmRecepcionProductosPedidoVenta
    Dim cn As New cnVentas
    Public _transferencia As String = ""
    Public _codigo As Integer = 0

    Sub ObtenerDireccionCliente()
        Try
            If (dtglistado.Rows.Count > 0) Then
                If (dtglistado.Rows.Count = 1) Then
                    cbxdestino.Visible = False
                    txtdestino.Visible = True
                Else
                    cbxdestino.Visible = True
                    txtdestino.Visible = False
                End If
                txtdestino.Text = dtglistado.Rows(0).Cells(7).Value.ToString
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Public Sub ListarPlanteles()
        Try
            Dim tbtmpplanteles As New DataTable
            ' Inicializar conexión y obtener datos
            Dim cn As New cnProducto
            tbtmpplanteles = cn.Cn_ListarPlanteles().Copy
            tbtmpplanteles.TableName = "tmp"
            With cbxplanteles
                .DataSource = tbtmpplanteles
                .DisplayMember = tbtmpplanteles.Columns(1).ColumnName ' Nombre de la columna a mostrar
                .ValueMember = tbtmpplanteles.Columns(0).ColumnName   ' Nombre de la columna del valor
                If tbtmpplanteles.Rows.Count > 0 Then
                    .Value = tbtmpplanteles.Rows(0)(0) ' Seleccionar el primer valor
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        Finally
        End Try
    End Sub
    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1922, 1150)
        ListarPlanteles()
        ListarTablas()
        Consultar()
        ' Configurar la fecha mínima y máxima
        dtfecharecepcion.Value = Now.Date
        txtArchivoRuta.Enabled = False
        clsBasicas.Formato_Tablas_Grid(dtglistado)
        txtcodtransportista.Text = 53
        txtdenominacion.Text = "MOLINO SAN MARTIN DE PORRAS SAC"
    End Sub

    Private DtDetalle As New DataTable("TempDetProd")


    Private Sub Dtg_Listado_ClickCellButton(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtglistado.ClickCellButton
        Try
            If (e.Cell.Column.Key = "btnEliminar") Then
                If dtglistado.ActiveRow IsNot Nothing Then
                    dtglistado.ActiveRow.Delete(False)
                    ObtenerDireccionCliente()
                Else
                    MsgBox("No hay ninguna fila seleccionada para eliminar.", MsgBoxStyle.Exclamation)
                End If
                CalcularPeso()
            End If
        Catch ex As Exception
            MsgBox("Error al intentar eliminar la fila: " & ex.Message, MsgBoxStyle.Critical)
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
                .Item(1).Hidden = True
                .Item(2).Hidden = True
                .Item(3).Header.Caption = "Cliente"
                .Item(4).Header.Caption = "Cantidad"
                .Item(5).Header.Caption = "Total Peso Kg"
                .Item(6).Header.Caption = "Eliminar"
                .Item(6).Width = 80
                .Item(6).Style = UltraWinGrid.ColumnStyle.Button
                .Item(6).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Item(6).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Item(7).Hidden = True
                .Item(8).Header.Caption = "Motivo Transacción"
                .Item(8).Header.VisiblePosition = 0
                .Item(9).Header.Caption = "Peso Promedio"
                .Item(9).Header.VisiblePosition = 6
                .Item(10).Header.Caption = "Fecha Pedido"
                .Item(10).Header.VisiblePosition = 9
                .Item(10).Header.Caption = "Producto"
                .Item(10).Header.VisiblePosition = 10
            End With

        Catch ex As Exception
            ' Manejo de excepciones
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Esta Seguro de Registrar la Guia de Traslado?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If
            If (dtglistado.Rows.Count = 0) Then
                msj_advert("No Tiene Pedidos PENDIENTES por Generar Guia")
                Return
            End If
            If (txtobservacion.Text.Length = 0) Then
                msj_advert("Ingrese una Observacion")
                txtobservacion.Select()
                Return
            ElseIf (txtNumDocumento.Text.Length = 0) Then
                msj_advert("Ingrese el N° de Documento de la Guia")
                txtNumDocumento.Select()
                Return
            ElseIf (txtcodtrabajador.Text.Length = 0) Then
                msj_advert("Seleccione un Conductor")
                Return
            ElseIf (txtcodtransportista.Text.Length = 0) Then
                msj_advert("Seleccione un Transportista")
                Return
            ElseIf (TxtPlaca.Text.Length = 0) Then
                msj_advert("Ingrese una Placa Válida")
                Return
            ElseIf (txtpeso.Text.Length = 0) Then
                msj_advert("Ingrese un Peso Válido")
                Return
            ElseIf (CDec(txtpeso.Text) = 0) Then
                msj_advert("Ingrese un Peso Válido")
                Return
            ElseIf (odometro_inicial.Text.Length = 0) Then
                msj_advert("Ingrese el Horómetro Inicial")
                Return
            ElseIf (txtpesobalanza.Text.Length = 0) Then
                msj_advert("Ingrese el Peso de Balanza")
                Return
            ElseIf (txtcodsenasa.Text.Length = 0) Then
                msj_advert("Ingrese el Código SENASA")
                Return
            ElseIf (CDec(txtpesobalanza.Text) = 0) Then
                msj_advert("Ingrese un Peso de Balanza Válido")
                Return
            Else
                'VerificarCompletoRecepcion()
                Dim obj As New coVentas
                obj.Codigo = _codigo
                obj.Todo = IIf(cktodo.Checked, 1, 0)
                obj.FEmision = dtfecharecepcion.Value
                obj.Iduser = VP_IdUser
                obj.Observacion = txtobservacion.Text
                obj.Lista_items = creacion_de_arrary()
                obj.NumDocumentoRecepcion = txtNumDocumento.Text

                obj.Fechahasta = dttraslado.Value
                obj.Puntopartida = txtpartida.Text
                obj.Puntollegada = IIf(dtglistado.Rows.Count = 1, txtdestino.Text, cbxdestino.Text)
                obj.Pesobrudo = txtpeso.Text
                obj.Idtransportista = txtcodtransportista.Text
                obj.Placa = TxtPlaca.Text
                obj.Idconductor = txtcodtrabajador.Text
                obj.Horometro_incial = txthorometroincial.Text
                obj.odometro_inicial = odometro_inicial.Text
                obj.Pesobalanza = txtpesobalanza.Text
                obj.Codigosenasa = txtcodsenasa.Text
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
                MensajeBgWk = cn.Cd_RecepcionPedidoVentasCerdo(obj)
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

    Sub CalcularPeso()
        Dim total As Decimal = 0
        If (dtglistado.Rows.Count > 0) Then
            For Each Fila As DataRow In DtDetalle.Rows
                total += CDec(Fila("totalpeso").ToString)
            Next
        End If

        ' Redondear a 2 decimales
        txtpesobalanza.Text = Math.Round(total, 2).ToString("F2")

        If (txtpesovaciocamion.Text.Length <> 0) Then
            Dim pesoFinal As Decimal = total + CDec(txtpesovaciocamion.Text)
            txtpeso.Text = Math.Round(pesoFinal, 2).ToString("F2")
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
                sb.Append(row.Cells(2).Value.ToString().Trim()) _
            .Append("+") _
            .Append(row.Cells(4).Value.ToString()) _
            .Append("+") _
            .Append(row.Cells(2).Value.ToString().Trim()) _
            .Append("+") _
            .Append(row.Cells(0).Value.ToString().Trim()) _
            .Append(",")
            End If

        Next

        ' Remover la última coma
        If sb.Length > 0 Then
            sb.Length -= 1
        End If

        Return sb.ToString()
    End Function

    Sub ListarTablas()
        Try
            Dim dt As New DataTable
            dt = cn.Cn_ListarDestinoScti().Copy
            dt.TableName = "tmp"

            Dim indice_tabla As Integer = 0
            With cbxdestino
                .DataSource = dt
                .DisplayMember = dt.Columns(4).ColumnName
                .ValueMember = dt.Columns(0).ColumnName
                If (dt.Rows.Count > 0) Then
                    .Value = dt.Rows(0)(0)
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub
    Sub Consultar()
        Try
            txtpartida.Text = cbxplanteles.ActiveRow.Cells(2).Value.ToString
            Dim dtConsulta As DataTable = cn.Cn_ConsultarPedidosAtendidosProduccion(cbxplanteles.Value, _transferencia)
            ' Assuming dtConsulta has the columns you need, map the data to DtDetalle
            CargarTablaDetalle(dtConsulta)
            CalcularPeso()
            ObtenerDireccionCliente()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub CargarTablaDetalle(ByVal dtConsulta As DataTable)
        ' Create DtDetalle
        DtDetalle = New DataTable("TempDetProd")
        DtDetalle.Columns.Add("idsalida", GetType(Integer))
        DtDetalle.Columns.Add("iddetallesalida", GetType(Integer))
        DtDetalle.Columns.Add("idproducto", GetType(Integer))
        DtDetalle.Columns.Add("cliente", GetType(String))
        DtDetalle.Columns.Add("cantidad", GetType(Decimal))
        DtDetalle.Columns.Add("totalpeso", GetType(Decimal))
        DtDetalle.Columns.Add("btnEliminar", GetType(String))
        DtDetalle.Columns.Add("direccion", GetType(String))
        DtDetalle.Columns.Add("MotivoTransaccion", GetType(String))
        DtDetalle.Columns.Add("peso_promedio", GetType(String))
        DtDetalle.Columns.Add("fPedido", GetType(String))
        ' Load data from dtConsulta into DtDetalle
        For Each row As DataRow In dtConsulta.Rows
            Dim newRow As DataRow = DtDetalle.NewRow()
            newRow("idsalida") = row("idsalida") ' Assuming the column name matches
            newRow("iddetallesalida") = row("iddetallesalida")
            newRow("idproducto") = row("idproducto")
            newRow("cliente") = row("cliente")
            newRow("cantidad") = row("cantidad")
            newRow("totalpeso") = row("totalpeso")
            newRow("btnEliminar") = "" ' Or whatever default value is needed
            newRow("direccion") = row("direccion")
            newRow("MotivoTransaccion") = row("MotivoTransaccion")
            newRow("peso_promedio") = row("peso_promedio")
            newRow("fPedido") = row("fPedido")
            DtDetalle.Rows.Add(newRow)
        Next
        ' Set the DataSource for dtglistado
        dtglistado.DataSource = DtDetalle

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
    Private Sub btnbuscartransportista_Click(sender As Object, e As EventArgs) Handles btnbuscartransportista.Click
        Dim f As New FrmBuscarProveedorIngreso()
        f.ShowDialog()
        If (f.codproveedor <> 0) Then
            txtcodtransportista.Text = f.codproveedor
            txtdenominacion.Text = f.razonsocial
            f.codproveedor = 0
        Else
            txtcodtransportista.Clear()
            txtdenominacion.Clear()
        End If
    End Sub

    Private Sub btnbuscarconductor_Click(sender As Object, e As EventArgs) Handles btnbuscarconductor.Click
        Try
            Dim f As New FrmBuscarConductores()
            f.ShowDialog()
            If (f.codtrabajador <> 0) Then
                txtcodtrabajador.Text = f.codtrabajador
                txttrabajador.Text = f.datos
                f.codtrabajador = 0
            Else
                txtcodtrabajador.Clear()
                txttrabajador.Clear()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub txtpeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpeso.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub txthorometroincial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txthorometroincial.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub
    Private Sub txtNumDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumDocumento.KeyPress
        clsBasicas.ValidarNumDocumentos(e)
    End Sub
    Private Sub txtcodsenasa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcodsenasa.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub
    Private idTransporte As Integer
    Public Sub LlenarCamposTransporte(codigo As Integer, numPlaca As String, tipoVehiculo As String, capacidad As Decimal, pesovacio As Decimal)
        idTransporte = codigo
        TxtTransporte.Text = tipoVehiculo
        TxtPlaca.Text = numPlaca
        TxtCapacidad.Text = capacidad
        txtpesovaciocamion.Text = Math.Round(pesovacio, 2).ToString("F2")

        CalcularPeso()
    End Sub


    Private Sub BtnBuscarVehiculo_Click(sender As Object, e As EventArgs) Handles BtnBuscarVehiculo.Click
        Try
            Dim f As New FrmListarTransporteGuiasTraslado(Me)
            f.ShowDialog()
            CalcularPeso()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxdestino_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxdestino.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Width = 200
                .Columns(2).Width = 200
                .Columns(3).Width = 200
                .Columns(4).Width = 200
                .Columns(5).Width = 300
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub



    Private Sub cbxplanteles_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxplanteles.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Header.Caption = "Plantel"
                .Columns(1).Width = 150
                .Columns(2).Header.Caption = "Dirección"
                .Columns(2).Width = 300
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxplanteles_ValueChanged(sender As Object, e As EventArgs) Handles cbxplanteles.ValueChanged
        Consultar()
    End Sub

    Private Sub dtfecharecepcion_ValueChanged(sender As Object, e As EventArgs) Handles dtfecharecepcion.ValueChanged

    End Sub
End Class