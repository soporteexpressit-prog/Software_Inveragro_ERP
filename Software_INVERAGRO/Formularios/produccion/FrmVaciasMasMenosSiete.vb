Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmVaciasMasMenosSiete
    Dim cn As New cnControlAnimal
    Public idPlantel As Integer

    Private Sub FrmVaciasMasMenosSiete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ListarVaciasMasMenosSiete()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarVaciasMasMenosSiete()
        Dim obj As New coControlAnimal With {
            .Filtro = If(RbtVaciasMas7.Checked, "MAS 7", "MENOS 7"),
            .IdPlantel = idPlantel
        }

        dtgListado.DataSource = cn.Cn_ConsultarVaciasMasMenosSiete(obj)
    End Sub

    Private Sub RbtVaciasMas7_CheckedChanged(sender As Object, e As EventArgs) Handles RbtVaciasMas7.CheckedChanged
        If RbtVaciasMas7.Checked Then
            ListarVaciasMasMenosSiete()
        End If
    End Sub

    Private Sub RbtVaciasMenos7_CheckedChanged(sender As Object, e As EventArgs) Handles RbtVaciasMenos7.CheckedChanged
        If RbtVaciasMenos7.Checked Then
            ListarVaciasMasMenosSiete()
        End If
    End Sub

    Private Sub BtnExportarMG_Click(sender As Object, e As EventArgs) Handles BtnExportarMG.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE CERDAS VACÍAS", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count > 0) Then
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 0)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class