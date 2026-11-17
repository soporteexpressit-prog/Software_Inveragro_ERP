Imports CapaNegocio
Imports CapaObjetos

Public Class FrmAsociarProductoRacion
    Dim cn As New cnControlFormulacion
    Dim ds As New DataSet

    Private Sub FrmAsociarProductoRacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        Ptbx_Cargando.Visible = True
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub BloquearControles()
        Ptbx_Cargando.Visible = True
        BarraOpciones.Enabled = False
    End Sub

    Private Sub DesbloquearControles()
        Ptbx_Cargando.Visible = False
        BarraOpciones.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            ds = cn.Cn_ConsultarAgrupacionProductoRacion().Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(1).ColumnMapping = MappingType.Hidden
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = ds.Tables(0)
            DesbloquearControles()
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If e.Layout.Bands.Count > 1 AndAlso e.Layout.Bands(1).Columns.Exists("Desagrupar") Then
                With e.Layout.Bands(1).Columns("Desagrupar")
                    .Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                    .ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                    .Header.Caption = "Desagrupar"
                End With
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        If e.Row.Band.Index = 1 AndAlso e.Row.Cells.Exists("Desagrupar") Then
            e.Row.Cells("Desagrupar").Value = "Desagrupar"
        End If
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            If e.Cell.Column.Key <> "Desagrupar" OrElse e.Cell.Row Is Nothing Then
                Return
            End If

            Dim idAgrupamiento As Integer = CInt(e.Cell.Row.Cells(0).Value)
            Dim resultado As DialogResult = MessageBox.Show(
                "¿Está seguro de desagrupar este producto-ración?",
                "Confirmar desagrupación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If resultado <> DialogResult.Yes Then
                Return
            End If

            Dim obj As New coControlFormulacion With {
                .Codigo = idAgrupamiento
            }
            Dim mensaje As String = cn.Cn_DesagruparProductoRacion(obj)

            If obj.Coderror = 0 Then
                msj_ok(mensaje)
                Consultar()
            Else
                msj_advert(mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnAsociar_Click(sender As Object, e As EventArgs) Handles BtnAsociar.Click
        Try
            Dim frm As New FrmMantAsociarRacionProducto
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            clsBasicas.ExportarExcel("Control Agrupamiento de Productos", dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class