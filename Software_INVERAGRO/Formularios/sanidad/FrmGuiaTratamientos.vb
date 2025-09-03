Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmGuiaTratamientos
    Dim tbtmp As New DataTable

    Private Sub FrmGuiaTratamientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            WindowState = Windows.Forms.FormWindowState.Maximized
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ConsultarItems()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ConsultarItems()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coEnfermedad
            Dim cn As New cnEnfermedad
            obj.Nombre = txtnombre.Text
            tbtmp = cn.Cn_ConsultarDetalleTratamiento(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        btnBuscar.Enabled = True
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "INACTIVO", 6)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 6)
            ToolStrip1.Enabled = True
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        End If
    End Sub
    Private Sub btnNuevoTratamiento_Click(sender As Object, e As EventArgs) Handles btnNuevoTratamientosani.Click
        Dim f As New FrmNuevoTratamiento
        f.ShowDialog()
        ConsultarItems()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Ptbx_Cargando.Visible = True
        btnBuscar.Enabled = False
        ConsultarItems()
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarsanidad.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim idDetTratamiento As Integer = activeRow.Cells(0).Value
                Dim enfermedad As String = activeRow.Cells(1).Value
                Dim producto As String = activeRow.Cells(2).Value
                Dim edadLote As Integer = activeRow.Cells(3).Value
                Dim observacion As String = activeRow.Cells(4).Value
                Dim estado As String = activeRow.Cells(6).Value

                Dim frm As New FrmEditarTratamiento With {
                    .idDetTratamiento = idDetTratamiento,
                    .nombreEnfermedad = enfermedad,
                    .nombreProducto = producto,
                    .edadLote = edadLote,
                    .observacion = observacion,
                    .estado = estado
                }
                frm.ShowDialog()
                ConsultarItems()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub
End Class