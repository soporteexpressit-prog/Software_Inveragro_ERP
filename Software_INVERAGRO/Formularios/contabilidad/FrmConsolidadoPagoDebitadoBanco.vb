Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports iText.Svg

Public Class FrmConsolidadoPagoDebitadoBanco
    Dim DtDetalle As New DataTable
    Dim CantidadRegistros As Integer
    Dim filasParaMostrarItf As List(Of Integer)
    Dim cn As New cnCtaPagar
    Private filaSeleccionadaDtDetalle As UltraGridRow = Nothing
    Private filaSeleccionadaDtPagosProgramados As UltraGridRow = Nothing

    Private Sub FrmConsolidadoPagoDebitadoBanco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializar()
        ListarBancos()
    End Sub
    Sub Inicializar()
        txtArchivo.Enabled = False
        txtTotalFavor.Enabled = False
        txtTotalItf.Enabled = False
        checkMostrarItf.Visible = False
        checkMostrarItf.Enabled = False
        txtTotalFavor.Text = "0.00"
    End Sub

    Sub ListarBancos()
        Dim cn As New cnBanco
        Dim tb As New DataTable
        tb = cn.Cn_Listar().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Banco"
        With cmbBanco
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarDebitado.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim indice As Integer = CInt(dtgListado.ActiveRow.Cells(0).Value.ToString)
                If (cmbBanco.Text = "BANCO DE CREDITO DEL PERU") Then
                    Dim f As New FrmMantDebitadoBCP()
                    PasarParametrosBCP(f, dtgListado.ActiveRow)
                    If f.ShowDialog() = DialogResult.OK Then
                        ActualizarFilaBCP(f, indice)
                        filasParaMostrarItf = ObtenerIndicesPorITFBCP(DtDetalle)
                        txtTotalItf.Text = SumarCargoAbonoItfPorIndicesBCP(DtDetalle, filasParaMostrarItf).ToString("N2")
                        txtTotalFavor.Text = ActualizarTotalFavorBcp().ToString("N2")
                    End If
                ElseIf (cmbBanco.Text = "CAJA PIURA") Then
                    Dim f As New FrmMantDebitadoCajaPiura()
                    PasarParametrosCajaPiura(f, dtgListado.ActiveRow)
                    If f.ShowDialog() = DialogResult.OK Then
                        ActualizarFilaCajaPiura(f, indice)
                        txtTotalItf.Text = SumarTodaColumnaPorNombre(DtDetalle, "ITF").ToString("N2") + SumarTodaColumnaPorNombre(DtDetalle, "ITF_").ToString("N2")
                        txtTotalFavor.Text = ActualizarTotalFavorCajaPiura().ToString("N2")
                    End If
                ElseIf (cmbBanco.Text = "BANCO BBVA") Then
                    Dim f As New FrmMantDebitadoBBVA
                    PasarParametrosBBVA(f, dtgListado.ActiveRow)
                    If f.ShowDialog() = DialogResult.OK Then
                        ActualizarFilaBBVA(f, indice)
                        txtTotalItf.Text = SumarValoresITFBBVA(DtDetalle).ToString("N2")
                        txtTotalFavor.Text = ActualizarTotalFavorBBVA().ToString("N2")
                    End If
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub PasarParametrosBCP(ByRef f As FrmMantDebitadoBCP, ByVal row As Infragistics.Win.UltraWinGrid.UltraGridRow)
        f.indice = CInt(row.Cells(0).Value.ToString)
        f._fechaProc = row.Cells(1).Value.ToString
        f._MedAt = row.Cells(3).Value.ToString
        f._SucAge = row.Cells(5).Value.ToString
        f._NumOperacion = row.Cells(6).Value.ToString
        f._Tipo = row.Cells(9).Value.ToString
        f._Descripcion = row.Cells(2).Value.ToString
        f._Lugar = row.Cells(4).Value.ToString
        f._CargoAbono = row.Cells(10).Value.ToString
        f._SaldoContable = row.Cells(11).Value.ToString
        f._Operacion = 1
    End Sub

    Private Sub PasarParametrosCajaPiura(ByRef f As FrmMantDebitadoCajaPiura, ByVal row As Infragistics.Win.UltraWinGrid.UltraGridRow)
        f.indice = CInt(row.Cells(0).Value.ToString)
        f._NrmDias = CInt(row.Cells(1).Value.ToString)
        f._Concepto = row.Cells(2).Value.ToString
        f._Deposito = row.Cells(3).Value.ToString
        f._Itf = row.Cells(4).Value.ToString
        f._Retiro = row.Cells(5).Value.ToString
        f._Itf_ = row.Cells(6).Value.ToString
        f._Orden = row.Cells(7).Value.ToString
        f._Saldo = row.Cells(8).Value.ToString
        f._Operacion = 1
    End Sub

    Private Sub PasarParametrosBBVA(ByRef f As FrmMantDebitadoBBVA, ByVal row As Infragistics.Win.UltraWinGrid.UltraGridRow)
        f.indice = CInt(row.Cells(0).Value.ToString)
        f._fechaOperacion = row.Cells(1).Value.ToString
        f._fechaValor = row.Cells(2).Value.ToString
        f._descripcionOficina = row.Cells(3).Value.ToString
        f._can = row.Cells(4).Value.ToString
        f._nOperacion = row.Cells(5).Value.ToString
        f._cargoAbono = row.Cells(6).Value.ToString
        f._itf = row.Cells(7).Value.ToString
        f._saldoContable = row.Cells(8).Value.ToString
        f._operacion = 1
    End Sub

    Private Sub ActualizarFilaBCP(ByRef f As FrmMantDebitadoBCP, ByVal indice As Integer)
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If CInt(row.Cells(0).Value) = indice Then
                row.Cells(1).Value = f._fechaProc
                row.Cells(2).Value = f._Descripcion
                row.Cells(3).Value = f._MedAt
                row.Cells(4).Value = f._Lugar
                row.Cells(5).Value = f._SucAge
                row.Cells(6).Value = f._NumOperacion
                row.Cells(9).Value = f._Tipo
                row.Cells(10).Value = f._CargoAbono
                row.Cells(11).Value = f._SaldoContable
                Exit For
            End If
        Next
    End Sub

    Private Sub ActualizarFilaCajaPiura(ByRef f As FrmMantDebitadoCajaPiura, ByVal indice As Integer)
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If CInt(row.Cells(0).Value) = indice Then
                row.Cells(1).Value = f._NrmDias
                row.Cells(2).Value = f._Concepto
                row.Cells(3).Value = f._Deposito
                row.Cells(4).Value = f._Itf
                row.Cells(5).Value = f._Retiro
                row.Cells(6).Value = f._Itf_
                row.Cells(7).Value = f._Orden
                row.Cells(8).Value = f._Saldo
                Exit For
            End If
        Next
    End Sub

    Private Sub ActualizarFilaBBVA(ByRef f As FrmMantDebitadoBBVA, ByVal indice As Integer)
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If CInt(row.Cells(0).Value) = indice Then
                row.Cells(1).Value = f._fechaOperacion
                row.Cells(2).Value = f._fechaValor
                row.Cells(3).Value = f._descripcionOficina
                row.Cells(4).Value = f._can
                row.Cells(5).Value = f._nOperacion
                row.Cells(6).Value = f._cargoAbono
                row.Cells(7).Value = f._itf
                row.Cells(8).Value = f._saldoContable
                Exit For
            End If
        Next
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregarDebitado.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                If cmbBanco.Text = "BANCO DE CREDITO DEL PERU" Then
                    Dim f As New FrmMantDebitadoBCP
                    If f.ShowDialog() = DialogResult.OK Then
                        AgregarFilaBCP(f)
                        filasParaMostrarItf = ObtenerIndicesPorITFBCP(DtDetalle)
                        txtTotalItf.Text = SumarCargoAbonoItfPorIndicesBCP(DtDetalle, filasParaMostrarItf).ToString("N2")
                        txtTotalFavor.Text = ActualizarTotalFavorBcp().ToString("N2")
                    End If
                ElseIf cmbBanco.Text = "CAJA PIURA" Then
                    Dim f As New FrmMantDebitadoCajaPiura
                    If f.ShowDialog() = DialogResult.OK Then
                        AgregarFilaCajaPiura(f)
                        txtTotalItf.Text = (SumarTodaColumnaPorNombre(DtDetalle, "ITF") + SumarTodaColumnaPorNombre(DtDetalle, "ITF_")).ToString("N2")
                        txtTotalFavor.Text = ActualizarTotalFavorCajaPiura().ToString("N2")
                    End If
                ElseIf cmbBanco.Text = "BANCO BBVA" Then
                    Dim f As New FrmMantDebitadoBBVA
                    If f.ShowDialog() = DialogResult.OK Then
                        AgregarFilaBBVA(f)
                        txtTotalItf.Text = SumarValoresITFBBVA(DtDetalle).ToString("N2")
                        txtTotalFavor.Text = ActualizarTotalFavorBBVA().ToString("N2")
                    End If
                End If
            Else
                msj_advert("La tabla debe contener como minimo un registro")
            End If
        Else
            msj_advert("Debe subir primero el archivo")
        End If
    End Sub

    Private Sub AgregarFilaBCP(ByRef f As FrmMantDebitadoBCP)
        InicializarTablaDetalleBCP()

        Dim nuevaFila As DataRow = DtDetalle.NewRow()
        nuevaFila("N°") = CantidadRegistros + 1
        nuevaFila("Fecha Proc.") = f._fechaProc
        nuevaFila("Descripción") = f._Descripcion
        nuevaFila("Med At*") = f._MedAt
        nuevaFila("Lugar") = f._Lugar
        nuevaFila("Suc-Age") = f._SucAge
        nuevaFila("Num Op") = f._NumOperacion
        nuevaFila("Hora") = ""
        nuevaFila("Origen") = ""
        nuevaFila("Tipo") = f._Tipo
        nuevaFila("Cargo/Abono") = f._CargoAbono
        nuevaFila("Saldo Contable") = f._SaldoContable

        DtDetalle.Rows.Add(nuevaFila)

        CantidadRegistros += 1
        dtgListado.DataSource = DtDetalle
        DtDetalle.AcceptChanges()
    End Sub

    Private Sub AgregarFilaCajaPiura(ByRef f As FrmMantDebitadoCajaPiura)
        InicializarTablaDetalleCajaPiura()

        Dim nuevaFila As DataRow = DtDetalle.NewRow()
        nuevaFila("N°") = CantidadRegistros + 1
        nuevaFila("Día") = f._NrmDias
        nuevaFila("Concepto") = f._Concepto
        nuevaFila("Depositos") = f._Deposito
        nuevaFila("ITF") = f._Itf
        nuevaFila("Retiros") = f._Retiro
        nuevaFila("ITF_") = f._Itf_
        nuevaFila("Orden") = f._Orden
        nuevaFila("Saldo") = f._Saldo

        DtDetalle.Rows.Add(nuevaFila)

        CantidadRegistros += 1
        dtgListado.DataSource = DtDetalle
        DtDetalle.AcceptChanges()
    End Sub

    Private Sub AgregarFilaBBVA(ByRef f As FrmMantDebitadoBBVA)
        InicializarTablaDetalleBBVA()

        Dim nuevaFila As DataRow = DtDetalle.NewRow()
        nuevaFila("N°") = CantidadRegistros + 1
        nuevaFila("Fecha Operación") = f._fechaOperacion
        nuevaFila("Fecha Valor") = f._fechaValor
        nuevaFila("Descripción - Oficina") = f._descripcionOficina
        nuevaFila("CAN") = f._can
        nuevaFila("N° Operación") = f._nOperacion
        nuevaFila("Cargo/Abono") = f._cargoAbono
        nuevaFila("ITF") = f._itf
        nuevaFila("Saldo Contable") = f._saldoContable

        DtDetalle.Rows.Add(nuevaFila)

        CantidadRegistros += 1
        dtgListado.DataSource = DtDetalle
        DtDetalle.AcceptChanges()
    End Sub

    Private Sub InicializarTablaDetalleBCP()
        If DtDetalle Is Nothing Then
            DtDetalle = New DataTable("DetalleDebitadoBCP")
        End If

        If DtDetalle.Columns.Count = 0 Then
            DtDetalle.Columns.Add("N°", GetType(String))
            DtDetalle.Columns.Add("Fecha Proc.", GetType(String))
            DtDetalle.Columns.Add("Descripción", GetType(String))
            DtDetalle.Columns.Add("Med At*", GetType(String))
            DtDetalle.Columns.Add("Lugar", GetType(String))
            DtDetalle.Columns.Add("Suc-Age", GetType(String))
            DtDetalle.Columns.Add("Num Op", GetType(String))
            DtDetalle.Columns.Add("Hora", GetType(String))
            DtDetalle.Columns.Add("Origen", GetType(String))
            DtDetalle.Columns.Add("Tipo", GetType(String))
            DtDetalle.Columns.Add("Cargo/Abono", GetType(String))
            DtDetalle.Columns.Add("Saldo Contable", GetType(String))
        End If
    End Sub

    Private Sub InicializarTablaDetalleCajaPiura()
        If DtDetalle Is Nothing Then
            DtDetalle = New DataTable("DetalleDebitadoCajaPiura")
        End If

        If DtDetalle.Columns.Count = 0 Then
            DtDetalle.Columns.Add("N°", GetType(String))
            DtDetalle.Columns.Add("Día", GetType(String))
            DtDetalle.Columns.Add("Concepto", GetType(String))
            DtDetalle.Columns.Add("Depositos", GetType(String))
            DtDetalle.Columns.Add("ITF", GetType(String))
            DtDetalle.Columns.Add("Retiros", GetType(String))
            DtDetalle.Columns.Add("ITF_", GetType(String))
            DtDetalle.Columns.Add("Orden", GetType(String))
            DtDetalle.Columns.Add("Saldo", GetType(String))
        End If
    End Sub

    Private Sub InicializarTablaDetalleBBVA()
        If DtDetalle Is Nothing Then
            DtDetalle = New DataTable("DetalleDebitadoBBVA")
        End If

        If DtDetalle.Columns.Count = 0 Then
            DtDetalle.Columns.Add("N°", GetType(String))
            DtDetalle.Columns.Add("Fecha Operación", GetType(String))
            DtDetalle.Columns.Add("Fecha Valor", GetType(String))
            DtDetalle.Columns.Add("Descripción - Oficina", GetType(String))
            DtDetalle.Columns.Add("CAN", GetType(String))
            DtDetalle.Columns.Add("N° Operación", GetType(String))
            DtDetalle.Columns.Add("Cargo/Abono", GetType(String))
            DtDetalle.Columns.Add("ITF", GetType(String))
            DtDetalle.Columns.Add("Saldo Contable", GetType(String))
        End If
    End Sub

    Private Sub FormatearTabla()
        DtDetalle.Clear()
        DtDetalle.Columns.Clear()
        dtgListado.DataSource = Nothing
        txtSaldoContable.Text = "0.00"
        txtTotalFavor.Text = "0.00"
        txtTotalItf.Text = "0.00"
    End Sub

    Private Sub checkMostrarItf_CheckedChanged(sender As Object, e As EventArgs) Handles checkMostrarItf.CheckedChanged
        Try
            If (dtgListado.Rows.Count > 0 AndAlso filasParaMostrarItf IsNot Nothing AndAlso filasParaMostrarItf.Count > 0) Then
                For Each indiceFila As Integer In filasParaMostrarItf
                    If indiceFila < dtgListado.Rows.Count Then
                        If checkMostrarItf.Checked Then
                            dtgListado.Rows(indiceFila).Hidden = False
                        Else
                            dtgListado.Rows(indiceFila).Hidden = True
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            clsBasicas.controlException("ERROR EN MOSTRAR ITF", ex)
        End Try
    End Sub

    Public Function SumarValoresITFBBVA(tabla As DataTable) As Decimal
        Dim sumaITF As Decimal = 0

        If tabla.Columns.Contains("ITF") Then
            For Each fila As DataRow In tabla.Rows
                If Not String.IsNullOrEmpty(fila("ITF").ToString().Trim()) Then
                    Dim valorITF As Decimal
                    If Decimal.TryParse(fila("ITF").ToString(), valorITF) Then
                        sumaITF += valorITF
                    End If
                End If
            Next
        End If

        Return sumaITF
    End Function

    Public Function ObtenerIndicesPorITFBCP(tabla As DataTable) As List(Of Integer)
        Dim indices As New List(Of Integer)

        If tabla.Columns.Contains("N°") AndAlso tabla.Columns.Contains("Tipo") Then
            For Each fila As DataRow In tabla.Rows
                If fila("Tipo").ToString().Trim() = "0909" Then
                    Dim numeroOperacion As Integer
                    If Integer.TryParse(fila("N°").ToString(), numeroOperacion) Then
                        indices.Add(numeroOperacion - 1)
                    End If
                End If
            Next
        End If

        Return indices
    End Function

    Private Sub txtSaldoContable_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSaldoContable.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub txtSaldoContable_TextChanged(sender As Object, e As EventArgs) Handles txtSaldoContable.TextChanged
        If String.IsNullOrWhiteSpace(txtSaldoContable.Text) OrElse txtSaldoContable.Text = "-" Then
            Return
        End If

        Dim cursorPosition As Integer = txtSaldoContable.SelectionStart
        Dim textoSinComas As String = txtSaldoContable.Text.Replace(",", "")
        Dim tieneDecimal As Boolean = textoSinComas.Contains(".")
        Dim parteDecimal As String = ""

        If tieneDecimal Then
            Dim partes() As String = textoSinComas.Split("."c)
            textoSinComas = partes(0)
            parteDecimal = "." & If(partes.Length > 1, partes(1), "")
        End If

        Dim parteEntera As Decimal
        If Decimal.TryParse(textoSinComas, parteEntera) Then
            txtSaldoContable.Text = parteEntera.ToString("#,##0") & parteDecimal
            txtSaldoContable.SelectionStart = cursorPosition + (txtSaldoContable.Text.Length - textoSinComas.Length)
        End If

        If cmbBanco.Text = "BANCO DE CREDITO DEL PERU" Then
            txtTotalFavor.Text = ActualizarTotalFavorBcp().ToString("N2")
        ElseIf cmbBanco.Text = "CAJA PIURA" Then
            txtTotalFavor.Text = ActualizarTotalFavorCajaPiura().ToString("N2")
        ElseIf cmbBanco.Text = "BANCO BBVA" Then
            txtTotalFavor.Text = ActualizarTotalFavorBBVA().ToString("N2")
        End If
    End Sub

    'BCP 
    Private Function ActualizarTotalFavorBcp() As Decimal
        Dim sueldoContable As Decimal = 0
        Dim totalFavor As Decimal = 0

        If Not String.IsNullOrWhiteSpace(txtSaldoContable.Text) Then
            Decimal.TryParse(txtSaldoContable.Text.Replace(",", ""), sueldoContable)
        End If

        If Not String.IsNullOrWhiteSpace(txtTotalFavor.Text) Then
            Decimal.TryParse(SumarTodaColumnaCargoAbonoBCP(dtgListado.DataSource), totalFavor)
        End If

        Dim sumaTotal As Decimal = sueldoContable + totalFavor

        Return sumaTotal
    End Function

    Public Function SumarTodaColumnaCargoAbonoBCP(tabla As DataTable) As Decimal
        Dim sumaTotal As Decimal = 0

        If tabla Is Nothing OrElse tabla.Columns.Count = 0 OrElse tabla.Rows.Count = 0 Then
            Return sumaTotal
        End If

        If tabla.Columns.Contains("Cargo/Abono") Then
            For Each fila As DataRow In tabla.Rows
                Dim valorCargoAbono As String = fila("Cargo/Abono").ToString().Trim()

                If valorCargoAbono.StartsWith(",") Then
                    Continue For
                End If

                If valorCargoAbono.EndsWith("-") Then
                    valorCargoAbono = valorCargoAbono.Replace("-", "").Trim()
                    Dim valorDecimal As Decimal
                    If Decimal.TryParse(valorCargoAbono, valorDecimal) Then
                        sumaTotal -= valorDecimal
                    End If
                Else
                    Dim valorDecimal As Decimal
                    If Decimal.TryParse(valorCargoAbono, valorDecimal) Then
                        sumaTotal += valorDecimal
                    End If
                End If
            Next
        End If

        Return sumaTotal
    End Function

    Public Function SumarCargoAbonoItfPorIndicesBCP(tabla As DataTable, indices As List(Of Integer)) As Decimal
        Dim sumaTotal As Decimal = 0

        If tabla.Columns.Contains("Cargo/Abono") Then
            For Each indice As Integer In indices
                Dim fila As DataRow = tabla.Rows(indice)

                Dim valorCargoAbono As Decimal
                If Decimal.TryParse(fila("Cargo/Abono").ToString(), valorCargoAbono) Then
                    sumaTotal += valorCargoAbono
                End If
            Next
        End If

        Return sumaTotal
    End Function

    'BBVA
    Private Function ActualizarTotalFavorBBVA() As Decimal
        Dim sueldoContable As Decimal = 0
        Dim totalFavor As Decimal = 0

        If Not String.IsNullOrWhiteSpace(txtSaldoContable.Text) Then
            Decimal.TryParse(txtSaldoContable.Text.Replace(",", ""), sueldoContable)
        End If

        If Not String.IsNullOrWhiteSpace(txtTotalFavor.Text) Then
            Dim totalCargoAbonoBBVA As Decimal = SumarTodaColumnaPorNombre(dtgListado.DataSource, "CARGO/ABONO")
            Dim totalCargoItfBBVA As Decimal = SumarTodaColumnaPorNombre(dtgListado.DataSource, "ITF")
            Decimal.TryParse(totalCargoAbonoBBVA - totalCargoItfBBVA, totalFavor)
        End If

        Dim sumaTotal As Decimal = sueldoContable + totalFavor

        Return sumaTotal
    End Function

    'CAJA PIURA
    Private Function ActualizarTotalFavorCajaPiura() As Decimal
        Dim sueldoContable As Decimal = 0
        Dim totalFavor As Decimal = 0

        If Not String.IsNullOrWhiteSpace(txtSaldoContable.Text) Then
            Decimal.TryParse(txtSaldoContable.Text.Replace(",", ""), sueldoContable)
        End If

        If Not String.IsNullOrWhiteSpace(txtTotalFavor.Text) Then
            Dim totalDeposito = SumarTodaColumnaPorNombre(dtgListado.DataSource, "Depositos")
            Dim totalItfDeposito = SumarTodaColumnaPorNombre(dtgListado.DataSource, "ITF")
            Dim totalRetiro = SumarTodaColumnaPorNombre(dtgListado.DataSource, "Retiros")
            Dim totalItfRetiro = SumarTodaColumnaPorNombre(dtgListado.DataSource, "ITF_")

            totalFavor = totalDeposito - totalItfDeposito - totalRetiro - totalItfRetiro
        End If

        Dim sumaTotal As Decimal = sueldoContable + totalFavor

        Return sumaTotal
    End Function

    Public Function SumarTodaColumnaPorNombre(tabla As DataTable, nombreColumna As String) As Decimal
        Dim sumaTotal As Decimal = 0

        If tabla Is Nothing OrElse tabla.Columns.Count = 0 OrElse tabla.Rows.Count = 0 Then
            Return sumaTotal
        End If

        If tabla.Columns.Contains(nombreColumna) Then
            For Each fila As DataRow In tabla.Rows
                Dim valorColumna As String = fila(nombreColumna).ToString().Trim()

                Dim valorDecimal As Decimal
                If Decimal.TryParse(valorColumna.Replace(",", "").Replace("-", "").Trim(), valorDecimal) Then
                    If valorColumna.StartsWith("-") Then
                        sumaTotal -= valorDecimal
                    Else
                        sumaTotal += valorDecimal
                    End If
                End If
            Next
        End If

        Return sumaTotal
    End Function

    Private Sub cmbBanco_ValueChanged(sender As Object, e As EventArgs) Handles cmbBanco.ValueChanged
        ListarPagosProgramados(cmbBanco.Value)
    End Sub
    Private Sub ListarPagosProgramados(idBanco As Integer)
        Dim obj As New coCtaPagar
        obj.IdBanco = idBanco
        dtgListadoPagosProgramados.DataSource = cn.Cn_ConsultarPrestamosPendientesxIdBanco(obj)
        clsBasicas.Formato_Tablas_Grid(dtgListadoPagosProgramados)
        dtgListadoPagosProgramados.DisplayLayout.Bands(0).Columns(0).Hidden = True
        dtgListadoPagosProgramados.DisplayLayout.Bands(0).Columns(1).Hidden = True
        dtgListadoPagosProgramados.DisplayLayout.Bands(0).Columns(2).Hidden = True
        dtgListadoPagosProgramados.DisplayLayout.Bands(0).Columns(3).Hidden = True
        dtgListadoPagosProgramados.DisplayLayout.Bands(0).Columns(4).Hidden = True
        dtgListadoPagosProgramados.DisplayLayout.Bands(0).Columns(5).Hidden = True
    End Sub

    Private Sub dtgListadoPagosProgramados_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListadoPagosProgramados.ClickCellButton
        If e.Cell.Column.Key = "Aplicar" Then

            If filaSeleccionadaDtDetalle IsNot Nothing AndAlso filaSeleccionadaDtPagosProgramados IsNot Nothing Then
                Dim idCuentaPagar As Integer = CInt(filaSeleccionadaDtPagosProgramados.Cells(0).Value.ToString().Trim())
                Dim filaSeleccionada As UltraGridRow = e.Cell.Row
                Dim idCuotaPagarSeleccionada As Integer = CInt(filaSeleccionada.Cells(0).Value.ToString())

                If idCuentaPagar = idCuotaPagarSeleccionada Then
                    Dim importePagoDebitado As String = filaSeleccionadaDtDetalle.Cells(10).Value.ToString().Trim()
                    Dim importePagoProgramado As String = filaSeleccionadaDtPagosProgramados.Cells(9).Value.ToString().Trim()

                    Dim esDebito As Boolean = importePagoDebitado.EndsWith("-")

                    If esDebito Then
                        importePagoDebitado = importePagoDebitado.Replace("-", "").Trim()
                    End If

                    If Not esDebito Then
                        msj_advert("El importe debito no tiene el signo '-', lo que indica que es un abono.")
                        Return
                    End If

                    Dim valorDebitado As Decimal
                    Dim valorProgramado As Decimal


                    If Decimal.TryParse(importePagoDebitado.Replace(",", ""), valorDebitado) AndAlso Decimal.TryParse(importePagoProgramado.Replace(",", ""), valorProgramado) Then
                        If valorDebitado = valorProgramado Then
                            Dim result As DialogResult = MessageBox.Show("¿Esta seguro de proceder con el registro del monto debitado por la suma de" & valorDebitado.ToString() & "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                            If result = DialogResult.Yes Then
                                Dim _mensaje As String = ""

                                Dim obj As New coCtaPagar
                                obj.Idctabancodestino = CInt(filaSeleccionadaDtPagosProgramados.Cells(4).Value.ToString())
                                obj.Total = Convert.ToDecimal(valorDebitado)
                                obj.Fpago = filaSeleccionadaDtPagosProgramados.Cells(5).Value.ToString()
                                obj.Idcuentapagar = CInt(filaSeleccionadaDtPagosProgramados.Cells(0).Value.ToString())
                                obj.Tipocambio = filaSeleccionadaDtPagosProgramados.Cells(1).Value.ToString()
                                obj.Idmoneda = CInt(filaSeleccionadaDtPagosProgramados.Cells(2).Value.ToString())
                                obj.Idcuota = CInt(filaSeleccionadaDtPagosProgramados.Cells(3).Value.ToString())
                                obj.Idusuario = VP_IdUser

                                _mensaje = cn.Cn_RegistrarMontoDebitadoCtaPagar(obj)
                                If (obj.Coderror = 0) Then
                                    msj_ok(_mensaje)
                                    filaSeleccionadaDtDetalle.Appearance.BackColor = Color.Gray
                                    filaSeleccionadaDtDetalle = Nothing
                                    ListarPagosProgramados(cmbBanco.Value)
                                Else
                                    msj_advert(_mensaje)
                                End If
                            Else
                                msj_advert("Proceso cancelado.")
                            End If
                        Else
                            msj_advert("No se puede ejecutar este proceso debido a que los montos no coinciden")
                        End If
                    Else
                        msj_advert("Error al convertir los importes a un formato numérico válido.")
                    End If
                Else
                    msj_advert("Por favor, clic la fila seleccionada.")
                    Return
                End If
            Else
                msj_advert("Por favor, seleccione una fila de cada tabla.")
            End If
        End If
    End Sub

    Private Sub dtgListadoPagosProgramados_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dtgListadoPagosProgramados.InitializeRow
        Dim column As UltraGridColumn = dtgListadoPagosProgramados.DisplayLayout.Bands(0).Columns("Aplicar")
        column.Style = ColumnStyle.Button
        column.ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
        If Not e.ReInitialize Then
            e.Row.Cells("Aplicar").Value = "Aplicar"
            e.Row.Cells("Aplicar").Appearance.TextHAlign = HAlign.Center
        End If
    End Sub

    Private Sub dtgListado_DoubleClickRow(sender As Object, e As UltraWinGrid.DoubleClickRowEventArgs) Handles dtgListado.DoubleClickRow
        If e.Row IsNot Nothing Then
            If e.Row.Appearance.BackColor = Color.Gray Then
                MessageBox.Show("Este registro ya ha sido procesado. Seleccione otro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If filaSeleccionadaDtDetalle IsNot Nothing Then
                filaSeleccionadaDtDetalle.Appearance.BackColor = Color.White
            End If

            filaSeleccionadaDtDetalle = e.Row
            filaSeleccionadaDtDetalle.Appearance.BackColor = Color.LightBlue
        End If
    End Sub

    Private Sub dtgListadoPagosProgramados_DoubleClickRow(sender As Object, e As UltraWinGrid.DoubleClickRowEventArgs) Handles dtgListadoPagosProgramados.DoubleClickRow
        If e.Row IsNot Nothing Then
            If filaSeleccionadaDtPagosProgramados IsNot Nothing Then
                filaSeleccionadaDtPagosProgramados.Appearance.BackColor = Color.White
            End If

            filaSeleccionadaDtPagosProgramados = e.Row
            filaSeleccionadaDtPagosProgramados.Appearance.BackColor = Color.LightBlue
        End If
    End Sub

    Private Sub btnSubirArchivo_Click(sender As Object, e As EventArgs) Handles btnSubirArchivo.Click
        Try
            If dtgListado.Rows.Count > 0 Then
                Dim result As DialogResult = MessageBox.Show("Ya existen datos cargados. ¿Está seguro que desea cargar un nuevo archivo? Se perderán los datos actuales.",
                                                            "Confirmar carga de nuevo archivo",
                                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If result = DialogResult.No Then
                    Return
                End If
            End If

            Dim openFileDialog As New OpenFileDialog()
            If (cmbBanco.Text = "CAJA PIURA") Then
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls"
                openFileDialog.Title = "Seleccionar archivo Excel"
            Else
                openFileDialog.Filter = "PDF Files | *.pdf| All files| *.*"
                openFileDialog.Title = "Seleccionar archivo PDF"
            End If

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim pdfPath As String = openFileDialog.FileName
                txtArchivo.Text = pdfPath
                Dim processor As New PdfExcelProcessor()

                Try
                    If (cmbBanco.Text = "BANCO DE CREDITO DEL PERU") Then
                        checkMostrarItf.Visible = True
                        checkMostrarItf.Checked = True
                        checkMostrarItf.Enabled = True
                        filasParaMostrarItf = New List(Of Integer)
                        FormatearTabla()

                        Dim tablaNueva As DataTable = processor.ProcesarPdfBCP(pdfPath)

                        If tablaNueva IsNot Nothing Then
                            InicializarTablaDetalleBCP()

                            For Each fila As DataRow In tablaNueva.Rows
                                Dim nuevaFila As DataRow = DtDetalle.NewRow()
                                nuevaFila.ItemArray = fila.ItemArray
                                DtDetalle.Rows.Add(nuevaFila)
                            Next

                            CantidadRegistros = tablaNueva.Rows.Count
                            filasParaMostrarItf = ObtenerIndicesPorITFBCP(tablaNueva)
                            dtgListado.DataSource = DtDetalle
                            DtDetalle.AcceptChanges()
                            txtTotalItf.Text = SumarCargoAbonoItfPorIndicesBCP(DtDetalle, filasParaMostrarItf).ToString("N2")
                            txtTotalFavor.Text = ActualizarTotalFavorBcp().ToString("N2")
                        Else
                            MessageBox.Show("No se encontraron datos válidos en el PDF.")
                        End If
                    ElseIf (cmbBanco.Text = "CAJA PIURA") Then
                        checkMostrarItf.Visible = False
                        checkMostrarItf.Enabled = False
                        FormatearTabla()

                        Dim tablaNueva As DataTable = processor.FormatearRegistroExcel(pdfPath)

                        If tablaNueva IsNot Nothing Then
                            InicializarTablaDetalleCajaPiura()

                            For Each fila As DataRow In tablaNueva.Rows
                                Dim nuevaFila As DataRow = DtDetalle.NewRow()
                                nuevaFila.ItemArray = fila.ItemArray
                                DtDetalle.Rows.Add(nuevaFila)
                            Next

                            CantidadRegistros = tablaNueva.Rows.Count
                            dtgListado.DataSource = DtDetalle
                            DtDetalle.AcceptChanges()
                            txtTotalItf.Text = (SumarTodaColumnaPorNombre(DtDetalle, "ITF") + SumarTodaColumnaPorNombre(DtDetalle, "ITF_")).ToString("N2")
                            txtTotalFavor.Text = ActualizarTotalFavorCajaPiura().ToString("N2")
                        Else
                            MessageBox.Show("No se encontraron datos válidos en el Excel.")
                        End If
                    ElseIf (cmbBanco.Text = "BBVA BANCO CONTINENTAL") Then
                        checkMostrarItf.Enabled = False
                        checkMostrarItf.Visible = False
                        FormatearTabla()

                        Dim tablaNueva As DataTable = processor.ProcesarPdfBBVA(pdfPath)

                        If tablaNueva IsNot Nothing Then
                            InicializarTablaDetalleBBVA()

                            For Each fila As DataRow In tablaNueva.Rows
                                Dim nuevaFila As DataRow = DtDetalle.NewRow()
                                nuevaFila.ItemArray = fila.ItemArray
                                DtDetalle.Rows.Add(nuevaFila)
                            Next

                            CantidadRegistros = tablaNueva.Rows.Count
                            dtgListado.DataSource = DtDetalle
                            DtDetalle.AcceptChanges()
                            txtTotalItf.Text = SumarValoresITFBBVA(tablaNueva).ToString("N2")
                            txtTotalFavor.Text = ActualizarTotalFavorBBVA().ToString("N2")
                        Else
                            MessageBox.Show("No se encontraron datos válidos en el PDF.")
                        End If
                    End If
                    clsBasicas.Formato_Tablas_Grid(dtgListado)
                Catch ex As Exception
                    MessageBox.Show("Error al procesar el Archivo: " & ex.Message)
                End Try
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class