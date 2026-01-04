Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarCerdaMovimiento1
    Dim cn As New cnControlAnimal
    Private ReadOnly _frmRegistrarMovimientoLechon As FrmRegistrarMovimientoLechon
    Public idPlantel As Integer = 0
    Public idCerda2 As Integer = 0
    Public idLote As Integer = 0

    Public Sub New(frmRegistrarMovimientoLechon As FrmRegistrarMovimientoLechon)
        InitializeComponent()
        _frmRegistrarMovimientoLechon = frmRegistrarMovimientoLechon
    End Sub

    Private Sub FrmListarCerdaMovimiento1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Dim obj As New coControlAnimal With {
                .idPlantel = idPlantel
            }
            dtgListado.DataSource = cn.Cn_ListarCerdaMovimientoMaternidad(obj)
            dtgListado.DisplayLayout.Bands(0).Columns("idAnimal").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("idLote").Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim idAnimal As Integer = dtgListado.ActiveRow.Cells("idAnimal").Value
                    Dim codigo As String = dtgListado.ActiveRow.Cells("Código").Value
                    Dim numCrias As Integer = dtgListado.ActiveRow.Cells("Número de Crías").Value
                    Dim idLoteAnimal As Integer = dtgListado.ActiveRow.Cells("idLote").Value

                    If idCerda2 <> 0 Then
                        If idCerda2 = idAnimal Then
                            msj_advert("SELECCIONE UNA CERDA DISTINTA A LA SEGUNDA")
                            Return
                        End If
                    End If

                    If idLote <> 0 Then
                        If idLoteAnimal <> idLote Then
                            msj_advert("LA CERDA DEBE PERTENECER AL MISMO LOTE QUE LA SEGUNDA CERDA SELECCIONADA")
                            Return
                        End If
                    End If

                    _frmRegistrarMovimientoLechon.LlenarCamposCerda1(idAnimal, codigo, numCrias, idLoteAnimal)
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