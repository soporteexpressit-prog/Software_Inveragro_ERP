Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Documents.Excel.Filtering
Imports Infragistics.Win

Public Class FrmListarMotivoMortalidadLote
    Dim cn As New cnTipoIncidencia
    Private ReadOnly _frmRegistrarMortalidadLote As FrmRegistrarMandarCamalMortalidadLote
    Public tipoRegistro As String = ""
    Public ambiente As String = ""

    Public Sub New(frmRegistrarMortalidadCerdosLote As FrmRegistrarMandarCamalMortalidadLote)
        InitializeComponent()
        _frmRegistrarMortalidadLote = frmRegistrarMortalidadCerdosLote
    End Sub

    Private Sub FrmListarMotivoMortalidadLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarMotivoMortalidad()
    End Sub

    Sub ListarMotivoMortalidad()
        Try
            Dim obj As New coTipoIncidencia With {
                .Tipo = tipoRegistro,
                .Ambiente = ambiente
            }
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            dtgListado.DataSource = cn.Cn_ConsultarTipoAmbiente(obj)
            dtgListado.DisplayLayout.Bands(0).Columns("idTipoIncidencia").Hidden = True
            If ambiente <> "RECRÍA" Or tipoRegistro = "MORTALIDAD" Then
                dtgListado.DisplayLayout.Bands(0).Columns("Tipo").Hidden = True
            Else
                dtgListado.DisplayLayout.Bands(0).Columns("Tipo").Width = 50
            End If
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

                    _frmRegistrarMortalidadLote.LlenarCampoMotivoMortalidad(codigo, descripcion)
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

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
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