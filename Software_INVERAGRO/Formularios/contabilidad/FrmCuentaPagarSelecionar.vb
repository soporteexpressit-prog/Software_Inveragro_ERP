Imports CapaNegocio
Imports CapaObjetos

Public Class FrmCuentaPagarSelecionar
    Dim cn As New cnCotizacion
    Public Property codproveedor As Integer
    Public Property codcuenta As Integer
    Public Property serie As String = ""
    Public Property correlativo As String = ""
    Public Property tiposervicio As String
    Public Property deudapendiente As String
    Public operacion As Integer
    Sub Consultar()
        Try
            Dim obj As New coCotizacion
            obj.IdDestino = codproveedor
            dtgListado.DataSource = cn.Cn_ConsultarxProveedorCuentaspagar(obj)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub Consultarabono()
        Try
            Dim obj As New coCotizacion
            obj.IdDestino = codproveedor
            dtgListado.DataSource = cn.Cn_ConsultarxProveedorCuentacobrarsaldofavor(obj)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub FrmCuentaPagarSelecionar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        If operacion = 1 Then
            Consultarabono()
        Else
            Consultar()
        End If
    End Sub
    Sub Seleccionar()
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    codcuenta = dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString
                    serie = dtgListado.DisplayLayout.ActiveRow.Cells(3).Value.ToString
                    correlativo = dtgListado.DisplayLayout.ActiveRow.Cells(4).Value.ToString
                    Dim serv As String = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
                    deudapendiente = dtgListado.DisplayLayout.ActiveRow.Cells(10).Value.ToString
                    tiposervicio = serv + "  N° " + serie + "  -  " + correlativo
                    Dispose()
                Else
                    ' msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                ' msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles dtgListado.ClickCell
        If operacion = 1 Then
        Else
            Seleccionar()
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "Código"
                .Columns(0).Width = 100
                .Columns(1).Width = 100
                .Columns(2).Width = 300
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub

    Private Sub dtgListado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgListado.KeyDown
        If e.KeyData = Keys.Enter Then
            Seleccionar()
        End If

    End Sub


End Class