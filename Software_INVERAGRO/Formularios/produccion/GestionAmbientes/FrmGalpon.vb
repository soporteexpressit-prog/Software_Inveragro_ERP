Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmGalpon
    Dim cn As New cnGalpon
    Private _CodGalpon As Integer

    Private Sub FrmGalpon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarPlanteles()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
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

    Sub Consultar()
        Dim obj As New coGalpon With {
            .Descripcion = "",
            .IdUbicacion = If(CkxTodos.Checked, Nothing, cmbUbicacion.Value)
        }
        dtgListado.DataSource = cn.Cn_Consultar(obj)
        dtgListado.DisplayLayout.Bands(0).Columns("Codigo").Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns("esEmbarcadero").Hidden = True
        Colorear()
    End Sub

    Private Sub CkxTodos_CheckedChanged(sender As Object, e As EventArgs) Handles CkxTodos.CheckedChanged
        Consultar()
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim nombreGalpon As Integer = 1
            Dim estadoCapacidad As Integer = 4

            'estadoCapacidad
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "LIBRE", estadoCapacidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightYellow, Color.DarkGoldenrod, "PARCIAL", estadoCapacidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "COMPLETO", estadoCapacidad)

            'nombreGalpon
            clsBasicas.Colorear_SegunClave(dtgListado, Color.LightYellow, Color.Black, "EMBARCADERO", nombreGalpon)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estadoCapacidad).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
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

    Private Sub btnNuevoPgal_Click(sender As Object, e As EventArgs) Handles btnNuevoPgal.Click
        Try
            Dim frm As New FrmMantenimientoGalpon With {
                ._IdGalpon = 0
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnEditarPgal_Click(sender As Object, e As EventArgs) Handles btnEditarPgal.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim idGalpon As Integer = CInt(activeRow.Cells("Codigo").Value)

                    Dim frm As New FrmMantenimientoGalpon With {
                        ._IdGalpon = idGalpon
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

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If (MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE GALPÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    Dim obj As New coGalpon With {
                        .Operacion = 2, 'Eliminar
                        .Codigo = activeRow.Cells(0).Value.ToString(),
                        .Descripcion = "",
                        .IdUbicacion = cmbUbicacion.Value,
                        .IdArea = cmbArea.Value,
                        .EsEmbarcadero = "NO"
                    }

                    Dim MensajeBgWk As String = cn.Cn_Mantenimiento(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(MensajeBgWk)
                        Consultar()
                    Else
                        msj_advert(MensajeBgWk)
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

    Private Sub BtnExportarBtnMandarCamalprocontrolverracos_Click(sender As Object, e As EventArgs) Handles BtnExportarBtnMandarCamalprocontrolverracos.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE GALPONES", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cmbUbicacion_ValueChanged(sender As Object, e As EventArgs) Handles cmbUbicacion.ValueChanged
        Consultar()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class