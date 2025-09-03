Imports CapaNegocio
Imports CapaObjetos

Public Class FrmVerSueldos
    Private cn As New cnControlPagosyDes
    Public idpago As Integer
    Sub Consultar()
        Dim obj As New coControlPagosyDes
        obj.idpago = idpago
        dtgListado.DataSource = cn.Cn_Consultarsueldos(obj)
    End Sub

    Private Sub FrmVerSueldos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        With e.Layout.Bands(0)
            ' Ocultar la primera columna
            .Columns(0).Hidden = True

            ' Configurar la última columna como botón de eliminar
            Dim lastColIndex As Integer = .Columns.Count - 1
            With .Columns(lastColIndex)
                .Header.Caption = "Eliminar"
                .Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                .ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                .CellButtonAppearance.Image = My.Resources.eliminar24_px ' Asegúrate de tener un recurso llamado "eliminar"
            End With
        End With
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = dtgListado.DisplayLayout.Bands(0).Columns(dtgListado.DisplayLayout.Bands(0).Columns.Count - 1).Key Then
            If e.Cell.Row IsNot Nothing Then
                If MessageBox.Show("¿Desea eliminar esta fila?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim obj As New coControlPagosyDes
                    ' Asigna el valor de la columna clave desde la fila seleccionada
                    obj.IdConceptoSueldo = Convert.ToInt32(e.Cell.Row.Cells(0).Value)
                    Dim _mensaje As String = cn.Cn_ELIMINARSUELDO(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(_mensaje)
                        Consultar()
                    Else
                        msj_advert(_mensaje)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dispose()
    End Sub
End Class