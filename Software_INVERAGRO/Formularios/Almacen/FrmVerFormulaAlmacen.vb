Imports CapaNegocio
Imports CapaObjetos

Public Class FrmVerFormulaAlmacen
    Dim cn As New cnControlFormulacion
    Dim tbtmp As New DataTable

    Private Sub FrmVerFormulaAlmacen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ListarNutricionista()
            Consultar()
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

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        GrupoFiltros.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        GrupoFiltros.Enabled = True
        ToolStrip1.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlFormulacion With {
                .IdNutricionista = CmbNutricionista.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlFormulacion = CType(e.Argument, coControlFormulacion)
            tbtmp = cn.Cn_ConsultarFormulaBasexIdNutricionista(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DesbloquearControladores()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            dtgListado.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
            Colorear()
        End If
    End Sub

    Private Sub Colorear()
        Try
            If dtgListado.Rows.Count >= 2 Then
                Dim ultimaFila = dtgListado.Rows(dtgListado.Rows.Count - 1)
                ultimaFila.Appearance.BackColor = Color.LightGray
                ultimaFila.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

                Dim penultimaFila = dtgListado.Rows(dtgListado.Rows.Count - 2)
                penultimaFila.Appearance.BackColor = Color.LightGray
                penultimaFila.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CmbNutricionista_TextChanged(sender As Object, e As EventArgs) Handles CmbNutricionista.TextChanged
        Consultar()
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class