Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListaRacionesExcedente
    Dim cn As New cnNucleo
    Dim idUbicacion As Integer = 6

    Private ReadOnly _frmRegistrarExcedentexRacion As FrmRegistrarExcedentexRacion

    Public Sub New(frmRegistrarExcedentexRacion As FrmRegistrarExcedentexRacion)
        InitializeComponent()
        _frmRegistrarExcedentexRacion = frmRegistrarExcedentexRacion
    End Sub

    Private Sub FrmListaRacionesExcedente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarRaciones()
    End Sub

    Private Sub ListarRaciones()
        Try
            Dim obj As New coNucleo With {
                .IdUbicacion = idUbicacion
            }
            DtgListado.DataSource = cn.Cn_ConsultarRaciones(obj)
            DtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            DtgListado.DisplayLayout.Bands(0).Columns(2).Hidden = True
            clsBasicas.Formato_Tablas_Grid(DtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles DtgListado.DoubleClickCell
        If DtgListado.Rows.Count = 0 Then
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
            If (DtgListado.Rows.Count > 0) Then
                If (DtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim codigo As String = e.Cell.Row.Cells(0).Value.ToString()
                    Dim nombre As String = e.Cell.Row.Cells(1).Value.ToString()

                    _frmRegistrarExcedentexRacion.LlenarCamposRacion(codigo, nombre)
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

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListado.InitializeLayout
        Try
            If (DtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(DtgListado, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class