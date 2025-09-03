Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmReporteVentasyContabilidad
    Dim cn As New cnVentas
    Dim tbtmp As New DataTable


    Private Sub FrmReporteVentasyContabilidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaDesde.Value = Now.Date
        dtpFechaHasta.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListadoventa)
        clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtglistadopagos)
        Consultar()
        Consultarcobros()
        ObtenerDatosCuentaporCobrar()
    End Sub

    Sub ObtenerDatosCuentaporCobrar()
        Try
            Dim cn As New cnCtaCobrar
            Dim obj As New coCtaCobrar With {.Id = txtproveedor.AccessibleDescription}
            Dim ds As DataSet = cn.Cn_ObtenerDatosdeCuentaPagarSFP(obj)

            ' 1) Texto: de Tables(1)
            If ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 0 Then
                Dim info As DataRow = ds.Tables(1).Rows(0)
                txtsaldofavor.Text = info("saldo disponible").ToString()
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub



    Private Sub btnbuscarpoveedor_Click(sender As Object, e As EventArgs) Handles btnbuscarpoveedor.Click
        Dim f As New FrmBuscarProveedorTrabajador
        f.ShowDialog()
        If (f.codproveedor <> 0) Then
            txtproveedor.AccessibleDescription = f.codproveedor
            txtproveedor.Text = f.razonsocial
            f.codproveedor = 0
        Else
            txtproveedor.AccessibleDescription = "0"
            txtproveedor.Clear()
        End If
    End Sub

    Sub Consultar()
        Try
            Dim obj As New coVentas With {
                .Fechadesde = dtpFechaDesde.Value,
                .Fechahasta = dtpFechaHasta.Value,
                .Iduser = txtproveedor.AccessibleDescription
            }
            dtgListadoventa.DataSource = cn.Cn_ReporteVentaCerdosPorcliente(obj).Copy
        Catch ex As Exception
        End Try
    End Sub


    Sub Consultarcobros()
        Try
            Dim obj As New coVentas With {
                .Fechadesde = dtpFechaDesde.Value,
                .Fechahasta = dtpFechaHasta.Value,
                .Iduser = txtproveedor.AccessibleDescription
            }
            dtglistadopagos.DataSource = cn.Cn_ReporteCobrosVentas(obj).Copy
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtproveedor.AccessibleDescription = "0" Or txtproveedor.Text = "" Then
            MsgBox("Debe seleccionar un proveedor", MsgBoxStyle.Exclamation, "Atención")
            txtproveedor.Focus()
            Return
        End If
        Consultar()
        Consultarcobros()
        ObtenerDatosCuentaporCobrar()
    End Sub

    Private Sub dtgListadoventa_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListadoventa.InitializeLayout
        Try
            clsBasicas.Totales_Formato(dtgListadoventa, e, 0)
            clsBasicas.SumarTotales_Formato(dtgListadoventa, e, 1)
            clsBasicas.SumarTotales_Formato(dtgListadoventa, e, 4)
            clsBasicas.PromedioTotales_divisiondoscolumnas(dtgListadoventa, e, 6, 4, 5)
            clsBasicas.SumarTotales_Formato(dtgListadoventa, e, 6)

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtglistadopagos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtglistadopagos.InitializeLayout
        Try
            clsBasicas.Totales_Formato(dtglistadopagos, e, 0)
            clsBasicas.SumarTotales_Formato(dtglistadopagos, e, 3)

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If ToolStripButton2.Checked Then
            ' Si está marcado, restauramos la vista de agrupamiento
            dtgListadoventa.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
            dtgListadoventa.DisplayLayout.GroupByBox.Hidden = False
            dtglistadopagos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
            dtglistadopagos.DisplayLayout.GroupByBox.Hidden = False
        Else
            ' Si no está marcado, cambiamos a la vista horizontal y ocultamos el GroupByBox
            dtgListadoventa.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal
            dtgListadoventa.DisplayLayout.GroupByBox.Hidden = True
            dtgListadoventa.DisplayLayout.Bands(0).SortedColumns.Clear() ' Eliminar agrupamiento y orden
            dtglistadopagos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal
            dtglistadopagos.DisplayLayout.GroupByBox.Hidden = True
            dtglistadopagos.DisplayLayout.Bands(0).SortedColumns.Clear() ' Eliminar agrupamiento y orden
        End If
        ' Alternar el estado de ToolStripButton2
        ToolStripButton2.Checked = Not ToolStripButton2.Checked
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim frm As New FrmConsolidadoCliente
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim frm As New FrmConsolidadoVentasMensualesVendedor
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class