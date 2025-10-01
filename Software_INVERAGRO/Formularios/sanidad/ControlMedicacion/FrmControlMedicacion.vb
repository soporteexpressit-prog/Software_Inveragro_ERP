Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlMedicacion
    Dim cnUnidadMedida As New cnUnidadMedida
    Dim cn As New cnControlMedico
    Dim ds As New DataSet

    Private Sub FrmControlMedicacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        Me.KeyPreview = True
        Ptbx_Cargando.Visible = True
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        CmbModoAplicacion.SelectedIndex = 0
        CmbEstado.SelectedIndex = 0
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        GrupoFiltros.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        GrupoFiltros.Enabled = True
        ToolStrip1.Enabled = True
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlanteles().Copy
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
            BloquearControladores()

            Dim obj As New coControlMedico With {
                .FechaInicio = dtpFechaDesde.Value,
                .FechaFin = dtpFechaHasta.Value,
                .ModoAplicacion = CmbModoAplicacion.Text,
                .IdPlantel = CmbUbicacion.Value,
                .Estado = CmbEstado.Text
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlMedico = CType(e.Argument, coControlMedico)

            ds = cn.Cn_ConsultarMedicacion(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(0).ColumnMapping = MappingType.Hidden
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
            DesbloquearControladores()
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim tipoControl As Integer = If(CmbModoAplicacion.Text = "TRATAMIENTO", 19, 16)
            Dim estado As Integer = If(CmbModoAplicacion.Text = "TRATAMIENTO", 20, 17)

            'tipoControl
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightBlue, Color.Blue, "TRATAMIENTO", tipoControl)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightPink, Color.Red, "VACUNACIÓN", tipoControl)

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.PaleGreen, Color.DarkGreen, "APLICADO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.IndianRed, Color.White, "CANCELADO", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(tipoControl).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnBuscarMedicacion_Click(sender As Object, e As EventArgs) Handles btnBuscarMedicacion.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        dtgListado.DataSource = Nothing
        Consultar()
    End Sub

    Private Sub btnAnularbtnconfirmar_facturacionpedidocerdoventas_Click(sender As Object, e As EventArgs) Handles BtnCancelarmedicacioncerdossanidav2.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then

                    Dim estado As String = activeRow.Cells("Estado").Value.ToString

                    If estado = "CANCELADO" Then
                        msj_advert("LA MEDICACIÓN YA HA SIDO CANCELADA")
                        Return
                    End If

                    Dim frm As New FrmCancelarMedicacion With {
                        .IdControlFicha = activeRow.Cells(0).Value
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

    Private Sub btnexportarVmopevepedidocerdoventas_Click(sender As Object, e As EventArgs) Handles BtnExportarMedicacioncerdosanidadv2.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL DE MEDICACION", dtgListado)
            End If
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

    Private Sub BtnTratamiento_Click(sender As Object, e As EventArgs) Handles BtnTratamiento.Click
        Try
            Dim frm As New FrmRegistrarTratamientoCerdo With {
                .idPlantel = CmbUbicacion.Value
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnVacunacion_Click(sender As Object, e As EventArgs) Handles BtnVacunacion.Click
        Try
            Dim frm As New FrmRegistrarVacunacionCerdo With {
                .idPlantel = CmbUbicacion.Value
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmControlMedicacion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscarMedicacion.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BtnCronogramaGestacion_Click(sender As Object, e As EventArgs) Handles BtnCronogramaGestacion.Click
        Try
            Dim frm As New FrmCronogramaGestacion With {
                .idUbicacion = CmbUbicacion.Value
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCronogramaEngorde_Click(sender As Object, e As EventArgs) Handles BtnCronogramaEngorde.Click
        Try
            Dim frm As New FrmCronogramaEngordeVT With {
                .idUbicacion = CmbUbicacion.Value
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Dispose()
    End Sub
End Class