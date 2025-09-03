Imports CapaNegocio
Imports CapaObjetos

Public Class FrmHistorialPerdidaReproductiva
    Dim cn As New cnControlGestacion
    Dim tbtmp As New DataTable
    Public idUbicacion As Integer = 0

    Private Sub FrmHistorialPerdidaReproductiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        Ptbx_Cargando.Visible = True
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        DtpFechaDesde.Value = DateAdd(DateInterval.Day, -7, Now.Date)
        DtpFechaHasta.Value = Now.Date
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            Dim obj As New coControlGestacion With {
                .FechaDesde = DtpFechaDesde.Value,
                .FechaHasta = DtpFechaHasta.Value,
                .IdPlantel = idUbicacion
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlGestacion = CType(e.Argument, coControlGestacion)
            tbtmp = cn.Cn_ConsultarPerdidaReproductiva(obj).Copy
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
            dtgListado.DataSource = CType(e.Result, DataTable)
            ToolStrip1.Enabled = True
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        End If
    End Sub

    Private Sub BtnBuscarPerdidaReproductiva_Click(sender As Object, e As EventArgs) Handles BtnBuscarPerdidaReproductiva.Click
        If DtpFechaDesde.Value > DtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        Consultar()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class