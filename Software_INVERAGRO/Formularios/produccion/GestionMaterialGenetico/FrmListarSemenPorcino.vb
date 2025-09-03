Imports CapaNegocio
Imports Infragistics.Win

Public Class FrmListarSemenPorcino
    Dim cn As New cnProducto
    Private ReadOnly _frmRegistrarPedidoSemenPorcino As FrmRegistrarPedidoSemenPorcino

    Private Sub FrmListarSemenPorcino_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ListarProductoLineaGenetica()
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            Colorear()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim sexo As Integer = 4
            Dim tipoProducto As Integer = 5

            'tipoProducto
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightBlue, Color.DarkBlue, "SEMEN", tipoProducto)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Pink, Color.Black, "CERDO", tipoProducto)

            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightBlue, Color.DarkBlue, "MACHO", sexo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Pink, Color.Black, "HEMBRA", sexo)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(tipoProducto).CellAppearance.TextHAlign = HAlign.Center
                .Columns(sexo).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Public Sub New(frmRegistrarPedidoSemenPorcino As FrmRegistrarPedidoSemenPorcino)
        InitializeComponent()
        _frmRegistrarPedidoSemenPorcino = frmRegistrarPedidoSemenPorcino
    End Sub

    Sub ListarProductoLineaGenetica()
        dtgListado.DataSource = cn.Cn_ListarProductoLineaGenetica()
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim codigo As String = e.Cell.Row.Cells("Código").Value.ToString()
                    Dim codigoGenetica As Integer = e.Cell.Row.Cells("Código Genética").Value
                    Dim descripcion As String = e.Cell.Row.Cells("Descripción").Value.ToString()
                    Dim presentacion As String = e.Cell.Row.Cells("Presentación").Value.ToString()
                    Dim tipoProducto As String = e.Cell.Row.Cells("Tipo Producto").Value.ToString()
                    _frmRegistrarPedidoSemenPorcino.LlenarCamposProductoGenetica(codigo, codigoGenetica, descripcion, presentacion, tipoProducto)
                    Me.Close()
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class