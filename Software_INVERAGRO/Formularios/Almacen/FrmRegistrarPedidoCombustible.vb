Imports System.Text
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmRegistrarPedidoCombustible
    Dim _CodSolicitante As Integer
    Private DtDetalle As New DataTable("TempDetProdCombustible")

    Public Sub LlenarCamposSolicitante(codigo As Integer, numDocumento As String, datos As String)
        _CodSolicitante = codigo
        txtNumDoc.Text = numDocumento
        txtDatos.Text = datos
    End Sub
    Private Sub FrmRegistrarPedidoCombustible_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFecha.Value = Now.Date
        txtNumDoc.ReadOnly = True
        txtDatos.ReadOnly = True
        txtCodProducto.ReadOnly = True
        txtDescripcionEpp.ReadOnly = True
        txtPresentacion.ReadOnly = True
        txtEstado.ReadOnly = True
        txtLiquidado.ReadOnly = True
        CargarTablaDetalleProductoCombustible()
        ListarTiposDocumento()
        LimpiarCamposProductoCombustible()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub
    Private Sub LimpiarCamposProductoCombustible()
        txtCodProducto.Text = ""
        txtDescripcionEpp.Text = ""
        txtPresentacion.Text = ""
        txtCantidad.Text = 1
        txtPrecio.Text = 0
        txtEstado.Text = "PENDIENTE"
        txtLiquidado.Text = "PENDIENTE"
    End Sub
    Public Sub LlenarCamposCombustible(codigo As Integer, descripcion As String, presentacion As String)
        txtCodProducto.Text = codigo
        txtDescripcionEpp.Text = descripcion
        txtPresentacion.Text = presentacion
    End Sub

    Sub CargarTablaDetalleProductoCombustible()
        DtDetalle = New DataTable("TempDetProdCombustible")
        DtDetalle.Columns.Add("codprod", GetType(Integer))
        DtDetalle.Columns.Add("producto", GetType(String))
        DtDetalle.Columns.Add("unidad", GetType(String))
        DtDetalle.Columns.Add("cantidad", GetType(Decimal))
        DtDetalle.Columns.Add("precio", GetType(Decimal))
        DtDetalle.Columns.Add("subtotal", GetType(Decimal))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        dtgListado.DataSource = DtDetalle
    End Sub

    Sub ListarTiposDocumento()
        Dim cn As New cnControlCombustible
        Dim tb As New DataTable
        tb = cn.Cn_ListarTiposDocumento().Copy()
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Tipo de Documento"
        With cbxTiposDocumento
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetalle.Rows.RemoveAt(rowIndex)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle
            End If
        End If
    End Sub


    Private Sub btnBuscarSolicitante_Click(sender As Object, e As EventArgs) Handles btnBuscarSolicitante.Click
        Dim f As New FrmBuscarSolicitanteCombustible(Me)
        f.ShowDialog()
    End Sub

    Private Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click
        Dim f As New FrmBuscarGrifo(Me)
        f.ShowDialog()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If txtCodProducto.Text.Length = 0 Then
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
            ElseIf txtPrecio.Text = 0 Then
                msj_advert("Por Favor Ingrese el Precio")
                txtPrecio.Select()
                Return
            Else
                Dim existeProducto = DtDetalle.Select("codprod = " & txtCodProducto.Text)
                If existeProducto.Length > 0 Then
                    msj_advert("El producto ya existe en la lista")
                    Return
                End If

                Dim dr As DataRow = DtDetalle.NewRow
                dr(0) = txtCodProducto.Text
                dr(1) = txtDescripcionEpp.Text
                dr(2) = txtPresentacion.Text
                Dim c As Double
                c = CDbl(txtCantidad.Text.Trim).ToString(P_FormatoDecimales)
                dr(3) = c
                Dim p As Double
                p = CDbl(txtPrecio.Text.Trim).ToString(P_FormatoDecimales)
                dr(4) = p
                Dim subtotal As Decimal = CDec(dr(3)) * CDec(dr(4))
                dr(5) = subtotal
                DtDetalle.Rows.Add(dr)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle
                dtgListado.DataBind()

                LimpiarCamposProductoCombustible()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

    End Sub

    Private Function ObtenerDetalleString() As String
        Dim detalleString As New StringBuilder()

        For Each row As DataRow In DtDetalle.Rows
            Dim idProducto As Integer = row("codprod")
            Dim cantidad As Decimal = row("cantidad")
            Dim precio As Decimal = row("precio")
            Dim subtotal As Decimal = row("subtotal")

            detalleString.AppendFormat("{0}+{1}+{2}+{3},", idProducto, cantidad, precio, subtotal)
        Next

        Return detalleString.ToString()
    End Function
    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "Codigo"
                .Columns(0).Width = 70
                .Columns(1).Header.Caption = "Producto"
                .Columns(1).Width = 150
                .Columns(2).Header.Caption = "Presentacion"
                .Columns(2).Width = 90
                .Columns(3).Header.Caption = "Cantidad"
                .Columns(3).Width = 70
                .Columns(4).Header.Caption = "Precio"
                .Columns(4).Width = 50
                .Columns(5).Header.Caption = "Subtotal"
                .Columns(5).Width = 70
                .Columns(6).Header.Caption = "Eliminar"
                .Columns(6).Width = 30
                .Columns(6).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(6).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(6).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class