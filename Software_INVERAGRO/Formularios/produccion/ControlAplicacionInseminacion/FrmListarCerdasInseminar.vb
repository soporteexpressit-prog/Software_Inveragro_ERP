Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmListarCerdasInseminar
    Dim cn As New cnControlAnimal
    Dim tbtmp As New DataTable
    Public idUbicacion As Integer = 0
    Private ReadOnly _frmRegistrarInseminacion As FrmRegistrarInseminacion

    Public Sub New(frmRegistrarInseminacion As FrmRegistrarInseminacion)
        InitializeComponent()
        _frmRegistrarInseminacion = frmRegistrarInseminacion
    End Sub

    Private Sub FrmListarCerdasInseminar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(DtgListadoCerda, True)
            clsBasicas.Formato_Tablas_Grid(DtgListadoCerda)
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            Dim obj As New coControlAnimal With {
                .IdPlantel = idUbicacion
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            tbtmp = cn.Cn_ListarCerdaDisponibleInseminar(obj).Copy
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
            DtgListadoCerda.DataSource = CType(e.Result, DataTable)
            ToolStrip1.Enabled = True
            DtgListadoCerda.DisplayLayout.Bands(0).Columns("idAnimal").Hidden = True
            DtgListadoCerda.DisplayLayout.Bands(0).Columns("idControlFicha").Hidden = True
        End If
    End Sub

    Private Sub DtgListadoCerda_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListadoCerda.InitializeLayout
        Try
            If (DtgListadoCerda.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(DtgListadoCerda, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgListadoCerda_DoubleClickCell(sender As Object, e As UltraWinGrid.DoubleClickCellEventArgs) Handles DtgListadoCerda.DoubleClickCell
        If DtgListadoCerda.Rows.Count = 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If

        ' Validamos que haya una fila seleccionada
        If e.Cell Is Nothing OrElse e.Cell.Row Is Nothing Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If

        ' Validamos que el índice sea válido
        If e.Cell.Row.Index < 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If
        Try
            If (DtgListadoCerda.Rows.Count > 0) Then
                If (DtgListadoCerda.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim codigo As String = e.Cell.Row.Cells("idAnimal").Value.ToString()
                    Dim datos As String = e.Cell.Row.Cells("Arete").Value.ToString()
                    Dim condCorporal As Decimal = e.Cell.Row.Cells("Cond. Corporal").Value.ToString()
                    Dim idServicio As Integer = e.Cell.Row.Cells("idControlFicha").Value

                    _frmRegistrarInseminacion.LlenarCamposCerdaInseminar(codigo, datos, condCorporal, idServicio)
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class