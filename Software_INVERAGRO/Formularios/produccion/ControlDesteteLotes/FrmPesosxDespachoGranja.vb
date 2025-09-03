Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmPesosxDespachoGranja
    Dim cn As New cnControlLoteDestete
    Dim tbtmp As New DataTable
    Public idSalida As Integer = 0

    Private Sub FrmPesosxDespachoGranja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        Ptbx_Cargando.Visible = True
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Filtrar_Tabla(dtgListado, True)
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Dim obj As New coControlLoteDestete With {
                .IdSalida = idSalida
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ReportePesosxDespacho(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            Ptbx_Cargando.Visible = False
            dtgListado.DataSource = CType(e.Result, DataTable)
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.SumarTotales_Formato(dtgListado, e, 0)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class