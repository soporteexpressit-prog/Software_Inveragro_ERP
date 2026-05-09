Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRptCostoxKiloDetalleF1
    Dim cn As New cnControlAnimal
    Dim ds As New DataSet
    Public idDetalle As String
    Public idCampaña As Integer

    Private Sub FrmRptCostoxKiloDetalleF1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim codigosSoportados As String() = {"RP2", "RP6"}

            If Not codigosSoportados.Contains(idDetalle) Then
                msj_advert("Para este registro no se tiene configurado un detalle")
                Dispose()
                Return
            End If

            ConfigurarTitulos()
            Consultar()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ConfigurarTitulos()
        ' Configura el título dinámico (LblTitle) según el idDetalle
        Select Case idDetalle
            Case "RP2"
                LblTitle.Text = "Reporte detallado de Reproduccion (VACUNACIÓN)"
            Case "RP6"
                LblTitle.Text = "Reporte detallado de gastos veterinarios"
                ' Case "RP3"
                '     LblTitle.Text = "Otro título para un nuevo reporte..."
            Case Else
                LblTitle.Text = "Reporte Detallado"
        End Select
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        BarraOpciones.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        BarraOpciones.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlAnimal With {
                .IdCampaña = idCampaña
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)

            ' Dependiendo del idDetalle, se llama a un PA diferente
            Select Case idDetalle
                Case "RP2"
                    ds = cn.Cn_CostoxKiloLechonRP2Detallado(obj).Copy
                    ds.Tables(1).Columns("idProducto").ColumnMapping = MappingType.Hidden
                Case "RP6"
                    ds = cn.Cn_CostoxKiloLechonRP6Detallado(obj).Copy
                    ds.Tables(1).Columns("idProducto").ColumnMapping = MappingType.Hidden
                    ds.Tables(1).Columns("idPlantel").ColumnMapping = MappingType.Hidden
                    ' Case "RP3"
                    '     ds = cn.Cn_OtroProcedimientoAlmacenado(obj).Copy 
                Case Else
                    ds = New DataSet()
            End Select

            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DesbloquearControladores()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            Dim dsResult As DataSet = CType(e.Result, DataSet)
            If dsResult Is Nothing OrElse dsResult.Tables.Count = 0 Then Return

            ' Se extraen y manejan las tablas de acuerdo a lo que necesite cada reporte (idDetalle)
            Select Case idDetalle
                Case "RP2"
                    Dim dtResult As DataTable = dsResult.Tables(0)
                    Dim dtResult2 As DataTable = dsResult.Tables(2)

                    LblInicioCampana.Text = If(IsDBNull(dtResult.Rows(0)("Campaña_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Campaña_Inicio")).ToString("dd/MM/yyyy"))
                    LblFinCampana.Text = If(IsDBNull(dtResult.Rows(0)("Campaña_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Campaña_Fin")).ToString("dd/MM/yyyy"))
                    LblDiasCampana.Text = If(IsDBNull(dtResult.Rows(0)("Campaña_Dias")), "-", dtResult.Rows(0)("Campaña_Dias").ToString())
                    LblInicioInseminacion.Text = If(IsDBNull(dtResult.Rows(0)("Inseminacion_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Inseminacion_Inicio")).ToString("dd/MM/yyyy"))
                    LblFinInseminacion.Text = If(IsDBNull(dtResult.Rows(0)("Inseminacion_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Inseminacion_Fin")).ToString("dd/MM/yyyy"))
                    LblDiasInseminacion.Text = If(IsDBNull(dtResult.Rows(0)("Inseminacion_Dias")), "-", dtResult.Rows(0)("Inseminacion_Dias").ToString())
                    LblInicioChanchilla.Text = If(IsDBNull(dtResult.Rows(0)("Chanchilla_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Chanchilla_Inicio")).ToString("dd/MM/yyyy"))
                    LblFinChanchilla.Text = If(IsDBNull(dtResult.Rows(0)("Chanchilla_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Chanchilla_Fin")).ToString("dd/MM/yyyy"))
                    LblDiasChanchilla.Text = If(IsDBNull(dtResult.Rows(0)("Chanchilla_Dias")), "-", dtResult.Rows(0)("Chanchilla_Dias").ToString())

                    dtgListado.DataSource = dsResult.Tables(1)

                    If IsDBNull(dtResult2.Rows(0)("vacunas_chanchillas_TOTAL")) Then
                        LblTotal.Text = "-"
                    Else
                        Dim total As Decimal = Convert.ToDecimal(dtResult2.Rows(0)("vacunas_chanchillas_TOTAL"))
                        LblTotal.Text = Math.Round(total, 2).ToString("0.00")
                    End If
                Case "RP6"
                    Dim dtResult As DataTable = dsResult.Tables(0)
                    Dim dtResult2 As DataTable = dsResult.Tables(2)

                    LblInicioCampana.Text = If(IsDBNull(dtResult.Rows(0)("Campaña_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Campaña_Inicio")).ToString("dd/MM/yyyy"))
                    LblFinCampana.Text = If(IsDBNull(dtResult.Rows(0)("Campaña_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Campaña_Fin")).ToString("dd/MM/yyyy"))
                    LblDiasCampana.Text = If(IsDBNull(dtResult.Rows(0)("MadresParidas_Denominador")), "-", dtResult.Rows(0)("MadresParidas_Denominador").ToString())
                    Label1.Text = "N° Paridas :"
                    LblInicioInseminacion.Text = If(IsDBNull(dtResult.Rows(0)("Monta_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Monta_Inicio")).ToString("dd/MM/yyyy"))
                    LblFinInseminacion.Text = If(IsDBNull(dtResult.Rows(0)("Monta_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Monta_Fin")).ToString("dd/MM/yyyy"))
                    LblDiasInseminacion.Visible = False
                    Label3.Visible = False
                    LblInicioChanchilla.Text = If(IsDBNull(dtResult.Rows(0)("Chanchilla_Inicio")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Chanchilla_Inicio")).ToString("dd/MM/yyyy"))
                    LblFinChanchilla.Text = If(IsDBNull(dtResult.Rows(0)("Chanchilla_Fin")), "- / - / -", Convert.ToDateTime(dtResult.Rows(0)("Chanchilla_Fin")).ToString("dd/MM/yyyy"))
                    LblDiasChanchilla.Visible = False
                    Label5.Visible = False

                    dtgListado.DataSource = dsResult.Tables(1)

                    If IsDBNull(dtResult2.Rows(0)("GastosVeterinarios_XMadre")) Then
                        LblTotal.Text = "-"
                    Else
                        Dim total As Decimal = Convert.ToDecimal(dtResult2.Rows(0)("GastosVeterinarios_XMadre"))
                        LblTotal.Text = Math.Round(total, 2).ToString("0.00")
                    End If

                    ' Case "RP3"
                    '     ' Aquí puedes extraer las tablas para el siguiente reporte futuro
                    '     ' Dim dtT1 as DataTable = dsResult.Tables(0)
                    '     ' LblNuevoDato.Text = ...
            End Select
        End If
    End Sub

    Private Sub BtnExportarprocontrolcerdos_Click(sender As Object, e As EventArgs) Handles BtnExportarprocontrolcerdos.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL DE DETALLE DE COSTO", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                clsBasicas.Totales_Formato(dtgListado, e, 1)
                ' Dependiendo del idDetalle, se llama a un PA diferente
                Select Case idDetalle
                    Case "RP2"
                        clsBasicas.SumarTotales_Formato(dtgListado, e, 2)
                        clsBasicas.SumarTotales_Formato(dtgListado, e, 3)
                        clsBasicas.SumarTotales_Formato(dtgListado, e, 4)
                        clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
                        clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
                    Case "RP6"
                        clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
                        clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
                        clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
                End Select
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class