Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMotivosRegularizacionReproduccion
    Dim cn As New cnTipoIncidencia
    Private ReadOnly _frmRegularizarCerdosReproduccion As FrmRegularizarCerdosReproduccion

    Public Sub New(frmRegularizarCerdosReproduccion As FrmRegularizarCerdosReproduccion)
        InitializeComponent()
        _frmRegularizarCerdosReproduccion = frmRegularizarCerdosReproduccion
    End Sub

    Private Sub FrmMotivosRegularizacionReproduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarMotivoMortalidad()
    End Sub

    Sub ListarMotivoMortalidad()
        Try
            Dim obj As New coTipoIncidencia With {
                .Tipo = "REGULARIZACIÓN"
            }
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            dtgListado.DataSource = cn.Cn_ConsultarTipo(obj)
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
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

                    _frmRegularizarCerdosReproduccion.LlenarCampoMotivoMortalidad(codigo, descripcion)
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