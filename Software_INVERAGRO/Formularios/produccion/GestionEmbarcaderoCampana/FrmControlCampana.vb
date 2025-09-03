Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlCampana
    Dim cn As New cnControlCampanaEmbarque
    Dim ds As New DataSet
    Dim flag As Boolean = False

    Private Sub FrmControlCampana_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
            Consultar()
        Catch ex As Exception
            msj_advert(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        For i As Integer = DateTime.Now.Year - 10 To DateTime.Now.Year + 20
            CmbAnios.Items.Add(i.ToString())
        Next
        CmbAnios.DropDownStyle = ComboBoxStyle.DropDownList
        CmbAnios.Text = DateTime.Now.Year.ToString()
        Ptbx_Cargando.Visible = True
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlantelesEngorde().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbUbicacion
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            flag = True

            Dim obj As New coControlCampanaEmbarque With {
                .Anio = CInt(CmbAnios.Text),
                .IdPlantel = CmbUbicacion.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlCampanaEmbarque = CType(e.Argument, coControlCampanaEmbarque)

            ds = cn.Cn_ConsultarCampanas(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns("idPlantel").ColumnMapping = MappingType.Hidden
            ds.Tables(0).Columns("idcampaña").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idCampaña").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idLote").ColumnMapping = MappingType.Hidden
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = ds.Tables(0)
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estado As Integer = 6

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "CERRADO", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If flag Then
            Consultar()
        End If
    End Sub

    Private Sub BtnCerrarCapacidadCampana_Click(sender As Object, e As EventArgs) Handles BtnCerrarCapacidadCampanapro.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        If (MessageBox.Show("¿ESTÁ SEGURO DE CERRAR ESTA CAMPAÑA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                            Return
                        End If

                        Dim obj As New coControlCampanaEmbarque With {
                            .Codigo = activeRow.Cells(1).Value
                        }

                        Dim MensajeBgWk As String = cn.Cn_CerrarCapacidadCampana(obj)
                        If (obj.Coderror = 0) Then
                            msj_ok(MensajeBgWk)
                            Consultar()
                        Else
                            msj_advert(MensajeBgWk)
                        End If
                    Else
                        msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
                    End If
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

    Private Sub BtnExportarControlCerda_Click(sender As Object, e As EventArgs) Handles BtnExportarControlCerdaprocampa.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REGISTRO DE CAMPAÑAS", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class