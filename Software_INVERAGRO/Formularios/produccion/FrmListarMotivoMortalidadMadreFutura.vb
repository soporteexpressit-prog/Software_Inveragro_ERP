Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmListarMotivoMortalidadMadreFutura
    Dim cn As New cnTipoIncidencia
    Private ReadOnly _frmMandarCamalMortalidadMadreFutura As FrmMandarCamalMortalidadMadreFutura
    Public tipoRegistro As String = ""

    Public Sub New(frmMandarCamalMortalidadMadreFutura As FrmMandarCamalMortalidadMadreFutura)
        InitializeComponent()
        _frmMandarCamalMortalidadMadreFutura = frmMandarCamalMortalidadMadreFutura
    End Sub

    Private Sub FrmListarMotivoMortalidadMadreFutura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarMotivoMortalidad()
    End Sub

    Sub ListarMotivoMortalidad()
        Try
            Dim obj As New coTipoIncidencia With {
                .Tipo = tipoRegistro,
                .Ambiente = "GESTACIÓN"
            }
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            If tipoRegistro = "MORTALIDAD" Then
                dtgListado.DataSource = cn.Cn_ConsultarTipoAmbiente(obj)
                dtgListado.DisplayLayout.Bands(0).Columns(2).Hidden = True
            Else
                dtgListado.DataSource = cn.Cn_ConsultarMotivoGeneral()
                Colorear()
            End If
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
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

                    _frmMandarCamalMortalidadMadreFutura.LlenarCampoMotivoMortalidad(codigo, descripcion)
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