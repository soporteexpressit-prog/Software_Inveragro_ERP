Imports CapaNegocio
Imports CapaObjetos

Public Class FrmPlanteles
    Dim cn As New cnUbicacion
    Private _CodUbicacion As Integer
    Dim _Operacion As Integer

    Sub Nuevo()
        _Operacion = 0
        Cambio()
        limpiar()
    End Sub

    Sub limpiar()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtDescripcion.Select()
        _CodUbicacion = 0
    End Sub

    Sub Cambio()
        btnEditarCtubicacion.Visible = False
        btnGuardarCtubicacion.Visible = True
        btnCancelar.Visible = True
        txtDescripcion.Enabled = True
    End Sub
    Sub Cancelar()
        btnEditarCtubicacion.Visible = True
        btnGuardarCtubicacion.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
    End Sub

    Private Sub FrmPlanteles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Cancelar()
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

    Sub Mantenimiento()
        Try
            If (_Operacion = 1 OrElse _Operacion = 2) AndAlso (txtCodigo.Text = "" OrElse txtCodigo.Text.Length = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtDescripcion.Text = "" OrElse txtDescripcion.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If

            If (TxtDensidad.Text = "" OrElse TxtDensidad.Text.Length = 0) Then
                msj_advert("Densidad no Valida")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE ESTA ACCIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coUbicacion With {
                .Operacion = _Operacion,
                .Codigo = _CodUbicacion,
                .Descripcion = txtDescripcion.Text,
                .Densidad = CDec(TxtDensidad.Text),
                .NumChanchillas = NumChanchillas.Value,
                .Iduser = 1
            }

            Dim _mensaje As String = cn.Cn_MantenimientoPlanteles(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Cancelar()
                Consultar()
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        dtgListado.DataSource = cn.Cn_ConsultarPlanteles()
        dtgListado.DisplayLayout.Bands(0).Columns("idUbicacion").Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns("Raciones Asignadas").Hidden = True
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarCtubicacion.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodUbicacion = CInt(dtgListado.DisplayLayout.ActiveRow.Cells("idUbicacion").Value.ToString)
                txtCodigo.Text = _CodUbicacion.ToString
                txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells("Descripción").Value.ToString
                txtDescripcion.Focus()
                TxtDensidad.Text = dtgListado.DisplayLayout.ActiveRow.Cells("Densidad por Corral").Value.ToString
                NumChanchillas.Value = CInt(dtgListado.DisplayLayout.ActiveRow.Cells("+ N° Chanchillas").Value.ToString)
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarCtubicacion.Click
        Mantenimiento()
        TxtDensidad.Text = ""
        NumChanchillas.Value = 0
    End Sub

    Private Sub TxtDensidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDensidad.KeyPress
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class