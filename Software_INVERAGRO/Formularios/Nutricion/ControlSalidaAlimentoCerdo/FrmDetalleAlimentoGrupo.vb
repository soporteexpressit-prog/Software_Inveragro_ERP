Imports CapaNegocio
Imports CapaObjetos

Public Class FrmDetalleAlimentoGrupo
    Public IdGrupo As Integer = 0
    Public IdAlimento As Integer = 0
    Public IdUbicacion As Integer = 0
    Dim cn As New cnControlAlimento

    ' Propiedad para indicar si se eliminó exitosamente
    Public Property EliminadoExitoso As Boolean = False

    Private Sub FrmDetalleAlimentoGrupo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ListarAlimentos()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarAlimentos()
        Try
            Dim obj As New coControlAlimento With {
                .IdUbicacion = IdUbicacion,
                .IdGrupo = IdGrupo,
                .IdProducto = IdAlimento
            }
            dtgListado.DataSource = cn.Cn_ListarxDetalleAlimentoGrupo(obj)
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        If e.Row.Band.Index = 0 Then
            Dim colVerPDF As Infragistics.Win.UltraWinGrid.UltraGridColumn
            If dtgListado.DisplayLayout.Bands(0).Columns.Exists("Eliminar") Then
                colVerPDF = dtgListado.DisplayLayout.Bands(0).Columns("Eliminar")
                colVerPDF.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                colVerPDF.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                If Not e.ReInitialize Then
                    e.Row.Cells("Eliminar").Value = "Eliminar"
                    e.Row.Cells("Eliminar").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                End If
            End If
        End If
    End Sub
    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "Eliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE REGISTRO?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim idDetGrupo As Integer = Convert.ToInt32(e.Cell.Row.Cells(0).Value)

                Dim obj As New coControlAlimento With {
                    .Codigo = idDetGrupo,
                    .IdUsuario = VP_IdUser
                }

                Dim MensajeBgWk As String = cn.Cn_EliminarDetalleAlimentoGrupo(obj)
                If (obj.Coderror = 0) Then
                    EliminadoExitoso = True ' Marcar como eliminado exitosamente
                    ListarAlimentos()
                Else
                    msj_advert(MensajeBgWk)
                End If
            End If
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 3)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class