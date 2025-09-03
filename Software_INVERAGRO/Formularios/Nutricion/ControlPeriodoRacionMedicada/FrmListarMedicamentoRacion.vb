Imports CapaNegocio

Public Class FrmListarMedicamentoRacion
    Dim cn As New cnProducto
    Private ReadOnly _frmMantMedicacionRacion As FrmRegistrarMedicacionRacion

    Public Sub New(frmMantMedicacionRacion As FrmRegistrarMedicacionRacion)
        InitializeComponent()
        _frmMantMedicacionRacion = frmMantMedicacionRacion
    End Sub

    Private Sub FrmListarMedicamentoRacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ListarMedicamentos()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarMedicamentos()
        Dim dt As DataTable = cn.Cn_ListarMedicamentosActivos(0)
        dtgListado.DataSource = dt
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim codigo As String = e.Cell.Row.Cells(0).Value.ToString()
                Dim descripcion As String = e.Cell.Row.Cells(1).Value.ToString()
                Dim unidad As String = e.Cell.Row.Cells(2).Value.ToString()
                _frmMantMedicacionRacion.LlenarCamposMedicamentoRacion(codigo, descripcion, unidad)
                Me.Close()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class