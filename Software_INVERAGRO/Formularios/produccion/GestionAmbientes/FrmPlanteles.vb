Imports CapaNegocio
Imports CapaObjetos

Public Class FrmPlanteles
    Dim cn As New cnUbicacion
    Private _CodUbicacion As Integer
    Dim _Operacion As Integer

    Private Sub FrmPlanteles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Consultar()
            ListarPlanteles()
            If VariablesGlobales.estadoBloqueo Then
                CmbUbicacion.Enabled = False
                LblPlantelFijado.Text = "BLOQUEADO"
                LblPlantelFijado.BackColor = Color.Green
                LblPlantelFijado.ForeColor = Color.White
            Else
                LblPlantelFijado.Text = "DESBLOQUEADO"
                LblPlantelFijado.BackColor = Color.Red
                LblPlantelFijado.ForeColor = Color.White
                CmbUbicacion.Enabled = True
            End If
            CmbUbicacion.Value = VariablesGlobales.idPlantelGlobal
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlantelesReproduccion().Copy
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
        dtgListado.DataSource = cn.Cn_ConsultarPlanteles()
        dtgListado.DisplayLayout.Bands(0).Columns("idUbicacion").Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns("Raciones Asignadas").Hidden = True
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim idUbicacion As Integer = CInt(activeRow.Cells("idUbicacion").Value)

                    Dim frm As New FrmMantenimientoPlantel With {
                        ._IdUbicacion = idUbicacion
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

    Private Sub TxtDensidad_KeyPress(sender As Object, e As KeyPressEventArgs)
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        Dim column As Infragistics.Win.UltraWinGrid.UltraGridColumn = dtgListado.DisplayLayout.Bands(0).Columns("Acción")
        column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        If Not e.ReInitialize Then
            e.Row.Cells("Acción").Value = "Aplicar Densidad"
            e.Row.Cells("Acción").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        End If
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            With dtgListado
                If (e.Cell.Column.Key = "Acción") Then

                    If (MessageBox.Show("¿ESTÁ SEGURO DE APLICAR NUEVA DENSIDAD A TODOS LOS CORRALES?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    Dim obj As New coUbicacion
                    obj.Codigo = CInt(.ActiveRow.Cells("idUbicacion").Value)
                    obj.Densidad = CDec(.ActiveRow.Cells("Densidad por Corral").Value)
                    obj.NumChanchillas = CInt(.ActiveRow.Cells("+ N° Chanchillas").Value)

                    Dim _mensaje As String = cn.Cn_AplicarDensidadPlantel(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(_mensaje)
                        Consultar()
                    Else
                        msj_advert(_mensaje)
                    End If
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscarVehiculo_Click(sender As Object, e As EventArgs) Handles BtnBuscarVehiculo.Click
        CmbUbicacion.Enabled = Not CmbUbicacion.Enabled

        If Not CmbUbicacion.Enabled Then
            VariablesGlobales.idPlantelGlobal = CInt(CmbUbicacion.Value)
            VariablesGlobales.estadoBloqueo = True
        End If

        If CmbUbicacion.Enabled Then
            LblPlantelFijado.Text = "DESBLOQUEADO"
            LblPlantelFijado.BackColor = Color.Red
            LblPlantelFijado.ForeColor = Color.White
        Else
            LblPlantelFijado.Text = "BLOQUEADO"
            LblPlantelFijado.BackColor = Color.Green
            LblPlantelFijado.ForeColor = Color.White
        End If
    End Sub

    Private Sub BtnExportarBtnMandarCamalprocontrolverracos_Click(sender As Object, e As EventArgs) Handles BtnExportarBtnMandarCamalprocontrolverracos.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REPORTE PLANTELES", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Try
            Dim frm As New FrmMantenimientoPlantel With {
                ._IdUbicacion = 0
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class