Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmListarMatGeneticoRecepcionado
    Dim cn As New cnProducto
    Private ReadOnly _frmMantMaterialGenetico As FrmMantMaterialGenetico
    Public tipo As String = ""
    Public idUbicacion As Integer = 0

    Public Sub New(frmMantMaterialGenetico As FrmMantMaterialGenetico)
        InitializeComponent()
        _frmMantMaterialGenetico = frmMantMaterialGenetico
    End Sub

    Private Sub FrmListarMatGeneticoRecepcionado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ConsultarSemenPorcino()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ConsultarSemenPorcino()
        Try
            Dim obj As New coProductos With {
                .IdUbicacion = idUbicacion
            }
            dtgListado.DataSource = cn.Cn_ConsultarProductoSemen(obj)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            If tipo = "REGULARIZACIÓN" Then
                dtgListado.DisplayLayout.Bands(0).Columns("Último Precio Compra").Hidden = True
                dtgListado.DisplayLayout.Bands(0).Columns("Último Proveedor").Hidden = True
                dtgListado.DisplayLayout.Bands(0).Columns("Stock").Hidden = True
            End If
            Colorear()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim tipoProducto As Integer = 6

            'tipoProducto
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightBlue, Color.DarkBlue, "SEMEN", tipoProducto)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Pink, Color.Black, "CERDO", tipoProducto)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(tipoProducto).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow IsNot Nothing AndAlso dtgListado.ActiveRow.Cells(0).Value IsNot Nothing AndAlso dtgListado.ActiveRow.Cells(0).Value.ToString().Length <> 0) Then
                    Dim codigo As String = If(e.Cell.Row.Cells(0).Value IsNot Nothing, e.Cell.Row.Cells(0).Value.ToString(), "")
                    Dim descripcion As String = If(e.Cell.Row.Cells(1).Value IsNot Nothing, e.Cell.Row.Cells(1).Value.ToString(), "")
                    Dim presentacion As String = If(e.Cell.Row.Cells(2).Value IsNot Nothing, e.Cell.Row.Cells(2).Value.ToString(), "")

                    Dim stock As Decimal = 0
                    If tipo = "REGULARIZACIÓN" Then
                        stock = 0
                    ElseIf e.Cell.Row.Cells(5).Value IsNot Nothing Then
                        stock = CDec(e.Cell.Row.Cells(5).Value)
                    End If

                    Dim tipoProducto As String = If(e.Cell.Row.Cells(6).Value IsNot Nothing, e.Cell.Row.Cells(6).Value.ToString(), "")

                    If stock <= 0 And tipo <> "REGULARIZACIÓN" Then
                        msj_advert("No hay stock disponible")
                        Exit Sub
                    End If

                    _frmMantMaterialGenetico.LlenarCamposExternoSemenVerraco(codigo, descripcion, presentacion, stock, tipoProducto)
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