Imports CapaNegocio

Public Class FrmListarInsumosFormulacion
    Dim cn As New cnProducto
    Private ReadOnly _frmRegistrarInsumoExcedente As FrmRegistrarInsumoExcedente

    Public Sub New(frmRegistrarInsumoExcedente As FrmRegistrarInsumoExcedente)
        InitializeComponent()
        _frmRegistrarInsumoExcedente = frmRegistrarInsumoExcedente
    End Sub
    Private Sub FrmListarInsumosFormulacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarInsumos()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarInsumos()
        Dim dt As DataTable = cn.Cn_ListarInsumosActivos()
        DtgListadoInsumo.DataSource = dt
        clsBasicas.Filtrar_Tabla(DtgListadoInsumo, True)
        clsBasicas.Formato_Tablas_Grid(DtgListadoInsumo)
        DtgListadoInsumo.DisplayLayout.Bands(0).Columns(0).Hidden = True
    End Sub

    Private Sub DtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles DtgListadoInsumo.DoubleClickCell
        Try
            If (DtgListadoInsumo.Rows.Count > 0) Then
                If (DtgListadoInsumo.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim codigo As String = e.Cell.Row.Cells(0).Value.ToString()
                    Dim descripcion As String = e.Cell.Row.Cells(1).Value.ToString()
                    Dim presentacion As String = e.Cell.Row.Cells(3).Value.ToString()
                    _frmRegistrarInsumoExcedente.LlenarCamposInsumo(codigo, descripcion, presentacion)
                    Dispose()
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Dispose()
    End Sub
End Class