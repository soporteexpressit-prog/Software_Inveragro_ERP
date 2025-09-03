Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmControlPagosDescuentos
    Private cn As New cnControlPagosyDes()
    Dim obj As New coControlPagosyDes
    Public anio As Integer
    Public idpago As Integer
    Public mes As Integer
    Public tipoQuincena As Integer = 0
    Dim dtIngreso As DataTable
    Dim dtDescuento As DataTable
    Dim dtIngresoExtra As DataTable
    Dim dtDescuentoExtra As DataTable
    Dim dtaporteempleador As DataTable
    Dim id As Integer
    Dim periodo2 As String
    Public mostrarperiodo As String
    Public ds As DataSet
    Dim montohorasextras As Decimal
    Public Montototalingresobase As Decimal
    Public Montototalingresoextra As Decimal
    Public _estadoaprobado As String = ""
    Public _tipopago As String = ""
    Public _tipoperiodo As String = ""
    Dim preciototalhorasextras As Decimal
    Dim preciotHEmarranas As Decimal
    Private sueldoquincena As Decimal
    Dim valordesp As Decimal
    Dim familiar As Decimal
    Dim bonoagrario As Decimal
    Dim essalud As Decimal
    Dim idregimenlaboral As Decimal
    Dim sueldotal As Decimal
    Dim montoeventual As Decimal
    Dim vhoraextra As Decimal
    Dim validarcuenta As Integer
    Dim ultimoDiaMarcacion As Integer
    Dim diasvacaciones As Integer
    Dim observacion As String
    Dim horasregulares, horasextras As Decimal


    Private Sub FrmControlDescansoMedico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AsignarValores()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Formato_Tablas_Grid(dtgListadoIngresoBase)
        clsBasicas.Formato_Tablas_Grid(dtgListadoDescuentoBase)
        clsBasicas.Formato_Tablas_Grid(dtgListadoDescuentoExt)
        clsBasicas.Formato_Tablas_Grid(dtgListadoIngresoExt)
        clsBasicas.Formato_Tablas_Grid(dtgaporteempleador)
        InicializarTablas()
        SumarMontos(ds)
        If _estadoaprobado = "APROBADO" Then
            btnGuardarRrhhCtrlasist.Enabled = False
            btnAgregaringresobase.Visible = False
            btnAgregardescuentobase.Visible = False
            btnagregaraporteempleador.Visible = False
            btnAgregarIngresoExtra.Visible = False
            btnAgregarDescuentoextra.Visible = False
            Conceptos.Enabled = False

        End If
        If _tipopago = "EVENTUAL" And _estadoaprobado = "PENDIENTE" Then
            btnAgregardescuentobase.Visible = False
            btnagregaraporteempleador.Visible = False
            btnAgregarIngresoExtra.Visible = False
            btnAgregarDescuentoextra.Visible = False
        End If
        If _tipopago = "EVENTUAL" Then
            ToolStripButton2.Visible = False
        End If
    End Sub
    Private Sub btnMincidentes_Click(sender As Object, e As EventArgs)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub
    Sub AsignarValores()
        Consultar()
    End Sub
    Private Sub dtgListado_MouseClick(sender As Object, e As MouseEventArgs) Handles dtgListado.MouseClick
        Dim cell As Infragistics.Win.UltraWinGrid.UltraGridCell = dtgListado.ActiveCell
        If cell IsNot Nothing AndAlso cell.Column.Key = "Seleccionar" Then
            cell.Value = Not CBool(cell.Value)
            Dim estadoactual As Integer = If(cell.Value, 1, 0)
            Try
                obj.IdPersona = id
                obj.idpago = idpago
                obj.estado = estadoactual
                cn.Cn_actualizar_estado_detallesueldo(obj)
                cell.Row.Update()
                dtgListado.UpdateData()
            Catch ex As Exception
                MsgBox("Error al actualizar el estado: " & ex.Message)
            End Try
        End If
    End Sub
    Sub Consultar()
        If _tipopago = "PLANILLA" Or _tipopago = "EVENTUAL" Then
            Try
                obj.idpago = idpago
                Dim dt As DataTable = cn.Cn_Consultarsemana(obj)

                ' Agregar columna checkbox
                If _estadoaprobado = "PENDIENTE" Then
                    dt.Columns.Add("Seleccionar", GetType(Boolean))
                    For Each row As DataRow In dt.Rows
                        Dim estado As Integer = Convert.ToInt32(row("estado"))
                        row("Seleccionar") = (estado = 1)
                    Next
                End If

                dtgListado.DataSource = dt

                With dtgListado
                    .DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
                    .DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
                    ' Configuración específica de la columna checkbox
                    If _estadoaprobado = "PENDIENTE" Then
                        With .DisplayLayout.Bands(0).Columns("Seleccionar")
                            .Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                            .Header.Caption = "✓"
                            .Width = 30
                            .CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                            .Header.VisiblePosition = 0
                            .AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                        End With
                    End If

                    ' Deshabilitar edición para otras columnas
                    If _estadoaprobado = "PENDIENTE" Then
                        For Each col As UltraGridColumn In .DisplayLayout.Bands(0).Columns
                            If col.Key <> "Seleccionar" Then
                                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                            End If
                        Next
                    End If

                    ' Resto de la configuración de grupos y columnas...
                    ConfigurarGrupo(.DisplayLayout, "DatosEmpleado", "DATOS DEL EMPLEADO")
                    AsignarColumnasAGrupo(.DisplayLayout, "DatosEmpleado", 7, 1, 2)
                    ConfigurarGrupo(.DisplayLayout, "RESUMENTRABAJADO", "RESUMEN DE HORAS Y DÍAS TRABAJADOS")
                    If _estadoaprobado = "PENDIENTE" Then
                        Dim indiceSeleccionar As Integer = .DisplayLayout.Bands(0).Columns("Seleccionar").Index
                        AsignarColumnasAGrupo(.DisplayLayout, "RESUMENTRABAJADO", 3, 4, 5, 6, indiceSeleccionar)
                    Else
                        AsignarColumnasAGrupo(.DisplayLayout, "RESUMENTRABAJADO", 3, 4, 5, 6)
                    End If
                End With

            Catch ex As Exception
                MsgBox("Error al consultar los datos: " & ex.Message)
                Return
            End Try
        End If
    End Sub
    Sub MostrarOcultarColumnas(layout As UltraGridLayout, inicio As Integer, fin As Integer, mostrar As Boolean)
        For colIndex As Integer = inicio To fin
            If colIndex >= 0 AndAlso colIndex < layout.Bands(0).Columns.Count Then
                layout.Bands(0).Columns(colIndex).Hidden = Not mostrar
            End If
        Next
    End Sub
    Sub ConfigurarGrupo(layout As UltraGridLayout, nombreGrupo As String, titulo As String)
        Dim group As UltraGridGroup
        If Not layout.Bands(0).Groups.Exists(nombreGrupo) Then
            group = layout.Bands(0).Groups.Add(nombreGrupo)
            group.Header.Caption = titulo
            group.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        End If
    End Sub
    ' Función para asignar columnas a un grupo
    Sub AsignarColumnasAGrupo(layout As UltraGridLayout, nombreGrupo As String, ParamArray columnas As Integer())
        For Each colIndex In columnas
            If colIndex >= 0 AndAlso colIndex < layout.Bands(0).Columns.Count Then
                layout.Bands(0).Columns(colIndex).Group = layout.Bands(0).Groups(nombreGrupo)
            Else
                MsgBox("Índice de columna fuera de rango: " & colIndex)
            End If
        Next
    End Sub
    Sub ConfigurarAlineacionColumnas(layout As UltraGridLayout)
        For Each col As UltraGridColumn In layout.Bands(0).Columns
            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
        Next
    End Sub


    ' Método auxiliar para asignar texto a un control, usando un valor por defecto si es nulo o vacío
    Private Sub AsignarTexto(control As Control, valor As Object, Optional valorPorDefecto As String = "")
        If valor IsNot Nothing AndAlso Not IsDBNull(valor) AndAlso Not String.IsNullOrWhiteSpace(valor.ToString()) Then
            control.Text = valor.ToString()
        Else
            control.Text = valorPorDefecto
        End If
    End Sub
    Public Sub LlenarCamposCapacitador(
    sueldo As Decimal, familiar As Decimal, ingreso As Decimal, remudiario As Decimal, costoHoras As Decimal,
    diasAsistidos As Integer, DiasFeriados As Integer, totalHorasTrabajadas As Decimal, periodo As String,
    DiasNoAsistidos As Integer, DiasDomingoDescanso As Integer, descripsp As String, valordesp As Decimal,
    valorsp As Decimal, Extrabono As Decimal, idsegurosocial As Integer, bonoagrario As Decimal, essalud As Decimal,
    idregimenlaboral As Integer, montoeventual As Decimal, numdiasvacaciones As Integer, fechavacacion As String,
    vhoraextra As Decimal, salariobase As Decimal, validarcuenta As Integer, observacion As String, diasdescanso As Integer,
    ultimoDiaMarcacion As Integer, diasvacaciones As Integer, diasdescansoeti As String, fetrabajados As Integer, fenotrabajado As Integer,
    diaspermiso As Integer, horasmmarrana As Double, costohorasmarrana As Double, importevacacionesvendidas As Double, diasvendidos As Integer,
    montograti As Double, MontoCts As Double)

        sueldoquincena = sueldo / 2
        Me.valordesp = valordesp
        Me.familiar = familiar
        Me.bonoagrario = bonoagrario
        Me.essalud = essalud
        Me.idregimenlaboral = idregimenlaboral
        Me.montoeventual = montoeventual
        Me.vhoraextra = vhoraextra
        Me.validarcuenta = validarcuenta
        Me.observacion = observacion
        Me.ultimoDiaMarcacion = ultimoDiaMarcacion
        Me.diasvacaciones = diasvacaciones
        sueldotal = bonoagrario + sueldo

        AsignarTexto(txtsueldo, sueldo.ToString("C"))
        AsignarTexto(txtAfamiliar, Me.familiar.ToString("C"))
        AsignarTexto(txtmontoagrario, bonoagrario.ToString("C"))
        AsignarTexto(txtremudiario, remudiario.ToString("C"))
        AsignarTexto(txtcostohorAfami, costoHoras.ToString("C"))
        AsignarTexto(txtfechavacaciones, If(fechavacacion <> "0", fechavacacion, ""), "")
        AsignarTexto(txtasis, diasAsistidos.ToString())
        AsignarTexto(txtobservacion, observacion, "Sin observaciones")
        AsignarTexto(lbdiasvacaciones, numdiasvacaciones.ToString())
        AsignarTexto(txtingreso, sueldotal.ToString("C"))
        AsignarTexto(txthorastrabajadas, totalHorasTrabajadas.ToString())
        AsignarTexto(txtperiodo, periodo)
        AsignarTexto(txtfalta, DiasNoAsistidos.ToString())
        AsignarTexto(lb_dias_vacaciones, diasvacaciones.ToString())
        AsignarTexto(lbdiasdescanso, diasdescanso.ToString())
        AsignarTexto(txtlosdiasdescanso, diasdescansoeti, "")
        AsignarTexto(txttrabferiado, fetrabajados.ToString())
        AsignarTexto(txtnotrabferiado, fenotrabajado.ToString())
        AsignarTexto(txthorasmarrana, horasmmarrana.ToString())
        AsignarTexto(txtdiaspermisomedico, diaspermiso.ToString())
        AsignarTexto(lbvacacionesvendidas, diasvendidos.ToString())
    End Sub
    Public Sub LlenarCamposTrabajador(sueldo As Decimal, valordesp As Decimal)
        sueldoquincena = sueldo / 2
        Me.valordesp = valordesp
    End Sub
    Private selectedId As Integer = -1
    Dim estadoregistro As Integer
    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        Try
            estadoregistro = Convert.ToInt32(e.Row.Cells(e.Row.Cells.Count - 1).Value)
            Dim rowId As Integer = Convert.ToInt32(e.Row.Cells(0).Value)
            If rowId = selectedId Then
                e.Row.Appearance.BackColor = Color.LightBlue
            ElseIf estadoregistro = 1 Then
                e.Row.Appearance.BackColor = Color.LightBlue
            Else
                e.Row.Appearance.BackColor = Color.White
            End If
        Catch ex As Exception
            e.Row.Appearance.BackColor = Color.White
        End Try
    End Sub
    ' Asigna los datos del empleado seleccionado a los controles y variables
    Private Function AsignarDatosEmpleado(activeRow As UltraGridRow) As Boolean
        If activeRow IsNot Nothing AndAlso activeRow.Cells(0).Value IsNot Nothing Then
            id = Convert.ToInt32(activeRow.Cells(0).Value)
            lblnombreEmpleado.Text = activeRow.Cells(2).Value
            lblSetPeriodo.Text = mostrarperiodo
            Return True
        End If
        Return False
    End Function

    ' Limpia todas las tablas de conceptos y la de aportes del empleador
    Private Sub LimpiarTablasConceptos()
        dtIngreso.Clear()
        dtDescuento.Clear()
        dtIngresoExtra.Clear()
        dtDescuentoExtra.Clear()
        If dtaporteempleador Is Nothing Then
            dtaporteempleador = New DataTable()
            dtaporteempleador.Columns.Add("Descripción", GetType(String))
            dtaporteempleador.Columns.Add("Costo", GetType(Decimal))
        End If
        dtaporteempleador.Clear()
    End Sub

    ' Nueva sobrecarga que acepta el objeto completo y los valores adicionales si es necesario
    Public Sub LlenarCamposCapacitador(objp As coControlPagosyDes)
        LlenarCamposCapacitador(
        objp.Salario, objp.AsignacionFamiliar, objp.IngresoBasico,
        objp.CostoDia, objp.CostoPorHoraSinAsigFam, objp.DiasAsistidos,
        objp.DiasFeriados, objp.TotalHorasTrabajadas, objp.Periodo,
        objp.DiasNoAsistidos, objp.DiasDomingoDescanso, objp.Descripcionsp,
        objp.valorsp, objp.valorspdec, objp.Extrabono, objp.idsegurosocial,
        objp.bonoagrario, objp.essalud, objp.idregimenlaboral, objp.montoeventual,
        objp.numdiasvacaciones, objp.fechavacacion, objp.valorhoraextra, objp.salariobase, objp.validarcuenta, objp.observacion,
        objp.diasdescanso, objp.ultimoDiaMarcacion, objp.diasvacaciones, objp.diasdescansoeti, objp.Nfetrabajado, objp.Nfenotrabajado, objp.diapermisomedico,
        objp.horasmarrana, objp.costohorasmarrana, objp.importevacacionesvendidas, objp.diasvendidos, objp.montograti, objp.MontoCts
    )
    End Sub

    ' Método auxiliar para agregar un pago a la lista
    Private Sub AgregarPago(
    pagos As List(Of coControlPagosyDes),
    idPersona As Integer,
    importe As Decimal,
    idConceptoSueldo As Integer,
    tipoQuincena As Integer,
    Optional periodo As String = ""
)
        pagos.Add(New coControlPagosyDes With {
        .IdPersona = idPersona,
        .Importe = Math.Round(importe, 2),
        .IdConceptoSueldo = idConceptoSueldo,
        .TipoQuincena = tipoQuincena,
        .Periodo = periodo
    })
    End Sub


    ' Redondea hacia arriba al siguiente múltiplo de 0.10
    Private Function RedondearADecimaSuperior(valor As Decimal) As Decimal
        Return Math.Ceiling(valor * 10) / 10
    End Function

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles dtgListado.ClickCell
        If dtgListado.Rows.Count = 0 Then
            'msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If
        If e.Cell Is Nothing OrElse e.Cell.Row Is Nothing Then
            'msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If

        If e.Cell.Row.Index < 0 Then
            ' msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If
        Try
            Dim pagos As New List(Of coControlPagosyDes)
            Dim tieneEstado1 As Boolean = False
            If dtgListado.ActiveRow IsNot Nothing Then
                Try
                    tieneEstado1 = Convert.ToInt32(dtgListado.ActiveRow.Cells(dtgListado.ActiveRow.Cells.Count - 1).Value) = 1
                Catch ex As Exception
                    tieneEstado1 = False
                End Try
            End If
            If e.Cell IsNot Nothing AndAlso e.Cell.Row.Cells(0).Value IsNot Nothing Then
                selectedId = Convert.ToInt32(e.Cell.Row.Cells(0).Value)
                dtgListado.Refresh()
                dtgListado.UpdateData()
                dtgListado.Invalidate()
                Application.DoEvents() ' Forzar el procesamiento de eventos pendientes
            End If
            If e.Cell IsNot Nothing AndAlso e.Cell.Row.Cells(0).Value IsNot Nothing Then
                selectedId = Convert.ToInt32(e.Cell.Row.Cells(0).Value)
                e.Cell.Row.Appearance.BackColor = Color.LightBlue
                dtgListado.Refresh()
            End If


            If _tipopago = "PLANILLA" Then
                If _tipoperiodo = "MENSUAL" Then
                    Try
                        ' Limpiar datos previos
                        LimpiarTablasConceptos()
                        If dtgListado.Rows.Count > 0 Then
                            Dim activeRow = dtgListado.ActiveRow

                            If activeRow IsNot Nothing AndAlso activeRow.Cells(0).Value IsNot Nothing Then
                                id = Convert.ToInt32(activeRow.Cells(0).Value)

                                ' Consultar datos de pagos y descuentos
                                Dim obj2 As New coControlPagosyDes With {.idpago = idpago}
                                Dim objp As coControlPagosyDes = cn.Cn_ConsultarPagosYDes(obj2, id)

                                AsignarDatosEmpleado(activeRow)
                                horasregulares = Convert.ToDecimal(activeRow.Cells(3).Value)
                                horasextras = Convert.ToDecimal(activeRow.Cells(4).Value)

                                LlenarCamposCapacitador(objp)
                                periodo2 = objp.Periodo
                                Dim diasrestantes As Integer = 0
                                Dim totaldiasmes As Integer = objp.DiasAsistidos + objp.Nfenotrabajado + objp.Nfetrabajado + objp.diasdescanso + objp.diapermisomedico + objp.diasvacaciones + objp.DiasNoAsistidos
                                If totaldiasmes = objp.ultimoDiaMarcacion Then
                                    If objp.diasvacaciones = objp.ultimoDiaMarcacion Then
                                        objp.diasvacaciones = 30
                                    End If
                                End If
                                If objp.diasvacaciones <> 30 Then
                                        If objp.ultimoDiaMarcacion = 30 Then
                                            diasrestantes = 0
                                        End If
                                        If objp.ultimoDiaMarcacion > 30 Then
                                            diasrestantes = 30 - objp.ultimoDiaMarcacion
                                        End If
                                        If objp.ultimoDiaMarcacion < 30 Then
                                            diasrestantes = 30 - objp.ultimoDiaMarcacion
                                        End If

                                        If totaldiasmes = objp.ultimoDiaMarcacion Then
                                            If objp.diasdescanso > 4 Then
                                                objp.diasdescanso = 4
                                            Else
                                                objp.diasdescanso = 4
                                            End If
                                        End If
                                    End If
                                ' Monto salario base
                                Dim salarioDiario As Decimal = (objp.Salario + objp.bonoagrario) / 30
                                Dim costo As Decimal = 0D
                                If objp.IngresoBasico > 2000 Then
                                    costo = (salarioDiario * ((objp.DiasAsistidos + diasrestantes) + objp.Nfenotrabajado + (objp.Nfetrabajado) + objp.diasdescanso + objp.diapermisomedico + objp.diasvacaciones))
                                Else
                                    costo = (salarioDiario * ((objp.DiasAsistidos + diasrestantes) + objp.Nfenotrabajado + (objp.Nfetrabajado * 2) + objp.diasdescanso + objp.diapermisomedico + objp.diasvacaciones))
                                End If
                                Dim restante As Decimal = costo - (((objp.Salario - objp.Extrabono) + objp.bonoagrario))
                                Dim montosalario As Decimal
                                If costo >= (objp.salariobase + objp.bonoagrario) Then
                                    montosalario = ((objp.Salario - objp.Extrabono) + objp.bonoagrario)
                                Else
                                    montosalario = costo
                                End If

                                'Isaias
                                ' calculo de SALARIO
                                AgregarPago(pagos, id, Math.Round(montosalario, 2), 127, idpago, objp.Periodo)
                                ' calculo de BONO EXTRAORDINARIO
                                If restante > 0 Then
                                    AgregarPago(pagos, id, Math.Round(restante, 2), 130, idpago, objp.Periodo)
                                End If
                                'calculo de aportes empleador
                                Select Case objp.idsegurosocial
                                            ' calculo de ESSALUD 
                                    Case 236
                                        If id = 75 Then 'en el caso de walter rojas el importe essalud se saca con su salario base osea 10000
                                            AgregarPago(pagos, id, Math.Round((objp.IngresoBasico * objp.essalud), 2), 129, idpago)
                                        Else
                                            AgregarPago(pagos, id, Math.Round((objp.salariobase * objp.essalud), 2), 129, idpago)
                                        End If
                                            ' calculo de EPS
                                    Case 237
                                        If id = 75 Then 'en el caso de walter rojas el importe essalud se saca con su salario base osea 10000
                                            AgregarPago(pagos, id, Math.Round((objp.IngresoBasico * objp.essalud), 2), 133, idpago)
                                        Else
                                            AgregarPago(pagos, id, Math.Round((objp.salariobase * objp.essalud), 2), 133, idpago)
                                        End If
                                End Select
                                Select Case objp.idregimenp
                                    Case 1
                                        ' calculo de AFP PRIMA FLUJO
                                        AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 128, idpago)
                                    Case 2
                                        ' calculo de AFP PRIMA FLUJO
                                        AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 134, idpago)
                                    Case 3
                                        ' calculo de AFP HABITAT FLUJO
                                        AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 135, idpago)
                                    Case 4
                                        ' calculo de AFP INTEGRA FLUJO
                                        AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 136, idpago)
                                    Case 5
                                        ' calculo de AFP PROFUTURO FLUJO
                                        AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 137, idpago)
                                    Case 11
                                        ' calculo de AFP HABITAT MIXTA
                                        AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 140, idpago)
                                    Case 12
                                        ' calculo de AFP INTEGRA MIXTA
                                        AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 141, idpago)
                                    Case 13
                                        ' calculo de AFP PRIMA MIXTA
                                        AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 142, idpago)
                                    Case 14
                                        ' calculo de AFP PROFUTURO MIXTA
                                        AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 143, idpago)
                                End Select
                                ' Monto Asignación Familiar
                                If objp.AsignacionFamiliar <> 0 Then
                                    AgregarPago(pagos, id, Math.Round(objp.AsignacionFamiliar, 2), 131, idpago)
                                End If
                                'Monto de MONTO ESSALUD+VIDA
                                AgregarPago(pagos, id, objp.montoeventual, 144, idpago)
                                ' Monto hora extra
                                preciototalhorasextras = objp.valorhoraextra * (horasextras - objp.horasmarrana)
                                If preciototalhorasextras <> 0 Then
                                    AgregarPago(pagos, id, Math.Round(preciototalhorasextras, 2), 111, idpago)
                                End If
                                '   Monto horas extras marrana 160 en dev, test? 
                                preciotHEmarranas = objp.horasmarrana * objp.costohorasmarrana
                                If preciototalhorasextras <> 0 Then
                                    AgregarPago(pagos, id, Math.Round(preciotHEmarranas, 2), 160, idpago)
                                End If
                                'Ingresar importe de vacaciones pagadas 
                                If objp.importevacacionesvendidas > 0 Then
                                    AgregarPago(pagos, id, Math.Round(objp.importevacacionesvendidas, 2), 171, idpago)
                                End If
                                'Ingresar importe de GRATIFICACION
                                If objp.montograti > 0 Then
                                    AgregarPago(pagos, id, Math.Round(objp.montograti, 2), 172, idpago)
                                End If
                                'Ingresar importe de CTS
                                If objp.MontoCts > 0 Then
                                    AgregarPago(pagos, id, Math.Round(objp.MontoCts, 2), 166, idpago)
                                End If
                                ' Procesar todos los pagos de una vez
                                If _estadoaprobado = "PENDIENTE" AndAlso Not tieneEstado1 Then
                                    For Each pago As coControlPagosyDes In pagos
                                        cn.Cn_AgregamosDetallesueldo(pago)
                                    Next
                                End If
                                periodo2 = anio.ToString() & "/" & mes.ToString("00")
                                ListarTablas(id, idpago, periodo2)
                                SumarMontos(ds)
                                If _estadoaprobado = "PENDIENTE" AndAlso Not tieneEstado1 Then
                                    For Each pago As coControlPagosyDes In pagos
                                        InsertarSueldo()
                                    Next
                                End If

                            End If
                        End If
                    Catch ex As Exception
                        msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                        Return
                    End Try
                Else
                    Try
                        LimpiarTablasConceptos()
                        If dtgListado.Rows.Count > 0 Then
                            Dim activeRow = dtgListado.ActiveRow

                            If activeRow IsNot Nothing AndAlso activeRow.Cells(0).Value IsNot Nothing Then
                                id = Convert.ToInt32(activeRow.Cells(0).Value)

                                ' Consultar datos de pagos y descuentos
                                Dim obj2 As New coControlPagosyDes With {.idpago = idpago}
                                Dim objp As coControlPagosyDes = cn.Cn_ConsultarPagosYDes(obj2, id)

                                AsignarDatosEmpleado(activeRow)
                                lblnombreEmpleado.Text = activeRow.Cells(2).Value
                                lblSetPeriodo.Text = mostrarperiodo
                                horasregulares = Convert.ToDecimal(activeRow.Cells(3).Value)
                                horasextras = Convert.ToDecimal(activeRow.Cells(4).Value)
                                LlenarCamposCapacitador(objp)
                                periodo2 = objp.Periodo

                                Dim valorquicena2 As Integer = objp.ultimoDiaMarcacion - 15
                                Dim diasrestantes As Integer = 0
                                Dim totaldiasmes As Integer = objp.DiasAsistidos + objp.Nfenotrabajado + objp.Nfetrabajado + objp.diasdescanso + objp.diapermisomedico + objp.diasvacaciones + objp.DiasNoAsistidos
                                If _tipoperiodo = "QUINCENA 2" Then
                                    If totaldiasmes = valorquicena2 Then
                                        If objp.diasvacaciones = valorquicena2 Then
                                            objp.diasvacaciones = 15
                                        End If
                                    End If
                                    If objp.diasvacaciones <> 15 Then

                                        If valorquicena2 = 15 Then
                                            diasrestantes = 0
                                        End If
                                        If valorquicena2 > 15 Then
                                            diasrestantes = 15 - valorquicena2
                                        End If
                                        If valorquicena2 < 15 Then
                                            diasrestantes = 15 - valorquicena2
                                        End If

                                        If totaldiasmes = valorquicena2 Then
                                            If objp.diasdescanso > 2 Then
                                                objp.diasdescanso = 2
                                            Else
                                                objp.diasdescanso = 2
                                            End If
                                        End If
                                    End If
                                End If

                                If _tipoperiodo = "QUINCENA 1" Then
                                    If objp.diasvacaciones <> 15 Then
                                        If objp.diasdescanso <> 2 Then
                                            objp.diasdescanso = 2
                                        End If
                                    End If

                                End If


                                ' Monto salario base
                                Dim salarioDiario As Decimal = (objp.Salario + objp.bonoagrario) / 30
                                Dim costo As Decimal = 0D
                                If objp.IngresoBasico > 2000 Then
                                    costo = (salarioDiario * ((objp.DiasAsistidos + diasrestantes) + objp.Nfenotrabajado + (objp.Nfetrabajado) + objp.diasdescanso + objp.diapermisomedico + objp.diasvacaciones))
                                Else
                                    costo = (salarioDiario * ((objp.DiasAsistidos + diasrestantes) + objp.Nfenotrabajado + (objp.Nfetrabajado * 2) + objp.diasdescanso + objp.diapermisomedico + objp.diasvacaciones))
                                End If

                                Dim restante As Decimal = costo - (((objp.Salario - objp.Extrabono) + objp.bonoagrario) / 2)
                                Dim montosalario As Decimal

                                If costo >= (objp.salariobase + objp.bonoagrario) / 2 Then
                                    montosalario = ((objp.Salario - objp.Extrabono) + objp.bonoagrario) / 2
                                Else
                                    montosalario = costo
                                End If
                                'Isaias
                                ' calculo de SALARIO
                                AgregarPago(pagos, id, Math.Round(montosalario, 2), 127, idpago, objp.Periodo)
                                ' calculo de BONO EXTRAORDINARIO
                                If restante > 0 Then
                                    AgregarPago(pagos, id, Math.Round(restante, 2), 130, idpago, objp.Periodo)
                                End If
                                If _tipoperiodo = "QUINCENA 2" Then
                                    Select Case objp.idregimenp
                                        Case 1
                                            ' calculo de AFP PRIMA FLUJO
                                            AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 128, idpago)
                                        Case 2
                                            ' calculo de AFP PRIMA FLUJO
                                            AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 134, idpago)
                                        Case 3
                                            ' calculo de AFP HABITAT FLUJO
                                            AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 135, idpago)
                                        Case 4
                                            ' calculo de AFP INTEGRA FLUJO
                                            AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 136, idpago)
                                        Case 5
                                            ' calculo de AFP PROFUTURO FLUJO
                                            AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 137, idpago)
                                        Case 11
                                            ' calculo de AFP HABITAT MIXTA
                                            AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 140, idpago)
                                        Case 12
                                            ' calculo de AFP INTEGRA MIXTA
                                            AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 141, idpago)
                                        Case 13
                                            ' calculo de AFP PRIMA MIXTA
                                            AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 142, idpago)
                                        Case 14
                                            ' calculo de AFP PROFUTURO MIXTA
                                            AgregarPago(pagos, id, Math.Round(objp.salariobase * objp.valorsp, 2), 143, idpago)
                                    End Select

                                    Select Case objp.idsegurosocial
                                            ' calculo de ESSALUD 
                                        Case 236
                                            If id = 75 Then 'en el caso de walter rojas el importe essalud se saca con su salario base osea 10000
                                                AgregarPago(pagos, id, Math.Round((objp.IngresoBasico * objp.essalud), 2), 129, idpago)
                                            Else
                                                AgregarPago(pagos, id, Math.Round((objp.salariobase * objp.essalud), 2), 129, idpago)
                                            End If
                                            ' calculo de EPS
                                        Case 237
                                            If id = 75 Then 'en el caso de walter rojas el importe essalud se saca con su salario base osea 10000
                                                AgregarPago(pagos, id, Math.Round((objp.IngresoBasico * objp.essalud), 2), 133, idpago)
                                            Else
                                                AgregarPago(pagos, id, Math.Round((objp.salariobase * objp.essalud), 2), 133, idpago)
                                            End If
                                    End Select
                                    'Monto de MONTO ESSALUD+VIDA
                                    AgregarPago(pagos, id, Math.Round(objp.montoeventual, 2), 144, idpago)
                                End If
                                ' Monto Asignación Familiar
                                If objp.AsignacionFamiliar <> 0 Then
                                    AgregarPago(pagos, id, Math.Round(objp.AsignacionFamiliar / 2, 2), 131, idpago)
                                End If
                                ' Monto hora extra normal por plantel  id 111 dev y test
                                preciototalhorasextras = objp.valorhoraextra * (horasextras - objp.horasmarrana)
                                If preciototalhorasextras > 0 Then
                                    AgregarPago(pagos, id, Math.Round(preciototalhorasextras, 2), 111, idpago)
                                End If
                                '   Monto horas extras marrana 160 en dev, test? 
                                preciotHEmarranas = objp.horasmarrana * objp.costohorasmarrana
                                If preciotHEmarranas <> 0 Then
                                    AgregarPago(pagos, id, Math.Round(preciotHEmarranas, 2), 168, idpago)
                                End If
                                'Ingresar importe de vacaciones pagadas 
                                If objp.importevacacionesvendidas > 0 Then
                                    AgregarPago(pagos, id, Math.Round(objp.importevacacionesvendidas, 2), 171, idpago)
                                End If
                                'Ingresar importe de GRATIFICACION
                                If objp.montograti > 0 Then
                                    AgregarPago(pagos, id, Math.Round(objp.montograti, 2), 172, idpago)
                                End If
                                'Ingresar importe de CTS
                                If objp.MontoCts > 0 Then
                                    AgregarPago(pagos, id, Math.Round(objp.MontoCts, 2), 166, idpago)
                                End If
                                ' Procesar todos los pagos de una vez
                                If _estadoaprobado = "PENDIENTE" AndAlso Not tieneEstado1 Then
                                    For Each pago As coControlPagosyDes In pagos
                                        cn.Cn_AgregamosDetallesueldo(pago)
                                    Next
                                End If
                                periodo2 = anio.ToString() & "/" & mes.ToString("00")
                                ListarTablas(id, idpago, periodo2)
                                SumarMontos(ds)
                                If _estadoaprobado = "PENDIENTE" AndAlso Not tieneEstado1 Then
                                    For Each pago As coControlPagosyDes In pagos
                                        InsertarSueldo()
                                    Next
                                End If

                            End If
                        End If
                    Catch ex As Exception
                        'msj_advert("SELECCIONE_REGISTRO")
                        msj_advert("Ocurrió un error: " & ex.Message)
                    Return
                    End Try
                End If
            End If
            If _tipopago = "EVENTUAL" Then
                Try
                    ' Limpiar datos previos
                    dtIngreso.Clear()
                    If dtgListado.Rows.Count > 0 Then
                        Dim activeRow = dtgListado.ActiveRow
                        If activeRow IsNot Nothing AndAlso activeRow.Cells(0).Value IsNot Nothing Then
                            id = Convert.ToInt32(activeRow.Cells(0).Value)
                            AsignarDatosEmpleado(activeRow)
                            periodo2 = anio.ToString() & "/" & mes.ToString("00")
                            ListarTablas(id, idpago, periodo2)
                            SumarMontos(ds)
                            InsertarSueldo()
                            Dim diasLaboradosString As String = dtgListado.ActiveRow.Cells(6).Value
                            Dim horasextras As Decimal
                            horasextras = Convert.ToDecimal(activeRow.Cells(4).Value)
                            Dim diasLaborados As Integer = CInt(diasLaboradosString)
                            Dim obje As New coControlPagosyDes With {.idpago = idpago}
                            obje = cn.Cn_ConsultarPagosYDeseventual(obje, id)
                            lbdiasdescanso.Text = obje.diasdescanso
                            txtasis.Text = diasLaborados
                            txtremudiario.Text = obje.montoeventual
                            txtfalta.Text = obje.DiasNoAsistidos
                            txtobservacion.Text = obje.observacion
                            txtlosdiasdescanso.Text = obje.diasdescansoeti
                            txthorasmarrana.Text = obje.horasmarrana
                            'SALARIO BASE EVENTUAL
                            AgregarPago(pagos, id, Math.Round(obje.montoeventual * (diasLaborados + obje.diasdescanso), 2), 132, idpago)

                            ' Monto hora extra normal por plantel  id 111 dev y test
                            preciototalhorasextras = obje.valorhoraextra * (horasextras - obje.horasmarrana)
                            If preciototalhorasextras <> 0 Then
                                AgregarPago(pagos, id, Math.Round(preciototalhorasextras, 2), 111, idpago)
                            End If
                            '   Monto horas extras marrana 160 en dev, test? 
                            preciotHEmarranas = obje.horasmarrana * obje.costohorasmarrana
                            If preciotHEmarranas <> 0 Then
                                AgregarPago(pagos, id, Math.Round(preciotHEmarranas, 2), 168, idpago)
                            End If
                            ' Procesar todos los pagos de una vez
                            If _estadoaprobado = "PENDIENTE" AndAlso Not tieneEstado1 Then
                                For Each pago As coControlPagosyDes In pagos
                                    cn.Cn_AgregamosDetallesueldo(pago)
                                Next
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Error al llenar los datos: " & ex.Message)
                End Try
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    ' Método auxiliar para asignar y refrescar un grid si la tabla tiene datos
    Private Sub AsignarYRefrescarGrid(grid As UltraGrid, tabla As DataTable)
        grid.DataSource = Nothing
        If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
            grid.DataSource = tabla
            grid.Refresh()
        End If
    End Sub
    Sub ListarTablas(id As Integer, idpago As Integer, periodo As String)
        Try
            ds = cn.Cn_ListarTablasMaestrasTrabajadores(id, idpago, periodo).Copy
            ds.DataSetName = "tmp"
            If ds Is Nothing OrElse ds.Tables.Count = 0 Then
                If _tipopago = "PLANILLA" Then
                    MsgBox("No se encontraron datos para esta persona.", MsgBoxStyle.Information, "Información")
                End If
                Return
            End If

            If _tipopago = "PLANILLA" Then
                AsignarYRefrescarGrid(dtgListadoIngresoBase, ds.Tables(0))
                If ds.Tables.Count > 1 Then AsignarYRefrescarGrid(dtgListadoDescuentoBase, ds.Tables(1))
                If ds.Tables.Count > 2 Then AsignarYRefrescarGrid(dtgListadoIngresoExt, ds.Tables(2))
                If ds.Tables.Count > 3 Then AsignarYRefrescarGrid(dtgListadoDescuentoExt, ds.Tables(3))
                If ds.Tables.Count > 4 Then AsignarYRefrescarGrid(dtgaporteempleador, ds.Tables(4))
            ElseIf _tipopago = "EVENTUAL" Then
                AsignarYRefrescarGrid(dtgListadoIngresoBase, ds.Tables(0))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    ' Método auxiliar para sumar una columna "MONTO" de una tabla
    Private Function SumarColumnaMonto(tabla As DataTable) As Decimal
        Dim total As Decimal = 0
        If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
            For Each row As DataRow In tabla.Rows
                If Not IsDBNull(row("MONTO")) Then
                    total += Convert.ToDecimal(row("MONTO"))
                End If
            Next
        End If
        Return total
    End Function
    Private Sub SumarMontos(ds As DataSet)
        Dim totalingresobase As Decimal = 0
        Dim totaldescuentobase As Decimal = 0
        Dim totalingresoextra As Decimal = 0
        Dim totaldescuentoextra As Decimal = 0
        Dim totalaportaciones As Decimal = 0
        If ds Is Nothing Then Exit Sub
        If _tipopago = "PLANILLA" Then
            Try
                If ds.Tables.Count > 0 Then
                    totalingresobase = SumarColumnaMonto(ds.Tables(0))
                    lbtotalib.Text = totalingresobase.ToString("N2")
                Else
                    lbtotalib.Text = "0.00"
                End If
                If ds.Tables.Count > 1 Then
                    totaldescuentobase = SumarColumnaMonto(ds.Tables(1))
                    lbtotaldb.Text = totaldescuentobase.ToString("N2")
                Else
                    lbtotaldb.Text = "0.00"
                End If
                If ds.Tables.Count > 2 Then
                    totalingresoextra = SumarColumnaMonto(ds.Tables(2))
                    lbtotalie.Text = totalingresoextra.ToString("N2")
                Else
                    lbtotalie.Text = "0.00"
                End If
                If ds.Tables.Count > 3 Then
                    totaldescuentoextra = SumarColumnaMonto(ds.Tables(3))
                    lbtotalde.Text = totaldescuentoextra.ToString("N2")
                Else
                    lbtotalde.Text = "0.00"
                End If
                If ds.Tables.Count > 4 Then
                    totalaportaciones = SumarColumnaMonto(ds.Tables(4))
                    lbtotalae.Text = totalaportaciones.ToString("N2")
                Else
                    lbtotalae.Text = "0.00"
                End If
                Montototalingresobase = totalingresobase - totaldescuentobase
                Montototalingresoextra = totalingresoextra - totaldescuentoextra
                Dim p As Decimal = Montototalingresobase + Montototalingresoextra
                Dim Montototal As Double = CDbl(p).ToString(P_FormatoDecimales1)
                lbtotalbase.Text = Montototalingresobase.ToString("N2")
                lbtotalextra.Text = Montototalingresoextra.ToString("N2")
                txt_total_salario.Text = Montototal.ToString("N2")
            Catch ex As Exception
                MessageBox.Show("Error al sumar los montos: " & ex.Message)
            End Try
        ElseIf _tipopago = "EVENTUAL" Then
            Try
                If ds.Tables.Count > 0 Then
                    totalingresobase = SumarColumnaMonto(ds.Tables(0))
                    lbtotalib.Text = totalingresobase.ToString("N2")
                Else
                    lbtotalib.Text = "0.00"
                End If
                Montototalingresobase = totalingresobase
                lbtotalbase.Text = Montototalingresobase.ToString("N2")
                txt_total_salario.Text = totalingresobase.ToString("N2")
            Catch ex As Exception
                MessageBox.Show("Error al sumar los montos: " & ex.Message)
            End Try
        End If
    End Sub

    ' Método auxiliar para crear una tabla con las columnas estándar
    Private Function CrearTablaConceptos() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Descripción", GetType(String))
        dt.Columns.Add("Costo", GetType(Object))
        Return dt
    End Function
    Private Sub InicializarTablas()
        dtIngreso = CrearTablaConceptos()
        dtDescuento = CrearTablaConceptos()
        dtIngresoExtra = CrearTablaConceptos()
        dtDescuentoExtra = CrearTablaConceptos()
    End Sub


    Public Function LlenarCamposSueldoSinextraA() As Decimal
        Dim montoconseg = (sueldoquincena * Me.valordesp) / 2
        Return montoconseg
    End Function
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub
    Public Sub LlenarCamposSueldoSinextra(sueldoQ1 As Decimal, rol As String)
        Dim cn As New coControlPagosyDes
        Dim montoconseg = (sueldoquincena * Me.valordesp) / 2
        Dim montofamiliar = familiar / 2
        Dim totalremu = (sueldoquincena + montofamiliar)
        Dim totaldes = (montoconseg - 0)
        Dim montoneto = (totalremu - totaldes)
    End Sub
    Private Sub btnGuardarConcepto_Click(sender As Object, e As EventArgs)
        Dim mensaje As String = cn.Cn_RegConceptoSueldo(obj)
        If obj.Coderror <> 0 Then
            msj_advert(mensaje)
        Else
            msj_ok(mensaje)
        End If
    End Sub


    ' Método auxiliar para registrar un sueldo
    Private Sub RegistrarSueldo(sueldo As Decimal, tipoSueldo As String, Optional esEventual As Boolean = False)
        Dim objSueldo As New coControlPagosyDes With {
        .IdPersona = id,
        .Salario = sueldo,
        .Iduser = "1",
        .estado = "PENDIENTE",
        .TipoQuincena = idpago,
        .Periodo = periodo2,
        .tiposueldo = tipoSueldo
    }
        Dim resultado As String
        If esEventual Then
            resultado = cn.Cn_agregarsueldoeventual(objSueldo)
        Else
            resultado = cn.Cn_Consultaragregarsueldo(objSueldo)
        End If
        If Not String.IsNullOrEmpty(resultado) Then
            MsgBox("Error al agregar el sueldo: " & resultado, MsgBoxStyle.Critical, "Error")
        End If
    End Sub
    Public Sub InsertarSueldo()
        If _tipopago = "PLANILLA" Then
            Try
                If validarcuenta = 1 Then
                    If Montototalingresobase > 0 Then
                        RegistrarSueldo(Montototalingresobase + Montototalingresoextra, "SUELDO BASE")
                    End If
                Else
                    If Montototalingresobase > 0 Then
                        RegistrarSueldo(Montototalingresobase, "SUELDO BASE")
                    End If
                    If Montototalingresoextra >= 0 Then
                        RegistrarSueldo(Montototalingresoextra, "SUELDO EXTRA")
                    End If
                End If
                If _estadoaprobado = "PENDIENTE" AndAlso Montototalingresobase = 0 AndAlso montohorasextras = 0 Then

                End If
            Catch ex As Exception
                msj_advert("Error al procesar los sueldos: ")
            End Try
        ElseIf _tipopago = "EVENTUAL" Then
            Try
                If Montototalingresobase > 0 Then
                    RegistrarSueldo(Montototalingresobase, "SUELDO EVENTUAL", True)
                End If
            Catch ex As Exception
                MsgBox("Error al procesar los sueldos: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If

    End Sub



    Private Sub UltraGrid1_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles dtgaporteempleador.AfterCellUpdate
        If e.Cell.Column.Key = "Costo" Then
            e.Cell.Row.Update()
            dtgaporteempleador.UpdateData()
            ActualizarTotalAportaciones()
            dtgaporteempleador.Refresh()
        End If
    End Sub
    Private Sub ActualizarTotalAportaciones()
        Dim totalaportaciones As Decimal = 0
        Try
            For Each row As UltraGridRow In dtgaporteempleador.Rows
                If Not row.IsAddRow Then
                    Dim costo As Object = row.Cells("Costo").Value
                    If costo IsNot Nothing AndAlso IsNumeric(costo) Then
                        totalaportaciones += Convert.ToDecimal(costo)
                    End If
                End If
            Next
            lblTotalaportaciones.Text = "Total Aportaciones: " & totalaportaciones.ToString("C2")
            lblTotalaportaciones.Refresh()

        Catch ex As Exception
            MessageBox.Show("Error al actualizar el total: " & ex.Message)
        End Try
    End Sub
    Private Sub AgregarConcepto(tipo As String, tipoconcepto As Integer)
        If Not String.IsNullOrWhiteSpace(lblnombreEmpleado.Text) Then
            Dim f As New FrmAgregarConceptoSueldo(Me)
            f.Tipo = tipo
            f.Tipoconcepto = tipoconcepto
            f.id = id
            f.idpago = idpago
            f.Periodo = periodo2
            f._tipopago = _tipopago
            f.ShowDialog()
            SumarMontos(ds)
            InsertarSueldo()
        Else
            MessageBox.Show("Debe seleccionar un empleado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregaringresobase.Click
        If Not String.IsNullOrWhiteSpace(lblnombreEmpleado.Text) Then
            AgregarConcepto("SALARIO BASE", 0)
        Else
            msj_advert("Debe seleccionar un empleado")
        End If
    End Sub
    Private Sub btnAgregarDescuentoextra_Click(sender As Object, e As EventArgs) Handles btnAgregarDescuentoextra.Click
        If Not String.IsNullOrWhiteSpace(lblnombreEmpleado.Text) Then
            AgregarConcepto("DESCUENTO EXTRA", 3)
        Else
            msj_advert("Debe seleccionar un empleado")
        End If

    End Sub
    Private Sub btnagregaraporteempleador_Click(sender As Object, e As EventArgs) Handles btnagregaraporteempleador.Click
        If Not String.IsNullOrWhiteSpace(lblnombreEmpleado.Text) Then
            AgregarConcepto("APORTE EMPLEADOR", 4)
        Else
            msj_advert("Debe seleccionar un empleado")
        End If
    End Sub
    Private Sub btnAgregarSalarioExtra_Click(sender As Object, e As EventArgs) Handles btnAgregarIngresoExtra.Click
        If Not String.IsNullOrWhiteSpace(lblnombreEmpleado.Text) Then
            AgregarConcepto("SALARIO EXTRA", 1)
        Else
            msj_advert("Debe seleccionar un empleado")
        End If
    End Sub
    Private Sub btnAgregardescuentobase_Click(sender As Object, e As EventArgs) Handles btnAgregardescuentobase.Click
        If Not String.IsNullOrWhiteSpace(lblnombreEmpleado.Text) Then
            AgregarConcepto("DESCUENTO BASE", 2)
        Else
            msj_advert("Debe seleccionar un empleado")
        End If
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles Conceptos.Click
        Dim f As New AgregarConceptoPagos
        f.ShowDialog()
    End Sub

    Private Sub dtgListadoIngresoBase_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListadoIngresoBase.InitializeLayout
        If e.Layout.Bands(0).Columns.Count > 0 Then
            e.Layout.Bands(0).Columns(0).Hidden = True
            If _estadoaprobado = "APROBADO" Then
                e.Layout.Bands(0).Columns(3).Hidden = True
            End If
        End If
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next

        Try
            clsBasicas.Formato_Tablas_Grid(dtgListadoIngresoBase)
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "iddetallesueldo"
                .Columns(1).Header.Caption = "CONCEPTO"
                .Columns(2).Header.Caption = "MONTO"
                .Columns(3).Header.Caption = "ELIMINAR"
                .Columns(3).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(3).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(3).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns(3).CellClickAction = UltraWinGrid.CellClickAction.EditAndSelectText ' Para asegurar que el botón sea clickeable
                For Each columnns As UltraGridColumn In e.Layout.Bands(0).Columns
                    columnns.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                Next
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub dtgListadoIngresoBase_ClickCellButton(sender As Object, e As CellEventArgs) Handles dtgListadoIngresoBase.ClickCellButton
        If e.Cell.Column.Key = "ELIMINAR" Then
            Dim rowIndex As Integer = e.Cell.Row.Index
            If rowIndex >= 0 AndAlso rowIndex < ds.Tables(0).Rows.Count Then
                Dim idconcepto As String = ds.Tables(0).Rows(rowIndex)("iddetallesueldo").ToString()
                obj.iddetalleconcepto = idconcepto
                If _tipopago = "PLANILLA" Then
                    cn.Cn_EliminarConceptospagos(obj)
                    ds.Tables(0).Rows.RemoveAt(rowIndex)
                    ds.Tables(0).AcceptChanges()
                    dtgListadoIngresoBase.DataSource = ds.Tables(0)
                    dtgListadoIngresoBase.Refresh()
                    SumarMontos(ds)
                End If
                If _tipopago = "EVENTUAL" Then
                    cn.Cn_EliminarConceptospagoseventual(obj)
                    ds.Tables(0).Rows.RemoveAt(rowIndex)
                    ds.Tables(0).AcceptChanges()
                    dtgListadoIngresoBase.DataSource = ds.Tables(0)
                    dtgListadoIngresoBase.Refresh()
                    SumarMontos(ds)
                End If
            Else
                MessageBox.Show("Fila no válida para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        SumarMontos(ds)
        InsertarSueldo()

    End Sub

    Private Sub dtgListadoDescuentoBase_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListadoDescuentoBase.InitializeLayout
        If e.Layout.Bands(0).Columns.Count > 0 Then
            e.Layout.Bands(0).Columns(0).Hidden = True
            If _estadoaprobado = "APROBADO" Then
                e.Layout.Bands(0).Columns(3).Hidden = True
            End If
        End If
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListadoDescuentoBase)
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "iddetallesueldo"
                .Columns(1).Header.Caption = "CONCEPTO"
                .Columns(2).Header.Caption = "MONTO"
                .Columns(3).Header.Caption = "ELIMINAR"
                .Columns(3).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(3).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(3).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns(3).CellClickAction = UltraWinGrid.CellClickAction.EditAndSelectText ' Para asegurar que el botón sea clickeable
                For Each columnns As UltraGridColumn In e.Layout.Bands(0).Columns
                    columnns.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                Next
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub dtgListadoDescuentoBase_ClickCellButton(sender As Object, e As CellEventArgs) Handles dtgListadoDescuentoBase.ClickCellButton
        If e.Cell.Column.Key = "ELIMINAR" Then
            Dim rowIndex As Integer = e.Cell.Row.Index
            If rowIndex >= 0 AndAlso rowIndex < ds.Tables(1).Rows.Count Then
                Dim idconcepto As String = ds.Tables(1).Rows(rowIndex)("iddetallesueldo").ToString()
                obj.iddetalleconcepto = idconcepto
                cn.Cn_EliminarConceptospagos(obj)
                ds.Tables(1).Rows.RemoveAt(rowIndex)
                    ds.Tables(1).AcceptChanges()
                    dtgListadoDescuentoBase.DataSource = ds.Tables(1)
                    dtgListadoDescuentoBase.Refresh()
                    SumarMontos(ds)
                Else
                    MessageBox.Show("Fila no válida para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        SumarMontos(ds)
        InsertarSueldo()

    End Sub

    Private Sub dtgListadoIngresoExt_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListadoIngresoExt.InitializeLayout
        If e.Layout.Bands(0).Columns.Count > 0 Then
            e.Layout.Bands(0).Columns(0).Hidden = True
            If _estadoaprobado = "APROBADO" Then
                e.Layout.Bands(0).Columns(3).Hidden = True
            End If
        End If
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListadoIngresoExt)
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "iddetallesueldo"
                .Columns(1).Header.Caption = "CONCEPTO"
                .Columns(2).Header.Caption = "MONTO"
                .Columns(3).Header.Caption = "ELIMINAR"
                .Columns(3).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(3).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(3).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns(3).CellClickAction = UltraWinGrid.CellClickAction.EditAndSelectText ' Para asegurar que el botón sea clickeable
                For Each columnns As UltraGridColumn In e.Layout.Bands(0).Columns
                    columnns.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                Next
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try

    End Sub
    Private Sub dtgListadoIngresoExt_ClickCellButton(sender As Object, e As CellEventArgs) Handles dtgListadoIngresoExt.ClickCellButton
        If e.Cell.Column.Key = "ELIMINAR" Then
            Dim rowIndex As Integer = e.Cell.Row.Index
            If rowIndex >= 0 AndAlso rowIndex < ds.Tables(2).Rows.Count Then
                Dim idconcepto As String = ds.Tables(2).Rows(rowIndex)("iddetallesueldo").ToString()
                obj.iddetalleconcepto = idconcepto
                cn.Cn_EliminarConceptospagos(obj)
                ds.Tables(2).Rows.RemoveAt(rowIndex)
                ds.Tables(2).AcceptChanges()
                dtgListadoIngresoExt.DataSource = ds.Tables(2)
                dtgListadoIngresoExt.Refresh()
                SumarMontos(ds)
            Else
                MessageBox.Show("Fila no válida para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        SumarMontos(ds)
        InsertarSueldo()

    End Sub

    Private Sub dtgListadoDescuentoExt_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListadoDescuentoExt.InitializeLayout
        If e.Layout.Bands(0).Columns.Count > 0 Then
            e.Layout.Bands(0).Columns(0).Hidden = True
            If _estadoaprobado = "APROBADO" Then
                e.Layout.Bands(0).Columns(3).Hidden = True
            End If
        End If
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListadoDescuentoExt)
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "iddetallesueldo"
                .Columns(1).Header.Caption = "CONCEPTO"
                .Columns(2).Header.Caption = "MONTO"
                .Columns(3).Header.Caption = "ELIMINAR"
                .Columns(3).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(3).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(3).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns(3).CellClickAction = UltraWinGrid.CellClickAction.EditAndSelectText ' Para asegurar que el botón sea clickeable
                For Each columnns As UltraGridColumn In e.Layout.Bands(0).Columns
                    columnns.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                Next
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try

    End Sub
    Private Sub dtgListadoDescuentoExt_ClickCellButton(sender As Object, e As CellEventArgs) Handles dtgListadoDescuentoExt.ClickCellButton
        If e.Cell.Column.Key = "Eliminar" Then
            Dim rowIndex As Integer = e.Cell.Row.Index
            If rowIndex >= 0 AndAlso rowIndex < ds.Tables(3).Rows.Count Then
                Dim idconcepto As String = ds.Tables(3).Rows(rowIndex)("iddetallesueldo").ToString()
                obj.iddetalleconcepto = idconcepto
                cn.Cn_EliminarConceptospagos(obj)
                ds.Tables(3).Rows.RemoveAt(rowIndex)
                ds.Tables(3).AcceptChanges()
                dtgListadoDescuentoExt.DataSource = ds.Tables(3)
                dtgListadoDescuentoExt.Refresh()
                SumarMontos(ds)
            Else
                MessageBox.Show("Fila no válida para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        SumarMontos(ds)
        InsertarSueldo()

    End Sub

    Private Sub UltraGrid1_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgaporteempleador.InitializeLayout
        If e.Layout.Bands(0).Columns.Count > 0 Then
            e.Layout.Bands(0).Columns(0).Hidden = True
            If _estadoaprobado = "APROBADO" Then
                e.Layout.Bands(0).Columns(3).Hidden = True
            End If
        End If
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
        Try
            clsBasicas.Formato_Tablas_Grid(dtgaporteempleador)
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "iddetallesueldo"
                .Columns(1).Header.Caption = "CONCEPTO"
                .Columns(2).Header.Caption = "MONTO"
                .Columns(3).Header.Caption = "ELIMINAR"
                .Columns(3).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(3).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(3).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns(3).CellClickAction = UltraWinGrid.CellClickAction.EditAndSelectText ' Para asegurar que el botón sea clickeable
                For Each columnns As UltraGridColumn In e.Layout.Bands(0).Columns
                    columnns.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                Next
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub dtgaporteempleador_ClickCellButton(sender As Object, e As CellEventArgs) Handles dtgaporteempleador.ClickCellButton
        If e.Cell.Column.Key = "ELIMINAR" Then
            Dim rowIndex As Integer = e.Cell.Row.Index
            If rowIndex >= 0 AndAlso rowIndex < ds.Tables(4).Rows.Count Then
                Dim idconcepto As String = ds.Tables(4).Rows(rowIndex)("iddetallesueldo").ToString()
                obj.iddetalleconcepto = idconcepto
                cn.Cn_EliminarConceptospagos(obj)
                ds.Tables(4).Rows.RemoveAt(rowIndex)
                ds.Tables(4).AcceptChanges()
                dtgaporteempleador.DataSource = ds.Tables(4)
                dtgaporteempleador.Refresh()
                SumarMontos(ds)
            Else
                MessageBox.Show("Fila no válida para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        SumarMontos(ds)
        InsertarSueldo()
    End Sub
    Public Sub InsertarImportetotal()
        If _tipopago = "PLANILLA" Then
            Try
                Dim sueldoBase As New coControlPagosyDes With {
                .TipoQuincena = idpago,
                .Periodo = periodo2
            }
                Dim resultadoBase As String = cn.Cn_GenerarMontostotales(sueldoBase)
                If String.IsNullOrEmpty(resultadoBase) Then
                    MsgBox("Operación realizada correctamente: ", MsgBoxStyle.Information, "Éxito")
                    Me.Close()
                Else
                    MsgBox("" & resultadoBase, MsgBoxStyle.Exclamation, "Alerta")
                End If
            Catch ex As Exception
                MsgBox("" & ex.Message, MsgBoxStyle.Exclamation, "Alerta")
            End Try
        End If
        If _tipopago = "EVENTUAL" Then
            Try
                Dim sueldoBaseE As New coControlPagosyDes With {
                .TipoQuincena = idpago,
                .Periodo = periodo2
            }
                Dim resultadoBaseE As String = cn.Cn_GenerarMontostotaleseventual(sueldoBaseE)
                If String.IsNullOrEmpty(resultadoBaseE) Then
                    MsgBox("Operación realizada correctamente: ", MsgBoxStyle.Information, "Éxito")
                    Me.Close()
                Else
                    MsgBox("" & resultadoBaseE, MsgBoxStyle.Exclamation, "Alerta")
                End If
            Catch ex As Exception
                MsgBox("" & ex.Message, MsgBoxStyle.Exclamation, "Alerta")
            End Try
        End If
    End Sub
    Private Sub btnGuardarRrhhCtrlasist_Click(sender As Object, e As EventArgs) Handles btnGuardarRrhhCtrlasist.Click
        Dim totalBase As Decimal
        If Decimal.TryParse(lbtotalbase.Text, totalBase) AndAlso totalBase > 0 Then
            InsertarImportetotal()
            Dim formulario As FrmPrinIngresosyDescuentos = Application.OpenForms.OfType(Of FrmPrinIngresosyDescuentos).FirstOrDefault()
            formulario.ConsultarPagos()
        Else
            MsgBox("Primero verifique los ingresos de los trabajadores", MsgBoxStyle.Exclamation, "Alerta")
        End If
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim estado As String = dtgListado.ActiveRow.Cells(7).Value.ToString()
        ImprimirReporteTrabajador()
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
        Dim idpersona As Integer = activeRow.Cells(0).Value
        obj.IdPersona = idpersona
        obj.idpago = idpago
        dsCapacitacion = cn.Cn_ConsultarId(obj, tipoQuincena)
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_Boletadepago.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAjustarSueldos_Click(sender As Object, e As EventArgs) Handles btnAjustarSueldos.Click
        Try
            Dim f As New FrmVerSueldos
            f.idpago = idpago
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        If e.Layout.Bands.Count > 0 AndAlso e.Layout.Bands(0).Columns.Exists("Seleccionar") Then
            With e.Layout.Bands(0).Columns("Seleccionar")
                .Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Header.Caption = "✓"
                .Width = 30
                .CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                ' Agregar estas líneas
                .AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                .CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
            End With
        End If
        e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
    End Sub


End Class
