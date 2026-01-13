Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmProgramaAlimentacion
    Dim cn As New cnControlFormulacion
    Dim ds As New DataSet

    Private Sub FrmProgramaAlimentacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        cmbEstado.SelectedIndex = 0
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub BloquearControles()
        GrupoFiltros.Enabled = False
        Ptbx_Cargando.Visible = True
        BarraOpciones.Enabled = False
    End Sub

    Private Sub DesbloquearControles()
        GrupoFiltros.Enabled = True
        Ptbx_Cargando.Visible = False
        BarraOpciones.Enabled = True
    End Sub

    Private Sub BtnNuevoProgAlimentacion_Click(sender As Object, e As EventArgs) Handles BtnNuevoProgAlimentacion.Click
        Try
            Dim frm As New FrmMantProgramaAlimentacion With {
                .idProgramaAlimentacion = 0
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnEditarProgAlimentacion_Click(sender As Object, e As EventArgs) Handles BtnEditarProgAlimentacion.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim frm As New FrmMantProgramaAlimentacion With {
                        .idProgramaAlimentacion = activeRow.Cells(0).Value
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

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("PROGRAMA DE ALIMENTACIÓN", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()

            Dim obj As New coControlFormulacion With {
                .Anio = CInt(CmbAnios.Text),
                .Estado = cmbEstado.Text
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlFormulacion = CType(e.Argument, coControlFormulacion)

            ds = cn.Cn_ConsultarProgramaAlimentacion(obj).Copy
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
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estado As Integer = 7

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "INACTIVO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Consultar()
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class