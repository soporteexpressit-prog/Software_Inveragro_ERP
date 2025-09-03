Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmTipoIncidencia
    Dim cn As New cnTipoIncidencia

    Private Sub FrmTipoIncidencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub

    Sub Consultar()
        dtgListado.DataSource = cn.Cn_ConsultarTipoIncidencia()
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Colorear()
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim aplicar As Integer = 2
            Dim tipo As Integer = 3

            'tipo
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "INCIDENCIA", tipo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "MORTALIDAD", tipo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.Black, "REGULARIZACIÓN", tipo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "EMERGENCIA", tipo)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(tipo).CellAppearance.TextHAlign = HAlign.Center
                .Columns(aplicar).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoPtipoin.Click
        Try
            Dim frm As New FrmMantenimientoMotivosProduccion With {
                .operacion = 0
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnEditarPtipoin_Click(sender As Object, e As EventArgs) Handles btnEditarPtipoin.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim frm As New FrmMantenimientoMotivosProduccion With {
                    .operacion = 1,
                    .idTipoIncidencia = activeRow.Cells("Codigo").Value,
                    .descripcion = activeRow.Cells("Descripción").Value.ToString,
                    .tipo = activeRow.Cells("Tipo").Value.ToString
                }
                frm.ShowDialog()
                Consultar()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub BtnExportarBtnMandarCamalprocontrolverracos_Click(sender As Object, e As EventArgs) Handles BtnExportarBtnMandarCamalprocontrolverracos.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("MOTIVOS DE INCIDENCIAS Y MORTALIDAD EN PLANTELES", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class