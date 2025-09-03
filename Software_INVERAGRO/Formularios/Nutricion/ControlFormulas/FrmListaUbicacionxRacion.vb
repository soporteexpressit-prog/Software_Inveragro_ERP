Imports CapaNegocio

Public Class FrmListaUbicacionxRacion
    Dim cn As New cnUbicacion

    Private Sub FrmGestionVisualizacionRaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Consultar()
    End Sub

    Sub Consultar()
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            dtgListado.DataSource = cn.Cn_ConsultarPlanteles()
            dtgListado.DisplayLayout.Bands(0).Columns("idUbicacion").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Densidad por Corral").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("+ N° Chanchillas").Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        Dim column As Infragistics.Win.UltraWinGrid.UltraGridColumn = dtgListado.DisplayLayout.Bands(0).Columns("Acción")
        column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        If Not e.ReInitialize Then
            e.Row.Cells("Acción").Value = "Permisos"
            e.Row.Cells("Acción").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        End If
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            With dtgListado
                If (e.Cell.Column.Key = "Acción") Then
                    Dim frm As New FrmGestionarVisualizacionRacion
                    frm.idUbicacion = CInt(.ActiveRow.Cells("idUbicacion").Value)
                    frm.ShowDialog()
                    Consultar()
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        e.Layout.Bands(0).Columns("idUbicacion").Width = 0
        e.Layout.Bands(0).Columns("Descripción").Width = 50
        e.Layout.Bands(0).Columns("Raciones Asignadas").Width = 250
        e.Layout.Bands(0).Columns("Acción").Width = 50
    End Sub
End Class