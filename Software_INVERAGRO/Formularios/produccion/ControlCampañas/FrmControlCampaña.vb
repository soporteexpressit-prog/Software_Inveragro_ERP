Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlCampaña
    Dim cn As New cnControlLoteDestete
    Dim ds As New DataSet
    Dim search As Boolean = False

    Private Sub FrmControlCampaña_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        clsBasicas.LlenarComboAnios(CmbAnios)
        Ptbx_Cargando.Visible = True
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub BloquearControles()
        Ptbx_Cargando.Visible = True
        ToolStrip1.Enabled = False
        GrupoFiltros.Enabled = False
    End Sub

    Private Sub DesBloquearControles()
        Ptbx_Cargando.Visible = False
        ToolStrip1.Enabled = True
        GrupoFiltros.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()

            Dim obj As New coControlLoteDestete With {
                .Anio = CInt(CmbAnios.Text)
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            ds = cn.Cn_ConsultarCampaña(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns("idcampaña").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idcampaña").ColumnMapping = MappingType.Hidden
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
            DesBloquearControles()
            search = True
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estadoLlenado As Integer = 7
            Dim estadoCampaña As Integer = 8

            'estadoLlenado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "APERTURADO", estadoLlenado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.DarkRed, Color.White, "CERRADO", estadoLlenado)

            'estadoCampaña
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "EN CURSO", estadoCampaña)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "FINALIZADO", estadoCampaña)

            'centrar estado
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estadoLlenado).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoCampaña).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL DE CAMPAÑAS", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CmbAnios_TextChanged(sender As Object, e As EventArgs) Handles CmbAnios.TextChanged
        If search Then
            Consultar()
        End If
    End Sub

    Private Sub BtnReporteEngorde_Click(sender As Object, e As EventArgs) Handles BtnReporteEngorde.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim frm As New FrmReporteEngordeCampana With {
                    .idCampaña = dtgListado.ActiveRow.Cells("idcampaña").Value
                }
                frm.ShowDialog()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class