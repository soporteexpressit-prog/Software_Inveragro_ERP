Imports CapaNegocio
Imports CapaObjetos

Public Class FrmEmpleadosEnVacaciones
    Dim cn As New cnTrabajador
    Public frecuenciapago As Integer
    Private Sub FrmEmpleadosEnVacaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarTrabajadoresActivos()
    End Sub

    Sub ListarTrabajadoresActivos()
        Dim obj As New coControlPagosyDes
        obj.frecuenciapago = frecuenciapago
        dtgListado.DataSource = cn.Cn_ListarTrabajadoresvacaciones(obj)
    End Sub
    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        ' Verificar que la columna 9 exista antes de ocultarla
        If e.Layout.Bands(0).Columns.Count > 3 Then
            e.Layout.Bands(0).Columns(3).Hidden = True
        End If
        If e.Layout.Bands(0).Columns.Count > 0 Then
            e.Layout.Bands(0).Columns(0).Hidden = True
        End If
    End Sub

End Class