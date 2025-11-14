Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlAlimento
    Dim cn As New cnNucleo
    Dim dt As New DataTable

    Private Sub FrmControlAlimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Ptbx_Cargando.Visible = True
            clsBasicas.ListarAlmacenesAsignados(cbxalmacen)
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            Dim obj As New coProductos With {
                .IdUbicacion = cbxalmacen.SelectedValue
            }
            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coProductos = CType(e.Argument, coProductos)
            dt = cn.Cn_ListarRaciones(obj).Copy
            dt.TableName = "tmp"
            e.Result = dt
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
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            Colorear()
            ToolStrip1.Enabled = True
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estado As Integer = 7

            'tipoAdquisicion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "INACTIVO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportaralmacenali.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("REQUERIMIENTO DE ALIMENTOS CAPATAZ", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnConsolidado_Click(sender As Object, e As EventArgs) Handles btnConsolidadoalmacenali.Click
        Try
            Dim f As New FrmConsolidadoAlimento
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnPedidoAlimento_Click(sender As Object, e As EventArgs) Handles BtnPedidoAlimentoalmacenali.Click
        Try
            Dim frm As New FrmPedidoAlimentoCerdo
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnKardex_Click(sender As Object, e As EventArgs) Handles BtnKardexAlmacenali.Click
        Try
            If (dtgListado.Rows.Count > 0) Then
                If dtgListado.ActiveRow.Cells(0).Value.ToString <> 0 Then
                    Dim f As New FrmKardex With {
                        .idubicacion = cbxalmacen.SelectedValue
                    }
                    f.lblpresentación.Text = dtgListado.ActiveRow.Cells(5).Value.ToString
                    f.lblNombreProducto.Text = dtgListado.ActiveRow.Cells(1).Value.ToString
                    f.lblCodigo.Text = dtgListado.ActiveRow.Cells(0).Value.ToString
                    f.ShowDialog()
                Else
                    msj_advert("Seleccione un Registro")
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxalmacen_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbxalmacen.SelectionChangeCommitted
        Consultar()
    End Sub

    Private Sub BtnReporteGeneral_Click_1(sender As Object, e As EventArgs) Handles BtnReporteAnual.Click
        Try
            Dim frm As New FrmReporteAlimentoAnual
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnReporteSemanal_Click(sender As Object, e As EventArgs) Handles BtnReporteSemanal.Click
        Try
            Dim f As New FrmPrepararRegistrarOrden
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ReporteRecepcionesDespachos_Click(sender As Object, e As EventArgs) Handles ReporteRecepcionesDespachos.Click
        Try
            Dim f As New FrmReporteDespachosRecepciones
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnVerFormula_Click(sender As Object, e As EventArgs) Handles BtnVerFormula.Click
        Try
            Dim frm As New FrmVerFormulaAlmacen
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnAsignarUnidadesMedida_Click(sender As Object, e As EventArgs) Handles btnAsignarUnidadesMedida.Click
        Try
            Dim frm As New FrmAsignarUnidadesMedida
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnEditarUnidadMedida_Click(sender As Object, e As EventArgs) Handles BtnEditarUnidadMedida.Click
        Try
            Dim activeRow As UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim idProducto As String = activeRow.Cells(0).Value.ToString
                    Dim nombreProducto As String = activeRow.Cells(1).Value.ToString
                    Dim presentacion As String = activeRow.Cells(5).Value.ToString

                    Dim frm As New FrmAsignarUnidadesMedida With {
                        .operacion = 1,
                        .idProducto = idProducto,
                        .producto = nombreProducto,
                        .presentacion = presentacion
                    }
                    frm.ShowDialog()
                    Consultar()
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

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub
End Class