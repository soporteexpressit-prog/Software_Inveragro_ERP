Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmVerRecetaAlimento
    Dim cnControlPreparacionAlimento As New cnControlPreparacionAlimento
    Dim sumaCantidadOriginal As Decimal = 0
    Public idsDetalleAlimento As String
    Public idRacion As Integer

    Private Sub FrmVerRecetaAlimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1350, 830)
        txtPreparacion.Text = "5"
        ObtenerRecetaPorRacion()
    End Sub

    Private Sub ObtenerRecetaPorRacion()
        Try
            Dim obj As New coControlPreparacionAlimento With {
            .Codigo = idRacion,
            .ListaIdsDetalleSalida = idsDetalleAlimento
        }

            Dim resultado As Object = cnControlPreparacionAlimento.Cn_ObtenerRecetaAlimentoPremixeroPorIdRacion(obj)

            If TypeOf resultado Is String Then
                msj_advert(resultado.ToString())
                Dispose()
            Else
                Dim ds As DataSet = CType(resultado, DataSet)

                If ds.Tables.Count >= 6 Then
                    dtgListado1.DataSource = ds.Tables(3)   ' Primer tipoPremixero
                    dtgListado2.DataSource = ds.Tables(4)   ' Segundo tipoPremixero
                    dtgListado3.DataSource = ds.Tables(5)   ' Tercer tipoPremixero
                    dtgListadoExtra2.DataSource = ds.Tables(0)       ' Primer Extra
                    dtgListadoExtra1.DataSource = ds.Tables(1) ' Segundo Extra
                    dtgListadoExtra3.DataSource = ds.Tables(2)       ' Plan Medicado (MedicamentoRacion)

                    txtTitulo1.Text = "INSUMOS ASIGNADOS A " & dtgListado1.Rows(0).Cells(3).Value.ToString()
                    txtTitulo2.Text = "INSUMOS ASIGNADOS A " & dtgListado2.Rows(0).Cells(3).Value.ToString()
                    txtTitulo3.Text = "INSUMOS ASIGNADOS A " & dtgListado3.Rows(0).Cells(3).Value.ToString()

                    If dtgListadoExtra1.Rows.Count > 0 AndAlso dtgListadoExtra1.Rows(0).Cells(1).Value.ToString() <> "" Then
                        txtTituloExtra1.Text = "DETALLE INSUMOS " & dtgListadoExtra1.Rows(0).Cells(1).Value.ToString()
                    Else
                        txtTituloExtra1.Text = "NO SE ASIGNO PLAN MEDICADO"
                    End If

                    If dtgListadoExtra2.Rows.Count > 0 AndAlso dtgListadoExtra2.Rows(0).Cells(1).Value.ToString() <> "" Then
                        txtTituloExtra2.Text = "DETALLE INSUMOS " & dtgListadoExtra2.Rows(0).Cells(1).Value.ToString()
                    Else
                        txtTituloExtra2.Text = "NO SE ASIGNO INSUMOS EXTRA"
                    End If

                    If dtgListadoExtra3.Rows.Count > 0 AndAlso dtgListadoExtra3.Rows(0).Cells(1).Value.ToString() <> "" Then
                        txtTituloExtra3.Text = "DETALLE INSUMOS " & dtgListadoExtra3.Rows(0).Cells(1).Value.ToString()
                    Else
                        txtTituloExtra3.Text = "NO SE ASIGNO INSUMOS EXTRA"
                    End If
                Else
                    msj_advert("No se encontraron suficientes tablas en el resultado.")
                End If

                clsBasicas.Formato_Tablas_Grid(dtgListadoExtra1)
                clsBasicas.Formato_Tablas_Grid(dtgListadoExtra2)
                clsBasicas.Formato_Tablas_Grid(dtgListadoExtra3)

                dtgListadoExtra1.DisplayLayout.Bands(0).Columns(1).Hidden = True
                dtgListadoExtra2.DisplayLayout.Bands(0).Columns(1).Hidden = True
                dtgListadoExtra3.DisplayLayout.Bands(0).Columns(1).Hidden = True

                DividirCantidadMediaToneladaTablas(dtgListado1)
                DividirCantidadMediaToneladaTablas(dtgListado2)
                DividirCantidadMediaToneladaTablas(dtgListado3)

                lblTotal.Text = sumaCantidadOriginal.ToString("N2")
                ProcesarTablasPorPremixero()
                CalcularCantidadTipoPremixero()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub DividirCantidadMediaToneladaTablas(ByVal ultraGrid As UltraGrid)
        If ultraGrid.Rows.Count > 0 Then
            For Each row As UltraGridRow In ultraGrid.Rows
                Dim cantidadOriginal As Decimal

                If Decimal.TryParse(row.Cells("cantidad").Value.ToString(), cantidadOriginal) Then
                    row.Cells("cantidad").Value = cantidadOriginal / 2
                    sumaCantidadOriginal += row.Cells("cantidad").Value
                End If
            Next
        End If
        clsBasicas.Formato_Tablas_Grid(ultraGrid)
    End Sub

    Private Sub txtPreparacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPreparacion.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If

        If e.KeyChar = "." AndAlso txtPreparacion.Text.Contains(".") Then
            e.Handled = True
        End If

        If e.KeyChar = "." AndAlso txtPreparacion.Text.Length = 0 Then
            e.Handled = True
        End If

        If txtPreparacion.Text.Contains(".") Then
            Dim decimalPart As String = txtPreparacion.Text.Split("."c)(1)
            If decimalPart.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Sub ProcesarTablasPorPremixero()
        Try
            Dim factorPreparacion As Decimal
            If Not Decimal.TryParse(txtPreparacion.Text, factorPreparacion) Then
                Return
            End If

            ProcesarTablaPorPremixero(dtgListado1, factorPreparacion)
            ProcesarTablaPorPremixero(dtgListado2, factorPreparacion)
            ProcesarTablaPorPremixero(dtgListado3, factorPreparacion)

        Catch ex As Exception
            MsgBox("Error al procesar las tablas: " & ex.Message)
        End Try
    End Sub

    Private Sub txtPreparacion_TextChanged(sender As Object, e As EventArgs) Handles txtPreparacion.TextChanged
        Dim factorPreparacion As Decimal = 0
        If Not String.IsNullOrEmpty(txtPreparacion.Text) Then
            Decimal.TryParse(txtPreparacion.Text, factorPreparacion)
        End If

        ProcesarTablaPorPremixero(dtgListado1, factorPreparacion)
        ProcesarTablaPorPremixero(dtgListado2, factorPreparacion)
        ProcesarTablaPorPremixero(dtgListado3, factorPreparacion)
        calcularCantidadTipoPremixero()
        lblCantidadSacos.Text = (factorPreparacion * 2).ToString("N2")
    End Sub

    Sub ProcesarTablaPorPremixero(ByVal ultraGrid As UltraGrid, ByVal factorPreparacion As Decimal)
        If ultraGrid.Rows.Count > 0 Then
            Dim tipoPremixero As String = ultraGrid.Rows(0).Cells(3).Value.ToString()
            Dim esPremixero3 As Boolean = (tipoPremixero = "PREMIXERO 3")

            For Each row As UltraGridRow In ultraGrid.Rows
                Dim cantidadOriginal As Decimal
                Dim esNucleo As Boolean = Convert.ToBoolean(row.Cells("Es Núcleo").Value)

                If Decimal.TryParse(row.Cells("cantidad").Tag?.ToString(), cantidadOriginal) = False Then
                    If Decimal.TryParse(row.Cells("cantidad").Value.ToString(), cantidadOriginal) Then
                        row.Cells("cantidad").Tag = cantidadOriginal
                    End If
                End If

                If esNucleo OrElse esPremixero3 Then
                    row.Cells("cantidad").Value = cantidadOriginal
                Else
                    row.Cells("cantidad").Value = cantidadOriginal * factorPreparacion
                End If
            Next
        End If
    End Sub

    Private Sub CalcularCantidadTipoPremixero()
        Dim totalPremix01 As Decimal = 0
        Dim totalPremix02 As Decimal = 0
        Dim totalPremix03 As Decimal = 0

        totalPremix01 += SumarCantidadPorTipo(dtgListado1, "PREMIXERO 1")
        totalPremix02 += SumarCantidadPorTipo(dtgListado2, "PREMIXERO 2")
        totalPremix03 += SumarCantidadPorTipo(dtgListado3, "PREMIXERO 3")

        lblPremix01.Text = totalPremix01.ToString("N3")
        lblPremix02.Text = totalPremix02.ToString("N3")
        lblPremix03.Text = totalPremix03.ToString("N3")
    End Sub

    Private Function SumarCantidadPorTipo(ByVal ultraGrid As UltraGrid, ByVal tipoPremixero As String) As Decimal
        Dim totalCantidad As Decimal = 0

        If ultraGrid.Rows.Count > 0 AndAlso ultraGrid.Rows(0).Cells(3).Value.ToString() = tipoPremixero Then
            For Each row As UltraGridRow In ultraGrid.Rows
                Dim cantidadActual As Decimal
                If Decimal.TryParse(row.Cells("cantidad").Value.ToString(), cantidadActual) Then
                    totalCantidad += cantidadActual
                End If
            Next
        End If

        Return totalCantidad
    End Function
End Class