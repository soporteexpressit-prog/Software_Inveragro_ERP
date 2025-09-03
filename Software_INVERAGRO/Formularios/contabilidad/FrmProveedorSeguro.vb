Imports CapaNegocio

Public Class FrmProveedorSeguro
    Dim cn As New cnProveedor
    Sub Consultar()
        dtgListado.DataSource = cn.Cn_ListarTodasAseguradoras()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 9)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "INACTIVO", 9)
    End Sub
    Private Sub FrmProveedorSeguro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Consultar()
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportarctprose.Click
        Try
            clsBasicas.ExportarExcel("Control Aseguradoras", dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoctprose.Click
        Try
            Dim f As New FrmProveedor
            f._Codigo = 0
            f._TipoProveedor = 0

            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarctprose.Click
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim f As New FrmProveedor
                    f._Codigo = dtgListado.ActiveRow.Cells(0).Value.ToString
                    f._TipoProveedor = 0
                    f.ShowDialog()
                    Consultar()
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class