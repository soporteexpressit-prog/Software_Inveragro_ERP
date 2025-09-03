Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmMantNucleo
    Dim cn As New cnNucleo
    Private _CodNucleo As Integer
    Dim _Operacion As Integer
    Dim ds As New DataSet

    Sub Nuevo()
        _Operacion = 0
        Cambio()
        limpiar()
    End Sub

    Sub limpiar()
        txtDescripcion.Text = ""
        txtAbreviatura.Text = ""
        txtAbreviatura.Select()
        _CodNucleo = 0
    End Sub

    Sub Cambio()
        btnNuevo.Visible = False
        btnEditar.Visible = False
        btnGuardar.Visible = True
        btnCancelar.Visible = True
        txtDescripcion.Enabled = True
        txtAbreviatura.Enabled = True
        cmbEstado.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevo.Visible = True
        btnEditar.Visible = True
        btnGuardar.Visible = False
        btnCancelar.Visible = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        txtAbreviatura.Clear()
        txtAbreviatura.Enabled = False
        cmbEstado.SelectedIndex = 0
        cmbEstado.Enabled = False
    End Sub

    Private Sub FrmMantNucleo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Cancelar()
            Consultar()
            ListarNutricionista()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarNutricionista()
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarNutricionistaCombo().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione"
        With CmbNutricionista
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub Consultar()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ds = cn.Cn_Listar().Copy
        ds.DataSetName = "tmp"
        Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
        ds.Relations.Add(relation1)
        dtgListado.DataSource = ds
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        dtgListado.DisplayLayout.Bands(1).Columns(0).Hidden = True
        dtgListado.DisplayLayout.Bands(1).Columns(1).Hidden = True
        dtgListado.DisplayLayout.Bands(1).Columns(5).Hidden = True
        Colorear()
    End Sub

    Private Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            For Each row As UltraGridRow In dtgListado.Rows
                For Each childRow As UltraGridRow In row.ChildBands(0).Rows
                    Dim estadoCell As UltraGridCell = childRow.Cells("Estado")

                    Select Case estadoCell.Text
                        Case "ACTIVO"
                            With estadoCell.Appearance
                                .BackColor = Color.Green
                                .ForeColor = Color.White
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With estadoCell.ActiveAppearance
                                .BackColor = Color.Green
                                .ForeColor = Color.White
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With estadoCell.SelectedAppearance
                                .BackColor = Color.Green
                                .ForeColor = Color.White
                                .FontData.Bold = DefaultableBoolean.True
                            End With

                        Case "INACTIVO"
                            With estadoCell.Appearance
                                .BackColor = Color.Red
                                .ForeColor = Color.White
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With estadoCell.ActiveAppearance
                                .BackColor = Color.Red
                                .ForeColor = Color.White
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                            With estadoCell.SelectedAppearance
                                .BackColor = Color.Red
                                .ForeColor = Color.White
                                .FontData.Bold = DefaultableBoolean.True
                            End With
                    End Select
                Next
            Next

            With dtgListado.DisplayLayout.Bands(1)
                .Columns("Estado").CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (_Operacion = 1 OrElse _Operacion = 2) AndAlso (_CodNucleo = 0) Then
                msj_advert("Seleccione un Registro")
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtDescripcion.Text = "" OrElse txtDescripcion.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE GUARDAR ESTE REGISTRO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coNucleo With {
                .Operacion = _Operacion,
                .Codigo = _CodNucleo,
                .Descripcion = txtDescripcion.Text,
                .Abreviatura = txtAbreviatura.Text,
                .Estado = cmbEstado.Text,
                .IdNutricionista = CmbNutricionista.Value
            }

            _mensaje = cn.Cn_Mantenimiento(obj)
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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow

        If dtgListado.Rows.Count > 0 Then
            If activeRow IsNot Nothing AndAlso Not String.IsNullOrEmpty(activeRow.Cells(0).Value.ToString()) Then
                If activeRow.Band.Index > 0 Then
                    If (dtgListado.Rows.Count > 0) Then
                        If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                            _Operacion = 1
                            Cambio()
                            _CodNucleo = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString)
                            txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(3).Value.ToString
                            txtAbreviatura.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
                            txtAbreviatura.Focus()
                            cmbEstado.Text = dtgListado.DisplayLayout.ActiveRow.Cells(4).Value.ToString
                            CmbNutricionista.Value = dtgListado.DisplayLayout.ActiveRow.Cells(5).Value
                        Else
                            msj_advert("Seleccione un Registro")
                        End If
                    Else
                        msj_advert("Seleccione un Registro")
                    End If
                Else
                    msj_advert("SELECCIONE EL ITEM CONTENIDO")
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Mantenimiento()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class