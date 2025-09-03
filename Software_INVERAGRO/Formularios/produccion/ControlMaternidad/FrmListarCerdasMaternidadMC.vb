Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarCerdasMaternidadMC
    Dim cn As New cnControlAnimal
    Private ReadOnly _frmMonitoreoCondicionCorporal As FrmMonitoreoCondicionCorporal
    Public idPlantel As Integer = 0
    Public tipo As String = ""

    Public Sub New(frmMonitoreoCondicionCorporal As FrmMonitoreoCondicionCorporal)
        InitializeComponent()
        _frmMonitoreoCondicionCorporal = frmMonitoreoCondicionCorporal
    End Sub

    Private Sub FrmListarCerdasMaternidadMC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Dim obj As New coControlAnimal With {
                .IdPlantel = idPlantel,
                .TipoControl = tipo
            }
            dtgListado.DataSource = cn.Cn_ListarCerdasMaternidadGestacion(obj)
            dtgListado.DisplayLayout.Bands(0).Columns("idAnimal").Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim idAnimal As Integer = dtgListado.ActiveRow.Cells("idAnimal").Value
                    Dim codigo As String = dtgListado.ActiveRow.Cells("Arete").Value
                    Dim diasEtapa As Integer = dtgListado.ActiveRow.Cells("Días en Etapa").Value
                    Dim condCorporal As Decimal = dtgListado.ActiveRow.Cells("Cond. Corporal").Value

                    _frmMonitoreoCondicionCorporal.LlenarCamposCerda(idAnimal, codigo, diasEtapa, condCorporal)
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