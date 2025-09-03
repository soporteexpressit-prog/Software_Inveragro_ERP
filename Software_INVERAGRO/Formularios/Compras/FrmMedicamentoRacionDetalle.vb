Imports CapaNegocio

Public Class FrmMedicamentoRacionDetalle
    Dim cn As New cnControlAlimento
    Dim ds As New DataSet

    Private Sub FrmMedicamentoRacionDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'ds = cn.Cn_ConsultarDetalleSalidaAntiMedicadoRacion()
            'dtgListadoConsolidado.DataSource = ds.Tables(0)
            'clsBasicas.Formato_Tablas_Grid(dtgListadoConsolidado)
            'dtgListadoConsolidado.DisplayLayout.Bands(0).Columns(0).Hidden = True

            'dtgListadoRequerimientos.DataSource = ds.Tables(1)
            'clsBasicas.Formato_Tablas_Grid(dtgListadoRequerimientos)
            'dtgListadoRequerimientos.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            If (dtgListadoRequerimientos.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("LISTA DE MEDICAMENTOS A PEDIR", dtgListadoRequerimientos)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class