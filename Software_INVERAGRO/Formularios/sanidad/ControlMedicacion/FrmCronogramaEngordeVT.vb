Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmCronogramaEngordeVT
    Dim cn As New cnControlMedico
    Dim tbtmp As New DataTable
    Public idUbicacion As Integer = 0

    Private Sub FrmCronogramaEngordeVT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarCampañas()
            ListarLotes()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        clsBasicas.LlenarComboAnios(CmbAnios)
        Ptbx_Cargando.Visible = True
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Sub ListarCampañas()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        Dim obj As New coUbicacion With {
            .Codigo = idUbicacion,
            .Anio = CmbAnios.Text
        }
        tb = cn.Cn_ListarCampañas(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbCampaña
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarLotes()
        Dim tb As New DataTable
        Dim obj As New coControlMedico With {
            .Codigo = CmbCampaña.Value
        }
        tb = cn.Cn_ConsultarLotesSanidad(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbLote
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub CmbCampaña_TextChanged(sender As Object, e As EventArgs) Handles CmbCampaña.TextChanged
        If CmbLote Is Nothing OrElse CmbLote.Value Is Nothing OrElse String.IsNullOrEmpty(CmbLote.Text) Then
            Return
        End If
        ListarLotes()
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        GrupoFiltros.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        GrupoFiltros.Enabled = True
        ToolStrip1.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlMedico With {
                .IdLote = CmbLote.Value,
                .Codigo = CmbCampaña.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlMedico = CType(e.Argument, coControlMedico)
            tbtmp = cn.Cn_ConsultarCumplimientoVacunacion(obj).Copy
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
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim observacionTiempo As Integer = 6
            Dim estado As Integer = 7

            'observacionTiempo
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "-", observacionTiempo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightBlue, Color.DarkBlue, "TEMPRANO", observacionTiempo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "EN TIEMPO", observacionTiempo)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "TARDÍO", observacionTiempo)

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "-", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "CUMPLIDO", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(observacionTiempo).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class