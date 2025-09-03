Imports CapaNegocio

Public Class FrmListarAlimentoCerdos
    Private ReadOnly _frmNuevoAlimento As FrmNuevoAlimento
    Public idPlantel As Integer = 0
    Dim cn As New cnControlAlimento

    Public Sub New(frmNuevoAlimento As FrmNuevoAlimento)
        InitializeComponent()
        _frmNuevoAlimento = frmNuevoAlimento
    End Sub

    Private Sub FrmListarAlimentoCerdos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ListarAlimentoCerdo()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarAlimentoCerdo()
        Dim dt As DataTable = cn.Cn_ListarAlimentoCerdoActivo(idPlantel)
        dtgListado.DataSource = dt
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub


    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim codigo As Integer = e.Cell.Row.Cells(0).Value
                    Dim descripcion As String = e.Cell.Row.Cells(1).Value
                    Dim unidadMedida As String = e.Cell.Row.Cells(2).Value
                    Dim stock As String = e.Cell.Row.Cells(3).Value

                    Dim stockDecimal As Double
                    If Double.TryParse(stock, stockDecimal) Then
                        If stockDecimal <= 0 Then
                            msj_advert("No se puede seleccionar porque no hay stock disponible.")
                            Return
                        End If
                    Else
                        msj_advert("El valor del stock no es válido.")
                        Return
                    End If

                    _frmNuevoAlimento.LlenarCamposAlimento(codigo, descripcion, unidadMedida, stock)
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

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class