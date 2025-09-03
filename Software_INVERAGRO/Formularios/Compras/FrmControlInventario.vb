Imports CapaNegocio
Imports CapaObjetos

Public Class FrmControlInventario
    Dim cn As New cnIngreso

    Dim ds As New DataSet
    Dim dt As New DataTable

    Private Sub FrmControlEpp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = Windows.Forms.FormWindowState.Maximized
        cbxestado.SelectedIndex = 0
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        cbxestado.SelectedIndex = 0
        Consultar()
        cbxtipodocumento.SelectedValue = 10
    End Sub
    Private _estado As String
    Private _Idtipodocumento As String
    Sub Consultar()
        'Pasamos todos los parametros y ejecutamos el hilo para cargar la busqueda
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            'GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            _estado = cbxestado.Text
            _Idtipodocumento = cbxtipodocumento.SelectedValue
            BackgroundWorker1.RunWorkerAsync()
        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coIngreso
            obj.Fechadesde = dtpFechaDesde.Value
            obj.Fechahasta = dtpFechaHasta.Value
            obj.Estado = _estado
            ds = New DataSet
            ds = cn.Cn_ConsultarInventario(obj).Copy
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        btnConsultar.Enabled = True
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            ds.DataSetName = "tmp"

            Dim relation1 As New DataRelation("tabla_relacion_32", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(0), False)

            ds.Relations.Add(relation1)
            dtgListado.DataSource = ds
            If (ds.Tables(0).Rows.Count > 0) Then
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", 2)
                clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 2)

            End If

            'GrupoMasOpcionesBusqueda.Enabled = True
            ToolStrip1.Enabled = True
        End If
        ToolStrip1.Enabled = True
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try

            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
            End With

            With e.Layout.Bands(1)
                .Columns(0).Hidden = True
            End With
            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 1)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    ' Agregar este manejador de eventos al formulario
    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        Try
            If e.Row.Band.Index = 1 Then
                Dim valor As Object = e.Row.Cells(5).Value
                If valor IsNot Nothing AndAlso IsNumeric(valor) Then
                    Dim valorNumerico As Double = CDbl(valor)
                    If valorNumerico = 0 Then
                        e.Row.Appearance.BackColor = Color.GreenYellow
                    ElseIf valorNumerico > 0 Then
                        e.Row.Appearance.BackColor = Color.LightBlue
                    ElseIf valorNumerico < 0 Then
                        e.Row.Appearance.BackColor = Color.Orange
                    End If
                End If
            End If
        Catch ex As Exception
            ' Manejar la excepción de manera apropiada
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        Consultar()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportarCIalmacen.Click
        clsBasicas.ExportarExcel("Lista de Inventarios", dtgListado)
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub UltraGroupBox2_Click(sender As Object, e As EventArgs) Handles UltraGroupBox2.Click

    End Sub


    Private Sub btnnuevoingresoinventario_Click(sender As Object, e As EventArgs) Handles btnnuevoingresoinventario.Click

        Try
            Dim f As New FrmIngresoProducto
            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles btnnuevasalidaregularizacion.Click

        Try
            Dim f As New FrmSalidaProducto
            f.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class