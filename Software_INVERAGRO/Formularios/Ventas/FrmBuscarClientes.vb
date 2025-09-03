Imports CapaNegocio

Public Class FrmBuscarClientes
    Dim cn As New cnCotizacion
    Public Property codproveedor As Integer
    Public Property razonsocial As String
    Public Property direccion As String
    Sub Consultar()
        Try
            dtgListado.DataSource = cn.Cn_ListarClientes()
            clsBasicas.Filtrar_Tabla(dtgListado, True)

            clsBasicas.Colorear_SegunValor_mayor_a(dtgListado, Color.Red, Color.White, 0, 4)
            clsBasicas.Colorear_SegunValor_igual_a(dtgListado, Color.Green, Color.White, 0, 4)
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
                If (dtgListado.ActiveRow.Cells(4).Value > 0) Then
                    If MsgBox("¿El Cliente Seleccionado Tiene una Deuda Pendiente, esta seguro de continuar con la operación ?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Ok Then
                        codproveedor = dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString
                        razonsocial = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
                        direccion = dtgListado.DisplayLayout.ActiveRow.Cells(3).Value.ToString
                        Dispose()
                    End If
                Else
                    codproveedor = dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString
                    razonsocial = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
                    direccion = dtgListado.DisplayLayout.ActiveRow.Cells(3).Value.ToString

                    Dispose()
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub
    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Seleccionar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "Código"
                .Columns(0).Width = 100
                .Columns(1).Width = 100
                .Columns(2).Width = 220
                .Columns(3).Width = 220
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgListado.KeyDown
        If e.KeyData = Keys.Enter Then
            Seleccionar()
        End If

    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub btnNuevoCliente_Click(sender As Object, e As EventArgs) Handles btnNuevoCliente.Click
        Try
            Dim f As New FrmMantenimientoCliente
            f._Codigo = 0
            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class