Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarMotivoDescarteMadreFutura
    Dim cn As New cnTipoIncidencia
    Private ReadOnly _frmPrimerFiltroCerda As FrmPrimerFiltroCerda

    Public Sub New(frmPrimerFiltroCerda As FrmPrimerFiltroCerda)
        InitializeComponent()
        _frmPrimerFiltroCerda = frmPrimerFiltroCerda
    End Sub

    Private Sub FrmListarMotivoDescarteMadreFutrura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarMotivoMortalidad()
    End Sub

    Sub ListarMotivoMortalidad()
        Try
            Dim obj As New coTipoIncidencia With {
                .Tipo = "INCIDENCIA",
                .Ambiente = "ENGORDE"
            }
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            dtgListado.DataSource = cn.Cn_ConsultarTipoAmbiente(obj)
            dtgListado.DisplayLayout.Bands(0).Columns("idTipoIncidencia").Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim codigo As Integer = e.Cell.Row.Cells(0).Value
                    Dim descripcion As String = e.Cell.Row.Cells(1).Value

                    _frmPrimerFiltroCerda.LlenarCampoMotivo(codigo, descripcion)
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