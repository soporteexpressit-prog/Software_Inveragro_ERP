Imports CapaNegocio

Public Class FrmBuscarProveedorTrabajador
    Dim cn As New cnCotizacion
    Public Property codproveedor As Integer
    Public Property razonsocial As String

    Sub Consultar()
        Try
            dtgListado.DataSource = cn.Cn_ListarProveedoresTrabajadores()
            clsBasicas.Filtrar_Tabla(dtgListado, True)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub FrmBuscarProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub
    Sub Seleccionar()
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                codproveedor = dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString
                razonsocial = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString

                Dispose()
            Else
            End If
        Else
        End If
    End Sub
    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles dtgListado.ClickCell
        Seleccionar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "Código"
                .Columns(0).Width = 100
                .Columns(1).Width = 100
                .Columns(2).Width = 300
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub

    Private Sub dtgListado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgListado.KeyDown
        If e.KeyData = Keys.Enter Then
            Seleccionar()
        End If

    End Sub

    Private Sub btnnuevoproveedor_Click(sender As Object, e As EventArgs) Handles btnnuevoproveedor.Click
        Try
            Dim f As New FrmProveedor
            f._Codigo = 0
            f._TipoProveedor = 1
            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class