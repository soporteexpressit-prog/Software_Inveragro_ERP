Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRegistrarExcedentexRacion
    Dim cn As New cnControlFormulacion
    Dim codRacion As Integer = 0
    Dim idAntiValor As Integer = 0
    Dim codPeriodoMedicacion As Integer = 0
    Dim codPeriodoPlus As Integer = 0
    Dim valorMedicacion As String = "MEDICADO"
    Dim valorPlus As String = "PLUS"

    ' Variables para guardar los valores originales
    Dim idAntiOriginal As Integer = 0
    Dim codPeriodoMedicacionOriginal As Integer = 0
    Dim codPeriodoPlusOriginal As Integer = 0

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
            ' Validar que se haya seleccionado una ración
            If codRacion = 0 Then
                msj_advert("Debe seleccionar una ración")
                Return
            End If

            ' Construir el tipo de ración usando los valores ACTUALES según los checkboxes
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

            ' Crear objeto con los parámetros según el estado de los checkboxes
            Dim obj As New coControlFormulacion With {
                .IdNucleo = codRacion,
                .Tipo = valorTipo,
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
                    ' Ocultar la primera columna (índice 0)
                    dtgListadoInsumo.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
                    dtgListadoInsumo.DisplayLayout.Bands(0).Columns("Tipo de Premixero").Hidden = True

                    clsBasicas.Formato_Tablas_Grid(dtgListadoInsumo)

                    ' Establecer valor por defecto de TxtCantidad si está vacío
                    If String.IsNullOrWhiteSpace(TxtCantidad.Text) Then
                        TxtCantidad.Text = "1"
                    End If

                    ' Recalcular las cantidades totales con el valor actual de TxtCantidad
                    RecalcularCantidadTotal()
                End If
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    ' Método para recalcular la columna [Cantidad Total]
    Private Sub RecalcularCantidadTotal()
        Try
            If dtgListadoInsumo.DataSource Is Nothing Then
                Return
            End If

            Dim dt As DataTable = CType(dtgListadoInsumo.DataSource, DataTable)

            ' Validar que existan las columnas necesarias
            If Not dt.Columns.Contains("Cantidad") OrElse Not dt.Columns.Contains("Cantidad Total") Then
                Return
            End If

            ' Obtener el multiplicador del TextBox (mínimo 1)
            Dim multiplicador As Decimal = 1
            If Not String.IsNullOrWhiteSpace(TxtCantidad.Text) AndAlso IsNumeric(TxtCantidad.Text) Then
                multiplicador = CDec(TxtCantidad.Text)
                If multiplicador < 1 Then
                    multiplicador = 1
                    TxtCantidad.Text = ""
                End If
            Else
                TxtCantidad.Text = ""
            End If

            ' Recalcular cada fila
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row("Cantidad")) AndAlso IsNumeric(row("Cantidad")) Then
                    Dim cantidadBase As Decimal = CDec(row("Cantidad"))
                    row("Cantidad Total") = Math.Round(cantidadBase * multiplicador, 2)
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
        clsBasicas.ValidarDecimalEstricto(sender, e)
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

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class