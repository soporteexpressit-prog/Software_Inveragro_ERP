Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarCerdaDonadora
    Dim cn As New cnControlAnimal
    Private ReadOnly _frmRegistrarNodriza As FrmRegistrarNodriza
    Public idPlantel As Integer = 0
    Public idCodAreteNodriza As String = ""

    Public Sub New(frmRegistrarNodriza As FrmRegistrarNodriza)
        InitializeComponent()
        _frmRegistrarNodriza = frmRegistrarNodriza
    End Sub

    Private Sub FrmListarCerdaDonadora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Dim obj As New coControlAnimal With {
                .IdPlantel = idPlantel
            }
            dtgListado.DataSource = cn.Cn_ListarCerdasDonantes(obj)
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
                    Dim idLote As Integer = dtgListado.ActiveRow.Cells("idLote").Value
                    Dim valorLote As String = dtgListado.ActiveRow.Cells("Lote").Value

                    If codigo = idCodAreteNodriza Then
                        msj_advert("La cerda donadora no puede ser la misma que la nodriza")
                        Return
                    End If

                    _frmRegistrarNodriza.LlenarCamposCerdaDonadora(idAnimal, codigo, idLote, valorLote)
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