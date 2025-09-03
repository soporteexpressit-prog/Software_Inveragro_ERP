Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmListaEncargadoMortalidadCrias
    Dim cn As New cnTrabajador
    Private ReadOnly _frmMandarCamalMortalidadCriaCerda As FrmMandarCamalMortalidadCriaCerda

    Public Sub New(frmMandarCamalMortalidadCriaCerda As FrmMandarCamalMortalidadCriaCerda)
        InitializeComponent()
        _frmMandarCamalMortalidadCriaCerda = frmMandarCamalMortalidadCriaCerda
    End Sub

    Private Sub FrmListaEncargadoMortalidadCrias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarTrabajadoresActivos()
    End Sub

    Sub ListarTrabajadoresActivos()
        Try
            Dim obj As New coTrabajador With {
                .Tipo = "MATERNERO"
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
                    Dim codigo As String = e.Cell.Row.Cells(0).Value.ToString()
                    Dim numDocumento As String = e.Cell.Row.Cells(1).Value.ToString()
                    Dim datos As String = e.Cell.Row.Cells(2).Value.ToString()

                    _frmMandarCamalMortalidadCriaCerda.LlenarCamposResponsableMortalidad(codigo, datos)
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
                clsBasicas.Totales_Formato(dtgListado, e, 2)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class