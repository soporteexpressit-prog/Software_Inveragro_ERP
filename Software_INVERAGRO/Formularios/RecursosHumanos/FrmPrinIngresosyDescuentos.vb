Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmPrinIngresosyDescuentos
    Dim cn As New cnControlPagosyDes
    Dim quincenat As Integer = 0
    Dim semanat As Integer = 0
    Dim periodo2 As String = ""
    Dim montovalidador As Integer = 0
    Dim tipoPago As String = ""
    Dim tipoplanilla As String = ""
    Private selectedParentRows As New List(Of UltraGridRow)
    Private selectedIds As New List(Of String)

    Private Sub FrmPrinIngresosyDescuentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxMeses.SelectedIndex = DateTime.Now.Month - 1
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarAños()
        ConsultarPagos()
    End Sub
    Dim estadoaprobacion As String

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrarpagospgesrrhh.Click
        Dim resultado As String = String.Empty
        Dim esValido As Boolean = cn.Cn_validarfecharegimen(resultado)
        If esValido Then
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim idpago As Integer = activeRow.Cells("Codigo").Value
                    Dim tipoperiodo As String = activeRow.Cells("Tipo de Período").Value
                    If tipoperiodo = "GRATIFICACION" Or tipoperiodo = "CTS" Then
                        msj_advert(" El registro no corresponde a un tareo generado desde asistencia")
                        Return
                    End If
                    estadoaprobacion = activeRow.Cells("Estado Aprobación").Value
                        tipoPago = dtgListado.ActiveRow.Cells("Tipo").Value.ToString
                        If estadoaprobacion = "OBSERVACIÓN" Then
                            MessageBox.Show("La asistencia se encuentra en proceso de corrección.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            If tipoPago = "PLANILLA" Then
                                If tipoperiodo = "MENSUAL" Then
                                    Dim f As New FrmControlPagosDescuentos()
                                    f.idpago = idpago
                                    f._estadoaprobado = dtgListado.ActiveRow.Cells("Estado Aprobación").Value.ToString
                                    f._tipopago = dtgListado.ActiveRow.Cells("Tipo").Value.ToString
                                    f._tipoperiodo = tipoperiodo
                                    f.mostrarperiodo = dtgListado.ActiveRow.Cells("Rango Fechas").Value.ToString
                                    f.ShowDialog()
                                    ConsultarPagos()
                                Else
                                    Dim f As New FrmControlPagosDescuentos()
                                    f.idpago = idpago
                                    f._estadoaprobado = dtgListado.ActiveRow.Cells("Estado Aprobación").Value.ToString
                                    f._tipopago = dtgListado.ActiveRow.Cells("Tipo").Value.ToString
                                    f.mostrarperiodo = dtgListado.ActiveRow.Cells("Rango Fechas").Value.ToString
                                    f._tipoperiodo = tipoperiodo
                                    f.ShowDialog()
                                    ConsultarPagos()
                                End If
                            End If
                            If tipoPago = "EVENTUAL" Then
                                Dim f As New FrmControlPagosDescuentos()
                                f.idpago = idpago
                                f.tipoQuincena = semanat
                                f._estadoaprobado = dtgListado.ActiveRow.Cells("Estado Aprobación").Value.ToString
                                f._tipopago = dtgListado.ActiveRow.Cells("Tipo").Value.ToString
                                f.mostrarperiodo = dtgListado.ActiveRow.Cells("Rango Fechas").Value.ToString
                                f.ShowDialog()
                                ConsultarPagos()
                            End If

                        End If
                    Else
                        msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            MessageBox.Show("Para poder continua, actualice los porcentajes del sistema de pension", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Dim f As New FrmImportesAFP
            f.ShowDialog()
        End If
    End Sub

    Sub ListarAños()
        Try
            Dim dt As New DataTable
            dt = cn.Cn_ListarAñosDeHorarios().Copy
            dt.TableName = "tmp"
            dt.Columns(0).ColumnName = "Seleccione un Año"
            With cbxAños
                .DataSource = dt
                .DisplayMember = dt.Columns(0).ColumnName
                .ValueMember = dt.Columns(0).ColumnName
                If (dt.Rows.Count > 0) Then
                    .Value = dt.Rows(0)(0)
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ConsultarPagos()
    End Sub
    Sub ConsultarPagos()
        Dim obj As New coControlPagosyDes
        Dim mesSeleccionado As Integer? = Nothing
        Dim anio As Integer = cbxAños.Value
        If cbxMeses.SelectedIndex <> 12 Then
            mesSeleccionado = cbxMeses.SelectedIndex + 1
        End If
        obj.Mes = mesSeleccionado
        obj.Anio = anio
        Debug.WriteLine(mesSeleccionado)
        Dim dt As DataTable = cn.Cn_ConsultarControldepagos(obj)
        dtgListado.DataSource = dt
        ColorearGrid()
    End Sub
    Sub ColorearGrid()
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "PENDIENTE", 8)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "APROBADO", 8)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Yellow, Color.Black, "OBSERVACIÓN", 8)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "PENDIENTE", 9)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "APROBADO", 9)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Orange, Color.White, "EVENTUAL", 1)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "PLANILLA", 1)
    End Sub
    Public Sub AprobarPagos()
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow

            If dtgListado.Rows.Count > 0 Then
                tipoPago = activeRow.Cells("Tipo").Value.ToString

                If tipoPago = "PLANILLA" OrElse tipoPago = "EVENTUAL" Then
                    Dim idpago As Integer = activeRow.Cells(0).Value

                    Dim sueldoBase As New coControlPagosyDes With {
                        .TipoQuincena = idpago
                    }

                    Dim resultadoBase As String = cn.Cn_AprobarpagosEventuales(sueldoBase)

                    If String.IsNullOrEmpty(resultadoBase) Then
                        MsgBox("Operación realizada correctamente: ", MsgBoxStyle.Information, "Éxito")
                    Else
                        MsgBox(" " & resultadoBase, MsgBoxStyle.Exclamation, "Alerta")
                    End If
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If

        Catch ex As Exception
            MsgBox(" " & ex.Message, MsgBoxStyle.Exclamation, "Alerta")
        End Try
    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobarpgesrrhh.Click
        'Try
        '    Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro de que quieres Aprobarlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If resultado = DialogResult.Yes Then
        '        Dim estado As String = dtgListado.ActiveRow.Cells("Estado Aprobación").Value.ToString()
        '        If estado = "PENDIENTE" Then
        '            Dim monto As Double
        '            If Double.TryParse(dtgListado.ActiveRow.Cells("Total Ingreso Base").Value.ToString(), monto) AndAlso monto > 0 Then
        '                AprobarPagos()
        '                ConsultarPagos()
        '            Else
        '                MessageBox.Show("Registre el pago para continuar con la aprobación.", "Verificación de Monto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            End If
        '        Else
        '            MessageBox.Show("Este pago ya se encuentra aprobado.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Ocurrió un error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try


        Try
            If selectedIds.Count = 0 Then
                msj_advert("Debe seleccionar al menos un registro para aprobar.")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE APROBAR ESTOS REGISTROS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlPagosyDes With {
                .ListaIdsPago = ObtenerIdsSeleccionadosComoString()
            }

            Dim resultado As String = cn.Cn_AprobarPagoMultiple(obj)
            If (obj.Coderror = 0) Then
                msj_ok(resultado)
                LimpiarSelecciones()
                ConsultarPagos()
            Else
                msj_advert(resultado)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try

    End Sub

    Public Sub EnviarCuentasPorPagarbs()
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow

            Dim idpago As Integer = activeRow.Cells(0).Value
            Dim sueldoBase As New coControlPagosyDes With {
            .TipoQuincena = idpago,
            .Iduser = GlobalReferences.ActiveSessionId
        }
            Dim resultadoBase As String = cn.Cn_EnviarCuentasPagarbs(sueldoBase)
            If String.IsNullOrEmpty(resultadoBase) Then
                MsgBox("Operación realizada correctamente: ", MsgBoxStyle.Information, "Éxito")
            Else
                MsgBox(" " & resultadoBase, MsgBoxStyle.Exclamation, "Alerta")
            End If
        Catch ex As Exception
            MsgBox(" " & ex.Message, MsgBoxStyle.Critical, "Alerta")
        End Try
    End Sub
    Public Sub EnviarCuentasPorPagar()
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            tipoPago = dtgListado.ActiveRow.Cells("Tipo").Value.ToString
            tipoplanilla = dtgListado.ActiveRow.Cells("Tipo de Período").Value.ToString
            If tipoPago = "PLANILLA" Then
                If (dtgListado.Rows.Count > 0) Then
                    Dim idpago As Integer = activeRow.Cells(0).Value
                    Dim sueldoBase As New coControlPagosyDes With {
                    .TipoQuincena = idpago,
                    .Iduser = GlobalReferences.ActiveSessionId
                }
                    Dim resultadoBase As String = cn.Cn_EnviarCuentasPagar(sueldoBase)
                    If String.IsNullOrEmpty(resultadoBase) Then
                        MsgBox("Operación realizada correctamente: ", MsgBoxStyle.Information, "Éxito")
                    Else
                        MsgBox(" " & resultadoBase, MsgBoxStyle.Exclamation, "Alerta")
                    End If
                Else
                End If
            End If
            If tipoPago = "EVENTUAL" Then
                If (dtgListado.Rows.Count > 0) Then
                    Dim idpago As Integer = activeRow.Cells(0).Value
                    Dim sueldoBase As New coControlPagosyDes With {
                        .TipoQuincena = idpago,
                        .Iduser = GlobalReferences.ActiveSessionId
                     }
                    Dim resultadoBase As String = cn.Cn_EnviarCuentasPagarEventuales(sueldoBase)
                    If String.IsNullOrEmpty(resultadoBase) Then
                        MsgBox("Operación realizada correctamente: ", MsgBoxStyle.Information, "Éxito")
                    Else
                        MsgBox(" " & resultadoBase, MsgBoxStyle.Exclamation, "Alerta")
                    End If
                End If
            Else
            End If

        Catch ex As Exception
            MsgBox(" " & ex.Message, MsgBoxStyle.Critical, "Alerta")
        End Try
    End Sub

    Private Sub btnEnviarRrhhCtrlasist_Click(sender As Object, e As EventArgs) Handles btnEnviarRrhhCtrlasistpgesrrhh.Click
        Try
            Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro de que quieres Enviarlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resultado = DialogResult.Yes Then
                Dim estado As String = dtgListado.ActiveRow.Cells("Estado Aprobación").Value.ToString()
                Dim tipoperiodo As String = dtgListado.ActiveRow.Cells("Tipo de Período").Value.ToString()
                If estado = "APROBADO" Then
                    If tipoperiodo = "CTS" Or tipoperiodo = "GRATIFICACION" Then
                        EnviarCuentasPorPagarbs()
                    Else
                        EnviarCuentasPorPagar()
                    End If
                    ConsultarPagos()
                Else
                    MessageBox.Show("Primero debe aprobar el pago", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub ImprimirReporteTrabajador()
        Dim selectedRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If selectedRow Is Nothing Then
            MsgBox("Por favor, seleccione un registro.")
            Return
        End If
        Dim obj As New coControlPagosyDes
        Dim dsCapacitacion As New DataSet
        Dim idpago As Integer = activeRow.Cells(0).Value
        obj.TipoQuincena = idpago
        dsCapacitacion = cn.Cn_GenerarReportepagoPlanilla(obj)
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_CuentasPagar.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ImprimirReporteTrabajadorCTS()
        Dim selectedRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If selectedRow Is Nothing Then
            MsgBox("Por favor, seleccione un registro.")
            Return
        End If
        Dim obj As New coControlPagosyDes
        Dim dsCapacitacion As New DataSet
        Dim idpago As Integer = activeRow.Cells(0).Value
        obj.TipoQuincena = idpago
        dsCapacitacion = cn.Cn_GenerarReportepagoPlanillacts(obj)
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_CuentasPagarCTS.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ImprimirReporteTrabajadorCTSpagos()
        Dim selectedRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If selectedRow Is Nothing Then
            MsgBox("Por favor, seleccione un registro.")
            Return
        End If
        Dim obj As New coControlPagosyDes
        Dim dsCapacitacion As New DataSet
        Dim idpago As Integer = activeRow.Cells(0).Value
        obj.TipoQuincena = idpago
        dsCapacitacion = cn.Cn_GenerarReportepagoCTS(obj)
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_CuentasPagarCTSpagos.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ImprimirReporteTrabajador_oficina()
        Dim selectedRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If selectedRow Is Nothing Then
            MsgBox("Por favor, seleccione un registro.")
            Return
        End If
        Dim obj As New coControlPagosyDes
        Dim dsCapacitacion As New DataSet
        Dim idpago As Integer = activeRow.Cells(0).Value
        obj.TipoQuincena = idpago
        dsCapacitacion = cn.Cn_GenerarReportepagoPlanilla_oficina(obj)
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_CuentasPagar_oficina.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub ImprimirReporteTrabajadoreventual()
        Dim selectedRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If selectedRow Is Nothing Then
            MsgBox("Por favor, seleccione un registro.")
            Return
        End If
        Dim obj As New coControlPagosyDes
        Dim dsCapacitacion As New DataSet
        Dim idpago As Integer = activeRow.Cells(0).Value
        obj.TipoQuincena = idpago
        dsCapacitacion = cn.Cn_GenerarReporteEventual(obj)
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_CuentasPagarEventual.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ImprimirReporteTrabajadoreventual_oficina()
        Dim selectedRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If selectedRow Is Nothing Then
            MsgBox("Por favor, seleccione un registro.")
            Return
        End If
        Dim obj As New coControlPagosyDes
        Dim dsCapacitacion As New DataSet
        Dim idpago As Integer = activeRow.Cells(0).Value
        obj.TipoQuincena = idpago
        dsCapacitacion = cn.Cn_GenerarReporteEventual_oficina(obj)
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_CuentasPagarEventual_oficina.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalirpgesrrhh.Click
        Dispose()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles importeagppgesrrhh.Click
        Dim f As New FrmImportesAFP
        f.ShowDialog()
    End Sub


    Private Sub btnrrhhreporteoficina_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Dim band = e.Layout.Bands(0)
        clsBasicas.Totales_Formato(dtgListado, e, 0)
        clsBasicas.SumarTotales_Formato(dtgListado, e, 5)
        clsBasicas.SumarTotales_Formato(dtgListado, e, 6)
        clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
    End Sub

    Private Sub ReporteGeneralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteGeneralToolStripMenuItem.Click
        Try
            Dim frm As New FrmReporteGeneral
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub ReporteOficinaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteOficinaToolStripMenuItem.Click
        Dim estado As String = dtgListado.ActiveRow.Cells("Tipo").Value.ToString()
        If estado = "PLANILLA" Then
            ImprimirReporteTrabajador_oficina()
        End If
        If estado = "EVENTUAL" Then
            ImprimirReporteTrabajadoreventual_oficina()
        End If
    End Sub

    Private Sub ReporteTrabajadoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteTrabajadoresToolStripMenuItem.Click
        Dim estado As String = dtgListado.ActiveRow.Cells("Tipo").Value.ToString()
        If estado = "PLANILLA" Then
            ImprimirReporteTrabajador()
        End If
        If estado = "EVENTUAL" Then
            ImprimirReporteTrabajadoreventual()
        End If
    End Sub
    Private Sub ReporteCTSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteCTSToolStripMenuItem.Click
        Dim estado As String = dtgListado.ActiveRow.Cells("Tipo").Value.ToString()
        Dim tipoperiodo As String = dtgListado.ActiveRow.Cells("Tipo de Período").Value.ToString()
        If estado = "PLANILLA" Then
            If tipoperiodo = "CTS" Then
                ImprimirReporteTrabajadorCTSpagos()
            Else
                ImprimirReporteTrabajadorCTS()
            End If
        End If
        If estado = "EVENTUAL" Then
            MessageBox.Show("Este reporte solo es visible para registros de planilla", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If e.Cell Is Nothing OrElse e.Cell.Row Is Nothing Then
                Return
            End If

            Dim clickedRow As UltraGridRow = e.Cell.Row

            If clickedRow.IsDataRow AndAlso clickedRow.ParentRow Is Nothing Then
                Dim firstColumnValue As String = clickedRow.Cells(0).Value.ToString()
                Dim montoTotal As Double = CDbl(clickedRow.Cells("Monto Total").Value)
                Dim estadoAprobado As String = clickedRow.Cells("Estado Aprobación").Value.ToString()

                If montoTotal <= 0 Then
                    msj_advert("El monto total debe ser mayor a cero para seleccionar el registro.")
                    Return
                End If

                If estadoAprobado = "APROBADO" Then
                    msj_advert("Este pago ya ha sido aprobado y no puede ser seleccionado.")
                    Return
                End If

                If selectedParentRows.Contains(clickedRow) Then
                    clickedRow.Appearance.BackColor = Color.White
                    selectedParentRows.Remove(clickedRow)

                    selectedIds.Remove(firstColumnValue)
                Else
                    clickedRow.Appearance.BackColor = Color.LightSkyBlue
                    selectedParentRows.Add(clickedRow)

                    selectedIds.Add(firstColumnValue)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Function ObtenerIdsSeleccionadosComoString() As String
        Return String.Join(",", selectedIds)
    End Function

    Private Sub LimpiarSelecciones()
        For Each row As UltraGridRow In selectedParentRows
            If Not row Is Nothing Then
                row.Appearance.BackColor = Color.White
            End If
        Next
        selectedParentRows.Clear()
        selectedIds.Clear()
    End Sub

    Private Sub ReporteGratificacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteGratificacionToolStripMenuItem.Click
        Try
            Dim frm As New FrmReporteFacturasVinculadas
            frm.operacion = 2
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ReporteCTSToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReporteCTSToolStripMenuItem1.Click
        Try
            Dim frm As New FrmReporteFacturasVinculadas
            frm.operacion = 3
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub EnviarAObservacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnviarAObservacionToolStripMenuItem.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim estado As String = dtgListado.ActiveRow.Cells("Estado Aprobación").Value.ToString()
                If estado = "OBSERVACIÓN" Or estado = "APROBADO" Then
                    msj_advert("No se puede anular el pago.")
                    Return
                End If
                Dim idpago As Integer = activeRow.Cells(0).Value
                Dim f As New AnularPago()
                f.idpago = idpago
                f.ShowDialog()
                ConsultarPagos()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub AnularEnvioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularEnvioToolStripMenuItem.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim estado As String = dtgListado.ActiveRow.Cells("Estado Aprobación").Value.ToString()
                If estado = "PENDIENTE" Then
                    msj_advert("No se puede anular el envio de los pagos.")
                    Return
                End If
                Dim idpago As Integer = activeRow.Cells(0).Value
                Dim f As New AnularPago()
                f.idpago = idpago
                f.operacion = 1
                f.ShowDialog()
                ConsultarPagos()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        Dim f As New FrmPagosBeneficiosSociales()
        f.idpago = 0
        f.operacion = 0
        f.ShowDialog()
        ConsultarPagos()
    End Sub

    Private Sub ReportePagosGratifiaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportePagosGratifiaciónToolStripMenuItem.Click
        Dim tipoperiodo As String = dtgListado.ActiveRow.Cells("Tipo de Período").Value.ToString()
        If tipoperiodo = "GRATIFICACION" Then
            ImprimirReporteTrabajadorpagosgratificacion()
        Else
            msj_advert("Por favor, seleccione una cuenta válida.")
            Return
        End If
    End Sub
    Sub ImprimirReporteTrabajadorpagosgratificacion()
        Dim selectedRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If selectedRow Is Nothing Then
            MsgBox("Por favor, seleccione un registro.")
            Return
        End If
        Dim obj As New coControlPagosyDes
        Dim dsCapacitacion As New DataSet
        Dim idpago As Integer = activeRow.Cells(0).Value
        obj.TipoQuincena = idpago
        dsCapacitacion = cn.Cn_GenerarReportepagogratificacion(obj)
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_ReportePagos_gratificacion.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AnularBsSocialCreadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularBsSocialCreadaToolStripMenuItem.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim estado As String = dtgListado.ActiveRow.Cells("Estado Aprobación").Value.ToString()
                Dim tipoperiodo As String = dtgListado.ActiveRow.Cells("Tipo de Período").Value.ToString()
                If estado = "APROBADO" Then
                    msj_advert("La cuenta no puede ser anulada porque ya fue enviada a pagar. Anule el envío antes de continuar.")
                    Return
                End If
                If tipoperiodo = "GRATIFICACION" Or tipoperiodo = "CTS" Then
                    Dim idpago As Integer = activeRow.Cells(0).Value
                    Dim f As New AnularPago()
                    f.idpago = idpago
                    f.operacion = 2
                    f.ShowDialog()
                    ConsultarPagos()
                Else
                    msj_advert("La anulación de beneficios sociales solo es posible para gratificación y CTS.")
                End If

            Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub
End Class