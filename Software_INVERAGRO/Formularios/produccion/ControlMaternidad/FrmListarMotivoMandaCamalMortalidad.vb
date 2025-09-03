Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmListarMotivoMandaCamalMortalidad
    Dim cn As New cnTipoIncidencia
    Private ReadOnly _frmMortalidadCriaCerda As FrmMandarCamalMortalidadCriaCerda
    Public tipo As String = ""
    Public ambiente As String = ""

    Public Sub New(frmMortalidadCriaCerda As FrmMandarCamalMortalidadCriaCerda)
        InitializeComponent()
        _frmMortalidadCriaCerda = frmMortalidadCriaCerda
    End Sub

    Private Sub FrmListarMotivoMandaCamal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarMotivoMortalidad()
    End Sub

    Sub ListarMotivoMortalidad()
        Try
            Dim obj As New coTipoIncidencia With {
                .Tipo = tipo,
                .Ambiente = ambiente
            }
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            dtgListado.DataSource = cn.Cn_ConsultarTipoAmbiente(obj)
            dtgListado.DisplayLayout.Bands(0).Columns("idTipoIncidencia").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Tipo").Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim codigo As Integer = e.Cell.Row.Cells("idTipoIncidencia").Value
                    Dim descripcion As String = e.Cell.Row.Cells("Descripción").Value

                    _frmMortalidadCriaCerda.LlenarCampoMotivoMortalidad(codigo, descripcion)
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