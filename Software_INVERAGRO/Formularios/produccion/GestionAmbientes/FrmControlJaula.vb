Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlJaula
    Dim tbtmp As New DataTable
    Dim cn As New cnJaulaCorral

    Private Sub FrmControlJaula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarPlanteles()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Ptbx_Cargando.Visible = True
            CmbEstado.SelectedIndex = 0
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlanteles().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With cmbUbicacion
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
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

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coJaulaCorral With {
                .Descripcion = txtDescripcion.Text,
                .IdUbicacion = cmbUbicacion.Value,
                .Tipo = "JAULA",
                .Estado = "ACTIVO"
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coJaulaCorral = CType(e.Argument, coJaulaCorral)
            tbtmp = cn.Cn_Consultar(obj).Copy
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
            dtgListado.DisplayLayout.Bands(0).Columns("Codigo").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Dimensiones").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("densidadxCorral").Hidden = True
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estadoCapacidad As Integer = 10
            Dim estado As Integer = 11

            'estadoCapacidad
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "LIBRE", estadoCapacidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightYellow, Color.DarkGoldenrod, "PARCIAL", estadoCapacidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "LLENO", estadoCapacidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "NO DISPONIBLE", estadoCapacidad)

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "INACTIVO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estadoCapacidad).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub BtnNuevoJaula_Click(sender As Object, e As EventArgs) Handles BtnNuevoJaulapo.Click
        Try
            Dim frm As New FrmMantenimientoJaula With {
                ._CodJaula = 0,
                ._IdUbicacion = cmbUbicacion.Value
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnEditarJaula_Click(sender As Object, e As EventArgs) Handles BtnEditarJaulapro.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim estadoCapacidad As String = activeRow.Cells("Estado Capacidad").Value

                    Dim frm As New FrmMantenimientoJaula With {
                        ._CodJaula = activeRow.Cells("Codigo").Value,
                        .estadoCapacidad = estadoCapacidad,
                        .abreviatura = activeRow.Cells("Abreviatura").Value
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

    Private Sub BtnExportarJaula_Click(sender As Object, e As EventArgs) Handles BtnExportarJaularpo.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL DE JAULAS", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnBuscarJaula_Click(sender As Object, e As EventArgs) Handles btnBuscarJaula.Click
        Consultar()
    End Sub

    Private Sub BtnFiltro_Click(sender As Object, e As EventArgs) 
        Dim isFilterActive As Boolean = Not BtnFiltro.Checked
        BtnFiltro.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
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

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class