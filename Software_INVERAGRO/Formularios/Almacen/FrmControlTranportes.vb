Imports CapaNegocio
Imports CapaObjetos

Public Class FrmControlTranportes
    Dim cn As New cnTransporte
    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub FrmControlTranportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub

    Sub Consultar()
        Dim dt As DataTable = cn.Cn_Consultar()
        dtgListado.DataSource = dt
    End Sub

    Private Sub btnnuevoRrhhdm_Click(sender As Object, e As EventArgs) Handles btnnuevoalmacentransportes.Click
        Dim f As New FrmNuevoTransporte With {
            .operacion = 1
        }
        If f.ShowDialog() = DialogResult.OK Then
            Consultar()
        End If
        Consultar()
    End Sub
    Private Sub btneditar_Click(sender As Object, e As EventArgs) Handles btneditaralmacentransportes.Click
        If dtgListado.ActiveRow IsNot Nothing Then
            Dim filaSeleccionada = dtgListado.ActiveRow ' Obtener la fila activa
            Dim f As New FrmNuevoTransporte With {
            .operacion = 2,
            .codigo = filaSeleccionada.Cells(0).Value ' Valor de la primera columna
        }
            If f.ShowDialog() = DialogResult.OK Then
                Consultar()
            End If
        Else
            MessageBox.Show("Por favor, seleccione una fila para editar.", "Editar Transporte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Consultar()
    End Sub
    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        e.Layout.Bands(0).Columns(0).Hidden = True
    End Sub
    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "INACTIVO", 4)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 4)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "EN MANTENIMIENTO", 4)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class