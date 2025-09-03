Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Public Class FrmContratos
    Private ReadOnly _frmTrabajador As FrmTrabajador
    Dim cn As New cnDerechoHabientos
    Dim _mensajeBgWk As String = ""
    Dim _codtipodoc As Integer = 0
    Dim sueldoMinimo As Decimal
    Dim vidaMasVida As Decimal
    Dim bonificacionAgraria As Decimal
    Dim montoAgrario As Decimal
    Public Property esEdicion As Integer
    Public Property IdContrato As Integer
    Public Sub New(frmTrabajador As FrmTrabajador)
        InitializeComponent()
        _frmTrabajador = frmTrabajador
    End Sub
    Dim cn_item As New cnTrabajador
    Private Sub FrmContratos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarTipoSeguroPlanilla()
            cbxbono.Checked = True
            ListarTablas()
            ConsultarAgrario()
            If (esEdicion = 0) Then
            Else
            End If
            If (esEdicion <> 0) Then
                _frmTrabajador._operacion = 1
                If (esEdicion = 1) Then
                    Consultar2()
                    Refresh()
                Else
                    LimpiarCampos()
                End If
            Else
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub LimpiarCampos()
        txtCUSSP.Clear()
        txtnumcuenta_salariobase.Clear()
        txtsalariobase.Clear()
        txtmontoquincenal_sb.Clear()
        txtnumcuenta_se.Clear()
        txtmonto_extrabono_se.Clear()
        txtmontoquincenal_se.Clear()
        dtpFechaIngresoContrato.Value = DateTime.Now
        dtpFechaFincontrato.Value = DateTime.Now
    End Sub
    Sub ListarTipoSeguroPlanilla()
        Dim cn As New cnTipoSeguroPlanilla
        Dim tb As New DataTable
        tb = cn.Cn_Listar().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Tipo Seguro"
        With cbxregimenpensionario
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(4)(0)
            End If
        End With
    End Sub
    Sub ListarTablas()
        Try
            Dim ds As New DataSet
            ds = cn_item.Cn_ListarTablasMaestrasTrabajadores().Copy
            ds.DataSetName = "tmp"
            Dim nuevaFila As DataRow = ds.Tables(0).NewRow()
            Dim indice_tabla As Integer = 0
            indice_tabla = 2
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Ocupaciones"
            With cbxcargoocupacional
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(2)(0)
                End If
            End With
            indice_tabla = 4
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Entidades"
            With cbxbanco_sb
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With
            With cbxbanco_se
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With
            indice_tabla = 5
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Descripción"
            With cbxRegimenLaboral
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With
            indice_tabla = 6
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Descripción"
            With cbxfechapago
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(1)(0)
                End If
            End With
            indice_tabla = 7
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Forma de pago"
            With cbxtipopago_sb
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(3)(0)
                End If
            End With
            With cbxtipopago_se
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(3)(0)
                End If
            End With
            indice_tabla = 8
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Razon Social"
            With cbxsegurosocial
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With
            indice_tabla = 9
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Opciones"
            With cbxsegurosocial
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With
            indice_tabla = 11
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Descripción"
            With cbtipoContrato
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(1)(0)
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub Mantenimiento()
        Try
            If cbxregimenpensionario.Rows.Count >= 1 Then
                If cbxregimenpensionario.SelectedRow.Index >= 1 Then
                    If String.IsNullOrWhiteSpace(txtCUSSP.Text) Then
                        txtCUSSP.Focus()
                        msj_advert("Complete el campo CUSSP para guardar")
                        Return
                    End If
                ElseIf cbxregimenpensionario.SelectedRow.Index = 0 Then
                    txtCUSSP.Text = Nothing
                End If
                If dtpFechaIngresoContrato.Value >= dtpFechaFincontrato.Value Then
                    msj_advert("La fecha 'Inicio' debe ser anterior a la fecha 'Fin'.")
                    Return
                End If
                If String.IsNullOrWhiteSpace(txtnumcuenta_salariobase.Text) Then
                    txtnumcuenta_salariobase.Focus()
                    msj_advert("Ingrese un numero de cuenta")
                    Return
                End If
                If String.IsNullOrWhiteSpace(txtsalariobase.Text) Then
                    txtsalariobase.Focus()
                    msj_advert("Ingrese salario base")
                    Return
                End If
            End If
            Dim obj As New coTrabajador
            obj.Operacion = esEdicion
            obj.IdPersona = _frmTrabajador._Codigo
            obj.idcontrato = IdContrato
            obj.CUSSP = txtCUSSP.Text
            obj.IdUsuario = VariablesGlobales.VP_IdUser
            obj.IdTipoSeguroPlanilla = cbxregimenpensionario.Value
            obj.EstadoContrato = "ACTIVO"
            'Contrato
            obj.Idtiporegistrosunat = cbtipoContrato.Value
            obj.idRegimenLaboral = cbxRegimenLaboral.Value
            obj.idRegimenPnnsionario = cbxregimenpensionario.Value
            obj.idSeguroSocial = cbxsegurosocial.Value
            obj.FechaIngreso = dtpFechaIngresoContrato.Value
            obj.FechaFinContrato = dtpFechaFincontrato.Value
            obj.FechaRegPensionario = dtpFechaRegPensionario.Value
            obj.IdCargoocupacional = cbxcargoocupacional.Value
            obj.FechaSeguroSocial = dtpFechaSeguroSocial.Value
            obj.idfrecuenciadepago = cbxfechapago.Value
            If String.IsNullOrEmpty(txtmonto_extrabono_se.Text) Then
                obj.ExtraBono = 0
            Else
                obj.ExtraBono = Convert.ToDecimal(txtmonto_extrabono_se.Text)
            End If
            Dim salarioBase As Decimal
            If Decimal.TryParse(txtsalariobase.Text, salarioBase) Then
                obj.Remuneracion = salarioBase
            Else
                MessageBox.Show("Por favor, ingrese un valor numérico válido para el salario.")
            End If
            obj.NroCuenta = txtnumcuenta_salariobase.Text
            obj.idBanco = cbxbanco_sb.Value
            obj.Tipocuenta = "SALARIOBASE"
            obj.idFormadePagoextra = cbxtipopago_se.Value
            obj.idFormadePago = cbxtipopago_sb.Value
            obj.idBancoextra = cbxbanco_se.Value
            obj.NroCuentaextra = txtnumcuenta_se.Text
            obj.Tipocuentaextra = "SALARIOEXTRA"
            obj.TipoPagoextra = cbxtipopago_se.Value
            obj.sibono = If(cbxbono.Checked, 1, 0)
            _mensajeBgWk = cn_item.Cn_MantenimientoContrato(obj)
            If obj.Coderror = 0 Then
                msj_ok(_mensajeBgWk)
                _frmTrabajador.dtg_listadocontratos.Refresh()
                _frmTrabajador.contadorClicsGuardar += 2
                Close()
            Else
                msj_advert(_mensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub ConsultarAgrario()
        Dim cn As New cnTrabajador
        Dim tb As DataTable = cn.Cn_Consultaragrario().Copy
        tb.TableName = "tmp"
        If tb.Rows.Count > 0 Then
            sueldominimo = Convert.ToDecimal(tb.Rows(0).Item("Sueldo_Minimo_Valor"))
            vidaMasVida = Convert.ToDecimal(tb.Rows(0).Item("Vida_Mas_Vida_Valor"))
            Dim asignacionFamiliar As Decimal = Convert.ToDecimal(tb.Rows(0).Item("Asignacion_Familiar_Valor"))
            bonificacionAgraria = Convert.ToDecimal(tb.Rows(0).Item("Bonificacion_Agraria_Valor"))
            Dim esSalud As Decimal = Convert.ToDecimal(tb.Rows(0).Item("EsSalud_Valor"))
            montoAgrario = Convert.ToDecimal(tb.Rows(0).Item("montoagrario"))
        Else
            MessageBox.Show("No se encontró ningún registro con el código especificado.")
        End If
    End Sub




    Sub Consultar2()
        Dim obj As New coTrabajador
        Dim cn As New cnTrabajador
        obj.IdPersona = _frmTrabajador._Codigo
        obj.idcontrato = IdContrato
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarxCodigo(obj).Copy
        tb.TableName = "tmp"
        If tb.Rows.Count > 0 Then
            With tb.Rows(0)
                txtCUSSP.Text = .Item(27).ToString()
            End With
            Dim tbCuentaBanco As DataTable = cn.Cn_ObtenerCuentaBancoPorIdPersona(obj)
            If tbCuentaBanco.Rows.Count > 0 Then
                With tbCuentaBanco.Rows(0)
                    If .Item("numCuenta") IsNot DBNull.Value Then
                        txtnumcuenta_salariobase.Text = .Item("numCuenta").ToString()
                        cbxtipopago_sb.Text = .Item("formapago").ToString()
                    Else
                        txtnumcuenta_salariobase.Text = "0"
                    End If
                    cbxbanco_sb.Text = .Item("nombrebanco").ToString()
                    cbxtipopago_sb.Text = .Item("formapago").ToString()
                End With
                If tbCuentaBanco.Rows.Count > 1 Then
                    With tbCuentaBanco.Rows(1)
                        If .Item("numCuenta") IsNot DBNull.Value Then
                            txtnumcuenta_se.Text = .Item("numCuenta").ToString()
                            cbxtipopago_se.Text = .Item("formapago").ToString()
                        Else
                            txtnumcuenta_se.Text = "0"
                        End If
                        cbxbanco_se.Text = If(.Item("nombrebanco") IsNot DBNull.Value, .Item("nombrebanco").ToString(), "")
                        cbxtipopago_se.Text = If(.Item("formapago") IsNot DBNull.Value, .Item("formapago").ToString(), "")
                    End With
                End If
            Else
            End If
            Dim tbContrato As DataTable = cn.Cc_ConsultarxCodigoContrato(obj)
            If tbContrato.Rows.Count > 0 Then
                With tbContrato.Rows(0)
                    dtpFechaIngresoContrato.Text = .Item("fechainiciocontrato").ToString()
                    dtpFechaFincontrato.Text = .Item("fechafincontrato").ToString()
                    If .Item("salariobase") IsNot DBNull.Value Then
                        txtsalariobase.Text = .Item("salariobase").ToString()
                        txtmontoquincenal_sb.Text = .Item("salariobase").ToString() / 2
                    Else
                        txtsalariobase.Text = "0"
                        txtmontoquincenal_sb.Text = "0"
                    End If
                    If .Item("salarioreal") IsNot DBNull.Value Then
                        txtmonto_extrabono_se.Text = .Item("salarioreal").ToString()
                        txtmontoquincenal_se.Text = .Item("salarioreal").ToString() / 2
                    Else
                        txtmonto_extrabono_se.Text = "0"
                        txtmontoquincenal_se.Text = "0"
                    End If
                    obj.EstadoContrato = .Item("estado").ToString()
                    If obj.EstadoContrato = "INACTIVO" Then
                        btnGuardarmodelu.Enabled = False
                    End If
                    cbxRegimenLaboral.Value = .Item("idRegimenLaboral").ToString()
                    cbxregimenpensionario.Value = .Item("idRegimenPnnsionario").ToString()
                    cbxsegurosocial.Value = .Item("idSeguroSocial").ToString()
                    cbtipoContrato.Value = .Item("idTipoContrato").ToString()
                    cbxfechapago.Value = .Item("idfrecuenciadepago").ToString()
                    dtpFechaRegPensionario.Text = .Item("fRegimenpensionario").ToString()
                    dtpFechaSeguroSocial.Text = .Item("fSeguroSocial").ToString()
                    Dim bono As Integer = Convert.ToInt32(.Item("csbono"))
                    cbxbono.Checked = (bono = 1)
                End With
            Else
            End If
        Else
            MessageBox.Show("No se encontró ningún registro con el código especificado.")
        End If
    End Sub
    Private Sub cbxtiposerguro_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cbxregimenpensionario.InitializeLayout
        e.Layout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        e.Layout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
        For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In e.Layout.Bands(0).Columns
            col.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.None
        Next
        e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False
        e.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select
    End Sub
    Private Sub cbxregimenpensionario_ValueChanged(sender As Object, e As EventArgs) Handles cbxregimenpensionario.ValueChanged
        Debug.Print("Evento ValueChanged ejecutado")
        Dim selectedRow = cbxregimenpensionario.SelectedRow
        If selectedRow IsNot Nothing AndAlso selectedRow.Index = 0 Then
            txtCUSSP.Enabled = False
            txtCUSSP.Text = Nothing
        Else
            txtCUSSP.Enabled = True
        End If
    End Sub
    Private Sub btnGuardarmodelu_Click(sender As Object, e As EventArgs) Handles btnGuardarmodelu.Click
        Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que deseas continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Mantenimiento()
        End If
    End Sub
    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Dispose()
    End Sub

    Private Sub txtCUSSP_TextChanged(sender As Object, e As EventArgs) Handles txtCUSSP.TextChanged
        Dim cursorPosition As Integer = txtCUSSP.SelectionStart
        txtCUSSP.Text = New String(txtCUSSP.Text.Where(Function(c) Char.IsLetterOrDigit(c)).ToArray())
        txtCUSSP.SelectionStart = Math.Min(cursorPosition, txtCUSSP.Text.Length)
    End Sub

    Private Sub txtSalarioBase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsalariobase.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub
    Private Sub txtmonto_extrabono_se_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto_extrabono_se.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub
    Private Sub txtnumcuenta_salariobase_TextChanged(sender As Object, e As EventArgs) Handles txtnumcuenta_salariobase.TextChanged
    End Sub
    Private Sub txtmonto_extrabono_se_TextChanged(sender As Object, e As EventArgs) Handles txtmonto_extrabono_se.TextChanged
        Dim salarioextra As Decimal
        If Decimal.TryParse(txtmonto_extrabono_se.Text, salarioextra) Then
            txtmontoquincenal_se.Text = (salarioextra / 2).ToString("F2") ' Formato con dos decimales
        Else
            txtmontoquincenal_se.Text = String.Empty
        End If
    End Sub
    Private Sub txtsalariobase_TextChanged(sender As Object, e As EventArgs) Handles txtsalariobase.TextChanged
        Dim salarioBase As Decimal
        If Decimal.TryParse(txtsalariobase.Text, salarioBase) Then
            txtmontoquincenal_sb.Text = (salarioBase / 2).ToString("F2") ' Formato con dos decimales
        Else
            txtmontoquincenal_sb.Text = String.Empty
        End If
    End Sub
    Private Sub cbxfechapago_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxfechapago.InitializeLayout
        e.Layout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        e.Layout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
        For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In e.Layout.Bands(0).Columns
            col.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.None
        Next
        e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False
        e.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select
    End Sub
    Private Sub cbxRegimenLaboral_ValueChanged(sender As Object, e As EventArgs) Handles cbxRegimenLaboral.ValueChanged
        Dim selectedRow = cbxRegimenLaboral.SelectedRow
        If cbxbono.Checked Then
            ConsultarAgrario()
            agrarioporcentaje.Text = bonificacionAgraria
            agrariosoles.Text = montoAgrario
        Else
            ConsultarAgrario()
            agrarioporcentaje.Text = 0
            agrariosoles.Text = 0
            TextBox3.Text = 0
        End If
        cbxfechapago_ValueChanged(Nothing, EventArgs.Empty)
    End Sub
    Private Sub cbxfechapago_ValueChanged(sender As Object, e As EventArgs) Handles cbxfechapago.ValueChanged
        Debug.Print("Evento ValueChanged ejecutado")
        Dim salarioBase As Decimal
        Dim salarioextra As Decimal
        Dim selectedRow = cbxfechapago.SelectedRow
        If selectedRow IsNot Nothing AndAlso selectedRow.Index = 0 Then
            labelquincelaextra.Text = "Monto Mensual:"
            labelquincelabase.Text = "Monto Mensual:"
            If Decimal.TryParse(txtsalariobase.Text, salarioBase) Then
                txtmontoquincenal_sb.Text = (salarioBase).ToString("F2")
            Else
                txtmontoquincenal_sb.Text = String.Empty
            End If
            If Decimal.TryParse(txtmonto_extrabono_se.Text, salarioextra) Then
                txtmontoquincenal_se.Text = (salarioextra).ToString("F2")
            Else
                txtmontoquincenal_se.Text = String.Empty
            End If
            TextBox3.Text = agrariosoles.Text
        ElseIf selectedRow IsNot Nothing AndAlso selectedRow.Index = 1 Then
            labelquincelabase.Text = "Monto Quincenal:"
            labelquincelaextra.Text = "Monto Quincenal:"
            If Decimal.TryParse(txtsalariobase.Text, salarioBase) Then
                txtmontoquincenal_sb.Text = (salarioBase / 2).ToString("F2")
            Else
                txtmontoquincenal_sb.Text = String.Empty
            End If
            If Decimal.TryParse(txtmonto_extrabono_se.Text, salarioextra) Then
                txtmontoquincenal_se.Text = (salarioextra / 2).ToString("F2")
            Else
                txtmontoquincenal_se.Text = String.Empty
            End If
            TextBox3.Text = agrariosoles.Text / 2
        ElseIf selectedRow IsNot Nothing AndAlso selectedRow.Index = 2 Then
            labelquincelabase.Text = "Monto Semanal:"
            labelquincelaextra.Text = "Monto Semanal:"
            If Decimal.TryParse(txtsalariobase.Text, salarioBase) Then
                txtmontoquincenal_sb.Text = (salarioBase / 4).ToString("F2")
            Else
                txtmontoquincenal_sb.Text = String.Empty
            End If
            If Decimal.TryParse(txtmonto_extrabono_se.Text, salarioextra) Then
                txtmontoquincenal_se.Text = (salarioextra / 4).ToString("F2")
                txtmontoquincenal_se.Text = String.Empty
            End If
            TextBox3.Text = agrariosoles.Text / 4
        ElseIf selectedRow IsNot Nothing AndAlso selectedRow.Index = 3 Then
            labelquincelabase.Text = "Monto Diario:"
            labelquincelaextra.Text = "Monto Diario:"
            If Decimal.TryParse(txtsalariobase.Text, salarioBase) Then
                txtmontoquincenal_sb.Text = (salarioBase / 30).ToString("F2")
            Else
                txtmontoquincenal_sb.Text = String.Empty
            End If
            If Decimal.TryParse(txtmonto_extrabono_se.Text, salarioextra) Then
                txtmontoquincenal_se.Text = (salarioextra / 30).ToString("F2")
            Else
                txtmontoquincenal_se.Text = String.Empty
            End If
            TextBox3.Text = agrariosoles.Text / 30
        End If
    End Sub

    Private Sub cbxtipopago_sb_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxtipopago_sb.InitializeLayout
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
    End Sub

    Private Sub cbxtipopago_se_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxtipopago_se.InitializeLayout
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
    End Sub

    Private Sub cbxRegimenLaboral_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cbxRegimenLaboral.InitializeLayout

    End Sub

    Private Sub cbxbono_CheckedChanged(sender As Object, e As EventArgs) Handles cbxbono.CheckedChanged
        If cbxbono.Checked Then
            ConsultarAgrario()
            agrarioporcentaje.Text = bonificacionAgraria
            agrariosoles.Text = montoAgrario
        Else
            ConsultarAgrario()
            agrarioporcentaje.Text = 0
            agrariosoles.Text = 0
            TextBox3.Text = 0
        End If
        cbxfechapago_ValueChanged(Nothing, EventArgs.Empty)
    End Sub
End Class