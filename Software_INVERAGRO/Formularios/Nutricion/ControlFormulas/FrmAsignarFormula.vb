Imports System.Windows
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmAsignarFormula
    Dim cn As New cnControlFormulacion
    Dim listaIdsInsumos As New List(Of Integer)
    Dim _CodigoAsignadoNucleo As Integer = 0
    Dim _NombreAsignadoNucleo As String = ""
    Dim _TipoAsignadoNucleo As String = ""
    Dim idNucleo As Integer = 0
    Dim mombreRacion As String
    Dim listaDiferencia As List(Of Integer)
    Public DtDetalleNucleo As New DataTable("TempDetNucleo")
    Public listaIdsInsumosFormula As New List(Of Integer)
    Public DtDetalle As New DataTable("TempDetFormula")
    Public SelectedInsumos As New HashSet(Of Integer)
    Public idFormula As Integer = 0

    Private Sub FrmRegistrarFormula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            CargarTablaDetalleFormulaActual()
            CargarTablaDetalleInsumosNucleo()
            ListarRaciones()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarRaciones()
        Dim obj As New coControlFormulacion With {
            .Codigo = idFormula
        }

        dtgListadoRacionesFormula.DataSource = cn.Cn_ObtenerRacionesxFormulaBase(obj)
        dtgListadoRacionesFormula.DisplayLayout.Bands(0).Columns(0).Hidden = True
        clsBasicas.Formato_Tablas_Grid(dtgListadoRacionesFormula)
        clsBasicas.Filtrar_Tabla(dtgListadoRacionesFormula, False)
        clsBasicas.Colorear_SegunValor(dtgListadoRacionesFormula, Color.Green, Color.White, "ASIGNADO", 2)
        clsBasicas.Colorear_SegunValor(dtgListadoRacionesFormula, Color.Orange, Color.White, "POR ASIGNAR", 2)
    End Sub

    Sub Inicializar()
        Me.Width = 1440
        Me.CenterToScreen()
        btnGuardarAsignacion.Enabled = False
        btnCancelar.Enabled = False
        btnAsignarInsumo.Enabled = False
        btnAsignarNucleo.Enabled = False
        btnVisualizarAsignacion.Enabled = False
        txtPreparacion.Text = 5
        txtPreparacion.Enabled = False
        'btnAsignarPlus.Enabled = False
    End Sub

    Sub CargarTablaDetalleFormulaActual()
        DtDetalle = New DataTable("TempDetFormula")
        DtDetalle.Columns.Add("etiqueta", GetType(String))
        DtDetalle.Columns.Add("codprod", GetType(Integer))
        DtDetalle.Columns.Add("producto", GetType(String))
        DtDetalle.Columns.Add("cantidad", GetType(Double))
        DtDetalle.Columns.Add("idpremixero", GetType(Integer))
        DtDetalle.Columns.Add("premixero", GetType(String))
        DtDetalle.Columns.Add("tipo_premixero", GetType(String))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        DtDetalle.Columns.Add("cantUnaTonelada", GetType(Double))

        dtgListadoInsumos.DataSource = DtDetalle
        dtgListadoInsumos.DisplayLayout.Bands(0).Columns("codprod").Hidden = True
        dtgListadoInsumos.DisplayLayout.Bands(0).Columns("idpremixero").Hidden = True
        dtgListadoInsumos.DisplayLayout.Bands(0).Columns("cantUnaTonelada").Hidden = True
    End Sub

    Private Sub dtgListadoInsumos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListadoInsumos.InitializeLayout
        Try
            Formato_Tablas_Grid_AsignarFormula(dtgListadoInsumos)
            dtgListadoInsumos.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = ""
                .Columns(0).Width = 20

                .Columns(2).Header.Caption = "Producto"
                .Columns(2).Width = 200

                .Columns(3).Header.Caption = "Cantidad"
                .Columns(3).Width = 80

                .Columns(5).Header.Caption = "Premixero"
                .Columns(5).Width = 200

                .Columns(6).Header.Caption = "Tipo"
                .Columns(6).Width = 80

                .Columns(7).Header.Caption = "Eliminar"
                .Columns(7).Width = 40
                .Columns(7).Style = ColumnStyle.Button
                .Columns(7).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(7).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListadoInsumos_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListadoInsumos.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE INSUMO?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetalle.Rows.RemoveAt(rowIndex)
                DtDetalle.AcceptChanges()
                dtgListadoInsumos.DataSource = DtDetalle
                calcularCantidadTipoPremixero()
                lblTotal.Text = ObtenerSumaCantidadTotal().ToString("N3")
            End If
        End If
    End Sub

    Public Sub AgregarInsumos(detalleInsumos As DataTable)
        Dim tiposConConflicto As New HashSet(Of String)
        Dim premixerosExistentes As New HashSet(Of String)
        Dim alertaMostradaPremixero As Boolean = False

        For Each detalleRow As DataRow In DtDetalle.Rows
            Dim premixeroExistente As String = detalleRow("premixero").ToString()
            If Not premixerosExistentes.Contains(premixeroExistente) Then
                premixerosExistentes.Add(premixeroExistente)
            End If
        Next

        For Each row As DataRow In detalleInsumos.Rows
            Dim nuevoTipo As String = row("tipo").ToString()
            Dim nuevoPremixero As String = row("premixero").ToString()

            Dim existeConflictoTipo As Boolean = False
            Dim existeConflictoPremixero As Boolean = False

            For Each detalleRow As DataRow In DtDetalle.Rows
                Dim tipoExistente As String = detalleRow("tipo_premixero").ToString()
                Dim premixeroExistente As String = detalleRow("premixero").ToString()

                If tipoExistente = nuevoTipo AndAlso premixeroExistente <> nuevoPremixero Then
                    existeConflictoTipo = True
                    Exit For
                End If
            Next

            If premixerosExistentes.Contains(nuevoPremixero) Then
                existeConflictoPremixero = True
            End If

            If Not existeConflictoTipo AndAlso Not existeConflictoPremixero Then
                DtDetalle.Rows.Add("-", row("codprod"), row("producto"), row("cantidad"), row("idPremixero"), nuevoPremixero, nuevoTipo, "", row("cantUnaTonelada"))
            ElseIf existeConflictoTipo AndAlso Not tiposConConflicto.Contains(nuevoTipo) Then
                msj_advert("El tipo " & nuevoTipo & " ya está asignado a otro premixero. No puede asignarse a otro premixero.")
                tiposConConflicto.Add(nuevoTipo)
            ElseIf existeConflictoPremixero AndAlso Not alertaMostradaPremixero Then
                msj_advert("El premixero " & nuevoPremixero & " ya ha sido asignado previamente. No puede asignarse nuevamente.")
                alertaMostradaPremixero = True
            End If
        Next
        ObtenerListaIdsInsumos()
        listaDiferencia = listaIdsInsumos.Except(listaIdsInsumosFormula).ToList()

        For Each fila As UltraGridRow In dtgListadoInsumos.Rows
            Dim tipoPremixero As String = fila.Cells(6).Value.ToString()
            Dim codprod As Integer = CInt(fila.Cells("codprod").Value)
            Dim producto As String = fila.Cells("producto").Value.ToString().ToLower().Replace("í", "i")

            Select Case tipoPremixero
                Case "PREMIXERO 1", "PREMIXERO 2"
                    fila.Cells(0).Appearance.BackColor = Color.FromArgb(13, 242, 5)
                    fila.Cells(0).Appearance.ForeColor = Color.FromArgb(13, 242, 5)
                Case "PREMIXERO 3"
                    fila.Cells(0).Appearance.BackColor = Color.FromArgb(37, 113, 128)
                    fila.Cells(0).Appearance.ForeColor = Color.FromArgb(37, 113, 128)
                Case Else
                    fila.Cells(0).Appearance.BackColor = Color.Transparent
                    fila.Cells(0).Appearance.ForeColor = Color.Black
            End Select

            If listaDiferencia.Contains(codprod) Then
                If producto.Contains("maiz") Then
                    fila.Cells(0).Appearance.BackColor = Color.FromArgb(37, 113, 128)
                    fila.Cells(0).Appearance.ForeColor = Color.FromArgb(37, 113, 128)
                Else
                    fila.Cells(0).Appearance.BackColor = Color.Red
                    fila.Cells(0).Appearance.ForeColor = Color.Red
                End If
            End If
        Next

        calcularCantidadTipoPremixero()
        dtgListadoInsumos.DataSource = DtDetalle
        DtDetalle.AcceptChanges()
    End Sub

    Public Function ObtenerPremixerosUnicos(dt As DataTable) As DataTable
        Dim dtUnicos As New DataTable
        dtUnicos.Columns.Add("idpremixero", GetType(Integer))
        dtUnicos.Columns.Add("premixero", GetType(String))
        dtUnicos.Columns.Add("tipo_premixero", GetType(String))

        Dim hashPremixeros As New HashSet(Of String)

        For Each row As DataRow In dt.Rows
            Dim key As String = row("idpremixero").ToString() & "-" & row("premixero").ToString() & "-" & row("tipo_premixero").ToString()

            If Not hashPremixeros.Contains(key) Then
                dtUnicos.Rows.Add(row("idpremixero"), row("premixero"), row("tipo_premixero"))
                hashPremixeros.Add(key)
            End If
        Next

        Return dtUnicos
    End Function

    Private Sub txtNumPremixero_KeyPress(sender As Object, e As KeyPressEventArgs)
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub dtgListadoRacionesFormula_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dtgListadoRacionesFormula.InitializeRow
        Dim column As UltraGridColumn = dtgListadoRacionesFormula.DisplayLayout.Bands(0).Columns("Asignar")
        Dim columnClonar As UltraGridColumn = dtgListadoRacionesFormula.DisplayLayout.Bands(0).Columns("Clonar Asig.")
        column.Style = ColumnStyle.Button
        columnClonar.Style = ColumnStyle.Button
        column.ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
        columnClonar.ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
        If Not e.ReInitialize Then
            e.Row.Cells("Asignar").Value = "Asignar"
            e.Row.Cells("Asignar").Appearance.TextHAlign = HAlign.Center

            e.Row.Cells("Clonar Asig.").Value = "Clonar"
            e.Row.Cells("Clonar Asig.").Appearance.TextHAlign = HAlign.Center
        End If
    End Sub

    Private Sub dtgListadoRacionesFormula_ClickCellButton(sender As Object, e As CellEventArgs) Handles dtgListadoRacionesFormula.ClickCellButton
        Try
            With dtgListadoRacionesFormula
                If (e.Cell.Column.Key = "Asignar") Then
                    Dim filaSeleccionada As Integer = e.Cell.Row.Index
                    mombreRacion = .Rows(filaSeleccionada).Cells(1).Value.ToString()

                    If .Rows(filaSeleccionada).Cells(2).Value.ToString() = "ASIGNADO" Then
                        msj_advert("La ración seleccionada ya ha sido asignada")
                        Return
                    ElseIf (txtPreparacion.Text = "" OrElse txtPreparacion.Text.Length = 0) Then
                        msj_advert("Ingrese el diseño de preparación (TN)")
                        Return
                    ElseIf (CDec(txtPreparacion.Text) = 0) Then
                        msj_advert("El diseño de preparación no puede ser 0")
                        Return
                    End If

                    ugbRacion.Text = "ASIGNACIÓN DE INSUMOS: " & mombreRacion
                    idNucleo = CInt(.Rows(filaSeleccionada).Cells(0).Value)
                    lblCantidadSacos.Text = CDec(txtPreparacion.Text) * 2
                    For Each fila As UltraGridRow In dtgListadoRacionesFormula.Rows
                        If fila.Index <> filaSeleccionada Then
                            fila.Activation = Activation.Disabled
                            fila.Cells(2).Appearance.BackColor = Color.LightGray
                        End If
                    Next

                    btnGuardarAsignacion.Enabled = True
                    btnCancelar.Enabled = True
                    btnAsignarInsumo.Enabled = True
                    btnAsignarNucleo.Enabled = True
                    btnVisualizarAsignacion.Enabled = True
                    'btnAsignarPlus.Enabled = True
                    txtPreparacion.Enabled = False
                    lblPremixeroNucleo.Text = "-"
                    lblTipoPremixeroNucleo.Text = "-"

                    dtgListadoRacionesFormula.DisplayLayout.Override.SelectTypeRow = SelectType.None
                End If

                If (e.Cell.Column.Key = "Clonar Asig.") Then
                    Dim filaSeleccionada As Integer = e.Cell.Row.Index
                    Dim idRacion As Integer = CInt(.Rows(filaSeleccionada).Cells(0).Value)

                    If .Rows(filaSeleccionada).Cells(2).Value.ToString() = "ASIGNADO" Then
                        msj_advert("La ración seleccionada ya ha sido asignada")
                        Return
                    End If

                    If (MessageBox.Show("¿ESTÁ SEGURO DE CLONAR LA ASIGNACIÓN DE ESTA RACIÓN DE PREMIXEROS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    Dim obj As New coControlFormulacion With {
                        .IdFormulaBase = idFormula,
                        .IdNucleo = idRacion
                    }

                    Dim MensajeBgWk As String = cn.Cn_ClonarAsignacionPremixeroRacion(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(MensajeBgWk)
                        Dispose()
                    Else
                        msj_advert(MensajeBgWk)
                    End If
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            If CType(dtgListadoRacionesFormula.DataSource, DataTable).Rows.Count > 0 Then
                Dim result As DialogResult = MessageBox.Show("EXISTEN REGISTROS ASIGNADOS. ¿ESTÁ SEGURO DE QUE DESEA CANCELAR LA ASIGNACIÓN DE INSUMOS?", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.No Then
                    Return
                End If
            End If

            InicializarValores()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub InicializarValores()
        For Each fila As UltraGridRow In dtgListadoRacionesFormula.Rows
            fila.Activation = Activation.AllowEdit

            If fila.Cells(2).Value.ToString() = "ASIGNADO" Then
                fila.Cells(2).Appearance.BackColor = Color.Green
            Else
                fila.Cells(2).Appearance.BackColor = Color.Orange
            End If
        Next

        ugbRacion.Text = "ASIGNACIÓN DE INSUMOS"

        btnGuardarAsignacion.Enabled = False
        btnCancelar.Enabled = False
        btnAsignarInsumo.Enabled = False
        btnAsignarNucleo.Enabled = False
        'btnAsignarPlus.Enabled = False
        btnVisualizarAsignacion.Enabled = False
        lblTotal.Text = "0.000"
        lblPremixeroNucleo.Text = "-"
        lblTipoPremixeroNucleo.Text = "-"

        CargarTablaDetalleFormulaActual()
        CargarTablaDetalleInsumosNucleo()
        calcularCantidadTipoPremixero()

        dtgListadoRacionesFormula.DisplayLayout.Override.SelectTypeRow = SelectType.Single
    End Sub

    Private Sub btnAsignarInsumo_Click(sender As Object, e As EventArgs) Handles btnAsignarInsumo.Click
        Try
            ObtenerListaIdsInsumos()
            Dim f As New FrmAsignarInsumoPremixero With {
                .idFormulaBase = idFormula,
                .idNucleo = idNucleo,
                .cantidadPreparacion = CDbl(txtPreparacion.Text),
                .listaIdsInsumos = listaIdsInsumos,
                .Owner = Me
            }
            f.ShowDialog()

            If f.ListaInsumosRecibidos IsNot Nothing Then
                listaIdsInsumosFormula = f.ListaInsumosRecibidos
            End If

            lblTotal.Text = ObtenerSumaCantidadTotal().ToString("N3")
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnAsignarNucleo_Click(sender As Object, e As EventArgs) Handles btnAsignarNucleo.Click
        If DtDetalle Is Nothing OrElse DtDetalle.Rows.Count = 0 Then
            msj_advert("Asigne por lo menos un producto a un premixero")
            Return
        End If
        ObtenerListaIdsInsumos()
        Dim premixerosUnicos As DataTable = ObtenerPremixerosUnicos(DtDetalle)
        Dim idPremixeroSeleccionado As Integer = _CodigoAsignadoNucleo

        'para Asignar por defecto premixero 2
        For Each row As DataRow In premixerosUnicos.Rows
            If row("tipo_premixero").ToString() = "PREMIXERO 2" Then
                idPremixeroSeleccionado = CInt(row("idpremixero"))
                Exit For
            End If
        Next

        Dim f As New FrmAsignarNucleo(Me, premixerosUnicos, idPremixeroSeleccionado, idNucleo, idFormula, listaIdsInsumos)
        f.Owner = Me
        f.ShowDialog()

        Dim datosPremixero = f.ObtenerDatosPremixeroSeleccionado()
        _CodigoAsignadoNucleo = datosPremixero.Item1
        _NombreAsignadoNucleo = datosPremixero.Item2
        _TipoAsignadoNucleo = datosPremixero.Item3

        lblPremixeroNucleo.Text = _NombreAsignadoNucleo
        lblTipoPremixeroNucleo.Text = _TipoAsignadoNucleo
        lblTotal.Text = ObtenerSumaCantidadTotal().ToString("N3")
        calcularCantidadTipoPremixero()
    End Sub

    Sub CargarTablaDetalleInsumosNucleo()
        DtDetalleNucleo = New DataTable("TempDetNucleo")
        DtDetalleNucleo.Columns.Add("etiqueta", GetType(String))
        DtDetalleNucleo.Columns.Add("codprod", GetType(Integer))
        DtDetalleNucleo.Columns.Add("producto", GetType(String))
        DtDetalleNucleo.Columns.Add("cantidad", GetType(String))
        DtDetalleNucleo.Columns.Add("btneliminar", GetType(String))
        DtDetalleNucleo.Columns.Add("cantUnaTonelada", GetType(Double))
        dtgListadoInsumosNucleo.DataSource = DtDetalleNucleo
        dtgListadoInsumosNucleo.DisplayLayout.Bands(0).Columns("codprod").Hidden = True
        dtgListadoInsumosNucleo.DisplayLayout.Bands(0).Columns("cantUnaTonelada").Hidden = True
    End Sub

    Private Sub dtgListadoInsumosNucleo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListadoInsumosNucleo.InitializeLayout
        Try
            Formato_Tablas_Grid_AsignarFormula(dtgListadoInsumosNucleo)
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = ""
                .Columns(0).Width = 20

                .Columns(2).Header.Caption = "Producto"
                .Columns(2).Width = 200

                .Columns(3).Header.Caption = "Cantidad"
                .Columns(3).Width = 80

                .Columns(4).Header.Caption = "Eliminar"
                .Columns(4).Width = 40
                .Columns(4).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(4).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(4).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub PintarPrimeraColumnaNucleo()
        ObtenerListaIdsInsumos()
        Dim nuevaLista As List(Of Integer) = listaIdsInsumos.Except(listaIdsInsumosFormula).ToList()

        For Each fila As UltraGridRow In dtgListadoInsumosNucleo.Rows
            Dim codprod As Integer = CInt(fila.Cells("codprod").Value)

            If nuevaLista.Contains(codprod) Then
                fila.Cells(0).Appearance.BackColor = Color.Red
                fila.Cells(0).Appearance.ForeColor = Color.White
            Else
                fila.Cells(0).Appearance.BackColor = Color.FromArgb(255, 231, 0)
                fila.Cells(0).Appearance.ForeColor = Color.FromArgb(255, 231, 0)
            End If
        Next
    End Sub

    Private Sub dtgListadoInsumosNucleo_ClickCellButton(sender As Object, e As CellEventArgs) Handles dtgListadoInsumosNucleo.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este Producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                Dim codProducto As Integer = CInt(dtgListadoInsumosNucleo.Rows(rowIndex).Cells(1).Value)

                DtDetalleNucleo.Rows.RemoveAt(rowIndex)
                SelectedInsumos.Remove(codProducto)
                DtDetalleNucleo.AcceptChanges()
                dtgListadoInsumosNucleo.DataSource = DtDetalleNucleo
                calcularCantidadTipoPremixero()
                lblTotal.Text = ObtenerSumaCantidadTotal().ToString("N3")
            End If
        End If
    End Sub

    Private Sub btnVisualizarAsignacion_Click(sender As Object, e As EventArgs) Handles btnVisualizarAsignacion.Click
        Dim f As New FrmResumenAsignacionFormula(DtDetalle, DtDetalleNucleo) With {
            .nombrePremixero = _NombreAsignadoNucleo,
            .tipoPremixero = _TipoAsignadoNucleo
        }
        f.ShowDialog()
    End Sub

    Private Sub btnGuardarAsignacion_Click(sender As Object, e As EventArgs) Handles btnGuardarAsignacion.Click
        Try
            Dim totalMediaTonelada As Double = CDec(lblTotal.Text)

            If (DtDetalle.Rows.Count = 0) Then
                msj_advert("Ingrese un registro en la tabla de formulación")
                'ElseIf (DtDetalleNucleo.Rows.Count = 0) Then
                '    msj_advert("Ingrese un registro en la tabla de formulación de núcleo")
            Else
                For Each row As DataRow In DtDetalle.Rows
                    Dim cantidad As Decimal = 0
                    Dim cantidadStr As String = row("cantidad").ToString().Trim()

                    If String.IsNullOrEmpty(cantidadStr) OrElse Not Decimal.TryParse(cantidadStr, cantidad) OrElse cantidad <= 0 Then
                        msj_advert("No se puede asignar un producto con cantidad vacía, menor o igual a 0")
                        Return
                    End If
                Next

                For Each row As DataRow In DtDetalleNucleo.Rows
                    Dim cantidad As Decimal = 0
                    Dim cantidadStr As String = row("cantidad").ToString().Trim()

                    If String.IsNullOrEmpty(cantidadStr) OrElse Not Decimal.TryParse(cantidadStr, cantidad) OrElse cantidad <= 0 Then
                        msj_advert("No se puede asignar un producto con cantidad vacía, menor o igual a 0")
                        Return
                    End If
                Next

                Dim premixeros As New HashSet(Of String)
                For Each row As DataRow In DtDetalle.Rows
                    Dim tipoPremixero As String = row("tipo_premixero").ToString()
                    premixeros.Add(tipoPremixero)
                Next

                If premixeros.Count < 3 Then
                    msj_advert("Debe asignar al menos un producto de cada tipo de premixero")
                    Return
                End If

                If totalMediaTonelada <> 500 Then
                    msj_advert("La cantidad total de la ración debe ser igual a 500 kg")
                    Return
                End If

                'If lblTipoPremixeroNucleo.Text <> "PREMIXERO 2" Then
                '    msj_advert("El núcleo debe ser asignado al PREMIXERO 2")
                '    Return
                'End If

                Dim obj As New coControlFormulacion With {
                    .Descripcion = mombreRacion,
                    .Preparacion = CDec(txtPreparacion.Text),
                    .Iduser = VP_IdUser,
                    .Estado = "PENDIENTE",
                    .IdNucleo = idNucleo,
                    .Codigo = idFormula,
                    .ListaAsignacionRacion = creacion_de_array_detalle_formula()
                }

                Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE GUARDAR ESTA ASIGNACIÓN DE INSUMO A ESTA RACIÓN?", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    Dim MensajeBgWk As String = ""

                    MensajeBgWk = cn.Cn_RegistrarAsignacionRacionxFormula(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(MensajeBgWk)
                        'InicializarValores()
                        'ListarRaciones()
                        Dispose()
                    Else
                        msj_advert(MensajeBgWk)
                    End If
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function creacion_de_array_detalle_formula() As String
        Dim array_valvulas As String = ""

        ObtenerListaIdsInsumos()
        Dim nuevaLista As List(Of Integer) = listaIdsInsumos.Except(listaIdsInsumosFormula).ToList()

        Dim preparacionFactor As Double
        If Not Double.TryParse(txtPreparacion.Text, preparacionFactor) Then preparacionFactor = 1

        If (dtgListadoInsumos.Rows.Count > 0) Then
            For i = 0 To dtgListadoInsumos.Rows.Count - 1
                If (dtgListadoInsumos.Rows(i).Cells("codprod").Value.ToString.Trim.Length <> 0) Then
                    With dtgListadoInsumos.Rows(i)
                        Dim cantidad As Decimal = 0
                        Dim codprod As Integer = CInt(.Cells("codprod").Value)
                        Dim producto As String = .Cells("producto").Value.ToString().ToLower()

                        If Decimal.TryParse(.Cells("cantUnaTonelada").Value.ToString(), cantidad) Then
                            Dim indicador As String = If(producto.Contains("maiz") OrElse Not listaDiferencia.Contains(codprod), "1", "0")
                            Dim tipoPremixero As String = .Cells("tipo_premixero").Value.ToString

                            'AQUI SE CAMBIO
                            If producto.Contains("maiz") And tipoPremixero = "PREMIXERO 2" Then
                                cantidad /= 2
                            End If

                            array_valvulas &= .Cells("idpremixero").Value.ToString & "+" &
                                         "0" & "+" &
                                         cantidad.ToString("F2") & "+" &
                                         codprod.ToString & "+" &
                                         .Cells("tipo_premixero").Value.ToString & "+" &
                                         indicador & ","
                        End If
                    End With
                End If
            Next
        End If

        If (dtgListadoInsumosNucleo.Rows.Count > 0) Then
            For i = 0 To dtgListadoInsumosNucleo.Rows.Count - 1
                If (dtgListadoInsumosNucleo.Rows(i).Cells("codprod").Value.ToString.Trim.Length <> 0) Then
                    With dtgListadoInsumosNucleo.Rows(i)
                        Dim cantidad As Decimal = 0
                        Dim codprod As Integer = CInt(.Cells("codprod").Value)
                        Dim producto As String = .Cells("producto").Value.ToString().ToLower()

                        If Decimal.TryParse(.Cells("cantUnaTonelada").Value.ToString(), cantidad) Then
                            Dim indicador As String = If(producto.Contains("maiz") OrElse Not nuevaLista.Contains(codprod), "1", "0")

                            array_valvulas &= _CodigoAsignadoNucleo & "+" &
                                         "1" & "+" &
                                         cantidad.ToString("F2") & "+" &
                                         codprod.ToString & "+" &
                                         _TipoAsignadoNucleo & "+" &
                                         indicador & ","
                        End If
                    End With
                End If
            Next
        End If

        If array_valvulas.Length > 0 Then
            array_valvulas = array_valvulas.TrimEnd(","c)
        End If

        Return array_valvulas
    End Function

    Private Sub ObtenerListaIdsInsumos()
        listaIdsInsumos.Clear()

        For Each row As DataRow In DtDetalleNucleo.Rows
            Dim idProducto As Integer = CInt(row("codprod"))
            listaIdsInsumos.Add(idProducto)
        Next

        For Each row As DataRow In DtDetalle.Rows
            Dim idProducto As Integer = CInt(row("codprod"))
            listaIdsInsumos.Add(idProducto)
        Next
    End Sub

    Private Sub btnAsignarPlus_Click(sender As Object, e As EventArgs)
        Try
            ObtenerListaIdsInsumos()
            Dim f As New FrmListarEnNucleoPlus(Me) With {
                .Owner = Me,
                .listaIdsInsumos = listaIdsInsumos,
                .idNucleo = idNucleo,
                .idFormulaBase = idFormula
            }
            f.ShowDialog()
            lblTotal.Text = ObtenerSumaCantidadTotal().ToString("N3")
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListadoInsumos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtgListadoInsumos.KeyPress
        If dtgListadoInsumos.ActiveCell IsNot Nothing AndAlso dtgListadoInsumos.ActiveCell.Column.Key = "cantidad" Then
            Dim activeText As String = dtgListadoInsumos.ActiveCell.Text
            Dim pressedKey As Char = e.KeyChar
            Dim numeroInsumosEnTablaInsumoyNucleo As Integer = dtgListadoInsumos.Rows.Count + dtgListadoInsumosNucleo.Rows.Count

            If (listaIdsInsumosFormula.Count + 1) <> (numeroInsumosEnTablaInsumoyNucleo - 1) Then
                msj_advert("Realice primero al distribución de todos los insumos")
                dtgListadoInsumos.ActiveCell.Value = 0
                e.Handled = True
                Exit Sub
            End If

            If Char.IsDigit(pressedKey) OrElse pressedKey = ChrW(Keys.Back) Then
                e.Handled = False
            ElseIf pressedKey = "."c Then
                If activeText.Contains(".") Then
                    e.Handled = True
                Else
                    e.Handled = False
                End If
            Else
                e.Handled = True
            End If

            If activeText.Contains(".") Then
                Dim decimalPart As String = activeText.Split("."c)(1)
                If decimalPart.Length >= 3 AndAlso Not Char.IsControl(pressedKey) Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub dtgListadoInsumosNucleo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtgListadoInsumosNucleo.KeyPress
        If dtgListadoInsumosNucleo.ActiveCell IsNot Nothing AndAlso dtgListadoInsumosNucleo.ActiveCell.Column.Key = "cantidad" Then
            Dim activeText As String = dtgListadoInsumosNucleo.ActiveCell.Text
            Dim pressedKey As Char = e.KeyChar

            If Char.IsDigit(pressedKey) OrElse pressedKey = ChrW(Keys.Back) Then
                e.Handled = False
            ElseIf pressedKey = "."c Then
                If activeText.Contains(".") Then
                    e.Handled = True
                Else
                    e.Handled = False
                End If
            Else
                e.Handled = True
            End If

            If activeText.Contains(".") Then
                Dim decimalPart As String = activeText.Split("."c)(1)
                If decimalPart.Length >= 3 AndAlso Not Char.IsControl(pressedKey) Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub dtgListadoInsumos_CellChange(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListadoInsumos.CellChange
        If e.Cell.Column.Key = "cantidad" Then
            Dim cantidadTemporal As Double

            If String.IsNullOrWhiteSpace(e.Cell.Text) Then
                cantidadTemporal = 0
            ElseIf Double.TryParse(e.Cell.Text, cantidadTemporal) Then
                cantidadTemporal = Convert.ToDouble(e.Cell.Text)
                Dim producto As String = e.Cell.Row.Cells("Producto").Text.ToLower()

                If producto.Contains("maiz") OrElse producto.Contains("maíz") Then
                    e.Cell.Row.Cells("cantUnaTonelada").Value = cantidadTemporal * 2
                Else
                    e.Cell.Row.Cells("cantUnaTonelada").Value = cantidadTemporal / 5
                End If
            End If

            lblTotal.Text = ObtenerSumaCantidadTotalConValorTemporal(e.Cell.Row.Index, cantidadTemporal, True).ToString("N3")
            calcularCantidadTipoPremixeroConValorTemporal(cantidadTemporal, e.Cell.Row.Index, True)
        End If
    End Sub

    Private Sub dtgListadoInsumosNucleo_CellChange(sender As Object, e As CellEventArgs) Handles dtgListadoInsumosNucleo.CellChange
        If e.Cell.Column.Key = "cantidad" Then
            Dim cantidadTemporal As Double

            If String.IsNullOrWhiteSpace(e.Cell.Text) Then
                cantidadTemporal = 0
            ElseIf Double.TryParse(e.Cell.Text, cantidadTemporal) Then
                cantidadTemporal = Convert.ToDouble(e.Cell.Text)
                e.Cell.Row.Cells("cantUnaTonelada").Value = cantidadTemporal * 2
            End If

            lblTotal.Text = ObtenerSumaCantidadTotalConValorTemporal(e.Cell.Row.Index, cantidadTemporal, False).ToString("N3")
            calcularCantidadTipoPremixeroConValorTemporal(cantidadTemporal, e.Cell.Row.Index, False)
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Public Shared Sub Formato_Tablas_Grid_AsignarFormula(nombre As UltraGrid)
        Dim color_marron As Color = Color.FromArgb(84, 64, 50)
        Dim color_crema As Color = Color.FromArgb(224, 224, 224)
        Dim color_seleccion As Color = Color.FromArgb(226, 242, 167)

        'nombre.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        With nombre.DisplayLayout
            .Appearance.TextVAlign = VAlign.Middle
            .Override.AllowDelete = DefaultableBoolean.False
            .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl
            .EmptyRowSettings.ShowEmptyRows = True
            .RowConnectorColor = Color.Red
            .RowConnectorStyle = RowConnectorStyle.Dashed
            .ScrollStyle = ScrollStyle.Immediate

            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                .BackColor = color_crema
                .BackColor2 = color_crema
                .BorderColor = Color.Gainsboro
                .BorderColor2 = Color.Gainsboro
                .ForeColor = Color.Black
            End With

            With .GroupByBox
                .BorderStyle = UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .BackGradientStyle = GradientStyle.Vertical
                    .BorderColor = SystemColors.Window
                End With
            End With

            With .Override
                With .HeaderAppearance
                    .TextHAlignAsString = "Center"
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_crema
                    .BackColor2 = color_crema
                    .ForeColor = Color.Black
                End With
                With .RowAppearance
                    .BackColor = SystemColors.Window
                    .BorderColor = Color.Silver
                End With
                With .SelectedRowAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With
                With .ActiveCellAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With
                With .ActiveRowAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With
            End With
        End With

        nombre.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn

        AddHandler nombre.InitializeRow, AddressOf Grid_InitializeRow_Lista
    End Sub

    Private Shared Sub Grid_InitializeRow_Lista(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs)
        Dim formularioPadre = TryCast(e.Row.Band.Layout.Grid.FindForm(), FrmAsignarFormula)

        If formularioPadre IsNot Nothing AndAlso formularioPadre.listaIdsInsumosFormula IsNot Nothing Then
            Dim codProducto As Integer = CInt(e.Row.Cells("codprod").Value)

            If formularioPadre.listaIdsInsumosFormula.Contains(codProducto) Then
                e.Row.Activation = Activation.NoEdit
            Else
                For i As Integer = 0 To e.Row.Cells.Count - 1
                    If i = 3 Then
                        e.Row.Cells(i).Activation = Activation.AllowEdit
                    Else
                        e.Row.Cells(i).Activation = Activation.NoEdit
                    End If
                Next
            End If
        End If
    End Sub

    Public Function ObtenerSumaCantidadTotal() As Double
        Dim suma As Double = 0.0

        For Each row As DataRow In DtDetalle.Rows
            Dim tipoPremixero As String = row.Field(Of String)("tipo_premixero")
            Dim producto As String = row.Field(Of String)("producto")
            Dim cantidad As Double = If(String.IsNullOrEmpty(row("cantidad").ToString()), 0, Convert.ToDouble(row("cantidad")))

            Dim productoNormalizado As String = producto.ToLower().Replace("í", "i")

            'PRIMER CAMBIO
            If productoNormalizado.Contains("maiz") Then
                If tipoPremixero = "PREMIXERO 2" Then
                    cantidad /= 2
                End If
            End If

            If tipoPremixero = "PREMIXERO 1" OrElse tipoPremixero = "PREMIXERO 2" Then
                If productoNormalizado.Contains("maiz") Then
                    suma += cantidad
                Else
                    Dim preparacionFactor As Double = If(Double.TryParse(txtPreparacion.Text, preparacionFactor), preparacionFactor, 1)
                    suma += cantidad / (preparacionFactor * 2)
                End If
            Else
                suma += cantidad
            End If
        Next

        For Each row As DataRow In DtDetalleNucleo.Rows
            Dim cantidadNucleo As Double = If(String.IsNullOrEmpty(row("cantidad").ToString()), 0, Convert.ToDouble(row("cantidad")))
            suma += cantidadNucleo
        Next

        Return suma
    End Function

    Public Function ObtenerSumaCantidadTotalConValorTemporal(indiceFila As Integer, cantidadTemporal As Double, esDetalle As Boolean) As Double
        Dim suma As Double = 0.0

        For i As Integer = 0 To DtDetalle.Rows.Count - 1
            Dim row As DataRow = DtDetalle.Rows(i)
            Dim tipoPremixero As String = row.Field(Of String)("tipo_premixero")
            Dim producto As String = row.Field(Of String)("producto")
            Dim codprod As Integer = row.Field(Of Integer)("codprod")
            Dim cantidad As Double = If(esDetalle AndAlso i = indiceFila, cantidadTemporal, If(String.IsNullOrEmpty(row("cantidad").ToString()), 0, Convert.ToDouble(row("cantidad"))))
            Dim productoNormalizado As String = producto.ToLower().Replace("í", "i")

            Dim preparacionFactor As Double
            If Not Double.TryParse(txtPreparacion.Text, preparacionFactor) Then preparacionFactor = 1

            'PRIMER CAMBIO
            If productoNormalizado.Contains("maiz") Then
                If tipoPremixero = "PREMIXERO 2" Then
                    cantidad /= 2
                End If
            End If

            If listaDiferencia.Contains(codprod) Then
                If productoNormalizado.Contains("maiz") Then
                    suma += cantidad
                Else
                    suma += cantidad / (preparacionFactor * 2)
                End If
            ElseIf tipoPremixero = "PREMIXERO 1" OrElse tipoPremixero = "PREMIXERO 2" Then
                If productoNormalizado.Contains("maiz") Then
                    suma += cantidad
                Else
                    suma += cantidad / (preparacionFactor * 2)
                End If
            Else
                suma += cantidad
            End If
        Next

        For j As Integer = 0 To DtDetalleNucleo.Rows.Count - 1
            Dim row As DataRow = DtDetalleNucleo.Rows(j)
            Dim cantidadNucleo As Double = If(Not esDetalle AndAlso j = indiceFila, cantidadTemporal, If(String.IsNullOrEmpty(row("cantidad").ToString()), 0, Convert.ToDouble(row("cantidad"))))

            suma += cantidadNucleo
        Next

        Return suma
    End Function

    Private Sub calcularCantidadTipoPremixero()
        Dim totalPremix01 As Double = 0
        Dim totalPremix02 As Double = 0
        Dim totalPremix03 As Double = 0
        Dim tipoPremixeroNucleo As String = lblTipoPremixeroNucleo.Text

        For Each row As UltraGridRow In dtgListadoInsumos.Rows
            If Not row.IsFilterRow AndAlso Not row.IsGroupByRow Then
                Dim tipo As String = row.Cells("tipo_premixero").Value.ToString()
                Dim cantidad As Double = 0
                Dim producto As String = row.Cells("producto").Value.ToString().ToLower()
                Dim productoNormalizado As String = producto.ToLower().Replace("í", "i")
                Dim preparacionFactor As Double
                If Not Double.TryParse(txtPreparacion.Text, preparacionFactor) Then preparacionFactor = 1

                If Double.TryParse(row.Cells("cantidad").Value.ToString(), cantidad) Then


                    Select Case tipo
                        Case "PREMIXERO 1"
                            totalPremix01 += cantidad
                        Case "PREMIXERO 2"
                            'PRIMER CAMBIO
                            If productoNormalizado.Contains("maiz") Then
                                cantidad *= preparacionFactor
                            End If
                            totalPremix02 += cantidad
                        Case "PREMIXERO 3"
                            totalPremix03 += cantidad
                    End Select
                End If
            End If
        Next

        'For Each row As UltraGridRow In dtgListadoInsumosNucleo.Rows
        '    If Not row.IsFilterRow AndAlso Not row.IsGroupByRow Then
        '        Dim cantidad As Double = 0

        '        If Double.TryParse(row.Cells("cantidad").Value.ToString(), cantidad) Then
        '            Select Case tipoPremixeroNucleo
        '                Case "PREMIXERO 1"
        '                    totalPremix01 += cantidad
        '                Case "PREMIXERO 2"
        '                    totalPremix02 += cantidad
        '                Case "PREMIXERO 3"
        '                    totalPremix03 += cantidad
        '            End Select
        '        End If
        '    End If
        'Next

        lblPremix01.Text = totalPremix01.ToString("N3")
        lblPremix02.Text = totalPremix02.ToString("N3")

        LblInsumosSumatoriaP1P2.Text = (totalPremix01 + totalPremix02).ToString("N3")
    End Sub

    Private Sub calcularCantidadTipoPremixeroConValorTemporal(nuevaCantidad As Double, filaActual As Integer, esDetalle As Boolean)
        Dim totalPremix01 As Double = 0
        Dim totalPremix02 As Double = 0
        Dim totalPremix03 As Double = 0

        For Each row As UltraGridRow In dtgListadoInsumos.Rows
            If Not row.IsFilterRow AndAlso Not row.IsGroupByRow Then
                Dim tipo As String = row.Cells("tipo_premixero").Value.ToString()
                Dim cantidad As Double = 0
                Dim producto As String = row.Cells("producto").Value.ToString().ToLower()
                Dim productoNormalizado As String = producto.ToLower().Replace("í", "i")
                Dim preparacionFactor As Double
                If Not Double.TryParse(txtPreparacion.Text, preparacionFactor) Then preparacionFactor = 1

                If row.Index = filaActual AndAlso esDetalle Then
                    cantidad = nuevaCantidad
                ElseIf Double.TryParse(row.Cells("cantidad").Value.ToString(), cantidad) Then
                End If

                Select Case tipo
                    Case "PREMIXERO 1"
                        totalPremix01 += cantidad
                    Case "PREMIXERO 2"
                        If productoNormalizado.Contains("maiz") Then
                            cantidad *= preparacionFactor
                        End If
                        totalPremix02 += cantidad
                    Case "PREMIXERO 3"
                        totalPremix03 += cantidad
                End Select
            End If
        Next

        'For Each row As UltraGridRow In dtgListadoInsumosNucleo.Rows
        '    If Not row.IsFilterRow AndAlso Not row.IsGroupByRow Then
        '        Dim cantidad As Double = 0

        '        If row.Index = filaActual AndAlso Not esDetalle Then
        '            cantidad = nuevaCantidad
        '        ElseIf Double.TryParse(row.Cells("cantidad").Value.ToString(), cantidad) Then
        '        End If

        '        Select Case lblTipoPremixeroNucleo.Text
        '            Case "PREMIXERO 1"
        '                totalPremix01 += cantidad
        '            Case "PREMIXERO 2"
        '                totalPremix02 += cantidad
        '            Case "PREMIXERO 3"
        '                totalPremix03 += cantidad
        '        End Select
        '    End If
        'Next

        lblPremix01.Text = totalPremix01.ToString("N3")
        lblPremix02.Text = totalPremix02.ToString("N3")

        LblInsumosSumatoriaP1P2.Text = (totalPremix01 + totalPremix02).ToString("N3")
    End Sub
End Class