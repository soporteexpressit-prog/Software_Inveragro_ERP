Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlCorral
    Dim tbtmp As New DataTable
    Dim cn As New cnJaulaCorral
    Dim busqueda As Boolean = False

    Private Sub FrmControlCorral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            CmbEstado.SelectedIndex = 0
            ListarPlanteles()
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
                .Tipo = "CORRAL",
                .Estado = CmbEstado.Text
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
            dtgListado.DisplayLayout.Bands(0).Columns("densidadxCorral").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Sala").Hidden = True
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim nombreCorral As Integer = 2
            Dim estadoCapacidad As Integer = 10
            Dim estado As Integer = 11

            'colorear segun clave
            clsBasicas.Colorear_SegunClave(dtgListado, Color.LightBlue, Color.Black, "CLÍNICA", nombreCorral)

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

    Private Sub BtnNuevoCorral_Click(sender As Object, e As EventArgs) Handles BtnNuevoCorralpro.Click
        Try
            Dim frm As New FrmMantenimientoCorral With {
                ._CodCorral = 0,
                ._Densidad = dtgListado.ActiveRow.Cells("densidadxCorral").Value,
                ._IdUbicacion = cmbUbicacion.Value
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnEditarCorral_Click(sender As Object, e As EventArgs) Handles BtnEditarCorralpro.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim estadoCapacidad As String = activeRow.Cells("Estado Capacidad").Value

                    Dim frm As New FrmMantenimientoCorral With {
                        ._CodCorral = activeRow.Cells("Codigo").Value,
                        .estadoCapacidad = estadoCapacidad,
                        ._Densidad = dtgListado.ActiveRow.Cells("densidadxCorral").Value
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

    Private Sub btnBuscarCorral_Click(sender As Object, e As EventArgs) Handles btnBuscarCorral.Click
        Try
            busqueda = True
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportarCorral_Click(sender As Object, e As EventArgs) Handles BtnExportarCorralpro.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL DE CORRALES", dtgListado)
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

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class