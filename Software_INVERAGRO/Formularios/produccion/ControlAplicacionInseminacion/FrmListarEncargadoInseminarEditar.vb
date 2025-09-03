Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarEncargadoInseminarEditar
    Dim cn As New cnTrabajador
    Private ReadOnly _frmEditarInseminacion As FrmEditarInseminacion

    Public Sub New(frmEditarInseminacion As FrmEditarInseminacion)
        InitializeComponent()
        _frmEditarInseminacion = frmEditarInseminacion
    End Sub

    Private Sub FrmListarEncargadoInseminarEditar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarTrabajadoresActivos()
    End Sub

    Sub ListarTrabajadoresActivos()
        Try
            Dim obj As New coTrabajador With {
                .Tipo = "INSEMINADOR"
            }
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            dtgListado.DataSource = cn.Cn_ConsultarPersonalProduccionFiltrado(obj)
            dtgListado.DisplayLayout.Bands(0).Columns("idPersona").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("DNI").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("Cargo").Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.Rows.Count = 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If
        If e.Cell Is Nothing OrElse e.Cell.Row Is Nothing Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If

        If e.Cell.Row.Index < 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If

        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    _frmEditarInseminacion.LlenarCamposInseminador(
                     e.Cell.Row.Cells(0).Value.ToString(),
                    e.Cell.Row.Cells(1).Value.ToString(),
                     e.Cell.Row.Cells(2).Value.ToString()
                    )
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