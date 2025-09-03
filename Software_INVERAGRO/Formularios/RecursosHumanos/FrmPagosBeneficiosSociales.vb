Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.ComponentModel

Public Class FrmPagosBeneficiosSociales
    Dim cn As New cnIngreso
    Dim tbtmp As New DataTable
    Public idpago As Integer = 0
    Public operacion As Integer = 0
    Private ultimaFechaValida As Date = Date.Today
    Private Sub FrmPagosBeneficiosSociales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cbxperiodo.SelectedIndex = 0
            Consultar()
            ultimaFechaValida = dtpFechapago.Value
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            ActualizarRangoFechas()
            checkcts.Checked = True
            ConfigurarColumnaEditableUltraGrid()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ConfigurarColumnaEditableUltraGrid()
        Try
            ' Permitir edición en la grilla
            dtgListado.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True

            For i As Integer = 0 To dtgListado.DisplayLayout.Bands(0).Columns.Count - 1
                If i = 7 Then
                    With dtgListado.DisplayLayout.Bands(0).Columns(i)
                        .CellActivation = Activation.AllowEdit
                        .Style = ColumnStyle.Double
                        .MaskInput = "nnnnnnnn.nn"
                        .CellAppearance.TextHAlign = HAlign.Right
                    End With
                Else
                    dtgListado.DisplayLayout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error al configurar columna editable: " & ex.Message)
        End Try
    End Sub

    Sub Consultar()
        Dim obj As New coIngreso With {
                .Codigo = idpago,
                .Fechadesde = dtpFechapago.Value
}
        If checkgrati.Checked Then
            dtgListado.DataSource = cn.Cn_ReportePagosGratificacionpagos(obj).Copy
        ElseIf checkcts.Checked Then
            dtgListado.DataSource = cn.Cn_ReportePagosCtsPagos(obj).Copy
        Else
            '  msj_advert("Debe seleccionar un tipo de pago (Gratificación o CTS).")
        End If
        ConfigurarColumnaEditableUltraGrid()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Consultar()
    End Sub

    Private Sub checkcts_CheckedChanged(sender As Object, e As EventArgs) Handles checkcts.CheckedChanged
        RemoveHandler checkgrati.CheckedChanged, AddressOf checkgrati_CheckedChanged
        If checkcts.Checked Then
            checkgrati.Checked = False
            operacion = 1
            ActualizarRangoFechas()
            AddHandler checkgrati.CheckedChanged, AddressOf checkgrati_CheckedChanged
            Consultar()
        Else
            checkgrati.Checked = True
        End If

    End Sub

    Private Sub checkgrati_CheckedChanged(sender As Object, e As EventArgs) Handles checkgrati.CheckedChanged
        RemoveHandler checkcts.CheckedChanged, AddressOf checkcts_CheckedChanged
        If checkgrati.Checked Then
            checkcts.Checked = False
            operacion = 2
            ActualizarRangoFechas()
            AddHandler checkcts.CheckedChanged, AddressOf checkcts_CheckedChanged
            Consultar()
        Else
            checkcts.Checked = True
        End If
    End Sub
    Private Sub ActualizarRangoFechas()
        Dim minFecha As Date
        Dim maxFecha As Date
        Dim anioActual As Integer = Date.Today.Year
        Dim esPrimerPeriodo As Boolean = (cbxperiodo.SelectedIndex = 0)

        If checkcts.Checked Then
            If esPrimerPeriodo Then
                minFecha = New Date(anioActual, 5, 1)
                maxFecha = New Date(anioActual, 5, 15)
            Else
                minFecha = New Date(anioActual, 11, 1)
                maxFecha = New Date(anioActual, 11, 15)
            End If
        ElseIf checkgrati.Checked Then
            If esPrimerPeriodo Then
                minFecha = New Date(anioActual, 7, 1)
                maxFecha = New Date(anioActual, 7, 15)
            Else
                minFecha = New Date(anioActual, 12, 1)
                maxFecha = New Date(anioActual, 12, 15)
            End If
        Else
            minFecha = Date.Today
            maxFecha = Date.Today
        End If

        ' Resetear a un rango amplio primero para evitar conflictos
        dtpFechapago.MinDate = New Date(1900, 1, 1)
        dtpFechapago.MaxDate = New Date(2100, 12, 31)

        ' Ahora asignar los valores calculados
        If minFecha <= maxFecha Then
            dtpFechapago.MinDate = minFecha
            dtpFechapago.MaxDate = maxFecha
        Else
            dtpFechapago.MinDate = Date.Today
            dtpFechapago.MaxDate = Date.Today
        End If

        ' Ajustar el valor actual si está fuera del rango
        If dtpFechapago.Value < dtpFechapago.MinDate OrElse dtpFechapago.Value > dtpFechapago.MaxDate Then
            dtpFechapago.Value = dtpFechapago.MinDate
        End If
    End Sub

    Private Sub cbxperiodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxperiodo.SelectedIndexChanged
        ActualizarRangoFechas()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        clsBasicas.Totales_Formato(dtgListado, e, 0)
        clsBasicas.SumarTotales_Formato(dtgListado, e, 7)
    End Sub
    Private Function ObtenerListaIdImporte() As String
        Dim lista As New List(Of String)
        For Each row As UltraGridRow In dtgListado.Rows
            If Not row.IsDataRow Then Continue For
            Dim idPersona As String = row.Cells(0).Value.ToString()
            Dim importe As String = row.Cells(7).Value.ToString()
            lista.Add(idPersona & "+" & importe)
        Next
        Return String.Join(", ", lista)
    End Function

    Private Sub btnGuardarRrhhCtrlasist_Click(sender As Object, e As EventArgs) Handles btnGuardarRrhhCtrlasist.Click
        Dim respuesta As DialogResult = MessageBox.Show("¿Está seguro de que desea generar los importes de pago?", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = DialogResult.Yes Then
            Dim obj As New coIngreso
            obj.Fechadesde = dtpFechapago.Value
            obj.Lista_items = ObtenerListaIdImporte()
            obj.Iduser = VariablesGlobales.VP_IdUser
            Dim mensaje As String
            If checkgrati.Checked Then
                mensaje = cn.Cn_crearsueldosbonificaciones(obj)
            Else
                mensaje = cn.Cn_crearsueldosbonificacionescts(obj)
            End If
            If obj.Coderror = 0 Then
                msj_ok(mensaje)
                Dispose() ' Refresca la grilla si fue exitoso
            Else
                msj_advert(mensaje)
            End If
        End If
    End Sub
End Class