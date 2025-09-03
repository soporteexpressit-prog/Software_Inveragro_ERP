Imports CapaNegocio
Imports CapaObjetos

Public Class FrmControlBonificacionNN
    Dim cn As New cnControlBonificacionVehiculoNN
    Dim estadoBusqueda As Integer = 0

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevoctbonivehi.Click
        Dim f As New FrmRegistrarBonificacionVehiculoNN
        f.ShowDialog()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportarctbonivehi.Click
        Try
            clsBasicas.ExportarExcel("Control de Bonificacion", dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FrmControlBonificacionNN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializar()
        Consultar()
    End Sub
    Sub Inicializar()
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        txtPermiso.Text = ""
        txtResolucion.Text = ""
        txtPlaca.Text = ""
    End Sub


    Sub Consultar()
        Dim obj As New coControlBonificacionVehiculoNN

        If estadoBusqueda = 0 Then
            obj.FechaDesde = Nothing
            obj.FechaHasta = Nothing
            obj.NumPermiso = Nothing
            obj.NumResolucion = Nothing
            obj.Placa = Nothing
        Else
            obj.FechaDesde = dtpFechaDesde.Value
            obj.FechaHasta = dtpFechaHasta.Value
            obj.NumPermiso = txtPermiso.Text
            obj.NumResolucion = txtResolucion.Text
            obj.Placa = txtPlaca.Text
        End If

        Dim dt As DataTable = cn.Cn_Consultar(obj)
        dtgListado.DataSource = dt
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", 12)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 12)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        estadoBusqueda = 1
        Consultar()
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivarctbonivehi.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim estado As String = dtgListado.ActiveRow.Cells(12).Value.ToString
                If estado = "ANULADO" Then
                    msj_advert("Esta bonificación por suspeción de vehículo ya fue anulado")
                    Exit Sub
                End If
                Dim f As New FrmAnularBonificacionVehiculoNN
                f.Id_Bonificacion = CInt(dtgListado.ActiveRow.Cells(0).Value.ToString())
                f.ShowDialog()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
End Class