Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmGestionInsumo
    Dim cn As New cnControlFormulacion
    Public idNutricionista As Integer = 0

    Private Sub FrmGestionInsumo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarInsumos()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarInsumos()
        Dim obj As New coControlFormulacion With {
            .IdNutricionista = idNutricionista
        }

        Dim dt As DataTable = cn.Cn_ListarInsumosFormulaxNutricionista(obj)
        dtgListado.DataSource = dt
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        dtgListado.DisplayLayout.Bands(0).Columns("idProductoFormula").Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns("Codigo").Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns("Stock").Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns("Unidad").Hidden = True
        Colorear()
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estado As Integer = 7

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "INACTIVO", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim listaValores As New List(Of String)
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If Not row.IsFilterRow Then
                listaValores.Add(row.Cells(2).Value.ToString())
            End If
        Next

        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim formPadreWidth As Integer = Me.Width
        Dim formHijo As New FrmListarTodoInsumo(Me, listaValores, idNutricionista)
        Dim formHijoWidth As Integer = formHijo.Width

        Dim xPadre As Integer = (screenWidth / 2) - formPadreWidth
        Dim yPadre As Integer = (screenHeight - Me.Height) / 2
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(xPadre, yPadre)

        Dim xHijo As Integer = (screenWidth / 2)
        Dim yHijo As Integer = (screenHeight - formHijo.Height) / 2
        formHijo.StartPosition = FormStartPosition.Manual
        formHijo.Location = New Point(xHijo, yHijo)

        AddHandler formHijo.FormClosed, AddressOf ReposicionarFormularioPadre

        formHijo.ShowDialog()
    End Sub

    Private Sub ReposicionarFormularioPadre(sender As Object, e As FormClosedEventArgs)
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

        Dim xCentro As Integer = (screenWidth - Me.Width) / 2
        Dim yCentro As Integer = (screenHeight - Me.Height) / 2

        Me.Location = New Point(xCentro, yCentro)
    End Sub

    Private Sub btnDesactivarActivar_Click(sender As Object, e As EventArgs) Handles btnDesactivarActivar.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ESTA ACCIÓN?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If result = DialogResult.Yes Then
                    Dim obj As New coControlFormulacion With {
                        .Operacion = 1,
                        .Codigo = CInt(dtgListado.DisplayLayout.ActiveRow.Cells("idProductoFormula").Value.ToString),
                        .EstadoProductoFormula = If(dtgListado.DisplayLayout.ActiveRow.Cells("Estado").Value.ToString = "ACTIVO", "INACTIVO", "ACTIVO")
                    }

                    Dim _mensaje As String = cn.Cn_MantenimientoProductoFormula(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(_mensaje)
                        ListarInsumos()
                    Else
                        msj_advert(_mensaje)
                    End If
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE INSUMO?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If result = DialogResult.Yes Then
                    Dim obj As New coControlFormulacion With {
                        .Operacion = 2,
                        .Codigo = CInt(dtgListado.DisplayLayout.ActiveRow.Cells("idProductoFormula").Value.ToString)
                    }

                    Dim _mensaje As String = cn.Cn_MantenimientoProductoFormula(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(_mensaje)
                        ListarInsumos()
                    Else
                        msj_advert(_mensaje)
                    End If
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 0)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class