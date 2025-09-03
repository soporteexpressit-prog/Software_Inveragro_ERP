Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmHistoricoParaDescarte
    Dim cn As New cnControlLoteDestete
    Dim tbtmp As New DataTable
    Private idLote As Integer = 0
    Private search As Boolean = False
    Public idPlantel As Integer = 0

    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1300, 800)
    End Sub

    Private Sub FrmHistoricoParaDescarte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarLotes()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.Formato_Tablas_Grid(DtgListado)
    End Sub

    Private Sub CmbAnios_TextChanged(sender As Object, e As EventArgs) Handles CmbAnios.TextChanged
        If (search) Then
            ListarLotes()
        End If
    End Sub

    Sub ListarLotes()
        Dim cn As New cnControlLoteDestete
        Dim obj As New coControlLoteDestete With {
           .Anio = CmbAnios.Text,
           .IdPlantel = idPlantel
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
        CmbAnios.Enabled = False
        CmbLotes.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        CmbAnios.Enabled = True
        CmbLotes.Enabled = True
        ToolStrip1.Enabled = True
    End Sub

    Private Sub CmbLotes_ValueChanged(sender As Object, e As EventArgs) Handles CmbLotes.ValueChanged
        Consultar()
    End Sub

    Sub Consultar()
        DtgListado.DataSource = Nothing
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlLoteDestete With {
               .IdLote = CmbLotes.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_HistorialDescarte(obj).Copy
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
            DtgListado.DataSource = CType(e.Result, DataTable)
            PintarFilasHembrasPosibleDescarte()
        End If
    End Sub

    Private Sub PintarFilasHembrasPosibleDescarte()
        If DtgListado.DisplayLayout.Bands(0).Columns.Exists("Mensaje") Then
            Exit Sub
        End If

        Dim colorDescartable As Color = Color.FromArgb(255, 220, 220)
        Dim contadorDescartables As Integer = 0

        For Each fila As UltraGridRow In DtgListado.Rows
            Dim valorCelda As Object = fila.Cells("Promedio Crías/Parto").Value

            If valorCelda IsNot Nothing AndAlso IsNumeric(valorCelda) Then
                Dim criasPromedio As Decimal = Convert.ToDecimal(valorCelda)

                If criasPromedio < 10D Then
                    fila.Appearance.BackColor = colorDescartable
                    contadorDescartables += 1
                End If
            End If
        Next

        LblPosiblesEnviosCamal.Text = contadorDescartables.ToString()
    End Sub


    Private Sub DtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListado.InitializeLayout
        Try
            If DtgListado.DisplayLayout.Bands(0).Columns.Exists("Mensaje") Then
                Exit Sub
            End If

            If (DtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(DtgListado, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportarLoteParto_Click(sender As Object, e As EventArgs) Handles BtnExportarLoteParto.Click
        Try
            If (DtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("HISTORIAL PARA DESCARTE", DtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class