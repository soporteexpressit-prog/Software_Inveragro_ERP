Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmRegistrarExcedentexRacion
    Dim cnControlPreparacionAlimento As New cnControlPreparacionAlimento
    Dim cn As New cnControlFormulacion
    Dim codRacion As Integer = 0
    Dim idAntiValor As Integer = 0
    Dim codPeriodoMedicacion As Integer = 0
    Dim codPeriodoPlus As Integer = 0
    Dim valorMedicacion As String = "MEDICADO"
    Dim valorPlus As String = "PLUS"
    Dim valorTipoRacion As String = "" ' Variable de clase para guardar el tipo de ración

    ' Variables para guardar los valores originales
    Dim idAntiOriginal As Integer = 0
    Dim codPeriodoMedicacionOriginal As Integer = 0
    Dim codPeriodoPlusOriginal As Integer = 0

    ' Diccionario para guardar los valores originales de cada fila
    Private valoresOriginales As New Dictionary(Of Integer, Dictionary(Of String, Object))

    Private Sub FrmRegistrarExcedentexRacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Inicializar()
        ChkAnti.Enabled = False
        ChkAnti.Checked = False
        ChkMedicacion.Enabled = False
        ChkMedicacion.Checked = False
        ChkPlus.Enabled = False
        ChkPlus.Checked = False
        LblMedicaciones.Visible = False
        BtnBuscarMedicacion.Visible = False
        LblSeleccionadoMedicado.Visible = False
        LblPlus.Visible = False
        BtnBuscarPlus.Visible = False
        LblSeleccionadoPlus.Visible = False
        idAntiValor = 0
        codPeriodoMedicacion = 0
        codPeriodoPlus = 0
        idAntiOriginal = 0
        codPeriodoMedicacionOriginal = 0
        codPeriodoPlusOriginal = 0
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlanteles().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbUbicacion
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Public Sub LlenarCamposAlimento(codigo As Integer, descripcion As String, idAnti As Integer, idPlanMedicado As Integer, idPeriodoMedicacion As Integer, totalMedicacionesActivas As Integer, idPlus As Integer, totalPlusActivas As Integer)
        Try
            Inicializar()

            'Asignamos valores originales
            idAntiOriginal = idAnti
            codPeriodoMedicacionOriginal = idPeriodoMedicacion
            codPeriodoPlusOriginal = idPlus

            'Asignamos valores actuales
            idAntiValor = idAnti
            codPeriodoMedicacion = idPeriodoMedicacion
            codPeriodoPlus = idPlus
            codRacion = codigo
            TxtNombreRacion.Text = descripcion

            If idAnti <> 0 Then
                ChkAnti.Enabled = True
                ChkAnti.Checked = True ' Marcado por defecto si tiene valor
            Else
                ChkAnti.Enabled = False
                ChkAnti.Checked = False
            End If

            'para la medicación
            If totalMedicacionesActivas = 1 Then
                ChkMedicacion.Enabled = True
                ChkMedicacion.Checked = True ' Marcado por defecto si tiene valor
            Else
                ChkMedicacion.Enabled = False
                ChkMedicacion.Checked = False
            End If

            If totalMedicacionesActivas > 1 Then
                LblMedicaciones.Visible = True
                BtnBuscarMedicacion.Visible = True
                LblSeleccionadoMedicado.Visible = True
                ChkMedicacion.Visible = False
            Else
                LblMedicaciones.Visible = False
                BtnBuscarMedicacion.Visible = False
                LblSeleccionadoMedicado.Visible = False
                ChkMedicacion.Visible = True
            End If

            'para el plus
            If totalPlusActivas = 1 Then
                ChkPlus.Enabled = True
                ChkPlus.Checked = True ' Marcado por defecto si tiene valor
            Else
                ChkPlus.Enabled = False
                ChkPlus.Checked = False
            End If

            If totalPlusActivas > 1 Then
                LblPlus.Visible = True
                BtnBuscarPlus.Visible = True
                LblSeleccionadoPlus.Visible = True
                ChkPlus.Visible = False
            Else
                LblPlus.Visible = False
                BtnBuscarPlus.Visible = False
                LblSeleccionadoPlus.Visible = False
                ChkPlus.Visible = True
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub ActualizarMedicacionRacion(codigo As Integer, medicacionPlus As String, tipo As String)
        If tipo = "MEDICACIÓN" Then
            codPeriodoMedicacion = codigo
            codPeriodoMedicacionOriginal = codigo
            LblSeleccionadoMedicado.Visible = True
            LblSeleccionadoMedicado.Text = medicacionPlus
            valorMedicacion = medicacionPlus
        Else
            codPeriodoPlus = codigo
            codPeriodoPlusOriginal = codigo
            LblSeleccionadoPlus.Visible = True
            LblSeleccionadoPlus.Text = medicacionPlus
            valorPlus = medicacionPlus
        End If
    End Sub

    ' Evento CheckedChanged para ChkAnti
    Private Sub ChkAnti_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAnti.CheckedChanged
        Try
            If ChkAnti.Checked Then
                ' Restaurar valor original
                idAntiValor = idAntiOriginal
            Else
                ' Poner a 0
                idAntiValor = 0
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    ' Evento CheckedChanged para ChkMedicacion
    Private Sub ChkMedicacion_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMedicacion.CheckedChanged
        Try
            If ChkMedicacion.Checked Then
                ' Restaurar valor original
                codPeriodoMedicacion = codPeriodoMedicacionOriginal
            Else
                ' Poner a 0
                codPeriodoMedicacion = 0
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    ' Evento CheckedChanged para ChkPlus
    Private Sub ChkPlus_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPlus.CheckedChanged
        Try
            If ChkPlus.Checked Then
                ' Restaurar valor original
                codPeriodoPlus = codPeriodoPlusOriginal
            Else
                ' Poner a 0
                codPeriodoPlus = 0
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscarRacion_Click(sender As Object, e As EventArgs) Handles BtnBuscarRacion.Click
        Try
            Dim frm As New FrmListaRacionesExcedente(Me) With {
                .IdUbicacionDestino = CmbUbicacion.Value
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscarMedicacion_Click(sender As Object, e As EventArgs) Handles BtnBuscarMedicacion.Click
        Try
            Dim frm As New FrmListaMedicacionesExcedente(Me) With {
                .idRacion = codRacion,
                .idUbicacion = CmbUbicacion.Value,
                .tipo = "MEDICACIÓN"
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscarPlus_Click(sender As Object, e As EventArgs) Handles BtnBuscarPlus.Click
        Try
            Dim frm As New FrmListaMedicacionesExcedente(Me) With {
                .idRacion = codRacion,
                .idUbicacion = CmbUbicacion.Value,
                .tipo = "PLUS"
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCalcularInsumos_Click(sender As Object, e As EventArgs) Handles BtnCalcularInsumos.Click
        Try
            clsBasicas.Formato_Tablas_Grid_CincoUltimasColumnasEditables(dtgListadoInsumo)

            ' Validar que se haya seleccionado una ración
            If codRacion = 0 Then
                msj_advert("Debe seleccionar una ración")
                Return
            End If

            ' Construir el tipo de ración usando los valores ACTUALES según los checkboxes
            valorTipoRacion = ObtenerTipoRacion()

            ' Crear objeto con los parámetros según el estado de los checkboxes
            Dim idAntiActual As Integer = If(ChkAnti.Checked, idAntiValor, 0)
            Dim codMedicacionActual As Integer = If(ChkMedicacion.Checked, codPeriodoMedicacion, 0)
            Dim codPlusActual As Integer = If(ChkPlus.Checked, codPeriodoPlus, 0)

            Dim obj As New coControlFormulacion With {
                .IdNucleo = codRacion,
                .Tipo = valorTipoRacion,
                .IdNutricionista = 1,
                .IdPeriodoMedicion = codMedicacionActual,
                .IdPeriodoPlus = codPlusActual
            }

            ' Llamar a la consulta
            Dim resultado As Object = cn.Cn_ConsultarInsumosFormulaRacionUnidad(obj)

            ' Validar si el resultado es un error (String) o datos (DataTable)
            If TypeOf resultado Is String Then
                msj_advert(resultado.ToString())
                ' Limpiar el grid si hay error
                dtgListadoInsumo.DataSource = Nothing
            Else
                ' Asignar los datos al grid
                Dim dt As DataTable = CType(resultado, DataTable)
                dtgListadoInsumo.DataSource = dt

                ' Aplicar formato si hay datos
                If dt.Rows.Count > 0 Then
                    ' Ocultar las columnas de equivalencia que no son necesarias visualmente
                    dtgListadoInsumo.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
                    dtgListadoInsumo.DisplayLayout.Bands(0).Columns("Tipo de Premixero").Hidden = True
                    dtgListadoInsumo.DisplayLayout.Bands(0).Columns("Cantidad").Hidden = True
                    dtgListadoInsumo.DisplayLayout.Bands(0).Columns("idProductoEquivalencia").Hidden = True
                    dtgListadoInsumo.DisplayLayout.Bands(0).Columns("nombreProductoEquivalencia").Hidden = True
                    dtgListadoInsumo.DisplayLayout.Bands(0).Columns("equivalencia").Hidden = True

                    ' Establecer valor por defecto de TxtCantidad si está vacío
                    If String.IsNullOrWhiteSpace(TxtCantidad.Text) Then
                        TxtCantidad.Text = "1"
                    End If

                    ' Recalcular las cantidades totales con el valor actual de TxtCantidad
                    RecalcularCantidadTotal()

                    ' Guardar valores originales para funcionalidad de equivalencia
                    GuardarValoresOriginales()
                End If
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    ' Método para obtener el tipo de ración según los checkboxes
    Private Function ObtenerTipoRacion() As String
        Dim valorTipo As String = ""
        Dim idAntiActual As Integer = If(ChkAnti.Checked, idAntiValor, 0)
        Dim codMedicacionActual As Integer = If(ChkMedicacion.Checked, codPeriodoMedicacion, 0)
        Dim codPlusActual As Integer = If(ChkPlus.Checked, codPeriodoPlus, 0)

        If idAntiActual <> 0 Then
            If codMedicacionActual <> 0 Then
                If codPlusActual <> 0 Then
                    valorTipo = "ANTI-" & valorMedicacion & "-" & valorPlus
                Else
                    valorTipo = "ANTI-" & valorMedicacion
                End If
            Else
                If codPlusActual <> 0 Then
                    valorTipo = "ANTI-" & valorPlus
                Else
                    valorTipo = "ANTI"
                End If
            End If
        Else
            If codMedicacionActual <> 0 Then
                If codPlusActual <> 0 Then
                    valorTipo = valorMedicacion & "-" & valorPlus
                Else
                    valorTipo = valorMedicacion
                End If
            Else
                If codPlusActual <> 0 Then
                    valorTipo = valorPlus
                Else
                    valorTipo = "NORMAL"
                End If
            End If
        End If

        Return valorTipo
    End Function

    ' Método para recalcular la columna [Cantidad Total]
    Private Sub RecalcularCantidadTotal()
        Try
            If dtgListadoInsumo.DataSource Is Nothing Then
                Return
            End If

            ' Obtener el multiplicador del TextBox (mínimo 1)
            Dim multiplicador As Decimal = 1

            ' Si el texto está vacío o solo es un punto, no hacer nada (dejar que el usuario termine de escribir)
            If String.IsNullOrWhiteSpace(TxtCantidad.Text) OrElse TxtCantidad.Text = "." OrElse TxtCantidad.Text = "0." Then
                Return
            End If

            If IsNumeric(TxtCantidad.Text) Then
                multiplicador = CDec(TxtCantidad.Text)
                ' Permitir cualquier valor positivo, no forzar mínimo de 1
                If multiplicador <= 0 Then
                    Return ' No hacer nada si es 0 o negativo
                End If
            Else
                Return ' No hacer nada si no es numérico
            End If

            ' Recalcular cada fila usando el grid directamente para respetar equivalencias
            For Each row As UltraGridRow In dtgListadoInsumo.Rows
                If Not row.IsFilteredOut Then
                    If Not IsDBNull(row.Cells("Cantidad").Value) AndAlso IsNumeric(row.Cells("Cantidad").Value) Then
                        Dim cantidadBase As Decimal = CDec(row.Cells("Cantidad").Value)
                        row.Cells("Cantidad Total").Value = Math.Round(cantidadBase * multiplicador, 2)
                    End If
                End If
            Next

            ' Refrescar el grid
            dtgListadoInsumo.Refresh()

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    ' Evento TextChanged para TxtCantidad
    Private Sub TxtCantidad_TextChanged(sender As Object, e As EventArgs) Handles TxtCantidad.TextChanged
        Try
            ' Solo recalcular si hay datos en el grid
            If dtgListadoInsumo.DataSource IsNot Nothing AndAlso dtgListadoInsumo.Rows.Count > 0 Then
                RecalcularCantidadTotal()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    ' Validar que solo se ingresen números decimales en TxtCantidad
    Private Sub TxtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidad.KeyPress
        ' Obtener el TextBox
        Dim textBox As TextBox = CType(sender, TextBox)

        ' Permitir control keys (backspace, delete, etc.)
        If Char.IsControl(e.KeyChar) Then
            Return
        End If

        ' Permitir números
        If Char.IsDigit(e.KeyChar) Then
            Return
        End If

        ' Permitir punto decimal
        If e.KeyChar = "."c Then
            ' Si ya tiene un punto, no permitir otro
            If textBox.Text.Contains(".") Then
                e.Handled = True
                Return
            End If

            ' Si el texto está vacío, agregar automáticamente "0." antes del punto
            If String.IsNullOrWhiteSpace(textBox.Text) Then
                textBox.Text = "0."
                textBox.SelectionStart = textBox.Text.Length
                e.Handled = True
                Return
            End If

            ' Permitir el punto en cualquier otra posición
            Return
        End If

        ' Bloquear cualquier otro carácter
        e.Handled = True
    End Sub

    ' Guardar los valores originales de cada fila al cargar
    Private Sub GuardarValoresOriginales()
        Try
            valoresOriginales.Clear()

            For Each row As UltraGridRow In dtgListadoInsumo.Rows
                If Not row.IsFilteredOut Then
                    Dim rowIndex As Integer = row.Index
                    Dim valores As New Dictionary(Of String, Object)

                    valores.Add("idProducto", row.Cells("idProducto").Value)
                    valores.Add("Nombre del Producto", row.Cells("Nombre del Producto").Value)
                    valores.Add("Cantidad", row.Cells("Cantidad").Value)
                    valores.Add("Cantidad Total", row.Cells("Cantidad Total").Value)
                    valores.Add("idProductoEquivalencia", row.Cells("idProductoEquivalencia").Value)
                    valores.Add("nombreProductoEquivalencia", row.Cells("nombreProductoEquivalencia").Value)
                    valores.Add("equivalencia", row.Cells("equivalencia").Value)

                    valoresOriginales.Add(rowIndex, valores)
                End If
            Next
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    ' Evento que se dispara cuando cambia el valor de una celda
    Private Sub dtgListadoInsumo_CellChange(sender As Object, e As CellEventArgs) Handles dtgListadoInsumo.CellChange
        Try
            ' Verificar que sea la columna "Utilizar Eq."
            If e.Cell.Column.Key = "Utilizar Eq." Then
                ' Forzar salida del modo edición para obtener el valor actualizado
                dtgListadoInsumo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)

                Dim row As UltraGridRow = e.Cell.Row
                ' Obtener el valor DESPUÉS del cambio
                Dim utilizarEquivalencia As Boolean = CBool(e.Cell.Value)

                AplicarEquivalencia(row, utilizarEquivalencia)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    ' Aplicar o revertir la equivalencia según el estado del checkbox
    Private Sub AplicarEquivalencia(row As UltraGridRow, utilizarEquivalencia As Boolean)
        Try
            Dim rowIndex As Integer = row.Index

            If Not valoresOriginales.ContainsKey(rowIndex) Then
                Return
            End If

            Dim valoresOriginalesRow As Dictionary(Of String, Object) = valoresOriginales(rowIndex)

            If utilizarEquivalencia Then
                ' VALIDAR TIPO DE PREMIXERO ANTES DE APLICAR EQUIVALENCIA
                Dim tipoPremixero As String = row.Cells("Tipo de Premixero").Value?.ToString()

                If String.IsNullOrEmpty(tipoPremixero) OrElse tipoPremixero.Trim().ToUpper() <> "PREMIXERO 3" Then
                    msj_advert("Solo se puede utilizar equivalencia para productos de tipo PREMIXERO 3")
                    row.Cells("Utilizar Eq.").Value = False
                    Return
                End If

                ' MARCAR CHECK: Aplicar equivalencia
                Dim idProductoEq As Object = valoresOriginalesRow("idProductoEquivalencia")
                Dim nombreProductoEq As Object = valoresOriginalesRow("nombreProductoEquivalencia")
                Dim equivalencia As Object = valoresOriginalesRow("equivalencia")

                If IsDBNull(idProductoEq) OrElse IsDBNull(nombreProductoEq) OrElse IsDBNull(equivalencia) OrElse
                   String.IsNullOrEmpty(idProductoEq?.ToString()) OrElse
                   String.IsNullOrEmpty(nombreProductoEq?.ToString()) OrElse
                   CDec(equivalencia) = 0 Then

                    msj_advert("No hay producto de equivalencia disponible para este insumo")
                    row.Cells("Utilizar Eq.").Value = False
                    Return
                End If

                ' Cambiar a producto equivalente
                row.Cells("idProducto").Value = idProductoEq
                row.Cells("Nombre del Producto").Value = nombreProductoEq

                ' Obtener multiplicador actual de TxtCantidad
                Dim multiplicador As Decimal = 1
                If Not String.IsNullOrWhiteSpace(TxtCantidad.Text) AndAlso IsNumeric(TxtCantidad.Text) Then
                    multiplicador = CDec(TxtCantidad.Text)
                    If multiplicador <= 0 Then
                        multiplicador = 1
                    End If
                End If

                Dim cantidadOriginal As Decimal = CDec(valoresOriginalesRow("Cantidad"))
                Dim factorEquivalencia As Decimal = CDec(equivalencia)
                Dim nuevaCantidad As Decimal = cantidadOriginal / factorEquivalencia

                row.Cells("Cantidad").Value = Math.Round(nuevaCantidad, 2)
                row.Cells("Cantidad Total").Value = Math.Round(nuevaCantidad * multiplicador, 2)
            Else
                ' DESMARCAR CHECK: Revertir a valores originales
                row.Cells("idProducto").Value = valoresOriginalesRow("idProducto")
                row.Cells("Nombre del Producto").Value = valoresOriginalesRow("Nombre del Producto")
                row.Cells("Cantidad").Value = valoresOriginalesRow("Cantidad")

                ' Recalcular Cantidad Total con el multiplicador actual
                Dim multiplicador As Decimal = 1
                If Not String.IsNullOrWhiteSpace(TxtCantidad.Text) AndAlso IsNumeric(TxtCantidad.Text) Then
                    multiplicador = CDec(TxtCantidad.Text)
                    If multiplicador <= 0 Then
                        multiplicador = 1
                    End If
                End If

                Dim cantidadOriginal As Decimal = CDec(valoresOriginalesRow("Cantidad"))
                row.Cells("Cantidad Total").Value = Math.Round(cantidadOriginal * multiplicador, 2)
            End If

            ' Refrescar la fila
            row.Refresh()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListadoInsumo_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListadoInsumo.InitializeLayout
        Try
            If (dtgListadoInsumo.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListadoInsumo, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            dtgListadoInsumo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)

            ' Validar que se haya seleccionado una ración
            If codRacion = 0 Then
                msj_advert("Debe seleccionar una ración")
                Return
            End If

            ' Validar que se haya calculado los insumos
            If dtgListadoInsumo.DataSource Is Nothing OrElse dtgListadoInsumo.Rows.Count = 0 Then
                msj_advert("Debe calcular los insumos antes de guardar")
                Return
            End If

            ' Validar que TxtCantidad tenga un valor válido
            If String.IsNullOrWhiteSpace(TxtCantidad.Text) OrElse Not IsNumeric(TxtCantidad.Text) Then
                msj_advert("Debe ingresar una cantidad válida")
                TxtCantidad.Focus()
                Return
            End If

            Dim cantidadDecimal As Decimal = CDec(TxtCantidad.Text)
            If cantidadDecimal <= 0 Then
                msj_advert("La cantidad debe ser mayor a 0")
                TxtCantidad.Focus()
                Return
            End If

            If DtpFecha.Value.Date > Now.Date Then
                msj_advert("La fecha no puede ser mayor a la actual")
                Return
            End If

            If Not MsgBox("¿ESTÁ SEGURO DE REGISTRAR LA SALIDA DE INSUMOS POR EXCEDENTE?", MsgBoxStyle.YesNo Or MsgBoxStyle.Information, "Salida de Insumos") = MsgBoxResult.Yes Then
                Return
            End If

            Dim obj As New coControlPreparacionAlimento With {
                .Codigo = codRacion,
                .IdUsuario = VP_IdUser,
                .IdUbicacion = 6,
                .IdUbicacionDestino = CmbUbicacion.Value,
                .ListaInsumoPreparacion = InsumosNecesariosRacionString(),
                .Fecha = DtpFecha.Value,
                .Cantidad = cantidadDecimal,
                .Tipo = valorTipoRacion
            }

            Dim MensajeBgWk As String = cnControlPreparacionAlimento.Cn_RegistrarSalidaInsumosExcedente(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Dispose()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function InsumosNecesariosRacionString() As String
        Dim resultados As New List(Of String)

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListadoInsumo.Rows
            If Not row.IsFilteredOut Then
                ' Verificar que la columna "Incluir" exista y esté marcada
                If row.Cells.Exists("Incluir") AndAlso TypeOf row.Cells("Incluir").Value Is Boolean Then
                    Dim incluir As Boolean = CBool(row.Cells("Incluir").Value)

                    ' Solo agregar si el checkbox está marcado
                    If incluir Then
                        Dim total As String = row.Cells("Cantidad Total").Value.ToString()
                        Dim insumo As String = row.Cells("idProducto").Value.ToString()
                        resultados.Add($"{total}+{insumo}")
                    End If
                End If
            End If
        Next

        Return String.Join(",", resultados)
    End Function

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class