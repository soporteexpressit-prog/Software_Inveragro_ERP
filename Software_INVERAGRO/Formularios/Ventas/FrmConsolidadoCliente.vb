Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmConsolidadoCliente


    Dim cn As New cnVentas
    Dim tbtmp As New DataTable
    Dim usuarioActivo As Integer = ActiveSessionId


    Private Sub FrmConsolidadoCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.LlenarComboMeses(CmbMeses)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        Consultar()
    End Sub


    Sub Consultar()
        Try
            Dim obj As New coVentas With {
                    .Iduser = txtproveedor.AccessibleDescription,
                    .anio = CInt(CmbAnios.Text),
                    .Semana = If(CkbOmitirMes.Checked, 0, clsBasicas.ObtenerNumeroMes(CmbMeses))
                }
            dtgListado.DataSource = cn.Cn_ReporteVentaconsolidado(obj).Copy

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtproveedor.AccessibleDescription = "" Or txtproveedor.Text = "" Then
            msj_advert("Debe seleccionar un proveedor")
            Return
        End If
        Consultar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 0)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 2)
                clsBasicas.PromedioTotales_Formato(dtgListado, e, 3)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 4)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class