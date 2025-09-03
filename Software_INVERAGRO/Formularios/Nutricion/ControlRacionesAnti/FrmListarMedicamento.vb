Imports CapaNegocio

Public Class FrmListarMedicamento
    Dim cn As New cnProducto
    Private ReadOnly _frmRegistrarAnti As FrmRegistrarExtra

    Public Sub New(frmRegistrarAnti As FrmRegistrarExtra)
        InitializeComponent()
        _frmRegistrarAnti = frmRegistrarAnti
    End Sub

    Private Sub FrmListarMedicamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ListarMedicamentos()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarMedicamentos()
        dtgListado.DataSource = cn.Cn_ListarMedicamentosActivos(6)
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns(2).Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns(3).Hidden = True
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                Dim activeRow = dtgListado.ActiveRow
                If activeRow IsNot Nothing AndAlso activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(0).Value.ToString().Length <> 0 Then
                    Dim codigo As String = activeRow.Cells(0).Value.ToString()
                    Dim descripcion As String = activeRow.Cells(1).Value.ToString()
                    Dim unidadMedida As String = activeRow.Cells(2).Value.ToString()
                    _frmRegistrarAnti.LlenarCamposMedicamento(codigo, descripcion, unidadMedida)
                    Me.Close()
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException("", ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class