Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmListaDespachosPedido
    Public idSalida As Integer
    Dim cn As New cnControlRecepcionAlimento
    Dim ds As New DataSet

    Private Sub FrmEnviosRecepcionesAlimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListadoPreparacionRacion)
            Inicializar()
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Inicializar()
        Ptbx_Cargando.Visible = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True

            Dim obj As New coControlRecepcionAlimento With {
                .Codigo = idSalida
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlRecepcionAlimento = CType(e.Argument, coControlRecepcionAlimento)

            ds = cn.Cn_ConsultarRecepcionesxIdSalida(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns("idrecepcion").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("idrecepcion").ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns("iddetrecepcion").ColumnMapping = MappingType.Hidden
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListadoPreparacionRacion.DataSource = ds.Tables(0)
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListadoPreparacionRacion.Rows.Count > 0) Then
            Dim estado As Integer = 7

            'tipoAdquisicion
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.LightBlue, Color.Black, "ENTREGADO", estado)
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.LightGray, Color.Black, "PENDIENTE", estado)
            clsBasicas.Colorear_SegunValor(dtgListadoPreparacionRacion, Color.Red, Color.White, "ANULADO", estado)

            'centrar columnas
            With dtgListadoPreparacionRacion.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            If (dtgListadoPreparacionRacion.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL DE RECEPCIONES", dtgListadoPreparacionRacion)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCancelarDespacho_Click(sender As Object, e As EventArgs) Handles BtnCancelarDespacho.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListadoPreparacionRacion.ActiveRow
        If (dtgListadoPreparacionRacion.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim estadoDespacho = activeRow.Cells("Estado").Value.ToString()

                    If estadoDespacho = "ANULADO" Then
                        msj_advert("EL DESPACHO DE ALIMENTO YA FUE ANULADO")
                        Return
                    End If

                    If (MessageBox.Show("¿ESTÁ SEGURO DE CANCELAR EL DESPACHO DE ALIMENTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    Dim obj As New coControlRecepcionAlimento With {
                        .Codigo = activeRow.Cells("idrecepcion").Value,
                        .IdUsuario = VP_IdUser
                    }

                    Dim MensajeBgWk As String = cn.Cn_CancelarDespachoAlimento(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(MensajeBgWk)
                        Consultar()
                    Else
                        msj_advert(MensajeBgWk)
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub dtgListadoPreparacionRacion_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListadoPreparacionRacion.InitializeLayout
        If (dtgListadoPreparacionRacion.Rows.Count > 0) Then
            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListadoPreparacionRacion, e, 1)
        End If
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class