Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmHistorialMortalidadLechon
    Dim cn As New cnControlAnimal
    Dim ds As New DataSet
    Public idUbicacion As Integer = 0
    Private search As Boolean = False

    Private Sub FrmHistorialMortalidadLechon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarLotes()
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        Ptbx_Cargando.Visible = True
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        DtpFechaDesde.Value = DateAdd(DateInterval.Day, -7, Now.Date)
        DtpFechaHasta.Value = Now.Date
        LblPromedioMuertoEvento.Text = "(X" & ChrW(&H305) & ") Muertes x Evento:"
        RtnPeriodo.Checked = True
        RtnLotes.Checked = False
    End Sub

    Sub ListarLotes()
        Dim cn As New cnControlLoteDestete
        Dim obj As New coControlLoteDestete With {
           .Anio = CmbAnios.Text,
           .IdPlantel = idUbicacion
        }
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarLotesAnioCombo(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbLotes
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
        search = True
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        DtpFechaDesde.Enabled = False
        DtpFechaHasta.Enabled = False
        BtnBuscarPerdidaReproductiva.Enabled = False
        BtnMotivoFrecuencia.Enabled = False
        BtnDescuidoPersonal.Enabled = False
        ToolStrip1.Enabled = False
        RtnPeriodo.Enabled = False
        RtnLotes.Enabled = False
        CmbAnios.Enabled = False
        CmbLotes.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        DtpFechaDesde.Enabled = True
        DtpFechaHasta.Enabled = True
        BtnBuscarPerdidaReproductiva.Enabled = True
        BtnMotivoFrecuencia.Enabled = True
        BtnDescuidoPersonal.Enabled = True
        ToolStrip1.Enabled = True
        RtnPeriodo.Enabled = True
        RtnLotes.Enabled = True
        CmbAnios.Enabled = True
        CmbLotes.Enabled = True
    End Sub

    Private Sub CmbAnios_TextChanged(sender As Object, e As EventArgs) Handles CmbAnios.TextChanged
        If (search) Then
            ListarLotes()
        End If
    End Sub

    Sub Consultar()
        If DtpFechaDesde.Value > DtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        BloquearControladores()
        If Not BackgroundWorker1.IsBusy Then

            Dim obj As New coControlAnimal With {
                .FechaDesde = DtpFechaDesde.Value,
                .FechaHasta = DtpFechaHasta.Value,
                .IdPlantel = idUbicacion,
                .IdLote = If(RtnLotes.Checked, CmbLotes.Value, 0)
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            ds = cn.Cn_ConsultarMortalidadCriasMaternidad(obj).Copy
            ds.Tables(0).TableName = "tmp"
            ds.Tables(1).TableName = "indicadores"
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            Dim ds As DataSet = CType(e.Result, DataSet)
            dtgListado.DataSource = ds.Tables("tmp")

            If ds.Tables("indicadores").Rows.Count > 0 Then
                Dim fila As DataRow = ds.Tables("indicadores").Rows(0)
                LblPorcMortalidad.Text = fila("%Mortalidad").ToString()
                LblNacVivos.Text = fila("NacidosVivos").ToString()
                LblPromxEvento.Text = fila("PromedioMuertesEvento").ToString()
                LblPorcMortalidadxDescuido.Text = fila("%MortalidadNegligencia").ToString()
                LblLoteMasAfectado.Text = fila("LoteMasAfectado").ToString()
                LblMotivoMasFrecuente.Text = fila("MotivoMasFrecuente").ToString()
                LblTasaMortalidadxDia.Text = fila("TasaMortalidadDia").ToString()
            End If
            DesbloquearControladores()
        End If
    End Sub

    Private Sub BtnBuscarPerdidaReproductiva_Click(sender As Object, e As EventArgs) Handles BtnBuscarPerdidaReproductiva.Click
        Consultar()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 0)
                clsBasicas.SumarTotales_Formato(dtgListado, e, 3)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("HISTORIAL DE MORTALIDAD", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnMotivoFrecuencia_Click(sender As Object, e As EventArgs) Handles BtnMotivoFrecuencia.Click
        Try
            Dim frm As New FrmDetalleMotivoFrecuenteDescuidoPersonal With {
                .fDesde = DtpFechaDesde.Value,
                .fHasta = DtpFechaHasta.Value,
                .idUbicacion = idUbicacion,
                .tipo = "INCIDENCIA",
                .idLote = If(RtnLotes.Checked, CmbLotes.Value, 0)
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnDescuidoPersonal_Click(sender As Object, e As EventArgs) Handles BtnDescuidoPersonal.Click
        Try
            Dim frm As New FrmDetalleMotivoFrecuenteDescuidoPersonal With {
                .fDesde = DtpFechaDesde.Value,
                .fHasta = DtpFechaHasta.Value,
                .idUbicacion = idUbicacion,
                .tipo = "DESCUIDO",
                .idLote = If(RtnLotes.Checked, CmbLotes.Value, 0)
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub RtnPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles RtnPeriodo.CheckedChanged
        If RtnPeriodo.Checked Then
            DtpFechaDesde.Enabled = True
            LblFechaDesde.Visible = True
            DtpFechaDesde.Visible = True
            DtpFechaHasta.Enabled = True
            LblFechaHasta.Visible = True
            DtpFechaHasta.Visible = True
            LblAnio.Visible = False
            CmbAnios.Visible = False
            LblLotes.Visible = False
            CmbLotes.Visible = False
        Else
            DtpFechaDesde.Enabled = False
            LblFechaDesde.Visible = False
            DtpFechaDesde.Visible = False
            DtpFechaHasta.Enabled = False
            LblFechaHasta.Visible = False
            DtpFechaHasta.Visible = False
            LblAnio.Visible = True
            CmbAnios.Visible = True
            LblLotes.Visible = True
            CmbLotes.Visible = True
        End If
        Consultar()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class