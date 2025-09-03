Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarLotesParto
    Dim cn As New cnControlLoteDestete
    Public idUbicacion As Integer = 0
    Private ReadOnly _frmRegParto As FrmRegParto

    Public Sub New(frmRegParto As FrmRegParto)
        InitializeComponent()
        _frmRegParto = frmRegParto
    End Sub

    Private Sub FrmListarLoteParto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ListarLotesRecientes()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarLotesRecientes()
        Dim obj As New coControlLoteDestete With {
            .IdPlantel = idUbicacion
        }
        dtgListado.DataSource = cn.Cn_ConsultarLotesUltimos(obj)
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
                    Dim idLote As String = e.Cell.Row.Cells(0).Value.ToString()
                    Dim descripcion As String = e.Cell.Row.Cells(1).Value.ToString()

                    _frmRegParto.LlenarLoteParto(idLote, descripcion)
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