Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmDetalleMotivoFrecuenteDescuidoPersonal
    Dim cn As New cnControlAnimal
    Dim tbtmp As New DataTable
    Public fDesde As Date
    Public fHasta As Date
    Public idUbicacion As Integer = 0
    Public tipo As String = ""
    Public idLote As Integer = 0

    Private Sub FrmDetalleMotivoFrecuenteDescuidoPersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(DtgListado)
            Ptbx_Cargando.Visible = True
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True

            Dim obj As New coControlAnimal With {
                .FechaDesde = fDesde,
                .FechaHasta = fHasta,
                .IdPlantel = idUbicacion,
                .TipoControl = tipo,
                .IdLote = idLote
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            tbtmp = cn.Cn_ConsultarIncidenciaTrabajador(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            DtgListado.DataSource = CType(e.Result, DataTable)
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListado.InitializeLayout
        Try
            If (DtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(DtgListado, e, 0)
                clsBasicas.SumarTotales_Formato(DtgListado, e, If(tipo = "INCIDENCIA", 1, 2))
                clsBasicas.SumarTotales_Formato(DtgListado, e, If(tipo = "INCIDENCIA", 2, 3))
                clsBasicas.SumarTotales_Formato(DtgListado, e, If(tipo = "INCIDENCIA", 3, 4))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            If (DtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONSOLIDAD DE MORTALIDAD X PERIODO", DtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class