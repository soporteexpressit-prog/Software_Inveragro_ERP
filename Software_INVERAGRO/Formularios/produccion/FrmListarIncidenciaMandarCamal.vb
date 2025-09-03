Imports CapaNegocio
Imports Infragistics.Win

Public Class FrmListarIncidenciaMandarCamal
    Dim cn As New cnTipoIncidencia
    Private ReadOnly _frmMandarCamalAnimal As FrmMandarCamalAnimal

    Public Sub New(frmMandarCamalAnimal As FrmMandarCamalAnimal)
        InitializeComponent()
        _frmMandarCamalAnimal = frmMandarCamalAnimal
    End Sub

    Private Sub FrmListarIncidenciaMandarCamal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            dtgListado.DataSource = cn.Cn_ConsultarMotivoGeneral()
            dtgListado.DisplayLayout.Bands(0).Columns("idTipoIncidencia").Hidden = True
            Colorear()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim tipo As Integer = 2

            'tipo
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "INCIDENCIA", tipo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "EMERGENCIA", tipo)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(tipo).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim codigo As Integer = e.Cell.Row.Cells(0).Value
                    Dim descripcion As String = e.Cell.Row.Cells(1).Value
                    Dim tipo As String = e.Cell.Row.Cells(2).Value

                    _frmMandarCamalAnimal.LlenarCampoMotivoMortalidad(codigo, descripcion, tipo)
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