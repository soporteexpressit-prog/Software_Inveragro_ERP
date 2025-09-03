Imports CapaNegocio

Public Class FrmListarTemario
    Dim cn As New cnTemarioCapacitacion
    Private ReadOnly _frmRegCapacitacion As FrmRegistrarCapacitacion

    Public Sub New(frmRegCapacitacion As FrmRegistrarCapacitacion)
        InitializeComponent()
        _frmRegCapacitacion = frmRegCapacitacion
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub FrmListarTemario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarTemariosActivos()
    End Sub
    Sub ListarTemariosActivos()
        dtgListado.DataSource = cn.Cn_Listar()
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
    End Sub
    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
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
                        Dim codigo As String = e.Cell.Row.Cells("Código").Value.ToString()
                        Dim descripcion As String = e.Cell.Row.Cells("Descripción").Value.ToString()
                        Dim area As String = e.Cell.Row.Cells("Área Capacitadora").Value.ToString()

                        _frmRegCapacitacion.LlenarCamposTemario(codigo, descripcion, area)
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
        Catch ex As Exception
            clsBasicas.controlException("", ex)
        End Try
    End Sub
End Class