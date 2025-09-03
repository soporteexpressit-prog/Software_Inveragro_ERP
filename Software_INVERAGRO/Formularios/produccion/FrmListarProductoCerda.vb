Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarProductoCerda
    Dim cn As New cnProducto
    Private ReadOnly _frmMantenimientoCerda As FrmMantenimientoCerda

    Public Sub New(frmMantenimientoCerda As FrmMantenimientoCerda)
        InitializeComponent()
        _frmMantenimientoCerda = frmMantenimientoCerda
    End Sub

    Private Sub FrmListarProductoCerda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ConsultarProductoCerda()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ConsultarProductoCerda()
        Try
            Dim obj As New coProductos With {
                .IdUbicacion = 6
            }
            dtgListado.DataSource = cn.Cn_ConsultarProductoCerda(obj)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Pink, Color.Black, "CERDO", 6)
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim codigo As String = e.Cell.Row.Cells(0).Value.ToString()
                    Dim descripcion As String = e.Cell.Row.Cells(1).Value.ToString()
                    Dim presentacion As String = e.Cell.Row.Cells(2).Value.ToString()
                    Dim stock As Decimal = e.Cell.Row.Cells(5).Value

                    If stock <= 0 Then
                        msj_advert("No hay stock disponible")
                        Exit Sub
                    End If

                    _frmMantenimientoCerda.LlenarCamposCerda(codigo, descripcion, presentacion)
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