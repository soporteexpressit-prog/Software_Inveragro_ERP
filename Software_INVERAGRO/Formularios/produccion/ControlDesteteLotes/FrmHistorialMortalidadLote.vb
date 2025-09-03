Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmHistorialMortalidadLote
    Dim cn As New cnControlLoteDestete
    Dim tbtmp As New DataTable
    Dim ds As New DataSet
    Public idLote As Integer = 0
    Public idPlantel As Integer = 0
    Dim search As Boolean = True

    Public Sub FrmHistorialMortalidadLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        DtpFechaDesde.Enabled = False
        DtpFechaHasta.Enabled = False
        BtnBuscarHistorialMortalidadLote.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        DtpFechaDesde.Enabled = True
        DtpFechaHasta.Enabled = True
        BtnBuscarHistorialMortalidadLote.Enabled = True
        ToolStrip1.Enabled = True
    End Sub

    Sub Consultar()
        If DtpFechaDesde.Value > DtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            If search Then
                Dim intervalo = ObtenerIntervaloSemana(Now.Date)
                DtpFechaDesde.Value = intervalo.Item1
                DtpFechaHasta.Value = intervalo.Item2
            End If

            Dim obj As New coControlLoteDestete With {
                .FechaDesde = DtpFechaDesde.Value,
                .FechaHasta = DtpFechaHasta.Value,
                .IdLote = idLote,
                .IdPlantel = idPlantel
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Public Function ObtenerIntervaloSemana(ByVal fecha As Date) As Tuple(Of Date, Date)
        Dim primerDiaSemana As Date = fecha.AddDays(-(fecha.DayOfWeek))
        Dim ultimoDiaSemana As Date = primerDiaSemana.AddDays(6)

        Return New Tuple(Of Date, Date)(primerDiaSemana, ultimoDiaSemana)
    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            ds = cn.Cn_ConsultarCriasMortalidadLote(obj).Copy
            ds.DataSetName = "tmp"
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataSet)
            DesbloquearControladores()
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        End If
    End Sub

    Private Sub BtnBuscarPerdidaReproductiva_Click(sender As Object, e As EventArgs) Handles BtnBuscarHistorialMortalidadLote.Click
        search = False
        Consultar()
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub BtnEliminarEvento_Click(sender As Object, e As EventArgs) Handles BtnEliminarEvento.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If (MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE EVENTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    Dim obj As New coControlLoteDestete With {
                        .IdControlFichaMortalidad = activeRow.Cells(0).Value
                    }

                    Dim mensaje As String = cn.Cn_EliminarEventoMortalidadLote(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(mensaje)
                        Consultar()
                    Else
                        msj_advert(mensaje)
                    End If
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
                clsBasicas.Totales_Formato(dtgListado, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class