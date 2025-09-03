Imports CapaNegocio
Imports CapaObjetos

Public Class FrmBuscarOrdenesCompraPendientesFacturacion
    Dim cn As New cnIngreso
    Dim ds As New DataSet

    Sub ListarTipoDocumento()
        Try
            Dim dt As New DataTable
            dt = cn.Cn_ListarTipoDocumento().Copy
            dt.Columns(1).ColumnName = "Seleccione un Tipo de Documento"

            With cbxtipodocumento
                .DataSource = dt
                .DisplayMember = dt.Columns(1).ColumnName
                .ValueMember = dt.Columns(0).ColumnName
                If (dt.Rows.Count > 0) Then
                    .SelectedValue = dt.Rows(0)(0)
                End If
            End With

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub FrmControlEpp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cbxestado.SelectedIndex = 0
        dtpFechaDesde.Value = Now.Date.AddDays(-4)
        dtpFechaHasta.Value = Now.Date
        ListarTipoDocumento()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        cbxestado.SelectedIndex = 0
        Consultar()
    End Sub
    Private _estado As String
    Private _Idtipodocumento As String
    Sub Consultar()
        'Pasamos todos los parametros y ejecutamos el hilo para cargar la busqueda
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
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
            obj.Idtipodocumento = _Idtipodocumento
            obj.NombreProducto = txtProducto.Text
            obj.NombreProveedor = txtProveedor.Text
            ds = New DataSet
            ds = cn.Cn_ConsultarOrdenesCompraEnviadasaFacturacion(obj).Copy
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
            Dim relation1 As New DataRelation("tabla_relacion_32", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(5), False)

                ds.Relations.Add(relation1)
            dtgListado.DataSource = ds

            If (ds.Tables(0).Rows.Count > 0) Then
                'clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "ANULADO", 17)
                'clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 17)

                'clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "RECEPCIONADO", 18)
                'clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "PARCIAL", 18)
                'clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "SIN RECEPCION", 18)
            End If
            ToolStrip1.Enabled = True
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try

            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True
                .Columns("codorden").Header.VisiblePosition = 0
                .Columns("codorden").Header.Caption = "Código Orden"
                .Columns("codorden").Width = 130
                '.Columns(2).Hidden = True
                '.Columns(3).Hidden = True
                '.Columns(4).Hidden = True
                '.Columns(8).Hidden = True
                '.Columns(15).Hidden = True
                '.Columns("btnver").Header.Caption = "Cotización"
                '.Columns("btnver").Width = 80
                '.Columns("btnver").Style = UltraWinGrid.ColumnStyle.Button
                '.Columns("btnver").CellButtonAppearance.Image = My.Resources.adjuntar
                '.Columns("btnver").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always

            End With

            With e.Layout.Bands(1)
                .Columns(5).Hidden = True
            End With
            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 1)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 8)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
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

    Private Sub btnfacturar_Click(sender As Object, e As EventArgs) Handles btnfacturar.Click
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length = 0) Then
                    msj_advert("Seleccione una Orden de Compra")
                Else
                    Dim f As New FrmCompra
                    f._codordencompra = dtgListado.ActiveRow.Cells(0).Value.ToString
                    f.txtnumorden.Text = dtgListado.ActiveRow.Cells("codorden").Value.ToString
                    f.porfacturar = dtgListado.ActiveRow.Cells("Importe Pendiente de Facturar").Value.ToString
                    f.ShowDialog() ' Muestra el nuevo formulario
                    Consultar()
                End If
            Else
                msj_advert("Seleccione una Orden de Compra")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


End Class