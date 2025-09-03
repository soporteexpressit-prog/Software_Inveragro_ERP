Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmRegistrarInsumoExcedente
    Dim codInsumo As Integer
    Private DtDetalle As New DataTable("TempDetInsumos")
    Dim cn As New cnControlExcedente

    Private Sub FrmRegistrarInsumoExcedente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            CargarTablaDetalleInsumos()
            ListarAlmacenesPrincipales()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
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

    Private Sub Inicializar()
        txtDescripcionInsumo.Enabled = False
        txtPresentacion.Enabled = False
        txtDescripcionInsumo.Text = ""
        txtPresentacion.Text = ""
        codInsumo = 0
        TxtCantidad.Text = "1"
    End Sub

    Sub CargarTablaDetalleInsumos()
        DtDetalle = New DataTable("TempDetInsumos")
        DtDetalle.Columns.Add("codprod", GetType(Integer))
        DtDetalle.Columns.Add("producto", GetType(String))
        DtDetalle.Columns.Add("presentacion", GetType(String))
        DtDetalle.Columns.Add("cantidad", GetType(Decimal))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        dtgListado.DataSource = DtDetalle
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(0).Width = 70
                .Columns(1).Header.Caption = "Producto"
                .Columns(1).Width = 200
                .Columns(2).Header.Caption = "Presentación"
                .Columns(2).Width = 90
                .Columns(3).Header.Caption = "Cantidad"
                .Columns(3).Width = 65
                .Columns(4).Header.Caption = "Eliminar"
                .Columns(4).Width = 60
                .Columns(4).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(4).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(4).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE INSUMO?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetalle.Rows.RemoveAt(rowIndex)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle
            End If
        End If
    End Sub

    Public Sub LlenarCamposInsumo(codigo As Integer, descripcion As String, presentacion As String)
        codInsumo = codigo
        txtDescripcionInsumo.Text = descripcion
        txtPresentacion.Text = presentacion
    End Sub

    Private Sub BtnBuscarInsumo_Click(sender As Object, e As EventArgs) Handles BtnBuscarInsumo.Click
        Try
            Dim epp As New FrmListarInsumosFormulacion(Me)
            epp.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TxtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidad.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnAgregarInsumo_Click(sender As Object, e As EventArgs) Handles BtnAgregarInsumo.Click
        Try
            If codInsumo < 1 Then
                msj_advert("Seleccione un Producto")
                Return
            ElseIf TxtCantidad.Text.Length = 0 Then
                msj_advert("Ingrese una Cantidad")
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
                Dim existeProducto = DtDetalle.Select("codprod = " & codInsumo.ToString())
                If existeProducto.Length > 0 Then
                    msj_advert("El producto ya existe en la lista")
                    Return
                End If

                Dim dr As DataRow = DtDetalle.NewRow
                dr(0) = codInsumo
                dr(1) = txtDescripcionInsumo.Text
                dr(2) = txtPresentacion.Text
                Dim c As Double
                c = CDbl(TxtCantidad.Text.Trim).ToString(P_FormatoDecimales)
                dr(3) = c
                DtDetalle.Rows.Add(dr)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle
                dtgListado.DataBind()

                Inicializar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert("Seleccione un Producto")
            Else
                If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR EXCEDENTE?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim obj As New coControlExcedente With {
                    .IdUbicacion = cmbAlmacenPrincipal.Value,
                    .IdUsuario = VP_IdUser,
                    .ListaInsumosExtra = CreacionArrayInsumos()
                }

                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_RegistrarInsumoExcedenteAlimentoCerdo(obj)
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

    Function CreacionArrayInsumos() As String
        Dim array_valvulas As String = ""
        If (dtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgListado.Rows.Count - 1
                If (dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtgListado.Rows(i)
                        array_valvulas = array_valvulas & .Cells(3).Value.ToString.Trim & "+" &
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