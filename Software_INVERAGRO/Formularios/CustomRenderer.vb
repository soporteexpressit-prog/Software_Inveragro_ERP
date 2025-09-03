Public Class CustomRenderer
    Inherits ToolStripProfessionalRenderer

    ' Lista de ToolStripMenuItem con color verde constante
    Private ReadOnly itemsWithGreenBackground As New List(Of String) From {
        "toolAlmacen",
        "toolCompras",
        "toolContabilidad",
        "toolMolino",
        "toolNutricion",
        "toolProduccion",
        "toolRRHH",
        "toolSanidad",
        "toolVentas",
        "toolSegPersonal",
        "toolConfiguracion",
        "toolSalir"
    }

    ' Variable para rastrear el ToolStripMenuItem principal activo
    Private activeMainItem As ToolStripMenuItem = Nothing

    ' Colores
    Private ReadOnly greenColor As Color = Color.FromArgb(226, 242, 167)
    Private ReadOnly activeColor As Color = Color.ForestGreen

    Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
        Dim isMainItem As Boolean = itemsWithGreenBackground.Contains(e.Item.Name)

        If isMainItem Then
            ' Aplica color al principal activo o verde constante
            If e.Item Is activeMainItem Then
                e.Graphics.FillRectangle(New SolidBrush(activeColor), e.Item.ContentRectangle)
            Else
                If e.Item.Selected OrElse CType(e.Item, ToolStripMenuItem).DropDown.Visible Then
                    e.Graphics.FillRectangle(Brushes.ForestGreen, e.Item.ContentRectangle)
                Else
                    e.Graphics.FillRectangle(Brushes.DarkGreen, e.Item.ContentRectangle)
                End If
            End If
        ElseIf e.Item.Selected Then
            ' Aplica un color de fondo a los ítems seleccionados
            e.Graphics.FillRectangle(Brushes.ForestGreen, e.Item.ContentRectangle)
        End If
    End Sub

    ' Sobrescribe el método para renderizar el texto con el color correspondiente
    Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)
        If e.Item.Selected Then
            e.TextColor = Color.White
        End If
        ' Renderiza el texto con el color definido
        MyBase.OnRenderItemText(e)
    End Sub

    ' Método para establecer el principal activo
    Public Sub SetActiveMainItem(activeItem As ToolStripMenuItem)
        activeMainItem = activeItem
    End Sub
End Class