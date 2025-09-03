Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmGalpon
    Dim cn As New cnGalpon
    Private _CodGalpon As Integer
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
        _CodGalpon = 0
    End Sub

    Sub Cambio()
        btnNuevoPgal.Visible = False
        btnEditarPgal.Visible = False
        btnGuardarPgal.Visible = True
        btnCancelar.Visible = True
        txtDescripcion.Enabled = True
        cmbUbicacion.Enabled = True
        cmbArea.Enabled = True
    End Sub
    Sub Cancelar()
        btnNuevoPgal.Visible = True
        btnEditarPgal.Visible = True
        btnGuardarPgal.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        cmbUbicacion.Enabled = False
        cmbArea.Enabled = False
        CkxEsEmbarcadero.Checked = False
    End Sub
    Private Sub FrmGalpon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Cancelar()
            ListarPlanteles()
            ListarAreas()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
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

    Sub ListarAreas()
        Dim cn As New cnArea
        Dim tb As New DataTable
        tb = cn.Cn_Listar().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Área"
        With cmbArea
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
            Dim _mensaje As String = ""
            If (_Operacion = 1 OrElse _Operacion = 2) AndAlso (txtCodigo.Text = "" OrElse txtCodigo.Text.Length = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtDescripcion.Text = "" OrElse txtDescripcion.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE ESTA ACCIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coGalpon With {
                .Operacion = _Operacion,
                .Codigo = _CodGalpon,
                .Descripcion = txtDescripcion.Text,
                .IdArea = cmbArea.Value,
                .IdUbicacion = cmbUbicacion.Value,
                .EsEmbarcadero = If(CkxEsEmbarcadero.Checked, "SI", "NO")
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

    Sub Consultar()
        Dim obj As New coGalpon With {
            .Descripcion = "",
            .IdUbicacion = Nothing
        }
        dtgListado.DataSource = cn.Cn_Consultar(obj)
        dtgListado.DisplayLayout.Bands(0).Columns("Codigo").Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns("esEmbarcadero").Hidden = True
        Colorear()
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
                .Columns(nombreGalpon).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoCapacidad).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoPgal.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarPgal.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodGalpon = CInt(dtgListado.DisplayLayout.ActiveRow.Cells("Codigo").Value.ToString)
                txtCodigo.Text = _CodGalpon.ToString
                txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells("Galpón").Value.ToString.Replace("- EMBARCADERO", "").Trim()
                txtDescripcion.Focus()
                cmbUbicacion.Text = dtgListado.DisplayLayout.ActiveRow.Cells("Plantel").Value.ToString
                cmbArea.Text = dtgListado.DisplayLayout.ActiveRow.Cells("Área").Value.ToString
                CkxEsEmbarcadero.Checked = dtgListado.DisplayLayout.ActiveRow.Cells("esEmbarcadero").Value.ToString = "SI"
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarPgal.Click
        Mantenimiento()
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class