Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarProductosActivos

    Dim cn As New cnCotizacion
    Dim tb As New DataTable
    Private ReadOnly _frmAsignarUnidadesMedida As FrmAsignarUnidadesMedida

    Public Sub New(frmAsignarUnidadesMedida As FrmAsignarUnidadesMedida)
        InitializeComponent()
        _frmAsignarUnidadesMedida = frmAsignarUnidadesMedida
    End Sub

    Private Sub FrmListarProductosActivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarProductos()
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarProductos()
        tb = cn.Cn_ListarProductosActivos(6).Copy
        tb.TableName = "tmp"
        dtgListado.DataSource = tb
        With dtgListado
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(6).Hidden = True
            .DisplayLayout.Bands(0).Columns(7).Hidden = True
        End With
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim codigo As Integer = e.Cell.Row.Cells(0).Value
                Dim descripcion As String = e.Cell.Row.Cells(3).Value.ToString()
                Dim unidadmedida As String = e.Cell.Row.Cells(5).Value.ToString()

                _frmAsignarUnidadesMedida.LlenarCampoProducto(codigo, descripcion, unidadmedida)
                Me.Close()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class