Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarAnimalesCodificadosRegu
    Dim cn As New cnControlAnimal
    Dim tbtmp As New DataTable
    Public idPlantel As Integer

    Private ReadOnly _frmRegularizarSalidaConArete As FrmRegularizarSalidaConArete

    Public Sub New(frmRegularizarSalidaConArete As FrmRegularizarSalidaConArete)
        InitializeComponent()
        _frmRegularizarSalidaConArete = frmRegularizarSalidaConArete
    End Sub

    Private Sub FrmListarAnimalesCodificadosRegu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        TxtSexo.SelectedIndex = 0
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        ToolStrip1.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlAnimal With {
                .Sexo = TxtSexo.Text,
                .IdPlantel = idPlantel
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            tbtmp = cn.Cn_ConsultarAnimalCodificadosRegularizacion(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DesbloquearControladores()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            dtgListado.DisplayLayout.Bands(0).Columns("idAnimal").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("idLote").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("idJaulaCorral").Hidden = True
        End If
    End Sub

    Private Sub TxtSexo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TxtSexo.SelectedIndexChanged
        Consultar()
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim codigo As Integer = e.Cell.Row.Cells(0).Value
                    Dim arete As String = e.Cell.Row.Cells(1).Value
                    Dim idLote As String = e.Cell.Row.Cells(6).Value
                    Dim idJaulaCorral As String = e.Cell.Row.Cells(7).Value

                    _frmRegularizarSalidaConArete.LlenarCampoMotivoAnimal(codigo, idLote, arete, idJaulaCorral)
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