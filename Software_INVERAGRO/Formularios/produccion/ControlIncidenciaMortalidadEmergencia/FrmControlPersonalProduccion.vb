Imports CapaNegocio
Imports Infragistics.Win

Public Class FrmControlPersonalProduccion
    Dim cn As New cnTrabajador
    Dim tbtmp As New DataTable

    Private Sub FrmControlPersonalProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            tbtmp = cn.Cn_ConsultarPersonalProduccion().Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            ToolStrip1.Enabled = True
            dtgListado.DisplayLayout.Bands(0).Columns("idPersona").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("idCargo").Hidden = True
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim tipoAdquisicion As Integer = 4
            Dim estado As Integer = 5

            'tipoAdquisicion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightSkyBlue, Color.Black, "INSEMINADOR(A)", tipoAdquisicion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightPink, Color.Black, "MATERNERO(A)", tipoAdquisicion)

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.Black, "ACTIVO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "INACTIVO", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(tipoAdquisicion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnNuevoPtipoin_Click(sender As Object, e As EventArgs) Handles btnNuevoPtipoin.Click
        Try
            Dim frm As New FrmMantPersonalProduccion With {
                .operacion = 0
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnEditarPtipoin_Click(sender As Object, e As EventArgs) Handles btnEditarPtipoin.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim frm As New FrmMantPersonalProduccion With {
                        .operacion = 1,
                        .idPersonaProduccion = activeRow.Cells("idPersona").Value,
                        .dni = activeRow.Cells("DNI").Value,
                        .nombre = activeRow.Cells("Personal").Value,
                        .idCargo = activeRow.Cells("idCargo").Value,
                        .estado = activeRow.Cells("Estado").Value
                    }
                    frm.ShowDialog()
                    Consultar()
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub
End Class