Imports CapaNegocio
Imports iText.Kernel.Pdf.Canvas.Wmf

Public Class FrmControlCombustible
    Dim loginNegocio As New cnLogin()
    Dim estado As Boolean
    ' Actualiza el estado de un botón específico según su nombre
    Public Sub ActualizarEstadoBtnAincidencia(idPersona As Integer, NombreBoton As String)
        ' Obtener el estado de los botones
        Dim botonesEstado As List(Of (NombreBoton As String, Estado As Boolean)) = loginNegocio.ObtenerEstadoBotonesPorUsuario(idPersona)

        ' Habilitar o deshabilitar los botones según su estado
        For Each boton In botonesEstado
            Dim control As ToolStripButton = Nothing

            ' Buscar el botón correspondiente por su nombre
            Select Case boton.NombreBoton
                Case "btnNuevoPedido"
                    control = btnNuevoPedidocombus
                Case "btncerrar"
                    control = btncerrar
                Case "ToolStripButton2"
                    control = btntiketalmacombus
            End Select
            ' Si se encontró el botón, actualizar su estado
            If control IsNot Nothing Then
                control.Enabled = boton.Estado
            End If
        Next
    End Sub



    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub btnNuevoPedido_Click(sender As Object, e As EventArgs) Handles btnNuevoPedidocombus.Click
        ' El formulario se abrirá solo si el botón está habilitado
        If btnNuevoPedidocombus.Enabled Then
            Dim f As New FrmRegistrarPedidoCombustible
            f.ShowDialog()
        Else
            btnNuevoPedidocombus.Enabled = estado
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles btntiketalmacombus.Click
        If btntiketalmacombus.Enabled Then
            ' Lógica que se ejecuta si el botón está habilitado
        Else
            btntiketalmacombus.Enabled = estado
        End If
    End Sub

    Private Sub FrmControlCombustible_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub ckfiltro_CheckedChanged(sender As Object, e As EventArgs)

    End Sub
End Class
