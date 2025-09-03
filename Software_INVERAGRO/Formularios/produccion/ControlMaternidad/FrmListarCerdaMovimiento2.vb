Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarCerdaMovimiento2
    Dim cn As New cnControlAnimal
    Private ReadOnly _frmRegistrarMovimientoLechon As FrmRegistrarMovimientoLechon
    Public idPlantel As Integer = 0
    Public codAreteCerda1 As String = ""
    Public idLote As Integer = 0

    Public Sub New(frmRegistrarMovimientoLechon As FrmRegistrarMovimientoLechon)
        InitializeComponent()
        _frmRegistrarMovimientoLechon = frmRegistrarMovimientoLechon
    End Sub

    Private Sub FrmListarCerdaMovimiento2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                    Dim idAnimal As Integer = dtgListado.ActiveRow.Cells(0).Value
                    Dim codigo As String = dtgListado.ActiveRow.Cells(1).Value
                    Dim numCrias As Integer = dtgListado.ActiveRow.Cells(3).Value
                    Dim idLoteAnimal As Integer = dtgListado.ActiveRow.Cells(4).Value

                    If codAreteCerda1 = codigo Then
                        msj_advert("Selecciones una cerda distinta a la seleccionada")
                        Return
                    End If

                    If idLoteAnimal <> idLote Then
                        If (MessageBox.Show("¿ESTE ANIMAL SE ENCUENTRA EN OTRO LOTE ESTA SEGURO DE REALIZAR EL MOVIMIENTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                            Return
                        End If
                    End If

                    _frmRegistrarMovimientoLechon.LlenarCamposCerda2(idAnimal, codigo, numCrias, idLoteAnimal)
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