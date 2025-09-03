Imports CapaNegocio
Imports CapaObjetos

Public Class FrmControlActivo
    Dim cn As New cnActivo
    Dim estadoBusqueda As Integer = 0
    Private Sub FrmControlActivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializar()
        Consultar()
    End Sub

    Sub Inicializar()
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        cmbEstado.SelectedIndex = 2
        cmbTipo.SelectedIndex = 2
    End Sub

    Sub Consultar()
        Dim obj As New coActivo

        If estadoBusqueda = 0 Then
            obj.FechaDesde = Nothing
            obj.FechaHasta = Nothing
            obj.Tipo = cmbTipo.Text
            obj.Estado = cmbEstado.Text
        Else
            obj.FechaDesde = dtpFechaDesde.Value
            obj.FechaHasta = dtpFechaHasta.Value
            obj.Tipo = cmbTipo.Text
            obj.Estado = cmbEstado.Text
        End If

        dtgListado.DataSource = cn.Cn_ConsultarActivos(obj)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "EN SERVICIO", 14)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ASEGURADO", 15)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "INACTIVO", 17)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 17)
        dtgListado.DisplayLayout.Bands(0).Columns(13).Hidden = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarctconac.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim f As New FrmRegistrarActivo
                f._Codigo = dtgListado.ActiveRow.Cells(0).Value.ToString
                f.formControlActivo = Me
                f.tipo = dtgListado.ActiveRow.Cells(12).Value.ToString
                f.ShowDialog()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub



    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert("La fecha 'Desde' debe ser anterior o igual a la fecha 'Hasta'.")
            Return
        End If
        estadoBusqueda = 1
        Consultar()
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivarctconac.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim estado As String = dtgListado.ActiveRow.Cells(13).Value.ToString
                If estado = "INACTIVO" Then
                    msj_advert("El Activo ya fue dado de baja")
                    Exit Sub
                End If
                Dim f As New FrmDarBajaActivo
                f.Id_Activo = CInt(dtgListado.ActiveRow.Cells(0).Value.ToString())
                f.ShowDialog()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportarctconac.Click
        Try
            clsBasicas.ExportarExcel("Control de Activos", dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnImprimirTickets_Click(sender As Object, e As EventArgs) Handles btnImprimirTicketsctconac.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim estado As String = dtgListado.ActiveRow.Cells(14).Value.ToString
                If estado <> "EN SERVICIO" Then
                    msj_advert("No se puede imprimir ticket a un Activo que ya fue dado de baja")
                    Exit Sub
                End If
                Dim f As New FrmFormatoTicketActivo
                f._Codigo = dtgListado.ActiveRow.Cells(0).Value.ToString
                f._NumSerie = dtgListado.ActiveRow.Cells(2).Value.ToString
                f._Descripcion = dtgListado.ActiveRow.Cells(1).Value.ToString
                f.ShowDialog()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class