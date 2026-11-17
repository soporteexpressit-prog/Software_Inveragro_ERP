Imports System.ComponentModel
Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmGestionGenetica
    Dim tbtmp As New DataTable
    Dim cn As New cnControlAnimal
    Public Modulo_CV As String = ""

    Private Sub FrmGestionGenetica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Ptbx_Cargando.Visible = True
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        ToolStrip1.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlAnimal With {
                .TipoControl = Modulo_CV
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            tbtmp = cn.Cn_ConsultarGenetica(obj).Copy
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
            dtgListado.DisplayLayout.Bands(0).Columns("codigo").Hidden = True
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim categoriaGenetica As Integer = 4
            Dim categoriaProduccion As Integer = 5

            'categoriaGenetica
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "SI", categoriaGenetica)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "NO", categoriaGenetica)

            'categoriaProduccion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "SI", categoriaProduccion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "NO", categoriaProduccion)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(categoriaGenetica).CellAppearance.TextHAlign = HAlign.Center
                .Columns(categoriaProduccion).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub BtnNueva_Click(sender As Object, e As EventArgs) Handles BtnNueva.Click
        Try
            Dim frm As New FrmMantenimientoGenetica With {
                ._CodGenetica = 0,
                ._Modulo = Modulo_CV
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then

                    Dim frm As New FrmMantenimientoGenetica With {
                        ._CodGenetica = activeRow.Cells("Codigo").Value,
                        ._Modulo = Modulo_CV
                    }
                    frm.ShowDialog()
                    Consultar()
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportarGenetica_Click(sender As Object, e As EventArgs) Handles BtnExportarGenetica.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("GENETICAS", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_ClickCell(sender As Object, e As UltraWinGrid.ClickCellEventArgs) Handles dtgListado.ClickCell
        Try
            Dim col As String = e.Cell.Column.Key
            If col <> "Cate. Genetica" AndAlso col <> "Cate. Produccion" Then Return

            ' Si ya tiene (SI) no hace nada
            If e.Cell.Value Is Nothing OrElse e.Cell.Value.ToString() <> "NO" Then Return

            Dim tipoCrear As String = If(col = "Cate. Genetica", "GENETICA", "PRODUCCION")
            Dim idGenetica As Integer = Convert.ToInt32(e.Cell.Row.Cells("codigo").Value)
            Dim desc As String = e.Cell.Row.Cells(2).Value.ToString()   ' columna Descripción

            If MessageBox.Show($"¿Está seguro de crear {tipoCrear} para {desc}?",
                               "Confirmar", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.Yes Then

                ' TODO guardado: usp_CrearProductosDesdeGenetica(idGenetica, tipoCrear, idUsuario)

                Dim obj As New coControlAnimal With {
                    .IdGenetica = idGenetica,
                    .TipoControl = tipoCrear,
                    .IdUsuario = VP_IdUser
                }

                Dim _mensaje As String = cn.Cn_EnlaceGeneticaProducto(obj)

                If (obj.Coderror = 0) Then
                    msj_ok(_mensaje)
                Else
                    msj_advert(_mensaje)
                End If

                Consultar()   ' recarga y la celda pasa a SI
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class