Imports CapaNegocio

Public Class FrmSeleccionarNutricionista
    Private Sub FrmSeleccionarNutricionista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarNutricionista()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarNutricionista()
        Dim cn As New cnNucleo
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarNutricionistaCombo().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione Nutricionista"
        With CmbNutricionista
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Try
            Dim f As New FrmRegistrarFormula With {
                .idNutricionista = CmbNutricionista.Value
            }
            f.ShowDialog()
            Dispose()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class