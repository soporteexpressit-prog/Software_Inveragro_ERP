Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarProductoNuevoFormula
    Dim cnFormula As New cnControlFormulacion
    Dim cn As New cnProducto
    Public idProducto As Integer = 0
    Public idFormula As Integer = 0
    Public valorProducto As String = ""
    Dim idProductoNuevo As Integer = 0

    Private Sub FrmListarProductoNuevoFormula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarInsumos()
        LblProductoActual.Text = valorProducto
    End Sub

    Sub ListarInsumos()
        Dim dt As DataTable = cn.Cn_ListarInsumosActivos()
        dtgListado.DataSource = dt
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        dtgListado.DisplayLayout.Bands(0).Columns("Codigo").Hidden = True
        If (dt.Rows.Count > 0) Then
            idProductoNuevo = dt.Rows(0)("Codigo")
            LblProductoNuevo.Text = dt.Rows(0)("Descripción")
            dtgListado.Rows(0).Appearance.BackColor = Color.LightBlue
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If idProducto = idProductoNuevo Then
                msj_advert("El producto seleccionado es el mismo que el actual")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REMPLAZAR ESTE INSUMO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlFormulacion With {
                .IdFormulaBase = idFormula,
                .IdProductoFormula = idProducto,
                .IdProductoNuevo = idProductoNuevo
            }

            Dim mensaje As String = cnFormula.Cn_ActualizarProductoFormula(obj)
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

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    idProductoNuevo = activeRow.Cells("Codigo").Value
                    LblProductoNuevo.Text = activeRow.Cells("Descripción").Value
                    For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                        row.Appearance.BackColor = Color.White
                    Next
                    activeRow.Appearance.BackColor = Color.LightBlue
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class