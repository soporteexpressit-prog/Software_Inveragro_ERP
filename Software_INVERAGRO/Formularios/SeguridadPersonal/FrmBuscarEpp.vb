Imports CapaNegocio
Imports CapaObjetos

Public Class FrmBuscarEpp
    Dim cn As New cnProducto
    Public idplantel As Integer
    Private ReadOnly _formularioMantenimientoEpp As FrmMantenimientoEpp

    Public Sub New(formularioMantEpp As FrmMantenimientoEpp)
        InitializeComponent()
        _formularioMantenimientoEpp = formularioMantEpp
    End Sub

    Private Sub FrmBuscarEpp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ListarProductosEpp()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarProductosEpp()
        Dim obj As New coProductos
        obj.IdUbicacion = idplantel
        dtgListado.DataSource = cn.Cn_ListarProductoEpp(obj)
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.Rows.Count = 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If

        ' Validamos que haya una fila seleccionada
        If e.Cell Is Nothing OrElse e.Cell.Row Is Nothing Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If

        ' Validamos que el índice sea válido
        If e.Cell.Row.Index < 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim codigo As String = e.Cell.Row.Cells(0).Value.ToString()
                    Dim descripcion As String = e.Cell.Row.Cells(1).Value.ToString()
                    Dim presentacion As String = e.Cell.Row.Cells(2).Value.ToString()
                    Dim stock As Integer = CInt(e.Cell.Row.Cells(3).Value)

                    _formularioMantenimientoEpp.LlenarCamposEpp(codigo, descripcion, presentacion, stock)
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