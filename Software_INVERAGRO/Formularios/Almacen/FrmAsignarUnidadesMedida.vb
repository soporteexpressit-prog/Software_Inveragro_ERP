Imports System.ComponentModel
Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmAsignarUnidadesMedida

    Private DtDetalleAsignacion As New DataTable("DtDetalleAsignacion")
    Public idProducto As Integer = 0
    Public operacion As Integer
    Public producto As String
    Public presentacion As String
    Dim cn As New cnProducto

    Private Sub FrmAsignarUnidadesMedida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarUnidadMedida()
            CargarDetalleTablaAsignacion()
            If operacion = 1 Then
                Dim tb As DataTable = ConsultarItems()
                LlenarDetalleAsignacionDesdeDataTable(tb)
                txtProducto.Text = producto
                txtUnidadMedida.Text = presentacion
                btnBuscarProducto.Visible = False
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Inicializar()
        txtUnidadMedida.ReadOnly = True
        txtProducto.ReadOnly = True
    End Sub
    Function ConsultarItems() As DataTable
        Try
            Dim obj As New coProductos
            Dim cn As New cnProducto
            obj.Operacion = idProducto
            Dim tbtmp As DataTable = cn.Cn_Consultarunidamedidas(obj).Copy
            tbtmp.TableName = "tmp"
            Return tbtmp
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
            Return Nothing
        End Try
    End Function
    Sub LlenarDetalleAsignacionDesdeDataTable(tb As DataTable)
        CargarDetalleTablaAsignacion() ' Limpia y define la estructura
        If tb Is Nothing OrElse tb.Rows.Count = 0 Then Exit Sub

        For Each row As DataRow In tb.Rows
            Dim dr As DataRow = DtDetalleAsignacion.NewRow()
            dr("idProducto") = row("idProducto")
            dr("idUnidadMedida") = row("idUnidadOrigen")
            dr("producto") = row("producto")
            dr("presentacion") = row("presentacion")
            dr("cantidad") = row("cantidad")
            dr("unidadMedida") = row("unidadMedida")
            dr("contexto") = row("idConversion") ' O asigna el valor que corresponda
            dr("btneliminar") = "" ' O asigna el valor que corresponda
            DtDetalleAsignacion.Rows.Add(dr)
        Next
        DtDetalleAsignacion.AcceptChanges()
        dtgListado.DataSource = DtDetalleAsignacion
    End Sub

    Sub CargarDetalleTablaAsignacion()
        DtDetalleAsignacion = New DataTable("DtDetalleAsignacion")
        DtDetalleAsignacion.Columns.Add("idProducto", GetType(Integer))
        DtDetalleAsignacion.Columns.Add("idUnidadMedida", GetType(Integer))
        DtDetalleAsignacion.Columns.Add("producto", GetType(String))
        DtDetalleAsignacion.Columns.Add("presentacion", GetType(String))
        DtDetalleAsignacion.Columns.Add("cantidad", GetType(Integer))
        DtDetalleAsignacion.Columns.Add("unidadMedida", GetType(String))
        DtDetalleAsignacion.Columns.Add("contexto", GetType(String))
        DtDetalleAsignacion.Columns.Add("btneliminar", GetType(String))
        dtgListado.DataSource = DtDetalleAsignacion
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True
                .Columns(2).Header.Caption = "Producto"
                .Columns(2).Width = 160
                .Columns(3).Header.Caption = "U.M. Mínima"
                .Columns(3).Width = 80
                .Columns(4).Header.Caption = "Equivalencia"
                .Columns(4).Width = 60
                .Columns(5).Header.Caption = "U. Medida"
                .Columns(5).Width = 60
                .Columns(6).Hidden = True
                .Columns(7).Header.Caption = "Eliminar"
                .Columns(7).Width = 60
                .Columns(7).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(7).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(7).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarUnidadMedida()
        Try
            Dim obj As New coProductos
            Dim cn As New cnProducto
            obj.Descripcion = ""
            Dim tb As New DataTable
            tb = cn.Cn_ListUnidadMedida(obj).Copy
            tb.TableName = "tmp"
            tb.Columns(1).ColumnName = "Seleccione una Unidad Medida"
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

    Private Sub btnAgregarAlimento_Click(sender As Object, e As EventArgs) Handles btnAgregarAlimento.Click
        Try

            If idProducto = 0 Then
                msj_advert("Debe seleccionar un producto")
                Return
            End If

            If txtCantidad.Text.Length = 0 Then
                msj_advert("Debe ingresar una cantidad")
                Return
            End If

            If CInt(txtCantidad.Text) <= 0 Then
                msj_advert("La cantidad debe ser mayor a cero")
                Return
            End If

            Dim filtro As String = "idProducto = " & idProducto & " AND idUnidadMedida = " & cbUnidadMedida.Value

            Dim rows() As DataRow = DtDetalleAsignacion.Select(filtro)
            If rows.Length > 0 Then
                msj_advert("El producto ya ha sido agregado con la unidad de medida seleccionada.")
                Return
            End If

            Dim dr As DataRow = DtDetalleAsignacion.NewRow()
            dr(0) = idProducto
            dr(1) = cbUnidadMedida.Value
            dr(2) = txtProducto.Text
            dr(3) = txtUnidadMedida.Text
            dr(4) = If(String.IsNullOrEmpty(txtCantidad.Text), 0, Convert.ToInt32(txtCantidad.Text))
            dr(5) = cbUnidadMedida.Text
            dr(6) = "NINGUNO"

            DtDetalleAsignacion.Rows.Add(dr)
            DtDetalleAsignacion.AcceptChanges()
            dtgListado.DataSource = DtDetalleAsignacion

            If operacion = 0 Then
                LimpiarCampos()
            Else
                txtCantidad.Text = ""
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        idProducto = 0
        txtProducto.Text = String.Empty
        txtUnidadMedida.Text = String.Empty
        txtCantidad.Text = String.Empty
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then

                If operacion = 0 Then
                    Dim rowIndex As Integer = e.Cell.Row.Index
                    DtDetalleAsignacion.Rows.RemoveAt(rowIndex)
                    DtDetalleAsignacion.AcceptChanges()
                    dtgListado.DataSource = DtDetalleAsignacion
                ElseIf operacion = 1 Then
                    Dim obj As New coProductos With {
                            .IdIngreso = dtgListado.ActiveRow.Cells(6).Value.ToString
                        }
                    Dim mensaje As String
                    mensaje = cn.Cn_Eliminarunidadesmedida(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(mensaje)
                        Dispose()
                    Else
                        msj_advert(mensaje)
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If DtDetalleAsignacion.Rows.Count = 0 Then
                msj_advert("Debe agregar al menos un producto antes de guardar.")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REALIZAR ESTE PEDIDO DE ALIMENTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coProductos With {
                .ListaItems = ObtenerListaProductos()
            }

            Dim mensaje As String
            If operacion = 1 Then
                mensaje = cn.Cn_Editarunidadesmedida(obj)
            Else
                mensaje = cn.Cn_RegistrarAsignacionMultipleUnidadesMedida(obj)
            End If
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

    Public Sub LlenarCampoProducto(codigo As Integer, descripcion As String, unidadmedida As String)
        idProducto = codigo
        txtProducto.Text = descripcion
        txtUnidadMedida.Text = unidadmedida
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Function ObtenerListaProductos() As String
        Dim array_valvulas As String = ""
        If (dtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgListado.Rows.Count - 1
                If (dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtgListado.Rows(i)
                        array_valvulas = array_valvulas & .Cells("idProducto").Value.ToString.Trim & "+" &
                            .Cells("idUnidadMedida").Value.ToString.Trim & "+" &
                            .Cells("cantidad").Value.ToString.Trim & "+" &
                            .Cells("contexto").Value.ToString.Trim & ","
                    End With
                End If
            Next

            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub btnAbrirUnidadMedida_Click(sender As Object, e As EventArgs) Handles btnAbrirUnidadMedida.Click
        Try
            Dim f As New FrmUnidadMedida
            f.ShowDialog()
            ListarUnidadMedida()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click
        Try
            Dim frm As New FrmListarProductosActivos(Me)
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class