Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmRegistrarPedidoSemenPorcino
    Dim cn As New cnControlMaterialGenetico
    Dim idProductoGenetica As Integer = 0
    Dim codigoGeneticaValor As String = ""
    Dim tipoProductoValor As String = ""
    Private DtDetalle As New DataTable("TempDetProdGenetica")

    Private Sub FrmRegistrarPedidoSemenPorcino_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            CargarTablaDetalleProductoGenetica()
            ListarAlmacenesPrincipales()
            ListarPlantelesSolicitante()
            CmbUbicacionSolicitante.Value = 2
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        DtpFechaPedido.Value = Now.Date
        TxtDescripcion.ReadOnly = True
        TxtPresentacion.ReadOnly = True
    End Sub

    Sub ListarPlantelesSolicitante()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlantelesReproduccion().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbUbicacionSolicitante
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarAlmacenesPrincipales()
        Dim cn As New cnProducto
        Dim tb As New DataTable
        tb = cn.Cn_ListarAlmacenPrincipal().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Categoría"
        With cmbAlmacenPrincipal
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub CargarTablaDetalleProductoGenetica()
        DtDetalle = New DataTable("TempDetProdGenetica")
        DtDetalle.Columns.Add("codProd", GetType(Integer))
        DtDetalle.Columns.Add("codGenetica", GetType(String))
        DtDetalle.Columns.Add("producto", GetType(String))
        DtDetalle.Columns.Add("presentacion", GetType(String))
        DtDetalle.Columns.Add("tipoProducto", GetType(String))
        DtDetalle.Columns.Add("cantidad", GetType(Decimal))
        DtDetalle.Columns.Add("btnEliminar", GetType(String))
        dtgListado.DataSource = DtDetalle
    End Sub

    Public Sub LlenarCamposProductoGenetica(codigo As Integer, codigoGenetica As String, descripcion As String, presentacion As String, tipoProducto As String)
        idProductoGenetica = codigo
        codigoGeneticaValor = codigoGenetica
        TxtDescripcion.Text = descripcion
        TxtPresentacion.Text = presentacion
        tipoProductoValor = tipoProducto
    End Sub

    Private Sub BtnBuscarProductoGenetica_Click(sender As Object, e As EventArgs) Handles BtnBuscarProductoGenetica.Click
        Dim frm As New FrmListarSemenPorcino(Me)
        frm.ShowDialog()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If idProductoGenetica = 0 Then
            msj_advert("Seleccione un Producto Genético")
            Return
        ElseIf TxtCantidad.Text.Length = 0 Then
            msj_advert("Ingrese una Cantidad")
            TxtCantidad.Select()
            Return
        ElseIf CDec(TxtCantidad.Text) = 0 Then
            msj_advert("Por Favor Ingrese Cantidad válida")
            TxtCantidad.Select()
            Return
        ElseIf TxtCantidad.Text = 0 Then
            msj_advert("Por Favor Ingrese la Cantidad")
            TxtCantidad.Select()
            Return
        Else
            Dim existeProducto = DtDetalle.Select("codprod = " & idProductoGenetica.ToString())
            If existeProducto.Length > 0 Then
                msj_advert("El producto ya existe en la lista")
                Return
            End If

            Dim dr As DataRow = DtDetalle.NewRow
            dr(0) = idProductoGenetica
            dr(1) = codigoGeneticaValor
            dr(2) = TxtDescripcion.Text
            dr(3) = TxtPresentacion.Text
            dr(4) = tipoProductoValor
            dr(5) = TxtCantidad.Text
            DtDetalle.Rows.Add(dr)
            DtDetalle.AcceptChanges()
            dtgListado.DataSource = DtDetalle
            dtgListado.DataBind()
            LimpiarCamposProductoGenetico()
        End If
    End Sub

    Private Sub LimpiarCamposProductoGenetico()
        idProductoGenetica = 0
        TxtDescripcion.Text = ""
        TxtPresentacion.Text = ""
        TxtCantidad.Text = ""
    End Sub

    Private Sub TxtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidad.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            With e.Layout.Bands(0)
                .Columns(1).Header.Caption = "Código Genética"
                .Columns(1).Width = 120
                .Columns(2).Header.Caption = "Producto"
                .Columns(2).Width = 150
                .Columns(3).Header.Caption = "Presentación"
                .Columns(3).Width = 90
                .Columns(4).Header.Caption = "Tipo Producto"
                .Columns(4).Width = 100
                .Columns(5).Header.Caption = "Cantidad"
                .Columns(5).Width = 65
                .Columns(6).Header.Caption = "Eliminar"
                .Columns(6).Width = 60
                .Columns(6).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(6).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(6).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns(0).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "btnEliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetalle.Rows.RemoveAt(rowIndex)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If dtgListado.Rows.Count = 0 Then
                msj_advert("SE DEBE REGISTRAR POR LO MENOS UN PRODUCTO")
                Return
            End If

            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE PREPRARAR LA ORDEN CON ESTE TOTAL DE INSUMO?", "Confirmar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim MensajeBgWk As String = ""
                Dim objAlimento As New coControlMaterialGenetico With {
                    .IdUsuario = VP_IdUser,
                    .IdAlmacenPrincipal = cmbAlmacenPrincipal.Value,
                    .IdAlmacenSolicitante = CmbUbicacionSolicitante.Value,
                    .ListaProductos = CreacionArrayProductoGenetica(),
                    .FechaControl = DtpFechaPedido.Value
                }

                MensajeBgWk = cn.Cn_RegistrarPedidoSemenCerdoProveedor(objAlimento)
                If (objAlimento.Coderror = 0) Then
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

    Function CreacionArrayProductoGenetica() As String
        Dim array_valvulas As String = ""
        If (dtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgListado.Rows.Count - 1
                If (dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtgListado.Rows(i)
                        array_valvulas = array_valvulas & .Cells(5).Value.ToString.Trim & "+" &
                            .Cells(0).Value.ToString.Trim & ","
                    End With
                End If
            Next
            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class